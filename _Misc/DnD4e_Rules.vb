Module DnD4e_Rules
    Function DnD4e_CalcStatBonus(ByVal input As Integer) As Integer
        Dim output As Integer = input - 10

        If output < 0 Then
            output = (output - 1) \ 2
        Else
            output = output \ 2
        End If

        Return output
    End Function

    Function DnD4e_EncounterLevel(ByVal p_nPartySize As Integer, ByVal p_nXP_Budget As Integer) As Integer
        If p_nPartySize = 0 Then
            Return 0
        End If

        Dim nPerPC As Integer = p_nXP_Budget \ p_nPartySize

        Select Case nPerPC
            Case Is <= 112 : Return 1
            Case Is <= 137 : Return 2
            Case Is <= 162 : Return 3
            Case Is <= 187 : Return 4
            Case Is <= 225 : Return 5

            Case Is <= 275 : Return 6
            Case Is <= 325 : Return 7
            Case Is <= 375 : Return 8
            Case Is <= 450 : Return 9
            Case Is <= 550 : Return 10

            Case Is <= 650 : Return 11
            Case Is <= 750 : Return 12
            Case Is <= 900 : Return 13
            Case Is <= 1100 : Return 14
            Case Is <= 1300 : Return 15

            Case Is <= 1500 : Return 16
            Case Is <= 1800 : Return 17
            Case Is <= 2200 : Return 18
            Case Is <= 2600 : Return 19
            Case Is <= 3000 : Return 20

            Case Is <= 3675 : Return 21
            Case Is <= 4625 : Return 22
            Case Is <= 5575 : Return 23
            Case Is <= 6525 : Return 24
            Case Is <= 8000 : Return 25

            Case Is <= 10000 : Return 26
            Case Is <= 12000 : Return 27
            Case Is <= 14000 : Return 28
            Case Is <= 17000 : Return 29
            Case Is <= 21000 : Return 30

            Case Is <= 25000 : Return 31
            Case Is <= 29000 : Return 32
            Case Is <= 35000 : Return 33
            Case Is <= 43000 : Return 34
            Case Is <= 51000 : Return 35

            Case Is <= 59000 : Return 36
            Case Is <= 71000 : Return 37
            Case Is <= 87000 : Return 38
            Case Is <= 103000 : Return 39
            Case Else : Return 40
        End Select
    End Function

End Module
