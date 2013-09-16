Imports DnD4e_Combat_Manager.DnDLibrary
Public Class Monster
    Public sName, sSecondaryRole, sRole, sSize, sOrigin, sType, sRegenDetails, sLanguages, sAlignment, sEquipment, sNotes, sSource As String
    Public nLevel, nXP, nInit, nHP, nAC, nFort, nRef, nWill, nBaseACAtt, nBaseFortAtt, nBaseRefAtt, nBaseWillAtt, nActionPoints As Integer
    Public nStr, nCon, nDex, nWis, nInt, nCha As Integer
    Public cSenses, cSkills, cImmunities, cResistances, cVulnerabilities, cSavingThrows, cSpeeds, cTraits, cPowers, cKeywords As New ArrayList
    Public bLeader As Boolean
    Public Sub New()
        ClearAll()
    End Sub
    Public Sub New(ByRef cp As Monster)
        Copy(cp)
    End Sub

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
    ReadOnly Property sHandle() As String
        Get
            Return sName + " - " + sRoleLevel
        End Get
    End Property
    ReadOnly Property sRoleLevel() As String
        Get
            Return sSecondaryRole.Substring(0, Math.Min(2, sSecondaryRole.Length)) + sRole.Substring(0, Math.Min(2, sRole.Length)) + nLevel.ToString
        End Get
    End Property
    ReadOnly Property sLevelRole() As String
        Get
            Dim _levelRole As String = ""
            _levelRole = "Level " & nLevel.ToString
            If sSecondaryRole <> "" Then _levelRole += " " & sSecondaryRole
            _levelRole += " " & sRole
            If bLeader Then _levelRole += " (Leader)"
            Return _levelRole
        End Get
    End Property
    ReadOnly Property sTypeKeywords()
        Get
            Dim output As String = ""
            If sSize <> "" Then output += sSize & " "
            If sOrigin <> "" Then output += sOrigin & " "
            If sType <> "" Then output += sType & " "
            If cKeywords.Count > 0 Then
                output += "("
                Dim index As Integer = 0
                For Each key As Keyword In cKeywords
                    index += 1
                    output += key.sName
                    If index < cKeywords.Count Then output += ", "
                Next
                output += ")"
            End If
            Return output
        End Get
    End Property
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer
        writer.WriteStartElement("monster")
        writer.WriteElementString("name", sName)
        writer.WriteElementString("role", sRole)
        writer.WriteElementString("secondaryrole", sSecondaryRole)
        writer.WriteElementString("size", sSize)
        writer.WriteElementString("origin", sOrigin)
        writer.WriteElementString("type", sType)
        writer.WriteElementString("regendetails", sRegenDetails)
        writer.WriteElementString("languages", sLanguages)
        writer.WriteElementString("alignment", sAlignment)
        writer.WriteElementString("equipment", sEquipment)
        writer.WriteElementString("notes", sNotes)
        writer.WriteElementString("source", sSource)
        writer.WriteElementString("level", nLevel.ToString)
        writer.WriteElementString("leader", bLeader.ToString)
        writer.WriteElementString("xp", nXP.ToString)
        writer.WriteElementString("init", nInit.ToString)
        writer.WriteElementString("hp", nHP.ToString)
        writer.WriteElementString("ac", nAC.ToString)
        writer.WriteElementString("fort", nFort.ToString)
        writer.WriteElementString("ref", nRef.ToString)
        writer.WriteElementString("will", nWill.ToString)
        writer.WriteElementString("baseacatt", nBaseACAtt.ToString)
        writer.WriteElementString("basefortatt", nBaseFortAtt.ToString)
        writer.WriteElementString("baserefatt", nBaseRefAtt.ToString)
        writer.WriteElementString("basewillatt", nBaseWillAtt.ToString)
        writer.WriteElementString("actionpoints", nActionPoints.ToString)
        writer.WriteElementString("str", nStr.ToString)
        writer.WriteElementString("con", nCon.ToString)
        writer.WriteElementString("dex", nDex.ToString)
        writer.WriteElementString("wis", nWis.ToString)
        writer.WriteElementString("int", nInt.ToString)
        writer.WriteElementString("cha", nCha.ToString)
        For Each subitem As Keyword In cKeywords
            subitem.ExportXML(writer)
        Next
        For Each subitem As Sense In cSenses
            subitem.ExportXML(writer)
        Next
        For Each subitem As Skill In cSkills
            subitem.ExportXML(writer)
        Next
        For Each subitem As Immunity In cImmunities
            subitem.ExportXML(writer)
        Next
        For Each subitem As Resistance In cResistances
            subitem.ExportXML(writer)
        Next
        For Each subitem As Vulnerability In cVulnerabilities
            subitem.ExportXML(writer)
        Next
        For Each subitem As SavingThrow In cSavingThrows
            subitem.ExportXML(writer)
        Next
        For Each subitem As Speed In cSpeeds
            subitem.ExportXML(writer)
        Next
        For Each subitem As Trait In cTraits
            subitem.ExportXML(writer)
        Next
        For Each subitem As Power In cPowers
            subitem.ExportXML(writer)
        Next
        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newSense As Sense
        Dim newSkill As Skill
        Dim newImmunity As Immunity
        Dim newResistance As Resistance
        Dim newVulnerability As Vulnerability
        Dim newSavingThrow As SavingThrow
        Dim newSpeed As Speed
        Dim newTrait As Trait
        Dim newPower As Power
        Dim newKeyword As Keyword
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "monster" Then
            ClearAll()
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "sense" Then
                        newSense = New Sense
                        newSense.ImportXML(reader)
                        cSenses.Add(newSense)
                    ElseIf reader.Name = "keyword" Then
                        newKeyword = New Keyword
                        newKeyword.ImportXML(reader)
                        cKeywords.Add(newKeyword)
                    ElseIf reader.Name = "skill" Then
                        newSkill = New Skill
                        newSkill.ImportXML(reader)
                        cSkills.Add(newSkill)
                    ElseIf reader.Name = "immunity" Then
                        newImmunity = New Immunity
                        newImmunity.ImportXML(reader)
                        cImmunities.Add(newImmunity)
                    ElseIf reader.Name = "resistance" Then
                        newResistance = New Resistance
                        newResistance.ImportXML(reader)
                        cResistances.Add(newResistance)
                    ElseIf reader.Name = "vulnerability" Then
                        newVulnerability = New Vulnerability
                        newVulnerability.ImportXML(reader)
                        cVulnerabilities.Add(newVulnerability)
                    ElseIf reader.Name = "savingthrow" Then
                        newSavingThrow = New SavingThrow
                        newSavingThrow.ImportXML(reader)
                        cSavingThrows.Add(newSavingThrow)
                    ElseIf reader.Name = "speed" Then
                        newSpeed = New Speed
                        newSpeed.ImportXML(reader)
                        cSpeeds.Add(newSpeed)
                    ElseIf reader.Name = "trait" Then
                        newTrait = New Trait
                        newTrait.ImportXML(reader)
                        cTraits.Add(newTrait)
                    ElseIf reader.Name = "power" Then
                        newPower = New Power
                        newPower.ImportXML(reader)
                        cPowers.Add(newPower)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "name"
                            sName = reader.Value
                        Case "role"
                            sRole = reader.Value
                        Case "secondaryrole"
                            sSecondaryRole = reader.Value
                        Case "size"
                            sSize = reader.Value
                        Case "origin"
                            sOrigin = reader.Value
                        Case "type"
                            sType = reader.Value
                        Case "regendetails"
                            sRegenDetails = reader.Value
                        Case "languages"
                            sLanguages = reader.Value
                        Case "alignment"
                            sAlignment = reader.Value
                        Case "equipment"
                            sEquipment = reader.Value
                        Case "notes"
                            sNotes = reader.Value
                        Case "source"
                            sSource = reader.Value
                        Case "level"
                            nLevel = CInt(reader.Value)
                        Case "xp"
                            nXP = CInt(reader.Value)
                        Case "init"
                            nInit = CInt(reader.Value)
                        Case "hp"
                            nHP = CInt(reader.Value)
                        Case "ac"
                            nAC = CInt(reader.Value)
                        Case "fort"
                            nFort = CInt(reader.Value)
                        Case "ref"
                            nRef = CInt(reader.Value)
                        Case "will"
                            nWill = CInt(reader.Value)
                        Case "baseacatt"
                            nBaseACAtt = CInt(reader.Value)
                        Case "basefortatt"
                            nBaseFortAtt = CInt(reader.Value)
                        Case "baserefatt"
                            nBaseRefAtt = CInt(reader.Value)
                        Case "basewillatt"
                            nBaseWillAtt = CInt(reader.Value)
                        Case "actionpoints"
                            nActionPoints = CInt(reader.Value)
                        Case "str"
                            nStr = CInt(reader.Value)
                        Case "con"
                            nCon = CInt(reader.Value)
                        Case "dex"
                            nDex = CInt(reader.Value)
                        Case "wis"
                            nWis = CInt(reader.Value)
                        Case "int"
                            nInt = CInt(reader.Value)
                        Case "cha"
                            nCha = CInt(reader.Value)
                        Case "leader"
                            bLeader = CBool(reader.Value)
                    End Select
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "monster" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Public Sub Copy(ByRef tocopy As Monster)
        Dim newSense As New Sense
        Dim newSkill As New Skill
        Dim newImmunity As New Immunity
        Dim newResistance As New Resistance
        Dim newVulnerability As New Vulnerability
        Dim newSavingThrow As New SavingThrow
        Dim newSpeed As New Speed
        Dim newTrait As New Trait
        Dim newPower As New Power
        Dim newKeyword As New Keyword
        sName = tocopy.sName
        sRole = tocopy.sRole
        sSecondaryRole = tocopy.sSecondaryRole
        sSize = tocopy.sSize
        sOrigin = tocopy.sOrigin
        sType = tocopy.sType
        sRegenDetails = tocopy.sRegenDetails
        sLanguages = tocopy.sLanguages
        sAlignment = tocopy.sAlignment
        sEquipment = tocopy.sEquipment
        sNotes = tocopy.sNotes
        sSource = tocopy.sSource
        nLevel = tocopy.nLevel
        nXP = tocopy.nXP
        nInit = tocopy.nInit
        nHP = tocopy.nHP
        nAC = tocopy.nAC
        nFort = tocopy.nFort
        nRef = tocopy.nRef
        nWill = tocopy.nWill
        nBaseACAtt = tocopy.nBaseACAtt
        nBaseFortAtt = tocopy.nBaseFortAtt
        nBaseRefAtt = tocopy.nBaseRefAtt
        nBaseWillAtt = tocopy.nBaseWillAtt
        nActionPoints = tocopy.nActionPoints
        nStr = tocopy.nStr
        nCon = tocopy.nCon
        nDex = tocopy.nDex
        nWis = tocopy.nWis
        nInt = tocopy.nInt
        nCha = tocopy.nCha
        bLeader = tocopy.bLeader
        For Each subitem As Keyword In tocopy.cKeywords
            newKeyword.ClearAll()
            newKeyword.Copy(subitem)
            cKeywords.Add(New Keyword(newKeyword))
        Next
        For Each subitem As Sense In tocopy.cSenses
            newSense.ClearAll()
            newSense.Copy(subitem)
            cSenses.Add(New Sense(newSense))
        Next
        For Each subitem As Skill In tocopy.cSkills
            newSkill.ClearAll()
            newSkill.Copy(subitem)
            cSkills.Add(New Skill(newSkill))
        Next
        For Each subitem As Immunity In tocopy.cImmunities
            newImmunity.ClearAll()
            newImmunity.Copy(subitem)
            cImmunities.Add(New Immunity(newImmunity))
        Next
        For Each subitem As Resistance In tocopy.cResistances
            newResistance.ClearAll()
            newResistance.Copy(subitem)
            cSkills.Add(New Resistance(newResistance))
        Next
        For Each subitem As Vulnerability In tocopy.cVulnerabilities
            newVulnerability.ClearAll()
            newVulnerability.Copy(subitem)
            cVulnerabilities.Add(New Vulnerability(newVulnerability))
        Next
        For Each subitem As SavingThrow In tocopy.cSavingThrows
            newSavingThrow.ClearAll()
            newSavingThrow.Copy(subitem)
            cSavingThrows.Add(New SavingThrow(newSavingThrow))
        Next
        For Each subitem As Speed In tocopy.cSpeeds
            newSpeed.ClearAll()
            newSpeed.Copy(subitem)
            cSpeeds.Add(New Speed(newSpeed))
        Next
        For Each subitem As Trait In tocopy.cTraits
            newTrait.ClearAll()
            newTrait.Copy(subitem)
            cTraits.Add(New Trait(newTrait))
        Next
        For Each subitem As Power In tocopy.cPowers
            newPower.ClearAll()
            newPower.Copy(subitem)
            cPowers.Add(New Power(newPower))
        Next
    End Sub
    Public Sub ClearAll()
        sName = ""
        sRole = ""
        sSecondaryRole = ""
        sSize = ""
        sOrigin = ""
        sType = ""
        sRegenDetails = ""
        sLanguages = ""
        sAlignment = ""
        sEquipment = ""
        sNotes = ""
        sSource = ""
        nLevel = 1
        nXP = 100
        nInit = 0
        nHP = 25
        nAC = 10
        nFort = 10
        nRef = 10
        nWill = 10
        nBaseACAtt = 0
        nBaseFortAtt = 0
        nBaseRefAtt = 0
        nBaseWillAtt = 0
        nActionPoints = 0
        nStr = 10
        nCon = 10
        nDex = 10
        nWis = 10
        nInt = 10
        nCha = 10
        bLeader = False
        If cKeywords.Count > 0 Then cKeywords.Clear()
        If cSenses.Count > 0 Then cSenses.Clear()
        cSkills.Clear()
        cImmunities.Clear()
        cResistances.Clear()
        cVulnerabilities.Clear()
        cSavingThrows.Clear()
        cSpeeds.Clear()
        cTraits.Clear()
        cPowers.Clear()
    End Sub
    Public Function SaveToFile(ByVal filename As String) As Boolean
        Dim xmlSettings As New Xml.XmlWriterSettings
        xmlSettings.Indent = True
        xmlSettings.NewLineOnAttributes = True

        Dim tempfilename As String = filename & ".tmp"
        Dim tempfileinfo As New IO.FileInfo(tempfilename)
        If tempfileinfo.Exists Then tempfileinfo.Delete()

        Using fileXMLWriter As Xml.XmlWriter = Xml.XmlWriter.Create(tempfilename, xmlSettings)
            ExportXML(fileXMLWriter)
        End Using

        tempfileinfo.CopyTo(filename, True)
        tempfileinfo.Delete()

        Return True
    End Function
    Public ReadOnly Property HTMLOut()
        Get
            Return Statblock_HTML_Out()
        End Get
    End Property
    ReadOnly Property SkillBonus(ByVal skillname As String)
        Get
            Dim statmod As Integer
            Dim skillmod As Integer = 0
            If "acrobaticsstealththievery".Contains(skillname.ToLower) Then
                statmod = nDex
            ElseIf "athletics".Contains(skillname.ToLower) Then
                statmod = nStr
            ElseIf "endurance".Contains(skillname.ToLower) Then
                statmod = nCon
            ElseIf "dungeoneeringhealinsightnatureperception".Contains(skillname.ToLower) Then
                statmod = nWis
            ElseIf "arcanahistoryreligion".Contains(skillname.ToLower) Then
                statmod = nInt
            ElseIf "bluffdiplomacyintimidatestreetwise".Contains(skillname.ToLower) Then
                statmod = nCha
            Else
                statmod = 0
            End If
            statmod = StatLevelBonus(statmod, nLevel)
            For Each ski As Skill In cSkills
                If ski.sName.ToLower.Contains(skillname.ToLower) Then
                    skillmod = 0
                    If ski.bTrained Then skillmod += 5
                    skillmod += ski.nBonus
                End If
            Next
            Return statmod + skillmod
        End Get
    End Property
    ReadOnly Property sSpeeds() As String
        Get
            Dim output As New System.Text.StringBuilder
            output.Append("<b>Speed</b> ")
            Dim tempspeeds As New ArrayList
            For Each spd As Speed In cSpeeds
                If spd.sType = "Land" Then
                    output.Append(spd.nSpeed.ToString)
                    If spd.sDetails <> "" Then output.Append(" " & spd.sDetails)
                    If cSpeeds.Count > 1 Then output.Append(", ")
                Else : tempspeeds.Add(New Speed(spd))
                End If
            Next
            Dim index As Integer = 0
            For Each spd As Speed In tempspeeds
                If spd.sType <> "Land" Then
                    index += 1
                    If spd.nSpeed <> 0 Then
                        output.Append(spd.sType & " " & spd.nSpeed.ToString)
                    Else
                        output.Append(spd.sType)
                    End If
                    If spd.sDetails <> "" Then output.Append(" " & spd.sDetails)
                    If index < tempspeeds.Count Then output.Append(", ")
                End If
            Next
            Return output.ToString
        End Get
    End Property
    ReadOnly Property sImmunities() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cImmunities.Count > 0 Then
                output.Append("<b>Immune</b> ")
                For Each imm As Immunity In cImmunities
                    index += 1
                    output.Append(imm.sType)
                    If index < cImmunities.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    ReadOnly Property sResistances() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cResistances.Count > 0 Then
                output.Append("<b>Resist</b> ")
                index = 0
                For Each res As Resistance In cResistances
                    index += 1
                    If res.nAmount > 0 Then output.Append(res.nAmount.ToString & " ")
                    output.Append(res.sType)
                    If res.sDetails <> "" Then output.Append(" " & res.sDetails)
                    If index < cResistances.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    ReadOnly Property sVulnerabilities() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cVulnerabilities.Count > 0 Then
                output.Append("<b>Vulnerability</b> ")
                index = 0
                For Each vul As Vulnerability In cVulnerabilities
                    index += 1
                    If vul.nAmount > 0 Then output.Append(vul.nAmount.ToString & " ")
                    output.Append(vul.sType)
                    If vul.sDetails <> "" Then output.Append(" " & vul.sDetails)
                    If index < cVulnerabilities.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    ReadOnly Property sSavingThrows() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cSavingThrows.Count > 0 Then
                output.Append("<b>Saving Throws </b>")
                index = 0
                For Each sav As SavingThrow In cSavingThrows
                    index += 1
                    If sav.nBonus > 0 Then
                        output.Append("+")
                    ElseIf sav.nBonus < 0 Then
                        output.Append("-")
                    End If
                    output.Append(sav.nBonus.ToString)
                    If sav.sDetails <> "" Then output.Append(" " & sav.sDetails)
                    If index < cSavingThrows.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    ReadOnly Property nSavingThrow() As Integer
        Get
            If cSavingThrows.count > 0 Then
                Dim tempSave As SavingThrow = cSavingThrows.Item(0)
                Return tempSave.nBonus
            Else
                Return 0
            End If
        End Get
    End Property
    ReadOnly Property sSenses() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cSenses.Count > 0 Then
                index = 0
                For Each sen As Sense In cSenses
                    index += 1
                    output.Append(sen.sType)
                    If sen.nRange > 0 Then output.Append(" " & sen.nRange.ToString)
                    If index < cSenses.Count Then output.Append(",<br>")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    ReadOnly Property sSkills() As String
        Get
            Dim output As New System.Text.StringBuilder
            Dim index As Integer = 0
            If cSkills.Count > 0 Then
                index = 0
                For Each ski As Skill In cSkills
                    index += 1
                    output.Append(ski.sName & " ")
                    If SkillBonus(ski.sName) >= 0 Then output.Append("+")
                    output.Append(SkillBonus(ski.sName))
                    If index < cSkills.Count Then output.Append(", ")
                Next
            End If
            Return output.ToString
        End Get
    End Property
    Private Function Statblock_HTML_Out() As String
        If sName = "" Then
            Return ""
        End If

        Dim output As New System.Text.StringBuilder
        Dim tempPowers As New ArrayList
        ' Add HTML Header
        output.AppendLine("<html><head><style type='text/css'>html {font-family: Arial, Sans-Serif; font-size: 9.5pt}  body {margin: 0px; padding: 0px; text-align:left; font-weight: normal;}  DIV.symbol {font-family: DnD4Attack} DIV.mbwrap {width: 100%; max-width: 570px;}  DIV.ggdark {width: 100%; padding-left:5px; padding-right:5px; padding-top:2px; padding-bottom:2px; background-color: #374b27; min-height: 14px;}  DIV.mbheadleft {float: left;  align: left; color: #ffffff; font-size: 13px;}  DIV.mbheadright {float: right; align: right; color: #ffffff; font-size: 13px;}  DIV.mbsubleft {float: left; align: left; color: #ffffff;}  DIV.mbsubright {float: right; align: right; color: #ffffff;}  DIV.gglt {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #e1e6c4; min-height: 14px;}  DIV.ggmed {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #9fa48c; min-height: 14px; }  DIV.ggtype {width: 100%; padding-left:5px; padding-right:5px; padding-top:1px; padding-bottom:1px; background-color: #727c55; min-height: 14px; }  DIV.ggindent {padding-left:20px;} TD.indlt {padding-left: 4px; padding-right: 4px; font-size: 9.5pt; background-color: #e1e6c4;} TD.indmed {padding-left: 4px; padding-right: 4px; font-size: 9.5pt; background-color: #9fa48c;}</style></head><body>")

        ' Add Name/Type/Level Block
        output.AppendLine("<div class='ggdark'><div class='mbheadleft'><b>" & sName & "</b></div><div class='mbheadright'><b>" & sLevelRole & "</b></div></div>")
        output.AppendLine("<div class='ggdark'><div class='mbsubleft'>" & sTypeKeywords & "</div><div class='mbsubright'>XP " & nXP.ToString("#,0") & "</div></div>")

        ' Add HP and Bloodied
        output.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        output.Append("<tr><td class='indlt'><b>HP</b> ")
        If nHP = 1 Then
            output.Append("1, a missed attack never damages a minion.")
        Else
            output.Append(nHP.ToString("#,0") & "; <b>Bloodied</b> " & Math.Truncate(nHP / 2).ToString("#,0"))
        End If
        '     Add Regeneration line
        If sRegenDetails <> "" Then
            output.Append("<br><b>Regeneration</b> " & sRegenDetails)
        End If
        'Add(Resists, Immunities, Vulnerabilities)
        output.Append("<br><b>AC</b> " & CStr(nAC) & ", <b>Fortitude</b> " & CStr(nFort) & ", <b>Reflex</b> " & CStr(nRef) & ", <b>Will</b> " & CStr(nWill) & "<br>")
        output.Append(sSpeeds)
        If cImmunities.Count > 0 Or cResistances.Count > 0 Or cVulnerabilities.Count > 0 Then output.Append("<br>")
        output.Append(sImmunities)
        If cImmunities.Count > 0 And (cResistances.Count > 0 Or cVulnerabilities.Count > 0) Then output.Append("; ")
        output.Append(sResistances)
        If cResistances.Count > 0 And cVulnerabilities.Count > 0 Then output.Append("; ")
        output.Append(sVulnerabilities)
        '    Add Saving Throw Bonuses, Action Points, and Power Points
        If cSavingThrows.Count > 0 Or nActionPoints > 0 Then output.Append("<br>")
        output.Append(sSavingThrows)
        If cSavingThrows.Count > 0 And nActionPoints > 0 Then output.Append("; ")
        If nActionPoints > 0 Then output.Append("<b>Action Points</b> " & CStr(nActionPoints))

        output.AppendLine("</td>")

        '     Add Initiative and Senses line
        output.Append("<td class='indlt' align='right'>")
        output.Append("<b>Initiative</b> ")
        If nInit >= 0 Then
            output.Append("+")
        End If
        output.Append(CStr(nInit) & "<br>")
        output.Append("<b>Perception</b> ")
        If SkillBonus("Perception") >= 0 Then output.Append("+")
        output.Append(SkillBonus("Perception").ToString & "<br>")
        If SkillBonus("Insight") <> 0 Then
            output.Append("<b>Insight</b> ")
            If SkillBonus("Insight") >= 0 Then output.Append("+")
            output.Append(SkillBonus("Insight").ToString & "<br>")
        End If
        output.Append(sSenses)
        output.AppendLine("</td></tr></table>")
        If cTraits.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Traits</b></div></div>")
            For Each tr As Trait In cTraits
                output.AppendLine(tr.HTML_Out)
            Next

        End If
        'Standard Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower = "standard" Then
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Standard Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If
        'Move Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower = "move" Then
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Move Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If
        'Minor Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower = "minor" Then
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Minor Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If
        'Free Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower = "free" And pow.sTrigger = "" Then
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Free Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If
        'Triggered Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower.Contains("immediate") Or pow.sActionType.ToLower.Contains("opportunity") Or pow.sActionType.ToLower.Contains("no action") Then
                tempPowers.Add(New Power(pow))
            ElseIf pow.sActionType.ToLower.Contains("free") And pow.sTrigger <> "" Then
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Triggered Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If
        'Other Actions
        tempPowers.Clear()
        For Each pow As Power In cPowers
            If pow.sActionType.ToLower.Contains("immediate") Or pow.sActionType.ToLower.Contains("opportunity") Or pow.sActionType.ToLower.Contains("no action") Or (pow.sActionType.ToLower = "free" And pow.sTrigger = "") Or pow.sActionType.ToLower = "minor" Or pow.sActionType.ToLower = "move" Or pow.sActionType.ToLower = "standard" Then
            Else
                tempPowers.Add(New Power(pow))
            End If
        Next
        If tempPowers.Count > 0 Then
            output.AppendLine("<div class='ggtype'><div class='mbsubleft'><b>Other Actions</b></div></div>")
            For Each pow As Power In tempPowers
                output.AppendLine(pow.HTML_Out)
            Next
        End If

        ' Start Statblock Table
        output.AppendLine("<div class='ggmed'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        ' Add Skills line
        If sSkills <> "" Then
            output.AppendLine("<tr><td colspan='3' class='indmed'><b>Skills</b> " & sSkills & "</td></tr>")
        End If

        ' Add Feats line
        'If sFeats <> "" Then
        'output.AppendLine("<tr><td colspan='3' class='indmed'><b>Feats</b> " & sFeats & "</td></tr>")
        'End If

        ' Add Stats
        If nStr > 0 Then
            output.Append("<tr><td class='indmed'><b>Str</b> " & StatAndBonus(nStr, nLevel) & "</td>")
            output.Append("<td class='indmed'><b>Dex</b> " & StatAndBonus(nDex, nLevel) & "</td>")
            output.Append("<td class='indmed'><b>Wis</b> " & StatAndBonus(nWis, nLevel) & "</td></tr>")
            output.Append("<tr><td class='indmed'><b>Con</b> " & StatAndBonus(nCon, nLevel) & "</td>")
            output.Append("<td class='indmed'><b>Int</b> " & StatAndBonus(nInt, nLevel) & "</td>")
            output.Append("<td class='indmed'><b>Cha</b> " & StatAndBonus(nCha, nLevel) & "</td></tr>")
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
        If sNotes <> "" Then
            output.Append("<b>Notes:")
            output.Append("  " & sNotes.Replace("###", "<br>"))
        End If

        ' Add close
        output.AppendLine("</div></body></html>")

        ' Return assembled HTML
        Return output.ToString
        Return output.ToString
    End Function
    Public Function LoadFromMonsterFile(ByVal filename As String) As Boolean
        Dim filetool As New IO.FileInfo(filename)
        Dim xmlSettings As New System.Xml.XmlReaderSettings
        If filetool.Exists Then
            Using fileXMLReader As Xml.XmlReader = Xml.XmlReader.Create(filename, xmlSettings)
                fileXMLReader.MoveToContent()
                If Not fileXMLReader.EOF Then
                    While fileXMLReader.NodeType <> Xml.XmlNodeType.Element And Not fileXMLReader.EOF
                        fileXMLReader.Read()
                    End While
                    ImportMonsterFromATXML(fileXMLReader)
                    Return True
                End If
            End Using
        End If
        Return False
    End Function
    Public Sub ImportMonsterFromATXML(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim itemList As New Hashtable

        ClearAll()

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Monster" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "AbilityScores" Then
                        ImportMonsterFromATXML_Abilities(reader)
                    ElseIf reader.Name = "Defenses" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Defenses(reader)
                    ElseIf reader.Name = "AttackBonuses" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_AttackBonuses(reader)
                    ElseIf reader.Name = "Skills" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Skills(reader)
                    ElseIf reader.Name = "Items" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Items(reader)
                    ElseIf reader.Name = "Languages" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Languages(reader)
                    ElseIf reader.Name = "Senses" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Senses(reader)
                    ElseIf reader.Name = "Keywords" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Keywords(reader)
                    ElseIf reader.Name = "Powers" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Powers(reader)
                    ElseIf reader.Name = "Speeds" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Speeds(reader)
                    ElseIf reader.Name = "SavingThrows" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_SavingThrows(reader)
                    ElseIf reader.Name = "Weaknesses" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Weaknesses(reader)
                    ElseIf reader.Name = "Immunities" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Immunities(reader)
                    ElseIf reader.Name = "Resistances" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Resistances(reader)
                    ElseIf reader.Name = "SourceBooks" And Not reader.IsEmptyElement Then
                        ImportMonsterFromATXML_Sources(reader)
                    ElseIf reader.Name = "Size" Or reader.Name = "Origin" Or reader.Name = "Type" Or _
                    reader.Name = "GroupRole" Or reader.Name = "Alignment" Or reader.Name = "Regeneration" _
                    Or reader.Name = "Initiative" Or reader.Name = "HitPoints" Or reader.Name = _
                    "ActionPoints" Or reader.Name = "LandSpeed" Or reader.Name = "Experience" Or _
                    reader.Name = "Role" Then
                        ImportMonsterFromATXML_Details(reader, reader.Name)
                    Else
                        elementName = reader.Name
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    Select Case elementName
                        Case "IsLeader"
                            bLeader = CBool(reader.Value)
                        Case "Phasing"
                            If CBool(reader.Value) Then
                                Dim tempspeed As New Speed
                                tempspeed.sType = "phasing"
                                cSpeeds.Add(tempspeed)
                            End If
                        Case "Name"
                            sName = reader.Value
                        Case "Level"
                            nLevel = Val(reader.Value)
                            REM                        Case "Description"
                            REM                            sNotes = reader.Value
                    End Select
                End If
                If reader.NodeType = Xml.XmlNodeType.EndElement _
                And reader.Name = "Monster" Then
                    Exit Do
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Abilities(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "AbilityScores" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "AbilityScoreNumber" Then
                        Dim tempAbil As Integer = Val(reader.GetAttribute("FinalValue"))
                        Dim tempAbilName As String = ""
                        GetXMLFields(p_reader, "AbilityScoreNumber", "Name", tempAbilName)
                        Select Case tempAbilName
                            Case "Strength"
                                nStr = tempAbil
                            Case "Dexterity"
                                nDex = tempAbil
                            Case "Constitution"
                                nCon = tempAbil
                            Case "Intelligence"
                                nInt = tempAbil
                            Case "Wisdom"
                                nWis = tempAbil
                            Case "Charisma"
                                nCha = tempAbil
                        End Select
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "AbilityScores" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Defenses(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Defenses" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "SimpleAdjustableNumber" Then
                        Dim tempDef As Integer = Val(reader.GetAttribute("FinalValue"))
                        Dim tempDefName As String = ""
                        GetXMLFields(p_reader, "SimpleAdjustableNumber", "Name", tempDefName)
                        Select Case tempDefName
                            Case "AC"
                                nAC = tempDef
                            Case "Fortitude"
                                nFort = tempDef
                            Case "Reflex"
                                nRef = tempDef
                            Case "Will"
                                nWill = tempDef
                        End Select
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Defenses" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_AttackBonuses(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "AttackBonuses" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "CalculatedNumber" Then
                        Dim tempDef As Integer = Val(reader.GetAttribute("FinalValue"))
                        Dim tempDefName As String = ""
                        GetXMLFields(p_reader, "CalculatedNumber", "Name", tempDefName)
                        Select Case tempDefName
                            Case "Attack vs. AC"
                                nBaseACAtt = tempDef
                            Case "Attack vs. Fortitude"
                                nBaseFortAtt = tempDef
                            Case "Attack vs. Reflex"
                                nBaseRefAtt = tempDef
                            Case "Attack vs. Will"
                                nBaseWillAtt = tempDef
                        End Select
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "AttackBonuses" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Skills(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Skills" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "SkillNumber" Then
                        Dim tempSkill As New Skill
                        GetXMLFields(p_reader, "SkillNumber", "Name", tempSkill.sName, "Value", tempSkill.nBonus, "Trained", tempSkill.bTrained)
                        If tempSkill.nBonus > 0 Or tempSkill.bTrained Then
                            cSkills.Add(New Skill(tempSkill))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Skills" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Items(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim itemList As New ArrayList
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Items" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ItemAndQuantity" Then
                        Dim tempItemName As String = ""
                        Dim tempItemQuantity As Integer = 0
                        Dim tempItemString As String = ""
                        GetXMLFields(p_reader, "ItemAndQuantity", "Name", tempItemName, "Quantity", tempItemQuantity)
                        If tempItemQuantity > 0 And tempItemName <> "" Then
                            tempItemString += tempItemName
                            If tempItemQuantity > 1 Then tempItemString += " x" & tempItemQuantity.ToString
                            itemList.Add(tempItemString)
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Items" Then
                        Dim index As Integer = 0
                        sEquipment = ""
                        For Each tItem As String In itemList
                            sEquipment += tItem.ToString
                            index += 1
                            If index < itemList.Count Then sEquipment += ", "
                        Next
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Languages(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim langList As New ArrayList
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Languages" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ReferencedObject" Then
                        Dim tempLangName As String = ""
                        GetXMLFields(p_reader, "ReferencedObject", "Name", tempLangName)
                        If tempLangName <> "" Then
                            langList.Add(tempLangName)
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Languages" Then
                        Dim index As Integer = 0
                        sLanguages = ""
                        For Each tLang As String In langList
                            sLanguages += tLang.ToString
                            index += 1
                            If index < langList.Count Then sLanguages += ", "
                        Next
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Sources(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim sourceList As New ArrayList
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "SourceBooks" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ReferencedObject" Then
                        Dim tempSourceName As String = ""
                        GetXMLFields(p_reader, "ReferencedObject", "Name", tempSourceName)
                        If tempSourceName <> "" Then
                            sourceList.Add(tempSourceName)
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "SourceBooks" Then
                        Dim index As Integer = 0
                        sSource = ""
                        For Each tSource As String In sourceList
                            sSource += tSource.ToString
                            index += 1
                            If index < sourceList.Count Then sSource += ", "
                        Next
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_SavingThrows(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "SavingThrows" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterSavingThrow" Then
                        Dim tempSave As New SavingThrow
                        tempSave.nBonus = reader.GetAttribute("FinalValue")
                        GetXMLFields(p_reader, "MonsterSavingThrow", "Details", tempSave.sDetails)
                        If tempSave.nBonus <> 0 Then
                            cSavingThrows.Add(New SavingThrow(tempSave))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "SavingThrows" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Weaknesses(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Weaknesses" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "CreatureSusceptibility" Then
                        Dim tempVuln As New Vulnerability
                        GetXMLFields(p_reader, "CreatureSusceptibility", "ReferencedObject!Name", tempVuln.sType, "Amount.FinalValue", tempVuln.nAmount, "Details", tempVuln.sDetails)
                        If tempVuln.nAmount <> 0 Then
                            If tempVuln.sType.ToLower = "against" Then
                                tempVuln.sType += " " & tempVuln.sDetails
                                tempVuln.sDetails = ""
                            End If
                            cVulnerabilities.Add(New Vulnerability(tempVuln))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Weaknesses" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Immunities(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Immunities" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ObjectReference" Then
                        Dim tempImm As New Immunity
                        GetXMLFields(p_reader, "ObjectReference", "ReferencedObject!Name", tempImm.sType)
                        If tempImm.sType <> "" Then
                            cImmunities.Add(New Immunity(tempImm))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Immunities" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Resistances(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Resistances" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "CreatureSusceptibility" Then
                        Dim tempRes As New Resistance
                        GetXMLFields(p_reader, "CreatureSusceptibility", "ReferencedObject!Name", tempRes.sType, "Amount.FinalValue", tempRes.nAmount, "Details", tempRes.sDetails)
                        If tempRes.nAmount <> 0 Or tempRes.sType <> "" Then
                            If tempRes.sType.ToLower = "against" Then
                                tempRes.sType += " " & tempRes.sDetails
                                tempRes.sDetails = ""
                            End If
                            cResistances.Add(New Resistance(tempRes))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Resistances" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

    Public Sub ImportMonsterFromATXML_Senses(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Senses" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "SenseReference" Then
                        Dim tempSense As New Sense
                        GetXMLFields(p_reader, "SenseReference", "Name", tempSense.sType, "Range", tempSense.nRange)
                        If tempSense.sType <> "" Then
                            tempSense.sType = StrConv(tempSense.sType, VbStrConv.ProperCase)
                            cSenses.Add(New Sense(tempSense))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Senses" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Speeds(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Speeds" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "CreatureSpeed" Then
                        Dim tempSpeed As New Speed
                        GetXMLFields(p_reader, "CreatureSpeed", "ReferencedObject!Name", tempSpeed.sType, "Speed.FinalValue", tempSpeed.nSpeed, "Details", tempSpeed.sDetails)
                        If tempSpeed.sType <> "" Then
                            If tempSpeed.sType = "Speed" Then
                                'Fix Speed entry to show correct entry.  XML File sticks the name in a subnode.  Having trouble getting to it.
                            End If
                            tempSpeed.sType = StrConv(tempSpeed.sType, VbStrConv.ProperCase)
                            cSpeeds.Add(New Speed(tempSpeed))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Speeds" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

    Public Sub ImportMonsterFromATXML_Keywords(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Keywords" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "ReferencedObject" Then
                        Dim tempItem As New Keyword
                        GetXMLFields(p_reader, "ReferencedObject", "Name", tempItem.sName)
                        If tempItem.sName <> "" Then
                            tempItem.sName = StrConv(tempItem.sName, VbStrConv.ProperCase)
                            cKeywords.Add(tempItem)
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Keywords" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub
    Public Sub ImportMonsterFromATXML_Powers(ByRef p_reader As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Powers" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "MonsterTrait" Then
                        Dim tempTrait As New Trait
                        tempTrait.ATXMLImport(reader)
                        If tempTrait.sName <> "" Then
                            cTraits.Add(New Trait(tempTrait))
                        End If
                    ElseIf reader.Name = "MonsterPower" Then
                        Dim tempPower As New Power
                        tempPower.ATXMLImport(reader)
                        If tempPower.sName <> "" Then
                            cPowers.Add(New Power(tempPower))
                        End If
                    Else
                        elementName = reader.Name.ToLower
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "Powers" Then
                        Exit Sub
                    End If
                End If
            Loop
        End If
    End Sub

    Public Sub ImportMonsterFromATXML_Details(ByRef p_reader As Object, ByVal p_name As String)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Select Case p_name
            Case "Initiative"
                nInit = Val(reader.GetAttribute("FinalValue"))
            Case "HitPoints"
                nHP = Val(reader.GetAttribute("FinalValue"))
            Case "ActionPoints"
                nActionPoints = Val(reader.GetAttribute("FinalValue"))
            Case "LandSpeed"
                Dim tSpeed As New Speed
                tSpeed.sType = "Land"
                GetXMLFields(reader, p_name, "Speed.FinalValue", tSpeed.nSpeed, "Details", tSpeed.sDetails)
                If tSpeed.nSpeed > 0 Then cSpeeds.Add(tSpeed)
            Case "Experience"
                nXP = Val(reader.GetAttribute("FinalValue"))
            Case "Role"
                GetXMLFields(reader, p_name, "Name", sRole)
            Case "Size"
                GetXMLFields(reader, p_name, "Name", sSize)
            Case "Origin"
                GetXMLFields(reader, p_name, "Name", sOrigin)
            Case "Type"
                GetXMLFields(reader, p_name, "Name", sType)
            Case "GroupRole"
                GetXMLFields(reader, p_name, "Name", sSecondaryRole)
                If sSecondaryRole = "Standard" Then sSecondaryRole = ""
            Case "Alignment"
                GetXMLFields(reader, p_name, "Name", sAlignment)
            Case "Regeneration"
                Dim nRegBonus As Integer = 0
                Dim sRegDetails As String = ""
                GetXMLFields(reader, p_name, "Value", nRegBonus, "Details", sRegDetails)
                If nRegBonus > 0 Then
                    sRegenDetails = nRegBonus.ToString
                    If sRegDetails <> "" Then
                        sRegenDetails += " "
                    End If
                    If sRegDetails <> "" Then
                        sRegenDetails += "(" & sRegDetails & ")"
                    End If
                End If
        End Select
    End Sub


End Class

