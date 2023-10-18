Imports System.IO
Imports FormerLib.FormerEnum

Public Class MgrPreventivi

    Public Shared Function SalvaPreventivo(IdListinoBasePartenza As Integer,
                                      IdUtenteOnline As Integer,
                                      RagioneSocialeNome As String,
                                      Email As String,
                                      NomeLavoro As String,
                                      IdReparto As Integer,
                                      Qta As String,
                                      Larghezza As String,
                                      Lunghezza As String,
                                      Orientamento As Integer,
                                      Finitura As String,
                                      IdTipoCarta As Integer,
                                      IdColoreStampa As Integer,
                                      LRif As ListinoBaseW,
                                      LPart As ListinoBaseW,
                                      IsMultipagina As Boolean,
                                      IsAutocopertinato As Boolean,
                                      NumeroFacciate As String,
                                      IdOpzioniSel As List(Of Integer),
                                      Annotazioni As String,
                                      PathXML As String,
                                      Optional InviaMail As Boolean = False) As RichiestaPreventivoLogica

        Dim ListinoRiferimento As ListinoBaseW = Nothing

        Dim R As New RichiestaPreventivoLogica
        'il guid è valorizzato automaticamente

        R.Quando = Now
        R.IdListinoBasePartenza = IdListinoBasePartenza
        R.IdCliente = IdUtenteOnline
        R.RagioneSocialeNome = RagioneSocialeNome
        R.Email = Email
        R.NomeLavoro = NomeLavoro
        R.Reparto = IdReparto
        R.Qta = Qta
        R.Larghezza = Larghezza
        R.Lunghezza = Lunghezza
        R.Orientamento = Orientamento
        R.Finitura = Finitura
        R.IdTipoCarta = IdTipoCarta
        R.ColoreStampa = IdColoreStampa

        R.DataIndicativaConsegna = Date.Now

        If Not R.TipoCartaRif Is Nothing Then
            'DA QUI SI PARLA DI LISTINOBASE
            If (LRif.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso LRif.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
                (LRif.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso LRif.FormatoCarta.AltezzaMM = CInt(R.Larghezza)) Then
                'qui il formato prodtto del listino riferimento va bene

                If R.TipoCartaRif.IdTipoCarta = LRif.IdTipoCarta AndAlso R.ColoreStampa = LRif.ColoreStampa.IdColoreStampa Then
                    'qui il listinobase e' rimasto identico
                    ListinoRiferimento = LRif
                End If
            End If

            If ListinoRiferimento Is Nothing Then
                'qui qualcosa è diverso devo capire se fare una variante di questo listino base o se esiste gia una combinazione 
                Using Mgr As New ListinoBaseWDAO
                    '********* 
                    '********* QUI VA CAMBIATO E DEVO PRENDERE TUTTI QUELLI IN GRUPPOVARIANTE
                    '********* 
                    Dim LLib As List(Of ListinoBaseW) = Nothing

                    If LRif.Preventivazione.GruppoVariante Then
                        Using gv As New GruppoVarianteW
                            gv.Read(LRif.Preventivazione.GruppoVariante)
                            LLib = gv.GetListinibyGruppoVariante()
                        End Using
                    Else
                        LLib = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdTipoCarta, R.TipoCartaRif.IdTipoCarta),
                                           New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, LPart.IdPrev))

                    End If

                    LLib = LLib.FindAll(Function(x) x.NascondiOnline = enSiNo.No)

                    For Each lb In LLib
                        lb.IdListinoBasePerOrdinamentoComparativo = LPart.IdListinoBase
                    Next

                    'LLib.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))

                    LLib.Sort(AddressOf FormerListSorterW.ListinoBaseWSorter.SortPreventivi)


                    For Each Lb As ListinoBaseW In LLib
                        If (Lb.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
                            (Lb.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Larghezza)) Then
                            'qui il formato prodtto del listino riferimento va bene

                            If R.TipoCartaRif.IdTipoCarta = Lb.IdTipoCarta AndAlso
                                R.ColoreStampa = Lb.ColoreStampa.IdColoreStampa Then
                                'qui il listinobase e' rimasto identico
                                ListinoRiferimento = Lb
                                ListinoRiferimento.CaricaLavorazioniBase()
                                ListinoRiferimento.CaricaLavorazioniOpz()
                                Exit For
                            End If
                        End If
                    Next

                    If ListinoRiferimento Is Nothing Then 'qui vediamo se riesco a trovarlo senza coloredistampa 
                        For Each Lb As ListinoBaseW In LLib
                            If (Lb.FormatoCarta.LarghezzaMM = CInt(R.Larghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Lunghezza)) OrElse
                                (Lb.FormatoCarta.LarghezzaMM = CInt(R.Lunghezza) AndAlso Lb.FormatoCarta.AltezzaMM = CInt(R.Larghezza)) Then
                                'qui il formato prodtto del listino riferimento va bene

                                If R.TipoCartaRif.IdTipoCarta = Lb.IdTipoCarta Then
                                    'qui il listinobase e' rimasto identico
                                    ListinoRiferimento = Lb
                                    ListinoRiferimento.CaricaLavorazioniBase()
                                    ListinoRiferimento.CaricaLavorazioniOpz()
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    If ListinoRiferimento Is Nothing Then
                        'se qui non ho trovato niente vuoldire che non c'e' niente cerco il formato in cui entra 

                        For Each Lb As ListinoBaseW In LLib
                            If (Lb.FormatoCarta.LarghezzaMM >= CInt(R.Larghezza) AndAlso Lb.FormatoCarta.AltezzaMM >= CInt(R.Lunghezza)) OrElse
                            (Lb.FormatoCarta.LarghezzaMM >= CInt(R.Lunghezza) AndAlso Lb.FormatoCarta.AltezzaMM >= CInt(R.Larghezza)) Then
                                'qui il formato prodtto del listino riferimento va bene

                                If R.TipoCartaRif.IdTipoCarta = Lb.IdTipoCarta AndAlso R.ColoreStampa = Lb.ColoreStampa.IdColoreStampa Then
                                    'qui il listinobase e' rimasto identico


                                    ListinoRiferimento = Lb
                                    ListinoRiferimento.CaricaLavorazioniBase()
                                    ListinoRiferimento.CaricaLavorazioniOpz()
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End Using
            End If
        End If

        If ListinoRiferimento Is Nothing Then
            'se qui ancora è nothing non c'è niente di gia pronto che va bene e neanche di adattabile
            'quindi per ora lascio quello che trovo ma segnalo che non c'e' possibilita di adattare
            R.NessunFormatoAdattabile = True
            ListinoRiferimento = LRif
        End If

        Dim lIdLavBase As New List(Of Integer)
        Dim lIdLavOpz As New List(Of Integer)

        If Not ((ListinoRiferimento.FormatoProdotto.Larghezza = CInt(R.Larghezza) AndAlso ListinoRiferimento.FormatoProdotto.Lunghezza = CInt(R.Lunghezza)) OrElse
                (ListinoRiferimento.FormatoProdotto.Larghezza = CInt(R.Lunghezza) AndAlso ListinoRiferimento.FormatoProdotto.Lunghezza = CInt(R.Larghezza))) Then
            'qui devo aggiungere il taglio a formato specifico 
            lIdLavOpz.Add(FormerLib.FormerConst.Lavorazioni.TaglioAMisura)
        End If

        R.IdListinoBaseRif = ListinoRiferimento.IdListinoBase
        R.NumeroFacciate = ListinoRiferimento.faccmin

        If IsMultipagina Then
            R.MultiPagina = True
            If IsAutocopertinato Then
                R.Autocopertinato = True
            End If
            R.NumeroFacciate = NumeroFacciate
        End If

        'Dim lc As List(Of CatLavW) = Nothing

        'Using mgr As New CatLavWDAO

        '    Dim RepartiDisp As String = enRepartoWeb.Tutto

        '    If ListinoRiferimento.IdListinoBase Then
        '        RepartiDisp &= "," & ListinoRiferimento.Preventivazione.IdReparto
        '    End If

        '    lc = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione"},
        '                    New LUNA.LunaSearchParameter(LFM.CatLavW.RepartoAppartenenza, "(" & RepartiDisp & ")", "IN"),
        '                    New LUNA.LunaSearchParameter(LFM.CatLavW.VisibilePreventivo, enSiNo.Si))

        'End Using

        'prima carico tutte le opzioni base non selezionabili 

        'qui ora devo riempire gli id delle opzioni sel 
        For Each lav As LavorazioneW In ListinoRiferimento.LavorazioniBase.FindAll(Function(x) x.LavorazioneInterna = enSiNo.Si Or x.CatLav.VisibilePreventivo = enSiNo.No)
            If lIdLavBase.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavBase.Add(lav.IdLavoro)
        Next

        For Each lav As LavorazioneW In LRif.LavorazioniBase
            If lIdLavBase.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavBase.Add(lav.IdLavoro)
        Next

        For Each IdLav In IdOpzioniSel

            If lIdLavBase.FindAll(Function(x) x = IdLav).Count = 0 Then lIdLavOpz.Add(IdLav)

        Next

        'For Each catsi As CatLavW In lc
        '    If catsi.TipoControllo = enTipoControllo.RadioButton Then
        '        Dim cmb As RadioButtonList = ListaRDO.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
        '                Dim lav As New LavorazioneW
        '                lav.Read(Convert.ToInt32(cmb.SelectedValue))
        '                If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '            End If
        '        End If
        '    ElseIf catsi.TipoControllo = enTipoControllo.ComboBox Then
        '        Dim cmb As DropDownList = ListaCombo.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            If cmb.SelectedValue <> String.Empty AndAlso cmb.SelectedValue <> "0" Then
        '                Dim lav As New LavorazioneW
        '                lav.Read(Convert.ToInt32(cmb.SelectedValue))
        '                If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '            End If
        '        End If
        '    ElseIf catsi.TipoControllo = enTipoControllo.CheckBox Then
        '        Dim cmb As CheckBoxList = ListaCheckbox.Find(Function(x) x.ID = "lav" & catsi.IdCatLav)
        '        If Not cmb Is Nothing Then
        '            'se nessuno e' selezionato controllo se era in quelel base e selezion cmq la prima voce
        '            If ListinoRiferimento.LavorazioniBase.FindAll(Function(x) x.IdCatLav = catsi.IdCatLav).Count <> 0 Then
        '                'qui almeno una voce deve essere selezionata
        '                If cmb.SelectedItem Is Nothing Then
        '                    cmb.Items(0).Selected = True
        '                End If
        '            End If

        '            For Each valore As ListItem In cmb.Items
        '                If valore.Selected Then
        '                    Dim lav As New LavorazioneW
        '                    lav.Read(Convert.ToInt32(valore.Value))
        '                    If lIdLavOpz.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then lIdLavOpz.Add(lav.IdLavoro)
        '                End If
        '            Next
        '        End If
        '    End If
        'Next

        R.ElencoIdOpzioniBase = lIdLavBase
        R.ElencoIdOpzioniSel = lIdLavOpz
        R.Annotazioni = Annotazioni
        R.PrezzoCalcolatoNetto = R.GetPrezzoCalcolatoNetto()

        'qui serializzo l'oggetto 
        Dim P As String = PathXML & "FP-" & FormerLib.FormerHelper.Numeri.GetNumeroCasuale() & ".xml"

        FormerLib.FormerSerializator.SerializeObjectToFile(R, P)
        Dim BufferXML As String = String.Empty
        Using RXML As New StreamReader(P)
            BufferXML = RXML.ReadToEnd
        End Using

        Dim RP As New RichiestaPreventivo
        RP.IdUt = IdUtenteOnline
        RP.IdLb = IdListinoBasePartenza
        RP.Quando = R.Quando
        RP.BufferXML = BufferXML
        RP.ImportoNetto = R.PrezzoCalcolatoNetto
        RP.Save()



        R.RichiestaRif = RP

        Dim m As New My.Templates.MailRichiestaPreventivo
        m.R = R
        Dim Buffer As String = m.TransformText
        R.BufferCalcolo = Buffer
        Dim Titolo As String = "Richiesta di Preventivo per variante di " & ListinoRiferimento.Preventivazione.Descrizione
        Dim MailDest As String = "tipografia.duca@gmail.com" '"soft@tipografiaformer.it" '"preventivi@tipografiaformer.it"

        If InviaMail Then FormerLib.FormerHelper.Mail.InviaMail(Titolo, Buffer, MailDest,,, P)

        Return R

    End Function

End Class
