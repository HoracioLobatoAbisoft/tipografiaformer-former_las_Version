Imports System.IO.Ports
Imports FormerDALSql
Imports System.Threading
Imports FormerLib
Imports System.ComponentModel
Imports FormerLib.FormerEnum

Public Class frmReminder
    ' Inherits baseFormInternaFixed
    'Private ComPort As SerialPort
    ' Private tmrClose As Threading.Timer

    Public Sub Carica()

        Cursor.Current = Cursors.WaitCursor

        Dim r As RisCheckFinanziario = MgrCheckFinanziario.GetSituation

        Cursor.Current = Cursors.Default

        If r.TotAlert <> 0 OrElse r.TotError <> 0 Then

            lblContError.Text = r.TotError
            lblContWarning.Text = r.TotAlert

            'If DocDaInviare Then lblDocDaInviare.Text = DocDaInviare Else lblDocDaInviare.Text = "-"
            'If DocScartati Then lblDocScartati.Text = DocScartati Else lblDocScartati.Text = "-"
            'If DocDaCompletare Then lblDocDaCompletare.Text = DocDaCompletare Else lblDocDaCompletare.Text = "-"

            ''MessageBox.Show(Buffer)
            ''qui ricevo il buffer in cui c'e' un numero di telefono  
            Dim PosizioneStart As Integer = Me.Width
            If PostazioneCorrente.CallerAttivo Then
                PosizioneStart += 10 + Me.Width
            End If

            Me.Left = Screen.PrimaryScreen.WorkingArea.Width - PosizioneStart
            Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

            'Dim Posiz As Integer = Buffer.ToUpper.IndexOf("NMBR")
            ''Dim PosizFine As Integer = Buffer.ToUpper.IndexOf("NAME", Posiz)

            ''    'qui devo vedere se riesco a capire il chiamante
            'Dim NumeroTrovato As String = Buffer.Substring(Posiz + 7)

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


            PostazioneCorrente.ReminderAttivo = True
            Show(FormPrincipale)
            Try
                TopMost = True
                Me.ShowInTaskbar = True
                Focus()
                Refresh()
            Catch ex As Exception

            End Try
        End If


    End Sub


    Private Sub lnkClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked

        Close()

    End Sub

    Private Sub frmReminder_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PostazioneCorrente.ReminderAttivo = False
    End Sub

    Private Sub lnkRisolvi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRisolvi.LinkClicked

        FormPrincipale.UcMain.TabMain.SelectedIndex = 3
        FormPrincipale.UcMain.UcFatture.TabMain.SelectedIndex = 0
        FormPrincipale.UcMain.UcFatture.UcAmministrazioneDashboard.Carica()
        Close()

    End Sub
End Class