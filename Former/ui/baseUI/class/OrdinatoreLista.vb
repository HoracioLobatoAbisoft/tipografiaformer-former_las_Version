Public Class OrdinatoreLista(Of T)
    Private Shared _OrdinamentoLista As System.Windows.Forms.SortOrder = SortOrder.Ascending

    Public Shared Sub OrdinaLista(sender As Object, e As DataGridViewCellMouseEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Try

            Dim C As DataGridViewColumn = sender.Columns(e.ColumnIndex)
            Dim L As List(Of T)

            If TypeOf (sender) Is DataGridView Then
                L = sender.DataSource
            Else
                L = sender.DataSourceVirtual
            End If

            If _OrdinamentoLista = SortOrder.Ascending Then
                _OrdinamentoLista = SortOrder.Descending
            Else
                _OrdinamentoLista = SortOrder.Ascending
            End If

            Dim NomeProperty As String = C.DataPropertyName
            Dim NomepropertyExt As String = C.DataPropertyName
            If NomepropertyExt.EndsWith("Str") Then NomepropertyExt = NomepropertyExt.Substring(0, NomepropertyExt.Length - 3)

            L.Sort(Function(o1 As T, o2 As T)

                       Dim T As Type = o1.GetType
                       Dim P As System.Reflection.PropertyInfo = T.GetProperty(NomepropertyExt)
                       If P Is Nothing Then
                           P = T.GetProperty(NomeProperty)
                       End If
                       Dim Val = P.GetValue(o1, Nothing)
                       Dim Val2 = P.GetValue(o2, Nothing)
                       If _OrdinamentoLista = SortOrder.Ascending Then
                           Return Val.CompareTo(Val2)
                       Else
                           Return Val2.CompareTo(Val)
                       End If
                   End Function)

            If TypeOf (sender) Is DataGridView Then
                sender.DataSource = L
                sender.Refresh()
            Else
                sender.DataSourceVirtual = L
            End If

        Catch ex As Exception

        End Try

        Cursor.Current = Cursors.Default
    End Sub

End Class