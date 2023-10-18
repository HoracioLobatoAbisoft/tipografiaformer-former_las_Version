Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib.FormerEnum

Friend Class frmSelectTipoCarta
    'Inherits baseFormInternaFixed
    Private _Ris As RisSelectTipoCarta

    Private Sub CaricaCombo()

        Using mgr As New TipiCartaDAO

            cmbLB.ValueMember = "idTipoCarta"
            cmbLB.DisplayMember = "RiassuntoTipologia"

            Dim IdTCDaEsc As String = String.Empty

            If _IdLbEscluso Then
                Using Lb As New ListinoBase
                    Lb.Read(_IdLbEscluso)
                    IdTCDaEsc = Lb.IdTipoCarta & ","
                End Using

                'cerco le varianti da escludere anche quelle

                Using mgrV As New GruppiVariantiRifDAO
                    Dim lv As List(Of GruppoVarianteRif) = mgrV.FindAll(New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, _IdLbEscluso),
                                                                        New LUNA.LSP(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.TipoCarta))
                    For Each voce In lv
                        IdTCDaEsc &= voce.IdRiferimento & ","
                    Next
                End Using

                IdTCDaEsc = IdTCDaEsc.TrimEnd(",")

            End If

            Dim p As LUNA.LSP = Nothing

            If IdTCDaEsc.Length Then
                IdTCDaEsc = "(" & IdTCDaEsc & ")"
                p = New LUNA.LSP(LFM.TipoCarta.IdTipoCarta, IdTCDaEsc, " NOT IN ")

            End If

            Dim l As List(Of TipoCarta) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Tipologia"}, p)

            cmbLB.DataSource = l

        End Using

    End Sub

    Private _IdLbEscluso As Integer = 0

    Friend Function Carica(IdLbEscluso As Integer) As RisSelectTipoCarta

        _IdLbEscluso = IdLbEscluso

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr
    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)

    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi la scelta del Tipo Carta selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui controllo se c'e' gia e avviso 

            Dim fp As TipoCarta = DirectCast(cmbLB.SelectedItem, TipoCarta)

            _Ris = New RisSelectTipoCarta
            _Ris.IdTipoCarta = fp.IdTipoCarta
            _Ris.PercCambiamento = txtVarPerc.Text

            Close()


        End If

    End Sub

End Class