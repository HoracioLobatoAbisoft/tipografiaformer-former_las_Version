Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmCodTrackBrt
    'Inherits baseFormInternaFixed

    Private _Ris As String = String.Empty
    Private _BufferCodice As String = String.Empty
    Dim _C As ConsegnaProgrammata

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Friend Function Carica(ByVal IdCons As Integer) As String

        _C = New ConsegnaProgrammata
        _C.Read(IdCons)

        txtCodTrack.Text = _C.CodTrack
        'txtNumColloIniz.Text = _C.NumeroPrimoColloBartolini

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            btnReset.Visible = True
            btnIncolla.Visible = True
        End If

        'txtNumColloIniz.Focus()
        txtCodTrack.Focus()

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

        _Ris = 0

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If ModuloValido() Then
            If MessageBox.Show("Confermi il salvataggio del codice di tracking?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using mgr As New ConsegneProgrammateDAO
                    Dim CodTrack As String = String.Empty
                    If txtCodTrack.Text.Trim.Length <> 0 Then
                        CodTrack = txtCodTrack.Text.Substring(0, 15)
                    End If
                    Dim lst As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, CodTrack),
                                                                          New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, "(" & enCorriere.Bartolini & ", " & enCorriere.PortoAssegnatoBartolini & ")", "IN"))
                    If Not lst.Count Then
                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                            Try
                                tb.TransactionBegin()
                                _C.CodTrack = CodTrack
                                '_C.Blocco = enSiNo.Si
                                _C.DataTrasmissioneCorriere = Date.MinValue
                                Dim NumCollo As String = String.Empty
                                Dim StatoConsegna As enStatoConsegna = enStatoConsegna.InLavorazione
                                If txtCodTrack.Text.Trim.Length <> 0 Then
                                    NumCollo = _C.CodTrack.Substring(8, 7)
                                    StatoConsegna = enStatoConsegna.RegistrataCorriere
                                End If
                                _C.NumeroPrimoColloBartolini = NumCollo
                                Using mgr2 As New ConsegneProgrammateDAO()
                                    mgr2.AvanzaStatoConsegna(_C, StatoConsegna)
                                End Using
                                _C.Save()
                                tb.TransactionCommit()

                                _Ris = _C.CodTrack
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                MessageBox.Show("Errore durante il salvataggio: " & ex.Message)
                            End Try

                            Close()
                        End Using
                    Else
                        MessageBox.Show("Il codice inserito è già assegnato a un'altra consegna!")
                    End If
                End Using

            End If
        Else
            MessageBox.Show("Il Numero Spedizione di BRT deve essere di 15 o 18 caratteri!")
        End If
    End Sub

    Private Function ModuloValido() As Boolean
        Dim ris As Boolean = True

        If txtCodTrack.Text.Trim.Length <> 0 And txtCodTrack.Text.Length <> 15 And txtCodTrack.Text.Length <> 18 Then
            ris = False
        End If

        Return ris
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtCodTrack.Text = String.Empty
    End Sub

    Private Sub frmBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If rdoBarCode.Checked Then
            _BufferCodice &= e.KeyChar

            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                _BufferCodice = _BufferCodice.TrimEnd
                If _BufferCodice.Length = 18 Then
                    _BufferCodice = _BufferCodice.Substring(0, 15)
                    Using mgr As New ConsegneProgrammateDAO
                        Dim lst As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, _BufferCodice),
                                                                              New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, enCorriere.Bartolini))
                        If Not lst.Count Then
                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                                Try
                                    tb.TransactionBegin()
                                    Dim CodTrack As String = _BufferCodice
                                    _C.CodTrack = CodTrack
                                    '_C.Blocco = enSiNo.Si
                                    _C.DataTrasmissioneCorriere = Date.MinValue
                                    Dim NumCollo As String = String.Empty
                                    Dim StatoConsegna As enStatoConsegna = enStatoConsegna.InLavorazione
                                    NumCollo = _C.CodTrack.Substring(8, 7)
                                    StatoConsegna = enStatoConsegna.RegistrataCorriere
                                    _C.NumeroPrimoColloBartolini = NumCollo
                                    Using mgr2 As New ConsegneProgrammateDAO()
                                        mgr2.AvanzaStatoConsegna(_C, StatoConsegna)
                                    End Using
                                    _C.Save()
                                    tb.TransactionCommit()

                                    _Ris = _C.CodTrack
                                Catch ex As Exception
                                    tb.TransactionRollBack()
                                    MessageBox.Show("Errore durante il salvataggio: " & ex.Message)
                                End Try

                                Close()
                            End Using
                        Else
                            MessageBox.Show("Il codice inserito è già assegnato a un'altra consegna!")
                        End If
                    End Using
                Else
                    MessageBox.Show("Il Numero Spedizione di BRT deve essere di 18 caratteri!")
                    _BufferCodice = ""
                End If

            End If

        End If
    End Sub

    Private Sub rdoManuale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoManuale.CheckedChanged
        txtCodTrack.Enabled = rdoManuale.Checked
        btnOk.Visible = rdoManuale.Checked
        btnIncolla.Enabled = rdoManuale.Checked
        btnReset.Enabled = rdoManuale.Checked
    End Sub

    Private Sub btnIncolla_Click(sender As Object, e As EventArgs) Handles btnIncolla.Click
        txtCodTrack.Text = Clipboard.GetText()
    End Sub

    Private Sub txtCodTrack_LostFocus(sender As Object, e As EventArgs) Handles txtCodTrack.LostFocus
        txtCodTrack.Text = txtCodTrack.Text.TrimEnd(" ")
    End Sub
End Class