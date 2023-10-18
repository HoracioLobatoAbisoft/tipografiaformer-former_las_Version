#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/02/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of VoceCosto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _VociCostoDAO
	Inherits LUNA.LunaBaseClassDAO(Of VoceCosto)

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
	'''Read from DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a VoceCosto object
	''' </returns>
	Public Overrides Function Read(Id as integer) as VoceCosto
		Dim cls as new VoceCosto

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_vocicosto WHERE IdVoceCosto = " & Id
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
	'''Save on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as VoceCosto) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdVoceCosto = 0 Then
							sql = "INSERT INTO T_vocicosto ("
							sql &= " AliquotaIva,"
							sql &= " Codice,"
							sql &= " Descrizione,"
							sql &= " idCat,"
							sql &= " IdCosto,"
							sql &= " IdMovMagaz,"
							sql &= " PrezzoUnit,"
							sql &= " Qta,"
							sql &= " TipoCessionePrestazione,"
							sql &= " Totale,"
							sql &= " Um"
							sql &= ") VALUES ("
							sql &= " @AliquotaIva,"
							sql &= " @Codice,"
							sql &= " @Descrizione,"
							sql &= " @idCat,"
							sql &= " @IdCosto,"
							sql &= " @IdMovMagaz,"
							sql &= " @PrezzoUnit,"
							sql &= " @Qta,"
							sql &= " @TipoCessionePrestazione,"
							sql &= " @Totale,"
							sql &= " @Um"
							sql &= ")"
						Else
							sql = "UPDATE T_vocicosto SET "
							If cls.WhatIsChanged.AliquotaIva Then sql &= "AliquotaIva = @AliquotaIva,"
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.idCat Then sql &= "idCat = @idCat,"
							If cls.WhatIsChanged.IdCosto Then sql &= "IdCosto = @IdCosto,"
							If cls.WhatIsChanged.IdMovMagaz Then sql &= "IdMovMagaz = @IdMovMagaz,"
							If cls.WhatIsChanged.PrezzoUnit Then sql &= "PrezzoUnit = @PrezzoUnit,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta,"
							If cls.WhatIsChanged.TipoCessionePrestazione Then sql &= "TipoCessionePrestazione = @TipoCessionePrestazione,"
							If cls.WhatIsChanged.Totale Then sql &= "Totale = @Totale,"
							If cls.WhatIsChanged.Um Then sql &= "Um = @Um"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdVoceCosto= " & cls.IdVoceCosto
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AliquotaIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AliquotaIva"
							p.Value = cls.AliquotaIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Codice Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Codice"
							p.Value = cls.Codice
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.idCat Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@idCat"
							p.Value = cls.idCat
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCosto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCosto"
							p.Value = cls.IdCosto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMovMagaz Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMovMagaz"
							p.Value = cls.IdMovMagaz
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoUnit Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoUnit"
							p.Value = cls.PrezzoUnit
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta"
							p.Value = cls.Qta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCessionePrestazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCessionePrestazione"
							p.Value = cls.TipoCessionePrestazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Totale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Totale"
							p.Value = cls.Totale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Um Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Um"
							p.Value = cls.Um
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdVoceCosto=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdVoceCosto = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdVoceCosto
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdVoceCosto
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
				'Dim Sql As String = "UPDATE T_vocicosto SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_vocicosto"
				Sql &= " WHERE IdVoceCosto = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_vocicosto. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_vocicosto. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as VoceCosto, Optional ByRef ListaObj as List (of VoceCosto) = Nothing)
		DestroyPermanently (obj.IdVoceCosto)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceCosto
		Dim ris As VoceCosto = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of VoceCosto) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return first of VoceCosto
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceCosto
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return first of VoceCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceCosto
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table VoceCosto
	''' </summary>
	''' <returns>
	'''Return first of VoceCosto
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceCosto
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceCosto)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceCosto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceCosto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceCosto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceCosto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of VoceCosto)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocicosto by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of VoceCosto by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of VoceCosto)
		Dim Ls As New List(Of VoceCosto)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of VoceCosto)
		Dim Ls As New List(Of VoceCosto)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_vocicosto" 
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
	'''Return all record on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceCosto
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of VoceCosto)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceCosto
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceCosto)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_vocicosto
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceCosto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceCosto)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceCosto)
		Dim Ls As List(Of VoceCosto)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_vocicosto" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceCosto)
		Dim Ls As New List(Of VoceCosto)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  VoceCosto() With {.IdVoceCosto = 0 ,.AliquotaIva = 0 ,.Codice = "" ,.Descrizione = EmptyItemDescription,.idCat = 0 ,.IdCosto = 0 ,.IdMovMagaz = 0 ,.PrezzoUnit = 0 ,.Qta = 0 ,.TipoCessionePrestazione = "" ,.Totale = 0 ,.Um = ""  })
					While myReader.Read
						Dim classe as new VoceCosto(CType(myReader, IDataRecord))
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