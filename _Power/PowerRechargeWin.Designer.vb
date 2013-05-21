<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerRechargeWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PowerRechargeWin))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.pbOk = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.pbRerollAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.lbChecklist = New System.Windows.Forms.ListView
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.colNotes = New System.Windows.Forms.ColumnHeader
        Me.pbOk2 = New System.Windows.Forms.Button
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lbChecklist)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.pbOk2)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(384, 108)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(384, 133)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbOk, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.pbRerollAll, Me.ToolStripSeparator4})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(384, 25)
        Me.ToolStrip2.Stretch = True
        Me.ToolStrip2.TabIndex = 0
        '
        'pbOk
        '
        Me.pbOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pbOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbOk.Image = CType(resources.GetObject("pbOk.Image"), System.Drawing.Image)
        Me.pbOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbOk.Name = "pbOk"
        Me.pbOk.Size = New System.Drawing.Size(75, 22)
        Me.pbOk.Text = "Save Results"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'pbRerollAll
        '
        Me.pbRerollAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pbRerollAll.Image = CType(resources.GetObject("pbRerollAll.Image"), System.Drawing.Image)
        Me.pbRerollAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pbRerollAll.Name = "pbRerollAll"
        Me.pbRerollAll.Size = New System.Drawing.Size(58, 22)
        Me.pbRerollAll.Text = "Reroll All"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'lbChecklist
        '
        Me.lbChecklist.CheckBoxes = True
        Me.lbChecklist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colNotes})
        Me.lbChecklist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbChecklist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbChecklist.FullRowSelect = True
        Me.lbChecklist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lbChecklist.Location = New System.Drawing.Point(0, 0)
        Me.lbChecklist.MultiSelect = False
        Me.lbChecklist.Name = "lbChecklist"
        Me.lbChecklist.Size = New System.Drawing.Size(384, 108)
        Me.lbChecklist.TabIndex = 0
        Me.lbChecklist.UseCompatibleStateImageBehavior = False
        Me.lbChecklist.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Power Name"
        Me.colName.Width = 224
        '
        'colNotes
        '
        Me.colNotes.Text = "Recharge Result"
        Me.colNotes.Width = 130
        '
        'pbOk2
        '
        Me.pbOk2.Location = New System.Drawing.Point(194, 66)
        Me.pbOk2.Name = "pbOk2"
        Me.pbOk2.Size = New System.Drawing.Size(51, 29)
        Me.pbOk2.TabIndex = 1
        Me.pbOk2.Text = "pbOk2"
        Me.pbOk2.UseVisualStyleBackColor = True
        '
        'PowerRechargeWin
        '
        Me.AcceptButton = Me.pbOk2
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(384, 133)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PowerRechargeWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Power Recharge"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents pbOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbRerollAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbChecklist As System.Windows.Forms.ListView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNotes As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pbOk2 As System.Windows.Forms.Button
End Class
