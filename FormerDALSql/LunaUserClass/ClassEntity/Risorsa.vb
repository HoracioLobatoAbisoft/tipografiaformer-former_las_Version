#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports FormerLib
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_risorse
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Risorsa
    Inherits _Risorsa
    Implements IRisorsa, IVoceComboConImmagine

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public ReadOnly Property Lunghezzamm As Integer
        Get
            Return Lunghezza * 10
        End Get
    End Property

    Public ReadOnly Property Larghezzamm As Integer
        Get
            Return Larghezza * 10
        End Get
    End Property

    Public ReadOnly Property UltimoCaricoMagazzinoDate As Date
        Get
            Dim ris As Date = Date.MinValue
            If Not UltimoCaricoMagazzino Is Nothing Then
                ris = UltimoCaricoMagazzino.DataMov
            End If
            Return ris
        End Get
    End Property

    Private _TipoAListino As String = String.Empty
    Public ReadOnly Property TipoAListino As String
        Get
            If _TipoAListino = String.Empty Then
                If Not TipoCarta Is Nothing Then
                    _TipoAListino = TipoCarta.Tipologia
                Else
                    _TipoAListino = "-"
                End If
            End If

            Return _TipoAListino
        End Get
    End Property

    Public ReadOnly Property VoceComboIdRis As Integer Implements IVoceComboConImmagine.Id
        Get
            Return IdRis
        End Get
    End Property

    Public ReadOnly Property VoceComboText As String Implements IVoceComboConImmagine.Text
        Get
            Return Descrizione
        End Get
    End Property

    Public ReadOnly Property VoceComboDescrizione As String Implements IVoceComboConImmagine.Description
        Get
            Dim Ris As String = String.Empty
            If IdTipoCarta Then
                Ris = TipoCarta.Tipologia
            Else
                Ris = "-"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property UltimoCaricoMagazzinoStr As String
        Get
            Dim ris As String = String.Empty
            If Not UltimoCaricoMagazzino Is Nothing Then
                ris = UltimoCaricoMagazzino.DataMov.ToString("dd/MM/yyyy")
            Else
                ris = "-"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property UltimoScaricoMagazzinoStr As String
        Get
            Dim ris As String = String.Empty
            If Not UltimoScaricoMagazzino Is Nothing Then
                ris = UltimoScaricoMagazzino.DataMov.ToString("dd/MM/yyyy")
            Else
                ris = "-"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property GruppiStr As String
        Get
            Dim ris As String = String.Empty

            For Each g In Gruppi
                ris &= g.NomeGruppo & ControlChars.NewLine
            Next

            If ris.Length = 0 Then ris = "-"

            Return ris
        End Get
    End Property

    Public ReadOnly Property Gruppi As List(Of RisorsaInGruppo)
        Get
            Dim l As List(Of RisorsaInGruppo) = Nothing

            Using mgr As New RisorsaInGruppoDAO
                l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.RisorsaInGruppo.IdRisorsa, IdRis))
            End Using

            Return l
        End Get
    End Property

    Public ReadOnly Property UltimoMovimentoStr As String
        Get
            Dim _Ris As String = String.Empty
            If Not UltimoMovimentoMagazzino Is Nothing Then
                _Ris = UltimoMovimentoMagazzino.TipoStr
            End If
            Return _Ris
        End Get
    End Property

    Public ReadOnly Property DataUltimoCarico As Date
        Get
            Return UltimoCaricoMagazzinoDate
        End Get
    End Property


    Public ReadOnly Property DataUltimoMov As String
        Get
            Dim _Ris As String = String.Empty
            If Not UltimoMovimentoMagazzino Is Nothing Then
                _Ris = UltimoMovimentoMagazzino.DataMov.ToString("dd/MM/yyyy")
            End If

            Return _Ris
        End Get
    End Property

    Public ReadOnly Property ImageRif As Image Implements IVoceComboConImmagine.Image
        Get
            Dim ris As Image = Nothing
            If imgPath.Length Then
                If File.Exists(imgPath) Then
                    Try
                        ris = Image.FromFile(imgPath)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image
            End If
            Return ris
        End Get
    End Property

    Private _TipoCarta As TipoCarta = Nothing
    Public ReadOnly Property TipoCarta As TipoCarta
        Get
            If _TipoCarta Is Nothing Then
                _TipoCarta = New TipoCarta
                If IdTipoCarta Then

                    _TipoCarta.Read(IdTipoCarta)
                End If

            End If
            Return _TipoCarta
        End Get
    End Property

    Public ReadOnly Property TipologiaStr As String
        Get
            Dim ris As String = String.Empty

            If TipoRis = enTipoProdCom.Consumo Then

                If Categoria.Length Then
                    ris = Categoria
                Else
                    ris = "Materiale di Consumo"
                End If

            Else

                If IsLastra Then
                    ris = "Lastra"
                Else
                    ris = "Materia Prima"
                End If

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim ris As String = FormerEnumHelper.StatoString(Stato)
            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaCarichi As List(Of MovimentoMagazzino)
        Get
            Dim ris As List(Of MovimentoMagazzino) = Nothing

            Using mgr As New MagazzinoDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.MovimentoMagazzino.DataMov.Name & " DESC"},
                                  New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico),
                                  New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis)) ',
                ' New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdFat, 0, "<>"))
            End Using

            Return ris
        End Get
    End Property


    Public ReadOnly Property GetPrezzoMedioKgUltimoAnno As Decimal
        Get
            Dim ris As Decimal = 0
            Dim lista As New List(Of Decimal)
            Using mgr As New MagazzinoDAO
                Dim l As List(Of MovimentoMagazzino)

                Dim ParamLastYear As LUNA.LunaSearchParameter = New LUNA.LunaSearchParameter("datediff(""d"",DataMov,GetDate())", 365, "<=")

                l = mgr.FindAll(ParamLastYear,
                                New LUNA.LunaSearchParameter("IdRis", IdRis),
                                New LUNA.LunaSearchParameter("TipoMov", "(" & enTipoMovMagaz.Carico & "," & enTipoMovMagaz.Inserimento & ")", " IN "))

                For Each singMov As MovimentoMagazzino In l
                    Dim PalKg As Decimal = singMov.PrezzoAlKg
                    If PalKg Then lista.Add(PalKg)
                Next

                If lista.Count Then
                    For Each singVal As Decimal In lista
                        ris += singVal
                    Next

                    ris = ris / lista.Count

                End If

            End Using

            Return ris
        End Get
    End Property

    Public Function GetScartoCM2RispettoModelloCommessa(M As ModelloCommessa) As Integer

        Dim ris As Integer = 0
        Try
            'qui vedo quanti ne entrano nel formato poi moltiplico l'area del formato per la quantita e vedo lo scarto con l'area della risorsa

            Dim AreaRisorsa As Integer = Larghezza * Lunghezza

            Dim Quanti As Integer = QuantiNeEntranoInFormatoMacchina(M.FormatoMacchina)

            Dim AreaFormatoMacchina As Integer = M.FormatoMacchina.Larghezza * M.FormatoMacchina.Altezza
            Dim AreaOccupata As Integer = AreaFormatoMacchina * Quanti

            ris = AreaRisorsa - AreaOccupata
        Catch ex As Exception

        End Try

        Return ris

    End Function

    Public Function QuantiNeEntranoInFormatoMacchina(fm As Formato) As Integer

        Dim Ris As Integer = 0

        If fm.LatoLungo <= LatoLungo AndAlso fm.LatoCorto <= LatoCorto Then
            'li monto in entrambi i versi e vedo in quale ce ne entrano di piu
            Dim QtaCalcolata As Integer = 0

            Dim QtaOrizzontale As Integer = 0
            Dim QtaVerticale As Integer = 0

            If fm.LatoCorto = fm.LatoLungo Then
                QtaOrizzontale = Math.Floor(LatoLungo / fm.LatoLungo)
                QtaVerticale = Math.Floor(LatoCorto / fm.LatoCorto)

                QtaCalcolata = QtaOrizzontale * QtaVerticale
            Else

                Dim QtaCalcolataV As Integer = 0
                Dim QtaCalcolataO As Integer = 0

                QtaOrizzontale = Math.Floor(LatoLungo / fm.LatoLungo)
                QtaVerticale = Math.Floor(LatoCorto / fm.LatoCorto)

                If QtaOrizzontale >= 1 And QtaVerticale >= 1 Then QtaCalcolataO = QtaOrizzontale * QtaVerticale

                QtaOrizzontale = Math.Floor(LatoLungo / fm.LatoCorto)
                QtaVerticale = Math.Floor(LatoCorto / fm.LatoLungo)

                If QtaOrizzontale >= 1 And QtaVerticale >= 1 Then QtaCalcolataV = QtaOrizzontale * QtaVerticale

                If QtaCalcolataO > QtaCalcolataV Then
                    QtaCalcolata = QtaCalcolataO
                Else
                    QtaCalcolata = QtaCalcolataV
                End If

            End If

            Ris = QtaCalcolata

        End If

        Return Ris
    End Function

    Private _ListaMacchinari As List(Of RisorsaSuMacchina) = Nothing
    Public ReadOnly Property ListaMacchinari As List(Of RisorsaSuMacchina)
        Get
            If _ListaMacchinari Is Nothing Then
                Using mgr As New RisorseSuMacchinaDAO
                    _ListaMacchinari = mgr.FindAll(New LUNA.LunaSearchParameter("IdRisorsa", IdRis))
                End Using
            End If
            Return _ListaMacchinari
        End Get
    End Property

    Private _RegolaSottoScorta As AzioneSottoscorta = Nothing
    Public ReadOnly Property RegolaSottoScorta As AzioneSottoscorta
        Get
            If _RegolaSottoScorta Is Nothing Then

                Using mgr As New AzioniSottoscortaDAO
                    _RegolaSottoScorta = mgr.Find(New LUNA.LunaSearchParameter("IdRisorsa", _IdRis))
                End Using

            End If

            Return _RegolaSottoScorta

        End Get
    End Property

    Public ReadOnly Property CodiceStr As String
        Get
            Dim ris As String = String.Empty

            If Codice.Length Then
                ris = Codice
            Else
                ris = "-"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property RegolaSottoScortaStr As String
        Get
            Dim ris As String = String.Empty

            If Not RegolaSottoScorta Is Nothing Then
                If RegolaSottoScorta.Azione = enAzioneSottoScorta.RichiestaDiAcquisto Then
                    ris = "Richiesta di acquisto"
                ElseIf RegolaSottoScorta.Azione = enAzioneSottoScorta.RiOrdina Then
                    ris = "Riordina"
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoRisStr As String
        Get
            Dim ris As String = TipologiaStr 'String.Empty

            'If IsLastra = True Then
            '    ris = "Lastra"
            'Else
            '    ris = "Materia Prima"
            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ProdottoRifStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerLib.FormerEnum.FormerEnumHelper.TipoProdComStr(TipoRis)

            Return ris
        End Get
    End Property

    Public ReadOnly Property LatoLungo As Integer
        Get
            Dim ris As Integer = 0
            If Larghezza > Lunghezza Then
                ris = Larghezza
            ElseIf Larghezza < Lunghezza Then
                ris = Lunghezza
            Else
                ris = Lunghezza
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property LatoCorto As Integer
        Get
            Dim ris As Integer = 0
            If Larghezza < Lunghezza Then
                ris = Larghezza
            ElseIf Larghezza > Lunghezza Then
                ris = Lunghezza
            Else
                ris = Lunghezza
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrizioneWithId As String
        Get
            Dim ris As String = "(" & IdRis & ") " & Descrizione

            Return ris
        End Get
    End Property


    Public ReadOnly Property Riassunto As String
        Get

            Dim ris As String = IIf(Codice.Length, "(" & Codice & ") ", String.Empty) & Descrizione
            Return ris

        End Get
    End Property

    Public ReadOnly Property RiassuntoTipoCarta As String
        Get

            Dim ris As String = TipoCarta.Tipologia
            Return ris

        End Get
    End Property

    Private _UltimaRichiestaAcquistoInevasa As MovimentoMagazzino = Nothing
    Public ReadOnly Property UltimaRichiestaAcquistoInevasa As MovimentoMagazzino
        Get
            If _UltimaRichiestaAcquistoInevasa Is Nothing Then

                Using mgr As New MagazzinoDAO

                    Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataMov Desc", .Top = 1},
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis),
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0),
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.RichiestaAcquisto))

                    If l.Count Then
                        _UltimaRichiestaAcquistoInevasa = l(0)
                    End If

                End Using

            End If
            Return _UltimaRichiestaAcquistoInevasa
        End Get
    End Property

    Private _UltimoScaricoMagazzino As MovimentoMagazzino = Nothing
    Public ReadOnly Property UltimoScaricoMagazzino As MovimentoMagazzino
        Get
            If _UltimoScaricoMagazzino Is Nothing Then

                Using mgr As New MagazzinoDAO

                    Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataMov Desc", .Top = 1},
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis),
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Scarico))

                    If l.Count Then
                        _UltimoScaricoMagazzino = l(0)
                    End If

                End Using

            End If
            Return _UltimoScaricoMagazzino
        End Get
    End Property

    Private _UltimoCaricoMagazzino As MovimentoMagazzino = Nothing
    Public ReadOnly Property UltimoCaricoMagazzino As MovimentoMagazzino
        Get
            If _UltimoCaricoMagazzino Is Nothing Then

                Using mgr As New MagazzinoDAO

                    Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataMov Desc", .Top = 1},
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis),
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Carico))

                    If l.Count Then
                        _UltimoCaricoMagazzino = l(0)
                    End If

                End Using

            End If
            Return _UltimoCaricoMagazzino
        End Get
    End Property

    Private _UltimoMovimento As MovimentoMagazzino = Nothing

    Public ReadOnly Property UltimoMovimentoMagazzino As MovimentoMagazzino
        Get
            If _UltimoMovimento Is Nothing Then

                Using mgr As New MagazzinoDAO

                    Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataMov Desc", .Top = 1},
                                                                        New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis))

                    If l.Count Then
                        _UltimoMovimento = l(0)
                    End If

                End Using

            End If
            Return _UltimoMovimento
        End Get
    End Property


    Public ReadOnly Property FornitoreStr As String
        Get
            Dim ris As String = "-"

            If Not UltimoCaricoMagazzino Is Nothing Then

                If UltimoCaricoMagazzino.IdForn Then
                    Using R As New VoceRubrica
                        R.Read(UltimoCaricoMagazzino.IdForn)
                        ris = R.RagSocNome
                    End Using
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property UltimoPrezzoStr As String
        Get
            Dim ris As String = "-"

            If Not UltimoCaricoMagazzino Is Nothing Then

                ris = UltimoCaricoMagazzino.Qta & "pz. - €" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(UltimoCaricoMagazzino.Prezzo) & ControlChars.NewLine

                If UltimoCaricoMagazzino.PrezzoUnit Then
                    ris &= "Unitario " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(UltimoCaricoMagazzino.PrezzoUnit) & ControlChars.NewLine
                End If

                If UltimoCaricoMagazzino.PrezzoAlKg Then
                    ris &= "Al kg" & UltimoCaricoMagazzino.PrezzoAlKgStr
                End If

            End If

            Return ris
        End Get
    End Property



#End Region


#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IRisorsa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        'If IdTipoCarta = 0 Then Ris = False
        If Descrizione.Length = 0 Then
            Ris = False
        End If

        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IRisorsa.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Refresh() As Integer
        Dim Ris As Integer = MyBase.Refresh()

        _TipoAListino = String.Empty
        _TipoCarta = Nothing
        _ListaMacchinari = Nothing
        _RegolaSottoScorta = Nothing
        _UltimaRichiestaAcquistoInevasa = Nothing
        _UltimoScaricoMagazzino = Nothing
        _UltimoCaricoMagazzino = Nothing
        _UltimoMovimento = Nothing

        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IRisorsa.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

Public Class RisorsaRicerca
    Inherits Risorsa

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


    Public Property Selezionata As Boolean = False

End Class

''' <summary>
'''Interface for table T_risorse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IRisorsa
    Inherits _IRisorsa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface