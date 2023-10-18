Imports FormerLib.FormerEnum

Public Class ConsegnaDiritti
    Private _C As ConsegnaProgrammata = Nothing

    Public Sub New(C As ConsegnaProgrammata)
        _C = C
    End Sub
    Public ReadOnly Property PossoAnticipareGiorno As RisConsegnaModificabile
        Get
            Dim ris As New RisConsegnaModificabile
            If _C.HaOrdiniConDataGarantita = True Then
                ris.AddProblem("Ha ordini con data garantita")
            End If
            If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
                ris.AddProblem("La consegna non è più in stato modificabile")
            End If
            'If _C.Blocco = enSiNo.Si Then
            '    ris.AddProblem("La consegna ha il lucchetto")
            'End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property PossoPosticipareGiorno As RisConsegnaModificabile
        Get
            Dim ris As New RisConsegnaModificabile
            If _C.HaOrdiniConDataGarantita = True Then
                ris.AddProblem("Ha ordini con data garantita")
            End If
            If _C.HaUnPagamentoAnticipato = True Then
                ris.AddProblem("Ha un pagamento anticipato")
            End If
            If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
                ris.AddProblem("La consegna non è più in stato modificabile")
            End If
            If _C.HaDocumentiFiscali = True Then
                ris.AddProblem("Ha documenti fiscali già emessi")
            End If
            'If _C.Blocco = enSiNo.Si Then
            '    ris.AddProblem("La consegna ha il lucchetto")
            'End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property PossoModificareIndirizzoOppureCorriere(Optional NuovoCap As String = "") As RisConsegnaModificabile
        Get
            Dim ris As New RisConsegnaModificabile
            If _C.HaDocumentiFiscali Then
                ris.AddProblem("Ha documenti fiscali già emessi")
            End If

            If _C.HaUnPagamentoAnticipato Then 'DA SISTEMARE VALUTANDO IL NUOVO CAP
                ris.AddProblem("Ha un pagamento anticipato")
            End If

            If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
                ris.AddProblem("La consegna non è più in stato modificabile")
            End If

            'If _C.Blocco = enSiNo.Si Then
            '    ris.AddProblem("La consegna ha il lucchetto")
            'End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property PossoModificareOrdiniContenutiOAccorparla As RisConsegnaModificabile
        Get
            Dim ris As New RisConsegnaModificabile
            If _C.HaDocumentiFiscali Then
                ris.AddProblem("Ha documenti fiscali già emessi")
            End If

            If _C.HaUnPagamentoAnticipato Then
                ris.AddProblem("Ha un pagamento anticipato")
            End If

            If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
                ris.AddProblem("La consegna non è più in stato modificabile")
            End If

            'If _C.Blocco = enSiNo.Si Then
            '    ris.AddProblem("La consegna ha il lucchetto")
            'End If
            Return ris
        End Get

    End Property

    Public ReadOnly Property PossoCambiareDocumentoFiscaleOrdini As RisConsegnaModificabile
        Get
            Dim ris As New RisConsegnaModificabile
            If _C.HaDocumentiFiscali Then
                ris.AddProblem("Ha documenti fiscali già emessi")
            End If

            If _C.HaUnPagamentoAnticipato Then
                ris.AddProblem("Ha un pagamento anticipato")
            End If

            If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
                ris.AddProblem("La consegna non è più in stato modificabile")
            End If

            'If _C.Blocco = enSiNo.Si Then
            '    ris.AddProblem("La consegna ha il lucchetto")
            'End If
            Return ris
        End Get

    End Property

End Class
