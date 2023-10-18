Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrFormerException

    Public Shared Function UsareGiornoConsegnaPerGiornoRicavo(R As Ricavo, Cp As ConsegnaProgrammata) As Boolean
        Dim ris As Boolean = False

        If R.Tipo = enTipoDocumento.Preventivo Then
            If Cp.Giorno.Year < 2017 Then
                ris = True
            End If
        End If

        Return ris
    End Function

    Public Shared Function ValutareRigaFatturaComeRisorsa(Riga As VoceCosto) As Boolean
        Dim ris As Boolean = True

        Using mgr As New VociCostoDAO
            ris = mgr.ValutareRigaFatturaComeRisorsa(Riga)
        End Using

        Return ris
    End Function

    Public Shared Function AggiungereLavorazioneInserimentoNelSistema() As Boolean

        Dim ris As Boolean = True

        Return ris

    End Function

    Public Shared Function FatturareConSnc(IdListinoBase As Integer) As Boolean
        Dim ris As Boolean = False

        If IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Then
            'ris = True
        End If

        Return ris
    End Function

    Public Shared Function SincronizzareNoteCommessa(O As Ordine) As Boolean
        Dim ris As Boolean = False
        If O.IdTipoProd <> enRepartoWeb.StampaOffset And O.IdTipoProd <> enRepartoWeb.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Public Shared Function SpostareDataConsegnaOggiQuandoEmettoDocumenti(C As ConsegnaProgrammata) As Boolean
        Dim ris As Boolean = True

        If C.Giorno.Year < 2017 Then
            ris = False
        End If

        Return ris
    End Function

    Public Shared Function SincronizzareNoteOrdine(C As Commessa) As Boolean
        Dim ris As Boolean = False
        If C.TipoCom <> enRepartoWeb.StampaOffset And C.TipoCom <> enRepartoWeb.Packaging Then
            ris = True
        End If
        Return ris
    End Function

    Public Shared Function StampareDataScadenzaPagamento(D As Ricavo) As Boolean
        Dim ris As Boolean = True

        For Each O As Ordine In D.ListaOrdini
            If O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
              O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
              O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
                ris = False
                Exit For
            End If
        Next

        Return ris
    End Function

    Public Shared Function StampareEtichetteOrdine(O As Ordine) As Boolean
        Dim ris As Boolean = True
        If O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
              O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
              O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
            ris = False
        End If
        Return ris
    End Function

    Public Shared Function UsareNomeLavoroInFattura(O As Ordine) As Boolean
        Dim ris As Boolean = False
        If O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
            O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
            O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Or
            O.OrdineInOmaggio = enSiNo.Si Then
            ris = True
        End If
        Return ris
    End Function

    Public Shared Function SpostareOrdineSeConsegnaNonAncoraCompleta(O As Ordine) As Boolean
        Dim ris As Boolean = True
        If O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
            O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
            O.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
            ris = False
        End If
        Return ris
    End Function

    Public Shared Function ValidareFileSorgente(IdListinoBase As Integer) As Boolean
        Dim ris As Boolean = True
        If IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
            IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
            IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
            ris = False
        Else
            Using L As New ListinoBase
                L.Read(IdListinoBase)
                If L.NoAttachFile = enSiNo.Si Then
                    ris = False
                End If
            End Using
        End If
        Return ris
    End Function

    Public Shared Function ForzareStampaAutomaticaDocumenti(IdListinoBase As Integer) As Boolean
        Dim ris As Boolean = False
        If IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
           IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
           IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
            ris = True
        End If
        Return ris
    End Function

    Public Shared Function CalcolareSpeseDiSpedizioneInFatturazione(C As ConsegnaProgrammata) As Boolean
        Dim ris As Boolean = True

        If C.HaUnPagamentoAnticipato Then
            ris = False
        Else
            For Each singOrd As Ordine In C.ListaOrdini

                If singOrd.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio Or
                   singOrd.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiSardegna Or
                   singOrd.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGrimaldi Then
                    ris = False
                    Exit For
                End If
            Next
        End If

        Return ris
    End Function

End Class
