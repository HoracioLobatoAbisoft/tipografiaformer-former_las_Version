Imports FormerDALSql
Friend Class frmListinoCli
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaNodi(0)
        CaricaFasce()
        tvwCat.ExpandAll()
        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaFasce()
        Using m As New FascePrezzoDAO()
            Dim l As List(Of FasciaPrezzo) = m.GetAll(LFM.FasciaPrezzo.Min)
            DgFasce.AutoGenerateColumns = False
            DgFasce.DataSource = l
        End Using
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

    Private Sub CaricaNodi(ByVal IdPadre As Integer)

        Using mgr As New CatProdDAO()
            Dim par1 As New LUNA.LunaSearchParameter(LFM.CatProd.IdCatPadre, IdPadre)
            Dim Lst As List(Of CatProd) = mgr.FindAll(LFM.CatProd.Descrizione, par1)
            For Each CategProd As CatProd In Lst
                If IdPadre Then
                    tvwCat.Nodes("C" & IdPadre).Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione & " (" & CategProd.PercPubblico & "%)", 0, 0)
                Else
                    tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione & " (" & CategProd.PercPubblico & "%)", 0, 0)
                End If
                'tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione)
                CaricaNodi(CategProd.IdCatProd)

            Next
        End Using

    End Sub

    Private Sub btnCaricaFasce_Click(sender As System.Object, e As System.EventArgs) Handles btnCaricaFasce.Click
        CaricaFasce()
    End Sub

    Private Sub lnkModifica_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModifica.LinkClicked

        ModificaCat()

    End Sub

    Private Sub lnkApplica_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApplica.LinkClicked

        If MessageBox.Show("Questa operazione sovrascriverà tutti i prezzi al pubblico, sicuro di voler continuare?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            ApplicaPrezzi()
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub ApplicaPrezzi()

        'applica i prezzi al pubblico in base ai prezzi inseriti in questa maschera

        Using mgr As New ProdottiDAO()

            Dim lst As List(Of Prodotto) = mgr.GetAll()

            For Each p As Prodotto In lst
                Dim c As CatProd
                Dim PrezzoBase As Decimal = p.Prezzo
                Using cat As New CatProdDAO()
                    c = cat.Read(p.IdCatProd)
                End Using
                Dim PercBase As Single = 0
                Using f As New FascePrezzoDAO()
                    f.PercentualePrezzo(p.Prezzo)
                End Using
                Dim PercEff As Single = PercBase

                If c.PercPubblico Then
                    PercEff = PercEff + (PercEff * (c.PercPubblico / 100))
                End If
                PrezzoBase = PrezzoBase + (PrezzoBase * (PercEff / 100))
                p.PrezzoPubbl = PrezzoBase
                mgr.Save(p)
            Next
        End Using
        MessageBox.Show("Operazione terminata, i prezzi sono stati aggiornati!", "")
        Close()

    End Sub

    Private Sub tvwCat_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwCat.NodeMouseDoubleClick
        ModificaCat()
    End Sub

    Private Sub ModificaCat()
        If Not tvwCat.SelectedNode Is Nothing Then
            Dim IdCat As Integer = tvwCat.SelectedNode.Name.Substring(1)
            Dim x As CatProd
            Using mgr As New CatProdDAO()
                x = mgr.Read(IdCat)
                Dim Res As String = InputBox("Inserire la percentuale di ricarico per la categoria selezionata (" & tvwCat.SelectedNode.Text & ")", "Percentuale di ricarico", x.PercPubblico)
                If Res.Length Then
                    If IsNumeric(Res) Then
                        x.PercPubblico = CInt(Res)
                        mgr.Save(x)
                        tvwCat.Nodes.Clear()
                        CaricaNodi(0)
                        tvwCat.ExpandAll()
                    End If
                End If
            End Using
        End If
    End Sub

End Class