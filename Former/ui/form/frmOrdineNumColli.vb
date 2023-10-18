Imports FormerDALSql

Public Class frmOrdineNumColli
    'Inherits baseFormInternaRedim

    Private _Ris As Integer = 0

    Public Sub New()
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.


        Catch ex As Exception

        End Try
    End Sub

    Friend ReadOnly Property NumColli As Integer
        Get
            Return _Ris
        End Get
    End Property

    Friend Function Carica(ByVal IdOrd As Integer,
                           ByVal NumColli As Integer) As Integer
        Try

            txtNumColli.Text = NumColli
            lblOrdine.Text = IdOrd

            Using O As New Ordine
                O.Read(IdOrd)
                MgrAnteprime.CreaRiepilogoOrd(O, UcAnteprimaO.WebPrint, FormerLib.FormerEnum.enTipoAnteprima.Operatore)

            End Using

            'ucOrdiniAnteprima.Carica(IdOrd, True, True)
            ShowDialog()

            Return _Ris
        Catch ex As Exception

        End Try

    End Function

    Private Sub frmBase_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtNumColli.Focus()
    End Sub

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If txtNumColli.Value <> 0 Then
            If MessageBox.Show("Confermi il numero di colli?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _Ris = txtNumColli.Value
                Close()
            End If
        Else
            MessageBox.Show("Numero di Colli inserito non valido!")
            txtNumColli.Focus()
        End If
    End Sub
End Class