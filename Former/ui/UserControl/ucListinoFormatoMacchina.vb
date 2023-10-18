Imports FormerDALSql

Public Class ucListinoFormatoMacchina
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Private Sub ucFormatoMacchina_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub

    Public Sub Carica()
        Try
            CaricaFormatoMacchina()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub CaricaFormatoMacchina()

        Using mgr As New FormatiDAO
            Dim l As List(Of Formato) = mgr.GetAll(LFM.Formato.Formato)

            dgFormatoMacchina.AutoGenerateColumns = False
            dgFormatoMacchina.DataSource = l
        End Using



    End Sub


    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked
        ParentFormEx.Sottofondo()

        Dim ris As Integer = (New frmListinoFormatoMacchina).Carica()

        If ris Then CaricaFormatoMacchina()

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub ModificaVoce()
        If dgFormatoMacchina.SelectedRows.Count Then

            Dim v As Formato = dgFormatoMacchina.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdFormato
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoFormatoMacchina
            Ris = x.Carica(IdRif)
            If Ris Then CaricaFormatoMacchina()
            x = Nothing
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModFormato.LinkClicked
        ModificaVoce()
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked

    End Sub

    Private Sub dgFormatoMacchina_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFormatoMacchina.CellContentClick

    End Sub

    Private Sub dgFormatoMacchina_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFormatoMacchina.CellDoubleClick
        ModificaVoce()
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaFormatoMacchina()
    End Sub
End Class
