Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrOmaggi

    Public Shared Function OmaggioUtilizzabile(O As OmaggioW,
                                               Lp As List(Of ProdottoInCarrello),
                                               TotaleImportiNetti As Decimal) As Boolean
        Dim ris As Boolean = True

        If O.IdPreventivazione Then
            'qui puo avere un importo
            If O.ImportoMin Then
                If Lp.FindAll(Function(x) x.ListinoBase.IdPrev = O.IdPreventivazione And x.TotaleNetto >= O.ImportoMin).Count = 0 Then
                    ris = False
                End If
            Else
                'qui basta che ha in carrello una cosa 
                If Lp.FindAll(Function(x) x.ListinoBase.IdPrev = O.IdPreventivazione).Count = 0 Then
                    ris = False
                End If
            End If
        Else
            'qui deve avere un importo
            If TotaleImportiNetti < O.ImportoMin Then
                ris = False
            End If
        End If

        Return ris
    End Function

    Public Shared Function GetOmaggi(ByRef UtenteConnesso As UtenteSito,
                                     Optional Tipologia As enTipologiaOmaggio = enTipologiaOmaggio.Tutto) As List(Of OmaggioW)
        Dim ris As New List(Of OmaggioW)

        Dim l As List(Of OmaggioW) = Nothing

        Dim CounterOrdini As Integer = 0
        If UtenteConnesso.IdUtente Then
            Using mgr As New OrdiniWebDAO
                Dim lO As List(Of OrdineWeb) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdUt, UtenteConnesso.IdUtente),
                                                           New LUNA.LunaSearchParameter(LFM.OrdineWeb.Stato, enStatoOrdine.Eliminato, "<>"))

                CounterOrdini = lO.Count
            End Using
        End If

        Using mgr As New OmaggiWDAO
            l = mgr.GetOmaggiDisponibili(Tipologia)

            For Each SingO As OmaggioW In l
                'qui per ogni omaggio disponibile vedo se soddisfa le caratteristiche che richiede
                Dim Aggiungi As Boolean = True

                If SingO.TipoCliente <> enTipoRubrica.Tutto Then
                    If UtenteConnesso.Tipo <> SingO.TipoCliente Then
                        Aggiungi = False
                    End If
                End If

                If Aggiungi Then
                    If SingO.Tipologia = enTipologiaOmaggio.AlPrimoOrdine Then
                        If CounterOrdini <> 0 Then Aggiungi = False
                    Else
                        Aggiungi = True
                    End If
                    'COMMENTATO PER VISUALIZZARE GLI OMAGGI SOLO QUANDO LI PUOI RISCATTARE
                    'ElseIf SingO.Tipologia = enTipologiaOmaggio.ConCriteri Then
                    ''qui vedo se soddisfa i criteri qualche prodotto in carrello
                    'If SingO.IdPreventivazione Then
                    '    'qui puo avere un importo
                    '    If SingO.ImportoMin Then
                    '        If Carrello.Ordini.FindAll(Function(x) x.ListinoBase.IdPrev = SingO.IdPreventivazione And x.TotaleNetto >= SingO.ImportoMin).Count = 0 Then
                    '            Aggiungi = False
                    '        End If
                    '    Else
                    '        'qui basta che ha in carrello una cosa 
                    '        If Carrello.Ordini.FindAll(Function(x) x.ListinoBase.IdPrev = SingO.IdPreventivazione).Count = 0 Then
                    '            Aggiungi = False
                    '        End If
                    '    End If
                    'Else
                    '    'qui deve avere un importo
                    '    If Carrello.TotaleImportiNetti < SingO.ImportoMin Then
                    '        Aggiungi = False
                    '    End If
                    'End If

                End If

                If Aggiungi Then
                    If ris.FindAll(Function(x) x.IdListinoOmaggio = SingO.IdListinoOmaggio).Count = 0 Then
                        ris.Add(SingO)
                    End If
                End If

            Next

        End Using

        ris.Sort(Function(x, y) x.Tipologia.CompareTo(y.Tipologia))

        Return ris
    End Function

    Public Shared Function MostraOmaggi(ByRef UtenteConnesso As UtenteSito,
                                        Lp As List(Of ProdottoInCarrello),
                                        Optional TipoOmaggio As enTipologiaOmaggio = enTipologiaOmaggio.Tutto) As Boolean

        Dim ris As Boolean = True

        'se non ha gia in carrello un omaggio puo avere un omaggio
        'se ci sono omaggi puo avere un omaggio

        If Lp.Count <> 0 Then
            '    ris = False
            'Else
            If Lp.FindAll(Function(x) x.Omaggio = enSiNo.Si).Count Then
                ris = False
            End If
        End If

        If ris Then
            Using p As New PreventivazioneW
                p.Read(FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi)
                Dim l As List(Of ListinoBaseW) = p.GetListiniBase

                If l.FindAll(Function(x) x.Disattivo = enSiNo.No).Count = 0 Then
                    ris = False
                End If

            End Using
        End If

        If ris Then
            'qui vado a valutare quali omaggi mostrare
            Dim l As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso, TipoOmaggio)

            If l.Count = 0 Then
                ris = False
            End If
        End If

        Return ris
    End Function

End Class
