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
'''This class manage persistency on db of Comune object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ComuniDAO
	Inherits LUNA.LunaBaseClassDAO(Of Comune)

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
	'''Read from DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a Comune object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Comune
		Dim cls as new Comune

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Comuni WHERE ID = " & Id
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
	'''Save on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Comune) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.ID = 0 Then
							sql = "INSERT INTO Comuni ("
							sql &= " ID,"
							sql &= " CAP,"
							sql &= " CODCOMUNE,"
							sql &= " DESCCOMUNE,"
							sql &= " DTVARIAZIONE,"
							sql &= " FLGVARIAZIONE,"
							sql &= " IDPROV,"
							sql &= " ordine,"
							sql &= " SGLCATASTALE,"
							sql &= " SGLNAZIONALE"
							sql &= ") VALUES ("
							sql &= " @ID,"
							sql &= " @CAP,"
							sql &= " @CODCOMUNE,"
							sql &= " @DESCCOMUNE,"
							sql &= " @DTVARIAZIONE,"
							sql &= " @FLGVARIAZIONE,"
							sql &= " @IDPROV,"
							sql &= " @ordine,"
							sql &= " @SGLCATASTALE,"
							sql &= " @SGLNAZIONALE"
							sql &= ")"
						Else
							sql = "UPDATE Comuni SET "
							If cls.WhatIsChanged.ID Then sql &= "ID = @ID,"
							If cls.WhatIsChanged.CAP Then sql &= "CAP = @CAP,"
							If cls.WhatIsChanged.CODCOMUNE Then sql &= "CODCOMUNE = @CODCOMUNE,"
							If cls.WhatIsChanged.DESCCOMUNE Then sql &= "DESCCOMUNE = @DESCCOMUNE,"
							If cls.WhatIsChanged.DTVARIAZIONE Then sql &= "DTVARIAZIONE = @DTVARIAZIONE,"
							If cls.WhatIsChanged.FLGVARIAZIONE Then sql &= "FLGVARIAZIONE = @FLGVARIAZIONE,"
							If cls.WhatIsChanged.IDPROV Then sql &= "IDPROV = @IDPROV,"
							If cls.WhatIsChanged.ordine Then sql &= "ordine = @ordine,"
							If cls.WhatIsChanged.SGLCATASTALE Then sql &= "SGLCATASTALE = @SGLCATASTALE,"
							If cls.WhatIsChanged.SGLNAZIONALE Then sql &= "SGLNAZIONALE = @SGLNAZIONALE"
							sql = sql.TrimEnd(",")
							sql &= " WHERE ID= " & cls.ID
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.ID Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ID"
							p.Value = cls.ID
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CAP Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CAP"
							p.Value = cls.CAP
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CODCOMUNE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CODCOMUNE"
							p.Value = cls.CODCOMUNE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DESCCOMUNE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DESCCOMUNE"
							p.Value = cls.DESCCOMUNE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DTVARIAZIONE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DTVARIAZIONE"
							p.Value = cls.DTVARIAZIONE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FLGVARIAZIONE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FLGVARIAZIONE"
							p.Value = cls.FLGVARIAZIONE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IDPROV Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IDPROV"
							p.Value = cls.IDPROV
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ordine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ordine"
							p.Value = cls.ordine
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SGLCATASTALE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SGLCATASTALE"
							p.Value = cls.SGLCATASTALE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SGLNAZIONALE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SGLNAZIONALE"
							p.Value = cls.SGLNAZIONALE
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

						Ris = cls.ID
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.ID
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
				'Dim Sql As String = "UPDATE Comuni SET DELETED=True "
				Dim Sql As String = "DELETE FROM Comuni"
				Sql &= " WHERE ID = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Comuni. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Comuni. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Comune, Optional ByRef ListaObj as List (of Comune) = Nothing)
		DestroyPermanently (obj.ID)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Comune
		Dim ris As Comune = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Comune) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return first of Comune
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Comune
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return first of Comune
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Comune
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Comune
	''' </summary>
	''' <returns>
	'''Return first of Comune
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Comune
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Comune)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Comune)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Comune)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Comune)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Comune)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return a list of Comune
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Comune)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comuni by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Comune by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Comune)
		Dim Ls As New List(Of Comune)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Comune)
		Dim Ls As New List(Of Comune)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Comuni" 
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
	'''Return all record on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return all record in list of Comune
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Comune)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return all record in list of Comune
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Comune)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Comuni
	''' </summary>
	''' <returns>
	'''Return all record in list of Comune
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Comune)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Comune)
		Dim Ls As List(Of Comune)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Comuni" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Comune)
		Dim Ls As New List(Of Comune)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Comune() With {.ID = 0 ,.CAP = "" ,.CODCOMUNE = 0 ,.DESCCOMUNE = "" ,.DTVARIAZIONE = "" ,.FLGVARIAZIONE = 0 ,.IDPROV = 0 ,.ordine = 0 ,.SGLCATASTALE = "" ,.SGLNAZIONALE = ""  })
					While myReader.Read
						Dim classe as new Comune(CType(myReader, IDataRecord))
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