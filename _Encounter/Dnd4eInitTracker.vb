Imports System.Diagnostics.Process
Imports System.Drawing.Text

Public Class frmTracker


    ' Window Data
    Dim fight As Encounter
    Dim statlib As StatLibrary
    Dim statlib_filename As String
    Dim trackerDice As DiceBag
    Dim cmWebServer As WebServer = WebServer.getWebServer
    Dim cmHTMLInitList As HTMLInitList = HTMLInitList.getHTMLInitList

    ' Events - Window
    Private Sub frmTracker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myfonts As InstalledFontCollection = New InstalledFontCollection()
        Dim testfont As Font = New Font("4etools symbols", 16.0F, FontStyle.Regular, GraphicsUnit.Pixel)
        If testfont.Name.ToLower <> "4etools symbols" Then
            MsgBox("4etools_symbols.ttf font not installed.  Please install the font included in the Combat Manager package to view the attack symbols.  Symbols will not appear until you restart Combat Manger after installing the font.", MsgBoxStyle.Exclamation, "Missing Font")
        End If
        ' Create and Load StatLibrary

        If statlib_filename = "" Then
            statlib_filename = My.Application.Info.DirectoryPath & "\" & My.Settings.sLibraryFileName
        End If
        statlib = New StatLibrary
        trackerDice = New DiceBag
        Dim filetest As New IO.FileInfo(statlib_filename)
        If filetest.Exists Then
            statlib.LoadFromFile(statlib_filename, True)
        End If

        ' Set up initial encounter
        fight = New Encounter(statlib, trackerDice, My.Settings.bHR_UseModRoles)

        ' Disable Stat values
        StatDataClear()

        If Not My.Settings.bHR_UseModRoles Then
            dfRoleMod.Visible = False
            labRoleMod.Visible = False
        End If



        UpdateCheckedOptions()
        UpdateEnabledControls()
    End Sub

    Private Sub frmTracker_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        statlib.SaveToFile(statlib_filename)
    End Sub


    ' Events - Menu - File
    Private Sub menuNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuNewToolStripMenuItem.Click
        NewEncounter()
    End Sub
    Private Sub menuSaveEncounterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSaveEncounterToolStripMenuItem.Click
        SaveEncounter()
    End Sub
    Private Sub menuLoadEncounterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLoadEncounterToolStripMenuItem.Click
        LoadEncounter(True)
    End Sub
    Private Sub menuImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuImportToolStripMenuItem.Click
        LoadEncounter(False)
    End Sub
    Private Sub menuExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExitToolStripMenuItem.Click
        ExitEncounter()
    End Sub

    ' Events - Menu - Encounter
    Private Sub menuSelectCurrentCombatantToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSelectCurrentCombatantToolStripMenuItem.Click
        fight.SelectCurrentFighter()
        UpdateFromClass()
    End Sub
    Private Sub menuRollAllInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRollAllInit.Click
        fight.StartFight(My.Settings.bGroupSimilar)
        UpdateFromClass()
    End Sub
    Private Sub menuResetAllInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuResetAllInit.Click
        If MsgBox("Are you sure you want to End the Battle?" & ControlChars.NewLine & _
                    ControlChars.NewLine & "This will:" & ControlChars.NewLine & _
                    "    -Reset Monster Health and Powers" & ControlChars.NewLine & _
                    "    -End all Ongoing Effects", _
                MsgBoxStyle.YesNo, "Take Short Rest") = MsgBoxResult.Yes Then
            fight.ResetEncounter(False)
            UpdateFromClass()
        End If
    End Sub
    Private Sub menuClearNPCsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuClearNPCsToolStripMenuItem.Click
        fight.ClearNPCs()
        UpdateFromClass()
    End Sub

    ' Events - Menu - Party
    Private Sub menuShortRestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTakeShortRestToolStripMenuItem.Click
        If MsgBox("Are you sure you want to Take a Short Rest?" & ControlChars.NewLine & _
                    ControlChars.NewLine & "This will:" & ControlChars.NewLine & _
                    "    -Clear all monsters from the encounter" & ControlChars.NewLine & _
                    "    -Refresh all non-Daily PC powers" & ControlChars.NewLine & _
                    "    -Clear all temporary hit points", _
                MsgBoxStyle.YesNo, "Take Short Rest") = MsgBoxResult.Yes Then
            fight.TakeShortRest()
            UpdateFromClass()
        End If
    End Sub
    Private Sub menuTakeExtendedRestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTakeExtendedRestToolStripMenuItem.Click
        If MsgBox("Are you sure you want to Take an Extended Rest?" & ControlChars.NewLine & _
                    ControlChars.NewLine & "This will:" & ControlChars.NewLine & _
                    "    -Clear all monsters from the encounter" & ControlChars.NewLine & _
                    "    -Refresh all PC powers" & ControlChars.NewLine & _
                    "    -Restore the party to full health", _
                MsgBoxStyle.YesNo, "Take Extended Rest") = MsgBoxResult.Yes Then
            fight.TakeExtendedRest()
            UpdateFromClass()
        End If
    End Sub
    Private Sub menuResetPCHealthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuResetPCHealthToolStripMenuItem.Click
        If MsgBox("Are you sure you want to reset the HP of all PCs?", _
                              MsgBoxStyle.YesNo, "Reset PCs") = MsgBoxResult.Yes Then
            fight.ResetPCHealth()
            UpdateFromClass()
        End If
    End Sub
    Private Sub menuClearPCsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuClearPCsToolStripMenuItem.Click
        fight.ClearPCs()
        UpdateFromClass()
    End Sub

    ' Events - Menu - Options
    Private Sub menuRollSavesAutomaticallyToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuRollSavesAutomaticallyToolStripMenuItem.CheckedChanged
        '        fight.bRollEffectSaves = menuRollSavesAutomaticallyToolStripMenuItem.Checked
        My.Settings.bRollEffectSaves = menuRollSavesAutomaticallyToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub
    Private Sub menuRollForPowerRechargeToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuRollForPowerRechargeToolStripMenuItem.CheckedChanged
        '        fight.bRollPowerRecharge = menuRollForPowerRechargeToolStripMenuItem.Checked
        My.Settings.bRollPowerRecharge = menuRollForPowerRechargeToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub
    Private Sub menuPopupForOngoingDamageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuPopupForOngoingDamageToolStripMenuItem.CheckedChanged
        '        fight.bOngoingPopup = menuPopupForOngoingDamageToolStripMenuItem.Checked
        My.Settings.bOngoingPopup = menuPopupForOngoingDamageToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub
    Private Sub menuSurpriseRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSurpriseRound.CheckedChanged
        My.Settings.bSurpriseRound = menuSurpriseRound.Checked
        My.Settings.Save()
    End Sub
    ' Events - Menu - Library
    Private Sub menuOpenStatLibraryOpenMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuStatLibraryOpenMenuItem.Click
        Dim statlibWin As New StatLibraryView(statlib)
        Dim statlibReturn As DialogResult = statlibWin.ShowDialog(Me)

        If statlibWin.statsToAdd.Count > 0 Then
            For Each fighter As Statblock In statlibWin.statsToAdd
                fight.Add(fighter, False)
            Next
        End If

        statlibWin.Dispose()
        fight.UpdateAllStats(Not fight.bOngoingFight)
        UpdateFromClass()
    End Sub


    ' Events - List
    Private Sub lbFightList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFightList.Click
        If bListSelected Then
            If fight.sSelectedFighter <> lbFightList.Items(lbFightList.SelectedIndices(0)).Text Then
                fight.sSelectedFighter = lbFightList.Items(lbFightList.SelectedIndices(0)).Text
                StatDataLoad()
            End If
        End If
    End Sub
    Private Sub lbFightList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbFightList.KeyUp
        lbFightList_Click(sender, e)
    End Sub

    ' Events - Stat Values
    Private Sub dfGlobalNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfGlobalNotes.TextChanged
        If dfGlobalNotes.Text <> fight.sGlobalNotes Then
            fight.sGlobalNotes = dfGlobalNotes.Text
        End If
    End Sub
    Private Sub dfFighterNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFighterNotes.TextChanged
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            fighter.sCombatNotes = dfFighterNotes.Text
            If dfFighterNotes.Text <> "" Then
                tabNotes.Text = "++Notes++"
            Else
                tabNotes.Text = "Notes"
            End If
        End If
    End Sub
    Private Sub dfStatName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfStatName.Validated
        dfStatName.Text = dfStatName.Text.Trim
        If dfStatName.Text <> "" Then
            Dim fighter As Combatant = ListSelectedFighter

            If Not fighter Is Nothing Then
                If dfStatName.Text <> fighter.sName Then
                    fight.Roster.Remove(fighter.sCombatHandle)
                    fighter.sName = dfStatName.Text
                    fight.Add(fighter, False, True)
                    fight.oSelectedFighter = fighter
                    UpdateFromClass()
                End If
            End If
        End If
    End Sub

    Private Sub dfStatInitRoll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dfStatInitRoll.KeyDown
        If e.KeyCode = Keys.Enter Then
            dfStatInitRoll_ValueChanged(Nothing, Nothing)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub dfStatInitRoll_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfStatInitRoll.ValueChanged
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            If dfStatInitRoll.Value <> fighter.nInitRoll Then
                If fighter.sInitStatus = "Reserve" Then
                    fight.RollOneInit(fighter)
                End If
                'fighter.nInitRoll = dfStatInitRoll.Value
                fight.FighterInitRollUpdate(fighter.sCombatHandle, dfStatInitRoll.Value)
                UpdateFromClass()
            End If
        End If
    End Sub

    Private Sub dfRoleMod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dfRoleMod.SelectedIndexChanged
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            If fighter.sRoleMod <> dfRoleMod.Text Then
                fighter.sRoleMod = dfRoleMod.Text
                UpdateFromClass()
            End If
        End If
    End Sub

    ' Events - Damage/Healing Button
    Private Sub dfDamHealAmt_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfDamHealAmt.ValueChanged
        If dfDamHealAmt.Value > 0 Then
            pbDealDamage.Enabled = True
            pbHealDamage.Enabled = True
            pbAddTemp.Enabled = True
        Else
            pbDealDamage.Enabled = False
            pbHealDamage.Enabled = False
            pbAddTemp.Enabled = False
        End If
    End Sub
    Private Sub pbDealDamage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDealDamage.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            If fighter.sCombatHandle = fight.sCurrentFighterHandle Then
                fighter.Damage(dfDamHealAmt.Value)
                If Not fighter.bAlive Then
                    fight.BeginTurn()
                End If
            Else
                fighter.Damage(dfDamHealAmt.Value)
            End If
            UpdateFromClass()
            dfDamHealAmt.Focus()
        End If
    End Sub
    Private Sub pbFailDeath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbFailDeath.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            fighter.FailDeathSave()
            UpdateFromClass()
        End If
    End Sub
    Private Sub pbHealDamage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbHealDamage.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            fighter.Heal(dfDamHealAmt.Value)
            UpdateFromClass()
            dfDamHealAmt.Focus()
        End If
    End Sub
    Private Sub pbUnfailDeath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbUnfailDeath.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            fighter.UndoDeathSave()
            UpdateFromClass()
        End If
    End Sub
    Private Sub pbAddTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddTemp.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            fighter.AddTempHP(dfDamHealAmt.Value)
            UpdateFromClass()
        End If
    End Sub
    Private Sub pbSurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSurge.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            If My.Settings.bSurgePlusPrompt Then
                Dim nAdditionalHealing As Integer

                nAdditionalHealing = Val(InputBox("Base healing surge is " & fighter.nSurgeValue & Environment.NewLine _
                                                  & fighter.sName & " has " & fighter.nSurgesLeft & " healing surges left." & Environment.NewLine & Environment.NewLine _
                                                  & "Additional healing:", "Healing Surge", "0"))
                dfDamHealAmt.Value = fighter.nSurgeValue + nAdditionalHealing
            Else
                dfDamHealAmt.Value = fighter.nSurgeValue
            End If
            dfDamHealAmt.Focus()

            If My.Settings.bAutoSurge Then
                ' Make sure they have surges remaining
                If (fighter.nSurgesLeft <= 0) Then
                    Dim reply As DialogResult = MessageBox.Show(fighter.sName & " is out of healing surges.  Proceed anyways?", "Out of healing surges", _
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If reply = Windows.Forms.DialogResult.No Then
                        Return
                    End If
                End If
                Dim usesurge As DialogResult = MessageBox.Show("Heal " & fighter.sName & " for " & dfDamHealAmt.Value & "?", "Healing surge", _
                                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If usesurge = Windows.Forms.DialogResult.No Then
                    Return
                End If

                ' Heal them
                fighter.Heal(dfDamHealAmt.Value)
                UpdateFromClass()
                ' Use a surge
                fighter.ModSurges(-1)
                dfSurgesLeft.Text = fighter.sSurgeView
            End If
        End If
    End Sub
    Private Sub pbMaxHP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbMaxHP.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            dfDamHealAmt.Value = fighter.nMaxHP
            dfDamHealAmt.Focus()
        End If
    End Sub
    Private Sub pbHP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbHP5.Click
        dfDamHealAmt.Value = 5
        dfDamHealAmt.Focus()
    End Sub
    Private Sub pbHPplus5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbHPplus5.Click
        dfDamHealAmt.Value += 5
        dfDamHealAmt.Focus()
    End Sub

    ' Events - Initiative Buttons
    Private Sub pbDeleteFighter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDeleteFighter.Click, ctxtRemoveFighterFromCombatToolStripMenuItem.Click
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            If MsgBox("Are you sure you want to remove" & ControlChars.NewLine & _
                      fighter.sCombatHandle & " from the battle?", _
                      MsgBoxStyle.YesNo, "Remove Fighter") = MsgBoxResult.Yes Then
                fight.Roster.Remove(fighter.sCombatHandle)
                fight.ClearSelectedFighter()
                UpdateFromClass()
            End If
        End If
    End Sub
    Private Sub pbMoveToTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbMoveToTop.Click
        fight.MoveToTop(ListSelectedFighter)
        UpdateFromClass()
    End Sub
    Private Sub pbRollInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRollInit.Click
        fight.RollOneInit(ListSelectedFighter)
        UpdateFromClass()
    End Sub
    Private Sub pbBackRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBackRound.Click
        fight.FighterUndoTurn(fight.sPriorFighterHandle)
        UpdateFromClass()
    End Sub
    Private Sub pbReady_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReady.Click
        fight.SetInitStatus(ListSelectedFighter, "Ready")
        UpdateFromClass()
    End Sub
    Private Sub pbDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDelay.Click
        fight.SetInitStatus(ListSelectedFighter, "Delay")
        UpdateFromClass()
    End Sub
    Private Sub pbReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReserve.Click
        fight.SetInitStatus(ListSelectedFighter, "Reserve")
        UpdateFromClass()
    End Sub

    Private Sub pbNextInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNextInit.Click
        fight.FinishCurrentTurn()
        If My.Settings.bAutoSave Then
            fight.SaveToFile(My.Application.Info.DirectoryPath & "\Autosave.xml")
        End If
        UpdateFromClass()
    End Sub

    ' Events - Context Menu
    Private Sub ctxtMoveToTopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtMoveToTopToolStripMenuItem.Click
        pbMoveToTop_Click(sender, e)
    End Sub
    Private Sub ctxtDelayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtDelayToolStripMenuItem.Click
        pbDelay_Click(sender, e)
    End Sub
    Private Sub ctxtReadyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtReadyToolStripMenuItem.Click
        pbReady_Click(sender, e)
    End Sub
    Private Sub ctxtMarkedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtMarkedToolStripMenuItem.Click
        fight.EffectAdd("Marked", fight.sCurrentFighter.sCombatHandle, fight.sSelectedFighter, 5, False, False)
        EffectLoad()
    End Sub
    Private Sub ctxtMarkedEncounterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtMarkedEncounterToolStripMenuItem.Click
        fight.EffectAdd("Marked", fight.sCurrentFighter.sCombatHandle, fight.sSelectedFighter, 7, False, False)
        EffectLoad()
    End Sub
    Private Sub SetAsActiveStance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsActiveStance.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    For Each temppower As StatPower In fighter.PowerList
                        If listitem.Tag = temppower.sName Then
                            fight.EffectAdd("Stance - " & temppower.sName, fight.sSelectedFighter, fight.sSelectedFighter, 7, True, False)
                        End If
                    Next
                Next
            End If
        End If
        EffectLoad()
    End Sub
    ' Properties - Is an item on the listbox selected?
    Private ReadOnly Property bListSelected() As Boolean
        Get
            If lbFightList.SelectedIndices.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    ' Properties - The currently selected fighter
    Private ReadOnly Property ListSelectedFighter() As Combatant
        Get
            Return fight.oSelectedFighter
        End Get
    End Property


    ' Functions - Main Update
    Sub UpdateFromClass()
        ReloadListFromClass()
        If fight.bSelectedFighter Then
            Dim fighter As Combatant = fight.oSelectedFighter
            Dim selecteditem As System.Windows.Forms.ListViewItem = _
                                lbFightList.FindItemWithText(fighter.sCombatHandle)
            selecteditem.EnsureVisible()
            selecteditem.Selected = True
            StatDataLoad()
        Else
            StatDataClear()
        End If
        ExportHTMLInitList()
    End Sub
    Sub ReloadListFromClass()
        lbFightList.SuspendLayout()

        ' Remove extra lines
        Do While fight.Roster.Count < lbFightList.Items.Count
            lbFightList.Items.RemoveAt(lbFightList.Items.Count - 1)
        Loop

        ' Update Lines
        Dim index As Integer = 0
        Do While index < fight.Roster.Count
            Dim fighter As Combatant = fight.GetFighterByIndex(index)
            Dim listitem As System.Windows.Forms.ListViewItem

            If fighter Is Nothing Then
                Exit Do
            End If

            If index < lbFightList.Items.Count Then
                ' Update line
                listitem = lbFightList.Items(index)
                listitem.Text = fighter.sCombatHandle
                listitem.SubItems(1).Text = fighter.sStatusLine
                listitem.SubItems(3).Text = fighter.sDefenses
            Else
                ' Insert new line
                listitem = lbFightList.Items.Add(fighter.sCombatHandle)
                listitem.SubItems.Add(fighter.sStatusLine)
                listitem.SubItems.Add(CStr(fighter.nRound))
                listitem.SubItems.Add(fighter.sDefenses)
            End If

            ' Fill in line data
            listitem.ForeColor = fighter.cDisplayForeColor
            listitem.BackColor = fighter.cDisplayBackColor
            Select Case fighter.sInitStatus
                Case "Rolled"
                    listitem.Group = lbFightList.Groups(0)
                    If fighter.nRound = 0 Then
                        listitem.SubItems(2).Text = "S"
                    Else
                        listitem.SubItems(2).Text = CStr(fighter.nRound)
                    End If
                Case "Delay"
                    listitem.Group = lbFightList.Groups(1)
                    listitem.SubItems(2).Text = "D"
                Case "Ready"
                    listitem.Group = lbFightList.Groups(2)
                    listitem.SubItems(2).Text = "R"
                Case "Inactive"
                    listitem.Group = lbFightList.Groups(3)
                    listitem.SubItems(2).Text = "I"
                Case "Rolling"
                    listitem.Group = lbFightList.Groups(4)
                    listitem.SubItems(2).Text = "x"
                Case Else
                    listitem.Group = lbFightList.Groups(5)
                    listitem.SubItems(2).Text = ""
            End Select

            index += 1
        Loop

        lbFightList.ResumeLayout()
        lbFightList.Refresh()

        UpdateEnabledControls()
        UpdateEncounterXPTotals()
        dfGlobalNotes.Text = fight.sGlobalNotes
    End Sub

    ' Functions - File menu
    Sub NewEncounter()
        fight.ClearAll()
        UpdateFromClass()
        dfGlobalNotes.Clear()
    End Sub
    Sub LoadEncounter(ByVal p_bClearFirst As Boolean)
        Dim dlgOpen As New OpenFileDialog

        With dlgOpen
            .Filter = "Encounter files (*.xml)|*.xml|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Load Encounter File"
            .Multiselect = True
        End With

        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If p_bClearFirst Then
                fight.ClearAll()
            End If
            For Each filename As String In dlgOpen.FileNames
                fight.LoadFromFile(filename, False)
            Next
            fight.ClearSelectedFighter()
            UpdateFromClass()
        End If
    End Sub
    Sub SaveEncounter()
        Dim dlgSave As New SaveFileDialog

        With dlgSave
            .DefaultExt = "xml"
            .FileName = "Encounter.xml"
            .Filter = "Encounter files (*.xml)|*.xml|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Save Encounter File"
            .OverwritePrompt = True
        End With

        If dlgSave.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fight.SaveToFile(dlgSave.FileName)
        End If
    End Sub
    Sub ExitEncounter()
        cmWebServer.StopWebServer()
        Me.Close()
    End Sub

    ' Functions - Update control enabling based on class
    Private Sub UpdateEnabledControls()
        ' Modify Enabled controls
        menuSaveEncounterToolStripMenuItem.Enabled = False

        menuSelectCurrentCombatantToolStripMenuItem.Enabled = False
        menuRollAllInit.Enabled = False
        menuResetAllInit.Enabled = False
        menuClearNPCsToolStripMenuItem.Enabled = False

        menuTakeShortRestToolStripMenuItem.Enabled = False
        menuTakeShortRestWMilestoneToolStripMenuItem.Enabled = False
        menuTakeExtendedRestToolStripMenuItem.Enabled = False
        menuResetPCHealthToolStripMenuItem.Enabled = False
        menuClearPCsToolStripMenuItem.Enabled = False

        pbNextInit.Enabled = False

        If fight.Roster.Count > 0 Then
            menuSaveEncounterToolStripMenuItem.Enabled = True
            menuSelectCurrentCombatantToolStripMenuItem.Enabled = True
            If fight.ReserveList.Count > 0 Then
                menuRollAllInit.Enabled = True
            End If
            If Not fight.bOngoingFight Then
                menuClearNPCsToolStripMenuItem.Enabled = True
                menuClearPCsToolStripMenuItem.Enabled = True
                menuTakeShortRestToolStripMenuItem.Enabled = True
                menuTakeShortRestWMilestoneToolStripMenuItem.Enabled = True
                menuTakeExtendedRestToolStripMenuItem.Enabled = True
                menuResetPCHealthToolStripMenuItem.Enabled = True
            Else
                menuResetAllInit.Enabled = True
                If fight.RolledList.Count > 0 Then
                    pbNextInit.Enabled = True
                End If
            End If
        End If
    End Sub

    ' Functions - Update XP/Level encounter totals
    Private Sub UpdateEncounterXPTotals()
        dfPartySize.Text = CStr(fight.nPartySize)
        dfXPTotal.Text = fight.nEncounterXP.ToString("#,0")
        If fight.nPartySize = 0 Then
            dfEncounterLevel.Text = CStr(DnD4e_EncounterLevel(5, fight.nEncounterXP))
        Else
            dfEncounterLevel.Text = CStr(fight.nEncounterLevel)
        End If
    End Sub

    ' Functions - Stat Data handling
    Public Sub StatDataLoad()
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            dfStatName.Text = fighter.sName
            If fighter.nFighterNumber > 0 Then
                dfFighterNum.Text = CStr(fighter.nFighterNumber)
            Else
                dfFighterNum.Text = "PC"
            End If
            dfStatInitRoll.Text = CStr(fighter.nInitRoll)

            dfFighterNotes.Text = fighter.sCombatNotes

            If dfFighterNotes.Text <> "" Then
                tabNotes.Text = "++Notes++"
            Else
                tabNotes.Text = "Notes"
            End If

            dfHTMLStatBlock.DocumentText = fighter.Stat.Statblock_HTML
            dfRoleMod.SelectedItem = fighter.sRoleMod
            dfXPValue.Text = fighter.nXP.ToString("#,0")

            dfStatCurrHP.Text = fighter.nCurHP.ToString("#,0")
            dfStatMaxHP.Text = fighter.nMaxHP.ToString("#,0")
            dfStatDefAC.Text = CStr(fighter.Stat.nAC)
            dfStatDefFort.Text = CStr(fighter.Stat.nFort)
            dfStatDefReflex.Text = CStr(fighter.Stat.nRef)
            dfStatDefWill.Text = CStr(fighter.Stat.nWill)
            dfStatLevel.Text = CStr(fighter.Stat.nLevel)
            dfSurgesLeft.Text = CStr(fighter.sSurgeView)

            PowerLoad()
            EffectLoad()

            StatDataEnable(fighter)
        End If
    End Sub
    Public Sub StatDataClear()
        dfHTMLStatBlock.DocumentText = ""
        dfFighterNotes.Clear()
        tabNotes.Text = "Notes"
        lbPowerUsage.Items.Clear()
        lbEffects.Items.Clear()
        dfStatName.Text = ""
        dfFighterNum.Text = ""
        dfStatInitRoll.Text = ""
        dfStatCurrHP.Text = ""
        dfStatMaxHP.Text = ""
        dfStatDefAC.Text = ""
        dfStatDefFort.Text = ""
        dfStatDefReflex.Text = ""
        dfStatDefWill.Text = ""
        dfStatLevel.Text = ""

        dfRoleMod.SelectedItem = "Normal"

        fight.ClearSelectedFighter()
        StatDataDisable()
    End Sub
    Public Sub StatDataDisable()
        dfFighterNotes.Enabled = False
        dfStatName.Enabled = False
        dfStatInitRoll.Enabled = False

        pbBackRound.Enabled = False
        pbDelay.Enabled = False
        pbMoveToTop.Enabled = False
        pbReady.Enabled = False
        pbReserve.Enabled = False
        pbRollInit.Enabled = False
        ctxtMarkedToolStripMenuItem.Enabled = False
        ctxtMarkedEncounterToolStripMenuItem.Enabled = False

        dfDamHealAmt.Enabled = False
        pbDealDamage.Enabled = False
        pbFailDeath.Enabled = False
        pbHP5.Enabled = False
        pbHPplus5.Enabled = False
        pbSurge.Enabled = False
        pbMaxHP.Enabled = False

        pbHealDamage.Enabled = False
        pbUnfailDeath.Enabled = False
        pbAddTemp.Enabled = False

        dfRoleMod.Enabled = False

        pbDeleteFighter.Enabled = False

        lbPowerUsage.Enabled = False
        pbPowerExpended.Enabled = False
        pbPowerRefresh.Enabled = False

        lbEffects.Enabled = False
        pbEffectAdd.Enabled = False
        pbEffectChange.Enabled = False
        pbEffectRemove.Enabled = False

        ctxtmenuInitList.Enabled = False
    End Sub
    Public Sub StatDataEnable(ByRef fighter As Combatant)
        If Not fighter Is Nothing Then
            ' Enable Stat entry values
            dfStatName.Enabled = True
            dfFighterNotes.Enabled = True
            dfStatInitRoll.Enabled = True

            lbPowerUsage.Enabled = False
            lbEffects.Enabled = False

            ' Set initial button status
            pbBackRound.Enabled = False
            pbDelay.Enabled = False
            pbMoveToTop.Enabled = False
            pbReady.Enabled = False
            pbReserve.Enabled = False
            pbRollInit.Enabled = False

            pbFailDeath.Enabled = False
            pbUnfailDeath.Enabled = False
            dfDamHealAmt.Enabled = False
            pbDealDamage.Enabled = False
            pbHealDamage.Enabled = False
            pbAddTemp.Enabled = False
            pbHP5.Enabled = False
            pbHPplus5.Enabled = False
            pbSurge.Enabled = False
            pbMaxHP.Enabled = False
            pbSubSurge.Enabled = False
            pbAddSurge.Enabled = False
            pbAllSurge.Enabled = False

            ' Enable fighter delete
            pbDeleteFighter.Enabled = True

            ' Enable RoleMod 
            If fighter.bPC Or fighter.bMinion Then
                dfRoleMod.Enabled = False
            Else
                dfRoleMod.Enabled = True
            End If

            ' Enable based on initiative status
            Select Case fighter.sInitStatus
                Case "Rolled"
                    pbBackRound.Enabled = True
                    pbDelay.Enabled = True
                    pbMoveToTop.Enabled = True
                    pbReady.Enabled = True
                    pbReserve.Enabled = True
                    ctxtMarkedToolStripMenuItem.Enabled = True
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = True
                Case "Ready"
                    pbDelay.Enabled = True
                    pbMoveToTop.Enabled = True
                    pbReserve.Enabled = True
                    ctxtMarkedToolStripMenuItem.Enabled = True
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = True
                Case "Delay"
                    pbMoveToTop.Enabled = True
                    pbReady.Enabled = True
                    pbReserve.Enabled = True
                    ctxtMarkedToolStripMenuItem.Enabled = True
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = True
                Case "Reserve"
                    pbRollInit.Enabled = True
                    ctxtMarkedToolStripMenuItem.Enabled = False
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = False
                Case Else
                    pbReserve.Enabled = True
                    ctxtMarkedToolStripMenuItem.Enabled = False
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = False
            End Select
            ' Enable move-to-top button
            If pbMoveToTop.Enabled Then
                If fight.GetCurrentFighter().sCombatHandle = fighter.sCombatHandle Then
                    pbMoveToTop.Enabled = False
                    ctxtMarkedToolStripMenuItem.Enabled = False
                    ctxtMarkedEncounterToolStripMenuItem.Enabled = False
                End If
            End If

            ' Enable damage buttons
            If fighter.sInitStatus <> "Reserve" Or fighter.bPC Then
                dfStatInitRoll.Enabled = True
                dfDamHealAmt.Enabled = True
                pbHP5.Enabled = True
                pbHPplus5.Enabled = True
                pbSurge.Enabled = True
                pbMaxHP.Enabled = True
                If fighter.bPC Then
                    If Not fighter.bActive Then
                        If fighter.bAlive Then
                            pbFailDeath.Enabled = True
                        End If
                        If fighter.bDyingOrDead Then
                            pbUnfailDeath.Enabled = True
                        End If
                    End If
                End If
                If Val(dfDamHealAmt.Text.Replace(",", "")) > 0 Then
                    pbDealDamage.Enabled = True
                    pbHealDamage.Enabled = True
                    If fighter.bAlive Then
                        pbAddTemp.Enabled = True
                    Else
                        pbAddTemp.Enabled = False
                    End If
                Else
                    pbDealDamage.Enabled = False
                    pbHealDamage.Enabled = False
                    pbAddTemp.Enabled = False
                End If

                lbPowerUsage.Enabled = True
                PowerButtonUpdate()

                lbEffects.Enabled = True
                pbEffectAdd.Enabled = True
                EffectButtonUpdate()
                pbSubSurge.Enabled = True
                pbAddSurge.Enabled = True
                pbAllSurge.Enabled = True
            End If

            ctxtmenuInitList.Enabled = True
            ctxtDelayToolStripMenuItem.Enabled = pbDelay.Enabled
            ctxtMoveToTopToolStripMenuItem.Enabled = pbMoveToTop.Enabled
            ctxtReadyToolStripMenuItem.Enabled = pbReady.Enabled
        End If
    End Sub


    ' Functions - Effect list
    Public Sub EffectLoad()
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            lbEffects.Items.Clear()
            Dim listitem As System.Windows.Forms.ListViewItem

            For Each eff As Effect In fight.EffectsByTarget(fighter.sCombatHandle)
                listitem = lbEffects.Items.Add(eff.sName)
                listitem.SubItems.Add("     Source: " & eff.sSourceHandle)
                listitem.SubItems.Add("     Duration: " & eff.sDesc)
                listitem.Tag = eff.nEffectID
                If eff.bHidden Then
                    listitem.ForeColor = Color.LightGray()
                Else
                    listitem.ForeColor = Color.White
                End If
                listitem.SubItems(1).ForeColor = Color.LightGray
                listitem.SubItems(2).ForeColor = Color.LightGray
                If eff.bBeneficial Then
                    listitem.BackColor = Color.DarkGreen
                Else
                    listitem.BackColor = Color.DarkRed
                End If
            Next
            EffectButtonUpdate()
        End If
    End Sub
    Public Sub EffectButtonUpdate()
        If lbEffects.SelectedItems.Count() > 0 Then
            pbEffectChange.Enabled = True
            pbEffectRemove.Enabled = True
        Else
            pbEffectChange.Enabled = False
            pbEffectRemove.Enabled = False
        End If
    End Sub
    Private Sub pbEffectAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEffectAdd.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            Dim eff As New Effect
            Dim effectwin As New EffectView(fight)
            Dim effectreturn As DialogResult = effectwin.ShowDialog(Me)

            If effectreturn = Windows.Forms.DialogResult.OK Then
                fight.EffectAdd(effectwin.modeffect)
                EffectLoad()
                UpdateFromClass()
            End If

            effectwin.Dispose()
        End If
    End Sub
    Private Sub pbEffectChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEffectChange.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbEffects.SelectedItems.Count > 0 Then
                Dim effectwin As New EffectView(fight, fight.ActiveEffects(lbEffects.SelectedItems(0).Tag))
                Dim effectreturn As DialogResult = effectwin.ShowDialog(Me)

                If effectreturn = Windows.Forms.DialogResult.OK Then
                    fight.EffectChange(effectwin.modeffect)
                    EffectLoad()
                    UpdateFromClass()
                End If

                effectwin.Dispose()
            End If
        End If
    End Sub
    Private Sub pbEffectRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEffectRemove.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbEffects.SelectedItems.Count > 0 Then
                fight.EffectRemove(lbEffects.SelectedItems(0).Tag)
                EffectLoad()
                UpdateFromClass()
            End If
        End If
    End Sub
    Private Sub lbEffects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEffects.DoubleClick
        pbEffectChange_Click(sender, e)
    End Sub
    Private Sub lbEffects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEffects.SelectedIndexChanged
        EffectButtonUpdate()
    End Sub


    ' Functions - Power List
    Public Sub PowerLoad()
        Dim fighter As Combatant = ListSelectedFighter

        If Not fighter Is Nothing Then
            lbPowerUsage.Items.Clear()
            Dim listitem As System.Windows.Forms.ListViewItem

            For Each pow As StatPower In fighter.PowerList
                listitem = lbPowerUsage.Items.Add(pow.sName & pow.sActionLine)
                listitem.Tag = pow.sName
                If fighter.bPowerUsed(pow.sName) Then
                    listitem.ForeColor = Color.DarkGoldenrod
                    listitem.BackColor = Color.White
                    listitem.Text = "x  " & listitem.Text
                Else
                    listitem.ForeColor = pow.cForeColor
                    listitem.BackColor = pow.cBackColor
                End If
            Next
            PowerButtonUpdate()
        End If
    End Sub
    Public Sub PowerButtonUpdate()
        If lbPowerUsage.SelectedItems.Count() > 0 Then
            pbPowerExpended.Enabled = True
            pbPowerRefresh.Enabled = True
            If My.Settings.bAutoCompendium Then ViewCompendium()
        Else
            pbPowerExpended.Enabled = False
            pbPowerRefresh.Enabled = False
        End If
    End Sub
    Private Sub pbPowerExpended_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPowerExpended.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    fighter.bPowerUsed(listitem.Tag) = True
                Next
                PowerLoad()
            End If
        End If
    End Sub
    Private Sub pbPowerRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPowerRefresh.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    fighter.bPowerUsed(listitem.Tag) = False
                Next
                PowerLoad()
            End If
        End If
    End Sub
    Private Sub lbPowerUsage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPowerUsage.SelectedIndexChanged
        PowerButtonUpdate()
    End Sub

    Private Sub UseDisableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseDisableToolStripMenuItem.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    fighter.bPowerUsed(listitem.Tag) = True
                Next
                PowerLoad()
            End If
        End If
    End Sub

    Private Sub RechargeEnableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechargeEnableToolStripMenuItem.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    fighter.bPowerUsed(listitem.Tag) = False
                Next
                PowerLoad()
            End If
        End If
    End Sub

    Private Sub ViewCompendiumEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewCompendiumEntryToolStripMenuItem.Click
        ViewCompendium()
    End Sub
    Private Sub FindPower()
        REM Unusued currently.  Need to find a way to locate a string on the HTML Window, and scroll it to the top.
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    For Each temppower As StatPower In fighter.PowerList
                        If listitem.Tag = temppower.sName Then
                            Try
                                'Start(temppower.sURL)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                Next
            End If
        End If
    End Sub
    Private Sub ViewCompendium()
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            If lbPowerUsage.SelectedItems.Count > 0 Then
                For Each listitem As System.Windows.Forms.ListViewItem In lbPowerUsage.SelectedItems
                    For Each temppower As StatPower In fighter.PowerList
                        If listitem.Tag = temppower.sName Then
                            Try
                                'Start(temppower.sURL)
                                dfPowerBlockHTML.Navigate(temppower.sURL)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub CopyInitiativeListToClipboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyInitiativeListToClipboardToolStripMenuItem.Click
        Dim sInitList As String = ""
        If fight.Roster.Count > 0 Then
            For Each tempfighter In lbFightList.Items
                Dim thisfighter As Combatant = fight.Roster.Values(fight.Roster.IndexOfKey(tempfighter.text))
                sInitList = sInitList & thisfighter.sName & " - " & thisfighter.nInitRoll & ControlChars.CrLf
            Next
            My.Computer.Clipboard.SetText(sInitList)
        End If
    End Sub

    Private Sub TakeShortRestWMilestoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTakeShortRestWMilestoneToolStripMenuItem.Click
        If MsgBox("Are you sure you want to Take a Short Rest?" & ControlChars.NewLine & _
                    ControlChars.NewLine & "This will:" & ControlChars.NewLine & _
                    "    -Clear all monsters from the encounter" & ControlChars.NewLine & _
                    "    -Refresh all non-Daily PC powers" & ControlChars.NewLine & _
                    "    -Clear all temporary hit points" & ControlChars.NewLine & _
                    "    -Refresh PC Action Points", _
                MsgBoxStyle.YesNo, "Take Short Rest") = MsgBoxResult.Yes Then
            fight.TakeShortRestAddActionPoint()
            UpdateFromClass()
        End If
    End Sub

    Private Sub pbSubSurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSubSurge.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.ModSurges(-1)
            dfSurgesLeft.Text = fighter.sSurgeView
        End If
    End Sub

    Private Sub pbAddSurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddSurge.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.ModSurges(1)
            dfSurgesLeft.Text = fighter.sSurgeView
        End If
    End Sub

    Private Sub pbAllSurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAllSurge.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.ModSurges(fighter.Stat.nSurges - fighter.nSurgesLeft)
            dfSurgesLeft.Text = fighter.sSurgeView
        End If
    End Sub

    Private Sub AboutDnD4eCMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutDnD4eCMToolStripMenuItem.Click
        Dim aboutbox As New AboutBox1()
        Dim aboutboxReturn As DialogResult = aboutbox.ShowDialog(Me)
        aboutbox.Dispose()
    End Sub

    Private Sub menuAutoCompendium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAutoCompendium.Click
        My.Settings.bAutoCompendium = menuAutoCompendium.Checked
        My.Settings.Save()
    End Sub

    Private Sub menuStartWebServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuStartWebServerToolStripMenuItem.Click
        If cmWebServer.StartWebServer() Then
            ExportHTMLInitList()
            menuStartWebServerToolStripMenuItem.Enabled = False
            menuStopWebServer.Enabled = True
        End If
    End Sub
    Private Sub shutdown() Handles Me.FormClosing
        cmWebServer.StopWebServer()
    End Sub

    Private Sub ExportHTMLInitList()
        Dim tempstring As New System.Text.StringBuilder
        If fight.Roster.Count > 0 And fight.bOngoingFight Then
            tempstring.Append("<table width='100%' class='inittable'><tr>")
            If My.Settings.htmlDisplayRound Then tempstring.Append("<th class='header'>Round</th>")
            If My.Settings.htmlDisplayInit Then tempstring.Append("<th class='header'>Init</th>")
            tempstring.Append("<th class='header' width='30%'>Combatant</th>")
            tempstring.Append("<th class='header' width='50%'>Effects</th></tr>")
            For Each tempfighter In lbFightList.Items
                Dim thisfighter As Combatant = fight.Roster.Values(fight.Roster.IndexOfKey(tempfighter.text))
                If Not thisfighter.bHidden Then
                    If My.Settings.htmlDisplayRound Then tempstring.Append("<tr><td class='round'>" & fight.nCurrentRound.ToString & "</td>")
                    If My.Settings.htmlDisplayInit Then tempstring.Append("<td class='init'>" & thisfighter.nInitRoll & "</td>")
                    If thisfighter.bDyingOrDead Then
                        tempstring.Append("<td class='name' bgcolor='#999999'><font color='#FFFFFF'>")
                    ElseIf thisfighter.bUnconscious Then
                        tempstring.Append("<td class='name' bgcolor='#999999'><font color='#FFFFFF'>")
                    ElseIf thisfighter.bBloody Then
                        tempstring.Append("<td class='name' bgcolor='#FF0000'><font color='#FFFFFF'>")
                    Else
                        tempstring.Append("<td class='name'><font color='#000000'>")
                    End If
                    tempstring.Append(thisfighter.sName)
                    If ((thisfighter.bPC Or thisfighter.bCompanion) And My.Settings.htmlDisplayHeroHP) Or (Not (thisfighter.bPC Or thisfighter.bCompanion) And My.Settings.htmlDisplayOtherHP) Then tempstring.Append(" - " & thisfighter.sStatusLine)
                    tempstring.Append("</font></td><td class='effects'><table class='effecttable'>")
                    For Each eff As Effect In fight.EffectsByTarget(thisfighter.sCombatHandle)
                        If Not eff.bHidden Then
                            Dim tempeffect As New System.Text.StringBuilder
                            If eff.bBeneficial Then
                                tempeffect.Append("<tr bgcolor='#999900'>")
                            Else
                                tempeffect.Append("<tr bgcolor='#FF0000'>")
                            End If
                            tempeffect.Append("<td class='effectdetail'>" & eff.sName & "</td>")
                            tempeffect.Append("<td class='effectdetail'>Source: " & eff.sSourceHandle & "</td>")
                            tempeffect.Append("<td class='effectdetail'>Duration: " & eff.sDesc & "</td></tr>")
                            tempstring.Append(tempeffect.ToString)
                        End If
                    Next
                    tempstring.Append("</table></td></tr>")
                End If
            Next
            tempstring.Append("</table>")
            cmHTMLInitList.Text = tempstring.ToString
        End If
    End Sub

    Private Sub menuStopWebServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuStopWebServer.Click
        cmWebServer.StopWebServer()
        menuStartWebServerToolStripMenuItem.Enabled = True
        menuStopWebServer.Enabled = False
    End Sub

    Private Sub menucbGroupSimilar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menucbGroupSimilar.Click
        My.Settings.bGroupSimilar = menucbGroupSimilar.Checked
        My.Settings.Save()
    End Sub

    Private Sub OptionsToolStripMenuItem_Open(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        UpdateCheckedOptions()
    End Sub
    Private Sub UpdateCheckedOptions()
        If menuRollForPowerRechargeToolStripMenuItem.Checked <> My.Settings.bRollPowerRecharge Then menuRollForPowerRechargeToolStripMenuItem.Checked = My.Settings.bRollPowerRecharge
        If menuPopupForOngoingDamageToolStripMenuItem.Checked <> My.Settings.bOngoingPopup Then menuPopupForOngoingDamageToolStripMenuItem.Checked = My.Settings.bOngoingPopup
        If menuRollSavesAutomaticallyToolStripMenuItem.Checked <> My.Settings.bRollEffectSaves Then menuRollSavesAutomaticallyToolStripMenuItem.Checked = My.Settings.bRollEffectSaves
        If menucbGroupSimilar.Checked <> My.Settings.bGroupSimilar Then menucbGroupSimilar.Checked = My.Settings.bGroupSimilar
        If menuAutoCompendium.Checked <> My.Settings.bAutoCompendium Then menuAutoCompendium.Checked = My.Settings.bAutoCompendium
        If menuSurpriseRound.Checked <> My.Settings.bSurpriseRound Then menuSurpriseRound.Checked = My.Settings.bSurpriseRound
    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Dim configWin As New Config
        configWin.ShowDialog(Me)
    End Sub

    Private Sub ctxtmenuInitList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtmenuInitList.Opening
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            ctxtDisplayName.Text = fighter.sName
            ctxtHideCombatant.Checked = fighter.bHidden
        End If
    End Sub

    Private Sub ctxtDisplayName_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtDisplayName.Leave
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.sName = ctxtDisplayName.Text
        End If
    End Sub

    Private Sub ctxtHideCombattant_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtHideCombatant.CheckedChanged
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.bHidden = ctxtHideCombatant.Checked
        End If
        UpdateFromClass()
    End Sub

    Private Sub btnAddMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMax.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.ModMaxSurges(1)
            dfSurgesLeft.Text = fighter.sSurgeView
        End If
    End Sub

    Private Sub btnSubMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubMax.Click
        Dim fighter As Combatant = ListSelectedFighter
        If Not fighter Is Nothing Then
            fighter.ModMaxSurges(-1)
            dfSurgesLeft.Text = fighter.sSurgeView
        End If
    End Sub

    Private Sub CopyInitiativeListToClipboardHTMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyInitiativeListToClipboardHTMLToolStripMenuItem.Click
        Dim sInitList As String = ""
        If fight.Roster.Count > 0 Then
            ExportHTMLInitList()
            My.Computer.Clipboard.SetText(cmHTMLInitList.Text)
        End If
    End Sub

    Private Sub dfPowerBlockHTML_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles dfPowerBlockHTML.DocumentCompleted

    End Sub
End Class