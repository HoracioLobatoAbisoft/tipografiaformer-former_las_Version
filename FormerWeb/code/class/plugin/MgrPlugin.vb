Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports System.Web.Routing
Imports FormerBusinessLogicInterface
Imports FormerGraphics

Public Class MgrPlugin

    Shared Sub New()

        'precarico i plugin

        'PACKAGING
        Dim FPack As New FormerPlugin
        FPack.Nome = "Packaging"
        FPack.Tipo = enPluginOnline.Packaging
        FPack.StepWizard = enStepWizard.FormatoProdotto
        FPack.Firma = "pluginPackagingRis"
        FPack.Route = RouteTable.Routes("pluginPackaging")

        Plugins.Add(FPack)

        Dim FEtichette As New FormerPlugin
        FEtichette.Nome = "Etichette"
        FEtichette.Tipo = enPluginOnline.Etichette
        FEtichette.StepWizard = enStepWizard.FormatoProdotto
        FEtichette.Firma = "pluginEtichetteRis"
        FEtichette.Route = RouteTable.Routes("pluginEtichetteStep1")

        Plugins.Add(FEtichette)

        Dim FEtichetteCm As New FormerPlugin
        FEtichetteCm.Nome = "EtichetteCm"
        FEtichetteCm.Tipo = enPluginOnline.EtichetteCm
        FEtichetteCm.StepWizard = enStepWizard.FormatoProdotto
        FEtichetteCm.Firma = "pluginEtichetteCmRis"
        FEtichetteCm.Route = RouteTable.Routes("pluginEtichetteCm")

        Plugins.Add(FEtichetteCm)

        Dim FMisurePersonalizzate As New FormerPlugin
        FMisurePersonalizzate.Nome = "MisurePersonalizzate"
        FMisurePersonalizzate.Tipo = enPluginOnline.MisurePersonalizzate
        FMisurePersonalizzate.StepWizard = enStepWizard.Prodotto
        FMisurePersonalizzate.Firma = "pluginMisurePersonalizzate"
        FMisurePersonalizzate.ResetAtStart = False
        'FMisurePersonalizzate.Route = RouteTable.Routes("pluginEtichetteCm")

        Plugins.Add(FMisurePersonalizzate)


    End Sub

    Private Shared Plugins As New List(Of FormerPlugin)

    'Public Shared Function FustelleCompatibili(P As PreventivazioneW,
    '                                           Base As Integer,
    '                                           Profondita As Integer,
    '                                           Altezza As Integer,
    '                                           lst As List(Of TipoFustellaW)) As List(Of TipoFustellaW)

    '    Dim DiffMax As Integer = 5
    '    Dim ris As New List(Of TipoFustellaW)

    '    For Each F As TipoFustellaW In lst
    '        Dim Compatibile As Boolean = True
    '        If Profondita Then
    '            If Math.Abs(F.Profondita - Profondita) > DiffMax Then
    '                Compatibile = False
    '            End If
    '        End If
    '        If Altezza Then
    '            If Math.Abs(F.Altezza - Altezza) > DiffMax Then
    '                Compatibile = False
    '            End If
    '        End If
    '        If Base Then
    '            If Math.Abs(F.Base - Base) > DiffMax Then
    '                Compatibile = False
    '            End If
    '        End If
    '        If Compatibile Then
    '            F.FillSVG(P, FormerWebApp.BrowserCompatibileSVG)

    '            'Dim mgr As New MgrPackagingDraw
    '            'Dim Buffer As String = String.Empty
    '            'Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
    '            'If FormerWebApp.BrowserCompatibileSVG Then
    '            '    Buffer = Rsteso.BufferSVG
    '            'Else
    '            '    Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
    '            'End If
    '            'F.RisultatoStesoAltezza = Rsteso.Heigth
    '            'F.RisultatoStesoBase = Rsteso.Width
    '            'F.SvgRender = Buffer
    '            ris.Add(F)
    '        End If
    '    Next

    '    Dim AggiungiPersonalizzata As Boolean = False

    '    If Profondita <> 0 Then
    '        If ris.FindAll(Function(x) x.Profondita = Profondita).Count = 0 Then
    '            AggiungiPersonalizzata = True
    '        End If
    '    End If

    '    If AggiungiPersonalizzata = False AndAlso Altezza <> 0 Then
    '        If ris.FindAll(Function(x) x.Altezza = Altezza).Count = 0 Then
    '            AggiungiPersonalizzata = True
    '        End If
    '    End If

    '    If AggiungiPersonalizzata = False AndAlso Base <> 0 Then
    '        If ris.FindAll(Function(x) x.Base = Base).Count = 0 Then
    '            AggiungiPersonalizzata = True
    '        End If
    '    End If

    '    'prima di aggiuyngere la personalizzata se ho tuitti e tre i valori vedo se entra
    '    If AggiungiPersonalizzata AndAlso (Base <> 0 And Altezza <> 0 And Profondita <> 0) Then
    '        Dim r As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(P, Altezza, Base, Profondita)

    '        If r.ListiniBase.Count = 0 Then
    '            AggiungiPersonalizzata = False
    '        End If

    '    End If

    '    If AggiungiPersonalizzata Then
    '        Dim F As New TipoFustellaW
    '        F.Profondita = Profondita
    '        F.Base = Base
    '        F.Altezza = Altezza

    '        F.FillSVG(P, FormerWebApp.BrowserCompatibileSVG)
    '        'Dim Buffer As String = String.Empty
    '        'If Base <> 0 And Altezza <> 0 And Profondita <> 0 Then
    '        '    Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
    '        '    If FormerWebApp.BrowserCompatibileSVG Then
    '        '        Buffer = Rsteso.BufferSVG
    '        '    Else
    '        '        Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
    '        '    End If
    '        '    F.RisultatoStesoAltezza = Rsteso.Heigth
    '        '    F.RisultatoStesoBase = Rsteso.Width
    '        'Else
    '        '    Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
    '        'End If

    '        'F.SvgRender = Buffer
    '        ris.Add(F)
    '    End If

    '    'ora qui ho tutte le compatibili, le ordini sempre per base che e' il primo parametro
    '    ris.Sort(AddressOf ComparerTipoFustella)

    '    Return ris

    'End Function



    Public Shared Function GetRisPlugin(Fp As FormerPlugin) As RisultatoPlugin
        Dim R As RisultatoPlugin = Nothing
        Try
            R = HttpContext.Current.Session(Fp.Firma)
            If R Is Nothing Then
                If Fp.Tipo = enPluginOnline.Packaging Then
                    CreaRisPluginEmpty()
                End If
            End If
        Catch ex As Exception

        End Try
        Return R
    End Function

    Public Shared Function GetIdPluginToUse(P As PreventivazioneW) As enPluginOnline
        Dim Ris As enPluginOnline = enPluginOnline.Nessuno
        Try
            Ris = P.IdPluginToUse
        Catch ex As Exception

        End Try
        Return Ris
    End Function

    Public Shared Function GetPlugin(P As PreventivazioneW,
                                     Optional StepWizard As enStepWizard = enStepWizard.Nessuno) As FormerPlugin
        Dim ris As FormerPlugin = Nothing

        Dim PluginToUse As enPluginOnline

        PluginToUse = GetIdPluginToUse(P)

        If PluginToUse Then
            Dim fp As FormerPlugin = Plugins.Find(Function(x) x.Tipo = PluginToUse)

            If StepWizard <> enStepWizard.Nessuno Then
                If fp.StepWizard <> StepWizard Then
                    fp = Nothing
                End If
            End If

            ris = fp
        End If

        Return ris
    End Function

    Public Shared Sub EditPluginRisFP(P As PreventivazioneW,
                                    IdFP As Integer)

        Dim PluginToUse As enPluginOnline

        PluginToUse = GetIdPluginToUse(P)
        Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = PluginToUse)
        Dim r As RisultatoPluginPackaging = HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse))

        If Not r Is Nothing Then
            r.IdFormatoProdottoScelto = IdFP
            HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse)) = r
        End If

    End Sub

    Public Shared Sub EditPluginRis(P As PreventivazioneW,
                                    IdTipoFustella As Integer)

        Dim PluginToUse As enPluginOnline

        PluginToUse = GetIdPluginToUse(P)
        Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = PluginToUse)
        Dim r As RisultatoPluginPackaging = HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse))

        If Not r Is Nothing Then
            r.IdTipoFustella = IdTipoFustella
            HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse)) = r
        End If

    End Sub

    Public Shared Sub EditPluginRis(P As PreventivazioneW,
                                    Valore As Integer,
                                    Asse As enAsseXYZ)
        Dim PluginToUse As enPluginOnline

        PluginToUse = GetIdPluginToUse(P)
        Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = PluginToUse)
        Dim r As RisultatoPluginPackaging = HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse))
        If Not r Is Nothing Then
            Select Case Asse
                Case enAsseXYZ.Altezza
                    r.Altezza = Valore
                Case enAsseXYZ.Base
                    r.Base = Valore
                Case enAsseXYZ.Profondita
                    r.Profondita = Valore
            End Select

            'qui se tutti i valori sono validi vado a ricostruire il disegno
            If r.Base <> 0 And r.Altezza <> 0 And r.Profondita <> 0 Then
                Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, r.Altezza, r.Base, r.Profondita, 128)
                If FormerWebApp.BrowserCompatibileSVG Then
                    r.BufferSVG = Rsteso.BufferSVG
                Else
                    r.BufferSVG = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
                End If
            End If

            HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(PluginToUse)) = r
        End If

    End Sub

    Private Shared Sub CreaRisPluginEmpty()
        Dim R As New RisultatoPluginPackaging

        R.Altezza = 0 'ValidaDimensione(Altezza, enAsseXYZ.Altezza)
        R.Base = 0 'ValidaDimensione(Base, enAsseXYZ.Base)
        R.Profondita = 0 ' ValidaDimensione(Profondita, enAsseXYZ.Profondita)
        R.IdFormatoProdottoScelto = 0 'IdFormatoProdotto
        R.IdTipoFustella = 0 'IdTipoFustella
        R.NomeInUrl = "inserisci-le-misure" '"Misure-" & R.Base & "x" & R.Profondita & "x" & R.Altezza
        'Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, R.Altezza, R.Base, R.Profondita, 128)

        'R.BufferSVG = Rsteso.BufferSVG

        HttpContext.Current.Session(MgrPlugin.GetFirmaPlugin(enPluginOnline.Packaging)) = R
    End Sub

    Public Shared Sub CheckNeedPlugin(P As PreventivazioneW,
                                      StepAttuale As enStepWizard)

        'controllo se la preventviazione prevede un plugin e se in sessione c'e' gia il risultato 
        'in tal caso ti rimanda li 
        Dim GoUrl As String = String.Empty
        Dim PluginToUse As enPluginOnline

        PluginToUse = GetIdPluginToUse(P)

        If PluginToUse Then
            Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = PluginToUse)
            If FP.StepWizard = StepAttuale OrElse GetRisPlugin(FP) Is Nothing Then
                'qui devo andare alla pagina del plugin
                If PluginToUse = enPluginOnline.Packaging Then
                    CreaRisPluginEmpty()
                Else
                    GoUrl = "/" & FP.Route.Url.Replace("{idp}", P.IdPrev)
                End If

            End If
        Else
            ClearPlugin()
        End If

        'Select Case PluginToUse
        '    Case enFormerPlugin.Packaging
        '        Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = enFormerPlugin.Packaging)
        '        If FP.StepWizard = StepAttuale OrElse HttpContext.Current.Session(FP.Firma) Is Nothing Then
        '            'qui devo andare alla pagina del plugin
        '            GoUrl = "/" & FP.Route.Url.Replace("{idp}", P.IdPrev)
        '        End If
        '    Case Else
        '        ClearPlugin()
        'End Select

        If GoUrl.Length Then
            HttpContext.Current.Response.Redirect(GoUrl)
        End If

    End Sub

    Public Shared Function GetFirmaPlugin(TipoPlugin As enPluginOnline) As String

        Dim ris As String = String.Empty

        Dim FP As FormerPlugin = Plugins.Find(Function(x) x.Tipo = TipoPlugin)
        If Not FP Is Nothing Then
            ris = FP.Firma
        End If

        Return ris

    End Function

    Public Shared Sub ClearPlugin()
        For Each P As FormerPlugin In Plugins
            If P.ResetAtStart Then HttpContext.Current.Session(P.Firma) = Nothing
        Next
    End Sub

End Class
