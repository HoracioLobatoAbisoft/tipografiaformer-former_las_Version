Imports System.Windows.Forms

Public Class FormerVirtualLoad

    Public Enum enDirezione As Integer
        Basso
        Alto = 1
    End Enum

    Private Shared _ItemPerPage As Integer = 50

    Public Shared Sub DisplayData(Source As IEnumerable(Of Object),
                                  ByRef Datagrid As ucDataGridView,
                                  Direzione As enDirezione,
                                  Optional ItemToScroll As Integer = 0)

        Cursor.Current = Cursors.WaitCursor
        Dim ItemPerPage As Integer = 0 ' = Datagrid.DisplayedRowCount(True)

        ItemToScroll = Datagrid.DisplayedRowCount(True)

        If ItemToScroll = 0 Then
            ItemPerPage = _ItemPerPage
        Else
            ItemPerPage = ItemToScroll
        End If

        If Datagrid.DataSource Is Nothing Then
            Datagrid.DataSource = Source.Take(ItemPerPage).ToList
        Else
            Dim L As List(Of Object) = Datagrid.DataSource
            Dim Start As Integer = L.Count
            If Direzione = enDirezione.Alto Then
                Start -= ItemPerPage
                If Start < 0 Then Start = 0
            End If

            L.AddRange(Source.Skip(Start).Take(ItemPerPage))
            Datagrid.Enabled = False
            Datagrid.DataSource = Nothing
            Datagrid.DataSource = L
            Datagrid.Enabled = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Shared Function GetPropertyValue(ByVal obj As Object, ByVal PropName As String) As Object
        Dim objType As Type = obj.GetType()
        Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(PropName)
        Dim PropValue As Object = pInfo.GetValue(obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
        Return PropValue
    End Function

End Class
