Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucListinoImpatto
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private Function CreaRisultato(L As List(Of ListinoBase)) As String

        Dim PathRis As String = String.Empty

        Dim Buffer As String = "<html><body><h2>Le modifiche impatteranno su:</h2><ul>"

        For Each singL As ListinoBase In L.FindAll(Function(x) x.IdListinoBaseSource = 0)

            If singL.Disattivo <> enSiNo.Si Then
                Buffer &= "<li>" & singL.NomeEx
            End If

        Next

        Buffer &= "</ul></body></html>"

        PathRis = FormerLib.FormerHelper.File.CreaFileHtml(Buffer)

        Return PathRis

    End Function

    Public Sub CalcolaSuFormatoMacchina(IdFormatoMacchina As Integer)

        Dim PathRis As String = String.Empty

        Dim L As List(Of ListinoBase)

        Using Mgr As New ListinoBaseDAO
            L = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdFormato, IdFormatoMacchina),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0))
        End Using

        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuFormatoProdotto(IdFormatoProdotto As Integer)

        Dim PathRis As String = String.Empty

        Dim L As List(Of ListinoBase)

        Using Mgr As New ListinoBaseDAO
            L = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdFormProd, IdFormatoProdotto),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0))
        End Using

        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuTipoCarta(IdTipoCarta As Integer)

        Dim PathRis As String = String.Empty

        Dim L As List(Of ListinoBase)

        Using Mgr As New ListinoBaseDAO
            L = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCarta, IdTipoCarta),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCartaCop, IdTipoCarta, , LUNA.enLogicOperator.enOR),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCartaDorso, IdTipoCarta, , LUNA.enLogicOperator.enOR))
            L = L.FindAll(Function(x) x.IdListinoBaseSource = 0)
        End Using

        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuCategoriaLavorazione(IdCategoriaLavorazione As Integer)

        Dim PathRis As String = String.Empty

        Dim L As New List(Of ListinoBase)

        Using mgr As New LavorazioniDAO
            Dim lLav As List(Of Lavorazione) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Lavorazione.IdCatLav, IdCategoriaLavorazione))

            For Each Lav In lLav
                Using mgrL As New LavorazSuPreventivazDAO
                    Dim LR As List(Of LavorazSuPreventivaz) = mgrL.FindAll(New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdLavoro, Lav.IdLavoro))
                    For Each singLav In LR

                        If L.FindAll(Function(X) X.IdListinoBase = singLav.IdListinoBase).Count = 0 Then
                            Dim SingL As New ListinoBase
                            SingL.Read(singLav.IdListinoBase)
                            L.Add(SingL)
                        End If
                    Next
                End Using
            Next
        End Using
        L = L.FindAll(Function(x) x.IdListinoBaseSource = 0)
        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuLavorazione(IdLavorazione As Integer)

        Dim PathRis As String = String.Empty

        Dim L As New List(Of ListinoBase)

        Using mgr As New LavorazSuPreventivazDAO
            Dim LR As List(Of LavorazSuPreventivaz) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdLavoro, IdLavorazione))
            For Each singLav In LR
                Dim SingL As New ListinoBase
                SingL.Read(singLav.IdListinoBase)
                L.Add(SingL)
            Next
        End Using
        L = L.FindAll(Function(x) x.IdListinoBaseSource = 0)
        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuColoreDiStampa(IdColoreStampa As Integer)

        Dim PathRis As String = String.Empty

        Dim L As List(Of ListinoBase)

        Using Mgr As New ListinoBaseDAO
            L = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdColoreStampa, IdColoreStampa),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0))
        End Using

        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

    Public Sub CalcolaSuModelloCubetto(IdModelloCubetto As Integer)

        Dim PathRis As String = String.Empty

        Dim L As List(Of ListinoBase)

        Using Mgr As New ListinoBaseDAO
            L = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdModelloCubetto, IdModelloCubetto),
                            New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0))
        End Using

        PathRis = CreaRisultato(L)

        UcAnteprima.Carica(PathRis)

    End Sub

End Class
