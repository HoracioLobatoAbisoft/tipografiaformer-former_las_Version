Imports FormerDALSql
Imports FormerDALSql.LUNA
Imports FormerLib.FormerEnum

Public Class ucProduzioneDigitale


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Function CommesseInCoda() As Integer
        Dim ris As Integer = 0

        Using mgr As New CommesseDAO

            Dim l As List(Of Commessa) = mgr.FindAll(New LunaSearchParameter(LFM.Commessa.IdReparto, enRepartoWeb.StampaDigitale),
                                                     New LunaSearchParameter(LFM.Commessa.Stato, "(" & enStatoCommessa.Preinserito & "," & enStatoCommessa.Pronto & ")", "IN"))
            ris = l.Count
        End Using

        Return ris
    End Function

    Public Function Carica() As Integer

        Dim ris As Integer = 0

        ris = UcCommesse.Carica()

        Return ris

    End Function

    Public Event CommessaSelezionata(sender As Object)

    Public IdComSel As Integer = 0

    Private Sub UcCommesse_CommessaSelezionata() Handles UcCommesse.CommessaSelezionata

        IdComSel = UcCommesse.IdComSel

        RaiseEvent CommessaSelezionata(Me)

    End Sub

End Class
