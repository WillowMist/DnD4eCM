Public Class DnDLibrary
    Shared Function StatLevelBonus(ByVal stat As Integer, ByVal level As Integer)
        Return Math.Truncate((stat / 2) - 5) + Math.Truncate(level / 2)
    End Function
    Shared Function LevelBonus(ByVal level As Integer)
        Return Math.Truncate(level / 2)
    End Function
    Shared Function StatBonus(ByVal stat As Integer)
        Return Math.Truncate((stat / 2) - 5)
    End Function
    Shared Function StatAndBonus(ByVal stat As Integer, ByVal level As Integer) As String
        Dim output As New System.Text.StringBuilder
        output.Append(stat.ToString & " (")
        If Math.Truncate((stat / 2) - 5) >= 0 Then output.Append("+")
        output.Append(Math.Truncate((stat / 2) - 5) + Math.Truncate(level / 2) & ")")
        Return output.ToString
    End Function
    Shared Function HTMLDice(ByVal dice As Integer) As String
        Dim output As New System.Text.StringBuilder
        output.Append("<font face='4etools symbols'>")
        For i = dice To 6
            output.Append(i.ToString)
            If i < 6 Then output.Append(" ")
        Next
        output.Append("</font>")
        Return output.ToString
    End Function
    Shared Function GetXMLFields(ByRef p_reader As Object, ByVal mainkey As String, ByVal key1 As String, ByRef prop1 As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attr1 As String = ""
        Dim subkey1 As String = ""
        If key1.Contains("!") Then
            subkey1 = key1.Substring(key1.IndexOf("!") + 1)
            key1 = key1.Substring(0, key1.IndexOf("!"))
        Else
            If key1.Contains(".") Then
                attr1 = key1.Substring(key1.IndexOf(".") + 1)
                key1 = key1.Substring(0, key1.IndexOf("."))
            End If
        End If
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = mainkey Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = key1 Then
                        If subkey1 <> "" Then
                            GetXMLFields(p_reader, key1, subkey1, prop1)
                        End If
                        If attr1 <> "" And reader.Value.ToLower <> "ad hoc" Then prop1 = reader.GetAttribute(attr1)
                    End If
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    If elementName = key1 And reader.Value.ToLower <> "ad hoc" Then
                        prop1 = reader.Value
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = mainkey Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Shared Function IntToIteration(ByVal p_int As Integer) As String
        Select Case p_int
            Case 0
                Return "Zeroth"
            Case 1
                Return "First"
            Case 2
                Return "Second"
            Case 3
                Return "Third"
            Case 4
                Return "Fourth"
            Case 5
                Return "Fifth"
            Case 6
                Return "Sixth"
            Case 7
                Return "Seventh"
            Case 8
                Return "Eighth"
            Case Else
                Return ""
        End Select
    End Function
    Shared Function getXMLFields(ByRef p_reader As Object, ByVal mainkey As String, ByVal key1 As String, ByRef prop1 As Object, ByVal key2 As String, ByRef prop2 As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attr1 As String = ""
        Dim attr2 As String = ""
        Dim subkey1 As String = ""
        Dim subkey2 As String = ""
        If key1.Contains("!") Then
            subkey1 = key1.Substring(key1.IndexOf("!") + 1)
            key1 = key1.Substring(0, key1.IndexOf("!"))
        Else
            If key1.Contains(".") Then
                attr1 = key1.Substring(key1.IndexOf(".") + 1)
                key1 = key1.Substring(0, key1.IndexOf("."))
            End If
        End If
        If key2.Contains("!") Then
            subkey2 = key2.Substring(key2.IndexOf("!") + 1)
            key2 = key2.Substring(0, key2.IndexOf("!"))
        Else
            If key2.Contains(".") Then
                attr2 = key2.Substring(key2.IndexOf(".") + 1)
                key2 = key2.Substring(0, key2.IndexOf("."))
            End If
        End If
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = mainkey Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = key1 Then
                        If subkey1 <> "" Then
                            getXMLFields(p_reader, key1, subkey1, prop1)
                        End If
                        If attr1 <> "" And reader.Value.ToLower <> "ad hoc" Then prop1 = reader.GetAttribute(attr1)
                    ElseIf reader.Name = key2 Then
                        If subkey2 <> "" Then
                            getXMLFields(p_reader, key2, subkey2, prop2)
                        End If
                        If attr2 <> "" And reader.Value.ToLower <> "ad hoc" Then prop2 = reader.GetAttribute(attr2)
                    End If
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    If elementName = key1 And reader.Value.ToLower <> "ad hoc" Then
                        prop1 = reader.Value
                    ElseIf elementName = key2 And reader.Value.ToLower <> "ad hoc" Then
                        prop2 = reader.Value
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = mainkey Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function
    Shared Function getXMLFields(ByRef p_reader As Object, ByVal mainkey As String, ByVal key1 As String, ByRef prop1 As Object, ByVal key2 As String, ByRef prop2 As Object, ByVal key3 As String, ByRef prop3 As Object)
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim attr1 As String = ""
        Dim attr2 As String = ""
        Dim attr3 As String = ""
        Dim subkey1 As String = ""
        Dim subkey2 As String = ""
        Dim subkey3 As String = ""
        If key1.Contains("!") Then
            subkey1 = key1.Substring(key1.IndexOf("!") + 1)
            key1 = key1.Substring(0, key1.IndexOf("!"))
        Else
            If key1.Contains(".") Then
                attr1 = key1.Substring(key1.IndexOf(".") + 1)
                key1 = key1.Substring(0, key1.IndexOf("."))
            End If
        End If
        If key2.Contains("!") Then
            subkey2 = key2.Substring(key2.IndexOf("!") + 1)
            key2 = key2.Substring(0, key2.IndexOf("!"))
        Else
            If key2.Contains(".") Then
                attr2 = key2.Substring(key2.IndexOf(".") + 1)
                key2 = key2.Substring(0, key2.IndexOf("."))
            End If
        End If
        If key3.Contains("!") Then
            subkey3 = key3.Substring(key3.IndexOf("!") + 1)
            key3 = key3.Substring(0, key3.IndexOf("!"))
        Else
            If key3.Contains(".") Then
                attr3 = key3.Substring(key3.IndexOf(".") + 1)
                key3 = key3.Substring(0, key3.IndexOf("."))
            End If
        End If
        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = mainkey Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = key1 Then
                        If subkey1 <> "" Then
                            getXMLFields(p_reader, key1, subkey1, prop1)
                        End If
                        If attr1 <> "" And reader.Value.ToLower <> "ad hoc" Then prop1 = reader.GetAttribute(attr1)
                    ElseIf reader.Name = key2 Then
                        If subkey2 <> "" Then
                            getXMLFields(p_reader, key2, subkey2, prop2)
                        End If
                        If attr2 <> "" And reader.Value.ToLower <> "ad hoc" Then prop2 = reader.GetAttribute(attr2)
                    ElseIf reader.Name = key3 Then
                        If subkey3 <> "" Then
                            getXMLFields(p_reader, key3, subkey3, prop3)
                        End If
                        If attr3 <> "" And reader.Value.ToLower <> "ad hoc" Then prop3 = reader.GetAttribute(attr2)
                    End If
                    elementName = reader.Name
                ElseIf reader.NodeType = Xml.XmlNodeType.Text Then
                    If elementName = key1 And reader.Value.ToLower <> "ad hoc" Then
                        prop1 = reader.Value
                    ElseIf elementName = key2 And reader.Value.ToLower <> "ad hoc" Then
                        prop2 = reader.Value
                    ElseIf elementName = key3 And reader.Value.ToLower <> "ad hoc" Then
                        prop3 = reader.Value
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = mainkey Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
        Return False
    End Function

End Class
