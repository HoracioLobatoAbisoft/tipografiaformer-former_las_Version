Imports System.Windows.Forms
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmFileFTP
    'Inherits baseFormInterna

    Private _Ris As Integer
    Private _Origine As String
    Private _Destinazione As String

    Private _FtpConn As FTPclient
    Private _TipoOp As enTipoOpFTP

    Public Property FTPConnection() As FTPclient
        Get
            Return _FtpConn
        End Get
        Set(ByVal value As FTPclient)
            _FtpConn = value
        End Set
    End Property

    Friend Function Transfer(ByVal TipoOp As enTipoOpFTP, ByVal Origine As String, ByVal Destinazione As String) As Integer

        _Origine = Origine
        _Destinazione = Destinazione
        _TipoOp = TipoOp

        lblOrigine.Text = Origine
        ToolTipFile.SetToolTip(lblOrigine, Origine)
        lblDestinazione.Text = Destinazione
        ToolTipFile.SetToolTip(lblDestinazione, Destinazione)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub EseguiOperazione()

        'esegue effettivamente l'operazione che gli e' stata richiesta
        Try

            If _TipoOp = enTipoOpFTP.Upload Then
                _FtpConn.Upload(_Origine, _Destinazione)
            Else
                _FtpConn.Download(_Origine, _Destinazione, True)
            End If

            _Ris = 1

            Close()

        Catch ex As Exception

            If Not ex Is Nothing Then

                MessageBox.Show("Si è verificato il seguente errore nel trasferimento del file: " & ex.Message, "Errore trasferimento FTP", MessageBoxButtons.OK, MessageBoxIcon.Error)

                btnRetry.Enabled = True
                btnIgnore.Enabled = True

            End If

        End Try

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub tmrStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStart.Tick

        tmrStart.Enabled = False

        EseguiOperazione()

    End Sub

    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        btnRetry.Enabled = False
        btnIgnore.Enabled = False

        EseguiOperazione()
    End Sub

    Private Sub btnIgnore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnore.Click

        Close()

    End Sub

End Class