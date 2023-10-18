Public Class CachingSection
    Inherits ConfigurationSection

    Private _CachingTimeSpan As TimeSpan = Nothing
    <ConfigurationProperty("CachingTimeSpan", IsRequired:=True)>
    Public Property CachingTimeSpan As TimeSpan
        Get
            Return _CachingTimeSpan
        End Get
        Set(ByVal value As TimeSpan)
            _CachingTimeSpan = value
        End Set
    End Property

    Private _FileExtensions As New FileExtensionCollection '= Nothing
    <ConfigurationProperty("FileExtensions", IsDefaultCollection:=True, IsRequired:=True)>
    Public ReadOnly Property FileExtensions As FileExtensionCollection
        Get
            Return _FileExtensions
        End Get
    End Property
End Class