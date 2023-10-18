#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.8 
'Author: Diego Lunadei
'Date: 06/12/2017 
#End Region




Imports FormerLib
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_regolecalcolo
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class RegolaCalcolo
    Inherits _RegolaCalcolo
    Implements IRegolaCalcolo

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdRegola() As Integer
        Get
            Return MyBase.IdRegola
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRegola = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


    Public Overrides Property TipoRegola() As Integer
        Get
            Return MyBase.TipoRegola
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoRegola = value
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


    Public Overrides Property Chiave() As String
        Get
            Return MyBase.Chiave
        End Get
        Set(ByVal value As String)
            MyBase.Chiave = value
        End Set
    End Property


    Public Overrides Property Valore() As String
        Get
            Return MyBase.Valore
        End Get
        Set(ByVal value As String)
            MyBase.Valore = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property StatoStr As String
        Get
            Dim ris As String = String.Empty

            If Stato = enStato.Attivo Then
                ris = "Attiva"
            Else
                ris = "NON Attiva"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoRegolaStr As String
        Get
            Dim ris As String = String.Empty

            If TipoRegola = enTipoRegola.DiSistema Then
                ris = "Di sistema"
            Else
                ris = "Utente"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property AmbitoStr As String
        Get
            Dim ris As String = String.Empty
            If IdListinoBase Then
                ris = ListinoBase.NomeEx
            Else
                ris = "Tutto"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            Dim Ris As ListinoBase = Nothing
            If IdListinoBase Then
                Ris = New ListinoBase
                Ris.Read(IdListinoBase)
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property ListExtraData As List(Of ExtraData)
        Get
            Dim l As New List(Of ExtraData)
            If Opzioni.Length Then
                For Each coppia As String In Opzioni.Split(";")
                    If coppia.Length Then
                        Dim Chiave As String = coppia.Substring(0, coppia.IndexOf(":"))
                        Dim Valore As String = coppia.Substring(coppia.IndexOf(":") + 1)
                        Dim E As New ExtraData
                        E.Chiave = Chiave
                        E.Valore = Valore
                        l.Add(E)
                    End If

                Next
            End If

            Return l
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IRegolaCalcolo.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IRegolaCalcolo.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IRegolaCalcolo.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_regolecalcolo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IRegolaCalcolo
    Inherits _IRegolaCalcolo

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface