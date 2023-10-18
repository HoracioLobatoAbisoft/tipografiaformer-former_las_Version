Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucContabCostoAmmortamento
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private _IdCosto As Integer = 0

    Public Sub Carica(IdCosto As Integer)
        _IdCosto = IdCosto

        CaricaDatiAmmortamento()

    End Sub

    Private Sub lnkSalva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSalva.LinkClicked

        Using c As New Costo
            c.Read(_IdCosto)
            If c.Ammortamento Is Nothing Then

                If txtPerc.Text > 0 AndAlso txtAnni.Text > 1 Then
                    If MessageBox.Show("Confermi la creazione del piano di ammortamento?",, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Dim AnnoStart As Integer = c.DataCosto.Year

                        Using a As New AmmortamentoCosto
                            a.IdCosto = _IdCosto
                            a.Anni = txtAnni.Text
                            a.AnnoStart = AnnoStart
                            a.AnnoEnd = AnnoStart + a.Anni - 1
                            a.PercTotale = txtPerc.Text
                            Dim ImportoTotale As Decimal = c.Importo * a.PercTotale / 100
                            a.ImportoTotale = ImportoTotale
                            a.ImportoAnnuo = ImportoTotale / a.Anni
                            a.IdAzienda = c.IdAzienda
                            a.Save()

                        End Using

                        CaricaDatiAmmortamento()

                    End If
                Else
                    MessageBox.Show("Dati inseriti non validi")
                End If


            Else
                MessageBox.Show("Esiste già un piano di ammortamento per questo costo")
            End If
        End Using



    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        Using c As New Costo
            c.Read(_IdCosto)
            If Not c.Ammortamento Is Nothing Then
                If MessageBox.Show("Confermi l'eliminazione del piano di ammortamento corrente?",, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using mgr As New AmmortamentoCostiDAO
                        mgr.Delete(c.Ammortamento.IdAmmCosto)
                        CaricaDatiAmmortamento()
                    End Using
                End If
            Else
                MessageBox.Show("Non esiste un piano di ammortamento da eliminare per questo costo")
            End If
        End Using

    End Sub

    Private Sub CaricaDatiAmmortamento()

        Using c As New Costo
            c.Read(_IdCosto)
            If Not c.Ammortamento Is Nothing Then
                'carico il piano di ammortamento attivo
                txtPianoAmmortamentoAttivo.Text = c.Ammortamento.Riassunto
                txtAnni.Text = c.Ammortamento.Anni
                txtPerc.Text = c.Ammortamento.PercTotale

            Else
                txtPianoAmmortamentoAttivo.Text = "Non è presente al momento un piano di ammortamento per questo COSTO"
                txtAnni.Text = 5
                txtPerc.Text = 100
            End If
        End Using

    End Sub

End Class
