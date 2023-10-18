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
'''This class manage persistency on db of ListinoUtenteW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ListiniUtenteWDAO
	Inherits LUNA.LunaBaseClassDAO(Of ListinoUtenteW)

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
	'''Read from DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a ListinoUtenteW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ListinoUtenteW
		Dim cls as new ListinoUtenteW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Listiniutente WHERE IdListino = " & Id
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
	'''Save on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ListinoUtenteW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdListino = 0 Then
							sql = "INSERT INTO Listiniutente ("
							sql &= " IdUt,"
							sql &= " PercDefault,"
							sql &= " UltimaGenerazione,"
							sql &= " UltimoAccesso"
							sql &= ") VALUES ("
							sql &= " @IdUt,"
							sql &= " @PercDefault,"
							sql &= " @UltimaGenerazione,"
							sql &= " @UltimoAccesso"
							sql &= ")"
						Else
							sql = "UPDATE Listiniutente SET "
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.PercDefault Then sql &= "PercDefault = @PercDefault,"
							If cls.WhatIsChanged.UltimaGenerazione Then sql &= "UltimaGenerazione = @UltimaGenerazione,"
							If cls.WhatIsChanged.UltimoAccesso Then sql &= "UltimoAccesso = @UltimoAccesso"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdListino= " & cls.IdListino
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercDefault Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercDefault"
							p.Value = cls.PercDefault
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UltimaGenerazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UltimaGenerazione"
							p.DbType = DbType.DateTime
							If cls.UltimaGenerazione <> Date.MinValue Then
								p.Value = cls.UltimaGenerazione
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UltimoAccesso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UltimoAccesso"
							p.DbType = DbType.DateTime
							If cls.UltimoAccesso <> Date.MinValue Then
								p.Value = cls.UltimoAccesso
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdListino=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdListino = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdListino
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdListino
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
				'Dim Sql As String = "UPDATE Listiniutente SET DELETED=True "
				Dim Sql As String = "DELETE FROM Listiniutente"
				Sql &= " WHERE IdListino = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Listiniutente. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Listiniutente. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ListinoUtenteW, Optional ByRef ListaObj as List (of ListinoUtenteW) = Nothing)
		DestroyPermanently (obj.IdListino)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoUtenteW
		Dim ris As ListinoUtenteW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ListinoUtenteW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return first of ListinoUtenteW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoUtenteW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return first of ListinoUtenteW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoUtenteW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ListinoUtenteW
	''' </summary>
	''' <returns>
	'''Return first of ListinoUtenteW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoUtenteW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoUtenteW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoUtenteW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoUtenteW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoUtenteW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoUtenteW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ListinoUtenteW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listiniutente by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ListinoUtenteW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoUtenteW)
		Dim Ls As New List(Of ListinoUtenteW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ListinoUtenteW)
		Dim Ls As New List(Of ListinoUtenteW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Listiniutente" 
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
	'''Return all record on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoUtenteW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ListinoUtenteW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoUtenteW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoUtenteW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Listiniutente
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoUtenteW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoUtenteW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ListinoUtenteW)
		Dim Ls As List(Of ListinoUtenteW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Listiniutente" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ListinoUtenteW)
		Dim Ls As New List(Of ListinoUtenteW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ListinoUtenteW() With {.IdListino = 0 ,.IdUt = 0 ,.PercDefault = 0 ,.UltimaGenerazione = Nothing ,.UltimoAccesso = Nothing  })
					While myReader.Read
						Dim classe as new ListinoUtenteW(CType(myReader, IDataRecord))
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