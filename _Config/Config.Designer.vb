<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.cfgAutoSurge = New System.Windows.Forms.CheckBox()
        Me.cfgSurgePlusPrompt = New System.Windows.Forms.CheckBox()
        Me.cfgWhiteMonsterBGs = New System.Windows.Forms.CheckBox()
        Me.cfgRollEffectSaves = New System.Windows.Forms.CheckBox()
        Me.cfgRollPowerRecharge = New System.Windows.Forms.CheckBox()
        Me.cfgSurpriseRound = New System.Windows.Forms.CheckBox()
        Me.cfgOngoingPopup = New System.Windows.Forms.CheckBox()
        Me.cfgGroupSimilar = New System.Windows.Forms.CheckBox()
        Me.cfgAutoCompendium = New System.Windows.Forms.CheckBox()
        Me.tabSecondaryDisplay = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cfgDisplayOtherHP = New System.Windows.Forms.CheckBox()
        Me.cfgDisplayHeroHP = New System.Windows.Forms.CheckBox()
        Me.cfgDisplayInit = New System.Windows.Forms.CheckBox()
        Me.cfgDisplayRound = New System.Windows.Forms.CheckBox()
        Me.cfgHttpPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.tabSecondaryDisplay.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabGeneral)
        Me.TabControl1.Controls.Add(Me.tabSecondaryDisplay)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(385, 251)
        Me.TabControl1.TabIndex = 0
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.cfgAutoSurge)
        Me.tabGeneral.Controls.Add(Me.cfgSurgePlusPrompt)
        Me.tabGeneral.Controls.Add(Me.cfgWhiteMonsterBGs)
        Me.tabGeneral.Controls.Add(Me.cfgRollEffectSaves)
        Me.tabGeneral.Controls.Add(Me.cfgRollPowerRecharge)
        Me.tabGeneral.Controls.Add(Me.cfgSurpriseRound)
        Me.tabGeneral.Controls.Add(Me.cfgOngoingPopup)
        Me.tabGeneral.Controls.Add(Me.cfgGroupSimilar)
        Me.tabGeneral.Controls.Add(Me.cfgAutoCompendium)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(377, 225)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'cfgAutoSurge
        '
        Me.cfgAutoSurge.AutoSize = True
        Me.cfgAutoSurge.Location = New System.Drawing.Point(6, 190)
        Me.cfgAutoSurge.Name = "cfgAutoSurge"
        Me.cfgAutoSurge.Size = New System.Drawing.Size(331, 17)
        Me.cfgAutoSurge.TabIndex = 8
        Me.cfgAutoSurge.Text = "Automatically apply healing and remove surge using surge button"
        Me.cfgAutoSurge.UseVisualStyleBackColor = True
        '
        'cfgSurgePlusPrompt
        '
        Me.cfgSurgePlusPrompt.AutoSize = True
        Me.cfgSurgePlusPrompt.Location = New System.Drawing.Point(6, 167)
        Me.cfgSurgePlusPrompt.Name = "cfgSurgePlusPrompt"
        Me.cfgSurgePlusPrompt.Size = New System.Drawing.Size(259, 17)
        Me.cfgSurgePlusPrompt.TabIndex = 7
        Me.cfgSurgePlusPrompt.Text = "Prompt for value to add when using healing surge"
        Me.cfgSurgePlusPrompt.UseVisualStyleBackColor = True
        '
        'cfgWhiteMonsterBGs
        '
        Me.cfgWhiteMonsterBGs.AutoSize = True
        Me.cfgWhiteMonsterBGs.Location = New System.Drawing.Point(6, 144)
        Me.cfgWhiteMonsterBGs.Name = "cfgWhiteMonsterBGs"
        Me.cfgWhiteMonsterBGs.Size = New System.Drawing.Size(347, 17)
        Me.cfgWhiteMonsterBGs.TabIndex = 6
        Me.cfgWhiteMonsterBGs.Text = "Use White Backgrounds for NPCs and Monsters (Red when Bloody)"
        Me.cfgWhiteMonsterBGs.UseVisualStyleBackColor = True
        '
        'cfgRollEffectSaves
        '
        Me.cfgRollEffectSaves.AutoSize = True
        Me.cfgRollEffectSaves.Location = New System.Drawing.Point(6, 121)
        Me.cfgRollEffectSaves.Name = "cfgRollEffectSaves"
        Me.cfgRollEffectSaves.Size = New System.Drawing.Size(272, 17)
        Me.cfgRollEffectSaves.TabIndex = 5
        Me.cfgRollEffectSaves.Text = "Automatically Roll For Saving Throws at End of Turn"
        Me.cfgRollEffectSaves.UseVisualStyleBackColor = True
        '
        'cfgRollPowerRecharge
        '
        Me.cfgRollPowerRecharge.AutoSize = True
        Me.cfgRollPowerRecharge.Location = New System.Drawing.Point(6, 98)
        Me.cfgRollPowerRecharge.Name = "cfgRollPowerRecharge"
        Me.cfgRollPowerRecharge.Size = New System.Drawing.Size(284, 17)
        Me.cfgRollPowerRecharge.TabIndex = 4
        Me.cfgRollPowerRecharge.Text = "Automatically Roll For Power Recharge at Start of Turn"
        Me.cfgRollPowerRecharge.UseVisualStyleBackColor = True
        '
        'cfgSurpriseRound
        '
        Me.cfgSurpriseRound.AutoSize = True
        Me.cfgSurpriseRound.Location = New System.Drawing.Point(6, 75)
        Me.cfgSurpriseRound.Name = "cfgSurpriseRound"
        Me.cfgSurpriseRound.Size = New System.Drawing.Size(147, 17)
        Me.cfgSurpriseRound.TabIndex = 3
        Me.cfgSurpriseRound.Text = "Include A Surprise Round"
        Me.cfgSurpriseRound.UseVisualStyleBackColor = True
        '
        'cfgOngoingPopup
        '
        Me.cfgOngoingPopup.AutoSize = True
        Me.cfgOngoingPopup.Location = New System.Drawing.Point(6, 52)
        Me.cfgOngoingPopup.Name = "cfgOngoingPopup"
        Me.cfgOngoingPopup.Size = New System.Drawing.Size(214, 17)
        Me.cfgOngoingPopup.TabIndex = 2
        Me.cfgOngoingPopup.Text = "Pop Up Reminder For Ongoing Damage"
        Me.cfgOngoingPopup.UseVisualStyleBackColor = True
        '
        'cfgGroupSimilar
        '
        Me.cfgGroupSimilar.AutoSize = True
        Me.cfgGroupSimilar.Location = New System.Drawing.Point(6, 29)
        Me.cfgGroupSimilar.Name = "cfgGroupSimilar"
        Me.cfgGroupSimilar.Size = New System.Drawing.Size(253, 17)
        Me.cfgGroupSimilar.TabIndex = 1
        Me.cfgGroupSimilar.Text = "Group Similar Combatants Together For Initiative"
        Me.cfgGroupSimilar.UseVisualStyleBackColor = True
        '
        'cfgAutoCompendium
        '
        Me.cfgAutoCompendium.AutoSize = True
        Me.cfgAutoCompendium.Location = New System.Drawing.Point(6, 6)
        Me.cfgAutoCompendium.Name = "cfgAutoCompendium"
        Me.cfgAutoCompendium.Size = New System.Drawing.Size(305, 17)
        Me.cfgAutoCompendium.TabIndex = 0
        Me.cfgAutoCompendium.Text = "Auto-Load Compendium Entry (Requires D&&D Insider Login)"
        Me.cfgAutoCompendium.UseVisualStyleBackColor = True
        '
        'tabSecondaryDisplay
        '
        Me.tabSecondaryDisplay.Controls.Add(Me.GroupBox1)
        Me.tabSecondaryDisplay.Controls.Add(Me.cfgHttpPort)
        Me.tabSecondaryDisplay.Controls.Add(Me.Label1)
        Me.tabSecondaryDisplay.Location = New System.Drawing.Point(4, 22)
        Me.tabSecondaryDisplay.Name = "tabSecondaryDisplay"
        Me.tabSecondaryDisplay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSecondaryDisplay.Size = New System.Drawing.Size(377, 225)
        Me.tabSecondaryDisplay.TabIndex = 1
        Me.tabSecondaryDisplay.Text = "Secondary Display"
        Me.tabSecondaryDisplay.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cfgDisplayOtherHP)
        Me.GroupBox1.Controls.Add(Me.cfgDisplayHeroHP)
        Me.GroupBox1.Controls.Add(Me.cfgDisplayInit)
        Me.GroupBox1.Controls.Add(Me.cfgDisplayRound)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 112)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'cfgDisplayOtherHP
        '
        Me.cfgDisplayOtherHP.AutoSize = True
        Me.cfgDisplayOtherHP.Location = New System.Drawing.Point(6, 42)
        Me.cfgDisplayOtherHP.Name = "cfgDisplayOtherHP"
        Me.cfgDisplayOtherHP.Size = New System.Drawing.Size(176, 17)
        Me.cfgDisplayOtherHP.TabIndex = 2
        Me.cfgDisplayOtherHP.Text = "Display Monster/NPC Hit Points"
        Me.cfgDisplayOtherHP.UseVisualStyleBackColor = True
        '
        'cfgDisplayHeroHP
        '
        Me.cfgDisplayHeroHP.AutoSize = True
        Me.cfgDisplayHeroHP.Location = New System.Drawing.Point(6, 19)
        Me.cfgDisplayHeroHP.Name = "cfgDisplayHeroHP"
        Me.cfgDisplayHeroHP.Size = New System.Drawing.Size(134, 17)
        Me.cfgDisplayHeroHP.TabIndex = 1
        Me.cfgDisplayHeroHP.Text = "Display Hero Hit Points"
        Me.cfgDisplayHeroHP.UseVisualStyleBackColor = True
        '
        'cfgDisplayInit
        '
        Me.cfgDisplayInit.AutoSize = True
        Me.cfgDisplayInit.Location = New System.Drawing.Point(6, 65)
        Me.cfgDisplayInit.Name = "cfgDisplayInit"
        Me.cfgDisplayInit.Size = New System.Drawing.Size(138, 17)
        Me.cfgDisplayInit.TabIndex = 3
        Me.cfgDisplayInit.Text = "Display Initiative Scores"
        Me.cfgDisplayInit.UseVisualStyleBackColor = True
        '
        'cfgDisplayRound
        '
        Me.cfgDisplayRound.AutoSize = True
        Me.cfgDisplayRound.Location = New System.Drawing.Point(6, 88)
        Me.cfgDisplayRound.Name = "cfgDisplayRound"
        Me.cfgDisplayRound.Size = New System.Drawing.Size(132, 17)
        Me.cfgDisplayRound.TabIndex = 4
        Me.cfgDisplayRound.Text = "Display Current Round"
        Me.cfgDisplayRound.UseVisualStyleBackColor = True
        '
        'cfgHttpPort
        '
        Me.cfgHttpPort.Location = New System.Drawing.Point(150, 10)
        Me.cfgHttpPort.Name = "cfgHttpPort"
        Me.cfgHttpPort.Size = New System.Drawing.Size(101, 20)
        Me.cfgHttpPort.TabIndex = 6
        Me.cfgHttpPort.Text = "9000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "HTTP Port (Default 9000)"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(237, 269)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(318, 269)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 323)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Config"
        Me.ShowIcon = False
        Me.Text = "Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        Me.tabSecondaryDisplay.ResumeLayout(False)
        Me.tabSecondaryDisplay.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabSecondaryDisplay As System.Windows.Forms.TabPage
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cfgAutoCompendium As System.Windows.Forms.CheckBox
    Friend WithEvents cfgGroupSimilar As System.Windows.Forms.CheckBox
    Friend WithEvents cfgOngoingPopup As System.Windows.Forms.CheckBox
    Friend WithEvents cfgSurpriseRound As System.Windows.Forms.CheckBox
    Friend WithEvents cfgRollPowerRecharge As System.Windows.Forms.CheckBox
    Friend WithEvents cfgRollEffectSaves As System.Windows.Forms.CheckBox
    Friend WithEvents cfgDisplayHeroHP As System.Windows.Forms.CheckBox
    Friend WithEvents cfgDisplayOtherHP As System.Windows.Forms.CheckBox
    Friend WithEvents cfgDisplayInit As System.Windows.Forms.CheckBox
    Friend WithEvents cfgDisplayRound As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cfgHttpPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cfgWhiteMonsterBGs As System.Windows.Forms.CheckBox
    Friend WithEvents cfgSurgePlusPrompt As System.Windows.Forms.CheckBox
    Friend WithEvents cfgAutoSurge As System.Windows.Forms.CheckBox
End Class
