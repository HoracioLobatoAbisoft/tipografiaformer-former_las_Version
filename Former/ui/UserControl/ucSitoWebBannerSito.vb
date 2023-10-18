Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogic
Imports FW = FormerDALWeb

Public Class ucSitoWebBannerSito
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub CaricaBanner(Optional IdBannerDaSelezionare As Integer = 0)
        Dim L As List(Of BannerSito) = Nothing
        Using mgr As New BannerSitoDAO

            L = mgr.GetAll("Ordine")

        End Using
        DgBanner.AutoGenerateColumns = False
        DgBanner.DataSource = L

        If IdBannerDaSelezionare Then
            For Each singRow As DataGridViewRow In DgBanner.Rows
                Dim b As BannerSito = singRow.DataBoundItem
                If b.IdBannerSito = IdBannerDaSelezionare Then
                    singRow.Selected = True
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CaricaBanner()

    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        SpostaBanner(enDirezione.Sopra)
    End Sub

    Private Sub SpostaBanner(Direzione As enDirezione)

        If DgBanner.SelectedRows.Count Then
            Cursor = Cursors.WaitCursor
            Dim Posizione As Integer = DgBanner.SelectedRows(0).Index
            Dim bannerScelto As BannerSito = DgBanner.SelectedRows(0).DataBoundItem
            Dim IdBannerScelto As Integer = bannerScelto.IdBannerSito
            Dim bannerDaSpostare As BannerSito = Nothing
            If Direzione = enDirezione.Sopra Then
                'su
                If Posizione <> 0 Then
                    'lo sposto prima
                    bannerDaSpostare = DgBanner.Rows(Posizione - 1).DataBoundItem
                    bannerScelto.Ordine -= 1
                    bannerScelto.Save()
                    bannerDaSpostare.Ordine += 1
                    bannerDaSpostare.Save()
                End If
            Else
                'giu
                If Posizione <> DgBanner.RowCount - 1 Then
                    'lo sposto dopo
                    bannerDaSpostare = DgBanner.Rows(Posizione + 1).DataBoundItem
                    bannerScelto.Ordine += 1
                    bannerScelto.Save()
                    bannerDaSpostare.Ordine -= 1
                    bannerDaSpostare.Save()
                End If
            End If
            CaricaBanner(IdBannerScelto)
            Cursor = Cursors.Default
        End If

    End Sub



    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        NuovoBanner()
    End Sub

    Private Sub NuovoBanner()

        ParentFormEx.Sottofondo()
        Dim Ris As Integer = 0
        Using f As New frmListinoBanner
            Ris = f.Carica
        End Using
        If Ris Then CaricaBanner()
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub RiapriBanner()

        If DgBanner.SelectedRows.Count Then

            Dim b As BannerSito = DirectCast(DgBanner.SelectedRows(0).DataBoundItem, BannerSito)
            ParentFormEx.Sottofondo()
            Dim f As New frmListinoBanner
            Dim Ris As Integer = f.Carica(b)
            f = Nothing
            If Ris Then CaricaBanner()
            ParentFormEx.Sottofondo()
        End If

    End Sub

    Private Sub PubblicaBanner()

        If MessageBox.Show("Confermi la pubblicazione dei banner del sito online ora?", "Banner Sito Web", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            lnkPubblica.Enabled = False

            Dim buffer As String = String.Empty

            Dim l As List(Of BannerSito) = Nothing
            Using mgr As New BannerSitoDAO
                l = mgr.FindAll(LFM.BannerSito.Ordine,
                                New LUNA.LunaSearchParameter(LFM.BannerSito.Stato, enStato.Attivo))
            End Using

            If l.Count > 1 Then '> 2 And l.Count < 7 Then

                Dim ServerInUso As ServerSito = ServerProduzione
                Dim Ftp As New FTPclient(ServerInUso.FTPHost, ServerInUso.FTPLogin, ServerInUso.FTPPwd)

                Using mgrB As New FW.BannerDAO
                    Dim lBannerAttivi As List(Of FW.Banner) = mgrB.GetAll
                    Dim IdToDelete As New List(Of Integer)
                    For Each b In lBannerAttivi
                        If l.FindAll(Function(x) x.imgRif.EndsWith(b.Path)).Count = 0 Then
                            IdToDelete.Add(b.IdBanner)
                        End If
                    Next

                    For Each singId In IdToDelete
                        mgrB.Delete(singId)
                    Next

                    For Each b As BannerSito In l
                        Dim BN As FW.Banner = Nothing
                        BN = lBannerAttivi.Find(Function(x) x.Path = FormerLib.FormerHelper.File.EstraiNomeFile(b.imgRif))
                        If BN Is Nothing Then
                            'qui il banner non ci sta quindi va inserito
                            'qui pubblico i file
                            Dim PathRemotoFile As String = "tipografiaformer.it/banner/" & FormerLib.FormerHelper.File.EstraiNomeFile(b.imgRif)
                            Dim PathLocaleFile As String = b.imgRif

                            Try
                                If Ftp.FtpFileExists(PathRemotoFile) = False Then
                                    MgrIO.FtpTransfer(Me.ParentForm, Ftp, PathLocaleFile, PathRemotoFile, enTipoOpFTP.Upload)
                                End If
                            Catch ex As Exception

                            End Try

                            BN = New FW.Banner
                            BN.Alt = b.Alternate
                            BN.Attivo = enSiNo.Si
                            BN.Path = FormerLib.FormerHelper.File.EstraiNomeFile(b.imgRif)
                            BN.Url = b.Url

                        Else
                            'qui il banner va aggiornato
                            BN.Alt = b.Alternate
                            BN.Attivo = enSiNo.Si
                            BN.Path = FormerLib.FormerHelper.File.EstraiNomeFile(b.imgRif)
                            BN.Url = b.Url

                        End If

                        BN.Save()

                        BN.Dispose()
                    Next

                End Using

                MessageBox.Show("Pubblicazione Banner Online Terminata", "Pubblicazione Banner")

            Else
                MessageBox.Show("Impossibile pubblicare i banner online! Deve esserci almeno un banner attivo")
            End If

            lnkPubblica.Enabled = True

        End If

    End Sub

    Private Sub lnkPubblica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPubblica.LinkClicked
        PubblicaBanner()
    End Sub

    Private Sub DgBanner_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgBanner.CellContentClick

    End Sub

    Private Sub DgBanner_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgBanner.CellDoubleClick

        RiapriBanner()

    End Sub

    Private Sub DgBanner_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgBanner.RowPostPaint

        Dim R As DataGridViewRow = DgBanner.Rows(e.RowIndex)
        Dim b As BannerSito = R.DataBoundItem

        If b.Stato = enStato.Attivo Then
            R.Cells(3).Style.BackColor = Color.Green
            R.Cells(3).Style.SelectionBackColor = Color.Green
        Else
            R.Cells(3).Style.BackColor = Color.Red
            R.Cells(3).Style.SelectionBackColor = Color.Red
        End If

    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        SpostaBanner(enDirezione.Sotto)
    End Sub

    Private Sub lnkModifica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModifica.LinkClicked
        RiapriBanner()
    End Sub
End Class
