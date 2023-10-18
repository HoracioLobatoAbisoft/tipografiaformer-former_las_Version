Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmCalcNumerazione
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

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

    Private Sub TrovaSoluzione()

        Try
            Dim NumeroIniziale As Integer = CInt(txtNumIniziale.Text)
            Dim NumeroBlocchi As Integer = CInt(txtNumBlocchi.Text)
            Dim FogliBlocco As Integer = CInt(txtFogliBlocco.Text)
            Dim NumeroFinale As Integer = NumeroBlocchi * FogliBlocco
            Dim Posizioni As Integer = CInt(txtPosizPag.Text)

            Dim NumeriInColonna As Single = NumeroFinale / Posizioni
            Dim RipetizioniBlocco As Single = NumeriInColonna Mod txtFogliBlocco.Text

            lblFogliCalc.Text = NumeriInColonna
            Dim SoluzioneMinima As Integer = Math.Ceiling(NumeriInColonna)

            Dim SoluzioneOttimale As Integer = SoluzioneMinima

            SoluzioneOttimale = (Math.Ceiling(SoluzioneMinima / FogliBlocco)) * FogliBlocco

            lblSoluzMinima.Text = SoluzioneMinima

            lblSoluzOttimale.Text = SoluzioneOttimale
            txtFogliProposti.Text = SoluzioneOttimale

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnProponiSoluz_Click(sender As Object, e As EventArgs) Handles btnProponiSoluz.Click

        TrovaSoluzione()

    End Sub

    Private Sub txtFogliProposti_TextChanged(sender As Object, e As EventArgs) Handles txtFogliProposti.TextChanged

        Try

            Dim NumeroFinale As Integer = CInt(txtFogliProposti.Text)
            Dim Posizioni As Integer = CInt(txtPosizPag.Text)

            Dim NumFinale As Integer = (CInt(txtNumIniziale.Text) + (NumeroFinale * Posizioni)) - 1

            lblNumReale.Text = NumFinale

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtNumBlocchi_TextChanged(sender As Object, e As EventArgs) Handles txtNumBlocchi.TextChanged, txtFogliBlocco.TextChanged, txtNumIniziale.TextChanged

        Try

            Dim NumFinale As Integer = (CInt(txtNumIniziale.Text) + (CInt(txtNumBlocchi.Text) * CInt(txtFogliBlocco.Text)) - 1)

            lblNumPrevista.Text = NumFinale

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCreaCSV_Click(sender As Object, e As EventArgs) Handles btnCreaCSV.Click

        If MessageBox.Show("Confermi la creazione della sequenza?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'controlli preliminari sul checkbox barcode

            Dim Path As String = FormerPath.PathTemp & FormerLib.FormerHelper.File.GetNomeFileTemp(".csv") ' gettemp"C:\temp\temp.csv"
            Dim NumeroIniziale As Integer = CInt(txtNumIniziale.Text)
            Dim NumeroFinale As Integer = (CInt(txtNumBlocchi.Text) * CInt(txtFogliBlocco.Text)) + NumeroIniziale - 1
            Dim NumeroPosizioni As Integer = CInt(txtPosizPag.Text)

            Dim NumeroCifre As Integer = NumeroFinale.ToString.Length
            Dim ParteFissa As String = txtParteFissa.Text

            Dim BarCodeOk As Boolean = True
            If chkBarcode.Checked Then
                If (ParteFissa.Length + NumeroCifre) > 13 Then
                    BarCodeOk = False
                End If
            End If

            If BarCodeOk Then
                Dim FogliScelti As Integer = txtFogliProposti.Text

                Dim ListaSerie As New List(Of List(Of Integer))
                Dim NumeroAttuale As Integer = NumeroIniziale

                For j = 1 To NumeroPosizioni
                    Dim NumeroFinaleSerie As Integer = NumeroAttuale + FogliScelti
                    Dim Serie As New List(Of Integer)
                    For I = NumeroAttuale To NumeroFinaleSerie
                        Serie.Add(I)
                    Next
                    ListaSerie.Add(Serie)
                    NumeroAttuale = NumeroFinaleSerie
                Next

                Dim Titolo As String = NumeroIniziale & "-" & NumeroFinale

                Using w As New StreamWriter(Path)

                    w.WriteLine(Titolo)

                    Dim ValoreIniziale As Integer = 0
                    Dim ValoreFinale As Integer = 0
                    Dim StepFor As Integer = 1

                    Dim Reverse As Boolean = False

                    If Reverse = False Then
                        ValoreIniziale = 0
                        ValoreFinale = FogliScelti - 1
                        StepFor = 1
                    Else
                        ValoreIniziale = FogliScelti - 1
                        ValoreFinale = 0
                        StepFor = -1
                    End If

                    For I As Integer = ValoreIniziale To ValoreFinale Step StepFor
                        For Each Lista As List(Of Integer) In ListaSerie
                            Dim Valore As String = String.Empty

                            If chkBarcode.Checked Then

                                Dim SpaziRestanti As Integer = 0
                                SpaziRestanti = 12 - ParteFissa.Length

                                Valore = ParteFissa & FormerLib.FormerHelper.Stringhe.FormattaConZeri(Lista(I), SpaziRestanti)
                            Else
                                Valore = FormerLib.FormerHelper.Stringhe.FormattaConZeri(Lista(I), NumeroCifre)
                            End If

                            If chkBarcode.Checked Then
                                'ToEAN13
                                Valore = FormerLib.FormerHelper.EAN13.ToEAN13(Valore)
                            End If

                            w.WriteLine(Valore)
                        Next
                    Next

                End Using

                FormerHelper.File.ShellExtended(Path)
            Else
                MessageBox.Show("Il codice a barre prevede 13 caratteri. La parte fissa inserita più i valori generati creano una sequenza più lunga.")
            End If

        End If

    End Sub

    Private Sub frmNumerazione_Load(sender As Object, e As EventArgs) Handles Me.Load

        'txtNumBlocchi.Text = 1000

    End Sub

    Private Sub btnCreaPDF_Click(sender As Object, e As EventArgs) Handles btnCreaPDF.Click

        Using f As New frmCalcNumerazionePDFEx 'frmCalcNumerazionePDF

            Sottofondo()

            f.Carica(txtNumIniziale.Text,
                     txtNumBlocchi.Text,
                     txtFogliBlocco.Text,
                     txtFogliProposti.Text,
                     txtPosizPag.Text,
                     chkBarcode.Checked,
                     txtParteFissa.Text)

            Sottofondo()

        End Using

    End Sub

End Class