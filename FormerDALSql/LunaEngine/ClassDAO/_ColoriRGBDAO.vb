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
'''This class manage persistency on db of ColoreRGB object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ColoriRGBDAO
	Inherits LUNA.LunaBaseClassDAO(Of ColoreRGB)

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
	'''Read from DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a ColoreRGB object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ColoreRGB
		Dim cls as new ColoreRGB

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_colori WHERE IdColore = " & Id
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
	'''Save on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ColoreRGB) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdColore = 0 Then
							sql = "INSERT INTO T_colori ("
							sql &= " Alpha,"
							sql &= " Attivo,"
							sql &= " B,"
							sql &= " G,"
							sql &= " ImportoMillePunti,"
							sql &= " Nome,"
							sql &= " R"
							sql &= ") VALUES ("
							sql &= " @Alpha,"
							sql &= " @Attivo,"
							sql &= " @B,"
							sql &= " @G,"
							sql &= " @ImportoMillePunti,"
							sql &= " @Nome,"
							sql &= " @R"
							sql &= ")"
						Else
							sql = "UPDATE T_colori SET "
							If cls.WhatIsChanged.Alpha Then sql &= "Alpha = @Alpha,"
							If cls.WhatIsChanged.Attivo Then sql &= "Attivo = @Attivo,"
							If cls.WhatIsChanged.B Then sql &= "B = @B,"
							If cls.WhatIsChanged.G Then sql &= "G = @G,"
							If cls.WhatIsChanged.ImportoMillePunti Then sql &= "ImportoMillePunti = @ImportoMillePunti,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.R Then sql &= "R = @R"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdColore= " & cls.IdColore
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Alpha"
						p.Value = cls.Alpha
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Attivo"
						p.Value = cls.Attivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@B"
						p.Value = cls.B
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@G"
						p.Value = cls.G
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@ImportoMillePunti"
						p.Value = cls.ImportoMillePunti
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Nome"
						p.Value = cls.Nome
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@R"
						p.Value = cls.R
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdColore=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdColore = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdColore
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdColore
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
				'Dim Sql As String = "UPDATE T_colori SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_colori"
				Sql &= " WHERE IdColore = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_colori. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_colori. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ColoreRGB, Optional ByRef ListaObj as List (of ColoreRGB) = Nothing)
		DestroyPermanently (obj.IdColore)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreRGB
		Dim ris As ColoreRGB = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ColoreRGB) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return first of ColoreRGB
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreRGB
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return first of ColoreRGB
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreRGB
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ColoreRGB
	''' </summary>
	''' <returns>
	'''Return first of ColoreRGB
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreRGB
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreRGB)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreRGB)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreRGB)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreRGB)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreRGB)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ColoreRGB)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_colori by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ColoreRGB by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreRGB)
		Dim Ls As New List(Of ColoreRGB)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ColoreRGB)
		Dim Ls As New List(Of ColoreRGB)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_colori" 
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
	'''Return all record on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreRGB
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ColoreRGB)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreRGB
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreRGB)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_colori
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreRGB
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreRGB)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreRGB)
		Dim Ls As List(Of ColoreRGB)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_colori" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreRGB)
		Dim Ls As New List(Of ColoreRGB)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ColoreRGB() With {.IdColore = 0 ,.Alpha = 0 ,.Attivo = 0 ,.B = 0 ,.G = 0 ,.ImportoMillePunti = 0 ,.Nome = "" ,.R = 0  })
					While myReader.Read
						Dim classe as new ColoreRGB(CType(myReader, IDataRecord))
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