Imports FormerBusinessLogicInterface
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucDocumentiFiscaliEditRow
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private _M As MovimentoMagazzino = Nothing

    Public Sub Carica(ByRef M As MovimentoMagazzino)

        _M = M

        txtQta.Text = M.Qta
        txtPrezzo.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(M.Prezzo, 2)
        txtPrezzo.Focus()

    End Sub

    Public Sub Salva()
        _M.Qta = txtQta.Text
        _M.Prezzo = txtPrezzo.Text
        _M.Save()
    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click
        Salva()
        RaiseEvent ClickSalva(_M.IdCarMag)
    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click
        RaiseEvent ClickAnnulla()
    End Sub

    Public Event ClickAnnulla()
    Public Event ClickSalva(IdMovimento As Integer)

    Private Sub CalcolaPrezzoUnit()
        Dim PrezzoUnit As Decimal = 0

        Try

            Dim prezzo As Decimal = CDec(txtPrezzo.Text)
            Dim qta As Single = txtQta.Text

            PrezzoUnit = prezzo / qta

        Catch ex As Exception
            PrezzoUnit = 0
        End Try

        txtPrezzoUnit.Text = PrezzoUnit
    End Sub

    Private Sub CalcolaPesoEPrezzoKg()
        Try


            Dim IdRis As Integer = _M.IdRis
            If IdRis Then
                Dim Peso As Single = 0
                Dim PrezzoAlKg As Decimal = 0
                Dim PrezzoTot As Decimal = txtPrezzo.Text
                Dim Qta As Integer = txtQta.Text

                Using R As New Risorsa
                    R.Read(IdRis)

                    Peso = MgrPreventivazioneB.CalcolaKgCarta(R.Lunghezza, R.Larghezza, R.Grammatura, Qta)

                End Using

                PrezzoAlKg = PrezzoTot / Peso

                txtPesoKg.Text = Math.Round(Peso, 2)
                txtPrezzoKg.Text = FormerHelper.Stringhe.FormattaPrezzo(PrezzoAlKg)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtQta_TextChanged(sender As Object, e As EventArgs) Handles txtQta.TextChanged, txtPrezzo.TextChanged
        CalcolaPrezzoUnit()
        CalcolaPesoEPrezzoKg()
    End Sub

    Private Sub txtQta_GotFocus(sender As Object, e As EventArgs) Handles txtQta.GotFocus, txtPrezzo.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub txtQta_Click(sender As Object, e As EventArgs) Handles txtQta.Click, txtPrezzo.Click
        sender.SelectAll()
    End Sub
End Class
