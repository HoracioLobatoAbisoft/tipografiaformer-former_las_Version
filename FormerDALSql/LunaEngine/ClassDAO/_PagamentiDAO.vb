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
'''This class manage persistency on db of Pagamento object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PagamentiDAO
	Inherits LUNA.LunaBaseClassDAO(Of Pagamento)

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
	'''Read from DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a Pagamento object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Pagamento
		Dim cls as new Pagamento

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_pagamenti WHERE IdPag = " & Id
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
	'''Save on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Pagamento) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdPag = 0 Then
							sql = "INSERT INTO T_pagamenti ("
							sql &= " DataPag,"
							sql &= " Descrizione,"
							sql &= " IdConsegna,"
							sql &= " IdFat,"
							sql &= " IdRub,"
							sql &= " IdTipoPagamento,"
							sql &= " Importo,"
							sql &= " NotePag,"
							sql &= " Tipo"
							sql &= ") VALUES ("
							sql &= " @DataPag,"
							sql &= " @Descrizione,"
							sql &= " @IdConsegna,"
							sql &= " @IdFat,"
							sql &= " @IdRub,"
							sql &= " @IdTipoPagamento,"
							sql &= " @Importo,"
							sql &= " @NotePag,"
							sql &= " @Tipo"
							sql &= ")"
						Else
							sql = "UPDATE T_pagamenti SET "
							If cls.WhatIsChanged.DataPag Then sql &= "DataPag = @DataPag,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.IdConsegna Then sql &= "IdConsegna = @IdConsegna,"
							If cls.WhatIsChanged.IdFat Then sql &= "IdFat = @IdFat,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdTipoPagamento Then sql &= "IdTipoPagamento = @IdTipoPagamento,"
							If cls.WhatIsChanged.Importo Then sql &= "Importo = @Importo,"
							If cls.WhatIsChanged.NotePag Then sql &= "NotePag = @NotePag,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdPag= " & cls.IdPag
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@DataPag"
						p.DbType = DbType.DateTime
						If cls.DataPag <> Date.MinValue Then
							p.Value = cls.DataPag
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Descrizione"
						p.Value = cls.Descrizione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdConsegna"
						p.Value = cls.IdConsegna
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdFat"
						p.Value = cls.IdFat
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdRub"
						p.Value = cls.IdRub
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdTipoPagamento"
						p.Value = cls.IdTipoPagamento
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Importo"
						p.Value = cls.Importo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NotePag"
						p.Value = cls.NotePag
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Tipo"
						p.Value = cls.Tipo
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdPag=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdPag = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdPag
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdPag
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
				'Dim Sql As String = "UPDATE T_pagamenti SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_pagamenti"
				Sql &= " WHERE IdPag = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_pagamenti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_pagamenti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Pagamento, Optional ByRef ListaObj as List (of Pagamento) = Nothing)
		DestroyPermanently (obj.IdPag)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Pagamento
		Dim ris As Pagamento = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Pagamento) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return first of Pagamento
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Pagamento
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return first of Pagamento
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Pagamento
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Pagamento
	''' </summary>
	''' <returns>
	'''Return first of Pagamento
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Pagamento
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Pagamento)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Pagamento)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Pagamento)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Pagamento)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Pagamento)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Pagamento)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_pagamenti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Pagamento by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Pagamento)
		Dim Ls As New List(Of Pagamento)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Pagamento)
		Dim Ls As New List(Of Pagamento)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_pagamenti" 
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
	'''Return all record on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Pagamento
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Pagamento)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Pagamento
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Pagamento)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_pagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Pagamento
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Pagamento)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Pagamento)
		Dim Ls As List(Of Pagamento)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_pagamenti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Pagamento)
		Dim Ls As New List(Of Pagamento)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Pagamento() With {.IdPag = 0 ,.DataPag = Nothing ,.Descrizione = EmptyItemDescription,.IdConsegna = 0 ,.IdFat = 0 ,.IdRub = 0 ,.IdTipoPagamento = 0 ,.Importo = 0 ,.NotePag = "" ,.Tipo = 0  })
					While myReader.Read
						Dim classe as new Pagamento(CType(myReader, IDataRecord))
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