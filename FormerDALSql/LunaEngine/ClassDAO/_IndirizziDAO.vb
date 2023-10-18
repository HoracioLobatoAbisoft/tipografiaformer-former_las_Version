#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 21/02/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Indirizzo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _IndirizziDAO
	Inherits LUNA.LunaBaseClassDAO(Of Indirizzo)

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
	'''Read from DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a Indirizzo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Indirizzo
		Dim cls as new Indirizzo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_indirizzi WHERE IDIndirizzo = " & Id
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
	'''Save on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Indirizzo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IDIndirizzo = 0 Then
							sql = "INSERT INTO T_indirizzi ("
							sql &= " Cap,"
							sql &= " Citta,"
							sql &= " Destinatario,"
							sql &= " IdComune,"
							sql &= " IdIndOnline,"
							sql &= " IdNazione,"
							sql &= " IdProvincia,"
							sql &= " IdRubrica,"
							sql &= " Indirizzo,"
							sql &= " Nome,"
							sql &= " Predefinito,"
							sql &= " Presso,"
							sql &= " Status,"
							sql &= " Telefono"
							sql &= ") VALUES ("
							sql &= " @Cap,"
							sql &= " @Citta,"
							sql &= " @Destinatario,"
							sql &= " @IdComune,"
							sql &= " @IdIndOnline,"
							sql &= " @IdNazione,"
							sql &= " @IdProvincia,"
							sql &= " @IdRubrica,"
							sql &= " @Indirizzo,"
							sql &= " @Nome,"
							sql &= " @Predefinito,"
							sql &= " @Presso,"
							sql &= " @Status,"
							sql &= " @Telefono"
							sql &= ")"
						Else
							sql = "UPDATE T_indirizzi SET "
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.Destinatario Then sql &= "Destinatario = @Destinatario,"
							If cls.WhatIsChanged.IdComune Then sql &= "IdComune = @IdComune,"
							If cls.WhatIsChanged.IdIndOnline Then sql &= "IdIndOnline = @IdIndOnline,"
							If cls.WhatIsChanged.IdNazione Then sql &= "IdNazione = @IdNazione,"
							If cls.WhatIsChanged.IdProvincia Then sql &= "IdProvincia = @IdProvincia,"
							If cls.WhatIsChanged.IdRubrica Then sql &= "IdRubrica = @IdRubrica,"
							If cls.WhatIsChanged.Indirizzo Then sql &= "Indirizzo = @Indirizzo,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.Predefinito Then sql &= "Predefinito = @Predefinito,"
							If cls.WhatIsChanged.Presso Then sql &= "Presso = @Presso,"
							If cls.WhatIsChanged.Status Then sql &= "Status = @Status,"
							If cls.WhatIsChanged.Telefono Then sql &= "Telefono = @Telefono"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IDIndirizzo= " & cls.IDIndirizzo
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Cap Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cap"
							p.Value = cls.Cap
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Citta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Citta"
							p.Value = cls.Citta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Destinatario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Destinatario"
							p.Value = cls.Destinatario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdComune Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdComune"
							p.Value = cls.IdComune
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdIndOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdIndOnline"
							p.Value = cls.IdIndOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdNazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdNazione"
							p.Value = cls.IdNazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdProvincia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdProvincia"
							p.Value = cls.IdProvincia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRubrica Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRubrica"
							p.Value = cls.IdRubrica
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Indirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Indirizzo"
							p.Value = cls.Indirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Predefinito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Predefinito"
							p.Value = cls.Predefinito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Presso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Presso"
							p.Value = cls.Presso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Status Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Status"
							p.Value = cls.Status
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Telefono Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Telefono"
							p.Value = cls.Telefono
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IDIndirizzo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IDIndirizzo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IDIndirizzo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IDIndirizzo
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
				'Dim Sql As String = "UPDATE T_indirizzi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_indirizzi"
				Sql &= " WHERE IDIndirizzo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_indirizzi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_indirizzi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Indirizzo, Optional ByRef ListaObj as List (of Indirizzo) = Nothing)
		DestroyPermanently (obj.IDIndirizzo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Indirizzo
		Dim ris As Indirizzo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Indirizzo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return first of Indirizzo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Indirizzo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return first of Indirizzo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Indirizzo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Indirizzo
	''' </summary>
	''' <returns>
	'''Return first of Indirizzo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Indirizzo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Indirizzo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Indirizzo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Indirizzo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Indirizzo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Indirizzo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Indirizzo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_indirizzi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Indirizzo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Indirizzo)
		Dim Ls As New List(Of Indirizzo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Indirizzo)
		Dim Ls As New List(Of Indirizzo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_indirizzi" 
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
	'''Return all record on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return all record in list of Indirizzo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Indirizzo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return all record in list of Indirizzo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Indirizzo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_indirizzi
	''' </summary>
	''' <returns>
	'''Return all record in list of Indirizzo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Indirizzo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Indirizzo)
		Dim Ls As List(Of Indirizzo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_indirizzi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Indirizzo)
		Dim Ls As New List(Of Indirizzo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Indirizzo() With {.IDIndirizzo = 0 ,.Cap = "" ,.Citta = "" ,.Destinatario = "" ,.IdComune = 0 ,.IdIndOnline = 0 ,.IdNazione = 0 ,.IdProvincia = 0 ,.IdRubrica = 0 ,.Indirizzo = "" ,.Nome = "" ,.Predefinito = False ,.Presso = "" ,.Status = 0 ,.Telefono = ""  })
					While myReader.Read
						Dim classe as new Indirizzo(CType(myReader, IDataRecord))
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