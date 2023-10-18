Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Friend Class frmCalcPrezzoIndicativo
    ' Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _TipoProd As enTipoProdCom

    Private Sub CaricaCombo()

        Dim TipoFormato As New cTipoFormatoCalcCarta
        cmbFormato.DataSource = TipoFormato
        cmbFormato.ValueMember = "Id"
        cmbFormato.DisplayMember = "Descrizione"

        Dim TipoCarta As New cTipoCarta

        cmbCarta.DataSource = TipoCarta
        cmbCarta.ValueMember = "Id"
        cmbCarta.DisplayMember = "Descrizione"

        Dim TipoLav As New cTipoLavorazioni

        cmbLavorazioni.DataSource = TipoLav
        cmbLavorazioni.ValueMember = "Id"
        cmbLavorazioni.DisplayMember = "Descrizione"

    End Sub

    Friend Function Carica() As Integer
        CaricaCombo()
        MgrControl.SelectIndexComboEnum(cmbFormato, 2)

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

    Private Sub txtCopie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopie.KeyPress, txtPagine.KeyPress
        Dim x As Char = vbBack
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCopie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCopie.TextChanged, txtPagine.TextChanged
        EseguiCalcolo()
    End Sub

    Private Sub EseguiCalcolo()

        Try

            Dim ImportoSingolo As Decimal = 0

            If rdoBiancoNero.Checked Then
                ImportoSingolo = 0.1
                If chkRiv.Checked Then
                    ImportoSingolo = 0.05
                End If
            Else
                ImportoSingolo = 0.9
                If chkRiv.Checked Then
                    ImportoSingolo = 0.28
                End If
            End If

            If chkFR.Checked = True And chkRiv.Checked = False Then
                ImportoSingolo *= 2
            End If

            Dim Copie As Integer = 0
            Copie = txtCopie.Text

            Dim Pagine As Integer = 0
            Pagine = txtPagine.Text

            Dim NFogli As Single = Math.Ceiling((Copie * Pagine) / cmbFormato.SelectedValue)

            Dim Importo As Decimal = NFogli * ImportoSingolo

            If cmbCarta.SelectedValue Then

                Importo += ((Importo * cmbCarta.SelectedValue) / 100)

            End If

            If cmbLavorazioni.SelectedValue Then
                Dim PercAum As Integer = 0
                Dim ImportoLav As Decimal = 0
                If cmbLavorazioni.SelectedValue = cTipoLavorazioni.enTipoLav.Spillatura Then
                    PercAum = 15
                ElseIf cmbLavorazioni.SelectedValue = cTipoLavorazioni.enTipoLav.RifiloComplesso Then
                    PercAum = 15
                ElseIf cmbLavorazioni.SelectedValue = cTipoLavorazioni.enTipoLav.SpiraleMetallica Then
                    PercAum = 0

                    ImportoLav = (Copie * 3)

                ElseIf cmbLavorazioni.SelectedValue <> cTipoLavorazioni.enTipoLav.Nessuna Then
                    PercAum = 10
                End If

                If PercAum Then ImportoLav = ((Importo * PercAum) / 100)

                If ImportoLav < 5 Then ImportoLav = 5

                Importo += ImportoLav
            End If

            If chkFileDiversi.Checked Then

                Importo += 5

            End If

            lblPrezzoCalc.Text = "€ " & FormerHelper.Stringhe.FormattaPrezzo(importo)

        Catch ex As Exception

        End Try

    End Sub

    Private Class cTipoLavorazioni
        Inherits CollectionBase

        Public Enum enTipoLav As Integer
            Nessuna = 0
            Spillatura
            Cordonatura
            RifiloSemplice
            RifiloComplesso
            SpiraleMetallica
        End Enum

        Public Sub New()

            Dim TipoProd As cEnum

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.Nessuna
            TipoProd.Descrizione = "Nessuna"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.Spillatura
            TipoProd.Descrizione = "Spillatura"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.Cordonatura
            TipoProd.Descrizione = "Cordonatura"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.RifiloSemplice
            TipoProd.Descrizione = "Rifilo semplice"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.RifiloComplesso
            TipoProd.Descrizione = "Rifilo complesso"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = enTipoLav.SpiraleMetallica
            TipoProd.Descrizione = "Spirale Metallica"
            InnerList.Add(TipoProd)

        End Sub

        Default Public Property item(ByVal index As Integer) As cEnum
            Get
                Return (CType(InnerList.Item(index), cEnum))
            End Get
            Set(ByVal Value As cEnum)
                InnerList.Item(index) = Value
            End Set
        End Property

    End Class

    Private Class cTipoCarta
        Inherits CollectionBase

        Public Sub New()

            Dim TipoProd As cEnum

            TipoProd = New cEnum
            TipoProd.Id = 0
            TipoProd.Descrizione = "Usomano 80gr"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 60
            TipoProd.Descrizione = "Cartoncino Bristol"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 90
            TipoProd.Descrizione = "Cartoncino Lavorato"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 40
            TipoProd.Descrizione = "Cartoncino Patinato "
            InnerList.Add(TipoProd)

        End Sub
        Default Public Property item(ByVal index As Integer) As cEnum
            Get
                Return (CType(InnerList.Item(index), cEnum))
            End Get
            Set(ByVal Value As cEnum)
                InnerList.Item(index) = Value
            End Set
        End Property
    End Class

    Private Class cTipoFormatoCalcCarta
        Inherits CollectionBase

        Public Sub New()
            Dim TipoProd As cEnum

            'TipoProd = New cEnum
            'TipoProd.Id = 20
            'TipoProd.Descrizione = "Biglietti da Visita 8,5 x 5,5"
            'InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 8
            TipoProd.Descrizione = "Cartoline 10 x 15"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 6
            TipoProd.Descrizione = "Inviti 10 x 21"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 8
            TipoProd.Descrizione = "A6 10 x 15"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 4
            TipoProd.Descrizione = "A5 15 x 21"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 2
            TipoProd.Descrizione = "A4 21 x 29,7"
            InnerList.Add(TipoProd)

            TipoProd = New cEnum
            TipoProd.Id = 1
            TipoProd.Descrizione = "A3 29,7 x 42"
            InnerList.Add(TipoProd)

        End Sub
        Default Public Property item(ByVal index As Integer) As cEnum
            Get
                Return (CType(InnerList.Item(index), cEnum))
            End Get
            Set(ByVal Value As cEnum)
                InnerList.Item(index) = Value
            End Set
        End Property
    End Class

    Private Sub cmbFormato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormato.SelectedIndexChanged, cmbCarta.SelectedIndexChanged
        EseguiCalcolo()
    End Sub

    Private Sub chkFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFR.CheckedChanged, chkRiv.CheckedChanged
        EseguiCalcolo()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        _Ris = 1
        Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtPagineIns_TextChanged(sender As Object, e As EventArgs) Handles txtPagineIns.TextChanged

        If chkRiv.Checked Then

            Dim ValInserito As Integer = txtPagineIns.Value

            If ValInserito Mod 4 = 0 Then
                txtPagine.Text = ValInserito / 4
            Else
                txtPagine.Text = 4
            End If

        Else
            txtPagine.Text = txtPagineIns.Text
        End If

    End Sub

    Private Sub lblPrezzoCalc_Click(sender As Object, e As EventArgs) Handles lblPrezzoCalc.Click

    End Sub

    Private Sub cmbLavorazioni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLavorazioni.SelectedIndexChanged
        EseguiCalcolo()
    End Sub

    Private Sub rdoColori_CheckedChanged(sender As Object, e As EventArgs) Handles rdoColori.CheckedChanged
        EseguiCalcolo()
    End Sub

    Private Sub chkFileDiversi_CheckedChanged(sender As Object, e As EventArgs) Handles chkFileDiversi.CheckedChanged
        EseguiCalcolo()
    End Sub
End Class



