'pilota la class CorriereG
Imports FormerLib.FormerEnum

Public Class MgrMetodiConsegna

    Private Shared _Corrieri As List(Of MetodoConsegna) = Nothing

    Public Shared ReadOnly Property Corrieri As List(Of MetodoConsegna)
        Get

            If _Corrieri Is Nothing Then
                _Corrieri = New List(Of MetodoConsegna)

                Dim C As New MetodoConsegna
                C.IdMetodoConsegna = enTipoCorriere.Gratis
                C.Descrizione = "Compra e Ritira"
                C.Label = "Scegli <b>Compra e Ritira</b> e vieni a ritirare il tuo ordine direttamente presso la nostra sede di Roma"
                C.UrlDettaglio = "/compra-e-ritira"
                _Corrieri.Add(C)

                C = New MetodoConsegna
                C.IdMetodoConsegna = enTipoCorriere.ConTariffa
                C.Descrizione = "Con Corriere"
                C.Label = "Un Corriere da noi incaricato si occuperà di recapitare il tuo ordine all'indirizzo che hai indicato"
                _Corrieri.Add(C)

                C = New MetodoConsegna
                C.IdMetodoConsegna = enTipoCorriere.PortoAssegnato
                C.Descrizione = "Porto Assegnato"
                C.Label = "Hai un tuo Corriere di fiducia? Prepareremo il pacco per la consegna (+3%)"
                C.OnlyAutorized = True
                _Corrieri.Add(C)

            End If
            Return _Corrieri
        End Get
    End Property

    Public Shared Function GetMetodoConsegna(TipoCorriere As enTipoCorriere) As MetodoConsegna

        Dim ris As MetodoConsegna = Nothing

        ris = Corrieri.Find(Function(x) x.IdMetodoConsegna = TipoCorriere)

        Return ris

    End Function

    Public Shared Function GetMetodoConsegna(Corriere As ICorriereBusiness) As MetodoConsegna

        Dim ris As MetodoConsegna = Nothing

        ris = Corrieri.Find(Function(x) x.IdMetodoConsegna = Corriere.TipoCorriere)

        Return ris

    End Function

    Public Shared Function GetICorriereB(Corriere As MetodoConsegna,
                                         l As List(Of ICorriereBusiness),
                                         Optional Cap As String = "",
                                         Optional NonPrendereInConsiderazioneCorriereFormer As Boolean = False) As ICorriereBusiness

        Dim Ris As ICorriereBusiness = Nothing
        Try
            Select Case Corriere.IdMetodoConsegna
                Case enTipoCorriere.Gratis
                    Ris = l.Find(Function(x) x.TipoCorriere = enTipoCorriere.Gratis)
                Case enTipoCorriere.PortoAssegnato
                    'qui vediamo dovrebbe essercene uno in teoria cioe prendo il primo che capita come sopra
                    Ris = l.Find(Function(x) x.TipoCorriere = enTipoCorriere.PortoAssegnato)
                Case enTipoCorriere.ConTariffa
                    'qui invece vado a calcolare in base al cap se cel'ho quale corriere prendere in considerazione tra i tanti di tipo a tariffa
                    Dim IdCorriereDaUsare As Integer = enCorriere.GLS
                    If Cap.Length Then
                        If NonPrendereInConsiderazioneCorriereFormer Then
                            l = l.FindAll(Function(x) x.IdCorriere <> enCorriere.TipografiaFormer And x.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo)
                        End If
                        For Each c As ICorriereBusiness In l.FindAll(Function(x) x.TipoCorriere = enTipoCorriere.ConTariffa)
                            If c.LavoraCap(Cap) Then
                                IdCorriereDaUsare = c.IdCorriere
                                Exit For
                            End If
                        Next
                    End If

                    Ris = l.Find(Function(x) x.IdCorriere = IdCorriereDaUsare)

            End Select
        Catch ex As Exception
            Ris = l.Find(Function(x) x.IdCorriere = enCorriere.GLS)
        End Try


        Return Ris

    End Function

End Class
