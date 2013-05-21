Public Class Combatant

    ' Data - Saved
    Private stats As Statblock
    Private sCustomName As String
    Private sMod As String
    Private sCombatNotesCoded As String

    ' Data - Encounter Specific
    Private nCurrHP, nDeathSaveFailed, nTempHP, nSurgesRemaining As Integer
    Public nRound, nInitRoll, nRandom3, nFighterNumber, nTempActionPoints, nTempMaxSurges As Integer
    Private sRoundStatus As String
    Public bReady, bHidden As Boolean

    Private PowersUsed As New ArrayList ' Contains string names


    ' Initiative
    Public ReadOnly Property nInitSequence() As Integer
        Get
            If nRandom3 = 0 Then
                Return 0
            Else
                Return (nRound * 10000000) + ((95 - nInitRoll) * 100000) + nRandom3
            End If
        End Get
    End Property

    Public Property sInitStatus() As String
        Get
            If Not bActive And Not bPC Then
                Return "Inactive"
            ElseIf sRoundStatus = "Ready" Or sRoundStatus = "Delay" Or sRoundStatus = "Rolling" Then
                Return sRoundStatus
            ElseIf nInitSequence > 0 Then
                Return "Rolled"
            Else
                Return "Reserve"
            End If
        End Get
        Set(ByVal value As String)
            If value = "Ready" Or value = "Delay" Or value = "Rolling" Then
                sRoundStatus = value
            ElseIf nInitSequence > 0 Then
                sRoundStatus = "Rolled"
            Else
                sRoundStatus = "Reserve"
            End If
        End Set
    End Property
    Public Function RollInitiative(ByRef die As DiceBag) As Integer
        Return RollInitiative(die.Roll(20) + stats.nInit, die)
    End Function
    Public Function RollInitiative(ByVal p_rollvalue As Integer, ByRef die As DiceBag) As Integer
        nInitRoll = p_rollvalue
        NewInitMod(die)
        sRoundStatus = "Rolling"
        Return nInitRoll
    End Function
    Public Sub NewInitMod(ByRef die As DiceBag)
        nRandom3 = die.Roll(500) + 200
        nRandom3 += ((90 - stats.nInit) * 1000)
    End Sub
    Public Sub InitClear()
        nRound = 0
        nInitRoll = 0
        nRandom3 = 0
        bReady = False
    End Sub
    Public ReadOnly Property sInitSort() As String
        Get
            Dim prefix As String = ""

            Select Case sInitStatus
                Case "Rolled"
                    Return nInitSequence.ToString("0000000000")
                Case "Delay"
                    prefix = "95"
                Case "Ready"
                    prefix = "96"
                Case "Inactive"
                    prefix = "97"
                Case "Rolling"
                    prefix = "98"
                Case Else
                    prefix = "99"
            End Select

            If bPC Then
                prefix &= "0"
            Else
                prefix &= "1"
            End If

            Return prefix & sCombatHandle
        End Get
    End Property


    ' Information
    Public ReadOnly Property sHandle() As String
        Get
            Return stats.sHandle
        End Get
    End Property
    Public ReadOnly Property sCombatHandle() As String
        Get
            If nFighterNumber > 0 Then
                '                Return sName & " - " & CStr(nFighterNumber).PadLeft(2, "0")
                Return stats.sName & " - " & CStr(nFighterNumber).PadLeft(2, "0")
            Else
                '                Return sName
                Return stats.sName
            End If
        End Get
    End Property

    Public Property sName() As String
        Get
            If sCustomName <> "" Then
                Return sCustomName
            Else
                Return stats.sName
            End If
        End Get
        Set(ByVal value As String)
            If value.Trim = stats.sName Then
                sCustomName = ""
            Else
                sCustomName = value.Trim
            End If
        End Set
    End Property
    Public ReadOnly Property sDefenses() As String
        Get
            Dim defenses As String = ""
            If stats.nAC > 1 Then defenses = defenses & stats.nAC.ToString
            If stats.nFort > 1 Then defenses = defenses & " " & stats.nFort.ToString
            If stats.nRef > 1 Then defenses = defenses & " " & stats.nRef.ToString
            If stats.nWill > 1 Then defenses = defenses & " " & stats.nWill.ToString
            Return defenses
        End Get
    End Property
    Public ReadOnly Property sStatusLine() As String
        Get
            Dim status As String = ""

            If nMaxHP < 1 Then
                Return "(no HP)"
            End If

            If bBloody Then
                If bActive Then
                    status = " (bloodied)"
                ElseIf nDeathSaveFailed = 0 Then
                    status = " (unconscious)"
                ElseIf nDeathSaveFailed < 3 Then
                    status = " (dying " & CStr(nDeathSaveFailed) & "/3)"
                End If
            End If

            If bActive And bReady Then
                status = " *Rdy*" & status
            End If

            Return sHP_Status & status
        End Get
    End Property
    Public ReadOnly Property sHP_Status() As String
        Get
            Dim value As String
            If bAlive Then
                If nMaxHP = 1 Then
                    value = "Minion"
                Else
                    value = CStr(nCurrHP) & "/" & CStr(nMaxHP)
                End If
                If nTempHP > 0 Then
                    value &= "+" & CStr(nTempHP)
                End If
            Else
                value = "Dead (" & CStr(nCurrHP) & "/" & CStr(nMaxHP) & ")"
            End If
            Return value
        End Get
    End Property
    Public ReadOnly Property cDisplayForeColor() As System.Drawing.Color
        Get
            If bHidden Then
                Return Color.LightGray
            ElseIf Not My.Settings.bWhiteMonsterBGs Or Not bAlive Or Not bActive Or bPC Or bCompanion Or bTrapHazard Or bBloody Then
                Return Color.White
            Else
                Return Color.Black
            End If
        End Get
    End Property
    Public ReadOnly Property cDisplayBackColor() As System.Drawing.Color
        Get
            If Not bAlive Then
                Return Color.Black
            End If

            If Not bActive Then
                Return Color.Gray
            End If

            If bPC Then
                Return Color.DarkGreen
            ElseIf bCompanion Then
                Return Color.DarkBlue
            ElseIf bTrapHazard Then
                Return Color.DarkOrange
            Else
                If My.Settings.bWhiteMonsterBGs And Not bBloody Then
                    Return Color.White
                Else
                    Return Color.DarkRed
                End If
            End If
        End Get
    End Property

    Public Property sRoleMod() As String
        Get
            If sMod <> "" Then
                Return sMod
            ElseIf bMinion Then
                Return "Minion"
            ElseIf bPC Then
                Return "PC"
            Else
                Return "Normal"
            End If
        End Get
        Set(ByVal value As String)
            Dim newMod As String = sMod
            If bMinion Or bPC Then ' Minions and PCs are always regular
                newMod = ""
            Else
                Select Case value.ToLower
                    Case "demi"
                        newMod = "Demi"
                    Case "semi"
                        newMod = "Semi"
                    Case "minion"
                        newMod = "Minion"
                    Case Else
                        newMod = ""
                End Select

                If newMod <> sMod Then
                    Dim nOldMaxHP As Integer = nMaxHP
                    sMod = newMod
                    If nOldMaxHP > nMaxHP Then ' HP went down
                        Damage(nOldMaxHP - nMaxHP)
                    ElseIf nOldMaxHP < nMaxHP Then ' HP went up
                        Heal(nMaxHP - nOldMaxHP)
                    End If
                End If
            End If
        End Set
    End Property
    Public ReadOnly Property bPC() As Boolean
        Get
            Return stats.bPC
        End Get
    End Property
    Public ReadOnly Property bCompanion() As Boolean
        Get
            Return stats.bCompanion
        End Get
    End Property
    Public ReadOnly Property bMinion() As Boolean
        Get
            Return stats.bMinion
        End Get
    End Property
    Public ReadOnly Property bTrapHazard() As Boolean
        Get
            Return stats.bTrapHazard
        End Get
    End Property
    Public ReadOnly Property nXP() As Integer
        Get
            If bMinion Or bPC Then ' Minions and PCs are always regular
                Return stats.nXP
            Else
                Select Case sMod
                    Case "Demi"
                        Return (stats.nXP * 2) \ 3
                    Case "Semi"
                        Return stats.nXP \ 3
                    Case "Minion"
                        Return stats.nXP \ 4
                    Case Else
                        Return stats.nXP
                End Select
            End If
        End Get
    End Property

    Public Property Stat() As Statblock
        Get
            Return stats
        End Get
        Set(ByVal newstat As Statblock)
            Dim nOldMaxHP As Integer = nMaxHP

            stats = newstat

            If nOldMaxHP > nMaxHP Then ' HP went down
                Damage(nOldMaxHP - nMaxHP)
            ElseIf nOldMaxHP < nMaxHP Then ' HP went up
                Heal(nMaxHP - nOldMaxHP)
            End If

            Dim newPowersUsed As New ArrayList
            For Each powused As String In PowersUsed
                For Each pow As StatPower In PowerList
                    If pow.sName = powused Then
                        newPowersUsed.Add(powused)
                    End If
                Next
            Next
            PowersUsed = newPowersUsed
        End Set
    End Property

    Public Property sCombatNotes() As String
        Get
            Return sCombatNotesCoded.Replace("###", ControlChars.NewLine)
        End Get
        Set(ByVal value As String)
            sCombatNotesCoded = value.Replace(ControlChars.NewLine, "###")
        End Set
    End Property


    ' Status
    Public ReadOnly Property bActive() As Boolean
        Get
            If nMaxHP < 1 Then
                Return True
            End If

            If nCurrHP > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bAlive() As Boolean
        Get
            If nMaxHP < 1 Then
                Return True
            End If

            If Not bPC Then
                Return bActive
            End If

            If nCurrHP > (-1 * nBloodyHP) And nDeathSaveFailed < 3 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bBloody() As Boolean
        Get
            If nCurrHP <= nBloodyHP And bAlive Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bDyingOrDead()
        Get

            If (bPC Or bCompanion) And nDeathSaveFailed > 0 Then
                Return True
            ElseIf Not (bPC Or bCompanion) And nCurrHP <= 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bUnconscious()
        Get
            If nCurrHP < 1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Sub Slay()
        If nCurrHP > 0 Then
            nCurrHP = 0
        End If
        nTempHP = 0
        nDeathSaveFailed = 3
        bReady = False
    End Sub
    Public Sub FailDeathSave()
        If nDeathSaveFailed < 3 Then
            nDeathSaveFailed = nDeathSaveFailed + 1
        Else
            nDeathSaveFailed = 3
        End If
    End Sub
    Public Sub UndoDeathSave()
        nDeathSaveFailed = nDeathSaveFailed - 1
        If nDeathSaveFailed < 0 Then
            nDeathSaveFailed = 0
        End If
    End Sub

    Public Sub ResetInit()
        sRoundStatus = ""
        bReady = False
        InitClear()
    End Sub
    Public Sub ResetHealth()
        nCurrHP = nMaxHP
        nDeathSaveFailed = 0
        ResetTempHP()
        nSurgesRemaining = Stat.nSurges
    End Sub
    Public Sub ResetActionPoints()
        nTempActionPoints = Stat.nActionPoints
    End Sub
    Public Sub ResetHealingSurges()
        nTempMaxSurges = Stat.nSurges
    End Sub
    Public Sub ResetTempHP()
        nTempHP = 0
        nDeathSaveFailed = 0
    End Sub
    Public Sub UpdateStatus()
        If Not bAlive Then
            Slay()
        ElseIf Not bActive Then
            If Not bPC Then
                Slay()
            Else
                bReady = False
            End If
        End If
    End Sub


    ' Hit Points
    Public ReadOnly Property nMaxHP() As Integer
        Get
            Select Case sMod
                Case "Demi"
                    Return stats.nMaxHP \ 2
                Case "Semi"
                    Return stats.nMaxHP \ 4
                Case "Minion"
                    Return 1
                Case Else
                    Return stats.nMaxHP
            End Select
        End Get
    End Property
    Public ReadOnly Property nCurHP() As Integer
        Get
            Return nCurrHP
        End Get
    End Property
    Public ReadOnly Property nSurgesLeft() As Integer
        Get
            Return nSurgesRemaining
        End Get
    End Property

    Public ReadOnly Property nBloodyHP() As Integer
        Get
            Return nMaxHP \ 2
        End Get
    End Property
    Public ReadOnly Property nSurgeValue() As Integer
        Get
            If stats.sType.ToLower.Contains("dragonborn") Then
                Return (nMaxHP \ 4) + CInt(((stats.nCon - 10) / 2))
            Else
                Return nMaxHP \ 4
            End If
        End Get
    End Property

    Public Sub Damage(ByVal p_nDamage As Integer)
        If p_nDamage <= 0 Then
            Exit Sub
        End If

        nTempHP = nTempHP - p_nDamage
        If nTempHP < 0 Then
            nCurrHP = nCurrHP + nTempHP
            nTempHP = 0
        End If

        UpdateStatus()
    End Sub
    Public Sub Heal(ByVal p_nHealing As Integer)
        If p_nHealing <= 0 Then
            Exit Sub
        End If

        If nCurrHP <= 0 Then
            nCurrHP = 0
            ' nDeathSaveFailed = 0 -- Should not reset when healed
        End If

        nCurrHP = nCurrHP + p_nHealing
        If nCurrHP > nMaxHP Then
            nCurrHP = nMaxHP
        End If

        UpdateStatus()
    End Sub
    Public Sub AddTempHP(ByVal p_nTemp As Integer)
        If p_nTemp <= 0 Then
            Exit Sub
        End If
        If Not bAlive Then
            Exit Sub
        End If
        If p_nTemp > nTempHP Then
            nTempHP = p_nTemp
        End If
    End Sub
    Public Sub ModSurges(ByVal p_nSurges As Integer)
        If (p_nSurges + nSurgesRemaining) <= Stat.nSurges And (p_nSurges + nSurgesRemaining) >= 0 Then
            nSurgesRemaining += p_nSurges
        End If
    End Sub
    Public Sub ModMaxSurges(ByVal p_nSurges As Integer)
        If (p_nSurges + nTempMaxSurges) >= 0 Then
            nTempMaxSurges += p_nSurges
            If (p_nSurges + nSurgesRemaining) <= nTempMaxSurges And (p_nSurges + nSurgesRemaining) >= 0 Then
                nSurgesRemaining += p_nSurges
            End If
        End If
    End Sub
    Public ReadOnly Property sSurgeView() As String
        Get
            Return CStr(nSurgesRemaining) & "/" & CStr(nTempMaxSurges)
        End Get
    End Property


    ' Powers
    Public Property bPowerUsed(ByVal powname As String) As Boolean
        Get
            If PowersUsed.Contains(powname) Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(ByVal value As Boolean)
            If value = False Then
                PowersUsed.Remove(powname)
            Else
                For Each pow As StatPower In PowerList
                    If pow.sName = powname And Not PowersUsed.Contains(pow.sName) Then
                        PowersUsed.Add(pow.sName)
                    End If
                Next
            End If
        End Set
    End Property
    Public ReadOnly Property PowerList() As ArrayList
        Get
            Dim list As New ArrayList

            For Each pow As StatPower In Stat.PowerList
                list.Add(pow)
            Next

            If Stat.sRegen <> "" Then
                Dim pow As New StatPower("Regeneration " & CStr(Val(Stat.sRegen)), "", "", "", "Regeneration", 0)
                list.Add(pow)
            End If

            'If Stat.nActionPoints > 0 Then
            'For i As Integer = 1 To Stat.nActionPoints
            'Dim pow As New Power("Action Point " & CStr(i), "", "", "", "Action Point", 0)
            'list.Add(pow)
            'Next
            If nTempActionPoints > 0 Then
                For i As Integer = 1 To nTempActionPoints
                    Dim pow As New StatPower("Action Point " & CStr(i), "", "", "", "Action Point", 0)
                    list.Add(pow)
                Next
            End If
            If Stat.nPowerPoints > 0 Then
                For i As Integer = 1 To Stat.nPowerPoints
                    Dim pow As New StatPower("Power Point " & CStr(i), "", "", "", "Power Point", 0)
                    list.Add(pow)
                Next
            End If

            If bPC Then
                Dim pow As New StatPower("Action Point", "", "", "", "Action Point", 0)
                list.Add(pow)
                pow = New StatPower("Second Wind", "", "standard; encounter", "", "Second Wind", 0)
                list.Add(pow)
            End If

            Return list
        End Get
    End Property
    Public Sub ResetPowersUsage(ByVal bResetDaily As Boolean, ByVal bResetAction As Boolean)
        If bResetDaily Then
            PowersUsed.Clear()
        Else
            For Each pow As StatPower In PowerList
                If bPowerUsed(pow.sName) And Not pow.bDaily And Not pow.bItem And Not pow.bPowerPoint Then
                    If pow.bActionPoint And Not bResetAction Then
                    Else
                        bPowerUsed(pow.sName) = False
                    End If
                End If
            Next
        End If
    End Sub


    ' Constructors
    Public Sub New()
        ClearAll()
        stats = New Statblock
        sRoleMod = ""
    End Sub
    Public Sub New(ByRef p_stat As Statblock)
        ClearAll()
        stats = p_stat
        sRoleMod = ""
        ResetInit()
        ResetHealth()
        sCustomName = stats.sDisplayName
        ResetHealingSurges()
        ResetActionPoints()
        nTempMaxSurges = stats.nSurges
    End Sub
    Public Sub New(ByRef p_stat As Statblock, ByVal p_rolemod As String)
        ClearAll()
        stats = p_stat
        sRoleMod = p_rolemod
        ResetInit()
        ResetHealth()
        ResetHealingSurges()
        ResetActionPoints()
    End Sub


    ' Clear
    Public Sub ClearAll()
        stats = New Statblock
        sCustomName = ""
        sMod = ""

        nFighterNumber = 0
        sCombatNotesCoded = ""

        sRoundStatus = ""
        nCurrHP = 0
        nDeathSaveFailed = 0
        nTempHP = 0
        nInitRoll = 0
        nRound = 0
        nRandom3 = 0
        bReady = False
        bHidden = False
        nTempActionPoints = stats.nActionPoints
        nTempMaxSurges = stats.nSurges
        PowersUsed.Clear()
    End Sub


    ' Library Update
    Public Sub UpdateLibrary(ByRef p_lib As StatLibrary, ByVal bUpdateFromLibrary As Boolean)
        If p_lib.Contains(stats.sHandle) Then
            If bUpdateFromLibrary Then
                Stat = p_lib(stats.sHandle)
            End If
        Else
            If stats.Valid Then
                p_lib(stats.sHandle) = stats
            End If
        End If
        'If stats.Valid And Not p_lib.Contains(stats.sHandle) Then
        '    p_lib(stats.sHandle) = stats
        'End If
    End Sub


    ' XML Import/Export
    Public Sub ExportXML(ByRef p_writer As Object, ByVal p_bOngoing As Boolean)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("combatant")

        writer.WriteElementString("customname", sCustomName)
        writer.WriteElementString("rolemod", sMod)
        writer.WriteElementString("notes", sCombatNotesCoded)

        stats.ExportXML(p_writer)

        If p_bOngoing Then
            writer.WriteElementString("nRound", CStr(nRound))
            writer.WriteElementString("nInitRoll", CStr(nInitRoll))
            writer.WriteElementString("nRandom3", CStr(nRandom3))
            writer.WriteElementString("nFighterNumber", CStr(nFighterNumber))
            writer.WriteElementString("sRoundStatus", sRoundStatus)
            writer.WriteElementString("bReady", CStr(bReady))
        End If
        writer.WriteElementString("bHidden", CStr(bHidden))

        If bPC Or p_bOngoing Then
            writer.WriteElementString("nCurrHP", CStr(nCurrHP))
            writer.WriteElementString("nDeathSaveFailed", CStr(nDeathSaveFailed))
            writer.WriteElementString("nTempHP", CStr(nTempHP))
            writer.WriteElementString("nSurgesRemaining", CStr(nSurgesRemaining))
            writer.WriteElementString("nTempActionPoints", CStr(nTempActionPoints))
            writer.WriteElementString("nTempMaxSurges", CStr(nTempMaxSurges))

            For Each pow As String In PowersUsed
                writer.WriteElementString("PowerUsed", pow)
            Next
        End If

        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "combatant" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "statblock" Then
                        stats = New Statblock
                        stats.ImportXML(reader)
                        ResetInit()
                        ResetHealth()
                        ResetHealingSurges()
                        ResetActionPoints()
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "customname"
                            sCustomName = reader.Value
                        Case "rolemod"
                            sMod = reader.Value
                        Case "notes"
                            sCombatNotesCoded = reader.Value

                        Case "nCurrHP"
                            nCurrHP = Val(reader.Value)
                        Case "nSurgesRemaining"
                            nSurgesRemaining = Val(reader.Value)
                        Case "nDeathSaveFailed"
                            nDeathSaveFailed = Val(reader.Value)
                        Case "nTempHP"
                            nTempHP = Val(reader.Value)
                        Case "nRound"
                            nRound = Val(reader.Value)
                        Case "nInitRoll"
                            nInitRoll = Val(reader.Value)
                        Case "nRandom3"
                            nRandom3 = Val(reader.Value)
                        Case "nFighterNumber"
                            nFighterNumber = Val(reader.Value)
                        Case "nTempActionPoints"
                            nTempActionPoints = Val(reader.Value)
                        Case "nTempMaxSurges"
                            nTempMaxSurges = Val(reader.Value)
                        Case "sRoundStatus"
                            sRoundStatus = reader.Value
                        Case "bReady"
                            bReady = CBool(reader.Value)
                        Case "bHidden"
                            bHidden = CBool(reader.Value)
                        Case "PowerUsed"
                            PowersUsed.Add(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "combatant" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function

End Class
