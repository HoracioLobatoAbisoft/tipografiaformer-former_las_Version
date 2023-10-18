#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of PagamentoOnline object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PagamentiOnlineDAO
	Inherits LUNA.LunaBaseClassDAO(Of PagamentoOnline)

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
	'''Read from DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a PagamentoOnline object
	''' </returns>
	Public Overrides Function Read(Id as integer) as PagamentoOnline
		Dim cls as new PagamentoOnline

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Pagamentionline WHERE IdPagamentoOnline = " & Id
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
	'''Save on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as PagamentoOnline) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdPagamentoOnline = 0 Then
							sql = "INSERT INTO Pagamentionline ("
							sql &= " IdConsegna,"
							sql &= " IdPagInt,"
							sql &= " IdTipoPagamento,"
							sql &= " IdUt,"
							sql &= " Importo,"
							sql &= " Quando,"
							sql &= " StatoPagamento"
							sql &= ") VALUES ("
							sql &= " @IdConsegna,"
							sql &= " @IdPagInt,"
							sql &= " @IdTipoPagamento,"
							sql &= " @IdUt,"
							sql &= " @Importo,"
							sql &= " @Quando,"
							sql &= " @StatoPagamento"
							sql &= ")"
						Else
							sql = "UPDATE Pagamentionline SET "
							If cls.WhatIsChanged.IdConsegna Then sql &= "IdConsegna = @IdConsegna,"
							If cls.WhatIsChanged.IdPagInt Then sql &= "IdPagInt = @IdPagInt,"
							If cls.WhatIsChanged.IdTipoPagamento Then sql &= "IdTipoPagamento = @IdTipoPagamento,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.Importo Then sql &= "Importo = @Importo,"
							If cls.WhatIsChanged.Quando Then sql &= "Quando = @Quando,"
							If cls.WhatIsChanged.StatoPagamento Then sql &= "StatoPagamento = @StatoPagamento"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdPagamentoOnline= " & cls.IdPagamentoOnline
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdConsegna"
							p.Value = cls.IdConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPagInt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPagInt"
							p.Value = cls.IdPagInt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoPagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoPagamento"
							p.Value = cls.IdTipoPagamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Importo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Importo"
							p.Value = cls.Importo
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

						If cls.WhatIsChanged.StatoPagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoPagamento"
							p.Value = cls.StatoPagamento
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdPagamentoOnline=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdPagamentoOnline = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdPagamentoOnline
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdPagamentoOnline
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
				'Dim Sql As String = "UPDATE Pagamentionline SET DELETED=True "
				Dim Sql As String = "DELETE FROM Pagamentionline"
				Sql &= " WHERE IdPagamentoOnline = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Pagamentionline. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Pagamentionline. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as PagamentoOnline, Optional ByRef ListaObj as List (of PagamentoOnline) = Nothing)
		DestroyPermanently (obj.IdPagamentoOnline)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PagamentoOnline
		Dim ris As PagamentoOnline = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of PagamentoOnline) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return first of PagamentoOnline
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PagamentoOnline
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return first of PagamentoOnline
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PagamentoOnline
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table PagamentoOnline
	''' </summary>
	''' <returns>
	'''Return first of PagamentoOnline
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PagamentoOnline
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PagamentoOnline)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PagamentoOnline)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PagamentoOnline)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PagamentoOnline)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PagamentoOnline)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of PagamentoOnline)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Pagamentionline by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of PagamentoOnline by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of PagamentoOnline)
		Dim Ls As New List(Of PagamentoOnline)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of PagamentoOnline)
		Dim Ls As New List(Of PagamentoOnline)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Pagamentionline" 
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
	'''Return all record on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return all record in list of PagamentoOnline
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of PagamentoOnline)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return all record in list of PagamentoOnline
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PagamentoOnline)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Pagamentionline
	''' </summary>
	''' <returns>
	'''Return all record in list of PagamentoOnline
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PagamentoOnline)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PagamentoOnline)
		Dim Ls As List(Of PagamentoOnline)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Pagamentionline" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PagamentoOnline)
		Dim Ls As New List(Of PagamentoOnline)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  PagamentoOnline() With {.IdPagamentoOnline = 0 ,.IdConsegna = 0 ,.IdPagInt = 0 ,.IdTipoPagamento = 0 ,.IdUt = 0 ,.Importo = 0 ,.Quando = Nothing ,.StatoPagamento = 0  })
					While myReader.Read
						Dim classe as new PagamentoOnline(CType(myReader, IDataRecord))
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