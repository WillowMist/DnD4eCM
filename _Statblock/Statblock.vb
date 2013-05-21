Imports _4eMonster

Public Class Statblock

    ' Main Data Elements
    Public sName, sType, sRole, sRole2 As String
    Public sSenses, sSpeed, sResist, sImmune, sVuln, sRegen As String
    Public sAlignment, sSkills, sLanguages, sEquipment, sSource, sFeats, sDisplayName As String
    Public nLevel, nXP, nInit, nMaxHP, nSaveBonus, nActionPoints, nPowerPoints, nSurges As Integer
    Public nAC, nFort, nRef, nWill As Integer
    Public nStr, nDex, nWis, nCon, nInt, nCha As Integer
    Public bLeader, bNotesOnly As Boolean
    Public PowerList As New ArrayList
    Public PresetEffects As New Hashtable
    Public sDesc, sTrap, sHazard, sPuzzle As String
    Private sNotesBase As String


    ' Properties
    Public ReadOnly Property nBloodyHP() As Integer
        Get
            Return (nMaxHP \ 2)
        End Get
    End Property
    Public ReadOnly Property nSurgeValue() As Integer
        Get
            If sType.ToLower.Contains("dragonborn") Then
                Return (nMaxHP \ 4) + DnD4e_CalcStatBonus(nCon)
            Else
                Return nMaxHP \ 4
            End If
        End Get
    End Property
    Public ReadOnly Property sHandle() As String
        Get
            If Valid Then
                Dim handle As String = sRole.Substring(0, 2) & CStr(nLevel)

                If sRole2 <> "" Then
                    handle &= sRole2.Substring(0, 1)
                End If

                If bPC Then
                    Return "* " & sName & " (" & handle & ")"
                Else
                    Return sName & " (" & handle & ")"
                End If
            Else
                Return "(invalid)"
            End If
        End Get
    End Property
    Public Property sLevelRole() As String
        Get
            Dim levelrole As New System.Text.StringBuilder

            levelrole.Append("Level " & CStr(nLevel))

            If sRole2 <> "" Then
                levelrole.Append(" " & sRole2)
            End If

            levelrole.Append(" " & sRole)

            If bLeader Then
                levelrole.Append(" (Leader)")
            End If

            Return levelrole.ToString
        End Get
        Set(ByVal line As String)
            line = line.ToLower.Trim

            ' Get Level
            nLevel = Val(line.Substring(line.IndexOf(" ")))

            ' Get primary Role
            If line.Contains("soldier") Then
                sRole = "Soldier"
            ElseIf line.Contains("brute") Then
                sRole = "Brute"
            ElseIf line.Contains("skirmisher") Then
                sRole = "Skirmisher"
            ElseIf line.Contains("lurker") Then
                sRole = "Lurker"
            ElseIf line.Contains("artillery") Then
                sRole = "Artillery"
            ElseIf line.Contains("controller") Then
                sRole = "Controller"
            ElseIf line.Contains("hero") Then
                sRole = "Hero"
            ElseIf line.Contains("obstacle") Then
                sRole = "Obstacle"
            ElseIf line.Contains("warder") Then
                sRole = "Warder"
            ElseIf line.Contains("blaster") Then
                sRole = "Blaster"
            ElseIf line.Contains("puzzle") Then
                sRole = "Puzzle"
            Else
                sRole = "Unspecified"
            End If

            ' Get Secondary Role
            If line.Contains("elite") Then
                sRole2 = "Elite"
            ElseIf line.Contains("solo") Then
                sRole2 = "Solo"
            ElseIf line.Contains("companion") Then
                sRole2 = "Companion"
            ElseIf line.Contains("minion") Then
                sRole2 = "Minion"
            Else
                sRole2 = ""
            End If

            ' Check for leader
            If line.Contains("(leader)") Then
                bLeader = True
            Else
                bLeader = False
            End If
        End Set
    End Property
    Public ReadOnly Property Valid() As Boolean
        Get
            If sName = "" Then
                Return False
            ElseIf nLevel < 1 Then
                Return False
            ElseIf sRole = "" Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Public ReadOnly Property bPC() As Boolean
        Get
            If sRole = "Hero" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bCompanion()
        Get
            If sRole2 = "Companion" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bMinion() As Boolean
        Get
            If nMaxHP = 1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property bTrapHazard()
        Get
            If sTrap <> "" Or sHazard <> "" Or sPuzzle <> "" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property sNotes() As String
        Get
            Return sNotesBase.Replace("###", ControlChars.NewLine)
        End Get
        Set(ByVal value As String)
            sNotesBase = value.Replace(ControlChars.NewLine, "###")
        End Set
    End Property

    ' Preset effect functions
    Public Sub PresetEffectAdd(ByRef eff As EffectBase)
        If eff.bValid And Not PresetEffects.Contains(eff.sEffectBaseID) Then
            PresetEffects.Add(eff.sEffectBaseID, eff)
        End If
    End Sub


    ' Constructor/Reset Functions
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef tocopy As Statblock)
        Copy(tocopy)
    End Sub
    Sub ClearAll()
        ' Clear strings
        sName = ""
        sRole = ""
        sRole2 = ""
        bLeader = False
        bNotesOnly = False
        sType = ""
        sSenses = ""
        sResist = ""
        sImmune = ""
        sVuln = ""
        sSpeed = ""
        sRegen = ""
        sAlignment = ""
        sSkills = ""
        sLanguages = ""
        sEquipment = ""
        sSource = ""
        sFeats = ""
        sDisplayName = ""
        sNotesBase = ""

        ' Clear numerics
        nLevel = 0
        nXP = 0
        nInit = 0
        nMaxHP = 0
        nAC = 0
        nFort = 0
        nRef = 0
        nWill = 0
        nSaveBonus = 0
        nActionPoints = 0
        nPowerPoints = 0
        nSurges = 0
        nStr = 0
        nDex = 0
        nWis = 0
        nCon = 0
        nInt = 0
        nCha = 0

        ' Clear powers
        PowerList.Clear()
        PresetEffects.Clear()
    End Sub


    ' RTF Import/Export
    Public Property Statblock_RTF() As String
        Get
            Return Statblock_RTF_Out()
        End Get
        Set(ByVal value As String)
            Statblock_DetailImport(ImportRTF_ToDetails(value))
        End Set
    End Property
    Public Property Statblock_HTML() As String
        Get
            Return Statblock_HTML_Out()
        End Get
        Set(ByVal value As String)
            Statblock_HTMLImport(value)
        End Set
    End Property

    ' Text Processing Functions
    Private Sub Statblock_HTMLImport(ByVal input As String)
        sNotes = input
        bNotesOnly = True
        Dim StartString, EndString As String
        StartString = "<h1 class=" + Chr(34) + "monster" + Chr(34) + ">"
        EndString = "<br/>"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            sName = sNotes.Substring(start + 20, endpoint - 20)
        End If
        StartString = "<h1 class=" + Chr(34) + "trap" + Chr(34) + ">"
        EndString = "<br/>"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            sName = sNotes.Substring(start + 17, endpoint - 17)
            sTrap = sNotes.Substring(start + 17, endpoint - 17)
        End If
        StartString = "<span class=" + Chr(34) + "type" + Chr(34) + ">"
        EndString = "</span>"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            sType = sNotes.Substring(start + 19, endpoint - 19)
        End If
        StartString = "<span class=" + Chr(34) + "level" + Chr(34) + ">"
        EndString = "<span class=" + Chr(34) + "xp" + Chr(34) + ">"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            sLevelRole = sNotes.Substring(start + 20, endpoint - 20)
        End If
        StartString = "<span class=" + Chr(34) + "xp" + Chr(34) + ">"
        EndString = "</span>"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            nXP = Val(sNotes.Substring(start + 21))
        End If
        StartString = "<b>HP</b>"
        EndString = ";"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            nMaxHP = Val(sNotes.Substring(start + 9))
        End If
        StartString = "<b>Initiative</b>"
        EndString = "</td>"
        If sNotes.Contains(StartString) Then
            Dim start As Integer = sNotes.IndexOf(StartString)
            Dim endpoint As Integer = sNotes.Substring(start).IndexOf(EndString)
            nInit = Val(sNotes.Substring(start + 17))
        End If
    End Sub
    Private Sub Statblock_DetailImport(ByVal input As String)
        Dim lines, lines2 As String()
        Dim head, tail, head2, tail2 As String
        Dim CurrentSection As String = "Senses"

        lines = input.Split(ControlChars.NewLine)

        If lines(0) <> "@4eSB001" Then
            Return
        End If

        ' Clear prior values
        ClearAll()

        ' Process input string
        For Each line As String In lines
            If line.Contains("Str ") Or line.Contains("Con ") Or line.Contains("Skills ") Then
                line = line.Substring(4).Trim
            End If
            If line.IndexOf(" ") > 0 Then
                line = line.Trim()
                head = line.Substring(0, line.IndexOf(" ")).Trim
                tail = line.Substring(line.IndexOf(" ")).Trim
            Else
                line = line.Trim
                head = line.Trim
                tail = ""
            End If
            If head = "Level" Then
                sLevelRole = line
            ElseIf head = "XP" Then
                nXP = Val(tail.Replace(",", ""))
            ElseIf head = "Initiative" Then
                nInit = Val(tail.Replace("+", ""))
            ElseIf head = "Senses" And sSenses = "" Then
                sSenses = tail
            ElseIf head = "HP" And nMaxHP = 0 Then
                nMaxHP = Val(tail.Substring(0, tail.IndexOf(";")).Replace(",", ""))
            ElseIf head = "AC" And nAC = 0 Then
                lines2 = line.Split(";")
                For Each line2 As String In lines2
                    line2 = line2.Trim
                    head2 = line2.Substring(0, line2.IndexOf(" ")).Trim
                    tail2 = line2.Substring(line2.IndexOf(" ")).Trim
                    If head2 = "AC" Then
                        nAC = Val(tail2)
                    ElseIf head2 = "Fortitude" Then
                        nFort = Val(tail2)
                    ElseIf head2 = "Reflex" Then
                        nRef = Val(tail2)
                    ElseIf head2 = "Will" Then
                        nWill = Val(tail2)
                    End If
                Next
            ElseIf head = "Vulnerability" And sVuln = "" Then
                sVuln = tail
            ElseIf head = "Immune" And sImmune = "" Then
                sImmune = tail
            ElseIf head = "Resist" And sResist = "" Then
                sResist = tail
            ElseIf head = "Regeneration" And sRegen = "" Then
                sRegen = tail
            ElseIf line.StartsWith("Saving Throws") Then
                tail = tail.Substring(tail.IndexOf(" ")).Trim
                nSaveBonus = Val(tail.Replace("+", ""))
            ElseIf head = "Speed" And sSpeed = "" Then
                sSpeed = tail
            ElseIf line.StartsWith("Action Points") Then
                tail = tail.Substring(tail.IndexOf(" ")).Trim
                nActionPoints = Val(tail)
            ElseIf head = "Alignment" And sAlignment = "" Then
                sAlignment = tail
            ElseIf head = "Str" Then
                nStr = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Dex" Then
                nDex = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Wis" Then
                nWis = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Con" Then
                nCon = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Int" Then
                nInt = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Cha" Then
                nCha = Val(tail.Substring(0, 2).Trim)
            ElseIf head = "Languages" And sLanguages = "" Then
                sLanguages = tail
            ElseIf head = "Equipment" And sEquipment = "" Then
                sEquipment = tail
            ElseIf line.StartsWith("Monster found in ") Then
                sSource = line.Replace("Monster found in ", "")
            ElseIf head = "Skills" And sSkills = "" Then
                sSkills = tail
            Else
                If line = "" Then
                    ' Do Nothing - skip it
                ElseIf line = "Standard Actions" Then
                    CurrentSection = "standard"
                ElseIf line = "Minor Actions" Then
                    CurrentSection = "minor"
                ElseIf line = "Move Actions" Then
                    CurrentSection = "move"
                ElseIf line = "Triggered Actions" Then
                    CurrentSection = "triggered"
                ElseIf line = "Traits" Then
                    CurrentSection = "trait"
                ElseIf line = "Free Actions" Then
                    CurrentSection = "free"
                ElseIf line = "Other Powers" Then
                    CurrentSection = "other"



                ElseIf sName = "" Then
                    If head.StartsWith("@4eSB") Then
                        ' File header - skip it
                    Else
                        ' Name
                        sName = line
                    End If
                ElseIf sType = "" Then
                    ' Type/Size/Keywords
                    sType = line
                ElseIf CurrentSection = "Senses" Then
                    If sSenses = "" Then
                        sSenses = line
                    Else
                        sSenses = sSenses & ", " & line
                    End If
                ElseIf line.ToLower.Trim.StartsWith("@") Then
                    ' First line of power - create
                    PowerList.Add(New StatPower(line, CurrentSection))
                Else
                    ' Power Detail Line
                    If PowerList.Count > 0 Then
                        PowerList.Item(PowerList.Count - 1).Power_DetailImport(line, CurrentSection)
                    End If
                End If
                If nLevel > 0 And nMaxHP > 1 And nSurges = 0 Then
                    If nLevel >= 21 Then
                        nSurges = 3
                    ElseIf nLevel >= 11 Then
                        nSurges = 2
                    Else
                        nSurges = 1
                    End If
                End If
            End If
        Next
    End Sub
    Private Function Statblock_RTF_Out() As String

        If sName = "" Then
            Return ""
        End If

        Dim output As New System.Text.StringBuilder

        ' Add RTF intro
        output.AppendLine("{\rtf1\fbidis\ansi\ansicpg1252\deff0")
        output.AppendLine("{\fonttbl{\f0\fnil\fcharset0 Arial;}")
        output.AppendLine("{\f1\fnil\fcharset0 4etools symbols;}}")
        output.AppendLine("{\colortbl ;\red0\green0\blue0;}")
        output.AppendLine("\viewkindlt\uc1\pard\ltrpar\cf1\lang1033")

        ' Add Name/Type/Level Block
        output.AppendLine("\fs24\b " & sName & "\b0\par")
        output.Append("\fs20 " & sLevelRole)
        If nXP > 0 Then
            output.AppendLine(" \bullet  XP " & nXP.ToString("#,0"))
        End If
        output.AppendLine("\par")
        output.AppendLine(sType & "\par")
        output.AppendLine("\par")

        ' Add Initiative and Senses line
        output.Append(RTF_Bold("Initiative "))
        If nInit >= 0 Then
            output.Append("+")
        End If
        output.Append(CStr(nInit))
        If sSenses <> "" Then
            output.Append(" \tab " & RTF_Bold("Senses ") & sSenses)
        End If
        output.AppendLine("\par")

        ' Add Auras
        For Each aura As StatPower In PowerList
            If aura.bAura Then
                output.Append(aura.Power_RTF_Out)
            End If
        Next

        ' Add HP Line
        If nMaxHP = 1 Then
            output.AppendLine(RTF_Bold("HP ") & _
                              "1; a missed attack never damages a minion.\par")
        ElseIf nMaxHP > 1 Then
            output.Append(RTF_Bold("HP ") & nMaxHP.ToString("#,0") & "; ")
            output.Append(RTF_Bold("Bloodied ") & nBloodyHP.ToString("#,0"))
            If bPC Then
                output.Append(RTF_Bold("; Surge ") & nSurgeValue.ToString("#,0"))
            End If
            output.AppendLine("\par")
        End If

        ' Add Regeneration line
        If sRegen <> "" Then
            output.Append(RTF_Bold("Regeneration ") & sRegen)
            output.AppendLine("\par")
        End If

        ' Add Defenses Line
        If (nAC + nFort + nRef + nWill) > 0 Then
            output.Append(RTF_Bold("AC ") & CStr(nAC) & "; ")
            output.Append(RTF_Bold("Fortitude ") & CStr(nFort) & "; ")
            output.Append(RTF_Bold("Reflex ") & CStr(nRef) & "; ")
            output.Append(RTF_Bold("Will ") & CStr(nWill))
            output.AppendLine("\par")
        End If

        ' Add Immune line
        If sImmune <> "" Then
            output.Append(RTF_Bold("Immune ") & sImmune)
            output.AppendLine("\par")
        End If

        ' Add Resist line
        If sResist <> "" Then
            output.Append(RTF_Bold("Resist ") & sResist)
            output.AppendLine("\par")
        End If

        ' Add Vulnerable line
        If sVuln <> "" Then
            output.Append(RTF_Bold("Vulnerable ") & sVuln)
            output.AppendLine("\par")
        End If

        ' Add Saving Throw line
        If nSaveBonus > 0 Then
            output.Append(RTF_Bold("Saving Throws ") & "+" & CStr(nSaveBonus))
            output.AppendLine("\par")
        End If

        ' Add Speed line
        If sSpeed <> "" Then
            output.Append(RTF_Bold("Speed ") & sSpeed)
            output.AppendLine("\par")
        End If

        ' Add Action Points line
        If nActionPoints > 0 Then
            output.Append(RTF_Bold("Action Points ") & CStr(nActionPoints))
            output.AppendLine("\par")
        End If
        ' Add Power Points line
        If nPowerPoints > 0 Then
            output.Append(RTF_Bold("Power Points ") & CStr(nPowerPoints))
            output.AppendLine("\par")
        End If

        ' Add Powers
        output.AppendLine("\par")
        For Each pow As StatPower In PowerList
            If Not pow.bAura Then
                output.Append(pow.Power_RTF_Out)
                output.AppendLine("\par")
            End If
        Next

        ' Add Alignment line
        If sAlignment <> "" Then
            output.Append(RTF_Bold("Alignment ") & sAlignment)
            output.AppendLine("\par")
        End If

        ' Add Languages line
        If sLanguages <> "" Then
            output.Append(RTF_Bold("Languages ") & sLanguages)
            output.AppendLine("\par")
        End If

        ' Add Feats line
        If sFeats <> "" Then
            output.AppendLine("\par")
            output.Append(RTF_Bold("Feats ") & sFeats)
            output.AppendLine("\par")
            output.AppendLine("\par")
        End If

        ' Add Skills line
        If sSkills <> "" Then
            output.Append(RTF_Bold("Skills ") & sSkills)
            output.AppendLine("\par")
        End If

        ' Add Stats
        output.AppendLine("\par")
        If nStr > 0 Then
            output.Append(RTF_Bold("Str ") & RTF_DnDStatBonus(nStr) & "\tab")
            output.Append(RTF_Bold("Dex ") & RTF_DnDStatBonus(nDex) & "\tab")
            output.Append(RTF_Bold("Wis ") & RTF_DnDStatBonus(nWis))
            output.AppendLine("\par")
            output.Append(RTF_Bold("Con ") & RTF_DnDStatBonus(nCon) & "\tab")
            output.Append(RTF_Bold("Int ") & RTF_DnDStatBonus(nInt) & "\tab")
            output.Append(RTF_Bold("Cha ") & RTF_DnDStatBonus(nCha))
            output.AppendLine("\par")
            output.AppendLine("\par")
        End If

        ' Add Equipment line
        If sEquipment <> "" Then
            output.Append(RTF_Bold("Equipment ") & sEquipment)
            output.AppendLine("\par")
        End If

        ' Add Source line
        If sSource <> "" Then
            output.AppendLine("\par")
            output.Append(RTF_Bold("Source ") & sSource)
            output.AppendLine("\par")
        End If

        ' Add Notes lines
        If sNotesBase <> "" Then
            output.AppendLine("\par")
            output.Append(RTF_Bold("Notes:"))
            output.AppendLine("\par")
            output.Append("  " & sNotesBase.Replace("###", "\par" & ControlChars.NewLine & "  "))
            output.AppendLine("\par")
        End If

        ' Add close
        output.AppendLine("}")

        ' Return assembled RTF
        Return output.ToString
    End Function
    Private Function Statblock_HTML_Out() As String
        If Not bNotesOnly Then
            If sName = "" Then
                Return ""
            End If

            Dim output As New System.Text.StringBuilder

            ' Add HTML Header
            output.AppendLine("<html><head><style type='text/css'>html {font-family: Arial, Sans-Serif; font-size: 9.5pt}  body {margin: 0px; padding: 0px; text-align:left; font-weight: normal;}  DIV.symbol {font-family: 4etools symbols} DIV.mbwrap {width: 100%; max-width: 570px;}  DIV.ggdark {width: 100%; padding-left:5px; padding-right:5px; padding-top:2px; padding-bottom:2px; background-color: #374b27; min-height: 14px;}  DIV.mbheadleft {float: left;  align: left; color: #ffffff; font-size: 13px;}  DIV.mbheadright {float: right; align: right; color: #ffffff; font-size: 13px;}  DIV.mbsubleft {float: left; align: left; color: #ffffff;}  DIV.mbsubright {float: right; align: right; color: #ffffff;}  DIV.gglt {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #e1e6c4; min-height: 14px;}  DIV.ggmed {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #9fa48c; min-height: 14px; }  DIV.ggtype {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #727c55; min-height: 14px; }  DIV.ggindent {padding-left:20px;} TD.indlt {padding-left: 4px; padding-right: 4px; font-size: 9.5pt; background-color: #e1e6c4;} TD.indmed {padding-left: 4px; padding-right: 4px; font-size: 9.5pt; background-color: #9fa48c;}</style></head><body>")

            ' Add Name/Type/Level Block
            output.AppendLine("<div class='ggdark'><div class='mbheadleft'><b>" & sName & "</b></div><div class='mbheadright'><b>" & sLevelRole & "</b></div></div>")
            output.AppendLine("<div class='ggdark'><div class='mbsubleft'>" & sType & "</div><div class='mbsubright'>XP " & nXP.ToString("#,0") & "</div></div>")

            ' Add HP and Bloodied
            output.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            If sType.ToLower.Contains("trap") Or sType.ToLower.Contains("hazard") Or sType.ToLower.Contains("Puzzle") Then
                If sDesc <> "" Then output.Append("<tr><td class='indlt'><i>" & sDesc & "</i></td></tr>")
                If sTrap <> "" Then output.Append("<tr><td class='indlt'><B>Trap:</B> " & sTrap & "</td></tr>")
                If sHazard <> "" Then output.Append("<tr><td class='indlt'><B>Hazard:</B> " & sHazard & "</td></tr>")
                If sPuzzle <> "" Then output.Append("<tr><td class='indlt'><B>Puzzle:</B> " & sPuzzle & "</td></tr>")
                If nInit > 0 Then output.Append("<tr><td class='indlt'><B>Init:</B> +" & nInit.ToString & "</td></tr>")
                If nInit < 0 Then output.Append("<tr><td class='indlt'><B>Init:</B> " & nInit.ToString & "</td></tr>")

            Else
                output.Append("<tr><td class='indlt'><b>HP</b> ")
                If nMaxHP = 1 Then
                    output.Append("1, a missed attack never damages a minion.")
                Else
                    output.Append(nMaxHP.ToString("#,0") & "; <b>Bloodied</b> " & nBloodyHP.ToString("#,0"))
                End If
                If bPC Then
                    output.Append("; <b>Surge</b> " & nSurgeValue.ToString("#,0"))
                End If

                ' Add Regeneration line
                If sRegen <> "" Then
                    output.Append("<br><b>Regeneration</b> " & sRegen)
                End If

                ' Add Resists, Immunities, Vulnerabilities
                output.Append("<br><b>AC</b> " & CStr(nAC) & ", <b>Fortitude</b> " & CStr(nFort) & ", <b>Reflex</b> " & CStr(nRef) & ", <b>Will</b> " & CStr(nWill) & "<br><b>Speed</b> " & sSpeed)
                If sImmune <> "" Or sResist <> "" Or sVuln <> "" Then output.Append("<br>")
                If sImmune <> "" Then output.Append("<b>Immune</b> " & sImmune)
                If sImmune <> "" And (sResist <> "" Or sVuln <> "") Then output.Append("; ")
                If sResist <> "" Then output.Append("<b>Resist</b> " & sResist)
                If sResist <> "" And (sVuln <> "") Then output.Append("; ")
                If sVuln <> "" Then output.Append("<b>Vulnerability </b>" & sVuln)

                'Add Saving Throw Bonuses, Action Points, and Power Points
                If nSaveBonus > 0 Or nActionPoints > 0 Or nPowerPoints > 0 Then output.Append("<br>")
                If nSaveBonus > 0 Then output.Append("<b>Saving Throws</b> " & CStr(nSaveBonus))
                If nSaveBonus > 0 And (nActionPoints > 0 Or nPowerPoints > 0) Then output.Append("; ")
                If nActionPoints > 0 Then output.Append("<b>Action Points</b> " & CStr(nActionPoints))
                If nActionPoints > 0 And nPowerPoints > 0 Then output.Append("; ")
                If nPowerPoints > 0 Then output.Append("<b>Power Points</b> " & CStr(nPowerPoints))

                output.AppendLine("</td>")

                ' Add Initiative and Senses line
                output.Append("<td class='indlt' align='right'>")
                output.Append("<b>Initiative</b> ")
                If nInit >= 0 Then
                    output.Append("+")
                End If
                output.Append(CStr(nInit) & "<br>")
                If sSenses <> "" Then
                    output.Append(sSenses.Replace("Perception", "<b>Perception</b>").Replace("Insight", "<b>Insight</b>").Replace(",", "<br>").Replace(";", "<br>"))
                End If
            End If
            output.AppendLine("</td></tr></table>")
            Dim bTraitShown As Boolean = False
            For Each aura As StatPower In PowerList
                If aura.bAura Or aura.sAction = "" Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Traits</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(aura.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each standard As StatPower In PowerList
                If standard.sAction.ToLower.Contains("standard") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Standard Actions</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(standard.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each move As StatPower In PowerList
                If move.sAction.ToLower.Contains("move") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Move Actions</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(move.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each minor As StatPower In PowerList
                If minor.sAction.ToLower.Contains("minor") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Minor Actions</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(minor.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each triggered As StatPower In PowerList
                If triggered.sAction.ToLower.Contains("triggered") Or triggered.sAction.ToLower.Contains("immediate") Or triggered.sAction.ToLower.Contains("opportunity") Or triggered.sAction.ToLower.Contains("free") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Triggered Actions</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(triggered.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each sense As StatPower In PowerList
                If "perception insight arcana dungeoneering nature religion streetwise thievery acrobatics athletics bluff diplomacy endurance heal intimidate stealth history".Contains(sense.sAction.ToLower) And sense.sAction.Trim <> "" Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>" & sense.sAction & "</b></div></div>")
                    End If
                    output.AppendLine(sense.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each trigger As StatPower In PowerList
                If trigger.sAction.ToLower = "trigger" Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Trigger</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(trigger.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each attack As StatPower In PowerList
                If attack.sAction.ToLower.Contains("attack") And attack.sAction.ToLower.IndexOf("attack") < attack.sAction.ToLower.IndexOf("recharge") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Attack</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(attack.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each countermeasures As StatPower In PowerList
                If countermeasures.sAction.ToLower.Contains("countermeasures") Then
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Countermeasures</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(countermeasures.Power_HTML_Out)
                End If
            Next
            bTraitShown = False
            For Each other As StatPower In PowerList
                If other.sAction.ToLower = "trigger" Or other.sAction.ToLower.Contains("countermeasures") Or other.sAction.ToLower.Contains("attack") Or "perception insight arcana dungeoneering nature religion streetwise thievery acrobatics athletics bluff diplomacy endurance heal intimidate stealth history".Contains(other.sAction.ToLower) Or other.sAction.ToLower.Contains("standard") Or other.bAura Or other.sAction.ToLower.Contains("minor") Or other.sAction.ToLower.Contains("move") Or other.sAction.ToLower.Contains("free") Or other.sAction.ToLower.Contains("triggered") Or other.sAction.Trim = "" Or other.sAction.ToLower.Contains("item") Or other.sAction.ToLower.Contains("immediate") Or other.sAction.ToLower.Contains("opportunity") Then
                Else
                    If bTraitShown = False Then
                        output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Other Powers</b></div></div>")
                        bTraitShown = True
                    End If
                    output.AppendLine(other.Power_HTML_Out)
                End If
            Next

            ' Start Statblock Table
            output.AppendLine("<div class='ggmed'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            ' Add Skills line
            If sSkills <> "" Then
                output.AppendLine("<tr><td colspan='3' class='indmed'><b>Skills</b> " & sSkills & "</td></tr>")
            End If

            ' Add Feats line
            If sFeats <> "" Then
                output.AppendLine("<tr><td colspan='3' class='indmed'><b>Feats</b> " & sFeats & "</td></tr>")
            End If

            ' Add Stats
            If nStr > 0 Then
                output.Append("<tr><td class='indmed'><b>Str</b> " & RTF_DnDStatBonus(nStr) & "</td>")
                output.Append("<td class='indmed'><b>Dex</b> " & RTF_DnDStatBonus(nDex) & "</td>")
                output.Append("<td class='indmed'><b>Wis</b> " & RTF_DnDStatBonus(nWis) & "</td></tr>")
                output.Append("<tr><td class='indmed'><b>Con</b> " & RTF_DnDStatBonus(nCon) & "</td>")
                output.Append("<td class='indmed'><b>Int</b> " & RTF_DnDStatBonus(nInt) & "</td>")
                output.Append("<td class='indmed'><b>Cha</b> " & RTF_DnDStatBonus(nCha) & "</td></tr>")
            End If

            output.AppendLine("</table></div>")
            output.AppendLine("<div class='gglt'>")

            ' Add Alignment line
            If sAlignment <> "" Then
                output.Append("<b>Alignment</b> " & sAlignment & " &nbsp;")
                If sLanguages = "" Then output.AppendLine("<br>")
            End If

            ' Add Languages line
            If sLanguages <> "" Then
                output.AppendLine("<b>Languages</b> " & sLanguages & "<br>")
            End If

            ' Add Equipment line
            If sEquipment <> "" Then
                output.AppendLine("<b>Equipment</b> " & sEquipment & "<br>")
            End If

            ' Add Source line
            If sSource <> "" Then
                output.Append("<b>Source</b> " & sSource & "<br>")
            End If

            ' Add Notes lines
            If sNotesBase <> "" Then
                output.Append("<b>Notes:")
                output.Append("  " & sNotesBase.Replace("###", "<br>"))
            End If

            ' Add close
            output.AppendLine("</div></body></html>")

            ' Return assembled HTML
            Return output.ToString
        Else
            Dim output As New System.Text.StringBuilder

            ' Add HTML Header
            output.AppendLine("<html><head><style type='text/css'>html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre,a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, dl, dt, dd, ol, ul, li, fieldset, form, label, legend {	margin: 0;	padding: 0;	border: 0;	outline: 0;	font-size: 100%;}body {	line-height: 1;}ol, ul { 	list-style: none; }blockquote, q {	quotes: none;}:focus { 	outline: 0; } table {	border-collapse: collapse;	border-spacing: 0;} body {	font-size: 75%; line-height: 1.5em;}body, div, p, th, td, li, dd, input, select, textarea	{font-family: Arial, Helvetica, sans-serif;	color: #000;}table, thead, tbody, tr, th, td { font-size: 1em;}html>body { font-size: 12px;}  a img { border-style: none; } a:link { color: blue; }a:visited { color: purple; }a:focus,a:hover,a:active { color: blue; } p {	font-size: 1em;	margin: 0 0 1.5em 0;}p strong, p b {	font-weight: bold;}p em, p i { 	font-style: italic;} .left {	float: left;	margin: 0.5em 0.5em 0.5em 0;}.right {	float: right;	margin: 0.5em 0 0.5em 0.5em;}.clear { clear: both; } .hidden { position: absolute; left: -9999em; } span.super {	font-size: 0.917em;	vertical-align: super;}span.sub {	font-size: 0.917em;	vertical-align: sub;} #wrap { float: left;} #container { position: relative; margin: 0 auto;	width: 910px;}#MasterMainContent {	clear: both; }#bannerGraphic img {	display: block; }.searchControl .textBox { width:150px; }.searchControl .emptyTextBox { width:150px; font-style:italic; } #detail {	background: #fff;	float: left;	padding: 15px;	width: 560px;    color: #3e141e;}#detail {    font-size: 0.916em;}#detail p {	padding-left: 15px;	color: #3e141e;}#detail table {	width: 100%;}#detail table td {	vertical-align: top;	padding: 0 10px 0;	background: #d6d6c2;	border-bottom: 1px solid #fff;}#detail p.flavor,#detail span.flavor,#detail ul.flavor {	display: block;	padding: 2px 15px;	margin: 0;	background: #d6d6c2;}#detail p.powerstat {	padding: 0px 0px 0px 15px;	margin: 0;	background: #FFFFFF;}#detail span.ritualstats {	float:right;	padding: 0 30px 0 0;}#detail p.flavorIndent {	display: block;	padding: 2px 15px 2px 30px;	margin: 0;	background: #d6d6c2;}#detail p.alt,#detail span.alt,#detail td.alt {	background: #c3c6ad;}#detail th {    background: #1d3d5e;    color: #fff;    text-align: left;    padding: 0 0 0 5px;}#detail i,#detail em {	font-style: italic;}#detail ul {    list-style: disc;    margin: 1em 0 1em 30px;}#detail table,#detail ul.flavor {	margin-bottom: 1em;}#detail ul li {    color: #3e141e;}#detail ul.flavor li {	margin-left: 15px;}#detail a {    color: #3e141e;}#detail blockquote {	padding: 0 0 0 22px;	background: #d6d6c2;}#detail h1 {    font-size: 1.09em;    line-height: 2;    padding-left: 15px;    margin: 0;    color: #fff;    background: #000;}#detail h1.player {    background: #1d3d5e;    font-size: 1.35em;}#detail h1.monster {    background: #4e5c2e;    height:38px;}#detail h1.dm {    background: #5c1f34;}#detail h1.trap {    background: #5c1f34;    height:38px;}#detail h1.atwillpower {    background: #619869;}#detail h1.encounterpower {    background: #961334;}#detail h1.dailypower {    background: #4d4d4f;}#detail h1.magicitem {    background: #d8941d;}#detail h1.utilitypower {    background: #1c3d5f;}#detail h1 .level {    padding-right: 15px;	margin-top: 0;	text-align: right;	float: right;}#detail h1.monster .level, h1.trap .level {	margin-top: 0;	text-align: right;	position:relative;	top:-60px;}#detail h1.monster .type,#detail h1.monster .xp {	display: block;	position: relative;	z-index: 99;	top: -0.75em;	height: 1em;	font-weight: normal;	font-size: 0.917em;}#detail .rightalign {	text-align: right;}/* Traps */#detail h1.trap .level {	margin-top: 0;	text-align: right;}#detail h1.trap .type,#detail h1.trap .xp {	display: block;	position: relative;	z-index: 99;	top: -0.75em;	height: 1em;	font-weight: normal;	font-size: 0.917em;}#detail .traplead {	display: block;	padding: 1px 15px;	margin: 0;	background: #ffffff;}#detail .trapblocktitle {	display: block;	padding: 1px 15px;	margin: 0;	background: #d6d6c2;	font-weight: bold;}#detail .trapblockbody {	display: block;	padding: 1px 15px 1px 30px;	margin: 0;	background: #ffffff;}/* Detail page related link section *//* -------------------------------------------- */#detail #RelatedArticles h5 {	width: 100px;	float: left;	padding-top: 10px;	padding-left: 20px;	color: #3e141e;	font-weight: bold;}#detail #RelatedArticles ul.RelatedArticles {	padding: 10px 0 0 0;	float: right;	width: 430px;	margin: 0;	list-style: none;}#detail .bodytable {	border: 0;	margin: 0;	width: 560px;	background: #d6d6c2;}#detail .bodytable td {	border-bottom: none;	padding-left: 15px;	padding-right: 15px;}#detail h2 {    font-size: 1.25em;    padding-left: 15px;    margin: 0;    color: #fff;    background: #4e5c2e;    height:20px;    font-variant: small-caps;    padding-top: 5px;}</style></head><body>")
            output.AppendLine(sNotes.Substring(sNotes.IndexOf("<body>") + 6))
            Return output.ToString
        End If
    End Function


    ' XML Import/Export
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("statblock")

        writer.WriteElementString("name", sName)
        writer.WriteElementString("type", sType)
        writer.WriteElementString("levelrole", sLevelRole)
        writer.WriteElementString("xp", CStr(nXP))

        writer.WriteElementString("senses", sSenses)
        writer.WriteElementString("speed", sSpeed)

        writer.WriteElementString("immune", sImmune)
        writer.WriteElementString("resist", sResist)
        writer.WriteElementString("vuln", sVuln)
        writer.WriteElementString("regen", sRegen)

        writer.WriteElementString("init", CStr(nInit))
        writer.WriteElementString("max_hp", CStr(nMaxHP))
        writer.WriteElementString("save", CStr(nSaveBonus))
        writer.WriteElementString("a_pts", CStr(nActionPoints))
        writer.WriteElementString("p_pts", CStr(nPowerPoints))
        writer.WriteElementString("surges", CStr(nSurges))

        writer.WriteElementString("d_ac", CStr(nAC))
        writer.WriteElementString("d_fort", CStr(nFort))
        writer.WriteElementString("d_ref", CStr(nRef))
        writer.WriteElementString("d_will", CStr(nWill))

        writer.WriteElementString("align", sAlignment)
        writer.WriteElementString("skills", sSkills)
        writer.WriteElementString("lang", sLanguages)
        writer.WriteElementString("equip", sEquipment)
        writer.WriteElementString("source", sSource)
        writer.WriteElementString("feats", sFeats)


        writer.WriteElementString("desc", sDesc)
        writer.WriteElementString("trap", sTrap)
        writer.WriteElementString("hazard", sHazard)
        writer.WriteElementString("puzzle", sPuzzle)

        writer.WriteElementString("notes", CStr(sNotesBase))
        writer.WriteElementString("notesonly", CStr(bNotesOnly))
        writer.WriteElementString("displayname", CStr(sDisplayName))

        writer.WriteElementString("s_str", CStr(nStr))
        writer.WriteElementString("s_dex", CStr(nDex))
        writer.WriteElementString("s_wis", CStr(nWis))
        writer.WriteElementString("s_con", CStr(nCon))
        writer.WriteElementString("s_int", CStr(nInt))
        writer.WriteElementString("s_cha", CStr(nCha))

        For Each pow As StatPower In PowerList
            pow.ExportXML(writer)
        Next

        For Each eff As EffectBase In PresetEffects.Values
            eff.ExportXML(writer)
        Next

        writer.WriteEndElement()
    End Sub
    Public Function ImportHTML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Console.WriteLine(p_reader.ToString)
        While reader.Read
            Console.WriteLine(reader.NodeType & " - " & reader.Name & " - " & reader.Value)
        End While
    End Function

    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newpower As StatPower
        Dim neweffect As EffectBase

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "statblock" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "power" Then
                        newpower = New StatPower
                        newpower.ImportXML(reader)
                        PowerList.Add(newpower)
                    ElseIf reader.Name = "effectbase" Then
                        neweffect = New EffectBase
                        neweffect.ImportXML(reader)
                        PresetEffectAdd(neweffect)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "type"
                            sType = reader.Value
                        Case "levelrole"
                            sLevelRole = reader.Value
                        Case "xp"
                            nXP = Val(reader.Value)

                        Case "senses"
                            sSenses = reader.Value
                        Case "speed"
                            sSpeed = reader.Value

                        Case "resist"
                            sResist = reader.Value
                        Case "immune"
                            sImmune = reader.Value
                        Case "vuln"
                            sVuln = reader.Value
                        Case "regen"
                            sRegen = reader.Value

                        Case "init"
                            nInit = Val(reader.Value)
                        Case "max_hp"
                            nMaxHP = Val(reader.Value)
                        Case "save"
                            nSaveBonus = Val(reader.Value)
                        Case "a_pts"
                            nActionPoints = Val(reader.Value)
                        Case "p_pts"
                            nPowerPoints = Val(reader.Value)
                        Case "surges"
                            nSurges = Val(reader.Value)

                        Case "d_ac"
                            nAC = Val(reader.Value)
                        Case "d_fort"
                            nFort = Val(reader.Value)
                        Case "d_ref"
                            nRef = Val(reader.Value)
                        Case "d_will"
                            nWill = Val(reader.Value)

                        Case "align"
                            sAlignment = reader.Value
                        Case "skills"
                            sSkills = reader.Value
                        Case "lang"
                            sLanguages = reader.Value
                        Case "equip"
                            sEquipment = reader.Value
                        Case "source"
                            sSource = reader.Value
                        Case "feats"
                            sFeats = reader.Value


                        Case "notes"
                            sNotesBase = reader.Value
                        Case "notesonly"
                            bNotesOnly = CBool(reader.Value)
                        Case "displayname"
                            sDisplayName = reader.Value
                        Case "desc"
                            sDesc = reader.Value
                        Case "trap"
                            sTrap = reader.Value
                        Case "hazard"
                            sHazard = reader.Value
                        Case "puzzle"
                            sPuzzle = reader.Value

                        Case "s_str"
                            nStr = Val(reader.Value)
                        Case "s_dex"
                            nDex = Val(reader.Value)
                        Case "s_wis"
                            nWis = Val(reader.Value)
                        Case "s_con"
                            nCon = Val(reader.Value)
                        Case "s_int"
                            nInt = Val(reader.Value)
                        Case "s_cha"
                            nCha = Val(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "statblock" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function


    ' CB_XML Import
    Public Function LoadFromCBFile(ByVal filename As String) As Boolean
        Dim filetool As New IO.FileInfo(filename)
        Dim xmlSettings As New System.Xml.XmlReaderSettings
        If filetool.Exists Then
            Using fileXMLReader As Xml.XmlReader = Xml.XmlReader.Create(filename, xmlSettings)
                fileXMLReader.MoveToContent()
                If Not fileXMLReader.EOF Then
                    While fileXMLReader.NodeType <> Xml.XmlNodeType.Element And Not fileXMLReader.EOF
                        fileXMLReader.Read()
                    End While
                    ImportCharFromCBXML(fileXMLReader)
                    Return True
                End If
            End Using
        End If
        Return False
    End Function
    Public Function ConvertFromMonster(ByVal mon As Monster) As Boolean
        sName = mon.sName
        sType = mon.sTypeKeywords.ToString
        sRole = mon.sRole
        sRole2 = mon.sSecondaryRole
        nLevel = mon.nLevel
        sSenses = "Perception "
        If mon.SkillBonus("perception") < 0 Then
            sSenses += "-"
        ElseIf mon.SkillBonus("perception") > 0 Then
            sSenses += "+"
        End If
        sSenses += mon.SkillBonus("perception") & "; Insight "
        If mon.SkillBonus("insight") < 0 Then
            sSenses += "-"
        ElseIf mon.SkillBonus("insight") > 0 Then
            sSenses += "+"
        End If
        sSenses += mon.SkillBonus("insight") & "; "
        sSenses += mon.sSenses
        sSpeed = mon.sSpeeds.Substring(mon.sSpeeds.IndexOf(" ") + 1)
        sResist = mon.sResistances.Substring(mon.sResistances.IndexOf(" ") + 1)
        sImmune = mon.sImmunities.Substring(mon.sImmunities.IndexOf(" ") + 1)
        sVuln = mon.sVulnerabilities.Substring(mon.sVulnerabilities.IndexOf(" ") + 1)
        sRegen = mon.sRegenDetails
        sAlignment = mon.sAlignment
        sSkills = mon.sSkills
        sLanguages = mon.sLanguages
        sEquipment = mon.sEquipment
        sSource = mon.sSource
        nXP = mon.nXP
        nInit = mon.nInit
        nMaxHP = mon.nHP
        nSaveBonus = mon.nSavingThrow
        nActionPoints = mon.nActionPoints
        nAC = mon.nAC
        nFort = mon.nFort
        nRef = mon.nRef
        nWill = mon.nWill
        nStr = mon.nStr
        nDex = mon.nDex
        nWis = mon.nWis
        nCon = mon.nCon
        nInt = mon.nInt
        nCha = mon.nCha
        bLeader = mon.bLeader
        For Each tempPow As Power In mon.cPowers
            Dim tempStatPow As New StatPower
            tempStatPow.sName = tempPow.sName
            tempStatPow.Type = tempPow.sType
            tempStatPow.sAction = tempPow.sActionType.ToLower
            If tempPow.sUsage <> "" Then
                tempStatPow.sAction += "; " & tempPow.sUsage.ToLower
                If tempPow.sUsageDetails <> "" Then
                    tempStatPow.sAction += " " & tempPow.sUsageDetails
                End If
            End If
            If tempPow.cKeywords.Count > 0 Then
                Dim output As New System.Text.StringBuilder
                Dim index As Integer = 0
                For Each key As Keyword In tempPow.cKeywords
                    index += 1
                    output.Append(key.sName)
                    If index < tempPow.cKeywords.Count Then output.Append(", ")
                Next
                tempStatPow.sKeywords = output.ToString
            End If
            If tempPow.cAttacks.Count > 0 Then tempStatPow.sDesc = ""
            If tempPow.sRequirements <> "" Then tempStatPow.sDesc += "Requirements: " & tempPow.sRequirements & "###"
            If tempPow.sTrigger <> "" Then tempStatPow.sDesc += "Trigger: " & tempPow.sTrigger & "###"
            For Each att As Attack In tempPow.cAttacks
                tempStatPow.sDesc += att.text_out(tempPow, "###")
            Next
            PowerList.Add(tempStatPow)
        Next
        For Each tempTrait As Trait In mon.cTraits
            Dim tempStatPow As New StatPower
            tempStatPow.sName = tempTrait.sName
            tempStatPow.nAura = tempTrait.nAura
            If tempTrait.cKeywords.Count > 0 Then
                Dim output As New System.Text.StringBuilder
                Dim index As Integer = 0
                For Each key As Keyword In tempTrait.cKeywords
                    index += 1
                    output.Append(key.sName)
                    If index < tempTrait.cKeywords.Count Then output.Append(", ")
                Next
                tempStatPow.sKeywords = output.ToString
            End If
            If tempTrait.sDetails <> "" Then tempStatPow.sDesc = tempTrait.sDetails
            PowerList.Add(tempStatPow)
        Next
        Return True
    End Function
    Public Sub ImportCharFromCBXML(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim itemList As New Hashtable

        ClearAll()
        sRole = "Hero"
        sSource = "WotC Character Builder"

        Try
            If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "D20Character" Then
                Do While reader.Read
                    If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "CharacterSheet" Then
                        Do While reader.Read
                            If reader.NodeType = Xml.XmlNodeType.Element Then
                                If reader.Name = "Details" Then
                                    ImportCharFromCBXML_Details(reader)
                                ElseIf reader.Name = "StatBlock" Then
                                    ImportCharFromCBXML_StatBlock(reader)
                                ElseIf reader.Name = "RulesElementTally" Then
                                    ImportCharFromCBXML_RulesElementTally(reader)
                                ElseIf reader.Name = "LootTally" Then
                                    ImportCharFromCBXML_LootTally(reader, itemList)
                                ElseIf reader.Name = "PowerStats" Then
                                    ImportCharFromCBXML_PowerStats(reader)
                                End If
                            ElseIf reader.NodeType = Xml.XmlNodeType.EndElement _
                                   And reader.Name = "CharacterSheet" Then
                                Exit Do
                            End If
                        Loop
                    ElseIf reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Level" Then
                        ImportCharFromCBXML_PowerURLs(reader)
                    End If
                Loop
            End If
            If itemList.Count > 0 Then
                For Each item As String In itemList.Keys
                    Dim newpower As New StatPower
                    newpower.sName = item
                    newpower.sAction = "item"
                    newpower.sURL = itemList(item)
                    newpower.sDesc = ""
                    newpower.sKeywords = ""
                    PowerList.Add(newpower)
                Next
            End If
        Catch exc As Xml.XmlException
        Finally
        End Try

    End Sub
    Private Sub ImportCharFromCBXML_Details(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Details" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    elementName = reader.Name.ToLower
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value.Trim
                        Case "level"
                            nLevel = Val(reader.Value)
                        Case "experience"
                            nXP = Val(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Details" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Private Sub ImportCharFromCBXML_StatBlock(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attlist As New Hashtable
        Dim skillList As New SortedList
        Dim tempvalue As String = "0"

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "StatBlock" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    ' Get Information from Element Node
                    elementName = reader.Name
                    attlist.Clear()
                    If reader.AttributeCount > 0 Then
                        While reader.MoveToNextAttribute
                            attlist.Add(reader.Name.Trim, reader.Value.Trim)
                        End While
                        If elementName = "Stat" And attlist.ContainsKey("value") Then
                            tempvalue = Val(attlist("value"))
                        End If
                    End If

                    ' Analyze element
                    If elementName = "alias" And attlist.ContainsKey("name") Then
                        Select Case attlist("name")
                            Case "Strength"
                                nStr = Val(tempvalue)
                            Case "Constitution"
                                nCon = Val(tempvalue)
                            Case "Dexterity"
                                nDex = Val(tempvalue)
                            Case "Intelligence"
                                nInt = Val(tempvalue)
                            Case "Wisdom"
                                nWis = Val(tempvalue)
                            Case "Charisma"
                                nCha = Val(tempvalue)

                            Case "AC"
                                nAC = Val(tempvalue)
                            Case "Fortitude Defense"
                                nFort = Val(tempvalue)
                            Case "Reflex Defense"
                                nRef = Val(tempvalue)
                            Case "Will Defense"
                                nWill = Val(tempvalue)

                            Case "Hit Points"
                                nMaxHP = Val(tempvalue)
                            Case "Initiative"
                                nInit = Val(tempvalue)
                            Case "Speed"
                                sSpeed = tempvalue
                            Case "Power Points"
                                nPowerPoints = Val(tempvalue)
                            Case "Healing Surges"
                                nSurges = Val(tempvalue)

                            Case "Acrobatics"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Arcana"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Athletics"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Bluff"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Diplomacy"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Dungeoneering"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Endurance"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Heal"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "History"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Insight"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Nature"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Perception"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Religion"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Stealth"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Streetwise"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Thievery"
                                skillList(attlist("name")) = Val(tempvalue)
                            Case "Streetwise"
                                skillList(attlist("name")) = Val(tempvalue)

                            Case "Passive Perception"
                                If sSenses <> "" Then sSenses &= "; "
                                sSenses &= "Perception " & tempvalue
                            Case "Passive Insight"
                                If sSenses <> "" Then sSenses &= "; "
                                sSenses &= "Insight " & tempvalue
                        End Select
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "StatBlock" Then
                        ' Write out skills
                        If skillList.Count > 0 Then
                            Dim skilltemp As New System.Text.StringBuilder
                            For Each skillname As String In skillList.Keys
                                If skilltemp.Length > 0 Then skilltemp.Append("; ")
                                skilltemp.Append(skillname & " " & IntegerFormatForPlus(skillList(skillname)))
                            Next
                            sSkills = skilltemp.ToString
                        End If
                        ' Finished with Statblock
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Private Sub ImportCharFromCBXML_RulesElementTally(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attlist As New Hashtable

        Dim sPowerSource As String = ""
        Dim sClassRole As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "RulesElementTally" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    ' Get Information from Element Node
                    elementName = reader.Name
                    attlist.Clear()
                    If reader.AttributeCount > 0 Then
                        While reader.MoveToNextAttribute
                            attlist.Add(reader.Name.Trim, reader.Value.Trim)
                        End While
                    End If

                    ' Analyze element
                    If elementName = "RulesElement" And attlist.ContainsKey("name") _
                                            And attlist.ContainsKey("type") Then
                        Select Case attlist("type")
                            Case "Gender"
                                If sType <> "" Then sType &= " "
                                sType &= attlist("name")
                            Case "Race"
                                If sType <> "" Then sType &= " "
                                sType &= attlist("name")
                            Case "Class"
                                If sType <> "" Then sType &= " "
                                sType &= attlist("name")
                            Case "Role"
                                sClassRole = attlist("name")
                            Case "Power Source"
                                sPowerSource = attlist("name")

                            Case "Alignment"
                                sAlignment = attlist("name")
                            Case "Vision"
                                If attlist("name") <> "Normal" Then
                                    If sSenses <> "" Then sSenses &= "; "
                                    sSenses &= attlist("name")
                                End If
                            Case "Feat"
                                If sFeats <> "" Then sFeats &= ", "
                                sFeats &= attlist("name")
                            Case "Language"
                                If sLanguages <> "" Then sLanguages &= ", "
                                sLanguages &= attlist("name")
                        End Select
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "RulesElementTally" Then
                        If sClassRole <> "" Or sPowerSource <> "" Then
                            Dim temp As String = sPowerSource & " " & sClassRole
                            temp = temp.Trim
                            sType &= " (" & temp & ")"
                        End If

                        ' Finished with RulesElementTally
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Private Sub ImportCharFromCBXML_LootTally(ByRef p_reader As Object, ByRef p_items As Hashtable)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attlist As New Hashtable
        Dim sItemName As String = ""
        Dim sItemType As String = ""
        Dim sItemURL As String = ""
        Dim nCount As Integer = 0

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "LootTally" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    ' Get Information from Element Node
                    elementName = reader.Name
                    attlist.Clear()
                    If reader.AttributeCount > 0 Then
                        While reader.MoveToNextAttribute
                            attlist.Add(reader.Name.Trim, reader.Value.Trim)
                        End While
                    End If

                    ' Analyze element
                    If elementName = "loot" Then
                        sItemName = ""
                        sItemType = ""
                        sItemURL = ""
                        nCount = Val(attlist("count"))
                    ElseIf elementName = "RulesElement" And attlist.ContainsKey("name") _
                                            And attlist.ContainsKey("type") Then
                        If sItemName <> "" Then
                            sItemName = attlist("name").ToString.Replace(sItemType, sItemName)
                        End If
                        If sItemName = "" Then sItemName &= attlist("name")
                        sItemType &= attlist("type")
                        sItemURL = attlist("url")
                        If sItemURL = Nothing Then
                            sItemURL = ""
                        End If
                        If sItemURL <> "" Then sItemURL = sItemURL.Replace("&amp;", "&")
                        If sItemURL.Contains("item.aspx") Then sItemURL = sItemURL.Replace("item.aspx?", "display.aspx?page=item&")

                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "LootTally" Then
                        ' Finished with LootTally
                        Exit Sub
                    ElseIf reader.Name = "loot" And sItemName <> "" And nCount > 0 Then
                        sItemName = sItemName.Replace(" (heroic tier)", "")
                        sItemName = sItemName.Replace(" (paragon tier)", "")
                        sItemName = sItemName.Replace(" (epic tier)", "")
                        If nCount > 1 Then sItemName &= " x" & CStr(nCount)
                        If sEquipment <> "" Then sEquipment &= "; "
                        If sItemType.Contains("Magic Item") Then
                            If Not p_items.ContainsKey(sItemName) Then
                                p_items.Add(sItemName, sItemURL)
                            End If
                        End If
                        sEquipment &= sItemName
                        sItemName = ""
                        nCount = 0
                    End If
                End If
            Loop
        End If
    End Sub
    Private Sub ImportCharFromCBXML_PowerStats(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attlist As New Hashtable

        Dim newpow As StatPower = Nothing
        Dim tempDesc As New System.Text.StringBuilder
        If tempDesc.Length > 0 Then tempDesc.Remove(0, tempDesc.Length)
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "PowerStats" Then
            Do While reader.Read

                If reader.NodeType = Xml.XmlNodeType.Element Then
                    ' Get Information from Element Node
                    elementName = reader.Name
                    attlist.Clear()
                    If reader.AttributeCount > 0 Then
                        While reader.MoveToNextAttribute
                            attlist.Add(reader.Name.Trim, reader.Value.Trim)
                        End While
                    End If

                    ' Analyze element
                    If elementName = "Power" Then
                        newpow = New StatPower
                        newpow.sName = attlist("name")
                        If tempDesc.Length > 0 Then tempDesc.Remove(0, tempDesc.Length)
                        newpow.sDesc = ""
                    ElseIf elementName = "specific" And attlist("name") = "Power Usage" _
                            And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            newpow.sAction &= "; " & reader.Value.ToLower.Trim
                        End If
                    ElseIf elementName = "specific" And attlist("name") = "Action Type" _
                            And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            newpow.sAction = reader.Value.ToLower.Trim.Replace(" action", "") & newpow.sAction
                        End If
                    ElseIf elementName = "Weapon" And Not newpow Is Nothing Then
                        tempDesc.Append(attlist("name") & ": UUU (WWW) vs YYY, ZZZ damage###")
                    ElseIf elementName = "AttackBonus" And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            If CInt(reader.Value.Trim) >= 0 Then
                                tempDesc.Replace("UUU", "+" & reader.Value.Trim)
                            Else
                                tempDesc.Replace("UUU", reader.Value.Trim)
                            End If
                        End If
                    ElseIf elementName = "AttackStat" And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            tempDesc.Replace("WWW", reader.Value.Trim.Substring(0, 3))
                        End If
                    ElseIf elementName = "Defense" And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            tempDesc.Replace("YYY", reader.Value.Trim)
                        End If
                    ElseIf elementName = "Damage" And Not newpow Is Nothing Then
                        reader.Read()
                        If reader.NodeType = Xml.XmlNodeType.Text Then
                            tempDesc.Replace("ZZZ", reader.Value.Trim)
                        End If

                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "PowerStats" Then
                        ' Finished with PowerStats
                        Exit Sub
                    ElseIf reader.Name = "Power" Then
                        If Not newpow Is Nothing Then
                            If newpow.sName <> "" And Not newpow.sName.EndsWith("Basic Attack") Then
                                tempDesc.Replace("ZZZ", "No").Replace("(Unk) vs Unknown, No damage", "")
                                newpow.sDesc = tempDesc.ToString
                                PowerList.Add(newpow)
                                If newpow.sAction.ToLower.Contains("encounter (special)") Then
                                    If "healing infusion majestic word rune of mending healing word inspiring word healing spirit".Contains(newpow.sName.ToLower) Then
                                        Dim newpow2 As New StatPower
                                        newpow2.sName = newpow.sName & " - 2"
                                        newpow2.sAction = newpow.sAction
                                        PowerList.Add(newpow2)
                                        newpow2 = Nothing
                                        If nLevel >= 16 Then
                                            Dim newpow3 As New StatPower
                                            newpow3.sName = newpow.sName & " - 3"
                                            newpow3.sAction = newpow.sAction
                                            PowerList.Add(newpow3)
                                            newpow2 = Nothing
                                        End If
                                    End If
                                End If
                            End If
                            newpow = Nothing
                        End If
                    End If
                End If
            Loop
        End If
    End Sub
    Private Sub ImportCharFromCBXML_PowerURLs(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attlist As New Hashtable
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Level" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    ' Get Information from Element Node
                    elementName = reader.Name
                    attlist.Clear()
                    If reader.AttributeCount > 0 Then
                        While reader.MoveToNextAttribute
                            attlist.Add(reader.Name.Trim, reader.Value.Trim)
                        End While
                    End If
                    ' Analyze element
                    If elementName = "RulesElement" Then
                        If attlist("type") = "Power" Then
                            For Each pow As StatPower In PowerList
                                Dim tempName As String = attlist("name")
                                If pow.sName.Contains(tempName) Then
                                    If attlist("url") <> "" Then
                                        pow.sURL = attlist("url").ToString.Replace("&amp;", "&")
                                    End If
                                    REM Else : pow.sURL = ""
                                End If
                            Next
                        End If
                    End If
                End If

            Loop
        End If


    End Sub

    Public Sub Copy(ByRef tocopy As Statblock)
        sName = tocopy.sName
        sType = tocopy.sType
        sRole = tocopy.sRole
        sRole2 = tocopy.sRole2
        sSenses = tocopy.sSenses
        sSpeed = tocopy.sSpeed
        sResist = tocopy.sResist
        sImmune = tocopy.sImmune
        sVuln = tocopy.sVuln
        sRegen = tocopy.sRegen
        sAlignment = tocopy.sAlignment
        sSkills = tocopy.sSkills
        sLanguages = tocopy.sLanguages
        sEquipment = tocopy.sEquipment
        sSource = tocopy.sSource
        sFeats = tocopy.sFeats
        sDisplayName = tocopy.sDisplayName
        nLevel = tocopy.nLevel
        nXP = tocopy.nXP
        nInit = tocopy.nInit
        nMaxHP = tocopy.nMaxHP
        nSaveBonus = tocopy.nSaveBonus
        nActionPoints = tocopy.nActionPoints
        nPowerPoints = tocopy.nPowerPoints
        nSurges = tocopy.nSurges
        nAC = tocopy.nAC
        nFort = tocopy.nFort
        nRef = tocopy.nRef
        nWill = tocopy.nWill
        nStr = tocopy.nStr
        nDex = tocopy.nDex
        nCon = tocopy.nCon
        nInt = tocopy.nInt
        nWis = tocopy.nWis
        nCha = tocopy.nCha
        bLeader = tocopy.bLeader
        bNotesOnly = tocopy.bNotesOnly
        sDesc = tocopy.sDesc
        sTrap = tocopy.sTrap
        sHazard = tocopy.sHazard
        sPuzzle = tocopy.sPuzzle
        sNotesBase = tocopy.sNotesBase
        For Each pow As StatPower In tocopy.PowerList
            Dim newpow As New StatPower
            newpow.Copy(pow)
            PowerList.Add(newpow)
        Next
        For Each eff As EffectBase In tocopy.PresetEffects.Values
            Dim neweff As New EffectBase
            neweff.copy(eff)
            PresetEffectAdd(neweff)
        Next
    End Sub
End Class