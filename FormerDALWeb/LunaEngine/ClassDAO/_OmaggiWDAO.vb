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
'''This class manage persistency on db of OmaggioW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _OmaggiWDAO
	Inherits LUNA.LunaBaseClassDAO(Of OmaggioW)

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
	'''Read from DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a OmaggioW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as OmaggioW
		Dim cls as new OmaggioW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_omaggi WHERE IdOmaggio = " & Id
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
	'''Save on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as OmaggioW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdOmaggio = 0 Then
							sql = "INSERT INTO T_omaggi ("
							sql &= " IdListinoOmaggio,"
							sql &= " IdPreventivazione,"
							sql &= " ImportoMin,"
							sql &= " QtaOmaggio,"
							sql &= " TipoCliente,"
							sql &= " Tipologia"
							sql &= ") VALUES ("
							sql &= " @IdListinoOmaggio,"
							sql &= " @IdPreventivazione,"
							sql &= " @ImportoMin,"
							sql &= " @QtaOmaggio,"
							sql &= " @TipoCliente,"
							sql &= " @Tipologia"
							sql &= ")"
						Else
							sql = "UPDATE T_omaggi SET "
							If cls.WhatIsChanged.IdListinoOmaggio Then sql &= "IdListinoOmaggio = @IdListinoOmaggio,"
							If cls.WhatIsChanged.IdPreventivazione Then sql &= "IdPreventivazione = @IdPreventivazione,"
							If cls.WhatIsChanged.ImportoMin Then sql &= "ImportoMin = @ImportoMin,"
							If cls.WhatIsChanged.QtaOmaggio Then sql &= "QtaOmaggio = @QtaOmaggio,"
							If cls.WhatIsChanged.TipoCliente Then sql &= "TipoCliente = @TipoCliente,"
							If cls.WhatIsChanged.Tipologia Then sql &= "Tipologia = @Tipologia"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdOmaggio= " & cls.IdOmaggio
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdListinoOmaggio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdListinoOmaggio"
							p.Value = cls.IdListinoOmaggio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPreventivazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPreventivazione"
							p.Value = cls.IdPreventivazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoMin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoMin"
							p.Value = cls.ImportoMin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QtaOmaggio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QtaOmaggio"
							p.Value = cls.QtaOmaggio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCliente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCliente"
							p.Value = cls.TipoCliente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipologia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipologia"
							p.Value = cls.Tipologia
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdOmaggio=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdOmaggio = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdOmaggio
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdOmaggio
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
				'Dim Sql As String = "UPDATE T_omaggi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_omaggi"
				Sql &= " WHERE IdOmaggio = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_omaggi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_omaggi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as OmaggioW, Optional ByRef ListaObj as List (of OmaggioW) = Nothing)
		DestroyPermanently (obj.IdOmaggio)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OmaggioW
		Dim ris As OmaggioW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of OmaggioW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return first of OmaggioW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OmaggioW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return first of OmaggioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OmaggioW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table OmaggioW
	''' </summary>
	''' <returns>
	'''Return first of OmaggioW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OmaggioW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OmaggioW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OmaggioW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OmaggioW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OmaggioW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OmaggioW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of OmaggioW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_omaggi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of OmaggioW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of OmaggioW)
		Dim Ls As New List(Of OmaggioW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of OmaggioW)
		Dim Ls As New List(Of OmaggioW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_omaggi" 
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
	'''Return all record on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return all record in list of OmaggioW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of OmaggioW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return all record in list of OmaggioW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of OmaggioW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_omaggi
	''' </summary>
	''' <returns>
	'''Return all record in list of OmaggioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of OmaggioW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of OmaggioW)
		Dim Ls As List(Of OmaggioW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_omaggi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of OmaggioW)
		Dim Ls As New List(Of OmaggioW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  OmaggioW() With {.IdOmaggio = 0 ,.IdListinoOmaggio = 0 ,.IdPreventivazione = 0 ,.ImportoMin = 0 ,.QtaOmaggio = 0 ,.TipoCliente = 0 ,.Tipologia = 0  })
					While myReader.Read
						Dim classe as new OmaggioW(CType(myReader, IDataRecord))
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