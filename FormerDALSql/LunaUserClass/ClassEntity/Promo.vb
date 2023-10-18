#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 18/01/2017 
#End Region




Imports System.Drawing
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_promo
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class Promo
    Inherits _Promo
    Implements IPromo

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdPromo() As Integer
        Get
            Return MyBase.IdPromo
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPromo = value
        End Set
    End Property


    Public Overrides Property IdListinoBase() As Integer
        Get
            Return MyBase.IdListinoBase
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBase = value
        End Set
    End Property


    Public Overrides Property Stato() As Integer
        Get
            Return MyBase.Stato
        End Get
        Set(ByVal value As Integer)
            MyBase.Stato = value
        End Set
    End Property


    Public Overrides Property Percentuale() As Integer
        Get
            Return MyBase.Percentuale
        End Get
        Set(ByVal value As Integer)
            MyBase.Percentuale = value
        End Set
    End Property


    Public Overrides Property QtaSpecifica() As Integer
        Get
            Return MyBase.QtaSpecifica
        End Get
        Set(ByVal value As Integer)
            MyBase.QtaSpecifica = value
        End Set
    End Property


    Public Overrides Property DataFineValidita() As DateTime
        Get
            Return MyBase.DataFineValidita
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataFineValidita = value
        End Set
    End Property


    Public Overrides Property IdPromoOnline() As Integer
        Get
            Return MyBase.IdPromoOnline
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPromoOnline = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _ListinoBaseStr As String = String.Empty
    Public ReadOnly Property ListinoBaseStr As String
        Get
            If _ListinoBaseStr.Length = 0 Then
                If IdListinoBase Then
                    _ListinoBaseStr = QtaSpecifica & " " & L.Riassunto
                End If
            End If
            Return _ListinoBaseStr
        End Get
    End Property

    Private _L As ListinoBase = Nothing
    Public ReadOnly Property L As ListinoBase
        Get
            If IdListinoBase Then
                If _L Is Nothing Then
                    _L = New ListinoBase
                    _L.Read(IdListinoBase)
                End If
            End If
            Return _L

        End Get
    End Property

    Public ReadOnly Property ImgRif As Image
        Get
            Dim Ris As Image = Nothing
            If IdListinoBase Then

                Select Case L.PrendiIcoDa
                    Case enPrendiIcoDa.Preventivazione
                        Ris = L.Preventivazione.Img
                    Case enPrendiIcoDa.FormatoProdotto
                        Ris = L.ImgFp48
                    Case enPrendiIcoDa.ColoreDiStampa
                        Ris = L.ImgCs48
                    Case enPrendiIcoDa.TipoCarta
                        Ris = L.ImgTc48
                End Select
            End If

            'If Ris Is Nothing Then Ris = New Bitmap(My.Resources.no_image, 75, 50)

            Return Ris
        End Get
    End Property
    Public ReadOnly Property DataFineValiditaStr As String
        Get
            Return DataFineValidita.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property Scaduto As Boolean
        Get
            Dim risB As Boolean = False

            Dim DataOra As Date = Now

            Dim DiffGiorni As Single = DateDiff(DateInterval.Day, DataOra, DataFineValidita)
            If Not DiffGiorni > 0 Then
                Dim DiffOre As Single = DateDiff(DateInterval.Hour, DataOra, DataFineValidita)
                If Not DiffOre > 0 Then
                    Dim DiffMinuti As Single = DateDiff(DateInterval.Minute, DataOra, DataFineValidita)
                    If Not DiffMinuti >= 0 Then
                        risB = True
                    End If
                End If
            End If

            Return risB
        End Get
    End Property

    Public ReadOnly Property ScadeTraStr As String
        Get
            Dim Ris As String = String.Empty
            Dim DataOra As Date = Now

            Dim DiffGiorni As Single = DateDiff(DateInterval.Day, DataOra, DataFineValidita)
            If DiffGiorni > 0 Then

                Ris = DiffGiorni & " giorni "

                DataOra = DataOra.AddDays(DiffGiorni)
            End If

            Dim DiffOre As Single = DateDiff(DateInterval.Hour, DataOra, DataFineValidita)

            If DiffOre > 0 Then

                Ris &= DiffOre & " ore "

                DataOra = DataOra.AddHours(DiffOre)
            End If

            Dim DiffMinuti As Single = DateDiff(DateInterval.Minute, DataOra, DataFineValidita)

            If DiffMinuti > 0 Then

                Ris &= DiffMinuti & " minuti "
            ElseIf DiffMinuti = 0 Then
                If Ris = String.Empty Then
                    Ris = " pochi secondi "
                End If
            Else
                Ris = " Scaduto "

            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim ris As String = String.Empty

            If Stato = enStato.Attivo Then

                If IdPromoOnline Then
                    'qui devo vedere se e' scaduto 
                    ris = "Pubblicato"
                Else
                    ris = "Non pubblicato"
                End If

            Else
                ris = "Non attivo"
            End If

            Return ris

        End Get
    End Property

    Public ReadOnly Property AutomaticoStr As String
        Get
            Dim ris As String = "NO"

            If Automatico = enSiNo.Si Then
                ris = "SI"
            End If

            Return ris

        End Get
    End Property

#End Region

#Region "Method"

    Public Function GetPrezzoPromo(PrezzoPieno As Decimal) As Decimal
        Dim PrezzoPromo As Decimal = 0

        PrezzoPromo = Math.Floor(PrezzoPieno - ((PrezzoPieno * Percentuale) / 100))

        Return PrezzoPromo
    End Function

    Public Overrides Function IsValid() As Boolean Implements IPromo.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPromo.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPromo.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_promo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPromo
    Inherits _IPromo

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface