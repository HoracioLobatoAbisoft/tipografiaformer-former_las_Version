Imports FormerDALWeb
Imports FormerGraphics
Imports FormerLib.FormerEnum

Public Class ucBoxCorpoLavoro
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Property Ordine As IOrdineBox

    Public Function GetImgFormatoSVG() As String
        Dim ris As String = String.Empty
        Dim IdPluginToUse As Integer = Ordine.ListinoBase.Preventivazione.IdPluginToUse
        If IdPluginToUse = enPluginOnline.Packaging Then

            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(Ordine.ListinoBase.Preventivazione,
                                                                                    Ordine.Altezza,
                                                                                    Ordine.Base,
                                                                                    Ordine.Profondita,
                                                                                    100)
            ris = Rsteso.BufferSVG
        ElseIf IdPluginToUse = enPluginOnline.Etichette OrElse IdPluginToUse = enPluginOnline.EtichetteCm Then
            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(Ordine.ListinoBase.Preventivazione,
                                                                                    Ordine.Altezza,
                                                                                    Ordine.Base,
                                                                                    enTipoFormaEtichetta.Custom,
                                                                                    100)

            ris = Rsteso.BufferSVG
        ElseIf Ordine.ListinoBase.idGruppoLogico <> 0 Or Ordine.ListinoBase.AllowCustomSize = enSiNo.Si Then
            ' se arriva qui non serve controllare altro
            Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgEtichetteSteso(Ordine.ListinoBase.Preventivazione,
                                                                                    Ordine.Altezza,
                                                                                    Ordine.Base,
                                                                                    enTipoFormaEtichetta.Custom,
                                                                                    100)
            ris = Rsteso.BufferSVG
        End If
        Return ris
    End Function

    Public Function ShowSVG() As Boolean
        Dim ris As Boolean = False
        Dim IdPluginToUse As Integer = Ordine.ListinoBase.Preventivazione.IdPluginToUse
        If IdPluginToUse Then
            If Ordine.IdTipoFustella = 0 Then
                ris = True
            End If
        ElseIf Ordine.ListinoBase.idGruppoLogico Or Ordine.ListinoBase.AllowCustomSize = enSiNo.Si Then
            If (Ordine.Base <> 0 AndAlso Ordine.Altezza <> 0) And (Ordine.ListinoBase.FormatoProdotto.Larghezza <> Ordine.Base Or Ordine.ListinoBase.FormatoProdotto.Lunghezza <> Ordine.Altezza) And
                (Ordine.ListinoBase.FormatoProdotto.Larghezza <> Ordine.Altezza Or Ordine.ListinoBase.FormatoProdotto.Lunghezza <> Ordine.Base) Then
                ris = True
            End If
        End If

        'If P.IdPluginToUse = enPluginOnline.Packaging Then
        '    Dim R As RisultatoPluginPackaging = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging))
        '    If Not R Is Nothing Then
        '        ris = True
        '    End If
        'ElseIf P.IdPluginToUse = enPluginOnline.Etichette Then
        '    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Etichette))
        '    If Not R Is Nothing Then
        '        If R.IdTipoFustella = 0 Then
        '            ris = True
        '        End If

        '    End If
        'ElseIf P.IdPluginToUse = enPluginOnline.EtichetteCm Then
        '    Dim R As RisultatoPluginEtichette = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.EtichetteCm))
        '    If Not R Is Nothing Then
        '        If R.IdTipoFustella = 0 Then
        '            ris = True
        '        End If
        '    End If
        'ElseIf LRif.idGruppoLogico <> 0 Or LRif.AllowCustomSize = enSiNo.Si Then
        '    Dim R As RisultatoPluginMisurePersonalizzate = Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.MisurePersonalizzate))
        '    If Not R Is Nothing Then
        '        ris = True
        '    End If
        'End If
        Return ris
    End Function

End Class