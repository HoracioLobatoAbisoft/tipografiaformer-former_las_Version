Imports FormerDALSql
Imports FormerLib.FormerEnum

Namespace My.Templates

    Partial Public Class ParcelTemplate

        Private _Consegna As ConsegnaProgrammata
        Public Property Consegna As ConsegnaProgrammata
            Get
                Return _Consegna
            End Get
            Set(value As ConsegnaProgrammata)
                _Consegna = value
            End Set
        End Property

        Private _TipoPorto As String = String.Empty
        Public ReadOnly Property TipoPorto As String
            Get
                Dim TipoCorriere As enTipoCorriere = Consegna.Corriere.TipoCorriere
                If TipoCorriere = enTipoCorriere.ConTariffa Then
                    _TipoPorto = "F"
                ElseIf TipoCorriere = enTipoCorriere.PortoAssegnato Then
                    _TipoPorto = "A"
                End If
                Return _TipoPorto
            End Get
        End Property

        Public ReadOnly Property GetDestinatario As String
            Get
                Dim ris As String = Consegna.IndirizzoRif.Destinatario

                If ris.Length > 20 Then
                    ris = ris.Substring(0, 20)
                End If
                Return ris
            End Get
        End Property

        Public ReadOnly Property NoteSpedizione As String
            Get
                Dim ris As String = String.Empty

                ris = Consegna.Annotazioni

                Return ris
            End Get
        End Property

        Public ReadOnly Property ImportoContrassegno As Decimal
            Get
                Dim ris As Decimal = 0
                If Consegna.MetodoPagamento.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro Then
                    If Consegna.HaUnPagamentoAnticipato = False Then
                        If NumeroCollo = 1 Then
                            If Consegna.ListaIdDocumenti.Count Then
                                Dim IdDoc As Integer = Consegna.ListaIdDocumenti(0)
                                Using d As New Ricavo
                                    d.Read(IdDoc)
                                    ris = d.Totale
                                End Using
                            Else
                                'TODO: ?
                            End If
                        End If
                    End If
                End If
                Return ris
            End Get
        End Property

        Private _NumeroCollo As Integer = 0
        Public Property NumeroCollo As Integer
            Get
                Return _NumeroCollo
            End Get
            Set(value As Integer)
                _NumeroCollo = value
            End Set
        End Property

        Private _ContatoreProgressivo As Integer = 0
        Public Property ContatoreProgressivo As Integer
            Get
                Return _ContatoreProgressivo
            End Get
            Set(value As Integer)
                _ContatoreProgressivo = value
            End Set
        End Property

        'TODO: PER ORA VIENE CALCOLATO IL PESO DEL SINGOLO COLLO DIVIDENDO IL PESO DELLA CONSEGNA PER IL NUMERO DI COLLI
        'BISOGNA STUDIARE UN MODO PER AVERE IL PESO REALE DEI SINGOLI COLLI
        Public ReadOnly Property PesoCollo As Single
            Get
                Dim ris As Single = 1

                If Consegna.NumColli Then
                    ris = Consegna.Peso / Consegna.NumColli
                End If

                Return ris
            End Get
        End Property

        Public ReadOnly Property ModalitaIncasso As String
            Get
                Dim ris As String = "AB"

                'qui devo gestire la modalita di incasso per i contrassegni
                If Consegna.MetodoPagamento.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro Then
                    If Consegna.HaUnPagamentoAnticipato = False Then
                        If Consegna.AssRilIntMitt = enSiNo.Si Then
                            ris = "ARM"
                        End If
                    End If
                End If

                Return ris
            End Get
        End Property

        Public ReadOnly Property CodiceContrattoGls As String
            Get
                Return FormerConfig.FConfiguration.Gls.CodiceContratto
            End Get
        End Property

    End Class

End Namespace
