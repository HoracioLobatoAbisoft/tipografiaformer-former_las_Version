Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucMail
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        'If FormerDebug.DebugAttivo = False Then tabMail.TabPages.Remove(tpPreventiviNew)

    End Sub

    Public Sub Carica()

    End Sub

    Public Event CambiamentoStatoMail(Conteggio As Integer)

    Public Function CounterDaLavorare() As Integer
        Dim ris As Integer = 0

        Using mgr As New PreventiviMailDAO

            ris = mgr.CounterDaLavorare()

        End Using

        'ris += UcMailPreventivi.CounterDaLavorare

        'ris += UcMailOrdini.CounterDaLavorare

        Return ris
    End Function

    Private Sub UcMailPreventivi_CambiamentoStatoMail(Conteggio As Integer) Handles UcMailPreventivi.CambiamentoStatoMail,
                                                                                    UcMailOrdini.CambiamentoStatoMail
        RaiseEvent CambiamentoStatoMail(-1)

    End Sub
End Class
