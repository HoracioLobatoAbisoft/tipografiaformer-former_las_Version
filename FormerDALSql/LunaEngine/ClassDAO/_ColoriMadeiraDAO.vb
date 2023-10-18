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
'''This class manage persistency on db of ColoreMadeira object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ColoriMadeiraDAO
	Inherits LUNA.LunaBaseClassDAO(Of ColoreMadeira)

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
	'''Read from DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a ColoreMadeira object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ColoreMadeira
		Dim cls as new ColoreMadeira

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_madeira WHERE IdMadeira = " & Id
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
	'''Save on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ColoreMadeira) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdMadeira = 0 Then
							sql = "INSERT INTO T_madeira ("
							sql &= " Attivo,"
							sql &= " CodiceMadeira,"
							sql &= " CostoMillePunti,"
							sql &= " IdPantone,"
							sql &= " IdTavolozza"
							sql &= ") VALUES ("
							sql &= " @Attivo,"
							sql &= " @CodiceMadeira,"
							sql &= " @CostoMillePunti,"
							sql &= " @IdPantone,"
							sql &= " @IdTavolozza"
							sql &= ")"
						Else
							sql = "UPDATE T_madeira SET "
							If cls.WhatIsChanged.Attivo Then sql &= "Attivo = @Attivo,"
							If cls.WhatIsChanged.CodiceMadeira Then sql &= "CodiceMadeira = @CodiceMadeira,"
							If cls.WhatIsChanged.CostoMillePunti Then sql &= "CostoMillePunti = @CostoMillePunti,"
							If cls.WhatIsChanged.IdPantone Then sql &= "IdPantone = @IdPantone,"
							If cls.WhatIsChanged.IdTavolozza Then sql &= "IdTavolozza = @IdTavolozza"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdMadeira= " & cls.IdMadeira
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Attivo"
						p.Value = cls.Attivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@CodiceMadeira"
						p.Value = cls.CodiceMadeira
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@CostoMillePunti"
						p.Value = cls.CostoMillePunti
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdPantone"
						p.Value = cls.IdPantone
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdTavolozza"
						p.Value = cls.IdTavolozza
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdMadeira=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdMadeira = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdMadeira
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdMadeira
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
				'Dim Sql As String = "UPDATE T_madeira SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_madeira"
				Sql &= " WHERE IdMadeira = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_madeira. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_madeira. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ColoreMadeira, Optional ByRef ListaObj as List (of ColoreMadeira) = Nothing)
		DestroyPermanently (obj.IdMadeira)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreMadeira
		Dim ris As ColoreMadeira = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ColoreMadeira) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return first of ColoreMadeira
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreMadeira
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return first of ColoreMadeira
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreMadeira
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ColoreMadeira
	''' </summary>
	''' <returns>
	'''Return first of ColoreMadeira
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreMadeira
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreMadeira)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreMadeira)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreMadeira)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreMadeira)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreMadeira)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ColoreMadeira)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_madeira by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ColoreMadeira by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreMadeira)
		Dim Ls As New List(Of ColoreMadeira)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ColoreMadeira)
		Dim Ls As New List(Of ColoreMadeira)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_madeira" 
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
	'''Return all record on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreMadeira
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ColoreMadeira)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreMadeira
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreMadeira)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_madeira
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreMadeira
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreMadeira)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreMadeira)
		Dim Ls As List(Of ColoreMadeira)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_madeira" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreMadeira)
		Dim Ls As New List(Of ColoreMadeira)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ColoreMadeira() With {.IdMadeira = 0 ,.Attivo = 0 ,.CodiceMadeira = "" ,.CostoMillePunti = 0 ,.IdPantone = 0 ,.IdTavolozza = 0  })
					While myReader.Read
						Dim classe as new ColoreMadeira(CType(myReader, IDataRecord))
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