Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerDALWeb

Public Class MgrPackagingDraw

    Private Shared AltezzaAggancioDoppio As Integer = 105
    Private Shared AltezzaAggancioSingolo As Integer = 50

    Private Shared Function CreaContenitorePrincipaleSteso(Tipo As String,
                                                       B As Integer,
                                                        P As Integer,
                                                        H As Integer,
                                                        Linguetta As Integer,
                                                        ByRef MargX As Integer,
                                                        ByRef MargY As Integer) As ContenitorePrincipale

        Dim ris As New ContenitorePrincipale

        Dim AltezzaContenitore As Integer = 0
        Dim BaseContenitore As Integer = 0

        Select Case Tipo
            Case "A"
                AltezzaContenitore = H
                BaseContenitore = (B * 2) + (P * 2) + Linguetta
                ris.BufferSvg &= DrawPolilyne(BaseContenitore, AltezzaContenitore, MargX, MargY, enDirezione.Sinistra, "#ff0000", , , Linguetta)
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta, MargY, H, "#00ff00")
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + B, MargY, H, "#00ff00")
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + B + P, MargY, H, "#00ff00")
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + B + P + B, MargY, H, "#00ff00")
                ris.Width = BaseContenitore
                MargY += AltezzaContenitore

            Case "F"
                AltezzaContenitore = B + P
                BaseContenitore = (H * 2) + Linguetta
                ris.BufferSvg &= DrawPolilyne(BaseContenitore, AltezzaContenitore, MargX, MargY, enDirezione.Sinistra, "#ff0000", , , Linguetta)
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta, MargY, AltezzaContenitore, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta, MargY, H, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta, MargY, H, "#00ff00",, "-")
                ris.BufferSvg &= DrawArco(MargX + Linguetta, AltezzaContenitore + MargY, H, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta, AltezzaContenitore + MargY, H, "#00ff00",, "-")
                ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + H, MargY, AltezzaContenitore, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta + H, MargY, H, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta + H, MargY, H, "#00ff00",, "-")
                ris.BufferSvg &= DrawArco(MargX + Linguetta + H, AltezzaContenitore + MargY, H, "#00ff00")
                ris.BufferSvg &= DrawArco(MargX + Linguetta + H, AltezzaContenitore + MargY, H, "#00ff00",, "-")
                'ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + B + P, MargY, H, "#00ff00")
                'ris.BufferSvg &= DrawLineaVerticale(MargX + Linguetta + B + P + B, MargY, H, "#00ff00")
                ris.Width = BaseContenitore
                MargY += AltezzaContenitore
        End Select


        Return ris


    End Function

    Private Shared Function CreaChiusura3D(ByRef MargX As Integer,
                                         ByRef MargY As Integer,
                                         TipoChiusura As String,
                                         B As Integer,
                                         P As Integer,
                                         H As Integer,
                                         ByRef DifferenzialeX As Integer) As String
        Dim ris As String = String.Empty
        Select Case TipoChiusura
            Case "21"
                ris &= DrawRettangolo(B, AltezzaAggancioSingolo, MargX, MargY, "#ff0000")
                ris &= DrawCerchio(MargX + (B / 2) - 5, MargY + 8, , "#ff0000")

                DifferenzialeX -= AltezzaAggancioSingolo '+ MargX
                MargY += AltezzaAggancioSingolo

        End Select
        Return ris
    End Function

    Private Shared Function CreaChiusuraSteso(ByRef MargX As Integer,
                                         ByRef MargY As Integer,
                                         TipoChiusura As String,
                                         Verso As enDirezione,
                                         PosizioneChiusura As String,
                                         B As Integer,
                                         P As Integer,
                                         H As Integer,
                                         Linguetta As Integer) As Chiusura
        Dim ris As New Chiusura

        Select Case TipoChiusura
            Case "20"
                'chiusura modello 20 
                Dim AltezzaAletta As Integer = Math.Round((P * 80) / 100)
                If Verso = enDirezione.Sopra Then
                    'creo le due alette
                    'VECCHIA ALETTA - ris.BufferSvg &= DrawRettangolo(P, AltezzaAletta, MargX + Linguetta + B, MargY + Linguetta + (P - AltezzaAletta), "#ff0000", 1)
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B, MargY + Linguetta + (P - AltezzaAletta), Verso, "#ff0000", 1)
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY + Linguetta + (P - AltezzaAletta), Verso, "#ff0000", 1)
                    'creo la chiusura
                    Dim PosizioneStart As Integer = 0
                    Select Case PosizioneChiusura
                        Case "01"
                            PosizioneStart = MargX + Linguetta
                        Case "03"
                            PosizioneStart = MargX + Linguetta + B + P
                    End Select
                    'ris.BufferSvg &= DrawRettangolo(B, Linguetta + P, PosizioneStart, MargY, "#ff0000", 1)
                    ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY, Verso, "#ff0000", 1, , Linguetta)
                    ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + Linguetta, B, "#00ff00")
                    MargY += Linguetta + P
                Else
                    'creo le due alette
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B, MargY, enDirezione.Sotto, "#ff0000", 1)
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY, enDirezione.Sotto, "#ff0000", 1)
                    'creo la chiusura
                    Dim PosizioneStart As Integer = 0
                    Select Case PosizioneChiusura
                        Case "01"
                            PosizioneStart = MargX + Linguetta
                        Case "03"
                            PosizioneStart = MargX + Linguetta + B + P
                    End Select
                    ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY, enDirezione.Sotto, "#ff0000", 1, , Linguetta)
                    ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + P, B, "#00ff00")
                    MargY += Linguetta + P
                End If
            Case "21"
                If Verso = enDirezione.Sopra Then
                    'chiusura modello 21
                    Dim AltezzaAletta As Integer = Math.Round((P * 80) / 100)
                    'creo le due alette
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B, MargY + (AltezzaAggancioDoppio - AltezzaAletta), Verso, "#ff0000", 1)
                    ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY + (AltezzaAggancioDoppio - AltezzaAletta), Verso, "#ff0000", 1)
                    'creo la chiusura
                    Dim PosizioneStart As Integer = MargX + Linguetta

                    ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY + (AltezzaAggancioDoppio - P - Linguetta), Verso, "#ff0000", 1, , Linguetta)
                    ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + Linguetta + (AltezzaAggancioDoppio - P - Linguetta), B, "#00ff00")

                    PosizioneStart = MargX + Linguetta + B + P

                    ris.BufferSvg &= DrawRettangolo(B, AltezzaAggancioDoppio, PosizioneStart, MargY, "#ff0000", 1)
                    ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + 55, B, "#00ff00")

                    PosizioneStart = MargX + Linguetta + B + P + (B / 2) - 5 'levo 5 per meta larghezza cerchio

                    ris.BufferSvg &= DrawCerchio(PosizioneStart, MargY + 65, , "#ff0000")
                    ris.BufferSvg &= DrawCerchio(PosizioneStart, MargY + 48, , "#ff0000")

                    MargY += AltezzaAggancioDoppio
                End If
            Case "55"
                'chiusura modello 55 
                Dim AltezzaAletta As Integer = Math.Round((B * 50) / 100)
                If Verso = enDirezione.Sopra Then
                    'creo le due alette

                    'VECCHIA ALETTA - ris.BufferSvg &= DrawRettangolo(P, AltezzaAletta, MargX + Linguetta + B, MargY + Linguetta + (P - AltezzaAletta), "#ff0000", 1)
                    ris.BufferSvg &= DrawLinguetta55(P, AltezzaAletta, MargX + Linguetta + B, MargY + Linguetta + (P - AltezzaAletta), enDirezione.Sinistra, "#ff0000", 1)
                    ris.BufferSvg &= DrawLinguetta55(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY + Linguetta + (P - AltezzaAletta), enDirezione.Destra, "#ff0000", 1)
                    'ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B, MargY + Linguetta + (P - AltezzaAletta), Verso, "#ff0000", 1,, 5)
                    'ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY + Linguetta + (P - AltezzaAletta), Verso, "#ff0000", 1,, 5)
                    'creo la chiusura
                    Dim PosizioneStart As Integer = 0
                    Select Case PosizioneChiusura
                        Case "01"
                            PosizioneStart = MargX + Linguetta
                        Case "03"
                            PosizioneStart = MargX + Linguetta + B + P
                    End Select
                    'ris.BufferSvg &= DrawRettangolo(B, Linguetta + P, PosizioneStart, MargY, "#ff0000", 1)

                    ris.BufferSvg &= DrawPositivo55(B, (Linguetta + P), PosizioneStart, MargY, "#ff0000", 1)
                    ris.BufferSvg &= DrawNegativo55(B, (Linguetta + P), PosizioneStart + B + P, MargY, "#ff0000", 1)
                    'ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY, Verso, "#ff0000", 1, , Linguetta)

                    'ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY, Verso, "#ff0000", 1, , Linguetta)
                    'ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + Linguetta, B, "#00ff00")

                    'qui devo aggiungere l'altra chiusura

                    MargY += Linguetta + P
                Else
                    ''creo le due alette
                    'ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B, MargY, enDirezione.Sotto, "#ff0000", 1)
                    'ris.BufferSvg &= DrawPolilyne(P, AltezzaAletta, MargX + Linguetta + B + P + B, MargY, enDirezione.Sotto, "#ff0000", 1)
                    ''creo la chiusura
                    'Dim PosizioneStart As Integer = 0
                    'Select Case PosizioneChiusura
                    '    Case "01"
                    '        PosizioneStart = MargX + Linguetta
                    '    Case "03"
                    '        PosizioneStart = MargX + Linguetta + B + P
                    'End Select
                    'ris.BufferSvg &= DrawPolilyne(B, Linguetta + P, PosizioneStart, MargY, enDirezione.Sotto, "#ff0000", 1, , Linguetta)
                    'ris.BufferSvg &= DrawLineaOrizzontale(PosizioneStart, MargY + P, B, "#00ff00")
                    'MargY += Linguetta + P
                End If
        End Select

        Return ris

    End Function

    Public Shared Function GetSvgPackaging3D(Pre As IPreventivazioneB,
                                           RisPack As RisPackaging,
                                           H As Integer,
                                           B As Integer,
                                           Profondita As Integer,
                                           Optional Width As Integer = 400,
                                           Optional Heigth As Integer = 400) As String

        Dim P As Integer = Math.Round(Profondita / 2)

        Dim ris As String = "<svg width=""" & Width & """ height=""" & Heigth & """>" & ControlChars.NewLine
        ris &= "<defs>" & ControlChars.NewLine
        ris &= "  <g id=""cubo""> " & ControlChars.NewLine

        Dim MargX As Integer = 5
        Dim MargY As Integer = 5

        'calcolo lo start per centrarla
        'b+margx+p ' punto finale /2
        MargX = (Width / 2) - Math.Round((B + P) / 2)
        MargY = MargX



        Dim NomeStandard As String = MgrPluginPackaging.GetNomeStandardECMA(RisPack.FunzioneEcma)
        Dim NomeCodificato As String() = NomeStandard.Split(".")

        Dim TipologiaPack As String = NomeCodificato(0).Substring(0, 1)
        Dim TipoChiusuraSopra As String = NomeCodificato(1)
        Dim PosizioneChiusuraSopra As String = NomeCodificato(3)

        Dim TipoChiusuraSotto As String = NomeCodificato(0).Substring(1)
        Dim PosizioneChiusuraSotto As String = NomeCodificato(2)

        Dim DifferenzialeX As Integer = 0
        If TipoChiusuraSopra <> "01" Then
            Dim CSopra As String = CreaChiusura3D(MargX, MargY, TipoChiusuraSopra, B, P, H, DifferenzialeX)
            ris &= CSopra
        End If

        'CREO IL CUBO BASE
        ris &= DrawRettangolo(B, H, MargX, MargY, "#00ff00", , "stroke-dasharray:4, 3;")
        ris &= DrawRettangolo(B, P, DifferenzialeX, MargY, "#ff0000", , , 45)
        ris &= DrawRettangolo(B, P, -H + DifferenzialeX, MargY + H, "#00ff00", , "stroke-dasharray:4, 3;stroke-dashoffset:5;", 45)
        ris &= DrawRettangolo(P, H, MargX, -DifferenzialeX, "#ff0000", , , , 45)
        ris &= DrawRettangolo(B, H, MargX + P, MargY + P, "#ff0000")

        ris &= "</g>" & ControlChars.NewLine
        ris &= "</defs>" & ControlChars.NewLine
        ris &= "<use xlink:href=""#cubo"" width=""" & Width & """ heigth=""" & Heigth & """/>"""

        ris &= "</svg>" & ControlChars.NewLine

        Return ris

    End Function

    Private Shared ScaleFactor As Integer = 165

    Private Shared Function GetMis(X As Integer,
                                   Y As Integer,
                                   Optional ScaleFactorCustom As Integer = 0) As Single

        Dim ris As Single = 0
        Dim Mis As Integer = 0

        If X > Y Then
            Mis = X
        Else
            Mis = Y
        End If

        Dim Fattore As Integer = ScaleFactor

        If ScaleFactorCustom Then
            Fattore = ScaleFactorCustom
        End If

        ris = (Fattore) / Mis

        Return ris
    End Function

    Public Shared Function GetSvgEtichetteSteso(Pre As IPreventivazioneB,
                                               H As Integer,
                                               B As Integer,
                                               TipoForma As enTipoFormaEtichetta,
                                               Optional ScaleFactorCustom As Integer = 0,
                                               Optional AutoTextWithMisure As Boolean = True) As RisultatoSVGSteso
        Dim risultato As New RisultatoSVGSteso

        Dim MargX As Integer = 5
        Dim MargY As Integer = 5

        Dim ris As String = "<svg width=""###W###"" height=""###H###"" >" & ControlChars.NewLine
        ris &= "  <g transform=""scale(###S###)""> " & ControlChars.NewLine
        Dim TestoToPrint As String = B & "x" & H
        If AutoTextWithMisure = False Then TestoToPrint = String.Empty
        Select Case TipoForma
            Case enTipoFormaEtichetta.Custom
                ris &= DrawRettangolo(B, H, MargX, MargY, "#2b2b2b", 1, "stroke-dasharray:4, 3;stroke-dashoffset:5;", , , "#ffc4c4", 1, TestoToPrint)
            Case enTipoFormaEtichetta.Cerchio
                If B = H Then
                    ris &= DrawEllisse(MargX, MargY, B, B, "#2b2b2b", 1, "#ffffff")
                Else
                    ris &= DrawEllisse(MargX, MargY, B, H, "#2b2b2b", 1, "#ffffff")
                End If
            Case enTipoFormaEtichetta.Ellisse
                ris &= DrawEllisse(MargX, MargY, B, H, "#2b2b2b", 1, "#ffffff")
            Case enTipoFormaEtichetta.Rettangolare
                Dim RoundBorder As Integer = 1
                If MargX < MargY Then
                    RoundBorder = Math.Floor((MargY * 10) / 100)
                Else
                    RoundBorder = Math.Floor((MargX * 10) / 100)
                End If
                If RoundBorder <= 0 Then
                    RoundBorder = 1
                End If
                ris &= DrawRettangolo(B, H, MargX, MargY, "#2b2b2b", 1, "stroke-dasharray:4, 3;stroke-dashoffset:5;", , , "#ffc4c4", 1, TestoToPrint)
        End Select

        ris &= "</g>" & ControlChars.NewLine
        ris &= "</svg>" & ControlChars.NewLine

        risultato.Width = (MargX * 2) + B
        risultato.Heigth = (MargY * 2) + H 'MargY + H

        ris = ris.Replace("###H###", risultato.Heigth)
        ris = ris.Replace("###W###", risultato.Width)

        ris = ris.Replace("###S###", GetMis(risultato.Width, risultato.Heigth, ScaleFactorCustom).ToString.Replace(",", "."))

        risultato.BufferSVG = ris
        Return risultato

    End Function

    Public Shared Function GetSvgPackagingSteso(Pre As IPreventivazioneB,
                                           H As Integer,
                                           B As Integer,
                                           P As Integer,
                                           Optional ScaleFactorCustom As Integer = 0,
                                           Optional Testo As String = "") As RisultatoSVGSteso

        Dim risultato As New RisultatoSVGSteso

        Dim ris As String = "<svg width=""###W###"" height=""###H###"" >" & ControlChars.NewLine
        ris &= "  <g transform=""scale(###S###)"
        If Pre.IdFunzionePack = enFunzionePackaging.FunzioneECMA4 Then
            ris &= " rotate(180 ###R###)"
        End If

        ris &= """> " & ControlChars.NewLine

        Dim NomeStandard As String = MgrPluginPackaging.GetNomeStandardECMA(Pre.IdFunzionePack)
        Dim NomeCodificato As String() = NomeStandard.Split(".")

        Dim TipologiaPack As String = NomeCodificato(0).Substring(0, 1)
        Dim TipoChiusuraSopra As String = NomeCodificato(1)
        Dim PosizioneChiusuraSopra As String = NomeCodificato(3)

        Dim TipoChiusuraSotto As String = NomeCodificato(0).Substring(1)
        Dim PosizioneChiusuraSotto As String = NomeCodificato(2)

        Dim Linguetta As Integer = 12
        Dim MargX As Integer = 5
        Dim MargY As Integer = 5
        If Pre.Linguetta Then Linguetta = Pre.Linguetta

        'MargY += Linguetta + P

        If TipoChiusuraSopra <> "01" Then
            Dim CSopra As Chiusura = CreaChiusuraSteso(MargX, MargY, TipoChiusuraSopra, enDirezione.Sopra, PosizioneChiusuraSopra, B, P, H, Linguetta)
            ris &= CSopra.BufferSvg
        End If

        Dim C As ContenitorePrincipale = CreaContenitorePrincipaleSteso(TipologiaPack, B, P, H, Linguetta, MargX, MargY)

        If TipoChiusuraSotto <> "01" Then
            Dim CSotto As Chiusura = CreaChiusuraSteso(MargX, MargY, TipoChiusuraSotto, enDirezione.Sotto, PosizioneChiusuraSotto, B, P, H, Linguetta)
            ris &= CSotto.BufferSvg
        End If

        ris &= C.BufferSvg
        ris &= "</g>" & ControlChars.NewLine

        ris &= "</svg>" & ControlChars.NewLine

        risultato.Width = (MargX * 2) + C.Width
        risultato.Heigth = MargY + 5

        ris = ris.Replace("###H###", risultato.Heigth)
        ris = ris.Replace("###W###", risultato.Width)

        ris = ris.Replace("###S###", GetMis(risultato.Width, risultato.Heigth, ScaleFactorCustom).ToString.Replace(",", "."))

        If Pre.IdFunzionePack = enFunzionePackaging.FunzioneECMA4 Then
            Dim PuntoCentroX As Integer = risultato.Width / 2
            Dim PuntoCentroY As Integer = risultato.Heigth / 2
            ris = ris.Replace("###R###", PuntoCentroX & " " & PuntoCentroY)
        End If



        risultato.BufferSVG = ris


        Return risultato

    End Function

    Private Shared Function DrawText(Text As String) As String
        Dim ris As String = String.Empty

        Return ris
    End Function

    Private Shared Function DrawLineaVerticale(xStart As Integer, _
                                    yStart As Integer, _
                                    H As Integer, _
                                    Optional BordoColore As String = "#000000", _
                                    Optional BordoSpessore As Integer = 1, _
                                    Optional Tratteggio As String = "stroke-dasharray:12,3;") As String

        Dim ris As String = String.Empty

        ris &= "<path style=""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";" & Tratteggio & "stroke-dashoffset:0"""
        ris &= " d = ""m " & xStart & "," & yStart & " 0," & H
        ris &= " id=""path2989""/>"

        Return ris

    End Function

    Private Shared Function DrawLineaOrizzontale(xStart As Integer, _
                                  yStart As Integer, _
                                  W As Integer, _
                                  Optional BordoColore As String = "#000000", _
                                  Optional BordoSpessore As Integer = 1, _
                                  Optional Tratteggio As String = "stroke-dasharray:12,3;") As String

        Dim ris As String = String.Empty

        ris &= "<path style=""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";" & Tratteggio & "stroke-dashoffset:0"""
        ris &= " d = ""m " & xStart & "," & yStart & " " & W & ",0"
        ris &= " id=""path2989""/>"

        Return ris


    End Function

    Private Shared Function DrawEllisse(xStart As Integer,
                                         yStart As Integer,
                                         Optional LatoLungo As Integer = 12,
                                         Optional LatoCorto As Integer = 8,
                                         Optional BordoColore As String = "#000000",
                                         Optional BordoSpessore As Integer = 1,
                                         Optional ColoreRiempimento As String = "none") As String
        Dim ris As String = String.Empty

        ris &= "<ellipse"
        ris &= " Style = ""fill:" & ColoreRiempimento & ";stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " rx=""" & Math.Floor((LatoLungo / 2)) & """ ry=""" & Math.Floor((LatoCorto / 2)) & """"
        ris &= " cx=""" & xStart + Math.Floor((LatoLungo / 2)) & """ cy=""" & yStart + Math.Floor((LatoCorto / 2)) & """"
        ris &= " />"

        Return ris
    End Function

    Private Shared Function DrawArco(xStart As Integer,
                                    yStart As Integer,
                                    H As Integer,
                                    Optional BordoColore As String = "#000000",
                                    Optional BordoSpessore As Integer = 1,
                                    Optional Verso As String = "+") As String

        Dim ris As String = String.Empty

        ris &= "<path d=""M " & xStart & " " & yStart & " q " & Math.Ceiling(H / 2) & " " & Verso & "30 " & H & " 0"" stroke=""" & BordoColore & """ stroke-width=""" & BordoSpessore & """ stroke-dasharray=""12,3"" stroke-dashoffset=""0"" fill=""none""/>"

        Return ris

    End Function

    Private Shared Function DrawCerchio(xStart As Integer,
                                         yStart As Integer,
                                         Optional LarghezzaCerchio As Integer = 10,
                                         Optional BordoColore As String = "#000000",
                                         Optional BordoSpessore As Integer = 1,
                                         Optional ColoreRiempimento As String = "none") As String

        Dim ris As String = String.Empty

        ris &= "<path"
        ris &= " Style = ""fill:" & ColoreRiempimento & ";stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " d = ""m " & xStart & "," & yStart & " a " & LarghezzaCerchio & ",3 1 1 1 10,0 z"""
        ris &= " />"

        Return ris

    End Function

    Private Shared Function DrawLinguetta55(w As Integer,
                                 h As Integer,
                                 Optional x As Integer = 0,
                                 Optional y As Integer = 0,
                                 Optional Verso As enDirezione = enDirezione.Sopra,
                                 Optional BordoColore As String = "#000000",
                                 Optional BordoSpessore As Integer = 2) As String
        Dim ris As String = String.Empty

        ris &= "<polyline "
        ris &= " Style = ""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " points="""
        Dim x1 As Integer = w * 50 / 100
        Dim Linguetta As Integer = 10
        If Verso = enDirezione.Sinistra Then
            '<polyline  Style = "fill:none;stroke:#ff0000;stroke-width:1;" points="108,24 125,24 125,29 136,46 108,46 108,24 "/>
            ris &= x & "," & y & " "
            ris &= x + x1 & "," & y & " "
            ris &= x + x1 & "," & y + Linguetta & " "
            ris &= x + w & "," & h + y & " "
            ris &= x & "," & y + h & " "
            ris &= x & "," & y & " "
        ElseIf Verso = enDirezione.Destra Then
            '<polyline  Style = "fill:none;stroke:#ff0000;stroke-width:1;" points="237,24 254,24 254,46 226,46 237,29 237,24 "/>
            ris &= x + x1 & "," & y & " "
            ris &= x + w & "," & y & " "
            ris &= x + w & "," & h + y & " "
            ris &= x & "," & y + h & " "
            ris &= x + x1 & "," & y + Linguetta & " "
            ris &= x + x1 & "," & y & " "
        End If
        ris &= """/>"
        Return ris
    End Function

    Private Shared Function DrawPositivo55(w As Integer,
                                 h As Integer,
                                 Optional x As Integer = 0,
                                 Optional y As Integer = 0,
                                 Optional BordoColore As String = "#000000",
                                 Optional BordoSpessore As Integer = 2) As String

        '<polyline class="ﬁl0 str0" points="(X_P4),(Y_P4) (X_P3),(Y_P3) (X_P2),(Y_P2) (X_P1),(Y_P1) "/>
        Dim ris As String = String.Empty
        ris &= "<polyline "
        ris &= " Style = ""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " points="""
        Dim Linguetta As Integer = 10
        Dim LarghezzaAnsa As Integer = Math.Floor(w * 60 / 100) '10 'w - (x1 * 2)
        Dim Differenziale As Integer = Math.Ceiling((w - LarghezzaAnsa) / 2)
        '<polyline  Style = "fill:none;stroke:#ff0000;stroke-width:1;" points="108,24 125,24 125,29 136,46 108,46 108,24 "/>
        ris &= x + (Differenziale) & "," & y + Math.Ceiling(h / 2) & " "
        ris &= x + LarghezzaAnsa + Differenziale & "," & y + Math.Ceiling(h / 2) & " "
        ris &= x + LarghezzaAnsa + Differenziale & "," & y + Math.Ceiling(h / 2) + Linguetta & " "
        ris &= x + w & "," & h + y & " "
        ris &= x & "," & y + h & " "
        ris &= x + Differenziale & "," & y + Math.Ceiling(h / 2) + Linguetta & " "
        ris &= x + Differenziale & "," & y + Math.Ceiling(h / 2) & " "

        ris &= """/>"


        Return ris
    End Function

    Private Shared Function DrawNegativo55(w As Integer,
                                 h As Integer,
                                 Optional x As Integer = 0,
                                 Optional y As Integer = 0,
                                 Optional BordoColore As String = "#000000",
                                 Optional BordoSpessore As Integer = 2) As String

        '<polyline class="ﬁl0 str0" points="(X_P4),(Y_P4) (X_P3),(Y_P3) (X_P2),(Y_P2) (X_P1),(Y_P1) "/>
        Dim ris As String = String.Empty
        ris &= "<polyline "
        ris &= " Style = ""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " points="""
        Dim Linguetta As Integer = 10
        Dim LarghezzaAnsa As Integer = Math.Floor(w * 60 / 100) '10 'w - (x1 * 2)
        Dim Differenziale As Integer = Math.Ceiling((w - LarghezzaAnsa) / 2)
        '<polyline  Style = "fill:none;stroke:#ff0000;stroke-width:1;" points="108,24 125,24 125,29 136,46 108,46 108,24 "/>
        Dim MezzaAltezza As Integer = Math.Ceiling(h / 2)
        ris &= x & "," & y + MezzaAltezza & " "
        ris &= x + (Differenziale) & "," & y + MezzaAltezza & " "
        ris &= x + (Differenziale) & "," & y + Linguetta + MezzaAltezza & " "
        ris &= x + LarghezzaAnsa + Differenziale & "," & y + Linguetta + MezzaAltezza & " "
        ris &= x + LarghezzaAnsa + Differenziale & "," & y + MezzaAltezza & " "
        ris &= x + w & "," & y + MezzaAltezza & " "
        ris &= x + w & "," & y + h & " "
        ris &= x & "," & y + h & " "
        ris &= x & "," & y + MezzaAltezza & " "

        ris &= """/>"


        Return ris
    End Function

    Private Shared Function DrawPolilyne(w As Integer,
                                 h As Integer,
                                 Optional x As Integer = 0,
                                 Optional y As Integer = 0,
                                 Optional Verso As enDirezione = enDirezione.Sopra,
                                 Optional BordoColore As String = "#000000",
                                 Optional BordoSpessore As Integer = 2,
                                 Optional Delta As Integer = 5,
                                 Optional Linguetta As Integer = 0) As String

        '<polyline class="ﬁl0 str0" points="(X_P4),(Y_P4) (X_P3),(Y_P3) (X_P2),(Y_P2) (X_P1),(Y_P1) "/>
        '<polyline class="ﬁl0 str0" points="10000,0 9000,5000 1000,5000 0,0 "/>
        Dim ris As String = String.Empty

        ris &= "<polyline "
        ris &= " Style = ""fill:none;stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";"""
        ris &= " points="""
        If Verso = enDirezione.Sopra Then
            ris &= x + Delta & "," & y & " "
            ris &= x + w - Delta & "," & y & " "
            If Linguetta Then ris &= x + w & "," & y + Linguetta & " "
            ris &= x + w & "," & h + y & " "
            ris &= x & "," & y + h & " "
            If Linguetta Then ris &= x & "," & y + Linguetta & " "
            ris &= x + Delta & "," & y & " "
        ElseIf Verso = enDirezione.Sotto Then
            ris &= x & "," & y & " "
            ris &= x + w & "," & y & " "
            If Linguetta Then ris &= x + w & "," & y + h - Linguetta & " "
            ris &= x + w - Delta & "," & h + y & " "
            ris &= x + Delta & "," & y + h & " "
            If Linguetta Then ris &= x & "," & y + h - Linguetta & " "
            ris &= x & "," & y & " "
        ElseIf Verso = enDirezione.Sinistra Then
            ris &= x & "," & y + Delta & " "
            If Linguetta Then ris &= x + Linguetta & "," & y & " "
            ris &= x + w & "," & y & " "
            ris &= x + w & "," & h + y & " "
            If Linguetta Then ris &= x + Linguetta & "," & y + h & " "
            ris &= x & "," & y + h - Delta & " "
            ris &= x & "," & y + Delta & " "
        ElseIf Verso = enDirezione.Destra Then
            ris &= x & "," & y & " "
            If Linguetta Then ris &= x + w - Linguetta & "," & y & " "
            ris &= x + w & "," & y + Delta & " "
            ris &= x + w & "," & h + y - Delta & " "
            If Linguetta Then ris &= x + w - Linguetta & "," & y + h & " "
            ris &= x & "," & y + h & " "
            ris &= x & "," & y & " "
        End If

        ris &= """/>"
        Return ris

    End Function

    Private Shared Function DrawRettangolo(w As Integer,
                                    h As Integer,
                                    Optional x As Integer = 0,
                                    Optional y As Integer = 0,
                                    Optional BordoColore As String = "#000000",
                                    Optional BordoSpessore As Integer = 2,
                                    Optional Opzioni As String = "",
                                    Optional TranslaX As Integer = 0,
                                    Optional TranslaY As Integer = 0,
                                    Optional ColoreRiempimento As String = "none",
                                    Optional ArrotondaBordo As Integer = 0,
                                    Optional Testo As String = "") As String

        Dim ris As String = String.Empty

        ris &= "<rect "
        ris &= " style=""fill:" & ColoreRiempimento & ";stroke:" & BordoColore & ";stroke-width:" & BordoSpessore & ";" & Opzioni & """"
        If TranslaX Then ris &= " transform=""skewX(" & TranslaX & ")"""
        If TranslaY Then ris &= " transform=""skewY(" & TranslaY & ")"""
        ris &= " width=""" & w & """ "
        ris &= " height=""" & h & """ "
        ris &= " x=""" & x & """ "
        ris &= " y=""" & y & """ "

        If ArrotondaBordo Then
            ris &= " rx=""" & ArrotondaBordo & """ "
            ris &= " ry=""" & ArrotondaBordo & """ "
        End If

        ris &= " />"
        If Testo.Length Then
            'y è fisso 
            'x lo giro in base alla larghezza del testo. 2 punti ogni carattere
            Dim Shifting As Integer = 0
            Dim posX As Integer = 0
            Dim PosY As Integer = 0
            Shifting = Testo.Length * 4
            'Shifting = Math.Ceiling(Shifting)
            posX = x + (w / 2) - Shifting
            PosY = y + (h / 2) + 6
            If posX < 0 Then posX = 0



            ris &= "<text x=""" & posX & """ y=""" & PosY & """ fill=""red"" font-size=""12"" font-weight=""bold"">" & Testo & "</text>"
            'ris &= "<image xlink:href=""" & UrlImgCentered & """  x=""0"" y=""0"" height=""50px"" width=""50px""/>"

        End If
        Return ris

    End Function

End Class
