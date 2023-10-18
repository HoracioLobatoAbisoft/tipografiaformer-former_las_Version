#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of AmmortamentoCosto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _AmmortamentoCostiDAO
	Inherits LUNA.LunaBaseClassDAO(Of AmmortamentoCosto)

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
	'''Read from DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a AmmortamentoCosto object
	''' </returns>
	Public Overrides Function Read(Id as integer) as AmmortamentoCosto
		Dim cls as new AmmortamentoCosto

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Ammortamentocosti WHERE IdAmmCosto = " & Id
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
	'''Save on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as AmmortamentoCosto) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdAmmCosto = 0 Then
							sql = "INSERT INTO Ammortamentocosti ("
							sql &= " Anni,"
							sql &= " AnnoEnd,"
							sql &= " AnnoStart,"
							sql &= " IdAzienda,"
							sql &= " IdCosto,"
							sql &= " ImportoAnnuo,"
							sql &= " ImportoTotale,"
							sql &= " PercTotale"
							sql &= ") VALUES ("
							sql &= " @Anni,"
							sql &= " @AnnoEnd,"
							sql &= " @AnnoStart,"
							sql &= " @IdAzienda,"
							sql &= " @IdCosto,"
							sql &= " @ImportoAnnuo,"
							sql &= " @ImportoTotale,"
							sql &= " @PercTotale"
							sql &= ")"
						Else
							sql = "UPDATE Ammortamentocosti SET "
							If cls.WhatIsChanged.Anni Then sql &= "Anni = @Anni,"
							If cls.WhatIsChanged.AnnoEnd Then sql &= "AnnoEnd = @AnnoEnd,"
							If cls.WhatIsChanged.AnnoStart Then sql &= "AnnoStart = @AnnoStart,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.IdCosto Then sql &= "IdCosto = @IdCosto,"
							If cls.WhatIsChanged.ImportoAnnuo Then sql &= "ImportoAnnuo = @ImportoAnnuo,"
							If cls.WhatIsChanged.ImportoTotale Then sql &= "ImportoTotale = @ImportoTotale,"
							If cls.WhatIsChanged.PercTotale Then sql &= "PercTotale = @PercTotale"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdAmmCosto= " & cls.IdAmmCosto
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Anni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Anni"
							p.Value = cls.Anni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AnnoEnd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AnnoEnd"
							p.Value = cls.AnnoEnd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AnnoStart Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AnnoStart"
							p.Value = cls.AnnoStart
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAzienda"
							p.Value = cls.IdAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCosto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCosto"
							p.Value = cls.IdCosto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoAnnuo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoAnnuo"
							p.Value = cls.ImportoAnnuo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoTotale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoTotale"
							p.Value = cls.ImportoTotale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercTotale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercTotale"
							p.Value = cls.PercTotale
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdAmmCosto=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdAmmCosto = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdAmmCosto
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdAmmCosto
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
				'Dim Sql As String = "UPDATE Ammortamentocosti SET DELETED=True "
				Dim Sql As String = "DELETE FROM Ammortamentocosti"
				Sql &= " WHERE IdAmmCosto = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Ammortamentocosti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Ammortamentocosti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as AmmortamentoCosto, Optional ByRef ListaObj as List (of AmmortamentoCosto) = Nothing)
		DestroyPermanently (obj.IdAmmCosto)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AmmortamentoCosto
		Dim ris As AmmortamentoCosto = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of AmmortamentoCosto) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return first of AmmortamentoCosto
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AmmortamentoCosto
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return first of AmmortamentoCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AmmortamentoCosto
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table AmmortamentoCosto
	''' </summary>
	''' <returns>
	'''Return first of AmmortamentoCosto
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AmmortamentoCosto
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AmmortamentoCosto)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AmmortamentoCosto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AmmortamentoCosto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AmmortamentoCosto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AmmortamentoCosto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of AmmortamentoCosto)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ammortamentocosti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of AmmortamentoCosto by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of AmmortamentoCosto)
		Dim Ls As New List(Of AmmortamentoCosto)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of AmmortamentoCosto)
		Dim Ls As New List(Of AmmortamentoCosto)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Ammortamentocosti" 
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
	'''Return all record on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return all record in list of AmmortamentoCosto
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of AmmortamentoCosto)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return all record in list of AmmortamentoCosto
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AmmortamentoCosto)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Ammortamentocosti
	''' </summary>
	''' <returns>
	'''Return all record in list of AmmortamentoCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AmmortamentoCosto)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AmmortamentoCosto)
		Dim Ls As List(Of AmmortamentoCosto)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Ammortamentocosti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AmmortamentoCosto)
		Dim Ls As New List(Of AmmortamentoCosto)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  AmmortamentoCosto() With {.IdAmmCosto = 0 ,.Anni = 0 ,.AnnoEnd = 0 ,.AnnoStart = 0 ,.IdAzienda = 0 ,.IdCosto = 0 ,.ImportoAnnuo = 0 ,.ImportoTotale = 0 ,.PercTotale = 0  })
					While myReader.Read
						Dim classe as new AmmortamentoCosto(CType(myReader, IDataRecord))
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