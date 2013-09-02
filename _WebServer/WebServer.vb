Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml


Public Class WebServer
#Region "Declarations"
    Private Shared singleWebserver As WebServer
    Private Shared blnFlag As Boolean
    Private activeListen As Boolean
    Private timer1 As Timer
    Private timer2 As Timer
    Private LocalTCPListener As TcpListener
    Private LocalPort As Integer = My.Settings.htmlPort
    Private LocalAddress As IPAddress = GetIPAddress()
    Private DefaultDoc As String = "index.html"
    Private WebThread As Thread
    Private LocalImageDir As String
    Private LocalVirtualRoot As String = My.Application.Info.DirectoryPath & "\"
    Private cmHTMLInitList As HTMLInitList = HTMLInitList.getHTMLInitList
#End Region

#Region "Properties"
    Public Property ListenWebPort() As Integer
        Get
            Return LocalPort
        End Get
        Set(ByVal Value As Integer)
            LocalPort = Value
        End Set
    End Property

    Public ReadOnly Property ListenIPAddress() As IPAddress
        Get
            Return LocalAddress
        End Get
    End Property


    Public Property DefaultDocument() As String
        Get
            Return DefaultDoc
        End Get
        Set(ByVal Value As String)
            DefaultDoc = Value
        End Set
    End Property

    Public Property ImageDirectory() As String
        Get
            Return LocalImageDir
        End Get
        Set(ByVal Value As String)
            LocalImageDir = Value
        End Set
    End Property

    Public Property VirtualRoot() As String
        Get
            Return LocalVirtualRoot
        End Get
        Set(ByVal Value As String)
            LocalVirtualRoot = Value
        End Set
    End Property
    Public ReadOnly Property Running() As Boolean
        Get
            Return activeListen
        End Get
    End Property
#End Region

#Region "Methods"

    Private Function GetIPAddress() As IPAddress
        Dim oAddr As System.Net.IPAddress
        REM Dim sAddr As String
        With System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            If .AddressList.Length > 0 Then
                oAddr = New IPAddress(.AddressList.GetLowerBound(0))
            Else : oAddr = New IPAddress(.AddressList.GetLowerBound(0))
            End If
            GetIPAddress = oAddr
        End With
    End Function


    Friend Shared Function getWebServer() As WebServer
        If Not blnFlag Then
            singleWebserver = New WebServer
            blnFlag = True
            Return singleWebserver
        Else
            Return singleWebserver
        End If
    End Function


    Public Function StartWebServer()
        Try
            LocalPort = My.Settings.htmlPort
            activeListen = True
            LocalTCPListener = New TcpListener(LocalAddress, LocalPort)
            Firewall("open", LocalPort)
            LocalTCPListener.Start()
            WebThread = New Thread(AddressOf StartListen)
            WebThread.Start()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MessageBox.Show("Error starting web server - port already in use?")
            Return False
        End Try
        Return True

    End Function
    Public Sub Firewall(ByVal cmd As String, ByVal port As Integer)
        Dim firewall As New ProcessStartInfo
        firewall.UseShellExecute = False
        firewall.CreateNoWindow = True
        firewall.FileName = "netsh.exe"
        If cmd.ToLower = "open" Then
            firewall.Arguments = "firewall add portopening TCP " + port.ToString + " DnD4eCM ENABLE ALL"
        ElseIf cmd.ToLower = "close" Then
            firewall.Arguments = "firewall delete portopening TCP " + port.ToString + " ALL"
        End If
        Process.Start(firewall)
    End Sub

    'Here is where we check our XML file and see what MIME types are defined and handle the accordingly.

    Public Function GetMimeType(ByVal sRequestFile As String) As String
        REM Dim sr As StreamReader
        Dim sLine As String = ""
        Dim sMimeType As String = ""
        Dim sFileExt As String = ""
        Dim sMimeExt As String = ""
        sRequestFile = sRequestFile.ToLower
        Dim iStartPos As Integer = sRequestFile.IndexOf(".") + 1
        sFileExt = sRequestFile.Substring(iStartPos)
        'now go through the mime definitions and apply to the request.
        Dim dom As New XmlDocument
        dom.Load(Application.StartupPath & "\Settings.xml")
        Dim objCurrentNode As XmlNode
        objCurrentNode = dom.SelectSingleNode("//mimetypes")
        'now go through all child nodes.
        If objCurrentNode.HasChildNodes Then
            'loop
            Dim xmlMimeType As XmlNode
            For Each xmlMimeType In objCurrentNode
                sMimeExt = xmlMimeType.Name
                sMimeType = xmlMimeType.InnerText
                If (sMimeExt = sFileExt) Then
                    Exit For
                End If
            Next
        End If
        If sMimeExt = sFileExt Then
            Return sMimeType
        Else
            Return ""
        End If
    End Function

    Public Function GetTheDefaultFileName(ByVal sLocalDirectory As String) As String
        Return "index.html"
    End Function

    Public Function GetLocalPath(ByVal sWebServerRoot As String, ByVal sDirName As String) As String
        'Dim sr As StreamReader
        'Dim sLine As String = ""
        Dim sVirtualDir As String = ""
        Dim sRealDir As String = ""
        Dim iStartPos As Integer = 0
        sDirName.Trim()
        sWebServerRoot = sWebServerRoot.ToLower
        sDirName = sDirName.ToLower
        Select Case sDirName
            Case "/"
                sRealDir = LocalVirtualRoot
            Case Else
                If Mid$(sDirName, 1, 1) = "/" Then
                    sDirName = Mid$(sDirName, 2, Len(sDirName))
                End If
                sRealDir = LocalVirtualRoot & sDirName.Replace("/", "\")
        End Select
        Return sRealDir
    End Function

    Public Sub SendHeader(ByVal sHttpVersion As String, ByVal sMimeHeader As String, _
              ByVal iTotalBytes As Integer, ByVal sStatusCode As String, ByRef thisSocket As Socket)
        Dim sBuffer As String = ""
        If Len(sMimeHeader) = 0 Then
            sMimeHeader = "text/html"
        End If
        sBuffer = sHttpVersion & sStatusCode & vbCrLf & _
            "Server: X10CamControl" & vbCrLf & _
            "Content-Type: " & sMimeHeader & vbCrLf & _
            "Accept-Ranges: bytes" & vbCrLf & _
            "Content-Length: " & iTotalBytes & vbCrLf & vbCrLf

        Dim bSendData As [Byte]() = Encoding.ASCII.GetBytes(sBuffer)
        SendToBrowser(bSendData, thisSocket)
    End Sub

    Public Overloads Sub SendToBrowser(ByVal sData As String, ByRef thisSocket As Socket)
        SendToBrowser(Encoding.ASCII.GetBytes(sData), thisSocket)
    End Sub

    Public Overloads Sub SendToBrowser(ByVal bSendData As [Byte](), ByRef thisSocket As Socket)
        Dim iNumBytes As Integer = 0
        If thisSocket.Connected Then
            If (iNumBytes = thisSocket.Send(bSendData, bSendData.Length, 0)) = -1 Then
                'socket error can't send packet
            Else
                'number of bytes sent.
            End If
        Else
            'connection dropped.
        End If
    End Sub

    Private Sub New()
        'create a singleton
    End Sub

    Private Sub StartListen()
        Dim iStartPos As Integer
        Dim sRequest As String
        Dim sDirName As String
        Dim sRequestedFile As String
        Dim sErrorMessage As String
        Dim sLocalDir As String
        Dim sWebserverRoot = LocalVirtualRoot
        Dim sQueryString As String
        Dim sPhysicalFilePath As String = ""
        Dim sFormattedMessage As String = ""
        Do While activeListen
            'accept new socket connection
            Dim mySocket As Socket = LocalTCPListener.Server
            Try
                mySocket = LocalTCPListener.AcceptSocket
                mySocket.ReceiveTimeout = 2000
                mySocket.SendTimeout = 2000
            Catch ex As Exception
            Finally
            End Try
            If mySocket.Connected Then
                Dim bReceive() As Byte = New [Byte](1024) {}
                Try
                    Dim i As Integer = mySocket.Receive(bReceive, bReceive.Length, 0)
                Catch
                End Try
                Dim sBuffer As String = Encoding.ASCII.GetString(bReceive)
                'find the GET request.
                If (sBuffer.Substring(0, 3) <> "GET") Then
                    mySocket.Close()
                    Return
                End If
                iStartPos = sBuffer.IndexOf("HTTP", 1)
                Dim sHttpVersion = sBuffer.Substring(iStartPos, 8)
                sRequest = sBuffer.Substring(0, iStartPos - 1)
                sRequest.Replace("\\", "/")
                If (sRequest.IndexOf(".") < 1) And (Not (sRequest.EndsWith("/"))) Then
                    sRequest = sRequest & "/"
                End If
                'get the file name
                iStartPos = sRequest.LastIndexOf("/") + 1
                sRequestedFile = sRequest.Substring(iStartPos)
                If InStr(sRequest, "?") <> 0 Then
                    iStartPos = sRequest.IndexOf("?") + 1
                    sQueryString = sRequest.Substring(iStartPos)
                    sRequestedFile = Replace(sRequestedFile, "?" & sQueryString, "")
                End If
                'get the directory
                sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3)
                'identify the physical directory.
                If (sDirName = "/") Then
                    sLocalDir = sWebserverRoot
                Else
                    sLocalDir = GetLocalPath(sWebserverRoot, sDirName)
                End If
                'if the directory isn't there then display error.
                If sLocalDir.Length = 0 Then
                    sErrorMessage = "Error!! Requested Directory does not exists"
                    SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", mySocket)
                    SendToBrowser(sErrorMessage, mySocket)
                    mySocket.Close()
                End If
                If sRequestedFile.Length = 0 Then
                    sRequestedFile = GetTheDefaultFileName(sLocalDir)
                    If sRequestedFile = "" Then
                        sErrorMessage = "Error!! No Default File Name Specified"
                        SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", mySocket)
                        SendToBrowser(sErrorMessage, mySocket)
                        mySocket.Close()
                        Return
                    End If
                End If

                Dim sMimeType As String = GetMimeType(sRequestedFile)
                sPhysicalFilePath = sLocalDir & sRequestedFile
                If sRequest = "GET /content/" And Not (cmHTMLInitList.Text Is Nothing) Then
                    SendHeader(sHttpVersion, "text/html", cmHTMLInitList.Text.Length, " 200 OK", mySocket)
                    SendToBrowser(cmHTMLInitList.Text, mySocket)
                ElseIf Not File.Exists(sPhysicalFilePath) Then
                    sErrorMessage = "404 Error! File Does Not Exists..."
                    SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", mySocket)
                    SendToBrowser(sErrorMessage, mySocket)
                Else

                    Try
                        Dim iTotBytes As Integer = 0
                        Dim sResponse As String = ""
                        Dim fs As New FileStream(sPhysicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Dim reader As New BinaryReader(fs)
                        Dim bytes() As Byte = New Byte(fs.Length) {}

                        While reader.BaseStream.Position < reader.BaseStream.Length
                            reader.Read(bytes, 0, bytes.Length)
                            sResponse = sResponse & Encoding.ASCII.GetString(bytes, 0, reader.BaseStream.Length)
                            iTotBytes = reader.BaseStream.Length
                        End While
                        reader.Close()
                        fs.Close()
                        SendHeader(sHttpVersion, sMimeType, iTotBytes, " 200 OK", mySocket)
                        SendToBrowser(bytes, mySocket)
                    Catch ex As Exception
                        sErrorMessage = "404 Error! File Does Not Exists..."
                        SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", mySocket)
                        SendToBrowser(sErrorMessage, mySocket)
                    End Try

                End If
                mySocket.Close()

            End If
        Loop

    End Sub

    Public Sub StopWebServer()
        Try
            Firewall("close", LocalPort)
            'LocalTCPListener.AcceptSocket.Close()
            LocalTCPListener.Stop()
            activeListen = False
            WebThread.Abort()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
#End Region


End Class
