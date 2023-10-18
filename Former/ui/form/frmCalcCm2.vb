Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Friend Class frmCalcCm2
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(btnCancel)
    End Sub

    Private _Lrif As ListinoBase = Nothing

    Friend Function Carica(Lrif As ListinoBase) As Integer

        _Lrif = Lrif

        Dim DimensioneMax As Single = _Lrif.FormatoProdotto.FormatoCarta.Larghezza * 10

        lblLatoRif.Text = DimensioneMax

        txtAltezza.My_MinValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
        txtAltezza.My_DefaultValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
        txtLarghezza.My_MinValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin
        txtLarghezza.My_DefaultValue = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.LatoCortoMin

        txtLarghezza.My_MaxValue = DimensioneMax - (FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato * 2)

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

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged
        CalcolaTutto()
    End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged
        CalcolaTutto()
    End Sub

    Private Sub txtQuantita_TextChanged(sender As Object, e As EventArgs) Handles txtQuantita.TextChanged
        CalcolaTutto()
    End Sub

    Private Sub CalcolaTutto()

        lblRis.Text = MgrCalcoliTecnici.CalcolaCmQuadri(txtAltezza.Text,
                                                                        txtLarghezza.Text,
                                                                        enTipoOrientamento.Orizzontale,
                                                                        (_Lrif.FormatoProdotto.FormatoCarta.Larghezza * 10),
                                                                        txtQuantita.Text)

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub lblLatoRif_Click(sender As Object, e As EventArgs) Handles lblLatoRif.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub lblRis_Click(sender As Object, e As EventArgs) Handles lblRis.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub pctTipo_Click(sender As Object, e As EventArgs) Handles pctTipo.Click

    End Sub

    Private Sub lblTipo_Click(sender As Object, e As EventArgs) Handles lblTipo.Click

    End Sub
End Class