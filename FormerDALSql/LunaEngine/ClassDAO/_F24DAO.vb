#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 27/12/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of F24 object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _F24DAO
	Inherits LUNA.LunaBaseClassDAO(Of F24)

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
	'''Read from DB table F24
	''' </summary>
	''' <returns>
	'''Return a F24 object
	''' </returns>
	Public Overrides Function Read(Id as integer) as F24
		Dim cls as new F24

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM F24 WHERE IdF24 = " & Id
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
	'''Save on DB table F24
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as F24) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdF24 = 0 Then
							sql = "INSERT INTO F24 ("
							sql &= " Descrizione,"
							sql &= " IdAzienda,"
							sql &= " InseritoIl,"
							sql &= " NotePagamento,"
							sql &= " PagatoIl,"
							sql &= " Totale"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @IdAzienda,"
							sql &= " @InseritoIl,"
							sql &= " @NotePagamento,"
							sql &= " @PagatoIl,"
							sql &= " @Totale"
							sql &= ")"
						Else
							sql = "UPDATE F24 SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.InseritoIl Then sql &= "InseritoIl = @InseritoIl,"
							If cls.WhatIsChanged.NotePagamento Then sql &= "NotePagamento = @NotePagamento,"
							If cls.WhatIsChanged.PagatoIl Then sql &= "PagatoIl = @PagatoIl,"
							If cls.WhatIsChanged.Totale Then sql &= "Totale = @Totale"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdF24= " & cls.IdF24
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAzienda"
							p.Value = cls.IdAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InseritoIl Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InseritoIl"
							p.DbType = DbType.DateTime
							If cls.InseritoIl <> Date.MinValue Then
								p.Value = cls.InseritoIl
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NotePagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NotePagamento"
							p.Value = cls.NotePagamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PagatoIl Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PagatoIl"
							p.DbType = DbType.DateTime
							If cls.PagatoIl <> Date.MinValue Then
								p.Value = cls.PagatoIl
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Totale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Totale"
							p.Value = cls.Totale
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdF24=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdF24 = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdF24
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdF24
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
				'Dim Sql As String = "UPDATE F24 SET DELETED=True "
				Dim Sql As String = "DELETE FROM F24"
				Sql &= " WHERE IdF24 = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table F24. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table F24. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as F24, Optional ByRef ListaObj as List (of F24) = Nothing)
		DestroyPermanently (obj.IdF24)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24
		Dim ris As F24 = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of F24) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table F24
	''' </summary>
	''' <returns>
	'''Return first of F24
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table F24
	''' </summary>
	''' <returns>
	'''Return first of F24
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table F24
	''' </summary>
	''' <returns>
	'''Return first of F24
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24
	''' </summary>
	''' <returns>
	'''Return a list of F24
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of F24)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24 by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of F24 by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of F24)
		Dim Ls As New List(Of F24)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of F24)
		Dim Ls As New List(Of F24)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM F24" 
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
	'''Return all record on DB table F24
	''' </summary>
	''' <returns>
	'''Return all record in list of F24
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of F24)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table F24
	''' </summary>
	''' <returns>
	'''Return all record in list of F24
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of F24)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table F24
	''' </summary>
	''' <returns>
	'''Return all record in list of F24
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of F24)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of F24)
		Dim Ls As List(Of F24)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM F24" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of F24)
		Dim Ls As New List(Of F24)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  F24() With {.IdF24 = 0 ,.Descrizione = EmptyItemDescription,.IdAzienda = 0 ,.InseritoIl = Nothing ,.NotePagamento = "" ,.PagatoIl = Nothing ,.Totale = 0  })
					While myReader.Read
						Dim classe as new F24(CType(myReader, IDataRecord))
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