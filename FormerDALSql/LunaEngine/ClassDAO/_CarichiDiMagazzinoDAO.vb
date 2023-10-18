#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 02/04/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of CaricoDiMagazzino object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CarichiDiMagazzinoDAO
	Inherits LUNA.LunaBaseClassDAO(Of CaricoDiMagazzino)

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
	'''Read from DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a CaricoDiMagazzino object
	''' </returns>
	Public Overrides Function Read(Id as integer) as CaricoDiMagazzino
		Dim cls as new CaricoDiMagazzino

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_carichimagazzino WHERE IdCaricoMagazzino = " & Id
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
	'''Save on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as CaricoDiMagazzino) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCaricoMagazzino = 0 Then
							sql = "INSERT INTO T_carichimagazzino ("
							sql &= " DataCarico,"
							sql &= " IdAzienda,"
							sql &= " IdCosto,"
							sql &= " IdRub,"
							sql &= " IdStatoInterno,"
							sql &= " IdUtCarico,"
							sql &= " NumeroDocRiferimento,"
							sql &= " TipoDocRiferimento"
							sql &= ") VALUES ("
							sql &= " @DataCarico,"
							sql &= " @IdAzienda,"
							sql &= " @IdCosto,"
							sql &= " @IdRub,"
							sql &= " @IdStatoInterno,"
							sql &= " @IdUtCarico,"
							sql &= " @NumeroDocRiferimento,"
							sql &= " @TipoDocRiferimento"
							sql &= ")"
						Else
							sql = "UPDATE T_carichimagazzino SET "
							If cls.WhatIsChanged.DataCarico Then sql &= "DataCarico = @DataCarico,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.IdCosto Then sql &= "IdCosto = @IdCosto,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdStatoInterno Then sql &= "IdStatoInterno = @IdStatoInterno,"
							If cls.WhatIsChanged.IdUtCarico Then sql &= "IdUtCarico = @IdUtCarico,"
							If cls.WhatIsChanged.NumeroDocRiferimento Then sql &= "NumeroDocRiferimento = @NumeroDocRiferimento,"
							If cls.WhatIsChanged.TipoDocRiferimento Then sql &= "TipoDocRiferimento = @TipoDocRiferimento"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCaricoMagazzino= " & cls.IdCaricoMagazzino
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.DataCarico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataCarico"
							p.DbType = DbType.DateTime
							If cls.DataCarico <> Date.MinValue Then
								p.Value = cls.DataCarico
							Else
								p.Value = DBNull.Value
							End If  
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

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdStatoInterno Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdStatoInterno"
							p.Value = cls.IdStatoInterno
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtCarico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtCarico"
							p.Value = cls.IdUtCarico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroDocRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroDocRiferimento"
							p.Value = cls.NumeroDocRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoDocRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoDocRiferimento"
							p.Value = cls.TipoDocRiferimento
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCaricoMagazzino=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCaricoMagazzino = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCaricoMagazzino
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCaricoMagazzino
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
				'Dim Sql As String = "UPDATE T_carichimagazzino SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_carichimagazzino"
				Sql &= " WHERE IdCaricoMagazzino = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_carichimagazzino. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_carichimagazzino. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as CaricoDiMagazzino, Optional ByRef ListaObj as List (of CaricoDiMagazzino) = Nothing)
		DestroyPermanently (obj.IdCaricoMagazzino)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CaricoDiMagazzino
		Dim ris As CaricoDiMagazzino = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of CaricoDiMagazzino) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return first of CaricoDiMagazzino
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CaricoDiMagazzino
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return first of CaricoDiMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CaricoDiMagazzino
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table CaricoDiMagazzino
	''' </summary>
	''' <returns>
	'''Return first of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CaricoDiMagazzino
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CaricoDiMagazzino)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CaricoDiMagazzino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CaricoDiMagazzino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CaricoDiMagazzino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CaricoDiMagazzino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of CaricoDiMagazzino)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_carichimagazzino by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of CaricoDiMagazzino by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of CaricoDiMagazzino)
		Dim Ls As New List(Of CaricoDiMagazzino)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of CaricoDiMagazzino)
		Dim Ls As New List(Of CaricoDiMagazzino)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_carichimagazzino" 
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
	'''Return all record on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return all record in list of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of CaricoDiMagazzino)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return all record in list of CaricoDiMagazzino
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CaricoDiMagazzino)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_carichimagazzino
	''' </summary>
	''' <returns>
	'''Return all record in list of CaricoDiMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CaricoDiMagazzino)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CaricoDiMagazzino)
		Dim Ls As List(Of CaricoDiMagazzino)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_carichimagazzino" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CaricoDiMagazzino)
		Dim Ls As New List(Of CaricoDiMagazzino)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  CaricoDiMagazzino() With {.IdCaricoMagazzino = 0 ,.DataCarico = Nothing ,.IdAzienda = 0 ,.IdCosto = 0 ,.IdRub = 0 ,.IdStatoInterno = 0 ,.IdUtCarico = 0 ,.NumeroDocRiferimento = "" ,.TipoDocRiferimento = 0  })
					While myReader.Read
						Dim classe as new CaricoDiMagazzino(CType(myReader, IDataRecord))
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