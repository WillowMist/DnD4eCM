Public Class StatPower

    ' Power Data
    Public sName, sType, sAction, sKeywords, sDesc, sURL As String
    Public nAura As Integer


    '    Derived Properties
    Public ReadOnly Property bAura() As Boolean
        Get
            If nAura > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property Type() As String
        Get
            If bAura Then
                Return "Aura " & Val(nAura)
            ElseIf sType = "m" Then
                Return "Basic Melee"
            ElseIf sType = "M" Then
                Return "Melee"
            ElseIf sType = "r" Then
                Return "Basic Ranged"
            ElseIf sType = "R" Then
                Return "Ranged"
            ElseIf sType = "A" Then
                Return "Area"
            ElseIf sType = "C" Then
                Return "Close"
            ElseIf sType = "c" Then
                Return "Basic Close"
            ElseIf sType = "" Then
                Return "(no icon)"
            Else
                Return "???"
            End If
        End Get
        Set(ByVal value As String)
            value = value.ToLower.Trim
            If value.StartsWith("aura") Then
                nAura = Val(value.Replace("aura", ""))
                sType = "@"
            ElseIf value = "basic melee" Then
                sType = "m"
            ElseIf value = "melee" Then
                sType = "M"
            ElseIf value = "basic ranged" Then
                sType = "r"
            ElseIf value = "ranged" Then
                sType = "R"
            ElseIf value.ToLower.Contains("area") Then
                sType = "A"
            ElseIf value = "basic close" Or value = "basic close burst" Or value = "basic close blast" Then
                sType = "c"
            ElseIf value = "close" Or value = "close burst" Or value = "close blast" Then
                sType = "C"
            Else
                sType = ""
            End If
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return sDesc.Replace("###", ControlChars.NewLine)
        End Get
        Set(ByVal value As String)
            sDesc = value.Replace(ControlChars.NewLine, "###")
        End Set
    End Property
    Public ReadOnly Property nRechargeVal() As Integer
        Get
            If sAction Is Nothing Or sAction = "" Then
                Return 0
            ElseIf sAction.ToLower.Contains("recharge 2") Then
                Return 2
            ElseIf sAction.ToLower.Contains("recharge 3") Then
                Return 3
            ElseIf sAction.ToLower.Contains("recharge 4") Then
                Return 4
            ElseIf sAction.ToLower.Contains("recharge 5") Then
                Return 5
            ElseIf sAction.ToLower.Contains("recharge 6") Then
                Return 6
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property bDaily() As Boolean
        Get
            If sAction.ToLower.Contains("daily") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bItem() As Boolean
        Get
            If sAction.ToLower.Contains("item") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bActionPoint() As Boolean
        Get
            If sName.ToLower.Contains("action point") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bPowerPoint() As Boolean
        Get
            If sName.ToLower.Contains("power point") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    ' Display Properties
    Public ReadOnly Property sActionLine() As String
        Get
            Dim line As New System.Text.StringBuilder

            If bAura Then
                line.Append("aura " & CStr(nAura))
            ElseIf sAction = "" Then
                Return "  "
            ElseIf sAction.ToLower.Contains("recharges") Then
                line.Append("recharge *")
            ElseIf sAction.ToLower.Contains("recharge ") Then
                line.Append("recharge ")
                If Val(sAction.Substring(sAction.IndexOf("recharge ") + 9)) > 0 Then
                    line.Append(CStr(Val(sAction.Substring(sAction.IndexOf("recharge ") + 9))))
                Else
                    line.Append("*")
                End If
            ElseIf sAction.ToLower.Contains("encounter") Then
                line.Append("encounter")
            ElseIf sAction.ToLower.Contains("at-will") Then
                line.Append("at-will")
            ElseIf sAction.ToLower.Contains("daily") Then
                line.Append("daily")
            ElseIf sAction.ToLower.Contains("item") Then
                line.Append("item")
            Else
                line.Append("special")
            End If

            Return " (" & line.ToString & ")"
        End Get
    End Property
    Public ReadOnly Property cForeColor() As System.Drawing.Color
        Get
            If bAura Then
                Return Color.White
            End If

            If sAction.ToLower.Contains("recharge") Then
                Return Color.White
            ElseIf sAction.ToLower.Contains("encounter") Then
                Return Color.White
            ElseIf sAction.ToLower.Contains("daily") Then
                Return Color.White
            ElseIf sAction.ToLower.Contains("at-will") Then
                Return Color.White
            ElseIf sAction.ToLower.Contains("item") Then
                Return Color.Black
            Else
                Return Color.Black
            End If
        End Get
    End Property
    Public ReadOnly Property cBackColor() As System.Drawing.Color
        Get
            If bAura Then
                Return Color.DarkBlue
            End If

            If sAction.ToLower.Contains("recharge") Then
                Return Color.OrangeRed
            ElseIf sAction.ToLower.Contains("encounter") Then
                Return Color.DarkRed
            ElseIf sAction.ToLower.Contains("daily") Then
                Return Color.Black
            ElseIf sAction.ToLower.Contains("at-will") Then
                Return Color.DarkGreen
            ElseIf sAction.ToLower.Contains("item") Then
                Return Color.Gold
            Else
                Return Color.LightGray
            End If
        End Get
    End Property


    ' Constructor Functions
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByVal p_sName As String, ByVal p_sType As String, _
                   ByVal p_sAction As String, ByVal p_sKeywords As String, _
                   ByVal p_sDesc As String, ByVal p_nAura As Integer)
        sName = p_sName
        sType = p_sType
        sAction = p_sAction
        sKeywords = p_sKeywords
        sDesc = p_sDesc
        nAura = p_nAura
    End Sub
    Public Sub New(ByVal line1 As String, ByVal type As String)
        Power_DetailImport(line1, type)
    End Sub
    Public Sub New(ByRef tocopy As StatPower)
        Copy(tocopy)
    End Sub


    ' RTF Import/Export
    Public Sub Power_DetailImport(ByVal line1 As String, ByVal type As String)

        ' Analyze line1 
        Dim temp As String = line1.Trim

        If temp.EndsWith("#") Then
            temp = temp.Replace("#", "").Trim

            nAura = 0

            ' Get Description
            If sDesc <> "" Then
                sDesc = sDesc & "###" & temp
            Else
                sDesc = temp
            End If
        End If
        If temp.StartsWith("@B ") Or temp.StartsWith("@O ") Or temp.StartsWith("@M ") Or temp.StartsWith("@m ") Or temp.StartsWith("@R ") Or temp.StartsWith("@r ") Or temp.StartsWith("@A ") Or temp.StartsWith("@C ") Then
            Dim tempName As String = ""
            Dim tempKeywords As String = ""
            Dim tempAction As String = ""
            If temp.StartsWith("@O ") Then
                nAura = Val(temp.Substring(temp.IndexOf("*") + 7).Trim)
                If temp.Contains("Aura " & nAura.ToString & " ") Then
                    sDesc = temp.Substring(temp.IndexOf("*") + 9).Trim
                End If
            End If
            If temp.StartsWith("@M ") Or temp.StartsWith("@m ") Or temp.StartsWith("@R ") Or temp.StartsWith("@r ") Or temp.StartsWith("@A ") Or temp.StartsWith("@C ") Then
                sType = temp.Substring(temp.IndexOf("@") + 1, 1)
            End If
            If temp.Contains("*") Then
                tempAction = temp.Substring(temp.IndexOf("*") + 2)
            End If
            If temp.Contains("(") Then
                tempName = temp.Substring(3, temp.IndexOf("(") - 3).Trim
                tempKeywords = temp.Substring(temp.IndexOf("(") + 1, temp.IndexOf(")") - temp.IndexOf("(") - 1)
            ElseIf temp.Contains("*") Then
                tempName = temp.Substring(3, temp.IndexOf("*") - 3).Trim
            Else
                tempName = temp.Substring(3).Trim
            End If
            sAction = tempAction.ToLower
            sKeywords = tempKeywords
            sName = tempName
            If type = "standard" Or type = "move" Or type = "minor" Or type = "free" Or type = "triggered" Then
                If sAction <> "" Then
                    sAction = type & "; " & sAction
                Else
                    sAction = type
                End If
            Else
                ' sDesc = ""
            End If
        Else
            If sName = "" Then
                sName = temp
            ElseIf sDesc <> "" Then
                If sDesc.EndsWith("~") Then
                    sDesc = sDesc.Replace("~", " ")
                Else
                    sDesc = sDesc & "###"
                End If
                If temp.ToLower.StartsWith("attack") Then
                    sDesc = sDesc & temp & "~"
                Else
                    sDesc = sDesc & temp
                End If
            Else
                If temp.ToLower.StartsWith("attack") Then
                    sDesc = temp & "~"
                Else
                    sDesc = temp
                End If
            End If
        End If
    End Sub
    Public ReadOnly Property Power_RTF_Out() As String
        Get
            Dim output As New System.Text.StringBuilder

            If nAura > 0 Then
                ' Add Aura Name
                output.Append(RTF_Bold(sName))

                If sKeywords <> "" Then
                    output.Append(" (" & sKeywords & ")")
                End If

                ' Add aura value
                output.Append(" aura " & CStr(nAura) & "; ")

                ' Add details
                output.Append(sDesc)

                ' Finish Aura line
                output.AppendLine("\par")
            Else
                ' Add Type
                If sType <> "" Then
                    output.Append(RTF_DnDSymbol(sType) & " ")
                End If

                ' Add Power Name
                output.Append(RTF_Bold(sName.Replace("*", "\bullet ")))

                If sAction <> "" Then
                    output.Append(" (" & sActionDice & ")")
                End If

                ' Add Keywords
                If sKeywords <> "" Then
                    output.Append(" \bullet  " & sKeywords)
                End If

                ' Finish First line
                output.AppendLine("\par")

                ' Create Second Line
                If sDesc <> "" Then
                    output.Append("  " & sDesc)
                    output.AppendLine("\par")
                End If
            End If

            output.Replace("###", "\par" & ControlChars.NewLine & "  ")
            output.Replace("Recharge 6", "Recharge " & RTF_DnDSymbol("6"))
            output.Replace("Recharge 5", "Recharge " & RTF_DnDSymbol("5 6"))
            output.Replace("Recharge 4", "Recharge " & RTF_DnDSymbol("4 5 6"))
            output.Replace("Recharge 3", "Recharge " & RTF_DnDSymbol("3 4 5 6"))
            output.Replace("Recharge 2", "Recharge " & RTF_DnDSymbol("2 3 4 5 6"))

            Return output.ToString
        End Get
    End Property
    Public ReadOnly Property Power_HTML_Out() As String
        Get
            Dim output As New System.Text.StringBuilder

            If nAura > 0 Then
                output.AppendLine("<div class='ggmed'>")
                If sType <> "" Then
                    output.Append("<font face='4etools symbols'>" & sType & "</font> ")
                End If
                ' Add Aura Name
                output.Append("<b>" & sName.Replace("*", "&bull;") & "</b>")

                If sKeywords <> "" Then
                    output.Append(" (" & sKeywords & ")")
                End If

                ' Add aura value
                output.Append(" Aura " & CStr(nAura) & "; ")
                output.Append("</div>")
                ' Add details
                output.Append("<div class='gglt'><div class='ggindent'>")
                output.Append(sDesc.Replace("###", "<br>"))

                ' Finish Aura line
                output.AppendLine("</div></div>")
            Else
                If (Not sName.ToLower.Contains("no name")) And (Not sName.ToLower.Contains("unnamed power")) Then
                    ' Add Type
                    output.AppendLine("<div class='ggmed'>")
                    If sType <> "" Then
                        output.Append("<font face='4etools symbols'>" & sType & "</font> ")
                    End If
                    ' Add Power Name
                    output.Append("<b>" & sName.Replace("*", "&bull;") & "</b>")

                    If sAction <> "" Then
                        output.Append(" (" & sActionDiceHTML & ")")
                    End If

                    ' Add Keywords
                    If sKeywords <> "" Then
                        output.Append(" &bull;  " & sKeywords)
                    End If

                    ' Finish First line
                    output.AppendLine("</div>")
                End If
                ' Create Second Line
                If sDesc <> "" Then
                    output.Append("<div class='gglt'><div class='ggindent'>")
                    output.Append(sDesc.Replace("###", "<br>").Replace("*", "&bull;"))
                    output.AppendLine("</div></div>")
                End If
            End If
            Return output.ToString
        End Get
    End Property

    Private ReadOnly Property sActionDice() As String
        Get
            Dim line As New System.Text.StringBuilder
            line.AppendLine(sAction)

            line.Replace("recharge 6", "recharge " & RTF_DnDSymbol("6"))
            line.Replace("recharge 5", "recharge " & RTF_DnDSymbol("5 6"))
            line.Replace("recharge 4", "recharge " & RTF_DnDSymbol("4 5 6"))
            line.Replace("recharge 3", "recharge " & RTF_DnDSymbol("3 4 5 6"))
            line.Replace("recharge 2", "recharge " & RTF_DnDSymbol("2 3 4 5 6"))

            Return line.ToString
        End Get
    End Property
    Private ReadOnly Property sActionDiceHTML() As String
        Get
            Dim line As New System.Text.StringBuilder
            line.AppendLine(sAction)
            line.Replace("recharge 6", "recharge <font face='4etools symbols'>6</font>")
            line.Replace("recharge 5", "recharge <font face='4etools symbols'>5 6</font>")
            line.Replace("recharge 4", "recharge <font face='4etools symbols'>4 5 6</font>")
            line.Replace("recharge 3", "recharge <font face='4etools symbols'>3 4 5 6</font>")
            line.Replace("recharge 2", "recharge <font face='4etools symbols'>2 3 4 5 6</font>")
            Return line.ToString
        End Get
    End Property


    ' XML Import/Export
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("power")

        writer.WriteElementString("name", sName)
        writer.WriteElementString("type", Type)
        writer.WriteElementString("act", sAction)
        writer.WriteElementString("key", sKeywords)
        writer.WriteElementString("desc", sDesc)
        writer.WriteElementString("url", sURL)

        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "power" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "type"
                            Type = reader.Value
                        Case "act"
                            sAction = reader.Value
                        Case "key"
                            sKeywords = reader.Value
                        Case "desc"
                            sDesc = reader.Value
                        Case "url"
                            sURL = reader.Value
                            If sURL.Contains("item.aspx") Then sURL = sURL.Replace("item.aspx?", "display.aspx?page=item&")
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "power" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function


    ' Data Manipulation Functions
    Public Sub Copy(ByRef tocopy As StatPower)
        sName = tocopy.sName
        sType = tocopy.sType
        sAction = tocopy.sAction
        sKeywords = tocopy.sKeywords
        sDesc = tocopy.sDesc
        nAura = tocopy.nAura
        sURL = tocopy.sURL
    End Sub
    Public Sub ClearAll()
        sName = "(unnamed power)"
        sType = ""
        sAction = ""
        sKeywords = ""
        sDesc = "(no description)"
        nAura = 0
        sURL = ""
    End Sub


End Class
