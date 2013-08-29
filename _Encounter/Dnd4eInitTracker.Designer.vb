<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTracker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Rounds", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Delaying", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Readied", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Inactive", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("In Flux", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Reserve", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTracker))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuLoadEncounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSaveEncounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSelectCurrentCombatantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuRollAllInit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuResetAllInit = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyInitiativeListToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyInitiativeListToClipboardHTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuClearNPCsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatLibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTakeShortRestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTakeShortRestWMilestoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTakeExtendedRestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuResetPCHealthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuClearPCsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menucbGroupSimilar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAutomaticRollsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRollSavesAutomaticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRollForPowerRechargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPopupForOngoingDamageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSurpriseRound = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAutoCompendium = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RosterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStatLibraryOpenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStartWebServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStopWebServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutDnD4eCMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitLeft = New System.Windows.Forms.SplitContainer()
        Me.SplitLeftUpDown = New System.Windows.Forms.SplitContainer()
        Me.ToolStripListbox = New System.Windows.Forms.ToolStripContainer()
        Me.lbFightList = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRound = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDef = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ctxtmenuInitList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxtMoveToTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxtReadyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtDelayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxtRemoveFighterFromCombatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtMarkedEncounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtMarkedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxtDisplayName = New System.Windows.Forms.ToolStripTextBox()
        Me.ctxtHideCombatant = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripEncXP = New System.Windows.Forms.ToolStrip()
        Me.toolPCCount = New System.Windows.Forms.ToolStripLabel()
        Me.dfPartySize = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolEncLevel = New System.Windows.Forms.ToolStripLabel()
        Me.dfEncounterLevel = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolTotalXP = New System.Windows.Forms.ToolStripLabel()
        Me.dfXPTotal = New System.Windows.Forms.ToolStripTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dfGlobalNotes = New System.Windows.Forms.TextBox()
        Me.SplitMiddleRight = New System.Windows.Forms.SplitContainer()
        Me.SplitMiddleUpDown = New System.Windows.Forms.SplitContainer()
        Me.SplitMiddleTop = New System.Windows.Forms.SplitContainer()
        Me.ToolStripMiddleTop = New System.Windows.Forms.ToolStripContainer()
        Me.TabControlStats = New System.Windows.Forms.TabControl()
        Me.tabInitiative = New System.Windows.Forms.TabPage()
        Me.dfStatInitRoll = New System.Windows.Forms.NumericUpDown()
        Me.pbDeleteFighter = New System.Windows.Forms.Button()
        Me.pbReserve = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbDelay = New System.Windows.Forms.Button()
        Me.pbMoveToTop = New System.Windows.Forms.Button()
        Me.pbReady = New System.Windows.Forms.Button()
        Me.pbRollInit = New System.Windows.Forms.Button()
        Me.tabDamageHeal = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSubMax = New System.Windows.Forms.Button()
        Me.btnAddMax = New System.Windows.Forms.Button()
        Me.pbAllSurge = New System.Windows.Forms.Button()
        Me.pbAddSurge = New System.Windows.Forms.Button()
        Me.pbSubSurge = New System.Windows.Forms.Button()
        Me.dfSurgesLeft = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pbHPplus5 = New System.Windows.Forms.Button()
        Me.pbSurge = New System.Windows.Forms.Button()
        Me.pbHP5 = New System.Windows.Forms.Button()
        Me.dfDamHealAmt = New System.Windows.Forms.NumericUpDown()
        Me.pbDealDamage = New System.Windows.Forms.Button()
        Me.pbUnfailDeath = New System.Windows.Forms.Button()
        Me.pbMaxHP = New System.Windows.Forms.Button()
        Me.pbHealDamage = New System.Windows.Forms.Button()
        Me.pbAddTemp = New System.Windows.Forms.Button()
        Me.pbFailDeath = New System.Windows.Forms.Button()
        Me.tabFighterStats = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dfStatCurrHP = New System.Windows.Forms.TextBox()
        Me.dfStatMaxHP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dfStatLevel = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dfStatDefWill = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dfStatDefReflex = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dfStatDefFort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dfStatDefAC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dfRoleMod = New System.Windows.Forms.ComboBox()
        Me.labRoleMod = New System.Windows.Forms.Label()
        Me.dfXPValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripName = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.dfStatName = New System.Windows.Forms.ToolStripTextBox()
        Me.dfFighterNum = New System.Windows.Forms.ToolStripTextBox()
        Me.pbNextInit = New System.Windows.Forms.Button()
        Me.pbBackRound = New System.Windows.Forms.Button()
        Me.SplitMiddleBottom = New System.Windows.Forms.SplitContainer()
        Me.ToolStripContainerEffects = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStripEffects = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.pbEffectAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.pbEffectChange = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.pbEffectRemove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbEffects = New System.Windows.Forms.ListView()
        Me.colEffectName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSource = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEffectDuration = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabMiddleBottom = New System.Windows.Forms.TabControl()
        Me.tabPowers = New System.Windows.Forms.TabPage()
        Me.ToolContainerPowerUsage = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStripPowerUsage = New System.Windows.Forms.ToolStrip()
        Me.pbPowerExpended = New System.Windows.Forms.ToolStripButton()
        Me.pbPowerRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbPowerUsage = New System.Windows.Forms.ListView()
        Me.colPowerName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPowerAction = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CctxtmenuPowerList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UseDisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechargeEnableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewCompendiumEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAsActiveStance = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabNotes = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dfFighterNotes = New System.Windows.Forms.TextBox()
        Me.RightPanelSplit = New System.Windows.Forms.SplitContainer()
        Me.dfHTMLStatBlock = New System.Windows.Forms.WebBrowser()
        Me.dfPowerBlockHTML = New System.Windows.Forms.WebBrowser()
        Me.pbDoNothing = New System.Windows.Forms.Button()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.MenuStrip1.SuspendLayout()
        Me.SplitLeft.Panel1.SuspendLayout()
        Me.SplitLeft.Panel2.SuspendLayout()
        Me.SplitLeft.SuspendLayout()
        Me.SplitLeftUpDown.Panel1.SuspendLayout()
        Me.SplitLeftUpDown.Panel2.SuspendLayout()
        Me.SplitLeftUpDown.SuspendLayout()
        Me.ToolStripListbox.ContentPanel.SuspendLayout()
        Me.ToolStripListbox.TopToolStripPanel.SuspendLayout()
        Me.ToolStripListbox.SuspendLayout()
        Me.ctxtmenuInitList.SuspendLayout()
        Me.ToolStripEncXP.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SplitMiddleRight.Panel1.SuspendLayout()
        Me.SplitMiddleRight.Panel2.SuspendLayout()
        Me.SplitMiddleRight.SuspendLayout()
        Me.SplitMiddleUpDown.Panel1.SuspendLayout()
        Me.SplitMiddleUpDown.Panel2.SuspendLayout()
        Me.SplitMiddleUpDown.SuspendLayout()
        Me.SplitMiddleTop.Panel1.SuspendLayout()
        Me.SplitMiddleTop.Panel2.SuspendLayout()
        Me.SplitMiddleTop.SuspendLayout()
        Me.ToolStripMiddleTop.ContentPanel.SuspendLayout()
        Me.ToolStripMiddleTop.TopToolStripPanel.SuspendLayout()
        Me.ToolStripMiddleTop.SuspendLayout()
        Me.TabControlStats.SuspendLayout()
        Me.tabInitiative.SuspendLayout()
        CType(Me.dfStatInitRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDamageHeal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dfDamHealAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFighterStats.SuspendLayout()
        Me.ToolStripName.SuspendLayout()
        Me.SplitMiddleBottom.Panel1.SuspendLayout()
        Me.SplitMiddleBottom.Panel2.SuspendLayout()
        Me.SplitMiddleBottom.SuspendLayout()
        Me.ToolStripContainerEffects.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainerEffects.ContentPanel.SuspendLayout()
        Me.ToolStripContainerEffects.SuspendLayout()
        Me.ToolStripEffects.SuspendLayout()
        Me.TabMiddleBottom.SuspendLayout()
        Me.tabPowers.SuspendLayout()
        Me.ToolContainerPowerUsage.BottomToolStripPanel.SuspendLayout()
        Me.ToolContainerPowerUsage.ContentPanel.SuspendLayout()
        Me.ToolContainerPowerUsage.SuspendLayout()
        Me.ToolStripPowerUsage.SuspendLayout()
        Me.CctxtmenuPowerList.SuspendLayout()
        Me.tabNotes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.RightPanelSplit.Panel1.SuspendLayout()
        Me.RightPanelSplit.Panel2.SuspendLayout()
        Me.RightPanelSplit.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EncounterToolStripMenuItem, Me.StatLibraryToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.RosterToolStripMenuItem, Me.WebServerToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(892, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNewToolStripMenuItem, Me.ToolStripSeparator2, Me.menuImportToolStripMenuItem, Me.ToolStripSeparator3, Me.menuLoadEncounterToolStripMenuItem, Me.menuSaveEncounterToolStripMenuItem, Me.ToolStripSeparator8, Me.menuExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'menuNewToolStripMenuItem
        '
        Me.menuNewToolStripMenuItem.Name = "menuNewToolStripMenuItem"
        Me.menuNewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.menuNewToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.menuNewToolStripMenuItem.Text = "&New"
        Me.menuNewToolStripMenuItem.ToolTipText = "Clear current encounter Roster" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(new combatants must be added from Library)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'menuImportToolStripMenuItem
        '
        Me.menuImportToolStripMenuItem.Name = "menuImportToolStripMenuItem"
        Me.menuImportToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.menuImportToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.menuImportToolStripMenuItem.Text = "Import Encounter"
        Me.menuImportToolStripMenuItem.ToolTipText = "Load Roster from file into current encounter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(does not clear current Roster)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(194, 6)
        '
        'menuLoadEncounterToolStripMenuItem
        '
        Me.menuLoadEncounterToolStripMenuItem.Name = "menuLoadEncounterToolStripMenuItem"
        Me.menuLoadEncounterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.menuLoadEncounterToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.menuLoadEncounterToolStripMenuItem.Text = "&Load Encounter"
        Me.menuLoadEncounterToolStripMenuItem.ToolTipText = "Load new Roster from file " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(clears current Roster)"
        '
        'menuSaveEncounterToolStripMenuItem
        '
        Me.menuSaveEncounterToolStripMenuItem.Name = "menuSaveEncounterToolStripMenuItem"
        Me.menuSaveEncounterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.menuSaveEncounterToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.menuSaveEncounterToolStripMenuItem.Text = "&Save Encounter"
        Me.menuSaveEncounterToolStripMenuItem.ToolTipText = "Save current encounter roster to file"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(194, 6)
        '
        'menuExitToolStripMenuItem
        '
        Me.menuExitToolStripMenuItem.Name = "menuExitToolStripMenuItem"
        Me.menuExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.menuExitToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.menuExitToolStripMenuItem.Text = "E&xit"
        Me.menuExitToolStripMenuItem.ToolTipText = "Exit Combat Tracker"
        '
        'EncounterToolStripMenuItem
        '
        Me.EncounterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSelectCurrentCombatantToolStripMenuItem, Me.ToolStripSeparator9, Me.menuRollAllInit, Me.menuResetAllInit, Me.CopyInitiativeListToClipboardToolStripMenuItem, Me.CopyInitiativeListToClipboardHTMLToolStripMenuItem, Me.ToolStripSeparator10, Me.menuClearNPCsToolStripMenuItem})
        Me.EncounterToolStripMenuItem.Name = "EncounterToolStripMenuItem"
        Me.EncounterToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.EncounterToolStripMenuItem.Text = "Encounter"
        '
        'menuSelectCurrentCombatantToolStripMenuItem
        '
        Me.menuSelectCurrentCombatantToolStripMenuItem.Name = "menuSelectCurrentCombatantToolStripMenuItem"
        Me.menuSelectCurrentCombatantToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.menuSelectCurrentCombatantToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.menuSelectCurrentCombatantToolStripMenuItem.Text = "Select Current"
        Me.menuSelectCurrentCombatantToolStripMenuItem.ToolTipText = "Select the currently acting combatant."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(281, 6)
        '
        'menuRollAllInit
        '
        Me.menuRollAllInit.Name = "menuRollAllInit"
        Me.menuRollAllInit.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.menuRollAllInit.Size = New System.Drawing.Size(284, 22)
        Me.menuRollAllInit.Text = "Roll Initiative"
        Me.menuRollAllInit.ToolTipText = "This will roll Initiative for all currently unrolled combatants." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pre-existing in" & _
    "itiative rolls will not be affected."
        '
        'menuResetAllInit
        '
        Me.menuResetAllInit.Name = "menuResetAllInit"
        Me.menuResetAllInit.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
        Me.menuResetAllInit.Size = New System.Drawing.Size(284, 22)
        Me.menuResetAllInit.Text = "End Encounter"
        Me.menuResetAllInit.ToolTipText = "End the Current Encounter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This will remove all ongoing effects and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "reset monste" & _
    "r health."
        '
        'CopyInitiativeListToClipboardToolStripMenuItem
        '
        Me.CopyInitiativeListToClipboardToolStripMenuItem.Name = "CopyInitiativeListToClipboardToolStripMenuItem"
        Me.CopyInitiativeListToClipboardToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.CopyInitiativeListToClipboardToolStripMenuItem.Text = "Copy Initiative List to Clipboard"
        '
        'CopyInitiativeListToClipboardHTMLToolStripMenuItem
        '
        Me.CopyInitiativeListToClipboardHTMLToolStripMenuItem.Name = "CopyInitiativeListToClipboardHTMLToolStripMenuItem"
        Me.CopyInitiativeListToClipboardHTMLToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.CopyInitiativeListToClipboardHTMLToolStripMenuItem.Text = "Copy Initiative List to Clipboard (HTML)"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(281, 6)
        '
        'menuClearNPCsToolStripMenuItem
        '
        Me.menuClearNPCsToolStripMenuItem.Name = "menuClearNPCsToolStripMenuItem"
        Me.menuClearNPCsToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.menuClearNPCsToolStripMenuItem.Text = "Remove All Monsters"
        Me.menuClearNPCsToolStripMenuItem.ToolTipText = "Clear all NPCs from roster" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(combat must be reset first)"
        '
        'StatLibraryToolStripMenuItem
        '
        Me.StatLibraryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuTakeShortRestToolStripMenuItem, Me.menuTakeShortRestWMilestoneToolStripMenuItem, Me.menuTakeExtendedRestToolStripMenuItem, Me.ToolStripSeparator6, Me.menuResetPCHealthToolStripMenuItem, Me.ToolStripSeparator4, Me.menuClearPCsToolStripMenuItem})
        Me.StatLibraryToolStripMenuItem.Name = "StatLibraryToolStripMenuItem"
        Me.StatLibraryToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.StatLibraryToolStripMenuItem.Text = "Party"
        '
        'menuTakeShortRestToolStripMenuItem
        '
        Me.menuTakeShortRestToolStripMenuItem.Name = "menuTakeShortRestToolStripMenuItem"
        Me.menuTakeShortRestToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.menuTakeShortRestToolStripMenuItem.Text = "Take Short Rest"
        '
        'menuTakeShortRestWMilestoneToolStripMenuItem
        '
        Me.menuTakeShortRestWMilestoneToolStripMenuItem.Name = "menuTakeShortRestWMilestoneToolStripMenuItem"
        Me.menuTakeShortRestWMilestoneToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.menuTakeShortRestWMilestoneToolStripMenuItem.Text = "Take Short Rest w/ Milestone"
        '
        'menuTakeExtendedRestToolStripMenuItem
        '
        Me.menuTakeExtendedRestToolStripMenuItem.Name = "menuTakeExtendedRestToolStripMenuItem"
        Me.menuTakeExtendedRestToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.menuTakeExtendedRestToolStripMenuItem.Text = "Take Extended Rest"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(224, 6)
        '
        'menuResetPCHealthToolStripMenuItem
        '
        Me.menuResetPCHealthToolStripMenuItem.Name = "menuResetPCHealthToolStripMenuItem"
        Me.menuResetPCHealthToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.menuResetPCHealthToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.menuResetPCHealthToolStripMenuItem.Text = "Reset PC Health"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(224, 6)
        '
        'menuClearPCsToolStripMenuItem
        '
        Me.menuClearPCsToolStripMenuItem.Name = "menuClearPCsToolStripMenuItem"
        Me.menuClearPCsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.menuClearPCsToolStripMenuItem.Text = "Remove Party from Roster"
        Me.menuClearPCsToolStripMenuItem.ToolTipText = "Clear all PCs from roster" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(combat must be reset first)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menucbGroupSimilar, Me.menuAutomaticRollsToolStripMenuItem, Me.menuPopupForOngoingDamageToolStripMenuItem, Me.menuSurpriseRound, Me.menuAutoCompendium, Me.ConfigurationToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'menucbGroupSimilar
        '
        Me.menucbGroupSimilar.Checked = True
        Me.menucbGroupSimilar.CheckOnClick = True
        Me.menucbGroupSimilar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menucbGroupSimilar.Name = "menucbGroupSimilar"
        Me.menucbGroupSimilar.Size = New System.Drawing.Size(295, 22)
        Me.menucbGroupSimilar.Text = "Group Similar when Rolling"
        Me.menucbGroupSimilar.ToolTipText = "Use the same initiative roll for all similar combatants"
        '
        'menuAutomaticRollsToolStripMenuItem
        '
        Me.menuAutomaticRollsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRollSavesAutomaticallyToolStripMenuItem, Me.menuRollForPowerRechargeToolStripMenuItem})
        Me.menuAutomaticRollsToolStripMenuItem.Name = "menuAutomaticRollsToolStripMenuItem"
        Me.menuAutomaticRollsToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.menuAutomaticRollsToolStripMenuItem.Text = "Automatic Rolls"
        '
        'menuRollSavesAutomaticallyToolStripMenuItem
        '
        Me.menuRollSavesAutomaticallyToolStripMenuItem.CheckOnClick = True
        Me.menuRollSavesAutomaticallyToolStripMenuItem.Name = "menuRollSavesAutomaticallyToolStripMenuItem"
        Me.menuRollSavesAutomaticallyToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.menuRollSavesAutomaticallyToolStripMenuItem.Text = "Roll for Saving Throws"
        '
        'menuRollForPowerRechargeToolStripMenuItem
        '
        Me.menuRollForPowerRechargeToolStripMenuItem.CheckOnClick = True
        Me.menuRollForPowerRechargeToolStripMenuItem.Name = "menuRollForPowerRechargeToolStripMenuItem"
        Me.menuRollForPowerRechargeToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.menuRollForPowerRechargeToolStripMenuItem.Text = "Roll for Power Recharge"
        '
        'menuPopupForOngoingDamageToolStripMenuItem
        '
        Me.menuPopupForOngoingDamageToolStripMenuItem.Checked = True
        Me.menuPopupForOngoingDamageToolStripMenuItem.CheckOnClick = True
        Me.menuPopupForOngoingDamageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuPopupForOngoingDamageToolStripMenuItem.Name = "menuPopupForOngoingDamageToolStripMenuItem"
        Me.menuPopupForOngoingDamageToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.menuPopupForOngoingDamageToolStripMenuItem.Text = "Popup for Ongoing Damage"
        '
        'menuSurpriseRound
        '
        Me.menuSurpriseRound.CheckOnClick = True
        Me.menuSurpriseRound.Name = "menuSurpriseRound"
        Me.menuSurpriseRound.Size = New System.Drawing.Size(295, 22)
        Me.menuSurpriseRound.Text = "Include Surprise Round"
        '
        'menuAutoCompendium
        '
        Me.menuAutoCompendium.CheckOnClick = True
        Me.menuAutoCompendium.Name = "menuAutoCompendium"
        Me.menuAutoCompendium.Size = New System.Drawing.Size(295, 22)
        Me.menuAutoCompendium.Text = "Auto-Load Compendium Powers on Click"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'RosterToolStripMenuItem
        '
        Me.RosterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuStatLibraryOpenMenuItem})
        Me.RosterToolStripMenuItem.Name = "RosterToolStripMenuItem"
        Me.RosterToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.RosterToolStripMenuItem.Text = "Library"
        '
        'menuStatLibraryOpenMenuItem
        '
        Me.menuStatLibraryOpenMenuItem.Name = "menuStatLibraryOpenMenuItem"
        Me.menuStatLibraryOpenMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.menuStatLibraryOpenMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.menuStatLibraryOpenMenuItem.Text = "Open Statblock Library"
        Me.menuStatLibraryOpenMenuItem.ToolTipText = "Open the Library" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(it is used for creation, update, deletion, copy-pasting, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and" & _
    " adding-to-battle of stat blocks)"
        '
        'WebServerToolStripMenuItem
        '
        Me.WebServerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuStartWebServerToolStripMenuItem, Me.menuStopWebServer})
        Me.WebServerToolStripMenuItem.Name = "WebServerToolStripMenuItem"
        Me.WebServerToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.WebServerToolStripMenuItem.Text = "WebServer"
        '
        'menuStartWebServerToolStripMenuItem
        '
        Me.menuStartWebServerToolStripMenuItem.Name = "menuStartWebServerToolStripMenuItem"
        Me.menuStartWebServerToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.menuStartWebServerToolStripMenuItem.Text = "Start WebServer"
        '
        'menuStopWebServer
        '
        Me.menuStopWebServer.Enabled = False
        Me.menuStopWebServer.Name = "menuStopWebServer"
        Me.menuStopWebServer.Size = New System.Drawing.Size(157, 22)
        Me.menuStopWebServer.Text = "Stop WebServer"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutDnD4eCMToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutDnD4eCMToolStripMenuItem
        '
        Me.AboutDnD4eCMToolStripMenuItem.Name = "AboutDnD4eCMToolStripMenuItem"
        Me.AboutDnD4eCMToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.AboutDnD4eCMToolStripMenuItem.Text = "About DnD4eCM"
        '
        'SplitLeft
        '
        Me.SplitLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeft.Location = New System.Drawing.Point(0, 24)
        Me.SplitLeft.Name = "SplitLeft"
        '
        'SplitLeft.Panel1
        '
        Me.SplitLeft.Panel1.Controls.Add(Me.SplitLeftUpDown)
        '
        'SplitLeft.Panel2
        '
        Me.SplitLeft.Panel2.Controls.Add(Me.SplitMiddleRight)
        Me.SplitLeft.Size = New System.Drawing.Size(892, 523)
        Me.SplitLeft.SplitterDistance = 274
        Me.SplitLeft.SplitterWidth = 6
        Me.SplitLeft.TabIndex = 1
        '
        'SplitLeftUpDown
        '
        Me.SplitLeftUpDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeftUpDown.Location = New System.Drawing.Point(0, 0)
        Me.SplitLeftUpDown.Name = "SplitLeftUpDown"
        Me.SplitLeftUpDown.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitLeftUpDown.Panel1
        '
        Me.SplitLeftUpDown.Panel1.Controls.Add(Me.ToolStripListbox)
        '
        'SplitLeftUpDown.Panel2
        '
        Me.SplitLeftUpDown.Panel2.Controls.Add(Me.GroupBox5)
        Me.SplitLeftUpDown.Size = New System.Drawing.Size(274, 523)
        Me.SplitLeftUpDown.SplitterDistance = 327
        Me.SplitLeftUpDown.TabIndex = 0
        '
        'ToolStripListbox
        '
        Me.ToolStripListbox.BottomToolStripPanelVisible = False
        '
        'ToolStripListbox.ContentPanel
        '
        Me.ToolStripListbox.ContentPanel.Controls.Add(Me.lbFightList)
        Me.ToolStripListbox.ContentPanel.Size = New System.Drawing.Size(274, 298)
        Me.ToolStripListbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripListbox.LeftToolStripPanelVisible = False
        Me.ToolStripListbox.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripListbox.Name = "ToolStripListbox"
        Me.ToolStripListbox.RightToolStripPanelVisible = False
        Me.ToolStripListbox.Size = New System.Drawing.Size(274, 327)
        Me.ToolStripListbox.TabIndex = 0
        Me.ToolStripListbox.Text = "ToolStripContainer1"
        '
        'ToolStripListbox.TopToolStripPanel
        '
        Me.ToolStripListbox.TopToolStripPanel.Controls.Add(Me.ToolStripEncXP)
        '
        'lbFightList
        '
        Me.lbFightList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colStatus, Me.colRound, Me.colDef})
        Me.lbFightList.ContextMenuStrip = Me.ctxtmenuInitList
        Me.lbFightList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbFightList.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFightList.FullRowSelect = True
        ListViewGroup1.Header = "Rounds"
        ListViewGroup1.Name = "grpCurrentRnd"
        ListViewGroup2.Header = "Delaying"
        ListViewGroup2.Name = "grpDelay"
        ListViewGroup3.Header = "Readied"
        ListViewGroup3.Name = "grpReady"
        ListViewGroup4.Header = "Inactive"
        ListViewGroup4.Name = "grpInactive"
        ListViewGroup5.Header = "In Flux"
        ListViewGroup5.Name = "grpRolling"
        ListViewGroup6.Header = "Reserve"
        ListViewGroup6.Name = "grpReserve"
        Me.lbFightList.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6})
        Me.lbFightList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lbFightList.HideSelection = False
        Me.lbFightList.Location = New System.Drawing.Point(0, 0)
        Me.lbFightList.MultiSelect = False
        Me.lbFightList.Name = "lbFightList"
        Me.lbFightList.Size = New System.Drawing.Size(274, 298)
        Me.lbFightList.TabIndex = 0
        Me.lbFightList.UseCompatibleStateImageBehavior = False
        Me.lbFightList.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.DisplayIndex = 1
        Me.colName.Text = "Name"
        Me.colName.Width = 119
        '
        'colStatus
        '
        Me.colStatus.DisplayIndex = 2
        Me.colStatus.Text = "Status"
        Me.colStatus.Width = 52
        '
        'colRound
        '
        Me.colRound.DisplayIndex = 0
        Me.colRound.Text = "R"
        Me.colRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colRound.Width = 25
        '
        'colDef
        '
        Me.colDef.Text = "AC F R W"
        Me.colDef.Width = 73
        '
        'ctxtmenuInitList
        '
        Me.ctxtmenuInitList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxtMoveToTopToolStripMenuItem, Me.ToolStripSeparator18, Me.ctxtReadyToolStripMenuItem, Me.ctxtDelayToolStripMenuItem, Me.ToolStripSeparator5, Me.ctxtRemoveFighterFromCombatToolStripMenuItem, Me.MarksToolStripMenuItem, Me.ToolStripMenuItem1, Me.ctxtDisplayName, Me.ctxtHideCombatant})
        Me.ctxtmenuInitList.Name = "ctxtmenuInitList"
        Me.ctxtmenuInitList.ShowCheckMargin = True
        Me.ctxtmenuInitList.ShowImageMargin = False
        Me.ctxtmenuInitList.Size = New System.Drawing.Size(233, 177)
        Me.ctxtmenuInitList.Text = "Combat Options"
        '
        'ctxtMoveToTopToolStripMenuItem
        '
        Me.ctxtMoveToTopToolStripMenuItem.Name = "ctxtMoveToTopToolStripMenuItem"
        Me.ctxtMoveToTopToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ctxtMoveToTopToolStripMenuItem.Text = "Move to Top"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(229, 6)
        '
        'ctxtReadyToolStripMenuItem
        '
        Me.ctxtReadyToolStripMenuItem.Name = "ctxtReadyToolStripMenuItem"
        Me.ctxtReadyToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ctxtReadyToolStripMenuItem.Text = "Ready Action"
        '
        'ctxtDelayToolStripMenuItem
        '
        Me.ctxtDelayToolStripMenuItem.Name = "ctxtDelayToolStripMenuItem"
        Me.ctxtDelayToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ctxtDelayToolStripMenuItem.Text = "Delay Initiative"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(229, 6)
        '
        'ctxtRemoveFighterFromCombatToolStripMenuItem
        '
        Me.ctxtRemoveFighterFromCombatToolStripMenuItem.Name = "ctxtRemoveFighterFromCombatToolStripMenuItem"
        Me.ctxtRemoveFighterFromCombatToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ctxtRemoveFighterFromCombatToolStripMenuItem.Text = "Remove Fighter from Combat"
        '
        'MarksToolStripMenuItem
        '
        Me.MarksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxtMarkedEncounterToolStripMenuItem, Me.ctxtMarkedToolStripMenuItem})
        Me.MarksToolStripMenuItem.Name = "MarksToolStripMenuItem"
        Me.MarksToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.MarksToolStripMenuItem.Text = "Marks"
        '
        'ctxtMarkedEncounterToolStripMenuItem
        '
        Me.ctxtMarkedEncounterToolStripMenuItem.Name = "ctxtMarkedEncounterToolStripMenuItem"
        Me.ctxtMarkedEncounterToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.ctxtMarkedEncounterToolStripMenuItem.Text = "Marked Until End of Encounter"
        '
        'ctxtMarkedToolStripMenuItem
        '
        Me.ctxtMarkedToolStripMenuItem.Name = "ctxtMarkedToolStripMenuItem"
        Me.ctxtMarkedToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.ctxtMarkedToolStripMenuItem.Text = "Marked Until Source's Next Turn"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(229, 6)
        '
        'ctxtDisplayName
        '
        Me.ctxtDisplayName.AutoSize = False
        Me.ctxtDisplayName.AutoToolTip = True
        Me.ctxtDisplayName.Name = "ctxtDisplayName"
        Me.ctxtDisplayName.Size = New System.Drawing.Size(120, 21)
        Me.ctxtDisplayName.ToolTipText = "Change the name as it displays on Initative List"
        '
        'ctxtHideCombatant
        '
        Me.ctxtHideCombatant.CheckOnClick = True
        Me.ctxtHideCombatant.Name = "ctxtHideCombatant"
        Me.ctxtHideCombatant.Size = New System.Drawing.Size(232, 22)
        Me.ctxtHideCombatant.Text = "Hide from Secondary Displays"
        '
        'ToolStripEncXP
        '
        Me.ToolStripEncXP.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEncXP.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEncXP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolPCCount, Me.dfPartySize, Me.ToolStripSeparator7, Me.toolEncLevel, Me.dfEncounterLevel, Me.ToolStripSeparator1, Me.toolTotalXP, Me.dfXPTotal})
        Me.ToolStripEncXP.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripEncXP.Name = "ToolStripEncXP"
        Me.ToolStripEncXP.Padding = New System.Windows.Forms.Padding(0, 0, 1, 4)
        Me.ToolStripEncXP.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripEncXP.Size = New System.Drawing.Size(274, 29)
        Me.ToolStripEncXP.Stretch = True
        Me.ToolStripEncXP.TabIndex = 0
        '
        'toolPCCount
        '
        Me.toolPCCount.Name = "toolPCCount"
        Me.toolPCCount.Size = New System.Drawing.Size(30, 22)
        Me.toolPCCount.Text = "PCs:"
        Me.toolPCCount.ToolTipText = "Number of PCs currently in Encounter"
        '
        'dfPartySize
        '
        Me.dfPartySize.Enabled = False
        Me.dfPartySize.Name = "dfPartySize"
        Me.dfPartySize.Size = New System.Drawing.Size(30, 25)
        Me.dfPartySize.ToolTipText = "Number of PCs currently in Encounter"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolEncLevel
        '
        Me.toolEncLevel.Name = "toolEncLevel"
        Me.toolEncLevel.Size = New System.Drawing.Size(59, 22)
        Me.toolEncLevel.Text = "Enc Level:"
        Me.toolEncLevel.ToolTipText = "Current encounter level for current PCs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(if no PCs, is based on a party of 5)"
        '
        'dfEncounterLevel
        '
        Me.dfEncounterLevel.Enabled = False
        Me.dfEncounterLevel.Name = "dfEncounterLevel"
        Me.dfEncounterLevel.Size = New System.Drawing.Size(30, 25)
        Me.dfEncounterLevel.ToolTipText = "Current encounter level for current PCs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(if no PCs, is based on a party of 5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolTotalXP
        '
        Me.toolTotalXP.Name = "toolTotalXP"
        Me.toolTotalXP.Size = New System.Drawing.Size(54, 22)
        Me.toolTotalXP.Text = "Total XP:"
        Me.toolTotalXP.ToolTipText = "Total XP available from combatants"
        '
        'dfXPTotal
        '
        Me.dfXPTotal.Enabled = False
        Me.dfXPTotal.Name = "dfXPTotal"
        Me.dfXPTotal.Size = New System.Drawing.Size(60, 23)
        Me.dfXPTotal.ToolTipText = "Total XP available from combatants"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dfGlobalNotes)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(274, 192)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Global Notes"
        '
        'dfGlobalNotes
        '
        Me.dfGlobalNotes.AcceptsReturn = True
        Me.dfGlobalNotes.AcceptsTab = True
        Me.dfGlobalNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dfGlobalNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfGlobalNotes.Location = New System.Drawing.Point(3, 16)
        Me.dfGlobalNotes.Multiline = True
        Me.dfGlobalNotes.Name = "dfGlobalNotes"
        Me.dfGlobalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dfGlobalNotes.Size = New System.Drawing.Size(268, 173)
        Me.dfGlobalNotes.TabIndex = 0
        '
        'SplitMiddleRight
        '
        Me.SplitMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddleRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitMiddleRight.IsSplitterFixed = True
        Me.SplitMiddleRight.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddleRight.Name = "SplitMiddleRight"
        '
        'SplitMiddleRight.Panel1
        '
        Me.SplitMiddleRight.Panel1.Controls.Add(Me.SplitMiddleUpDown)
        '
        'SplitMiddleRight.Panel2
        '
        Me.SplitMiddleRight.Panel2.Controls.Add(Me.RightPanelSplit)
        Me.SplitMiddleRight.Panel2.Controls.Add(Me.pbDoNothing)
        Me.SplitMiddleRight.Size = New System.Drawing.Size(612, 523)
        Me.SplitMiddleRight.SplitterDistance = 300
        Me.SplitMiddleRight.TabIndex = 0
        '
        'SplitMiddleUpDown
        '
        Me.SplitMiddleUpDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddleUpDown.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitMiddleUpDown.IsSplitterFixed = True
        Me.SplitMiddleUpDown.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddleUpDown.Name = "SplitMiddleUpDown"
        Me.SplitMiddleUpDown.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMiddleUpDown.Panel1
        '
        Me.SplitMiddleUpDown.Panel1.Controls.Add(Me.SplitMiddleTop)
        '
        'SplitMiddleUpDown.Panel2
        '
        Me.SplitMiddleUpDown.Panel2.Controls.Add(Me.SplitMiddleBottom)
        Me.SplitMiddleUpDown.Size = New System.Drawing.Size(300, 523)
        Me.SplitMiddleUpDown.SplitterDistance = 206
        Me.SplitMiddleUpDown.TabIndex = 0
        '
        'SplitMiddleTop
        '
        Me.SplitMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddleTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitMiddleTop.IsSplitterFixed = True
        Me.SplitMiddleTop.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddleTop.Name = "SplitMiddleTop"
        Me.SplitMiddleTop.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMiddleTop.Panel1
        '
        Me.SplitMiddleTop.Panel1.Controls.Add(Me.ToolStripMiddleTop)
        '
        'SplitMiddleTop.Panel2
        '
        Me.SplitMiddleTop.Panel2.Controls.Add(Me.pbNextInit)
        Me.SplitMiddleTop.Panel2.Controls.Add(Me.pbBackRound)
        Me.SplitMiddleTop.Size = New System.Drawing.Size(300, 206)
        Me.SplitMiddleTop.SplitterDistance = 167
        Me.SplitMiddleTop.TabIndex = 0
        '
        'ToolStripMiddleTop
        '
        Me.ToolStripMiddleTop.BottomToolStripPanelVisible = False
        '
        'ToolStripMiddleTop.ContentPanel
        '
        Me.ToolStripMiddleTop.ContentPanel.Controls.Add(Me.TabControlStats)
        Me.ToolStripMiddleTop.ContentPanel.Size = New System.Drawing.Size(300, 137)
        Me.ToolStripMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripMiddleTop.LeftToolStripPanelVisible = False
        Me.ToolStripMiddleTop.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMiddleTop.Name = "ToolStripMiddleTop"
        Me.ToolStripMiddleTop.RightToolStripPanelVisible = False
        Me.ToolStripMiddleTop.Size = New System.Drawing.Size(300, 167)
        Me.ToolStripMiddleTop.TabIndex = 0
        Me.ToolStripMiddleTop.Text = "ToolStripContainer1"
        '
        'ToolStripMiddleTop.TopToolStripPanel
        '
        Me.ToolStripMiddleTop.TopToolStripPanel.Controls.Add(Me.ToolStripName)
        '
        'TabControlStats
        '
        Me.TabControlStats.Controls.Add(Me.tabInitiative)
        Me.TabControlStats.Controls.Add(Me.tabDamageHeal)
        Me.TabControlStats.Controls.Add(Me.tabFighterStats)
        Me.TabControlStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlStats.Location = New System.Drawing.Point(0, 0)
        Me.TabControlStats.Name = "TabControlStats"
        Me.TabControlStats.SelectedIndex = 0
        Me.TabControlStats.Size = New System.Drawing.Size(300, 137)
        Me.TabControlStats.TabIndex = 0
        '
        'tabInitiative
        '
        Me.tabInitiative.BackColor = System.Drawing.Color.Transparent
        Me.tabInitiative.Controls.Add(Me.dfStatInitRoll)
        Me.tabInitiative.Controls.Add(Me.pbDeleteFighter)
        Me.tabInitiative.Controls.Add(Me.pbReserve)
        Me.tabInitiative.Controls.Add(Me.Label2)
        Me.tabInitiative.Controls.Add(Me.pbDelay)
        Me.tabInitiative.Controls.Add(Me.pbMoveToTop)
        Me.tabInitiative.Controls.Add(Me.pbReady)
        Me.tabInitiative.Controls.Add(Me.pbRollInit)
        Me.tabInitiative.Location = New System.Drawing.Point(4, 22)
        Me.tabInitiative.Name = "tabInitiative"
        Me.tabInitiative.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInitiative.Size = New System.Drawing.Size(292, 111)
        Me.tabInitiative.TabIndex = 1
        Me.tabInitiative.Text = "Initiative"
        Me.tabInitiative.UseVisualStyleBackColor = True
        '
        'dfStatInitRoll
        '
        Me.dfStatInitRoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfStatInitRoll.Location = New System.Drawing.Point(227, 32)
        Me.dfStatInitRoll.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
        Me.dfStatInitRoll.Name = "dfStatInitRoll"
        Me.dfStatInitRoll.Size = New System.Drawing.Size(61, 35)
        Me.dfStatInitRoll.TabIndex = 6
        Me.dfStatInitRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dfStatInitRoll.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        '
        'pbDeleteFighter
        '
        Me.pbDeleteFighter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbDeleteFighter.Location = New System.Drawing.Point(6, 6)
        Me.pbDeleteFighter.Name = "pbDeleteFighter"
        Me.pbDeleteFighter.Size = New System.Drawing.Size(68, 37)
        Me.pbDeleteFighter.TabIndex = 0
        Me.pbDeleteFighter.Text = "Remove Fighter"
        Me.pbDeleteFighter.UseVisualStyleBackColor = True
        '
        'pbReserve
        '
        Me.pbReserve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbReserve.Location = New System.Drawing.Point(6, 49)
        Me.pbReserve.Name = "pbReserve"
        Me.pbReserve.Size = New System.Drawing.Size(68, 33)
        Me.pbReserve.TabIndex = 3
        Me.pbReserve.Text = "Reserve"
        Me.pbReserve.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Init Roll"
        '
        'pbDelay
        '
        Me.pbDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbDelay.Location = New System.Drawing.Point(80, 49)
        Me.pbDelay.Name = "pbDelay"
        Me.pbDelay.Size = New System.Drawing.Size(68, 33)
        Me.pbDelay.TabIndex = 4
        Me.pbDelay.Text = "Delay"
        Me.pbDelay.UseVisualStyleBackColor = True
        '
        'pbMoveToTop
        '
        Me.pbMoveToTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbMoveToTop.Location = New System.Drawing.Point(154, 6)
        Me.pbMoveToTop.Name = "pbMoveToTop"
        Me.pbMoveToTop.Size = New System.Drawing.Size(68, 37)
        Me.pbMoveToTop.TabIndex = 2
        Me.pbMoveToTop.Text = "Move To Top"
        Me.pbMoveToTop.UseVisualStyleBackColor = True
        '
        'pbReady
        '
        Me.pbReady.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbReady.Location = New System.Drawing.Point(154, 49)
        Me.pbReady.Name = "pbReady"
        Me.pbReady.Size = New System.Drawing.Size(68, 33)
        Me.pbReady.TabIndex = 5
        Me.pbReady.Text = "Ready"
        Me.pbReady.UseVisualStyleBackColor = True
        '
        'pbRollInit
        '
        Me.pbRollInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbRollInit.Location = New System.Drawing.Point(80, 6)
        Me.pbRollInit.Name = "pbRollInit"
        Me.pbRollInit.Size = New System.Drawing.Size(68, 37)
        Me.pbRollInit.TabIndex = 1
        Me.pbRollInit.Text = "Roll Initiative"
        Me.pbRollInit.UseVisualStyleBackColor = True
        '
        'tabDamageHeal
        '
        Me.tabDamageHeal.BackColor = System.Drawing.Color.Transparent
        Me.tabDamageHeal.Controls.Add(Me.GroupBox1)
        Me.tabDamageHeal.Controls.Add(Me.GroupBox2)
        Me.tabDamageHeal.Location = New System.Drawing.Point(4, 22)
        Me.tabDamageHeal.Name = "tabDamageHeal"
        Me.tabDamageHeal.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDamageHeal.Size = New System.Drawing.Size(292, 111)
        Me.tabDamageHeal.TabIndex = 0
        Me.tabDamageHeal.Text = "Damage/Healing"
        Me.tabDamageHeal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSubMax)
        Me.GroupBox1.Controls.Add(Me.btnAddMax)
        Me.GroupBox1.Controls.Add(Me.pbAllSurge)
        Me.GroupBox1.Controls.Add(Me.pbAddSurge)
        Me.GroupBox1.Controls.Add(Me.pbSubSurge)
        Me.GroupBox1.Controls.Add(Me.dfSurgesLeft)
        Me.GroupBox1.Location = New System.Drawing.Point(209, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(82, 110)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Surges"
        '
        'btnSubMax
        '
        Me.btnSubMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubMax.Location = New System.Drawing.Point(66, 35)
        Me.btnSubMax.Name = "btnSubMax"
        Me.btnSubMax.Size = New System.Drawing.Size(14, 19)
        Me.btnSubMax.TabIndex = 16
        Me.btnSubMax.Text = "-"
        Me.btnSubMax.UseVisualStyleBackColor = True
        '
        'btnAddMax
        '
        Me.btnAddMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMax.Location = New System.Drawing.Point(66, 13)
        Me.btnAddMax.Name = "btnAddMax"
        Me.btnAddMax.Size = New System.Drawing.Size(14, 19)
        Me.btnAddMax.TabIndex = 15
        Me.btnAddMax.Text = "+"
        Me.btnAddMax.UseVisualStyleBackColor = True
        '
        'pbAllSurge
        '
        Me.pbAllSurge.Enabled = False
        Me.pbAllSurge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAllSurge.Location = New System.Drawing.Point(3, 84)
        Me.pbAllSurge.Name = "pbAllSurge"
        Me.pbAllSurge.Size = New System.Drawing.Size(77, 23)
        Me.pbAllSurge.TabIndex = 14
        Me.pbAllSurge.Text = "AllSurge"
        Me.pbAllSurge.UseVisualStyleBackColor = True
        '
        'pbAddSurge
        '
        Me.pbAddSurge.Enabled = False
        Me.pbAddSurge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAddSurge.Location = New System.Drawing.Point(42, 59)
        Me.pbAddSurge.Name = "pbAddSurge"
        Me.pbAddSurge.Size = New System.Drawing.Size(38, 22)
        Me.pbAddSurge.TabIndex = 13
        Me.pbAddSurge.Text = "+1"
        Me.pbAddSurge.UseVisualStyleBackColor = True
        '
        'pbSubSurge
        '
        Me.pbSubSurge.Enabled = False
        Me.pbSubSurge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbSubSurge.Location = New System.Drawing.Point(3, 59)
        Me.pbSubSurge.Name = "pbSubSurge"
        Me.pbSubSurge.Size = New System.Drawing.Size(38, 22)
        Me.pbSubSurge.TabIndex = 12
        Me.pbSubSurge.Text = "-1"
        Me.pbSubSurge.UseVisualStyleBackColor = True
        '
        'dfSurgesLeft
        '
        Me.dfSurgesLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfSurgesLeft.Location = New System.Drawing.Point(6, 19)
        Me.dfSurgesLeft.Name = "dfSurgesLeft"
        Me.dfSurgesLeft.ReadOnly = True
        Me.dfSurgesLeft.Size = New System.Drawing.Size(57, 29)
        Me.dfSurgesLeft.TabIndex = 10
        Me.dfSurgesLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pbHPplus5)
        Me.GroupBox2.Controls.Add(Me.pbSurge)
        Me.GroupBox2.Controls.Add(Me.pbHP5)
        Me.GroupBox2.Controls.Add(Me.dfDamHealAmt)
        Me.GroupBox2.Controls.Add(Me.pbDealDamage)
        Me.GroupBox2.Controls.Add(Me.pbUnfailDeath)
        Me.GroupBox2.Controls.Add(Me.pbMaxHP)
        Me.GroupBox2.Controls.Add(Me.pbHealDamage)
        Me.GroupBox2.Controls.Add(Me.pbAddTemp)
        Me.GroupBox2.Controls.Add(Me.pbFailDeath)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 110)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Health"
        '
        'pbHPplus5
        '
        Me.pbHPplus5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbHPplus5.Location = New System.Drawing.Point(38, 59)
        Me.pbHPplus5.Name = "pbHPplus5"
        Me.pbHPplus5.Size = New System.Drawing.Size(34, 22)
        Me.pbHPplus5.TabIndex = 4
        Me.pbHPplus5.Text = "+5"
        Me.pbHPplus5.UseVisualStyleBackColor = True
        '
        'pbSurge
        '
        Me.pbSurge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbSurge.Location = New System.Drawing.Point(4, 84)
        Me.pbSurge.Name = "pbSurge"
        Me.pbSurge.Size = New System.Drawing.Size(68, 23)
        Me.pbSurge.TabIndex = 5
        Me.pbSurge.Text = "Surge"
        Me.pbSurge.UseVisualStyleBackColor = True
        '
        'pbHP5
        '
        Me.pbHP5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbHP5.Location = New System.Drawing.Point(4, 59)
        Me.pbHP5.Name = "pbHP5"
        Me.pbHP5.Size = New System.Drawing.Size(34, 22)
        Me.pbHP5.TabIndex = 3
        Me.pbHP5.Text = "5"
        Me.pbHP5.UseVisualStyleBackColor = True
        '
        'dfDamHealAmt
        '
        Me.dfDamHealAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfDamHealAmt.Location = New System.Drawing.Point(7, 19)
        Me.dfDamHealAmt.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.dfDamHealAmt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.dfDamHealAmt.Name = "dfDamHealAmt"
        Me.dfDamHealAmt.Size = New System.Drawing.Size(65, 35)
        Me.dfDamHealAmt.TabIndex = 0
        Me.dfDamHealAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dfDamHealAmt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pbDealDamage
        '
        Me.pbDealDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbDealDamage.Location = New System.Drawing.Point(78, 10)
        Me.pbDealDamage.Name = "pbDealDamage"
        Me.pbDealDamage.Size = New System.Drawing.Size(55, 47)
        Me.pbDealDamage.TabIndex = 1
        Me.pbDealDamage.Text = "Damage"
        Me.pbDealDamage.UseVisualStyleBackColor = True
        '
        'pbUnfailDeath
        '
        Me.pbUnfailDeath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbUnfailDeath.Location = New System.Drawing.Point(139, 84)
        Me.pbUnfailDeath.Name = "pbUnfailDeath"
        Me.pbUnfailDeath.Size = New System.Drawing.Size(65, 23)
        Me.pbUnfailDeath.TabIndex = 9
        Me.pbUnfailDeath.Text = "UnFail D"
        Me.pbUnfailDeath.UseVisualStyleBackColor = True
        '
        'pbMaxHP
        '
        Me.pbMaxHP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbMaxHP.Location = New System.Drawing.Point(139, 31)
        Me.pbMaxHP.Name = "pbMaxHP"
        Me.pbMaxHP.Size = New System.Drawing.Size(65, 23)
        Me.pbMaxHP.TabIndex = 6
        Me.pbMaxHP.Text = "Max"
        Me.pbMaxHP.UseVisualStyleBackColor = True
        '
        'pbHealDamage
        '
        Me.pbHealDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbHealDamage.Location = New System.Drawing.Point(78, 61)
        Me.pbHealDamage.Name = "pbHealDamage"
        Me.pbHealDamage.Size = New System.Drawing.Size(55, 46)
        Me.pbHealDamage.TabIndex = 2
        Me.pbHealDamage.Text = "Healing"
        Me.pbHealDamage.UseVisualStyleBackColor = True
        '
        'pbAddTemp
        '
        Me.pbAddTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAddTemp.Location = New System.Drawing.Point(139, 10)
        Me.pbAddTemp.Name = "pbAddTemp"
        Me.pbAddTemp.Size = New System.Drawing.Size(65, 22)
        Me.pbAddTemp.TabIndex = 7
        Me.pbAddTemp.Text = "Add Temp"
        Me.pbAddTemp.UseVisualStyleBackColor = True
        '
        'pbFailDeath
        '
        Me.pbFailDeath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbFailDeath.Location = New System.Drawing.Point(139, 61)
        Me.pbFailDeath.Name = "pbFailDeath"
        Me.pbFailDeath.Size = New System.Drawing.Size(65, 22)
        Me.pbFailDeath.TabIndex = 8
        Me.pbFailDeath.Text = "Fail Death"
        Me.pbFailDeath.UseVisualStyleBackColor = True
        '
        'tabFighterStats
        '
        Me.tabFighterStats.BackColor = System.Drawing.Color.Transparent
        Me.tabFighterStats.Controls.Add(Me.Label9)
        Me.tabFighterStats.Controls.Add(Me.dfStatCurrHP)
        Me.tabFighterStats.Controls.Add(Me.dfStatMaxHP)
        Me.tabFighterStats.Controls.Add(Me.Label10)
        Me.tabFighterStats.Controls.Add(Me.dfStatLevel)
        Me.tabFighterStats.Controls.Add(Me.Label8)
        Me.tabFighterStats.Controls.Add(Me.dfStatDefWill)
        Me.tabFighterStats.Controls.Add(Me.Label7)
        Me.tabFighterStats.Controls.Add(Me.dfStatDefReflex)
        Me.tabFighterStats.Controls.Add(Me.Label6)
        Me.tabFighterStats.Controls.Add(Me.dfStatDefFort)
        Me.tabFighterStats.Controls.Add(Me.Label5)
        Me.tabFighterStats.Controls.Add(Me.dfStatDefAC)
        Me.tabFighterStats.Controls.Add(Me.Label4)
        Me.tabFighterStats.Controls.Add(Me.dfRoleMod)
        Me.tabFighterStats.Controls.Add(Me.labRoleMod)
        Me.tabFighterStats.Controls.Add(Me.dfXPValue)
        Me.tabFighterStats.Controls.Add(Me.Label3)
        Me.tabFighterStats.Location = New System.Drawing.Point(4, 22)
        Me.tabFighterStats.Name = "tabFighterStats"
        Me.tabFighterStats.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFighterStats.Size = New System.Drawing.Size(292, 111)
        Me.tabFighterStats.TabIndex = 2
        Me.tabFighterStats.Text = "Stats"
        Me.tabFighterStats.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Curr HP"
        '
        'dfStatCurrHP
        '
        Me.dfStatCurrHP.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatCurrHP.Enabled = False
        Me.dfStatCurrHP.Location = New System.Drawing.Point(7, 24)
        Me.dfStatCurrHP.Name = "dfStatCurrHP"
        Me.dfStatCurrHP.ReadOnly = True
        Me.dfStatCurrHP.Size = New System.Drawing.Size(52, 20)
        Me.dfStatCurrHP.TabIndex = 23
        Me.dfStatCurrHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dfStatMaxHP
        '
        Me.dfStatMaxHP.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatMaxHP.Enabled = False
        Me.dfStatMaxHP.Location = New System.Drawing.Point(65, 24)
        Me.dfStatMaxHP.Name = "dfStatMaxHP"
        Me.dfStatMaxHP.ReadOnly = True
        Me.dfStatMaxHP.Size = New System.Drawing.Size(52, 20)
        Me.dfStatMaxHP.TabIndex = 22
        Me.dfStatMaxHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(68, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Max HP"
        '
        'dfStatLevel
        '
        Me.dfStatLevel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatLevel.Enabled = False
        Me.dfStatLevel.Location = New System.Drawing.Point(44, 50)
        Me.dfStatLevel.Name = "dfStatLevel"
        Me.dfStatLevel.ReadOnly = True
        Me.dfStatLevel.Size = New System.Drawing.Size(37, 20)
        Me.dfStatLevel.TabIndex = 18
        Me.dfStatLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Level"
        '
        'dfStatDefWill
        '
        Me.dfStatDefWill.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatDefWill.Enabled = False
        Me.dfStatDefWill.Location = New System.Drawing.Point(252, 24)
        Me.dfStatDefWill.Name = "dfStatDefWill"
        Me.dfStatDefWill.ReadOnly = True
        Me.dfStatDefWill.Size = New System.Drawing.Size(37, 20)
        Me.dfStatDefWill.TabIndex = 16
        Me.dfStatDefWill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(258, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Will"
        '
        'dfStatDefReflex
        '
        Me.dfStatDefReflex.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatDefReflex.Enabled = False
        Me.dfStatDefReflex.Location = New System.Drawing.Point(209, 24)
        Me.dfStatDefReflex.Name = "dfStatDefReflex"
        Me.dfStatDefReflex.ReadOnly = True
        Me.dfStatDefReflex.Size = New System.Drawing.Size(37, 20)
        Me.dfStatDefReflex.TabIndex = 14
        Me.dfStatDefReflex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(209, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Reflex"
        '
        'dfStatDefFort
        '
        Me.dfStatDefFort.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatDefFort.Enabled = False
        Me.dfStatDefFort.Location = New System.Drawing.Point(166, 24)
        Me.dfStatDefFort.Name = "dfStatDefFort"
        Me.dfStatDefFort.ReadOnly = True
        Me.dfStatDefFort.Size = New System.Drawing.Size(37, 20)
        Me.dfStatDefFort.TabIndex = 12
        Me.dfStatDefFort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(173, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fort"
        '
        'dfStatDefAC
        '
        Me.dfStatDefAC.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfStatDefAC.Enabled = False
        Me.dfStatDefAC.Location = New System.Drawing.Point(123, 24)
        Me.dfStatDefAC.Name = "dfStatDefAC"
        Me.dfStatDefAC.ReadOnly = True
        Me.dfStatDefAC.Size = New System.Drawing.Size(37, 20)
        Me.dfStatDefAC.TabIndex = 10
        Me.dfStatDefAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(132, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "AC"
        '
        'dfRoleMod
        '
        Me.dfRoleMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dfRoleMod.Items.AddRange(New Object() {"Normal", "Demi", "Semi", "Minion", "PC"})
        Me.dfRoleMod.Location = New System.Drawing.Point(216, 50)
        Me.dfRoleMod.Name = "dfRoleMod"
        Me.dfRoleMod.Size = New System.Drawing.Size(73, 21)
        Me.dfRoleMod.TabIndex = 8
        '
        'labRoleMod
        '
        Me.labRoleMod.AutoSize = True
        Me.labRoleMod.Location = New System.Drawing.Point(182, 53)
        Me.labRoleMod.Name = "labRoleMod"
        Me.labRoleMod.Size = New System.Drawing.Size(28, 13)
        Me.labRoleMod.TabIndex = 7
        Me.labRoleMod.Text = "Mod"
        '
        'dfXPValue
        '
        Me.dfXPValue.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dfXPValue.Enabled = False
        Me.dfXPValue.Location = New System.Drawing.Point(114, 50)
        Me.dfXPValue.Name = "dfXPValue"
        Me.dfXPValue.ReadOnly = True
        Me.dfXPValue.Size = New System.Drawing.Size(62, 20)
        Me.dfXPValue.TabIndex = 6
        Me.dfXPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "XP"
        '
        'ToolStripName
        '
        Me.ToolStripName.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripName.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripName.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.dfStatName, Me.dfFighterNum})
        Me.ToolStripName.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripName.Name = "ToolStripName"
        Me.ToolStripName.Padding = New System.Windows.Forms.Padding(0, 0, 1, 4)
        Me.ToolStripName.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripName.Size = New System.Drawing.Size(300, 30)
        Me.ToolStripName.Stretch = True
        Me.ToolStripName.TabIndex = 0
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(39, 23)
        Me.ToolStripLabel1.Text = "Name"
        '
        'dfStatName
        '
        Me.dfStatName.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfStatName.Name = "dfStatName"
        Me.dfStatName.Size = New System.Drawing.Size(230, 26)
        '
        'dfFighterNum
        '
        Me.dfFighterNum.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.dfFighterNum.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfFighterNum.Name = "dfFighterNum"
        Me.dfFighterNum.ReadOnly = True
        Me.dfFighterNum.Size = New System.Drawing.Size(25, 26)
        Me.dfFighterNum.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbNextInit
        '
        Me.pbNextInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbNextInit.Location = New System.Drawing.Point(0, 2)
        Me.pbNextInit.Name = "pbNextInit"
        Me.pbNextInit.Size = New System.Drawing.Size(232, 30)
        Me.pbNextInit.TabIndex = 0
        Me.pbNextInit.Text = "Next Turn"
        Me.pbNextInit.UseVisualStyleBackColor = True
        '
        'pbBackRound
        '
        Me.pbBackRound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbBackRound.Location = New System.Drawing.Point(235, 2)
        Me.pbBackRound.Name = "pbBackRound"
        Me.pbBackRound.Size = New System.Drawing.Size(61, 30)
        Me.pbBackRound.TabIndex = 3
        Me.pbBackRound.Text = "Back Up"
        Me.pbBackRound.UseVisualStyleBackColor = True
        '
        'SplitMiddleBottom
        '
        Me.SplitMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddleBottom.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddleBottom.Name = "SplitMiddleBottom"
        Me.SplitMiddleBottom.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMiddleBottom.Panel1
        '
        Me.SplitMiddleBottom.Panel1.Controls.Add(Me.ToolStripContainerEffects)
        '
        'SplitMiddleBottom.Panel2
        '
        Me.SplitMiddleBottom.Panel2.Controls.Add(Me.TabMiddleBottom)
        Me.SplitMiddleBottom.Size = New System.Drawing.Size(300, 313)
        Me.SplitMiddleBottom.SplitterDistance = 89
        Me.SplitMiddleBottom.SplitterWidth = 8
        Me.SplitMiddleBottom.TabIndex = 0
        '
        'ToolStripContainerEffects
        '
        '
        'ToolStripContainerEffects.BottomToolStripPanel
        '
        Me.ToolStripContainerEffects.BottomToolStripPanel.Controls.Add(Me.ToolStripEffects)
        '
        'ToolStripContainerEffects.ContentPanel
        '
        Me.ToolStripContainerEffects.ContentPanel.Controls.Add(Me.lbEffects)
        Me.ToolStripContainerEffects.ContentPanel.Size = New System.Drawing.Size(300, 64)
        Me.ToolStripContainerEffects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainerEffects.LeftToolStripPanelVisible = False
        Me.ToolStripContainerEffects.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainerEffects.Name = "ToolStripContainerEffects"
        Me.ToolStripContainerEffects.RightToolStripPanelVisible = False
        Me.ToolStripContainerEffects.Size = New System.Drawing.Size(300, 89)
        Me.ToolStripContainerEffects.TabIndex = 0
        Me.ToolStripContainerEffects.Text = "ToolStripContainer1"
        '
        'ToolStripContainerEffects.TopToolStripPanel
        '
        Me.ToolStripContainerEffects.TopToolStripPanel.Padding = New System.Windows.Forms.Padding(0, 0, 25, 25)
        Me.ToolStripContainerEffects.TopToolStripPanelVisible = False
        '
        'ToolStripEffects
        '
        Me.ToolStripEffects.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEffects.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEffects.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.ToolStripSeparator16, Me.pbEffectAdd, Me.ToolStripSeparator11, Me.pbEffectChange, Me.ToolStripSeparator12, Me.pbEffectRemove, Me.ToolStripSeparator13})
        Me.ToolStripEffects.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripEffects.Name = "ToolStripEffects"
        Me.ToolStripEffects.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripEffects.Size = New System.Drawing.Size(300, 25)
        Me.ToolStripEffects.Stretch = True
        Me.ToolStripEffects.TabIndex = 0
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripLabel5.Text = "Effects:     "
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'pbEffectAdd
        '
        Me.pbEffectAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbEffectAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbEffectAdd.Image = CType(resources.GetObject("pbEffectAdd.Image"), System.Drawing.Image)
        Me.pbEffectAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbEffectAdd.Name = "pbEffectAdd"
        Me.pbEffectAdd.Size = New System.Drawing.Size(33, 22)
        Me.pbEffectAdd.Text = "Add"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'pbEffectChange
        '
        Me.pbEffectChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbEffectChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbEffectChange.Image = CType(resources.GetObject("pbEffectChange.Image"), System.Drawing.Image)
        Me.pbEffectChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbEffectChange.Name = "pbEffectChange"
        Me.pbEffectChange.Size = New System.Drawing.Size(54, 22)
        Me.pbEffectChange.Text = "Change"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'pbEffectRemove
        '
        Me.pbEffectRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbEffectRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbEffectRemove.Image = CType(resources.GetObject("pbEffectRemove.Image"), System.Drawing.Image)
        Me.pbEffectRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbEffectRemove.Name = "pbEffectRemove"
        Me.pbEffectRemove.Size = New System.Drawing.Size(57, 22)
        Me.pbEffectRemove.Text = "Remove"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'lbEffects
        '
        Me.lbEffects.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEffectName, Me.colSource, Me.colEffectDuration})
        Me.lbEffects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbEffects.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEffects.FullRowSelect = True
        Me.lbEffects.Location = New System.Drawing.Point(0, 0)
        Me.lbEffects.MultiSelect = False
        Me.lbEffects.Name = "lbEffects"
        Me.lbEffects.Size = New System.Drawing.Size(300, 64)
        Me.lbEffects.TabIndex = 0
        Me.lbEffects.TileSize = New System.Drawing.Size(270, 50)
        Me.lbEffects.UseCompatibleStateImageBehavior = False
        Me.lbEffects.View = System.Windows.Forms.View.Tile
        '
        'colEffectName
        '
        Me.colEffectName.Text = "Effect Name"
        Me.colEffectName.Width = 200
        '
        'colSource
        '
        Me.colSource.Text = "Source"
        '
        'colEffectDuration
        '
        Me.colEffectDuration.Text = "Effect Duration"
        '
        'TabMiddleBottom
        '
        Me.TabMiddleBottom.Controls.Add(Me.tabPowers)
        Me.TabMiddleBottom.Controls.Add(Me.tabNotes)
        Me.TabMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMiddleBottom.Location = New System.Drawing.Point(0, 0)
        Me.TabMiddleBottom.Name = "TabMiddleBottom"
        Me.TabMiddleBottom.SelectedIndex = 0
        Me.TabMiddleBottom.Size = New System.Drawing.Size(300, 216)
        Me.TabMiddleBottom.TabIndex = 0
        '
        'tabPowers
        '
        Me.tabPowers.Controls.Add(Me.ToolContainerPowerUsage)
        Me.tabPowers.Location = New System.Drawing.Point(4, 22)
        Me.tabPowers.Name = "tabPowers"
        Me.tabPowers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPowers.Size = New System.Drawing.Size(292, 190)
        Me.tabPowers.TabIndex = 1
        Me.tabPowers.Text = "Powers"
        Me.tabPowers.UseVisualStyleBackColor = True
        '
        'ToolContainerPowerUsage
        '
        '
        'ToolContainerPowerUsage.BottomToolStripPanel
        '
        Me.ToolContainerPowerUsage.BottomToolStripPanel.Controls.Add(Me.ToolStripPowerUsage)
        '
        'ToolContainerPowerUsage.ContentPanel
        '
        Me.ToolContainerPowerUsage.ContentPanel.Controls.Add(Me.lbPowerUsage)
        Me.ToolContainerPowerUsage.ContentPanel.Size = New System.Drawing.Size(286, 159)
        Me.ToolContainerPowerUsage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolContainerPowerUsage.LeftToolStripPanelVisible = False
        Me.ToolContainerPowerUsage.Location = New System.Drawing.Point(3, 3)
        Me.ToolContainerPowerUsage.Name = "ToolContainerPowerUsage"
        Me.ToolContainerPowerUsage.RightToolStripPanelVisible = False
        Me.ToolContainerPowerUsage.Size = New System.Drawing.Size(286, 184)
        Me.ToolContainerPowerUsage.TabIndex = 0
        Me.ToolContainerPowerUsage.Text = "ToolStripContainer1"
        '
        'ToolContainerPowerUsage.TopToolStripPanel
        '
        Me.ToolContainerPowerUsage.TopToolStripPanel.Padding = New System.Windows.Forms.Padding(0, 0, 25, 25)
        Me.ToolContainerPowerUsage.TopToolStripPanelVisible = False
        '
        'ToolStripPowerUsage
        '
        Me.ToolStripPowerUsage.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripPowerUsage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripPowerUsage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbPowerExpended, Me.pbPowerRefresh, Me.ToolStripSeparator15, Me.ToolStripSeparator14})
        Me.ToolStripPowerUsage.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPowerUsage.Name = "ToolStripPowerUsage"
        Me.ToolStripPowerUsage.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripPowerUsage.Size = New System.Drawing.Size(286, 25)
        Me.ToolStripPowerUsage.Stretch = True
        Me.ToolStripPowerUsage.TabIndex = 0
        '
        'pbPowerExpended
        '
        Me.pbPowerExpended.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbPowerExpended.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbPowerExpended.Image = CType(resources.GetObject("pbPowerExpended.Image"), System.Drawing.Image)
        Me.pbPowerExpended.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbPowerExpended.Name = "pbPowerExpended"
        Me.pbPowerExpended.Size = New System.Drawing.Size(81, 22)
        Me.pbPowerExpended.Text = "Use/Disable"
        '
        'pbPowerRefresh
        '
        Me.pbPowerRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pbPowerRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbPowerRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbPowerRefresh.Image = CType(resources.GetObject("pbPowerRefresh.Image"), System.Drawing.Image)
        Me.pbPowerRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbPowerRefresh.Name = "pbPowerRefresh"
        Me.pbPowerRefresh.Size = New System.Drawing.Size(111, 22)
        Me.pbPowerRefresh.Text = "Recharge/Enable"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'lbPowerUsage
        '
        Me.lbPowerUsage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPowerName, Me.colPowerAction})
        Me.lbPowerUsage.ContextMenuStrip = Me.CctxtmenuPowerList
        Me.lbPowerUsage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPowerUsage.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPowerUsage.FullRowSelect = True
        Me.lbPowerUsage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lbPowerUsage.HideSelection = False
        Me.lbPowerUsage.Location = New System.Drawing.Point(0, 0)
        Me.lbPowerUsage.Name = "lbPowerUsage"
        Me.lbPowerUsage.Size = New System.Drawing.Size(286, 159)
        Me.lbPowerUsage.TabIndex = 0
        Me.lbPowerUsage.TileSize = New System.Drawing.Size(256, 18)
        Me.lbPowerUsage.UseCompatibleStateImageBehavior = False
        Me.lbPowerUsage.View = System.Windows.Forms.View.Tile
        '
        'colPowerName
        '
        Me.colPowerName.Text = "Name"
        Me.colPowerName.Width = 200
        '
        'colPowerAction
        '
        Me.colPowerAction.Text = "Action"
        '
        'CctxtmenuPowerList
        '
        Me.CctxtmenuPowerList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseDisableToolStripMenuItem, Me.RechargeEnableToolStripMenuItem, Me.ViewCompendiumEntryToolStripMenuItem, Me.SetAsActiveStance})
        Me.CctxtmenuPowerList.Name = "ContextMenuStrip1"
        Me.CctxtmenuPowerList.Size = New System.Drawing.Size(207, 92)
        '
        'UseDisableToolStripMenuItem
        '
        Me.UseDisableToolStripMenuItem.Name = "UseDisableToolStripMenuItem"
        Me.UseDisableToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.UseDisableToolStripMenuItem.Text = "Use/Disable"
        '
        'RechargeEnableToolStripMenuItem
        '
        Me.RechargeEnableToolStripMenuItem.Name = "RechargeEnableToolStripMenuItem"
        Me.RechargeEnableToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.RechargeEnableToolStripMenuItem.Text = "Recharge/Enable"
        '
        'ViewCompendiumEntryToolStripMenuItem
        '
        Me.ViewCompendiumEntryToolStripMenuItem.Name = "ViewCompendiumEntryToolStripMenuItem"
        Me.ViewCompendiumEntryToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ViewCompendiumEntryToolStripMenuItem.Text = "View Compendium Entry"
        '
        'SetAsActiveStance
        '
        Me.SetAsActiveStance.Name = "SetAsActiveStance"
        Me.SetAsActiveStance.Size = New System.Drawing.Size(206, 22)
        Me.SetAsActiveStance.Text = "Set As Active Stance"
        '
        'tabNotes
        '
        Me.tabNotes.Controls.Add(Me.GroupBox4)
        Me.tabNotes.Location = New System.Drawing.Point(4, 22)
        Me.tabNotes.Name = "tabNotes"
        Me.tabNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNotes.Size = New System.Drawing.Size(292, 190)
        Me.tabNotes.TabIndex = 0
        Me.tabNotes.Text = "Notes"
        Me.tabNotes.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dfFighterNotes)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(286, 184)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Individual Notes"
        '
        'dfFighterNotes
        '
        Me.dfFighterNotes.AcceptsReturn = True
        Me.dfFighterNotes.AcceptsTab = True
        Me.dfFighterNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dfFighterNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dfFighterNotes.Location = New System.Drawing.Point(3, 16)
        Me.dfFighterNotes.Multiline = True
        Me.dfFighterNotes.Name = "dfFighterNotes"
        Me.dfFighterNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dfFighterNotes.Size = New System.Drawing.Size(280, 165)
        Me.dfFighterNotes.TabIndex = 0
        '
        'RightPanelSplit
        '
        Me.RightPanelSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RightPanelSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightPanelSplit.Location = New System.Drawing.Point(0, 0)
        Me.RightPanelSplit.Name = "RightPanelSplit"
        Me.RightPanelSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'RightPanelSplit.Panel1
        '
        Me.RightPanelSplit.Panel1.Controls.Add(Me.dfHTMLStatBlock)
        '
        'RightPanelSplit.Panel2
        '
        Me.RightPanelSplit.Panel2.Controls.Add(Me.dfPowerBlockHTML)
        Me.RightPanelSplit.Size = New System.Drawing.Size(308, 523)
        Me.RightPanelSplit.SplitterDistance = 318
        Me.RightPanelSplit.TabIndex = 3
        '
        'dfHTMLStatBlock
        '
        Me.dfHTMLStatBlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dfHTMLStatBlock.Location = New System.Drawing.Point(0, 0)
        Me.dfHTMLStatBlock.MinimumSize = New System.Drawing.Size(20, 20)
        Me.dfHTMLStatBlock.Name = "dfHTMLStatBlock"
        Me.dfHTMLStatBlock.ScriptErrorsSuppressed = True
        Me.dfHTMLStatBlock.Size = New System.Drawing.Size(304, 314)
        Me.dfHTMLStatBlock.TabIndex = 1
        '
        'dfPowerBlockHTML
        '
        Me.dfPowerBlockHTML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dfPowerBlockHTML.Location = New System.Drawing.Point(0, 0)
        Me.dfPowerBlockHTML.MinimumSize = New System.Drawing.Size(20, 20)
        Me.dfPowerBlockHTML.Name = "dfPowerBlockHTML"
        Me.dfPowerBlockHTML.Size = New System.Drawing.Size(304, 197)
        Me.dfPowerBlockHTML.TabIndex = 2
        '
        'pbDoNothing
        '
        Me.pbDoNothing.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.pbDoNothing.Location = New System.Drawing.Point(3, 3)
        Me.pbDoNothing.Name = "pbDoNothing"
        Me.pbDoNothing.Size = New System.Drawing.Size(54, 41)
        Me.pbDoNothing.TabIndex = 0
        Me.pbDoNothing.Text = "Do Nothing"
        Me.pbDoNothing.UseVisualStyleBackColor = True
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 150)
        '
        'frmTracker
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.pbDoNothing
        Me.ClientSize = New System.Drawing.Size(892, 547)
        Me.Controls.Add(Me.SplitLeft)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 576)
        Me.Name = "frmTracker"
        Me.Text = "D&D 4e Combat Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitLeft.Panel1.ResumeLayout(False)
        Me.SplitLeft.Panel2.ResumeLayout(False)
        Me.SplitLeft.ResumeLayout(False)
        Me.SplitLeftUpDown.Panel1.ResumeLayout(False)
        Me.SplitLeftUpDown.Panel2.ResumeLayout(False)
        Me.SplitLeftUpDown.ResumeLayout(False)
        Me.ToolStripListbox.ContentPanel.ResumeLayout(False)
        Me.ToolStripListbox.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripListbox.TopToolStripPanel.PerformLayout()
        Me.ToolStripListbox.ResumeLayout(False)
        Me.ToolStripListbox.PerformLayout()
        Me.ctxtmenuInitList.ResumeLayout(False)
        Me.ctxtmenuInitList.PerformLayout()
        Me.ToolStripEncXP.ResumeLayout(False)
        Me.ToolStripEncXP.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.SplitMiddleRight.Panel1.ResumeLayout(False)
        Me.SplitMiddleRight.Panel2.ResumeLayout(False)
        Me.SplitMiddleRight.ResumeLayout(False)
        Me.SplitMiddleUpDown.Panel1.ResumeLayout(False)
        Me.SplitMiddleUpDown.Panel2.ResumeLayout(False)
        Me.SplitMiddleUpDown.ResumeLayout(False)
        Me.SplitMiddleTop.Panel1.ResumeLayout(False)
        Me.SplitMiddleTop.Panel2.ResumeLayout(False)
        Me.SplitMiddleTop.ResumeLayout(False)
        Me.ToolStripMiddleTop.ContentPanel.ResumeLayout(False)
        Me.ToolStripMiddleTop.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripMiddleTop.TopToolStripPanel.PerformLayout()
        Me.ToolStripMiddleTop.ResumeLayout(False)
        Me.ToolStripMiddleTop.PerformLayout()
        Me.TabControlStats.ResumeLayout(False)
        Me.tabInitiative.ResumeLayout(False)
        Me.tabInitiative.PerformLayout()
        CType(Me.dfStatInitRoll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDamageHeal.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dfDamHealAmt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFighterStats.ResumeLayout(False)
        Me.tabFighterStats.PerformLayout()
        Me.ToolStripName.ResumeLayout(False)
        Me.ToolStripName.PerformLayout()
        Me.SplitMiddleBottom.Panel1.ResumeLayout(False)
        Me.SplitMiddleBottom.Panel2.ResumeLayout(False)
        Me.SplitMiddleBottom.ResumeLayout(False)
        Me.ToolStripContainerEffects.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainerEffects.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainerEffects.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainerEffects.ResumeLayout(False)
        Me.ToolStripContainerEffects.PerformLayout()
        Me.ToolStripEffects.ResumeLayout(False)
        Me.ToolStripEffects.PerformLayout()
        Me.TabMiddleBottom.ResumeLayout(False)
        Me.tabPowers.ResumeLayout(False)
        Me.ToolContainerPowerUsage.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolContainerPowerUsage.BottomToolStripPanel.PerformLayout()
        Me.ToolContainerPowerUsage.ContentPanel.ResumeLayout(False)
        Me.ToolContainerPowerUsage.ResumeLayout(False)
        Me.ToolContainerPowerUsage.PerformLayout()
        Me.ToolStripPowerUsage.ResumeLayout(False)
        Me.ToolStripPowerUsage.PerformLayout()
        Me.CctxtmenuPowerList.ResumeLayout(False)
        Me.tabNotes.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.RightPanelSplit.Panel1.ResumeLayout(False)
        Me.RightPanelSplit.Panel2.ResumeLayout(False)
        Me.RightPanelSplit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SplitLeft As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripListbox As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lbFightList As System.Windows.Forms.ListView
    Friend WithEvents SplitMiddleRight As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitMiddleUpDown As System.Windows.Forms.SplitContainer
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuLoadEncounterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSaveEncounterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatLibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbMoveToTop As System.Windows.Forms.Button
    Friend WithEvents pbReserve As System.Windows.Forms.Button
    Friend WithEvents pbDelay As System.Windows.Forms.Button
    Friend WithEvents pbReady As System.Windows.Forms.Button
    Friend WithEvents pbBackRound As System.Windows.Forms.Button
    Friend WithEvents pbRollInit As System.Windows.Forms.Button
    Friend WithEvents dfFighterNotes As System.Windows.Forms.TextBox
    Friend WithEvents pbNextInit As System.Windows.Forms.Button
    Friend WithEvents pbDealDamage As System.Windows.Forms.Button
    Friend WithEvents pbFailDeath As System.Windows.Forms.Button
    Friend WithEvents pbAddTemp As System.Windows.Forms.Button
    Friend WithEvents pbUnfailDeath As System.Windows.Forms.Button
    Friend WithEvents pbHealDamage As System.Windows.Forms.Button
    Friend WithEvents ToolStripEncXP As System.Windows.Forms.ToolStrip
    Friend WithEvents toolTotalXP As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfXPTotal As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dfEncounterLevel As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents toolEncLevel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolPCCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfPartySize As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dfXPValue As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dfRoleMod As System.Windows.Forms.ComboBox
    Friend WithEvents labRoleMod As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colRound As System.Windows.Forms.ColumnHeader
    Friend WithEvents menuImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dfGlobalNotes As System.Windows.Forms.TextBox
    Friend WithEvents TabControlStats As System.Windows.Forms.TabControl
    Friend WithEvents tabDamageHeal As System.Windows.Forms.TabPage
    Friend WithEvents tabInitiative As System.Windows.Forms.TabPage
    Friend WithEvents tabFighterStats As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripMiddleTop As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripName As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfStatName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dfFighterNum As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitMiddleTop As System.Windows.Forms.SplitContainer
    Friend WithEvents dfStatDefAC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dfStatLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dfStatDefWill As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dfStatDefReflex As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dfStatDefFort As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dfStatCurrHP As System.Windows.Forms.TextBox
    Friend WithEvents dfStatMaxHP As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pbDoNothing As System.Windows.Forms.Button
    Friend WithEvents SplitLeftUpDown As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitMiddleBottom As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripContainerEffects As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripEffects As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents pbEffectAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbEffectChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbEffectRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbEffects As System.Windows.Forms.ListView
    Friend WithEvents colEffectName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEffectDuration As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabMiddleBottom As System.Windows.Forms.TabControl
    Friend WithEvents tabPowers As System.Windows.Forms.TabPage
    Friend WithEvents ToolContainerPowerUsage As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripPowerUsage As System.Windows.Forms.ToolStrip
    Friend WithEvents pbPowerExpended As System.Windows.Forms.ToolStripButton
    Friend WithEvents pbPowerRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbPowerUsage As System.Windows.Forms.ListView
    Friend WithEvents colPowerName As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabNotes As System.Windows.Forms.TabPage
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents colPowerAction As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colSource As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbSurge As System.Windows.Forms.Button
    Friend WithEvents pbHP5 As System.Windows.Forms.Button
    Friend WithEvents pbHPplus5 As System.Windows.Forms.Button
    Friend WithEvents pbMaxHP As System.Windows.Forms.Button
    Friend WithEvents dfDamHealAmt As System.Windows.Forms.NumericUpDown
    Friend WithEvents pbDeleteFighter As System.Windows.Forms.Button
    Friend WithEvents dfStatInitRoll As System.Windows.Forms.NumericUpDown
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menucbGroupSimilar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAutomaticRollsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRollSavesAutomaticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRollForPowerRechargeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RosterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncounterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRollAllInit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuResetAllInit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuStatLibraryOpenMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuTakeShortRestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuTakeExtendedRestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuResetPCHealthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSelectCurrentCombatantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuClearNPCsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuClearPCsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtmenuInitList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxtMoveToTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtDelayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtReadyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuPopupForOngoingDamageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CctxtmenuPowerList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UseDisableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechargeEnableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCompendiumEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyInitiativeListToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuTakeShortRestWMilestoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxtRemoveFighterFromCombatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtMarkedEncounterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtMarkedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dfSurgesLeft As System.Windows.Forms.TextBox
    Friend WithEvents pbSubSurge As System.Windows.Forms.Button
    Friend WithEvents pbAllSurge As System.Windows.Forms.Button
    Friend WithEvents pbAddSurge As System.Windows.Forms.Button
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutDnD4eCMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dfPowerBlockHTML As System.Windows.Forms.WebBrowser
    Friend WithEvents dfHTMLStatBlock As System.Windows.Forms.WebBrowser
    Friend WithEvents RightPanelSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents colDef As System.Windows.Forms.ColumnHeader
    Friend WithEvents menuSurpriseRound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAutoCompendium As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAsActiveStance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuStartWebServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuStopWebServer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtDisplayName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxtHideCombatant As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddMax As System.Windows.Forms.Button
    Friend WithEvents btnSubMax As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CopyInitiativeListToClipboardHTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
