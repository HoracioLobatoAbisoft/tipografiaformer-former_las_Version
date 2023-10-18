Imports FormerLib
Imports FormerDALSql
Imports FW = FormerDALWeb
Imports FormerPrinter
Imports FormerLib.FormerEnum
Imports System.Net
Imports System.IO
Imports System.Text
Imports FormerConfig
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports iTextSharp
Imports FormerWebLabeling
Imports FormerBancaSella
Imports System.Data.Common
Imports FDE = FormerDALEventi
Imports FormerListiniLib
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerIO
Imports System.Data.SqlClient
Imports ActiveUp.Net.Mail
Imports Microsoft.Win32
Imports MgrDocumentiFiscali = FormerBusinessLogic.MgrDocumentiFiscali
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Drawing.Imaging

Public Class frmMain
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        'SkinManager.AddFormToManage(Me)
        'SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        'SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800,
        '                                          Primary.BlueGrey900,
        '                                          Primary.BlueGrey500,
        '                                          Accent.LightBlue200,
        '                                          TextShade.WHITE)
    End Sub



    Private Function CheckCongruenzaPrezziLavorazione()
        Using mgr As New LavorazioniDAO
            Dim llav As List(Of Lavorazione) = mgr.GetAll
            Dim ListaIdLav As New List(Of String)
            For Each l In llav
                l.CaricaPrezzi()

                'qui sono ordinati per grandezza
                Dim pMin As PrezzoLavoro = l.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
                Dim pMax As PrezzoLavoro = l.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

                'cerco il prezzo sul meno piu piccolo e il meno piu grande
                Dim Lp As New List(Of PrezzoLavoro)
                Lp.AddRange(l.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
                'Lp.AddRange(L.Prezzi)
                If Lp.Count Then
                    Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
                End If

                If Not pMin Is Nothing Then Lp.Insert(0, pMin)
                If Not pMax Is Nothing Then Lp.Insert(Lp.Count, pMax)

                Dim ValorePrecedente As Decimal = 0

                For Each voce In Lp
                    If voce.Prezzo >= ValorePrecedente Then
                        'tutto ok
                        ValorePrecedente = voce.Prezzo
                    Else
                        'anomalia
                        ListaIdLav.Add(voce.IdLavoro & " " & l.Descrizione)
                        Exit For
                    End If
                Next
            Next

            MessageBox.Show(ListaIdLav.Count)
            For Each voce In ListaIdLav
                txtDebug.AppendText(voce & ControlChars.NewLine)
            Next

        End Using

    End Function

    Private Function CheckCongruenzaPrezziLavorazione(IdLav As Integer)

        Using L As New Lavorazione
            L.Read(IdLav)

            L.CaricaPrezzi()

            'qui sono ordinati per grandezza
            Dim pMin As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
            Dim pMax As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

            'cerco il prezzo sul meno piu piccolo e il meno piu grande
            Dim Lp As New List(Of PrezzoLavoro)
            Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
            'Lp.AddRange(L.Prezzi)
            If Lp.Count Then
                Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
            End If

            If Not pMin Is Nothing Then Lp.Insert(0, pMin)
            If Not pMax Is Nothing Then Lp.Insert(Lp.Count, pMax)

            Dim ValorePrecedente As Decimal = 0
            Dim ListaIdLav As New List(Of Integer)
            For Each voce In Lp
                If voce.Prezzo >= ValorePrecedente Then
                    'tutto ok
                    ValorePrecedente = voce.Prezzo
                Else
                    'anomalia
                    ListaIdLav.Add(voce.IdLavoro)
                End If
            Next

        End Using

    End Function




    Private Function TestCalcoloLavorazioni(IdLav As Integer,
                                            DimXmm As Integer,
                                            DimYmm As Integer) As RisCalcoloPrezzoIntermedioLavorazioni
        Dim Ris As New RisCalcoloPrezzoIntermedioLavorazioni

        Using L As New Lavorazione
            L.Read(IdLav)
            'Dim Calcolabile As Boolean = True
            'If (DimXmm < L.DimensMinW And DimXmm < L.DimensMinH) Or (DimYmm < L.DimensMinW And DimYmm < L.DimensMinH) Then
            '    qui non posso calcolare la lavorazione
            '    Calcolabile = False
            'End If

            'If (DimXmm > L.DimensMaxW And DimXmm > L.DimensMaxH) Or (DimYmm > L.DimensMaxW And DimYmm > L.DimensMaxH) Then
            '    qui non posso calcolare la lavorazione
            '    Calcolabile = False
            'End If
            'Dim Calcolabile As Boolean = False
            'If (DimXmm >= L.DimensMinW And DimYmm >= L.DimensMinH) Or (DimYmm >= L.DimensMinW And DimXmm >= L.DimensMinH) Then
            '    'qui non posso calcolare la lavorazione
            '    Calcolabile = True
            'End If
            'If Calcolabile Then
            '    If (DimXmm <= L.DimensMaxW And DimYmm <= L.DimensMaxH) Or (DimYmm <= L.DimensMaxW And DimXmm <= L.DimensMaxH) Then
            '        'qui non posso calcolare la lavorazione
            '        Calcolabile = True
            '    Else
            '        Calcolabile = False
            '    End If
            'End If


            'If Calcolabile Then
            '    L.CaricaPrezzi()

            '    Dim pMin As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
            '    Dim pMax As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

            '    Dim cm2Min As Integer = Math.Ceiling(L.DimensMinW * L.DimensMinH) / 10
            '    Dim cm2Max As Integer = Math.Ceiling(L.DimensMaxW * L.DimensMaxH) / 10

            '    Dim cm2Sviluppati As Integer = (DimXmm * DimYmm) / 10
            '    Dim DeltaCm As Integer = cm2Sviluppati - cm2Min

            '    Dim PrezzoCm2Max As Decimal = pMax.Prezzo / cm2Max
            '    Dim PrezzoSuGenerici As Decimal = pMin.Prezzo + (DeltaCm * PrezzoCm2Max)
            '    Dim PrezzoSuSpecifici As Decimal = 0

            '    'cerco il prezzo sul meno piu piccolo e il meno piu grande
            '    Dim Lp As New List(Of PrezzoLavoro)
            '    'Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
            '    Lp.AddRange(L.Prezzi)
            '    If Lp.Count Then
            '        Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
            '    End If

            '    Dim pPrima As PrezzoLavoro = Nothing
            '    Dim pDopo As PrezzoLavoro = Nothing

            '    For Each p As PrezzoLavoro In Lp
            '        'qui trovo il meno piu piccolo e il meno piu grande
            '        If (p.FormatoProdotto.Larghezza <= DimXmm And p.FormatoProdotto.Lunghezza <= DimYmm) And (p.FormatoProdotto.Larghezza <= DimXmm And p.FormatoProdotto.Lunghezza <= DimYmm) Then
            '            pPrima = p 'meno piu piccolo
            '        End If

            '        If (p.FormatoProdotto.Larghezza < DimXmm And p.FormatoProdotto.Lunghezza < DimYmm) And (p.FormatoProdotto.Larghezza < DimXmm And p.FormatoProdotto.Lunghezza < DimYmm) Then
            '            pDopo = p 'meno piu grande
            '        End If

            '    Next

            '    'MgrPreventivazioneB.CalcolaPrezzoLavorazione()

            '    'Ris = pMin.Prezzo + (DeltaCm * PrezzoCm2Max)
            '    If PrezzoSuGenerici > PrezzoSuSpecifici Then
            '        Ris = PrezzoSuGenerici
            '    Else
            '        Ris = PrezzoSuSpecifici
            '    End If
            'Else
            '    Ris = -1
            'End If

            'If Calcolabile Then
            L.CaricaPrezzi()

                Dim pMin As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
                Dim pMax As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

                'cerco il prezzo sul meno piu piccolo e il meno piu grande
                Dim Lp As New List(Of PrezzoLavoro)
                Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
                'Lp.AddRange(L.Prezzi)
                If Lp.Count Then
                    Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
                End If

                Lp.Insert(0, pMin)
                Lp.Insert(Lp.Count, pMax)

                Dim pPrima As PrezzoLavoro = Nothing
                Dim pDopo As PrezzoLavoro = Nothing

                For Each p As PrezzoLavoro In Lp
                    Dim Larghezza As Integer = 0
                    Dim Altezza As Integer = 0

                    If p.IdFormProd Then
                        Larghezza = p.FormatoProdotto.Larghezza
                        Altezza = p.FormatoProdotto.Lunghezza
                    Else
                        If p.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                            Larghezza = L.DimensMinW
                            Altezza = L.DimensMinH
                        ElseIf p.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande Then
                            Larghezza = L.DimensMaxW
                            Altezza = L.DimensMaxH
                        End If

                    End If

                    Dim AreaFp As Integer = Larghezza * Altezza
                    Dim AreaRic As Integer = DimXmm * DimYmm

                    If AreaFp <= AreaRic Then
                        pPrima = p
                    End If
                    If pDopo Is Nothing Then
                        If AreaFp > AreaRic Then
                            pDopo = p
                        End If
                    End If

                Next

                Dim PrezzoCalcolato As Decimal = 0

                If Not pPrima Is Nothing AndAlso Not pDopo Is Nothing Then
                    Dim cm2Min As Integer = 0
                    Dim cm2Max As Integer = 0

                    Dim LarghezzaPrima As Integer = 0
                    Dim AltezzaPrima As Integer = 0

                    Dim LarghezzaDopo As Integer = 0
                    Dim AltezzaDopo As Integer = 0

                    If pPrima.IdFormProd Then
                        LarghezzaPrima = pPrima.FormatoProdotto.Larghezza
                        AltezzaPrima = pPrima.FormatoProdotto.Lunghezza
                    Else
                        LarghezzaPrima = L.DimensMinW
                        AltezzaPrima = L.DimensMinH
                    End If

                    If pDopo.IdFormProd Then
                        LarghezzaDopo = pDopo.FormatoProdotto.Larghezza
                        AltezzaDopo = pDopo.FormatoProdotto.Lunghezza
                    Else
                        LarghezzaDopo = L.DimensMaxW
                        AltezzaDopo = L.DimensMaxH
                    End If

                    cm2Min = Math.Ceiling(LarghezzaPrima * AltezzaPrima) / 10
                    cm2Max = Math.Ceiling(LarghezzaDopo * AltezzaDopo) / 10

                    Dim cm2Sviluppati As Integer = (DimXmm * DimYmm) / 10
                    Dim DeltaCm As Integer = cm2Sviluppati - cm2Min

                    Dim PrezzoCm2Max As Decimal = pDopo.Prezzo / cm2Max

                    Dim DiffPrezzo As Single = pDopo.Prezzo - pPrima.Prezzo
                    Dim DiffQta As Integer = cm2Max - cm2Min

                    Dim Incr As Double = DiffPrezzo / DiffQta

                    PrezzoCalcolato = (DeltaCm * Incr) + pPrima.Prezzo

                    Ris.RifPrezzoPrima = pPrima
                    Ris.RifPrezzoDopo = pDopo

                    'MgrPreventivazioneB.CalcolaPrezzoLavorazione()
                End If

                Ris.Prezzo = PrezzoCalcolato

            'Else
            'Ris.Prezzo = -1
            'End If

        End Using

        Return Ris

    End Function
    'Private Function TestCalcoloLavorazioni(IdLav As Integer,
    '                                        DimXmm As Integer,
    '                                        DimYmm As Integer) As RisCalcoloPrezzoIntermedioLavorazioni
    '    Dim Ris As New RisCalcoloPrezzoIntermedioLavorazioni

    '    Using L As New Lavorazione
    '        L.Read(IdLav)
    '        'Dim Calcolabile As Boolean = True
    '        'If (DimXmm < L.DimensMinW And DimXmm < L.DimensMinH) Or (DimYmm < L.DimensMinW And DimYmm < L.DimensMinH) Then
    '        '    qui non posso calcolare la lavorazione
    '        '    Calcolabile = False
    '        'End If

    '        'If (DimXmm > L.DimensMaxW And DimXmm > L.DimensMaxH) Or (DimYmm > L.DimensMaxW And DimYmm > L.DimensMaxH) Then
    '        '    qui non posso calcolare la lavorazione
    '        '    Calcolabile = False
    '        'End If
    '        Dim Calcolabile As Boolean = False
    '        If (DimXmm >= L.DimensMinW And DimYmm >= L.DimensMinH) Or (DimYmm >= L.DimensMinW And DimXmm >= L.DimensMinH) Then
    '            'qui non posso calcolare la lavorazione
    '            Calcolabile = True
    '        End If
    '        If Calcolabile Then
    '            If (DimXmm <= L.DimensMaxW And DimYmm <= L.DimensMaxH) Or (DimYmm <= L.DimensMaxW And DimXmm <= L.DimensMaxH) Then
    '                'qui non posso calcolare la lavorazione
    '                Calcolabile = True
    '            Else
    '                Calcolabile = False
    '            End If
    '        End If


    '        'If Calcolabile Then
    '        '    L.CaricaPrezzi()

    '        '    Dim pMin As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
    '        '    Dim pMax As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

    '        '    Dim cm2Min As Integer = Math.Ceiling(L.DimensMinW * L.DimensMinH) / 10
    '        '    Dim cm2Max As Integer = Math.Ceiling(L.DimensMaxW * L.DimensMaxH) / 10

    '        '    Dim cm2Sviluppati As Integer = (DimXmm * DimYmm) / 10
    '        '    Dim DeltaCm As Integer = cm2Sviluppati - cm2Min

    '        '    Dim PrezzoCm2Max As Decimal = pMax.Prezzo / cm2Max
    '        '    Dim PrezzoSuGenerici As Decimal = pMin.Prezzo + (DeltaCm * PrezzoCm2Max)
    '        '    Dim PrezzoSuSpecifici As Decimal = 0

    '        '    'cerco il prezzo sul meno piu piccolo e il meno piu grande
    '        '    Dim Lp As New List(Of PrezzoLavoro)
    '        '    'Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
    '        '    Lp.AddRange(L.Prezzi)
    '        '    If Lp.Count Then
    '        '        Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
    '        '    End If

    '        '    Dim pPrima As PrezzoLavoro = Nothing
    '        '    Dim pDopo As PrezzoLavoro = Nothing

    '        '    For Each p As PrezzoLavoro In Lp
    '        '        'qui trovo il meno piu piccolo e il meno piu grande
    '        '        If (p.FormatoProdotto.Larghezza <= DimXmm And p.FormatoProdotto.Lunghezza <= DimYmm) And (p.FormatoProdotto.Larghezza <= DimXmm And p.FormatoProdotto.Lunghezza <= DimYmm) Then
    '        '            pPrima = p 'meno piu piccolo
    '        '        End If

    '        '        If (p.FormatoProdotto.Larghezza < DimXmm And p.FormatoProdotto.Lunghezza < DimYmm) And (p.FormatoProdotto.Larghezza < DimXmm And p.FormatoProdotto.Lunghezza < DimYmm) Then
    '        '            pDopo = p 'meno piu grande
    '        '        End If

    '        '    Next

    '        '    'MgrPreventivazioneB.CalcolaPrezzoLavorazione()

    '        '    'Ris = pMin.Prezzo + (DeltaCm * PrezzoCm2Max)
    '        '    If PrezzoSuGenerici > PrezzoSuSpecifici Then
    '        '        Ris = PrezzoSuGenerici
    '        '    Else
    '        '        Ris = PrezzoSuSpecifici
    '        '    End If
    '        'Else
    '        '    Ris = -1
    '        'End If

    '        If Calcolabile Then
    '            L.CaricaPrezzi()

    '            Dim pMin As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
    '            Dim pMax As PrezzoLavoro = L.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

    '            'cerco il prezzo sul meno piu piccolo e il meno piu grande
    '            Dim Lp As New List(Of PrezzoLavoro)
    '            Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
    '            'Lp.AddRange(L.Prezzi)
    '            If Lp.Count Then
    '                Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
    '            End If

    '            Lp.Insert(0, pMin)
    '            Lp.Insert(Lp.Count, pMax)

    '            Dim pPrima As PrezzoLavoro = Nothing
    '            Dim pDopo As PrezzoLavoro = Nothing

    '            For Each p As PrezzoLavoro In Lp
    '                Dim Larghezza As Integer = 0
    '                Dim Altezza As Integer = 0

    '                If p.IdFormProd Then
    '                    Larghezza = p.FormatoProdotto.Larghezza
    '                    Altezza = p.FormatoProdotto.Lunghezza
    '                Else
    '                    If p.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
    '                        Larghezza = L.DimensMinW
    '                        Altezza = L.DimensMinH
    '                    ElseIf p.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande Then
    '                        Larghezza = L.DimensMaxW
    '                        Altezza = L.DimensMaxH
    '                    End If

    '                End If

    '                Dim AreaFp As Integer = Larghezza * Altezza
    '                Dim AreaRic As Integer = DimXmm * DimYmm

    '                If AreaFp <= AreaRic Then
    '                    pPrima = p
    '                End If
    '                If pDopo Is Nothing Then
    '                    If AreaFp > AreaRic Then
    '                        pDopo = p
    '                    End If
    '                End If

    '            Next

    '            Dim PrezzoCalcolato As Decimal = 0

    '            If Not pPrima Is Nothing AndAlso Not pDopo Is Nothing Then
    '                Dim cm2Min As Integer = 0
    '                Dim cm2Max As Integer = 0

    '                Dim LarghezzaPrima As Integer = 0
    '                Dim AltezzaPrima As Integer = 0

    '                Dim LarghezzaDopo As Integer = 0
    '                Dim AltezzaDopo As Integer = 0

    '                If pPrima.IdFormProd Then
    '                    LarghezzaPrima = pPrima.FormatoProdotto.Larghezza
    '                    AltezzaPrima = pPrima.FormatoProdotto.Lunghezza
    '                Else
    '                    LarghezzaPrima = L.DimensMinW
    '                    AltezzaPrima = L.DimensMinH
    '                End If

    '                If pDopo.IdFormProd Then
    '                    LarghezzaDopo = pDopo.FormatoProdotto.Larghezza
    '                    AltezzaDopo = pDopo.FormatoProdotto.Lunghezza
    '                Else
    '                    LarghezzaDopo = L.DimensMaxW
    '                    AltezzaDopo = L.DimensMaxH
    '                End If

    '                cm2Min = Math.Ceiling(LarghezzaPrima * AltezzaPrima) / 10
    '                cm2Max = Math.Ceiling(LarghezzaDopo * AltezzaDopo) / 10

    '                Dim cm2Sviluppati As Integer = (DimXmm * DimYmm) / 10
    '                Dim DeltaCm As Integer = cm2Sviluppati - cm2Min

    '                Dim PrezzoCm2Max As Decimal = pDopo.Prezzo / cm2Max

    '                Dim DiffPrezzo As Single = pDopo.Prezzo - pPrima.Prezzo
    '                Dim DiffQta As Integer = cm2Max - cm2Min

    '                Dim Incr As Double = DiffPrezzo / DiffQta

    '                PrezzoCalcolato = (DeltaCm * Incr) + pPrima.Prezzo

    '                Ris.RifPrezzoPrima = pPrima
    '                Ris.RifPrezzoDopo = pDopo

    '                'MgrPreventivazioneB.CalcolaPrezzoLavorazione()
    '            End If

    '            Ris.Prezzo = PrezzoCalcolato

    '        Else
    '            Ris.Prezzo = -1
    '        End If

    '    End Using

    '    Return Ris

    'End Function

    Private Sub TentaCombinazioni()

        txtDebug.Text = String.Empty

        Dim l As New List(Of OrdineInSoluzione)

        Dim O1 As New OrdineInSoluzione
        O1.Ordine = New OrdineRicerca() With {.IdOrd = 1, .Qta = 500}
        'O.IdOrd = 1
        O1.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O1)

        Dim O2 As New OrdineInSoluzione
        O2.Ordine = New OrdineRicerca() With {.IdOrd = 2, .Qta = 500}
        'O.IdOrd = 1
        O2.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O2)

        Dim O3 As New OrdineInSoluzione
        O3.Ordine = New OrdineRicerca() With {.IdOrd = 3, .Qta = 500}
        'O.IdOrd = 1
        O3.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O3)

        Dim O4 As New OrdineInSoluzione
        O4.Ordine = New OrdineRicerca() With {.IdOrd = 4, .Qta = 1000}
        'O.IdOrd = 1
        O4.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O4)

        Dim O5 As New OrdineInSoluzione
        O5.Ordine = New OrdineRicerca() With {.IdOrd = 5, .Qta = 5000}
        'O.IdOrd = 1
        O5.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O5)

        Dim O6 As New OrdineInSoluzione
        O6.Ordine = New OrdineRicerca() With {.IdOrd = 6, .Qta = 1000}
        'O.IdOrd = 1
        O6.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O6)

        Dim O7 As New OrdineInSoluzione
        O7.Ordine = New OrdineRicerca() With {.IdOrd = 7, .Qta = 1000}
        'O.IdOrd = 1
        O7.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O7)

        Dim O8 As New OrdineInSoluzione
        O8.Ordine = New OrdineRicerca() With {.IdOrd = 8, .Qta = 1000}
        'O.IdOrd = 1
        O8.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O8)

        Dim O9 As New OrdineInSoluzione
        O9.Ordine = New OrdineRicerca() With {.IdOrd = 9, .Qta = 1000}
        'O.IdOrd = 1
        O9.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O9)

        Dim O10 As New OrdineInSoluzione
        O10.Ordine = New OrdineRicerca() With {.IdOrd = 10, .Qta = 1000}
        'O.IdOrd = 1
        O10.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O10)

        Dim O11 As New OrdineInSoluzione
        O11.Ordine = New OrdineRicerca() With {.IdOrd = 11, .Qta = 1000}
        'O.IdOrd = 1
        O11.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O11)

        Dim O12 As New OrdineInSoluzione
        O12.Ordine = New OrdineRicerca() With {.IdOrd = 12, .Qta = 1000}
        'O.IdOrd = 1
        O12.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O12)

        Dim O13 As New OrdineInSoluzione
        O13.Ordine = New OrdineRicerca() With {.IdOrd = 13, .Qta = 1000}
        'O.IdOrd = 1
        O13.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O13)

        Dim O14 As New OrdineInSoluzione
        O14.Ordine = New OrdineRicerca() With {.IdOrd = 14, .Qta = 1000}
        'O.IdOrd = 1
        O14.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O14)

        Dim O15 As New OrdineInSoluzione
        O15.Ordine = New OrdineRicerca() With {.IdOrd = 15, .Qta = 1000}
        'O.IdOrd = 1
        O15.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O15)

        Dim O16 As New OrdineInSoluzione
        O16.Ordine = New OrdineRicerca() With {.IdOrd = 16, .Qta = 1000}
        'O.IdOrd = 1
        O16.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O16)

        Dim O17 As New OrdineInSoluzione
        O17.Ordine = New OrdineRicerca() With {.IdOrd = 17, .Qta = 1000}
        'O.IdOrd = 1
        O17.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O17)

        Dim O18 As New OrdineInSoluzione
        O18.Ordine = New OrdineRicerca() With {.IdOrd = 18, .Qta = 1000}
        'O.IdOrd = 1
        O18.TiratoA = 500
        'O.QtaOrdine = 1000
        l.Add(O18)




        Dim mySubsets As New List(Of List(Of OrdineInSoluzione))

        'Dim LimiteMax As Integer = MaxSpazi
        'If MaxSpazi > lstOSpec.Count Then LimiteMax = lstOSpec.Count
        'l.Sort(Function(x, y) y.SpaziUsati.CompareTo(x.SpaziUsati))
        Dim Max As Integer = 25
        'For I As Integer = 2 To Max
        mySubsets = CombinationEx.GetSubsetsEx(l.ToArray, Max, New ParametriCreazioneSoluzione)
        'Next


        'Clear the display.
        'SORT DISATTIVATO CHE PER ORA NN MI SERVE
        'Combination.Sort(mySubsets)

        'Dim MaxSpazi As Integer = l.Sum(Function(x) x.SpaziUsati)

        'mySubsets = mySubsets.FindAll(Function(x) x.Sum(Function(y) y.SpaziUsati) <= 3)

        For Each s As Object In mySubsets
            Dim lstOrd As List(Of OrdineInSoluzione) = s

            For Each o As OrdineInSoluzione In lstOrd
                txtDebug.Text &= o.IdOrd & "-"
            Next
            txtDebug.Text &= ControlChars.NewLine
        Next

    End Sub

    Private IdUtenteDiego As Integer = 23

    Private Sub CaricaCostantiUDP()

        Dim constants As New List(Of ValoreCombo)
        Dim fieldInfos As FieldInfo() = GetType(FormerUDP).GetFields(BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.FlattenHierarchy)

        For Each fi As FieldInfo In fieldInfos
            If fi.Name.StartsWith("TipoUDP_") Then
                Dim Val As New ValoreCombo
                Val.Valore = fi.GetValue(Nothing)
                Val.Descrizione = fi.Name
                constants.Add(Val)
            End If
        Next

        cmbTipoUDP.DisplayMember = "Descrizione"
        cmbTipoUDP.ValueMember = "Valore"
        cmbTipoUDP.DataSource = constants

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMessage.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FormerUDP.SendUDPCommand(cmbTipoUDP.SelectedValue, txtMsg.Text)
            MessageBox.Show("Operazione effettuata")
        End If
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Destinatario As String = "ALL"
            If txtUtConnection.Text.Length Then Destinatario = txtUtConnection.Text
            FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Service, "DISCONNECT", Destinatario)
            MessageBox.Show("Operazione effettuata")
        End If
    End Sub

    Private Sub btnReconnect_Click(sender As Object, e As EventArgs) Handles btnReconnect.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Destinatario As String = "ALL"
            If txtUtConnection.Text.Length Then Destinatario = txtUtConnection.Text
            FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Service, "CONNECT", Destinatario)
            MessageBox.Show("Operazione effettuata")
        End If
    End Sub

    Private Sub btnCaller_Click(sender As Object, e As EventArgs) Handles btnCaller.Click

        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_CallerID, "3409253719", "diego")

    End Sub

    Private Sub btnTestPerformance_Click(sender As Object, e As EventArgs) Handles btnTestPerformance.Click

        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            '    Dim u As New Utente
            '    u.Login = "test" & (New Random()).Next(1000000000)
            '    ris = u.Save()

            'End Using

            'Dim u2 As New Utente
            'u2.Read(ris)
            'If u2.IdUt = 0 Then Stop

            ''u2.Login = "2test" & (New Random()).Next(1000000000)
            ''u2.Save()


            'Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\lavoro\source\former\test\former.mdb;Persist Security Info=False")
            'cn.Open()
            'Dim t As OleDb.OleDbTransaction = cn.BeginTransaction()
            'For j As Integer = 1 To 1


            '    Dim cm As OleDb.OleDbCommand = cn.CreateCommand
            '    Dim Nome As String = "testOLD" & (New Random()).Next(1000000000)
            '    Dim sql As String = "Insert into t_utenti(Login,pwd,NomeReale,RepDefault,tipo,attivo) values(@Login,@Pwd,@NomeReale,@RepDefault,@Attivo,@Tipo)"

            '    cm.Parameters.Add(New OleDbParameter("@Login", Nome))
            '    cm.Parameters.Add(New OleDbParameter("@Pwd", ""))
            '    cm.Parameters.Add(New OleDbParameter("@NomeReale", ""))
            '    cm.Parameters.Add(New OleDbParameter("@RepDefault", 0))
            '    cm.Parameters.Add(New OleDbParameter("@Attivo", 0))
            '    cm.Parameters.Add(New OleDbParameter("@Tipo", 0))
            '    cm.CommandType = CommandType.Text
            '    cm.CommandText = sql

            '    cm.Transaction = t
            '    cm.ExecuteNonQuery()

            '    Dim IdInserito As Integer = 0
            '    cm.CommandText = "select @@identity"
            '    IdInserito = cm.ExecuteScalar()
            '    cm.Dispose()

            'Next
            't.Commit()
            't.Dispose()
            't = Nothing

            'cn.Close()
            'cn.Dispose()
            'cn = Nothing
            'Dim EndDate As Date = Now

            'MessageBox.Show(StartDate.ToLongTimeString & "." & StartDate.Millisecond & " - " & EndDate.ToLongTimeString & "." & EndDate.Millisecond)

            'MessageBox.Show("Fine")
        End If

    End Sub

    Private Sub btnTestSvls_Click(sender As Object, e As EventArgs) Handles btnTestSvls.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            testSlvs()
        End If
    End Sub

    Private Sub btnDuplicaCons_Click(sender As Object, e As EventArgs) Handles btnDuplicaCons.Click

        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If txtIdConsegna.Text.Length Then
                Dim IdCons As Integer = txtIdConsegna.Text

                Dim C As New ConsegnaProgrammata
                C.Read(IdCons)

                Dim CNew As ConsegnaProgrammata = C.Clone
                CNew.IdCons = 0
                CNew.LastUpdate = 1
                CNew.Save()

                MessageBox.Show(CNew.IdCons)

                lblRisDup.Text = CNew.IdCons
                ResetId()
            Else
                Beep()
            End If
        End If
    End Sub

    Private Sub CaricamentoIniziale()

        Try
            lblConnStringSql.Text = System.Configuration.ConfigurationManager.ConnectionStrings("FormerDALSql.ConnectionString").ConnectionString
            lblConnStringWeb.Text = System.Configuration.ConfigurationManager.ConnectionStrings("FormerDALWeb.ConnectionString").ConnectionString

            If lblConnStringSql.Text.IndexOf("former-server") <> -1 Then
                lblConnStringSql.BackColor = Color.Green
                lblConnStringSql.ForeColor = Color.White
            Else
                lblConnStringSql.BackColor = Color.Red
                lblConnStringSql.ForeColor = Color.White
            End If

            If lblConnStringWeb.Text.IndexOf("former-server") <> -1 OrElse
lblConnStringWeb.Text.IndexOf("localhost") <> -1 Then
                lblConnStringWeb.BackColor = Color.Red
                lblConnStringWeb.ForeColor = Color.White
            Else
                lblConnStringWeb.BackColor = Color.Green
                lblConnStringWeb.ForeColor = Color.White
            End If

            'InAttesaAllegati = 5
            'Preinserito = 10
            'InAttesaPagamento = 15
            'Registrato = 20
            'InSospeso = 21
            'InCodaDiStampa = 22
            'StampaInizio = 30
            'StampaFine = 31
            'FinituraCommessaInizio = 32
            'FinituraCommessaFine = 33
            'FinituraProdottoInizio = 34
            'FinituraProdottoFine = 35
            'Imballaggio = 40
            'ImballaggioCorriere = 45
            'ProntoRitiro = 50
            'UscitoMagazzino = 51
            'InConsegna = 60
            'Consegnato = 70
            'PagatoAcconto = 80
            'PagatoInteramente = 81
            'Rifiutato = 90
            'Eliminato = 91

            Dim voce As New cEnum
            voce.Id = enStatoOrdine.InAttesaAllegati
            voce.Descrizione = "InAttesaAllegati = 5"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Preinserito
            voce.Descrizione = "Preinserito = 10"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.InAttesaPagamento
            voce.Descrizione = "InAttesaPagamento = 15"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Registrato
            voce.Descrizione = "Registrato = 20"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.InSospeso
            voce.Descrizione = "InSospeso = 21"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.InCodaDiStampa
            voce.Descrizione = "InCodaDiStampa = 22"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.StampaInizio
            voce.Descrizione = "StampaInizio = 30"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.StampaFine
            voce.Descrizione = "StampaFine = 31"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.FinituraCommessaInizio
            voce.Descrizione = "FinituraCommessaInizio = 32"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.FinituraCommessaFine
            voce.Descrizione = "FinituraCommessaFine = 33"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.FinituraProdottoInizio
            voce.Descrizione = "FinituraProdottoInizio = 34"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.FinituraProdottoFine
            voce.Descrizione = "FinituraProdottoFine = 35"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Imballaggio
            voce.Descrizione = "Imballaggio = 40"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.ImballaggioCorriere
            voce.Descrizione = "ImballaggioCorriere = 45"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.ProntoRitiro
            voce.Descrizione = "ProntoRitiro = 50"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.UscitoMagazzino
            voce.Descrizione = "UscitoMagazzino = 51"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.InConsegna
            voce.Descrizione = "InConsegna = 60"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Consegnato
            voce.Descrizione = "Consegnato = 70"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.PagatoAcconto
            voce.Descrizione = "PagatoAcconto = 80"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.PagatoInteramente
            voce.Descrizione = "PagatoInteramente = 81"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Rifiutato
            voce.Descrizione = "Rifiutato = 90"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            voce = New cEnum
            voce.Id = enStatoOrdine.Eliminato
            voce.Descrizione = "Eliminato = 91"
            cmbStato.Items.Add(voce)
            cmbColoreStatoOrd.Items.Add(voce)

            cmbStato.SelectedIndex = 0

            CaricaVersioniGestionale()
            CaricaVersioniDemone()

            FormerDebug.DebugAttivo = FormerConfig.FConfiguration.Debug.DebugAttivo


            Dim BugPresenti As Integer = CaricaBug()

            tpBug.Text = "Bug (" & BugPresenti & ")"

            CaricaCostantiUDP()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        CaricamentoIniziale()

    End Sub

    Private Sub btnDuplicaConsFromOrd_Click(sender As Object, e As EventArgs) Handles btnDuplicaConsFromOrd.Click

        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If txtIdOrdine.Text.Length Then
                Dim IdOrd As Integer = txtIdOrdine.Text
                Dim O As New Ordine
                O.Read(IdOrd)
                Dim OldIdCons As Integer = O.ConsegnaAssociata.IdCons

                Dim CNew As ConsegnaProgrammata = O.ConsegnaAssociata.Clone
                CNew.IdCons = 0
                CNew.LastUpdate = 1
                CNew.IdRub = O.IdRub
                CNew.Save()

                Using mgr As New ConsProgrOrdiniDAO
                    Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd))
                    Dim c As ConsProgrOrdini = l(0)
                    c.IdCons = CNew.IdCons

                    c.Save()
                    If l.Count > 1 Then
                        MessageBox.Show("Errore incongruenza")
                    End If
                End Using

                O.ConsegnaAssociata.LastUpdate = 1
                O.ConsegnaAssociata.Save()

                MessageBox.Show(CNew.IdCons)

                lblRisDup2.Text = CNew.IdCons
                ResetId()
            Else
                Beep()
            End If
        End If
    End Sub

    Private Sub btnLega_Click(sender As Object, e As EventArgs) Handles btnLega.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim IdOrd As Integer = txtIdOrdine.Text
            Dim IdCons As Integer = txtIdConsegna.Text

            Dim O As New Ordine
            O.Read(IdOrd)
            Dim IdOldCons As Integer = O.ConsegnaAssociata.IdCons
            O.ConsegnaAssociata.LastUpdate = 1
            O.ConsegnaAssociata.Save()

            Using mgr As New ConsProgrOrdiniDAO
                Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrd))

                Dim c As ConsProgrOrdini = Nothing

                If l.Count = 1 Then
                    c = l(0)
                    c.IdCons = IdCons
                    c.Save()
                ElseIf l.Count = 0 Then
                    c = New ConsProgrOrdini
                    c.IdOrd = IdOrd
                    c.IdCons = IdCons
                    c.Save()
                ElseIf l.Count > 1 Then
                    MessageBox.Show("Errore incongruenza")
                End If

            End Using

            Using cr As New ConsegnaProgrammata
                cr.Read(IdCons)
                cr.LastUpdate = 1
                cr.Save()
            End Using

            MessageBox.Show("Ordine legato a consegna")
            ResetId()
        End If
    End Sub

    Private Sub btnCambiaStato_Click(sender As Object, e As EventArgs) Handles btnCambiaStato.Click

        If MessageBox.Show("Confermi il cambiamento degli ordini selezionati allo stato scelto???", "Cambio Stato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim ListaOrd As String = txtOrdCambioStato.Text
            If ListaOrd.Trim.Length Then

                Dim NuovoStato As Integer = DirectCast(cmbStato.SelectedItem, cEnum).Id
                For Each SingOrd In ListaOrd.Split(",")
                    If SingOrd.Length Then
                        Using O As New OrdiniDAO
                            O.InserisciLog(SingOrd, NuovoStato, IdUtenteDiego)
                        End Using

                    End If
                Next
                MessageBox.Show("Stato degli ordini modificato")
            Else
                MessageBox.Show("Inserire gli id degli ordini")

            End If
        End If

    End Sub

    Private Sub btnIdConsFromIdOrd_Click(sender As Object, e As EventArgs) Handles btnIdConsFromIdOrd.Click

        Dim IdOrd As Integer = 0
        If txtIdOrdine.Text.Length Then
            IdOrd = txtIdOrdine.Text
            Using mgr As New ConsProgrOrdiniDAO

                Dim CO As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrd))

                If CO.Count = 1 Then
                    lblIdConsFromIdOrd.Text = CO(0).IdCons

                    MessageBox.Show(CO(0).IdCons)
                    ResetId()
                ElseIf CO.Count = 0 Then
                    MessageBox.Show("Non risultano consegne associate all'ordine")
                Else
                    MessageBox.Show("ERRORE L'ordine e' associato a piu consegne")
                End If

            End Using
        Else
            MessageBox.Show("Inserisci un id Ordine")
        End If

    End Sub

    Private Sub btnStampaCodiceBarre_Click(sender As Object, e As EventArgs) Handles btnStampaCodiceBarre.Click
        If MessageBox.Show("Confermi?", "Confermi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim x As New myFPrinter

            x.IdOrd = 46025
            x.NumColli = 1

            x.PrinterName = "\\m5\Oki ML 280 Elite (IBM)"

            x.StampaEtichetteOrdine()

            x = Nothing
        End If
    End Sub

    Private Sub btnRiportaIndietroConsegna_Click(sender As Object, e As EventArgs) Handles btnRiportaIndietroConsegna.Click

        If MessageBox.Show("Confermi il cambiamento dello stato della consegna a In Lavorazione???", "Cambio Stato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If txtIdOrdine.Text.Length Then
                Dim IdOrd As Integer = txtIdOrdine.Text
                Using O As New Ordine
                    O.Read(IdOrd)
                    Using c As ConsegnaProgrammata = O.ConsegnaAssociata

                        c.IdStatoConsegna = enStatoConsegna.InLavorazione
                        c.Save()
                    End Using
                End Using
                MessageBox.Show("Operazione effettuata")
                ResetId()
            Else
                Beep()
            End If
        End If

    End Sub

    Private Sub btnEventViewer_Click(sender As Object, e As EventArgs) Handles btnEventViewer.Click

        If MessageBox.Show("Confermi la creazione dell'errore nello strato dati?", "EventViewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            My.Application.Log.WriteEntry("Errore di invio", TraceEventType.Error)
            MessageBox.Show("OK")
        End If

    End Sub

    Public Function Scarica(m_strURL As String) As String

        Dim wreq As WebRequest = WebRequest.Create(m_strURL)
        Dim wres As WebResponse = wreq.GetResponse()
        Dim iBuffer As Integer = 0
        Dim buffer(128) As [Byte]
        Dim stream As Stream = wres.GetResponseStream()
        iBuffer = stream.Read(buffer, 0, 128)
        Dim strRes As New StringBuilder("")
        While iBuffer <> 0
            strRes.Append(Encoding.ASCII.GetString(buffer, 0, iBuffer))
            iBuffer = stream.Read(buffer, 0, 128)
        End While
        Return strRes.ToString()

    End Function

    Private Sub CaptureDataFromWeb()

        Using mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter("len(CAP)", 0),
                    New LUNA.LunaSearchParameter("email", FormerLib.FormerConst.EmailNonDisponibile, "<>"))
            Dim Counter As Integer = 0

            For Each voce In l
                If voce.RagSoc.Length Then
                    If voce.Indirizzo.Length > 0 And voce.Citta.Length > 0 Then
                        Dim ChiaveDiRicerca As String = voce.Indirizzo & " " & voce.Citta
                        Dim NewChiave As String = String.Empty
                        For Each singchar In ChiaveDiRicerca
                            If Char.IsLetterOrDigit(singchar) Or singchar = " " Then
                                NewChiave &= singchar
                            Else
                                NewChiave &= " "
                            End If
                        Next

                        Dim NewChiaveWeb As String = NewChiave.Trim.Replace(" ", "+")

                        Dim testoPag As String = Scarica("http://www.paginebianche.it/ricerca-da-indirizzo?dv=" & NewChiaveWeb)

                        Dim PosizCap As Integer = testoPag.IndexOf("<span class=""locality"">")

                        If PosizCap <> -1 Then

                            PosizCap = PosizCap - 6

                            Dim CapTrovato As String = testoPag.Substring(PosizCap, 5)
                            If CapTrovato.Length = 5 Then

                                Using mgrE As New ElencoComuniDAO
                                    Dim lcap As List(Of ComuneInElenco) = mgrE.FindAll(New LUNA.LunaSearchParameter("CAP", CapTrovato),
                                                    New LUNA.LunaSearchParameter("Comune", voce.Citta))
                                    If lcap.Count Then
                                        voce.CAP = CapTrovato
                                        voce.Save()
                                        Counter += 1
                                    End If
                                End Using
                            End If
                        End If
                    End If
                End If
            Next
        End Using

    End Sub

    Private Sub TestData(Optional DataO As Date = Nothing)

        If DataO = Date.MinValue Then
            MessageBox.Show("SI")
        Else
            MessageBox.Show("NO")
        End If

    End Sub

    Private Function RiordinaListaLav(listaDisordinata As List(Of Integer),
    IdListinoBase As Integer) As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Dim l As New List(Of Lavorazione)

        Dim ListaId As String = String.Empty

        For Each singId In listaDisordinata
            ListaId &= singId & ","
        Next
        ListaId = "(" & ListaId.TrimEnd(",") & ")"

        Using mgr As New LavorazSuPreventivazDAO
            Dim lP As List(Of LavorazSuPreventivaz) = mgr.FindAll("Ordine",
                                New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                New LUNA.LunaSearchParameter("IdLavoro", ListaId, " IN "))

            For Each singlP As LavorazSuPreventivaz In lP
                Ris.Add(singlP.IdLavoro)
            Next

        End Using

        Return Ris
    End Function

    Private Sub FileCambiato(ByVal e As IO.FileSystemEventArgs)
        MessageBox.Show("File cambiato")
    End Sub

    Private Sub CreazioneAutomaticaCommesse()

        'DA RIATTIVARE IN CASO SI VUOLE USCIRE SENZA CREARE LE COMMESSE IN AUTOMATICO
        'Exit Sub
        Dim lCom As New List(Of Integer)
        Try
            LogMe("Creazione Automatica Commesse")

            Dim ParametriImpostati As ParametriCreazioneSoluzione = Nothing

            ParametriImpostati = New ParametriCreazioneSoluzione

            ParametriImpostati.CreazioneAutomaticaCommesse = True
            ParametriImpostati.NonMostrareTutteleCombinazioni = True
            ParametriImpostati.SoloSoluzioniOttimali = True
            'ParametriImpostati.TieniContoLavorazioniEsclusive = True
            'ParametriImpostati.TieniContoRating = True
            ParametriImpostati.MaxDuplicazioneSingoloOrdine = 20
            ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile

            Dim LstStati As String = enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato

            Dim L As List(Of OrdineRicerca)

            Using OMgr As New OrdiniDAO
                L = OMgr.Lista(, LstStati, , True, , , , , , , , , , enTipoProdCom.StampaOffSet, True)
            End Using

            Dim lSol As List(Of Soluzione) = MotoreCalcoloSoluzioni.ProponiSoluzioni(L, ParametriImpostati)

            Dim SoluzionePerfetta As Soluzione = lSol.Find(Function(x) x.TipoSoluzione = enTipoSoluzione.Perfetta)

            'For Each soluz As Soluzione In lSol
            '    MessageBox.Show(soluz.TipoSoluzione & " - " & soluz.Commesse.Count)
            'Next

            If Not SoluzionePerfetta Is Nothing Then
                For Each Commessa As CommessaProposta In SoluzionePerfetta.Commesse
                    'qui posso valutare che le cose vadano bene per la creazione automatizzata della commessa
                    Using Mgr As New CommesseDAO
                        Dim IdCom As Integer = Mgr.CreaCommessaAutomaticaOffset(Commessa)
                        If IdCom Then
                            lCom.Add(IdCom)
                            LogMe(" - Creata commessa automatica " & IdCom)
                            'Else
                            '    FormerHelper.Mail.InviaMail("Errore Creazione commesse automatiche", "Errore, IdCom = 0 Commessa Firma " & Commessa.Firma, "soft@tipografiaformer.it")
                        End If
                    End Using
                Next
            End If

            LogMe("Creazione Automatica Commesse Terminata. Create " & lCom.Count & " Commesse")
        Catch ex As Exception
            LogMe("ERRORE Creazione Automatica Commesse",, ex)
        End Try

        If lCom.Count Then
            FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Notifica, "Create automaticamente " & lCom.Count & " commesse.", FormerUDP.DestUDP_Admin)
        End If

    End Sub

    Private Function ComparerVR(ByVal x As IVoceRubricaG, ByVal y As IVoceRubricaG) As Integer
        Dim result As Integer = y.ProvenienzaVoce.CompareTo(x.ProvenienzaVoce)
        If result = 0 Then result = x.NominativoG.CompareTo(y.NominativoG)

        Return result
    End Function

    Private Sub TestMarketingBilanciato()

        Try
            Dim DataRiferimento As Date = Now

            Using mgr As New FiltriMarketingDAO
                Dim l As List(Of FiltroMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStato.Attivo))

                Select Case DataRiferimento.Month
                    Case 1
                        l = l.FindAll(Function(x) x.chkGennaio)
                    Case 2
                        l = l.FindAll(Function(x) x.chkFebbraio)
                    Case 3
                        l = l.FindAll(Function(x) x.chkMarzo)
                    Case 4
                        l = l.FindAll(Function(x) x.chkAprile)
                    Case 5
                        l = l.FindAll(Function(x) x.chkMaggio)
                    Case 6
                        l = l.FindAll(Function(x) x.chkGiugno)
                    Case 7
                        l = l.FindAll(Function(x) x.chkLuglio)
                    Case 8
                        l = l.FindAll(Function(x) x.chkAgosto)
                    Case 9
                        l = l.FindAll(Function(x) x.chkSettembre)
                    Case 10
                        l = l.FindAll(Function(x) x.chkOttobre)
                    Case 11
                        l = l.FindAll(Function(x) x.chkNovembre)
                    Case 12
                        l = l.FindAll(Function(x) x.chkDicembre)
                End Select

                Dim lVR As List(Of IVoceRubricaG)
                Using mgrV As New VociRubGDAO
                    lVR = mgrV.GetAllVoceRubG()
                End Using

                'LogMe("***Filtri da eseguire trovati: " & l.Count)

                For Each singF In l
                    'qui lavoro ogni singolo filtro che va fatto questo mese
                    Dim lVRSing As New List(Of IVoceRubricaG)
                    'Dim PathFile As String = PathTemplate
                    'Dim NomeFile As String = String.Empty

                    'LogMe("***Filtro da eseguire: " & singF.Nome)

                    lVRSing.AddRange(lVR)

                    Using mgrV As New VociRubGDAO

                        'LogMe("***Applico filtro a : " & lVRSing.Count)
                        lVRSing = mgrV.ApplicaFiltro(lVRSing, singF, True)
                        lVRSing.Sort(AddressOf ComparerVR)
                        'LogMe("***Filtro applicato : " & lVRSing.Count)

                        'qui devo andare a controllare queste voci risultati dal filtro applicato e vedere se 
                        'hanno gia avuto troppe spedizioni in questo mese 

                        Dim lVRSingNew As New List(Of IVoceRubricaG)

                        For Each singVR As IVoceRubricaG In lVRSing

                            Using mgrLM As New LogMarketingDAO

                                Dim InviiGiaFatti As List(Of LogMarketing) = mgrLM.FindAll(New LUNA.LunaSearchParameter("IdRubG", singVR.IdRubG),
                                                        New LUNA.LunaSearchParameter("month(DataIns)", Now.Month),
                                                        New LUNA.LunaSearchParameter("year(DataIns)", Now.Year))

                                If InviiGiaFatti.Count = 0 Then
                                    'qui non ci sono state altre spedizioni nel mese 
                                    lVRSingNew.Add(singVR)

                                    'qui dovrei prende la data di spedizione dell'ulòtima volta a prescinde dalla spedizione perche 
                                    'per questo mese questo non ne ha avuti ma magari l'ha avuti l'ultimo giorno del mese prima
                                    Dim InviiPrecedenti As List(Of LogMarketing) = mgrLM.FindAll("Datains desc", New LUNA.LunaSearchParameter("IdRubG", singVR.IdRubG))

                                    If InviiPrecedenti.Count Then
                                        singVR.DataUltimoInvioNewsletter = InviiPrecedenti(0).DataIns
                                    End If

                                ElseIf InviiGiaFatti.Count = 1 Then
                                    'qui ci sono state e devo vedere se il filtro usato va o non va bene 
                                    Using llM As LogMarketing = InviiGiaFatti(0)

                                        Using f As New FiltroMarketing
                                            f.Read(llM.IdFm)
                                            If f.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                                                If singF.TipoFiltro <> enTipoFiltroMarketing.SuFileHtml Then
                                                    singVR.DataUltimoInvioNewsletter = llM.DataSent
                                                    lVRSingNew.Add(singVR)
                                                End If
                                            ElseIf f.TipoFiltro <> enTipoFiltroMarketing.SuFileHtml Then
                                                If singF.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                                                    singVR.DataUltimoInvioNewsletter = llM.DataSent
                                                    lVRSingNew.Add(singVR)
                                                End If
                                            End If
                                        End Using

                                    End Using
                                ElseIf InviiGiaFatti.Count > 1 Then
                                    'se ci sta piu di un invio gia lo posso scartare 
                                    'lo scrivo solo per documentazione futura
                                End If
                            End Using
                        Next

                        'se il filtro produce risultati me li schedulo 
                        If lVRSingNew.Count Then
                            Dim ggDisp As Integer = DateTime.DaysInMonth(DataRiferimento.Year, DataRiferimento.Month)
                            Dim ggDiv As Integer = ggDisp - DataRiferimento.Day
                            If ggDiv = 0 Then ggDiv = 1
                            Dim CaricoGiorn As Integer = Math.Ceiling(lVRSingNew.Count / ggDiv)
                            'ora so quanti ne dovrò spedire 
                            'inserisco i primi tot nella tabella del log da spedire e fine , passo la palla al processo che le invia
                            Dim VociLavorate As Integer = 0

                            lVRSingNew.Sort(Function(x, y) x.DataUltimoInvioNewsletter.CompareTo(y.DataUltimoInvioNewsletter))

                            Dim numerovoci As Integer = lVRSingNew.Count

                        End If

                    End Using

                    'LogMe("***Filtro eseguito: " & singF.Nome)
                Next
            End Using
        Catch ex As Exception
            'LogMe("SORGENTE: Inserimento Marketing Bilanciato(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
        End Try

    End Sub

    Private Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Long

    Public Function CreateClass(ByVal className As String, ByVal properties As Dictionary(Of String, Type)) As Type

        Dim myDomain As AppDomain = AppDomain.CurrentDomain
        Dim myAsmName As New AssemblyName("MyAssembly")
        Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run)

        Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("MyModule")

        Dim myType As TypeBuilder = myModule.DefineType(className, TypeAttributes.Public)

        myType.DefineDefaultConstructor(MethodAttributes.Public)

        For Each o In properties

            Dim prop As PropertyBuilder = myType.DefineProperty(o.Key, PropertyAttributes.HasDefault, o.Value, Nothing)

            Dim field As FieldBuilder = myType.DefineField("_" + o.Key, o.Value, FieldAttributes.[Private])

            Dim getter As MethodBuilder = myType.DefineMethod("get_" + o.Key, MethodAttributes.[Public] Or MethodAttributes.SpecialName Or MethodAttributes.HideBySig, o.Value, Type.EmptyTypes)
            Dim getterIL As ILGenerator = getter.GetILGenerator()
            getterIL.Emit(OpCodes.Ldarg_0)
            getterIL.Emit(OpCodes.Ldfld, field)
            getterIL.Emit(OpCodes.Ret)

            Dim setter As MethodBuilder = myType.DefineMethod("set_" + o.Key, MethodAttributes.[Public] Or MethodAttributes.SpecialName Or MethodAttributes.HideBySig, Nothing, New Type() {o.Value})
            Dim setterIL As ILGenerator = setter.GetILGenerator()
            setterIL.Emit(OpCodes.Ldarg_0)
            setterIL.Emit(OpCodes.Ldarg_1)
            setterIL.Emit(OpCodes.Stfld, field)
            setterIL.Emit(OpCodes.Ret)

            prop.SetGetMethod(getter)
            prop.SetSetMethod(setter)

        Next

        Return myType.CreateType()

    End Function

    Private Sub logchange(ByVal source As Object, ByVal e As _
System.IO.FileSystemEventArgs)
        MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString & " " & e.Name)
    End Sub

    Public Function IsPingable(Address As String, Optional TimeOut As Integer = 1000) As Integer
        Dim ris As Integer = 0
        Try
            If My.Computer.Network.IsAvailable Then
                Dim Result As Net.NetworkInformation.PingReply
                Dim SendPing As New Net.NetworkInformation.Ping
                Result = SendPing.Send(Address)
                If Result.Status = Net.NetworkInformation.IPStatus.Success Then
                    If Result.RoundtripTime Then
                        ris = Result.RoundtripTime
                    Else
                        ris = 10
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        Return ris
    End Function

    Private Sub ScaricaTestMail()
        Try
            Using p As New OpenPop.Pop3.Pop3Client

                p.Connect(FConfiguration.PreventiviMail.ServerPOP, 995, True)

                p.Authenticate(FConfiguration.PreventiviMail.Email,
FConfiguration.PreventiviMail.Password,
OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword)

                Dim count As Integer = p.GetMessageCount()

                If count Then
                    For i As Integer = count To 1 Step -1

                        Dim msg As OpenPop.Mime.Message = p.GetMessage(i)
                        Dim msgMail As MailMessage = msg.ToMailMessage

                        Dim body As String = msgMail.Body

                        If msgMail.IsBodyHtml Then

                            Dim bodyParsed As String = String.Empty

                            If msgMail.AlternateViews.Count Then
                                For Each a As AlternateView In msgMail.AlternateViews
                                    If a.ContentType.MediaType = "text/plain" Then
                                        Dim contenuto As Stream = a.ContentStream
                                        Dim byteBuffer(contenuto.Length) As Byte

                                        'Dim CharsetTrovato As String = a.ContentType.CharSet

                                        'Select Case CharsetTrovato.ToUpper
                                        '    Case "UTF-7"
                                        '        bodyParsed = Encoding.UTF7.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                        '    Case "UTF-32"
                                        '        bodyParsed = Encoding.UTF32.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                        '    Case "UNICODE"
                                        '        bodyParsed = Encoding.Unicode.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                        '    Case "US-ASCII"
                                        '        bodyParsed = Encoding.ASCII.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                        '    Case Else '"UTF-8"
                                        '        bodyParsed = Encoding.UTF8.GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))
                                        'End Select

                                        bodyParsed = Encoding.GetEncoding(a.ContentType.CharSet).GetString(byteBuffer, 0, contenuto.Read(byteBuffer, 0, byteBuffer.Length))

                                    End If
                                Next
                            End If

                            If bodyParsed.Length = 0 Then
                                body = FormerLib.FormerHelper.HTML.EliminaTag(msgMail.Body)
                            Else
                                body = bodyParsed
                            End If

                        End If

                        Try
                            body = System.Web.HttpUtility.HtmlDecode(body)
                        Catch ex As Exception

                        End Try

                        Dim Mittente As String = msgMail.From.Address
                        Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                        'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                        If risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com" Then
                            'qui devo cercare l'inoltro

                            Dim collCercaMail As MatchCollection = Regex.Matches(msgMail.Body, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

                            For Each singRis As Match In collCercaMail

                                Dim cercaMail As Match = Regex.Match(singRis.Value, "@tipografiaformer.")

                                If cercaMail.Success = False And singRis.Value <> "tipografia.duca@gmail.com" Then

                                    If FormerLib.FormerHelper.Mail.IsValidEmailAddress(singRis.Value) Then
                                        Mittente = singRis.Value
                                        Exit For
                                    End If

                                End If

                            Next

                        End If
                    Next
                End If
                p.Disconnect()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckPEC()

    End Sub

    Private Sub WatchFolder()

        Dim watchfolder As New FileSystemWatcher
        watchfolder.Path = "C:\temp\watch\"
        watchfolder.NotifyFilter = IO.NotifyFilters.DirectoryName
        watchfolder.NotifyFilter = watchfolder.NotifyFilter Or
IO.NotifyFilters.FileName
        watchfolder.NotifyFilter = watchfolder.NotifyFilter Or
IO.NotifyFilters.Attributes

        AddHandler watchfolder.Changed, AddressOf logchange
        AddHandler watchfolder.Created, AddressOf logchange
        AddHandler watchfolder.Deleted, AddressOf logchange

        watchfolder.EnableRaisingEvents = True

    End Sub

    Private Function ResizePdf(PathSource As String,
LarghezzaMM As Single,
AltezzaMM As Single,
PathDestination As String) As Integer

        Dim Ris As Integer = 0

        Dim reader As New text.pdf.PdfReader(PathSource)

        Dim Larghezza As Single = FormerHelper.PDF.TrasformaMmInPoint(LarghezzaMM)
        Dim Altezza As Single = FormerHelper.PDF.TrasformaMmInPoint(AltezzaMM)

        If Larghezza > 14400 Or Altezza > 14400 Then
            Larghezza /= 2
            Altezza /= 2
            Ris = 1
        End If

        Dim DimensioniDocumento As New text.Rectangle(Larghezza, Altezza)

        Dim doc As New text.Document(DimensioniDocumento, 0, 0, 0, 0)

        Dim writer As text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                                                    New FileStream(PathDestination, FileMode.Create))
        doc.Open()
        Dim cb As text.pdf.PdfContentByte = writer.DirectContent

        Dim page As text.pdf.PdfImportedPage = writer.GetImportedPage(reader, 1)

        Dim widthFactor As Single = doc.PageSize.Width / page.Width
        Dim heightFactor As Single = doc.PageSize.Height / page.Height
        Dim factor As Single = Math.Min(widthFactor, heightFactor)

        Dim offsetX As Single = (doc.PageSize.Width - (page.Width * factor)) / 2
        Dim offsetY As Single = (doc.PageSize.Height - (page.Height * factor)) / 2
        cb.AddTemplate(page, factor, 0, 0, factor, offsetX, offsetY)

        doc.Close()

        Return Ris

    End Function

    Private Sub Pannelli(SourcePdfFilePath As String,
DestinationPdfFilePath As String,
LarghezzaRotoloMM As Single,
AltezzaTotaleMM As Single,
NPannelli As Integer,
SormontoMM As Single,
Optional LarghezzaCrocini As Integer = 10)

        'Dim SourcePdfFilePath As String = "c:\temp\digitale\source.pdf"
        'Dim DestinationPdfFilePath As String = "c:\temp\digitale\destination$.pdf"
        Dim PageNumber As Integer = 1

        'Dim dimensioni As Size = FormerHelper.PDF.GetDimensioniPagina("c:\temp\digitale\1_B.pdf")

        Using reader As text.pdf.PdfReader = New text.pdf.PdfReader(SourcePdfFilePath)
            Dim Larghezza As Single = FormerHelper.PDF.TrasformaMmInPoint(LarghezzaRotoloMM)
            Dim Altezza As Single = FormerHelper.PDF.TrasformaMmInPoint(AltezzaTotaleMM)
            Dim DimensioniDocumento As New text.Rectangle(Larghezza, Altezza)

            Dim shift As Single = 0 '-28

            For i = 1 To NPannelli
                Dim doc As New iTextSharp.text.Document(DimensioniDocumento, 0, 0, 0, 0)

                Using writer As text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                                                            New FileStream(DestinationPdfFilePath.Replace("$", i), FileMode.Create))

                    doc.Open()
                    'doc.Add(New text.Paragraph(""))
                    Dim cb As text.pdf.PdfContentByte = writer.DirectContent
                    Dim page As text.pdf.PdfImportedPage = writer.GetImportedPage(reader, 1)
                    Dim Scale As New iTextSharp.awt.geom.AffineTransform
                    cb.AddTemplate(page, (shift), 0, False)

                    If i > 1 Then
                        cb.SetLineWidth(0.5) '; // Make a bit thicker than 1.0 Default
                        cb.SetColorStroke(iTextSharp.text.BaseColor.GRAY)
                        cb.SetLineDash(15, 15, 100)
                        cb.MoveTo(FormerHelper.PDF.TrasformaMmInPoint(SormontoMM), 0)
                        cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(SormontoMM), Altezza)
                        cb.Stroke()
                    End If

                    cb.SetLineWidth(0.5) '; // Make a bit thicker than 1.0 Default
                    cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK)
                    cb.SetLineDash(1)

                    'basso SX
                    cb.MoveTo(0, 0)
                    cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), 0)
                    cb.Stroke()

                    cb.MoveTo(0, 0)
                    cb.LineTo(0, FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    'alto sx
                    cb.MoveTo(0, Altezza)
                    cb.LineTo(0, Altezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    cb.MoveTo(0, Altezza)
                    cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), Altezza)
                    cb.Stroke()

                    'alto dx
                    cb.MoveTo(Larghezza, Altezza)
                    cb.LineTo(Larghezza, Altezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    cb.MoveTo(Larghezza, Altezza)
                    cb.LineTo(Larghezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), Altezza)
                    cb.Stroke()

                    'basso dx
                    cb.MoveTo(Larghezza, 0)
                    cb.LineTo(Larghezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), 0)
                    cb.Stroke()

                    cb.MoveTo(Larghezza, 0)
                    cb.LineTo(Larghezza, FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    doc.Close()
                End Using
                shift -= Larghezza - FormerHelper.PDF.TrasformaMmInPoint(SormontoMM)
            Next

        End Using

    End Sub

    Private Sub ComunicazioneGabetti()

        Dim l As New List(Of String)
        'l.Add("soft@tipografiaformer.it")

        'l.Add("fiumicino@gabetti.it")
        'l.Add("fontenuova@gabetti.it")
        'l.Add("nettuno@gabetti.it")
        'l.Add("rmappio@gabetti.it")
        'l.Add("rmaurelia@gabetti.it")
        'l.Add("rmbalduina@gabetti.it")
        'l.Add("rmbologna@gabetti.it")
        'l.Add("rmcasettamattei@gabetti.it")
        'l.Add("rmcassia@gabetti.it")
        'l.Add("rmcipro@gabetti.it")
        'l.Add("rmcollialbani@gabetti.it")
        'l.Add("rmcolliportuensi@gabetti.it")
        'l.Add("rmcorsoitalia@gabetti.it")
        'l.Add("rmesquilino@gabetti.it")
        'l.Add("rmfleming@gabetti.it")
        'l.Add("rmlibia@gabetti.it")
        'l.Add("rmmalatesta@gabetti.it")
        'l.Add("rmolgiata@gabetti.it")
        'l.Add("rmparioli@gabetti.it")
        'l.Add("rmprati@gabetti.it")
        'l.Add("rmsalario@gabetti.it")
        'l.Add("rmsanpaolo@gabetti.it")
        'l.Add("rmserafico@gabetti.it")
        'l.Add("rmtrieste@gabetti.it")
        'l.Add("romaaventino@gabetti.it")
        'l.Add("romacentrostorico@gabetti.it")
        'l.Add("santamarinella@gabetti.it")

        For Each singMail As String In l

            Dim Titolo As String = "Uscita Pocket Gennaio 2017"

            Dim Testo As String = "Gentile Agenzia,<br><br> informiamo che come ogni anno non è prevista uscita Gabetti Pocket per il mese di dicembre.<br>"

            Testo &= "La prossima uscita sarà quella del mese di Gennaio 2017."
            Testo &= "<br><br>A tal proposito, inviamo  in allegato, copia del nuovo contratto edizione Gabetti Pocket 2017 da rispedire controfirmato via mail o via fax allo 06.30884057<br>"
            Testo &= "A disposizione per qualsiasi chiarimento, Vi ringraziamo della fiducia fin qui accordata<br><br> Lidia<br><br>Ufficio Grandi Clienti"
            Dim Allegato As String = "c:\temp\gabetti\Contratto_Gabetti_2017.pdf"

            Try
                FormerHelper.Mail.InviaMail(Titolo, Testo, singMail, "info@tipografiaformer.it",, Allegato,,,, False)
            Catch ex As Exception

            End Try

        Next

    End Sub

    Private Sub PannelliTotale()

        Dim AbbondanzaTrovata As Boolean = FormerLib.FormerHelper.PDF.DocumentWithExternalLevel("c:\temp\digitale\source.pdf")

        ' MessageBox.Show(AbbondanzaTrovata)

        Dim AltezzaTotale As Single = 2850
        Dim AltezzaPannello As Single = AltezzaTotale
        Dim LarghezzaTotale As Single = 5850
        Dim NPannelli As Integer = 6
        Dim Sormonto As Single = 15
        Dim Crocini As Single = 10

        Dim LarghezzaPannello As Single = (LarghezzaTotale + ((NPannelli - 1) * Sormonto)) / NPannelli

        Dim ris As Integer = ResizePdf("c:\temp\digitale\source.pdf", LarghezzaTotale, AltezzaTotale, "c:\temp\digitale\source2.pdf")

        If ris Then
            Sormonto /= 2
            AltezzaPannello /= 2
            LarghezzaPannello /= 2
            Crocini /= 2
        End If

        Pannelli("c:\temp\digitale\source2.pdf", "c:\temp\digitale\destination$.pdf", LarghezzaPannello, AltezzaPannello, NPannelli, Sormonto, Crocini)

        If ris Then
            'qui devo duplicare i pannelli 
            LarghezzaPannello *= 2
            For i As Integer = 1 To NPannelli
                ResizePdf("c:\temp\digitale\destination$.pdf".Replace("$", i), LarghezzaPannello, AltezzaTotale, "c:\temp\digitale\destination$R.pdf".Replace("$", i))
            Next

        End If

    End Sub

    Private Sub ImportHashtag(Hashtag As String)

        Hashtag = Hashtag.ToLower

        Dim PathDb As String = ""

        PathDb = "C:\temp\contacts.mdb"
        Dim VociRubAggiornate As Integer = 0
        Dim VociRubMarkAggiornate As Integer = 0
        Dim VociRubMarkCreate As Integer = 0
        Dim MailNonConformi As Integer = 0
        FDE.LUNA.LunaContext.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathDb & ";Persist Security Info=False;"

        Using mgrC As New FDE.ContattiDAO
            Dim lC As List(Of FDE.Contatto) = mgrC.FindAll(New FDE.LUNA.LunaSearchParameter("Tag", Hashtag))

            For Each C As FDE.Contatto In lC

                If FormerLib.FormerHelper.Mail.IsValidEmailAddress(C.Email) Then

                    'qui prima devo vedere se esiste una voce in rubrica normale per quella email 
                    Using mgrV As New VociRubricaDAO
                        Dim lV As List(Of VoceRubrica) = mgrV.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, C.Email))
                        If lV.Count Then
                            Dim R As VoceRubrica = lV(0)
                            If R.tag.IndexOf(Hashtag) = -1 Then
                                R.tag &= " " & Hashtag
                                R.Save()
                                VociRubAggiornate += 1
                            End If
                        Else
                            Using mgr As New VoceRubricaMarketingDAO
                                Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.Email, C.Email))

                                If l.Count = 0 Then
                                    'Using mgrR As New VociRubricaDAO
                                    '    Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter("Email", Email))

                                    '    If lR.Count Then ElencoGiaPresentiRub.Add(Email)

                                    'End Using

                                    Using R As New VoceRubricaMarketing
                                        R.DataAcquisizione = Now
                                        R.Email = C.Email
                                        R.Telefono = C.Cellulare
                                        R.NomeAzienda = C.RagSoc
                                        R.Annotazioni = C.Nominativo
                                        R.IdCategoria = 0
                                        R.IdCategoria2 = 0
                                        R.IdUtente = 0
                                        R.Lavorato = 1
                                        R.NoEmail = 0
                                        R.Tipo = enTipoRubrica.Rivenditore
                                        R.Disattivo = 0
                                        R.IdCategoria = 0
                                        R.Tag = Hashtag
                                        R.Save()
                                        VociRubMarkCreate += 1
                                    End Using
                                Else
                                    Dim R As VoceRubricaMarketing = l(0)
                                    If R.Tag.IndexOf(Hashtag) = -1 Then
                                        R.Tag &= " " & Hashtag
                                        R.Save()
                                        VociRubMarkAggiornate += 1
                                    End If
                                End If
                            End Using
                        End If
                    End Using
                Else
                    MailNonConformi += 1
                End If

            Next
            MessageBox.Show("Contatti trovati: " & lC.Count & ControlChars.NewLine &
"Voci Rubrica aggiornate: " & VociRubAggiornate & ControlChars.NewLine &
"Voci Rubrica Marketing aggiornate: " & VociRubMarkAggiornate & ControlChars.NewLine &
"Voci Rubrica Marketing create: " & VociRubMarkCreate & ControlChars.NewLine &
"Mail non conformi: " & MailNonConformi)
        End Using



    End Sub


    'Private Sub ImportViscom2016()
    '    Dim xmldoc As New XmlDataDocument()
    '    Dim xmlnode As XmlNodeList
    '    Dim i As Integer
    '    Dim fs As New FileStream("c:\lavoro\Former\FormerContacts\DBFull\Contatti.xml", FileMode.Open, FileAccess.Read)
    '    xmldoc.Load(fs)
    '    xmlnode = xmldoc.GetElementsByTagName("Contatti")

    '    Dim ElencoGiaPresenti As New List(Of String)
    '    Dim ElencoGiaPresentiRub As New List(Of String)

    '    For i = 0 To xmlnode.Count - 1
    '        Dim RagSoc As String = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
    '        Dim Nominativo As String = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
    '        Dim Email As String = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
    '        Dim Cellulare As String = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()

    '        Using mgr As New VoceRubricaMarketingDAO
    '            Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("Email", Email))

    '            If l.Count = 0 Then
    '                'Using mgrR As New VociRubricaDAO
    '                '    Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter("Email", Email))

    '                '    If lR.Count Then ElencoGiaPresentiRub.Add(Email)

    '                'End Using

    '                Using R As New VoceRubricaMarketing
    '                    R.DataAcquisizione = Now
    '                    R.Email = Email
    '                    R.Telefono = Cellulare
    '                    R.NomeAzienda = RagSoc
    '                    R.Annotazioni = Nominativo
    '                    R.IdCategoria = 0
    '                    R.IdCategoria2 = 85
    '                    R.IdUtente = 0
    '                    R.Lavorato = 1
    '                    R.NoEmail = 0
    '                    R.Tipo = enTipoRubrica.Rivenditore
    '                    R.Disattivo = 0
    '                    R.IdCategoria = 0
    '                    R.Save()
    '                End Using

    '            Else

    '                Dim R As VoceRubricaMarketing = l(0)
    '                R.IdCategoria2 = 85
    '                R.Save()
    '                'qui vediamo che fare 
    '                'ElencoGiaPresenti.Add(Email)

    '                'Using mgrR As New VociRubricaDAO
    '                '    Dim lR As List(Of VoceRubrica) = mgrR.FindAll(New LUNA.LunaSearchParameter("Email", Email))

    '                '    If lR.Count Then ElencoGiaPresentiRub.Add(Email)

    '                'End Using

    '            End If
    '        End Using

    '        'str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim() & "  " & xmlnode(i).ChildNodes.Item(1).InnerText.Trim() & "  " & xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
    '        'MsgBox(str)
    '    Next

    '    MessageBox.Show("Trovati: " & xmlnode.Count & " Gia in marketing, " & ElencoGiaPresenti.Count & " - Gia in rub," & ElencoGiaPresentiRub.Count)

    'End Sub

    Private Sub LogCoupon(Testo As String,
GruppoCoupon As String)

        Try
            Dim PathFolder As String = "C:\temp\"
            Using w As New StreamWriter(PathFolder & "LogCoupon" & GruppoCoupon & ".txt", True)
                w.WriteLine(Now.ToString & " - " & Testo)
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EmettiCoupon(V As VoceRubrica,
GruppoCoupon As String)

        LogCoupon("Richiesta Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)

        Try
            Select Case GruppoCoupon
                Case "VISCOM2016" 'GRUPPO VISCOM 2016
                    If Now.Year < 2017 Then
                        Dim Codice As String = V.IdUtOnline & "-VISCOM2016"
                        Dim DataInizioValidita As Date = Now
                        Dim DataFineValidita As Date = New Date(2016, 12, 31)

                        Using mgr As New FormerDALWeb.CouponWDAO
                            Dim l As List(Of FormerDALWeb.CouponW) = mgr.FindAll(New FormerDALWeb.LUNA.LunaSearchParameter("Codice", Codice),
                                                New FormerDALWeb.LUNA.LunaSearchParameter("Riservato", V.IdUtOnline))

                            If l.Count = 0 Then
                                Using Conl As New FormerDALWeb.CouponW

                                    Conl.Codice = Codice
                                    Conl.Nome = "Sconto Viscom2016"
                                    Conl.IdListinoBase = 0
                                    'quando lo porto online devo salvare l'id del cliente online non qui
                                    Conl.Riservato = V.IdUtOnline
                                    Conl.Percentuale = 30
                                    Conl.ImportoFisso = 0
                                    Conl.QtaSpecifica = 0
                                    Conl.MaxVolte = 1
                                    Conl.DataInizioValidita = DataInizioValidita
                                    Conl.DataFineValidita = DataFineValidita
                                    Conl.RiservatoATipoUtente = enTipoRubrica.Rivenditore
                                    Conl.Save()

                                End Using

                                'INVIO LA MAIL DI AVVISO
                                Dim Soggetto As String = "Ecco il tuo Coupon di sconto VISCOM 2016"
                                Dim Buffer As String = ""

                                Buffer &= "<center><img src=""http://www.tipografiaformer.it/emailattach/CouponDiSconto.png""></center><br><br><b>HAI RICEVUTO UN COUPON DI SCONTO</b><br><br>"

                                Buffer &= "Gentile Cliente,<br><br>ringraziandoti della visita al nostro stand al <b>VISCOM 2016</b> ti inviamo come promesso il codice del Coupon di sconto con cui potrai ottenere il <b>30% di sconto</b> incondizionato sul primo ordine.<br><br>"

                                Buffer &= "Il codice del coupon è: <b>" & Codice & "</b><br><br>"
                                Buffer &= "La data di scadenza è il : <b>" & DataFineValidita.ToString & "</b><br><br>"
                                Buffer &= "Troverai tutte le informazioni sulle modalità di utilizzo del Coupon sul nostro sito nella sezione <b>I tuoi Coupon</b> che puoi raggiungere all'indirizzo http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto o cliccando <a href=""http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto"">qui</a>."

                                FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, V.Email)

                                LogCoupon("Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)
                            End If

                        End Using

                    End If

                Case "SHOPEXPO2017"
                    If Now.Year < 2018 Then
                        Dim Codice As String = V.IdUtOnline & "-SHOPEXPO2017"
                        Dim DataInizioValidita As Date = Now
                        Dim DataFineValidita As Date = New Date(2017, 12, 31)

                        Using mgr As New FormerDALWeb.CouponWDAO
                            Dim l As List(Of FormerDALWeb.CouponW) = mgr.FindAll(New FormerDALWeb.LUNA.LunaSearchParameter("Codice", Codice),
                                                New FormerDALWeb.LUNA.LunaSearchParameter("Riservato", V.IdUtOnline))

                            If l.Count = 0 Then
                                Using Conl As New FormerDALWeb.CouponW

                                    Conl.Codice = Codice
                                    Conl.Nome = "Sconto SHOPEXPO2017"
                                    Conl.IdListinoBase = 0
                                    Conl.Riservato = V.IdUtOnline
                                    Conl.Percentuale = 30
                                    Conl.ImportoFisso = 0
                                    Conl.QtaSpecifica = 0
                                    Conl.MaxVolte = 1
                                    Conl.DataInizioValidita = DataInizioValidita
                                    Conl.DataFineValidita = DataFineValidita
                                    Conl.RiservatoATipoUtente = enTipoRubrica.Rivenditore
                                    Conl.Save()

                                End Using

                                'INVIO LA MAIL DI AVVISO
                                Dim Soggetto As String = "Ecco il tuo Coupon di sconto SHOPEXPO 2017"
                                Dim Buffer As String = ""

                                Buffer &= "<center><img src=""http://www.tipografiaformer.it/emailattach/CouponDiSconto.png""></center><br><br><b>HAI RICEVUTO UN COUPON DI SCONTO</b><br><br>"

                                Buffer &= "Gentile Cliente,<br><br>ringraziandoti della visita al nostro stand al <b>SHOPEXPO 2017</b> ti inviamo come promesso il codice del Coupon di sconto con cui potrai ottenere il <b>30% di sconto</b> incondizionato sul primo ordine.<br><br>"

                                Buffer &= "Il codice del coupon è: <b>" & Codice & "</b><br><br>"
                                Buffer &= "La data di scadenza è il : <b>" & DataFineValidita.ToString & "</b><br><br>"
                                Buffer &= "Troverai tutte le informazioni sulle modalità di utilizzo del Coupon sul nostro sito nella sezione <b>I tuoi Coupon</b> che puoi raggiungere all'indirizzo http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto o cliccando <a href=""http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto"">qui</a>."

                                FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, V.Email)

                                LogCoupon("Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)
                                'LogMe(GruppoCoupon & " - Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome)
                            End If

                        End Using

                    End If


                Case Else

            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EmettiCouponNuovi(Vr As VoceRubrica)

        'VISCOM2016
        Using mgr As New VoceRubricaMarketingDAO
            Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("Email", Vr.Email),
                                New LUNA.LunaSearchParameter("IdCategoria2", FormerConst.Coupon.GruppoCouponShopExpo2017))
            If l.Count Then
                EmettiCoupon(Vr, "SHOPEXPO2017")
            End If
        End Using

    End Sub

    Private Sub EmettiCouponGiaRegistrati()
        Dim TotGia As Integer = 0
        Dim TotPiuMail As Integer = 0

        Using mgr As New VoceRubricaMarketingDAO
            Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCategoria2", FormerConst.Coupon.GruppoCouponShopExpo2017))

            'alcuni di questi sono gia registrati, questa procedura la posso lanciare solo dopo aver terminato l'emissione automatica in registrazione

            For Each singV As VoceRubricaMarketing In l

                Using mgrV As New VociRubricaDAO
                    Dim lV As List(Of VoceRubrica) = mgrV.FindAll(New LUNA.LunaSearchParameter("Email", singV.Email))
                    If lV.Count = 1 Then

                        Dim vr As VoceRubrica = Nothing
                        vr = lV(0)

                        'vr = New VoceRubrica
                        'vr.Read(1703)

                        EmettiCoupon(vr, "SHOPEXPO2017")
                        Threading.Thread.Sleep(1000)
                        TotGia += 1
                    ElseIf lV.Count = 2 Then
                        TotPiuMail += 1

                    End If
                End Using

                'qui emetto il coupon a sto tizio

            Next

        End Using

        If TotPiuMail Then
            MessageBox.Show("Corrispondono A piu ut" & TotPiuMail)
        End If

    End Sub

    Private Sub AvvisaViscom2016()

        'INVIO LA MAIL DI AVVISO
        Dim Soggetto As String = "Come ottenere il tuo Coupon di sconto VISCOM 2016"
        Dim Buffer As String = ""

        Buffer &= "<center><img src=""http://www.tipografiaformer.it/emailattach/CouponDiSconto.png""></center><br><br><b>COME OTTENERE IL COUPON DI SCONTO</b><br><br>"

        Buffer &= "Gentile Cliente,<br><br>ringraziandoti della visita al nostro stand al <b>VISCOM 2016</b> ti ricordiamo che per ottenere il <b>Coupon di sconto 30%</b> sul tuo primo ordine, ti basta registrarti al sito Tipografiaformer.it (<a href=""http://www.tipografiaformer.it"">http://www.tipografiaformer.it</a>).<br><br>"

        Buffer &= "Una volta registrato riceverai in automatico nella tua email il <b>Coupon di sconto</b><br><br>"
        Buffer &= "Troverai tutte le informazioni sulle modalità di utilizzo del Coupon sul nostro sito nella sezione <b>I tuoi Coupon</b> che puoi raggiungere all'indirizzo http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto o cliccando <a href=""http://www.tipografiaformer.it/i-tuoi-coupon-di-sconto"">qui</a>."

        'FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, "soft@tipografiaformer.it")

        Using mgr As New VoceRubricaMarketingDAO
            Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCategoria2", 85))

            For Each singV As VoceRubricaMarketing In l

                'avviso ognuno di loro se non e' gia presente in rubrica

                Using mgrV As New VociRubricaDAO
                    Dim lV As List(Of VoceRubrica) = mgrV.FindAll(New LUNA.LunaSearchParameter("Email", singV.Email))

                    If lV.Count = 0 Then
                        FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, singV.Email)

                        Threading.Thread.Sleep(1000)
                    End If
                End Using

            Next

        End Using

    End Sub

    Private Sub InvioMailConFiltro()

        Dim PathNl As String = String.Empty
        Dim buffer As String = String.Empty

        PathNl = "c:\temp\SalutiViscom2017.html"

        Using r As New StreamReader(PathNl)
            buffer = r.ReadToEnd
        End Using

        Dim l As List(Of IVoceRubricaG)
        Using mgr As New VociRubGDAO

            l = mgr.GetAllVoceRubG()

            Using f As New FiltroMarketing
                f.tag = "#Viscom2017"
                l = mgr.ApplicaFiltro(l, f)
            End Using
            l.Sort(Function(x, y) x.EmailG.CompareTo(y.EmailG))

            For Each singC In l

                'buffer &= singC.EmailG & ControlChars.NewLine
                FormerHelper.Mail.InviaMail("Ringraziamenti VISCOM 2017", buffer, singC.EmailG,,,,,, True)
                Threading.Thread.Sleep(500)
            Next

            'MessageBox.Show(buffer)
        End Using

    End Sub

    Private Sub TestInvioNewsletter()

        Dim PathNl As String = String.Empty
        Dim buffer As String = String.Empty

        PathNl = "W:\templatemarketing\InvitoComunikart2019.htm"

        Using r As New StreamReader(PathNl)
            buffer = r.ReadToEnd
        End Using

        FormerHelper.Mail.InviaMail("Invito Comunikart 2019", buffer, "soft@tipografiaformer.it",,,,, "info@tipografiaformer.it",, True)

    End Sub

    Private Sub ValidazioneIndirizzo()

        Dim ris As RisValidazioneIndirizzo = Nothing
        Dim Cap As String = "02032"
        Dim Indirizzo As String = "Viale Unita' D' Italia,1"
        Dim IdNazione As Integer = 0

        Dim Comune As String = "Fara In Sabina"
        Dim Provincia As String = "RI"
        ris = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(Provincia, Cap, Comune, Indirizzo, IdNazione)

        If ris.Valido Then
            MessageBox.Show("L'indirizzo inserito ha superato CORRETTAMENTE la validazione GLS")
        Else
            Dim MessaggioErrore As String = String.Empty

            MessaggioErrore = "L'indirizzo inserito NON ha superato la validazione GLS. Informazioni supplementari: " & ris.Messaggio
            If ris.ListaIndirizziSuggeriti.Count Then
                MessaggioErrore &= ControlChars.NewLine & ControlChars.NewLine & "Suggerimenti: "

                For Each Indirizzo In ris.ListaIndirizziSuggeriti
                    MessaggioErrore &= Indirizzo & ControlChars.NewLine
                Next

            End If

            MessageBox.Show(MessaggioErrore)

        End If

    End Sub

    Private Sub FileMultiPagina()

        Dim NomeSorgenteFronte As String = "c:\temp\62898.pdf"

        Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(NomeSorgenteFronte)

        If NumPag > 1 Then
            Try
                For i As Integer = 1 To NumPag

                    Dim PathEnd As String = NomeSorgenteFronte.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                    FormerHelper.PDF.EstraiPaginaFromPdf(NomeSorgenteFronte, PathEnd, i)

                    'Dim risCopia As enStatoRefineSorgente = CopiaSorgenteToRefine(PathEnd)

                    '    NumPagina += 1

                Next
            Catch ex As Exception
                Dim err As String = String.Empty
                err = ex.Message
            End Try
        End If
    End Sub

    Private Sub TestStampante()

        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = "\\LIDIA\iR2200 (FATTURE)"

        Dim tipoCarta As New System.Drawing.Printing.PaperSize
        tipoCarta.PaperName = Printing.PaperKind.A4

        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        '**********************
        '24/03/2016 per prevenire orientamento orizzontale
        prn.PrinterSettings.DefaultPageSettings.Landscape = False

        For Each s As Printing.PaperSource In prn.PrinterSettings.PaperSources

            Dim m As String = s.SourceName

        Next

    End Sub

    Private Sub HashPassword()

        Dim testo As String = FormerHelper.Security.GetMd5Hash("pacopaco1")

        Clipboard.SetText(testo)

        MessageBox.Show(testo)

    End Sub

    Private Sub CallBancaSella()

        Dim IdUtenteConnesso As Integer = 1703
        Dim IdOrdine As Integer = 75690
        Dim GuidOrd As Guid = Guid.NewGuid()
        Dim GuidToSave As String = IdUtenteConnesso & "-" & GuidOrd.ToString

        Dim R As New BancaSellaRequest

        R.amount = 1103.5
        'R.BuyerName = "Diego"
        'R.BuyerEmail = "soft@tipografiaformer.it"
        R.ShopTransactionId = IdOrdine
        R.CustomInfo = "Guid=" & GuidToSave

        Dim bsResult As BancaSellaResult = MgrBancaSella.Encript(R)

        If bsResult.Risultato = "OK" Then

            Dim urlToGo As String = MgrBancaSella.UrlPageCreator(bsResult)

            Clipboard.SetText(urlToGo)
            MessageBox.Show(urlToGo)

        Else

            MessageBox.Show(bsResult.Risultato & " " & bsResult.ErrorDescription)

        End If

    End Sub

    Private Sub ReCallBancaSella()

        Dim shoplogin As String = "GESPAY66778"
        Dim buffer As String = "LoX4D9ooMa*fqUfYCmdmYXGkQvqs_hjZJReDgFMuZIGRIj9kolYacJPzqkHidHLblCeo1H_4ryvgxeBFMSfC1TaVWmHTnCIUbTd4X4BkPkZWUT2Nb_UHHqv5xUAHPh4JNwecs36ZkfdN*kZtC8v6kEpbd*twRw_i7Plmf_TFt6TVPpAWZXIGb_F_W9Ej7sgFXN14KtG*lcRi5EguKSq5hKTU3ON78BM5HQYXfRMhe57*QjSSdEde6fTIRV0m2IJHIPqatMsaNuFMAbgbL1F2_d0B*X_8nbWxBN8FkojJ0PDMuTj_QAYn_rnh5ouzVIE_PCICwPCBoVqzkt5xOo76KlyYwrKrS7Ca97nto2OZ2Qo8w7gzKLl5_gX7sI3TN_HJv377U8N3fosH2FUQVBjFVSYAv_GHgNfIajz1a5MemuMx6MKWizq*aUofoGmPvKP*xwkVJ*773S1OuPiC*KS66Mgtgb1a7jnDM*0FOPmzAQw6mY8YTrm8IrzSeK*n*7PciOs9GutDQu1zNqXGnR3pTpULHvlVRvID1r81o*fzy0KHLcKCK_pcQSYLeyNJVvqqe8upL24HMDcSX3Tt9nGIYk_1_reJTJn3kPY9f5ft9U0ghzfNlSpEgCUHVi8aKuVzytVo55MIm5kyCV7UppLudpPRTwMtbu*ADHYjO9EPcHPDvuq418M3wUplTQ1_imrT"

        Dim bsResult As BancaSellaResult = MgrBancaSella.Decript(shoplogin, buffer)

        If bsResult.Risultato = "OK" Then

        Else

        End If


    End Sub

    Public Shared Sub LogMe(Testo As String,
Optional DontStore As Boolean = False,
Optional Errore As Exception = Nothing)

        FormerLog.LogMe(Nothing, Nothing, "LAB", "LAB", Testo, DontStore, Errore)

    End Sub

    Private Sub ImportShopExpo2017()

        Using r As New StreamReader("C:\temp\se2017.txt")

            Dim buffer As String = r.ReadToEnd
            Dim MailTrovate As Integer = buffer.Split(";").Count
            Dim MailLavorate As Integer = 0
            Dim MailNonTrovate As Integer = 0
            Dim TagToIns As String = "#shopexpo2017"
            Dim UltimaMail As String = String.Empty

            For Each singM In buffer.Split(";")

                'qui cerco la mail e ci metto il tag #shopexpo2017
                Using mgr As New VociRubricaDAO
                    Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter("Email", singM))

                    If l.Count = 1 Then
                        Dim v As VoceRubrica = l(0)

                        If v.tag.IndexOf(TagToIns) = -1 Then
                            v.tag = TagToIns
                            v.Save()
                            MailLavorate += 1
                        End If
                    ElseIf l.Count = 0 Then
                        MailNonTrovate += 1
                    End If

                    UltimaMail = singM

                End Using

            Next

            MessageBox.Show("Trovate " & MailTrovate & " Lavorate " & MailLavorate & " Non Trovate " & MailNonTrovate & " UltimaMail " & UltimaMail)

        End Using

    End Sub

    Private Sub InterpretaPixart()

        Dim NomeFile As String = "C:\temp\" & Now.ToString("yyyyMMdd") & ".htm"

        'If File.Exists(NomeFile) = False Then

        Try
            Dim W As New Net.WebClient
            W.DownloadFile("https://www.pixartprinting.it/", NomeFile)
            W.Dispose()
        Catch ex As Exception
            MessageBox.Show("C'è stato un problema nello scaricamento del file")
        End Try

        Dim Buffer As String = String.Empty
        Using r As New StreamReader(NomeFile)

            Buffer = r.ReadToEnd

        End Using

        Dim Posizione As Integer = Buffer.IndexOf(">Promo<")

        While Posizione <> -1

            'qui becco la caption 

            Dim PosizPrima As Integer = 0
            PosizPrima = Buffer.IndexOf("<h4", Posizione)
            PosizPrima = Buffer.IndexOf(">", PosizPrima)

            Dim PosizFinale As Integer = 0

            PosizFinale = Buffer.IndexOf("</h4>", PosizPrima + 1)

            Dim BuffVoce As String = Buffer.Substring(PosizPrima + 1, PosizFinale - PosizPrima - 1)

            MessageBox.Show(BuffVoce)

            Posizione = Buffer.IndexOf(">Promo<", Posizione + 1)

        End While



    End Sub

    Private Sub TestMultiPagina()

        Dim NomeSorgenteFronte As String = "c:\temp\Binder1.pdf"

        Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(NomeSorgenteFronte)

        For i As Integer = 1 To NumPag

            Dim PathEnd As String = NomeSorgenteFronte.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

            FormerHelper.PDF.EstraiPaginaFromPdf(NomeSorgenteFronte, PathEnd, i)

        Next

    End Sub

    Private Sub UnificaOrdiniVecchi()

        Dim Counter As Integer = 0

        Using mgr As New OrdiniDAO
            Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdConsProgrammata desc"},
                New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.PagatoInteramente),
                New LUNA.LunaSearchParameter(LFM.Ordine.Preventivo, enSiNo.Si),
                New LUNA.LunaSearchParameter("Year(DataIns)", 2016, "<="))

            For Each O As Ordine In l

                Using C As ConsegnaProgrammata = O.ConsegnaAssociata

                    Dim R As Ricavo = C.ListaDocumenti.Find(Function(x) x.Tipo = enTipoDocumento.Preventivo)

                    If Not R Is Nothing Then

                        'qui ho il preventivo devo vedere se ha un pagamento associato 

                        If R.PagatoInteramente Then
                            Dim IdCons As Integer = 0
                            Dim PresentiPiuConsegne As Boolean = False
                            For Each Oric As Ordine In R.ListaOrdini
                                If IdCons = 0 Then
                                    IdCons = Oric.IdCons
                                Else
                                    If IdCons <> Oric.IdCons Then
                                        PresentiPiuConsegne = True
                                        Exit For
                                    End If
                                End If
                            Next

                            If PresentiPiuConsegne Then
                                Counter += 1
                                txtDebug.Text &= Counter & ControlChars.NewLine
                                'qui devo sganciare tutti gli ordini dalla loro consegna e crearne una nuova allo stesso giorno del documento fiscale
                                Using mgrC As New ConsegneProgrammateDAO

                                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                                        Try
                                            tb.TransactionBegin()
                                            Dim ConsegnaProgrammataInCorso As ConsegnaProgrammata = Nothing
                                            For Each OInt As Ordine In R.ListaOrdini

                                                Dim IdConsVecchia As Integer = OInt.IdCons

                                                mgrC.EliminaOrdineDaConsegna(IdConsVecchia, OInt.IdOrd)

                                                ConsegnaProgrammataInCorso = mgrC.RegistraConsegnaOrdineSuGiorno(OInt.IdOrd,
                                                                                OInt.IdCorriere,
                                                                                R.DataRicavo,
                                                                                OInt.IdRub,
                                                                                enMomentoConsegna.Mattina,
                                                                                OInt.IdIndirizzo,
                                                                                ConsegnaProgrammataInCorso)

                                                mgrC.EliminaConsegnaSeVuota(IdConsVecchia)

                                            Next
                                            tb.TransactionCommit()
                                        Catch ex As Exception
                                            tb.TransactionRollBack()
                                            MessageBox.Show(ex.Message)
                                        End Try

                                    End Using

                                End Using

                            End If

                            Application.DoEvents()
                        End If

                    End If

                End Using

            Next

        End Using

        MessageBox.Show(Counter)

    End Sub

    Private Function ArchiviaOrdini() As Integer

        'FormerDaemon_Server.Syncronizer.ProceduraGiornaliera.ArchiviazionePreventivi()


        Exit Function

        Dim ris As Integer = 0

        Using mgr As New OrdiniDAO
            Dim AnnoRiferimento As Integer = 0
            Dim MeseRiferimento As Integer = 0
            Dim DataRiferimento As Date = Now.Date.AddMonths(-1)
            AnnoRiferimento = DataRiferimento.Year
            MeseRiferimento = DataRiferimento.Month


            Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdConsProgrammata desc"},
                New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.PagatoInteramente),
                New LUNA.LunaSearchParameter(LFM.Ordine.Preventivo, enSiNo.Si))

            Dim ListR As New List(Of Ricavo)

            Dim data1 As New Date(2019, 6, 1)
            Dim data2 As New Date(2018, 11, 22)

            Dim differenza As Integer = DateDiff(DateInterval.Day, data2, data1)


            l = l.FindAll(Function(x) DateDiff(DateInterval.Day, x.DataIns, DataRiferimento) > 1)
            l.Sort(Function(x, y) y.DataIns.CompareTo(x.DataIns))




            For Each O As Ordine In l

                If Not O.ConsegnaAssociata Is Nothing Then

                    Using C As ConsegnaProgrammata = O.ConsegnaAssociata

                        Dim R As Ricavo = C.ListaDocumenti.Find(Function(x) x.Tipo = enTipoDocumento.Preventivo)

                        If Not R Is Nothing Then

                            'qui ho il preventivo devo vedere se ha un pagamento associato 

                            If R.PagatoInteramente Then
                                Dim IdCons As Integer = 0
                                For Each Oric As Ordine In R.ListaOrdini
                                    If IdCons = 0 Then
                                        IdCons = Oric.IdCons
                                    Else
                                        If IdCons <> Oric.IdCons Then
                                            IdCons = 0
                                            Exit For
                                        End If
                                    End If
                                Next

                                If IdCons <> 0 Then
                                    'ok qui devo cancellare il pagamento , il preventivo e tutti gli ordini a preventivo contenuti nel preventivo

                                    If ListR.FindAll(Function(x) x.IdRicavo = R.IdRicavo).Count = 0 Then
                                        ListR.Add(R)
                                    End If
                                End If
                                Application.DoEvents()
                            End If

                        End If

                    End Using

                End If

            Next

            'ora qui in listR ho la lista dei documetni da cancellare
            Randomize()

            ris = ListR.Count
            MessageBox.Show(ris)
            'For Each R As Ricavo In ListR
            '    LogMe("Archiviazione Ricavo " & R.IdRicavo)
            '    Application.DoEvents()
            '    Using t As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            '        Try
            '            Dim IsCopyOk As Boolean = False

            '            Dim PathF As String = FormerPath.PathArchivioOrdini & R.IdRub & "\"
            '            PathF = PathF.Replace("O:\", "N:\")

            '            FormerHelper.File.CreateLongPath(PathF)
            '            LogMe("-LAVORO I SORGENTI")
            '            For Each o As Ordine In R.ListaOrdini
            '                Application.DoEvents()
            '                For Each S As FileSorgente In o.ListaSorgenti
            '                    LogMe("--Lavoro Sorgente '" & S.FilePath & "'")
            '                    Dim FileSorgente As String = S.FilePath

            '                    FileSorgente = FileSorgente.ToLower.Replace("z:\", "w:\")

            '                    If File.Exists(FileSorgente) Then
            '                        Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(FileSorgente)
            '                        Dim NomeFileDest As String = NomeFile

            '                        Dim risPulizia As Match = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
            '                        While risPulizia.Success
            '                            NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
            '                            risPulizia = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
            '                        End While

            '                        'NomeFileDest = NomeFileDest.Replace(o.IdCom & "-", String.Empty)
            '                        'NomeFileDest = NomeFileDest.Replace(o.IdOrd & "_", String.Empty)

            '                        risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
            '                        While risPulizia.Success
            '                            NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
            '                            risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
            '                        End While

            '                        Dim Estensione As String = FormerLib.FormerHelper.File.GetEstensione(NomeFileDest)
            '                        NomeFileDest = NomeFileDest.Substring(0, NomeFileDest.Length - Estensione.Length)

            '                        Dim Rnd As New Random
            '                        NomeFileDest &= Rnd.Next(1000000, 9999999) & "." & Estensione

            '                        NomeFileDest.Replace(" ", "_")

            '                        Dim DestPath As String = PathF & NomeFileDest

            '                        LogMe("---Copio '" & S.FilePath & "' al path '" & DestPath & "'")
            '                        FileCopy(FileSorgente, DestPath)
            '                    Else
            '                        LogMe("---Sorgente '" & S.FilePath & "' non trovato")
            '                    End If

            '                Next
            '            Next

            '            IsCopyOk = True

            '            If IsCopyOk Then
            '                t.TransactionBegin()
            '                LogMe("-ELIMINO I PAGAMENTI")
            '                Using mgrP As New PagamentiDAO
            '                    For Each P As Pagamento In R.ListaPagamenti
            '                        mgrP.Delete(P)
            '                    Next
            '                End Using

            '                Dim IdConsToDelete As Integer = 0

            '                For Each o As Ordine In R.ListaOrdini
            '                    LogMe("-LAVORO ORDINE " & o.IdOrd)
            '                    Dim IdOrdToLav As Integer = o.IdOrd
            '                    IdConsToDelete = o.IdConsProgrammata
            '                    LogMe("--Salvo Ordine Archiviato")
            '                    Using OArch As New Archiviato(o)
            '                        OArch.Save()
            '                    End Using
            '                    LogMe("--Cancello sorgenti")

            '                    For Each S As FileSorgente In o.ListaSorgenti

            '                        Dim PathToDelete As String = S.FilePath.ToLower.Replace("z:\", "w:\")

            '                        If File.Exists(PathToDelete) Then
            '                            Try
            '                                MgrFormerIO.FileDelete(PathToDelete)
            '                            Catch ex As Exception
            '                                LogMe("---Errore nella cancellazione del sorgente '" & S.FilePath & "'")
            '                            End Try
            '                        End If
            '                    Next
            '                    Using mgrS As New FileSorgentiDAO
            '                        mgrS.DeleteByIdOrd(o.IdOrd)
            '                    End Using
            '                    LogMe("--Cancello ordine")
            '                    Using mgrO As New OrdiniDAO
            '                        mgrO.Delete(o)
            '                    End Using
            '                    LogMe("--Sgancio dalla consegna e cancello in caso la consegna")
            '                    Using mgrC As New ConsegneProgrammateDAO
            '                        mgrC.EliminaOrdineDaConsegna(IdConsToDelete, o.IdOrd)
            '                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.ConsegnaIdConsToDelete, "Ordini Archiviati in questa consegna")
            '                        mgrC.EliminaConsegnaSeVuota(IdConsToDelete)
            '                    End Using

            '                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrdToLav, "Ordine Archiviato")

            '                Next

            '                LogMe("-ELIMINO LA VOCE DI RICAVO")
            '                Using mgrr As New RicaviDAO
            '                    mgrr.Delete(R)
            '                End Using
            '                ris += 1
            '                t.TransactionCommit()
            '            End If

            '        Catch ex As Exception
            '            t.TransactionRollBack()
            '            LogMe("Errore nell'archiviazione ordini",, ex)
            '        End Try

            '    End Using
            '    'Exit For
            '    LogMe("Archiviazione Ricavo " & R.IdRicavo & " TERMINATA")
            'Next

        End Using

        Return ris

    End Function

    Private Sub TestFtpFile()

        Dim Ftp As New FTPclient(FConfiguration.Ftp.ServerNameSviluppo,
FConfiguration.Ftp.ServerLoginSviluppo,
FConfiguration.Ftp.ServerPwdSviluppo)
        Try
            Dim PathRemotoDir As String = "/tipografiaformer.it/listino/foto/493"
            Dim x As FTPdirectory = Ftp.ListDirectoryDetail(PathRemotoDir)

            For Each ss As FTPfileInfo In x.GetFiles

                Stop
                Ftp.FtpDelete(ss.FullName)
            Next

        Catch ex As Exception
            Stop
        End Try

        Ftp.Dispose()
        Ftp = Nothing

    End Sub

    Private Sub BackupDb()

        Using c As Data.IDbCommand = LUNA.LunaContext.Connection.CreateCommand

            Dim Giorno As String = Now.Date.ToString("yyyy-MM-dd") & ".bak"
            Dim sql As String = "BACKUP DATABASE [FormerSql] TO DISK = N'C:\Lavoro\" & Giorno & "' WITH INIT , NOUNLOAD , NAME = N'FormerSqlBackup', NOSKIP , STATS = 10, NOFORMAT"
            c.CommandText = sql
            c.ExecuteNonQuery()

        End Using

    End Sub


    Private Sub PulisciDB()

        Dim Sql As String = "DELETE from T_VociFat where IdDoc not in (select idricavo from t_contabricavi)"

        Using myCommand As DbCommand = LUNA.LunaContext.Connection.CreateCommand
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_Commesse where IdCom not in (select distinct IdCom from t_Ordini)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_CommesseCrono where IdCom not in (select IdCom from T_Commesse)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_OrdiniCrono where IdOrd  not in (select IdOrd from t_Ordini)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_LavLog  where IdOrd <>0 and IdOrd not in (select IdOrd from t_Ordini)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_LavLog  where IdCom <>0 and IdCom not in (select IdCom from T_Commesse)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from T_Prodotti where IdProd not in (select distinct IdProd from T_Ordini)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from TR_ConsOrd where IdOrd not in (select IdOrd from t_Ordini)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()

            Sql = "DELETE from TR_ConsOrd where IdCons not in (select IdCons from T_Cons)"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()
        End Using

    End Sub

    Private Sub CheckNLastre()


        Dim NumLastreNecessarie As Integer = 0
        Using M As New ModelloCommessa
            M.Read(58)
            Using mgr As New CommesseDAO
                Dim X(0) As Integer

                X(0) = 79710

                NumLastreNecessarie = mgr.GetLastreNecessarie(M, X)
            End Using
        End Using

        MessageBox.Show(NumLastreNecessarie)



    End Sub

    Private Sub SistemaCartelleLog()

        Dim D As New DirectoryInfo(FormerPath.PathLog)

        For Each f As FileInfo In D.GetFiles("*.txt")
            Dim CopiaOk As Boolean = False

            Try
                Dim NomeDir As String = f.Name.Substring(0, f.Name.IndexOf("."))

                Dim PathDir As String = FormerPath.PathLog & NomeDir & "\"

                FormerLib.FormerHelper.File.CreateLongPath(PathDir)

                Dim PathFileNew As String = PathDir & f.Name

                If File.Exists(PathFileNew) Then
                    'qui devo integrare il nuovo con il vecchio
                    Dim Buffer As String = String.Empty
                    Using r As New StreamReader(f.FullName)
                        Buffer = r.ReadToEnd
                    End Using

                    Using r As New StreamReader(PathFileNew)
                        Buffer &= r.ReadToEnd
                    End Using

                    Using W As New StreamWriter(PathFileNew)
                        W.Write(Buffer)
                    End Using

                Else
                    File.Copy(f.FullName, PathFileNew)
                End If

                CopiaOk = True

            Catch ex As Exception

            End Try

            If CopiaOk Then
                MgrFormerIO.FileDelete(f.FullName)
            End If
            Application.DoEvents()
        Next


    End Sub

    Private Sub GeneraListino()

        Try
            Dim L As New ListinoUtente
            L.IdUt = 7
            L.Nominativo = "Former"
            L.PercRicarico = 0
            'L.ColoreSfondo = lblColSfondo.BackColor
            'L.ColoreContrasto = lblColPrimoPiano.BackColor

            'FormerWebApp.LogMe("GENERAZIONE LISTINO - Percentuale Ricarico: " & L.PercRicarico, UtenteConnesso)

            'Dim PathFileDest As String = Server.MapPath("/output") ' & "\listino.pdf"
            Dim PathTimeStamp As String = String.Empty
            Dim PathFileDest As String = String.Empty

            'PathFileDest &= "\" & UtenteConnesso.IdUtente & "\"

            'If Directory.Exists(PathListino) = False Then
            '   Directory.CreateDirectory(PathListino)
            'End If

            'FormerLib.FormerHelper.File.CreateLongPath(PathListino)

            ' FormerWebApp.LogMe("GENERAZIONE LISTINO - Creata Cartella: " & PathListino, UtenteConnesso)

            'PathTimeStamp = PathListino & "timestamp.txt"

            PathFileDest = "c:\temp\ListinoFormerOttobre2017.pdf"

            If File.Exists(PathFileDest) Then
                Try
                    MgrFormerIO.FileDelete(PathFileDest)
                Catch ex As Exception

                End Try
            End If

            MGRListini.CreaCatalogo(PathFileDest, L,, True)

            Using w As New StreamWriter(PathTimeStamp)
                w.Write(Now.ToString)
            End Using

            FormerLib.FormerHelper.File.ShellExtended(PathFileDest)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TestLoadFatture()

        Using mgr As New FW.ConsegneDAO

            Dim l As List(Of FW.Consegna) = mgr.FindAll("DataInserimento Desc,Giorno Desc",
                New FW.LUNA.LunaSearchParameter("Idut", 2016),
                New FW.LUNA.LunaSearchParameter("datediff(""d"",DataInserimento,GetDate())", 365, "<="),
                New FW.LUNA.LunaSearchParameter("IdStatoConsegna", "(" & enStatoConsegna.InConsegna & "," & enStatoConsegna.Consegnata & ")", " IN "))

            l = l.FindAll(Function(x) x.ListaOrdini.Count > 0)

            Dim tot As Integer = l.Count

        End Using

    End Sub

    Private Sub TestFattureFtp()

        Dim F As FileInfo = New FileInfo("c:\temp\2017-1212.pdf")

        Dim IdConsegna As Integer = 0
        Dim PosizionePunto As Integer = F.Name.IndexOf(".")
        Dim AnnoDocumento As Integer = F.Name.Substring(0, 4)
        Dim NumeroDocumento As Integer = F.Name.Substring(5, PosizionePunto - 4)

        Using Mgr As New RicaviDAO
            IdConsegna = Mgr.GetIdConsegnaFromFattura(AnnoDocumento, NumeroDocumento, MgrAziende.IdAziende.AziendaSrl)
        End Using
        'LogMe(" - IdConsegna " & IdConsegna)

        If IdConsegna Then
            Dim IdConsOnline As Integer = 0
            Using mgr As New FW.ConsegneDAO
                IdConsOnline = mgr.GetIdConsFromIdInt(IdConsegna)
            End Using
            'LogMe(" - IdConsegna Online " & IdConsOnline)

            If IdConsOnline Then
                'il path e' dentro Consegne/IdConsegna/
                Dim PathRemoto As String = "/tipografiaformer.it/consegne/" & IdConsOnline & "/" & F.Name
                Using Ftp As New FTPclient(FConfiguration.Ftp.ServerNameProduzione, FConfiguration.Ftp.ServerLoginProduzione, FConfiguration.Ftp.ServerPwdProduzione)
                    'LogMe(" - Upload " & F.Name & " su Consegna " & IdConsOnline)

                    Try
                        Ftp.FtpCreateDirectory("tipografiaformer.it/consegne/" & IdConsOnline)
                    Catch ex As Exception

                    End Try
                End Using
            End If
        End If

    End Sub

    'Private Sub RiempiTemplateJOB(NomeFileDest As String,
    '                              collOrd As OrdiniCTP)

    '    Dim bufferFinale As String = String.Empty
    '    Dim PathDir As String = FormerHelper.File.TranslateRealDrivePath(FormerPath.PathJOB & collOrd.IdCom & "\")

    '    Dim ContNumFronte As Integer = 1
    '    Dim ContNumRetro As Integer = 2
    '    'qui vado a fare le varie sostituzioni all'interno del file JOB

    '    Dim CountSegnature As Integer = 1

    '    If collOrd.Commessa.Segnature Then
    '        CountSegnature = collOrd.Commessa.Segnature
    '    End If

    '    Using R As New StreamReader(NomeFileDest)
    '        Dim FileEncoding As String = String.Empty
    '        While Not R.EndOfStream
    '            Dim Riga As String = R.ReadLine

    '            If Riga.StartsWith("%%FileEncoding: ") Then
    '                FileEncoding = Riga.Substring(15).Trim
    '            End If


    '            bufferFinale &= Riga & ControlChars.NewLine
    '            If Riga.StartsWith("%SSiPrepsVer:") Then
    '                'qui ci devo inserire i file ref partendo non so perche da 6
    '                '%SSiJobFileRef: 8 'file://hw20952-62/JobData/Pdf_Ok/39563/001-39563-81684_F_otticabigli_a.pdf' 8 1264748899 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 1264748899
    '                Dim ModelloRiga As String = "%SSiJobFileRef: {1} 'file:{2}' {1} {3} 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 {3}"
    '                Dim Progressivo As Integer = 6
    '                For Each O As OrdineCTP In collOrd.ListaOrdini
    '                    O.ProgressivoAssegnato = Progressivo
    '                    For Each s As FileSorgente In O.Ordine.ListaSorgenti
    '                        Dim NuovoNomeFileRiga As String = s.FilePath

    '                        NuovoNomeFileRiga = FormerHelper.File.TranslateRealDrivePath(NuovoNomeFileRiga)

    '                        NuovoNomeFileRiga = NuovoNomeFileRiga.Replace("\", "/")
    '                        Dim RigaToWrite As String = ModelloRiga.Replace("{2}", NuovoNomeFileRiga)
    '                        RigaToWrite = RigaToWrite.Replace("{1}", Progressivo)
    '                        'If FormerDebug.DebugAttivo = False Then
    '                        'Dim f As New FileInfo(NuovoNomeFile)
    '                        RigaToWrite = RigaToWrite.Replace("{3}", FileEncoding)
    '                        'End If
    '                        bufferFinale &= RigaToWrite & ControlChars.NewLine
    '                        Progressivo += 1
    '                    Next

    '                Next

    '            ElseIf Riga.StartsWith("%SSiJobFileRef: -4") Then
    '                'qui ci dveo inserire i jobpage partendo sempre da 6
    '                Dim ModelloRiga As String = "%SSiJobPage: {1} 1 0.00000 0.00000 1.00000 1.00000 {2} 0.00000 0.00000 '' 1 -1 1"

    '                For Each O As OrdineCTP In collOrd.ListaOrdini
    '                    For i As Integer = 1 To O.Duplicati
    '                        Dim RigaToWrite As String = String.Empty
    '                        If O.Ordine.ListaSorgenti.Count = 1 Then
    '                            RigaToWrite = ModelloRiga.Replace("{1}", O.ProgressivoAssegnato)
    '                            RigaToWrite = RigaToWrite.Replace("{2}", GetOrientamento(O.Ordine.ListaSorgenti(0), collOrd.Commessa.ModelloCommessa, O))
    '                            bufferFinale &= RigaToWrite & ControlChars.NewLine
    '                            'se il modello e' fronte retro aggiungo il retro
    '                            If collOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.Si Then
    '                                RigaToWrite = ModelloRiga.Replace("{1}", "-1")
    '                                RigaToWrite = RigaToWrite.Replace("{2}", "3")
    '                                bufferFinale &= RigaToWrite & ControlChars.NewLine
    '                            End If
    '                        Else 'If O.Ordine.ListaSorgenti.Count = 2 Then
    '                            For Each s As FileSorgente In O.Ordine.ListaSorgenti
    '                                RigaToWrite = ModelloRiga.Replace("{1}", O.ProgressivoAssegnato)
    '                                RigaToWrite = RigaToWrite.Replace("{2}", GetOrientamento(s, collOrd.Commessa.ModelloCommessa, O))
    '                                bufferFinale &= RigaToWrite & ControlChars.NewLine
    '                            Next
    '                            'Else
    '                            'qui è per multipagina

    '                        End If
    '                    Next
    '                Next
    '            End If
    '            'End If
    '        End While
    '    End Using

    '    'qui lavoro sulle segnature 

    '    If CountSegnature > 1 Then
    '        'individuo il blocco segnature e lo duplico per ogni segnature che ci sarà portando avanti progressivo e counter iniziale 
    '        Dim BufferWithSegnature As String = String.Empty
    '        Dim RigaSegnatura As String = String.Empty
    '        Dim ModelloJobDelivery As String = "%SSiJobDelivery: {1} {2} 1 1 0"
    '        For Each riga As String In bufferFinale.Split(vbLf)
    '            riga = riga.TrimEnd(vbCr)
    '            If riga.StartsWith("%SSiSigUsed:") Then
    '                RigaSegnatura = riga
    '                BufferWithSegnature &= FormerConst.CTP.MarcatoreRigaSegnatura
    '            ElseIf riga.StartsWith("%SSiJobDelivery:") Then
    '                'niente
    '            Else
    '                BufferWithSegnature &= riga & ControlChars.NewLine
    '            End If
    '        Next

    '        Dim BufferToReplace As String = String.Empty
    '        Dim ProgressivoIniziale As Integer = 1
    '        For i As Integer = 1 To CountSegnature
    '            BufferToReplace &= RigaSegnatura & ControlChars.NewLine
    '            Dim RigaToIns As String = ModelloJobDelivery.Replace("{2}", i)
    '            RigaToIns = RigaToIns.Replace("{1}", ProgressivoIniziale)

    '            'aumento il progressivo iniziale del numero di spazi del modello
    '            ProgressivoIniziale += collOrd.Commessa.ModelloCommessa.NumSpazi

    '            BufferToReplace &= RigaToIns & ControlChars.NewLine
    '        Next

    '        BufferWithSegnature = BufferWithSegnature.Replace(FormerConst.CTP.MarcatoreRigaSegnatura, BufferToReplace)

    '        bufferFinale = BufferWithSegnature

    '    End If

    '    Using w As New StreamWriter(NomeFileDest.Replace(".j", ".a.j"))
    '        w.Write(bufferFinale)
    '    End Using

    'End Sub

    Private Function GetOrientamento(F As FileSorgente,
    M As ModelloCommessa,
    O As OrdineCTP) As Integer
        Dim ris As Integer = 3
        Dim OrientamentoPrevisto As enTipoOrientamento = enTipoOrientamento.Orizzontale
        Dim OrientamentoTrovato As enTipoOrientamento = enTipoOrientamento.NonSpecificato
        OrientamentoTrovato = FormerLib.FormerHelper.PDF.GetOrientamentoPdf(F.FilePath.Replace("Z:", "W:"))

        Dim ModComFP As ModComFormProd = M.FormatiProdotto.Find(Function(x) x.IdFormProd = O.Ordine.ListinoBase.IdFormProd)

        Dim AngoloRotazione As Integer = 0

        If ModComFP Is Nothing Then
            ModComFP = M.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = O.Ordine.ListinoBase.FormatoProdotto.IdFormCarta)
        End If
        OrientamentoPrevisto = ModComFP.Orientamento

        If F.NumPagina And Not ModComFP Is Nothing Then
            If OrientamentoPrevisto = enTipoOrientamento.Orizzontale Then
                If OrientamentoTrovato = enTipoOrientamento.Verticale Then
                    If F.NumPagina Mod 2 = 0 Then ' retro
                        '-270
                        AngoloRotazione = -270
                    Else 'fronte
                        '-90
                        AngoloRotazione = -90
                    End If
                End If
            ElseIf OrientamentoPrevisto = enTipoOrientamento.Verticale Then
                If OrientamentoTrovato = enTipoOrientamento.Orizzontale Then
                    If F.NumPagina Mod 2 = 0 Then ' retro
                        '-270
                        AngoloRotazione = -270
                    Else 'fronte
                        '-90
                        AngoloRotazione = -90
                    End If
                End If
            End If
        End If

        If AngoloRotazione = -270 Then
            ris = 2
        ElseIf AngoloRotazione = -90 Then
            ris = 0
        End If

        Return ris
    End Function

    Private Sub TestExportJOB()

        Dim IdCom As Integer = 39498

        Dim NomeFileDest As String = "C:\temp\" & IdCom & ".job"

        'qui devo andare a rieditare il JOB appena copiato 

        Using com As New Commessa
            com.Read(IdCom)
            Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(com)
            'MgrCTP.EsportaCTP(collOrd)
            MgrCTP.EsportaJOB(IdCom, collOrd)
        End Using

    End Sub

    Private Sub ResizePDF()
        Dim PathIn As String = "O:\OrdiniDaVerificare\81971_F_cal_tabaccheria.pdf"
        'Dim PathOut As String = "C:\temp\out.pdf"

        FormerHelper.PDF.ResizePDF(PathIn, 290, 69)
        '        FormerLib.FormerHelper.File.ShellExtended(PathIn)


    End Sub

    Private Sub TestDataConsegna()

        Dim DataIns As New Date(2017, 11, 7) 'martedi 7
        Dim DataCons As New Date(2017, 11, 10) 'venerdi 10 

        Dim DataRis As Date = MgrDataConsegna.ConfermaDataConsegna(DataIns,
            DataCons,
            enCorriere.RitiroCliente)

        MessageBox.Show(DataRis)

    End Sub

    Private Sub StampaReticolo()

        Dim x As New FormerPrinter.myFPrinter

        x.StampaReticolo()

        x = Nothing

    End Sub

    Private Sub CalcolaRisorseUtilizzate()

        Using mgr As New CommesseDAO
            Dim Qta As Single = mgr.CalcolaQtaRisorsaNecessaria(enRepartoWeb.StampaOffset,
                            1,
                            10000,
                            29)
            MessageBox.Show(Qta)
        End Using

    End Sub

    Private Sub TestJdfPath()

        Dim Path As String = "C:\temp\20171201104903802920.jdf"
        Dim NewPathJdfFile As String = "Z:\Commesse\39560\20171201104903802920.jdf"

        Dim Buffer As String = String.Empty
        Using R As New StreamReader(Path)
            Buffer = R.ReadToEnd
        End Using

        Dim NewPathJ As String = NewPathJdfFile
        NewPathJ = FormerHelper.File.TranslateRealDrivePath(NewPathJ)
        NewPathJ = NewPathJ.Replace("\", "/")
        'ora cerco il marcatore JDFMarksFlats

        Dim Righe() As String = Buffer.Split(vbLf)
        Dim NewBuffer As String = String.Empty

        For Each riga As String In Righe

            Dim Posiz As Integer = riga.IndexOf("/JDFMarksFlats/")

            If Posiz <> -1 Then
                'questa riga va cambiata con il path nuovo
                Dim RigaNew As String = riga
                Posiz = RigaNew.IndexOf("file:")
                RigaNew = RigaNew.Substring(0, Posiz) & "file:" & NewPathJ & """/>"
                NewBuffer &= RigaNew & ControlChars.NewLine
            Else
                NewBuffer &= riga & ControlChars.NewLine
            End If

        Next

        'Dim OldPathJ As String = OldPathJdfFile
        'OldPathJ = FormerHelper.File.TranslateRealDrivePath(OldPathJ)
        'OldPathJ = OldPathJ.Replace("\", "/")

        'Buffer = Buffer.Replace(OldPathJ, NewPathJ)

        Using w As New StreamWriter(Path)
            w.Write(NewBuffer)
        End Using

    End Sub

    Private Sub PulisciCartellaTemp()

        Dim D As New DirectoryInfo("W:\temp\")
        Dim l As List(Of FileSorgente) = Nothing
        Dim lO As List(Of Ordine) = Nothing
        Dim NoRis As New List(Of String)
        Using mgrO As New OrdiniDAO
            Using mgr As New FileSorgentiDAO
                For Each F As FileInfo In D.GetFiles("*.*")
                    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, F.FullName.Replace("W", "Z")))

                    If l.Count = 0 Then
                        lO = mgrO.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, F.FullName.Replace("W", "Z")))
                        If lO.Count = 0 Then
                            NoRis.Add(F.FullName)
                        End If
                    End If

                Next
            End Using
        End Using

    End Sub

    Private Sub CreazioneCartelleCommesse()

        Using mgr As New CommesseDAO

            Dim l As List(Of Commessa) = mgr.FindAll(LFM.Commessa.IdCom,
                    New LUNA.LunaSearchParameter(LFM.Commessa.IdCom, "(40175,26316,26310,22638,22401,19846,16882,15899,15434,15433,15069,15065,15042,14902,7897)", "IN"))

            For Each C As Commessa In l

                Dim Path As String = FormerPath.PathCommesse & C.IdCom & "\"
                FormerHelper.File.CreateLongPath(Path.ToLower.Replace("z:", "w:"))
                For Each O As Ordine In C.ListaOrdini
                    'sposto l'anteprima
                    If O.FilePath.ToLower.StartsWith(Path.ToLower) = False AndAlso O.FilePath.Length <> 0 Then
                        Dim OldPath As String = O.FilePath
                        'qui il sorgente va spostato
                        Dim NuovoPath As String = FormerHelper.File.EstraiNomeFile(OldPath)
                        NuovoPath = Path & NuovoPath
                        File.Copy(OldPath.ToLower.Replace("z:", "w:"), NuovoPath.ToLower.Replace("z:", "w:"))

                        O.FilePath = NuovoPath
                        O.Save()
                    End If

                    For Each S As FileSorgente In O.ListaSorgenti
                        If S.FilePath.ToLower.StartsWith(Path.ToLower) = False Then
                            Dim OldPath As String = S.FilePath
                            'qui il sorgente va spostato
                            Dim NuovoPath As String = FormerHelper.File.EstraiNomeFile(OldPath)
                            NuovoPath = Path & C.IdCom & "-" & NuovoPath
                            If File.Exists(NuovoPath.ToLower.Replace("z:", "w:")) = False Then File.Copy(OldPath.ToLower.Replace("z:", "w:"), NuovoPath.ToLower.Replace("z:", "w:"))

                            S.FilePath = NuovoPath
                            S.Save()

                        End If
                    Next
                    Application.DoEvents()

                Next

                'Path = Path.ToLower.Replace("z", "w")

            Next

        End Using

    End Sub

    Private Sub CambiaTestoInPdf()

        Try
            Dim SourcePdfFilePath As String = "C:\temp\2017121315020686374.pdf"

            Dim TextToChange As String = "2017121315020686374"
            Dim TextIdCom As String = "40123"

            Dim document As text.pdf.PdfDocument = New text.pdf.PdfDocument

            FormerHelper.File.ShellExtended(SourcePdfFilePath)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub InserisciCalendari2018Gabetti()

        'ProxyDocumenti.CreaDocumenti(101617, False, False, 0)
        'Exit Sub

        Dim IdProd As Integer = 8151
        Dim DescrRiga As String = "Calendario 2018 Gabetti"
        Dim ListaIdRub As String = "(9745)"
        Dim DataCons As New Date(2017, 12, 19)
        Dim IdCorr As Integer = enCorriere.RitiroCliente
        Dim Qta As Integer = 75
        Dim Prezzo As Decimal = 2.13
        Dim Totale As Decimal = 160
        Dim NumColli As Integer = 3
        Dim Peso As Integer = 9
        Dim PathAnteprimaOrig As String = "C:\temp\gabetti\anteprima.jpg"
        Dim PathSorgenteOrig As String = "C:\temp\gabetti\sorgente.pdf"

        Using mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.IdRub, ListaIdRub, "IN"))

            Using P As New Prodotto
                P.Read(IdProd)
                For Each V As VoceRubrica In l
                    'inserisco consegna, ordine, fattura, voci fattura
                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                        Try

                            'controllo se c'e' gia un ordine per questo cliente di questo tipo di prodotto
                            Using mgrO As New OrdiniDAO
                                Dim lO As List(Of Ordine) = mgrO.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, V.IdRub),
                                        New LUNA.LunaSearchParameter(LFM.Ordine.IdProd, IdProd))
                                If lO.Count = 0 Then

                                    tb.TransactionBegin()

                                    'qui lo devo inserire
                                    'prima creo la consegna 
                                    Dim C As New ConsegnaProgrammata
                                    C.Giorno = DataCons
                                    C.IdCorr = IdCorr
                                    C.MatPom = enMomentoConsegna.Pomeriggio
                                    C.IdRub = V.IdRub
                                    C.Peso = Peso
                                    C.NumColli = NumColli
                                    C.IdPagam = enMetodoPagamento.BonificoBancario
                                    C.TipoDoc = enTipoDocumento.Fattura
                                    C.Blocco = enSiNo.Si
                                    C.Save()
                                    'ora ho la consegna mi mancano colli e peso
                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, C.IdCons, "CREATA NUOVA CONSEGNA CON PROCEDURA AUTOMATIZZATA PER CALENDARI GABETTI 2018")

                                    Dim O As New Ordine
                                    O.IdRub = V.IdRub
                                    O.IdProd = IdProd
                                    O.IdCorriere = IdCorr
                                    O.Preventivo = enSiNo.No
                                    O.RilascioCli = 1
                                    O.NomeLavoro = DescrRiga
                                    O.UsaNomeLavoroInFattura = enSiNo.Si
                                    O.DataIns = DataCons
                                    O.DataPrevConsegna = DataCons
                                    O.IdTipoProd = enRepartoWeb.StampaOffset
                                    O.Stato = enStatoOrdine.ProntoRitiro
                                    O.Qta = Qta
                                    O.PeriodoPrevConsegna = enMomentoConsegna.Pomeriggio
                                    O.NFogli = P.NumFacciate
                                    O.TipoRetro = enTipoRetro.RetroBianco
                                    O.OrdMail = True
                                    O.PrezzoProd = Prezzo
                                    O.TotaleForn = Totale
                                    O.Save()

                                    Dim PathAnteprima As String = FormerPath.PathTemp & O.IdOrd & "_anteprima.jpg"
                                    FileCopy(PathAnteprimaOrig, PathAnteprima)
                                    O.FilePath = PathAnteprima.Replace("W:", "Z:")
                                    O.Save()

                                    'qui salvo l'unico sorgente 
                                    Dim PathSorgente As String = FormerPath.PathTemp & O.IdOrd & "_sorgente.pdf"
                                    FileCopy(PathSorgenteOrig, PathSorgente)

                                    Dim CO As New ConsProgrOrdini
                                    CO.IdOrd = O.IdOrd
                                    CO.IdCons = C.IdCons
                                    CO.Save()

                                    Dim S As New FileSorgente
                                    S.IdOrd = O.IdOrd
                                    S.FilePath = PathSorgente.Replace("W:", "Z:")
                                    S.NumPagina = 1
                                    S.Save()

                                    'ora qui devo emettere la fattura in automatico
                                    ProxyDocumenti.CreaDocumenti(C.IdCons, False, True, 0)

                                    tb.TransactionCommit()
                                End If
                            End Using

                        Catch ex As Exception
                            tb.TransactionRollBack()

                        End Try

                    End Using
                Next

            End Using

        End Using

    End Sub

    Private Function CalcolaPrezzi(L As ListinoBase,
        Qta As Single) As RisPrezzoIntermedio
        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)

        Dim listaBaseB As List(Of ILavorazioneB) = L.LavorazioniBaseB

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(L, listaBaseB, , False)

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
        '                                                                                 L,
        '                                                                                 _Risultato)

        L.NumFacciate = L.FaccMin

        Dim R As RisPrezzoIntermedio = Nothing

        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Dim QtaRichiesta As Single = 0
            Dim QtaSecondaria As Integer = 0

            Dim LatoFisso As Integer = (L.FormatoProdotto.FormatoCarta.Larghezza * 10)
            Dim LatoRiferimento As Single = Math.Sqrt(FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio)

            QtaSecondaria = ((LatoRiferimento * LatoRiferimento)) * Qta
            QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(LatoRiferimento,
                                        LatoRiferimento,
                                        enTipoOrientamento.Orizzontale,
                                        LatoFisso,
                                        QtaRichiesta)
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB, QtaSecondaria,, False,, LatoRiferimento, LatoRiferimento)

        Else
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB,,, False)
        End If

        Return R

    End Function

    Private Sub AggiornaIndiciRicerca()
        'Dim ServerProduzione As New ServerSito("Produzione")

        'ServerProduzione.SQLConnectionString = "Server=95.110.147.224;Database=FormerWeb;User Id=sa;Password=tgHi9MaEQA;"
        'ServerProduzione.FTPLogin = FConfiguration.Ftp.ServerLoginProduzione
        'ServerProduzione.FTPPwd = FConfiguration.Ftp.ServerPwdProduzione
        'ServerProduzione.FTPHost = FConfiguration.Ftp.ServerNameProduzione

        'MgrPubblicazioneWeb.ApriConnessioneRemota(ServerProduzione)

        'Using mgr As New ListinoBaseDAO()
        '    Dim l As List(Of ListinoBase) = mgr.ListiniUtilizzabili

        '    l = l.FindAll(Function(x) x.FaccMin <> 2)

        '    MgrPubblicazioneWeb.PubblicaIndiciRicerca(l)
        'End Using

        'MgrPubblicazioneWeb.ChiudiConnessioneRemota()

    End Sub

    Private Sub ScalePdf()

        '        PdfReader reader = New PdfReader("In.PDF");
        'Document doc = New Document(PageSize.A4, 0, 0, 0, 0);
        'PdfWriter writer = PdfWriter.GetInstance(doc,
        'New FileStream("Out.PDF",
        'FileMode.Create));
        'doc.Open();
        'PdfContentByte cb = writer.DirectContent;
        'PdfImportedPage page = writer.GetImportedPage(reader, 1); //page #1
        'float Scale() = 0.67F;
        'cb.AddTemplate(page, Scale, 0, 0, Scale, 0, 0);
        'doc.Close();

        Dim Path As String = "c:\temp\in2.pdf"

        FormerHelper.PDF.ResizePDF(Path, 85, 55, "c:\temp\out.pdf", True)

        FormerHelper.File.ShellExtended("c:\temp\out.pdf")

    End Sub

    Private Sub CallRefineAutomatico()
        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_RefineAutomatico, "CIAO")
    End Sub

    Private Sub ResettaOrdini()

        Using Mgr As New OrdiniDAO

            Dim l As List(Of Ordine) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "83390,83388,83376,83359,83318"))

            For Each O As Ordine In l

                'qui devo riscaricare il sorgente 
                For Each S As FileSorgente In O.ListaSorgenti

                    Dim NomeFileOnline = FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath).Substring(6)

                Next
            Next
        End Using

    End Sub

    Private Sub ResettaFustelle()

        Using mgr As New TipoFustelleDAO

            Dim l As List(Of TipoFustella) = mgr.GetAll(LFM.TipoFustella.IdTipoFustella)

            For Each singFust As TipoFustella In l
                Using mgrW As New FW.TipiFustellaWDAO

                    Dim lW As List(Of FW.TipoFustellaW) = mgrW.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.TipoFustellaW.IdTipoFustella, singFust.IdTipoFustella))

                    If lW.Count = 0 Then
                        'qui va inserita 

                        Dim newFust As New FW.TipoFustellaW
                        newFust.Altezza = singFust.Altezza
                        newFust.IdPrev = singFust.IdPrev
                        newFust.Disponibile = singFust.Disponibile
                        newFust.Profondita = singFust.Profondita
                        newFust.Base = singFust.Base
                        newFust.Save()

                    End If

                End Using
            Next

        End Using

    End Sub

    Private Sub ErroreData()

        Using Ow As New FW.OrdineWeb
            Ow.Read(72201)

            Using Mgr As New ConsegneProgrammateDAO
                Using O As New Ordine
                    O.Read(83449)
                    Dim DataRifConsegna As Date = Now.Date

                    If O.IdCorriere = enCorriere.RitiroCliente Then
                        DataRifConsegna = O.DataPrevProduzione
                    ElseIf O.IdCorriere = enCorriere.TipografiaFormer Or
O.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                        DataRifConsegna = O.DataPrevConsegna
                    Else
                        DataRifConsegna = Ow.ConsegnaAssociata.Giorno
                    End If

                    DataRifConsegna = MgrDataConsegna.ConfermaDataConsegna(O.DataIns,
                        DataRifConsegna,
                        O.IdCorriere)

                    Dim FirstCons As ConsegnaProgrammata = Mgr.GetPrimaConsegnaCompatibileOrdine(O,
                                                                O.IdCorriere,
                                                                DataRifConsegna,
                                                                O.IdRub,
                                                                enMomentoConsegna.Mattina,
                                                                O.IdIndirizzo)
                End Using
            End Using

        End Using

    End Sub
    Private Sub TestCercaByData()

        Using mgr As New ConsegneProgrammateDAO
            Using O As New Ordine
                O.Read(83520)
                Dim IdOldCons As Integer = O.ConsegnaAssociata.IdCons
                Dim IdCorr As Integer = O.ConsegnaAssociata.IdCorr
                Dim IdRub As Integer = O.IdRub
                Dim IdInd As Integer = O.ConsegnaAssociata.IdIndirizzo

                Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCons", O.ConsegnaAssociata.IdCons, "<>"),
                                New LUNA.LunaSearchParameter("IdCorr", O.ConsegnaAssociata.IdCorr),
                                New LUNA.LunaSearchParameter("IdRub", O.ConsegnaAssociata.IdRub),
                                New LUNA.LunaSearchParameter("IdIndirizzo", O.ConsegnaAssociata.IdIndirizzo),
                                New LUNA.LunaSearchParameter("Eliminato", enSiNo.Si, "<>"),
                                New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InLavorazione),
                                New LUNA.LunaSearchParameter("Giorno", Date.Now.AddDays(-1), ">"),
                                New LUNA.LunaSearchParameter("Giorno", O.ConsegnaAssociata.Giorno, "<"))
                For Each singC As ConsegnaProgrammata In l


                Next
            End Using

        End Using

    End Sub

    Public Shared Sub RigeneraAnteprima(IdModelloCommessa As Integer,
    FronteRetro As enFronteRetro)

        'PER L'ANTEPRIMA LA DEVO CREARE
        Using M As New ModelloCommessa
            M.Read(IdModelloCommessa)

            Dim PathFile As String = M.PDF
            Dim PathDest As String = String.Empty

            If FronteRetro = enFronteRetro.Fronte Then
                PathDest = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(PathFile) & ".F.jpg"
            Else
                PathDest = FormerConfig.FormerPath.PathTemplatePreps & Path.GetFileNameWithoutExtension(PathFile) & ".R.jpg"
            End If

            'SE ESISTE LA ELIMINO
            Try
                If IO.File.Exists(PathDest) Then IO.File.Delete(PathDest)
            Catch ex As Exception

            End Try

            Try
                If FileIO.FileSystem.FileExists(PathFile) Then
                    If PathFile.ToLower.EndsWith("pdf") Then
                        If FronteRetro = enFronteRetro.Fronte Then
                            FormerHelper.PDF.GetPdfThumbnail(PathFile, PathDest)
                            M.Anteprima = PathDest
                        ElseIf FronteRetro = enFronteRetro.Retro Then
                            Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(PathFile)
                            If NumPag = 2 Then
                                FormerHelper.PDF.GetPdfThumbnail(PathFile, PathDest,, 2)
                                M.AnteprimaR = PathDest
                            End If
                        End If
                    End If
                    M.Save()
                End If
            Catch ex As Exception
                'qui c'è stato un errore nella creazione dell'anteprima
                'metto un file temporaneo e poi vediamo
                'UdpCommand.LogMe("ERRORE Rigenerazione Anteprima MODELLO COMMESSA " & IdModelloCommessa,, ex)

            End Try
        End Using

    End Sub

    Private Sub SistemaGabetti(Optional InserisciPagamenti As Boolean = False)

        Using Mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.IdRub, "(4559,4531,4558,4534,4549,4553,4532,4548,9310,5905,4552,4550,4541,4543,4554,4553,4547,4533)", "IN"))

            For Each r As VoceRubrica In l
                txtDebug.Text &= "(" & r.IdRub & ") " & r.RagSocNome & ControlChars.NewLine
            Next

        End Using

        If InserisciPagamenti Then
            Using mgr As New OrdiniDAO

                Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, "(4559,4531,4558,4534,4549,4553,4532,4548,9310,5905,4552,4550,4541,4543,4554,4553,4547,4533)", "IN"))

                l = l.FindAll(Function(x) x.IdListinoBase = FormerConst.ProdottiParticolari.IdListinoBaseGabettiLazio And x.DataIns.Year <= 2017)

                l = l.FindAll(Function(x) x.Stato <> enStatoOrdine.PagatoInteramente And x.Stato > enStatoOrdine.Registrato And x.Stato <> enStatoOrdine.Eliminato)

                Dim LF As New List(Of Integer)

                For Each O As Ordine In l

                    Using MgrVo As New VociFatturaDAO
                        Dim lv As List(Of VoceFattura) = MgrVo.FindAll(New LUNA.LunaSearchParameter(LFM.VoceFattura.IdOrd, O.IdOrd))

                        LF.Add(lv(0).IdDoc)

                    End Using

                    'mgr.InserisciLog(O.IdOrd,enStatoOrdine.PagatoInteramente,)
                Next

                For Each Id As Integer In LF

                    Using r As New Ricavo
                        r.Read(Id)

                        If r.Stato <> enStatoDocumentoFiscale.PagatoInteramente Then
                            Dim Importo As Decimal = r.TotaleAncoraDaPagare

                            Dim P As New Pagamento
                            P.IdRub = r.IdRub
                            P.DataPag = Now
                            P.Descrizione = "Pagamento inserito automaticamente da FormerLAB"
                            P.Importo = Importo
                            P.IdFat = Id
                            'P.NotePag = "Pagamento inserito automaticamente"
                            P.Tipo = enTipoVoceContab.VoceVendita
                            P.IdTipoPagamento = enMetodoPagamento.BonificoBancario
                            P.Save()

                            Using doc As New cContabRicaviColl
                                doc.PassaA(Id, enStatoOrdine.PagatoInteramente)
                            End Using

                            r.idstato = enStatoDocumentoFiscale.PagatoInteramente
                            r.Save()

                        End If

                    End Using

                Next

                MessageBox.Show(LF.Count)

            End Using
        End If


    End Sub


    Private Sub CheckNumeriConsecutivi(Optional AnnoRif As Integer = 0)

        MessageBox.Show("snc" & MgrDocumentiFiscali.DocumentNumber.GetNextNumber(MgrAziende.IdAziende.AziendaSnc, enTipoDocumento.Fattura))
        MessageBox.Show("srl" & MgrDocumentiFiscali.DocumentNumber.GetNextNumber(MgrAziende.IdAziende.AziendaSrl, enTipoDocumento.Fattura))
        Dim Ris As String = MgrDocumentiFiscali.DocumentNumber.GetNumberError()
        txtDebug.Text = Ris

        MessageBox.Show(MgrDocumentiFiscali.DocumentNumber.GetNumberError(2018))

    End Sub

    Private Sub CheckTb()


        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
            tb.TransactionBegin()
            Dim i As Integer = 1

            CheckTb()
            tb.TransactionCommit()

        End Using

    End Sub

    Private Function TestValidazioneFileSorgente(IdListinobase As Integer,
                PathFile As String,
                Optional Larghezza As Integer = 0,
                Optional Altezza As Integer = 0) As String

        Dim Ris As String = String.Empty

        Using L As New ListinoBase
            L.Read(IdListinobase)
            Dim risValidazioneFile As ValidationFileResult = FormerValidator.ValidateSourceFilePDF(L,
                                                                PathFile,
                                                                Larghezza,
                                                                Altezza,
                                                                enTipoOrientamento.NonSpecificato)

            If risValidazioneFile.ReturnMaxErrorLevel = enValidatorErrorLevel.Errore Then
                Ris = "Il file FRONTE non può essere allegato all'ordine perche presenta i seguenti problemi BLOCCANTI: " & ControlChars.NewLine & risValidazioneFile.ErrorBuffer(True)
            End If
        End Using
        Return Ris

    End Function

    Private Function DownloadFtp()

        Dim PathOnlineFronte As String = "/tipografiaformer.it/ordini/76570/F_vol_giovanili_2018.pdf"
        Dim PathOfflineFronte As String = "C:\temp\testftp.pdf"

        Dim Ftp As New FTPclient(FormerConfig.FConfiguration.Ftp.ServerNameProduzione,
FormerConfig.FConfiguration.Ftp.ServerLoginProduzione,
FormerConfig.FConfiguration.Ftp.ServerPwdProduzione)

        MgrFormerIO.FtpTransfer(Ftp, PathOnlineFronte, PathOfflineFronte, enTipoOpFTP.Download)

        Ftp = Nothing

    End Function

    Private Sub EmettiPromoAutomatici()

        Dim TotalePromo As Integer = 10
        Dim Primi As Integer = 5

        Dim ListaIdLbAttiviSuPromo As New List(Of Integer)

        Using Mgr As New PromoDAO
            Dim l As List(Of Promo) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Promo.Automatico, enSiNo.Si))
            For Each p As Promo In l
                ListaIdLbAttiviSuPromo.Add(p.IdListinoBase)

                'qui elimino i vecchi promo sia offline che online
                Using MgrW As New FW.PromoWDAO
                    MgrW.Delete(p.IdPromoOnline)
                End Using
                Mgr.Delete(p)
            Next
        End Using

        Dim ListaFinale As New List(Of RisPromoSuLB)

        Using Mgr As New ListinoBaseDAO

            Dim l As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.PercPromoAutomatico, 0, "<>"))

            Dim lP As New List(Of RisPromoSuLB)

            For Each singL As ListinoBase In l

                Dim lbP As New RisPromoSuLB(singL)

                lbP.FatturatoMensileTotale = Mgr.GetFatturatoNelMese(lbP.IdListinoBase)
                lbP.FatturatoMensileConPromo = Mgr.GetFatturatoNelMese(lbP.IdListinoBase,,, True)
                'MessageBox.Show(lbP.PercentualeSuFatturato)

                lP.Add(lbP)

            Next

            'prendo tutti quelli sotto fatturato
            lP = lP.FindAll(Function(xx) xx.PercentualeSuFatturato < xx.ListinoBase.PercMaxPromoFatturato)

            'qui ho la lista dei promo attivi con i conteggi. 
            If lP.Count <= TotalePromo Then
                'se sono meno di 10 qui li inserisco tutti 
                ListaFinale.AddRange(lP)
            Else
                'qui devo andare a scegliere

                'ordino in base a quelli con meno fatturatomensile
                lP.Sort(Function(xx, y) xx.PercentualeSuFatturato.CompareTo(y.PercentualeSuFatturato))

                'Dim Primi As Integer = 5

                'If lP.Count < 5 Then Primi = lP.Count

                For i As Integer = 1 To Primi
                    'qui inserisco i primi x
                    ListaFinale.Add(lP(i))

                    '                    ListaIdLbAttiviSuPromo.Remove(lP(i).IdListinoBase)

                Next

                For i As Integer = 1 To Primi
                    lP.RemoveAt(0)
                Next

                'metto gli altri 

                For Each singRis In lP
                    If ListaFinale.Count = TotalePromo Then Exit For

                    If ListaFinale.FindAll(Function(x) x.IdListinoBase = singRis.IdListinoBase).Count = 0 Then
                        ListaFinale.Add(singRis)
                    End If

                Next
                'qui ho aggiunto quelli che non c'erano la volta prima 

                If ListaFinale.Count < TotalePromo Then
                    For Each singRis In lP
                        If ListaFinale.Count = TotalePromo Then Exit For

                        If ListaFinale.FindAll(Function(x) x.IdListinoBase = singRis.IdListinoBase).Count = 0 Then
                            ListaFinale.Add(singRis)
                        End If

                    Next

                End If

            End If

        End Using

        Dim DataScadenza As Date = Now.Date.AddDays(1)
        Dim DataFine As New Date(DataScadenza.Year, DataScadenza.Month, DataScadenza.Day, 23, 59, 0)

        For Each SingPromo In ListaFinale
            'qui vado a creare il promo online e offline 

            Using C As New Promo

                C.IdListinoBase = SingPromo.IdListinoBase
                C.Percentuale = SingPromo.PercPromo
                C.DataFineValidita = DataFine
                C.Stato = enStato.Attivo
                C.Automatico = enSiNo.Si
                C.Save()

                Dim i As Integer = 0

                For i = 0 To 1

                    If i = 1 Then
                        FormerDALWeb.LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                    End If

                    Using tb As FormerDALWeb.LUNA.LunaTransactionBox = FormerDALWeb.LUNA.LunaContext.CreateTransactionBox()
                        Try
                            Using mgr As New FormerDALWeb.PromoWDAO
                                Dim Conl As FormerDALWeb.PromoW
                                If C.IdPromoOnline Then
                                    Conl = mgr.Read(C.IdPromoOnline)
                                Else
                                    Conl = New FormerDALWeb.PromoW
                                End If
                                Conl.IdListinoBase = C.IdListinoBase
                                'quando lo porto online devo salvare l'id del cliente online non qui
                                Conl.Percentuale = C.Percentuale
                                Conl.QtaSpecifica = C.QtaSpecifica
                                Conl.DataFineValidita = C.DataFineValidita
                                Conl.IdPromoInt = C.IdPromo
                                Conl.Automatico = enSiNo.Si
                                tb.TransactionBegin()
                                mgr.Save(Conl)
                                If Conl.IdPromo = 0 Then
                                    Throw New Exception("IdCouponOnline non inserito")
                                End If
                                If i = 0 Then C.IdPromoOnline = Conl.IdPromo
                                C.Save()
                                tb.TransactionCommit()

                            End Using
                        Catch ex As Exception
                            tb.TransactionRollBack()
                            MessageBox.Show("Si è verificato un errore nella pubblicazione del Coupon " & IIf(i = 0, "online", " sul server web interno") & ", riprovare. Errore " & ex.Message, "Errore")
                        End Try
                    End Using
                Next
                FormerDALWeb.LUNA.LunaContext.ConnectionString = String.Empty

            End Using


        Next

    End Sub

    Private Sub InviaSituazioneAttuale(Destinatario As String)

        Dim Buffer As String = String.Empty
        Dim l As New List(Of String)
        Dim NOrd As Integer = 0
        Dim NOrdR As Integer = 0

        Using M As New CatProdDAO

            NOrd = M.GetNumOrd(0, 0, enStatoOrdine.Preinserito)
            NOrdR = M.GetNumOrd(0, 0, enStatoOrdine.Registrato)

            Buffer &= "<h3>ORDINI DISPONIBILI</h3>"
            Buffer &= "<b style=""background-color:" & FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Preinserito) & ";padding:3px;"">Preinserito: " & NOrd & "</b><br>"
            Buffer &= "<b style=""background-color:" & FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Registrato) & ";padding:3px;"">Registrato: " & NOrdR & "</b><br>"
            Buffer &= "<ul>"

            Using Mgr As New PreventivazioniDAO
                Dim Lst As List(Of Preventivazione) = Mgr.GetAll("IdReparto,Descrizione")

                For Each CategProd As Preventivazione In Lst

                    Dim DescrP As String = CategProd.Descrizione
                    NOrd = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Preinserito)
                    DescrP &= " {"
                    If NOrd Then DescrP &= "<b>" & NOrd & "</b> Preinserito "

                    NOrdR = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Registrato)
                    If NOrdR Then
                        DescrP &= "<b>" & NOrdR & "</b> Registrato"
                    End If
                    DescrP &= "}"

                    If NOrd <> 0 Or NOrdR <> 0 Then
                        Buffer &= "<li>" & DescrP & "</li>"
                    End If
                Next
            End Using
        End Using

        Buffer &= "</ul>"

        Buffer &= "<b>COMMESSE IN CODA</b>"
        Buffer &= "<table border=0>"
        Buffer &= "<tr>"
        Buffer &= "<td width=""100""></td>"
        Buffer &= "<td><b>REPARTO</b></td>"
        Buffer &= "<td><b>COMMESSA</b></td>"
        Buffer &= "<td><b>STATO</b></td>"
        Buffer &= "<td><b>RIASSUNTO</b></td>"
        Buffer &= "<td align=right><b>COPIE/Q.TA</b></td>"
        Buffer &= "</tr>"
        Dim LOption As New LUNA.LunaSearchOption() With {.OrderBy = "IdReparto,DataIns"}

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                    New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Preinserito))

            For Each C As Commessa In lC
                Application.DoEvents()

                Dim Path As String = FormerPathCreator.GetAnteprima(C).Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                    New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Pronto))

            For Each C As Commessa In lC

                Application.DoEvents()
                Dim Path As String = FormerPathCreator.GetAnteprima(C).Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Using mgr As New CommesseDAO
            Dim lC As List(Of Commessa) = mgr.FindAll(LOption,
                    New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Stampa))

            For Each C As Commessa In lC
                Application.DoEvents()

                Dim Path As String = FormerPathCreator.GetAnteprima(C).Replace("Z:", "W:")
                Dim Cid As String = FormerHelper.File.EstraiNomeFile(Path)
                l.Add(Path)
                Buffer &= "<tr>"
                Buffer &= "<td width=""100""><img src=""cid:" & Cid & """ width=""100""></td>"
                Buffer &= "<td width=""8"" bgcolor=""" & FormerColori.GetColoreToHtml(FormerColori.GetColoreReparto(C.IdReparto)) & """>&nbsp;</td>"
                Buffer &= "<td>" & C.IdCom & "</td>"
                Buffer &= "<td bgcolor=""" & C.StatoColoreHTML & """>" & C.StatoStr & "</td>"
                Buffer &= "<td>" & C.Riassunto & "</td>"
                Buffer &= "<td align=right>" & C.CopieStr & "</td>"
                Buffer &= "</tr>"
            Next

        End Using

        Buffer &= "</table>"

        'Buffer &= "<b>OPERATORI</b><ul>"
        'Buffer &= "</ul>"

        FormerLib.FormerHelper.Mail.InviaMailEx("Situazione aggiornata", Buffer, Destinatario, l)


    End Sub

    Private Sub StampaPdf(Path As String)

        Dim MyProcess As New Process
        MyProcess.StartInfo.CreateNoWindow = False
        MyProcess.StartInfo.Verb = "print"

        'HERE IS WHERE I WANT TO CHANGE THE PRINTER (BUT THIS COMMAND IS IGNORED)
        MyProcess.StartInfo.Arguments = "Samsung ML-1660 Series (Copy 1)"

        MyProcess.StartInfo.UseShellExecute = True
        MyProcess.StartInfo.FileName = Path
        MyProcess.Start()
        MyProcess.WaitForExit(10000)
        MyProcess.CloseMainWindow()
        MyProcess.Close()

    End Sub

    Private Sub InterpretaPdfGLS(Path As String)

        Dim buffer As String = FormerLib.FormerHelper.PDF.GetTextFromPDF(Path)

        Dim righe() As String = buffer.Split(ControlChars.Lf)
        Dim BufferOut As String = String.Empty

        For Each riga In righe

            Dim Valori() As String = riga.Split(" ")

            For Each valore In Valori
                If FormerLib.FormerHelper.Mail.IsValidEmailAddress(valore) Then
                    BufferOut &= valore & ";" & ControlChars.NewLine
                End If
            Next

            'Dim CodTrack As String = Valori(Valori.Count - 1)

            'If IsNumeric(CodTrack) Then

            '    If CodTrack.Length > 5 Then
            '        MessageBox.Show(CodTrack)
            '    End If

            'End If
        Next

        Using w As New StreamWriter("C:\temp\temppdf.txt")
            w.Write(BufferOut)
        End Using


    End Sub

    Private Sub MAGAZZINOResetQtaRisorse()
        Using mgr As New RisorseDAO
            Using mgrM As New MagazzinoDAO
                Dim l As List(Of Risorsa) = mgr.GetBySQL("select * from t_risorse where idris = 216")

                ' Dim IdRisAttuale As Integer = 0
                'Dim IdRisOld As Integer = 0

                Dim DataStorno As Date = New Date(2018, 12, 31)
                For Each ris In l
                    Dim Giacenza3112 As Single = 0

                    Giacenza3112 = mgrM.GetGiacenzaAggiornata(ris.IdRis, DataStorno)
                    Dim QtaStorno As Integer = 0
                    If Giacenza3112 > 0 Then
                        QtaStorno = 0 - Giacenza3112
                    Else
                        QtaStorno = Math.Abs(Giacenza3112)
                    End If

                    Using m As New MovimentoMagazzino
                        m.IdRis = ris.IdRis

                        m.Qta = QtaStorno
                        m.TipoMov = enTipoMovMagaz.Storno
                        m.DataMov = DataStorno
                        m.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                        m.Nota = "STORNO AUTOMATICO"
                        m.Save()
                    End Using

                    mgrM.AggiornaQta(ris.IdRis)

                Next
            End Using



            '    If ris.IdRis <> IdRisAttuale Then

            '        If IdRisAttuale = 0 Then
            '            IdRisAttuale = ris.IdRis
            '            'IdRisOld = ris.IdRis
            '            QtaCarico = ris.Qta
            '        Else
            '            'devo andare ad aggiornare risold
            '            Using m As New MovimentoMagazzino
            '                m.IdRis = IdRisAttuale
            '                m.Qta = -QtaCarico
            '                m.TipoMov = enTipoMovMagaz.Storno
            '                m.DataMov = New Date(2018, 12, 31)
            '                m.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
            '                m.Nota = "STORNO AUTOMATICO"
            '                m.Save()
            '            End Using

            '            'IdRisOld = IdRisAttuale
            '            IdRisAttuale = ris.IdRis
            '            QtaCarico = ris.Qta
            '        End If
            '    Else
            '        QtaCarico += ris.Qta
            '    End If
            '    'mgrM.AggiornaQta(ris.IdRis)
            'Next

            ''If IdRisAttuale = IdRisOld Then
            'Using m As New MovimentoMagazzino
            '    m.IdRis = IdRisAttuale

            '    m.Qta = -QtaCarico
            '    m.TipoMov = enTipoMovMagaz.Storno
            '    m.DataMov = New Date(2018, 12, 31)
            '    m.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
            '    m.Nota = "STORNO AUTOMATICO"
            '    m.Save()
            'End Using
            ''End If


        End Using

    End Sub

    Private Sub MAGAZZINOResetQtaRisorseEStornaAZero()

        Using mgr As New RisorseDAO

            Dim l As List(Of Risorsa) = mgr.GetAll

            Using mgrM As New MagazzinoDAO

                For Each ris In l

                    mgrM.AggiornaQta(ris.IdRis)

                Next

            End Using

            'dopo che ho aggiornato tutte le quantita prendo tutte le risorse che hanno giacenza inferiore a 0
            'di ogni risorsa se non hanno avuto movimentazione negli ultimi 6 mesi di nessun tipo 
            'inserisco uno storno per portarle a 0 

            'l = l.FindAll(Function(x) x.Giacenza < 0)

            'For Each ris In l

            '    Dim AggiornaConStorno As Boolean = False

            '    If Not ris.UltimoMovimentoMagazzino Is Nothing Then

            '        Dim MesiPassati As Integer = DateDiff(DateInterval.Month, Now, ris.UltimoMovimentoMagazzino.DataMov)

            '        If MesiPassati < -5 Then
            '            AggiornaConStorno = True
            '        End If

            '    End If

            '    If AggiornaConStorno Then

            '        Using m As New MovimentoMagazzino
            '            m.IdRis = ris.IdRis
            '            m.DataMov = Now
            '            m.TipoMov = enTipoMovMagaz.Storno
            '            m.IdUt = 1
            '            m.Qta = Math.Abs(ris.Giacenza)
            '            m.Save()
            '        End Using

            '    End If

            'Next

        End Using


    End Sub

    Private Sub PulisciGac()

        Dim PathGacUtil As String = "C:\Program Files\Microsoft SDKs\Windows\v6.0A\bin\gacutil.exe"

        Dim d As New DirectoryInfo("C:\Windows\Microsoft.NET\assembly\GAC_MSIL\")
        Dim Buffer As String = String.Empty

        For Each f As DirectoryInfo In d.GetDirectories("Telerik*.*")

            Buffer &= "gacutil /u " & f.Name & ControlChars.NewLine

            'FormerLib.FormerHelper.File.ShellExtended(PathGacUtil, "/u " & f.Name)

        Next

        Dim dN As New DirectoryInfo("c:\lavoro\Former\Source\main\lib\RCWF\2019.1.219.40\")

        For Each f As FileInfo In dN.GetFiles("Telerik*.dll")
            Buffer &= "gacutil /i " & f.FullName & ControlChars.NewLine
        Next

        Using w As New StreamWriter("C:\temp\telerik.bat")
            w.Write(Buffer)
        End Using


    End Sub

    Private Sub ChiudiSpedizioni()

        Dim lstConsegne As List(Of ConsegnaProgrammata)
        Using mgr As New ConsegneProgrammateDAO
            'TODO: COSI' NON VA BENE: BECCO ANCHE QUELLE PASSATE CON LO STATO ANCORA A "INCONSEGNA"!
            lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, "580593472",, LUNA.enLogicOperator.enOR),
    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, "580593054",, LUNA.enLogicOperator.enOR),
    New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, "580593036",, LUNA.enLogicOperator.enOR))
        End Using

        Dim lstConsegneColliGls As New List(Of ConsegnaProgrammata)

        For Each C In lstConsegne
            For i = 1 To C.NumColli
                lstConsegneColliGls.Add(C)
            Next
        Next

        Dim ris As String = String.Empty
        Try
            ris = FormerWebLabeling.MgrWebLabelingGls.TrasmettiSpedizioniGls(lstConsegneColliGls)
        Catch ex As Exception
            ris = ex.Message
        End Try

        MessageBox.Show(ris)

    End Sub

    Private Sub sendAnonymousMail()

        FormerLib.FormerHelper.Mail.InviaMail("Ciao Daniele come stai? ",
            "Ciao Daniele è tanto che ti tengo sotto controllo...",
            "soft@tipografiaformer.it", ,,
            ,,
            False,
            False,
            enTipoBordoEmail.Nessuno,
            False)

    End Sub

    Private Sub TestWeTransfer()

        FormerLib.FormerHelper.Web.GetFile("https://we.tl/t-1b7KeXGDjf", "C:\temp\testwetransfer.pdf")

    End Sub

    Private Sub CreaPreventivo()

        'Using L As New FW.ListinoBaseW
        '    L.Read(254)
        '    ' L.Read(257)
        '    L.CaricaLavorazioniBase()
        '    L.CaricaLavorazioniOpz()

        '    Dim InviaMail As Boolean = True

        '    Dim LOpz As New List(Of Integer)

        '    LOpz.Add(2)
        '    Dim PathXml As String = FormerPath.PathTempLocale
        '    Dim R As FW.RichiestaPreventivo = FW.MgrPreventivi.SalvaPreventivo(L.IdListinoBase,
        '                                 1703,
        '                                 "Diego Lunadei",
        '                                 "soft@tipografiaformer.it",
        '                                 "Nome Lavoro",
        '                                 enRepartoWeb.StampaOffset,
        '                                 1000, 90, 55, enTipoOrientamento.Orizzontale, "Opaca", L.TipoCarta.Tipologia,
        '                                 L.ColoreStampa.IdColoreStampa, L, L, False, False, L.NumFacciate, LOpz, "note ordine", PathXml, InviaMail)

        '    If InviaMail = False Then
        '        MessageBox.Show(R.GetPrezzoCalcolatoNetto)
        '    End If

        'End Using

    End Sub

    Private Sub Testrigenerapassword()

        Try
            Dim PwdHash As String = "360218359bc405f054e4ff4eedb3c17b"

            Dim idutformer As Integer = 3
            Dim Email As String = "soft@tipografiaformer.it"

            Dim FormerConnString As String = "Data Source=188.213.172.73\sqlexpress,1433;Initial Catalog=Formerweb;MultipleActiveResultSets=true;User Id=sa;Password=tgHi9MaEQA;Encrypt=false;Packet Size=4096;Connection Timeout=10;"
            'Dim FormerConnString As String = "Data Source=former-server\sqlexpress;Initial Catalog=Formerweb;MultipleActiveResultSets=true;User Id=sa;Password=tgHi9MaEQA;Encrypt=false;Packet Size=4096;Connection Timeout=10;"
            Using FormerDbConn As SqlConnection = New SqlConnection(FormerConnString)
                FormerDbConn.Open()
                Dim StrSQL As String = "UPDATE Utenti SET PasswordHash = '" & PwdHash & "' WHERE IdUt = " & idutformer & " AND Email = '" & Email & "'"
                Using Query As SqlCommand = New SqlCommand(StrSQL, FormerDbConn)
                    Query.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            'ris = 1
        End Try

    End Sub

    Dim StopSearch As Boolean = False

    Private Sub CercaInPath(Path As String, MinMega As Integer, ByRef LRis As List(Of cEnum))

        Dim d As New DirectoryInfo(Path)

        For Each f As FileInfo In d.GetFiles()
            Dim Dimensione As Integer = (f.Length / (1024 * 1024))
            If Dimensione >= MinMega Then
                Dim val As New cEnum
                val.Id = Dimensione
                val.Descrizione = f.FullName
                LRis.Add(val)
            End If
            If StopSearch Then Exit For
            Application.DoEvents()
        Next

        For Each dir As DirectoryInfo In d.GetDirectories
            CercaInPath(dir.FullName, MinMega, LRis)
            If StopSearch Then Exit For
        Next

    End Sub


    Private Sub CercaBigFile()

        Dim PathStart As String = "w:\commesse"
        Dim MinMega As Integer = 100
        Dim Lris As New List(Of cEnum)

        CercaInPath(PathStart, MinMega, Lris)

        For Each ris In Lris
            Dim riga As String = ris.Descrizione & " (" & ris.Id & " mb)" & ControlChars.NewLine
            txtDebug.Text = String.Concat(txtDebug.Text, riga)
        Next

        txtDebug.Text = String.Concat(txtDebug.Text, ControlChars.NewLine & "Trovati " & Lris.Count & " file")

    End Sub

    Private Sub CreaFatturaElettronica()

        Using R As New Ricavo
            R.Read(38551) '38532)

            Dim path As String = "C:\temp\IT" & MgrAziende.GetPartitaIva(R.IdAzienda) & "_" & MgrFattureFE.GetProgressivo(R) & ".xml"
            Dim ris As String = MgrFattureFE.RicavoToXML(R, path)
            FormerHelper.File.ShellExtended(path)

            MessageBox.Show(ris)
        End Using

    End Sub

    Private Sub InviaFattureElettroniche()


    End Sub

    'Private Sub CheckP7m()

    '    'IT04599340967_01YHY.xml

    '    Dim Path As String = "C:\temp\IT04599340967_01YHY.xml.p7m"
    '    Dim Ris As String = String.Empty

    '    Ris = MgrFatturePAEx.ReadXmlSigned(Path, True)

    '    FormerLib.FormerHelper.File.ShellExtended(Ris)
    'End Sub

    Private Sub TestInvioFattureFE(IdAzienda As Integer)
        LogMe("***Invio Fatture FE***")

        Try

            Using mgr As New RicaviDAO
                Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdAzienda, IdRicavo"},
            New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.InCodaInvio),
            New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")", "IN"),
            New LUNA.LunaSearchParameter("YEAR(DataRicavo)", "2019", ">="))

                Dim Adesso As Date = Now.AddDays(-1)
                Dim DataRiferimento As New Date(Adesso.Year, Adesso.Month, Adesso.Day, 23, 59, 59)

                For Each R As Ricavo In l
                    Dim Lavora As Boolean = True

                    'If R.IdAzienda = MgrAziende.IdAziende.AziendaSrl And (R.Numero = 191) Then
                    '    Lavora = True
                    'End If

                    If Lavora Then
                        If R.DataRicavo.Year >= 2019 Then
                            Dim DataRicavo As Date = R.DataRicavo
                            Dim DiffMinuti As Long = DateDiff(DateInterval.Minute, DataRicavo, DataRiferimento)

                            If DiffMinuti >= 1 Then
                                Threading.Thread.Sleep(2000) 'aspetto 2 secondi tra un invio e l'altro

                                LogMe("FATTURA " & R.Numero & "/" & R.AnnoRiferimento & " " & R.AziendaStr & " (IdRicavo " & R.IdRicavo & ")")
                                If R.VoceRubrica.Fatturabile.Length = 0 Then

                                    'qui genero l'xml e procedo all'invio della pec 

                                    Try

                                        Dim PathTemp As String = FormerConfig.FormerPath.PathFattureFE & R.AnnoRiferimento & "\" & R.IdAzienda & "\IT" & MgrAziende.GetPartitaIva(R.IdAzienda) & "_" & MgrFattureFE.GetProgressivo(R) & ".xml"

                                        FormerHelper.File.CreateLongPath(PathTemp)

                                        If IO.File.Exists(PathTemp) Then
                                            Try
                                                Kill(PathTemp)
                                            Catch ex As Exception

                                            End Try
                                        End If

                                        Dim bufferXML As String = MgrFattureFE.RicavoToXML(R, PathTemp)
                                        LogMe("Generato file XML: " & PathTemp)

                                        'invio il file XML 
                                        Dim ListaAllegati As New List(Of String)
                                        ListaAllegati.Add(PathTemp)

                                        Dim RisInvio As Integer = MgrFattureFE.InviaFatturaPEC(R, ListaAllegati)

                                        If RisInvio = 0 Then
                                            LogMe("Inviato file XML")
                                            'qui l'ho spedita
                                            R.StatoFE = enStatoFatturaFE.InviatoXML
                                            R.DataOraInvio = Now
                                            R.DocXML = bufferXML
                                            R.Save()
                                            LogMe("Salvati i dati della fattura e Terminato il processo di invio")
                                        Else
                                            LogMe("ERRORE: Si è verificato un errore nell'invio della PEC, l'invio sarà tentato nuovamente")
                                        End If

                                    Catch ex As Exception
                                        LogMe("ERRORE: " & ex.Source & "- " & ex.Message,, ex)
                                    End Try
                                Else
                                    LogMe("-NON INVIATA: Non fatturabile")
                                End If
                            End If

                        End If
                    End If


                Next

            End Using

        Catch ex As Exception
            LogMe("SORGENTE: InvioFattureFE(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
        End Try

        LogMe("***FINE Invio Fatture FE***")
    End Sub

    Private Sub TestInvioMailPEC()

        'tgHi9MaEQA
        'Dim ListaAllegati As New List(Of String)
        'ListaAllegati.Add("C:\temp\pec\IT05200481009_00001.xml")

        'Dim Ris As Integer = MgrFatturePA.InviaFatturaPEC(R, ListaAllegati)




        'Using msg As New MailMessage()
        '    msg.Subject = "Test Invio"
        '    msg.IsBodyHtml = True

        '    msg.Body = "Test INVIO SERVER POSTA IN USCITA"

        '    msg.From = New MailAddress("soft@tipografiaformer.it", "Soft")
        '    msg.To.Add("soft@tipografiaformer.it")

        '    Using sm As New SmtpClient("smtp.tipografiaformer.it")
        '        Dim c As New System.Net.NetworkCredential("soft@tipografiaformer.it", "tgHi9MaEQA")
        '        sm.UseDefaultCredentials = False
        '        sm.Credentials = c
        '        sm.Send(msg)
        '    End Using
        'End Using



    End Sub

    Private Shared Function DecodeQuotedPrintables(ByVal input As String) As String

        Dim ris As String = String.Empty

        Dim A As AlternateView = AlternateView.CreateAlternateViewFromString(input)

        Using r As New StreamReader(A.ContentStream)
            ris = r.ReadToEnd
        End Using
        'ris = A.ContentStream
        ris = ris.Replace("3D""", """")
        ris = ris.Replace("=3D", "=")
        Return ris

    End Function

    Private Shared Function ScaricaXMLFromEMLEx(msgMail As Message,
            PathFolder As String,
            TipoMail As enTipoMailPEC) As String
        Dim ris As String = String.Empty

        For Each a As MimePart In msgMail.EmbeddedObjects
            If Not a.ContentName Is Nothing AndAlso a.ContentName.EndsWith(".eml") Then

                FormerHelper.File.CreateLongPath(PathFolder)

                Dim NomeFile As String = PathFolder & a.ContentName
                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                    f.Write(a.BinaryContent, 0, a.BinaryContent.Length)
                End Using

                Dim Buffer As String = String.Empty
                Dim Parti As New List(Of String)

                Dim Boundary As String = String.Empty
                Dim EncodingFound As String = String.Empty
                Dim NomeFileXML As String = String.Empty

                Using r As New StreamReader(NomeFile, Encoding.UTF8)
                    While r.EndOfStream = False
                        Dim Riga As String = r.ReadLine
                        Dim Marcatore As String = String.Empty
                        Marcatore = "boundary="
                        Dim PosBoundary As Integer = Riga.IndexOf(Marcatore)
                        If PosBoundary <> -1 Then
                            Boundary = Riga.Substring(Riga.IndexOf("-"))
                            Boundary = Boundary.Substring(0, Boundary.Length - 1).Trim
                        End If
                        Marcatore = "Content-Transfer-Encoding:"
                        If Riga.StartsWith(Marcatore) Then
                            EncodingFound = Riga.Substring(Marcatore.Length).Trim
                        End If

                        If EncodingFound.Length AndAlso (EncodingFound = "base64" OrElse EncodingFound = "quoted-printable" OrElse EncodingFound = "7bit") Then
                            Marcatore = "Content-Disposition: attachment; filename="
                            If Riga.StartsWith(Marcatore) AndAlso NomeFileXML.Length = 0 Then
                                Dim NomeFileTemp As String = Riga.Substring(Marcatore.Length).Trim
                                Dim NomeFileOriginale As String = NomeFileTemp
                                If NomeFileTemp.ToLower.EndsWith(".xml") = False AndAlso NomeFileTemp.ToLower.IndexOf(".xml") <> -1 Then
                                    NomeFileTemp = NomeFileTemp.Substring(0, NomeFileTemp.Length - 4)
                                End If

                                'qui controllo la regular expression per il nomefile fattura
                                Dim PatternReg As String = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.xml$"

                                If TipoMail <> enTipoMailPEC.InvioFile Then
                                    PatternReg = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.{0,7}.xml$"
                                End If

                                Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

                                If Re.IsMatch(NomeFileTemp.ToLower) Then
                                    NomeFileXML = NomeFileOriginale
                                End If

                            ElseIf NomeFileXML.Length Then
                                If Riga.IndexOf(Boundary) <> -1 Then
                                    Exit While
                                Else
                                    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                        Riga = Riga.Substring(0, Riga.Length - 1)
                                        Buffer &= Riga
                                    Else
                                        Buffer &= Riga & ControlChars.NewLine
                                    End If

                                End If

                            End If
                        End If


                    End While

                End Using
                Buffer = Buffer.Trim
                'Buffer = Buffer.Replace(vbCrLf, "")
                If NomeFileXML.Length Then
                    Dim PathFinale As String = PathFolder & NomeFileXML

                    If EncodingFound = "base64" Then
                        Buffer = Buffer.Replace(vbCrLf, "")
                        File.WriteAllBytes(PathFinale, Convert.FromBase64String(Buffer))
                    ElseIf EncodingFound = "quoted-printable" Then
                        Buffer = DecodeQuotedPrintables(Buffer)
                        Using w As New StreamWriter(PathFinale)
                            w.Write(Buffer)
                        End Using
                    ElseIf EncodingFound = "7bit" Then
                        Using w As New StreamWriter(PathFinale)
                            w.Write(Buffer)
                        End Using
                    End If

                    ris = PathFinale
                End If

                Exit For
            End If
        Next

        Return ris
    End Function
    Private Shared Function ScaricaXMLFromEML(msgMail As MailMessage,
            PathFolder As String,
            TipoMail As enTipoMailPEC) As String
        Dim ris As String = String.Empty

        For Each a In msgMail.AlternateViews
            If Not a.ContentType.Name Is Nothing AndAlso a.ContentType.Name.EndsWith(".eml") Then

                FormerHelper.File.CreateLongPath(PathFolder)

                Dim NomeFile As String = PathFolder & a.ContentType.Name
                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                    a.ContentStream.CopyTo(f)
                End Using

                Dim Buffer As String = String.Empty
                Dim Parti As New List(Of String)

                Dim Boundary As String = String.Empty
                Dim EncodingFound As String = String.Empty
                Dim NomeFileXML As String = String.Empty

                Using r As New StreamReader(NomeFile, Encoding.UTF8)
                    While r.EndOfStream = False
                        Dim Riga As String = r.ReadLine
                        Dim Marcatore As String = String.Empty
                        Marcatore = "boundary="
                        Dim PosBoundary As Integer = Riga.IndexOf(Marcatore)
                        If PosBoundary <> -1 Then
                            Boundary = Riga.Substring(Riga.IndexOf("-"))
                            Boundary = Boundary.Substring(0, Boundary.Length - 1).Trim
                        End If
                        Marcatore = "Content-Transfer-Encoding:"
                        If Riga.StartsWith(Marcatore) Then
                            EncodingFound = Riga.Substring(Marcatore.Length).Trim
                        End If

                        If EncodingFound.Length AndAlso (EncodingFound = "base64" OrElse EncodingFound = "quoted-printable" OrElse EncodingFound = "7bit") Then
                            Marcatore = "Content-Disposition: attachment; filename="
                            If Riga.StartsWith(Marcatore) AndAlso NomeFileXML.Length = 0 Then
                                Dim NomeFileTemp As String = Riga.Substring(Marcatore.Length).Trim
                                Dim NomeFileOriginale As String = NomeFileTemp
                                If NomeFileTemp.ToLower.EndsWith(".xml") = False AndAlso NomeFileTemp.ToLower.IndexOf(".xml") <> -1 Then
                                    NomeFileTemp = NomeFileTemp.Substring(0, NomeFileTemp.Length - 4)
                                End If

                                'qui controllo la regular expression per il nomefile fattura
                                Dim PatternReg As String = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.xml$"

                                If TipoMail <> enTipoMailPEC.InvioFile Then
                                    PatternReg = "^[A-Za-z]{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.{0,7}.xml$"
                                End If

                                Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

                                If Re.IsMatch(NomeFileTemp.ToLower) Then
                                    NomeFileXML = NomeFileOriginale
                                End If

                            ElseIf NomeFileXML.Length Then
                                If Riga.IndexOf(Boundary) <> -1 Then
                                    Exit While
                                Else
                                    If EncodingFound = "quoted-printable" AndAlso Riga.EndsWith("=") Then
                                        Riga = Riga.Substring(0, Riga.Length - 1)
                                        Buffer &= Riga
                                    Else
                                        Buffer &= Riga & ControlChars.NewLine
                                    End If

                                End If

                            End If
                        End If


                    End While

                End Using
                Buffer = Buffer.Trim
                'Buffer = Buffer.Replace(vbCrLf, "")

                Dim PathFinale As String = PathFolder & NomeFileXML

                If EncodingFound = "base64" Then
                    Buffer = Buffer.Replace(vbCrLf, "")
                    File.WriteAllBytes(PathFinale, Convert.FromBase64String(Buffer))
                ElseIf EncodingFound = "quoted-printable" Then
                    Buffer = DecodeQuotedPrintables(Buffer)
                    Using w As New StreamWriter(PathFinale)
                        w.Write(Buffer)
                    End Using
                ElseIf EncodingFound = "7bit" Then
                    Using w As New StreamWriter(PathFinale)
                        w.Write(Buffer)
                    End Using
                End If

                ris = PathFinale
                Exit For
            End If
        Next

        Return ris
    End Function

    Private Shared Function ScaricaEML(msgMail As MailMessage,
    PathFolder As String) As String
        Dim ris As String = String.Empty

        For Each a In msgMail.AlternateViews
            If Not a.ContentType.Name Is Nothing AndAlso a.ContentType.Name.EndsWith(".eml") Then
                'lo scarico riempio ris 
                Dim NomeFile As String = PathFolder & a.ContentType.Name
                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                    a.ContentStream.CopyTo(f)
                End Using
                ris = NomeFile
                Exit For
            End If
        Next

        Return ris
    End Function

    Private Sub MonitoraggioPEC(IdAzienda As Integer)

        'Dim IdRicavo As Integer = MgrFattureFE.GetIdRicavoFromNomeFile("IT14974961006_A0692_NS_001.xml", IdAzienda)

        'Using R As New Ricavo
        '    R.Read(IdRicavo)
        '    MgrFattureFE.RicavoToXML(R, "C:\temp\temp.xml")
        'End Using


        Dim Spostamenti As New Dictionary(Of Integer, String)
        Dim Scarti As New Dictionary(Of Integer, String)

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Using s As New Imap4Client()

            Dim NomeHost As String = "imaps.pec.aruba.it"

            Dim hs As New ActiveUp.Net.Security.SslHandShake(NomeHost, System.Security.Authentication.SslProtocols.Tls12)

            s.ConnectSsl(NomeHost, 993, hs)
            s.Login(MgrAziende.GetPEC(IdAzienda), MgrAziende.GetPECPassword(IdAzienda))

            Dim m As Mailbox = s.SelectMailbox("inbox")
            Dim fetch As Fetch = m.Fetch


            Dim count As Integer = m.MessageCount


            Dim x As Integer = 0

        End Using


        'FormerDaemon_Server.Messenger.MonitoraggioPECEx(IdAzienda)

    End Sub

    'Private Sub SpostaInCartella(ByRef s As Imap4Client,
    '                             ByRef m As Mailbox,
    '                             ByRef UId As Integer,
    '                             Folder As String)

    '    'FOLDER è tipo INBOX.FE.2019.A.3

    '    'CREO LA CARTELLA FE SE NON ESISTE
    '    Try
    '        Dim t As Mailbox = s.SelectMailbox(Folder)
    '    Catch ex As Exception
    '        ''non esiste la creo
    '        s.CreateMailbox(Folder)

    '        'Dim ListaFolder As String() = Folder.Split(".")
    '        'Dim NuovoFolder As String = "INBOX"
    '        'For Each FolderSing In ListaFolder
    '        '    If FolderSing.ToLower <> "inbox" Then
    '        '        NuovoFolder &= "." & FolderSing
    '        '        Try
    '        '            Dim t As Mailbox = s.SelectMailbox(NuovoFolder)
    '        '        Catch ex2 As Exception
    '        '            s.CreateMailbox(NuovoFolder)
    '        '        End Try
    '        '    End If
    '        'Next

    '    End Try
    '    'm.CopyMessage(Id, Folder)

    '    m.UidMoveMessage(UId, Folder)

    'End Sub

    Private Sub TestDate()

        Dim DirFatture As New DirectoryInfo("W:\fatture\1\")
        Dim DataRif As Date = Now.AddDays(-1)
        For Each F As FileInfo In DirFatture.GetFiles("2018-1928.pdf")

            Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, DataRif, F.CreationTime)

            MessageBox.Show(F.CreationTime & " " & IntervalloDallaCreazione)

            Dim IntervalloDallaUltimaModifica As Long = DateDiff(DateInterval.Second, F.LastWriteTime, DataRif)

            MessageBox.Show(F.LastWriteTime & " " & IntervalloDallaUltimaModifica)



        Next
    End Sub

    Private Sub CreaVociCostoFromMagaz()

        Using mgr As New MagazzinoDAO
            Dim l As List(Of MovimentoMagazzino) = mgr.GetBySQL("select * from t_magaz where (idfat <>0 and not idfat is null) and idVoceCosto is null and tipomov = 1  order by idfat,idcarmag ")
            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                Dim TotCancellati As Integer = 0
                Dim TotInseriti As Integer = 0
                For Each mov In l
                    Try
                        If Not mov.Fattura Is Nothing AndAlso mov.Fattura.IdCosto <> 0 Then
                            Using v As New VoceCosto
                                v.Codice = mov.CodiceForn
                                v.Descrizione = mov.DescrForn
                                v.AliquotaIva = mov.Fattura.PercIva
                                v.Qta = mov.Qta
                                v.PrezzoUnit = mov.PrezzoUnit
                                v.Totale = mov.Prezzo
                                v.IdCosto = mov.Fattura.IdCosto
                                tb.TransactionBegin()
                                v.Save()

                                mov.IdVoceCosto = v.IdVoceCosto
                                mov.Save()
                                tb.TransactionCommit()
                                TotInseriti += 1
                            End Using
                        Else
                            'qui devo cancellare il movimento
                            mgr.Delete(mov.IdCarMag)
                            TotCancellati += 1

                        End If
                    Catch ex As Exception
                        tb.TransactionRollBack()
                    End Try

                Next
                MessageBox.Show("Inseriti " & TotInseriti & " . Cancellati " & TotCancellati)
            End Using

        End Using

    End Sub

    Public Shared Function InviaFatturaPEC(R As Ricavo,
        ListaAllegati As List(Of String)) As Integer

        Dim Ris As Integer = 0

        'Try


        '    'Using s As New Imap4Client()
        '    '    s.ConnectSsl("imaps.pec.aruba.it", 993)
        '    '    s.Login(MgrAziende.GetPEC(R.IdAzienda), MgrAziende.GetPECPassword(R.IdAzienda))






        '    'End Using

        '    Dim m As New Message
        '    m.To.Add(MgrAziende.GetPECSDI(R.IdAzienda))
        '    m.From.Email = MgrAziende.GetPEC(R.IdAzienda)
        '    m.From.Name = MgrAziende.GetRagioneSociale(R.IdAzienda)
        '    m.Subject = "TEST Invio File " & R.IdRicavo
        '    m.IsHtml = False
        '    m.BodyText.Text = "Invio File XML " & R.IdRicavo

        '    If Not ListaAllegati Is Nothing Then

        '        For Each Allegato As String In ListaAllegati
        '            If System.IO.File.Exists(Allegato) Then
        '                m.Attachments.Add(Allegato, True)
        '            End If
        '        Next

        '    End If


        '    Dim RisultatoInvio As Boolean = ActiveUp.Net.Mail.SmtpClient.SendSsl(m,
        '                                                                         FormerLib.FormerHelper.Mail.SMTPServerPEC,
        '                                                                         465,
        '                                                                         MgrAziende.GetPEC(R.IdAzienda),
        '                                                                         MgrAziende.GetPECPassword(R.IdAzienda),
        '                                                                         SaslMechanism.Login)

        'Catch
        '    Ris = 1
        'End Try



        '    Dim Dest As String = MgrAziende.GetPECSDI(R.IdAzienda) '"sdi01@pec.fatturapa.it"
        '    Dim FromAddr As String = MgrAziende.GetPEC(R.IdAzienda)
        '    Dim FromName As String = MgrAziende.GetRagioneSociale(R.IdAzienda)
        '    Dim FromPwd As String = MgrAziende.GetPECPassword(R.IdAzienda)

        '    Dim sslMail As New System.Web.Mail.MailMessage()
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", FormerLib.FormerHelper.Mail.SMTPServerPEC)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465")
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2") 'Send the message using the network (SMTP over the network)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'YES
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", FromAddr)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", FromPwd)
        '    sslMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true")
        '    sslMail.From = FromAddr
        '    sslMail.To = Dest
        '    sslMail.Subject = "Invio File " & R.IdRicavo
        '    sslMail.BodyFormat = MailFormat.Text
        '    sslMail.Body = "Invio File XML " & R.IdRicavo

        '    If Not ListaAllegati Is Nothing Then

        '        For Each Allegato As String In ListaAllegati
        '            If System.IO.File.Exists(Allegato) Then
        '                sslMail.Attachments.Add(New MailAttachment(Allegato))
        '            End If
        '        Next

        '    End If

        '    System.Web.Mail.SmtpMail.SmtpServer = FormerLib.FormerHelper.Mail.SMTPServerPEC & ":465"
        '    System.Web.Mail.SmtpMail.Send(sslMail)

        'Catch ex As Exception
        '    Ris = 1
        'End Try

        'Try

        '    Using msg As New MailMessage()
        '        msg.Subject = "Invio File"
        '        'msg.IsBodyHtml = True
        '        msg.Body = "Invio Fattura XML"

        '        If Dest.Trim.Length Then
        '            For Each d As String In Dest.Split(";")
        '                msg.To.Add(d.TrimEnd(";"))
        '            Next
        '        End If

        '        msg.From = New MailAddress(FromAddr, FromName)

        '        If Not ListaAllegati Is Nothing Then

        '            For Each Allegato As String In ListaAllegati
        '                If System.IO.File.Exists(Allegato) Then
        '                    Dim a As New Net.Mail.Attachment(Allegato)
        '                    a.ContentId = FormerHelper.File.EstraiNomeFile(Allegato)
        '                    msg.Attachments.Add(a)
        '                End If
        '            Next

        '        End If

        '        Using sm As New SmtpClient(FormerLib.FormerHelper.Mail.SMTPServerPEC)
        '            Dim c As New System.Net.NetworkCredential(FromAddr, FromPwd)
        '            sm.Port = 465
        '            sm.UseDefaultCredentials = False
        '            sm.EnableSsl = True
        '            sm.Credentials = c
        '            sm.DeliveryMethod = SmtpDeliveryMethod.Network

        '            sm.Send(msg)

        '        End Using
        '    End Using

        'Catch ex As Exception
        '    If ex.Message.IndexOf("policy violation") <> -1 Then
        '        'qui devo loggare in qualche modo la violazione di policy 
        '        Try
        '            My.Application.Log.WriteException(ex, TraceEventType.Error, "Policy Violation")
        '        Catch exPolicy As Exception

        '        End Try
        '    End If
        '    Ris = 1
        'End Try
        Return Ris

    End Function

    Private Sub TestRegularExpression()

        Using s As New Imap4Client()
            s.ConnectSsl("imaps.pec.aruba.it", 993)
            s.Login(MgrAziende.GetPEC(MgrAziende.IdAziende.AziendaSnc), MgrAziende.GetPECPassword(MgrAziende.IdAziende.AziendaSnc))

            Dim m As Mailbox = s.SelectMailbox("INBOX.FE.2019.V.3")
            Dim fetch As Fetch = m.Fetch

            Dim count As Integer = m.MessageCount
            Dim PathStart As String = FormerPath.PathTempLocale & MgrAziende.IdAziende.AziendaSrl  'MgrAziende.GetAziendaStr(IdAzienda)

            Try
                ' IO.Directory.Delete(PathStart, True)
            Catch ex As Exception

            End Try

            If count Then

                For i As Integer = count To 1 Step -1
                    Dim Titolo As String = String.Empty

                    Dim DaSpostare As Boolean = False

                    Dim msg As Message = fetch.MessageObject(i)
                    'Dim msgMail As MailMessage = msg.ToMailMessage

                    'Dim body As String = msgMail.Body
                    Titolo = msg.Subject
                    'Dim ListaAllegati As New List(Of String)
                    Dim Mittente As String = msg.From.Email

                    Dim path As String = PathStart & "\" & i & "\"

                    FormerLib.FormerHelper.File.CreateLongPath(path)
                    Dim PathXML As String = ""
                    Dim BufferXML As String = ""
                    Dim PathEML As String = ""

                    Dim NuovoStato As enStatoFatturaFE = -1
                    Dim NuovoFolder As String = String.Empty

                    Dim TipoMail As enTipoMailPEC = enTipoMailPEC.Altro

                    If Titolo.StartsWith("POSTA CERTIFICATA: Ricevuta di consegna ", StringComparison.CurrentCultureIgnoreCase) Then
                        TipoMail = enTipoMailPEC.Ricevuta
                        Dim testo As String = String.Empty
                        For Each a As MimePart In msg.EmbeddedObjects
                            If Not a.ContentName Is Nothing AndAlso a.ContentName.EndsWith(".eml") Then

                                Dim NomeFile As String = path & a.ContentName
                                Using f As New FileStream(NomeFile, FileMode.Create, FileAccess.Write)
                                    f.Write(a.BinaryContent, 0, a.BinaryContent.Length)
                                End Using

                                'Dim Buffer As String = String.Empty

                                Using r As New StreamReader(NomeFile)
                                    testo = r.ReadToEnd
                                End Using
                                Exit For

                            End If
                        Next
                        If testo.Length Then
                            Dim espressione As String = "sdi([0-9]){1,50}@pec.fatturapa.it"

                            Dim risultato As Match = Regex.Match(testo, espressione)

                            If Not risultato Is Nothing Then
                                If risultato.Success Then
                                    MessageBox.Show(risultato.Value)
                                End If
                            End If
                        End If


                        'qui devo vedere nel contenuto 

                    End If
                Next
            End If
        End Using

    End Sub

    Public Sub LegaCostoACarico(ByRef C As Costo)

        Dim cm As CaricoDiMagazzino = CaricoMagazzinoDaCosto(C)

        For Each mov In cm.ListaMovimenti
            If mov.IdVoceCosto = 0 Then

                Dim vc As VoceCosto = C.ListaVociFattura.Find(Function(x) x.Codice = mov.CodiceForn And x.Qta = mov.Qta And cm.ListaMovimenti.FindAll(Function(z) z.IdVoceCosto = x.IdVoceCosto).Count = 0)

                If Not vc Is Nothing Then
                    'qui va agganciata
                    mov.IdVoceCosto = vc.IdVoceCosto
                    mov.IdFat = C.IdCosto
                    mov.Save()

                Else
                    'qui non c'e' una riga nella fattura a cui agganciare questo movimento di carico
                    cm.IdStatoInterno = enStatoFEInterno.Anomalia
                End If
            End If
        Next

        For Each riga In C.ListaVociFattura
            If cm.ListaMovimenti.FindAll(Function(x) x.IdVoceCosto = riga.IdVoceCosto).Count = 0 Then
                'questa riga va completamente creata e aggiunta al documento di carico
                'devo prima cercarela risorsa 
                'se non la trovo devo crearla e poi metterla nel carico di magazzino
                C.StatoFEInterno = enStatoFEInterno.Anomalia

                Using mgr As New MagazzinoDAO
                    Dim lMov As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.CodiceForn, riga.Codice),
                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))

                    If lMov.Count Then
                        'qui l'ho trovata 
                        Dim MovCampione As MovimentoMagazzino = lMov(0)
                        Using v As New MovimentoMagazzino
                            v.IdRis = MovCampione.IdRis
                            v.DataMov = C.DataCosto
                            v.CodiceForn = MovCampione.CodiceForn
                            v.DescrForn = riga.Descrizione
                            v.TipoMov = enTipoMovMagaz.Carico
                            v.IdForn = MovCampione.IdForn
                            v.IdVoceCosto = riga.IdVoceCosto
                            v.IdFat = C.IdCosto
                            v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                            v.Qta = riga.Qta
                            v.Prezzo = riga.Totale
                            v.PrezzoUnit = riga.PrezzoUnit
                            v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                            v.Save()
                        End Using

                    Else
                        'qui devo proprio creare la risorsa
                        Using r As New Risorsa
                            r.TipoRis = enTipoProdCom.NonSpecificato
                            r.Codice = riga.Codice
                            r.Descrizione = riga.Descrizione
                            r.Stato = enStato.Attivo
                            r.Save()

                            Using v As New MovimentoMagazzino
                                v.IdRis = r.IdRis
                                v.DataMov = C.DataCosto
                                v.CodiceForn = riga.Codice
                                v.DescrForn = riga.Descrizione
                                v.TipoMov = enTipoMovMagaz.Carico
                                v.IdForn = C.IdRub
                                v.IdVoceCosto = riga.IdVoceCosto
                                v.IdFat = C.IdCosto
                                v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                v.Qta = riga.Qta
                                v.Prezzo = riga.Totale
                                v.PrezzoUnit = riga.PrezzoUnit
                                v.IdCaricoMagazzino = cm.IdCaricoMagazzino

                                v.Save()
                            End Using


                        End Using
                    End If

                End Using

            End If
        Next

        If C.IsChanged Then C.Save()
        If cm.IsChanged Then cm.Save()

    End Sub


    Public Function CaricoMagazzinoDaCosto(C As Costo) As CaricoDiMagazzino

        Dim ris As CaricoDiMagazzino = Nothing


        Using mgr As New CarichiDiMagazzinoDAO
            Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.NumeroDocRiferimento, C.Numero),
                            New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdRub, C.IdRub),
                            New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.TipoDocRiferimento, C.Tipo),
                            New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdAzienda, C.IdAzienda))

            If l.Count Then
                'qui lo lego 
                If ris.IdCosto <> C.IdCosto Then
                    ris = l(0)
                    ris.IdCosto = C.IdCosto
                    ris.IdStatoInterno = enStatoFEInterno.Collegato
                    ris.Save()
                End If

            Else
                'qui lo creo
                ris = New CaricoDiMagazzino
                ris.IdAzienda = C.IdAzienda
                ris.DataCarico = Now
                ris.IdUtCarico = FormerConst.UtentiSpecifici.IdUtenteAdmin
                ris.IdRub = C.IdRub
                ris.NumeroDocRiferimento = C.Numero
                Dim TipoDoc As enTipoDocumento
                If C.Tipo = enTipoDocumento.FatturaRiepilogativa OrElse C.Tipo = enTipoDocumento.Fattura Then
                    TipoDoc = enTipoDocumento.Fattura
                ElseIf C.Tipo = enTipoDocumento.DDT Then
                    TipoDoc = enTipoDocumento.DDT
                End If
                ris.TipoDocRiferimento = TipoDoc
                ris.IdCosto = C.IdCosto
                ris.IdStatoInterno = enStatoFEInterno.Collegato
                ris.Save()
            End If

        End Using

        Return ris

    End Function

    Private Sub AgganciaCosti()

        'FormerDaemon_Server.Messenger.AgganciaDocumentiFiscalieCarichi()


        Using mgr As New CostiDAO
            Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchParameter("Year(DataCosto)", 2019),
                New LUNA.LunaSearchParameter(LFM.Costo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.Fattura & ")", "In"))
            Dim CostiErrore As New List(Of Integer)
            For Each costo In l
                If costo.IdCat = FormerConst.CategorieContabili.MateriePrime OrElse
costo.Fornitore.IdCatContab = FormerConst.CategorieContabili.MateriePrime Then
                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                        Try
                            tb.TransactionBegin()
                            costo.IdCat = FormerConst.CategorieContabili.MateriePrime
                            costo.Save()
                            MgrMagazzinoBusiness.LegaCostoACarico(costo,, True)
                            tb.TransactionCommit()
                        Catch ex As Exception
                            tb.TransactionRollBack()
                            CostiErrore.Add(costo.IdCosto)
                        End Try
                    End Using



                End If


            Next
            MessageBox.Show("Finito " & CostiErrore.Count)
        End Using

    End Sub

    Private globalCounter As Integer = 0
    Private Sub StampaDocumento(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Dim w As WebBrowser = sender

        'w.ShowPrintDialog()
        globalCounter += 1
        If globalCounter = 1 Then
            w.Print()
            RemoveHandler w.DocumentCompleted, AddressOf StampaDocumento
            globalCounter = 0
        End If

    End Sub

    Friend Shared Sub CreaFatturaElettronica(ByVal bufferXml As String,
    ByRef webRiepilogo As WebBrowser,
    Optional XslConPath As Boolean = True)

        webRiepilogo.Navigate("about:blank")
        Cursor.Current = Cursors.WaitCursor
        Dim RigaXSL As String = ""

        'RigaXSL = ControlChars.NewLine & "<?xml-stylesheet type=""text/xsl"" href=""" & Environment.CurrentDirectory.Replace("\", "/") & "/fatturaordinaria_v1.2.xsl""?>"
        If XslConPath Then
            RigaXSL = "<?xml-stylesheet type=""text/xsl"" href=""z:/fatture/fe/fatturaordinaria_v1.2.xsl""?>"
        Else
            RigaXSL = "<?xml-stylesheet type=""text/xsl"" href=""fatturaordinaria_v1.2.xsl""?>"
        End If

        Dim posiz As Integer = 0 ' bufferXml.IndexOf(">")
        Dim bufferXmlFinale As String = String.Empty

        posiz = bufferXml.IndexOf("<?xml-stylesheet")

        If posiz <> -1 Then
            Dim PosizFine As Integer = 0
            PosizFine = bufferXml.IndexOf(">", posiz)

            If posiz <> 0 Then bufferXmlFinale = bufferXml.Substring(0, posiz)
            bufferXmlFinale &= RigaXSL
            bufferXmlFinale &= bufferXml.Substring(PosizFine + 1)
        Else
            posiz = bufferXml.IndexOf(">")
            bufferXmlFinale = bufferXml.Substring(0, posiz + 1)
            bufferXmlFinale &= RigaXSL
            bufferXmlFinale &= bufferXml.Substring(posiz + 1)
        End If

        'If bufferXml.IndexOf("fatturaordinaria_v1.2.xsl") = -1 Then
        '    bufferXmlFinale = bufferXml.Substring(0, posiz + 1) & RigaXSL & bufferXml.Substring(posiz + 1)
        'Else
        '    'qui devo sostituire il path 
        '    bufferXmlFinale = bufferXml.Replace("fatturaordinaria_v1.2.xsl", "z:/fatture/fe/fatturaordinaria_v1.2.xsl")
        'End If

        Dim NomeFileFatt As String = FormerPath.PathTempLocale & "tempfattura.xml"
        Using w As New StreamWriter(NomeFileFatt)
            w.Write(bufferXmlFinale)
        End Using
        webRiepilogo.Navigate(NomeFileFatt)
        'webRiepilogo.Document.OpenNew(False)
        'webRiepilogo.Document.Write(bufferXmlFinale)
        'webRiepilogo.Refresh()

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub StampaHTML()

        ' Dim prin As New System.PrintDialog
        ' prin.ShowDialog()
        'If prin.PrinterSettings.PrinterName.Length Then prn.PrinterSettings.PrinterName = prin.PrinterSettings.PrinterName

        If MessageBox.Show("Confermi la stampa massiva dei documenti di Acquisto visualizzati?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim w As New WebBrowser


            'Software\Microsoft\Internet Explorer\PageSetup

            Dim okey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Internet Explorer\PageSetup", True)

            okey.SetValue("footer", "")
            okey.SetValue("header", "")
            okey.SetValue("Shrink_To_Fit", "yes")



            AddHandler w.DocumentCompleted, AddressOf StampaDocumento

            'Using f As New StreamWriter("c:\temp\fattura.xml")
            Using c As New Costo
                c.Read(6241)
                'f.Write(c.DocXML)

                CreaFatturaElettronica(c.DocXML, w, False)
                'Threading.Thread.Sleep(2000)
                'webReport.Print()
                'webReport.Print()
                'w.Navigate("file://c:/temp/fattura.xml")
            End Using
            'RemoveHandler w.DocumentCompleted, AddressOf StampaDocumento
            'End Using






        End If

    End Sub
    Private Sub ResetCosto()
        Dim Buffer As String = String.Empty
        Using r As New StreamReader("c:\temp\fattura.xml")
            Buffer = r.ReadToEnd
        End Using

        Using c As New Costo
            c.Read(5937)
            c.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto

            c.DocXML = Buffer
            c.Save()


        End Using

    End Sub

    Private Sub TestDoppioPrezzo()

        Using Lrif As New FW.ListinoBaseW
            Lrif.Read(313)
            Lrif.CaricaLavorazioniBase()
            Lrif.CaricaLavorazioniOpz()

            Dim listaBaseB As List(Of ILavorazioneB) = Lrif.LavorazioniBaseB

            Lrif.NumFacciate = 8

            If Lrif.NumFacciate > Lrif.faccmax Then Lrif.NumFacciate = Lrif.faccmax
            If Lrif.NumFacciate < Lrif.faccmin Then Lrif.NumFacciate = Lrif.faccmin

            Dim Qta As Integer = 10
            Dim buffer As String = String.Empty
            Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine

            Qta = 50
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine

            Qta = 100
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine
            Qta = 150
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine
            Qta = 200
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine
            Qta = 249
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine
            Qta = 250
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(Lrif, Qta, listaBaseB,,, False)
            buffer &= Qta & " - " & R.PrezzoRiv & " " & R.PrezzoPubbl & ControlChars.NewLine
            MessageBox.Show(buffer)

        End Using

    End Sub

    Private Sub TestFatturaElettronica()


        'Dim F As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(PathXML)

        'Dim RisSalvataggio As RisSalvaCostoDaFatturaElettronica = MgrFattureFE.SalvaCostoDaFatturaElettronica(F, PathXML)


        Dim PathXml As String = "C:\temp\f.xml"
        Dim F As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(PathXml)

        Dim RisSalvataggio As RisSalvaCostoDaFatturaElettronica = MgrFattureFE.SalvaCostoDaFatturaElettronica(F, PathXml)

        Exit Sub

        Using R As New Ricavo
            R.Read(39866)
            Using RicavoRif As Ricavo = R.RicavoRiferimentoNotadiCredito

                Dim Path As String = "w:\fatture\fe\2019\2\IT14974961006_A0318.xml"

                Dim FatturaVecchia As FatturaElettronica = MgrFattureFE.GetFatturaFromRicavo(RicavoRif)
                'Dim FatturaVecchia As FatturaElettronica = MgrFattureFE.GetFatturaFromXML(Path)

                Dim PrefissoPIva As String = String.Empty
                Dim Piva As String = String.Empty
                Dim CodFiscale As String = String.Empty
                Dim RagSociale As String = String.Empty
                Dim Nome As String = String.Empty
                Dim Cognome As String = String.Empty
                Dim SedeIndirizzo As String = String.Empty
                Dim SedeCap As String = String.Empty
                Dim SedeComune As String = String.Empty
                Dim SedeProvincia As String = String.Empty
                Dim SedeNazione As String = String.Empty


                PrefissoPIva = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese
                If PrefissoPIva Is Nothing Then PrefissoPIva = String.Empty
                Piva = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice
                'If Piva Is Nothing Then Piva = String.Empty
                CodFiscale = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.CodiceFiscale
                If CodFiscale Is Nothing Then CodFiscale = String.Empty
                RagSociale = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione
                If RagSociale Is Nothing Then RagSociale = String.Empty
                Nome = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Nome
                'If Nome Is Nothing Then Nome = String.Empty
                Cognome = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome
                If Cognome Is Nothing Then Cognome = String.Empty
                SedeIndirizzo = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Indirizzo
                If SedeIndirizzo Is Nothing Then SedeIndirizzo = String.Empty
                SedeCap = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.CAP
                If SedeCap Is Nothing Then SedeCap = String.Empty
                SedeComune = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Comune
                If SedeComune Is Nothing Then SedeComune = String.Empty
                SedeProvincia = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Provincia
                If SedeProvincia Is Nothing Then SedeProvincia = String.Empty
                SedeNazione = FatturaVecchia.FatturaElettronicaHeader.CessionarioCommittente.Sede.Nazione
                If SedeNazione Is Nothing Then SedeNazione = String.Empty


                If Nome.Length Then
                    Dim X As Integer
                    X += 1
                End If



            End Using
        End Using

    End Sub

    Private Function TestListiniBase() As Integer
        Dim TotFixed As Integer = 0
        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.GetAll()

            For Each Lb As ListinoBase In l

                Lb.CaricaLavorazioni()
                Lb.NumFacciate = Lb.FaccMin
                Dim Altezza As Integer = 0
                Dim Larghezza As Integer = 0
                If Lb.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                    Altezza = 100
                    Larghezza = 100
                End If

                Dim Ris As RisListinoBase = MgrPreventivazioneB.CalcolaListinoBase(Lb,
                    Lb.LavorazioniBaseB,
                    Nothing,
                    Altezza,
                    Larghezza,
                    True)

                Dim Val1 As Decimal = Lb.v1 - Ris.PrezzoLavObbl1
                Dim Val2 As Decimal = Lb.v2 - Ris.PrezzoLavObbl2
                Dim Val3 As Decimal = Lb.v3 - Ris.PrezzoLavObbl3
                Dim Val4 As Decimal = Lb.v4 - Ris.PrezzoLavObbl4
                Dim Val5 As Decimal = Lb.v5 - Ris.PrezzoLavObbl5
                Dim Val6 As Decimal = Lb.v6 - Ris.PrezzoLavObbl6

                Dim p1 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val1, Ris.PrezzoRivCalc1)
                Dim p2 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val2, Ris.PrezzoRivCalc2)
                Dim p3 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val3, Ris.PrezzoRivCalc3)
                Dim p4 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val4, Ris.PrezzoRivCalc4)
                Dim p5 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val5, Ris.PrezzoRivCalc5)
                Dim p6 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val6, Ris.PrezzoRivCalc6)

                Dim Anomalia As Boolean = False
                If p1 <> Lb.p1 Then
                    Anomalia = True
                End If
                If p2 <> Lb.p2 Then
                    Anomalia = True
                End If
                If p3 <> Lb.p3 Then
                    Anomalia = True
                End If
                If p4 <> Lb.p4 Then
                    Anomalia = True
                End If
                If p5 <> Lb.p5 Then
                    Anomalia = True
                End If
                If p6 <> Lb.p6 Then
                    Anomalia = True
                End If

                If Anomalia Then
                    TotFixed += 1

                    Lb.p1 = p1
                    Lb.p2 = p2
                    Lb.p3 = p3
                    Lb.p4 = p4
                    Lb.p5 = p5
                    Lb.p6 = p6
                    Lb.Save()

                End If
            Next
        End Using

        Return TotFixed

    End Function


    Public Sub PrenotaSpedizioneGls(ByRef c As ConsegnaProgrammata)

        If c.SpedibileConGls = True Then
            Dim IdCons As Integer = c.IdCons
            'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
            Dim lstZpl As String = String.Empty
            Dim CodTrack As String = String.Empty
            Dim Ok As Boolean = True
            For i = 1 To c.NumColli
                If Ok Then
                    Try
                        Dim ContatoreProgressivo As Integer = i
                        Dim SegnaCollo As SegnaCollo = MgrWebLabelingGls.GetSegnaCollo(c, ContatoreProgressivo)
                        'lstPdfStreams.Add(SegnaCollo.PdfLabel)
                        lstZpl &= SegnaCollo.Zpl & vbCrLf
                        CodTrack = SegnaCollo.NumeroSpedizione
                    Catch ex As Exception
                        Ok = False
                        'MessageBox.Show(ex.Message)
                        Throw ex
                    End Try
                End If
            Next

            If Ok Then
                c.CodTrack = CodTrack
                'c.Blocco = enSiNo.Si
                c.DataTrasmissioneCorriere = Now.Date()
                c.Save()
                Using mgr As New ConsegneProgrammateDAO()
                    mgr.AvanzaStatoConsegna(c, enStatoConsegna.RegistrataCorriere)
                End Using

                Dim Path As String = FormerPath.PathTempLocale()
                'Dim PdfSalvato As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
                'Dim PdfSalvato As String = CodTrack & ".pdf"
                'Dim Pdf As String = Path & PdfSalvato
                Dim ZplSalvato As String = c.CodTrack & ".zpl"
                Dim Zpl As String = Path & ZplSalvato

                Try
                    'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                    'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                    Using objWriter As New System.IO.StreamWriter(Zpl)
                        objWriter.Write(lstZpl)
                    End Using
                Catch ex As Exception

                End Try

                Dim StampanteEtichetteGls As String = FConfiguration.Printer.EtichetteGLS ' Configuration.ConfigurationManager.AppSettings("StampanteEtichetteGls")
                'TODO: E' IL CASO DI METTERE ANCHE LE DIMENSIONI DELLA PAGINA IN CONFIGURAZIONE?
                'FormerHelper.PDF.StampaPdf(Pdf, StampanteEtichetteGls, 297, 288)
                'FormerHelper.File.ShellExtended(Pdf)
                'QUI STAMPO LA STRINGA ZPL
                'TODO: SE DEBUG DISABILITARE LA STAMPA
                If FormerDebug.DebugAttivo = False Then
                    RawPrinterHelper.SendStringToPrinter(StampanteEtichetteGls, lstZpl)
                End If
            End If
            'Else
            '    Throw New Exception("La spedizione non può essere spedita con GLS!")
        End If

    End Sub

    Private Sub CloseWorkDay()

        Dim l As List(Of ConsegnaProgrammata)

        Using mgr As New ConsegneProgrammateDAO
            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, "(133550,133556,133744)", "IN"))

        End Using

        Dim risultato As String = MgrWebLabelingGls.TrasmettiSpedizioniGls(l)

        MessageBox.Show(risultato)

    End Sub

    Private Sub BannerCasuale()

        Using mgr As New BannerSitoDAO
            Dim l As List(Of BannerSito) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.BannerSito.Stato, enStato.Attivo))

            Randomize()
            Dim r As New Random
            Dim bannerScelto As BannerSito = l(r.Next(l.Count))

            txtDebug.Text = bannerScelto.IdBannerSito & " - " & bannerScelto.Url
        End Using

    End Sub

    Private Sub TestCheckListini()
        'qui devo ricalcolare le percentuali di ricarico di ogni quantità
        Using lb As New ListinoBase
            lb.Read(260)
            lb.CaricaLavorazioni()
            lb.NumFacciate = lb.FaccMin

            Dim V1 As Single = lb.p1
            Dim V2 As Single = lb.p2
            Dim V3 As Single = lb.p3
            Dim V4 As Single = lb.p4
            Dim V5 As Single = lb.p5
            Dim V6 As Single = lb.p6

            Dim ris As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(lb,
                                                lb.LavorazioniBaseB)

            If lb.p1 <> V1 OrElse
lb.p2 <> V2 OrElse
lb.p3 <> V3 OrElse
lb.p4 <> V4 OrElse
lb.p5 <> V5 OrElse
lb.p6 <> V6 Then

                'RisModificati += 1

            End If

            lb.VMotoreCalcolo = MgrPreventivazioneB.VMotoreCalcolo
            'lb.Save()
        End Using


    End Sub
    'Private Function GetReportSingolaAzienda(IdAzienda As Integer) As String

    '    Dim Buffer As String = String.Empty

    '    Buffer = "<font face=""Arial""><h1>" & MgrAziende.GetAziendaStr(IdAzienda) & "</h1>"

    '    For i As Integer = 1 To Now.Month
    '        Buffer &= "<h2>" & FormerLib.FormerHelper.Calendario.MeseToString(i) & "</h2>"
    '        Using mgr As New RicaviDAO
    '            Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, IdAzienda),
    '                                                   New LUNA.LunaSearchParameter("Month(DataRicavo)", i),
    '                                                   New LUNA.LunaSearchParameter("Year(DataRicavo)", 2019),
    '                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"))

    '            Dim TotNetto As Decimal = l.FindAll(Function(x) x.Tipo <> enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Importo)

    '            TotNetto -= l.FindAll(Function(x) x.Tipo = enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Importo)

    '            Dim TotLordo As Decimal = l.FindAll(Function(x) x.Tipo <> enTipoDocumento.NotaDiCredito).Sum(Function(x) x.TotaleEx)

    '            Buffer &= "Emessi <b>" & l.Count & "</b> documenti per un totale netto di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</b> (lordo &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</b>)"

    '        End Using

    '        Using mgr As New CostiDAO
    '            Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Costo.IdAzienda, IdAzienda),
    '                                                   New LUNA.LunaSearchParameter("Month(datacosto)", i),
    '                                                   New LUNA.LunaSearchParameter("Year(datacosto)", 2019),
    '                                                   New LUNA.LunaSearchParameter(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"))

    '            Dim TotNetto As Decimal = l.FindAll(Function(x) x.Tipo <> enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Importo)
    '            TotNetto -= l.FindAll(Function(x) x.Tipo = enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Importo)

    '            Dim TotLordo As Decimal = l.FindAll(Function(x) x.Tipo <> enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Totale)
    '            TotLordo -= l.FindAll(Function(x) x.Tipo = enTipoDocumento.NotaDiCredito).Sum(Function(x) x.Totale)

    '            Buffer &= "<br><br>Ricevuti <b>" & l.Count & "</b> documenti per un totale netto di &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotNetto) & "</b> (lordo &euro; <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotLordo) & "</b>)"

    '        End Using

    '    Next

    '    Return Buffer

    'End Function

    Private Sub ReportFatture()

        'MgrAziende.ReportFatture()

    End Sub

    'Async Sub DownloadPageAsync()
    '    Dim page As String = "http://192.168.1.173:30081/jdf-fum/jmf"

    '    ' Use HttpClient in Using-statement.
    '    ' ... Use GetAsync to get the page data.
    '    Using client As HttpClient = New HttpClient()
    '        Using response As HttpResponseMessage = Await client.GetAsync(page)
    '            txtDebug.Invoke(CType(Function()
    '                                      txtDebug.AppendText("HEADER" & ControlChars.NewLine)
    '                                  End Function, MethodInvoker))
    '            For Each h In response.Headers
    '                txtDebug.Invoke(CType(Function()
    '                                          txtDebug.AppendText(h.Key.ToString & ": " & h.Value.ToString & ControlChars.NewLine)
    '                                      End Function, MethodInvoker))
    '            Next

    '            Using content As HttpContent = response.Content
    '                ' Get contents of page as a String.
    '                Dim result As String = Await content.ReadAsStringAsync()
    '                ' If data exists, print a substring.
    '                If result IsNot Nothing And result.Length > 50 Then
    '                    txtDebug.Invoke(CType(Function()
    '                                              txtDebug.AppendText(result)
    '                                          End Function, MethodInvoker))
    '                End If
    '            End Using
    '        End Using
    '    End Using
    'End Sub

    Public Sub TestInvioMultipart(PathPdf As String)

        Dim UrlTarget As String = "http://192.168.1.173:30081/jdf-fum/jmf"

        Dim ByteBuffer() As Byte = File.ReadAllBytes(PathPdf)
        Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(PathPdf)
        Dim NomeFileSenzaEstensione As String = NomeFile.Substring(0, NomeFile.Length - 4)

        NomeFile = FormerHelper.Web.NormalizzaNomeFile(NomeFile)
        NomeFileSenzaEstensione = FormerHelper.Web.NormalizzaNomeFile(NomeFileSenzaEstensione)

        Dim webClient = New WebClient()
        Dim boundary As String = "------------------------" & DateTime.Now.Ticks.ToString("x")
        webClient.Headers.Add("MIMEVersion", "1.0")
        webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" & boundary)

        Dim fileData As String = webClient.Encoding.GetString(ByteBuffer)

        Dim buffer As String = String.Empty

        buffer &= "--" & boundary & ControlChars.NewLine
        buffer &= "Content-Type: application/vnd.cip4-jmf+xml;" & ControlChars.NewLine
        buffer &= "Content-Transfer-Encoding: 8bit" & ControlChars.NewLine
        buffer &= "Content-Disposition: attachment; filename=""JobId.jmf"";" & ControlChars.NewLine
        buffer &= "Content-ID: <JobId.jmf>" & ControlChars.NewLine
        buffer &= "<?xml version=""1.0"" encoding=""UTF-8"" ?><JMF SenderID=""Former"" TimeStamp=""2019-03-30T00:23:05-08:00"" Version=""1.2"" xmlns=""http://www.CIP4.org/JDFSchema_1_1""><Command ID=""id0001"" Type=""SubmitQueueEntry""><QueueSubmissionParams URL=""cid:JobID.jdf""/></Command></JMF>" & ControlChars.NewLine
        buffer &= "--" & boundary & ControlChars.NewLine
        buffer &= "Content-Type: application/vnd.cip4-jdf+xml;" & ControlChars.NewLine
        buffer &= "Content-Transfer-Encoding: 8bit" & ControlChars.NewLine
        buffer &= "Content-Disposition: attachment; filename=""JobID.jdf"";" & ControlChars.NewLine
        buffer &= "Content-ID: <JobID.jdf>" & ControlChars.NewLine
        buffer &= "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no"" ?>" & ControlChars.NewLine
        buffer &= "<JDF xmlns=""http://www.CIP4.org/JDFSchema_1_1"" Activation=""Held"" ID=""Job01"" Status=""Ready"" Type=""Combined"" Types=""LayoutPreparation Imposition Interpreting Rendering DigitalPrinting Stitching"" Version=""1.2"">" & ControlChars.NewLine
        buffer &= "<ResourcePool>" & ControlChars.NewLine
        buffer &= "<Media Class=""Consumable"" DescriptiveName=""media01"" ID=""Res_01"" ProductID=""01"" Status=""Available"">" & ControlChars.NewLine
        buffer &= "<Location LocationName=""Tray-3""/>" & ControlChars.NewLine
        buffer &= "</Media>" & ControlChars.NewLine
        buffer &= "<DigitalPrintingParams Class=""Parameter"" ID=""DPP"" Status=""Available"" />" & ControlChars.NewLine
        buffer &= "<LayoutPreparationParams Class=""Parameter"" ID=""LPP"" Sides=""OneSidedFront"" Status=""Available""/>" & ControlChars.NewLine
        buffer &= "<RunList Class=""Parameter"" ID=""RLL"" Status=""Available"">" & ControlChars.NewLine
        buffer &= "<LayoutElement>" & ControlChars.NewLine
        buffer &= "<FileSpec File=""file"" URL=""cid:""" & NomeFile & """ />" & ControlChars.NewLine
        buffer &= "</LayoutElement>" & ControlChars.NewLine
        buffer &= "</RunList>" & ControlChars.NewLine
        buffer &= "<CustomerInfo CustomerJobName=""test.pdf"" CustomerID=""FormerLab""/>" & ControlChars.NewLine
        buffer &= "<Component Class=""Quantity"" ID=""CL"" Status=""Unavailable""/>" & ControlChars.NewLine
        buffer &= "<ColorantControl Class=""Parameter"" ID=""CCL"" ProcessColorModel=""DeviceGray"" Status=""Available""/>" & ControlChars.NewLine
        buffer &= "</ResourcePool>" & ControlChars.NewLine
        buffer &= "<ResourceLinkPool>" & ControlChars.NewLine
        buffer &= "<MediaLink CombinedProcessIndex=""0"" Usage=""Input"" rRef=""Res_01""/>" & ControlChars.NewLine
        buffer &= "<LayoutPreparationParamsLink CombinedProcessIndex=""0"" Usage=""Input"" rRef=""LPP""/>" & ControlChars.NewLine
        buffer &= "<RunListLink xmlns=""0"" CombinedProcessIndex=""0 1"" Usage=""Input"" rRef=""RLL""/>" & ControlChars.NewLine
        buffer &= "<DigitalPrintingParamsLink CombinedProcessIndex=""4"" Usage=""Input"" rRef=""DPP""/>" & ControlChars.NewLine
        buffer &= "<ComponentLink Amount=""5"" CombinedProcessIndex=""4"" Usage=""Output"" rRef=""CL""/>" & ControlChars.NewLine
        buffer &= "<ColorantControlLink CombinedProcessIndex=""4"" Usage=""Input"" rRef=""CCL""/>" & ControlChars.NewLine
        buffer &= "</ResourceLinkPool>" & ControlChars.NewLine
        buffer &= "<AuditPool>" & ControlChars.NewLine
        buffer &= "<Created AgentName=""FormerLab"" AgentVersion=""1.0"" TimeStamp=""2019-03-30T16:45:17+05:00""/>" & ControlChars.NewLine
        buffer &= "</AuditPool>" & ControlChars.NewLine
        buffer &= "</JDF>" & ControlChars.NewLine
        buffer &= "--" & boundary & ControlChars.NewLine
        buffer &= "Content-Type: application/pdf;" & ControlChars.NewLine
        buffer &= "Content-Transfer-Encoding: base64" & ControlChars.NewLine
        buffer &= "Content-Disposition: attachment; filename=""" & NomeFile & """;" & ControlChars.NewLine
        buffer &= "Content-ID: <" & NomeFile & ">" & ControlChars.NewLine
        buffer &= Convert.ToBase64String(ByteBuffer) & ControlChars.NewLine
        buffer &= "--" & boundary & "--"

        Dim nfile() As Byte = webClient.Encoding.GetBytes(buffer)

        File.WriteAllBytes("c:\temp\test.mjm", nfile)

        Dim resp As Byte() = webClient.UploadData(UrlTarget, "POST", nfile)

    End Sub

    Private Sub CompletaConsegne()

        Try
            'UN GIORNO QUESTA FUNZIONE SPARISCE 
            LogMe("***COMPLETAMENTO CONSEGNE***")
            Dim IdConsChius As New List(Of Integer)

            'prendo tutti gli ordin iin stato in consegna prima di X giorni a seconda del corriere della consegna e 
            'li metto a consegnato spostando anche la relativa consegna
            Dim ggCorrFormer As Integer = 3
            Dim ggAltroCorriere As Integer = 7

            Using mgr As New OrdiniDAO
                Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataIns Desc"},
                    New LUNA.LunaSearchParameter("Stato", enStatoOrdine.InConsegna))

                'l = l.FindAll(Function(x) Not x.ConsegnaAssociata Is Nothing AndAlso _
                '                  (DateDiff(DateInterval.Day, x.ConsegnaAssociata.Giorno, DataRiferimento) > ggCorrFormer And x.ConsegnaAssociata.IdStatoConsegna < enStatoConsegna.Consegnata))
                l = l.FindAll(Function(x) Not x.ConsegnaAssociata Is Nothing)

                For Each O As Ordine In l

                    If IdConsChius.FindAll(Function(x) x = O.IdCons).Count = 0 Then
                        Dim Diff As Integer = DateDiff(DateInterval.Day, O.ConsegnaAssociata.Giorno, Now.Date)
                        'questa consegna non e' stata gia trattata
                        If O.ConsegnaAssociata.IdCorr = enCorriere.GLS Or
O.ConsegnaAssociata.IdCorr = enCorriere.GLSIsole Or
O.ConsegnaAssociata.IdCorr = enCorriere.PortoAssegnatoGLS Then

                            Dim CodTrack As String = O.ConsegnaAssociata.CodTrack.Trim(" ")

                            If CodTrack.Length Then
                                'qui devo fare il tracking della consegna
                                Dim StatoSped As String = MgrTraceCorriere.GetStatoConsegnaStrFromOnline(CodTrack)
                                If StatoSped.ToLower.Trim(" ") = "consegnato" Then
                                    mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                    If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                        IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                    End If
                                End If
                            Else
                                'qui il codice track non c'e' aspetto cmq i giorni previsti per portarlo avanti 
                                If Diff > ggAltroCorriere Then
                                    mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                    If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                        IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                    End If
                                End If
                            End If
                        Else
                            'questo andra tolto nel momento in cui finisco la funzione del gestionale da cui loro possono segnalre cosa hanno consegnato
                            If O.ConsegnaAssociata.Corriere.IdCorriere = enCorriere.TipografiaFormer Or
O.ConsegnaAssociata.Corriere.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                                If Diff > ggCorrFormer Then
                                    mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                    If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                        IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                    End If
                                End If
                            End If

                        End If
                    End If

                Next
            End Using

            Using mgr As New ConsegneProgrammateDAO
                Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InConsegna),
                                New LUNA.LunaSearchParameter("IdCorr", "(" & enCorriere.GLS & "," & enCorriere.GLSIsole & "," & enCorriere.PortoAssegnatoGLS & ")", "IN"))
                For Each c As ConsegnaProgrammata In l

                    Dim CodTrack As String = c.CodTrack.Trim(" ")
                    If CodTrack.Length Then
                        Dim StatoSped As String = MgrTraceCorriere.GetStatoConsegnaStrFromOnline(CodTrack)
                        If StatoSped.ToLower.Trim(" ") = "consegnato" Then
                            mgr.AvanzaStatoConsegna(c, enStatoConsegna.Consegnata)
                            LogMe("- Consegna " & c.IdCons & " completata da XML Gls")
                            IdConsChius.Add(c.IdCons)
                        End If
                    Else
                        Dim Diff As Integer = DateDiff(DateInterval.Day, c.Giorno, Now.Date)
                        If Diff > ggAltroCorriere Then
                            mgr.AvanzaStatoConsegna(c, enStatoConsegna.Consegnata)
                            IdConsChius.Add(c.IdCons)
                        End If
                    End If
                Next

            End Using

            MessageBox.Show(" - Completate " & IdConsChius.Count & " consegne")
            LogMe("***COMPLETAMENTO CONSEGNE TERMINATO***")
        Catch ex As Exception
            LogMe("SORGENTE: Completamento Consegne(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
        End Try
    End Sub


    Private Function MontaCommessa(C As Commessa) As String

        Dim PathFinale As String = String.Empty

        If C.ListaOrdini.Count = 1 Then
            Using O As Ordine = C.ListaOrdini()(0)
                Dim CountSorgenti As Integer = O.ListaSorgenti.Count

                Dim ListaSorgenti As New List(Of FileSorgente)

                If CountSorgenti = 1 Then
                    ListaSorgenti.Add(O.ListaSorgenti(0))
                ElseIf CountSorgenti = 2 Then
                    ListaSorgenti.Add(O.ListaSorgenti(0))
                    ListaSorgenti.Add(O.ListaSorgenti(1))
                Else
                    'qui poi devo vedere quante pagine vuote aggiungere


                End If
                Dim F As New Formato
                F.Read(C.IdFormato)

                If ListaSorgenti.Count Then
                    PathFinale = MontaPDF(ListaSorgenti, F)
                End If


            End Using
        End If

        Return PathFinale

    End Function




    Private Function MontaPDF(L As List(Of FileSorgente), F As Formato) As String

        Dim Ris As String = String.Empty

        Dim PathPDFOut As String = "C:\temp\temp.pdf"
        'Dim PathPDFIn As String = "C:\temp\biglietto.pdf"

        Dim DocWidth As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(F.LarghezzaMM)
        Dim DocHeight As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(F.AltezzaMM)

        'PRENDO IL PRIMO SORGENTE PER CALCOLARE LE DIMNESIONI E L'ORIENTAMENTO DEL DOCUMENTO
        'SE LO METTO  
        Dim FirstS As FileSorgente = L(0)

        Dim DimensioniSorgente As iTextSharp.text.Rectangle = FormerLib.FormerHelper.PDF.GetDimensioniPaginaInPointItext(FirstS.FilePath)
        'Dim DimensioniSorgente As iTextSharp.text.Rectangle = FormerLib.FormerHelper.PDF.GetDimensioniPaginaInPointItext(S.FilePath)

        Dim QuanteColonne As Integer = 0
        Dim QuanteRighe As Integer = 0

        Dim QuanteColonneR As Integer = 0
        Dim QuanteRigheR As Integer = 0

        Dim Colonne As Integer = 0
        Dim Righe As Integer = 0
        Dim CelleTotali As Integer = 0
        Dim LarghezzaColonna As Single = DimensioniSorgente.Width

        QuanteColonne = Math.Floor(DocWidth / DimensioniSorgente.Width)
        QuanteRighe = Math.Floor(DocHeight / DimensioniSorgente.Height)

        Dim totCelle As Integer = 0

        Try
            totCelle = QuanteColonne * QuanteRighe
        Catch

        End Try

        QuanteColonneR = Math.Floor(DocWidth / DimensioniSorgente.Height)
        QuanteRigheR = Math.Floor(DocHeight / DimensioniSorgente.Width)

        Dim totCelleR As Integer = 0
        Dim RuotaContenuto As Boolean = False

        Try
            totCelleR = QuanteColonneR * QuanteRigheR
        Catch

        End Try

        If totCelleR > totCelle Then
            'qui devo ruotare le cose dentro 
            Colonne = QuanteRigheR
            Righe = QuanteColonneR
            CelleTotali = totCelleR
            RuotaContenuto = True
            'LarghezzaColonna = DimensioniSorgente.Height
        Else
            Colonne = QuanteColonne
            Righe = QuanteRighe
            CelleTotali = totCelle
            'LarghezzaColonna = DimensioniSorgente.Width
        End If

        Dim dimensioniDocumento As iTextSharp.text.Rectangle = Nothing

        If RuotaContenuto Then
            dimensioniDocumento = New iTextSharp.text.Rectangle(DocHeight, DocWidth)

        Else
            dimensioniDocumento = New iTextSharp.text.Rectangle(DocWidth, DocHeight)
        End If

        For Each S As FileSorgente In L



            Dim t As iTextSharp.text.pdf.PdfPTable = New text.pdf.PdfPTable(Colonne)
            Dim larghezza As Single() = New Single(Colonne - 1) {}

            For i = 0 To UBound(larghezza)
                larghezza(i) = LarghezzaColonna
            Next

            Dim DifferenzaInTesta As Single = 0
            Dim SpazioTraColonnePoint As Single = 10

            DifferenzaInTesta = (dimensioniDocumento.Height - (Righe * DimensioniSorgente.Height)) / 2

            '= DifferenzaInTesta
            Dim tHeader As New iTextSharp.text.pdf.PdfPTable(1)
            tHeader.WidthPercentage = 100
            Dim cHeader As New iTextSharp.text.pdf.PdfPCell
            cHeader.FixedHeight = DifferenzaInTesta
            cHeader.Border = 0

            cHeader.AddElement(New iTextSharp.text.Phrase(""))
            tHeader.AddCell(cHeader)

            Dim PdfDoc As iTextSharp.text.Document = New iTextSharp.text.Document(dimensioniDocumento, 0, 0, 0, 0)
            Dim w As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(PdfDoc, New FileStream(PathPDFOut, FileMode.Append))
            PdfDoc.Open()

            PdfDoc.Add(tHeader)
            't.TotalWidth = (LarghezzaColonna * Colonne)
            't.WidthPercentage = 1
            t.SetTotalWidth(larghezza)

            t.LockedWidth = True
            't.WidthPercentage = 100

            Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing

            Using r As New iTextSharp.text.pdf.PdfReader(S.FilePath) 'pathfilein
                page = w.GetImportedPage(r, 1)

                Dim contenuto As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(page)
                Dim cella As New iTextSharp.text.pdf.PdfPCell()
                cella.Top = 0
                cella.Padding = 0

                cella.Border = 0
                cella.FixedHeight = contenuto.Height

                'cella.Width = contenuto.Width
                cella.AddElement(contenuto)

                't.setRotation(-page.getRotation())

                For i As Integer = 1 To CelleTotali
                    t.AddCell(cella)
                Next


                't.AddCell(cella)

                PdfDoc.Add(t)


                'Dim pg As iTextSharp.text.pdf.PdfPage = PdfDoc.get

                'DISEGNARE LINEA DIRETTA PER I CROCINI
                'Dim canvas As iTextSharp.text.pdf.PdfContentByte = w.DirectContent
                'canvas.SetRGBColorStroke(255, 0, 0)
                'canvas.MoveTo(0, 0)
                'canvas.LineTo(100, 100)

                'canvas.Stroke()

                PdfDoc.Close()
                PdfDoc.Dispose()
            End Using

        Next



        Ris = PathPDFOut


        Return Ris

    End Function


    Private MonitoraggioHotFolderStampaAttivo As Boolean = False
    Private Sub MonitoraggioHotFolderStampa()

        If MonitoraggioHotFolderStampaAttivo = False Then
            LogMe("AVVIATO MONITORAGGIO HOTFOLDER STAMPA")

            Try
                If FormerHelper.Web.IsPingable(FormerConfig.FConfiguration.Refine.Server) Then
                    Dim wfStampa As New FileSystemWatcher
                    wfStampa.Path = FormerPath.PathFattureTemp
                    wfStampa.NotifyFilter = IO.NotifyFilters.DirectoryName
                    wfStampa.NotifyFilter = wfStampa.NotifyFilter Or
                IO.NotifyFilters.FileName
                    wfStampa.NotifyFilter = wfStampa.NotifyFilter Or
                IO.NotifyFilters.Attributes

                    AddHandler wfStampa.Created, AddressOf PrintFatturaEvent

                    wfStampa.EnableRaisingEvents = True

                    MonitoraggioHotFolderStampaAttivo = True

                Else
                    LogMe("ERRORE: Il server HOTFOLDER STAMPA non è raggiungibile")
                End If

            Catch ex As Exception
                LogMe("ERRORE: Si è verificato un errore nel monitoraggio dei folder STAMPA",, ex)
            End Try
        End If


    End Sub

    Private Sub PrintFatturaEvent(ByVal source As Object,
            ByVal e As System.IO.FileSystemEventArgs)
        'l'evento si scatena al momento in cui un file viene creato nella cartella TEMP DELLA STAMPA FATTURE

        'vedo se compatibile con una  regular expression

        Dim PatternReg As String = "^[0-9]{1}_[0-9]{4}-[0-9]{1,10}.pdf$"

        Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

        If Re.IsMatch(e.Name) Then
            'qui è una fattura da spostare 
            Dim IdAzienda As Integer = e.Name.Substring(0, 1)
            Dim NuovoNome As String = FormerConfig.FormerPath.PathFatture(IdAzienda)
            Dim NuovoNomeFile As String = NuovoNome & e.Name.Substring(2)

            Try
                File.Copy(e.FullPath, NuovoNomeFile)

                Try
                    File.Delete(e.FullPath)
                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TestFatturaXML()

        Using r As New Ricavo
            r.Read(42905)
            MgrFattureFE.RicavoToXML(r, "C:\temp\test.xml")
        End Using

    End Sub

    Private Sub CleanCSS()

        Dim PathCss As String = "c:\lavoro\Former\Source\main\FormerWeb\styles\css\site.css"

        Dim ClassCollection As New List(Of String)

        Dim buffer As String = String.Empty

        Using r As New StreamReader(PathCss)
            buffer = r.ReadToEnd
        End Using

        Dim Righe As String() = buffer.Split(ControlChars.NewLine)

        For Each riga As String In Righe
            If riga.Trim.StartsWith(".") Then

                Dim PrimoSpazio As Integer = riga.IndexOf(" ")
                Dim PrimoDuePunti As Integer = riga.IndexOf(":")
                Dim Fine As Integer = 0
                If PrimoSpazio <> -1 Then
                    Fine = PrimoSpazio
                    If PrimoDuePunti <> -1 Then
                        If PrimoDuePunti < PrimoSpazio Then
                            Fine = PrimoDuePunti
                        End If
                    End If
                End If

                If Fine <> 0 Then
                    Dim classe As String = String.Empty

                    classe = riga.Trim.Substring(1, Fine - 1).Trim

                    If ClassCollection.FindAll(Function(x) x = classe).Count = 0 Then
                        ClassCollection.Add(classe)
                    End If
                End If

            End If
        Next

        'Dim listaFile As New List(Of String)

        Dim ClassCollectionNonTrovate As New List(Of String)

        Dim StartPath As String = "c:\lavoro\Former\Source\main\FormerWeb"

        'RiempiListaFile(listaFile, StartPath)

        For Each singClass In ClassCollection

            If TrovatoTestoInFolder(singClass, StartPath) = False Then
                ClassCollectionNonTrovate.Add(singClass)
            End If

        Next

        MessageBox.Show("Esistenti " & ClassCollection.Count & " - Non trovate " & ClassCollectionNonTrovate.Count)

    End Sub

    Private Function RiempiListaFile(ByRef l As List(Of String),
    Folder As String)

        Dim d As New DirectoryInfo(Folder)

        For Each file In d.GetFiles
            If file.Name.ToLower.EndsWith(".vb") OrElse
file.Name.ToLower.EndsWith(".aspx") OrElse
file.Name.ToLower.EndsWith(".ascx") OrElse
file.Name.ToLower.EndsWith(".master") Then
                Using r As New StreamReader(file.FullName)
                    Dim buffer As String = r.ReadToEnd
                    l.Add(buffer)
                End Using
            End If
        Next


        For Each singD As DirectoryInfo In d.GetDirectories()
            RiempiListaFile(l, Folder)
        Next


    End Function

    Private Function TrovatoTestoInFolder(TextToSearch As String,
        Folder As String) As Boolean
        Dim ris As Boolean = False
        Dim d As New DirectoryInfo(Folder)

        For Each file In d.GetFiles
            If file.Name.ToLower.EndsWith(".vb") OrElse
file.Name.ToLower.EndsWith(".aspx") OrElse
file.Name.ToLower.EndsWith(".ascx") OrElse
file.Name.ToLower.EndsWith(".master") Then
                Using r As New StreamReader(file.FullName)
                    Dim buffer As String = r.ReadToEnd
                    If buffer.ToLower.IndexOf(TextToSearch) <> -1 Then
                        ris = True
                        Exit For
                    End If
                End Using
            End If
        Next

        If ris = False Then
            For Each singD As DirectoryInfo In d.GetDirectories()
                ris = TrovatoTestoInFolder(TextToSearch, singD.FullName)
                If ris Then Exit For
            Next
        End If

        Return ris

    End Function


    Private Sub pulisciCartellabkp()

        Dim PathStart As String = "y:\commesse"
        Dim PathEnd As String = "w:\commesse"
        Dim DataRif As New Date(2019, 1, 1)

        Dim d As New DirectoryInfo(PathStart)
        Dim TotaleFileCancellati As Integer = 0
        Dim TotaleErroriCancellazione As Integer = 0

        For Each folder In d.GetDirectories

            Application.DoEvents()

            For Each file In folder.GetFiles

                Dim NomeFileDest As String = file.FullName.ToLower.Replace(PathStart, PathEnd)

                Dim DiffDataRif As Integer = DateDiff(DateInterval.Day, DataRif, file.LastWriteTime)

                If DiffDataRif < 0 Then
                    If System.IO.File.Exists(NomeFileDest) = False Then
                        LogMe("Trovato File da cancellare: " & file.FullName)
                        'qui va cancellato
                        Try
                            System.IO.File.Delete(file.FullName)
                            LogMe("DELETED")
                            TotaleFileCancellati += 1
                        Catch ex As Exception
                            TotaleErroriCancellazione += 1
                            LogMe("ERROR: " & ex.Message)
                        End Try
                    End If
                End If

            Next

        Next

        LogMe("CANCELLATI : " & TotaleFileCancellati)
        LogMe("ERRORE : " & TotaleErroriCancellazione)



    End Sub

    Private Sub ristrutturaNomiImgLavorazione()
        Dim Ok As Integer = 0
        Dim Errori As Integer = 0
        Dim l As List(Of Lavorazione) = Nothing
        Using mgr As New LavorazioniDAO
            l = mgr.GetAll()
            For Each item As Lavorazione In l
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim OldPath As String = item.ImgRif
                    Dim OldName As String = String.Empty
                    If OldPath.Length AndAlso File.Exists(OldPath.ToLower.Replace("z:\", "w:\")) Then
                        Dim FirstChar As String = String.Empty
                        OldName = FormerLib.FormerHelper.File.EstraiNomeFile(OldPath)

                        FirstChar = OldName.Substring(0, 1)

                        If IsNumeric(FirstChar) Then
                            Dim estensione As String = item.ImgRif.Substring(item.ImgRif.Length - 4)
                            Dim NewName As String = FormerLib.FormerHelper.File.GetNomeFileTemp(estensione,, item.Descrizione)
                            Dim NewPath As String = FormerPath.PathListinoImg & NewName

                            Try
                                tb.TransactionBegin()
                                item.ImgRif = NewPath
                                FileIO.FileSystem.RenameFile(OldPath.ToLower.Replace("z:\", "w:\"), NewName)
                                item.Save()
                                tb.TransactionCommit()
                                Ok += 1
                            Catch ex As Exception
                                Errori += 1
                                tb.TransactionRollBack()
                            End Try
                        End If

                    End If
                End Using
            Next
        End Using

        If Errori Then
            MessageBox.Show("LAVORAZIONE OK:" & Ok & " - Errori:" & Errori)
        End If

    End Sub

    Private Sub ristrutturaNomiImgTC()
        Dim Ok As Integer = 0
        Dim Errori As Integer = 0
        Dim l As List(Of TipoCarta) = Nothing
        Using mgr As New TipiCartaDAO
            l = mgr.GetAll()
            For Each item As TipoCarta In l
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim OldPath As String = item.ImgRif
                    Dim OldName As String = String.Empty
                    If OldPath.Length AndAlso File.Exists(OldPath.ToLower.Replace("z:\", "w:\")) Then
                        Dim FirstChar As String = String.Empty
                        OldName = FormerLib.FormerHelper.File.EstraiNomeFile(OldPath)

                        FirstChar = OldName.Substring(0, 1)

                        If IsNumeric(FirstChar) Then
                            Dim estensione As String = item.ImgRif.Substring(item.ImgRif.Length - 4)
                            Dim NewName As String = FormerLib.FormerHelper.File.GetNomeFileTemp(estensione,, item.Tipologia)
                            Dim NewPath As String = FormerPath.PathListinoImg & NewName

                            Try
                                tb.TransactionBegin()
                                item.ImgRif = NewPath
                                FileIO.FileSystem.RenameFile(OldPath.ToLower.Replace("z:\", "w:\"), NewName)
                                item.Save()
                                tb.TransactionCommit()
                                Ok += 1
                            Catch ex As Exception
                                Errori += 1
                                tb.TransactionRollBack()
                            End Try
                        End If

                    End If
                End Using
            Next
        End Using

        If Errori Then
            MessageBox.Show("TC OK:" & Ok & " - Errori:" & Errori)
        End If

    End Sub
    Private Sub ristrutturaNomiImgFP()
        Dim Ok As Integer = 0
        Dim Errori As Integer = 0
        Dim l As List(Of FormatoProdotto) = Nothing
        Using mgr As New FormatiProdottoDAO
            l = mgr.GetAll()
            For Each item As FormatoProdotto In l
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim OldPath As String = item.ImgRif
                    Dim OldName As String = String.Empty
                    If OldPath.Length AndAlso File.Exists(OldPath.ToLower.Replace("z:\", "w:\")) Then
                        Dim FirstChar As String = String.Empty
                        OldName = FormerLib.FormerHelper.File.EstraiNomeFile(OldPath)

                        FirstChar = OldName.Substring(0, 1)

                        If IsNumeric(FirstChar) Then
                            Dim estensione As String = item.ImgRif.Substring(item.ImgRif.Length - 4)
                            Dim NewName As String = FormerLib.FormerHelper.File.GetNomeFileTemp(estensione,, item.Formato)
                            Dim NewPath As String = FormerPath.PathListinoImg & NewName

                            Try
                                tb.TransactionBegin()
                                item.ImgRif = NewPath
                                FileIO.FileSystem.RenameFile(OldPath.ToLower.Replace("z:\", "w:\"), NewName)
                                item.Save()
                                tb.TransactionCommit()
                                Ok += 1
                            Catch ex As Exception
                                Errori += 1
                                tb.TransactionRollBack()
                            End Try
                        End If

                    End If
                End Using
            Next
        End Using

        If Errori Then
            MessageBox.Show("FP OK:" & Ok & " - Errori:" & Errori)
        End If

    End Sub

    Private Sub ristrutturaNomiImgCatFormato()
        Dim Ok As Integer = 0
        Dim Errori As Integer = 0
        Dim l As List(Of CatFormatoProdotto) = Nothing
        Using mgr As New CatFormatoProdottoDAO
            l = mgr.GetAll()
            For Each item As CatFormatoProdotto In l
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim OldPath As String = item.ImgRif
                    Dim OldName As String = String.Empty
                    If OldPath.Length AndAlso File.Exists(OldPath.ToLower.Replace("z:\", "w:\")) Then
                        Dim FirstChar As String = String.Empty
                        OldName = FormerLib.FormerHelper.File.EstraiNomeFile(OldPath)

                        FirstChar = OldName.Substring(0, 1)

                        If IsNumeric(FirstChar) Then
                            Dim estensione As String = item.ImgRif.Substring(item.ImgRif.Length - 4)
                            Dim NewName As String = FormerLib.FormerHelper.File.GetNomeFileTemp(estensione,, item.Nome)
                            Dim NewPath As String = FormerPath.PathListinoImg & NewName

                            Try
                                tb.TransactionBegin()
                                item.ImgRif = NewPath
                                FileIO.FileSystem.RenameFile(OldPath.ToLower.Replace("z:\", "w:\"), NewName)
                                item.Save()
                                tb.TransactionCommit()
                                Ok += 1
                            Catch ex As Exception
                                Errori += 1
                                tb.TransactionRollBack()
                            End Try
                        End If

                    End If
                End Using
            Next
        End Using

        If Errori Then
            MessageBox.Show("CATFORMATO OK:" & Ok & " - Errori:" & Errori)
        End If

    End Sub
    Private Sub ristrutturaNomiImgPreventivazione()
        Dim Ok As Integer = 0
        Dim Errori As Integer = 0
        Dim l As List(Of Preventivazione) = Nothing
        Using mgr As New PreventivazioniDAO
            l = mgr.GetAll()
            For Each item As Preventivazione In l
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim OldPath As String = item.ImgRif
                    Dim OldName As String = String.Empty
                    If OldPath.Length AndAlso File.Exists(OldPath.ToLower.Replace("z:\", "w:\")) Then
                        Dim FirstChar As String = String.Empty
                        OldName = FormerLib.FormerHelper.File.EstraiNomeFile(OldPath)

                        FirstChar = OldName.Substring(0, 1)

                        If IsNumeric(FirstChar) Then
                            Dim estensione As String = item.ImgRif.Substring(item.ImgRif.Length - 4)
                            Dim NewName As String = FormerLib.FormerHelper.File.GetNomeFileTemp(estensione,, item.Descrizione)
                            Dim NewPath As String = FormerPath.PathListinoImg & NewName

                            Try
                                tb.TransactionBegin()
                                item.ImgRif = NewPath
                                FileIO.FileSystem.RenameFile(OldPath.ToLower.Replace("z:\", "w:\"), NewName)
                                item.Save()
                                tb.TransactionCommit()
                                Ok += 1
                            Catch ex As Exception
                                Errori += 1
                                tb.TransactionRollBack()
                            End Try
                        End If

                    End If
                End Using
            Next
        End Using

        If Errori Then
            MessageBox.Show("PREV OK:" & Ok & " - Errori:" & Errori)
        End If

    End Sub

    Private Sub ImportaFatturaElettronica(PathXML As String)

        Dim f As FatturaElettronica
        Dim Counter As Integer, CounterKo As Integer
        If PathXML.ToLower.EndsWith("xml") = False Then
            PathXML = MgrFattureFE.ReadXmlSigned(PathXML, False)
        End If

        f = MgrFattureFE.GetFatturaFromXML(PathXML)

        Dim PathTemp As String = String.Empty
        PathTemp = FormerConfig.FormerPath.PathTempLocale
        FormerLib.FormerHelper.File.CreateLongPath(PathTemp)

        PathTemp &= FormerLib.FormerHelper.File.GetNomeFileTemp(".xml")

        MgrFattureFE.FatturaElettronicaToXML(f, PathTemp)

        Dim RisSalvataggio As RisSalvaCostoDaFatturaElettronica = MgrFattureFE.SalvaCostoDaFatturaElettronica(f, PathTemp)

        If RisSalvataggio.DaScartare Then
            CounterKo += 1
        Else
            Counter += 1
        End If

    End Sub

    Private Function ComparerMovMagaz(ByVal x As MovimentoMagazzino, ByVal y As MovimentoMagazzino) As Integer
        Dim result As Integer = x.FornitoreStr.CompareTo(y.FornitoreStr)

        If result = 0 Then
            result = x.RisorsaStr.CompareTo(y.RisorsaStr)
        End If

        Return result
    End Function

    Private Sub CsvMagazzino()

        Using mgr As New MagazzinoDAO
            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                            New LUNA.LunaSearchParameter("Year(DataMov)", 2019))

            l.Sort(AddressOf ComparerMovMagaz)

            Dim Buffer As String = String.Empty

            Dim IdVoceOld As Integer = 0
            Dim Riga As String = String.Empty
            Dim TotQta As Single = 0
            Dim TotEuro As Decimal = 0
            Dim GiacenzaAttuale As Single = 0
            Dim IdVoceAttuale As Integer = 0
            Buffer &= "FORNITORE;RISORSA;TOTEURO;TOTQTA;GIACENZA;" & ControlChars.NewLine
            For Each Voce In l
                IdVoceAttuale = Voce.IdRis
                If IdVoceOld <> IdVoceAttuale Then
                    IdVoceOld = IdVoceAttuale

                    'scrivo la riga precedente
                    If Riga.Length Then

                        Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & "€;" & TotQta & ";" & GiacenzaAttuale & ";" & ControlChars.NewLine
                        Buffer &= Riga
                    End If
                    TotEuro = Voce.Prezzo
                    TotQta = Voce.Qta
                    GiacenzaAttuale = Voce.Risorsa.Giacenza
                    Riga = Voce.FornitoreStr & ";" & Voce.RisorsaStr & ";"
                Else
                    TotEuro += Voce.Prezzo
                    TotQta += Voce.Qta
                End If
            Next

            If IdVoceOld = IdVoceAttuale Then
                'chiudo l'ultima 
                If Riga.Length Then

                    Riga &= FormerHelper.Stringhe.FormattaPrezzo(TotEuro) & "€;" & TotQta & ";" & GiacenzaAttuale & ";" & ControlChars.NewLine
                    Buffer &= Riga
                End If
            End If



            Using w As New StreamWriter("c:\temp\magazzino.csv")
                w.Write(Buffer)
            End Using


        End Using

    End Sub

    Private Sub AdjustQta()

        Using mgr As New CostiDAO
            Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchParameter("Year(datacosto)", 2019, ">="),
                New LUNA.LunaSearchParameter(LFM.Costo.Tipo, "(0,2)", "NOT In"))

            For Each costo In l

                If costo.DocXML.Length Then

                    Dim f As FatturaElettronica = MgrFattureFE.GetFatturaFromXMLBuffer(costo.DocXML)

                    For Each voce In costo.ListaVociFattura

                        For Each riga In f.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee

                            Dim Trovata As Boolean = True
                            If voce.Codice.Length Then
                                If riga.CodiceArticolo Is Nothing Then
                                    Trovata = False
                                Else
                                    If riga.CodiceArticolo.CodiceValore <> voce.Codice Then
                                        Trovata = False
                                    End If
                                End If
                            End If

                            If Trovata Then
                                If riga.Descrizione <> voce.Descrizione Then
                                    Trovata = False
                                End If
                            End If

                            If Trovata Then
                                If voce.Totale = 0 Then
                                    If Not riga.PrezzoTotale Is Nothing Then
                                        If MgrFattureFE.GetDecimalFromFormatoFE(riga.PrezzoTotale) <> 0 Then
                                            Trovata = False
                                        End If
                                    End If
                                Else
                                    If Not riga.PrezzoTotale Is Nothing Then
                                        If MgrFattureFE.GetDecimalFromFormatoFE(riga.PrezzoTotale) <> voce.Totale Then
                                            Trovata = False
                                        End If
                                    Else
                                        Trovata = False
                                    End If
                                End If
                            End If

                            If Trovata Then
                                'qui aggiorno e esco dal ciclo
                                If Not riga.Quantita Is Nothing Then
                                    If voce.Qta <> MgrFattureFE.GetDecimalFromFormatoFE(riga.Quantita) Then
                                        voce.Qta = MgrFattureFE.GetDecimalFromFormatoFE(riga.Quantita)
                                        voce.Save()
                                    End If
                                End If
                                Exit For
                            End If

                        Next
                    Next
                End If
            Next


        End Using


    End Sub

    Private Sub RicreaRigheMancantiCosto()

        Using mgr As New CostiDAO
            Dim l As List(Of Costo) = mgr.GetBySQL("select * from t_contabcosti where year(datacosto) >= 2019 and tipo in(1) and idcosto not in (select distinct idcosto from t_vocicosto)")


            For Each voceF In l

                If voceF.DocXML.Length Then

                    Dim f As FatturaElettronica = MgrFattureFE.GetFatturaFromXMLBuffer(voceF.DocXML)

                    If Not f.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee Is Nothing Then
                        For Each Linea In f.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
                            Dim IdCostoLinea As Integer = voceF.IdCosto

                            Using Voce As New VoceCosto
                                Voce.IdCosto = IdCostoLinea
                                If Not Linea.CodiceArticolo Is Nothing Then
                                    Voce.Codice = Linea.CodiceArticolo.CodiceValore
                                End If
                                Voce.Descrizione = Linea.Descrizione
                                If Not Linea.Quantita Is Nothing AndAlso Linea.Quantita.Length > 0 Then
                                    Voce.Qta = MgrFattureFE.GetDecimalFromFormatoFE(Linea.Quantita)
                                Else
                                    Voce.Qta = 1
                                End If
                                If Not Linea.UnitaMisura Is Nothing AndAlso Linea.UnitaMisura.Length > 0 Then
                                    Voce.Um = Linea.UnitaMisura
                                End If
                                If Not Linea.TipoCessionePrestazione Is Nothing AndAlso Linea.TipoCessionePrestazione.Length > 0 Then
                                    Voce.TipoCessionePrestazione = Linea.TipoCessionePrestazione
                                End If

                                Voce.PrezzoUnit = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoUnitario)
                                Voce.Totale = MgrFattureFE.GetDecimalFromFormatoFE(Linea.PrezzoTotale)

                                Voce.AliquotaIva = MgrFattureFE.GetDecimalFromFormatoFE(Linea.AliquotaIVA)
                                Voce.idCat = voceF.IdCat
                                Voce.Save()
                            End Using
                        Next
                    End If


                End If

            Next


        End Using
    End Sub

    Private Sub SincronizzaFotoHD()
        Dim D As New DirectoryInfo(FormerPath.PathListinoFoto)
        'qui devo ciclare per ogni cartella

        Dim Ftp As New FTPclient("ftp.tipografiaformer.it",
"1246360@aruba.it",
"tghi9maeqa")

        For Each DiNt As DirectoryInfo In D.GetDirectories()
            Dim PathRemotoDir As String = "tipografiaformer.it/listino/foto/" & DiNt.Name
            Try
                Dim x As FTPdirectory = Ftp.ListDirectoryDetail("/" & PathRemotoDir)

                For Each ss As FTPfileInfo In x.GetFiles

                    Dim PathInterno As String = FormerPath.PathListinoFoto & DiNt.Name & "\" & ss.Filename

                    If File.Exists(PathInterno) = False Then
                        Try
                            Ftp.FtpDelete(ss.FullName)
                        Catch ex As Exception

                        End Try
                    End If

                Next
            Catch ex As Exception

            End Try

        Next
    End Sub

    'Private Sub CheckResa()
    '    Dim Buffer As String = String.Empty

    '    Using mgr As New ResaDAO
    '        Dim l As List(Of Resa) = mgr.GetAll
    '        For Each voce In l
    '            If voce.IdFormCarta AndAlso voce.IdFormato Then
    '                Dim Fm As New Formato
    '                Dim Fc As New FormatoCarta

    '                Fc.Read(voce.IdFormCarta) 'a4
    '                Fm.Read(voce.IdFormato) '44x64
    '                If Fm.IdFormato <> 0 AndAlso Fc.IdFormCarta <> 0 Then
    '                    Dim Resa As ResaFPsuFM = MgrResa.GetResa(Fm, Fc)

    '                    If Resa.Resa <> voce.Resa Then
    '                        Buffer &= voce.IDFormatoResa & " - " & Fc.LatoLungoMM & "mm x " & Fc.LatoCortoMM & "mm su " & Fm.LatoLungoMM & "mm x " & Fm.LatoCortoMM & "mm - salvata " & voce.Resa & " calcolata " & Resa.Resa & ControlChars.NewLine
    '                    End If
    '                Else
    '                    Buffer &= voce.IDFormatoResa & " NON FUNZIONANTE" & ControlChars.NewLine
    '                End If

    '            End If
    '        Next
    '    End Using

    '    txtDebug.Text = Buffer

    '    '        MessageBox.Show("Errori riscontrati: " & Buffer)
    'End Sub

    Private Sub CreaListiniBaseSource()

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0))
            For Each singLb In l
                If singLb.ListiniBaseFigli.Count = 0 Then

                    Dim Lb As ListinoBase = Nothing

                    Lb = singLb.Clone
                    Lb.CaricaLavorazioni()
                    Lb.IdListinoBase = 0
                    'singLb.CaricaLavorazioni()
                    Lb.Save()
                    'qui vado a ricreare questo LB come figlio di quell'altro
                    singLb.IdListinoBaseSource = Lb.IdListinoBase
                    singLb.Save()

                    For Each catvirtuale In singLb.CollegamentoSuCatVirtuale
                        'le vado a spostare sul padre
                        catvirtuale.IdListinoBase = Lb.IdListinoBase
                        catvirtuale.Save()
                    Next

                    For Each PreventivazioneLnk In singLb.LinkAPreventivazione
                        'le vado a spostare sul padre
                        PreventivazioneLnk.IdListinoBase = Lb.IdListinoBase
                        PreventivazioneLnk.Save()
                    Next

                    'gestire listini base linkati

                End If

            Next
        End Using

    End Sub

    Private Sub CopiaFotoHD()
        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0))
            For Each singLb In l

                For Each lb In singLb.ListiniBaseFigli
                    Dim pathStart As String = FormerPath.PathListinoFoto & lb.IdListinoBase
                    If Directory.Exists(pathStart) Then
                        Dim d As New DirectoryInfo(pathStart)
                        For Each f In d.GetFiles
                            If f.Extension.ToLower = ".jpg" OrElse f.Extension.ToLower = ".png" Then
                                'file da copiare
                                Dim pathEnd As String = FormerPath.PathListinoFoto & singLb.IdListinoBase
                                FormerHelper.File.CreateLongPath(pathEnd & "\")
                                If File.Exists(pathEnd & "\" & f.Name) = False Then
                                    File.Copy(pathStart & "\" & f.Name, pathEnd & "\" & f.Name)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
        End Using
    End Sub
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        For Each codec As ImageCodecInfo In codecs

            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next

        Return Nothing
    End Function
    Private Function TrasformaPNGtoJPG(PathPNG As String) As String

        Dim Ris As String = PathPNG.ToLower.Replace(".png", ".jpg") 'String.Empty

        Dim OI = Image.FromFile(PathPNG)
        'Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)

        Dim gRif As Graphics = Nothing
        Dim ErroreImgOrigine As Boolean = False
        Try
            gRif = Graphics.FromImage(OI)
        Catch ex As Exception
            ErroreImgOrigine = True
        End Try

        If ErroreImgOrigine Then
            'qui provo a risalvarla in un formato diverso 

            Dim EditableImg As Bitmap = New Bitmap(OI)
            Dim PathTemp As String = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".png")
            EditableImg.Save(PathTemp)


            'Dim enc As Imaging.ImageCodecInfo = GetEncoder(ImageFormat.Png)
            'Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.ColorDepth
            'Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

            'Dim myEncoderParameter As EncoderParameter = New EncoderParameter(myEncoder, 90)
            'myEncoderParameters.Param(0) = myEncoderParameter
            'OI.Save(PathTemp, enc, myEncoderParameters)

            OI = Image.FromFile(PathTemp)
            gRif = Graphics.FromImage(OI)
        End If

        Using grp = gRif
            'grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            'OriginalImage.Dispose()

            Dim enc As Imaging.ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
            Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
            Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

            Dim myEncoderParameter As EncoderParameter = New EncoderParameter(myEncoder, 90)
            myEncoderParameters.Param(0) = myEncoderParameter

            OI.Save(Ris, enc, myEncoderParameters)
        End Using
        Return Ris
    End Function

    Private Sub SistemaImgListino()

        'RipulisciPath("T_Preventivazione") "imgRif" OK
        'RipulisciPath("T_Preventivazione", "imgSito") OK
        'RipulisciPath("T_ListinoBase", "imgSito") OK
        'RipulisciPath("Td_FormatoProdotto") OK
        'RipulisciPath("Td_FormatoProdotto", "PdfTemplate")
        'RipulisciPath("Td_FormatoProdotto", "PdfTemplate3D")
        'RipulisciPath("Td_TipoCarta") OK
        'RipulisciPath("Td_ColoriStampa") OK
        'RipulisciPath("T_lavori") OK
        'RipulisciPath("T_TipoFustella") OK
        'RipulisciPath("Td_CatFustelle") OK
        'RipulisciPath("TD_CatLav", "FileLavNonSelezionata")
        'RipulisciPath("T_Lavori", "ImgZoom") OK
        'RipulisciPath("T_TipoFustella", "TemplatePDF")
        'RipulisciPath("Td_CatFormatoProdotto")
        'RipulisciPath("T_Macchinari")
        'RipulisciPath("T_Macchinari", "imgBig")

        Dim TotErrori As Integer = 0
        Dim TotErroriDel As Integer = 0

        Using mgr As New PreventivazioniDAO
            Dim l As List(Of Preventivazione) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = item.ImgRif.ToLower
                Dim PathFileOut As String = String.Empty

                PathFileIn = PathFileIn.Replace("z:\", "w:\")

                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                PathFileIn = item.ImgSito
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgSito = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgSito
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgSito = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

                'qui oltre a fare le img devo vedere le fotohd
                Dim PathFotoHd As String = FormerPath.PathListinoFoto & item.IdListinoBase

                If Directory.Exists(PathFotoHd) = False Then
                    FormerLib.FormerHelper.File.CreateLongPath(PathFotoHd)
                    '            Directory.CreateDirectory(PathFotoHd)
                End If

                If FormerDebug.DebugAttivo Then
                    PathFotoHd = PathFotoHd.ToLower.Replace("z:\", "w:\")
                End If
                Try
                    Dim dHD As New DirectoryInfo(PathFotoHd)
                    For Each fileImg In dHD.GetFiles
                        If fileImg.Extension.ToLower = ".png" Then

                            Try
                                TrasformaPNGtoJPG(fileImg.FullName)

                            Catch ex As Exception
                                TotErrori += 1
                            End Try

                            Try
                                IO.File.Delete(fileImg.FullName)

                            Catch ex As Exception
                                TotErroriDel += 1
                            End Try

                        End If
                    Next
                Catch ex As Exception

                End Try

            Next
        End Using

        Using mgr As New FormatiProdottoDAO
            Dim l As List(Of FormatoProdotto) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New TipiCartaDAO
            Dim l As List(Of TipoCarta) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New ColoriStampaDAO
            Dim l As List(Of ColoreStampa) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.imgrif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.imgrif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New LavorazioniDAO
            Dim l As List(Of Lavorazione) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                PathFileIn = item.ImgZoom
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgZoom = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New TipoFustelleDAO
            Dim l As List(Of TipoFustella) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using

        Using mgr As New CategorieFustelleDAO

            Dim l As List(Of CategoriaFustella) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using


        Using mgr As New CatFormatoProdottoDAO

            Dim l As List(Of CategoriaFustella) = mgr.GetAll

            For Each item In l
                Dim PathFileIn As String = String.Empty
                Dim PathFileOut As String = String.Empty

                PathFileIn = item.ImgRif
                Try
                    If PathFileIn.EndsWith(".png") AndAlso IO.File.Exists(PathFileIn) Then
                        PathFileOut = TrasformaPNGtoJPG(PathFileIn)
                    End If
                Catch ex As Exception
                    TotErrori += 1
                End Try

                If PathFileOut.Length Then
                    item.ImgRif = PathFileOut.Replace("w:\", "z:\")
                End If

                If item.IsChanged Then
                    item.Save()
                End If

            Next

        End Using


        MessageBox.Show("errori: " & TotErrori & " errori del: " & TotErroriDel)



    End Sub

    Private Sub ReportPrimaNota(MeseScelto As Integer, AnnoScelto As Integer)


        Dim sql As String = "select * from ("
        sql &= " Select p.* from t_pagamenti p inner join t_contabricavi r on p.idfat = r.idricavo where p.tipo= " & enTipoVoceContab.VoceVendita & " and year(p.datapag) = " & AnnoScelto & " and month(p.datapag) = " & MeseScelto
        sql &= " union select p.* from t_pagamenti p inner join  t_contabcosti c on p.idfat= c.idcosto where p.tipo =  " & enTipoVoceContab.VoceAcquisto & " and year(p.datapag) = " & AnnoScelto & " and month(p.datapag) = " & MeseScelto
        sql &= " )a "
        sql &= "order by datapag"

        Dim Buffer As String = String.Empty

        Using mgr As New PagamentiDAO
            Dim l As List(Of Pagamento) = mgr.GetBySQL(sql)
            Dim Saldo As Decimal = 0

            Buffer &= "<font face=arial size=1><table border=1>"
            Buffer &= "<tr>"
            Buffer &= "<td><b>DATA</b></td>"
            Buffer &= "<td><b>RIFERIMENTO</b></td>"
            Buffer &= "<td><b>DOCUMENTO</b></td>"
            Buffer &= "<td><b>NOTE</b></td>"
            Buffer &= "<td><b>TIPO</b></td>"
            Buffer &= "<td><b>ENTRATE</b></td><td><b>USCITE</b></td>"

            Buffer &= "<td><b>SALDO</b></td>"
            Buffer &= "</tr>"
            For Each voce In l
                Dim ProcessaPagamento As Boolean = True
                If voce.Tipo = enTipoVoceContab.VoceAcquisto Then
                    ' lascio la if solo per memoria ma i costi li valuto tutti 
                ElseIf voce.Tipo = enTipoVoceContab.VoceVendita Then
                    If voce.RicavoRif.Tipo = enTipoDocumento.Preventivo Then
                        ProcessaPagamento = False
                    End If
                End If

                If ProcessaPagamento Then
                    Buffer &= "<tr>"
                    Buffer &= "<td>" & voce.DataPag.ToString("dd/MM/yyyy") & "</td>"
                    Buffer &= "<td>" & voce.ClienteNominativo & "</td>"
                    Buffer &= "<td>" & voce.TipoDocStr & " " & voce.NumeroDocStr & "</td>"
                    Buffer &= "<td>" & voce.NotePag & "</td>"
                    Buffer &= "<td>" & voce.TipoPagamentoStr & "</td>"
                    If voce.Tipo = enTipoVoceContab.VoceVendita Then
                        Buffer &= "<td>" & voce.ImportoStr & "</td><td>&nbsp;</td>"
                        Saldo += voce.Importo
                    Else
                        Buffer &= "<td>&nbsp;</td><td>" & voce.ImportoStr & "</td>"
                        Saldo -= voce.Importo
                    End If
                    Buffer &= "<td>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Saldo) & "</td>"
                    Buffer &= "</tr>"
                End If

            Next
            Buffer &= "</table>"
        End Using

        Using w As New StreamWriter("c:\temp\prova.htm")
            w.Write(Buffer)
        End Using







    End Sub

    Private Sub CreaFileTesto()

        Using w As New StreamWriter("C:\temp\etichetteandrea.txt")
            For i = 19 To 24
                For j = 1 To 50
                    w.WriteLine("- " & i.ToString("00"))
                Next
            Next
        End Using

    End Sub

    Private Sub AggiornaQtaRisDigitale()

        Dim l As List(Of MovimentoMagazzino)

        Using mgrM As New RisorseDAO
            Dim lr As List(Of Risorsa) = mgrM.FindAll(New LUNA.LSP(LFM.Risorsa.TipoRis, enTipoProdCom.StampaDigitale),
                                                      New LUNA.LSP(LFM.Risorsa.IdRis, 967))

            'Dim IdRis As Integer = 371

            For Each Ris In lr
                Using mgr As New MagazzinoDAO

                    If Ris.Larghezza <> 0 AndAlso Ris.Lunghezza <> 0 Then

                        l = mgr.FindAll(New LUNA.LSP(LFM.MovimentoMagazzino.IdRis, Ris.IdRis),
                                    New LUNA.LSP(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico),
                                    New LUNA.LSP(LFM.MovimentoMagazzino.IdCom, 0, "<>"))

                        For Each singmov In l

                            Using c As New Commessa
                                c.Read(singmov.IdCom)
                                If c.IdCom = 0 Then
                                    'elimino il movimento
                                    Using mgrMov As New MagazzinoDAO
                                        mgrMov.Delete(singmov.IdCarMag)
                                    End Using
                                Else
                                    Using MgrR As New RisorseDAO

                                        'If _ComSel.IdReparto = enRepartoWeb.StampaDigitale Then
                                        Dim qtaMov As Single = 0

                                        Dim IdUnimis As enUnitaDiMisura = Ris.IdUnitaMisura

                                        If IdUnimis = enUnitaDiMisura.Pezzi Then
                                            qtaMov = c.Copie
                                        Else
                                            Dim FFly As New Formato

                                            If c.Largo <> 0 And c.Lungo <> 0 Then
                                                FFly.Larghezza = c.Largo
                                                FFly.Altezza = c.Lungo
                                            Else
                                                'qui prendo dal primo ordine contenuto
                                                'se presente
                                                If c.ListaOrdini.Count Then
                                                    Using singO As Ordine = c.ListaOrdini()(0)
                                                        FFly.Larghezza = singO.ListinoBase.FormatoProdotto.Larghezza
                                                        FFly.Altezza = singO.ListinoBase.FormatoProdotto.Lunghezza
                                                    End Using
                                                End If

                                            End If

                                            If FFly.Larghezza <> 0 And FFly.Altezza <> 0 Then
                                                Dim qtaDaScar As Single = FFly.Larghezza * FFly.Altezza 'cm^2

                                                qtaDaScar *= c.Copie

                                                Dim m2DaScar As Single = MgrCalcoliTecnici.DaCmQuadriAMetriQuadri(qtaDaScar)
                                                Dim m2Ris As Single = MgrCalcoliTecnici.DaCmQuadriAMetriQuadri(Ris.Larghezza * Ris.Lunghezza)

                                                Dim Proporzione As Single = (m2DaScar * 100) / m2Ris

                                                qtaMov = Math.Round((Proporzione / 100), 2)
                                            End If

                                        End If

                                        singmov.Qta = qtaMov
                                        singmov.Save()


                                    End Using
                                End If
                            End Using



                        Next

                        MgrMagazzino.RicalcolaGiacenza(Ris.IdRis)

                    End If

                End Using
            Next




        End Using


    End Sub

    Private Sub ScaricaBetaGrafic()

        Dim ElencoPagineIniziali As New List(Of String)

        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/espositori-cartone-da-terra/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/espositori-in-cartone-da-banco/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/scatole-in-cartone/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/contenitori-da-terra/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/cartelli-da-banco/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/porta-depliants/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/totems-cartelli-da-terra-in-cartone/")
        ElencoPagineIniziali.Add("https://www.betagrafic.com/categoria-prodotto/espositori-in-cartone/accessori/")

        Dim PathIniziale As String = "c:\temp\betagrafic.com\"
        For Each PIn In ElencoPagineIniziali
            Dim Valore As String = String.Empty
            Dim buffer As String = FormerLib.FormerHelper.Web.GetUrlBuffer(PIn)

            'creo la cartella

            Dim path As String = PathIniziale

            Dim pathP As String = PIn.TrimEnd("/")
            Dim posiz As Integer = pathP.LastIndexOf("/")
            pathP = pathP.Substring(posiz + 1)

            pathP = PathIniziale & pathP & "\"

            FormerLib.FormerHelper.File.CreateLongPath(pathP)

            Dim Marcatore As String = "<p class=""name product-title"
            Dim Marcatore2 As String = String.Empty
            Dim posiz2 As Integer = 0

            posiz = buffer.IndexOf(Marcatore)

            Dim ElencoPagineContenute As New List(Of String)

            While posiz <> -1

                'aggiungo all'elenco le pagine contenute
                Marcatore2 = "href="
                posiz2 = buffer.IndexOf(Marcatore2, posiz)
                If posiz2 <> -1 Then
                    Dim posiz3 As Integer = buffer.IndexOf(">", posiz2)


                    Dim bufferP As String = buffer.Substring(posiz2, posiz3 - posiz2)
                    bufferP = bufferP.TrimEnd("""")
                    bufferP = bufferP.TrimEnd("/")

                    posiz2 = bufferP.IndexOf("""")
                    bufferP = (bufferP.Substring(posiz2 + 1))

                    ElencoPagineContenute.Add(bufferP)
                End If

                posiz = buffer.IndexOf(Marcatore, posiz + 1)
            End While

            'ciclo nelle pagine contenute

            For Each pCont In ElencoPagineContenute

                'scarico i dati dalal pagina contenuta
                Dim bufferDescr As String = String.Empty
                Dim buffer2 As String = FormerLib.FormerHelper.Web.GetUrlBuffer(PIn)
                'devo controllare che hanno il template senno non le scarico

                Dim ScaricaOk As Boolean = True



                If ScaricaOk Then

                    Dim pathSingP As String = pCont.TrimEnd("/")
                    posiz = pathSingP.LastIndexOf("/")
                    pathSingP = pathSingP.Substring(posiz + 1)
                    Dim prefix As String = String.Empty
                    prefix = pathSingP.Substring(0, pathSingP.IndexOf("-"))

                    pathSingP = pathP & pathSingP & "\"





                    'vado a prendere la qunatità
                    'vado a prendere template e immagini
                    Dim GoImg As Boolean = True

                    If GoImg Then
                        'woocommerce_thumbnail

                        'Marcatore = "<div class=""box-image"

                        'Dim PosizMin As Integer = buffer2.IndexOf(Marcatore)
                        'Dim PosizMax As Integer = 0
                        'If PosizMin <> -1 Then
                        'Marcatore = "Wishlist"
                        'PosizMax = buffer2.IndexOf(Marcatore, PosizMin)
                        'If PosizMax <> -1 Then
                        'Dim PosizM As Integer = 0
                        'Marcatore = "woocommerce_thumbnail"
                        'PosizM = buffer2.IndexOf(Marcatore)

                        'While PosizM <> -1
                        'If PosizM >= PosizMin And PosizM <= PosizMax Then

                        'qui controllo la regular expression per il nomefile fattura
                        'Dim PatternReg As String = "^[A-Za-z]7{2}[0-9A-Za-z]{11,16}_[0-9A-Za-z]{5}.jpg$"

                        Dim Scaricato As Boolean = False

                        prefix = prefix.Replace("-", "[-]*")

                        Dim PatternReg As String = "https://www.betagrafic.com/wp-content/uploads/[0-9]{4}/[0-9]{2}/" & prefix & "[0-9A-Za-z\-]*.jpg"

                        Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}
                        Dim PrimoPath As String = String.Empty

                        Dim m As MatchCollection = Re.Matches(buffer2)
                        If Re.IsMatch(buffer2) Then

                            For Each ris As Match In m

                                Dim valS As String = ris.Value


                                Dim lunghezza As Integer = valS.Length
                                'qui posso scaricare il file
                                Dim NomeLocale As String = String.Empty
                                posiz = ris.Value.LastIndexOf("/")
                                NomeLocale = ris.Value.Substring(posiz + 1)

                                NomeLocale = pathSingP & NomeLocale


                                If File.Exists(NomeLocale) = False Then
                                    FormerLib.FormerHelper.File.CreateLongPath(pathSingP)
                                    FormerLib.FormerHelper.Web.GetFile(ris.Value, NomeLocale)
                                End If
                                Scaricato = True
                                'prendo il primo path 
                                If PrimoPath.Length = 0 Then PrimoPath = ris.Value
                            Next

                        End If

                        PatternReg = "https://www.betagrafic.com/wp-content/uploads/[0-9]{4}/[0-9]{2}/" & prefix & "[0-9A-Za-z\-]*misure[0-9A-Za-z\-]*.jpg"

                        Re = New RegularExpressions.Regex(PatternReg) '.{0,7}

                        m = Re.Matches(buffer2)
                        If Re.IsMatch(buffer2) Then

                            For Each ris As Match In m

                                Dim valS As String = ris.Value


                                Dim lunghezza As Integer = valS.Length
                                'qui posso scaricare il file
                                Dim NomeLocale As String = String.Empty
                                posiz = ris.Value.LastIndexOf("/")
                                NomeLocale = ris.Value.Substring(posiz + 1)

                                NomeLocale = pathSingP & NomeLocale


                                If File.Exists(NomeLocale) = False Then
                                    FormerLib.FormerHelper.File.CreateLongPath(pathSingP)
                                    FormerLib.FormerHelper.Web.GetFile(ris.Value, NomeLocale)
                                End If

                                Scaricato = True

                            Next

                        End If

                        If Scaricato Then
                            'creoun file riapri.htm
                            Dim bufferHTML As String = "<html><frameset rows=""*,1""><frame src=""" & pCont & """></frameset></html>"

                            Using w As New StreamWriter(pathSingP & "riapri.htm")

                                w.WriteLine(bufferHTML)
                            End Using

                            Try
                                If PrimoPath.Length Then
                                    'provo a inventarmi un template
                                    PrimoPath = PrimoPath.Substring(0, PrimoPath.LastIndexOf("/") + 1)
                                    PrimoPath &= "template-" & prefix & ".pdf"

                                    Dim NomeLocale As String = pathSingP & "template-" & prefix & ".pdf"
                                    FormerLib.FormerHelper.Web.GetFile(PrimoPath, NomeLocale)


                                End If
                            Catch ex As Exception

                            End Try

                            Try
                                If PrimoPath.Length Then
                                    'provo a inventarmi un template
                                    PrimoPath = PrimoPath.Replace(".pdf", ".zip")

                                    Dim NomeLocale As String = pathSingP & "template-" & prefix & ".zip"
                                    FormerLib.FormerHelper.Web.GetFile(PrimoPath, NomeLocale)


                                End If
                            Catch ex As Exception

                            End Try

                        End If

                    End If


                    'template
                    '"https://www.betagrafic.com/prodotto/yannis-small-espositore-da-terra-con-ripiani-e-divisorio"
                    'https://www.betagrafic.com/prodotto/yannis-small-espositore-da-terra-con-ripiani-e-divisorio/

                End If
            Next





        Next

    End Sub

    Private Sub testvelocitacalcoloprezzi()

        Dim start1 As Date = Now
        Dim finish1 As Date = Now

        Dim L As New ListinoBase
        L.Read(593)
        L.CaricaLavorazioni()
        Dim lQta As List(Of Integer)
        Using mgr As New MgrQtaListinoBase
            lQta = mgr.GetElencoQtaReverse(L)
        End Using

        start1 = Now
        For Each i In lQta
            Dim calc As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(L, i, L.LavorazioniBaseB)
        Next
        finish1 = Now

        Dim start2 As Date = Now
        Dim finish2 As Date = Now

        Dim collRich As New List(Of RichiestaCalcoloPrezzo)

        For Each i In lQta
            Dim x As New RichiestaCalcoloPrezzo
            x.QtaRichiesta = i
            x.QtaDaUsareNelCalcoloLavorazioni = i
            collRich.Add(x)
        Next

        start2 = Now
        Dim calc2 As List(Of RisPrezzoIntermedio) = MgrPreventivazioneB.CalcolaPrezzoFinale(L, collRich, L.LavorazioniBaseB)
        finish2 = Now

        Dim dif1 As TimeSpan = finish1 - start1
        Dim dif2 As TimeSpan = finish2 - start2

        MessageBox.Show("calcolati " & lQta.Count & " prezzi " & ControlChars.NewLine & "s1:" & start1.ToString("mm.ss.fff") & " f1:" & finish1.ToString("mm.ss.fff") & " dif: " & dif1.Seconds & "s." & dif1.Milliseconds & ControlChars.NewLine & "s2:" & start2.ToString("mm.ss.fff") & " f2:" & finish2.ToString("mm.ss.fff") & " dif: " & dif2.Seconds & "s." & dif2.Milliseconds)

    End Sub

    Private Function CalcolaMq(Optional QtaForzata As Integer = 0) As RisCalcoloMq

        Dim Ris As New RisCalcoloMq
        Dim QtaToConsider As Integer = 1
        If QtaForzata Then
            QtaToConsider = QtaForzata
        End If
        'Ris = MgrCalcoliTecnici.CalcolaMq(LRif.FormatoProdotto.Fc.Larghezza,
        Dim AltezzaValidata As Integer = 160
        Dim LarghezzaValidata As Integer = 60

        Dim Scarto As Integer = 0

        Using LRif As New FW.ListinoBaseW
            Dim IdListinoBase As Integer = 397 ' PANNELLO FOREX
            'Dim IdListinoBase As Integer = 354 ' PVC ADESIVO
            LRif.Read(IdListinoBase)
            Dim LatoFissoRiferimento As Single = LRif.LatoFissoRiferimento(AltezzaValidata, LarghezzaValidata, QtaToConsider, Scarto).LatoFissoPrincipale

            Dim AltezzaFissaRiferimento As Integer = 0

            If LRif.FormatoProdotto.IsRotolo <> enSiNo.Si Then
                'qui non e' un rotolo devo calcolarlo a fogli sani
                AltezzaFissaRiferimento = LRif.FormatoProdotto.LunghezzaCm
            End If

            Ris.Mq = MgrCalcoliTecnici.CalcolaMq(LatoFissoRiferimento,
                                                       QtaToConsider,
                                                       AltezzaValidata,
                                                       LarghezzaValidata,,
                                                       Scarto,
                                                       AltezzaFissaRiferimento).AreaCalcolata

            Ris.Lato1FissoRiferimento = LatoFissoRiferimento

        End Using


        Return Ris

    End Function

    Private Function testPrestazioniAppend() As Integer

        Dim DStart As New Stopwatch
        Dim x As Char = "A"
        Dim y As String = "ciao"

        Dim s As New StringBuilder(y)
        DStart.Start()
        For i As Integer = 1 To 10000000
            s.Append(x)
        Next
        DStart.Stop()
        y = s.ToString

        'Dim DEnd As Date = Now

        '            CalcolaMq()
        Dim differenza As Double = DStart.Elapsed.TotalMilliseconds

        Return differenza

    End Function


    Private Function CheckCongruenzaFormati() As String
        Dim buffer As String = String.Empty
        Using mgr As New ListinoBaseDAO
            Dim soloSource As New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0)
            Dim soloAtt As New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No)
            Dim pNasc As New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.No)

            Dim l As List(Of ListinoBase) = mgr.FindAll(soloSource, soloAtt, pNasc) 'FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.VMotoreCalcolo, MgrPreventivazioneB.VMotoreCalcolo, "<>"),            p)

            'qui ho tutti i listinibase non compatibili
            For Each lb As ListinoBase In l


                If (lb.Formato.LarghezzaMM < lb.FormatoProdotto.FormatoCarta.LarghezzaMM OrElse
                    lb.Formato.AltezzaMM < lb.FormatoProdotto.FormatoCarta.AltezzaMM) And
                    (lb.Formato.AltezzaMM < lb.FormatoProdotto.FormatoCarta.LarghezzaMM OrElse
                    lb.Formato.LarghezzaMM < lb.FormatoProdotto.FormatoCarta.AltezzaMM) Then
                    'errore di incongruenza
                    buffer &= lb.IdListinoBase & " - " & lb.Nome & " (FM " & lb.Formato.LarghezzaMM & "x" & lb.Formato.AltezzaMM & ") (FP " & lb.FormatoProdotto.Larghezza & "x" & lb.FormatoProdotto.Lunghezza & ");" & ControlChars.NewLine
                End If

            Next

        End Using

        Return buffer

    End Function

    Private Sub CheckCongruenzaStatoRicavi()
        Dim Buffer As String = String.Empty

        Dim CheckCosti As Boolean = True
        Dim CheckRicavi As Boolean = True

        If CheckCosti Then
            Using mgr As New CostiDAO

                Dim countCosti As Integer = 0

                'Buffer &= "<h2>Costi</h2>"

                Dim l As List(Of Costo) = Nothing

                'SISTEMO I FALSI NEGATIVI

                l = mgr.FindAll(New LUNA.LSP(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                     New LUNA.LSP(LFM.Costo.IdStato, enStatoDocumentoFiscale.PagatoInteramente, "<>"))

                For Each singvoce In l
                    'voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti = singvoce.Totale Then
                        'NonCombaciano.Add(singvoce.IdRicavo)
                        'If singvoce.idstato = 0 Then
                        countCosti += 1
                        singvoce.IdStato = enStatoDocumentoFiscale.PagatoInteramente
                        singvoce.Save()
                        'End If
                    End If
                    Application.DoEvents()
                Next

                l = mgr.FindAll(New LUNA.LSP(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                    New LUNA.LSP(LFM.Costo.IdStato, enStatoDocumentoFiscale.PagatoInteramente, "="))

                For Each singvoce In l
                    MgrDocumentiFiscali.AggiornaStatoCostoDopoPagamento(singvoce.IdCosto)
                Next

                'MessageBox.Show("Costi totali " & l.Count & " FALSI NEGATIVI " & countCosti)

                'MOSTRO I FALSI POSITIVI



            End Using
        End If

        If CheckRicavi Then
            Using mgr As New RicaviDAO

                Buffer &= "<h2>Ricavi</h2>"

                Dim l As List(Of Ricavo) = Nothing

                'SISTEMO I FALSI NEGATIVI

                l = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                New LUNA.LSP(LFM.Ricavo.idstato, enStatoDocumentoFiscale.PagatoInteramente, "<>"))

                For Each singvoce In l
                    'voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti = singvoce.Totale Then
                        'NonCombaciano.Add(singvoce.IdRicavo)
                        'If singvoce.idstato = 0 Then
                        singvoce.idstato = enStatoDocumentoFiscale.PagatoInteramente
                        singvoce.Save()
                        'End If
                    End If
                    Application.DoEvents()
                Next

                l = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                                           New LUNA.LSP(LFM.Ricavo.idstato, enStatoDocumentoFiscale.PagatoInteramente))


                'MOSTRO I FALSI POSITIVI

                Dim totalevoci As Integer = l.Count
                Dim NonCombaciano As New List(Of Integer)
                Dim voceattuale As Integer = 0

                For Each singvoce In l
                    voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti <> singvoce.Totale Then
                        NonCombaciano.Add(singvoce.IdRicavo)
                    End If
                    Application.DoEvents()
                Next

                MessageBox.Show("PRESENTI " & totalevoci & " NON CONGRUENTI : " & NonCombaciano.Count)

                txtDebug.AppendText(ControlChars.NewLine & ControlChars.NewLine)

                NonCombaciano.Clear()

            End Using
        End If

    End Sub

    Private Sub NuovoLayoutEmail()

        Dim buffer As String = "bla bla bla <br>bla bla bla bla bla <br> bla bla bla bla "

        FormerHelper.Mail.InviaMailEx("ciao", buffer, "d.lunadei@gmail.com", New List(Of String))

    End Sub
    Private Sub TestClassi(param As a)



    End Sub
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        btnTest.Enabled = False

        If MessageBox.Show("Vuoi effettuare l'operazione di test?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'TestFatturaElettronica()
            'NuovoLayoutEmail()
            Dim x As New b


            TestClassi(x)


            'Using r As New Ricavo
            '    r.Read(58690)
            '    Dim FatturaVecchia As FatturaElettronica = MgrFattureFE.GetFatturaFromRicavo(r)


            '    Dim x As Integer = 0
            '    x += 1
            'End Using

            'CheckCongruenzaStatoRicavi()

            'Dim ListaFile As New List(Of String)

            'For i As Integer = 2 To 16
            '    Dim nomefile As String = "C:\temp\GabettiPocket\202104\Lazio\$.pdf"

            '    Dim NomeSing As String = nomefile.Replace("$", FormerLib.FormerHelper.Stringhe.FormattaConCaratterePrefisso(i, 2, "0"))

            '    ListaFile.Add(NomeSing)

            'Next

            'FormerLib.FormerHelper.PDF.MergePdfFiles(ListaFile.ToArray, "C:\temp\rivista.pdf")
            MessageBox.Show("OK")

        End If

        btnTest.Enabled = True
    End Sub

    Private Sub CalcolaPrezzoLavorazione()

        Using Lb As New ListinoBase
            Lb.Read(1187)

            Using l As New Lavorazione
                l.Read(169)

                Dim Prezzo As Decimal = MgrPreventivazioneB.CalcolaPrezzoLavorazione(500, l, Lb, Lb.TipoCartaB,,, True).PrezzoTotale

            End Using

        End Using

    End Sub

    Private Sub BonificaCap()

        Dim Ok As Integer = 0
        Dim Errati As String = String.Empty

        'Using mgr As New IndirizziDAO
        '    Dim l As List(Of Indirizzo) = mgr.GetAll()

        '    For Each singInd In l
        '        Using mgrCom As New ElencoComuniDAO

        '            Dim lC As List(Of ComuneInElenco) = mgrCom.FindAll(New LUNA.LunaSearchParameter("Comune", singInd.Citta), _
        '                                                              New LUNA.LunaSearchParameter("CAP", singInd.Cap))
        '            If lC.Count = 0 Or lC.Count > 1 Then
        '                Errati &= singInd.IDIndirizzo & ","
        '            Else
        '                Dim C As ComuneInElenco = lC(0)
        '                Ok += 1
        '                singInd.IdProvincia = C.ProvinciaSel.ID
        '                singInd.IdComune = C.IDCap
        '                singInd.Citta = StrConv(C.Comune, VbStrConv.ProperCase)
        '                singInd.Save()

        '                Dim indOn As New FW.Indirizzo
        '                indOn.Read(singInd.IdIndOnline)
        '                indOn.IdProvincia = singInd.IdProvincia
        '                indOn.IdComune = singInd.IdComune
        '                indOn.Citta = singInd.Citta
        '                indOn.Save()

        '            End If
        '        End Using
        '    Next

        'End Using

        'Using mgr As New FW.IndirizziDAO
        '    Dim l As List(Of FW.Indirizzo) = mgr.FindAll(New FW.LUNA.LunaSearchParameter("IdIndirizzoInt", 0))
        '    For Each singind In l
        '        Using mgrCom As New FW.ElencoComuniDAO

        '            Dim lC As List(Of FW.ComuneInElenco) = mgrCom.FindAll(New FW.LUNA.LunaSearchParameter("Comune", singind.Citta), _
        '                                                              New FW.LUNA.LunaSearchParameter("CAP", singind.Cap))
        '            If lC.Count = 0 Or lC.Count > 1 Then
        '                Errati &= singind.IdIndirizzo & ","
        '            Else
        '                Dim C As FW.ComuneInElenco = lC(0)
        '                Ok += 1
        '                singind.IdProvincia = C.ProvinciaSel.ID
        '                singind.IdComune = C.IDCap
        '                singind.Citta = StrConv(C.Comune, VbStrConv.ProperCase)
        '                singind.Save()
        '            End If
        '        End Using
        '    Next
        'End Using
        'Stop
        Ok = 0
        Errati = String.Empty
        'End
        Using mgr As New VociRubricaDAO

            'Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter("email", "emailnondisponibile@tipografiaformer.it", "<>"), _
            '                                            New LUNA.LunaSearchParameter("idrub", "(Select distinct Idrub from t_ordini)", "IN"), _
            '                                            New LUNA.LunaSearchParameter("Len(indirizzo)", 0, ">"))
            Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchParameter("Sorgente", "W"),
                    New LUNA.LunaSearchParameter("IdComune", "0"))

            For Each singvoce In l

                Using mgrCom As New ElencoComuniDAO

                    Dim lC As List(Of ComuneInElenco) = mgrCom.FindAll(New LUNA.LunaSearchParameter("Comune", singvoce.Citta),
                                    New LUNA.LunaSearchParameter("CAP", singvoce.CAP))

                    If lC.Count = 0 Or lC.Count > 1 Then
                        Errati &= singvoce.IdRub & ","
                    Else
                        Try
                            ''qui e' ok
                            Dim C As ComuneInElenco = lC(0)

                            'singvoce.LastUpdate = Now
                            singvoce.IdProvincia = C.ProvinciaSel.ID
                            singvoce.Provincia = C.Provincia
                            singvoce.IdComune = C.IDCap
                            singvoce.Citta = StrConv(C.Comune, VbStrConv.ProperCase)
                            singvoce.Save()

                            Dim indOn As New FW.Utente
                            indOn.Read(singvoce.IdUtOnline)
                            indOn.IdProvincia = singvoce.IdProvincia
                            indOn.Provincia = singvoce.Provincia
                            indOn.IdComune = singvoce.IdComune
                            indOn.Citta = singvoce.Citta
                            indOn.Save()

                            Ok += 1
                        Catch ex As Exception
                            Errati &= singvoce.IdRub & ","
                            Stop
                        End Try
                    End If

                End Using

            Next

            'MessageBox.Show("OK: " & Ok & " - Errati: " & Errati)
            Dim PathOut As String = "c:\temp\errati.txt"
            Using w As New StreamWriter(PathOut)
                w.Write(Errati)
            End Using

            FormerHelper.File.ShellExtended(PathOut)

        End Using

    End Sub

    Private Sub btnLogOrdineInt_Click(sender As Object, e As EventArgs) Handles btnLogOrdineInt.Click

        Dim path As String = FormerPath.PathLog.Replace("Z", "W") & txtIdOrdine.Text & ".log.txt"

        If FileIO.FileSystem.FileExists(path) Then
            FormerHelper.File.ShellExtended(path)
            ResetId()
        Else
            MessageBox.Show("Il file di Log non esiste")
        End If

    End Sub

    Private Sub btnLogOrdOnline_Click(sender As Object, e As EventArgs) Handles btnLogOrdOnline.Click

        Using mgr As New FW.OrdiniWebDAO

            Dim l As List(Of FW.OrdineWeb) = mgr.FindAll(New FW.LUNA.LunaSearchParameter("IdOrdineInt", txtIdOrdine.Text))

            If l.Count Then

                Dim IdOrd As Integer = l(0).IdOrdine
                Dim path As String = "http://www.tipografiaformer.it/ordini/" & IdOrd & "/" & IdOrd & ".xml"
                FormerHelper.File.ShellExtended(path)
                ResetId()

            Else
                MessageBox.Show("Ordine online non trovato per questo ordine interno")
            End If

        End Using

    End Sub

    'Private Sub Naviga()

    '    Dim Url As String = txtUrl.Text.ToLower

    '    If Url.StartsWith("http://") = False Then Url = "http://" & Url

    '    wbLab.Navigate(Url)

    'End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs)

        'Naviga()

    End Sub

    'Private Sub txtUrl_KeyDown(sender As Object, e As KeyEventArgs)

    '    If e.KeyCode = Keys.Enter Then
    '        Naviga()
    '    End If

    'End Sub

    Private Sub btnCreaIcona_Click(sender As Object, e As EventArgs) Handles btnCreaIcona.Click

        Dim Lettera As String = InputBox("Dammi la lettera o le lettere", "Creazione Icona").ToUpper

        Using i As Image = New Bitmap(24, 24)

            Dim flagGraphics As Graphics = Graphics.FromImage(i)

            Dim orangeBr As New SolidBrush(Color.FromArgb(225, 128, 0))
            Dim blackBr As New SolidBrush(Color.FromArgb(64, 64, 64))
            Dim whiteBr As New SolidBrush(Color.White)
            Dim LetteraForma As String = String.Empty

            Dim scrittaBr As SolidBrush = Nothing
            Dim sfondoBr As SolidBrush = Nothing

            If rdoBianca.Checked Then
                scrittaBr = whiteBr
            Else
                scrittaBr = blackBr
            End If

            If rdoOrange.Checked Then
                sfondoBr = orangeBr
            ElseIf rdoStatoOrdine.Checked Then
                Dim c As Color = FormerColori.GetColoreStatoOrdine(DirectCast(cmbColoreStatoOrd.SelectedItem, cEnum).Id)
                Dim sfondoCustom As New SolidBrush(c)
                sfondoBr = sfondoCustom
            Else
                Dim sfondoCustom As New SolidBrush(rdoCustom.Tag)
                sfondoBr = sfondoCustom
            End If

            If rdoRect.Checked Then
                Dim drawRect As New RectangleF(0, 0, 24, 24)
                flagGraphics.FillRectangle(sfondoBr, drawRect)
                LetteraForma = "R"
            Else
                Dim drawRect As New RectangleF(0, 0, 24, 24)
                flagGraphics.FillEllipse(sfondoBr, drawRect)
                LetteraForma = "C"
            End If

            Dim f As New Font("Roboto Mono", 12, FontStyle.Bold)

            If Lettera.Length = 1 Then
                flagGraphics.DrawString(Lettera, f, scrittaBr, 4, 1)
            ElseIf Lettera.Length = 2 Then
                flagGraphics.DrawString(Lettera, f, scrittaBr, -1, 1)
            End If

            flagGraphics.Save()
            Dim Path As String = "H:\Lavoro\source\Former\IconSet\Ufficiale\ico_" & Lettera & "_" & LetteraForma & ".png"
            Dim PathProd As String = "H:\Lavoro\source\Former\IconSet\Produzione\ico_" & Lettera & "_" & LetteraForma & ".png"
            'Path = "H:\temp\ico_" & Lettera & ".png"
            i.Save(Path)

            MgrFormerIO.FileCopy(Path, PathProd, Me)

            FormerLib.FormerHelper.File.ShellExtended(Path)

        End Using

    End Sub

    Private Sub rdoCustom_Click(sender As Object, e As EventArgs) Handles rdoCustom.Click

        If dlgColor.ShowDialog() = DialogResult.OK Then
            rdoCustom.Tag = dlgColor.Color
        Else
            rdoStatoOrdine.Checked = True
        End If

    End Sub

    Private Sub btnCaricamentoIniziale_Click(sender As Object, e As EventArgs)

        CaricamentoIniziale()

        MessageBox.Show("Fatto")

    End Sub

    Private Sub btnLoadCosaVede_Click(sender As Object, e As EventArgs) Handles btnLoadCosaVede.Click

        If txtIdUtOnline.Text.Length Then

            If MessageBox.Show("Confermi il caricamento dei dati?", "Caricamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                Using mgr As New FW.ConsegneDAO
                    Dim l As List(Of FW.Consegna) = mgr.FindAll("IdConsegna Desc",
                New FW.LUNA.LunaSearchParameter("Idut", txtIdUtOnline.Text),
                New FW.LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.Eliminata, "<>"))
                    dgConsegne.AutoGenerateColumns = False
                    dgConsegne.DataSource = l

                End Using

                Using mgr As New FW.OrdiniWebDAO
                    Dim l As List(Of FW.OrdineWeb) = mgr.FindAll("IdOrdine Desc", New FW.LUNA.LunaSearchParameter("IdUt", txtIdUtOnline.Text),
                        New FW.LUNA.LunaSearchParameter("StatoWeb", CInt(enStato.Attivo)))
                    dgLavori.AutoGenerateColumns = False
                    dgLavori.DataSource = l
                End Using

                Cursor = Cursors.Default
            End If
        Else
            MessageBox.Show("Inserire Id Utente Online")
        End If

    End Sub

    Private Sub btnRilascioGestionale_Click(sender As Object, e As EventArgs) Handles btnRilascioGestionale.Click
        If MessageBox.Show("Confermi?", "Rilascio Gestionale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim BufferReleaseNote As String = String.Empty

            Using f As New frmReleaseNote
                BufferReleaseNote = f.Carica
            End Using

            If BufferReleaseNote.Length Then

                Dim PathExeLocale As String = "c:\source\Former\Source\Main\Former\bin\Release\Former.exe"
                Dim FLocale As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeLocale)

                Dim Versione As String = "Former " & FLocale.FileVersion

                BufferReleaseNote = Versione & ControlChars.NewLine & "*************" & ControlChars.NewLine & ControlChars.NewLine & BufferReleaseNote & ControlChars.NewLine & "- Bugfix generici"
            End If

            Dim PathSorgente As String = "c:\source\Former\Source\Main\Former\bin\Release\"
            Dim PathDest As String = "c:\rilasci\Gestionale\"
            Dim PathDest2 As String = "W:\FormerEsercizio\bin\Former\"

            Try
                Dim PathReleaseNote As String = "W:\FormerEsercizio\bin\Former\releasenote.txt"

                If BufferReleaseNote.Length Then
                    Using w As New StreamWriter(PathReleaseNote)
                        w.Write(BufferReleaseNote)
                    End Using
                Else
                    Try
                        If File.Exists(PathReleaseNote) Then
                            File.Delete(PathReleaseNote)
                        End If
                    Catch ex As Exception

                    End Try
                End If

                Dim d As New DirectoryInfo(PathSorgente)

                For Each f As FileInfo In d.GetFiles("form*.exe")
                    File.Copy(f.FullName, PathDest & f.Name, True)
                    File.Copy(f.FullName, PathDest2 & f.Name, True)
                Next

                For Each f As FileInfo In d.GetFiles("*.dll")
                    File.Copy(f.FullName, PathDest & f.Name, True)
                    File.Copy(f.FullName, PathDest2 & f.Name, True)
                Next

                MessageBox.Show("Rilascio effettuato correttamente")

                CaricaVersioniGestionale()

            Catch ex As Exception
                MessageBox.Show("ERRORE: " & ex.Message)
            End Try

        End If
    End Sub

    Private Sub CaricaVersioniGestionale()

        Dim PathExeRemoto As String = "W:\FormerEsercizio\bin\Former\Former.exe"
        Dim PathExeLocale As String = "C:\Source\Former\Source\Main\Former\bin\Release\Former.exe"

        Dim FRemoto As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeRemoto)
        Dim FLocale As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeLocale)

        lblVerGest.Text = "Rilasciata " & FRemoto.FileVersion & " - Disponibile " & FLocale.FileVersion

        If FRemoto.FileVersion.ToString <> FLocale.FileVersion.ToString Then
            lblVerGest.BackColor = Color.Red
        Else
            lblVerGest.BackColor = Color.Green
        End If

    End Sub

    Private Sub CaricaVersioniDemone()

        Dim PathExeRemoto As String = "S:\Server\FormerDaemon-Server.exe"
        Dim PathExeLocale As String = "C:\source\Former\Source\Main\FormerDaemon-Server\bin\Release\FormerDaemon-Server.exe"

        Dim FRemoto As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeRemoto)
        Dim FLocale As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeLocale)

        lblVerDemone.Text = "Rilasciata " & FRemoto.FileVersion & " - Disponibile " & FLocale.FileVersion

        If FRemoto.FileVersion.ToString <> FLocale.FileVersion.ToString Then
            lblVerDemone.BackColor = Color.Red
        Else
            lblVerDemone.BackColor = Color.Green
        End If

    End Sub

    Private Sub btnRilascioDemone_Click(sender As Object, e As EventArgs) Handles btnRilascioDemone.Click

        If MessageBox.Show("Confermi?", "Rilascio DEMONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim PathSorgente As String = "C:\source\Former\Source\Main\FormerDaemon-Server\bin\Release\"
            Dim PathDest As String = "C:\rilasci\Daemon\"
            Dim PathDest2 As String = "S:\Server\"

            PathDest &= Now.Year & Now.Month.ToString("00") & Now.Day.ToString("00") & "\"

            FormerLib.FormerHelper.File.CreateLongPath(PathDest)

            Try
                Dim d As New DirectoryInfo(PathSorgente)

                For Each f As FileInfo In d.GetFiles("form*.exe")
                    File.Copy(f.FullName, PathDest & f.Name, True)
                    File.Copy(f.FullName, PathDest2 & f.Name, True)
                Next

                For Each f As FileInfo In d.GetFiles("*.dll")
                    File.Copy(f.FullName, PathDest & f.Name, True)
                    File.Copy(f.FullName, PathDest2 & f.Name, True)
                Next

                MessageBox.Show("Rilascio effettuato correttamente")
                CaricaVersioniDemone()
            Catch ex As Exception
                MessageBox.Show("ERRORE: " & ex.Message)
            End Try

        End If

    End Sub

    Private Sub btnRegistraPagamento_Click(sender As Object, e As EventArgs) Handles btnRegistraPagamento.Click

        If MessageBox.Show("Confermi la registrazione del pagamento online?", "Registra pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                    Using c As New FW.Consegna
                        c.Read(txtIdConsOnline.Text)

                        If c.IdConsegna Then
                            If c.PagamentoOrdine Is Nothing Then

                                tb.TransactionBegin()

                                Dim P As New FW.PagamentoOnline
                                P.IdUt = c.IdUt
                                P.Quando = Now
                                P.IdConsegna = c.IdConsegna
                                P.IdTipoPagamento = enMetodoPagamento.PayPal  '9 PAYPAL
                                P.Importo = c.ImportoTot
                                P.StatoPagamento = enStatoPagamento.Pagato
                                P.Save()

                                If c.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then
                                    c.IdStatoConsegna = enStatoConsegna.InLavorazione
                                    c.Save()
                                    For Each O As FW.OrdineWeb In c.ListaOrdini
                                        If O.Stato = enStatoOrdine.InAttesaPagamento Then
                                            O.Stato = enStatoOrdine.InAttesaAllegati
                                            O.Save()
                                        End If
                                    Next
                                End If

                                tb.TransactionCommit()
                                MessageBox.Show("Pagamento registrato")
                            End If
                        End If

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnGetChiave_Click(sender As Object, e As EventArgs) Handles btnGetChiave.Click

        Dim IdRub As String = InputBox("Inserisci l'id Rub interno")

        If IdRub.Length Then
            Using r As New VoceRubrica
                r.Read(IdRub)

                MessageBox.Show(r.CalcolaChiave)
            End Using
        End If

    End Sub

    Private Sub btnMalicious_Click(sender As Object, e As EventArgs) Handles btnMalicious.Click

        Dim IpToCheck As String = txtIp.Text.Trim

        If FormerLib.FormerHelper.Web.IsValidIpAddress(IpToCheck) Then

            Dim Url As String = "https://cymon.io/" & IpToCheck

            webBan.Navigate(Url)

        Else
            MessageBox.Show("Ip Inserito non valido")
        End If

    End Sub

    Private Sub btnGeo_Click(sender As Object, e As EventArgs) Handles btnGeo.Click

        Dim IpToCheck As String = txtIp.Text.Trim

        If FormerLib.FormerHelper.Web.IsValidIpAddress(IpToCheck) Then

            Dim Url As String = "http://whatismyipaddress.com/ip/" & IpToCheck

            webBan.Navigate(Url)

        Else
            MessageBox.Show("Ip Inserito non valido")
        End If

    End Sub

    Private Sub btnBan_Click(sender As Object, e As EventArgs) Handles btnBan.Click

        Dim IpToCheck As String = txtIp.Text.Trim

        If FormerLib.FormerHelper.Web.IsValidIpAddress(IpToCheck) Then
            If MessageBox.Show("Confermi il ban dell'ip inserito?", "Ban", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgr As New FW.IpBanDAO
                    Dim l As List(Of FW.IpBan) = mgr.FindAll(New FW.LUNA.LunaSearchParameter("IpToBan", IpToCheck))
                    If l.Count = 0 Then
                        Using Ip As New FW.IpBan
                            Ip.IpToBan = IpToCheck
                            Ip.Quando = Now
                            Ip.Save()
                        End Using

                        MessageBox.Show("Fatto")
                    Else
                        MessageBox.Show("Ip già bannato")
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Ip Inserito non valido")
        End If
    End Sub

    Private Sub RicreaConsegnaMassiva()

        Using mgr As New OrdiniDAO
            Dim l As List(Of Ordine) = mgr.GetBySQL("SELECT * FROM T_ORDINI ")
        End Using

    End Sub

    Private Sub RicreaConsegna(IdOrd As Integer)

        Using O As New Ordine
            O.Read(IdOrd)

            If O.ConsegnaAssociata Is Nothing OrElse O.ConsegnaAssociata.IdCons = 0 Then

                Dim C As New ConsegnaProgrammata
                Dim IdNewCons As Integer = 0
                C.LastUpdate = 1
                C.IdRub = O.IdRub
                C.Giorno = IIf(O.DataPrevConsegna = Date.MinValue, Now.Date, O.DataPrevConsegna)
                C.IdCorr = O.IdCorriere
                C.NumColli = O.NumeroRealeColli
                C.DataPrevistaOriginale = C.Giorno
                C.StampaDocumenti = enSiNo.Si
                C.IdStatoConsegna = enStatoConsegna.InLavorazione
                C.Peso = 0
                IdNewCons = C.Save()

                Using mgr As New ConsProgrOrdiniDAO
                    Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdOrd, O.IdOrd))

                    Dim cN As ConsProgrOrdini = Nothing
                    If l.Count = 0 Then
                        cN = New ConsProgrOrdini
                        cN.IdOrd = IdOrd
                    ElseIf l.Count = 1 Then
                        cN = l(0)
                    End If
                    cN.IdCons = IdNewCons
                    cN.Save()
                End Using
                C.AggiornaColliPeso()
                MessageBox.Show("Fatto")
                ResetId()
            Else
                MessageBox.Show("L'ordine inserito ha già una consegna associata")
            End If

        End Using

    End Sub


    Private Sub btnRicreaConsegna_Click(sender As Object, e As EventArgs) Handles btnRicreaConsegna.Click

        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If txtIdOrdine.Text.Length Then
                Dim IdOrd As Integer = txtIdOrdine.Text
                RicreaConsegna(IdOrd)
            Else
                Beep()
            End If
        End If

    End Sub

    Private Sub ResetId()
        txtIdOrdine.Text = String.Empty
        txtIdConsegna.Text = String.Empty

    End Sub

    Private Sub btnImportContacts_Click(sender As Object, e As EventArgs) Handles btnImportContacts.Click
        Dim Hashtag As String = "#viscom2017"

        If MessageBox.Show("Confermi l'import dei dati con hashtag '" & Hashtag & "'?", "Caricamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ImportHashtag(Hashtag)
        End If

    End Sub

    Private Sub lblVerGest_Click(sender As Object, e As EventArgs) Handles lblVerGest.Click

    End Sub

    Private Sub lblVerDemone_Click(sender As Object, e As EventArgs) Handles lblVerDemone.Click

    End Sub

    Private Sub btnRilascioSito_Click(sender As Object, e As EventArgs) Handles btnRilascioSito.Click

    End Sub

    Private Sub btnAggiornaBug_Click(sender As Object, e As EventArgs) Handles btnAggiornaBug.Click
        Dim BugPresenti As Integer = CaricaBug()

        tpBug.Text = "Bug (" & BugPresenti & ")"
    End Sub

    Private Function CaricaBug() As Integer

        tvBug.Nodes.Clear()

        Dim PathBug As String = FormerPath.PathBug
        PathBug = PathBug.Replace("Z:\", "W:\")

        Dim D As New DirectoryInfo(PathBug)
        Dim Counter As Integer = 0
        For Each bug As DirectoryInfo In D.GetDirectories

            If File.Exists(bug.FullName & "\timestamp.txt") = False Then
                'dal nome recupero data e tutto 
                Dim N As New TreeNode
                N.Name = bug.Name
                N.Tag = bug.FullName
                N.ImageIndex = 0
                N.Text = bug.Name
                tvBug.Nodes.Add(N)
                Counter += 1
            End If
        Next

        Return Counter
    End Function

    Private Sub CaricaSingoloBug()

        Dim Nodo As TreeNode = tvBug.SelectedNode
        pctBug.Image = Nothing

        If Not Nodo Is Nothing Then

            Dim Path As String = Nodo.Tag & "\"
            Dim PathImg As String = Path & "screenshot.jpg"
            Dim screen As Image = Image.FromFile(PathImg)
            pctBug.Image = screen
            pctBug.Tag = PathImg

            Dim D As New DirectoryInfo(Path)

            Dim l As List(Of FileInfo) = D.GetFiles("segnalazione-*.txt").ToList

            If l.Count Then
                Dim Annotazione As FileInfo = l(0)

                lblBugTitolo.Text = Annotazione.Name

                Using r As New StreamReader(Annotazione.FullName)
                    txtBug.Text = r.ReadToEnd
                End Using

            End If

        End If

    End Sub

    Private Sub tvBug_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvBug.AfterSelect
        CaricaSingoloBug()
    End Sub

    Private Sub pctBug_Click(sender As Object, e As EventArgs) Handles pctBug.Click

        FormerLib.FormerHelper.File.ShellExtended(pctBug.Tag)

    End Sub

    Private Sub btnBugLavorato_Click(sender As Object, e As EventArgs) Handles btnBugLavorato.Click

        If MessageBox.Show("Confermi di aver lavorato la segnalazione selezionata?", "Segnalazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim Responso As String = InputBox("Inserisci il responso della segnalazione o della modifica richiesta", "Come è andata?", "Risolto!")

            Dim Nodo As TreeNode = tvBug.SelectedNode
            pctBug.Image = Nothing
            lblBugTitolo.Text = "-"
            txtBug.Text = String.Empty

            If Not Nodo Is Nothing Then
                'Dim NewName As String = String.Empty

                'NewName = "-" & Nodo.Name

                'FileIO.FileSystem.RenameDirectory(Nodo.Tag, NewName)

                Using w As New StreamWriter(Nodo.Tag.ToString & "\timestamp.txt")
                    w.Write(Now.ToString & ControlChars.NewLine & ControlChars.NewLine & Responso)
                End Using
                Dim BugPresenti As Integer = CaricaBug()

                tpBug.Text = "Bug (" & BugPresenti & ")"
                'IO.Directory.
            End If
        End If

    End Sub

    'Private Sub CaricamentoVMStandard()

    '    Using Mgr As New OrdiniDAO
    '        Dim l As List(Of Ordine) = Mgr.GetAll("IdOrd Desc")
    '        dgNormalMode.AutoGenerateColumns = False
    '        dgNormalMode.DataSource = l
    '    End Using

    'End Sub

    'Private Sub CaricamentoVM()
    '    Cursor.Current = Cursors.WaitCursor
    '    txtDebugVM.Text = String.Empty
    '    Dim Data1 As Date = Now
    '    Dim Data2 As Date = Now
    '    Dim Diff As Long = 0
    '    Dim Entrambe As Boolean = False
    '    If Entrambe Then
    '        txtDebugVM.Text = "START NORMAL " & ControlChars.NewLine
    '        Using Mgr As New LavLogDAO
    '            Data2 = Now
    '            Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '            txtDebugVM.Text &= "ISTANZA " & Diff & ControlChars.NewLine
    '            Dim l As List(Of LavLog) = Mgr.GetAll("IdOrd Desc")
    '            Data1 = Data2
    '            Data2 = Now
    '            Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '            txtDebugVM.Text &= "GETDATA " & Diff & ControlChars.NewLine
    '            dgNormalMode.AutoGenerateColumns = False
    '            dgNormalMode.DataSource = l '.Take(100).ToList

    '            'DirectCast(dgNormalMode.DataSource, List(Of Object)).AddRange(l.Skip(100).Take(100))

    '            Data1 = Data2
    '            Data2 = Now
    '            Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '            txtDebugVM.Text &= "BIND " & Diff & ControlChars.NewLine
    '        End Using

    '        Try
    '            GC.Collect()
    '        Catch ex As Exception

    '        End Try
    '    End If

    '    txtDebugVM.Text &= "START VIRTUAL " & ControlChars.NewLine
    '    Data1 = Now
    '    Using Mgr As New LavLogDAO
    '        Data2 = Now
    '        Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '        txtDebugVM.Text &= "ISTANZA " & Diff & ControlChars.NewLine
    '        Dim l As List(Of LavLog) = Mgr.GetAll("IdOrd Desc") 'FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "IdOrd Desc", .Top = 80})
    '        Data1 = Data2
    '        Data2 = Now
    '        Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '        txtDebugVM.Text &= "GETDATA " & Diff & ControlChars.NewLine
    '        dgVirtualMode.AutoGenerateColumns = False
    '        dgVirtualMode.DataSource = l
    '        Data1 = Data2
    '        Data2 = Now
    '        Diff = (Data2.Ticks - Data1.Ticks) / 10000
    '        txtDebugVM.Text &= "BIND " & Diff & ControlChars.NewLine

    '    End Using

    '    Cursor.Current = Cursors.Default

    'End Sub

    'Private Sub btnTestVirtualMode_Click(sender As Object, e As EventArgs)

    '    CaricamentoVM()

    'End Sub

    Private Sub dgVirtualMode_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    'Private Sub dgVirtualMode_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgVirtualMode.CellValueNeeded
    '    lblCount.Tag += 1
    '    lblCount.Text = lblCount.Tag
    'End Sub
    Private Sub btnRigeneraAnteprima_Click(sender As Object, e As EventArgs) Handles btnRigeneraAnteprima.Click
        If MessageBox.Show("Confermi la rigenerazione dell'anteprima???", "Rigenerazione anteprima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim ListaOrd As String = txtOrdCambioStato.Text
            If ListaOrd.Trim.Length Then
                For Each SingOrd In ListaOrd.Split(",")
                    If SingOrd.Length Then

                        Using O As New Ordine
                            O.Read(SingOrd)

                            If O.ListaSorgenti.Count Then
                                Using f As FileSorgente = O.ListaSorgenti(0)

                                    'qui estraggo il file 
                                    'PER L'ANTEPRIMA LA DEVO CREARE
                                    Dim NomeAnteprima As String = O.FilePath.ToLower.Replace("z:\", "w:\")
                                    Try

                                        FormerHelper.PDF.GetPdfThumbnail(f.FilePath.ToLower.Replace("z:\", "w:\"), NomeAnteprima)

                                    Catch ex As Exception
                                        'qui c'è stato un errore nella creazione dell'anteprima
                                        'metto un file temporaneo e poi vediamo
                                        MessageBox.Show(ex.Message)

                                    End Try
                                End Using
                            End If

                        End Using
                    End If
                Next
                MessageBox.Show("Anteprima rigenerata per gli ordini inseriti")
            Else
                MessageBox.Show("Inserire gli id degli ordini")

            End If
        End If
    End Sub

    Private Sub lblTest_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTest_MouseEnter(sender As Object, e As EventArgs)
        sender.AutoSize = True
    End Sub

    Private Sub lblTest_MouseLeave(sender As Object, e As EventArgs)
        sender.AutoSize = False
    End Sub

    Private Sub btnDelBug_Click(sender As Object, e As EventArgs) Handles btnDelBug.Click

        Dim Nodo As TreeNode = tvBug.SelectedNode
        pctBug.Image = Nothing
        lblBugTitolo.Text = "-"
        txtBug.Text = String.Empty

        If Not Nodo Is Nothing Then
            'Dim NewName As String = String.Empty

            'NewName = "-" & Nodo.Name

            'FileIO.FileSystem.RenameDirectory(Nodo.Tag, NewName)

            Nodo.Text = "DELETED! " & Nodo.Text
            Using w As New StreamWriter(Nodo.Tag.ToString & "\timestamp.txt")
                w.Write(Now.ToString & ControlChars.NewLine & ControlChars.NewLine & "ELIMINATO! NON IMPORTANTE")
            End Using
            'Dim BugPresenti As Integer = CaricaBug()

            'tpBug.Text = "Bug (" & BugPresenti & ")"
            'IO.Directory.
        End If
    End Sub

    Private Sub btnStopSearch_Click(sender As Object, e As EventArgs) Handles btnStopSearch.Click
        StopSearch = True
    End Sub

    Private Sub btnCriptaPwd_Click(sender As Object, e As EventArgs) Handles btnCriptaPwd.Click
        txtPwdCriptata.Text = FormerLib.FormerHelper.Security.GetMd5Hash(txtPwdOrig.Text)
    End Sub

    Private Sub tpAltro_Click(sender As Object, e As EventArgs) Handles tpAltro.Click

    End Sub

    Private Sub btnGeneraReport_Click(sender As Object, e As EventArgs) Handles btnGeneraReport.Click

        Cursor.Current = Cursors.WaitCursor

        CreaReport()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CreaReport()

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim buffer As String = String.Empty

            Dim RisultatoMesi As List(Of MeseDisponibile) = MgrReport.GetTotaleMensile
            buffer &= "<html><head>"

            buffer &= "<style>"
            buffer &= "body {font-family:arial;font-size:11px;}"
            buffer &= "table {font-family:arial;font-size:11px;}td {padding-right:10px;}"
            buffer &= "h1 {font-size:20px;font-weight:bold;color:red;margin-bottom:5px;}"
            buffer &= "h2 {font-size:14px;font-weight:bold;color:blue;margin-bottom:5px;}"
            buffer &= ".importi {background-color:#f3cbaa;}"
            buffer &= ".importiHeader {background-color:#f58220;}"
            buffer &= ".statOrdini {background-color:#aaf3af;}"
            buffer &= ".statClienti {background-color:#aaddf3;}"
            buffer &= ".statProd {background-color:#f1f2a0;}"
            buffer &= "</style>"
            buffer &= "</head><body>"
            buffer &= "<table>"
            buffer &= "<tr>"

            'If _BufferTotale.Length = 0 Then
            '    _BufferTotale &= "<td valign=top>"
            '    _BufferTotale &= "<h1>Riassunto</h1>"
            '    _BufferTotale &= "<table border=1 class=""importi"">"
            '    _BufferTotale &= "<tr>"
            '    _BufferTotale &= "<td class=""importiHeader""><b>Mese</b></td>"
            '    _BufferTotale &= "<td class=""importiHeader""><b>Totale</b></td>"
            '    _BufferTotale &= "<td class=""importiHeader""><b>Numero Ordini</b></td>"
            '    _BufferTotale &= "<td class=""importiHeader""><b>Registrazioni dal sito</b></td>"
            '    _BufferTotale &= "</tr>"
            '    For Each singMese As MeseDisponibile In RisultatoMesi
            '        _BufferTotale &= "<tr>"
            '        _BufferTotale &= "<td>" & singMese.AnnoRif & " " & FormerLib.FormerHelper.Calendario.MeseToString(singMese.MeseRif) & "</td>"
            '        _BufferTotale &= "<td align=right>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(singMese.Fatturato) & "</td>"
            '        _BufferTotale &= "<td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(singMese.NumeroOrdini) & "</td>"
            '        _BufferTotale &= "<td align=right>" & singMese.NumeroRegistrazioniDalSito & "</td>"
            '        _BufferTotale &= "</tr>"
            '    Next
            '    _BufferTotale &= "</table></td>"

            '    _BufferTotale &= "<td valign=top>"
            '    _BufferTotale &= "<h1>Statistiche</h1>"

            '    Dim totClienti As Integer = 0
            '    Dim totClientiSito As Integer = 0
            '    Dim totClientiSitoOrd As Integer = 0
            '    Dim totClientiGest As Integer = 0
            '    Dim totClientiGestOrd As Integer = 0
            '    Dim totClientiPre As Integer = 0
            '    Dim totClientiPreOrd As Integer = 0
            '    Using mgr As New VociRubricaDAO
            '        Dim l As List(Of VoceRubrica) = mgr.GetAll()

            '        totClienti = l.Count
            '        Dim lSito As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente = "W")
            '        Dim lGest As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente = "G" Or x.Sorgente = "F")
            '        Dim lPre As List(Of VoceRubrica) = l.FindAll(Function(x) x.Sorgente <> "W" And x.Sorgente <> "G" And x.Sorgente <> "F")
            '        totClientiSito = lSito.Count
            '        totClientiSitoOrd = lSito.FindAll(Function(y) y.Ordini.Count > 0).Count
            '        totClientiGest = lGest.Count
            '        totClientiGestOrd = lGest.FindAll(Function(y) y.Ordini.Count > 0).Count
            '        totClientiPre = lPre.Count
            '        totClientiPreOrd = lPre.FindAll(Function(y) y.Ordini.Count > 0).Count
            '    End Using

            '    _BufferTotale &= "<h2>Clienti</h2>"
            '    _BufferTotale &= "<table class=""statClienti"" border=1 >"
            '    _BufferTotale &= "<tr><td>Numero Clienti</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClienti) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Registrati dal sito</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiSito) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Registrati dal sito che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiSitoOrd) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Registrati dal gestionale</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiGest) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Registrati dal gestionale che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiGestOrd) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Pre-esistenti</td align=right><td>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiPre) & "</td></tr>"
            '    _BufferTotale &= "<tr><td><i>Pre-esistenti che hanno fatto almeno un ordine</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totClientiPreOrd) & "</td></tr>"
            '    _BufferTotale &= "</table>"

            '    _BufferTotale &= "</td>"
            'End If

            'buffer &= _BufferTotale



            Dim L As New List(Of MeseDisponibile)
            Dim DataRif As Date
            For i As Integer = 0 To 3
                DataRif = Now.AddMonths(-i)

                Dim mese As New MeseDisponibile
                mese.AnnoRif = DataRif.Year
                mese.MeseRif = DataRif.Month
                L.Add(mese)
            Next

            DataRif = Now.AddMonths(-12)

            Dim meseConf As New MeseDisponibile
            meseConf.AnnoRif = DataRif.Year
            meseConf.MeseRif = DataRif.Month
            L.Add(meseConf)

            For Each MeseScelto As MeseDisponibile In L
                buffer &= "<td valign=top>"
                buffer &= "<h1>" & MeseScelto.Riassunto & "</h1>"

                Dim ListaOrdini As List(Of OrdineRicerca) = Nothing

                Dim DataStart As New Date(MeseScelto.AnnoRif, MeseScelto.MeseRif, 1)
                Dim DataEnd As Date = DataStart.AddMonths(1).AddDays(-1)

                Using mgr As New OrdiniDAO

                    Dim ListaStati As String = enStatoOrdine.Preinserito

                    ListaStati &= "," & enStatoOrdine.Registrato
                    ListaStati &= "," & enStatoOrdine.RefineAutomatico
                    'ListaStati &= "," & enStatoOrdine.InSospeso
                    ListaStati &= "," & enStatoOrdine.InCodaDiStampa
                    ListaStati &= "," & enStatoOrdine.StampaInizio
                    ListaStati &= "," & enStatoOrdine.StampaFine
                    ListaStati &= "," & enStatoOrdine.FinituraCommessaInizio
                    ListaStati &= "," & enStatoOrdine.FinituraCommessaFine
                    ListaStati &= "," & enStatoOrdine.FinituraProdottoInizio
                    ListaStati &= "," & enStatoOrdine.FinituraProdottoFine
                    ListaStati &= "," & enStatoOrdine.Imballaggio
                    ListaStati &= "," & enStatoOrdine.ImballaggioCorriere
                    ListaStati &= "," & enStatoOrdine.ProntoRitiro
                    ListaStati &= "," & enStatoOrdine.UscitoMagazzino
                    ListaStati &= "," & enStatoOrdine.InConsegna
                    ListaStati &= "," & enStatoOrdine.Consegnato
                    ListaStati &= "," & enStatoOrdine.PagatoAcconto
                    ListaStati &= "," & enStatoOrdine.PagatoInteramente

                    ListaOrdini = mgr.Lista(, ListaStati,,,,,,, DataStart, DataEnd)

                End Using

                'qui devo integrare quelli archiviati
                Dim ToTOrdiniArchiviati As Integer = 0
                Using mgr As New ArchiviDAO
                    Dim lO As List(Of Archiviato) = mgr.Lista(DataStart, DataEnd)

                    For Each singO In lO
                        Dim Oric As New OrdineRicerca(singO)
                        ListaOrdini.Add(Oric)
                    Next
                    ToTOrdiniArchiviati = lO.Count
                End Using


                Dim ToTOrdini As Integer = ListaOrdini.Count

                Dim totOrdiniDaNuovi As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente = "W").Count
                Dim totOrdiniDaGest As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente = "G").Count
                Dim totOrdiniDaVecchi As Integer = ListaOrdini.FindAll(Function(x) x.SorgenteCliente <> "W" And x.SorgenteCliente <> "G").Count

                Dim totOrdiniCoupon As Integer = ListaOrdini.FindAll(Function(x) x.IdCoupon <> 0).Count
                Dim totOrdiniPromo As Integer = ListaOrdini.FindAll(Function(x) x.IdPromo <> 0).Count

                Dim PercNuovi As Integer = Math.Round((totOrdiniDaNuovi * 100) / ToTOrdini)
                Dim PercGest As Integer = Math.Round((totOrdiniDaGest * 100) / ToTOrdini)
                Dim PercVecchi As Integer = Math.Round((totOrdiniDaVecchi * 100) / ToTOrdini)
                Dim TotaleImponibile As Decimal = ListaOrdini.Sum(Function(x) x.TotaleImponibile)

                Dim TotaleImponibilePrevisto As Decimal = 0
                Dim StipendioCalcolato As Decimal = 0
                Dim StipendioPrevisto As Decimal = 0
                Dim LimiteMinimo As Decimal = 2500
                Dim Scarto As Decimal = 0
                Dim ScartoPrevisto As Decimal = 0

                StipendioCalcolato = TotaleImponibile * 3 / 100

                Scarto = StipendioCalcolato - LimiteMinimo
                If Scarto < 0 Then Scarto = 0

                If MeseScelto.MeseRif = Now.Month And MeseScelto.AnnoRif = Now.Year Then

                    Try
                        Dim UpperMese As Integer = DateTime.DaysInMonth(MeseScelto.AnnoRif, MeseScelto.MeseRif)

                        TotaleImponibilePrevisto = UpperMese * TotaleImponibile / Now.Day

                        StipendioPrevisto = (TotaleImponibilePrevisto * 3 / 100)
                        ScartoPrevisto = StipendioPrevisto - LimiteMinimo
                        If ScartoPrevisto < 0 Then ScartoPrevisto = 0

                    Catch ex As Exception

                    End Try

                End If

                buffer &= "<h2>Ordini</h2>"
                buffer &= "<table class=""statOrdini"" border=1 >"
                buffer &= "<tr><td>Numero Ordini</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(ToTOrdini) & "</td></tr>"
                buffer &= "<tr><td>Totale Imponibile</td><td align=right><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleImponibile) & "</b></td></tr>"
                buffer &= "<tr><td>Stipendio Calcolato (3%)</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(StipendioCalcolato) & "</td></tr>"
                buffer &= "<tr><td>Delta</td><td align=right>" & IIf(Scarto, FormerLib.FormerHelper.Stringhe.FormattaPrezzo((Scarto)), "-") & "</td></tr>"
                buffer &= "<tr><td>Previsto Mensile</td><td align=right>" & IIf(TotaleImponibilePrevisto, FormerLib.FormerHelper.Stringhe.FormattaPrezzo((TotaleImponibilePrevisto)), "-") & "</td></tr>"
                buffer &= "<tr><td>Stipendio Previsto (3%)</td><td align=right>" & IIf(StipendioPrevisto, FormerLib.FormerHelper.Stringhe.FormattaPrezzo((StipendioPrevisto)), "-") & "</td></tr>"
                buffer &= "<tr><td>Delta Previsto</td><td align=right " & IIf(ScartoPrevisto, "style='background-color:green;color:white;'", "") & "><b>" & IIf(ScartoPrevisto, FormerLib.FormerHelper.Stringhe.FormattaPrezzo((ScartoPrevisto)), "-") & "</b></td></tr>"
                buffer &= "<tr><td><i>Inseriti da</i> Clienti registrati dal sito</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaNuovi) & " (" & PercNuovi & "%)</td></tr>"
                buffer &= "<tr><td><i>Inseriti da</i> Clienti registrati dal gestionale</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaGest) & " (" & PercGest & "%)</td></tr>"
                buffer &= "<tr><td><i>Inseriti da</i> Vecchi clienti della tipografia</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniDaVecchi) & " (" & PercVecchi & "%)</td></tr>"
                buffer &= "<tr><td><i>con Coupon</i></td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniCoupon) & "</td></tr>"
                buffer &= "<tr><td><i>con Promo</i></td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(totOrdiniPromo) & "</td></tr>"
                buffer &= "<tr><td><i>Archiviati</i></td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(ToTOrdiniArchiviati) & "</td></tr>"
                buffer &= "</table>"

                Dim lPrev As New List(Of RisultatoPreventivazione)
                Dim TotFatturato As Decimal = 0
                For Each O As Ordine In ListaOrdini
                    Dim IdListinoBase As Integer = O.IdListinoBase
                    Dim Pre As RisultatoPreventivazione = Nothing
                    If IdListinoBase Then
                        Pre = lPrev.Find(Function(x) x.IdPrev = O.ListinoBase.IdPrev)
                        If Pre Is Nothing Then
                            Pre = New RisultatoPreventivazione
                            Pre.Descrizione = O.ListinoBase.Preventivazione.Descrizione
                            Pre.IdPrev = O.ListinoBase.IdPrev
                            lPrev.Add(Pre)
                        End If
                    Else
                        Pre = lPrev.Find(Function(x) x.IdPrev = 0)
                        If Pre Is Nothing Then
                            Pre = New RisultatoPreventivazione
                            Pre.Descrizione = "Non specificato"
                            Pre.IdPrev = 0
                            lPrev.Add(Pre)
                        End If
                    End If
                    Pre.NumOrd += 1
                    Pre.Fatturato += O.TotaleImponibile
                    TotFatturato += O.TotaleImponibile
                Next
                lPrev.Sort(Function(x, y) y.Fatturato.CompareTo(x.Fatturato))

                buffer &= "<h2>Numero di Ordini per Prodotto</h2>"
                buffer &= "<table class=""statProd"" border=1 >"
                For Each P As RisultatoPreventivazione In lPrev
                    buffer &= "<tr><td>" & P.Descrizione & "</td><td align=right>" & FormerLib.FormerHelper.Stringhe.FormattaNumero(P.NumOrd) & "</td>"
                    buffer &= "<td align=right>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(P.Fatturato) & "</td>"
                    buffer &= "<td align=right>" & Math.Round((P.Fatturato * 100) / TotFatturato) & "%</td>"
                    buffer &= "</tr>"
                Next
                buffer &= "</table>"
                buffer &= "</td>"
            Next

            'Dim MeseScelto As MeseDisponibile = cmbMeseRif.SelectedItem

            buffer &= "</tr></table>"

            Dim PathRis As String = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

            Using w As New IO.StreamWriter(PathRis)

                w.Write(buffer)

            End Using

            webReport.Navigate(PathRis)
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nella creazione del report: " & ex.Message)
        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub webReport_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webReport.DocumentCompleted


    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        webReport.Print()
    End Sub

    Private Sub TabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabMain.SelectedIndexChanged
        'If TabMain.SelectedIndex = 9 Then
        '    brwTestWeb.Navigate("https://www.betagrafic.com/prodotto/yannis-small-espositore-da-terra-con-ripiani-e-divisorio/")



        'End If
    End Sub

    Private Sub brwTestWeb_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles brwTestWeb.DocumentCompleted
        'txtDebug.Text = brwTestWeb.Document.Body.InnerHtml
    End Sub
End Class

