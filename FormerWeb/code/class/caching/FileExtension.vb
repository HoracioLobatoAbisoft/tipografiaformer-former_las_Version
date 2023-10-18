Public Class FileExtension
    Inherits ConfigurationElement

    Private _Extension As String = String.Empty
    <ConfigurationProperty("Extension", IsRequired:=True)>
    Public Property Extension As String
        Get
            Return _Extension
        End Get
        Set(ByVal value As String)
            _Extension = value.Replace(".", "")
        End Set
    End Property

    Private _ContentType As String = String.Empty
    <ConfigurationProperty("ContentType", IsRequired:=True)>
    Public Property ContentType As String
        Get
            Return _ContentType
        End Get
        Set(ByVal value As String)
            _ContentType = value
        End Set
    End Property
End Class
