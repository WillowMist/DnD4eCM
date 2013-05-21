Public Class StatLibrary

    ' Library Collection
    Public StatblockLibrary As New Hashtable


    ' Data Manipulation
    Public Function Add(ByRef stat As Statblock, ByVal overwrite As Boolean) As Boolean
        If Not stat.Valid Then
            Return False
        End If
        If StatblockLibrary.ContainsKey(stat.sHandle) Then
            If overwrite Then
                StatblockLibrary(stat.sHandle) = stat
            Else
                Return False
            End If
        Else
            StatblockLibrary.Add(stat.sHandle, stat)
            Return True
        End If
    End Function
    Public Function Add(ByRef stat As Statblock) As Boolean
        Return Add(stat, False)
    End Function
    Public Function Remove(ByVal handle As String) As Boolean
        If StatblockLibrary.ContainsKey(handle) Then
            StatblockLibrary.Remove(handle)
            Return True
        Else
            Return False
        End If
    End Function
    Default Property Item(ByVal handle As String) As Statblock
        Get
            Return StatblockLibrary(handle)
        End Get
        Set(ByVal stat As Statblock)
            If stat.Valid Then
                StatblockLibrary(handle) = stat
            End If
        End Set
    End Property
    Default Property Item(ByVal index As Integer) As Statblock
        Get
            Return StatblockLibrary(index)
        End Get
        Set(ByVal stat As Statblock)
            If stat.Valid Then
                StatblockLibrary(index) = stat
            End If
        End Set
    End Property
    Public Sub Clear()
        StatblockLibrary.Clear()
    End Sub
    Public ReadOnly Property Contains(ByVal handle As String) As Boolean
        Get
            Return StatblockLibrary.Contains(handle)
        End Get
    End Property


    ' XML Import/Export
    Public Sub ExportXML(ByRef p_writer As Object)
        Dim writer As System.Xml.XmlWriter = p_writer

        writer.WriteStartElement("statblocklibrary")

        For Each stat As Statblock In StatblockLibrary.Values
            stat.ExportXML(writer)
        Next

        writer.WriteEndElement()
    End Sub
    Public Function ImportXML(ByRef p_reader As Object) As Boolean
        Dim reader As System.Xml.XmlReader = p_reader
        Dim elementName As String = ""
        Dim newstat As Statblock

        If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "statblocklibrary" Then
            Do While reader.Read
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    If reader.Name = "statblock" Then
                        newstat = New Statblock
                        newstat.ImportXML(reader)
                        Add(newstat)
                    End If
                ElseIf reader.NodeType = Xml.XmlNodeType.EndElement Then
                    If reader.Name = "statblocklibrary" Then
                        Return True
                    End If
                End If
            Loop
        Else
            Return False
        End If
    End Function


    ' Load/Save
    Public Function LoadFromFile(ByVal filename As String, ByVal bClearBeforeLoading As Boolean) As Boolean
        Dim xmlSettings As New System.Xml.XmlReaderSettings

        Dim backupfiletool As New IO.FileInfo(filename & ".bak")
        If backupfiletool.Exists Then
            ' May be a problem if this happens
            MsgBox("Previous Compendium backup found." & ControlChars.NewLine & _
                   "It is possible a previous session failed." & ControlChars.NewLine & _
                   "Backup has been copied to prevent data-loss.", MsgBoxStyle.Exclamation, "Backup Found")
            backupfiletool.CopyTo(filename & ".saved.bak", True)
        End If

        Dim filetool As New IO.FileInfo(filename)
        If filetool.Exists Then
            filetool.CopyTo(filename & ".bak", True)

            Using fileXMLReader As Xml.XmlReader = Xml.XmlReader.Create(filename, xmlSettings)
                fileXMLReader.MoveToContent()
                If Not fileXMLReader.EOF Then
                    While fileXMLReader.NodeType <> Xml.XmlNodeType.Element And Not fileXMLReader.EOF
                        fileXMLReader.Read()
                    End While
                    If bClearBeforeLoading Then Clear()
                    ImportXML(fileXMLReader)
                End If
            End Using
        Else
            Return False
        End If

        Return True
    End Function
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

        Dim backupfileinfo As New IO.FileInfo(filename & ".bak")
        If backupfileinfo.Exists Then
            backupfileinfo.Delete()
        End If

        Return True
    End Function


End Class
