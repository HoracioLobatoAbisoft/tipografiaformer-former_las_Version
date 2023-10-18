Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Fw = FormerDALWeb
Imports FormerLib


Public Class ucSitoWebRecensioniProdotti
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub CaricaRecensioni()

        Using mgr As New Fw.ReviewDAO

            Dim l As List(Of Fw.Review) = mgr.FindAll("Quando Desc",
                                                      New Fw.LUNA.LunaSearchParameter(Fw.LFM.Review.Stato, enStatoReview.DaApprovare))
            DgReview.AutoGenerateColumns = False
            DgReview.DataSource = l

        End Using

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        If MessageBox.Show("Confermi il caricamento delle recensioni inserite e non ancora approvate dal sito?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CaricaRecensioni()
        End If
    End Sub

    Private Sub lnkNonApprovare_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNonApprovare.LinkClicked
        If DgReview.SelectedRows.Count Then
            If MessageBox.Show("Confermi il RIFIUTO della recensione selezionata? La recensione non sarà conteggiata e non verrà emesso alcun coupon in favore dell'utente.", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Try
                    Using R As Fw.Review = DgReview.SelectedRows(0).DataBoundItem

                        R.Stato = enStatoReview.NonApprovata
                        R.Save()

                    End Using

                    CaricaRecensioni()
                Catch ex As Exception
                    ManageError(ex)
                End Try

            End If
        Else
            MessageBox.Show("Selezionare una Recensione dalla lista")
        End If

    End Sub

    Private Sub lnkApprova_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApprova.LinkClicked
        If DgReview.SelectedRows.Count Then

            Using R As Fw.Review = DgReview.SelectedRows(0).DataBoundItem
                Dim ris As Integer = 0
                ParentFormEx.Sottofondo()
                Using frm As New frmRecensione
                    ris = frm.Carica(R)
                End Using
                ParentFormEx.Sottofondo()
                If ris Then
                    CaricaRecensioni()
                End If

            End Using

        Else
            MessageBox.Show("Selezionare una Recensione dalla lista")
        End If

    End Sub
End Class
