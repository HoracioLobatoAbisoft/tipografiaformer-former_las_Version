Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucListinoValidatorError
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub Carica()

        Dim L As List(Of PreventivazioneValidator) = Nothing

        dgError.DataSource = Nothing

        Using mgr As New PreventivazioniValidatorDAO
            L = mgr.GetAllPrevValidator()

            Dim errori As New List(Of cEnum)

            Dim valNo As New cEnum
            valNo.Descrizione = "Default"
            valNo.Id = enValidatorErrorLevel.None
            errori.Add(valNo)

            Dim valInfo As New cEnum
            valInfo.Descrizione = "INFORMAZIONE"
            valInfo.Id = enValidatorErrorLevel.Informazione
            errori.Add(valInfo)

            Dim valWarn As New cEnum
            valWarn.Descrizione = "ATTENZIONE"
            valWarn.Id = enValidatorErrorLevel.Attenzione
            errori.Add(valWarn)

            Dim valErr As New cEnum
            valErr.Descrizione = "ERRORE"
            valErr.Id = enValidatorErrorLevel.Errore
            errori.Add(valErr)

            For i As Integer = 1 To 5
                Using Col As DataGridViewComboBoxColumn = dgError.Columns(i)
                    Col.DisplayMember = "Descrizione"
                    Col.ValueMember = "Id"
                    Col.DataSource = errori.ToList
                End Using
            Next

            dgError.AutoGenerateColumns = False
            dgError.DataSource = L

            'For Each singP In L

            '    Dim r As New DataGridViewRow
            '    r.Tag = singP
            '    r.CreateCells(dgError)
            '    r.Cells(0).Value = singP.Descrizione

            '    For i As Integer = 1 To 5

            '        'FormatoNonCorretto
            '        'DimensioniNonCorrette
            '        'OrientamentoNonCorretto
            '        'FontIncorporati
            '        'FontNonIncorporati
            '        'AbbondanzaErrata

            '        Dim veC As enValidatorErrorCode = i + 1

            '        Dim c As DataGridViewComboBoxCell = r.Cells(i)

            '        Dim errori As New List(Of cEnum)

            '        Dim valNo As New cEnum
            '        valNo.Descrizione = "Default"
            '        valNo.Id = enValidatorErrorLevel.None
            '        errori.Add(valNo)

            '        c.Items.Add(valNo)

            '        Dim valInfo As New cEnum
            '        valInfo.Descrizione = "INFO"
            '        valInfo.Id = enValidatorErrorLevel.Information
            '        errori.Add(valInfo)

            '        c.Items.Add(valInfo)

            '        Dim valWarn As New cEnum
            '        valWarn.Descrizione = "WARNING"
            '        valWarn.Id = enValidatorErrorLevel.Warning
            '        errori.Add(valWarn)

            '        c.Items.Add(valWarn)

            '        Dim valErr As New cEnum
            '        valErr.Descrizione = "ERROR"
            '        valErr.Id = enValidatorErrorLevel.Errore
            '        errori.Add(valErr)

            '        c.Items.Add(valErr)

            '        'c.DataSource = errori

            '        Using mgrV As New ValidatorErrorLevelDAO
            '            Dim vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", singP.IdPrev), _
            '                                                       New LUNA.LunaSearchParameter("ValidatorErrorCode", veC))

            '            If Not vel Is Nothing Then
            '                c.Value = errori.Find(Function(x) x.Id = vel.ValidatorErrorLevel)
            '            Else
            '                c.Value = valNo
            '            End If
            '            c.Tag = c.Value
            '        End Using

            '        ' c.Value = enValidatorErrorLevel.None
            '    Next

            '    dgError.Rows.Add(r)

            'Next

        End Using

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click

        Carica()

    End Sub

    Private Sub dgError_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgError.CellBeginEdit
        If e.ColumnIndex = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dgError_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgError.CellContentClick

    End Sub

    Private Sub dgError_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgError.CellEndEdit
        'Dim riga As DataGridViewRow = dgError.Rows(e.RowIndex)

        'ColoraCelleRiga(riga)
    End Sub

    Private Sub dgError_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgError.CellLeave
        ' SalvaValoreCella(e)

    End Sub

    Private Sub dgError_CellValuePushed(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgError.CellValuePushed

    End Sub

    Private Sub dgError_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgError.CurrentCellDirtyStateChanged


        '    dgError.BeginEdit(True)
        'ComboBox cmbMiCtrl=(ComboBox)dgError.EditingControl;
        'string Valor= cmbMiCtrl.Text;
        '    dataGridView1.EndEdit()

    End Sub

    Private Sub dgError_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgError.DataError

        e.Cancel = True

    End Sub

    Private Sub dgError_LostFocus(sender As Object, e As EventArgs) Handles dgError.LostFocus
        'Carica()
    End Sub

    Private Sub dgError_RowDirtyStateNeeded(sender As Object, e As QuestionEventArgs) Handles dgError.RowDirtyStateNeeded

    End Sub

    Private Sub ColoraCelleRiga(riga As DataGridViewRow)
        For Each c In riga.Cells
            If TypeOf (c) Is DataGridViewComboBoxCell Then
                If c.ColumnIndex <> 0 Then
                    Dim val As Integer = c.value

                    Select Case val
                        Case enValidatorErrorLevel.None
                            c.Style.BackColor = Color.White
                        Case enValidatorErrorLevel.Informazione
                            c.Style.BackColor = Color.Yellow
                        Case enValidatorErrorLevel.Attenzione
                            c.Style.BackColor = Color.Orange
                        Case enValidatorErrorLevel.Errore
                            c.Style.BackColor = Color.Red

                    End Select
                End If
            End If
        Next
    End Sub

    Private Sub dgError_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgError.RowPostPaint
        Dim riga As DataGridViewRow = dgError.Rows(e.RowIndex)

        ColoraCelleRiga(riga)
    End Sub

    Private Sub dgError_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgError.RowsAdded
     

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click
        If MessageBox.Show("Confermi il salvataggio dei valori inseriti?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SalvaSituazione()
        End If
    End Sub

    Private Sub SalvaSituazione()

        For Each row As DataGridViewRow In dgError.Rows
            Using p As PreventivazioneValidator = row.DataBoundItem

                Using mgr As New ValidatorErrorLevelDAO
                    mgr.ResetPreventivazione(p.IdPrev)
                End Using

                For i As Integer = 1 To 5
                    Dim Cell As DataGridViewComboBoxCell = row.Cells(i)

                    Dim veC As enValidatorErrorCode = i + 1
                    Dim veL As enValidatorErrorLevel = Cell.Value

                    If veL <> enValidatorErrorLevel.None Then
                        Using ve As New ValidatorErrorLevel
                            ve.IdPreventivazione = p.IdPrev
                            ve.ValidatorErrorLevel = veL
                            ve.ValidatorErrorCode = veC
                            ve.Save()
                        End Using
                    End If
                Next

            End Using
        Next

    End Sub

End Class
