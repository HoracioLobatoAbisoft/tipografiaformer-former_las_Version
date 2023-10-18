Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoCatVirtuale
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    Private _C As CatVirtuale = Nothing

    Private Sub CaricaListiniBase()
        DgListinoBase.DataSource = Nothing
        DgListinoBase.Rows.Clear()

        DgListinoBase.AutoGenerateColumns = False
        DgListinoBase.DataSource = _C.ListiniBase

        'DgListinoBase.Refresh()
        'CaricaListiniBaseOrdine()
    End Sub


    Friend Function Carica(Optional Id As Integer = 0) As Integer

        _C = New CatVirtuale
        If Id Then
            _C.Read(Id)
            txtNome.Text = _C.Nome

            CaricaListiniBase()

        End If

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

    'Private Sub btnCreaExcel_Click(sender As Object, e As EventArgs)

    '    Dim excel As Application = New Application
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim w As Workbook = excel.Workbooks.Add(misValue)
    '    w.Worksheets(3).delete()
    '    w.Worksheets(2).delete()
    '    'cancello gli altri sheet

    '    Dim sheet As Worksheet = w.Sheets(1)
    '    sheet.Name = "Risultati"
    '    Dim PathDir As String = FormerPath.PathLocale & "xls\"
    '    CreateLongDir(PathDir)
    '    Dim PathXLS As String = PathDir & GetNomeFileTemp(".xls")
    '    'Dim X As New Microsoft.Office.Interop.Excel.Workbook

    '    'IDFORMATO IDCARTA FORMATO CARTA 
    '    '500 1000 2000 3000 4000 5000 6000 7000 8000 9000 10000 15000 20000 30000 
    '    '40000 50000 60000 70000 80000 90000 100000

    '    Dim style As Style = w.Styles.Add("NewStyle")
    '    style.Font.Bold = True
    '    style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)


    '    'Dim r As Range = sheet.UsedRange

    '    sheet.Cells(1, 1).value = "IDFP"
    '    sheet.Cells(1, 2).value = "IDC"
    '    sheet.Cells(1, 3).value = "FORMPROD"
    '    sheet.Cells(1, 4).value = "CARTA"
    '    sheet.Cells(1, 5).value = "PREZZOCARTA"
    '    sheet.Cells(1, 6).value = "IDCURVA"
    '    sheet.Cells(1, 7).value = "COLORIDISTAMPA"
    '    sheet.Cells(1, 8).value = "500"
    '    sheet.Cells(1, 9).value = "1000"
    '    sheet.Cells(1, 10).value = "2000"
    '    sheet.Cells(1, 11).value = "3000"
    '    sheet.Cells(1, 12).value = "4000"
    '    sheet.Cells(1, 13).value = "5000"
    '    sheet.Cells(1, 14).value = "6000"
    '    sheet.Cells(1, 15).value = "7000"
    '    sheet.Cells(1, 16).value = "8000"
    '    sheet.Cells(1, 17).value = "9000"
    '    sheet.Cells(1, 18).value = "10000"
    '    sheet.Cells(1, 19).value = "15000"
    '    sheet.Cells(1, 20).value = "20000"
    '    sheet.Cells(1, 21).value = "30000"
    '    sheet.Cells(1, 22).value = "40000"
    '    sheet.Cells(1, 23).value = "50000"
    '    sheet.Cells(1, 24).value = "60000"
    '    sheet.Cells(1, 25).value = "70000"
    '    sheet.Cells(1, 26).value = "80000"
    '    sheet.Cells(1, 27).value = "90000"
    '    sheet.Cells(1, 28).value = "100000"

    '    Dim ColsI As Integer = 29

    '    For Each itemL As Lavorazione In chkLstLav.CheckedItems

    '        sheet.Cells(1, ColsI).value = itemL.IdLavoro & "@" & itemL.Descrizione & " Min."

    '        ColsI += 1

    '        sheet.Cells(1, ColsI).value = itemL.IdLavoro & "@" & itemL.Descrizione & " Copia"

    '        ColsI += 1

    '    Next

    '    For y As Integer = 1 To 50
    '        sheet.Cells(1, y).Style = "NewStyle"
    '    Next

    '    Dim RowsI As Integer = 2
    '    For Each item As FormatoProdotto In chkLstFormati.CheckedItems

    '        For Each itemC As TipoCarta In chkLstCarta.CheckedItems

    '            Dim Sigla As String = item.Sigla & itemC.Sigla

    '            Dim sheetForm As Worksheet = w.Sheets.Add

    '            sheetForm.Name = Sigla
    '            sheetForm.Cells(1, 1) = item.Formato & " " & itemC.Tipologia

    '            sheet.Cells(RowsI, 1) = item.IdFormProd
    '            sheet.Cells(RowsI, 2) = itemC.IdTipoCarta
    '            sheet.Cells(RowsI, 3) = item.Formato
    '            sheet.Cells(RowsI, 4) = itemC.Tipologia
    '            sheet.Cells(RowsI, 5) = "='" & Sigla & "'!B5"
    '            sheet.Cells(RowsI, 6) = "='" & Sigla & "'!C1"
    '            Dim ColsInd As Integer = 8
    '            For indC As Integer = 68 To 88
    '                sheet.Cells(RowsI, ColsInd) = "='" & Sigla & "'!" & Chr(indC) & "51"
    '                ColsInd += 1
    '            Next
    '            RowsI += 1
    '        Next

    '    Next

    '    Dim sheet2 As Worksheet = w.Sheets.Add()
    '    sheet2.Name = "Curve Attenuatori"
    '    sheet2.Cells(1, 1).value = "IDCURVA"
    '    sheet2.Cells(1, 2).value = "NOMECURVA"
    '    sheet2.Cells(1, 3).value = ""
    '    sheet2.Cells(1, 4).value = ""
    '    sheet2.Cells(1, 5).value = "500"
    '    sheet2.Cells(1, 6).value = "1000"
    '    sheet2.Cells(1, 7).value = "2000"
    '    sheet2.Cells(1, 8).value = "3000"
    '    sheet2.Cells(1, 9).value = "4000"
    '    sheet2.Cells(1, 10).value = "5000"
    '    sheet2.Cells(1, 11).value = "6000"
    '    sheet2.Cells(1, 12).value = "7000"
    '    sheet2.Cells(1, 13).value = "8000"
    '    sheet2.Cells(1, 14).value = "9000"
    '    sheet2.Cells(1, 15).value = "10000"
    '    sheet2.Cells(1, 16).value = "15000"
    '    sheet2.Cells(1, 17).value = "20000"
    '    sheet2.Cells(1, 18).value = "30000"
    '    sheet2.Cells(1, 19).value = "40000"
    '    sheet2.Cells(1, 20).value = "50000"
    '    sheet2.Cells(1, 21).value = "60000"
    '    sheet2.Cells(1, 22).value = "70000"
    '    sheet2.Cells(1, 23).value = "80000"
    '    sheet2.Cells(1, 24).value = "90000"
    '    sheet2.Cells(1, 25).value = "100000"

    '    For y As Integer = 1 To 25
    '        sheet2.Cells(1, y).Style = "NewStyle"
    '    Next

    '    RowsI = 2
    '    Dim lC As List(Of CurvaAtt) = (New CurveAttDAO).GetAll("NomeCurva")
    '    For Each C As CurvaAtt In lC
    '        sheet2.Cells(RowsI, 1) = C.IdCurvaAtt
    '        sheet2.Cells(RowsI, 2) = C.NomeCurva
    '        sheet2.Cells(RowsI, 5) = C.v500
    '        sheet2.Cells(RowsI, 6) = C.v1000
    '        sheet2.Cells(RowsI, 7) = C.v2000
    '        sheet2.Cells(RowsI, 8) = C.v3000
    '        sheet2.Cells(RowsI, 9) = C.v4000
    '        sheet2.Cells(RowsI, 10) = C.v5000
    '        sheet2.Cells(RowsI, 11) = C.v6000
    '        sheet2.Cells(RowsI, 12) = C.v7000
    '        sheet2.Cells(RowsI, 13) = C.v8000
    '        sheet2.Cells(RowsI, 14) = C.v9000
    '        sheet2.Cells(RowsI, 15) = C.v10000
    '        sheet2.Cells(RowsI, 16) = C.v15000
    '        sheet2.Cells(RowsI, 17) = C.v20000
    '        sheet2.Cells(RowsI, 18) = C.v30000
    '        sheet2.Cells(RowsI, 19) = C.v40000
    '        sheet2.Cells(RowsI, 20) = C.v50000
    '        sheet2.Cells(RowsI, 21) = C.v60000
    '        sheet2.Cells(RowsI, 22) = C.v70000
    '        sheet2.Cells(RowsI, 23) = C.v80000
    '        sheet2.Cells(RowsI, 24) = C.v90000
    '        sheet2.Cells(RowsI, 25) = C.v100000
    '        RowsI += 1
    '    Next

    '    w.SaveAs(PathXLS)
    '    w.Close()
    '    excel.Quit()

    '    releaseObject(sheet)
    '    releaseObject(w)
    '    releaseObject(excel)

    '    FormerHelper.File.ShellExtended(PathXLS)

    'End Sub

    'Private Sub btnSfoglia_Click(sender As Object, e As EventArgs)

    '    openXLS.ShowDialog()
    '    If openXLS.FileName.Length Then
    '        txtFileXLS.Text = openXLS.FileName
    '    End If

    'End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    'Private Sub btnRecupera_Click(sender As Object, e As EventArgs)

    '    Dim excel As Application = New Application
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim w As Workbook = excel.Workbooks.Open(txtFileXLS.Text)

    '    Dim sheet As Worksheet = w.Sheets("sheet1")

    '    'IDFORMATO IDCARTA FORMATO CARTA 
    '    '500 1000 2000 3000 4000 5000 6000 7000 8000 9000 10000 15000 20000 30000 
    '    '40000 50000 60000 70000 80000 90000 100000

    '    Dim RowsI As Integer = 2
    '    Dim strTrovata As String = ""

    '    Do

    '        strTrovata = sheet.Cells(RowsI, 1).value  'IDFORMPROD

    '        If Not strTrovata Is Nothing Then
    '            'qui se ho trovato qualcosa lo interpreto e lo salvo altrimenti vuoldire che sono finite le righe piene
    '            'mi becco il valore
    '            Dim Valore As String = sheet.Cells(RowsI, 5).value

    '            Valore = Valore
    '        End If

    '        RowsI += 1

    '    Loop While Not strTrovata Is Nothing

    '    w.Close()
    '    excel.Quit()

    '    releaseObject(sheet)
    '    releaseObject(w)
    '    releaseObject(excel)

    'End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        '        If SalvaPreventivazione() Then
        If MessageBox.Show("Confermi il salvataggio della Categoria Virtuale?", "Salva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If txtNome.Text.Trim.Length Then
                _C.Nome = txtNome.Text.Trim
                _C.Save()

                _Ris = 1
                Close()

            Else
                MessageBox.Show("Inserisci il nome della categoria virtuale")
            End If

        End If

        '       End If

    End Sub

    Private Sub btnAddListBase_Click(sender As Object, e As EventArgs) Handles btnAddListBase.Click
        If _C.IdCatVirtuale Then
            Sottofondo()
            Using f As New frmSelectLB
                Dim Ris As Integer = f.Carica(_C)

                If Ris Then

                    If _C.ListiniBase.FindAll(Function(x) x.IdListinoBase = Ris).Count = 0 Then
                        Using cl As New ListinoSuCatVirtuale
                            cl.IdCatVirtuale = _C.IdCatVirtuale
                            cl.IdListinoBase = Ris
                            cl.Save()
                        End Using
                        CaricaListiniBase()
                    End If

                End If
            End Using
            Sottofondo()
        Else
            MessageBox.Show("Salvare prima la categoria virtuale")
        End If
    End Sub

    Private Sub btnDelListBase_Click(sender As Object, e As EventArgs) Handles btnDelListBase.Click

        If DgListinoBase.SelectedRows.Count Then
            If MessageBox.Show("Confermi la cancellazione del listinobase dalla categoria Virtuale?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim lb As ListinoBase = DgListinoBase.SelectedRows(0).DataBoundItem

                Using mgr As New ListiniSuCatVirtualeDAO
                    mgr.DeleteByIdCatIdListinoBase(_C.IdCatVirtuale, lb.IdListinoBase)

                End Using

                CaricaListiniBase()

            End If

        End If

    End Sub



    'Private Sub chkListLav_ItemCheck(sender As Object, e As ItemCheckEventArgs)
    '    If e.NewValue = CheckState.Checked Then
    '        Dim item As Lavorazione = chkListLav.Items(e.Index)

    '        For Each i As Lavorazione In chkListLavOpz.CheckedItems
    '            If i.IdLavoro = item.IdLavoro Then
    '                'deselezionare la voce
    '                chkListLavOpz.SetItemCheckState(e.Index, CheckState.Unchecked)
    '                Exit For
    '            End If
    '        Next

    '    End If

    'End Sub

    'Private Sub chkListLav_SelectedIndexChanged(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub chkListLavOpz_ItemCheck(sender As Object, e As ItemCheckEventArgs)
    '    If e.NewValue = CheckState.Checked Then
    '        Dim item As Lavorazione = chkListLavOpz.Items(e.Index)

    '        For Each i As Lavorazione In chkListLav.CheckedItems
    '            If i.IdLavoro = item.IdLavoro Then
    '                'deselezionare la voce
    '                chkListLav.SetItemCheckState(e.Index, CheckState.Unchecked)
    '                Exit For
    '            End If
    '        Next

    '    End If
    'End Sub

End Class