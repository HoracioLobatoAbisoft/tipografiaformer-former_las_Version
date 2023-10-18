Imports FormerDALSql
Friend Class frmSelectCat
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()
        Using CatProd As New CatProdDAO
            cmbCatProd.ValueMember = "IdCatProd"
            cmbCatProd.DisplayMember = "Descrizione"

            cmbCatProd.DataSource = CatProd.FindAll(LFM.CatProd.Descrizione,
                                                    New LUNA.LunaSearchParameter(LFM.CatProd.IdCatPadre, 0))
        End Using
    End Sub

    Private Sub CaricaNodi(ByVal IdPadre As Integer)

        Using mgr As New CatProdDAO()
            Dim par1 As New LUNA.LunaSearchParameter(LFM.CatProd.IdCatPadre, IdPadre)
            Dim Lst As List(Of CatProd) = mgr.FindAll(LFM.CatProd.Descrizione, par1)

            For Each CategProd As CatProd In Lst
                If IdPadre Then
                    If tvwCat.Nodes.Find("C" & IdPadre, True).Count = 0 Then
                        tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                    Else
                        tvwCat.Nodes.Find("C" & IdPadre, True)(0).Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                    End If

                Else
                    tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione, 0, 0)
                End If
                'tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione)
                CaricaNodi(CategProd.IdCatProd)


            Next
        End Using
    End Sub

    Private Function TrovaIdCatPadre(IdCat As Integer) As Integer
        Dim Ris As Integer = 0
        Dim C As New CatProd
        C.Read(IdCat)

        If C.IdCatPadre Then
            Ris = TrovaIdCatPadre(C.IdCatPadre)
        Else
            Ris = C.IdCatProd
        End If

        Return Ris

    End Function

    Friend Function SelezionaCategoria(Optional IdCat As Integer = 0) As Integer

        CaricaCombo()

        'se mi passi l'idcat riseleziono la cat dall'alberoscorrendo fino alla cat padre
        Dim IdCatPrincipale As Integer = 0

        IdCatPrincipale = TrovaIdCatPadre(IdCat)

        If IdCatPrincipale Then

            MgrControl.SelectIndexCombo(cmbCatProd, IdCatPrincipale)

            If tvwCat.Nodes.Find("C" & IdCat, True).Count Then
                tvwCat.SelectedNode = tvwCat.Nodes.Find("C" & IdCat, True)(0)
                tvwCat.Select()
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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If MessageBox.Show("Confermi la categoria del prodotto selezionata?", "Selezione categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim N As TreeNode = tvwCat.SelectedNode
            If Not N Is Nothing Then

                'qui mi prendo l'id della cat selezionata
                Dim IdCatSel As Integer = N.Name.Substring(1)
                _Ris = IdCatSel
            Else
                _Ris = cmbCatProd.SelectedValue
            End If

            Close()
        End If

    End Sub

    Private Sub cmbCatProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCatProd.SelectedIndexChanged

        '  If sender.focused Then
        tvwCat.Nodes.Clear()
        CaricaNodi(cmbCatProd.SelectedValue)
        tvwCat.ExpandAll()
        ' End If

    End Sub
End Class