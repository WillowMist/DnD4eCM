Public Class SavingThrowWin

    ' Data elements
    Public Effects As New Hashtable
    Public SuccessfulSaves As New ArrayList ' List of integer IDs
    Public dice As DiceBag

    ' Constructor
    Public Sub New(ByRef p_Effects As ArrayList, ByVal p_savebonus As Integer, ByRef p_Dice As DiceBag)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dice = p_Dice
        dfSaveBonus.Text = CStr(p_savebonus)

        If p_Effects Is Nothing Then
            Effects = New Hashtable
        Else
            For Each eff As Effect In p_Effects
                eff.SetActive()
                Effects.Add(eff.nEffectID, eff)
            Next
        End If
    End Sub


    ' Form Events
    Private Sub CheckboxList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadEffectsToList()
    End Sub
    Private Sub SavingThrowWin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each listitem As Windows.Forms.ListViewItem In lbChecklist.Items
            If listitem.Checked Then
                SuccessfulSaves.Add(listitem.Tag)
            End If
        Next
    End Sub

    ' List Events
    Private Sub dfSaveBonus_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfSaveBonus.Validated
        dfSaveBonus.Text = Val(dfSaveBonus.Text.Replace(",", "")).ToString("0")
    End Sub
    Private Sub pbRerollAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRerollAll.Click
        RerollAllSaves()
    End Sub

    Private Sub pbOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub pbOk2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk2.Click
        ' Cannot set form-level Accept button to toolbar button, use hidden button instead
        pbOk_Click(sender, e)
    End Sub


    ' Functions
    Public Sub LoadEffectsToList()
        lbChecklist.Items.Clear()
        For Each eff As Effect In Effects.Values
            Dim listitem As Windows.Forms.ListViewItem = lbChecklist.Items.Add(eff.sName)
            listitem.Tag = eff.nEffectID
            listitem.SubItems.Add("Failed")
            listitem.Checked = False
            listitem.ForeColor = Color.White
            listitem.SubItems(1).ForeColor = Color.White
        Next
        RerollAllSaves()
    End Sub
    Public Sub RerollAllSaves()
        For Each listitem As Windows.Forms.ListViewItem In lbChecklist.Items
            Dim roll As Integer = dice.Roll(20) + Val(dfSaveBonus.Text)
            If roll >= 10 Then
                listitem.Checked = False ' Make sure the event fires
                listitem.Checked = True
            Else
                listitem.Checked = True ' Make sure the event fires
                listitem.Checked = False
            End If
            listitem.SubItems(1).Text &= " (roll=" & CStr(roll) & ")"
        Next
    End Sub

    Private Sub lbChecklist_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lbChecklist.ItemChecked
        Dim listitem As Windows.Forms.ListViewItem = e.Item

        If listitem.SubItems.Count > 1 Then
            If listitem.Checked Then
                listitem.SubItems(1).Text = "Successful"
                listitem.BackColor = Color.DarkGreen
            ElseIf Not listitem.Checked Then
                listitem.SubItems(1).Text = "Failed"
                listitem.BackColor = Color.DarkRed
            End If
        End If
    End Sub

End Class