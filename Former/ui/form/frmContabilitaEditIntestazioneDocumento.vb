Imports System.IO.Ports
Imports FormerDALSql
Imports System.Threading
Imports FormerLib

Public Class frmContabilitaEditIntestazioneDocumento
    ' Inherits baseFormInternaFixed
    'Private ComPort As SerialPort
    ' Private tmrClose As Threading.Timer
    Dim _Ris As Integer = 0

    Private _R As Ricavo = Nothing

    Public Function Carica(ByRef R As Ricavo) As Integer

        _R = R

        Dim l As New List(Of IntestazioneDocumento)

        Dim Def As New IntestazioneDocumento

        Def.pRagSoc = _R.pRagSoc
        Def.pIndirizzo = _R.pIndirizzo
        Def.pCitta = _R.pCitta
        Def.pCap = _R.pCap
        Def.pIva = _R.pIva

        l.Add(Def)

        'qui li carico dal db 

        Using mgr As New RicaviDAO

            Dim lDb As List(Of IntestazioneDocumento) = mgr.GetIntestazioniDocumento(R.IdRub)

            For Each IntDb In lDb
                l.Add(IntDb)
            Next

        End Using


        Dim Nuovo As New IntestazioneDocumento
        Nuovo.pRagSoc = "- Nuova intestazione"
        Nuovo.pIndirizzo = String.Empty
        Nuovo.pCitta = String.Empty
        Nuovo.pCap = String.Empty
        Nuovo.pIva = String.Empty

        l.Add(Nuovo)

        cmbRagSoc.DisplayMember = "Riassunto"
        cmbRagSoc.DataSource = l

        cmbRagSoc.SelectedIndex = 0

        ShowDialog()

        R = _R
        Return _Ris

    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi la modifica dell'intestazione del documento contabile? Ricorda di ristampare il documento", "Intestazione documento contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _R.pRagSoc = txtpRagSoc.Text
            _R.pIndirizzo = txtIndirizzo.Text
            _R.pCitta = txtCitta.Text
            _R.pCap = txtCap.Text
            _R.pIva = txtPiva.Text
            _Ris = 1

            Close()

        End If

    End Sub

    Private Sub cmbRagSoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRagSoc.SelectedIndexChanged

        Try
            If Not cmbRagSoc.SelectedItem Is Nothing Then

                Dim Int As IntestazioneDocumento = cmbRagSoc.SelectedItem

                If Int.pRagSoc <> "- Nuova intestazione" Then
                    txtpRagSoc.Text = Int.pRagSoc
                Else
                    txtpRagSoc.Text = String.Empty
                End If

                txtIndirizzo.Text = Int.pIndirizzo
                txtCitta.Text = Int.pCitta
                txtCap.Text = Int.pCap
                txtPiva.Text = Int.pIva


            End If
        Catch ex As Exception

        End Try

    End Sub
End Class