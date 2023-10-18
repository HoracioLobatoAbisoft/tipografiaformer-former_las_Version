#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/12/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of ConsegnaProgrammata object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ConsegneProgrammateDAO
	Inherits LUNA.LunaBaseClassDAO(Of ConsegnaProgrammata)

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
	'''Read from DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a ConsegnaProgrammata object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ConsegnaProgrammata
		Dim cls as new ConsegnaProgrammata

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_cons WHERE IdCons = " & Id
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
	'''Save on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ConsegnaProgrammata) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCons = 0 Then
							sql = "INSERT INTO T_cons ("
							sql &= " Annotazioni,"
							sql &= " AssRilIntMitt,"
							sql &= " Blocco,"
							sql &= " CodTrack,"
							sql &= " DataEffettiva,"
							sql &= " DataPrevistaOriginale,"
							sql &= " DataTrasmissioneCorriere,"
							sql &= " Eliminato,"
							sql &= " EmailNotificheCorriere,"
							sql &= " ForzaCsvCorriere,"
							sql &= " Giorno,"
							sql &= " GiornoPartenza,"
							sql &= " IdAziendaForzata,"
							sql &= " IdConsOnline,"
							sql &= " IdCorr,"
							sql &= " IdIndirizzo,"
							sql &= " IdOperatore,"
							sql &= " IdPagam,"
							sql &= " IdRub,"
							sql &= " IdStatoConsegna,"
							sql &= " ImportoNetto,"
							sql &= " LastUpdate,"
							sql &= " MatPom,"
							sql &= " NoCartaceo,"
							sql &= " NoRegistrazioneGLS,"
							sql &= " NumColli,"
							sql &= " NumeroPrimoColloBartolini,"
							sql &= " Peso,"
							sql &= " StampaDocumenti,"
							sql &= " TipoDoc"
							sql &= ") VALUES ("
							sql &= " @Annotazioni,"
							sql &= " @AssRilIntMitt,"
							sql &= " @Blocco,"
							sql &= " @CodTrack,"
							sql &= " @DataEffettiva,"
							sql &= " @DataPrevistaOriginale,"
							sql &= " @DataTrasmissioneCorriere,"
							sql &= " @Eliminato,"
							sql &= " @EmailNotificheCorriere,"
							sql &= " @ForzaCsvCorriere,"
							sql &= " @Giorno,"
							sql &= " @GiornoPartenza,"
							sql &= " @IdAziendaForzata,"
							sql &= " @IdConsOnline,"
							sql &= " @IdCorr,"
							sql &= " @IdIndirizzo,"
							sql &= " @IdOperatore,"
							sql &= " @IdPagam,"
							sql &= " @IdRub,"
							sql &= " @IdStatoConsegna,"
							sql &= " @ImportoNetto,"
							sql &= " @LastUpdate,"
							sql &= " @MatPom,"
							sql &= " @NoCartaceo,"
							sql &= " @NoRegistrazioneGLS,"
							sql &= " @NumColli,"
							sql &= " @NumeroPrimoColloBartolini,"
							sql &= " @Peso,"
							sql &= " @StampaDocumenti,"
							sql &= " @TipoDoc"
							sql &= ")"
						Else
							sql = "UPDATE T_cons SET "
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.AssRilIntMitt Then sql &= "AssRilIntMitt = @AssRilIntMitt,"
							If cls.WhatIsChanged.Blocco Then sql &= "Blocco = @Blocco,"
							If cls.WhatIsChanged.CodTrack Then sql &= "CodTrack = @CodTrack,"
							If cls.WhatIsChanged.DataEffettiva Then sql &= "DataEffettiva = @DataEffettiva,"
							If cls.WhatIsChanged.DataPrevistaOriginale Then sql &= "DataPrevistaOriginale = @DataPrevistaOriginale,"
							If cls.WhatIsChanged.DataTrasmissioneCorriere Then sql &= "DataTrasmissioneCorriere = @DataTrasmissioneCorriere,"
							If cls.WhatIsChanged.Eliminato Then sql &= "Eliminato = @Eliminato,"
							If cls.WhatIsChanged.EmailNotificheCorriere Then sql &= "EmailNotificheCorriere = @EmailNotificheCorriere,"
							If cls.WhatIsChanged.ForzaCsvCorriere Then sql &= "ForzaCsvCorriere = @ForzaCsvCorriere,"
							If cls.WhatIsChanged.Giorno Then sql &= "Giorno = @Giorno,"
							If cls.WhatIsChanged.GiornoPartenza Then sql &= "GiornoPartenza = @GiornoPartenza,"
							If cls.WhatIsChanged.IdAziendaForzata Then sql &= "IdAziendaForzata = @IdAziendaForzata,"
							If cls.WhatIsChanged.IdConsOnline Then sql &= "IdConsOnline = @IdConsOnline,"
							If cls.WhatIsChanged.IdCorr Then sql &= "IdCorr = @IdCorr,"
							If cls.WhatIsChanged.IdIndirizzo Then sql &= "IdIndirizzo = @IdIndirizzo,"
							If cls.WhatIsChanged.IdOperatore Then sql &= "IdOperatore = @IdOperatore,"
							If cls.WhatIsChanged.IdPagam Then sql &= "IdPagam = @IdPagam,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdStatoConsegna Then sql &= "IdStatoConsegna = @IdStatoConsegna,"
							If cls.WhatIsChanged.ImportoNetto Then sql &= "ImportoNetto = @ImportoNetto,"
							If cls.WhatIsChanged.LastUpdate Then sql &= "LastUpdate = @LastUpdate,"
							If cls.WhatIsChanged.MatPom Then sql &= "MatPom = @MatPom,"
							If cls.WhatIsChanged.NoCartaceo Then sql &= "NoCartaceo = @NoCartaceo,"
							If cls.WhatIsChanged.NoRegistrazioneGLS Then sql &= "NoRegistrazioneGLS = @NoRegistrazioneGLS,"
							If cls.WhatIsChanged.NumColli Then sql &= "NumColli = @NumColli,"
							If cls.WhatIsChanged.NumeroPrimoColloBartolini Then sql &= "NumeroPrimoColloBartolini = @NumeroPrimoColloBartolini,"
							If cls.WhatIsChanged.Peso Then sql &= "Peso = @Peso,"
							If cls.WhatIsChanged.StampaDocumenti Then sql &= "StampaDocumenti = @StampaDocumenti,"
							If cls.WhatIsChanged.TipoDoc Then sql &= "TipoDoc = @TipoDoc"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCons= " & cls.IdCons
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Annotazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Annotazioni"
							p.Value = cls.Annotazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AssRilIntMitt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AssRilIntMitt"
							p.Value = cls.AssRilIntMitt
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

						If cls.WhatIsChanged.DataTrasmissioneCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataTrasmissioneCorriere"
							p.DbType = DbType.DateTime
							If cls.DataTrasmissioneCorriere <> Date.MinValue Then
								p.Value = cls.DataTrasmissioneCorriere
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Eliminato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Eliminato"
							p.Value = cls.Eliminato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.EmailNotificheCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@EmailNotificheCorriere"
							p.Value = cls.EmailNotificheCorriere
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ForzaCsvCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ForzaCsvCorriere"
							p.Value = cls.ForzaCsvCorriere
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

						If cls.WhatIsChanged.GiornoPartenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GiornoPartenza"
							p.DbType = DbType.DateTime
							If cls.GiornoPartenza <> Date.MinValue Then
								p.Value = cls.GiornoPartenza
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAziendaForzata Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAziendaForzata"
							p.Value = cls.IdAziendaForzata
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdConsOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdConsOnline"
							p.Value = cls.IdConsOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorr"
							p.Value = cls.IdCorr
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdIndirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdIndirizzo"
							p.Value = cls.IdIndirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOperatore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOperatore"
							p.Value = cls.IdOperatore
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPagam"
							p.Value = cls.IdPagam
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdStatoConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdStatoConsegna"
							p.Value = cls.IdStatoConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoNetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoNetto"
							p.Value = cls.ImportoNetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastUpdate Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastUpdate"
							p.Value = cls.LastUpdate
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MatPom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MatPom"
							p.Value = cls.MatPom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoCartaceo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoCartaceo"
							p.Value = cls.NoCartaceo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoRegistrazioneGLS Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoRegistrazioneGLS"
							p.Value = cls.NoRegistrazioneGLS
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumColli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumColli"
							p.Value = cls.NumColli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroPrimoColloBartolini Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroPrimoColloBartolini"
							p.Value = cls.NumeroPrimoColloBartolini
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Peso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Peso"
							p.Value = cls.Peso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StampaDocumenti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StampaDocumenti"
							p.Value = cls.StampaDocumenti
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

		            
						If cls.IdCons=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCons = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCons
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCons
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
				'Dim Sql As String = "UPDATE T_cons SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_cons"
				Sql &= " WHERE IdCons = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_cons. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_cons. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ConsegnaProgrammata, Optional ByRef ListaObj as List (of ConsegnaProgrammata) = Nothing)
		DestroyPermanently (obj.IdCons)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ConsegnaProgrammata
		Dim ris As ConsegnaProgrammata = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ConsegnaProgrammata) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return first of ConsegnaProgrammata
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ConsegnaProgrammata
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return first of ConsegnaProgrammata
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ConsegnaProgrammata
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ConsegnaProgrammata
	''' </summary>
	''' <returns>
	'''Return first of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ConsegnaProgrammata
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ConsegnaProgrammata)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ConsegnaProgrammata)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ConsegnaProgrammata)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ConsegnaProgrammata)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ConsegnaProgrammata)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ConsegnaProgrammata)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_cons by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ConsegnaProgrammata by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ConsegnaProgrammata)
		Dim Ls As New List(Of ConsegnaProgrammata)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ConsegnaProgrammata)
		Dim Ls As New List(Of ConsegnaProgrammata)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_cons" 
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
	'''Return all record on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return all record in list of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ConsegnaProgrammata)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return all record in list of ConsegnaProgrammata
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ConsegnaProgrammata)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_cons
	''' </summary>
	''' <returns>
	'''Return all record in list of ConsegnaProgrammata
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ConsegnaProgrammata)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ConsegnaProgrammata)
		Dim Ls As List(Of ConsegnaProgrammata)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_cons" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ConsegnaProgrammata)
		Dim Ls As New List(Of ConsegnaProgrammata)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ConsegnaProgrammata() With {.IdCons = 0 ,.Annotazioni = "" ,.AssRilIntMitt = 0 ,.Blocco = 0 ,.CodTrack = "" ,.DataEffettiva = Nothing ,.DataPrevistaOriginale = Nothing ,.DataTrasmissioneCorriere = Nothing ,.Eliminato = 0 ,.EmailNotificheCorriere = "" ,.ForzaCsvCorriere = 0 ,.Giorno = Nothing ,.GiornoPartenza = Nothing ,.IdAziendaForzata = 0 ,.IdConsOnline = 0 ,.IdCorr = 0 ,.IdIndirizzo = 0 ,.IdOperatore = 0 ,.IdPagam = 0 ,.IdRub = 0 ,.IdStatoConsegna = 0 ,.ImportoNetto = 0 ,.LastUpdate = 0 ,.MatPom = 0 ,.NoCartaceo = 0 ,.NoRegistrazioneGLS = 0 ,.NumColli = 0 ,.NumeroPrimoColloBartolini = "" ,.Peso = 0 ,.StampaDocumenti = 0 ,.TipoDoc = 0  })
					While myReader.Read
						Dim classe as new ConsegnaProgrammata(CType(myReader, IDataRecord))
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