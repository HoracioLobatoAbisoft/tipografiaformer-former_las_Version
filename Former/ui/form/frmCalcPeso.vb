Imports FormerDALSql
Friend Class frmCalcPeso
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(btnCancel)
    End Sub

    Friend Function Carica() As Integer

        ShowDialog()

        Return _Ris

    End Function

    Friend Function CaricaDocked(frm As Form) As Integer
        'la mostro di fianco a una form 

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

    Private Sub txtAltezza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAltezza.Click, txtFogli.Click, txtGrammatura.Click, txtLarghezza.Click, txtLarghezza2.Click, txtGrammatura2.Click, TxtFogli2.Click, txtAltezza2.Click
        sender.selectall()
    End Sub

    Private Sub txtAltezza_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAltezza.GotFocus, txtFogli.GotFocus, txtGrammatura.GotFocus, txtLarghezza.GotFocus, txtLarghezza2.GotFocus, txtGrammatura2.GotFocus, TxtFogli2.GotFocus, txtAltezza2.GotFocus
        'sender.SelectionStart = 0
        'sender.SelectionLength = sender.Text.Length
        sender.selectall()

    End Sub

    Private Sub txtAltezza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAltezza.KeyPress, _
        txtFogli.KeyPress, _
        txtGrammatura.KeyPress, _
        txtLarghezza.KeyPress, _
        txtPrezzoKg.KeyPress, _
        txtPrezzoKg2.KeyPress, _
        txtLarghezza2.KeyPress, _
        txtGrammatura2.KeyPress, _
        TxtFogli2.KeyPress, _
        txtAltezza2.KeyPress

        MgrControl.ControlloNumerico(sender, e, False)

    End Sub



    Private Sub CalcolaPeso()

        Dim Risultato As Double = 0
        Dim PrezzoCarta As Decimal = 0

        Dim Risultato2 As Double = 0
        Dim PrezzoCarta2 As Decimal = 0

        Try
            Risultato = (CDbl(txtAltezza.Text) * CDbl(txtLarghezza.Text) * CDbl(txtGrammatura.Text) * CDbl(txtFogli.Text) * txtNumPezzi.Value) / 10000000
            PrezzoCarta = Risultato * txtPrezzoKg.Text

            Risultato2 = (CDbl(txtAltezza2.Text) * CDbl(txtLarghezza2.Text) * CDbl(txtGrammatura2.Text) * CDbl(TxtFogli2.Text) * txtNumPezzi2.Value) / 10000000
            PrezzoCarta2 = Risultato2 * txtPrezzoKg2.Text

        Catch ex As Exception

        End Try

        lblKilogrammi.Text = Risultato
        lblPrezzoCarta.Text = PrezzoCarta

        lblKilogrammi2.Text = Risultato2
        lblPrezzoCarta2.Text = PrezzoCarta2


        lblColli.Text = Math.Ceiling(Risultato / 15)
        lblColli2.Text = Math.Ceiling(Risultato2 / 15)

        Try
            lblDiffKg.Text = Risultato2 - Risultato
            lblDiffPrezzoCarta.Text = PrezzoCarta2 - PrezzoCarta

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged

        If sender.text.length = 0 Then sender.text = "0"
        txtAltezza2.Text = sender.text
        CalcolaPeso()

    End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        txtLarghezza2.Text = sender.text
        CalcolaPeso()
    End Sub

    Private Sub txtGrammatura_TextChanged(sender As Object, e As EventArgs) Handles txtGrammatura.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        txtGrammatura2.Text = sender.text
        CalcolaPeso()
    End Sub

    Private Sub txtFogli_TextChanged(sender As Object, e As EventArgs) Handles txtFogli.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        TxtFogli2.Text = sender.text
        CalcolaPeso()
    End Sub

    Private Sub txtPrezzoKg_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoKg.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        txtPrezzoKg2.Text = sender.text
        CalcolaPeso()
    End Sub

    Private Sub txtAltezza2_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza2.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        CalcolaPeso()
    End Sub

    Private Sub txtLarghezza2_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza2.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        CalcolaPeso()

    End Sub

    Private Sub txtGrammatura2_TextChanged(sender As Object, e As EventArgs) Handles txtGrammatura2.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        CalcolaPeso()

    End Sub

    Private Sub TxtFogli2_TextChanged(sender As Object, e As EventArgs) Handles TxtFogli2.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        CalcolaPeso()

    End Sub

    Private Sub txtPrezzoKg2_TextChanged(sender As Object, e As EventArgs) Handles txtPrezzoKg2.TextChanged
        If sender.text.length = 0 Then sender.text = "0"
        CalcolaPeso()

    End Sub

    Private Sub txtNumPezzi_TextChanged(sender As Object, e As EventArgs) Handles txtNumPezzi.TextChanged
        txtNumPezzi2.Text = sender.text
        CalcolaPeso()
    End Sub

    Private Sub txtNumPezzi2_TextChanged(sender As Object, e As EventArgs) Handles txtNumPezzi2.TextChanged
        CalcolaPeso()
    End Sub
End Class