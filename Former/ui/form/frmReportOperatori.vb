Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmReportOperatori
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        dtGiorno.Value = Now.Date

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

    Private Sub dtGiorno_ValueChanged(sender As Object, e As EventArgs) Handles dtGiorno.ValueChanged

        CreaReport()

    End Sub

    Private Sub CreaReport()

        Cursor.Current = Cursors.WaitCursor

        Dim GiornoRif As Date = dtGiorno.Value

        Dim Buffer As String = String.Empty
        Buffer &= "<h1>" & GiornoRif.ToString("dd/MM/yyyy") & "</h1>"
        Using mgr As New LavLogDAO
            Buffer &= "<table style='width:100%;border:1px solid black;font-family:Arial;font-size:14px;'>"
            Dim l As List(Of LavLog) = mgr.GetReportGiornaliero(GiornoRif)
            Buffer &= "<tr style='background-color:" & FormerColori.GetColoreToHtml(FormerColori.ColoreAmbienteVerde) & ";border:1px solid black;'><th>Inizio</th><th>Fine</th><th>Minuti (Previsti)</th><th>Riferimento</th><th>Lavorazione</th><th>Macchinario</th></tr>"
            Using mgrU As New UtentiDAO
                Dim lU As List(Of Utente) = mgrU.FindAll(LFM.Utente.Login,
                                                        New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si))

                For Each U As Utente In lU
                    Dim TotMinuti As Integer = 0
                    Dim lFilter As List(Of LavLog) = l.FindAll(Function(x) x.IdUtenteForzato = U.IdUt Or (x.IdUt = U.IdUt And x.IdUtenteForzato = 0))

                    If lFilter.Count Then
                        Buffer &= "<tr style='color:white;background-color:" & FormerColori.GetColoreToHtml(FormerColori.ColoreAmbienteSfondoGrigioScuro) & ";'><td colspan=7 style='vertical-align:middle;'><h2>" & U.LoginEx & "</h2></td></tr>"
                    End If

                    For Each voce As LavLog In lFilter
                        Buffer &= "<tr style='border:1px solid black;'><td style='border:1px solid black;vertical-align:middle;'>" & voce.DataOraInizio.ToString("HH:mm") & "<font size=-3>" & voce.DataOraInizio.ToString(".ss") & "</font></td>"
                        Buffer &= "<td style='border:1px solid black;vertical-align:middle;'>"

                        If DateDiff(DateInterval.Day, voce.DataOraInizio, voce.DataOraFine) < 1 Then
                            Buffer &= voce.DataOraFine.ToString("HH:mm") & "<font size=-3>" & voce.DataOraFine.ToString(".ss") & "</font>"
                        Else
                            Buffer &= "<b style='color:red;'>!!! " & voce.DataOraFine.ToString("dd/MM/yyyy HH:mm") & "<font size=-3>" & voce.DataOraFine.ToString(".ss") & "</font></b>"
                        End If

                        Buffer &= "</td>"
                        Buffer &= "<td style='border:1px solid black;vertical-align:middle;'>"

                        Dim TotMinLavoro As Integer = 0

                        If voce.DataOraFine <> Date.MinValue Then
                            TotMinLavoro = DateDiff(DateInterval.Minute, voce.DataOraInizio, voce.DataOraFine)
                            Buffer &= "<b>" & TotMinLavoro & " min.</b>"
                        Else
                            'qui faccio il conto di quanto tempo è fino ad ora 
                            TotMinLavoro = DateDiff(DateInterval.Minute, voce.DataOraInizio, Now)
                            Buffer &= "<b style='color:red;'>!!! " & TotMinLavoro & " min.</b>"
                        End If

                        TotMinuti += TotMinLavoro

                        Buffer &= IIf(voce.Tempo, " <br>(<i>" & voce.Tempo & "</i>)", "")

                        Buffer &= "</td>"

                        If voce.IdOrd Then
                            Using o As New Ordine
                                o.Read(voce.IdOrd)
                                Buffer &= "<td style='border:1px solid black;vertical-align:middle;'><img src=""" & FormerPathCreator.GetAnteprima(o) & """ width=80 align=absmiddle> <b>LAVORO " & voce.IdOrd & "</b></td>"
                            End Using
                        ElseIf voce.IdCom Then
                            Using c As New Commessa
                                c.Read(voce.IdCom)
                                Buffer &= "<td style='border:1px solid black;vertical-align:middle;'><img src=""" & FormerPathCreator.GetAnteprima(c) & """ width=80 align=absmiddle> <b>COMMESSA " & voce.IdCom & "</b></td>"
                            End Using
                        End If

                        Buffer &= "<td style='border:1px solid black;vertical-align:middle;'><b>" & voce.Descrizione.ToUpper & "</b></td>"
                        Buffer &= "<td style='border:1px solid black;vertical-align:middle;'><b>" & voce.Macchinario.ToUpper & "</b></td>"

                        Buffer &= "</tr>"
                    Next

                    If lFilter.Count Then
                        Buffer &= "<tr style='background-color:" & FormerColori.GetColoreToHtml(FormerColori.ColoreAmbienteGrigioChiaro) & ";'><td colspan=7 style='vertical-align:middle;'><h2>Totale lavorato: "

                        If TotMinuti < 60 Then
                            Buffer &= TotMinuti & " minuti"
                        Else
                            Dim TotOre As Integer = Math.Floor(TotMinuti / 60)

                            TotMinuti = TotMinuti - (TotOre * 60)

                            Buffer &= TotOre & " ore e " & TotMinuti & " minuti"

                        End If

                        Buffer &= "</h2></td></tr>"
                        Buffer &= "<tr><td colspan=7 >&nbsp;</td></tr>"
                    End If


                Next

            End Using

            Buffer &= "</table>"
        End Using

        Dim Path As String = FormerConfig.FormerPath.PathTempLocale & FormerHelper.File.GetNomeFileTemp(".htm")

        Using w As New StreamWriter(Path)
            w.Write(Buffer)
        End Using

        browser.Navigate(Path)

        Cursor.Current = Cursors.Default

    End Sub

End Class