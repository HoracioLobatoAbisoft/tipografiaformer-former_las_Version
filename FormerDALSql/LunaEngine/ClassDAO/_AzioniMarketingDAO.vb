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
'''This class manage persistency on db of AzioneMarketing object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _AzioniMarketingDAO
	Inherits LUNA.LunaBaseClassDAO(Of AzioneMarketing)

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
	'''Read from DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a AzioneMarketing object
	''' </returns>
	Public Overrides Function Read(Id as integer) as AzioneMarketing
		Dim cls as new AzioneMarketing

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_markaz WHERE IdMarkAz = " & Id
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
	'''Save on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as AzioneMarketing) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdMarkAz = 0 Then
							sql = "INSERT INTO T_markaz ("
							sql &= " Annotazioni,"
							sql &= " IdMarketing,"
							sql &= " IdRub,"
							sql &= " Quando,"
							sql &= " TipoAzione"
							sql &= ") VALUES ("
							sql &= " @Annotazioni,"
							sql &= " @IdMarketing,"
							sql &= " @IdRub,"
							sql &= " @Quando,"
							sql &= " @TipoAzione"
							sql &= ")"
						Else
							sql = "UPDATE T_markaz SET "
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.IdMarketing Then sql &= "IdMarketing = @IdMarketing,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.Quando Then sql &= "Quando = @Quando,"
							If cls.WhatIsChanged.TipoAzione Then sql &= "TipoAzione = @TipoAzione"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdMarkAz= " & cls.IdMarkAz
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Annotazioni"
						p.Value = cls.Annotazioni
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdMarketing"
						p.Value = cls.IdMarketing
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdRub"
						p.Value = cls.IdRub
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Quando"
						p.DbType = DbType.DateTime
						If cls.Quando <> Date.MinValue Then
							p.Value = cls.Quando
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoAzione"
						p.Value = cls.TipoAzione
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdMarkAz=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdMarkAz = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdMarkAz
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdMarkAz
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
				'Dim Sql As String = "UPDATE T_markaz SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_markaz"
				Sql &= " WHERE IdMarkAz = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_markaz. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_markaz. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as AzioneMarketing, Optional ByRef ListaObj as List (of AzioneMarketing) = Nothing)
		DestroyPermanently (obj.IdMarkAz)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneMarketing
		Dim ris As AzioneMarketing = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of AzioneMarketing) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return first of AzioneMarketing
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneMarketing
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return first of AzioneMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneMarketing
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table AzioneMarketing
	''' </summary>
	''' <returns>
	'''Return first of AzioneMarketing
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneMarketing
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneMarketing)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of AzioneMarketing)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_markaz by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of AzioneMarketing by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneMarketing)
		Dim Ls As New List(Of AzioneMarketing)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of AzioneMarketing)
		Dim Ls As New List(Of AzioneMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_markaz" 
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
	'''Return all record on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneMarketing
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of AzioneMarketing)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneMarketing
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneMarketing)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_markaz
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneMarketing)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AzioneMarketing)
		Dim Ls As List(Of AzioneMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_markaz" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AzioneMarketing)
		Dim Ls As New List(Of AzioneMarketing)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  AzioneMarketing() With {.IdMarkAz = 0 ,.Annotazioni = "" ,.IdMarketing = 0 ,.IdRub = 0 ,.Quando = Nothing ,.TipoAzione = 0  })
					While myReader.Read
						Dim classe as new AzioneMarketing(CType(myReader, IDataRecord))
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