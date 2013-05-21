Public Class PowerRechargeWin

    ' Data elements
    Public Powers As New Hashtable
    Public Recharged As New ArrayList ' List of string names
    Public dice As DiceBag

    ' Constructor
    Public Sub New(ByVal p_sFighterName As String, ByRef p_PowersUsed As ArrayList, ByRef p_Dice As DiceBag)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Power Recharge for " & p_sFighterName
        dice = p_Dice

        If p_PowersUsed Is Nothing Then
            Powers = New Hashtable
        Else
            For Each pow As StatPower In p_PowersUsed
                Powers.Add(pow.sName, pow)
            Next
        End If
    End Sub

    ' Form Events
    Private Sub CheckboxList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPowersToList()
    End Sub
    Private Sub PowerRechargeWin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each listitem As Windows.Forms.ListViewItem In lbChecklist.Items
            If listitem.Checked Then
                Recharged.Add(listitem.Tag)
            End If
        Next
    End Sub

    ' List Events
    Private Sub pbRerollAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRerollAll.Click
        RerollAllRecharge()
    End Sub

    Private Sub pbOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub pbOk2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk2.Click
        ' Cannot set form-level Accept button to toolbar button, use hidden button instead
        pbOk_Click(sender, e)
    End Sub


    ' Functions
    Public Sub LoadPowersToList()
        lbChecklist.Items.Clear()
        For Each pow As StatPower In Powers.Values
            Dim listitem As Windows.Forms.ListViewItem = _
                    lbChecklist.Items.Add(pow.sName & " (recharge " & CStr(pow.nRechargeVal) & ")")
            listitem.Tag = pow.sName
            listitem.SubItems.Add("Disabled")
            listitem.ForeColor = Color.DarkGoldenrod
            listitem.SubItems(1).ForeColor = Color.DarkGoldenrod
            listitem.BackColor = Color.White

            listitem.Checked = False
        Next
        RerollAllRecharge()
    End Sub
    Public Sub RerollAllRecharge()
        For Each listitem As Windows.Forms.ListViewItem In lbChecklist.Items
            Dim pow As StatPower = Powers(listitem.Tag)
            Dim roll As Integer = dice.Roll(6)
            If roll >= pow.nRechargeVal Then
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
            Dim pow As StatPower = Powers(listitem.Tag)
            If listitem.Checked Then
                listitem.SubItems(1).Text = "Recharged"
                listitem.BackColor = pow.cBackColor
                listitem.ForeColor = pow.cForeColor
                listitem.SubItems(1).ForeColor = pow.cForeColor
            ElseIf Not listitem.Checked Then
                listitem.SubItems(1).Text = "Disabled"
                listitem.ForeColor = Color.DarkGoldenrod
                listitem.SubItems(1).ForeColor = Color.DarkGoldenrod
                listitem.BackColor = Color.White
            End If
        End If
    End Sub

End Class