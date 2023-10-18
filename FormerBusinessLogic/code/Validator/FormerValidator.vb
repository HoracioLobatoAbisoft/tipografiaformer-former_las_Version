'VALIDA I FILE SORGENTI IN BASE AD ALCUNI PARAMETRI RITORNANDO UN REPORT IN CASO I CONTROLLI DI VALIDAZIONE NON VANNO A BUON FINE
'VIENE CHIAMATO DALLO SCARICAMENTO DI NUOVI ORDINI CHE PREVEDE POI COME E DOVE LASCIARE I FILE 
Imports FormerDALSql
Imports FW = FormerDALWeb
Imports FormerLib.FormerEnum

Public Class FormerValidator

    Public Shared Function ValidaOrdineInterno(O As Ordine) As ValidationOrderResult
        Dim RisValidazioneOrdine As New ValidationOrderResult
        RisValidazioneOrdine.IdOrdine = O.IdOrd

        For Each S As FileSorgente In O.ListaSorgenti
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(O.ListinoBase,
                                                                                                   S.FilePath,
                                                                                                   O.Largo,
                                                                                                   O.Lungo,
                                                                                                   O.Orientamento)
            RisValidazioneOrdine.ValidationFileList.Add(risValidazioneFile)
        Next

        Return RisValidazioneOrdine
    End Function

    Public Shared Function ValidaOrdineWeb(O As FW.OrdineWeb) As ValidationOrderResult

        Dim RisValidazioneOrdine As New ValidationOrderResult
        RisValidazioneOrdine.IdOrdine = O.IdOrdine

        Dim risValidazioneFronte As ValidationFileResult
        Dim risValidazioneRetro As ValidationFileResult

        Using L As New ListinoBase
            L.Read(O.IdListinoBase)

            risValidazioneFronte = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeFronte, O.Larghezza, O.Altezza, O.Orientamento)
            risValidazioneFronte.TipoSorgente = enFronteRetro.Fronte

            If O.TipoRetro <> enTipoRetro.RetroBianco And O.FileScaricatiNomeRetro.Length Then
                risValidazioneRetro = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeRetro, O.Larghezza, O.Altezza, O.Orientamento)
            Else
                risValidazioneRetro = New ValidationFileResult
            End If
            risValidazioneRetro.TipoSorgente = enFronteRetro.Retro
        End Using

        RisValidazioneOrdine.ValidationFileList.Add(risValidazioneFronte)
        RisValidazioneOrdine.ValidationFileList.Add(risValidazioneRetro)

        Return RisValidazioneOrdine

    End Function

    'Public Shared Function ValidateOrderWeb(O As FW.OrdineWeb) As ValidationOrderResult
    '    'Valida un Ordine nella sua interezza

    '    Dim ris As New ValidationOrderResult
    '    ris.IdOrdine = O.IdOrdine

    '    Dim risValidazioneFronte As ValidationFileResult
    '    Dim risValidazioneRetro As ValidationFileResult

    '    Using L As New ListinoBase
    '        L.Read(O.IdListinoBase)

    '        risValidazioneFronte = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeFronte, O.Larghezza, O.Altezza)
    '        risValidazioneFronte.TipoSorgente = enFronteRetro.Fronte

    '        If O.TipoRetro <> enTipoRetro.RetroBianco And O.FileScaricatiNomeRetro.Length Then
    '            risValidazioneRetro = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeRetro, O.Larghezza, O.Altezza)
    '        Else
    '            risValidazioneRetro = New ValidationFileResult
    '        End If
    '        risValidazioneRetro.TipoSorgente = enFronteRetro.Retro
    '    End Using

    '    ris.ValidationFileList.Add(risValidazioneFronte)
    '    ris.ValidationFileList.Add(risValidazioneRetro)

    '    Return ris

    'End Function

    Private Shared Function GetValidationErrorLevelForPreventivazione(CodiceDiErrore As enValidatorErrorCode,
                                                                      IdPreventivazione As Integer) As enValidatorErrorLevel
        Dim ris As enValidatorErrorLevel

        Select Case CodiceDiErrore 'qui metto i default 
            Case enValidatorErrorCode.DimensioniNonCorrette
                ris = enValidatorErrorLevel.Attenzione
            Case enValidatorErrorCode.OrientamentoNonCorretto
                ris = enValidatorErrorLevel.Attenzione
            Case enValidatorErrorCode.FontIncorporati
                ris = enValidatorErrorLevel.Informazione
            Case enValidatorErrorCode.FontNonIncorporati
                ris = enValidatorErrorLevel.Errore
            Case enValidatorErrorCode.AbbondanzaErrata
                ris = enValidatorErrorLevel.Informazione
        End Select

        Using mgrV As New ValidatorErrorLevelDAO
            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter(LFM.ValidatorErrorLevel.IdPreventivazione, IdPreventivazione),
                                                         New LUNA.LunaSearchParameter(LFM.ValidatorErrorLevel.ValidatorErrorCode, CodiceDiErrore))
                If Not vel Is Nothing Then
                    ris = vel.ValidatorErrorLevel
                End If
            End Using
        End Using

        Return ris
    End Function

    Public Shared Function ValidateSourceFilePDF(L As ListinoBase,
                                             FilePath As String,
                                             LarghezzaDallOrdine As Integer,
                                             AltezzaDallOrdine As Integer,
                                             OrientamentoDallOrdine As Integer) As ValidationFileResult

        Dim ris As New ValidationFileResult(FilePath)

        'per ora lavora solo su pdf, potrebbe prendere in carico anche uno zip che contiene un pdf in futuro
        If FilePath.ToLower.EndsWith("pdf") Then

            '********************************
            'ORIENTAMENTO
            '********************************
            Dim VersoPdf As enTipoOrientamento = FormerLib.FormerHelper.PDF.GetOrientamentoPdf(FilePath)
            ris.Orientamento = VersoPdf

            If L.FormatoProdotto.Orientabile = enSiNo.No Then

                If L.FormatoProdotto.Orientamento <> VersoPdf Then
                    Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.OrientamentoNonCorretto, L.IdPrev)
                    Dim ex As New ValidationError(enValidatorErrorCode.OrientamentoNonCorretto,
                                                  "Il formato prodotto prevede un PDF " & FormerLib.FormerEnum.FormerEnumHelper.OrientamentoStr(L.FormatoProdotto.Orientamento) & ";",
                                                  LivelloDiWarning)
                    ris.ErrorList.Add(ex)
                End If

            Else
                'qui controllo che l'orientamento e' compatibile con l'orientamento scelto nell'ordine
                'lo controllo solo se l'orientamento e' stato specificato anche se e' un controllo superfluo a questo punto 
                If OrientamentoDallOrdine <> enTipoOrientamento.NonSpecificato Then
                    If OrientamentoDallOrdine <> VersoPdf Then
                        Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.OrientamentoNonCorretto, L.IdPrev)
                        Dim ex As New ValidationError(enValidatorErrorCode.OrientamentoNonCorretto,
                                                      "L'ordine prevede un PDF " & FormerLib.FormerEnum.FormerEnumHelper.OrientamentoStr(L.FormatoProdotto.Orientamento) & ";",
                                                      LivelloDiWarning)
                        ris.ErrorList.Add(ex)
                    End If
                End If

            End If

            '********************************
            'DIMENSIONI
            '********************************

            Dim risCheckDimensioni As RisControlloDimensioniSorgente = Nothing
            Using mgr As New FileSorgentiDAO
                risCheckDimensioni = mgr.CheckDimensioni(L, FilePath, LarghezzaDallOrdine, AltezzaDallOrdine)
            End Using
            If risCheckDimensioni.ErroreDimensioni Then
                Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.DimensioniNonCorrette, L.IdPrev)
                Dim ex As New ValidationError(enValidatorErrorCode.DimensioniNonCorrette,
                                                  "Il formato del file è " & risCheckDimensioni.LarghezzaRiscontrata & " mm x " & risCheckDimensioni.AltezzaRiscontrata & " mm invece che " & risCheckDimensioni.LarghezzaPrevista & " mm x " & risCheckDimensioni.AltezzaPrevista & " mm;",
                                                  LivelloDiWarning)
                ris.ErrorList.Add(ex)
            End If



            'Dim dimensioniEffettive As System.Drawing.Size = FormerLib.FormerHelper.PDF.GetDimensioniTrimPagina(FilePath)

            'Dim LarghezzaFormato As Single = 0
            'Dim AltezzaFormato As Single = 0

            'If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '    LarghezzaFormato = LarghezzaDallOrdine
            '    AltezzaFormato = AltezzaDallOrdine
            'Else
            '    LarghezzaFormato = L.FormatoCarta.Larghezza
            '    AltezzaFormato = L.FormatoCarta.Altezza
            'End If

            'LarghezzaFormato = LarghezzaFormato * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 
            'AltezzaFormato = AltezzaFormato * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 

            'Dim LarghezzaRiferimento As Integer = IIf(LarghezzaFormato > AltezzaFormato, LarghezzaFormato, AltezzaFormato)
            'Dim AltezzaRiferimento As Integer = IIf(AltezzaFormato < LarghezzaFormato, AltezzaFormato, LarghezzaFormato)

            'Dim LarghezzaEffettiva As Integer = IIf(dimensioniEffettive.Width > dimensioniEffettive.Height, dimensioniEffettive.Width, dimensioniEffettive.Height)
            'Dim AltezzaEffettiva As Integer = IIf(dimensioniEffettive.Height < dimensioniEffettive.Width, dimensioniEffettive.Height, dimensioniEffettive.Width)

            'Dim diffW As Integer = LarghezzaEffettiva - LarghezzaRiferimento
            'Dim diffH As Integer = AltezzaEffettiva - AltezzaRiferimento

            'If diffW Then
            '    Dim ErroreTolleranza As Boolean = False
            '    If diffW > 0 Then 'qui il file e' piu grande del formato carta
            '        If diffW > (L.FormatoCarta.TolleranzaEccesso * 2) Then ErroreTolleranza = True
            '    Else 'qui il file e' piu piccolo del formato carta
            '        If Math.Abs(diffW) > (L.FormatoCarta.TolleranzaDifetto * 2) Then ErroreTolleranza = True
            '    End If
            '    If ErroreTolleranza Then
            '        Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.DimensioniNonCorrette, L.IdPrev)

            '        Dim ex As New ValidationError(enValidatorErrorCode.DimensioniNonCorrette,
            '                                      "Il formato del file è " & dimensioniEffettive.Width & " mm x " & dimensioniEffettive.Height & " mm invece che " & LarghezzaFormato & " mm x " & AltezzaFormato & " mm;",
            '                                      LivelloDiWarning)
            '        ris.ErrorList.Add(ex)
            '    End If
            'End If

            'If diffH AndAlso ris.ErrorList.FindAll(Function(x) x.ReturnCode = enValidatorErrorCode.DimensioniNonCorrette).Count = 0 Then 'se le dimensioni sono gia sbagliate inutile controllare
            '    Dim ErroreTolleranza As Boolean = False
            '    If diffH > 0 Then 'qui il file e' piu grande del formato carta
            '        If diffH > (L.FormatoCarta.TolleranzaEccesso * 2) Then ErroreTolleranza = True
            '    Else 'qui il file e' piu piccolo del formato carta
            '        If Math.Abs(diffH) > (L.FormatoCarta.TolleranzaDifetto * 2) Then ErroreTolleranza = True
            '    End If
            '    If ErroreTolleranza Then
            '        Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.DimensioniNonCorrette, L.IdPrev)
            '        Dim ex As New ValidationError(enValidatorErrorCode.DimensioniNonCorrette,
            '                                      "Il formato del file è " & dimensioniEffettive.Width & " mm x " & dimensioniEffettive.Height & " mm invece che " & LarghezzaRiferimento & " mm x " & AltezzaRiferimento & " mm;",
            '                                      LivelloDiWarning)
            '        ris.ErrorList.Add(ex)
            '    End If

            'End If

            '********************************
            'ABBONDANZA CONTROLLATA CON TOLLERANZE IMPOSTATE 
            '********************************
            Dim AbbondanzaTrovata As Integer = FormerLib.FormerHelper.PDF.GetAbbondanza(FilePath)

            If AbbondanzaTrovata = 0 Then
                Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.AbbondanzaErrata, L.IdPrev)
                Dim ex As New ValidationError(enValidatorErrorCode.AbbondanzaErrata,
                                                 "Il file non contiene abbondanza",
                                                 LivelloDiWarning)
                ris.ErrorList.Add(ex)
            ElseIf AbbondanzaTrovata = -1 Then
                Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.AbbondanzaErrata, L.IdPrev)
                Dim ex As New ValidationError(enValidatorErrorCode.AbbondanzaErrata,
                                                 "L'abbondanza trovata non è simmetrica",
                                                 LivelloDiWarning)
                ris.ErrorList.Add(ex)
            Else

                If AbbondanzaTrovata > 100 Then 'se superiore 10 centimetri va in errore
                    Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.AbbondanzaErrata, L.IdPrev)
                    Dim ex As New ValidationError(enValidatorErrorCode.AbbondanzaErrata,
                                                     "L'abbondanza trovata (" & AbbondanzaTrovata & "mm) è fuori dai limiti massimi",
                                                     LivelloDiWarning)
                    ris.ErrorList.Add(ex)

                End If
            End If

            '********************************
            'FONT INCORPORATI NON INCORPORATI
            '********************************

            Dim ListaFont As List(Of Object()) = FormerLib.FormerHelper.PDF.GetFontList(FilePath)

            Dim BufferFontIncorporati As String = String.Empty
            Dim BufferFontNonIncorporati As String = String.Empty

            For Each singFont In ListaFont
                Dim NomeFont As String = singFont(0).ToString

                If NomeFont.Length > 7 AndAlso NomeFont.Chars(6) = "+" Then
                    'font incorporato anche se in realta si tratta di un font contenuto in un gruppo
                    NomeFont = NomeFont.Substring(7)
                    BufferFontIncorporati &= NomeFont & "; "
                Else
                    BufferFontNonIncorporati &= NomeFont & "; "
                End If
            Next

            If BufferFontIncorporati.Length Then
                Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.FontIncorporati, L.IdPrev)
                Dim ex As New ValidationError(enValidatorErrorCode.FontIncorporati,
                               "Il file PDF contiene i seguenti font INCORPORATI che per un risultato ottimale andrebbero convertiti in curve: " & BufferFontIncorporati,
                               LivelloDiWarning)
                ris.ErrorList.Add(ex)
            End If

            If BufferFontNonIncorporati.Length Then
                Dim LivelloDiWarning As enValidatorErrorLevel = GetValidationErrorLevelForPreventivazione(enValidatorErrorCode.FontNonIncorporati, L.IdPrev)
                Dim ex As New ValidationError(enValidatorErrorCode.FontNonIncorporati,
                               "Il file PDF contiene i seguenti font NON INCORPORATI che devono essere incorporati nel file o convertiti in curve: " & BufferFontNonIncorporati,
                               LivelloDiWarning)
                ris.ErrorList.Add(ex)
            End If

            'RISOLUZIONE IMMAGINI
            'qui controllo la risoluzione delle immagini contenute nel documento PDF

            'Dim imgRis As Integer = FormerLib.FormerHelper.PDF.GetImageResolution(FilePath)

            'If imgRis Then

            'End If

        Else
            Dim ex As New ValidationError(enValidatorErrorCode.FormatoFileNonCorretto,
                                          "La validazione automatica può essere effettuata solo su file PDF;",
                                          enValidatorErrorLevel.Attenzione)
            ris.ErrorList.Add(ex)
        End If

        Return ris
    End Function

End Class
