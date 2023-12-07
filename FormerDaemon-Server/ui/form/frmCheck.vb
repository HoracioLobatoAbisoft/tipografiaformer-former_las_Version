Imports F = FormerDALSql
Imports Fw = FormerDALWeb

Public Class frmCheck
    Private _Ris As Integer = 0
    Public Function Carica() As Integer

        ShowDialog()

        Return _Ris
    End Function

    Private Sub CheckReale()

        tmrCheck.Enabled = False

        Try
            'Dim AddressServerInterno As String = "former-server"
            Dim AddressServerInterno As String = "localhost"
            Dim ris As Integer = Postazione.Network.IsPingable(AddressServerInterno)
            If ris Then
                imgServerInterno.Image = My.Resources.icoOk
            Else
                _Ris = 1
                imgServerInterno.Image = My.Resources.icoKO
            End If
        Catch ex As Exception
            _Ris = 1
            imgServerInterno.Image = My.Resources.icoKO
        End Try

        Application.DoEvents()
        Threading.Thread.Sleep(1000)

        Try
            Using mgr As New F.UtentiDAO
                Dim l As List(Of F.Utente) = mgr.GetAll()
            End Using
            imgDBInterno.Image = My.Resources.icoOk
        Catch ex As Exception
            _Ris = 1
            imgDBInterno.Image = My.Resources.icoKO
        End Try
        Threading.Thread.Sleep(1000)

        Try
            Dim ris As Integer = Postazione.Network.ConnessioneInternetDisponibile
            If ris Then
                imgConnInternet.Image = My.Resources.icoOk
            Else
                _Ris = 2
                imgConnInternet.Image = My.Resources.icoKO
            End If
        Catch ex As Exception
            _Ris = 2
            imgConnInternet.Image = My.Resources.icoKO
        End Try
        Application.DoEvents()
        Threading.Thread.Sleep(1000)

        Try
            Dim ris As Integer = Postazione.Network.IsPingable("www.tipografiaformer.it", 1500)
            If ris Then
                imgSito.Image = My.Resources.icoOk
            Else
                _Ris = 2
                imgSito.Image = My.Resources.icoKO
            End If
        Catch ex As Exception
            _Ris = 2
            imgSito.Image = My.Resources.icoKO
        End Try
        Application.DoEvents()
        Threading.Thread.Sleep(1000)

        Try
            Dim AddressServerVirtuale As String = "188.213.172.73"
            Dim ris As Integer = Postazione.Network.IsPingable(AddressServerVirtuale)
            If ris Then
                imgServer.Image = My.Resources.icoOk
            Else
                _Ris = 2
                imgServer.Image = My.Resources.icoKO
            End If
        Catch ex As Exception
            _Ris = 2
            imgServer.Image = My.Resources.icoKO
        End Try
        Application.DoEvents()
        Threading.Thread.Sleep(1000)

        Try
            Using mgr As New Fw.RegioniDAO
                Dim l As List(Of Fw.Regione) = mgr.GetAll()
            End Using
            imgDBRemoto.Image = My.Resources.icoOk
        Catch ex As Exception
            _Ris = 2
            imgDBRemoto.Image = My.Resources.icoKO
        End Try
        Threading.Thread.Sleep(1000)

        Select Case _Ris
            Case 0
                Close()
            Case 1 'errore bloccante

            Case 2 'errore non bloccante
                tmrAutoChiusura.Enabled = True
        End Select

        btnClose.Enabled = True

    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick

        CheckReale()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        End

    End Sub

    Private Sub tmrAutoChiusura_Tick(sender As Object, e As EventArgs) Handles tmrAutoChiusura.Tick

        _Ris = 0

        Close()

    End Sub
End Class