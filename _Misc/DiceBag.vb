Public Class DiceBag
    Private numgen As Random

    Public Sub New()
        numgen = New Random()
    End Sub

    Public Function Roll(ByVal dietype As Integer) As Integer
        If dietype < 2 Then
            Return 0
        End If

        Return numgen.Next(1, dietype + 1)
    End Function

    Public Function Roll(ByVal dienum As Integer, ByVal dietype As Integer) As Integer
        Dim total As Integer = 0

        If dienum < 1 Then
            Return 0
        End If

        For i As Integer = 1 To dienum
            total = total + Roll(dietype)
        Next

        Return total
    End Function

    Public Function Roll(ByVal dienum As Integer, ByVal dietype As Integer, ByRef desc As String) As Integer
        Dim total As Integer = 0
        Dim result As Integer

        desc = CStr(dienum) & "d" & CStr(dietype) & " ("

        If dienum < 1 Then
            Return 0
        End If

        For i As Integer = 1 To dienum
            result = Roll(dietype)
            total = total + result
            desc = desc & CStr(result)
            If i <> dienum Then
                desc = desc & ","
            End If
        Next

        desc = desc & ")"

        Return total
    End Function

End Class
