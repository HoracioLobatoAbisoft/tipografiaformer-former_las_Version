Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucMagazzinoRisorseAcquisto
    Inherits ucFormerUserControl
    Private _IdFat As Integer
    Public Property IdFat() As Integer
        Get
            Return _IdFat
        End Get
        Set(ByVal value As Integer)
            _IdFat = value
        End Set
    End Property

    Private _IdForn As Integer
    Public Property IdForn() As Integer
        Get
            Return _IdForn
        End Get
        Set(ByVal value As Integer)
            _IdForn = value
        End Set
    End Property

    Public ReadOnly Property NumeroRighe As Integer
        Get
            Return DgLavori.Rows.Count
        End Get
    End Property

    Public Property ShowAddDelButton As Boolean
        Get
            Dim ris As Boolean = False
            If lnkAdd.Visible Then
                ris = True
            End If
        End Get
        Set(value As Boolean)
            lnkAdd.Visible = value
            lnkDel.Visible = value
        End Set
    End Property

    Public Function GetTotale() As Decimal

        Dim Totale As Decimal = 0
        For Each R As DataGridViewRow In DgLavori.Rows

            'Dim Voce As MovimentoMagazzino = R.DataBoundItem
            Totale += R.Cells(3).Value ' Voce.Prezzo
        Next

        Return Totale
    End Function

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        Titolo = "Dettaglio fattura acquisto"
        StampaGlobale(Titolo, DgLavori)
        ParentFormEx.Sottofondo()

    End Sub

    Public Event CambiatoQualcosa()

    Private Sub Mostradati()

        Using x As New cMagazColl

            Dim dt As DataTable

            dt = x.ListaRisFattura(_IdFat)

            DgLavori.DataSource = dt

            Dim TotEuro As Single = 0

            For Each dr As DataGridViewRow In DgLavori.Rows
                TotEuro += dr.Cells(3).Value
            Next

            lblRiassunto.Text = "(" & DgLavori.Rows.Count & " righe, € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & ")"

        End Using
    End Sub

    Public Sub Carica()
        Mostradati()
        RaiseEvent CambiatoQualcosa()
    End Sub

    Private Sub lnkAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked

        Dim Mag As New frmMagazzinoCarico, Ris As Integer = 0

        ParentFormEx.Sottofondo()
        'Mag.IDFat = _IdFat
        Mag.IDForn = _IdForn

        Ris = Mag.Carica(, , enTipoMovMagaz.Carico, _IdFat)

        If Ris Then
            Mostradati()
            RaiseEvent CambiatoQualcosa()
        End If
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DgLavori_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellContentDoubleClick

        Dim RigaSel As Integer = e.RowIndex

        If RigaSel <> -1 Then
            Dim IdVoce As Integer = CType(DgLavori.Rows(RigaSel).Cells(0).FormattedValue, Integer)
            Dim IdRis As Integer = CType(DgLavori.Rows(RigaSel).Cells(6).FormattedValue, Integer)

            'riapertura appuntamento
            ParentFormEx.Sottofondo()
            Dim x As New frmMagazzinoCarico
            Dim Ris As Integer = 0
            x.IdRis = IdRis
            'x.IDFat = _IdFat
            Ris = x.Carica(IdVoce, , enTipoMovMagaz.Carico, _IdFat)
            x = Nothing
            ParentFormEx.Sottofondo()

            If Ris Then RaiseEvent CambiatoQualcosa()

        End If
    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        If DgLavori.SelectedRows.Count Then
            Dim IdVoce As Integer = DgLavori.SelectedRows(0).Cells(0).FormattedValue

            If MessageBox.Show("Confermi la cancellazione della riga di dettaglio selezionata?", "Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgr As New MagazzinoDAO
                    mgr.Delete(IdVoce)
                    RaiseEvent CambiatoQualcosa()
                End Using
                Mostradati()
            End If

        Else
            MessageBox.Show("Selezionare una riga dalla lista")
        End If

    End Sub

    Private Sub DgLavori_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavori.CellContentClick

    End Sub
End Class

