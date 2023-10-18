Imports FormerDALSql
Imports System.Data.SqlClient
Friend Class frmOpzioniTabSec
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    
    Private _dt As DataTable
    Private _cm As SqlCommand
    Private _adap As SqlDataAdapter
    Private _build As SqlCommandBuilder
    Private _ds As DataSet
    Private _tempDs As DataSet

    Friend Function Carica() As Integer

        'Aggiungo le Tabelle da Gestire
        cmbTabelle.Items.Add("T_CORRIERE")
        cmbTabelle.Items.Add("T_CURVAATT")
        cmbTabelle.Items.Add("T_FASCEPREZZO")
        cmbTabelle.Items.Add("T_ZONE")

        cmbTabelle.Items.Add("TD_CATLAV")
        cmbTabelle.Items.Add("TD_CATMODELLI")
        cmbTabelle.Items.Add("TD_FORMATOCARTA")
        cmbTabelle.Items.Add("TD_STATOCONSEGNA")
        cmbTabelle.Items.Add("TD_TIPOPAGAMENTI")

        cmbTabelle.Items.Add("T_FUSTELLE")
        cmbTabelle.Items.Add("T_TIPOFUSTELLA")

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If Not _dt Is Nothing Then

            SalvaDati()

        End If

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmbTabelle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTabelle.SelectedIndexChanged


        CaricaDati(cmbTabelle.Text)
        
    End Sub

    Private Sub SalvaDati()

        _adap.Update(_dt)

    End Sub

    Private Sub CaricaDati(NomeTab As String)

        If Not _dt Is Nothing Then

            SalvaDati()

            _dt.Clear()

        End If

        dgDati.DataSource = Nothing
        dgDati.Rows.Clear()
        dgDati.Columns.Clear()
        dgDati.Refresh()
        Dim sql As String = "SELECT * FROM " & NomeTab
        _cm = New SqlCommand(sql, LUNA.LunaContext.Connection)
        _adap = New SqlDataAdapter(_cm)
        _build = New SqlCommandBuilder(_adap)
        _ds = New DataSet("MainDataSet")
        '_tempDs = New DataSet("TempDataSet")

        '_adap.Fill(_tempDs)
        _adap.Fill(_ds, NomeTab)

        _dt = _ds.Tables(NomeTab)

        For Each dc As DataColumn In _dt.Columns
            Dim column As New DataGridViewTextBoxColumn()
            column.DataPropertyName = dc.ColumnName
            column.HeaderText = dc.ColumnName
            column.Name = dc.ColumnName
            column.SortMode = DataGridViewColumnSortMode.Automatic
            column.ValueType = dc.DataType
            dgDati.Columns.Add(column)
        Next

        dgDati.AllowUserToResizeColumns = True
        dgDati.AutoGenerateColumns = False
        dgDati.DataSource = _dt.DefaultView
        dgDati.ReadOnly = False

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If MessageBox.Show("ATTENZIONE! Vuoi cancellare la riga selezionata? L'operazione non è reversibile!", "TABELLE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If dgDati.SelectedRows.Count Then

                'cancello la riga selezionata
                dgDati.Rows.RemoveAt(dgDati.SelectedRows(0).Index)
                _adap.Update(_dt)

            End If
        End If


    End Sub

End Class