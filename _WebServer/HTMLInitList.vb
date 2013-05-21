Public Class HTMLInitList
#Region "Declarations"
    Private Shared singleHTMLInitList As HTMLInitList
    Private Shared blnFlag As Boolean

    Private myText As String

#End Region

#Region "Properties"
    Public Property Text() As String
        Get
            Return myText
        End Get
        Set(ByVal value As String)
            myText = value
        End Set
    End Property
#End Region

#Region "Methods"
    Private Sub New()
        'create a singleton
    End Sub
    Friend Shared Function getHTMLInitList() As HTMLInitList
        If Not blnFlag Then
            singleHTMLInitList = New HTMLInitList
            blnFlag = True
            Return singleHTMLInitList
        Else
            Return singleHTMLInitList
        End If
    End Function
#End Region
End Class
