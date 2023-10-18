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
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports System.IO
Imports FormerBusinessLogicInterface

Imports FormerLib
''' <summary>
'''Entity Class for table Td_tipocarta
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoCarta
    Inherits _TipoCarta
    Implements ITipoCarta
    Implements ITipoCartaB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdTipoCarta() As Integer Implements ITipoCartaB.IdTipoCarta
        Get
            Return MyBase.IdTipoCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoCarta = value
        End Set
    End Property


    Public Overrides Property Tipologia() As String Implements ITipoCartaB.Tipologia
        Get
            Return MyBase.Tipologia
        End Get
        Set(ByVal value As String)
            MyBase.Tipologia = value
        End Set
    End Property


    Public Overrides Property Finitura() As String Implements ITipoCartaB.Finitura
        Get
            Return MyBase.Finitura
        End Get
        Set(ByVal value As String)
            MyBase.Finitura = value
        End Set
    End Property


    Public Overrides Property Grammi() As Integer Implements ITipoCartaB.Grammi
        Get
            Return MyBase.Grammi
        End Get
        Set(ByVal value As Integer)
            MyBase.Grammi = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements ITipoCartaB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property Sigla() As String Implements ITipoCartaB.Sigla
        Get
            Return MyBase.Sigla
        End Get
        Set(ByVal value As String)
            MyBase.Sigla = value
        End Set
    End Property


    Public Overrides Property CostoCartaKg() As Decimal Implements ITipoCartaB.CostoCartaKg
        Get
            Return MyBase.CostoCartaKg
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoCartaKg = value
        End Set
    End Property


    Public Overrides Property Spessore() As Single Implements ITipoCartaB.Spessore
        Get
            Return MyBase.Spessore
        End Get
        Set(ByVal value As Single)
            MyBase.Spessore = value
        End Set
    End Property


    Public Overrides Property TipoCarta() As Integer Implements ITipoCartaB.TipoCarta
        Get
            Return MyBase.TipoCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoCarta = value
        End Set
    End Property


    Public Overrides Property DescrizioneEstesa() As String Implements ITipoCartaB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property


    Public Overrides Property TipoCosto() As Integer Implements ITipoCartaB.TipoCosto
        Get
            Return MyBase.TipoCosto
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoCosto = value
        End Set
    End Property


    Public Overrides Property CostoRiferimento() As Decimal Implements ITipoCartaB.CostoRiferimento
        Get
            Return MyBase.CostoRiferimento
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoRiferimento = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public Property PercVariazioneSuVariante As Integer = 0

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ComposizioniCartaB As IEnumerable(Of IComposizioneCartaB) Implements ITipoCartaB.ComposizioniCarta
        Get
            Return ComposizioniCarta
        End Get
    End Property

    Private Sub CaricaComposizioni()
        Using mgr As New ComposizioneCartaDAO
            _ComposizioniCarta = mgr.FindAll("NumFogli Desc", New LUNA.LunaSearchParameter("IdCartaPadre", IdTipoCarta))

        End Using
    End Sub

    Public Sub CaricaComposizioniCarta()
        CaricaComposizioni()
    End Sub

    Private _ComposizioniCarta As List(Of ComposizioneCarta)
    Public Property ComposizioniCarta As List(Of ComposizioneCarta)
        Get
            If _ComposizioniCarta Is Nothing Then
                'la carico
                CaricaComposizioni()
            End If
            Return _ComposizioniCarta
        End Get
        Set(value As List(Of ComposizioneCarta))
            _ComposizioniCarta = value
        End Set
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = ""
            'ris = _Sigla & " - " & _Tipologia
            ris = _Tipologia
            If _TipoCarta = enTipoCarta.Semplice Then
                ris &= " ( costo kg " & _CostoCartaKg & "€)"
            Else
                ris &= " (Carta Composta)"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property RiassuntoTipologia As String
        Get
            Dim ris As String = Finitura.ToUpper & " - " & Tipologia
            Return ris
        End Get
    End Property


    Public ReadOnly Property TipoCartaStr As String
        Get
            Dim ris As String = String.Empty
            If _TipoCarta = enTipoCarta.Semplice Then
                ris = "Semplice"
            Else
                ris = "Composta"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property RisorseAssociateStr As String
        Get
            Dim ris As String = String.Empty

            If TipoCarta = enTipoCarta.Semplice Then
                Using mgr As New RisorseDAO
                    Dim l As List(Of Risorsa) = mgr.FindAll("Descrizione",
                                                            New LUNA.LunaSearchParameter("IsLastra", enTipoRisOffSet.MateriaPrima),
                                                            New LUNA.LunaSearchParameter("IdTipoCarta", IdTipoCarta))

                    For Each risorsa As Risorsa In l
                        ris &= "- " & risorsa.Descrizione & ControlChars.NewLine
                    Next

                End Using
            Else
                'carta composta
                For Each comp As ComposizioneCarta In ComposizioniCarta
                    ris &= comp.CartaSingola.Tipologia & " (Num. Fogli " & comp.NumFogli & ")" & ControlChars.NewLine
                Next
            End If

            Return ris

        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITipoCarta.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If Sigla.Length = 0 Then Ris = False
        If Tipologia.Length = 0 Then Ris = False
        'If CostoCartaKg = 0 Then Ris = False
        If Grammi = 0 Then Ris = False
        If TipoCarta = enTipoCarta.Semplice And ComposizioniCarta.Count <> 0 Then Ris = False
        If TipoCarta = enTipoCarta.Composta And ComposizioniCarta.Count < 2 Then
            If ComposizioniCarta.Count Then
                Dim cc As ComposizioneCarta = ComposizioniCarta(0)
                If cc.NumFogli < 2 Then
                    'qui parliamo di una carta composta da N fogli di un altro solo tipo carta
                    Ris = False
                End If
            Else
                Ris = False
            End If
        End If
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ITipoCarta.Read
        Dim ris As Integer = MyBase.Read(Id)
        'qui ricarico i tipi di carta interni se e' di tipo composto
        CaricaComposizioni()

        Return ris
    End Function

    Public Overrides Function Save() As Integer Implements ITipoCarta.Save
        Dim ris As Integer = MyBase.Save()
        'qui salvo i tipi di carta interni se e' di tipo composto/

        Using m As New ComposizioneCartaDAO
            m.DeleteByIdTipoCarta(ris)
        End Using
        For Each cs As ComposizioneCarta In ComposizioniCarta
            cs.IdCartaComposta = 0
            cs.IdCartaPadre = ris
            cs.Save()
        Next

        Return ris
    End Function

    Public Overrides Function ToString() As String
        Return _Tipologia
    End Function

    Public Function CalcolaSpessoreCM(Qta As Integer) As Single

        Dim ris As Single = MgrCalcoliTecnici.CalcolaSpessoreCarta(Qta, Spessore)
        'If Spessore Then
        '    'formula = MICRON * QTA / 1000
        '    ris = Spessore * Qta / 10000
        'End If

        Return ris

    End Function

#End Region

End Class


Public Class TipoCartaEx
    Inherits TipoCarta
    Implements IVoceComboConImmagine
#Region "Logic Field"
    Public ReadOnly Property Id As Integer Implements IVoceComboConImmagine.Id
        Get
            Return _IdTipoCarta
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IVoceComboConImmagine.Text
        Get
            Return _Tipologia
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IVoceComboConImmagine.Description
        Get
            Return _Tipologia & vbNewLine & "(Finitura: " & _Finitura & " - Grammi: " & _Grammi & ")"
        End Get
    End Property
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub
    Private _ImageAnteprima As Image = Nothing

    Public ReadOnly Property ImageAnteprima64 As Image Implements IVoceComboConImmagine.Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then

                Try
                    If _ImgRif.Length Then
                        If File.Exists(_ImgRif) Then
                            Dim ImgInt As New Bitmap(_ImgRif)

                            Dim width As Integer = 0, height As Integer = 0

                            'If ImgInt.Width > ImgInt.Height Then
                            '    width = 80
                            '    height = 60
                            'ElseIf ImgInt.Width < ImgInt.Height Then
                            '    width = 60
                            '    height = 80
                            'Else
                            width = 64
                            height = 64
                            'End If

                            Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))

                            Img = ImgNew
                            _ImageAnteprima = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprima
            End If

            Return Img
            'Dim Img As Image = Nothing
            'Try

            '    Img = Image.FromFile(_Anteprima)
            'Catch ex As Exception

            'End Try
            'Return Img
        End Get
    End Property

    Public ReadOnly Property ImageAnteprima32 As Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then

                Try
                    If _ImgRif.Length Then
                        If File.Exists(_ImgRif) Then
                            Dim ImgInt As New Bitmap(_ImgRif)

                            Dim width As Integer = 0, height As Integer = 0

                            width = 32
                            height = 32

                            Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))

                            Img = ImgNew
                            _ImageAnteprima = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprima
            End If

            Return Img

        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image

            End If
            Return ris
        End Get
    End Property

End Class
''' <summary>
'''Interface for table Td_tipocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoCarta
    Inherits _ITipoCarta

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface