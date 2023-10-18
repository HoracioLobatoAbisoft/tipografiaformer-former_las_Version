Imports System.Windows.Forms

Public Class ucDataGridView
    Inherits DataGridView

    Private _DataSourceVirtual As IEnumerable(Of Object) = Nothing
    Public Sub New()
        MyBase.New
        'VirtualMode = True

    End Sub

    Public Property DataSourceVirtual As IEnumerable(Of Object)
        Get
            Return DataSource
            '            Return _DataSourceVirtual
        End Get
        Set(value As IEnumerable(Of Object))
            DataSource = value
            'CustomVirtualMode = True
            'ScrollValue = 0
            'DataSource = Nothing
            '_DataSourceVirtual = value

            'If Not _DataSourceVirtual Is Nothing Then
            '    FormerVirtualLoad.DisplayData(_DataSourceVirtual,
            '                                 Me,
            '                                 FormerVirtualLoad.enDirezione.Basso)
            'End If

        End Set
    End Property

    Public Property CustomVirtualMode As Boolean = False
    Public Property ScrollValue As Integer
    Public Property ScrollManuale As Boolean = False

    'Private Sub ucDataGridView_Scroll(sender As Object, e As ScrollEventArgs) Handles Me.Scroll

    '    If CustomVirtualMode AndAlso ScrollManuale = False Then
    '        If e.NewValue > e.OldValue Then
    '            Try
    '                ScrollValue += DisplayedRowCount(False)
    '                'sto scendendo 
    '                'qui devo appende

    '                If Rows.Count < _DataSourceVirtual.Count Then

    '                    ScrollManuale = True
    '                    Dim Incremento As Integer = e.NewValue - e.OldValue
    '                    FormerVirtualLoad.DisplayData(_DataSourceVirtual, Me, FormerVirtualLoad.enDirezione.Basso, Incremento)
    '                    'Me.Enabled = False
    '                    'FirstDisplayedScrollingRowIndex = ScrollValue
    '                    'Me.Enabled = True
    '                End If
    '            Catch ex As Exception

    '            Finally
    '                ScrollManuale = False
    '            End Try
    '        End If
    '    End If
    'End Sub

End Class
