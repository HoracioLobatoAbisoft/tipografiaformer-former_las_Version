Public Class FileExtensionCollection
    Inherits ConfigurationElementCollection

    Public Overrides ReadOnly Property CollectionType As ConfigurationElementCollectionType
        Get
            Return ConfigurationElementCollectionType.AddRemoveClearMap
        End Get
    End Property

    Default Public Overloads Property Item(ByVal index As Integer) As FileExtension
        Get
            Return CType(BaseGet(index), FileExtension)
        End Get
        Set(ByVal value As FileExtension)

            If BaseGet(index) IsNot Nothing Then
                BaseRemoveAt(index)
            End If

            BaseAdd(index, value)
        End Set
    End Property

    Default Public Overloads Property Item(ByVal extension As String) As FileExtension
        Get
            Return CType(BaseGet(extension), FileExtension)
        End Get
        Set(ByVal value As FileExtension)

            If BaseGet(extension) IsNot Nothing Then
                BaseRemove(extension)
            End If

            BaseAdd(value)
        End Set
    End Property

    Public Sub Add(ByVal element As FileExtension)
        BaseAdd(element)
    End Sub

    Public Sub Clear()
        BaseClear()
    End Sub

    Protected Overrides Function CreateNewElement() As ConfigurationElement
        Return New FileExtension()
    End Function

    Protected Overrides Function GetElementKey(ByVal element As ConfigurationElement) As Object
        Return (CType(element, FileExtension)).Extension
    End Function

    Public Sub Remove(ByVal element As FileExtension)
        BaseRemove(element.Extension)
    End Sub

    Public Sub Remove(ByVal name As String)
        BaseRemove(name)
    End Sub

    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)
    End Sub
End Class
