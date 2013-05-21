Module RTF_Manip
    Sub ImportRTF_Fast(ByVal orig As String, ByRef RTBox As RichTextBox)

        Dim entry As String = orig

        entry = entry.Replace("\cell", "\row")
        entry = entry.Replace("\line", "\row")
        entry = entry.Replace("\fs27", "\fs20")
        entry = entry.Replace("\fs24", "\fs16")

        RTBox.Rtf = entry.ToString
        entry = RTBox.Rtf

        entry = entry.Replace("\pard\ltrpar\qj\par" & ControlChars.NewLine, "")
        entry = entry.Replace("\f1 ", "\par\f1 ")
        entry = entry.Replace("\pard\ltrpar\b", "\par\pard\ltrpar\b")
        entry = entry.Replace("\par" & ControlChars.NewLine & "\b Dex", "\tab \b Dex")
        entry = entry.Replace("\par" & ControlChars.NewLine & "\b Wis", "\tab \b Wis")
        entry = entry.Replace("\par" & ControlChars.NewLine & "\b Int", "\tab \b Int")
        entry = entry.Replace("\par" & ControlChars.NewLine & "\b Cha", "\tab \b Cha")
        entry = entry.Replace("\par\pard\ltrpar\b Con", "\pard\ltrpar\b Con")
        entry = entry.Replace("Georgia", "Arial")
        entry = entry.Replace("\par" & ControlChars.NewLine & "Level", " \tab Level")
        entry = entry.Replace("\par" & ControlChars.NewLine & "XP", " \tab XP")
        entry = entry.Replace("\pard\ltrpar\qj\fs16\par", "\pard\ltrpar\qj\fs16")
        entry = entry.Replace(ControlChars.NewLine & "\pard\ltrpar\par" _
                              & ControlChars.NewLine, "")
        entry = entry.Remove(entry.ToString.IndexOf("\pard\ltrpar\'a9"))
        ' entry = entry.Replace("Recharge 6", "Recharge " & RTF_DnDSymbol("6"))
        entry = entry & "}"

        RTBox.Rtf = entry

    End Sub

    Sub ImportRTF_FromClipboard(ByRef RTBox As RichTextBox)
        Dim clipBlock As String

        If My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then
            clipBlock = My.Computer.Clipboard.GetText(TextDataFormat.Rtf)

            ImportRTF_Fast(clipBlock, RTBox)
        End If
    End Sub

    Function ImportRTF_ToDetails(ByVal input As String) As String
        Dim lines As String()
        Dim output As New System.Text.StringBuilder(input)

        Dim testswitch As Boolean = False

        output.Replace("{\fs18 ", "")
        output.Replace("\fs18", "")
        output.Replace("\cf1", "")
        output.Replace("  ", " ")
        output.Replace("\f3 }", "\ltrch }")
        output.Replace("};", ";")
        output.Replace("\loch", "")
        output.Replace("\f3 6", "6")
        output.Replace("\f3 5 6", "5")
        output.Replace("\f3 4 5 6", "4")
        output.Replace("\f3 3 4 5 6", "3")
        output.Replace("\f3 2 3 4 5 6", "2")
        output.Replace("\bullet ", "*")
        output.Replace("\endash ", "-")
        output.Replace("\emdash ", "-")
        output.Replace("\rquote ", "'")
        output.Replace("\b0 ", "")
        output.Replace("\b ", "")
        'output.Replace("}aura", "\line aura")
        'output.Replace("}Aura", "\line aura")
        'output.Replace("(aura", "\line aura")
        output.Replace("}", " ")
        output.Replace("{", " ")
        output.Replace("\", ControlChars.NewLine & "\")
        output.Replace("    ", " ")
        output.Replace("   ", " ")
        output.Replace("  ", " ")
        output.Replace(" ,", ",")
        output.Replace(" ; ", "; ")
        output.Replace("\~", "\ltrch ")


        lines = output.ToString.Split(ControlChars.NewLine)

        output.Length = 0
        Dim traitToggle As Integer = 0
        For Each line As String In lines
            If line.Trim.StartsWith("\ltrch") And line.Trim <> "\ltrch" Then
                If traitToggle = 1 Then
                    output.Append("@B " & line.Trim & ControlChars.NewLine)
                    traitToggle = 0
                Else
                    output.Append(line.Trim & ControlChars.NewLine)
                End If
            ElseIf line.Trim = "\clcbpat5" Then
                traitToggle = 1
            ElseIf line.Trim = "\clcbpat3" Then
                traitToggle = 0
            ElseIf line.Trim.StartsWith("\i ") And line.Trim <> "\i" Then
                output.Append(line.Substring(3).Trim & ControlChars.NewLine)
            ElseIf line.Trim.StartsWith("\tab") And line.Trim <> "\tab" Then
                If Not line.Trim.StartsWith("\tab Senses ") Then
                    output.Append("##" & ControlChars.NewLine)
                End If
                output.Append(line.Trim & ControlChars.NewLine)
            ElseIf line.Trim.StartsWith("\line") And line.Trim <> "\line" Then
                output.Append(line.Trim & ControlChars.NewLine)
            ElseIf line.Trim.StartsWith("\f3") And line.Trim <> "\f3" Then
                output.Append(line.Trim & ControlChars.NewLine)
            ElseIf line.Trim.StartsWith("\fi180") Then
                output.Append("##" & ControlChars.NewLine)
            ElseIf line.Trim.StartsWith("\fldrslt") Then
                output.Append(line.Trim & ControlChars.NewLine)
            ElseIf testswitch Then ' Test Line
                output.Append(line.Trim & ControlChars.NewLine)
            End If
        Next

        output.Replace("; Resist ", ControlChars.NewLine & "Resist ")
        output.Replace("; Vulnerability ", ControlChars.NewLine & "Vulnerability ")
        output.Replace("; Action ", ControlChars.NewLine & "Action ")

        output.Replace(ControlChars.NewLine & "\fldrslt", "")
        output.Replace(ControlChars.NewLine & "##", "#")
        If Not testswitch Then
            output.Replace("\ltrch ", "")
            output.Replace("\tab ", "")
            output.Replace("\line ", "")
            output.Replace("\f3 ", "@")
            output.Replace("  ", " ")
        End If

        output.Insert(0, "@4eSB001" & ControlChars.NewLine, 1)

        Return output.ToString
    End Function

    Function RTF_Bold(ByVal input As String) As String

        Return "\b " & input & "\b0 "
    End Function

    Function RTF_DnDSymbol(ByVal input As String) As String

        Return "\f1 " & input & "\f0 "
    End Function

    Function RTF_DnDStatBonus(ByVal input As Integer) As String
        Dim bonus As Integer = DnD4e_CalcStatBonus(input)

        Return CStr(input) & " (" & IntegerFormatForPlus(bonus) & ")"
    End Function


    Function IntegerFormatForPlus(ByVal input As Integer) As String
        If input < 0 Then
            Return CStr(input)
        Else
            Return "+" & CStr(input)
        End If
    End Function


End Module
