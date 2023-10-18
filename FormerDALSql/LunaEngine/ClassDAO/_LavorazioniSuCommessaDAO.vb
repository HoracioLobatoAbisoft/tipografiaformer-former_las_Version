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
'''This class manage persistency on db of LavorazioniSuCommessa object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _LavorazioniSuCommessaDAO
	Inherits LUNA.LunaBaseClassDAO(Of LavorazioniSuCommessa)

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
	'''Read from DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a LavorazioniSuCommessa object
	''' </returns>
	Public Overrides Function Read(Id as integer) as LavorazioniSuCommessa
		Dim cls as new LavorazioniSuCommessa

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Tr_lavori WHERE IdLavRel = " & Id
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
	'''Save on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as LavorazioniSuCommessa) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLavRel = 0 Then
							sql = "INSERT INTO Tr_lavori ("
							sql &= " IdLav,"
							sql &= " IdProd,"
							sql &= " IdTipoCom,"
							sql &= " Opzione,"
							sql &= " Ordine"
							sql &= ") VALUES ("
							sql &= " @IdLav,"
							sql &= " @IdProd,"
							sql &= " @IdTipoCom,"
							sql &= " @Opzione,"
							sql &= " @Ordine"
							sql &= ")"
						Else
							sql = "UPDATE Tr_lavori SET "
							If cls.WhatIsChanged.IdLav Then sql &= "IdLav = @IdLav,"
							If cls.WhatIsChanged.IdProd Then sql &= "IdProd = @IdProd,"
							If cls.WhatIsChanged.IdTipoCom Then sql &= "IdTipoCom = @IdTipoCom,"
							If cls.WhatIsChanged.Opzione Then sql &= "Opzione = @Opzione,"
							If cls.WhatIsChanged.Ordine Then sql &= "Ordine = @Ordine"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLavRel= " & cls.IdLavRel
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@IdLav"
						p.Value = cls.IdLav
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdProd"
						p.Value = cls.IdProd
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdTipoCom"
						p.Value = cls.IdTipoCom
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Opzione"
						p.Value = cls.Opzione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Ordine"
						p.Value = cls.Ordine
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdLavRel=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdLavRel = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdLavRel
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLavRel
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
				'Dim Sql As String = "UPDATE Tr_lavori SET DELETED=True "
				Dim Sql As String = "DELETE FROM Tr_lavori"
				Sql &= " WHERE IdLavRel = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Tr_lavori. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Tr_lavori. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as LavorazioniSuCommessa, Optional ByRef ListaObj as List (of LavorazioniSuCommessa) = Nothing)
		DestroyPermanently (obj.IdLavRel)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioniSuCommessa
		Dim ris As LavorazioniSuCommessa = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of LavorazioniSuCommessa) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return first of LavorazioniSuCommessa
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioniSuCommessa
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return first of LavorazioniSuCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioniSuCommessa
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table LavorazioniSuCommessa
	''' </summary>
	''' <returns>
	'''Return first of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioniSuCommessa
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioniSuCommessa)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioniSuCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioniSuCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioniSuCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioniSuCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of LavorazioniSuCommessa)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_lavori by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioniSuCommessa by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioniSuCommessa)
		Dim Ls As New List(Of LavorazioniSuCommessa)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of LavorazioniSuCommessa)
		Dim Ls As New List(Of LavorazioniSuCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Tr_lavori" 
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
	'''Return all record on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of LavorazioniSuCommessa)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioniSuCommessa
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioniSuCommessa)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Tr_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioniSuCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioniSuCommessa)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavorazioniSuCommessa)
		Dim Ls As List(Of LavorazioniSuCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Tr_lavori" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavorazioniSuCommessa)
		Dim Ls As New List(Of LavorazioniSuCommessa)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  LavorazioniSuCommessa() With {.IdLavRel = 0 ,.IdLav = 0 ,.IdProd = 0 ,.IdTipoCom = 0 ,.Opzione = False ,.Ordine = 0  })
					While myReader.Read
						Dim classe as new LavorazioniSuCommessa(CType(myReader, IDataRecord))
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