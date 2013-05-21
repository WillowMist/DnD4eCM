<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EffectView
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dfSource = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dfTarget = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dfDuration = New System.Windows.Forms.ComboBox
        Me.pbSave = New System.Windows.Forms.Button
        Me.pbCancel = New System.Windows.Forms.Button
        Me.cbBeneficial = New System.Windows.Forms.CheckBox
        Me.lbEffectsHistory = New System.Windows.Forms.ListView
        Me.colEffectName = New System.Windows.Forms.ColumnHeader
        Me.colEffectDuration = New System.Windows.Forms.ColumnHeader
        Me.dfName = New System.Windows.Forms.ComboBox
        Me.gbEffect = New System.Windows.Forms.GroupBox
        Me.cbHidden = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gbEffect.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'dfSource
        '
        Me.dfSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dfSource.FormattingEnabled = True
        Me.dfSource.Location = New System.Drawing.Point(60, 88)
        Me.dfSource.Name = "dfSource"
        Me.dfSource.Size = New System.Drawing.Size(282, 21)
        Me.dfSource.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Source"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Target"
        '
        'dfTarget
        '
        Me.dfTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dfTarget.FormattingEnabled = True
        Me.dfTarget.Location = New System.Drawing.Point(60, 115)
        Me.dfTarget.Name = "dfTarget"
        Me.dfTarget.Size = New System.Drawing.Size(282, 21)
        Me.dfTarget.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Duration"
        '
        'dfDuration
        '
        Me.dfDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dfDuration.FormattingEnabled = True
        Me.dfDuration.Items.AddRange(New Object() {"End of Source's Next Turn", "End of Target's Next Turn", "End of the Current Turn", "End of the Encounter", "Save Ends", "Special", "Start of Source's Next Turn", "Start of Target's Next Turn", "Sustained", "Permanent"})
        Me.dfDuration.Location = New System.Drawing.Point(60, 45)
        Me.dfDuration.Name = "dfDuration"
        Me.dfDuration.Size = New System.Drawing.Size(204, 21)
        Me.dfDuration.TabIndex = 3
        '
        'pbSave
        '
        Me.pbSave.Location = New System.Drawing.Point(171, 160)
        Me.pbSave.Name = "pbSave"
        Me.pbSave.Size = New System.Drawing.Size(93, 26)
        Me.pbSave.TabIndex = 5
        Me.pbSave.Text = "Save"
        Me.pbSave.UseVisualStyleBackColor = True
        '
        'pbCancel
        '
        Me.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.pbCancel.Location = New System.Drawing.Point(270, 160)
        Me.pbCancel.Name = "pbCancel"
        Me.pbCancel.Size = New System.Drawing.Size(93, 26)
        Me.pbCancel.TabIndex = 6
        Me.pbCancel.Text = "Cancel"
        Me.pbCancel.UseVisualStyleBackColor = True
        '
        'cbBeneficial
        '
        Me.cbBeneficial.AutoSize = True
        Me.cbBeneficial.Location = New System.Drawing.Point(270, 47)
        Me.cbBeneficial.Name = "cbBeneficial"
        Me.cbBeneficial.Size = New System.Drawing.Size(72, 17)
        Me.cbBeneficial.TabIndex = 4
        Me.cbBeneficial.Text = "Beneficial"
        Me.cbBeneficial.UseVisualStyleBackColor = True
        '
        'lbEffectsHistory
        '
        Me.lbEffectsHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEffectName, Me.colEffectDuration})
        Me.lbEffectsHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbEffectsHistory.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEffectsHistory.FullRowSelect = True
        Me.lbEffectsHistory.LabelWrap = False
        Me.lbEffectsHistory.Location = New System.Drawing.Point(3, 16)
        Me.lbEffectsHistory.MultiSelect = False
        Me.lbEffectsHistory.Name = "lbEffectsHistory"
        Me.lbEffectsHistory.Size = New System.Drawing.Size(345, 310)
        Me.lbEffectsHistory.TabIndex = 8
        Me.lbEffectsHistory.TileSize = New System.Drawing.Size(315, 35)
        Me.lbEffectsHistory.UseCompatibleStateImageBehavior = False
        Me.lbEffectsHistory.View = System.Windows.Forms.View.Tile
        '
        'colEffectName
        '
        Me.colEffectName.Text = "Effect Name"
        Me.colEffectName.Width = 200
        '
        'colEffectDuration
        '
        Me.colEffectDuration.Text = "Effect Duration"
        '
        'dfName
        '
        Me.dfName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dfName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dfName.FormattingEnabled = True
        Me.dfName.Items.AddRange(New Object() {"Attack Penalty", "Blinded", "Damage Penalty", "Dazed", "Deafened", "Defense Penalty", "Dominated", "Full Defense (+2 all Def)", "Granting Combat Advantage", "Immobilized", "Marked", "Ongoing Damage", "Petrified", "Prone", "Regeneration", "Resist", "Restrained", "Second Wind (+2 all Def)", "Slowed", "Stunned", "Surprised", "Unconscious", "Vulnerability", "Weakened"})
        Me.dfName.Location = New System.Drawing.Point(60, 19)
        Me.dfName.Name = "dfName"
        Me.dfName.Size = New System.Drawing.Size(282, 21)
        Me.dfName.Sorted = True
        Me.dfName.TabIndex = 1
        '
        'gbEffect
        '
        Me.gbEffect.Controls.Add(Me.cbHidden)
        Me.gbEffect.Controls.Add(Me.dfName)
        Me.gbEffect.Controls.Add(Me.Label1)
        Me.gbEffect.Controls.Add(Me.dfDuration)
        Me.gbEffect.Controls.Add(Me.Label4)
        Me.gbEffect.Controls.Add(Me.cbBeneficial)
        Me.gbEffect.Controls.Add(Me.Label3)
        Me.gbEffect.Controls.Add(Me.dfSource)
        Me.gbEffect.Controls.Add(Me.dfTarget)
        Me.gbEffect.Controls.Add(Me.Label2)
        Me.gbEffect.Location = New System.Drawing.Point(12, 12)
        Me.gbEffect.Name = "gbEffect"
        Me.gbEffect.Size = New System.Drawing.Size(351, 142)
        Me.gbEffect.TabIndex = 13
        Me.gbEffect.TabStop = False
        Me.gbEffect.Text = "Effect"
        '
        'cbHidden
        '
        Me.cbHidden.AutoSize = True
        Me.cbHidden.Location = New System.Drawing.Point(270, 65)
        Me.cbHidden.Name = "cbHidden"
        Me.cbHidden.Size = New System.Drawing.Size(60, 17)
        Me.cbHidden.TabIndex = 13
        Me.cbHidden.Text = "Hidden"
        Me.cbHidden.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbEffectsHistory)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 329)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prior/Preset Effects from Source"
        '
        'EffectView
        '
        Me.AcceptButton = Me.pbSave
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.pbCancel
        Me.ClientSize = New System.Drawing.Size(371, 528)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbEffect)
        Me.Controls.Add(Me.pbCancel)
        Me.Controls.Add(Me.pbSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EffectView"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Effect"
        Me.gbEffect.ResumeLayout(False)
        Me.gbEffect.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dfSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dfTarget As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dfDuration As System.Windows.Forms.ComboBox
    Friend WithEvents pbSave As System.Windows.Forms.Button
    Friend WithEvents pbCancel As System.Windows.Forms.Button
    Friend WithEvents cbBeneficial As System.Windows.Forms.CheckBox
    Friend WithEvents lbEffectsHistory As System.Windows.Forms.ListView
    Friend WithEvents colEffectName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEffectDuration As System.Windows.Forms.ColumnHeader
    Friend WithEvents dfName As System.Windows.Forms.ComboBox
    Friend WithEvents gbEffect As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbHidden As System.Windows.Forms.CheckBox
End Class
