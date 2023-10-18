#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 18/01/2017 
#End Region



''' <summary>
'''Entity Class for table Promo
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PromoW
    Inherits _PromoW
    Implements IPromoW

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


    Public Overrides Property IdPromoInt() As Integer
        Get
            Return MyBase.IdPromoInt
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPromoInt = value
        End Set
    End Property


#End Region

#Region "Logic Field"

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

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPromoW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPromoW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPromoW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function GetPrezzoPromo(PrezzoPieno As Decimal,
                                   Optional AllowDecimal As Boolean = False) As Decimal
        Dim PrezzoPromo As Decimal = 0

        PrezzoPromo = PrezzoPieno - ((PrezzoPieno * Percentuale) / 100)

        If AllowDecimal = False Then
            PrezzoPromo = Math.Floor(PrezzoPromo)
        End If

        Return PrezzoPromo
    End Function


#End Region

End Class



''' <summary>
'''Interface for table Promo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPromoW
    Inherits _IPromoW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface