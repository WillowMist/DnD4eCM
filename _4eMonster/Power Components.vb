Imports DnD4e_Combat_Manager.DnDLibrary

Public Class Damage
    Public sType, sDesc, sSpecial As String
    Public nDice, nAvgDamage, nDieSides, nMod, nModBase As Integer
    Public cAfterEffects As ArrayList
    Public cFailedSaves As ArrayList
    Public cSustains As ArrayList
    Public cSecondaryAttacks As ArrayList
    Public ReadOnly Property bIsValid() As Boolean
        Get
            Dim _b As Boolean = False
            If sType.ToLower = "none" And sDesc <> "" Then
                _b = True
            ElseIf sType.ToLower = "normal" And sDesc <> "" Then
                _b = True
            ElseIf sType = "" Then
                _b = False
            ElseIf sDiceString <> "0" Then
                _b = True
            End If
            Return _b
        End Get
    End Property
    Public Sub New()
        cAfterEffects = New ArrayList
        cFailedSaves = New ArrayList
        cSustains = New ArrayList
        cSecondaryAttacks = New ArrayList
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Damage)
        cAfterEffects = New ArrayList
        cFailedSaves = New ArrayList
        cSustains = New ArrayList
        cSecondaryAttacks = New ArrayList
        Copy(cp)
    End Sub
    Public ReadOnly Property sDamageLine() As String
        Get
            If sType = "None" Or sType = "" Then
                Return sDesc
            Else
                Dim output As New System.Text.StringBuilder
                output.Append(nDice.ToString & "d" & nDieSides.ToString)
                If nMod > 0 Then
                    output.Append("+" & nMod.ToString)
                ElseIf nMod < 0 Then
                    output.Append(nMod.ToString)
                End If
                If sDesc <> "" Then output.Append(" " & sDesc)
                Return output.ToString
            End If
        End Get
    End Property

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("damage")
        writer.WriteElementString("type", sType)
        writer.WriteElementString("desc", sDesc)
        writer.WriteElementString("avgdamage", nAvgDamage.ToString)
        writer.WriteElementString("dice", nDice.ToString)
        writer.WriteElementString("diesides", nDieSides.ToString)
        writer.WriteElementString("mod", nMod.ToString)
        writer.WriteElementString("special", sSpecial)
        For Each subitem As AfterEffect In cAfterEffects
            subitem.ExportXML(writer)
        Next
        For Each subitem As FailedSave In cFailedSaves
            subitem.ExportXML(writer)
        Next
        For Each subitem As Sustain In cSustains
            subitem.ExportXML(writer)
        Next
        For Each subitem As Attack In cSecondaryAttacks
            subitem.ExportXML(writer)
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newAfterEffect As AfterEffect
        Dim newFailedSave As FailedSave
        Dim newSustain As Sustain
        Dim newAttack As Attack

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "damage" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "aftereffect" Then
                        newAfterEffect = New AfterEffect
                        newAfterEffect.ImportXML(reader)
                        cAfterEffects.Add(newAfterEffect)
                    ElseIf reader.Name = "failedsave" Then
                        newFailedSave = New FailedSave
                        newFailedSave.ImportXML(reader)
                        cFailedSaves.Add(New FailedSave(newFailedSave))
                    ElseIf reader.Name = "sustain" Then
                        newSustain = New Sustain
                        newSustain.ImportXML(reader)
                        cSustains.Add(newSustain)
                    ElseIf reader.Name = "attack" Then
                        newAttack = New Attack
                        newAttack.ImportXML(reader)
                        cSecondaryAttacks.Add(newAttack)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "type"
                            sType = reader.Value
                        Case "desc"
                            sDesc = reader.Value
                        Case "avgdamage"
                            nAvgDamage = CInt(reader.Value)
                        Case "dice"
                            nDice = CInt(reader.Value)
                        Case "diesides"
                            nDieSides = CInt(reader.Value)
                        Case "mod"
                            nMod = CInt(reader.Value)
                            nModBase = GetModBase
                        Case "special"
                            sSpecial = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "damage" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Damage)
        Dim newAfterEffect As New AfterEffect
        Dim newFailedSave As New FailedSave
        Dim newSustain As New Sustain
        Dim newAttack As New Attack
        sType = tocopy.sType
        sDesc = tocopy.sDesc
        nAvgDamage = tocopy.nAvgDamage
        nDice = tocopy.nDice
        nDieSides = tocopy.nDieSides
        nMod = tocopy.nMod
        sSpecial = tocopy.sSpecial
        For Each subitem As AfterEffect In tocopy.cAfterEffects
            newAfterEffect.ClearAll()
            newAfterEffect.Copy(subitem)
            cAfterEffects.Add(New AfterEffect(newAfterEffect))
        Next
        For Each subitem As FailedSave In tocopy.cFailedSaves
            newFailedSave.ClearAll()
            newFailedSave.Copy(subitem)
            cFailedSaves.Add(New FailedSave(newFailedSave))
        Next
        For Each subitem As Sustain In tocopy.cSustains
            newSustain.ClearAll()
            newSustain.Copy(subitem)
            cSustains.Add(New Sustain(newSustain))
        Next
        For Each subitem As Attack In tocopy.cSecondaryAttacks
            newAttack.ClearAll()
            newAttack.Copy(subitem)
            cSecondaryAttacks.Add(New Attack(newAttack))
        Next
    End Sub
    Public Sub ClearAll()
        sType = ""
        sDesc = ""
        sSpecial = ""
        nAvgDamage = 0
        nDice = 0
        nDieSides = 0
        nMod = 0
        cAfterEffects.Clear()
        cFailedSaves.Clear()
        cSustains.Clear()
        cSecondaryAttacks.Clear()
    End Sub
    Private ReadOnly Property GetModBase() As Integer
        Get
            If nMod = 0 Then
                Return 0
            ElseIf nMod < nDieSides Then
                Return 0
            ElseIf nDieSides = 0 Then
                Return 0
            Else
                Return Math.Truncate(nMod / nDieSides) * nDieSides
            End If
        End Get
    End Property

    Public Property sDiceString() As String
        Get
            Dim output As New System.Text.StringBuilder
            If nDieSides = 0 Then
                output.Append(nMod.ToString)
            Else
                output.Append(nDice.ToString & "d" & nDieSides.ToString)
            End If
            If nMod > 0 And nDieSides <> 0 Then
                output.Append(" + " & nMod.ToString)
            ElseIf nMod < 0 And nDieSides <> 0 Then
                output.Append(" - " & Math.Abs(nMod).ToString)
            End If
            Return output.ToString
        End Get
        Set(ByVal value As String)
            Dim tempstring As String = value.ToLower
            If value.Contains("-") Then
                nMod = Val(tempstring.Substring(tempstring.IndexOf("-")))
                tempstring = tempstring.Substring(0, tempstring.IndexOf("-"))
            ElseIf value.Contains("+") Then
                nMod = Val(tempstring.Substring(tempstring.IndexOf("+")))
                tempstring = tempstring.Substring(0, tempstring.IndexOf("+"))
            Else
                nMod = 0
            End If
            If tempstring.Contains("d") Then
                nDice = Val(tempstring.Substring(0, tempstring.IndexOf("d")))
                nDieSides = Val(tempstring.Substring(tempstring.IndexOf("d") + 1))
            Else
                nDice = 0
                nDieSides = 0
                If nMod <= 0 Then nDice = nMod
                nMod = Val(tempstring)
            End If
            nModBase = GetModBase
        End Set
    End Property
    Public ReadOnly Property bValidDice(ByVal dice As String)
        Get
            Dim test, test2, test3 As String
            If dice.ToLower.Contains("-") Then
                test3 = dice.ToLower.Substring(dice.IndexOf("-"))
                dice = dice.ToLower.Substring(0, dice.IndexOf("-"))
            ElseIf dice.ToLower.Contains("+") Then
                test3 = dice.ToLower.Substring(dice.IndexOf("+"))
                dice = dice.ToLower.Substring(0, dice.IndexOf("+"))
            Else
                test3 = 0
            End If
            If dice.ToLower.Contains("d") Then
                test = dice.ToLower.Substring(0, dice.ToLower.IndexOf("d"))
                test2 = dice.ToLower.Substring(dice.ToLower.IndexOf("d"))
            Else
                test = dice
                test2 = 0
            End If
            If Val(test) >= 0 And Val(test) <= 10000 Then
                If Val(test2) >= 0 And Val(test2) <= 10000 Then
                    If Val(test3) >= 0 And Val(test3) <= 10000 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property nMin()
        Get
            If nDieSides = 0 Then
                Return nDice + nMod
            Else
                Return nDice + nMod
            End If
        End Get
    End Property
    Public ReadOnly Property nMax()
        Get
            If nDieSides = 0 Then
                Return nDice + nMod
            Else
                Return (nDice * nDieSides) + nMod
            End If
        End Get
    End Property
    Public ReadOnly Property nAvg()
        Get
            If nDieSides = 0 Then
                Return nDice + nMod
            Else
                Dim dieavg As Double = nDieSides / 2 + 0.5

                Return Math.Truncate(nDice * dieavg) + nMod
            End If
        End Get
    End Property

    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            If sType.ToLower = "none" Or sType = "" Or sDiceString = "0" Then
                output.Append(sDesc)
            Else
                output.Append(sDiceString)
                If sDesc <> "" Then output.Append(" " & sDesc)
                For Each fs As FailedSave In cFailedSaves
                    output.Append("<div><i>" & IntToIteration(cFailedSaves.IndexOf(fs) + 1) & " Failed Saving Throw: </i>")
                    output.Append(fs.HTML_Out(pow))
                    output.Append("</div>")
                Next
                For Each ae As AfterEffect In cAfterEffects
                    output.Append("<div><i>Aftereffect:</i> ")
                    output.Append(ae.HTML_Out(pow))
                    output.Append("</div>")
                Next
                For Each sus As Sustain In cSustains
                    output.Append("<div><i>Sustain")
                    output.Append(sus.HTML_Out(pow))
                    output.Append("</div>")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    Public ReadOnly Property Text_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            If sType.ToLower = "none" Or sType = "" Or sDiceString = "0" Then
                output.Append(sDesc)
            Else
                output.Append(sDiceString)
                If sDesc <> "" Then output.Append(" " & sDesc)
                For Each fs As FailedSave In cFailedSaves
                    output.Append(IntToIteration(cFailedSaves.IndexOf(fs) + 1) & " Failed Saving Throw: ")
                    output.Append(fs.HTML_Out(pow))
                Next
                For Each ae As AfterEffect In cAfterEffects
                    output.Append("Aftereffect: ")
                    output.Append(ae.HTML_Out(pow))
                Next
                For Each sus As Sustain In cSustains
                    output.Append("Sustain")
                    output.Append(sus.HTML_Out(pow))
                Next
            End If
            Return output.ToString
        End Get
    End Property
    Public Sub IncreaseDamage(ByVal p_per As Integer, Optional ByVal p_type As String = "amount")
        Dim percent As Double = (p_per / 100) + 1
        Dim olddice As Integer = nDice
        Dim oldmod As Integer = nMod
        Dim oldavg As Integer = nAvg
        Dim newavg As Integer
        If p_type = "percent" Then
            newavg = Math.Truncate(oldavg * percent)
        Else
            newavg = oldavg + p_per
        End If
        Do While nAvg < newavg
            'If nMod > oldmod + (nDieSides / 2) - 1 Then
            If nMod > nModBase + nDieSides - 1 Then
                'nMod = oldmod - Math.Truncate(nDieSides / 2)
                nMod = nModBase
                nDice += 1
            Else
                nMod += 1
            End If
        Loop
    End Sub
    Public Sub DecreaseDamage(ByVal p_per As Integer, Optional ByVal p_type As String = "amount")
        Dim percent As Double = 1 - (p_per / 100)
        Dim olddice As Integer = nDice
        Dim oldmod As Integer = nMod
        Dim oldavg As Integer = nAvg
        Dim newavg As Integer
        If p_type = "percent" Then
            newavg = Math.Truncate(oldavg * percent)
        Else
            newavg = oldavg - p_per
        End If
        Do While nAvg > newavg
            'If nMod < oldmod - (nDieSides / 2) + 1 Then
            'nMod = oldmod + Math.Truncate(nDieSides / 2)
            If nMod < nModBase + 1 And nDice > 1 Then
                nMod = nModBase + nDieSides
                nDice -= 1
            Else
                nMod -= 1
            End If
        Loop
    End Sub
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Damage" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "Expression"
                            sDiceString = reader.Value
                        Case "Type"
                            sType = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Damage" Then
                        nModBase = GetModBase
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_Sustains(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Sustains" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterSustainEffect" Then
                        Dim tempSustain As New Sustain
                        tempSustain.ATXMLImport(reader)
                        If tempSustain.sAction <> "" Then
                            cSustains.Add(New Sustain(tempSustain))
                        End If
                        tempSustain.ClearAll()
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Sustains" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_AfterEffects(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Aftereffects" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterAttackEntry" Then
                        Dim tempAftereffect As New AfterEffect
                        tempAftereffect.ATXMLImport(reader)
                        If tempAftereffect.cDamage.bIsValid Then
                            cAfterEffects.Add(New AfterEffect(tempAftereffect))
                        End If
                        tempAftereffect.ClearAll()
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Aftereffects" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_FailedSaves(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "FailedSavingThrows" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterAttackEntry" Then
                        Dim tempFailedSave As New FailedSave
                        tempFailedSave.ATXMLImport(reader)
                        If tempFailedSave.cDamage.bIsValid Then
                            cFailedSaves.Add(New FailedSave(tempFailedSave))
                        End If
                        tempFailedSave.ClearAll()
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "FailedSavingThrows" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_SecondaryAttacks(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Attacks" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterAttack" Then
                        Dim tempItem As New Attack
                        tempItem.ATXMLImport(reader)
                        If tempItem.sRange <> "" Or tempItem.sTarget <> "" Or tempItem.cAttackBonuses.Count > 0 Then
                            cSecondaryAttacks.Add(New Attack(tempItem))
                            tempItem.ClearAll()
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Attacks" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

End Class
Public Class AfterEffect
    Public cDamage As New Damage
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As AfterEffect)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("aftereffect")
        cDamage.ExportXML(writer)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "aftereffect" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "damage" Then
                        cDamage.ImportXML(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "aftereffect" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As AfterEffect)
        cDamage.Copy(tocopy.cDamage)
    End Sub
    Public Sub ClearAll()
        cDamage.ClearAll()
    End Sub
    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            output.Append(cDamage.HTML_Out(pow))
            Return output.ToString
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterAttackEntry" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Damage" Then
                        cDamage.ATXMLImport(reader)
                    ElseIf reader.Name = "Sustains" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_Sustains(reader)
                    ElseIf reader.Name = "Aftereffects" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_AfterEffects(reader)
                    ElseIf reader.Name = "FailedSavingThrows" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_FailedSaves(reader)
                    ElseIf reader.Name = "Attacks" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_SecondaryAttacks(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "Description"
                            cDamage.sDesc = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterAttackEntry" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

End Class
Public Class FailedSave
    Public sName As String
    Public cDamage As New Damage
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As FailedSave)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("failedsave")
        writer.WriteElementString("name", sName)
        cDamage.ExportXML(writer)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "failedsave" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "damage" Then
                        cDamage.ImportXML(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "failedsave" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As FailedSave)
        sName = tocopy.sName
        cDamage.Copy(tocopy.cDamage)
    End Sub
    Public Sub ClearAll()
        sName = ""
        cDamage.ClearAll()
    End Sub
    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            output.Append(cDamage.HTML_Out(pow))
            Return output.ToString
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterAttackEntry" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Damage" Then
                        cDamage.ATXMLImport(reader)
                    ElseIf reader.Name = "Sustains" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_Sustains(reader)
                    ElseIf reader.Name = "Aftereffects" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_AfterEffects(reader)
                    ElseIf reader.Name = "FailedSavingThrows" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_FailedSaves(reader)
                    ElseIf reader.Name = "Attacks" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_SecondaryAttacks(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "Description"
                            cDamage.sDesc = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterAttackEntry" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub


End Class
Public Class Sustain
    Public sAction As String
    Public cDamage As New Damage
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Sustain)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("sustain")
        writer.WriteElementString("action", sAction)
        cDamage.ExportXML(writer)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "sustain" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "damage" Then
                        cDamage.ImportXML(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "action"
                            sAction = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "sustain" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Sustain)
        sAction = tocopy.sAction
        cDamage.Copy(tocopy.cDamage)
    End Sub
    Public Sub ClearAll()
        sAction = ""
        cDamage.ClearAll()
    End Sub
    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            If sAction <> "" Then output.Append(" " & sAction)
            output.Append(":</i> " & cDamage.HTML_Out(pow))
            Return output.ToString
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterSustainEffect" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Damage" Then
                        cDamage.ATXMLImport(reader)
                    ElseIf reader.Name = "Sustains" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_Sustains(reader)
                    ElseIf reader.Name = "Aftereffects" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_AfterEffects(reader)
                    ElseIf reader.Name = "FailedSavingThrows" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_FailedSaves(reader)
                    ElseIf reader.Name = "Attacks" And Not reader.IsEmptyElement Then
                        cDamage.ATXMLImport_SecondaryAttacks(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select elementName
                        Case "Description"
                            cDamage.sDesc = reader.Value
                        Case "Action"
                            sAction = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterSustainEffect" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

End Class
Public Class SecondaryAttack
    Public cAttack As New ArrayList
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As SecondaryAttack)
        Copy(cp)
    End Sub

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("secondaryattack")
        For Each att As Attack In cAttack
            att.ExportXML(writer)
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newAttack As New Attack

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "secondaryattack" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "attack" Then
                        newAttack.ImportXML(reader)
                        cAttack.Add(newAttack)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "secondaryattack" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As SecondaryAttack)
        Dim newAttack As New Attack
        For Each att As Attack In tocopy.cAttack
            newAttack.ClearAll()
            newAttack.Copy(att)
            cAttack.Add(New Attack(newAttack))
        Next
    End Sub
    Public Sub ClearAll()
        cAttack.Clear()
    End Sub
    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            For Each att As Attack In cAttack
                output.Append(att.HTML_Out(pow))
            Next
            Return output.ToString
        End Get
    End Property
End Class
Public Class Attack
    Public sRange, sTarget, sDesc As String
    Public bMultiTarget As Boolean
    Public cDamages As Hashtable
    Public cAttackBonuses As New ArrayList
    Public Sub New()
        cDamages = New Hashtable
        cDamages.Add("cHit", New Damage)
        cDamages.Add("cMiss", New Damage)
        cDamages.Add("cEffect", New Damage)
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Attack)
        cDamages = New Hashtable
        cDamages.Add("cHit", New Damage)
        cDamages.Add("cMiss", New Damage)
        cDamages.Add("cEffect", New Damage)
        Copy(cp)
    End Sub
    Public ReadOnly Property sHandle() As String
        Get
            Dim output As New System.Text.StringBuilder
            If cAttackBonuses.Count > 0 Then
                Dim index As Integer = 0
                For Each ab As AttackBonus In cAttackBonuses
                    index += 1
                    output.Append(ab.sHandle)
                    If index < cAttackBonuses.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property

    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("attack")
        writer.WriteElementString("range", sRange)
        writer.WriteElementString("target", sTarget)
        writer.WriteElementString("multitargets", bMultiTarget.ToString)
        writer.WriteElementString("desc", sDesc)
        For Each subitem As AttackBonus In cAttackBonuses
            subitem.ExportXML(writer)
        Next
        For Each dmg As String In cDamages.Keys
            writer.WriteStartElement(dmg)
            Dim subdmg As Damage = cDamages.Item(dmg)
            subdmg.ExportXML(writer)
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newAttackBonus As AttackBonus

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "attack" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "attackbonus" Then
                        newAttackBonus = New AttackBonus
                        newAttackBonus.ImportXML(reader)
                        cAttackBonuses.Add(newAttackBonus)
                    ElseIf reader.Name = "cEffect" Or reader.Name = "cHit" Or reader.Name = "cMiss" Then
                        ImportXML_Subdmg(reader, reader.Name)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "range"
                            sRange = reader.Value
                        Case "target"
                            sTarget = reader.Value
                        Case "multitarget"
                            bMultiTarget = CBool(reader.Value)
                        Case "desc"
                            sDesc = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "attack" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Function ImportXML_Subdmg(ByRef p_reader As Object, ByVal subdmgtype As String) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim subdmg As Damage = cDamages.Item(subdmgtype)
        Do While reader.Read
            If reader.NodeType = Xml.XmlNodeType.Element Then
                If reader.Name = "damage" Then
                    subdmg.ImportXML(reader)
                End If
            ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                If reader.Name = subdmgtype Then
                    Return True
                End If
            End If
        Loop
        Return False
    End Function
    Public Sub Copy(ByRef tocopy As Attack)
        Dim newAttackBonus As New AttackBonus
        Dim newDamage As New Damage
        sRange = tocopy.sRange
        sDesc = tocopy.sDesc
        sTarget = tocopy.sTarget
        bMultiTarget = tocopy.bMultiTarget
        For Each subitem As AttackBonus In tocopy.cAttackBonuses
            newAttackBonus.ClearAll()
            newAttackBonus.Copy(subitem)
            cAttackBonuses.Add(New AttackBonus(newAttackBonus))
        Next
        Dim types As New ArrayList
        types.Add("cHit")
        types.Add("cMiss")
        types.Add("cEffect")
        For Each dmg As String In types
            newDamage = New Damage
            newDamage.Copy(tocopy.cDamages.Item(dmg))
            cDamages.Remove(dmg)
            cDamages.Add(dmg, New Damage(newDamage))
        Next
    End Sub
    Public Sub ClearAll()
        sRange = ""
        sDesc = ""
        sTarget = ""
        bMultiTarget = False
        cAttackBonuses.Clear()
        cDamages.Clear()
        cDamages.Add("cHit", New Damage)
        cDamages.Add("cMiss", New Damage)
        cDamages.Add("cEffect", New Damage)
    End Sub
    Public ReadOnly Property HTML_Out(ByVal pow As Power) As String
        Get
            Dim output As New System.Text.StringBuilder
            If cAttackBonuses.Count = 0 Then
                output.Append("<div><i>Effect")
                If pow.sActionType.ToLower = "immediate interrupt" Or pow.sActionType.ToLower = "immediate reaction" Or pow.sActionType.ToLower = "free action" Then
                    output.Append(" (" & pow.sActionType & ")")
                End If
                output.Append(":</i> ")
                If sRange <> "" Then output.Append(sRange)
                If sRange <> "" And sTarget <> "" Then output.Append(" ")
                If sTarget <> "" Then output.Append("(" & sTarget & ")")
                If sRange <> "" Or sTarget <> "" Then output.Append("; ")
                If sDesc <> "" Then output.Append(sDesc & "; ")
                Dim dam As Damage = cDamages("cEffect")
                output.Append(dam.HTML_Out(pow) & "</div>")
            Else
                output.Append("<div><i>Attack")
                If pow.sActionType.ToLower = "immediate interrupt" Or pow.sActionType.ToLower = "immediate reaction" Then
                    output.Append("(" & pow.sActionType & ")")
                End If
                output.Append(":</i> ")
                If sRange <> "" Then output.Append(sRange)
                If sRange <> "" And sTarget <> "" Then output.Append(" ")
                If sTarget <> "" Then output.Append("(" & sTarget & ")")
                If sRange <> "" Or sTarget <> "" Then output.Append("; ")
                Dim index As Integer = 0
                For Each ab As AttackBonus In cAttackBonuses
                    index += 1
                    output.Append(ab.sHandle)
                    If index < cAttackBonuses.Count Then output.Append(", ")
                Next
                If sDesc <> "" Then output.Append("; " & sDesc)
                output.Append("</div>")
                Dim types As New ArrayList
                types.Add("cHit")
                types.Add("cMiss")
                types.Add("cEffect")
                For Each damkey As String In types
                    Dim dam As Damage = cDamages(damkey)
                    If dam.bIsValid Then
                        output.Append("<div><i>" & damkey.Substring(1) & ":</i> ")
                        output.Append(dam.HTML_Out(pow))
                        output.Append("</div>")
                    End If
                Next
            End If
            Return output.ToString
        End Get
    End Property
    Public ReadOnly Property text_out(ByVal pow As Power) As String
        Get
            Return text_out(pow, "")
        End Get
    End Property
    Public ReadOnly Property Text_Out(ByVal pow As Power, ByVal delim As String) As String
        Get
            Dim output As New System.Text.StringBuilder
            If cAttackBonuses.Count = 0 Then
                output.Append("Effect")
                If pow.sActionType = "immediate interrupt" Or pow.sActionType = "immediate reaction" Then
                    output.Append("(" & pow.sActionType & ")")
                End If
                output.Append(": ")
                If sDesc <> "" Then output.Append(sDesc & "; ")
                Dim dam As Damage = cDamages("cEffect")
                output.Append(dam.Text_Out(pow))
                output.Append(delim)
            Else
                output.Append("Attack")
                If pow.sActionType.ToLower = "immediate interrupt" Or pow.sActionType.ToLower = "immediate reaction" Then
                    output.Append("(" & pow.sActionType & ")")
                End If
                output.Append(": ")
                If sRange <> "" Then output.Append(sRange)
                If sRange <> "" And sTarget <> "" Then output.Append(" ")
                If sTarget <> "" Then output.Append("(" & sTarget & ")")
                If sRange <> "" Or sTarget <> "" Then output.Append("; ")
                Dim index As Integer = 0
                For Each ab As AttackBonus In cAttackBonuses
                    index += 1
                    output.Append(ab.sHandle)
                    If index < cAttackBonuses.Count Then output.Append(", ")
                Next
                If sDesc <> "" Then output.Append("; " & sDesc)
                output.Append(delim)
                Dim types As New ArrayList
                types.Add("cHit")
                types.Add("cMiss")
                types.Add("cEffect")
                For Each damkey As String In types
                    Dim dam As Damage = cDamages(damkey)
                    If dam.bIsValid Then
                        output.Append(damkey.Substring(1) & ": ")
                        output.Append(dam.Text_Out(pow))
                        output.Append(delim)
                    End If
                Next
            End If
            Return output.ToString
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterAttack" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Hit" And Not reader.IsEmptyElement Then
                        Dim tempDamage As Damage = cDamages("cHit")
                        ATXMLImport_Damage(reader, "Hit", tempDamage)
                    ElseIf reader.Name = "Miss" And Not reader.IsEmptyElement Then
                        Dim tempDamage As Damage = cDamages("cMiss")
                        ATXMLImport_Damage(reader, "Miss", tempDamage)
                    ElseIf reader.Name = "Effect" And Not reader.IsEmptyElement Then
                        Dim tempDamage As Damage = cDamages("cEffect")
                        ATXMLImport_Damage(reader, "Effect", tempDamage)
                    ElseIf reader.Name = "AttackBonuses" And Not reader.IsEmptyElement Then
                        ATXMLImport_AttackBonuses(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "Range"
                            sRange = reader.Value
                        Case "Targets"
                            sTarget = reader.Value
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterAttack" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_Damage(ByRef p_reader As Object, ByVal tag As String, ByRef p_damage As Damage)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim dam As Damage = p_damage
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = tag Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Damage" Then
                        dam.ATXMLImport(reader)
                    ElseIf reader.Name = "Sustains" And Not reader.IsEmptyElement Then
                        dam.ATXMLImport_Sustains(reader)
                    ElseIf reader.Name = "Aftereffects" And Not reader.IsEmptyElement Then
                        dam.ATXMLImport_AfterEffects(reader)
                    ElseIf reader.Name = "FailedSavingThrows" And Not reader.IsEmptyElement Then
                        dam.ATXMLImport_FailedSaves(reader)
                    ElseIf reader.Name = "Attacks" And Not reader.IsEmptyElement Then
                        dam.ATXMLImport_SecondaryAttacks(reader)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    If elementName = "Description" Then
                        dam.sDesc = reader.Value
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = tag Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ATXMLImport_AttackBonuses(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "AttackBonuses" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterPowerAttackNumber" Then
                        Dim tempAB As New AttackBonus
                        tempAB.nBonus = reader.GetAttribute("FinalValue")
                        GetXMLFields(reader, "MonsterPowerAttackNumber", "DefenseName", tempAB.sDefense)
                        cAttackBonuses.Add(New AttackBonus(tempAB))
                        tempAB.ClearAll()
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "AttackBonuses" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
End Class
Public Class AttackBonus
    Public nBonus As Integer
    Public sDefense As String
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As AttackBonus)
        Copy(cp)
    End Sub
    Public ReadOnly Property sHandle() As String
        Get
            If sDefense <> "" Then
                Return nBonus.ToString & " vs " & sDefense
            Else : Return ""
            End If
        End Get
    End Property
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("attackbonus")
        writer.WriteElementString("bonus", nBonus.ToString)
        writer.WriteElementString("defense", sDefense)
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "attackbonus" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "defense"
                            sDefense = reader.Value
                        Case "bonus"
                            nBonus = CInt(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "attackbonus" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As AttackBonus)
        sDefense = tocopy.sDefense
        nBonus = tocopy.nBonus
    End Sub
    Public Sub ClearAll()
        sDefense = ""
        nBonus = 0
    End Sub
End Class
Public Class Power
    Public sName, sType, sActionType, sTrigger, sUsage, sRequirements, sUsageDetails As String
    Public cKeywords, cAttacks As New ArrayList
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As power)
        Copy(cp)
    End Sub


    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("power")
        writer.WriteElementString("name", sName)
        writer.WriteElementString("type", sType)
        writer.WriteElementString("actiontype", sActionType)
        writer.WriteElementString("trigger", sTrigger)
        writer.WriteElementString("usage", sUsage)
        writer.WriteElementString("usagedetails", sUsageDetails)
        writer.WriteElementString("requirements", sRequirements)
        For Each subitem As Keyword In cKeywords
            subitem.ExportXML(writer)
        Next
        For Each subitem As Attack In cAttacks
            subitem.ExportXML(writer)
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newAttack As Attack
        Dim newKeyword As Keyword
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "power" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "attack" Then
                        newAttack = New Attack
                        newAttack.ImportXML(reader)
                        cAttacks.Add(newAttack)
                    ElseIf reader.Name = "keyword" Then
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
                        Case "type"
                            sType = reader.Value
                        Case "actiontype"
                            sActionType = reader.Value
                        Case "trigger"
                            sTrigger = reader.Value
                        Case "usage"
                            sUsage = reader.Value
                        Case "usagedetails"
                            sUsageDetails = reader.Value
                        Case "requirements"
                            sRequirements = reader.Value
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
    Public Sub Copy(ByRef tocopy As power)
        Dim newKeyword As New Keyword
        Dim newAttack As New Attack
        sName = tocopy.sName
        sType = tocopy.sType
        sActionType = tocopy.sActionType
        sTrigger = tocopy.sTrigger
        sUsage = tocopy.sUsage
        sUsageDetails = tocopy.sUsageDetails
        sRequirements = tocopy.sRequirements
        For Each subitem As Attack In tocopy.cAttacks
            newAttack.ClearAll()
            newAttack.Copy(subitem)
            cAttacks.Add(New Attack(newAttack))
        Next
        For Each subitem As Keyword In tocopy.cKeywords
            newKeyword.ClearAll()
            newKeyword.Copy(subitem)
            cKeywords.Add(New Keyword(newKeyword))
        Next
    End Sub
    Public Sub ClearAll()
        sName = ""
        sType = ""
        sActionType = ""
        sTrigger = ""
        sUsage = ""
        sUsageDetails = ""
        sRequirements = ""
        cKeywords.Clear()
        cAttacks.Clear()
    End Sub
    Public ReadOnly Property Text_Out(ByVal lines As String) As String
        Get
            Dim output As New System.Text.StringBuilder
            If lines.Contains("1") Then
                If (Not sName.ToLower.Contains("no name")) And (Not sName.ToLower.Contains("unnamed power")) Then
                    ' Add Power Name
                    output.Append(sName)
                End If
            End If
            If lines.Contains("2") Then
                If sUsage <> "" Then
                    output.Append(" * ")
                    output.Append(" " & sUsage)
                    If sUsageDetails <> "" Then
                        output.Append(" " & sUsageDetails)
                    End If
                End If
                If cKeywords.Count > 0 Then
                    Dim index As Integer = 0
                    output.Append(" (")
                    For Each key As Keyword In cKeywords
                        index += 1
                        output.Append(key.sName)
                        If index < cKeywords.Count Then output.Append(", ")
                    Next
                    output.Append(")")
                End If


                ' Finish First line
            End If
            ' Create Second Line
            If lines.Contains("3") Then
                If sRequirements <> "" Then output.AppendLine("Requirements: " & sRequirements)
                If sTrigger <> "" Then output.AppendLine("Trigger: " & sTrigger)
                For Each att As Attack In cAttacks
                    output.Append(att.Text_Out(Me))
                Next
            End If
            Return output.ToString
        End Get
    End Property

    Public ReadOnly Property HTML_Out() As String
        Get
            Dim output As New System.Text.StringBuilder
            If (Not sName.ToLower.Contains("no name")) And (Not sName.ToLower.Contains("unnamed power")) Then
                ' Add Type
                output.AppendLine("<div class='ggmed'>")
                If sType <> "" Then
                    output.Append("<font face='4etools symbols'>" & sTypeIcon & "</font> ")
                End If
                ' Add Power Name
                output.Append("<b>" & sName)
                If cKeywords.Count > 0 Then
                    Dim index As Integer = 0
                    output.Append("</b> (")
                    For Each key As Keyword In cKeywords
                        index += 1
                        output.Append(key.sName)
                        If index < cKeywords.Count Then output.Append(", ")
                    Next
                    output.Append(")<b>")
                End If
                If sUsage <> "" Then
                    output.Append(" <font face='4etools symbols'>+</font>")
                    output.Append(" " & sUsage & "</b>")
                    If sUsageDetails <> "" Then
                        If sUsage.ToLower = "recharge" And Val(sUsageDetails) > 0 Then
                            output.Append(" " & HTMLDice(Val(sUsageDetails)))
                        Else
                            output.Append(" " & sUsageDetails)
                        End If
                    End If
                Else
                    output.Append("</b>")
                End If


                ' Finish First line
                output.AppendLine("</div>")
            End If
            ' Create Second Line
            'If sDesc <> "" Then
            output.Append("<div class='gglt'><div class='ggindent'>")
            If sRequirements <> "" Then output.AppendLine("<i>Requirements:</i> " & sRequirements & "<br>")
            If sTrigger <> "" Then output.AppendLine("<i>Trigger:</i> " & sTrigger & "<br>")
            For Each att As Attack In cAttacks
                output.Append(att.HTML_Out(Me))
            Next
            output.AppendLine("</div></div>")
            'End If
            Return output.ToString
        End Get
    End Property

    Public ReadOnly Property sTypeIcon()
        Get
            If sType.ToLower = "basic melee" Then
                Return "m"
            ElseIf sType.ToLower = "basic ranged" Then
                Return "r"
            ElseIf sType.ToLower = "basic close burst" Or sType.ToLower = "basic close blast" Then
                Return "c"
            ElseIf sType.ToLower = "basic area" Then
                Return "a"
            ElseIf sType.ToLower = "melee" Then
                Return "M"
            ElseIf sType.ToLower = "ranged" Then
                Return "R"
            ElseIf sType.ToLower = "close burst" Or sType.ToLower = "close blast" Then
                Return "C"
            ElseIf sType.ToLower.Contains("area") Then
                Return "A"
            Else
                Return ""
            End If
        End Get
    End Property
    Public Sub ATXMLImport(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MonsterPower" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "Attacks" And Not reader.IsEmptyElement Then
                        ATXMLImport_Attacks(reader)

                    ElseIf reader.Name = "Keywords" Then
                        If Not reader.IsEmptyElement Then
                            ATXMLImport_Keywords(reader)
                        End If
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "Name"
                            sName = reader.Value
                        Case "Action"
                            sActionType = reader.Value
                        Case "Requirements"
                            sRequirements = reader.Value
                        Case "Usage"
                            Dim tempUsage As String
                            tempUsage = reader.Value
                            If tempUsage.ToLower.Contains("recharge") Then
                                sUsageDetails = tempUsage.Substring(tempUsage.IndexOf(" ") + 1)
                                sUsage = "Recharge"
                            Else
                                sUsage = tempUsage
                            End If
                        Case "UsageDetails"
                            sUsageDetails = reader.Value
                        Case "Trigger"
                            sTrigger = reader.Value
                        Case "Type"
                            sType += reader.Value
                        Case "IsBasic"
                            Dim tempBasic As Boolean
                            tempBasic = CBool(reader.Value)
                            If tempBasic Then sType = "Basic " + sType
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "MonsterPower" Then
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
    Public Sub ATXMLImport_Attacks(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Attacks" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterAttack" Then
                        Dim tempItem As New Attack
                        tempItem.ATXMLImport(reader)
                        If tempItem.sRange <> "" Or tempItem.sTarget <> "" Or tempItem.cAttackBonuses.Count > 0 Then
                            cAttacks.Add(New Attack(tempItem))
                            tempItem.ClearAll()
                        Else
                            cAttacks.Add(New Attack(tempItem))
                            tempItem.ClearAll()
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Attacks" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

End Class
