Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneDashboard
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()
        Try
            UcAmministrazioneDashboardCount.CaricaDati()
            UcAmministrazioneCheckMassivoSnc.Carica()
            UcAmministrazioneContabilita.Carica()
        Catch ex As Exception

        End Try

    End Sub

End Class
