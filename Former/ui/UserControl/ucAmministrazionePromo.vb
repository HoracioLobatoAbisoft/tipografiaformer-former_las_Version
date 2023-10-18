Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucAmministrazionePromo
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        CaricaCombo()

    End Sub

    Private Sub CaricaCombo()
        cmbMeseRif.ValueMember = "Id"
        cmbMeseRif.DisplayMember = "Descrizione"
        For i As Integer = Now.Year To 2017 Step -1

            Dim Start As Integer = 12

            If i = Now.Year Then Start = Now.Month

            For j As Integer = Start To 1 Step -1

                Dim Val As New cEnum
                Val.Id = i.ToString & j.ToString("00")
                Val.Descrizione = i & " " & FormerHelper.Calendario.MeseToString(j)
                cmbMeseRif.Items.Add(Val)

            Next

        Next
        cmbMeseRif.SelectedIndex = 0

    End Sub

    Public Sub Carica()

        Using mgr As New PromoDAO
            Dim l As List(Of Promo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataFineValidita desc"},
                                                  New LUNA.LunaSearchParameter(LFM.Promo.Stato, enStato.Attivo),
                                                  New LUNA.LunaSearchParameter(LFM.Promo.Automatico, enSiNo.Si, "<>"))

            DgPromo.AutoGenerateColumns = False
            DgPromo.DataSource = l

            lblCountPromo.Text = l.FindAll(Function(x) DateDiff(DateInterval.Minute, Now, x.DataFineValidita) >= 0).Count

        End Using

    End Sub

    Private _IdRub As Integer = 0
    Public Property IdRub As Integer
        Get
            Return _IdRub
        End Get
        Set(value As Integer)
            _IdRub = value
        End Set
    End Property


    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ParentFormEx.Sottofondo()

        Dim Ris As Integer = 0

        Using F As New frmListinoPromo

            Ris = F.Carica()

        End Using

        ParentFormEx.Sottofondo()

        If Ris Then Carica()

    End Sub
    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        Carica()
    End Sub

    Private Sub DgCoupon_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPromo.CellDoubleClick

        RiapriPromo

    End Sub

    Private Sub RiapriPromo()

        Dim riga As DataGridViewRow = DgPromo.SelectedRows(0)

        If riga Is Nothing Then
            Beep()
        Else
            Dim C As Promo = riga.DataBoundItem
            ParentFormEx.Sottofondo()

            Dim f As New frmListinoPromo
            Dim Ris As Integer = f.Carica(C.IdPromo)
            f = Nothing
            If Ris Then Carica()

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub TrasformaPromo()

        Dim riga As DataGridViewRow = DgPromo.SelectedRows(0)

        If riga Is Nothing Then
            Beep()
        Else
            Dim C As Promo = riga.DataBoundItem

            ParentFormEx.Sottofondo()
            Dim Ris As Integer = 0
            Using f As New frmListinoPromoAutomatico
                Ris = f.Carica(C.IdListinoBase, C.Percentuale, True)
            End Using

            If Ris Then
                'elimino il promo normale
                If C.IdPromoOnline Then
                    'qui devo disattivare anche quello online
                    Using pO As New FormerDALWeb.PromoW
                        pO.Read(C.IdPromoOnline)
                        If pO.Stato <> enStato.NonAttivo Then
                            pO.Stato = enStato.NonAttivo
                            pO.Save()
                        End If
                    End Using
                End If
                C.Stato = enStato.NonAttivo
                C.Save()
                Carica()
            End If

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub DgCoupon_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgPromo.ColumnHeaderMouseClick
        OrdinatoreLista(Of Coupon).OrdinaLista(sender, e)
    End Sub

    Private Sub DgPromo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPromo.CellContentClick

    End Sub

    Private Sub lnkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEdit.LinkClicked
        RiapriPromo()
    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        If MessageBox.Show("Eliminando il promo sarà eliminato anche online. Continuare?", "Elimina Promo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim riga As DataGridViewRow = DgPromo.SelectedRows(0)
            Dim P As Promo = riga.DataBoundItem
            Try
                If P.IdPromoOnline Then
                    'qui devo disattivare anche quello online
                    Using pO As New FormerDALWeb.PromoW
                        pO.Read(P.IdPromoOnline)
                        pO.Stato = enStato.NonAttivo
                        pO.Save()
                    End Using
                End If
                P.Stato = enStato.NonAttivo
                P.Save()

                Carica()

            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nell'eliminazione del Promo. Riprovare")
            End Try

        End If

    End Sub

    Private Sub lnkDeleteAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDeleteAll.LinkClicked

        If MessageBox.Show("Vuoi eliminare tutti i promo scaduti?", "Eliminazione Promo scaduti", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            Using mgr As New PromoDAO
                Dim l As List(Of Promo) = mgr.GetAll

                For Each p As Promo In l

                    If p.Scaduto Then
                        Try
                            If p.IdPromoOnline Then
                                'qui devo disattivare anche quello online
                                Using pO As New FormerDALWeb.PromoW
                                    pO.Read(p.IdPromoOnline)
                                    pO.Stato = enStato.NonAttivo
                                    pO.Save()
                                End Using
                            End If
                            p.Stato = enStato.NonAttivo
                            p.Save()
                        Catch ex As Exception
                            MessageBox.Show("Si è verificato un errore nella cancellazione del promo su " & p.ListinoBaseStr)
                        End Try

                    End If
                Next
                Carica()
            End Using

        End If

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaDati()
    End Sub

    Private Sub CaricaDati()
        Dim Mese As Integer = 0
        Dim Anno As Integer = 0

        Dim EnumSel As cEnum = cmbMeseRif.SelectedItem

        Dim VoceSelezionata As String = EnumSel.Id

        Anno = VoceSelezionata.Substring(0, 4)
        Mese = VoceSelezionata.Substring(4, 2)

        Using Mgr As New ListinoBaseDAO

            Dim LRis As New List(Of RisPromoSuLB)

            Dim l As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.PercPromoAutomatico, 0, "<>"))

            For Each singl In l

                Dim Val As New RisPromoSuLB(singl)

                Val.FatturatoMensileTotale = Mgr.GetFatturatoNelMese(Val.IdListinoBase, Mese, Anno)
                Val.FatturatoMensileConPromo = Mgr.GetFatturatoNelMese(Val.IdListinoBase, Mese, Anno, True)
                'MessageBox.Show(lbP.PercentualeSuFatturato)

                LRis.Add(Val)
            Next
            dgPromoAuto.AutoGenerateColumns = False
            dgPromoAuto.DataSource = LRis

        End Using

    End Sub

    Private Sub lnkNewPromoAuto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNewPromoAuto.LinkClicked

        ParentFormEx.Sottofondo()
        Using f As New frmListinoPromoAutomatico
            Dim Ris As Integer = f.Carica()

            If Ris Then
                CaricaDati()
            End If
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub dgPromoAuto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPromoAuto.CellContentClick

    End Sub

    Private Sub dgPromoAuto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPromoAuto.CellDoubleClick

        If dgPromoAuto.SelectedRows.Count Then

            Dim SelItem As RisPromoSuLB = dgPromoAuto.SelectedRows(0).DataBoundItem
            Dim SelVal As Integer = SelItem.IdListinoBase

            ParentFormEx.Sottofondo()
            Using f As New frmListinoPromoAutomatico
                Dim Ris As Integer = f.Carica(SelVal)

                If Ris Then
                    CaricaDati()
                End If
            End Using
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub lnkTrasforma_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTrasforma.LinkClicked
        TrasformaPromo()
    End Sub
End Class
