

Public Class StatLibraryView

    ' Window Data
    Public statlib As StatLibrary
    Public statsToAdd As New ArrayList


    ' Constructors
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        statlib = New StatLibrary
    End Sub
    Public Sub New(ByRef p_statlib As StatLibrary)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        statlib = p_statlib
        ResetListFromClass()
    End Sub

    Private Sub StatLibraryView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pbAddListRemove.Enabled = False
    End Sub
    Private Sub StatLibraryView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Verify statsToAdd list
        For Each handle As String In lbAddToBattle.Items
            If statlib.StatblockLibrary.ContainsKey(handle) Then
                statsToAdd.Add(statlib(handle))
            End If
        Next
    End Sub


    ' Display Function
    Public Sub ResetListFromClass()
        Dim filter As String = dfFilterName.Text.ToLower
        Dim lowlevel As Integer = Val(dfFilterLevelLow.Text)
        Dim highlevel As Integer = Val(dfFilterLevelHigh.Text)
        Dim rolefilter As String = dfFilterRole.Text

        lbStatList.Items.Clear()
        For Each stat As Statblock In statlib.StatblockLibrary.Values
            If stat.nLevel >= lowlevel And stat.nLevel <= highlevel Then
                If rolefilter = "" Or rolefilter = stat.sRole Then
                    If filter = "" Or stat.sHandle.ToLower.Contains(filter) Then
                        lbStatList.Items.Add(stat.sHandle)
                    End If
                End If
            End If
        Next
        dfStatBlockHTML.DocumentText = ""
        pbChangeStat.Enabled = False
        pbDeleteStat.Enabled = False
        pbAddToBattle.Enabled = False
        pbAddToBattle.Enabled = False
    End Sub


    ' Main List
    Private Sub pbNewStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNewStat.Click
        Dim stat As New Statblock
        Dim statblockwin As New StatblockView(stat)
        Dim statreturn As DialogResult = statblockwin.ShowDialog(Me)

        If statreturn = Windows.Forms.DialogResult.OK Then
            If statlib.Contains(statblockwin.stat.sHandle) Then
                If MsgBox(statblockwin.stat.sHandle & " already exists in the Library." & _
                          ControlChars.NewLine & "Overwrite?", _
                          MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Ok Then
                    statlib.Add(statblockwin.stat, True)
                    dfFilterName.Text = ""
                    ResetListFromClass()
                End If
            Else
                statlib.Add(statblockwin.stat)
                dfFilterName.Text = ""
                ResetListFromClass()
            End If
        End If

        statblockwin.Dispose()
    End Sub
    Private Sub pbCopyStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCopyStat.Click
        If lbStatList.SelectedIndex >= 0 Then
            Dim handle As String = lbStatList.Text
            If statlib.StatblockLibrary.ContainsKey(handle) Then
                Dim oldstat As Statblock = statlib(handle)
                Dim stat As New Statblock
                stat.Copy(oldstat)
                Dim statblockwin As New StatblockView(stat)
                Dim statreturn As DialogResult = statblockwin.ShowDialog(Me)

                If statreturn = Windows.Forms.DialogResult.OK Then
                    If statlib.Contains(statblockwin.stat.sHandle) Then
                        If MsgBox(statblockwin.stat.sHandle & " already exists in the Library." & _
                                  ControlChars.NewLine & "Overwrite?", _
                                  MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Ok Then
                            statlib.Add(statblockwin.stat, True)
                            dfFilterName.Text = ""
                            ResetListFromClass()
                        End If
                    Else
                        statlib.Add(statblockwin.stat)
                        dfFilterName.Text = ""
                        ResetListFromClass()
                    End If
                End If

                statblockwin.Dispose()
            End If
        End If
    End Sub
    Private Sub pbChangeStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbChangeStat.Click
        If lbStatList.SelectedIndex >= 0 Then
            Dim handle As String = lbStatList.Text
            If statlib.StatblockLibrary.ContainsKey(handle) Then
                Dim stat As Statblock = statlib(handle)
                Dim statblockwin As New StatblockView(stat)
                Dim statreturn As DialogResult = statblockwin.ShowDialog(Me)

                If statreturn = Windows.Forms.DialogResult.OK Then
                    Dim bOkToProceed As Boolean = True
                    If statblockwin.stat.sHandle <> handle And _
                            statlib.Contains(statblockwin.stat.sHandle) Then
                        MsgBox(statblockwin.stat.sHandle & " already exists in the Library.", _
                                  MsgBoxStyle.OkOnly, "Statblock Found")
                        bOkToProceed = False
                    End If

                    If bOkToProceed Then
                        statlib.Remove(handle)
                        statlib.Add(statblockwin.stat)
                        dfFilterName.Text = ""
                        ResetListFromClass()
                        lbStatList.SelectedIndex = _
                            lbStatList.FindStringExact(statblockwin.stat.sHandle)
                        lbStatList_Click(sender, e)

                        If handle <> statblockwin.stat.sHandle Then
                            Dim index As Integer = lbAddToBattle.FindStringExact(handle)
                            Do While index >= 0
                                lbAddToBattle.SelectedIndex = index
                                lbAddToBattle.Items(index) = statblockwin.stat.sHandle
                                index = lbAddToBattle.FindStringExact(handle)
                            Loop
                        End If
                        UpdateAddXPTotals()
                    End If
                End If

                statblockwin.Dispose()
            End If
        End If
    End Sub
    Private Sub pbDeleteStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDeleteStat.Click
        If lbStatList.SelectedIndex >= 0 Then
            Dim list As New System.Text.StringBuilder

            For Each index In lbStatList.SelectedIndices
                If list.Length > 0 Then list.AppendLine()
                list.Append("   " & lbStatList.Items(index))
            Next

            If MsgBox("Are you sure you want to delete the" & ControlChars.NewLine & _
                      "following entries from the Library?" & ControlChars.NewLine & _
                      list.ToString, _
                      MsgBoxStyle.OkCancel, "Statblock Delete") = MsgBoxResult.Ok Then
                Dim handlelist As New ArrayList

                Do While lbStatList.SelectedIndex >= 0
                    statlib.Remove(lbStatList.Text)
                    handlelist.Add(lbStatList.Text)
                    lbStatList.Items.RemoveAt(lbStatList.SelectedIndex)
                Loop

                ResetListFromClass()

                For Each handle As String In handlelist
                    Dim index As Integer = lbAddToBattle.FindStringExact(handle)
                    Do While index >= 0
                        lbAddToBattle.Items.RemoveAt(index)
                        index = lbAddToBattle.FindStringExact(handle)
                    Loop
                Next

                UpdateAddXPTotals()
            End If
        End If
    End Sub
    Private Sub pbPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPaste.Click
        If My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then
            Dim stat As New Statblock
            stat.Statblock_RTF = My.Computer.Clipboard.GetText(TextDataFormat.Rtf)
            If stat.Valid Then
                If statlib.Contains(stat.sHandle) Then
                    If MsgBox(stat.sHandle & " already exists in the Library." & _
                              ControlChars.NewLine & "Overwrite?", _
                              MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End If
                statlib.Add(stat, True)
                dfFilterName.Text = ""
                ResetListFromClass()
                lbStatList.SelectedIndex = _
                    lbStatList.FindStringExact(stat.sHandle)
                lbStatList_Click(sender, e)
            End If
        End If
        If My.Computer.Clipboard.ContainsText(TextDataFormat.Text) Then
            Dim url As String = My.Computer.Clipboard.GetText.ToString
            If url.Contains("www.wizards.com/dndinsider/compendium/monster.aspx") Or url.Contains("www.wizards.com/dndinsider/compendium/display.aspx?page=monster") Or url.Contains("http://www.wizards.com/dndinsider/compendium/trap.aspx") Or url.Contains("www.wizards.com/dndinsider/compendium/display.aspx?page=trap") Or url.Contains("monster.php") Or url.Contains("trap.php") Then
                dfStatBlockHTML.Navigate(url)
                WaitingFor(2)
                If dfStatBlockHTML.DocumentText.Contains("Already a Subscriber?") Then
                    MsgBox("Please log in to your D&D Insider Account, and then click Paste again")
                Else
                    If dfStatBlockHTML.DocumentText.Contains("display.aspx?page=monster&amp") Or dfStatBlockHTML.DocumentText.Contains("display.aspx?page=trap&amp") Or dfStatBlockHTML.DocumentText.Contains("display.php?page=monster&amp") Or dfStatBlockHTML.DocumentText.Contains("display.php?page=trap&amp") Then
                        Dim stat As New Statblock
                        stat.Statblock_HTML = StripHTML(dfStatBlockHTML.DocumentText, url)
                        If stat.Valid Then
                            If statlib.Contains(stat.sHandle) Then
                                If MsgBox(stat.sHandle & " already exists in the Library." & _
                                          ControlChars.NewLine & "Overwrite?", _
                                          MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If
                            End If
                            statlib.Add(stat, True)
                            dfFilterName.Text = ""
                            ResetListFromClass()
                            lbStatList.SelectedIndex = _
                                lbStatList.FindStringExact(stat.sHandle)
                            lbStatList_Click(sender, e)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub pbCBLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCBLoad.Click
        Dim stat As Statblock
        Dim dlgOpen As New OpenFileDialog

        With dlgOpen
            .Filter = "Character files (*.dnd4e)|*.dnd4e|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Load Character File"
            .Multiselect = True
        End With

        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each filename As String In dlgOpen.FileNames
                stat = New Statblock
                If stat.LoadFromCBFile(filename) Then
                    If stat.Valid Then
                        If statlib.Contains(stat.sHandle) Then
                            If MsgBox(stat.sHandle & " already exists in the Library." & _
                                      ControlChars.NewLine & "Overwrite?", _
                                      MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Cancel Then
                                Exit Sub
                            End If
                        End If
                        statlib.Add(stat, True)
                        dfFilterName.Text = ""
                        ResetListFromClass()
                        lbStatList.SelectedIndex = _
                            lbStatList.FindStringExact(stat.sHandle)
                        lbStatList_Click(sender, e)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub lbStatList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStatList.Click
        If lbStatList.SelectedIndex >= 0 Then
            dfStatBlockHTML.DocumentText = statlib(lbStatList.Text).Statblock_HTML
            pbChangeStat.Enabled = True
            pbDeleteStat.Enabled = True
            pbAddToBattle.Enabled = True
            pbAddToBattle.Enabled = True
        Else
            dfStatBlockHTML.DocumentText = ""
            pbChangeStat.Enabled = False
            pbDeleteStat.Enabled = False
            pbAddToBattle.Enabled = False
            pbAddToBattle.Enabled = True
        End If
    End Sub
    Private Sub lbStatList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStatList.DoubleClick
        pbChangeStat.PerformClick()
    End Sub


    ' Main List Filter
    Private Sub dfFilterName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterName.TextChanged
        Dim currenttext As String = lbStatList.Text

        ResetListFromClass()
        lbStatList.SelectedIndex = lbStatList.FindStringExact(currenttext)
        lbStatList_Click(sender, e)
    End Sub
    Private Sub dfFilterLevelLow_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterLevelLow.TextChanged
        dfFilterLevelLow.Text = CStr(Val(dfFilterLevelLow.Text.Replace(",", "")))
    End Sub
    Private Sub dfFilterLevelHigh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterLevelHigh.TextChanged
        dfFilterLevelHigh.Text = CStr(Val(dfFilterLevelHigh.Text.Replace(",", "")))
    End Sub
    Private Sub dfFilterLevelLow_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterLevelLow.Validated
        If Val(dfFilterLevelLow.Text) > 40 Then
            dfFilterLevelLow.Text = 40
        ElseIf Val(dfFilterLevelLow.Text) < 1 Then
            dfFilterLevelLow.Text = 1
        End If

        If Val(dfFilterLevelHigh.Text) < Val(dfFilterLevelLow.Text) Then
            dfFilterLevelLow.Text = dfFilterLevelHigh.Text
        End If

        Dim currenttext As String = lbStatList.Text

        ResetListFromClass()
        lbStatList.SelectedIndex = lbStatList.FindStringExact(currenttext)
        lbStatList_Click(sender, e)
    End Sub
    Private Sub dfFilterLevelHigh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterLevelHigh.Validated
        If Val(dfFilterLevelHigh.Text) > 40 Then
            dfFilterLevelHigh.Text = 40
        ElseIf Val(dfFilterLevelHigh.Text) < 1 Then
            dfFilterLevelHigh.Text = 1
        End If

        If Val(dfFilterLevelHigh.Text) < Val(dfFilterLevelLow.Text) Then
            dfFilterLevelHigh.Text = dfFilterLevelLow.Text
        End If

        Dim currenttext As String = lbStatList.Text

        ResetListFromClass()
        lbStatList.SelectedIndex = lbStatList.FindStringExact(currenttext)
        lbStatList_Click(sender, e)
    End Sub
    Private Sub dfFilterRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFilterRole.SelectedIndexChanged
        Dim currenttext As String = lbStatList.Text

        ResetListFromClass()
        lbStatList.SelectedIndex = lbStatList.FindStringExact(currenttext)
        lbStatList_Click(sender, e)
    End Sub
    Private Sub pbClearMenuFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClearMenuFilter.Click
        dfFilterName.Text = ""
        dfFilterLevelLow.Text = "1"
        dfFilterLevelHigh.Text = "40"
        dfFilterRole.Text = ""
        dfFilterName_TextChanged(sender, e)
    End Sub


    ' Add to Battle List
    Private Sub lbAddToBattle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAddToBattle.Click
        If lbAddToBattle.SelectedIndex >= 0 Then
            pbClearMenuFilter_Click(sender, e)
            lbStatList.ClearSelected()
            lbStatList.SelectedIndex = lbStatList.FindStringExact(lbAddToBattle.Text)
            lbStatList_Click(sender, e)
        End If
    End Sub
    Private Sub lbAddToBattle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAddToBattle.DoubleClick
        lbStatList.SelectedItem = lbStatList.FindStringExact(lbAddToBattle.Text)
        lbStatList_Click(sender, e)
        pbChangeStat.PerformClick()
    End Sub
    Private Sub lbAddToBattle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAddToBattle.SelectedIndexChanged
        If lbAddToBattle.SelectedItems.Count > 0 Then
            pbAddListRemove.Enabled = True
        Else
            pbAddListRemove.Enabled = False
        End If
    End Sub

    Private Sub pbAddToBattle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddToBattle.Click
        If lbStatList.SelectedIndex >= 0 Then
            For Each index In lbStatList.SelectedIndices
                lbAddToBattle.Items.Add(lbStatList.Items(index))
            Next

            UpdateAddXPTotals()
        End If
    End Sub

    Private Sub pbAddListRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddListRemove.Click
        Do While lbAddToBattle.SelectedIndex >= 0
            lbAddToBattle.Items.RemoveAt(lbAddToBattle.SelectedIndex)
        Loop
        UpdateAddXPTotals()
    End Sub

    Private Sub UpdateAddXPTotals()
        Dim recalcXP As Integer = 0

        For Each handle As String In lbAddToBattle.Items
            If statlib.Contains(handle) Then
                If Not statlib(handle).bPC And Not statlib(handle).bCompanion Then
                    recalcXP += statlib(handle).nXP
                End If
            End If
        Next

        dfXP_Total.Text = (recalcXP).ToString("#,0")
        dfXPLevelFor4.Text = CStr(DnD4e_EncounterLevel(4, recalcXP))
        dfXPLevelFor5.Text = CStr(DnD4e_EncounterLevel(5, recalcXP))
        dfXPLevelFor6.Text = CStr(DnD4e_EncounterLevel(6, recalcXP))
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        Dim mon As Monster
        Dim dlgOpen As New OpenFileDialog
        Dim stat As Statblock

        With dlgOpen
            .Filter = "Monster files (*.monster)|*.monster|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Load Monster File"
            .Multiselect = True
        End With

        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each filename As String In dlgOpen.FileNames
                mon = New Monster
                If mon.LoadFromMonsterFile(filename) Then
                    If mon.Valid Then
                        stat = New Statblock
                        If stat.ConvertFromMonster(mon) Then
                            If stat.Valid Then
                                If statlib.Contains(stat.sHandle) Then
                                    If MsgBox(stat.sHandle & " already exists in the Library." & _
                                              ControlChars.NewLine & "Overwrite?", _
                                              MsgBoxStyle.OkCancel, "Statblock Found") = MsgBoxResult.Cancel Then
                                        Exit Sub
                                    End If
                                End If
                                statlib.Add(stat, True)
                                dfFilterName.Text = ""
                                ResetListFromClass()
                                lbStatList.SelectedIndex = _
                                    lbStatList.FindStringExact(stat.sHandle)
                                lbStatList_Click(sender, e)
                            End If
                        End If

                    End If
                End If
            Next
        End If
    End Sub
End Class