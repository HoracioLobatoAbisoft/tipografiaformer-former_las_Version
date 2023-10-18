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
'''This class manage persistency on db of TipoFustellaW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _TipiFustellaWDAO
	Inherits LUNA.LunaBaseClassDAO(Of TipoFustellaW)

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
	'''Read from DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a TipoFustellaW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as TipoFustellaW
		Dim cls as new TipoFustellaW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_tipofustella WHERE IdTipoFustella = " & Id
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
	'''Save on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as TipoFustellaW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdTipoFustella = 0 Then
							sql = "INSERT INTO T_tipofustella ("
							sql &= " Altezza,"
							sql &= " Base,"
							sql &= " CODICE,"
							sql &= " Disponibile,"
							sql &= " IdCatFustella,"
							sql &= " IdPrev,"
							sql &= " ImgRif,"
							sql &= " Orientabile,"
							sql &= " Profondita,"
							sql &= " TEMPLATEPDF"
							sql &= ") VALUES ("
							sql &= " @Altezza,"
							sql &= " @Base,"
							sql &= " @CODICE,"
							sql &= " @Disponibile,"
							sql &= " @IdCatFustella,"
							sql &= " @IdPrev,"
							sql &= " @ImgRif,"
							sql &= " @Orientabile,"
							sql &= " @Profondita,"
							sql &= " @TEMPLATEPDF"
							sql &= ")"
						Else
							sql = "UPDATE T_tipofustella SET "
							If cls.WhatIsChanged.Altezza Then sql &= "Altezza = @Altezza,"
							If cls.WhatIsChanged.Base Then sql &= "Base = @Base,"
							If cls.WhatIsChanged.CODICE Then sql &= "CODICE = @CODICE,"
							If cls.WhatIsChanged.Disponibile Then sql &= "Disponibile = @Disponibile,"
							If cls.WhatIsChanged.IdCatFustella Then sql &= "IdCatFustella = @IdCatFustella,"
							If cls.WhatIsChanged.IdPrev Then sql &= "IdPrev = @IdPrev,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.Orientabile Then sql &= "Orientabile = @Orientabile,"
							If cls.WhatIsChanged.Profondita Then sql &= "Profondita = @Profondita,"
							If cls.WhatIsChanged.TEMPLATEPDF Then sql &= "TEMPLATEPDF = @TEMPLATEPDF"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdTipoFustella= " & cls.IdTipoFustella
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Altezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Altezza"
							p.Value = cls.Altezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Base Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Base"
							p.Value = cls.Base
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CODICE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CODICE"
							p.Value = cls.CODICE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Disponibile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Disponibile"
							p.Value = cls.Disponibile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCatFustella Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCatFustella"
							p.Value = cls.IdCatFustella
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPrev Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPrev"
							p.Value = cls.IdPrev
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Orientabile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Orientabile"
							p.Value = cls.Orientabile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Profondita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Profondita"
							p.Value = cls.Profondita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TEMPLATEPDF Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TEMPLATEPDF"
							p.Value = cls.TEMPLATEPDF
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdTipoFustella=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdTipoFustella = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdTipoFustella
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdTipoFustella
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
				'Dim Sql As String = "UPDATE T_tipofustella SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_tipofustella"
				Sql &= " WHERE IdTipoFustella = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_tipofustella. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_tipofustella. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as TipoFustellaW, Optional ByRef ListaObj as List (of TipoFustellaW) = Nothing)
		DestroyPermanently (obj.IdTipoFustella)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoFustellaW
		Dim ris As TipoFustellaW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of TipoFustellaW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return first of TipoFustellaW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoFustellaW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return first of TipoFustellaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoFustellaW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table TipoFustellaW
	''' </summary>
	''' <returns>
	'''Return first of TipoFustellaW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoFustellaW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoFustellaW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoFustellaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoFustellaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoFustellaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoFustellaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of TipoFustellaW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_tipofustella by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of TipoFustellaW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of TipoFustellaW)
		Dim Ls As New List(Of TipoFustellaW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of TipoFustellaW)
		Dim Ls As New List(Of TipoFustellaW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_tipofustella" 
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
	'''Return all record on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoFustellaW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of TipoFustellaW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoFustellaW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoFustellaW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_tipofustella
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoFustellaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoFustellaW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoFustellaW)
		Dim Ls As List(Of TipoFustellaW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_tipofustella" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoFustellaW)
		Dim Ls As New List(Of TipoFustellaW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  TipoFustellaW() With {.IdTipoFustella = 0 ,.Altezza = 0 ,.Base = 0 ,.CODICE = "" ,.Disponibile = 0 ,.IdCatFustella = 0 ,.IdPrev = 0 ,.ImgRif = "" ,.Orientabile = 0 ,.Profondita = 0 ,.TEMPLATEPDF = ""  })
					While myReader.Read
						Dim classe as new TipoFustellaW(CType(myReader, IDataRecord))
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