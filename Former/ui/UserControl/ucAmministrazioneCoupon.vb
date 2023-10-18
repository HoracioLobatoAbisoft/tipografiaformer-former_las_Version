Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucAmministrazioneCoupon
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

        Dim LunaP As LUNA.LunaSearchParameter = Nothing

        If _IdRub Then

            LunaP = New LUNA.LunaSearchParameter(LFM.Coupon.Riservato, _IdRub)

        End If

        Using mgr As New CouponDAO
            Dim l As List(Of Coupon) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataInizioValidita desc"},
                                                   LunaP)

            DgCoupon.AutoGenerateColumns = False
            DgCoupon.DataSource = l

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

        Using F As New frmListinoCoupon

            Ris = F.Carica(, _IdRub)

        End Using

        ParentFormEx.Sottofondo()

        If Ris Then Carica()

    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        Carica()
    End Sub

    Private Sub DgCoupon_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgCoupon.CellDoubleClick
        Dim riga As DataGridViewRow = DgCoupon.SelectedRows(0)

        If riga Is Nothing Then
            Beep()
        Else
            Dim C As Coupon = riga.DataBoundItem
            ParentFormEx.Sottofondo()

            Dim f As New frmListinoCoupon
            Dim Ris As Integer = f.Carica(C.IdCoupon)
            f = Nothing
            If Ris Then Carica()

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub DgCoupon_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgCoupon.ColumnHeaderMouseClick
        OrdinatoreLista(Of Coupon).OrdinaLista(sender, e)
    End Sub

    Private Sub lnkRigenera_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRigenera.LinkClicked
        If DgCoupon.SelectedRows.Count Then
            Dim riga As DataGridViewRow = DgCoupon.SelectedRows(0)
            If riga Is Nothing Then
                Beep()
            Else
                If MessageBox.Show("Confermi la rigenerazione del Coupon Selezionato? Il coupon sarà creato ma non pubblicato automaticamente", "Rigenera Coupon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim C As Coupon = riga.DataBoundItem
                    Dim Codice As String = String.Empty
                    Dim Pref As String = String.Empty
                    If C.IdListinoBase Then
                        Dim L As New ListinoBase
                        L.Read(C.IdListinoBase)
                        Pref = L.Preventivazione.Prefisso
                    End If

                    Using mgr As New CouponDAO
                        Codice = mgr.GetCodiceCoupon(Pref, C.Riservato)
                    End Using

                    Using Cn As New Coupon
                        Cn.Codice = Codice
                        Cn.RiservatoATipoUtente = C.RiservatoATipoUtente
                        Cn.Nome = C.Nome & " Regen" & Now.ToString("ddMMyyyy")
                        Cn.QtaSpecifica = C.QtaSpecifica
                        Cn.DataInizioValidita = Now
                        Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, C.DataInizioValidita, C.DataFineValidita)
                        Cn.DataFineValidita = Now.AddDays(DiffGiorni)
                        Cn.Percentuale = C.Percentuale
                        Cn.ImportoFisso = C.ImportoFisso
                        Cn.MaxVolte = C.MaxVolte
                        Cn.IdListinoBase = C.IdListinoBase
                        Cn.Riservato = C.Riservato

                        Cn.Save()
                    End Using

                    Carica()

                End If
            End If
        End If

    End Sub
End Class
