#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 19.2.27.1 
'Author: Diego Lunadei
'Date: 28/02/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Coupon object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CouponDAO
	Inherits LUNA.LunaBaseClassDAO(Of Coupon)

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
	'''Read from DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a Coupon object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Coupon
		Dim cls as new Coupon

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_coupon WHERE IdCoupon = " & Id
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
	'''Save on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Coupon) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCoupon = 0 Then
							sql = "INSERT INTO T_coupon ("
							sql &= " Codice,"
							sql &= " DataFineValidita,"
							sql &= " DataInizioValidita,"
							sql &= " IdCouponOnline,"
							sql &= " IdListinoBase,"
							sql &= " IdReview,"
							sql &= " ImgOnline,"
							sql &= " ImportoFisso,"
							sql &= " ImportoMinimoSpesa,"
							sql &= " MaxVolte,"
							sql &= " Nome,"
							sql &= " Percentuale,"
							sql &= " QtaSpecifica,"
							sql &= " Riservato,"
							sql &= " RiservatoATipoUtente,"
							sql &= " Stato,"
							sql &= " UrlHref,"
							sql &= " VisibileOnline"
							sql &= ") VALUES ("
							sql &= " @Codice,"
							sql &= " @DataFineValidita,"
							sql &= " @DataInizioValidita,"
							sql &= " @IdCouponOnline,"
							sql &= " @IdListinoBase,"
							sql &= " @IdReview,"
							sql &= " @ImgOnline,"
							sql &= " @ImportoFisso,"
							sql &= " @ImportoMinimoSpesa,"
							sql &= " @MaxVolte,"
							sql &= " @Nome,"
							sql &= " @Percentuale,"
							sql &= " @QtaSpecifica,"
							sql &= " @Riservato,"
							sql &= " @RiservatoATipoUtente,"
							sql &= " @Stato,"
							sql &= " @UrlHref,"
							sql &= " @VisibileOnline"
							sql &= ")"
						Else
							sql = "UPDATE T_coupon SET "
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.DataFineValidita Then sql &= "DataFineValidita = @DataFineValidita,"
							If cls.WhatIsChanged.DataInizioValidita Then sql &= "DataInizioValidita = @DataInizioValidita,"
							If cls.WhatIsChanged.IdCouponOnline Then sql &= "IdCouponOnline = @IdCouponOnline,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdReview Then sql &= "IdReview = @IdReview,"
							If cls.WhatIsChanged.ImgOnline Then sql &= "ImgOnline = @ImgOnline,"
							If cls.WhatIsChanged.ImportoFisso Then sql &= "ImportoFisso = @ImportoFisso,"
							If cls.WhatIsChanged.ImportoMinimoSpesa Then sql &= "ImportoMinimoSpesa = @ImportoMinimoSpesa,"
							If cls.WhatIsChanged.MaxVolte Then sql &= "MaxVolte = @MaxVolte,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.Percentuale Then sql &= "Percentuale = @Percentuale,"
							If cls.WhatIsChanged.QtaSpecifica Then sql &= "QtaSpecifica = @QtaSpecifica,"
							If cls.WhatIsChanged.Riservato Then sql &= "Riservato = @Riservato,"
							If cls.WhatIsChanged.RiservatoATipoUtente Then sql &= "RiservatoATipoUtente = @RiservatoATipoUtente,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.UrlHref Then sql &= "UrlHref = @UrlHref,"
							If cls.WhatIsChanged.VisibileOnline Then sql &= "VisibileOnline = @VisibileOnline"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCoupon= " & cls.IdCoupon
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Codice Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Codice"
							p.Value = cls.Codice
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataFineValidita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataFineValidita"
							p.DbType = DbType.DateTime
							If cls.DataFineValidita <> Date.MinValue Then
								p.Value = cls.DataFineValidita
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataInizioValidita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataInizioValidita"
							p.DbType = DbType.DateTime
							If cls.DataInizioValidita <> Date.MinValue Then
								p.Value = cls.DataInizioValidita
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCouponOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCouponOnline"
							p.Value = cls.IdCouponOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdListinoBase Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdListinoBase"
							p.Value = cls.IdListinoBase
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdReview Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdReview"
							p.Value = cls.IdReview
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgOnline"
							p.Value = cls.ImgOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoFisso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoFisso"
							p.Value = cls.ImportoFisso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoMinimoSpesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoMinimoSpesa"
							p.Value = cls.ImportoMinimoSpesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MaxVolte Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MaxVolte"
							p.Value = cls.MaxVolte
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Percentuale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Percentuale"
							p.Value = cls.Percentuale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QtaSpecifica Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QtaSpecifica"
							p.Value = cls.QtaSpecifica
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Riservato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Riservato"
							p.Value = cls.Riservato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RiservatoATipoUtente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RiservatoATipoUtente"
							p.Value = cls.RiservatoATipoUtente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UrlHref Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UrlHref"
							p.Value = cls.UrlHref
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.VisibileOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@VisibileOnline"
							p.Value = cls.VisibileOnline
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCoupon=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCoupon = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCoupon
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCoupon
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
				'Dim Sql As String = "UPDATE T_coupon SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_coupon"
				Sql &= " WHERE IdCoupon = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_coupon. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_coupon. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Coupon, Optional ByRef ListaObj as List (of Coupon) = Nothing)
		DestroyPermanently (obj.IdCoupon)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Coupon
		Dim ris As Coupon = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Coupon) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return first of Coupon
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Coupon
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return first of Coupon
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Coupon
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Coupon
	''' </summary>
	''' <returns>
	'''Return first of Coupon
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Coupon
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Coupon)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Coupon)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Coupon)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Coupon)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Coupon)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return a list of Coupon
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Coupon)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_coupon by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Coupon by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Coupon)
		Dim Ls As New List(Of Coupon)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Coupon)
		Dim Ls As New List(Of Coupon)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_coupon" 
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
	'''Return all record on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return all record in list of Coupon
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Coupon)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return all record in list of Coupon
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Coupon)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_coupon
	''' </summary>
	''' <returns>
	'''Return all record in list of Coupon
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Coupon)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Coupon)
		Dim Ls As List(Of Coupon)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_coupon" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Coupon)
		Dim Ls As New List(Of Coupon)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Coupon() With {.IdCoupon = 0 ,.Codice = "" ,.DataFineValidita = Nothing ,.DataInizioValidita = Nothing ,.IdCouponOnline = 0 ,.IdListinoBase = 0 ,.IdReview = 0 ,.ImgOnline = "" ,.ImportoFisso = 0 ,.ImportoMinimoSpesa = 0 ,.MaxVolte = 0 ,.Nome = "" ,.Percentuale = 0 ,.QtaSpecifica = 0 ,.Riservato = 0 ,.RiservatoATipoUtente = 0 ,.Stato = 0 ,.UrlHref = "" ,.VisibileOnline = 0  })
					While myReader.Read
						Dim classe as new Coupon(CType(myReader, IDataRecord))
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