Public Class EffectView

    ' Effect to Modify
    Public modeffect As Effect
    Public fight As Encounter

    Private nOrigID As Integer = 0
    Private nOrigRound As Integer = 0

    Private PresetEffects As New SortedList


    ' Constructors
    Public Sub New(ByRef p_fight As Encounter)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        fight = p_fight
        modeffect = New Effect
        LoadCombos()
        SetDefaults()
        LoadHistory()
    End Sub
    Public Sub New(ByRef p_fight As Encounter, ByRef eff As Effect)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        fight = p_fight
        modeffect = eff
        LoadCombos()
        MoveClassToFields(modeffect)
        LoadHistory()
    End Sub


    ' Screen setup
    Public Sub LoadCombos()
        If Not fight Is Nothing Then
            For Each fighter As Combatant In fight.Roster.Values
                dfSource.Items.Add(fighter.sCombatHandle)
                dfTarget.Items.Add(fighter.sCombatHandle)
            Next
        End If
    End Sub
    Public Sub SetDefaults()
        If fight.sCurrentFighterHandle = "" Then
            dfSource.SelectedItem = fight.sSelectedFighter
        Else
            dfSource.SelectedItem = fight.sCurrentFighterHandle
        End If
        dfTarget.SelectedItem = fight.sSelectedFighter
        dfDuration.SelectedIndex = 0
        cbBeneficial.Checked = False
        cbHidden.Checked = False
    End Sub
    Public Sub LoadHistory()
        If dfSource.Text <> "" Then
            Dim listitem As System.Windows.Forms.ListViewItem
            lbEffectsHistory.Items.Clear()
            PresetEffects.Clear()

            Dim fighter As Combatant = fight.Roster(dfSource.Text)
            For Each eff As EffectBase In fighter.Stat.PresetEffects.Values
                PresetEffectAdd(eff)
            Next

            For Each eff As EffectBase In fight.EffectsUniqueHistoryBySource(dfSource.Text)
                PresetEffectAdd(eff)
            Next

            ' Add default effects
            If dfSource.Text = dfTarget.Text Then
                PresetEffectAdd(New EffectBase("Full Defense (+2 all Def)", "Start of Source's Next Turn", True, False))
                If fighter.bPC Then
                    PresetEffectAdd(New EffectBase("Second Wind (+2 all Def)", "Start of Source's Next Turn", True, False))
                End If
            End If

            For Each eff As EffectBase In PresetEffects.Values
                listitem = lbEffectsHistory.Items.Add(eff.sName)
                listitem.SubItems.Add("     Duration: " & eff.sDuration)
                listitem.Tag = eff.sEffectBaseID
                listitem.ForeColor = Color.White
                listitem.SubItems(1).ForeColor = Color.LightGray
                If eff.bBeneficial Then
                    listitem.BackColor = Color.DarkGreen
                Else
                    listitem.BackColor = Color.DarkRed
                End If
            Next
        End If
    End Sub
    Public Sub PresetEffectAdd(ByRef eff As EffectBase)
        If eff.bValid And Not PresetEffects.Contains(eff.sEffectBaseID) Then
            PresetEffects.Add(eff.sEffectBaseID, eff)
        End If
    End Sub


    ' Data load/save
    Sub MoveClassToFields(ByRef eff As Effect)
        dfName.Text = eff.sName
        dfSource.SelectedItem = eff.sSourceHandle
        dfTarget.SelectedItem = eff.sTargetHandle
        dfDuration.SelectedItem = eff.sDuration
        cbBeneficial.Checked = eff.bBeneficial
        cbHidden.Checked = eff.bHidden
        nOrigID = eff.nEffectID
        nOrigRound = eff.nRoundTill
    End Sub
    Sub MoveFieldsToClass(ByRef eff As Effect)
        eff.sName = dfName.Text
        eff.sSourceHandle = dfSource.Text
        eff.sTargetHandle = dfTarget.Text
        eff.sDuration = dfDuration.Text
        eff.bBeneficial = cbBeneficial.Checked
        eff.bHidden = cbHidden.Checked
        eff.nEffectID = nOrigID
        eff.nRoundTill = nOrigRound
    End Sub


    ' Control logic
    Private Sub pbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCancel.Click
        modeffect = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub pbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSave.Click
        If dfName.Text = "" Or dfSource.Text = "" Or dfTarget.Text = "" Or dfDuration.Text = "" Then
            MsgBox("Please assign a Name, Source, Target, and Duration to" & ControlChars.NewLine & _
                   "this Effect.  It cannot be added until" & ControlChars.NewLine & _
                   "these values are assigned.", MsgBoxStyle.OkOnly, "Missing Information")
        Else
            modeffect = New Effect
            MoveFieldsToClass(modeffect)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub dfSource_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfSource.SelectedValueChanged
        LoadHistory()
    End Sub
    Private Sub dfTarget_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfTarget.SelectedValueChanged
        LoadHistory()
    End Sub

    Private Sub lbEffectsHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEffectsHistory.Click
        If lbEffectsHistory.SelectedItems.Count > 0 Then
            Dim eff As EffectBase = PresetEffects(lbEffectsHistory.SelectedItems(0).Tag)
            If Not eff Is Nothing Then
                dfName.Text = eff.sName
                dfDuration.SelectedItem = eff.sDuration
                cbBeneficial.Checked = eff.bBeneficial
                cbHidden.Checked = eff.bHidden
            End If
        End If
    End Sub
    Private Sub lbEffectsHistory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEffectsHistory.DoubleClick
        lbEffectsHistory_Click(sender, e)
        pbSave.PerformClick()
    End Sub

End Class