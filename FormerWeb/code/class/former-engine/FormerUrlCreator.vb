Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class FormerUrlCreator

    Public Shared Function GetUrl(P As PreventivazioneW,
                                  Optional IdFormatoProdotto As Integer = 0,
                                  Optional IdTipoCarta As Integer = 0,
                                  Optional IdColoreStampa As Integer = 0) As String

        Dim ris As String = String.Empty

        ris = "/" & P.IdPrev & "/" & P.NomeInUrl

        Dim lst As List(Of ListinoBaseW) = Nothing

        Using L As New ListinoBaseWDAO

            If FormerWebApp.UseStaticCollection = enSiNo.Si Then
                lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdPrev = P.IdPrev)
            Else
                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, P.IdPrev),
                                New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"))
            End If

            If IdFormatoProdotto = 0 And P.SaltaFP = enSiNo.Si Then
                'qui vado a prendere il formato prodtto della formerchoice se c'e' 
                If Not P.FormerChoice Is Nothing Then
                    IdFormatoProdotto = P.FormerChoice.IdFormProd
                End If
            End If

            If IdFormatoProdotto Then
                If IdTipoCarta = 0 And P.SaltaTC = enSiNo.Si Then
                    If Not P.FormerChoice Is Nothing Then
                        IdTipoCarta = P.FormerChoice.IdTipoCarta
                    End If
                End If
            End If

            If IdTipoCarta Then
                If IdColoreStampa = 0 And P.SaltaCS = enSiNo.Si Then
                    If Not P.FormerChoice Is Nothing Then
                        IdColoreStampa = P.FormerChoice.IdColoreStampa
                    End If
                End If
            End If

            If (IdFormatoProdotto = 0 Or lst.FindAll(Function(x) x.IdFormProd = IdFormatoProdotto).Count = 0) And P.SaltaFP = enSiNo.Si Then

                Using mgr As New PreventivazioniWDAO
                    mgr.OrdinaListinoPerFormatoProd(lst)
                End Using

                IdFormatoProdotto = lst(0).IdFormProd
            End If

            If IdFormatoProdotto Then
                'qui devo andare a filtrare con questo formato prodotto
                lst = lst.FindAll(Function(x) x.IdFormProd = IdFormatoProdotto)
            End If

            If (IdTipoCarta = 0 Or lst.FindAll(Function(x) x.IdTipoCarta = IdTipoCarta).Count = 0) And P.SaltaTC = enSiNo.Si Then
                Using mgr As New PreventivazioniWDAO
                    mgr.OrdinaListinoPerGrammaturaCarta(lst)
                End Using
                IdTipoCarta = lst(0).IdTipoCarta
            End If

            If IdTipoCarta Then
                'qui devo andare a filtrare con questo formato prodotto
                lst = lst.FindAll(Function(x) x.IdTipoCarta = IdTipoCarta)
            End If

            If (IdColoreStampa = 0 Or lst.FindAll(Function(x) x.IdColoreStampa = IdColoreStampa).Count = 0) And P.SaltaCS = enSiNo.Si Then
                Using mgr As New PreventivazioniWDAO
                    mgr.OrdinaListinoPerColoreDiStampa(lst)
                End Using

                IdColoreStampa = lst(0).IdColoreStampa
                lst = lst.FindAll(Function(x) x.IdColoreStampa = IdColoreStampa)
            End If

            If IdColoreStampa Then
                'qui devo andare a filtrare con questo formato prodotto
                lst = lst.FindAll(Function(x) x.IdColoreStampa = IdColoreStampa)
            End If

            For Each singl As ListinoBaseW In P.GetListiniBaseLinkati
                Dim Aggiungi As Boolean = True
                If IdFormatoProdotto <> 0 AndAlso singl.IdFormProd <> IdFormatoProdotto Then
                    Aggiungi = False
                End If

                If IdTipoCarta <> 0 AndAlso singl.IdTipoCarta <> IdTipoCarta Then
                    Aggiungi = False
                End If

                If IdColoreStampa <> 0 AndAlso singl.IdColoreStampa <> IdColoreStampa Then
                    Aggiungi = False
                End If

                If Aggiungi Then
                    singl.Linkato = True
                    lst.Add(singl)
                End If
            Next

            'Using Pl As New PrevLinkListinoDAO
            '    Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter("IdPreventivazione", P.IdPrev))
            '    For Each SingPl As PrevLinkListino In lstPL
            '        Dim singL As New ListinoBaseW
            '        singL.Read(SingPl.IdListinoBase)
            '        If singL.NascondiOnline <> enSiNo.Si Then
            '            Dim Aggiungi As Boolean = True
            '            If IdFormatoProdotto <> 0 AndAlso singL.IdFormProd <> IdFormatoProdotto Then
            '                Aggiungi = False
            '            End If

            '            If IdTipoCarta <> 0 AndAlso singL.IdTipoCarta <> IdTipoCarta Then
            '                Aggiungi = False
            '            End If

            '            If IdColoreStampa <> 0 AndAlso singL.IdColoreStampa <> IdColoreStampa Then
            '                Aggiungi = False
            '            End If

            '            If Aggiungi Then
            '                singL.Linkato = True
            '                lst.Add(singL)
            '            End If
            '        End If
            '    Next
            'End Using

            'qui in lst ho tutti i listini base correlati a questa preventivazione
            If lst.Count = 1 Then
                'qui ho un solo listinobase
                Dim fp As FormerPlugin = Nothing

                'MODIFICA PER FARE SALTARE IL WIZARD DEL PLUGIN DEL PACKAGING
                If P.IdPluginToUse AndAlso P.IdPluginToUse <> enPluginOnline.Packaging Then
                    fp = MgrPlugin.GetPlugin(P)
                End If

                If fp Is Nothing OrElse Not MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                    'qui posso saltare direttamente al prodotto
                    Dim lb As ListinoBaseW = lst(0)
                    'Dim NFogli As Integer = lb.faccmin / 2

                    'If lb.faccmin <> lb.faccmax AndAlso lb.DefaultNFogli <> 0 Then
                    '    NFogli = lb.DefaultNFogli
                    'End If
                    'ris = "/" & P.IdPrev & "/" & lb.IdFormProd & "/" & lb.IdTipoCarta & "/" & lb.IdColoreStampa & "/" & NFogli & "/" & lb.NomeInUrl
                    ris = GetUrlLb(lb)
                Else
                    If Not fp Is Nothing AndAlso MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                        'qui vado diretto al plugin
                        ris = "/" & fp.Route.Url.Replace("{idp}", P.IdPrev)
                    End If
                End If
            Else
                'qui devo vedere se posso saltare il formato prodotto 
                Dim lstFP As New List(Of FormatoProdottoW)
                For Each Lb As ListinoBaseW In lst
                    If lstFP.FindAll(Function(x) x.IdFormProd = Lb.IdFormProd).Count = 0 Then
                        lstFP.Add(Lb.FormatoProdotto)
                    End If
                Next

                If lstFP.Count = 1 Then
                    'qui posso saltare oltre se non serve il plugin

                    Dim fp As FormerPlugin = Nothing
                    If P.IdPluginToUse <> 0 Then

                        fp = MgrPlugin.GetPlugin(P, enStepWizard.FormatoProdotto)
                        If Not fp Is Nothing AndAlso MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                            'qui vado diretto al plugin
                            ris = "/" & fp.Route.Url.Replace("{idp}", P.IdPrev)
                        End If

                    End If

                    If fp Is Nothing OrElse Not MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                        Dim FpSel As FormatoProdottoW = lstFP(0)
                        'qui vado a controllare il tipo carta
                        Dim fpNomeUrl As String = FpSel.NomeInUrl

                        If Not fp Is Nothing Then
                            Dim R As RisultatoPlugin = MgrPlugin.GetRisPlugin(fp) ' Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging)) fp.nomeinurl
                            fpNomeUrl = R.NomeInUrl
                        End If

                        If fpNomeUrl = "100x100" Then
                            fpNomeUrl = "a-misura"
                        End If

                        ris = "/" & P.IdPrev & "/" & FpSel.IdFormProd & "/" & P.NomeInUrl & "-" & fpNomeUrl

                        Dim lstTC As New List(Of TipoCartaW)
                        For Each lb As ListinoBaseW In lst
                            If lstTC.FindAll(Function(x) x.IdTipoCarta = lb.IdTipoCarta).Count = 0 Then
                                lstTC.Add(lb.TipoCarta)
                            End If
                        Next

                        If lstTC.Count = 1 Then
                            If P.IdPluginToUse <> 0 Then

                                fp = MgrPlugin.GetPlugin(P, enStepWizard.TipoCarta)
                                If Not fp Is Nothing AndAlso MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                                    'qui vado diretto al plugin
                                    ris = "/" & fp.Route.Url.Replace("{idp}", P.IdPrev)
                                End If

                            End If

                            If fp Is Nothing OrElse Not MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                                Dim tcSel As TipoCartaW = lstTC(0)
                                ris = "/" & P.IdPrev & "/" & FpSel.IdFormProd & "/" & tcSel.IdTipoCarta & "/" & P.NomeInUrl & "-" & fpNomeUrl & "-" & tcSel.NomeInUrl

                                'qui devo vedere se posso saltare il colore di stampa con il default per il colore di stampa
                                Dim lstCS As New List(Of ColoreStampaW)

                                For Each lb As ListinoBaseW In lst
                                    If lstCS.FindAll(Function(x) x.IdColoreStampa = lb.IdColoreStampa).Count = 0 Then
                                        lstCS.Add(lb.ColoreStampa)
                                    End If
                                Next

                                'If P.IdColoreStampaDefault Then
                                '    Dim CsDefault As ColoreStampaW = lstCS.Find(Function(x) x.IdColoreStampa = P.IdColoreStampaDefault)
                                '    If Not CsDefault Is Nothing Then
                                '        'qui il colore di stmapa e' contenuto. azzero la lista e riaggiungo solo questo 
                                '        lstCS.Clear()
                                '        lstCS.Add(CsDefault)

                                '    End If
                                'End If

                                If lstCS.Count = 1 Then
                                    If P.IdPluginToUse <> 0 Then
                                        fp = MgrPlugin.GetPlugin(P, enStepWizard.ColoriStampa)
                                        If Not fp Is Nothing AndAlso MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                                            'qui vado diretto al plugin
                                            ris = "/" & fp.Route.Url.Replace("{idp}", P.IdPrev)
                                        End If

                                    End If

                                    If fp Is Nothing OrElse Not MgrPlugin.GetRisPlugin(fp) Is Nothing Then
                                        Dim csSel As ColoreStampaW = lstCS(0)

                                        Dim lbSel As ListinoBaseW = lst.Find(Function(x) x.IdFormProd = FpSel.IdFormProd And x.IdTipoCarta = tcSel.IdTipoCarta And x.IdColoreStampa = csSel.IdColoreStampa)
                                        Dim NFogli As Integer = lbSel.faccmin / 2

                                        If lbSel.faccmin <> lbSel.faccmax AndAlso lbSel.DefaultNFogli <> 0 Then
                                            NFogli = lbSel.DefaultNFogli
                                        End If
                                        ris = "/" & lbSel.IdPrev & "/" & lbSel.IdFormProd & "/" & lbSel.IdTipoCarta & "/" & lbSel.IdColoreStampa & "/" & NFogli & "/" & lbSel.NomeInUrl

                                    End If
                                End If

                            End If
                        End If

                    End If

                End If

            End If
        End Using

        Return ris

    End Function

    Public Shared Function GetUrlCat(IdPrev As Integer,
                                     IdCat As Integer) As String
        Dim ris As String = String.Empty

        'qui devo vedere se c'e' un default per questa cat e questa preventivazione

        Using mgr As New DefaultFormatoProdottoDAO
            Dim l As List(Of DefaultFormatoProdotto) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.DefaultFormatoProdotto.IdPreventivazione, IdPrev),
                                                                   New LUNA.LunaSearchParameter(LFM.DefaultFormatoProdotto.IdCatFormatoProdotto, IdCat))

            If l.Count Then
                Dim IdFpDefault As Integer = l(0).IdFormatoProdotto
                ris = GetUrl(IdPrev, IdFpDefault)
            Else
                Using P As New PreventivazioneW
                    P.Read(IdPrev)
                    ris = "/scegli-formato/" & IdPrev & "/" & IdCat & "/" & P.NomeInUrl
                End Using
            End If

        End Using

        Return ris
    End Function

    Public Shared Function GetUrl(IdPrev As Integer,
                                  Optional IdFormatoProdotto As Integer = 0,
                                  Optional IdTipoCarta As Integer = 0,
                                  Optional IdColoreStampa As Integer = 0) As String

        Dim ris As String = String.Empty

        Using P As New PreventivazioneW
            P.Read(IdPrev)

            ris = GetUrl(P, IdFormatoProdotto, IdTipoCarta, IdColoreStampa)

        End Using

        Return ris

    End Function

    Public Shared Function GetUrlLb(IdListinoBase As Integer, Optional Mobile As Boolean = False) As String
        Dim Ris As String = String.Empty
        Using L As New ListinoBaseW
            L.Read(IdListinoBase)
            Ris = GetUrlLb(L, Mobile)
        End Using
        Return Ris
    End Function

    Public Shared Function GetUrlLb(L As ListinoBaseW, Optional Mobile As Boolean = False) As String
        Dim ris As String = String.Empty

        Dim NFogli As Integer = L.faccmin / 2

        If L.faccmin <> L.faccmax AndAlso L.DefaultNFogli <> 0 Then
            NFogli = L.DefaultNFogli
        End If
        If Mobile Then
            ris = "/m"
        End If
        ris &= "/" & L.IdPrev & "/" & L.IdFormProd & "/" & L.IdTipoCarta & "/" & L.IdColoreStampa & "/" & NFogli & "/" & L.NomeInUrl

        Return ris
    End Function

End Class
