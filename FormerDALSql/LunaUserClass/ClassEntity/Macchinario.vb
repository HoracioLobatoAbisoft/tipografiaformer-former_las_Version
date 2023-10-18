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
Imports System.Drawing
Imports System.IO
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports FormerLib

''' <summary>
'''Entity Class for table T_macchinari
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Macchinario
    Inherits _Macchinario
    Implements IMacchinario
    Implements IMacchinarioB
    Implements IVoceComboConImmagine

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdMacchinario() As Integer Implements IMacchinarioB.IdMacchinario, IVoceComboConImmagine.Id
        Get
            Return MyBase.IdMacchinario
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String Implements IMacchinarioB.Descrizione, IVoceComboConImmagine.Text
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property

    Public Overrides Property IdRepartoDefault() As Integer Implements IMacchinarioB.IdRepartoDefault
        Get
            Return MyBase.IdRepartoDefault
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRepartoDefault = value
        End Set
    End Property

    Public Overrides Property Tipo() As Integer Implements IMacchinarioB.Tipo
        Get
            Return MyBase.Tipo
        End Get
        Set(ByVal value As Integer)
            MyBase.Tipo = value
        End Set
    End Property


    Public Overrides Property CostoMinAvv() As Decimal Implements IMacchinarioB.CostoMinAvv
        Get
            Return MyBase.CostoMinAvv
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoMinAvv = value
        End Set
    End Property


    Public Overrides Property CostoSingCopia() As Decimal Implements IMacchinarioB.CostoSingCopia
        Get
            Return MyBase.CostoSingCopia
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoSingCopia = value
        End Set
    End Property


    Public Overrides Property CostoMensile() As Integer Implements IMacchinarioB.CostoMensile
        Get
            Return MyBase.CostoMensile
        End Get
        Set(ByVal value As Integer)
            MyBase.CostoMensile = value
        End Set
    End Property


    Public Overrides Property CaricoPrevistoMensile() As Integer Implements IMacchinarioB.CaricoPrevistoMensile
        Get
            Return MyBase.CaricoPrevistoMensile
        End Get
        Set(ByVal value As Integer)
            MyBase.CaricoPrevistoMensile = value
        End Set
    End Property


    Public Overrides Property MinutiAvv() As Integer Implements IMacchinarioB.MinutiAvv
        Get
            Return MyBase.MinutiAvv
        End Get
        Set(ByVal value As Integer)
            MyBase.MinutiAvv = value
        End Set
    End Property


    Public Overrides Property CopieOra() As Integer Implements IMacchinarioB.CopieOra
        Get
            Return MyBase.CopieOra
        End Get
        Set(ByVal value As Integer)
            MyBase.CopieOra = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements IMacchinarioB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property AltezzaCaricoCm() As Integer Implements IMacchinarioB.AltezzaCaricoCm
        Get
            Return MyBase.AltezzaCaricoCm
        End Get
        Set(ByVal value As Integer)
            MyBase.AltezzaCaricoCm = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property RepartoDefaultStr As String
        Get
            Dim ris As String = String.Empty

            If IdRepartoDefault Then
                ris = FormerEnumHelper.RepartoStr(IdRepartoDefault)
            Else
                ris = "Nessuno"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty
            ris = TipoStr & " - " & _Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto(SenzaAvviamento As Boolean) As String
        Get
            Dim ris As String = String.Empty
            ris = TipoStr & " - " & _Descrizione
            If SenzaAvviamento = False Then
                ris &= " ( avviam: " & _CostoMinAvv & "€)"
            End If
            Return ris

        End Get
    End Property

    Public Function LavoriInCoda(Optional SoloProntiDaLavorare As Boolean = False,
                                 Optional SoloForzatiAIdUtente As Integer = 0,
                                 Optional IdOrdine As Integer = 0,
                                 Optional IdCom As Integer = 0,
                                 Optional IdPreventivazione As Integer = 0) As List(Of LavLog)

        Dim ris As New List(Of LavLog)

        Using mgr As New LavLogDAO

            Dim sql As String = "SELECT * FROM T_Lavlog WHERE IdMacchinario = " & IdMacchinario & " AND (dataOrainizio IS NULL OR dataOrafine IS NULL) AND Idlav IN (SELECT IdLavoro FROM t_lavori WHERE IdCatLav IN (SELECT idcatlav FROM td_catlav WHERE TipoCaratteristica=" & enSiNo.No & "))"

            If SoloForzatiAIdUtente Then
                sql &= " AND IdUtenteForzato = " & SoloForzatiAIdUtente
            End If

            If IdOrdine Then
                sql &= " AND IdOrd = " & IdOrdine
            End If

            If IdCom Then
                sql &= " AND IdCom = " & IdCom
            End If

            If IdPreventivazione Then
                sql &= " AND IdCom = " & IdCom
            End If

            Dim l As List(Of LavLog) = mgr.GetBySQL(sql)

            For Each lav In l
                Dim OkPerLista As Boolean = True

                If SoloProntiDaLavorare Then
                    If lav.PrendibileInCarico = False Then
                        OkPerLista = False
                    End If
                End If

                If OkPerLista Then
                    If lav.Lavorazione.Categoria.TipoCaratteristica = enSiNo.Si Then
                        OkPerLista = False
                    End If
                End If

                If OkPerLista Then
                    If lav.IdOrdine Then
                        If Not lav.OrdineRiferimento Is Nothing _
                            AndAlso ((lav.OrdineRiferimento.Stato >= enStatoOrdine.InCodaDiStampa And lav.OrdineRiferimento.Stato < enStatoOrdine.Imballaggio)) Then

                            If Not lav.OrdineRiferimento.Commessa Is Nothing Then
                                If lav.OrdineRiferimento.Commessa.Stato >= enStatoCommessa.Pronto And lav.OrdineRiferimento.Commessa.Stato <= enStatoCommessa.Completata Then
                                    ris.Add(lav)
                                End If
                            End If

                        End If
                    ElseIf lav.IdCom Then
                        If Not lav.CommessaRiferimento Is Nothing Then
                            ris.Add(lav)
                        End If
                        'If Not lav.CommessaRiferimento Is Nothing _
                        '    AndAlso (lav.CommessaRiferimento.Stato >= enStatoCommessa.Pronto And lav.CommessaRiferimento.Stato <= enStatoCommessa.Completata) Then
                        '    ris.Add(lav)
                        'End If
                    End If
                End If
            Next

        End Using

        ris.Sort(AddressOf Comparer)

        Return ris

    End Function

    Private Function Comparer(ByVal x As LavLog, ByVal y As LavLog) As Integer
        Dim result As Integer = 0
        result = y.AttualmenteInLavorazione.CompareTo(x.AttualmenteInLavorazione)
        If result = 0 Then
            result = y.PrendibileInCarico.CompareTo(x.PrendibileInCarico)
            If result = 0 Then
                result = y.Priorita.CompareTo(x.Priorita)
                If result = 0 Then
                    result = x.Lavorazione.Categoria.OrdineEsecuzione.CompareTo(y.Lavorazione.Categoria.OrdineEsecuzione)
                    If result = 0 Then
                        result = x.Ordine.CompareTo(y.Ordine)
                        If result = 0 Then
                            'qui devo ordinare prima le commesse a parita e poi gli ordini, e a parita poi prima per data inserimento
                            result = y.TipoVoceLavLog.CompareTo(x.TipoVoceLavLog)
                            If result = 0 Then
                                result = x.DataInserimento.CompareTo(y.DataInserimento)
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return result
    End Function

    Public Property InCaricoPerLavoriForzati As Boolean = False

    Public ReadOnly Property TipoStr As String Implements IVoceComboConImmagine.Description
        Get
            Dim Ris As String = ""
            If _Tipo = FormerLib.FormerEnum.enTipoMacchinario.Produzione Then
                Ris = "Produzione"
            ElseIf _Tipo = FormerLib.FormerEnum.enTipoMacchinario.Allestimento Then
                Ris = "Allestimento"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Img As Image Implements IVoceComboConImmagine.Image
        Get
            Dim ris As Image = Nothing
            Dim PathRiferimento As String = _ImgRif.ToLower '.Replace("z:", "w:")

            If PathRiferimento.Length Then

                Dim PathLocaleImg As String = FormerPath.PathTempImg & FormerLib.FormerHelper.File.EstraiNomeFile(PathRiferimento)

                If File.Exists(PathLocaleImg) Then
                    PathRiferimento = PathLocaleImg
                Else
                    Try
                        Dim imgPreview As Image = Image.FromFile(PathRiferimento)

                        imgPreview = FormerThumbnail.GetForImgListino(imgPreview)

                        imgPreview.Save(PathLocaleImg)

                    Catch ex As Exception

                    End Try
                End If

                Try
                    If File.Exists(PathRiferimento) Then
                        ris = Image.FromFile(PathRiferimento)
                    End If

                Catch ex As Exception

                End Try

            End If

            If ris Is Nothing Then ris = New Bitmap(My.Resources.no_image, New Size(75, 50))

            Return ris
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IMacchinario.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If _Tipo = 0 Then Ris = False
        'If _CostoMinAvv = 0 Then Ris = False
        'If _CostoSingCopia = 0 Then Ris = False
        If _Descrizione.Length = 0 Then Ris = False
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IMacchinario.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IMacchinario.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return "[" & TipoStr & "] " & _Descrizione
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_macchinari
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IMacchinario
    Inherits _IMacchinario

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface