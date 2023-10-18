#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports FormerLib.FormerEnum
Imports FormerDALSql

''' <summary>
'''Entity Class for table T_lavlog
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LavLog
    Inherits _LavLog
    Implements ILavoroOperatore, ICloneable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Interfaccia ILavoroOperatore"

    Public ReadOnly Property IdLavoro As Integer Implements ILavoroOperatore.IdLavoro
        Get
            Return Idlav
        End Get
    End Property

    Private ReadOnly Property ILavoroOperatore_IdLavLog As Integer Implements ILavoroOperatore.IdLavLog
        Get
            Return IdLavLog
        End Get
    End Property

    Public ReadOnly Property CopieStr As String Implements ILavoroOperatore.Copie
        Get
            Return Copie
        End Get
    End Property

    Public ReadOnly Property DataInserimentoStr As String Implements ILavoroOperatore.DataInserimentoStr
        Get
            Return DataStr
        End Get
    End Property

    Public ReadOnly Property DataInserimento As Date Implements ILavoroOperatore.DataInserimento
        Get
            Return DataRif
        End Get
    End Property

    Public ReadOnly Property FronteRetro As String Implements ILavoroOperatore.FronteRetro
        Get
            Return FrStr
        End Get
    End Property

    Public ReadOnly Property DataRiferimentoStr As String Implements ILavoroOperatore.DataRiferimentoStr
        Get
            Dim ris As String = DataRiferimentoOrdine.ToString("dd/MM/yyyy")
            Return ris
        End Get
    End Property

    Public ReadOnly Property DataRiferimentoOrdine As Date Implements ILavoroOperatore.DataRifOrdinamento
        Get
            Dim ris As Date = Date.MinValue
            Try
                If IdCom Then

                    'If CommessaRiferimento.Priorita = enSiNo.No Then
                    ris = CommessaRiferimento.DataPrimaConsegna
                    'End If
                Else
                    'If OrdineRiferimento.Priorita = enSiNo.No Then
                    ris = OrdineRiferimento.ConsegnaAssociata.DataPrevistaProduzione
                    'End If

                End If
            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoVoceLavLog As enTipoVoceOrdineCommessa Implements ILavoroOperatore.TipoLavLog
        Get
            Dim ris As enTipoVoceOrdineCommessa

            If IdCom Then
                ris = enTipoVoceOrdineCommessa.Commessa
            Else
                ris = enTipoVoceOrdineCommessa.Ordine
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IdCommessa As Integer Implements ILavoroOperatore.IdCommessa
        Get
            Return IdCom
        End Get
    End Property

    Public ReadOnly Property IdMacchinarioSel As Integer Implements ILavoroOperatore.IdMacchinario
        Get
            Return IdMacchinario
        End Get
    End Property

    Public ReadOnly Property RagSocNome As String Implements ILavoroOperatore.RagSocNome
        Get
            Dim ris As String = "-"
            If IdOrd Then
                ris = OrdineRiferimento.VoceRubrica.RagSocNome
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IdCommessaStr As String Implements ILavoroOperatore.IdCommessaStr
        Get
            Dim ris As String = "-"
            If IdCom Then
                ris = IdCom
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IdOrdine As Integer Implements ILavoroOperatore.IdOrdine
        Get
            Return IdOrd
        End Get
    End Property

    Public ReadOnly Property IdOrdineStr As String Implements ILavoroOperatore.IdOrdineStr
        Get
            Dim ris As String = "-"
            If IdOrd Then
                ris = IdOrd
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property InCaricoA As String Implements ILavoroOperatore.InCaricoA
        Get
            Return Utente.Login
        End Get
    End Property

    Public ReadOnly Property StatoAttuale As Integer Implements ILavoroOperatore.Stato
        Get
            Return Stato
        End Get
    End Property

    Public ReadOnly Property LavorazioneDescrizione As String Implements ILavoroOperatore.LavorazioneStr
        Get
            Return LavorazioneStr
        End Get
    End Property

    Public ReadOnly Property Priorita As String Implements ILavoroOperatore.Priorita
        Get
            Return PrioritaStr
        End Get
    End Property

    Public ReadOnly Property StatoAttualeStr As String Implements ILavoroOperatore.StatoStr
        Get
            Return StatoStr
        End Get
    End Property

    Public ReadOnly Property Tipo As String Implements ILavoroOperatore.Tipo
        Get
            Return TipoStr
        End Get
    End Property

    Public ReadOnly Property RisorsaInUsoStr As String Implements ILavoroOperatore.RisorsaStr
        Get
            Return RisorsaStr
        End Get
    End Property

    Public ReadOnly Property QtaRisorsaStr As String Implements ILavoroOperatore.QtaStr
        Get
            Return QtaStr
        End Get
    End Property

    Public ReadOnly Property NLastreStr As String Implements ILavoroOperatore.NLastreStr
        Get
            Return NLastre
        End Get
    End Property

    Public ReadOnly Property IdUtInCarico As Integer Implements ILavoroOperatore.IdUtInCarico
        Get
            Return IdUt
        End Get
    End Property

    Public ReadOnly Property IdUtForzato As Integer Implements ILavoroOperatore.IdUtForzato
        Get
            Return IdUtenteForzato
        End Get
    End Property

    Public ReadOnly Property DataOraInizioLavoro As Date Implements ILavoroOperatore.DataOraInizio
        Get
            Return DataOraInizio
        End Get
    End Property

    Public ReadOnly Property DataOraFineLavoro As Date Implements ILavoroOperatore.DataOraFine
        Get
            Return DataOraFine
        End Get
    End Property

    Public Function PrendibileInCarico(Optional IdUtenteConnesso As Integer = 0,
                                       Optional RicaricaTuttiIDati As Boolean = False) As Boolean Implements ILavoroOperatore.PrendibileInCarico
        Dim ris As Boolean = False
        Try
            If RicaricaTuttiIDati Then
                Read(IdLavLog)
            End If

            If IdUtenteConnesso = 0 Then
                IdUtenteConnesso = LUNA.LunaContext.UtenteConnesso.IdUt
            End If

            If DataOraFine <> Date.MinValue Then
                ris = False
            Else
                If IdUtenteConnesso <> 0 AndAlso (IdUtenteConnesso = IdUt And DataOraFine = Date.MinValue) Then
                    ris = True
                ElseIf IdUt <> 0 And DataOraFine = Date.MinValue Then
                    ris = False
                Else
                    'qui devo capire se un lavoro che ancora non e' assegnato posso prenderlo in carico o no
                    If IdCom Then
                        'lavoro su commessa
                        If CommessaRiferimento.Stato <> enStatoCommessa.Preinserito Then
                            Using mgr As New LavLogDAO
                                Dim l As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCom", IdCom),
                                                                       New LUNA.LunaSearchParameter("Ordine", Ordine, "<"),
                                                                       New LUNA.LunaSearchParameter("DataOraFine", Nothing, "IS"))
                                If l.FindAll(Function(x) x.Lavorazione.Categoria.TipoCaratteristica = enSiNo.No).Count = 0 Then
                                    ris = True
                                End If
                            End Using
                        End If

                    ElseIf IdOrd Then
                        'lavoro su ordine
                        'prima controllo che sia stato fatto tutto su commessa
                        If Not OrdineRiferimento Is Nothing AndAlso OrdineRiferimento.IdCom Then

                            Using mgrC As New LavLogDAO
                                Dim lC As List(Of LavLog) = mgrC.FindAll(New LUNA.LunaSearchParameter("IdCom", OrdineRiferimento.IdCom),
                                                                       New LUNA.LunaSearchParameter("DataOraFine", Nothing, "IS"))
                                If lC.FindAll(Function(x) x.Lavorazione.Categoria.TipoCaratteristica = enSiNo.No).Count = 0 Then
                                    Using mgr As New LavLogDAO
                                        Dim l As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrdine),
                                                                   New LUNA.LunaSearchParameter("Ordine", Ordine, "<"),
                                                                   New LUNA.LunaSearchParameter("DataOraFine", Nothing, "IS"))
                                        If l.FindAll(Function(x) x.Lavorazione.Categoria.TipoCaratteristica = enSiNo.No).Count = 0 Then
                                            ris = True
                                        End If
                                    End Using
                                End If
                            End Using
                            'Else
                            '    If OrdineRiferimento.IdTipoProd <> enRepartoWeb.StampaOffset Then
                            '        Using mgr As New LavLogDAO
                            '            Dim l As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrdine),
                            '                                       New LUNA.LunaSearchParameter("Ordine", Ordine, "<"),
                            '                                       New LUNA.LunaSearchParameter("DataOraFine", Nothing, "IS"))
                            '            If l.Count = 0 Then
                            '                ris = True
                            '            End If
                            '        End Using
                            '    End If
                        End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try


        Return ris

    End Function

#End Region

#Region "Logic Field"

    Public ReadOnly Property AnnotazioniOperatore As String Implements ILavoroOperatore.AnnotazioniOperatore
        Get
            Dim ris As String = String.Empty

            If IdCom Then
                ris = CommessaRiferimento.Annotazioni
            ElseIf IdOrd Then
                ris = OrdineRiferimento.Annotazioni
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgIcoLavoro As Image Implements ILavoroOperatore.ImgLavorazione
        Get
            'Dim ImgPreview As Image
            'Dim ImgNew As Image = Nothing
            'Try
            '    Dim Path As String = Lavorazione.ImgRif
            '    If FileIO.FileSystem.FileExists(Path) Then
            '        ImgPreview = Image.FromFile(Path)
            '    Else
            '        ImgPreview = My.Resources.no_image
            '    End If
            '    ImgNew = New Bitmap(ImgPreview, New Size(64, 64))
            'Catch ex As Exception
            '    ImgNew = Nothing
            'End Try
            'Return ImgNew
            'Return MacchinarioRif.Img

            If Idlav = FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
                Return MacchinarioRif.Img
            Else
                Return Lavorazione.Img
            End If

        End Get
    End Property

    Private _MacchinarioRif As Macchinario = Nothing
    Public ReadOnly Property MacchinarioRif As Macchinario
        Get
            If _MacchinarioRif Is Nothing Then
                _MacchinarioRif = New Macchinario
                If IdMacchinario Then
                    _MacchinarioRif.Read(IdMacchinario)
                End If
            End If
            Return _MacchinarioRif
        End Get
    End Property

    Private IcoSegnalinoCercata As Boolean = False
    Private _ImgIcoSegnalino As Image = Nothing
    Public ReadOnly Property IcoSegnalino As Image Implements ILavoroOperatore.IcoSegnalino
        Get

            If IcoSegnalinoCercata = False Then
                Try
                    IcoSegnalinoCercata = True
                    If IdLavoro = FormerLib.FormerConst.Lavorazioni.Taglio Then

                        If IdCom Then
                            If CommessaRiferimento.IdReparto = enRepartoWeb.StampaOffset Or CommessaRiferimento.IdReparto = enRepartoWeb.Packaging Then
                                CommessaRiferimento.ModelloCommessa.CaricaFormatiCarta()
                                Dim FormatiTrovati As Integer = CommessaRiferimento.ModelloCommessa.FormatiCarta.Count

                                Dim IsUltimoLavoro As Boolean = True

                                If CommessaRiferimento.ListaLavorazioni.Last.IdLavoro <> IdLavoro Then
                                    IsUltimoLavoro = False
                                Else

                                    For Each O As Ordine In CommessaRiferimento.ListaOrdini
                                        If O.ListLavLog.Count Then
                                            IsUltimoLavoro = False
                                            Exit For
                                        End If

                                    Next


                                End If

                                If FormatiTrovati = 1 AndAlso IsUltimoLavoro = True Then
                                    _ImgIcoSegnalino = My.Resources.IcoFlagGreen
                                ElseIf FormatiTrovati = 1 Then
                                    _ImgIcoSegnalino = My.Resources.IcoFlagOrange
                                ElseIf IsUltimoLavoro = True Then
                                    _ImgIcoSegnalino = My.Resources.IcoFlagYellow
                                Else
                                    _ImgIcoSegnalino = My.Resources.IcoFlagRed
                                End If
                            End If
                        End If
                    End If

                Catch ex As Exception

                End Try
            End If

            If _ImgIcoSegnalino Is Nothing Then _ImgIcoSegnalino = New Bitmap(24, 24)

            Return _ImgIcoSegnalino
        End Get
    End Property

    Public ReadOnly Property ImgMacchinario As Image Implements ILavoroOperatore.ImgMacchinario
        Get
            'Dim ImgPreview As Image
            'Dim ImgNew As Image = Nothing
            'Try
            '    Dim Path As String = Lavorazione.ImgRif
            '    If FileIO.FileSystem.FileExists(Path) Then
            '        ImgPreview = Image.FromFile(Path)
            '    Else
            '        ImgPreview = My.Resources.no_image
            '    End If
            '    ImgNew = New Bitmap(ImgPreview, New Size(64, 64))
            'Catch ex As Exception
            '    ImgNew = Nothing
            'End Try
            'Return ImgNew
            Return MacchinarioRif.Img
        End Get
    End Property

    Public ReadOnly Property IcoMsg As Image Implements ILavoroOperatore.IcoMsg
        Get
            If NumeroMessaggi Then
                Return My.Resources.attach
            Else
                Return My.Resources.blank
            End If

        End Get
    End Property

    Public ReadOnly Property ImgAnteprima As Image Implements ILavoroOperatore.ImgAnteprima
        Get
            If IdCom Then
                Return CommessaRiferimento.ImgAnteprima
            ElseIf IdOrd Then
                Return OrdineRiferimento.ImgAnteprima
            End If
        End Get
    End Property

    Public ReadOnly Property NumeroMessaggi As Integer
        Get
            Dim ris As Integer = 0
            If IdCom Then
                ris = CommessaRiferimento.NumeroMessaggi
            ElseIf IdOrd Then
                ris = OrdineRiferimento.NumeroMessaggi
            End If
            Return ris
        End Get
    End Property

    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                If IdUt Then
                    _Utente.Read(IdUt)
                End If
            End If
            Return _Utente
        End Get
    End Property

    Private _Lavorazione As Lavorazione = Nothing
    Public ReadOnly Property Lavorazione As Lavorazione
        Get
            If _Lavorazione Is Nothing Then
                _Lavorazione = New Lavorazione
                _Lavorazione.Read(Idlav)
            End If
            Return _Lavorazione
        End Get
    End Property

    Public ReadOnly Property LavorazioneStr As String
        Get
            Return Descrizione
        End Get
    End Property

    Public ReadOnly Property DataRif As Date
        Get
            Dim ris As Date = Date.MinValue

            If IdCom Then
                ris = CommessaRiferimento.DataIns.Date
            ElseIf IdOrd Then
                ris = OrdineRiferimento.DataIns.Date
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataStr As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.DataIns.ToString("dd/MM/yy")
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.DataIns.ToString("dd/MM/yy")
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property PrioritaStr As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.PrioritaStr
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.PrioritaStr
                End If
            Catch ex As Exception

            End Try

            Return Ris

        End Get
    End Property

    Public ReadOnly Property TipoStr As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.TipoCommessaStr
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.Prodotto.Descrizione
                End If
            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property RisorsaStr As String
        Get
            Dim ris As String = ""
            Try
                If IdCom Then
                    ris = CommessaRiferimento.RisorsaStr
                ElseIf IdOrd Then
                    ris = "-"
                End If

            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property QtaStr As String
        Get
            Dim ris As String = ""
            Try
                If IdCom Then
                    ris = CommessaRiferimento.QtaStr
                ElseIf IdOrd Then
                    ris = "-"
                End If

            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property FrStr As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.FrStr
                ElseIf IdOrd Then
                    Ris = "F"
                End If

            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Copie As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.CopieStr
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.Qta
                End If

            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim Ris As String = ""
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.StatoStr
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.StatoStr
                End If

            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Stato As Integer
        Get
            Dim Ris As Integer = 0
            Try
                If IdCom Then
                    Ris = CommessaRiferimento.Stato
                ElseIf IdOrd Then
                    Ris = OrdineRiferimento.Stato
                End If

            Catch ex As Exception

            End Try
            Return Ris
        End Get
    End Property

    Public ReadOnly Property AttualmenteInLavorazione As Boolean
        Get
            Dim ris As Boolean = False

            If DataOraInizio <> Date.MinValue And DataOraFine = Date.MinValue Then
                ris = True
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property OrdinamentoOperatoreTipoConsegna As Integer
        Get
            Dim ris As Integer = 0
            If IdOrd Then
                If OrdineRiferimento.TipoConsegna = enTipoConsegna.Normale Then
                    ris = 2
                ElseIf OrdineRiferimento.TipoConsegna = enTipoConsegna.Fast Then
                    ris = 3
                ElseIf OrdineRiferimento.TipoConsegna = enTipoConsegna.Slow Then
                    ris = 1
                End If
            End If
            Return ris
        End Get
    End Property

    Private _OrdineRif As OrdineOperatore
    Public ReadOnly Property OrdineRiferimento(Optional ByVal ForceLoad As Boolean = False) As OrdineOperatore
        Get
            If IdOrd And (_OrdineRif Is Nothing Or ForceLoad = True) Then

                Using Mgr As New OrdiniDAO
                    _OrdineRif = Mgr.ReadOperatore(IdOrd)
                End Using

            End If
            Return _OrdineRif
        End Get
    End Property

    Private _Commessa As CommessaOperatore
    Public ReadOnly Property CommessaRiferimento(Optional ByVal ForceLoad As Boolean = False) As CommessaOperatore
        Get
            If IdCom And (_Commessa Is Nothing Or ForceLoad = True) Then
                Using Mgr As New CommesseDAO
                    _Commessa = Mgr.ReadOperatore(IdCom)
                End Using
            End If
            Return _Commessa
        End Get
    End Property

    Public ReadOnly Property NLastre As String
        Get
            Dim ris As String = "-"

            If IdCom Then
                ris = CommessaRiferimento.NLastreNecessarie
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PrendibileDa As String
        Get
            Dim ris As String = String.Empty

            If IdMacchinario Then
                Dim LUt As New List(Of Utente)
                Using mgr As New UtMacDAO
                    Dim l As List(Of UtMac) = mgr.FindAll(New LUNA.LunaSearchParameter("IdMac", IdMacchinario))
                    For Each singUM As UtMac In l
                        Dim u As New Utente
                        u.Read(singUM.IdUt)
                        LUt.Add(u)
                    Next
                End Using
                LUt.Sort(Function(x, y) x.Login.CompareTo(y.Login))

                For Each Ut As Utente In LUt
                    ris &= Ut.Login & ", "
                Next
                ris = ris.TrimEnd(" ", ",")
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

#End Region

End Class
