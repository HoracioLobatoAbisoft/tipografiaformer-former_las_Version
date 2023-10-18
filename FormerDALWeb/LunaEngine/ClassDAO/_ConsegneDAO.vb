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
'''This class manage persistency on db of Consegna object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ConsegneDAO
	Inherits LUNA.LunaBaseClassDAO(Of Consegna)

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
	'''Read from DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a Consegna object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Consegna
		Dim cls as new Consegna

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Consegne WHERE IdConsegna = " & Id
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
	'''Save on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Consegna) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdConsegna = 0 Then
							sql = "INSERT INTO Consegne ("
							sql &= " AlertLevel,"
							sql &= " Annotazioni,"
							sql &= " Blocco,"
							sql &= " CodTrack,"
							sql &= " DataEffettiva,"
							sql &= " DataInserimento,"
							sql &= " DataPrevistaOriginale,"
							sql &= " EmailNotificheCorriere,"
							sql &= " Giorno,"
							sql &= " GuidTransazione,"
							sql &= " IdConsegnaInt,"
							sql &= " IdCorriere,"
							sql &= " IdIndirizzo,"
							sql &= " IdPagam,"
							sql &= " IdStatoConsegna,"
							sql &= " IdUt,"
							sql &= " ImportoNetto,"
							sql &= " NoCartaceo,"
							sql &= " NumColli,"
							sql &= " Peso,"
							sql &= " TipoDoc"
							sql &= ") VALUES ("
							sql &= " @AlertLevel,"
							sql &= " @Annotazioni,"
							sql &= " @Blocco,"
							sql &= " @CodTrack,"
							sql &= " @DataEffettiva,"
							sql &= " @DataInserimento,"
							sql &= " @DataPrevistaOriginale,"
							sql &= " @EmailNotificheCorriere,"
							sql &= " @Giorno,"
							sql &= " @GuidTransazione,"
							sql &= " @IdConsegnaInt,"
							sql &= " @IdCorriere,"
							sql &= " @IdIndirizzo,"
							sql &= " @IdPagam,"
							sql &= " @IdStatoConsegna,"
							sql &= " @IdUt,"
							sql &= " @ImportoNetto,"
							sql &= " @NoCartaceo,"
							sql &= " @NumColli,"
							sql &= " @Peso,"
							sql &= " @TipoDoc"
							sql &= ")"
						Else
							sql = "UPDATE Consegne SET "
							If cls.WhatIsChanged.AlertLevel Then sql &= "AlertLevel = @AlertLevel,"
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.Blocco Then sql &= "Blocco = @Blocco,"
							If cls.WhatIsChanged.CodTrack Then sql &= "CodTrack = @CodTrack,"
							If cls.WhatIsChanged.DataEffettiva Then sql &= "DataEffettiva = @DataEffettiva,"
							If cls.WhatIsChanged.DataInserimento Then sql &= "DataInserimento = @DataInserimento,"
							If cls.WhatIsChanged.DataPrevistaOriginale Then sql &= "DataPrevistaOriginale = @DataPrevistaOriginale,"
							If cls.WhatIsChanged.EmailNotificheCorriere Then sql &= "EmailNotificheCorriere = @EmailNotificheCorriere,"
							If cls.WhatIsChanged.Giorno Then sql &= "Giorno = @Giorno,"
							If cls.WhatIsChanged.GuidTransazione Then sql &= "GuidTransazione = @GuidTransazione,"
							If cls.WhatIsChanged.IdConsegnaInt Then sql &= "IdConsegnaInt = @IdConsegnaInt,"
							If cls.WhatIsChanged.IdCorriere Then sql &= "IdCorriere = @IdCorriere,"
							If cls.WhatIsChanged.IdIndirizzo Then sql &= "IdIndirizzo = @IdIndirizzo,"
							If cls.WhatIsChanged.IdPagam Then sql &= "IdPagam = @IdPagam,"
							If cls.WhatIsChanged.IdStatoConsegna Then sql &= "IdStatoConsegna = @IdStatoConsegna,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.ImportoNetto Then sql &= "ImportoNetto = @ImportoNetto,"
							If cls.WhatIsChanged.NoCartaceo Then sql &= "NoCartaceo = @NoCartaceo,"
							If cls.WhatIsChanged.NumColli Then sql &= "NumColli = @NumColli,"
							If cls.WhatIsChanged.Peso Then sql &= "Peso = @Peso,"
							If cls.WhatIsChanged.TipoDoc Then sql &= "TipoDoc = @TipoDoc"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdConsegna= " & cls.IdConsegna
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AlertLevel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AlertLevel"
							p.Value = cls.AlertLevel
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Annotazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Annotazioni"
							p.Value = cls.Annotazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Blocco Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Blocco"
							p.Value = cls.Blocco
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodTrack Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodTrack"
							p.Value = cls.CodTrack
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataEffettiva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataEffettiva"
							p.DbType = DbType.DateTime
							If cls.DataEffettiva <> Date.MinValue Then
								p.Value = cls.DataEffettiva
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataInserimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataInserimento"
							p.DbType = DbType.DateTime
							If cls.DataInserimento <> Date.MinValue Then
								p.Value = cls.DataInserimento
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataPrevistaOriginale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataPrevistaOriginale"
							p.DbType = DbType.DateTime
							If cls.DataPrevistaOriginale <> Date.MinValue Then
								p.Value = cls.DataPrevistaOriginale
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.EmailNotificheCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@EmailNotificheCorriere"
							p.Value = cls.EmailNotificheCorriere
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Giorno Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Giorno"
							p.DbType = DbType.DateTime
							If cls.Giorno <> Date.MinValue Then
								p.Value = cls.Giorno
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GuidTransazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GuidTransazione"
							p.Value = cls.GuidTransazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdConsegnaInt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdConsegnaInt"
							p.Value = cls.IdConsegnaInt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorriere"
							p.Value = cls.IdCorriere
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdIndirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdIndirizzo"
							p.Value = cls.IdIndirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPagam"
							p.Value = cls.IdPagam
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdStatoConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdStatoConsegna"
							p.Value = cls.IdStatoConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoNetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoNetto"
							p.Value = cls.ImportoNetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoCartaceo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoCartaceo"
							p.Value = cls.NoCartaceo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumColli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumColli"
							p.Value = cls.NumColli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Peso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Peso"
							p.Value = cls.Peso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoDoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoDoc"
							p.Value = cls.TipoDoc
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdConsegna=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdConsegna = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdConsegna
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdConsegna
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
				'Dim Sql As String = "UPDATE Consegne SET DELETED=True "
				Dim Sql As String = "DELETE FROM Consegne"
				Sql &= " WHERE IdConsegna = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Consegne. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Consegne. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Consegna, Optional ByRef ListaObj as List (of Consegna) = Nothing)
		DestroyPermanently (obj.IdConsegna)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Consegna
		Dim ris As Consegna = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Consegna) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return first of Consegna
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Consegna
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return first of Consegna
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Consegna
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Consegna
	''' </summary>
	''' <returns>
	'''Return first of Consegna
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Consegna
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Consegna)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Consegna)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Consegna)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Consegna)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Consegna)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return a list of Consegna
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Consegna)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Consegne by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Consegna by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Consegna)
		Dim Ls As New List(Of Consegna)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Consegna)
		Dim Ls As New List(Of Consegna)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Consegne" 
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
	'''Return all record on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return all record in list of Consegna
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Consegna)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return all record in list of Consegna
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Consegna)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Consegne
	''' </summary>
	''' <returns>
	'''Return all record in list of Consegna
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Consegna)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Consegna)
		Dim Ls As List(Of Consegna)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Consegne" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Consegna)
		Dim Ls As New List(Of Consegna)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Consegna() With {.IdConsegna = 0 ,.AlertLevel = 0 ,.Annotazioni = "" ,.Blocco = 0 ,.CodTrack = "" ,.DataEffettiva = Nothing ,.DataInserimento = Nothing ,.DataPrevistaOriginale = Nothing ,.EmailNotificheCorriere = "" ,.Giorno = Nothing ,.GuidTransazione = "" ,.IdConsegnaInt = 0 ,.IdCorriere = 0 ,.IdIndirizzo = 0 ,.IdPagam = 0 ,.IdStatoConsegna = 0 ,.IdUt = 0 ,.ImportoNetto = 0 ,.NoCartaceo = 0 ,.NumColli = 0 ,.Peso = 0 ,.TipoDoc = 0  })
					While myReader.Read
						Dim classe as new Consegna(CType(myReader, IDataRecord))
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