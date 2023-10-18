Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmCatProd
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _IdCatSel As Integer = 0
    Private _CatProd As CatProd = Nothing

    Private Sub CaricaCombo()

        'Dim lstCat As List(Of CatProd) = MgrCat.GetAllCombo(_IdCatSel)
        'cmbCatPadre.DisplayMember = "Descrizione"
        'cmbCatPadre.ValueMember = "IdCatProd"
        'cmbCatPadre.DataSource = lstCat

        Using MgrCarat As New CaratProdDAO()
            Dim LstCarat As List(Of CaratProd) = MgrCarat.GetAll(LFM.CaratProd.NomeCarat)

            For Each caratt As CaratProd In LstCarat

                Dim Selezionato As Boolean = False

                If _IdCatSel Then
                    Using MgrCaratCat As New CatCaratDAO()
                        Dim Par1 As New LUNA.LunaSearchParameter(LFM.CatCarat.IdCatProd, _IdCatSel)
                        Dim Par2 As New LUNA.LunaSearchParameter(LFM.CatCarat.IdCaratProd, caratt.IDCaratProd)
                        Dim NumTrov As Integer = MgrCaratCat.FindAll(Par1, Par2).Count

                        If NumTrov Then Selezionato = True
                    End Using
                End If

                chkCarat.Items.Add(caratt, Selezionato)

            Next
            chkCarat.CheckOnClick = True
        End Using
        Using Mgr As New TipoCommesseDAO
            Dim l As List(Of TipoCommessa) = Mgr.GetAll(LFM.TipoCommessa.Descrizione)

            For Each t As TipoCommessa In l
                Dim Selezionato As Boolean = False

                If _IdCatSel Then
                    Using MgrCaratCat As New CatProdTipoComDAO()
                        Dim Par1 As New LUNA.LunaSearchParameter(LFM.CatProdTipoCom.IdCatProd, _IdCatSel)
                        Dim Par2 As New LUNA.LunaSearchParameter(LFM.CatProdTipoCom.IdTipoCom, t.IdTipoCom)
                        Dim NumTrov As Integer = MgrCaratCat.FindAll(Par1, Par2).Count

                        If NumTrov Then Selezionato = True
                    End Using
                End If
                chkTipCommessa.Items.Add(t, Selezionato)
            Next
            chkTipCommessa.CheckOnClick = True
        End Using
    End Sub

    Friend Function Carica(Optional ByVal IdCatSel As Integer = 0) As Integer
        _IdCatSel = IdCatSel

        CaricaCombo()
        _CatProd = New CatProd
        If IdCatSel Then

            _CatProd.Read(IdCatSel)
            txtDescrizione.Text = _CatProd.Descrizione
            txtDescrEstesa.Text = _CatProd.DescrizioneLunga
            txtImg.Text = _CatProd.ImgCat
            If txtImg.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImg.Text)
                Catch ex As Exception

                End Try
            End If

            If _CatProd.IdCatPadre Then
                Dim CP As New CatProd
                CP.Read(_CatProd.IdCatPadre)
                lblCat.Text = CP.Descrizione
                lblCat.Tag = CP.IdCatProd
                CP = Nothing
            End If

        End If

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi l'operazione?", "Dettaglio categoria prodotto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'Dim CatMgr As New CatProdDAO()
            Dim Cat As New CatProd
            If _IdCatSel Then
                Cat.Read(_IdCatSel)
            End If

            Cat.Descrizione = txtDescrizione.Text
            Cat.DescrizioneLunga = txtDescrEstesa.Text
            Cat.ImgCat = txtImg.Text
            Cat.IdCatPadre = lblCat.Tag

            If txtImg.Text.Length Then
                If txtImg.Text <> _CatProd.ImgCat Then
                    Dim nuovoNome As String = String.Empty
                    If txtImg.Text.StartsWith(FormerPath.PathListinoImg) Then
                        'non devo copiare
                        nuovoNome = txtImg.Text
                    Else
                        'devo copiare 
                        Dim F As New FileInfo(txtImg.Text)
                        nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImg.Text))
                        MgrIO.FileCopia(Me, txtImg.Text, nuovoNome)
                    End If
                    Cat.ImgCat = nuovoNome
                End If

            End If

            _IdCatSel = Cat.Save()

            Using MgrCatCar As New CatCaratDAO()
                MgrCatCar.DeleteByIdCat(_IdCatSel)

                For Each car As CaratProd In chkCarat.CheckedItems

                    Dim x As New CatCarat
                    x.IdCaratProd = car.IDCaratProd
                    x.IdCatProd = _IdCatSel
                    MgrCatCar.Save(x)

                Next
            End Using
            Using m As New CatProdTipoComDAO
                m.DeleteByIdCat(_IdCatSel)
            End Using

            For Each car As TipoCommessa In chkTipCommessa.CheckedItems

                Dim x As New CatProdTipoCom
                x.IdTipoCom = car.IdTipoCom
                x.IdCatProd = _IdCatSel
                x.Save()
            Next
            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub chkCarat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCarat.SelectedIndexChanged
        Try
            'pctAnteprima.Image = Image.FromFile(FormerPath.PathLocale & "listino\" & chkCarat.Items(chkCarat.SelectedIndex).imgcarat)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSelCat_Click(sender As Object, e As EventArgs) Handles btnSelCat.Click
        Sottofondo()

        Dim f As New frmSelectCat

        Dim Ris As Integer = f.SelezionaCategoria(lblCat.Tag)
        If Ris Then
            Dim C As New CatProd
            C.Read(Ris)
            lblCat.Text = C.Descrizione
            lblCat.Tag = Ris
            C = Nothing
        End If
        f = Nothing

        Sottofondo()
    End Sub

    Private Sub btnSelectImg_Click(sender As Object, e As EventArgs) Handles btnSelectImg.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImg.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImg.Text)
        End If
    End Sub
End Class