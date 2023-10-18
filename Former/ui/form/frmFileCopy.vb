
Imports System.IO
Imports FormerDALSql
Imports FormerLib

Friend Class frmFileCopy
    'Inherits baseFormInterna
    Private Enum enTipoAzione
        Copia = 1
        Sposta
    End Enum

    Private Azione As enTipoAzione = enTipoAzione.Copia


    Private _Ris As Integer = 0
    Private _Origine As String
    Private _Destinazione As String
    Private _ResizeImg As Boolean

    Friend Function Copia(ByVal Origine As String, ByVal Destinazione As String, Optional ByVal ResizeImg As Boolean = False) As Integer

        Azione = enTipoAzione.Copia
        _ResizeImg = ResizeImg
        _Origine = Origine
        _Destinazione = Destinazione

        lblOrigine.Text = Origine
        lblDestinazione.Text = Destinazione

        ShowDialog()

        Return _Ris

    End Function

    Friend Function Sposta(ByVal Origine As String, ByVal Destinazione As String, Optional ByVal ResizeImg As Boolean = False) As Integer

        Azione = enTipoAzione.Sposta
        _ResizeImg = ResizeImg
        _Origine = Origine
        _Destinazione = Destinazione

        lblOrigine.Text = Origine
        lblDestinazione.Text = Destinazione

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub tmrStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStart.Tick

        tmrStart.Enabled = False

        CopiaFile()

    End Sub

    Private Sub CopiaFile()
        'tenta di copiare il file di origine su quello di destinazione
        'se da errore permette di riprovare

        Try

            If _ResizeImg Then
                ResizeImg(_Origine, _Destinazione)
            Else
                FileCopy(_Origine, _Destinazione)
            End If
            If Azione = enTipoAzione.Sposta Then
                'qui devo cancellare il file di origine
                Try
                    MgrFormerIo.FileDelete(_Origine)
                    'questo lo metto in try catch cosi non rompe le scatole, se invece va in errore la copia lo blocco

                Catch ex As Exception

                End Try

            End If
            _Ris = 1
            Close()

        Catch ex As Exception
            'qui c'e' un errore

            If FormerDebug.DebugAttivo = False Then
                If Not ex Is Nothing Then
                    MessageBox.Show("Si è verificato il seguente errore nella copia del file: " & ex.Message, "Errore copia file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnRetry.Enabled = True
                    btnIgnore.Enabled = True
                End If
            Else
                _Ris = 1
                Close()
            End If

        End Try

    End Sub

    Private Sub ResizeImg(ByVal PathOld As String, ByVal PathNew As String)

        Dim Img As New Bitmap(PathOld)

        Dim width As Integer = 0, height As Integer = 0

        If Img.Width > Img.Height Then
            width = 800
            height = 600
        ElseIf Img.Width < Img.Height Then
            width = 600
            height = 800
        Else
            width = 800
            height = 800
        End If

        Dim ImgNew = New Bitmap(Img, New Size(width, height))

        Using ms As New MemoryStream()
            ImgNew.Save(ms, Imaging.ImageFormat.Jpeg)

            Dim imgData(ms.Length - 1) As Byte
            ms.Position = 0
            ms.Read(imgData, 0, ms.Length)
            Using fs As New FileStream(PathNew, FileMode.Create, FileAccess.Write)
                fs.Write(imgData, 0, UBound(imgData))
            End Using
        End Using
    End Sub

    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        btnRetry.Enabled = False
        btnIgnore.Enabled = False

        CopiaFile()
    End Sub

    Private Sub btnIgnore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnore.Click
        _Ris = 0
        Close()

    End Sub

End Class