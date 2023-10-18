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
'''This class manage persistency on db of CurvaAttW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CurvaAttWDAO
	Inherits LUNA.LunaBaseClassDAO(Of CurvaAttW)

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
	'''Read from DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a CurvaAttW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as CurvaAttW
		Dim cls as new CurvaAttW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_curvaatt WHERE IdCurvaAtt = " & Id
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
	'''Save on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as CurvaAttW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCurvaAtt = 0 Then
							sql = "INSERT INTO T_curvaatt ("
							sql &= " NomeCurva,"
							sql &= " v1,"
							sql &= " v2,"
							sql &= " v3,"
							sql &= " v4,"
							sql &= " v5,"
							sql &= " v6"
							sql &= ") VALUES ("
							sql &= " @NomeCurva,"
							sql &= " @v1,"
							sql &= " @v2,"
							sql &= " @v3,"
							sql &= " @v4,"
							sql &= " @v5,"
							sql &= " @v6"
							sql &= ")"
						Else
							sql = "UPDATE T_curvaatt SET "
							If cls.WhatIsChanged.NomeCurva Then sql &= "NomeCurva = @NomeCurva,"
							If cls.WhatIsChanged.v1 Then sql &= "v1 = @v1,"
							If cls.WhatIsChanged.v2 Then sql &= "v2 = @v2,"
							If cls.WhatIsChanged.v3 Then sql &= "v3 = @v3,"
							If cls.WhatIsChanged.v4 Then sql &= "v4 = @v4,"
							If cls.WhatIsChanged.v5 Then sql &= "v5 = @v5,"
							If cls.WhatIsChanged.v6 Then sql &= "v6 = @v6"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCurvaAtt= " & cls.IdCurvaAtt
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.NomeCurva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeCurva"
							p.Value = cls.NomeCurva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v1"
							p.Value = cls.v1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v2"
							p.Value = cls.v2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v3"
							p.Value = cls.v3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v4"
							p.Value = cls.v4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v5 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v5"
							p.Value = cls.v5
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v6 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v6"
							p.Value = cls.v6
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCurvaAtt=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCurvaAtt = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCurvaAtt
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCurvaAtt
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
				'Dim Sql As String = "UPDATE T_curvaatt SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_curvaatt"
				Sql &= " WHERE IdCurvaAtt = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_curvaatt. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_curvaatt. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as CurvaAttW, Optional ByRef ListaObj as List (of CurvaAttW) = Nothing)
		DestroyPermanently (obj.IdCurvaAtt)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CurvaAttW
		Dim ris As CurvaAttW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of CurvaAttW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return first of CurvaAttW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CurvaAttW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return first of CurvaAttW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CurvaAttW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table CurvaAttW
	''' </summary>
	''' <returns>
	'''Return first of CurvaAttW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CurvaAttW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CurvaAttW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CurvaAttW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CurvaAttW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CurvaAttW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CurvaAttW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of CurvaAttW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_curvaatt by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of CurvaAttW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of CurvaAttW)
		Dim Ls As New List(Of CurvaAttW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of CurvaAttW)
		Dim Ls As New List(Of CurvaAttW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_curvaatt" 
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
	'''Return all record on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return all record in list of CurvaAttW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of CurvaAttW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return all record in list of CurvaAttW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CurvaAttW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_curvaatt
	''' </summary>
	''' <returns>
	'''Return all record in list of CurvaAttW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CurvaAttW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CurvaAttW)
		Dim Ls As List(Of CurvaAttW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_curvaatt" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CurvaAttW)
		Dim Ls As New List(Of CurvaAttW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  CurvaAttW() With {.IdCurvaAtt = 0 ,.NomeCurva = "" ,.v1 = 0 ,.v2 = 0 ,.v3 = 0 ,.v4 = 0 ,.v5 = 0 ,.v6 = 0  })
					While myReader.Read
						Dim classe as new CurvaAttW(CType(myReader, IDataRecord))
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