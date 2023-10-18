Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Namespace My.Templates

    Partial Public Class DistintaTemplate

        Public Property Consegne As List(Of ConsegnaProgrammata)

        Private _TotaleColli As Integer
        Public ReadOnly Property TotaleColli As Integer
            Get
                _TotaleColli = 0
                For Each C In Consegne
                    _TotaleColli += C.NumColli
                Next
                Return _TotaleColli
            End Get
        End Property

        Private _TotalePeso As Single
        Public ReadOnly Property TotalePeso As Single
            Get
                _TotalePeso = 0
                For Each C In Consegne
                    _TotalePeso += C.Peso
                Next
                Return _TotalePeso
            End Get
        End Property

        Public ReadOnly Property TotaleContrassegno As Integer
            Get
                Dim ris As Integer = 0
                _TotaleRicavoContrassegno = 0
                For Each C In Consegne
                    If C.MetodoPagamento.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro Then
                        If C.HaUnPagamentoAnticipato = False Then
                            If C.ListaIdDocumenti.Count Then
                                Dim IdDoc As Integer = C.ListaIdDocumenti(0)
                                Using d As New Ricavo
                                    d.Read(IdDoc)
                                    _TotaleRicavoContrassegno += d.Totale
                                End Using
                                ris += 1
                            Else
                                'TODO: ?
                            End If
                        End If

                    End If
                Next
                Return ris
            End Get
        End Property

        Public ReadOnly Property TotalePortoFranco As Integer
            Get
                Dim ris As Integer = 0
                For Each C In Consegne
                    Dim TipoCorriere As enTipoCorriere = C.Corriere.TipoCorriere
                    If TipoCorriere = enTipoCorriere.ConTariffa Then
                        ris += 1
                    End If
                Next
                _TotalePortoAssegnato = Consegne.Count() - ris
                Return ris
            End Get
        End Property

        Private _TotalePortoAssegnato As Integer
        Public ReadOnly Property TotalePortoAssegnato As Integer
            Get
                Return _TotalePortoAssegnato
            End Get
        End Property

        Private _TotaleRicavoContrassegno As Decimal
        Public ReadOnly Property TotaleRicavoContrassegno As Decimal
            Get
                Return _TotaleRicavoContrassegno
            End Get
        End Property

    End Class

End Namespace
