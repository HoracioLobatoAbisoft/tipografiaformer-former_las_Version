#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 16/06/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of LogOperativo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _LogOperativiDAO
	Inherits LUNA.LunaBaseClassDAO(Of LogOperativo)

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
	'''Read from DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a LogOperativo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as LogOperativo
		Dim cls as new LogOperativo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Logoperativi WHERE IdLog = " & Id
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
	'''Save on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as LogOperativo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLog = 0 Then
							sql = "INSERT INTO Logoperativi ("
							sql &= " Buffer,"
							sql &= " Chiamata1,"
							sql &= " Chiamata2,"
							sql &= " IdOperatore,"
							sql &= " IdRif,"
							sql &= " Quando,"
							sql &= " TipoLog"
							sql &= ") VALUES ("
							sql &= " @Buffer,"
							sql &= " @Chiamata1,"
							sql &= " @Chiamata2,"
							sql &= " @IdOperatore,"
							sql &= " @IdRif,"
							sql &= " @Quando,"
							sql &= " @TipoLog"
							sql &= ")"
						Else
							sql = "UPDATE Logoperativi SET "
							If cls.WhatIsChanged.Buffer Then sql &= "Buffer = @Buffer,"
							If cls.WhatIsChanged.Chiamata1 Then sql &= "Chiamata1 = @Chiamata1,"
							If cls.WhatIsChanged.Chiamata2 Then sql &= "Chiamata2 = @Chiamata2,"
							If cls.WhatIsChanged.IdOperatore Then sql &= "IdOperatore = @IdOperatore,"
							If cls.WhatIsChanged.IdRif Then sql &= "IdRif = @IdRif,"
							If cls.WhatIsChanged.Quando Then sql &= "Quando = @Quando,"
							If cls.WhatIsChanged.TipoLog Then sql &= "TipoLog = @TipoLog"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLog= " & cls.IdLog
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Buffer Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Buffer"
							p.Value = cls.Buffer
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Chiamata1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Chiamata1"
							p.Value = cls.Chiamata1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Chiamata2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Chiamata2"
							p.Value = cls.Chiamata2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOperatore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOperatore"
							p.Value = cls.IdOperatore
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRif"
							p.Value = cls.IdRif
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

						If cls.WhatIsChanged.TipoLog Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoLog"
							p.Value = cls.TipoLog
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdLog=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdLog = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdLog
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLog
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
				'Dim Sql As String = "UPDATE Logoperativi SET DELETED=True "
				Dim Sql As String = "DELETE FROM Logoperativi"
				Sql &= " WHERE IdLog = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Logoperativi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Logoperativi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as LogOperativo, Optional ByRef ListaObj as List (of LogOperativo) = Nothing)
		DestroyPermanently (obj.IdLog)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LogOperativo
		Dim ris As LogOperativo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of LogOperativo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return first of LogOperativo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LogOperativo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return first of LogOperativo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LogOperativo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table LogOperativo
	''' </summary>
	''' <returns>
	'''Return first of LogOperativo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LogOperativo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LogOperativo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LogOperativo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LogOperativo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LogOperativo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LogOperativo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of LogOperativo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Logoperativi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of LogOperativo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of LogOperativo)
		Dim Ls As New List(Of LogOperativo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of LogOperativo)
		Dim Ls As New List(Of LogOperativo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Logoperativi" 
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
	'''Return all record on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return all record in list of LogOperativo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of LogOperativo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return all record in list of LogOperativo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LogOperativo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Logoperativi
	''' </summary>
	''' <returns>
	'''Return all record in list of LogOperativo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LogOperativo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LogOperativo)
		Dim Ls As List(Of LogOperativo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Logoperativi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LogOperativo)
		Dim Ls As New List(Of LogOperativo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  LogOperativo() With {.IdLog = 0 ,.Buffer = "" ,.Chiamata1 = "" ,.Chiamata2 = "" ,.IdOperatore = 0 ,.IdRif = 0 ,.Quando = Nothing ,.TipoLog = 0  })
					While myReader.Read
						Dim classe as new LogOperativo(CType(myReader, IDataRecord))
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