#Region "Author"

'All rights reserved.

'Author: Diego Lunadei
'Date: Marzo 2008

#End Region
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerDALSql.LUNA

Public Class frmPostit

    Private _IdRub As Integer = 0
    Private _NumeroTel As String = String.Empty

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(lnkRispondi)
        'ColoraSfondo(lnkSalva)
        'ColoraSfondo(lnkAggiorna)
    End Sub

    Public Function Carica(Optional IdRub As Integer = 0,
                           Optional NumeroTel As String = "")
        _IdRub = IdRub
        _NumeroTel = NumeroTel

        CaricaCombo()

        rdoAutomatico.Enabled = False
        cmbMitt.SelectedValue = 1
        cmbMitt.Enabled = False
        lnkSalva.Visible = True

        If IdRub Then
            Using r As New VoceRubrica
                r.Read(IdRub)
                lblVoceRub.Text = r.RagSocNome
            End Using
            rdoAutomatico.Enabled = False
            rdoMessaggio.Enabled = False
            rdoChiamataPersa.Checked = True

        End If

        If NumeroTel.Length Then
            lblNumeroTel.Text = NumeroTel
            rdoAutomatico.Enabled = False
            rdoMessaggio.Enabled = False
            rdoChiamataPersa.Checked = True
        Else
            rdoChiamataPersa.Enabled = False
        End If

        ShowDialog()

    End Function

    Private Sub CaricaCombo()

        Using Ut As New UtentiDAO

            Dim param As LUNA.LunaSearchParameter = Nothing

            If _IdRub Or _NumeroTel.Length Then
                param = New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Admin)
            End If

            Dim l As List(Of Utente) = Ut.GetAll(LFM.Utente.Login)
            cmbMitt.ValueMember = "IdUt"
            cmbMitt.DisplayMember = "Login"

            cmbMitt.DataSource = l


            Dim l2 As List(Of Utente) = Ut.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Login", .AddEmptyItem = True},
                                                   param)
            cmbDest.ValueMember = "IdUt"
            cmbDest.DisplayMember = "Login"

            cmbDest.DataSource = l2
        End Using
    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Close()
    End Sub

    Private Sub lnkElimina_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        txtContenuto.Text = ""
        Close()
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        Close()

    End Sub

    Private Sub lnkSalva_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSalva.LinkClicked
        'salvo e esco
        If MessageBox.Show("Confermi l'invio del messaggio?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Err As Boolean = False
            If txtTitolo.Text.Length = 0 Then Err = True
            If txtContenuto.Text.Length = 0 Then Err = True
            If cmbDest.SelectedValue = -1 Then Err = True

            If Err Then
                MessageBox.Show("Riempire tutti i campi!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else

                Dim TipoMessaggio As enTipoMessaggio

                If rdoAutomatico.Checked Then
                    TipoMessaggio = enTipoMessaggio.Automatico
                ElseIf rdoChiamataPersa.Checked Then
                    TipoMessaggio = enTipoMessaggio.Chiamata
                ElseIf rdoMessaggio.Checked Then
                    TipoMessaggio = enTipoMessaggio.Messaggio
                End If

                Dim OkInserisci As Boolean = True

                If TipoMessaggio = enTipoMessaggio.Chiamata Then
                    If cmbDest.SelectedValue = 0 Then
                        MessageBox.Show("Per le chiamate perse e' obbligatorio selezionare un destinatario del messaggio!")
                        OkInserisci = False
                    End If
                End If

                If OkInserisci Then
                    Using m As New Messaggio
                        m.Titolo = txtTitolo.Text
                        m.Testo = txtContenuto.Text
                        m.DataIns = Now
                        m.IdMitt = cmbMitt.SelectedValue
                        m.IdDest = cmbDest.SelectedValue
                        m.TipoMsg = TipoMessaggio
                        m.IdOrd = 0
                        m.IdCom = 0
                        m.IdVoceRubrica = _IdRub
                        m.NumeroTel = _NumeroTel
                        m.Save()
                    End Using

                    Close()

                End If

            End If

        End If

    End Sub

End Class