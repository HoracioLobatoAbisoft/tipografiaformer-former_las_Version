Imports System.IO.Ports
Imports FormerDALSql
Imports System.Threading
Imports FormerLib
Imports System.ComponentModel

Public Class frmCaller
    ' Inherits baseFormInternaFixed
    'Private ComPort As SerialPort
    ' Private tmrClose As Threading.Timer

    Private _IdCli As Integer = 0
    Private _NumeroTel As String = ""
    Public Sub Ring()
        'qui devo riallungare il periodo del timer 
        'Me.tmrClose.Change(Timeout.Infinite, Timeout.Infinite)
        'Me.tmrClose.Change(3000, 3000)
    End Sub

    Public Sub CloseTimer(ByVal state As Object)
        'Me.tmrClose.Change(Timeout.Infinite, Timeout.Infinite)
        'Me.Close()
    End Sub

    Public Sub AttivaTimer()
        'Me.tmrClose = New Threading.Timer(AddressOf CloseTimer, _
        '                                Nothing, _
        '                                3000, _
        '                                 3000)

        tmrRovescia.Tag = PostazioneCorrente.TimeoutCallerId
        lblTimer.Text = PostazioneCorrente.TimeoutCallerId
        tmrRovescia.Enabled = True
        tmrClose.Interval = (PostazioneCorrente.TimeoutCallerId * 1000)
        tmrClose.Enabled = True

    End Sub

    Public Sub Carica(CallerId As cCaller)

        ''MessageBox.Show(Buffer)
        ''qui ricevo il buffer in cui c'e' un numero di telefono  

        Dim PosizioneStart As Integer = Me.Width
        If PostazioneCorrente.ReminderAttivo Then
            PosizioneStart += 10 + Me.Width
        End If

        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - PosizioneStart
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        'Dim Posiz As Integer = Buffer.ToUpper.IndexOf("NMBR")
        ''Dim PosizFine As Integer = Buffer.ToUpper.IndexOf("NAME", Posiz)

        ''    'qui devo vedere se riesco a capire il chiamante
        'Dim NumeroTrovato As String = Buffer.Substring(Posiz + 7)
        If CallerId.IdRub Then
            lblCli.Text = CallerId.Nominativo
            _IdCli = CallerId.IdRub
        Else
            _IdCli = 0
            lblCli.Text = "Telefono non presente in rubrica"
        End If

        lblTel.Text = CallerId.NumeroTel
        _NumeroTel = CallerId.NumeroTel

        'lblTel.Text = NumeroTel
        '_NumeroTel = NumeroTel
        ''MessageBox.Show(NumeroTrovato)

        'Dim Lst As List(Of VoceRubrica) = Nothing
        'Using mgr As New VociRubricaDAO
        '    Lst = mgr.FindAll(New LUNA.LunaSearchParameter("Tel", NumeroTel), _
        '                                                            New LUNA.LunaSearchParameter("Fax", NumeroTel, , LUNA.enLogicOperator.enOR), _
        '                                                            New LUNA.LunaSearchParameter("Cellulare", NumeroTel, , LUNA.enLogicOperator.enOR), _
        '                                                            New LUNA.LunaSearchParameter("AltroTel", NumeroTel, , LUNA.enLogicOperator.enOR))

        'End Using

        'If Lst.Count Then
        '    Dim ClienteTrovato As VoceRubrica = Lst(0)
        '    lblCli.Text = ClienteTrovato.RagSoc
        '    _IdCli = ClienteTrovato.IdRub
        '    ClienteTrovato = Nothing
        'Else
        '    lblCli.Text = "Telefono non presente in rubrica"
        'End If

        AttivaTimer()

        PostazioneCorrente.CallerAttivo = True

        Show()
        Try
            Me.TopMost = True
            'Me.ShowInTaskbar = True
            Focus()
            Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tmrClose_Tick(sender As Object, e As EventArgs) Handles tmrClose.Tick

        Close()

    End Sub

    Private Sub lnkOrdini_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOrdini.LinkClicked
        If _IdCli Then

            Hide()
            FormPrincipale.WindowState = FormWindowState.Maximized
            FormPrincipale.Focus()

            FormPrincipale.SelezionaClienteDaChiamata(_IdCli)

            Close()
        Else
            MessageBox.Show("Il telefono non è associato a nessun cliente in rubrica e quindi non è possibile aprire la situazione clienti!", "Situazione Ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub tmrRovescia_Tick(sender As Object, e As EventArgs) Handles tmrRovescia.Tick

        Dim NewValue As Integer = tmrRovescia.Tag - 1
        tmrRovescia.Tag = NewValue
        If NewValue Then lblTimer.Text = NewValue

    End Sub

    Private Sub lnkClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked

        Close()

    End Sub

    Private Sub lnkPrendiCarico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrendiCarico.LinkClicked

        Hide()
        FormPrincipale.WindowState = FormWindowState.Maximized
        FormPrincipale.Focus()

        FormPrincipale.PrendiInCaricoChiamata(_IdCli, _NumeroTel)

        Close()

    End Sub

    Private Sub lnkRub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRub.LinkClicked
        If _IdCli Then

            Close()
            FormPrincipale.WindowState = FormWindowState.Maximized
            FormPrincipale.Focus()
            FormPrincipale.Sottofondo()

            Dim F As New frmVoceRubrica

            F.Carica(_IdCli)

            F = Nothing

            FormPrincipale.Sottofondo()

        Else
            MessageBox.Show("Il telefono non è associato a nessun cliente in rubrica e quindi non è possibile aprire la situazione clienti!", "Situazione Ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmCaller_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PostazioneCorrente.CallerAttivo = False
    End Sub
End Class