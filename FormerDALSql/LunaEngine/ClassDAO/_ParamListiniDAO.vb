#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of ParamListino object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ParamListiniDAO
	Inherits LUNA.LunaBaseClassDAO(Of ParamListino)

	''' <summary>
	'''New() create an istance of this class. Use default DB Connection
	''' </summary>
	Public Sub New()
		MyBase.New()
	End Sub

	''' <summary>
	'''New() create an istance of this class and specify an OPENED DB connection
	''' </summary>
	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	''' <summary>
	'''Read from DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a ParamListino object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ParamListino
		Dim cls as new ParamListino

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Paramlistini WHERE IdParamListino = " & Id
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader
					myReader.Read()
					If myReader.HasRows Then
						cls.FillFromDataRecord(CType(myReader, IDataRecord))	
					End If
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return cls
	End Function

	''' <summary>
	'''Save on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ParamListino) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdParamListino = 0 Then
							sql = "INSERT INTO Paramlistini ("
							sql &= " IdPrev,"
							sql &= " IdUt,"
							sql &= " PercRicarico,"
							sql &= " Qta1,"
							sql &= " Qta2,"
							sql &= " Qta3,"
							sql &= " Qta4,"
							sql &= " Qta5"
							sql &= ") VALUES ("
							sql &= " @IdPrev,"
							sql &= " @IdUt,"
							sql &= " @PercRicarico,"
							sql &= " @Qta1,"
							sql &= " @Qta2,"
							sql &= " @Qta3,"
							sql &= " @Qta4,"
							sql &= " @Qta5"
							sql &= ")"
						Else
							sql = "UPDATE Paramlistini SET "
							If cls.WhatIsChanged.IdPrev Then sql &= "IdPrev = @IdPrev,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.PercRicarico Then sql &= "PercRicarico = @PercRicarico,"
							If cls.WhatIsChanged.Qta1 Then sql &= "Qta1 = @Qta1,"
							If cls.WhatIsChanged.Qta2 Then sql &= "Qta2 = @Qta2,"
							If cls.WhatIsChanged.Qta3 Then sql &= "Qta3 = @Qta3,"
							If cls.WhatIsChanged.Qta4 Then sql &= "Qta4 = @Qta4,"
							If cls.WhatIsChanged.Qta5 Then sql &= "Qta5 = @Qta5"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdParamListino= " & cls.IdParamListino
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@IdPrev"
						p.Value = cls.IdPrev
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdUt"
						p.Value = cls.IdUt
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PercRicarico"
						p.Value = cls.PercRicarico
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta1"
						p.Value = cls.Qta1
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta2"
						p.Value = cls.Qta2
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta3"
						p.Value = cls.Qta3
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta4"
						p.Value = cls.Qta4
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta5"
						p.Value = cls.Qta5
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdParamListino=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdParamListino = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdParamListino
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdParamListino
			End If
		Else
			throw new ApplicationException("Object data is not valid")
		End If
		Return Ris
	End Function

	Private Sub DestroyPermanently(Id as integer) 
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.Connection = _cn

				'******IMPORTANT: You can use this commented instruction to make a logical delete .
				'******Replace DELETED Field with your logic deleted field name.
				'Dim Sql As String = "UPDATE Paramlistini SET DELETED=True "
				Dim Sql As String = "DELETE FROM Paramlistini"
				Sql &= " WHERE IdParamListino = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Paramlistini. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Paramlistini. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ParamListino, Optional ByRef ListaObj as List (of ParamListino) = Nothing)
		DestroyPermanently (obj.IdParamListino)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ParamListino
		Dim ris As ParamListino = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ParamListino) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return first of ParamListino
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ParamListino
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return first of ParamListino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ParamListino
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ParamListino
	''' </summary>
	''' <returns>
	'''Return first of ParamListino
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ParamListino
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ParamListino)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ParamListino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ParamListino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ParamListino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ParamListino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ParamListino)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Paramlistini by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ParamListino by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ParamListino)
		Dim Ls As New List(Of ParamListino)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ParamListino)
		Dim Ls As New List(Of ParamListino)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Paramlistini" 
			For Each Par As LUNA.LunaSearchParameter In Parameter
				If Not Par Is Nothing Then
					If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
					sql &= Par.FieldName & " " & Par.SqlOperator
					If Par.SqlOperator.ToUpper.IndexOf("IN") <> -1 Then
						sql &= " " & ApIn(Par.Value)
					Else
						sql &= " " & Ap(Par.Value)
					End If
				End if
			Next

			If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

			Ls = GetData(sql, SearchOption.AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	''' <summary>
	'''Return all record on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return all record in list of ParamListino
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ParamListino)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return all record in list of ParamListino
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ParamListino)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Paramlistini
	''' </summary>
	''' <returns>
	'''Return all record in list of ParamListino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ParamListino)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ParamListino)
		Dim Ls As List(Of ParamListino)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Paramlistini" 
			If OrderByField.Length Then
				Sql &= " ORDER BY " & OrderByField
			End If
			Ls = GetData(Sql,AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	Protected Overridable Property EmptyItemDescription As String = "Selezionare una voce"

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ParamListino)
		Dim Ls As New List(Of ParamListino)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ParamListino() With {.IdParamListino = 0 ,.IdPrev = 0 ,.IdUt = 0 ,.PercRicarico = 0 ,.Qta1 = 0 ,.Qta2 = 0 ,.Qta3 = 0 ,.Qta4 = 0 ,.Qta5 = 0  })
					While myReader.Read
						Dim classe as new ParamListino(CType(myReader, IDataRecord))
						Ls.Add(classe)
					End While
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
End Class