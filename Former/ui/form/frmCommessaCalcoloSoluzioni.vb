Imports FormerDALSql
Imports FormerLib

Public Class frmCommessaCalcoloSoluzioni

    Private _Ordini As List(Of OrdineRicerca) = Nothing
    Private _ParametriImpostati As ParametriCreazioneSoluzione = Nothing
    Private _Ris As List(Of Soluzione) = Nothing
    Public Function Carica(Ordini As List(Of OrdineRicerca),
                           ParametriImpostati As ParametriCreazioneSoluzione) As List(Of Soluzione)
        Cursor = Cursors.WaitCursor
        _Ordini = Ordini
        _ParametriImpostati = ParametriImpostati
        lblCount.Text = Ordini.Count
        'If FormerDebug.DebugAttivo Then btnClose.Visible = True
        ShowDialog()
        Cursor = Cursors.Default

        Return _Ris

    End Function

    Private Sub HandlerMotore(Messaggio As String)
        txtLog.AppendText(Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00") & " - " & Messaggio & ControlChars.NewLine)
        Application.DoEvents()
    End Sub

    Private Sub tmrStart_Tick(sender As Object, e As EventArgs) Handles tmrStart.Tick
        tmrStart.Enabled = False
        AddHandler MotoreCalcoloSoluzioni.AggiornamentoStato, AddressOf HandlerMotore
        _Ris = MotoreCalcoloSoluzioni.ProponiSoluzioni(_Ordini, _ParametriImpostati)
        RemoveHandler MotoreCalcoloSoluzioni.AggiornamentoStato, AddressOf HandlerMotore
        'If FormerDebug.DebugAttivo = False Then
        Close()
        'Else
        'Cursor.Current = Cursors.Default
        'End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Close()

    End Sub
End Class