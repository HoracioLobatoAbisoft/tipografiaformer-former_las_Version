#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 07/10/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of FunctionLock object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _FunctionLockDAO
	Inherits LUNA.LunaBaseClassDAO(Of FunctionLock)

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
	'''Read from DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a FunctionLock object
	''' </returns>
	Public Overrides Function Read(Id as integer) as FunctionLock
		Dim cls as new FunctionLock

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_functionlock WHERE IdFunctionLock = " & Id
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
	'''Save on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as FunctionLock) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdFunctionLock = 0 Then
							sql = "INSERT INTO T_functionlock ("
							sql &= " idcom,"
							sql &= " IdFunction,"
							sql &= " IdOrd,"
							sql &= " IdUt,"
							sql &= " Postazione,"
							sql &= " Quando"
							sql &= ") VALUES ("
							sql &= " @idcom,"
							sql &= " @IdFunction,"
							sql &= " @IdOrd,"
							sql &= " @IdUt,"
							sql &= " @Postazione,"
							sql &= " @Quando"
							sql &= ")"
						Else
							sql = "UPDATE T_functionlock SET "
							If cls.WhatIsChanged.idcom Then sql &= "idcom = @idcom,"
							If cls.WhatIsChanged.IdFunction Then sql &= "IdFunction = @IdFunction,"
							If cls.WhatIsChanged.IdOrd Then sql &= "IdOrd = @IdOrd,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.Postazione Then sql &= "Postazione = @Postazione,"
							If cls.WhatIsChanged.Quando Then sql &= "Quando = @Quando"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdFunctionLock= " & cls.IdFunctionLock
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.idcom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@idcom"
							p.Value = cls.idcom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFunction Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFunction"
							p.Value = cls.IdFunction
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrd"
							p.Value = cls.IdOrd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Postazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Postazione"
							p.Value = cls.Postazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Quando Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Quando"
							p.DbType = DbType.DateTime
							If cls.Quando <> Date.MinValue Then
								p.Value = cls.Quando
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdFunctionLock=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdFunctionLock = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdFunctionLock
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdFunctionLock
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
				'Dim Sql As String = "UPDATE T_functionlock SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_functionlock"
				Sql &= " WHERE IdFunctionLock = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_functionlock. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_functionlock. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as FunctionLock, Optional ByRef ListaObj as List (of FunctionLock) = Nothing)
		DestroyPermanently (obj.IdFunctionLock)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FunctionLock
		Dim ris As FunctionLock = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of FunctionLock) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return first of FunctionLock
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FunctionLock
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return first of FunctionLock
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FunctionLock
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table FunctionLock
	''' </summary>
	''' <returns>
	'''Return first of FunctionLock
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FunctionLock
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FunctionLock)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FunctionLock)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FunctionLock)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FunctionLock)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FunctionLock)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of FunctionLock)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_functionlock by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of FunctionLock by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of FunctionLock)
		Dim Ls As New List(Of FunctionLock)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of FunctionLock)
		Dim Ls As New List(Of FunctionLock)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_functionlock" 
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
	'''Return all record on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return all record in list of FunctionLock
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of FunctionLock)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return all record in list of FunctionLock
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FunctionLock)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_functionlock
	''' </summary>
	''' <returns>
	'''Return all record in list of FunctionLock
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FunctionLock)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FunctionLock)
		Dim Ls As List(Of FunctionLock)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_functionlock" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FunctionLock)
		Dim Ls As New List(Of FunctionLock)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  FunctionLock() With {.IdFunctionLock = 0 ,.idcom = 0 ,.IdFunction = 0 ,.IdOrd = 0 ,.IdUt = 0 ,.Postazione = "" ,.Quando = Nothing  })
					While myReader.Read
						Dim classe as new FunctionLock(CType(myReader, IDataRecord))
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