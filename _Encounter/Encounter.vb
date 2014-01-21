Public Class Encounter

    ' Class Data
    Private StatLib As StatLibrary
    Public EncounterDice As DiceBag
    Public Roster As New SortedList
    Public bUseRollMod As Boolean
    Private sGlobalNotesCoded As String
    Private sSelectedFighterHandle As String

    Public ActiveEffects As New Hashtable
    Private nNextEffectID As Integer = 1

    ' Notes
    Public Property sGlobalNotes() As String
        Get
            Return sGlobalNotesCoded.Replace("###", ControlChars.NewLine)
        End Get
        Set(ByVal value As String)
            sGlobalNotesCoded = value.Replace(ControlChars.NewLine, "###")
        End Set
    End Property


    ' Initiative Lists
    Public ReadOnly Property RolledList() As SortedList
        Get
            Dim list As New SortedList
            For Each fighter As Combatant In Roster.Values
                If fighter.sInitStatus = "Rolled" Then
                    If list.Contains(fighter.nInitSequence) Then
                        fighter.sInitStatus = "Rolling"
                    Else
                        list.Add(fighter.nInitSequence, fighter.sCombatHandle)
                    End If
                End If
            Next
            Return list
        End Get
    End Property
    Public ReadOnly Property ReserveList() As ArrayList
        Get
            Dim list As New ArrayList
            For Each fighter As Combatant In Roster.Values
                If fighter.sInitStatus = "Reserve" Then
                    list.Add(fighter.sCombatHandle)
                End If
            Next
            list.Sort()
            Return list
        End Get
    End Property

    Public ReadOnly Property InactiveRolledFighters() As ArrayList
        Get
            Dim list As New ArrayList
            For Each fighter As Combatant In Roster.Values
                If Not fighter.bActive And fighter.nInitSequence > 0 Then
                    list.Add(fighter)
                End If
            Next
            Return list
        End Get
    End Property
    Public ReadOnly Property DelayingFighters() As ArrayList
        Get
            Dim list As New ArrayList
            For Each fighter As Combatant In Roster.Values
                If fighter.sInitStatus = "Delay" Then
                    list.Add(fighter)
                End If
            Next
            Return list
        End Get
    End Property


    Public ReadOnly Property sCurrentFighterHandle() As String
        Get
            If RolledList.Count > 0 Then
                Return RolledList.Values(0)
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property sCurrentFighter() As Combatant
        Get
            Return Roster(sCurrentFighterHandle)
        End Get
    End Property
    Public ReadOnly Property sPriorFighterHandle() As String
        Get
            If RolledList.Count > 0 Then
                Return RolledList.Values(RolledList.Count - 1)
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property sPriorFighter() As Combatant
        Get
            Return Roster(sPriorFighterHandle)
        End Get
    End Property
    Public ReadOnly Property nCurrentRound() As Integer
        Get
            Dim round As Integer = 999
            For Each sHandle As String In RolledList.Values
                Dim fighter As Combatant = Roster(sHandle)
                If fighter.nRound < round Then
                    round = fighter.nRound
                End If
            Next
            If round = 999 Then
                If My.Settings.bSurpriseRound Then
                    Return 0
                Else
                    Return 1
                End If
            Else
                Return round
            End If
        End Get
    End Property
    Public ReadOnly Property nCurrentInitSequence() As Integer
        Get
            If bOngoingFight Then
                Return sCurrentFighter.nInitSequence
            Else
                Return 0
            End If
        End Get
    End Property


    ' Encounter Detail
    Public ReadOnly Property nEncounterLevel() As Integer
        Get
            Return DnD4e_EncounterLevel(nPartySize, nEncounterXP)
        End Get
    End Property
    Public ReadOnly Property nEncounterXP() As Integer
        Get
            Dim xptotal As Integer = 0
            For Each fighter As Combatant In Roster.Values
                If Not fighter.bPC And Not fighter.bCompanion Then
                    xptotal += fighter.nXP
                End If
            Next
            Return xptotal
        End Get
    End Property
    Public ReadOnly Property nPartySize() As Integer
        Get
            Dim nPCCount As Integer = 0
            For Each fighter As Combatant In Roster.Values
                If fighter.bPC Or fighter.bCompanion Then
                    nPCCount += 1
                End If
            Next
            Return nPCCount
        End Get
    End Property


    Public ReadOnly Property bOngoingFight() As Boolean
        Get
            If Roster.Count = ReserveList.Count Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property


    ' Data Functions
    Public Sub Add(ByRef p_stat As Statblock, ByVal bLibUpdate As Boolean)
        Dim newcombatant As New Combatant(p_stat)
        Add(newcombatant, bLibUpdate, True)
    End Sub
    Public Sub Add(ByRef p_stat As Statblock, ByVal p_rolemod As String, ByVal bLibUpdate As Boolean)
        Dim newcombatant As New Combatant(p_stat, p_rolemod)
        Add(newcombatant, bLibUpdate, True)
    End Sub
    Public Sub Add(ByRef p_combatant As Combatant, ByVal bLibUpdate As Boolean, ByVal bConfigEntry As Boolean)
        If bConfigEntry Then
            If Not p_combatant.bPC And p_combatant.nFighterNumber = 0 Then
                p_combatant.nFighterNumber = 1
            End If
        End If
        Do While Roster.Contains(p_combatant.sCombatHandle)
            Dim fighter As Combatant = Roster(p_combatant.sCombatHandle)
            p_combatant.nFighterNumber = fighter.nFighterNumber + 1
            If p_combatant.nFighterNumber < 2 Then
                p_combatant.nFighterNumber += 1
            End If
        Loop
        Roster.Add(p_combatant.sCombatHandle, p_combatant)
        If bLibUpdate Then p_combatant.UpdateLibrary(StatLib, bConfigEntry)
        If Not bUseRollMod Then
            p_combatant.sRoleMod = ""
        End If
    End Sub

    Public Sub ResetEncounter(ByVal bPCReset As Boolean)
        Dim tempEffects As New Hashtable
        For Each eff As Effect In ActiveEffects.Values
            If eff.DurationCode = Effect.Duration.Permanent And eff.bActive(nCurrentInitSequence) Then
                tempEffects.Add(eff.nEffectID, eff)
            End If
        Next
        For Each fighter As Combatant In Roster.Values
            fighter.ResetInit()
            If Not fighter.bPC Or bPCReset Or fighter.bCompanion Then
                fighter.ResetHealth()
                fighter.ResetPowersUsage(True, True)
                fighter.ResetActionPoints()
                fighter.ResetHealingSurges()
            End If
        Next
        ClearSelectedFighter()
        ActiveEffects.Clear()
        For Each eff As Effect In tempEffects.Values
            ActiveEffects.Add(eff.nEffectID, eff)
        Next
        tempEffects.Clear()
    End Sub
    Public Sub ResetPCHealth()
        For Each fighter As Combatant In Roster.Values
            If fighter.bPC Or fighter.bCompanion Then
                fighter.ResetHealth()
            End If
        Next
    End Sub

    Public Sub TakeShortRest()
        ClearNPCs()
        ResetEncounter(False)
        For Each fighter As Combatant In Roster.Values
            If fighter.bPC Then
                fighter.ResetTempHP()
                fighter.ResetPowersUsage(False, False)
            End If
            If fighter.nSurgesLeft > fighter.Stat.nSurges Then
                fighter.nTempMaxSurges = fighter.Stat.nSurges
                fighter.ResetHealth()
            End If
        Next
    End Sub
    Public Sub TakeShortRestAddActionPoint()
        ClearNPCs()
        ResetEncounter(False)
        For Each fighter As Combatant In Roster.Values
            If fighter.bPC Then
                fighter.ResetTempHP()
                fighter.ResetPowersUsage(False, False)
                fighter.nTempActionPoints += 1
            End If
            If fighter.nSurgesLeft > fighter.Stat.nSurges Then
                fighter.nTempMaxSurges = fighter.Stat.nSurges
                fighter.ResetHealth()
            End If
        Next
    End Sub

    Public Sub TakeExtendedRest()
        ClearNPCs()
        ResetEncounter(True)
    End Sub

    Public Sub ClearPCs()
        Dim toRemove As New ArrayList
        For Each fighter As Combatant In Roster.Values
            If fighter.bPC Or fighter.bCompanion Then
                toRemove.Add(fighter.sCombatHandle)
            End If
        Next
        For Each handle As String In toRemove
            Roster.Remove(handle)
        Next
        ResetEncounter(True)
    End Sub
    Public Sub ClearNPCs()
        Dim toRemove As New ArrayList
        For Each fighter As Combatant In Roster.Values
            If Not fighter.bPC And Not fighter.bCompanion Then
                toRemove.Add(fighter.sCombatHandle)
            End If
        Next
        For Each handle As String In toRemove
            Roster.Remove(handle)
        Next
        ResetEncounter(False)
    End Sub

    Public Sub UpdateAllStats(ByVal bConfigEntries As Boolean)
        For Each fighter As Combatant In Roster.Values
            fighter.UpdateLibrary(StatLib, bConfigEntries)
        Next
    End Sub


    ' Initiative Functions
    Public Sub StartFight(ByVal bGroupSimilar As Boolean)
        If bGroupSimilar Then
            RollAllInitGrouped()
        Else
            RollAllInitUngrouped()
        End If
        oSelectedFighter = GetCurrentFighter()
    End Sub
    Public Sub RollAllInitUngrouped()
        For Each fighter As Combatant In Roster.Values
            If fighter.sInitStatus <> "Rolled" Then
                fighter.ResetInit()
                fighter.RollInitiative(EncounterDice)
                fighter.nRound = nCurrentRound
                FighterInitUpdate(fighter, True)
                fighter.sInitStatus = "Rolled"
            End If
        Next
        FighterStartTurn(sCurrentFighterHandle)
    End Sub
    Public Sub RollAllInitGrouped()
        Dim initlist As New Hashtable
        Dim firstroller As Combatant

        For Each fighter As Combatant In Roster.Values
            If initlist.Contains(fighter.sHandle) Then
                If fighter.sInitStatus <> "Rolled" Then
                    firstroller = Roster(initlist(fighter.sHandle))
                    fighter.ResetInit()
                    FighterInitUpdate(fighter.sCombatHandle, firstroller.nRound, _
                                      firstroller.nInitRoll, firstroller.nRandom3, True)
                End If
            Else
                If fighter.sInitStatus <> "Rolled" Then
                    fighter.ResetInit()
                    fighter.RollInitiative(EncounterDice)
                    fighter.nRound = nCurrentRound
                    FighterInitUpdate(fighter, True)
                End If
                initlist.Add(fighter.sHandle, fighter.sCombatHandle)
            End If
        Next
        FighterStartTurn(sCurrentFighterHandle)
    End Sub

    Public Sub RollOneInit(ByRef fighter As Combatant)
        If Not fighter Is Nothing Then
            If fighter.sInitStatus <> "Rolled" Then
                fighter.ResetInit()
                fighter.RollInitiative(EncounterDice)
                fighter.nRound = nCurrentRound
                FighterInitUpdate(fighter, True)
                fighter.sInitStatus = "Rolled"
            End If
        End If
        If fighter.sCombatHandle = sCurrentFighterHandle Then
            FighterStartTurn(sCurrentFighterHandle)
        End If
    End Sub

    Public Function sInitSortvalue(ByRef fighter As Combatant) As String
        Return fighter.sInitSort
    End Function

    Public Function GetFighterByIndex(ByVal index As Integer) As Combatant
        Dim list As New SortedList
        For Each fighter As Combatant In Roster.Values
            list.Add(sInitSortvalue(fighter), fighter)
        Next
        If index >= list.Count Then
            Return Nothing
        End If
        Return list.Values(index)
    End Function
    Public Function GetCurrentFighter() As Combatant
        Return GetFighterByIndex(0)
    End Function

    Public Sub FinishCurrentTurn()
        If RolledList.Count > 0 Then
            Dim fighter As Combatant = GetCurrentFighter()
            FighterEndTurn(fighter.sCombatHandle)
            SkipInactive()
            ReturnDelay()
            SelectCurrentFighter()
            FighterStartTurn(sSelectedFighter)
        End If
    End Sub
    Public Sub BeginTurn()
        SelectCurrentFighter()
        FighterStartTurn(sSelectedFighter)
    End Sub
    Private Sub FighterStartTurn(ByVal p_sCombatHandle As String, Optional ByVal bBackup As Boolean = False)
        Dim fighter As Combatant = Roster(p_sCombatHandle)
        If Not bBackup Then
            EffectRemoveStart(fighter)
            fighter.bReady = False
            If My.Settings.bRollPowerRecharge = True Then PowerCheckRecharge(fighter)
            If My.Settings.bOngoingPopup = True Then OngoingDamageCheck(fighter)
        End If
    End Sub
    Private Sub FighterEndTurn(ByVal p_sCombatHandle As String)
        Dim fighter As Combatant = Roster(p_sCombatHandle)
        EffectRemoveEnd(fighter)
        If My.Settings.bRollEffectSaves = True Then EffectMakeSaves(fighter)
        FighterInitUpdate(fighter.sCombatHandle, fighter.nRound + 1, fighter.nInitRoll, _
                          fighter.nRandom3, True)
    End Sub
    Private Sub ReturnDelay()
        Dim nlowestactiveint As Integer = nCurrentInitSequence
        If nlowestactiveint > 0 Then
            For Each fighter As Combatant In DelayingFighters
                If fighter.nInitSequence < nlowestactiveint Then
                    fighter.sInitStatus = ""
                End If
            Next
        End If
    End Sub
    Private Sub SkipInactive()
        Dim nlowestactiveint As Integer = nCurrentInitSequence
        If nlowestactiveint > 0 Then
            For Each fighter As Combatant In InactiveRolledFighters
                If fighter.nInitSequence < nlowestactiveint Then
                    FighterStartTurn(fighter.sCombatHandle)
                    FighterEndTurn(fighter.sCombatHandle)
                End If
            Next
        End If
    End Sub

    Public Sub FighterUndoTurn(ByVal p_sCombatHandle As String)
        Dim fighter As Combatant = Roster(p_sCombatHandle)
        FighterUndoTurn(fighter)
    End Sub
    Public Sub FighterUndoTurn(ByRef fighter As Combatant)
        If Not fighter Is Nothing Then
            Dim newround As Integer = fighter.nRound
            newround -= 1
            If newround < 0 Then
                newround = 0
            End If

            FighterInitUpdate(fighter.sCombatHandle, newround, fighter.nInitRoll, fighter.nRandom3, True)
            sSelectedFighter = sCurrentFighterHandle
            FighterStartTurn(sCurrentFighterHandle, True)
        End If
    End Sub

    Public Sub FighterInitRollUpdate(ByVal p_sCombatHandle As String, ByVal p_nInit As Integer)
        If Roster.Contains(p_sCombatHandle) Then
            Dim fighter As Combatant = Roster(p_sCombatHandle)

            FighterInitUpdate(p_sCombatHandle, fighter.nRound, p_nInit, fighter.nRandom3, True)

            If fighter.sCombatHandle = sCurrentFighterHandle Then
                FighterStartTurn(sCurrentFighterHandle)
            End If
        End If
    End Sub
    Public Sub FighterInitUpdate(ByVal p_sCombatHandle As String, ByVal p_nRound As Integer, _
                                 ByVal p_nInit As Integer, ByVal p_nRandom3 As Integer, _
                                 ByVal p_bGoAfter As Boolean)
        If Roster.Contains(p_sCombatHandle) Then
            Dim fighter As Combatant = Roster(p_sCombatHandle)

            fighter.nRound = p_nRound
            fighter.nInitRoll = p_nInit
            fighter.nRandom3 = p_nRandom3

            FighterInitUpdate(fighter, p_bGoAfter)
        End If
    End Sub
    Public Sub FighterInitUpdate(ByRef fighter As Combatant, ByVal p_bGoAfter As Boolean)
        If Not fighter Is Nothing Then
            fighter.sInitStatus = "Rolling"

            Do While RolledList.Contains(fighter.nInitSequence)
                If p_bGoAfter Then
                    fighter.nRandom3 += 1
                Else
                    fighter.nRandom3 -= 1
                End If
            Loop

            fighter.sInitStatus = "Rolled"
        End If
    End Sub

    Public Sub MoveToTop(ByRef fighter As Combatant)
        If Not fighter Is Nothing Then
            FighterInitMatch(fighter.sCombatHandle, sCurrentFighterHandle, False)
        End If
    End Sub
    Public Sub FighterInitMatch(ByVal sMovingHandle As String, ByVal sTargetHandle As String, _
                                ByVal bMoveAfter As Boolean)
        Dim target As Combatant = Roster(sTargetHandle)

        FighterInitUpdate(sMovingHandle, target.nRound, target.nInitRoll, target.nRandom3, bMoveAfter)
        If sMovingHandle = sCurrentFighterHandle Then
            FighterStartTurn(sCurrentFighterHandle)
        End If
    End Sub

    Public Sub SetInitStatus(ByVal p_sCombatHandle As String, ByVal p_status As String)
        Dim fighter As Combatant = Roster(p_sCombatHandle)
        SetInitStatus(fighter, p_status)
    End Sub
    Public Sub SetInitStatus(ByRef fighter As Combatant, ByVal p_status As String)
        If Not fighter Is Nothing Then
            Select Case p_status
                Case "Ready"
                    'If fighter.sCombatHandle <> sCurrentFighterHandle Then
                    '    EffectRemoveStart(fighter)
                    'End If
                    'EffectRemoveEnd(fighter)
                    'fighter.InitClear()
                    'fighter.sInitStatus = p_status
                    If fighter.sInitStatus <> "Reserve" Then
                        fighter.bReady = True
                    End If
                Case "Delay"
                    If fighter.sCombatHandle <> sCurrentFighterHandle Then
                        EffectRemoveStart(fighter)
                    End If
                    EffectRemoveEndDelay(fighter)
                    'fighter.InitClear()
                    FighterInitUpdate(fighter.sCombatHandle, fighter.nRound + 1, fighter.nInitRoll, fighter.nRandom3, True)
                    fighter.sInitStatus = p_status
                Case "Reserve"
                    fighter.ResetInit()
                    If Not fighter.bPC Then
                        fighter.ResetHealth()
                    End If
                    EffectRemoveAllByTarget(fighter.sCombatHandle)
                Case Else
            End Select
        End If
    End Sub


    ' Selected functions
    Public Property sSelectedFighter() As String
        Get
            Return sSelectedFighterHandle
        End Get
        Set(ByVal value As String)
            If Roster.Contains(value) Then
                sSelectedFighterHandle = value
            Else
                sSelectedFighterHandle = ""
            End If
        End Set
    End Property
    Public Property oSelectedFighter() As Combatant
        Get
            If sSelectedFighterHandle <> "" And Roster.Contains(sSelectedFighterHandle) Then
                Return Roster(sSelectedFighterHandle)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Combatant)
            sSelectedFighter = value.sCombatHandle
        End Set
    End Property
    Public Sub ClearSelectedFighter()
        sSelectedFighterHandle = ""
    End Sub
    Public ReadOnly Property bSelectedFighter() As Boolean
        Get
            If sSelectedFighterHandle = "" Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Public Sub SelectCurrentFighter()
        oSelectedFighter = GetCurrentFighter()
    End Sub


    ' Effect functionality
    Public Sub EffectAdd(ByRef eff As Effect)
        EffectAdd(eff.sName, eff.sSourceHandle, eff.sTargetHandle, eff.DurationCode, eff.bBeneficial, eff.bHidden)
    End Sub
    Public Sub EffectAdd(ByVal p_sName As String, ByVal p_sSource As String, ByVal p_sTarget As String, _
                   ByVal p_Dur As Effect.Duration, ByVal p_bBeni As Boolean, ByVal p_bHidden As Boolean)
        Dim neweffect As New Effect(p_sName, nNextEffectID, p_sSource, p_sTarget, _
                                    EffectTillRound(p_sSource, p_sTarget, p_Dur), _
                                    p_Dur, p_bBeni, p_bHidden)

        If neweffect.bValid Then
            If Not ActiveEffects.Contains(nNextEffectID) Then
                ' Remove prior marks if effect is a mark
                If neweffect.bIsMark Then
                    EffectRemoveMarksByTarget(p_sTarget)
                End If
                If neweffect.bIsStance Then
                    EffectRemoveStances(p_sTarget)
                End If
                neweffect.SetActive()
                ActiveEffects.Add(neweffect.nEffectID, neweffect)
                nNextEffectID += 1
            End If
        End If
    End Sub
    Public Sub EffectChange(ByRef eff As Effect)
        If eff.bValid Then
            If ActiveEffects.Contains(eff.nEffectID) Then
                eff.nEndInitSeq = CType(ActiveEffects(eff.nEffectID), Effect).nEndInitSeq
                ActiveEffects(eff.nEffectID) = eff
            End If
        End If
    End Sub
    Public Sub EffectRemove(ByVal p_nID As Integer)
        If ActiveEffects.Contains(p_nID) Then
            CType(ActiveEffects(p_nID), Effect).SetInactive(nCurrentInitSequence)
        End If
    End Sub
    Public Sub EffectRemoveAllByTarget(ByVal p_sTargetHandle As String)
        Dim list As New ArrayList

        For Each eff As Effect In EffectsByTarget(p_sTargetHandle)
            list.Add(eff.nEffectID)
        Next

        For Each id As Integer In list
            EffectRemove(id)
        Next
    End Sub
    Public Sub EffectRemoveMarksByTarget(ByVal sTarget As String)
        Dim list As New ArrayList
        For Each eff As Effect In EffectsByTarget(sTarget)
            If eff.bIsMark Then
                list.Add(eff)
            End If
        Next

        For Each eff As Effect In list
            EffectRemove(eff.nEffectID)
        Next
    End Sub
    Public Sub EffectRemoveStances(ByVal sTarget As String)
        Dim list As New ArrayList
        For Each eff As Effect In EffectsByTarget(sTarget)
            If eff.bIsStance Then
                list.Add(eff)
            End If
        Next

        For Each eff As Effect In list
            EffectRemove(eff.nEffectID)
        Next
    End Sub


    Public ReadOnly Property EffectsBySource(ByVal p_sSourceHandle As String) As ArrayList
        Get
            Dim list As New ArrayList

            For Each eff As Effect In ActiveEffects.Values
                If eff.sSourceHandle = p_sSourceHandle And eff.bActive(nCurrentInitSequence) Then
                    list.Add(eff)
                End If
            Next

            Return list
        End Get
    End Property
    Public ReadOnly Property EffectsByTarget(ByVal p_sTargetHandle As String) As ArrayList
        Get
            Dim list As New ArrayList

            For Each eff As Effect In ActiveEffects.Values
                If eff.sTargetHandle = p_sTargetHandle And eff.bActive(nCurrentInitSequence) Then
                    list.Add(eff)
                End If
            Next

            Return list
        End Get
    End Property
    Public ReadOnly Property EffectsUniqueHistoryBySource(ByVal p_sSourceHandle As String) As ArrayList
        Get
            Dim uniquelist As New ArrayList
            Dim returnlist As New ArrayList

            For Each eff As Effect In ActiveEffects.Values
                If eff.sSourceHandle = p_sSourceHandle Then
                    If Not uniquelist.Contains(eff.sEffectBaseID) Then
                        uniquelist.Add(eff.sEffectBaseID)
                        returnlist.Add(eff)
                    End If
                End If
            Next

            Return returnlist
        End Get
    End Property
    Private Function EffectTillRound(ByVal p_sSource As String, ByVal p_sTarget As String, _
                   ByVal p_Dur As Effect.Duration) As Integer
        Dim tillround As Integer = 99

        Select Case p_Dur
            Case Effect.Duration.TargetStart, Effect.Duration.TargetEnd
                tillround = CType(Roster(p_sTarget), Combatant).nRound
                If p_sTarget = sCurrentFighterHandle Then
                    tillround += 1
                End If
            Case Effect.Duration.SourceStart, Effect.Duration.SourceEnd, Effect.Duration.Sustained
                tillround = CType(Roster(p_sSource), Combatant).nRound
                If p_sSource = sCurrentFighterHandle Then
                    tillround += 1
                End If
            Case Effect.Duration.TurnEnd
                tillround = nCurrentRound
        End Select

        Return tillround
    End Function

    Private Sub EffectRemoveStart(ByRef fighter As Combatant)
        Dim list As New ArrayList

        ' Handle Source effects
        For Each eff As Effect In EffectsBySource(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.SourceStart Then
                If eff.nRoundTill <= fighter.nRound Then
                    list.Add(eff)
                End If
            End If
        Next

        ' Handle target effects
        For Each eff As Effect In EffectsByTarget(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.TargetStart Then
                If eff.nRoundTill <= fighter.nRound Then
                    list.Add(eff)
                End If
            End If
        Next

        For Each eff As Effect In list
            eff.SetInactive(nCurrentInitSequence)
        Next
    End Sub
    Private Sub EffectRemoveEnd(ByRef fighter As Combatant)
        Dim list As New ArrayList

        ' Handle Source effects
        For Each eff As Effect In EffectsBySource(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.SourceEnd Or _
                        eff.DurationCode = Effect.Duration.TurnEnd Then
                If eff.nRoundTill <= fighter.nRound Then
                    list.Add(eff)
                End If
            End If
        Next

        ' Handle target effects
        For Each eff As Effect In EffectsByTarget(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.TargetEnd Or _
                        eff.DurationCode = Effect.Duration.TurnEnd Then
                If eff.nRoundTill <= fighter.nRound Then
                    list.Add(eff)
                End If
            End If
        Next

        For Each eff As Effect In list
            eff.SetInactive(fighter.nInitSequence + 1) 'Was nCurrentInitSequence 
        Next
    End Sub
    Private Sub EffectRemoveEndDelay(ByRef fighter As Combatant)
        Dim list As New ArrayList

        ' Handle Source effects
        For Each eff As Effect In EffectsBySource(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.SourceEnd Or _
                        eff.DurationCode = Effect.Duration.TurnEnd Then
                Dim bGoodForFighter As Boolean = eff.bBeneficial
                If fighter.bPC <> CType(Roster(eff.sTargetHandle), Combatant).bPC Then
                    bGoodForFighter = Not eff.bBeneficial
                End If
                If bGoodForFighter Then
                    list.Add(eff)
                End If
            ElseIf eff.DurationCode = Effect.Duration.Sustained Then
                list.Add(eff)
            End If
        Next

        ' Handle target effects
        For Each eff As Effect In EffectsByTarget(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.TargetEnd Or _
                        eff.DurationCode = Effect.Duration.TurnEnd Then
                If eff.nRoundTill <= fighter.nRound And eff.bBeneficial Then
                    list.Add(eff)
                End If
            End If
        Next

        For Each eff As Effect In list
            eff.SetInactive(nCurrentInitSequence + 1)
        Next
    End Sub

    Private Sub EffectMakeSaves(ByRef fighter As Combatant)
        If Not fighter.bAlive Then
            Exit Sub
        End If

        Dim list As New ArrayList

        For Each eff As Effect In EffectsByTarget(fighter.sCombatHandle)
            If eff.DurationCode = Effect.Duration.SaveEnds Then
                list.Add(eff)
            End If
        Next

        If list.Count > 0 Then
            Dim saveWin As New SavingThrowWin(list, fighter.Stat.nSaveBonus, EncounterDice)
            Dim saveWinReturn As DialogResult = saveWin.ShowDialog()

            If saveWinReturn = DialogResult.OK And saveWin.SuccessfulSaves.Count > 0 Then
                For Each id As Integer In saveWin.SuccessfulSaves
                    Dim eff As Effect = ActiveEffects(id)
                    eff.SetInactive(nCurrentInitSequence + 1)
                Next
            End If

            saveWin.Dispose()
        End If
    End Sub

    ' Check for Ongoing Damage
    Private Sub OngoingDamageCheck(ByRef fighter As Combatant)
        If Not fighter.bActive Then
            Exit Sub
        End If
        Dim bOngoing As Boolean = False
        Dim bRegen As Boolean = False
        For Each eff As Effect In Me.EffectsByTarget(fighter.sCombatHandle)
            If eff.sName.ToLower.Contains("ongoing") Then
                bOngoing = True
            End If
            If eff.sName.ToLower.Contains("regen") Then
                bRegen = True
            End If
        Next
        If bOngoing Then MsgBox(fighter.sName & " is taking ongoing damage.", MsgBoxStyle.OkOnly, "Ongoing Damage")
        If bRegen Then MsgBox(fighter.sName & " is regenerating.", MsgBoxStyle.OkOnly, "Regeneration")
    End Sub

    ' Power Functionality
    Private Sub PowerCheckRecharge(ByRef fighter As Combatant)
        If Not fighter.bActive Then
            Exit Sub
        End If

        Dim list As New ArrayList

        For Each pow As StatPower In fighter.PowerList
            If pow.nRechargeVal > 0 Then
                If fighter.bPowerUsed(pow.sName) Then
                    list.Add(pow)
                End If
            End If
        Next

        If list.Count > 0 Then
            Dim rechargeWin As New PowerRechargeWin(fighter.sCombatHandle, list, EncounterDice)
            Dim rechargeWinReturn As DialogResult = rechargeWin.ShowDialog()

            If rechargeWinReturn = DialogResult.OK And rechargeWin.Recharged.Count > 0 Then
                For Each powname As String In rechargeWin.Recharged
                    fighter.bPowerUsed(powname) = False
                Next
            End If

            rechargeWin.Dispose()
        End If
    End Sub

    ' Constructors
    Public Sub New(ByRef p_statlibrary As StatLibrary, ByRef p_DiceBag As DiceBag, _
                   ByVal p_bUseRoleMod As Boolean)
        ClearAll()
        EncounterDice = p_DiceBag
        StatLib = p_statlibrary
        bUseRollMod = p_bUseRoleMod
    End Sub


    ' Clear Class
    Public Sub ClearAll()
        Roster.Clear()

        sSelectedFighterHandle = ""
        sGlobalNotesCoded = ""
        ActiveEffects.Clear()
    End Sub


    ' XML Import/Export
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("encounter")

        writer.WriteElementString("ongoingfight", CStr(bOngoingFight))

        writer.WriteElementString("globalnotes", sGlobalNotesCoded)

        For Each fighter As Combatant In Roster.Values
            fighter.ExportXML(p_writer, bOngoingFight)
        Next

        If bOngoingFight Then
            writer.WriteElementString("nexteffectID", CStr(nNextEffectID))
            For Each eff As Effect In ActiveEffects.Values
                eff.ExportXML(p_writer)
            Next
        End If

        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim fighter As Combatant
        Dim eff As Effect
        Dim bResetInit As Boolean = True

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "encounter" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "combatant" Then
                        fighter = New Combatant
                        fighter.ImportXML(reader)
                        Add(fighter, True, bResetInit)
                    ElseIf reader.Name = "effect" Then
                        eff = New Effect
                        eff.ImportXML(reader)
                        ActiveEffects(eff.nEffectID) = eff
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "globalnotes"
                            If sGlobalNotesCoded <> "" Then
                                sGlobalNotesCoded &= "###" & reader.Value
                            Else
                                sGlobalNotesCoded = reader.Value
                            End If
                        Case "ongoingfight"
                            If CBool(reader.Value) = True Then
                                If Roster.Count > 0 Then
                                    MsgBox("An ongoing encounter cannot be imported with preexisting combatants." & ControlChars.NewLine & _
                                        "Please clear the list before attempting this operation.", _
                                        MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Import Error")
                                    Return False
                                End If
                                bResetInit = False
                            End If
                        Case "nexteffectID"
                            nNextEffectID = Val(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "encounter" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function


    ' Load/Save to File
    Public Function LoadFromFile(ByVal filename As String, ByVal bClearBeforeLoading As Boolean) As Boolean
        Dim xmlSettings As New System.Xml.XmlReaderSettings

        Dim filetool As New IO.FileInfo(filename)
        If filetool.Exists Then
            Using fileXMLReader As Xml.XmlReader = Xml.XmlReader.Create(filename, xmlSettings)
                fileXMLReader.MoveToContent()
                If Not fileXMLReader.EOF Then
                    While fileXMLReader.NodeType <> Xml.XmlNodeType.Element And Not fileXMLReader.EOF
                        fileXMLReader.Read()
                    End While
                    If bClearBeforeLoading Then ClearAll()
                    ImportXML(fileXMLReader)
                End If
            End Using
        Else
            Return False
        End If

        Return True
    End Function
    Public Function SaveToFile(ByVal filename As String) As Boolean
        Dim xmlSettings As New Xml.XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.NewLineOnAttributes = True

        Dim tempfilename As String = filename & ".tmp"
        Dim tempfileinfo As New IO.FileInfo(tempfilename)
        If tempfileinfo.Exists Then tempfileinfo.Delete()

        Using fileXMLWriter As Xml.XmlWriter = Xml.XmlWriter.Create(tempfilename, xmlSettings)
            ExportXML(fileXMLWriter)
        End Using

        tempfileinfo.CopyTo(filename, True)
        tempfileinfo.Delete()

        Return True
    End Function
End Class
