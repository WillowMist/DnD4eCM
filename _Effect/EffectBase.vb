Public Class EffectBase
    ' Effect data
    Public sName As String
    Public bBeneficial As Boolean
    Public bHidden As Boolean

    Public DurationCode As Duration

    Enum Duration As Integer
        None = 0
        SaveEnds = 1
        TargetStart = 2
        TargetEnd = 3
        SourceStart = 4
        SourceEnd = 5
        TurnEnd = 6
        Encounter = 7
        Sustained = 8
        Special = 9
        Permanent = 10
    End Enum
    Public Sub copy(ByRef tocopy As EffectBase)
        sName = tocopy.sName
        bBeneficial = tocopy.bBeneficial
        bHidden = tocopy.bHidden
        DurationCode = tocopy.DurationCode
    End Sub
    Private sDurationText() As String = {"None", _
                                       "Save Ends", _
                                       "Start of Target's Next Turn", _
                                       "End of Target's Next Turn", _
                                       "Start of Source's Next Turn", _
                                       "End of Source's Next Turn", _
                                       "End of the Current Turn", _
                                       "End of the Encounter", _
                                       "Sustained", _
                                       "Special", _
                                       "Permanent"}


    Public Property sDuration() As String
        Get
            Return GetDurDesc(DurationCode)
        End Get
        Set(ByVal value As String)
            DurationCode = GetDurCode(value)
        End Set
    End Property

    Private Function GetDurCode(ByVal input As String) As Duration
        Dim i As Integer = 0
        For Each txt As String In sDurationText
            If txt = input Then
                Return CType(i, Duration)
            Else
                i += 1
            End If
        Next
        Return Duration.None
    End Function

    Private Function GetDurDesc(ByVal input As Duration) As String
        Return sDurationText(CInt(input))
    End Function

    Public ReadOnly Property bIsMark() As Boolean
        Get
            If sName.ToLower.StartsWith("marked") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bIsStance() As Boolean
        Get
            If sName.ToLower.StartsWith("stance") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    ' Constructors
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef eff As EffectBase)
        ClearAll()
        sName = eff.sName
        DurationCode = eff.DurationCode
        bBeneficial = eff.bBeneficial
        bHidden = eff.bHidden
    End Sub
    Public Sub New(ByVal p_sName As String, ByVal p_sDur As String, ByVal p_bBeneficial As Boolean, ByVal p_bHidden As Boolean)
        ClearAll()
        sName = p_sName
        sDuration = p_sDur
        bBeneficial = p_bBeneficial
        bHidden = p_bHidden
    End Sub

    ' Clear Function
    Public Overridable Sub ClearAll()
        sName = ""
        DurationCode = Duration.None
        bBeneficial = False
        bHidden = False
    End Sub

    Public Overridable ReadOnly Property bValid() As Boolean
        Get
            If sName = "" Or DurationCode = Duration.None Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    Public ReadOnly Property sEffectBaseID() As String
        Get
            Return sName & DurationCode & bBeneficial
        End Get
    End Property


    ' XML Import/Export
    Public Overridable Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("effectbase")

        writer.WriteElementString("name", sName)
        writer.WriteElementString("beni", CStr(bBeneficial))
        writer.WriteElementString("hidden", CStr(bHidden))
        writer.WriteElementString("durcode", CStr(DurationCode))

        writer.WriteEndElement()
    End Sub
    Public Overridable Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "effectbase" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "beni"
                            bBeneficial = CBool(reader.Value)
                        Case "hidden"
                            bHidden = CBool(reader.Value)
                        Case "durcode"
                            DurationCode = CType(reader.Value, Duration)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "effectbase" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
End Class
