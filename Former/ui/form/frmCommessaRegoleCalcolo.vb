Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmCommessaRegoleCalcolo
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private Sub CaricaCombo()

        Using mgr As New ListinoBaseDAO

            cmbLB.ValueMember = "IdListinoBase"
            cmbLB.DisplayMember = "Nome"
            cmbLB.DataSource = mgr.FindAll(New LUNA.LSO() With {.OrderBy = LFM.ListinoBase.Nome.Name, .AddEmptyItem = True},
                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No),
                                            New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0, "<>"))

        End Using

        Dim Item As New cEnum(enTipoRegola.DiSistema, "Di Sistema")
        Dim L As New List(Of cEnum)
        L.Add(Item)

        Item = New cEnum(enTipoRegola.Utente, "Utente")
        L.Add(Item)

        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"
        cmbTipo.DataSource = L



    End Sub

    Private _IdRegolaCalcolo As Integer = 0
    Friend Function Carica(Optional IdRegolaCalcolo As Integer = 0) As Integer

        _IdRegolaCalcolo = IdRegolaCalcolo

        CaricaCombo()

        If IdRegolaCalcolo Then
            Using R As New RegolaCalcolo
                R.Read(IdRegolaCalcolo)

                txtNome.Text = R.Nome
                txtChiave.Text = R.Chiave
                txtValore.Text = R.Valore
                txtOpzioni.Text = R.Opzioni

                If R.IdListinoBase Then
                    MgrControl.SelectIndexCombo(cmbLB, R.IdListinoBase)
                End If

                MgrControl.SelectIndexComboEnum(cmbTipo, R.TipoRegola)

                If R.TipoRegola = enTipoRegola.DiSistema Then
                    txtNome.ReadOnly = True
                    txtChiave.ReadOnly = True
                    chkDisattiva.Enabled = False
                    cmbLB.Enabled = False
                End If

                If R.Stato = enStato.NonAttivo Then chkDisattiva.Checked = True

            End Using
            Me.Text &= " - " & IdRegolaCalcolo
        Else
            MgrControl.SelectIndexComboEnum(cmbTipo, enTipoRegola.Utente)
        End If

        cmbTipo.Enabled = False

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

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio della Regola di Calcolo?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Using R As New RegolaCalcolo
                If _IdRegolaCalcolo Then R.Read(_IdRegolaCalcolo)
                R.Nome = txtNome.Text
                R.IdListinoBase = cmbLB.SelectedValue
                R.TipoRegola = cmbTipo.SelectedValue
                R.Chiave = txtChiave.Text
                R.Valore = txtValore.Text
                R.Opzioni = txtOpzioni.Text
                R.Stato = IIf(chkDisattiva.Checked, enStato.NonAttivo, enStato.Attivo)
                R.Save()
            End Using

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub btnSfoglia_Click(sender As Object, e As EventArgs) Handles btnSfoglia.Click

        Dim Buffer As String = String.Empty
        Buffer &= MgrRegoleCalcolo.ChiaveRegolaUtente.OkConQtaSuperioreA & ControlChars.NewLine

        Using f As New frmTextShow
            f.Carica(Buffer)
        End Using

    End Sub

    Private Sub btnExtraData_Click(sender As Object, e As EventArgs) Handles btnExtraData.Click

        Dim Buffer As String = String.Empty
        Buffer &= MgrRegoleCalcolo.ExtraData.ForzaMacchinarioA & ControlChars.NewLine

        Using f As New frmTextShow
            f.Carica(Buffer)
        End Using

    End Sub
End Class