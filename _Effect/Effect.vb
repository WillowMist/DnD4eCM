Public Class Effect
    Inherits EffectBase

    ' Effect data
    Public sTargetHandle, sSourceHandle As String
    Public nRoundTill, nEffectID, nEndInitSeq As Integer

    ' Display
    Public ReadOnly Property sDesc() As String
        Get
            Dim line As New System.Text.StringBuilder

            Select Case DurationCode
                Case Duration.SaveEnds
                    line.Append("Save Ends")
                Case Duration.TargetStart
                    line.Append("Until start of Target's round ")
                    line.Append(CStr(nRoundTill))
                Case Duration.TargetEnd
                    line.Append("Until end of Target's round ")
                    line.Append(CStr(nRoundTill))
                Case Duration.SourceStart
                    line.Append("Until start of Source's round ")
                    line.Append(CStr(nRoundTill))
                Case Duration.SourceEnd
                    line.Append("Until end of Source's round ")
                    line.Append(CStr(nRoundTill))
                Case Duration.TurnEnd
                    line.Append("Until end of Source's ")
                    If nRoundTill > 0 Then
                        line.Append("round " & CStr(nRoundTill))
                    Else
                        line.Append("surprise round")
                    End If
                Case Duration.Encounter
                    line.Append("Until the end of Encounter")
                Case Duration.Sustained
                    line.Append("Sustained")
                Case Duration.Special
                    line.Append("Special")
                Case Duration.Permanent
                    line.Append("Permanent")
                Case Else
                    line.Append("Duration unknown")
            End Select

            Return line.ToString
        End Get
    End Property

    Public ReadOnly Property bActive(ByVal nCurrentSeq As Integer) As Boolean
        Get
            If nEndInitSeq > 0 And nEndInitSeq <= nCurrentSeq Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Public Sub SetInactive(ByVal nCurrentSeq As Integer)
        nEndInitSeq = nCurrentSeq
    End Sub
    Public Sub SetActive()
        nEndInitSeq = 0
    End Sub


    ' Constructors
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByVal p_sName As String, ByVal p_nID As Integer, _
                   ByVal p_sSource As String, ByVal p_sTarget As String, _
                   ByVal p_nRoundTill As Integer, ByVal p_Dur As Duration, ByVal p_bBeneficial As Boolean, ByVal p_bHidden As Boolean)
        ClearAll()
        sName = p_sName
        nEffectID = p_nID
        sSourceHandle = p_sSource
        sTargetHandle = p_sTarget
        DurationCode = p_Dur
        nRoundTill = p_nRoundTill
        bBeneficial = p_bBeneficial
        bHidden = p_bHidden
    End Sub


    ' Clear Function
    Public Overrides Sub ClearAll()
        MyBase.ClearAll()
        sSourceHandle = ""
        sTargetHandle = ""
        nRoundTill = 0
        nEffectID = 0
        nEndInitSeq = 0
    End Sub


    ' Validity Test
    Public Overrides ReadOnly Property bValid() As Boolean
        Get
            If Not MyBase.bValid Or sSourceHandle = "" Or sTargetHandle = "" Or nEffectID = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    ' XML Import/Export
    Public Overrides Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("effect")

        MyBase.ExportXML(p_writer)

        writer.WriteElementString("sTarget", sTargetHandle)
        writer.WriteElementString("sSource", sSourceHandle)
        writer.WriteElementString("nRoundTill", CStr(nRoundTill))
        writer.WriteElementString("nEffectID", CStr(nEffectID))
        writer.WriteElementString("nEndInitSeq", CStr(nEndInitSeq))

        writer.WriteEndElement()
    End Sub
    Public Overrides Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "effect" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "effectbase" Then
                        MyBase.ImportXML(p_reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "sTarget"
                            sTargetHandle = reader.Value
                        Case "sSource"
                            sSourceHandle = reader.Value
                        Case "nRoundTill"
                            nRoundTill = Val(reader.Value)
                        Case "nEffectID"
                            nEffectID = Val(reader.Value)
                        Case "nEndInitSeq"
                            nEndInitSeq = Val(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "effect" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function

End Class
