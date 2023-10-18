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

''' <summary>
'''DAO Class for table Tr_modcomformp
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ModComFormProdDAO
    Inherits _ModComFormProdDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function MaxPostiPerFormatoCarta(IdFormCarta As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "Select max(tot) as total from (SELECT SUM(mp.SPAZI) as tot FROM TR_MODCOMFORMP mp , T_ModelliCommessa m WHERE m.idmodello = mp.IdModCom and m.FromGanging=" & enSiNo.No & " and m.disattivo= " & enSiNo.No & " and mp.IDFORMPROD IN " &
            "(SELECT IDFORMPROD from TD_FORMATOPRODOTTO WHERE IDFORMCARTA= " & IdFormCarta & ") group by idmodcom) as a"

            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            If myReader.HasRows Then
                myReader.Read()
                If IsDBNull(myReader("total")) = False Then Ris = myReader("total")
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Sub DeletebyIdModCom(IdModCom As Integer)

        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_modcomformp SET DELETED=True "
            Dim Sql As String = "DELETE FROM Tr_ModComFormp"
            Sql &= " WHERE IdModCom = " & IdModCom

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub
End Class