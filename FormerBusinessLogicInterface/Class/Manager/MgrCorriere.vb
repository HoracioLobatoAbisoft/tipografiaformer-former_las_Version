Imports FormerLib.FormerEnum

Public Class MgrCorriere

    Public Shared Function CalcolaTariffa(Corriere As ICorriereBusiness, _
                               PesoVolumetrico As Single,
                               PesoKg As Single,
                               PrezzoOrdine As Decimal, _
                               MetodoPagamento As ITipoPagamentoBusiness) As Decimal

        Return CalcoloRealeTariffa(Corriere, MetodoPagamento, PesoVolumetrico, PesoKg, PrezzoOrdine)

    End Function

    'Public Shared Function CalcolaTariffa(Corriere As ICorriereBusiness, _
    '                           Altezza As Single, _
    '                           Larghezza As Single, _
    '                           Profondita As Single, _
    '                           KgPeso As Single, _
    '                           PrezzoOrdine As Decimal, _
    '                           MetodoPagamento As ITipoPagamentoBusiness) As Decimal

    '    Dim PesoVol As Single = CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

    '    Return CalcoloRealeTariffa(Corriere, MetodoPagamento, PesoVol, KgPeso, PrezzoOrdine)

    'End Function

    Public Shared Function CalcolaPesoVolumetrico(AltezzaCm As Single,
                                  LarghezzaCm As Single,
                                  ProfonditaCm As Single) As Single

        Dim PesoRif As Single = (AltezzaCm * LarghezzaCm * ProfonditaCm) / 3333
        PesoRif = PesoRif + ((PesoRif * 2) / 100)
        Return PesoRif
    End Function

    Private Shared Function CalcoloRealeTariffa(Corriere As ICorriereBusiness,
                                                MetodoPagamento As ITipoPagamentoBusiness,
                                                  PesoVolumetrico As Single,
                                                  PesoKg As Single,
                                                  PrezzoOrdine As Decimal) As Decimal
        Dim ris As Decimal = 0
        Select Case Corriere.TipoCorriere
            Case enTipoCorriere.Gratis
                'NULLA
            Case enTipoCorriere.PortoAssegnato
                'CALCOLO UNA PERCENTUALE SUL Totale dell'ordine
                ris = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((PrezzoOrdine * Corriere.PercPortoAssegnato / 100), 2)

            Case enTipoCorriere.ConTariffa
                'calcolo il peso volumetrico
                'lo confronto con il peso normale
                'prendo quello piu alto e calcolo la tariffa in base ai scaglioni di questo corriere 
                Dim PesoRif As Single = PesoVolumetrico

                If PesoKg > PesoVolumetrico Then PesoRif = PesoKg

                If PesoRif <= Corriere.KgLimite1 Then
                    ris = Corriere.TariffaLimite1
                ElseIf PesoRif > Corriere.KgLimite1 And PesoRif <= Corriere.KgLimite2 Then
                    ris = Corriere.TariffaLimite2
                ElseIf PesoRif > Corriere.KgLimite2 And PesoRif <= Corriere.KgLimite3 Then
                    ris = Corriere.TariffaLimite3
                ElseIf PesoRif > Corriere.KgLimite3 And PesoRif <= Corriere.KgLimite4 Then
                    ris = Corriere.TariffaLimite4
                ElseIf PesoRif > Corriere.KgLimite4 And PesoRif <= Corriere.KgLimite5 Then
                    ris = Corriere.TariffaLimite5
                ElseIf PesoRif > Corriere.KgLimite5 And PesoRif <= Corriere.KgLimite6 Then
                    ris = Corriere.TariffaLimite6
                ElseIf PesoRif > Corriere.KgLimite6 Then
                    'qui calcolo ogni xkg xeuro
                    Dim PesoDaCalc As Single = PesoRif - Corriere.KgLimite6
                    Dim Moltiplicatore As Integer = System.Math.Ceiling((PesoDaCalc / Corriere.KgLimite7))
                    If Moltiplicatore = 0 Then Moltiplicatore = 1
                    ris = Corriere.TariffaLimite6 + ((Corriere.TariffaLimite7 * Moltiplicatore))
                End If

                If MetodoPagamento.ImportoMaggiorazione Then ' le maggiorazioni vengono prese in considerazione solo se non si tratta di consegne che facciamo noi direttamente
                    If Corriere.IdCorriere <> enCorriere.TipografiaFormer And
                        Corriere.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then
                        ris += MetodoPagamento.ImportoMaggiorazione
                    End If

                End If

        End Select

        Return ris
    End Function

End Class
