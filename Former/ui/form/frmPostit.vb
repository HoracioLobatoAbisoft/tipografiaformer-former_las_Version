#Region "Author"

'All rights reserved.

'Author: Diego Lunadei
'Date: Marzo 2008

#End Region
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerDALSql.LUNA
Imports FormerLib

Public Class frmPostit
    'Inherits baseFormInternaRedim

    Private _IdCom As Integer = 0
    Private _IdOrd As Integer = 0
    Private _Ris As Integer = 0
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

    Public Function Carica(Optional M As Messaggio = Nothing,
                           Optional IdCom As Integer = 0,
                           Optional IdOrd As Integer = 0,
                           Optional IdDest As Integer = 0,
                           Optional IdRub As Integer = 0,
                           Optional NumeroTel As String = "")
        _IdCom = IdCom
        _IdOrd = IdOrd
        _IdRub = IdRub
        _NumeroTel = NumeroTel

        CaricaCombo()

        If Not M Is Nothing Then
            lblData.Text = "Inviato il " & M.DataInsFormat
            MgrControl.SelectIndexCombo(cmbMitt, M.IdMitt)
            MgrControl.SelectIndexCombo(cmbDest, M.IdDest)
            txtTitolo.Text = M.Titolo
            txtContenuto.Text = M.Testo
            If M.IdOrd Then lblOrdine.Text = M.IdOrd
            If M.IdCom Then lblCommessa.Text = M.IdCom

            cmbMitt.Enabled = False
            cmbDest.Enabled = False
            txtTitolo.ReadOnly = True
            txtContenuto.ReadOnly = True
            If M.IdDest = PostazioneCorrente.UtenteConnesso.IdUt Then
                lnkRispondi.Visible = True
            End If

            Select Case M.TipoMsg
                Case enTipoMessaggio.Messaggio
                    rdoMessaggio.Checked = True
                    rdoChiamataPersa.Enabled = False
                    rdoAutomatico.Enabled = False

                Case enTipoMessaggio.Automatico
                    rdoAutomatico.Checked = True
                    rdoChiamataPersa.Enabled = False
                    rdoMessaggio.Enabled = False

                Case enTipoMessaggio.Chiamata
                    rdoChiamataPersa.Checked = True
                    rdoAutomatico.Enabled = False
                    rdoMessaggio.Enabled = False

            End Select

            If M.IdOrd Then
                Using O As New Ordine
                    O.Read(M.IdOrd)
                    pctAnteprima.Image = O.ImgAnteprima
                End Using
            ElseIf M.IdCom Then
                Using C As New Commessa
                    C.Read(M.IdCom)
                    Try
                        pctAnteprima.Image = C.ImgAnteprima
                    Catch ex As Exception

                    End Try
                End Using
            End If

            If M.IdVoceRubrica Then
                _IdRub = M.IdVoceRubrica
                Using r As New VoceRubrica
                    r.Read(M.IdVoceRubrica)
                    lblVoceRub.Text = r.RagSocNome
                    toolTipHelp.SetToolTip(lblVoceRub, r.RagSocNome)
                End Using
            End If

            If M.NumeroTel.Length Then
                lblNumeroTel.Text = M.NumeroTel
                toolTipHelp.SetToolTip(lblNumeroTel, M.NumeroTel)
            End If

        Else
            rdoAutomatico.Enabled = False
            cmbMitt.SelectedValue = PostazioneCorrente.UtenteConnesso.IdUt
            cmbMitt.Enabled = False
            lnkSalva.Visible = True
            If IdOrd Then lblOrdine.Text = IdOrd
            If IdCom Then lblCommessa.Text = IdCom
            If IdDest Then
                cmbDest.SelectedValue = IdDest
            End If
            If IdOrd Then
                Dim O As New Ordine
                O.Read(IdOrd)
                Try
                    pctAnteprima.Image = Image.FromFile(O.FilePath)
                Catch ex As Exception

                End Try

            ElseIf IdCom Then
                Dim C As New Commessa
                C.Read(IdCom)
                Try
                    pctAnteprima.Image = Image.FromFile(FormerPathCreator.GetAnteprima(C))
                Catch ex As Exception

                End Try

            End If

            If IdRub Then
                Using r As New VoceRubrica
                    r.Read(IdRub)
                    lblVoceRub.Text = r.RagSocNome
                    toolTipHelp.SetToolTip(lblVoceRub, r.RagSocNome)
                End Using
                rdoAutomatico.Enabled = False
                rdoMessaggio.Enabled = False
                rdoChiamataPersa.Checked = True

            End If

            If NumeroTel.Length Then
                lblNumeroTel.Text = NumeroTel
                toolTipHelp.SetToolTip(lblNumeroTel, NumeroTel)
                rdoAutomatico.Enabled = False
                rdoMessaggio.Enabled = False
                rdoChiamataPersa.Checked = True
            Else
                rdoChiamataPersa.Enabled = False
            End If

        End If

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
            btnOrdine.Enabled = False
            btnCommessa.Enabled = False
            btnRub.Enabled = False
        End If

        ShowDialog()
        Return _Ris
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


            Dim l2 As List(Of Utente) = Ut.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Login", .AddEmptyItem = True}, param)
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

    Private Sub btnOrdine_Click(sender As System.Object, e As System.EventArgs) Handles btnOrdine.Click
        If lblOrdine.Text <> "-" Then
            Sottofondo()
            Using f As New frmOrdine
                f.Carica(lblOrdine.Text)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub btnCommessa_Click(sender As System.Object, e As System.EventArgs) Handles btnCommessa.Click
        If lblCommessa.Text <> "-" Then
            Sottofondo()
            Using f As New frmCommessa
                f.Carica(lblCommessa.Text)
            End Using
            Sottofondo()

        End If
    End Sub

    Private Sub lnkSalva_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSalva.LinkClicked
        'salvo e esco
        If MessageBox.Show("Confermi l'invio del messaggio?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

                    Dim IdDestMsg As Integer = cmbDest.SelectedValue

                    Using m As New Messaggio
                        m.Titolo = txtTitolo.Text
                        m.Testo = txtContenuto.Text
                        m.DataIns = Now
                        m.IdMitt = cmbMitt.SelectedValue
                        m.IdDest = IdDestMsg 'cmbDest.SelectedValue
                        m.TipoMsg = TipoMessaggio
                        m.IdOrd = _IdOrd
                        m.IdCom = _IdCom
                        m.IdVoceRubrica = _IdRub
                        m.NumeroTel = _NumeroTel
                        m.Save()
                    End Using

                    If IdDestMsg Then

                        Using u As New Utente
                            u.Read(IdDestMsg)

                            FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Notifica, "Hai ricevuto un messaggio da " & PostazioneCorrente.UtenteConnesso.Login, u.Login)

                        End Using

                    End If

                    _Ris = 1
                    Close()

                End If

            End If

        End If

    End Sub

    Private Sub lnkRispondi_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRispondi.LinkClicked
        Sottofondo()

        Dim f As New frmPostit
        f.Carica(, _IdCom, _IdOrd, cmbMitt.SelectedValue)
        Sottofondo()

    End Sub

    Private Sub btnRub_Click(sender As Object, e As EventArgs) Handles btnRub.Click
        If _IdRub Then
            Sottofondo()
            Using f As New frmVoceRubrica
                f.Carica(_IdRub)
            End Using
            Sottofondo()

        End If
    End Sub
End Class