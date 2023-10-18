Imports System.Drawing.Drawing2D
Imports System.IO

Friend Class frmCalcFustella
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        cmbZoom.SelectedIndex = 1

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileRul.InitialDirectory = "Z:\Fustelle\Programma\"
        OpenFileRul.ShowDialog()

        If OpenFileRul.FileName.Length Then
            txtFileRul.Text = OpenFileRul.FileName

            'carico l'anteprima

            Dim FileAnteprima As String = txtFileRul.Text.Replace(".rul", ".jpg")

            If File.Exists(FileAnteprima) Then
                pctAnteprima.Image = Image.FromFile(FileAnteprima)
            Else
                pctAnteprima.Image = Nothing
            End If
            pctPreviewSmall.Image = pctAnteprima.Image
            InterpretaRul()

        End If
    End Sub

    Private _ListaProc As List(Of ProcedimentoFustella) = Nothing

    Private Sub InterpretaRul()

        If txtFileRul.Text.Length Then
            Dim path As String = txtFileRul.Text.Trim
            _ListaProc = New List(Of ProcedimentoFustella)

            Dim p As ProcedimentoFustella = Nothing

            Dim CounterLama As Integer = 0
            Dim SpessoreLama As Single = 0

            Try
                SpessoreLama = (txtSpessoreLama.Text / 2)
            Catch ex As Exception

            End Try

            Using r As New StreamReader(path)
                Dim Riga As String = String.Empty
                Dim posInizio As Integer = 0
                Dim posFine As Integer = 0
                Dim Val As String = String.Empty

                While r.EndOfStream = False
                    Riga = r.ReadLine()

                    If Riga.StartsWith("start") Then

                        posInizio = 5
                        posFine = Riga.IndexOf(",", posInizio + 1)
                        Val = Riga.Substring(posInizio + 1, posFine - posInizio - 1).Replace(".", ",").Trim
                        p.StartX = Val

                        posInizio = Riga.IndexOf(",")
                        posFine = Riga.IndexOf(",", posInizio + 1)
                        Val = Riga.Substring(posInizio + 1, posFine - posInizio - 1).Replace(".", ",").Trim
                        p.StartY = Val
                        p.StartAngolo = Riga.Substring(posFine + 1).Replace(".", ",").Trim

                    End If

                    If Riga.StartsWith("type") Then

                        If Riga.IndexOf("tagliare") <> -1 Then
                            p.TipoAzione = "tagliare"
                        ElseIf Riga.IndexOf("cordonare") <> -1 Then
                            p.TipoAzione = "cordonare"
                        End If

                    End If

                    If Riga.StartsWith("rule") Then
                        CounterLama = 0

                        p = New ProcedimentoFustella

                        posInizio = Riga.IndexOf(",")

                        Val = Riga.Substring(4, posInizio - 4)
                        p.Pezzo = Val

                        Val = Riga.Substring(posInizio + 1)
                        p.Qta = Val

                    End If

                    If Riga.StartsWith("lipnone") Then

                        posInizio = Riga.IndexOf("e")
                        Val = Riga.Substring(posInizio + 1).Replace(".", ",")

                        If Val.Length Then
                            CounterLama -= 1
                            Val = Val - (SpessoreLama * CounterLama)
                            p.LunghezzaTotale = FormattaMM(Val)
                        End If

                    End If

                    If Riga.StartsWith("notch") Then

                        posInizio = Riga.IndexOf("h")
                        posFine = Riga.IndexOf(",", posInizio)
                        Val = Riga.Substring(posInizio + 1, posFine - posInizio - 1).Replace(".", ",").Trim
                        Dim V As New AzioneFustella
                        V.Tipo = "N"
                        V.Valore = Val
                        V.Descrizione = "N " & FormattaMM(V.Valore)
                        V.Counter = p.Notch.Count + 1
                        p.Notch.Add(V)

                    End If

                    If Riga.StartsWith("bend") Then
                        Dim Angolo As Integer = 0
                        posInizio = Riga.IndexOf(",")

                        Angolo = Riga.Substring(4, posInizio - 4).Replace(".", ",").Trim

                        If Angolo > 1 Or Angolo < -1 Then
                            Val = Riga.Substring(posInizio + 1).Replace(".", ",").Trim
                            'qui ho il valore 
                            'posso lavorare in base allo spessore della lama 

                            Dim ValSing As Single = Val

                            'If CounterLama <> 0 Then
                            ValSing -= SpessoreLama
                            'End If

                            Dim CountPrecedenti As Integer = p.Procedimento.FindAll(Function(x) x.Valore < ValSing).Count

                            If SpessoreLama Then ValSing -= (SpessoreLama * CountPrecedenti)

                            Dim V As New AzioneFustella
                            V.Valore = ValSing
                            V.Tipo = "B"
                            V.Descrizione = "B S1 " & FormattaMM(V.Valore) & "(" & Angolo & "°)"
                            V.Angolo = Angolo
                            V.Raggio = "S1"
                            V.Counter = p.Procedimento.Count + 1
                            p.Procedimento.Add(V)

                            'Val = "B " & FormattaMM(ValSing) & "(" & Angolo & "°)"
                            '    p.Procedimento.Add(Val)

                            CounterLama += 1

                        End If

                    End If

                    If Riga.StartsWith("curve") Then
                        Dim Buffer As String = "C"
                        Dim Raggio As Single = 0
                        Dim PuntoIniziale As Single = 0
                        Dim Angolo As Integer = 0

                        posInizio = Riga.IndexOf("e")
                        posFine = Riga.IndexOf(",", posInizio + 1)
                        Val = Riga.Substring(posInizio + 1, posFine - posInizio - 1).Replace(".", ",").Trim
                        Raggio = Val

                        posInizio = Riga.IndexOf(",")
                        posFine = Riga.IndexOf(",", posInizio + 1)
                        Val = Riga.Substring(posInizio + 1, posFine - posInizio - 1).Replace(".", ",").Trim
                        PuntoIniziale = Val

                        Angolo = Riga.Substring(posFine + 1).Replace(".", ",").Trim

                        Dim Lunghezza As Single = 0

                        Dim RaggioLunghezza As Single = Raggio

                        If CounterLama <> 0 Then
                            RaggioLunghezza -= SpessoreLama
                        End If

                        Lunghezza = (Math.Abs(Angolo) * (RaggioLunghezza * 2) * 3.14) / 360

                        PuntoIniziale += Lunghezza / 2

                        CounterLama += 1

                        Dim V As New AzioneFustella

                        V.Raggio = "R" & RaggioLunghezza

                        'Select Case Raggio
                        '    Case 2
                        '        V.Raggio = "S2"
                        '    Case 4
                        '        V.Raggio = "S5"
                        '    Case Else
                        '        V.Raggio = "R" & RaggioLunghezza
                        'End Select

                        'Buffer &= "-P.C" & FormattaMM(PuntoIniziale) & "(" & Angolo & "°)"

                        V.Valore = PuntoIniziale
                        V.Tipo = "C"
                        V.Descrizione = Buffer
                        V.Angolo = Angolo
                        V.Counter = p.Procedimento.Count + 1

                        p.Procedimento.Add(V)

                    End If

                    If Riga.StartsWith("endrule") Then

                        'qui a fine interpretazione rielaboro i notch
                        For Each N As AzioneFustella In p.Notch

                            Dim Count As Integer = 0

                            Count = p.Procedimento.FindAll(Function(x) x.Valore < N.Valore).Count

                            Count -= 1 'tolgo il primo

                            N.Valore -= (Count * SpessoreLama)

                        Next

                        _ListaProc.Add(p)

                    End If

                End While
            End Using

            dgProcedimento.AutoGenerateColumns = False
            dgProcedimento.DataSource = _ListaProc.FindAll(Function(x) x.TipoAzione = "tagliare")

            dgCordonatura.AutoGenerateColumns = False
            dgCordonatura.DataSource = _ListaProc.FindAll(Function(x) x.TipoAzione = "cordonare")


            dgProc.DataSource = Nothing
            dgNotch.DataSource = Nothing
            pctPreview.Image = Nothing

        End If

    End Sub

    Private Function FormattaMM(Val As Single) As String

        Dim ris As String = Format(Val, "#,##0.00")
        Return ris

    End Function

    Private Sub dgProcedimento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProcedimento.CellContentClick

    End Sub

    Private LastDataGrid As DataGridView = Nothing

    Private Sub CreaAnteprima()

        Dim P As ProcedimentoFustella = Nothing
        Dim Fattore As Integer = 3

        Try
            Fattore = cmbZoom.SelectedItem
        Catch ex As Exception

        End Try

        Dim AltezzaFissaLama As Integer = 21 * Fattore

        If LastDataGrid.SelectedRows.Count Then
            P = LastDataGrid.SelectedRows(0).DataBoundItem

            'CREO ANTEPRIMA DEL SINGOLO PEZZO

            Dim LarghezzaTotale As Integer = P.LunghezzaTotale * Fattore

            Dim bmp As New Bitmap(LarghezzaTotale + 60, AltezzaFissaLama + 40)
            Dim bmpPezzo As Graphics = Graphics.FromImage(bmp)
            Dim pBlack As New Pen(Color.Black, 2)
            Dim pBlackSmall As New Pen(Color.Black, 1)
            Dim pBend As New Pen(Color.Red, 1)
            Dim pCurve As New Pen(Color.Red, 1)
            pCurve.DashStyle = DashStyle.Dash

            Dim Etichetta As String = String.Empty
            Dim fnt As New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
            Dim Delta As Integer = 5
            bmpPezzo.DrawRectangle(pBlack, 5, 5, LarghezzaTotale, AltezzaFissaLama)
            bmpPezzo.DrawLine(pBlackSmall, 6, 8, LarghezzaTotale + 4, 8)

            Etichetta = "0"
            bmpPezzo.DrawString(Etichetta, fnt, Brushes.Black, 5, AltezzaFissaLama + Delta)

            Etichetta = FormattaMM(P.LunghezzaTotale)
            bmpPezzo.DrawString(Etichetta, fnt, Brushes.Black, LarghezzaTotale, AltezzaFissaLama + Delta)

            'flagGraphics.FillRectangle(Brushes.Red, 5, 5, LarghezzaTotale, AltezzaFissaLama)

            For Each n As AzioneFustella In P.Notch

                Dim AltezzaFissaNotch As Integer = 13 * Fattore
                Dim LarghezzaNotch As Single = 5
                Dim PIniz As Single = (n.Valore * Fattore) - (LarghezzaNotch / 2)

                bmpPezzo.FillRectangle(Brushes.Black, PIniz, AltezzaFissaLama - AltezzaFissaNotch, LarghezzaNotch * Fattore, AltezzaFissaNotch + 5)

                Etichetta = FormattaMM(n.Valore)
                If Delta = 20 Then Delta = 5 Else Delta = 20
                bmpPezzo.DrawString(Etichetta, fnt, Brushes.Black, PIniz, AltezzaFissaLama + Delta)

            Next

            For Each a As AzioneFustella In P.Procedimento

                If a.Tipo = "B" Then
                    bmpPezzo.DrawLine(pBend, 5 + (a.Valore * Fattore), 9, 5 + (a.Valore * Fattore), AltezzaFissaLama + 3)
                ElseIf a.Tipo = "C" Then
                    bmpPezzo.DrawLine(pCurve, 5 + (a.Valore * Fattore), 9, 5 + (a.Valore * Fattore), AltezzaFissaLama + 3)
                End If

                Etichetta = FormattaMM(a.Valore)
                If Delta = 20 Then Delta = 5 Else Delta = 20
                bmpPezzo.DrawString(Etichetta, fnt, Brushes.Black, (a.Valore * Fattore), AltezzaFissaLama + Delta)

            Next

            pctPreview.Image = bmp

            dgProc.AutoGenerateColumns = False
            dgProc.DataSource = P.Procedimento

            dgNotch.AutoGenerateColumns = False
            dgNotch.DataSource = P.Notch

            'LO EVIDENZIO NEL DISEGNO

            CreaStep(P.Pezzo)

        Else

            dgNotch.DataSource = Nothing
            dgProc.DataSource = Nothing

            pctPreview.Image = Nothing
            pctStep.Image = Nothing

        End If

    End Sub

    Private Sub CreaStep(Numero As Integer)

        Dim bmpStep As New Bitmap(300, 300)
        Dim bmpStepPezzo As Graphics = Graphics.FromImage(bmpStep)

        Dim pBlack As New Pen(Color.Black, 1)
        Dim pRed As New Pen(Color.Red, 1)
        Dim pUse As Pen = Nothing

        For Each sing As ProcedimentoFustella In _ListaProc

            Dim StartX As Integer = sing.StartX
            Dim StartY As Integer = sing.StartY

            Dim NextX As Integer = 0
            Dim NextY As Integer = 0

            'qui provo a disegnare questo pezzo 
            If sing.Pezzo = Numero Then
                pUse = pRed
            Else
                pUse = pBlack
            End If

            For Each proc As AzioneFustella In sing.Procedimento

            Next

            'bmpStepPezzo.DrawLine(pUse, sing.StartX, sing.StartY,)

        Next

        pctStep.Image = bmpStep


    End Sub

    Private Sub dgProcedimento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProcedimento.CellClick

        LastDataGrid = dgProcedimento

        CreaAnteprima()

    End Sub

    Private Sub txtSpessoreLama_TextChanged(sender As Object, e As EventArgs) Handles txtSpessoreLama.TextChanged

        InterpretaRul()

    End Sub

    Private Sub cmbZoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZoom.SelectedIndexChanged
        If sender.focus Then
            CreaAnteprima()
        End If
    End Sub

    Private Sub dgProc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProc.CellContentClick

    End Sub

    Private Sub CambiaValore()

        Dim A As AzioneFustella = Nothing

        If dgProc.SelectedRows.Count Then

            Dim R As DataGridViewRow = dgProc.SelectedRows(0)

            A = R.DataBoundItem

            Dim NewVal As Single = 0

            Dim Valore As String = InputBox("Inserisci il nuovo valore per questa azione", "Nuovo valore", A.Valore)

            If Valore.Length AndAlso IsNumeric(Valore) Then

                Dim OldVal As Single = A.Valore
                NewVal = Valore

                Dim Diff As Single = NewVal - OldVal
                Dim PezzoTrattato As Integer = A.Counter
                A.Valore = NewVal

                For Each singP As AzioneFustella In dgProc.DataSource

                    If singP.Counter > PezzoTrattato Then
                        singP.Valore = singP.Valore + Diff
                    End If

                Next

                Dim P As ProcedimentoFustella = dgProcedimento.SelectedRows(0).DataBoundItem

                P.LunghezzaTotale += FormattaMM(Diff)

                dgProcedimento.Refresh()
                dgProc.Refresh()

                CreaAnteprima()
            End If

        End If

    End Sub

    Private Sub CambiaNotch()

        Dim A As AzioneFustella = Nothing

        If dgNotch.SelectedRows.Count Then

            Dim R As DataGridViewRow = dgNotch.SelectedRows(0)

            A = R.DataBoundItem

            Dim NewVal As Single = 0

            Dim Valore As String = InputBox("Inserisci il nuovo valore per questo notch", "Nuovo valore", A.Valore)

            If Valore.Length AndAlso IsNumeric(Valore) Then
                NewVal = Valore
                A.Valore = NewVal
                dgNotch.Refresh()

                CreaAnteprima()
            End If

        End If

    End Sub

    Private Sub dgProc_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProc.CellDoubleClick

        CambiaValore()

    End Sub

    Private Sub dgNotch_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgNotch.CellDoubleClick
        CambiaNotch()
    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        If MessageBox.Show("Confermi il reset di tutti i valori?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            InterpretaRul()
            CreaAnteprima()

        End If
    End Sub

    Private Sub dgCordonatura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCordonatura.CellClick

        LastDataGrid = dgCordonatura
        CreaAnteprima()

    End Sub

End Class