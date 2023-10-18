Imports FormerDALSql
Imports FormerLib
Public Class ucCaller
    Inherits ucFormerUserControl

    Private IdCli As Integer = 0
    Private _NumeroTel As String = ""
    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White
    End Sub

    Public Sub Reset()

        IdCli = 0

        lblTel.Text = "-"
        lblCli.Text = String.Empty

        lblTimer.Text = PostazioneCorrente.TimeoutCallerId
        lblTimer.Visible = False

        tmrRovescia.Enabled = False

    End Sub

    Public Sub Carica(CallerId As cCaller)

        lblTel.Text = CallerId.NumeroTel
        _NumeroTel = CallerId.NumeroTel

        If CallerId.IdRub Then
            lblCli.Text = CallerId.Nominativo
            IdCli = CallerId.IdRub
        Else
            IdCli = 0
            lblCli.Text = "Telefono non presente in rubrica"
        End If

        AttivaTimer()

    End Sub

    Private Sub Carica(NumeroTel As String)

        lblTel.Text = NumeroTel
        _NumeroTel = NumeroTel
        'MessageBox.Show(NumeroTrovato)

        Dim Lst As List(Of VoceRubrica) = Nothing
        Using mgr As New VociRubricaDAO
            Lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Tel, NumeroTel),
                              New LUNA.LunaSearchParameter(LFM.VoceRubrica.Fax, NumeroTel, , LUNA.enLogicOperator.enOR),
                              New LUNA.LunaSearchParameter(LFM.VoceRubrica.Cellulare, NumeroTel, , LUNA.enLogicOperator.enOR),
                              New LUNA.LunaSearchParameter(LFM.VoceRubrica.AltroTel, NumeroTel, , LUNA.enLogicOperator.enOR))
        End Using

        If Lst.Count Then
            Dim ClienteTrovato As VoceRubrica = Lst(0)
            lblCli.Text = ClienteTrovato.RagSocNome
            IdCli = ClienteTrovato.IdRub
            ClienteTrovato = Nothing
        Else
            lblCli.Text = "Telefono non presente in rubrica"
        End If

        AttivaTimer()

    End Sub

    Public Sub AttivaTimer()
        'Me.tmrClose = New Threading.Timer(AddressOf CloseTimer, _
        '                                Nothing, _
        '                                3000, _
        '                                 3000)
        lblTimer.Visible = True
        tmrRovescia.Tag = PostazioneCorrente.TimeoutCallerId
        lblTimer.Text = PostazioneCorrente.TimeoutCallerId
        tmrRovescia.Enabled = True

    End Sub

    Private Sub tmrRovescia_Tick(sender As Object, e As EventArgs) Handles tmrRovescia.Tick
        Dim NewValue As Integer = tmrRovescia.Tag - 1
        tmrRovescia.Tag = NewValue
        If NewValue Then
            lblTimer.Text = NewValue
        Else
            Reset()
        End If

    End Sub

    Private Sub lnkOrdini_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOrdini.LinkClicked
        If IdCli Then

            FormPrincipale.SelezionaClienteDaChiamata(IdCli)

            Reset()
        Else
            MessageBox.Show("Il telefono non è associato a nessun cliente in rubrica e quindi non è possibile aprire la situazione clienti!", "Situazione Ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lnkRub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRub.LinkClicked
        If IdCli Then

            ParentFormEx.Sottofondo()

            Dim F As New frmVoceRubrica

            F.Carica(IdCli)

            F = Nothing

            ParentFormEx.Sottofondo()

        Else
            MessageBox.Show("Il telefono non è associato a nessun cliente in rubrica e quindi non è possibile aprire la situazione clienti!", "Situazione Ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
