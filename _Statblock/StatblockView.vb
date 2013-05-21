Public Class StatblockView

    ' Statblock to Modify
    Public stat As Statblock
    Public statpowers As ArrayList
    Public preseteffects As SortedList
    Private bPowerChanged As Boolean


    ' Constructors
    Public Sub New(ByRef p_statblock As Statblock)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        statpowers = New ArrayList
        preseteffects = New SortedList

        stat = p_statblock
        MoveClassToFields(stat)
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        statpowers = New ArrayList
        preseteffects = New SortedList
    End Sub


    ' Page Load Action
    Private Sub StatblockView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PowDataDisable()
        PowDataClear()
        pbPowDelete.Enabled = False
        pbPowUp.Enabled = False
        pbPowDown.Enabled = False

        pbEffectDelete.Enabled = False
        ClearEffect()
    End Sub


    ' Data load/save
    Sub MoveClassToFields(ByRef stat As Statblock)

        ' Basic Info
        dfName.Text = stat.sName
        dfLevel.Value = stat.nLevel
        dfRole.SelectedItem = stat.sRole
        dfRole2.SelectedItem = stat.sRole2
        cbLeader.Checked = stat.bLeader
        cbNotesOnly.Checked = stat.bNotesOnly
        dfType.Text = stat.sType
        dfXP.Text = stat.nXP.ToString("#,0")

        ' Basic Capabilities
        dfSenses.Text = stat.sSenses
        dfSpeed.Text = stat.sSpeed

        ' Damage Mods
        dfImmune.Text = stat.sImmune
        dfResist.Text = stat.sResist
        dfVuln.Text = stat.sVuln
        dfRegen.Text = stat.sRegen

        ' Combat Stats
        dfInit.Text = CStr(stat.nInit)
        dfSaveBonus.Text = CStr(stat.nSaveBonus)
        dfActionPoints.Text = CStr(stat.nActionPoints)
        dfPowerPoints.Text = CStr(stat.nPowerPoints)
        dfMaxHP.Text = stat.nMaxHP.ToString("#,0")
        dfSurges.Text = stat.nSurges.ToString("#,0")
        SetBloodyHP()

        ' Defenses
        dfAC.Text = CStr(stat.nAC)
        dfFort.Text = CStr(stat.nFort)
        dfReflex.Text = CStr(stat.nRef)
        dfWill.Text = CStr(stat.nWill)

        ' Attributes
        dfStr.Text = CStr(stat.nStr)
        dfDex.Text = CStr(stat.nDex)
        dfCon.Text = CStr(stat.nCon)
        dfInt.Text = CStr(stat.nInt)
        dfWis.Text = CStr(stat.nWis)
        dfCha.Text = CStr(stat.nCha)

        ' Other Traits
        dfAlignment.Text = stat.sAlignment
        dfSkills.Text = stat.sSkills
        dfFeats.Text = stat.sFeats
        dfLanguages.Text = stat.sLanguages
        dfEquipment.Text = stat.sEquipment
        dfSource.Text = stat.sSource
        dfNotes.Text = stat.sNotes
        dfDesc.Text = stat.sDesc
        dfTrap.Text = stat.sTrap
        dfHazard.Text = stat.sHazard
        dfPuzzle.Text = stat.sPuzzle
        dfDisplayName.Text = stat.sDisplayName

        ' Powers
        statpowers.Clear()
        For Each pow As StatPower In stat.PowerList
            statpowers.Add(New StatPower(pow))
        Next
        ResetPowerListFromArray()

        For Each eff As EffectBase In stat.PresetEffects.Values
            PresetEffectAdd(New EffectBase(eff))
        Next
        ResetEffectListFromArray()
    End Sub
    Sub MoveFieldsToClass(ByRef stat As Statblock)
        ' Basic Info
        stat.sName = dfName.Text
        stat.nLevel = dfLevel.Value
        stat.sRole = dfRole.Text
        stat.sRole2 = dfRole2.Text
        stat.bLeader = cbLeader.Checked
        stat.bNotesOnly = cbNotesOnly.Checked
        stat.sType = dfType.Text
        stat.nXP = Val(dfXP.Text.Replace(",", ""))

        ' Basic Capabilities
        stat.sSenses = dfSenses.Text
        stat.sSpeed = dfSpeed.Text

        ' Damage Mods
        stat.sImmune = dfImmune.Text
        stat.sResist = dfResist.Text
        stat.sVuln = dfVuln.Text
        stat.sRegen = dfRegen.Text

        ' Combat Stats
        stat.nInit = Val(dfInit.Text.Replace(",", ""))
        stat.nSaveBonus = Val(dfSaveBonus.Text.Replace(",", ""))
        stat.nActionPoints = Val(dfActionPoints.Text)
        stat.nPowerPoints = Val(dfPowerPoints.Text)
        stat.nMaxHP = Val(dfMaxHP.Text.Replace(",", ""))
        stat.nSurges = Val(dfSurges.Text.Replace(",", ""))

        ' Defenses
        stat.nAC = Val(dfAC.Text.Replace(",", ""))
        stat.nFort = Val(dfFort.Text.Replace(",", ""))
        stat.nRef = Val(dfReflex.Text.Replace(",", ""))
        stat.nWill = Val(dfWill.Text.Replace(",", ""))

        ' Attributes
        stat.nStr = Val(dfStr.Text.Replace(",", ""))
        stat.nDex = Val(dfDex.Text.Replace(",", ""))
        stat.nCon = Val(dfCon.Text.Replace(",", ""))
        stat.nInt = Val(dfInt.Text.Replace(",", ""))
        stat.nWis = Val(dfWis.Text.Replace(",", ""))
        stat.nCha = Val(dfCha.Text.Replace(",", ""))

        ' Other Traits
        stat.sAlignment = dfAlignment.Text
        stat.sSkills = dfSkills.Text
        stat.sFeats = dfFeats.Text
        stat.sLanguages = dfLanguages.Text
        stat.sEquipment = dfEquipment.Text
        stat.sSource = dfSource.Text
        stat.sNotes = dfNotes.Text
        stat.sDesc = dfDesc.Text
        stat.sTrap = dfTrap.Text
        stat.sHazard = dfHazard.Text
        stat.sPuzzle = dfPuzzle.Text
        stat.sDisplayName = dfDisplayName.Text

        ' Powers
        stat.PowerList.Clear()
        For Each pow As StatPower In statpowers
            If pow.sName <> "" Then
                stat.PowerList.Add(New StatPower(pow))
            End If
        Next

        ' Effects
        stat.PresetEffects.Clear()
        For Each eff As EffectBase In preseteffects.Values
            stat.PresetEffectAdd(New EffectBase(eff))
        Next
    End Sub


    ' Calculation Functions
    Sub SetBloodyHP()
        If CInt(dfMaxHP.Text) = 1 Then
            dfBloodyHP.Text = "Minion"
        Else
            dfBloodyHP.Text = (Val(dfMaxHP.Text.Replace(",", "")) \ 2).ToString("#,0")
        End If
    End Sub


    ' Dropdown validations
    Private Sub cbPC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPC.CheckedChanged
        If cbPC.Checked Then
            dfRole.Text = "Hero"
            dfRole2.Text = ""
            cbLeader.Checked = False

            dfRole2.Enabled = False
            cbLeader.Enabled = False
        Else
            dfRole2.Enabled = True
            cbLeader.Enabled = True
            If dfRole.Text = "Hero" Then
                dfRole.Text = ""
            End If
        End If
    End Sub
    Private Sub dfRole_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dfRole.SelectedIndexChanged
        If dfRole.Text = "Hero" And cbPC.Checked = False Then
            cbPC.Checked = True
        ElseIf dfRole.Text <> "Hero" And cbPC.Checked = True Then
            cbPC.Checked = False
        End If
    End Sub


    ' Number Field Validations
    Private Sub dfAC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfAC.Validated
        dfAC.Text = Val(dfAC.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfActionPoints_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfActionPoints.Validated
        dfActionPoints.Text = Val(dfActionPoints.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfPowerPoints_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowerPoints.Validated
        dfPowerPoints.Text = Val(dfPowerPoints.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfCha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfCha.Validated
        dfCha.Text = Val(dfCha.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfCon_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfCon.Validated
        dfCon.Text = Val(dfCon.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfDex_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfDex.Validated
        dfDex.Text = Val(dfDex.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfFort_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfFort.Validated
        dfFort.Text = Val(dfFort.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfInit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfInit.Validated
        dfInit.Text = Val(dfInit.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfInt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfInt.Validated
        dfInt.Text = Val(dfInt.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfMaxHP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfMaxHP.Validated
        dfMaxHP.Text = Val(dfMaxHP.Text.Replace(",", "")).ToString("#,0")
        SetBloodyHP()
    End Sub
    Private Sub dfReflex_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfReflex.Validated
        dfReflex.Text = Val(dfReflex.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfSaveBonus_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfSaveBonus.Validated
        dfSaveBonus.Text = Val(dfSaveBonus.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfStr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfStr.Validated
        dfStr.Text = Val(dfStr.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfWill_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfWill.Validated
        dfWill.Text = Val(dfWill.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfWis_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfWis.Validated
        dfWis.Text = Val(dfWis.Text.Replace(",", "")).ToString("#,0")
    End Sub
    Private Sub dfXP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfXP.Validated
        dfXP.Text = Val(dfXP.Text.Replace(",", "")).ToString("#,0")
    End Sub


    ' Save/Cancel/Import Buttons
    Private Sub pbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCancel.Click
        stat = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub pbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSave.Click
        stat = New Statblock
        MoveFieldsToClass(stat)

        If Not stat.Valid Then
            MsgBox("Please assign a Name, Level, and Role to" & ControlChars.NewLine & _
                   "this Statblock.  It cannot be saved until" & ControlChars.NewLine & _
                   "these values are assigned.", MsgBoxStyle.OkOnly, "Missing Information")
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Sub pbPasteRTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPasteRTF.Click
        If My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then
            stat = New Statblock
            stat.Statblock_RTF = My.Computer.Clipboard.GetText(TextDataFormat.Rtf)
            If stat.Valid Then MoveClassToFields(stat)
        End If
    End Sub
    Private Sub pbLoadCharFromCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLoadCharFromCB.Click
        stat = New Statblock

        Dim dlgOpen As New OpenFileDialog

        With dlgOpen
            .Filter = "Character files (*.dnd4e)|*.dnd4e|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Load Character File"
        End With

        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If stat.LoadFromCBFile(dlgOpen.FileName) Then
                If stat.Valid Then MoveClassToFields(stat)
            End If
        End If
    End Sub


    ' Power List handling
    Sub ResetPowerListFromArray()
        Dim newpower As System.Windows.Forms.ListViewItem

        lbPowerList.Items.Clear()
        For Each pow As StatPower In statpowers
            newpower = lbPowerList.Items.Add(pow.sName)

            If pow.bAura Then
                If pow.sKeywords <> "" Then
                    newpower.SubItems.Add("   " & pow.Type & " (" & pow.sKeywords & ")")
                Else
                    newpower.SubItems.Add("   " & pow.Type)
                End If
            Else
                If pow.sType <> "" And pow.sAction <> "" Then
                    newpower.SubItems.Add("   " & pow.Type & " (" & pow.sAction & ")")
                ElseIf pow.sAction <> "" Then
                    newpower.SubItems.Add("   (" & pow.sAction & ")")
                ElseIf pow.sType <> "" Then
                    newpower.SubItems.Add("   " & pow.Type)
                Else
                    newpower.SubItems.Add("   (constant)")
                End If
            End If
        Next
        bPowerChanged = False
    End Sub
    Private Sub lbPowerList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPowerList.SelectedIndexChanged
        Dim powindex As Integer
        If lbPowerList.SelectedIndices.Count > 0 Then
            powindex = lbPowerList.SelectedIndices(0)
            PowDataEnable()
            PowDataLoad(powindex)
            pbPowDelete.Enabled = True

            If lbPowerList.Items.Count > 1 And lbPowerList.SelectedIndices(0) > 0 Then
                pbPowUp.Enabled = True
            Else
                pbPowUp.Enabled = False
            End If
            If lbPowerList.Items.Count > 1 And lbPowerList.SelectedIndices(0) < lbPowerList.Items.Count - 1 Then
                pbPowDown.Enabled = True
            Else
                pbPowDown.Enabled = False
            End If
        Else
            PowDataDisable()
            PowDataClear()
            pbPowDelete.Enabled = False
            pbPowUp.Enabled = False
            pbPowDown.Enabled = False
            If bPowerChanged Then
                ResetPowerListFromArray()
            End If
        End If
    End Sub

    ' Power Data handling
    Private Sub PowDataEnable()
        dfPowName.Enabled = True
        dfPowKeywords.Enabled = True
        dfPowURL.Enabled = True
        dfPowAction.Enabled = True
        dfPowDesc.Enabled = True
        cbPowAura.Enabled = True
        cbPowAura.Visible = True
        If cbPowAura.Checked Then
            dfPowAuraSize.Enabled = True
            dfPowAuraSize.Visible = True
            dfPowType.Enabled = False
        Else
            dfPowAuraSize.Enabled = False
            dfPowAuraSize.Visible = False
            dfPowType.Enabled = True
        End If
    End Sub
    Private Sub PowDataDisable()
        dfPowName.Enabled = False
        dfPowKeywords.Enabled = False
        dfPowURL.Enabled = False
        dfPowAction.Enabled = False
        dfPowDesc.Enabled = False
        cbPowAura.Enabled = False
        cbPowAura.Visible = False
        dfPowAuraSize.Enabled = False
        dfPowAuraSize.Visible = False
        dfPowType.Enabled = False
    End Sub
    Private Sub PowDataClear()
        dfPowName.Text = ""
        dfPowType.SelectedIndex = 0
        dfPowKeywords.Text = ""
        dfPowURL.Text = ""
        dfPowAction.Text = ""
        dfPowAuraSize.Text = "0"
        cbPowAura.Checked = False
        dfPowType.Enabled = False
        dfPowAuraSize.Visible = False
        dfPowAuraSize.Enabled = False
        dfPowDesc.Text = ""
    End Sub
    Private Sub PowDataLoad(ByVal index As Integer)
        If index < statpowers.Count Then
            Dim pow As StatPower = statpowers.Item(index)

            dfPowName.Text = pow.sName
            dfPowKeywords.Text = pow.sKeywords
            dfPowURL.Text = pow.sURL
            dfPowAction.Text = pow.sAction
            dfPowDesc.Text = pow.Desc
            If pow.bAura Then
                dfPowType.SelectedIndex = 0
                dfPowType.Enabled = False
                cbPowAura.Checked = True
                dfPowAuraSize.Visible = True
                dfPowAuraSize.Enabled = True
                dfPowAuraSize.Value = pow.nAura
            Else
                dfPowType.SelectedItem = pow.Type
                dfPowType.Enabled = True
                cbPowAura.Checked = False
                dfPowAuraSize.Visible = False
                dfPowAuraSize.Enabled = False
                dfPowAuraSize.Value = 0
            End If
            bPowerChanged = False
        End If
    End Sub

    ' Power Data validations
    Private Sub cbPowAura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPowAura.CheckedChanged
        If cbPowAura.Checked Then
            dfPowType.Enabled = False
            dfPowAuraSize.Visible = True
            dfPowAuraSize.Enabled = True
            If Val(dfPowAuraSize.Text) < 1 Then
                dfPowAuraSize.Text = "1"
                dfPowAuraSize.Select()
            End If
        Else
            dfPowType.Enabled = True
            dfPowAuraSize.Visible = False
            dfPowAuraSize.Enabled = False
            If Val(dfPowAuraSize.Text) > 0 Then
                dfPowAuraSize.Text = "0"
                dfPowAuraSize.Select()
            End If
        End If
        bPowerChanged = True
    End Sub
    Public ReadOnly Property PowerDataValid() As Boolean
        Get
            If lbPowerList.SelectedIndices.Count < 1 Then
                PowDataDisable()
                PowDataClear()
                Return False
            Else
                If lbPowerList.SelectedIndices(0) >= statpowers.Count Then
                    PowDataDisable()
                    PowDataClear()
                    Return False
                End If
            End If

            Return True
        End Get
    End Property
    Private Sub dfPowName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowName.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            If dfPowName.Text = "" Then
                dfPowName.Text = "(no name)"
            End If
            pow.sName = dfPowName.Text
            bPowerChanged = True
        End If
    End Sub
    Private Sub dfPowType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowType.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.Type = dfPowType.Text
            bPowerChanged = True
        End If
    End Sub
    Private Sub dfPowKeywords_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowKeywords.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.sKeywords = dfPowKeywords.Text
            bPowerChanged = True
        End If
    End Sub
    Private Sub dfPowURL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowURL.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.sURL = dfPowURL.Text
            bPowerChanged = True
        End If
    End Sub

    Private Sub dfPowAction_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowAction.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.sAction = dfPowAction.Text
            bPowerChanged = True
        End If
    End Sub
    Private Sub dfPowDesc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dfPowDesc.Validated
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.Desc = dfPowDesc.Text
            bPowerChanged = True
        End If
    End Sub
    Private Sub dfPowAuraSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dfPowAuraSize.Validating
        If PowerDataValid Then
            Dim pow As StatPower = statpowers.Item(lbPowerList.SelectedIndices(0))
            pow.nAura = dfPowAuraSize.Value
            bPowerChanged = True
        End If
    End Sub


    ' Power List Buttons
    Private Sub pbPowNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbPowNew.Click
        Dim power As New StatPower()
        Dim index As Integer = statpowers.Add(power)
        ResetPowerListFromArray()
        lbPowerList.SelectedIndices.Clear()
        lbPowerList.SelectedIndices.Add(index)
        lbPowerList.Items(index).EnsureVisible()
    End Sub
    Private Sub pbPowDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbPowDelete.Click
        If PowerDataValid Then
            statpowers.RemoveAt(lbPowerList.SelectedIndices(0))
            ResetPowerListFromArray()
            lbPowerList_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Private Sub pbPowUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbPowUp.Click
        If PowerDataValid Then
            Dim index As Integer = lbPowerList.SelectedIndices(0)
            If index > 0 Then
                Dim temppow As StatPower = statpowers(index)
                statpowers(index) = statpowers(index - 1)
                index = index - 1
                statpowers(index) = temppow
                ResetPowerListFromArray()
                lbPowerList.SelectedIndices.Clear()
                lbPowerList.SelectedIndices.Add(index)
                lbPowerList.Items(index).EnsureVisible()
                lbPowerList_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub
    Private Sub pbPowDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbPowDown.Click
        If PowerDataValid Then
            Dim index As Integer = lbPowerList.SelectedIndices(0)
            If index < lbPowerList.Items.Count - 1 Then
                Dim temppow As StatPower = statpowers(index)
                statpowers(index) = statpowers(index + 1)
                index = index + 1
                statpowers(index) = temppow
                ResetPowerListFromArray()
                lbPowerList.SelectedIndices.Clear()
                lbPowerList.SelectedIndices.Add(index)
                lbPowerList.Items(index).EnsureVisible()
                lbPowerList_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub


    ' Effect handling
    Public Sub PresetEffectAdd(ByRef eff As EffectBase)
        If eff.bValid And Not preseteffects.Contains(eff.sEffectBaseID) Then
            preseteffects.Add(eff.sEffectBaseID, eff)
        End If
    End Sub
    Public Sub ClearEffect()
        dfEffectName.Text = ""
        dfEffectDuration.Text = ""
        cbEffectBeneficial.Checked = False
        cbEffectHidden.Checked = False
    End Sub
    Sub ResetEffectListFromArray()
        Dim listitem As System.Windows.Forms.ListViewItem

        lbEffectsHistory.Items.Clear()
        pbEffectDelete.Enabled = False
        For Each eff As EffectBase In preseteffects.Values
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
    End Sub
    Private Sub pbEffectAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEffectAdd.Click
        Dim eff As New EffectBase(dfEffectName.Text, dfEffectDuration.Text, cbEffectBeneficial.Checked, cbEffectHidden.Checked)
        If eff.bValid Then
            PresetEffectAdd(eff)
            ClearEffect()
            ResetEffectListFromArray()
        Else
            MsgBox("Please assign a Name and Duration to" & ControlChars.NewLine & _
                   "the Effect.  It cannot be added until" & ControlChars.NewLine & _
                   "these values are assigned.", MsgBoxStyle.OkOnly, "Missing Effect Info")
        End If
    End Sub
    Private Sub pbEffectDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEffectDelete.Click
        If lbEffectsHistory.SelectedIndices.Count > 0 Then
            Dim effID As String = lbEffectsHistory.SelectedItems(0).Tag
            preseteffects.Remove(effID)
            ResetEffectListFromArray()
        End If
    End Sub
    Private Sub lbEffectsHistory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEffectsHistory.SelectedIndexChanged
        If lbEffectsHistory.SelectedIndices.Count > 0 Then
            pbEffectDelete.Enabled = True
        Else
            pbEffectDelete.Enabled = False
        End If
    End Sub

    Private Sub dfName_EnterPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dfName.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            pbSave_Click(sender, e)

            'This tells the system not to process
            'the key, as you've already taken care 
            'of it 
            e.Handled = True
        End If
    End Sub
End Class