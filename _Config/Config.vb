Public Class Config

    Dim changed As Boolean

    Private Sub Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cfgAutoCompendium.Checked = My.Settings.bAutoCompendium
        cfgDisplayHeroHP.Checked = My.Settings.htmlDisplayHeroHP
        cfgDisplayInit.Checked = My.Settings.htmlDisplayInit
        cfgDisplayOtherHP.Checked = My.Settings.htmlDisplayOtherHP
        cfgDisplayRound.Checked = My.Settings.htmlDisplayRound
        cfgGroupSimilar.Checked = My.Settings.bGroupSimilar
        cfgOngoingPopup.Checked = My.Settings.bOngoingPopup
        cfgRollEffectSaves.Checked = My.Settings.bRollEffectSaves
        cfgRollPowerRecharge.Checked = My.Settings.bRollPowerRecharge
        cfgSurpriseRound.Checked = My.Settings.bSurpriseRound
        cfgHttpPort.Text = My.Settings.htmlPort.ToString
        cfgWhiteMonsterBGs.Checked = My.Settings.bWhiteMonsterBGs
        cfgSurgePlusPrompt.Checked = My.Settings.bSurgePlusPrompt
        cfgAutoSurge.Checked = My.Settings.bAutoSurge
        changed = False
    End Sub
    Private Sub ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cfgAutoCompendium.CheckedChanged, cfgDisplayHeroHP.CheckedChanged, cfgDisplayInit.CheckedChanged, cfgDisplayOtherHP.CheckedChanged, cfgDisplayRound.CheckedChanged, cfgGroupSimilar.CheckedChanged, cfgOngoingPopup.CheckedChanged, cfgRollEffectSaves.CheckedChanged, cfgRollPowerRecharge.CheckedChanged, cfgSurpriseRound.CheckedChanged, cfgWhiteMonsterBGs.CheckedChanged
        changed = True
    End Sub
    Private Sub PortChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cfgHttpPort.Leave
        If Not IsNumeric(cfgHttpPort.Text) Or CInt(cfgHttpPort.Text) < 1000 Or CInt(cfgHttpPort.Text) > 32768 Then
            cfgHttpPort.Text = "9000"
            MsgBox("Please enter a port number between 1000 and 32768.", MsgBoxStyle.OkOnly)
        End If
        changed = True
    End Sub

    Private Sub Config_Close(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        If changed Then
            Dim answer As MsgBoxResult = MsgBox("Do you wish to save your changes?", MsgBoxStyle.YesNoCancel)
            If answer = MsgBoxResult.Yes Then SaveConfig()
            If answer = MsgBoxResult.Cancel Then e.Cancel = True
        End If
    End Sub

    Private Sub SaveConfig()
        My.Settings.bAutoCompendium = cfgAutoCompendium.Checked
        My.Settings.htmlDisplayHeroHP = cfgDisplayHeroHP.Checked
        My.Settings.htmlDisplayInit = cfgDisplayInit.Checked
        My.Settings.htmlDisplayOtherHP = cfgDisplayOtherHP.Checked
        My.Settings.htmlDisplayRound = cfgDisplayRound.Checked
        If My.Settings.htmlPort <> CInt(cfgHttpPort.Text) And WebServer.getWebServer.Running Then
            WebServer.getWebServer.StopWebServer()
            My.Settings.htmlPort = CInt(cfgHttpPort.Text)
            WebServer.getWebServer.StartWebServer()
            MsgBox("Webserver Port has changed.  Any exisiting clients will have to update their browser address to port " + My.Settings.htmlPort.ToString)
        End If
        My.Settings.bGroupSimilar = cfgGroupSimilar.Checked
        My.Settings.bOngoingPopup = cfgOngoingPopup.Checked
        My.Settings.bRollEffectSaves = cfgRollEffectSaves.Checked
        My.Settings.bRollPowerRecharge = cfgRollPowerRecharge.Checked
        My.Settings.bSurpriseRound = cfgSurpriseRound.Checked
        My.Settings.bWhiteMonsterBGs = cfgWhiteMonsterBGs.Checked
        My.Settings.bSurgePlusPrompt = cfgSurgePlusPrompt.Checked
        My.Settings.bAutoSurge = cfgAutoSurge.Checked
        changed = False
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        SaveConfig()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        changed = False
        Me.Close()
    End Sub

End Class