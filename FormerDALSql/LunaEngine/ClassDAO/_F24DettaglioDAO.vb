#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 22/02/2021 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of F24Dettaglio object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _F24DettaglioDAO
	Inherits LUNA.LunaBaseClassDAO(Of F24Dettaglio)

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
	'''Read from DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a F24Dettaglio object
	''' </returns>
	Public Overrides Function Read(Id as integer) as F24Dettaglio
		Dim cls as new F24Dettaglio

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM F24dettaglio WHERE IdF24Dett = " & Id
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
	'''Save on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as F24Dettaglio) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdF24Dett = 0 Then
							sql = "INSERT INTO F24dettaglio ("
							sql &= " Anno,"
							sql &= " Causale,"
							sql &= " CausaleContributo,"
							sql &= " cc,"
							sql &= " CodiceDitta,"
							sql &= " CodiceRegione,"
							sql &= " CodiceSede,"
							sql &= " CodiceTributo,"
							sql &= " IdF24,"
							sql &= " IdSezione,"
							sql &= " ImportiCredito,"
							sql &= " ImportiDebito,"
							sql &= " MatricolaInps,"
							sql &= " Mese,"
							sql &= " NumeroRiferimento,"
							sql &= " PeriodoA,"
							sql &= " PeriodoDa"
							sql &= ") VALUES ("
							sql &= " @Anno,"
							sql &= " @Causale,"
							sql &= " @CausaleContributo,"
							sql &= " @cc,"
							sql &= " @CodiceDitta,"
							sql &= " @CodiceRegione,"
							sql &= " @CodiceSede,"
							sql &= " @CodiceTributo,"
							sql &= " @IdF24,"
							sql &= " @IdSezione,"
							sql &= " @ImportiCredito,"
							sql &= " @ImportiDebito,"
							sql &= " @MatricolaInps,"
							sql &= " @Mese,"
							sql &= " @NumeroRiferimento,"
							sql &= " @PeriodoA,"
							sql &= " @PeriodoDa"
							sql &= ")"
						Else
							sql = "UPDATE F24dettaglio SET "
							If cls.WhatIsChanged.Anno Then sql &= "Anno = @Anno,"
							If cls.WhatIsChanged.Causale Then sql &= "Causale = @Causale,"
							If cls.WhatIsChanged.CausaleContributo Then sql &= "CausaleContributo = @CausaleContributo,"
							If cls.WhatIsChanged.cc Then sql &= "cc = @cc,"
							If cls.WhatIsChanged.CodiceDitta Then sql &= "CodiceDitta = @CodiceDitta,"
							If cls.WhatIsChanged.CodiceRegione Then sql &= "CodiceRegione = @CodiceRegione,"
							If cls.WhatIsChanged.CodiceSede Then sql &= "CodiceSede = @CodiceSede,"
							If cls.WhatIsChanged.CodiceTributo Then sql &= "CodiceTributo = @CodiceTributo,"
							If cls.WhatIsChanged.IdF24 Then sql &= "IdF24 = @IdF24,"
							If cls.WhatIsChanged.IdSezione Then sql &= "IdSezione = @IdSezione,"
							If cls.WhatIsChanged.ImportiCredito Then sql &= "ImportiCredito = @ImportiCredito,"
							If cls.WhatIsChanged.ImportiDebito Then sql &= "ImportiDebito = @ImportiDebito,"
							If cls.WhatIsChanged.MatricolaInps Then sql &= "MatricolaInps = @MatricolaInps,"
							If cls.WhatIsChanged.Mese Then sql &= "Mese = @Mese,"
							If cls.WhatIsChanged.NumeroRiferimento Then sql &= "NumeroRiferimento = @NumeroRiferimento,"
							If cls.WhatIsChanged.PeriodoA Then sql &= "PeriodoA = @PeriodoA,"
							If cls.WhatIsChanged.PeriodoDa Then sql &= "PeriodoDa = @PeriodoDa"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdF24Dett= " & cls.IdF24Dett
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Anno Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Anno"
							p.Value = cls.Anno
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Causale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Causale"
							p.Value = cls.Causale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CausaleContributo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CausaleContributo"
							p.Value = cls.CausaleContributo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.cc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@cc"
							p.Value = cls.cc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodiceDitta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceDitta"
							p.Value = cls.CodiceDitta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodiceRegione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceRegione"
							p.Value = cls.CodiceRegione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodiceSede Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceSede"
							p.Value = cls.CodiceSede
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodiceTributo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceTributo"
							p.Value = cls.CodiceTributo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdF24 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdF24"
							p.Value = cls.IdF24
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdSezione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdSezione"
							p.Value = cls.IdSezione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportiCredito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportiCredito"
							p.Value = cls.ImportiCredito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportiDebito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportiDebito"
							p.Value = cls.ImportiDebito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MatricolaInps Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MatricolaInps"
							p.Value = cls.MatricolaInps
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Mese Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Mese"
							p.Value = cls.Mese
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroRiferimento"
							p.Value = cls.NumeroRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PeriodoA Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PeriodoA"
							p.Value = cls.PeriodoA
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PeriodoDa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PeriodoDa"
							p.Value = cls.PeriodoDa
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdF24Dett=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdF24Dett = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdF24Dett
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdF24Dett
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
				'Dim Sql As String = "UPDATE F24dettaglio SET DELETED=True "
				Dim Sql As String = "DELETE FROM F24dettaglio"
				Sql &= " WHERE IdF24Dett = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table F24dettaglio. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table F24dettaglio. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as F24Dettaglio, Optional ByRef ListaObj as List (of F24Dettaglio) = Nothing)
		DestroyPermanently (obj.IdF24Dett)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24Dettaglio
		Dim ris As F24Dettaglio = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of F24Dettaglio) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return first of F24Dettaglio
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24Dettaglio
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return first of F24Dettaglio
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24Dettaglio
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table F24Dettaglio
	''' </summary>
	''' <returns>
	'''Return first of F24Dettaglio
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As F24Dettaglio
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24Dettaglio)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24Dettaglio)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24Dettaglio)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24Dettaglio)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of F24Dettaglio)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of F24Dettaglio)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table F24dettaglio by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of F24Dettaglio by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of F24Dettaglio)
		Dim Ls As New List(Of F24Dettaglio)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of F24Dettaglio)
		Dim Ls As New List(Of F24Dettaglio)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM F24dettaglio" 
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
	'''Return all record on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return all record in list of F24Dettaglio
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of F24Dettaglio)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return all record in list of F24Dettaglio
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of F24Dettaglio)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table F24dettaglio
	''' </summary>
	''' <returns>
	'''Return all record in list of F24Dettaglio
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of F24Dettaglio)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of F24Dettaglio)
		Dim Ls As List(Of F24Dettaglio)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM F24dettaglio" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of F24Dettaglio)
		Dim Ls As New List(Of F24Dettaglio)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  F24Dettaglio() With {.IdF24Dett = 0 ,.Anno = "" ,.Causale = "" ,.CausaleContributo = "" ,.cc = "" ,.CodiceDitta = "" ,.CodiceRegione = "" ,.CodiceSede = "" ,.CodiceTributo = "" ,.IdF24 = 0 ,.IdSezione = 0 ,.ImportiCredito = "" ,.ImportiDebito = "" ,.MatricolaInps = "" ,.Mese = "" ,.NumeroRiferimento = "" ,.PeriodoA = "" ,.PeriodoDa = ""  })
					While myReader.Read
						Dim classe as new F24Dettaglio(CType(myReader, IDataRecord))
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