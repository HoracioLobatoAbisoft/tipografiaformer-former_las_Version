#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 28/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_logmw
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LogMarketing
	Inherits _LogMarketing
    Implements ILogMarketing

    Public Sub New()
        MyBase.New()
    End Sub

      Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Database Field"


Public Overrides Property IdLogMw() as integer
    Get
	    Return MyBase.IdLogMw
    End Get
    Set (byval value as integer)
        MyBase.IdLogMw= value
    End Set
End property 


Public Overrides Property IdFm() as integer
    Get
	    Return MyBase.IdFm
    End Get
    Set (byval value as integer)
        MyBase.IdFm= value
    End Set
End property 


Public Overrides Property IdRubG() as integer
    Get
	    Return MyBase.IdRubG
    End Get
    Set (byval value as integer)
        MyBase.IdRubG= value
    End Set
End property 


Public Overrides Property Stato() as integer
    Get
	    Return MyBase.Stato
    End Get
    Set (byval value as integer)
        MyBase.Stato= value
    End Set
End property 


Public Overrides Property DataIns() as DateTime
    Get
	    Return MyBase.DataIns
    End Get
    Set (byval value as DateTime)
        MyBase.DataIns= value
    End Set
End property 


Public Overrides Property DataSent() as DateTime
    Get
	    Return MyBase.DataSent
    End Get
    Set (byval value as DateTime)
        MyBase.DataSent= value
    End Set
End property 


Public Overrides Property NTent() as integer
    Get
	    Return MyBase.NTent
    End Get
    Set (byval value as integer)
        MyBase.NTent= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Public ReadOnly Property FiltroMarketing As FiltroMarketing
        Get
            Dim Fm As New FiltroMarketing
            Fm.Read(IdFm)
            Return Fm

        End Get
    End Property

    Public ReadOnly Property VoceRubricaG As IVoceRubricaG
        Get
            Dim Ris As IVoceRubricaG = Nothing

            If IdRubG Then
                Dim R As New VoceRubG
                R.Read(IdRubG)

                If R.IdRub Then

                    Dim Voce As New VoceRubrica
                    Voce.Read(R.IdRub)
                    Ris = Voce
                Else
                    Dim Voce As New VoceRubricaMarketing
                    Voce.Read(R.IdRubM)
                    Ris = Voce

                End If
            ElseIf IdEmail Then
                'qui vado a prendere l'id rub da dentro l'email 
                Using m As New Email
                    m.Read(IdEmail)

                    If m.IdRubDest Then
                        Dim Voce As New VoceRubrica
                        Voce.Read(m.IdRubDest)
                        Ris = Voce
                    End If

                    If m.IdRubDest Then

                        Dim Voce As New VoceRubrica
                        Voce.Read(m.IdRubDest)
                        Ris = Voce
                    Else
                        Dim Voce As New VoceRubricaMarketing
                        Voce.Read(m.IdRubMarketing)
                        Ris = Voce

                    End If

                End Using

            End If


            Return Ris
        End Get
    End Property


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ILogMarketing.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ILogMarketing.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ILogMarketing.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_logmw
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILogMarketing
        Inherits _ILogMarketing

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface