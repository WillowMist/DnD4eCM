<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatLibraryView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatLibraryView))
        Me.SplitLeft = New System.Windows.Forms.SplitContainer
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.dfFilterName = New System.Windows.Forms.ToolStripTextBox
        Me.pbClearMenuFilter = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.dfFilterLevelLow = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.dfFilterLevelHigh = New System.Windows.Forms.ToolStripTextBox
        Me.dfFilterRole = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel
        Me.lbStatList = New System.Windows.Forms.ListBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.pbNewStat = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pbCBLoad = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.pbCopyStat = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.pbChangeStat = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.pbDeleteStat = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.pbPaste = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.SplitMiddleRight = New System.Windows.Forms.SplitContainer
        Me.dfStatBlockHTML = New System.Windows.Forms.WebBrowser
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.dfXP_Total = New System.Windows.Forms.ToolStripTextBox
        Me.dfXPLevelFor6 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.dfXPLevelFor5 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.dfXPLevelFor4 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.lbAddToBattle = New System.Windows.Forms.ListBox
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.pbAddToBattle = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.pbAddListRemove = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.SplitLeft.Panel1.SuspendLayout()
        Me.SplitLeft.Panel2.SuspendLayout()
        Me.SplitLeft.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SplitMiddleRight.Panel1.SuspendLayout()
        Me.SplitMiddleRight.Panel2.SuspendLayout()
        Me.SplitMiddleRight.SuspendLayout()
        Me.ToolStripContainer2.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitLeft
        '
        Me.SplitLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitLeft.IsSplitterFixed = True
        Me.SplitLeft.Location = New System.Drawing.Point(0, 0)
        Me.SplitLeft.Name = "SplitLeft"
        '
        'SplitLeft.Panel1
        '
        Me.SplitLeft.Panel1.Controls.Add(Me.ToolStripContainer1)
        Me.SplitLeft.Panel1MinSize = 330
        '
        'SplitLeft.Panel2
        '
        Me.SplitLeft.Panel2.Controls.Add(Me.SplitMiddleRight)
        Me.SplitLeft.Size = New System.Drawing.Size(992, 547)
        Me.SplitLeft.SplitterDistance = 330
        Me.SplitLeft.TabIndex = 0
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip5)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lbStatList)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(330, 472)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(330, 547)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.dfFilterName, Me.pbClearMenuFilter})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "X"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "Name:"
        '
        'dfFilterName
        '
        Me.dfFilterName.Name = "dfFilterName"
        Me.dfFilterName.Size = New System.Drawing.Size(180, 25)
        Me.dfFilterName.ToolTipText = "Filter List by Name"
        '
        'pbClearMenuFilter
        '
        Me.pbClearMenuFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pbClearMenuFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbClearMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbClearMenuFilter.Name = "pbClearMenuFilter"
        Me.pbClearMenuFilter.Size = New System.Drawing.Size(36, 22)
        Me.pbClearMenuFilter.Text = "Clear"
        Me.pbClearMenuFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.pbClearMenuFilter.ToolTipText = "Clear Filter"
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.dfFilterLevelLow, Me.ToolStripLabel5, Me.dfFilterLevelHigh, Me.dfFilterRole, Me.ToolStripLabel7})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip5.Stretch = True
        Me.ToolStrip5.TabIndex = 1
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripLabel2.Text = "Levels:"
        '
        'dfFilterLevelLow
        '
        Me.dfFilterLevelLow.Name = "dfFilterLevelLow"
        Me.dfFilterLevelLow.Size = New System.Drawing.Size(30, 25)
        Me.dfFilterLevelLow.Text = "1"
        Me.dfFilterLevelLow.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dfFilterLevelLow.ToolTipText = "Filter List by Level"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(17, 22)
        Me.ToolStripLabel5.Text = "to"
        '
        'dfFilterLevelHigh
        '
        Me.dfFilterLevelHigh.Name = "dfFilterLevelHigh"
        Me.dfFilterLevelHigh.Size = New System.Drawing.Size(30, 25)
        Me.dfFilterLevelHigh.Text = "40"
        Me.dfFilterLevelHigh.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dfFilterLevelHigh.ToolTipText = "Filter List by Level"
        '
        'dfFilterRole
        '
        Me.dfFilterRole.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.dfFilterRole.Items.AddRange(New Object() {"", "Artillery", "Blaster", "Brute", "Controller", "Hero", "Lurker", "Minion", "Obstacle", "Puzzle", "Skirmisher", "Soldier", "Warder"})
        Me.dfFilterRole.Name = "dfFilterRole"
        Me.dfFilterRole.Size = New System.Drawing.Size(80, 25)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel7.Text = "Role:"
        '
        'lbStatList
        '
        Me.lbStatList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbStatList.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatList.FormattingEnabled = True
        Me.lbStatList.ItemHeight = 20
        Me.lbStatList.Location = New System.Drawing.Point(0, 0)
        Me.lbStatList.Name = "lbStatList"
        Me.lbStatList.ScrollAlwaysVisible = True
        Me.lbStatList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbStatList.Size = New System.Drawing.Size(330, 464)
        Me.lbStatList.Sorted = True
        Me.lbStatList.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbNewStat, Me.ToolStripSeparator2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator7, Me.pbCopyStat, Me.ToolStripSeparator10, Me.pbChangeStat, Me.ToolStripSeparator3, Me.pbDeleteStat, Me.ToolStripSeparator1, Me.pbPaste, Me.toolStripSeparator})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip2.Stretch = True
        Me.ToolStrip2.TabIndex = 0
        '
        'pbNewStat
        '
        Me.pbNewStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbNewStat.Image = CType(resources.GetObject("pbNewStat.Image"), System.Drawing.Image)
        Me.pbNewStat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbNewStat.Name = "pbNewStat"
        Me.pbNewStat.Size = New System.Drawing.Size(32, 22)
        Me.pbNewStat.Text = "New"
        Me.pbNewStat.ToolTipText = "Add new entry"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.pbCBLoad})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripDropDownButton1.Text = "Load"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.LoadToolStripMenuItem.Text = "Load from AT"
        '
        'pbCBLoad
        '
        Me.pbCBLoad.Name = "pbCBLoad"
        Me.pbCBLoad.Size = New System.Drawing.Size(149, 22)
        Me.pbCBLoad.Text = "Load from CB"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'pbCopyStat
        '
        Me.pbCopyStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbCopyStat.Image = CType(resources.GetObject("pbCopyStat.Image"), System.Drawing.Image)
        Me.pbCopyStat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbCopyStat.Name = "pbCopyStat"
        Me.pbCopyStat.Size = New System.Drawing.Size(36, 22)
        Me.pbCopyStat.Text = "Copy"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'pbChangeStat
        '
        Me.pbChangeStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbChangeStat.Image = CType(resources.GetObject("pbChangeStat.Image"), System.Drawing.Image)
        Me.pbChangeStat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbChangeStat.Name = "pbChangeStat"
        Me.pbChangeStat.Size = New System.Drawing.Size(48, 22)
        Me.pbChangeStat.Text = "Change"
        Me.pbChangeStat.ToolTipText = "Change selected entry"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'pbDeleteStat
        '
        Me.pbDeleteStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbDeleteStat.Image = CType(resources.GetObject("pbDeleteStat.Image"), System.Drawing.Image)
        Me.pbDeleteStat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbDeleteStat.Name = "pbDeleteStat"
        Me.pbDeleteStat.Size = New System.Drawing.Size(42, 22)
        Me.pbDeleteStat.Text = "Delete"
        Me.pbDeleteStat.ToolTipText = "Delete selected entry"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'pbPaste
        '
        Me.pbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbPaste.Image = CType(resources.GetObject("pbPaste.Image"), System.Drawing.Image)
        Me.pbPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbPaste.Name = "pbPaste"
        Me.pbPaste.Size = New System.Drawing.Size(38, 22)
        Me.pbPaste.Text = "&Paste"
        Me.pbPaste.ToolTipText = "Paste Rich Text entry from Monster Builder"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'SplitMiddleRight
        '
        Me.SplitMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddleRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitMiddleRight.IsSplitterFixed = True
        Me.SplitMiddleRight.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddleRight.Name = "SplitMiddleRight"
        '
        'SplitMiddleRight.Panel1
        '
        Me.SplitMiddleRight.Panel1.Controls.Add(Me.dfStatBlockHTML)
        '
        'SplitMiddleRight.Panel2
        '
        Me.SplitMiddleRight.Panel2.Controls.Add(Me.ToolStripContainer2)
        Me.SplitMiddleRight.Size = New System.Drawing.Size(658, 547)
        Me.SplitMiddleRight.SplitterDistance = 358
        Me.SplitMiddleRight.TabIndex = 0
        '
        'dfStatBlockHTML
        '
        Me.dfStatBlockHTML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dfStatBlockHTML.Location = New System.Drawing.Point(0, 0)
        Me.dfStatBlockHTML.MinimumSize = New System.Drawing.Size(20, 20)
        Me.dfStatBlockHTML.Name = "dfStatBlockHTML"
        Me.dfStatBlockHTML.ScriptErrorsSuppressed = True
        Me.dfStatBlockHTML.Size = New System.Drawing.Size(358, 547)
        Me.dfStatBlockHTML.TabIndex = 1
        Me.dfStatBlockHTML.WebBrowserShortcutsEnabled = False
        '
        'ToolStripContainer2
        '
        '
        'ToolStripContainer2.BottomToolStripPanel
        '
        Me.ToolStripContainer2.BottomToolStripPanel.Controls.Add(Me.ToolStrip4)
        '
        'ToolStripContainer2.ContentPanel
        '
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.lbAddToBattle)
        Me.ToolStripContainer2.ContentPanel.Size = New System.Drawing.Size(296, 497)
        Me.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        Me.ToolStripContainer2.Size = New System.Drawing.Size(296, 547)
        Me.ToolStripContainer2.TabIndex = 0
        Me.ToolStripContainer2.Text = "ToolStripContainer2"
        '
        'ToolStripContainer2.TopToolStripPanel
        '
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip3)
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.dfXP_Total, Me.dfXPLevelFor6, Me.ToolStripSeparator5, Me.dfXPLevelFor5, Me.ToolStripSeparator4, Me.dfXPLevelFor4, Me.ToolStripLabel4})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(296, 25)
        Me.ToolStrip4.Stretch = True
        Me.ToolStrip4.TabIndex = 0
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel3.Text = "XP Total:"
        '
        'dfXP_Total
        '
        Me.dfXP_Total.BackColor = System.Drawing.SystemColors.Control
        Me.dfXP_Total.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dfXP_Total.Enabled = False
        Me.dfXP_Total.Name = "dfXP_Total"
        Me.dfXP_Total.Size = New System.Drawing.Size(50, 25)
        '
        'dfXPLevelFor6
        '
        Me.dfXPLevelFor6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.dfXPLevelFor6.BackColor = System.Drawing.SystemColors.Control
        Me.dfXPLevelFor6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dfXPLevelFor6.Enabled = False
        Me.dfXPLevelFor6.Name = "dfXPLevelFor6"
        Me.dfXPLevelFor6.Size = New System.Drawing.Size(20, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'dfXPLevelFor5
        '
        Me.dfXPLevelFor5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.dfXPLevelFor5.BackColor = System.Drawing.SystemColors.Control
        Me.dfXPLevelFor5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dfXPLevelFor5.Enabled = False
        Me.dfXPLevelFor5.Name = "dfXPLevelFor5"
        Me.dfXPLevelFor5.Size = New System.Drawing.Size(20, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'dfXPLevelFor4
        '
        Me.dfXPLevelFor4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.dfXPLevelFor4.BackColor = System.Drawing.SystemColors.Control
        Me.dfXPLevelFor4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dfXPLevelFor4.Enabled = False
        Me.dfXPLevelFor4.Name = "dfXPLevelFor4"
        Me.dfXPLevelFor4.Size = New System.Drawing.Size(20, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripLabel4.Text = "Lvl for 4/5/6 PCs:"
        '
        'lbAddToBattle
        '
        Me.lbAddToBattle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbAddToBattle.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAddToBattle.FormattingEnabled = True
        Me.lbAddToBattle.ItemHeight = 20
        Me.lbAddToBattle.Location = New System.Drawing.Point(0, 0)
        Me.lbAddToBattle.Name = "lbAddToBattle"
        Me.lbAddToBattle.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbAddToBattle.Size = New System.Drawing.Size(296, 484)
        Me.lbAddToBattle.Sorted = True
        Me.lbAddToBattle.TabIndex = 0
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel6, Me.ToolStripSeparator9, Me.pbAddToBattle, Me.ToolStripSeparator8, Me.pbAddListRemove, Me.ToolStripSeparator6})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(296, 25)
        Me.ToolStrip3.Stretch = True
        Me.ToolStrip3.TabIndex = 0
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel6.Text = "Battle List:"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'pbAddToBattle
        '
        Me.pbAddToBattle.BackColor = System.Drawing.SystemColors.Control
        Me.pbAddToBattle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbAddToBattle.Image = CType(resources.GetObject("pbAddToBattle.Image"), System.Drawing.Image)
        Me.pbAddToBattle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbAddToBattle.Name = "pbAddToBattle"
        Me.pbAddToBattle.Size = New System.Drawing.Size(30, 22)
        Me.pbAddToBattle.Text = "Add"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'pbAddListRemove
        '
        Me.pbAddListRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pbAddListRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbAddListRemove.Image = CType(resources.GetObject("pbAddListRemove.Image"), System.Drawing.Image)
        Me.pbAddListRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbAddListRemove.Name = "pbAddListRemove"
        Me.pbAddListRemove.Size = New System.Drawing.Size(50, 22)
        Me.pbAddListRemove.Text = "Remove"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'StatLibraryView
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(992, 547)
        Me.Controls.Add(Me.SplitLeft)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 576)
        Me.Name = "StatLibraryView"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Statblock Library"
        Me.SplitLeft.Panel1.ResumeLayout(False)
        Me.SplitLeft.Panel2.ResumeLayout(False)
        Me.SplitLeft.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.SplitMiddleRight.Panel1.ResumeLayout(False)
        Me.SplitMiddleRight.Panel2.ResumeLayout(False)
        Me.SplitMiddleRight.ResumeLayout(False)
        Me.ToolStripContainer2.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitLeft As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lbStatList As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfFilterName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents pbClearMenuFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents pbNewStat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbChangeStat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbDeleteStat As System.Windows.Forms.ToolStripButton
    Friend WithEvents pbPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitMiddleRight As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripContainer2 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lbAddToBattle As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfXPLevelFor6 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfXP_Total As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dfXPLevelFor4 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dfXPLevelFor5 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbAddListRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfFilterLevelLow As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dfFilterLevelHigh As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dfFilterRole As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents pbAddToBattle As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dfStatBlockHTML As System.Windows.Forms.WebBrowser
    Friend WithEvents pbCopyStat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbCBLoad As System.Windows.Forms.ToolStripMenuItem
End Class
