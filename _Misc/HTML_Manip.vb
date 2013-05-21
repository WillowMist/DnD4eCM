Module HTML_Manip
    Function StripHTML(ByVal input As String, ByVal URL As String) As String
        Dim baseurl As String = URL.Substring(0, URL.LastIndexOf("/") + 1)
        Dim output As New System.Text.StringBuilder(input)

        Dim testswitch As Boolean = False
        output.Replace("<!DOCTYPE html PUBLIC " & Chr(34) & "-//W3C//DTD XHTML 1.0 Transitional//EN" & Chr(34) & " " & Chr(34) & "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" & Chr(34) & ">", "")
        Dim strip As String = "<input type=" & Chr(34) & "hidden" & Chr(34) & " name=" & Chr(34) & "__VIEWSTATE" & Chr(34)
        If output.ToString.Contains(strip) Then
            Dim stripstart As Integer = output.ToString.IndexOf(strip)
            Dim stripend As Integer = output.ToString.Substring(stripstart).IndexOf("</div>")
            output.Remove(stripstart, stripend)
        End If
        strip = "<head"
        While output.ToString.Contains(strip)
            Dim stripstart As Integer = output.ToString.IndexOf(strip)
            Dim stripend As Integer = output.ToString.Substring(stripstart).IndexOf("</head>") + 7
            output.Remove(stripstart, stripend)
        End While
        output.Replace("<img src=" & Chr(34) & "images", "<img src=" & Chr(34) & baseurl & "images")
        ' output.Replace("<img src=" & Chr(34) & "images/bullet.gif" & Chr(34) & " alt=" & Chr(34) & Chr(34) & "/>", "&bull;")
        Return output.ToString
    End Function
    Function StripXML(ByVal input As String) As String
        Dim output As New System.Text.StringBuilder(input)
        output.Replace("_(", "_")
        Return output.ToString
    End Function
    Sub WaitingFor(ByRef seconds As Double)
        Dim Fini As DateTime = Now.AddSeconds(seconds)
        While Now < Fini
            My.Application.DoEvents()
        End While
    End Sub
End Module
