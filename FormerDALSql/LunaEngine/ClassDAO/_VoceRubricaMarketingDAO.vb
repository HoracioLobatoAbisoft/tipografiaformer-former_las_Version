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
'''This class manage persistency on db of VoceRubricaMarketing object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _VoceRubricaMarketingDAO
	Inherits LUNA.LunaBaseClassDAO(Of VoceRubricaMarketing)

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
	'''Read from DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a VoceRubricaMarketing object
	''' </returns>
	Public Overrides Function Read(Id as integer) as VoceRubricaMarketing
		Dim cls as new VoceRubricaMarketing

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_rubricamarketing WHERE IDRubMarketing = " & Id
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
	'''Save on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as VoceRubricaMarketing) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IDRubMarketing = 0 Then
							sql = "INSERT INTO T_rubricamarketing ("
							sql &= " Annotazioni,"
							sql &= " Cap,"
							sql &= " Citta,"
							sql &= " DataAcquisizione,"
							sql &= " Disattivo,"
							sql &= " Email,"
							sql &= " Fax,"
							sql &= " IdCategoria,"
							sql &= " IdCategoria2,"
							sql &= " IdUtente,"
							sql &= " Indirizzo,"
							sql &= " Lavorato,"
							sql &= " NoEmail,"
							sql &= " NomeAzienda,"
							sql &= " Sito,"
							sql &= " Tag,"
							sql &= " Telefono,"
							sql &= " Tipo,"
							sql &= " UrlProvenienza"
							sql &= ") VALUES ("
							sql &= " @Annotazioni,"
							sql &= " @Cap,"
							sql &= " @Citta,"
							sql &= " @DataAcquisizione,"
							sql &= " @Disattivo,"
							sql &= " @Email,"
							sql &= " @Fax,"
							sql &= " @IdCategoria,"
							sql &= " @IdCategoria2,"
							sql &= " @IdUtente,"
							sql &= " @Indirizzo,"
							sql &= " @Lavorato,"
							sql &= " @NoEmail,"
							sql &= " @NomeAzienda,"
							sql &= " @Sito,"
							sql &= " @Tag,"
							sql &= " @Telefono,"
							sql &= " @Tipo,"
							sql &= " @UrlProvenienza"
							sql &= ")"
						Else
							sql = "UPDATE T_rubricamarketing SET "
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.DataAcquisizione Then sql &= "DataAcquisizione = @DataAcquisizione,"
							If cls.WhatIsChanged.Disattivo Then sql &= "Disattivo = @Disattivo,"
							If cls.WhatIsChanged.Email Then sql &= "Email = @Email,"
							If cls.WhatIsChanged.Fax Then sql &= "Fax = @Fax,"
							If cls.WhatIsChanged.IdCategoria Then sql &= "IdCategoria = @IdCategoria,"
							If cls.WhatIsChanged.IdCategoria2 Then sql &= "IdCategoria2 = @IdCategoria2,"
							If cls.WhatIsChanged.IdUtente Then sql &= "IdUtente = @IdUtente,"
							If cls.WhatIsChanged.Indirizzo Then sql &= "Indirizzo = @Indirizzo,"
							If cls.WhatIsChanged.Lavorato Then sql &= "Lavorato = @Lavorato,"
							If cls.WhatIsChanged.NoEmail Then sql &= "NoEmail = @NoEmail,"
							If cls.WhatIsChanged.NomeAzienda Then sql &= "NomeAzienda = @NomeAzienda,"
							If cls.WhatIsChanged.Sito Then sql &= "Sito = @Sito,"
							If cls.WhatIsChanged.Tag Then sql &= "Tag = @Tag,"
							If cls.WhatIsChanged.Telefono Then sql &= "Telefono = @Telefono,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.UrlProvenienza Then sql &= "UrlProvenienza = @UrlProvenienza"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IDRubMarketing= " & cls.IDRubMarketing
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Annotazioni"
						p.Value = cls.Annotazioni
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Cap"
						p.Value = cls.Cap
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Citta"
						p.Value = cls.Citta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DataAcquisizione"
						p.DbType = DbType.DateTime
						If cls.DataAcquisizione <> Date.MinValue Then
							p.Value = cls.DataAcquisizione
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Disattivo"
						p.Value = cls.Disattivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Email"
						p.Value = cls.Email
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Fax"
						p.Value = cls.Fax
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCategoria"
						p.Value = cls.IdCategoria
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCategoria2"
						p.Value = cls.IdCategoria2
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdUtente"
						p.Value = cls.IdUtente
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Indirizzo"
						p.Value = cls.Indirizzo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Lavorato"
						p.Value = cls.Lavorato
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NoEmail"
						p.Value = cls.NoEmail
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NomeAzienda"
						p.Value = cls.NomeAzienda
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Sito"
						p.Value = cls.Sito
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Tag"
						p.Value = cls.Tag
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Telefono"
						p.Value = cls.Telefono
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Tipo"
						p.Value = cls.Tipo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@UrlProvenienza"
						p.Value = cls.UrlProvenienza
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IDRubMarketing=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IDRubMarketing = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IDRubMarketing
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IDRubMarketing
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
				'Dim Sql As String = "UPDATE T_rubricamarketing SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_rubricamarketing"
				Sql &= " WHERE IDRubMarketing = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_rubricamarketing. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_rubricamarketing. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as VoceRubricaMarketing, Optional ByRef ListaObj as List (of VoceRubricaMarketing) = Nothing)
		DestroyPermanently (obj.IDRubMarketing)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubricaMarketing
		Dim ris As VoceRubricaMarketing = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of VoceRubricaMarketing) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return first of VoceRubricaMarketing
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubricaMarketing
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return first of VoceRubricaMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubricaMarketing
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table VoceRubricaMarketing
	''' </summary>
	''' <returns>
	'''Return first of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubricaMarketing
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubricaMarketing)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubricaMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubricaMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubricaMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubricaMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of VoceRubricaMarketing)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubricamarketing by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubricaMarketing by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubricaMarketing)
		Dim Ls As New List(Of VoceRubricaMarketing)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of VoceRubricaMarketing)
		Dim Ls As New List(Of VoceRubricaMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_rubricamarketing" 
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
	'''Return all record on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of VoceRubricaMarketing)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubricaMarketing
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubricaMarketing)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_rubricamarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubricaMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubricaMarketing)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceRubricaMarketing)
		Dim Ls As List(Of VoceRubricaMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_rubricamarketing" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceRubricaMarketing)
		Dim Ls As New List(Of VoceRubricaMarketing)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  VoceRubricaMarketing() With {.IDRubMarketing = 0 ,.Annotazioni = "" ,.Cap = "" ,.Citta = "" ,.DataAcquisizione = Nothing ,.Disattivo = 0 ,.Email = "" ,.Fax = "" ,.IdCategoria = 0 ,.IdCategoria2 = 0 ,.IdUtente = 0 ,.Indirizzo = "" ,.Lavorato = False ,.NoEmail = 0 ,.NomeAzienda = "" ,.Sito = "" ,.Tag = "" ,.Telefono = "" ,.Tipo = 0 ,.UrlProvenienza = ""  })
					While myReader.Read
						Dim classe as new VoceRubricaMarketing(CType(myReader, IDataRecord))
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