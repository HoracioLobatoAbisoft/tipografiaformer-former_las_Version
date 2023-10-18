#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.27766 
'Author: Diego Lunadei
'Date: 09/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Indirizzi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class IndirizziDAO
    Inherits _IndirizziDAO

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    '''New() create an istance of this class and specify an OPENED DB connection
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Public Function ListaNuoviIndirizzi() As List(Of Indirizzo)
        Dim Sql As String = "SELECT I.* FROM Indirizzi I INNER JOIN utenti u ON i.idut = u.idut WHERE IdIndirizzoInt = 0 AND u.idrubricaint <> 0 AND i.status = 0 "

        Return GetData(Sql)
    End Function

    Public Function EliminaIndirizzo(idUtente As Integer, idIndirizzo As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
                Dim Sql As String = "UPDATE Indirizzi SET status = " & enStato.NonAttivo
                Sql &= " WHERE IdUt = " & idUtente
                Sql &= " AND idindirizzo = " & idIndirizzo

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    Public Function RendiPredefinito(idutente As Integer, Optional idIndirizzoPred As Integer = 0) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
                Dim Sql As String = "UPDATE Indirizzi SET predefinito = " & enSiNo.No
                Sql &= " WHERE IdUt = " & idutente

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()

                If idIndirizzoPred Then
                    Sql = "UPDATE Indirizzi SET predefinito = " & enSiNo.Si
                    Sql &= " WHERE Idindirizzo = " & idIndirizzoPred
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()
                End If

            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    Public Function ResetPredefinito(idutente As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
                Dim Sql As String = "UPDATE Indirizzi set predefinito = 0"
                Sql &= " Where IdUt = " & idutente

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

End Class