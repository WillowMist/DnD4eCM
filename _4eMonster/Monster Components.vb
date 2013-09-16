Imports DnD4e_Combat_Manager.DnDLibrary

Public Class Sense
    Public sType As String
    Public nRange As Integer
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("sense")
        writer.WriteElementString("type", sType)
        writer.WriteElementString("range", nRange.ToString)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "sense" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                        Case "range"
                            nRange = CInt(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "sense" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Sense)
        sType = tocopy.sType
        nRange = tocopy.nRange
    End Sub
    Public Sub ClearAll()
        sType = ""
        nRange = 0
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Sense)
        Copy(cp)
    End Sub
End Class
Public Class Immunity
    Public sType As String
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("immunity")
        writer.WriteElementString("type", sType)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "immunity" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "immunity" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Immunity)
        sType = tocopy.sType
    End Sub
    Public Sub ClearAll()
        sType = ""
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Immunity)
        Copy(cp)
    End Sub
End Class
Public Class Resistance
    Public sType, sDetails As String
    Public nAmount As Integer
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("resistance")
        writer.WriteElementString("type", sType)
        writer.WriteElementString("amount", nAmount.ToString)
        writer.WriteElementString("details", sDetails)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "resistance" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                        Case "amount"
                            nAmount = CInt(reader.Value)
                        Case "details"
                            sDetails = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "resistance" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Resistance)
        sType = tocopy.sType
        nAmount = tocopy.nAmount
        sDetails = tocopy.sDetails
    End Sub
    Public Sub ClearAll()
        sType = ""
        nAmount = 0
        sDetails = ""
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Resistance)
        Copy(cp)
    End Sub

End Class
Public Class Vulnerability
    Public sType, sDetails As String
    Public nAmount As Integer

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("vulnerability")
        writer.WriteElementString("type", sType)
        writer.WriteElementString("amount", nAmount.ToString)
        writer.WriteElementString("details", sDetails)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "vulnerability" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                        Case "amount"
                            nAmount = CInt(reader.Value)
                        Case "details"
                            sDetails = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "vulnerability" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Vulnerability)
        sType = tocopy.sType
        nAmount = tocopy.nAmount
        sDetails = tocopy.sDetails
    End Sub
    Public Sub ClearAll()
        sType = ""
        nAmount = 0
        sDetails = ""
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Vulnerability)
        Copy(cp)
    End Sub

End Class
Public Class SavingThrow
    Public nBonus As Integer
    Public sDetails As String
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("savingthrow")
        writer.WriteElementString("bonus", nBonus.ToString)
        writer.WriteElementString("details", sDetails)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "savingthrow" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "bonus"
                            nBonus = CInt(reader.Value)
                        Case "details"
                            sDetails = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "savingthrow" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As SavingThrow)
        nBonus = tocopy.nBonus
        sDetails = tocopy.sDetails
    End Sub
    Public Sub ClearAll()
        nBonus = 0
        sDetails = ""
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As SavingThrow)
        Copy(cp)
    End Sub

End Class
Public Class Speed
    Public sType, sDetails As String
    Public nSpeed As Integer

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("speed")
        writer.WriteElementString("type", sType)
        writer.WriteElementString("distance", nSpeed.ToString)
        writer.WriteElementString("details", sDetails)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "speed" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                        Case "distance"
                            nSpeed = CInt(reader.Value)
                        Case "details"
                            sDetails = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "speed" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Speed)
        sType = tocopy.sType
        nSpeed = tocopy.nSpeed
        sDetails = tocopy.sDetails
    End Sub
    Public Sub ClearAll()
        sType = ""
        nSpeed = 0
        sDetails = ""
    End Sub
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Speed)
        Copy(cp)
    End Sub

End Class
Public Class Keyword
    Public sName As String
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("keyword")
        writer.WriteElementString("name", sName)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "keyword" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "description"
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "keyword" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Keyword)
        sName = tocopy.sName
    End Sub
    Public Sub ClearAll()
        sName = ""
    End Sub
    Public Sub New(ByRef cp As Keyword)
        Copy(cp)
    End Sub

End Class
Public Class Skill
    Public sName As String
    Public bTrained As Boolean
    Public nBonus As Integer
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Skill)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("skill")
        writer.WriteElementString("name", sName)
        writer.WriteElementString("trained", bTrained.ToString)
        writer.WriteElementString("bonus", nBonus.ToString)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "skill" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "trained"
                            bTrained = CBool(reader.Value)
                        Case "bonus"
                            nBonus = CInt(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "skill" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Skill)
        sName = tocopy.sName
        bTrained = tocopy.bTrained
        nBonus = tocopy.nBonus
    End Sub
    Public Sub ClearAll()
        sName = ""
        bTrained = False
        nBonus = 0
    End Sub

End Class
Public Class Trait
    Public sName, sAuraDetails, sDetails As String
    Public nAura As Integer
    Public cKeywords As New ArrayList

    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Trait)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("trait")
        writer.WriteElementString("name", sName)
        writer.WriteElementString("auradetails", sAuraDetails)
        writer.WriteElementString("details", sDetails)
        writer.WriteElementString("aura", nAura.ToString)
        For Each subitem As Keyword In cKeywords
            subitem.ExportXML(writer)
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newKeyword As Keyword

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "trait" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "keyword" Then
                        newKeyword = New Keyword
                        newKeyword.ImportXML(reader)
                        cKeywords.Add(newKeyword)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "auradetails"
                            sAuraDetails = reader.Value
                        Case "details"
                            sDetails = reader.Value
                        Case "aura"
                            nAura = CInt(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "trait" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Trait)
        sName = tocopy.sName
        sAuraDetails = tocopy.sAuraDetails
        sDetails = tocopy.sDetails
        nAura = tocopy.nAura
        cKeywords = tocopy.cKeywords
    End Sub
    Public Sub ClearAll()
        sName = ""
        sAuraDetails = ""
        sDetails = ""
        nAura = 0
        cKeywords.Clear()
    End Sub
    Public ReadOnly Property HTML_Out() As String
        Get
            Dim output As New System.Text.StringBuilder


            ' Add Aura Name
            output.Append("<div class='ggmed'>")
            If nAura > 0 Then output.Append("<font face='4etools symbols'>@</font> ")
            output.Append("<b>" & sName & "</b>")

            If cKeywords.Count > 0 Then
                output.Append(" (")
                Dim index As Integer = 0
                For Each key As Keyword In cKeywords
                    index += 1
                    output.Append(key.sName)
                    If index < cKeywords.Count Then output.Append(", ")
                Next
                output.Append(")")
            End If

            If nAura > 0 Then
                If sAuraDetails = "" Then
                    output.Append(" Aura " & CStr(nAura) & "; ")
                Else
                    output.Append(" Aura " & CStr(nAura) & " " & sAuraDetails & "; ")
                End If
                ' Add details
                ' Finish Aura line
            End If
            output.Append("</div>")
            output.Append("<div class='gglt'><div class='ggindent'>")
            output.Append(sDetails.Replace("###", "<br>"))
            output.AppendLine("</div></div>")
            Return output.ToString
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterTrait" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Range" Then
                        nAura = Val(reader.GetAttribute("FinalValue"))
                        GetXMLFields(reader, "Range", "Details", sAuraDetails)
                    ElseIf reader.Name = "Keywords" Then
                        If Not reader.IsEmptyElement Then
                            ATXMLImport_Keywords(reader)
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "details"
                            sDetails = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterTrait" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_Keywords(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Keywords" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ReferencedObject" Then
                        Dim tempItem As New Keyword
                        GetXMLFields(p_reader, "ReferencedObject", "Name", tempItem.sName)
                        If tempItem.sName <> "" Then
                            tempItem.sName = StrConv(tempItem.sName, VbStrConv.ProperCase)
                            cKeywords.Add(New Keyword(tempItem))
                            tempItem.ClearAll()
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Keywords" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

End Class