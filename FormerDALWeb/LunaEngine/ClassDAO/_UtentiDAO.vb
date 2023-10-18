#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 11/03/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Utente object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _UtentiDAO
	Inherits LUNA.LunaBaseClassDAO(Of Utente)

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
	'''Read from DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a Utente object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Utente
		Dim cls as new Utente

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Utenti WHERE IdUt = " & Id
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
	'''Save on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Utente) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdUt = 0 Then
							sql = "INSERT INTO Utenti ("
							sql &= " Cap,"
							sql &= " Cellulare,"
							sql &= " Citta,"
							sql &= " CodFisc,"
							sql &= " CodiceSDI,"
							sql &= " Cognome,"
							sql &= " DataIns,"
							sql &= " DisattivaAccessoSito,"
							sql &= " DownloadEsplicito,"
							sql &= " Email,"
							sql &= " Fax,"
							sql &= " IdComune,"
							sql &= " IdCorriereDef,"
							sql &= " IdNazione,"
							sql &= " IdPagamento,"
							sql &= " IdProvincia,"
							sql &= " IdRubricaInt,"
							sql &= " IdTipoAttivita,"
							sql &= " Indirizzo,"
							sql &= " LastIp,"
							sql &= " LastLogin,"
							sql &= " LastUpdate,"
							sql &= " NoCheckDatiFisc,"
							sql &= " NoMail,"
							sql &= " Nome,"
							sql &= " PasswordHash,"
							sql &= " Pec,"
							sql &= " Piva,"
							sql &= " PrefissoPIva,"
							sql &= " Provincia,"
							sql &= " RagSoc,"
							sql &= " SitoWeb,"
							sql &= " Tel,"
							sql &= " TipoRub,"
							sql &= " TipoWeb,"
							sql &= " UpdateFromUser"
							sql &= ") VALUES ("
							sql &= " @Cap,"
							sql &= " @Cellulare,"
							sql &= " @Citta,"
							sql &= " @CodFisc,"
							sql &= " @CodiceSDI,"
							sql &= " @Cognome,"
							sql &= " @DataIns,"
							sql &= " @DisattivaAccessoSito,"
							sql &= " @DownloadEsplicito,"
							sql &= " @Email,"
							sql &= " @Fax,"
							sql &= " @IdComune,"
							sql &= " @IdCorriereDef,"
							sql &= " @IdNazione,"
							sql &= " @IdPagamento,"
							sql &= " @IdProvincia,"
							sql &= " @IdRubricaInt,"
							sql &= " @IdTipoAttivita,"
							sql &= " @Indirizzo,"
							sql &= " @LastIp,"
							sql &= " @LastLogin,"
							sql &= " @LastUpdate,"
							sql &= " @NoCheckDatiFisc,"
							sql &= " @NoMail,"
							sql &= " @Nome,"
							sql &= " @PasswordHash,"
							sql &= " @Pec,"
							sql &= " @Piva,"
							sql &= " @PrefissoPIva,"
							sql &= " @Provincia,"
							sql &= " @RagSoc,"
							sql &= " @SitoWeb,"
							sql &= " @Tel,"
							sql &= " @TipoRub,"
							sql &= " @TipoWeb,"
							sql &= " @UpdateFromUser"
							sql &= ")"
						Else
							sql = "UPDATE Utenti SET "
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.Cellulare Then sql &= "Cellulare = @Cellulare,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.CodFisc Then sql &= "CodFisc = @CodFisc,"
							If cls.WhatIsChanged.CodiceSDI Then sql &= "CodiceSDI = @CodiceSDI,"
							If cls.WhatIsChanged.Cognome Then sql &= "Cognome = @Cognome,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.DisattivaAccessoSito Then sql &= "DisattivaAccessoSito = @DisattivaAccessoSito,"
							If cls.WhatIsChanged.DownloadEsplicito Then sql &= "DownloadEsplicito = @DownloadEsplicito,"
							If cls.WhatIsChanged.Email Then sql &= "Email = @Email,"
							If cls.WhatIsChanged.Fax Then sql &= "Fax = @Fax,"
							If cls.WhatIsChanged.IdComune Then sql &= "IdComune = @IdComune,"
							If cls.WhatIsChanged.IdCorriereDef Then sql &= "IdCorriereDef = @IdCorriereDef,"
							If cls.WhatIsChanged.IdNazione Then sql &= "IdNazione = @IdNazione,"
							If cls.WhatIsChanged.IdPagamento Then sql &= "IdPagamento = @IdPagamento,"
							If cls.WhatIsChanged.IdProvincia Then sql &= "IdProvincia = @IdProvincia,"
							If cls.WhatIsChanged.IdRubricaInt Then sql &= "IdRubricaInt = @IdRubricaInt,"
							If cls.WhatIsChanged.IdTipoAttivita Then sql &= "IdTipoAttivita = @IdTipoAttivita,"
							If cls.WhatIsChanged.Indirizzo Then sql &= "Indirizzo = @Indirizzo,"
							If cls.WhatIsChanged.LastIp Then sql &= "LastIp = @LastIp,"
							If cls.WhatIsChanged.LastLogin Then sql &= "LastLogin = @LastLogin,"
							If cls.WhatIsChanged.LastUpdate Then sql &= "LastUpdate = @LastUpdate,"
							If cls.WhatIsChanged.NoCheckDatiFisc Then sql &= "NoCheckDatiFisc = @NoCheckDatiFisc,"
							If cls.WhatIsChanged.NoMail Then sql &= "NoMail = @NoMail,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.PasswordHash Then sql &= "PasswordHash = @PasswordHash,"
							If cls.WhatIsChanged.Pec Then sql &= "Pec = @Pec,"
							If cls.WhatIsChanged.Piva Then sql &= "Piva = @Piva,"
							If cls.WhatIsChanged.PrefissoPIva Then sql &= "PrefissoPIva = @PrefissoPIva,"
							If cls.WhatIsChanged.Provincia Then sql &= "Provincia = @Provincia,"
							If cls.WhatIsChanged.RagSoc Then sql &= "RagSoc = @RagSoc,"
							If cls.WhatIsChanged.SitoWeb Then sql &= "SitoWeb = @SitoWeb,"
							If cls.WhatIsChanged.Tel Then sql &= "Tel = @Tel,"
							If cls.WhatIsChanged.TipoRub Then sql &= "TipoRub = @TipoRub,"
							If cls.WhatIsChanged.TipoWeb Then sql &= "TipoWeb = @TipoWeb,"
							If cls.WhatIsChanged.UpdateFromUser Then sql &= "UpdateFromUser = @UpdateFromUser"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdUt= " & cls.IdUt
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Cap Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cap"
							p.Value = cls.Cap
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Cellulare Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cellulare"
							p.Value = cls.Cellulare
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Citta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Citta"
							p.Value = cls.Citta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodFisc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodFisc"
							p.Value = cls.CodFisc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CodiceSDI Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceSDI"
							p.Value = cls.CodiceSDI
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Cognome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cognome"
							p.Value = cls.Cognome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataIns Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataIns"
							p.DbType = DbType.DateTime
							If cls.DataIns <> Date.MinValue Then
								p.Value = cls.DataIns
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DisattivaAccessoSito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DisattivaAccessoSito"
							p.Value = cls.DisattivaAccessoSito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DownloadEsplicito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DownloadEsplicito"
							p.Value = cls.DownloadEsplicito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Email Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Email"
							p.Value = cls.Email
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Fax Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Fax"
							p.Value = cls.Fax
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdComune Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdComune"
							p.Value = cls.IdComune
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorriereDef Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorriereDef"
							p.Value = cls.IdCorriereDef
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdNazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdNazione"
							p.Value = cls.IdNazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPagamento"
							p.Value = cls.IdPagamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdProvincia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdProvincia"
							p.Value = cls.IdProvincia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRubricaInt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRubricaInt"
							p.Value = cls.IdRubricaInt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoAttivita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoAttivita"
							p.Value = cls.IdTipoAttivita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Indirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Indirizzo"
							p.Value = cls.Indirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastIp Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastIp"
							p.Value = cls.LastIp
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastLogin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastLogin"
							p.DbType = DbType.DateTime
							If cls.LastLogin <> Date.MinValue Then
								p.Value = cls.LastLogin
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastUpdate Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastUpdate"
							p.DbType = DbType.DateTime
							If cls.LastUpdate <> Date.MinValue Then
								p.Value = cls.LastUpdate
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoCheckDatiFisc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoCheckDatiFisc"
							p.Value = cls.NoCheckDatiFisc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoMail Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoMail"
							p.Value = cls.NoMail
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PasswordHash Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PasswordHash"
							p.Value = cls.PasswordHash
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Pec Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Pec"
							p.Value = cls.Pec
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Piva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Piva"
							p.Value = cls.Piva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrefissoPIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrefissoPIva"
							p.Value = cls.PrefissoPIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Provincia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Provincia"
							p.Value = cls.Provincia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RagSoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RagSoc"
							p.Value = cls.RagSoc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SitoWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SitoWeb"
							p.Value = cls.SitoWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tel"
							p.Value = cls.Tel
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoRub"
							p.Value = cls.TipoRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoWeb"
							p.Value = cls.TipoWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UpdateFromUser Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UpdateFromUser"
							p.Value = cls.UpdateFromUser
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdUt=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdUt = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdUt
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdUt
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
				'Dim Sql As String = "UPDATE Utenti SET DELETED=True "
				Dim Sql As String = "DELETE FROM Utenti"
				Sql &= " WHERE IdUt = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Utenti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Utenti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Utente, Optional ByRef ListaObj as List (of Utente) = Nothing)
		DestroyPermanently (obj.IdUt)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Utente
		Dim ris As Utente = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Utente) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return first of Utente
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Utente
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return first of Utente
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Utente
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Utente
	''' </summary>
	''' <returns>
	'''Return first of Utente
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Utente
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Utente)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Utenti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Utente by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Utente)
		Dim Ls As New List(Of Utente)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Utente)
		Dim Ls As New List(Of Utente)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Utenti" 
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
	'''Return all record on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Utente
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Utente)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Utente
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Utente)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Utenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Utente
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Utente)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Utente)
		Dim Ls As List(Of Utente)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Utenti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Utente)
		Dim Ls As New List(Of Utente)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Utente() With {.IdUt = 0 ,.Cap = "" ,.Cellulare = "" ,.Citta = "" ,.CodFisc = "" ,.CodiceSDI = "" ,.Cognome = "" ,.DataIns = Nothing ,.DisattivaAccessoSito = 0 ,.DownloadEsplicito = 0 ,.Email = "" ,.Fax = "" ,.IdComune = 0 ,.IdCorriereDef = 0 ,.IdNazione = 0 ,.IdPagamento = 0 ,.IdProvincia = 0 ,.IdRubricaInt = 0 ,.IdTipoAttivita = 0 ,.Indirizzo = "" ,.LastIp = "" ,.LastLogin = Nothing ,.LastUpdate = Nothing ,.NoCheckDatiFisc = 0 ,.NoMail = 0 ,.Nome = "" ,.PasswordHash = "" ,.Pec = "" ,.Piva = "" ,.PrefissoPIva = "" ,.Provincia = "" ,.RagSoc = "" ,.SitoWeb = "" ,.Tel = "" ,.TipoRub = 0 ,.TipoWeb = 0 ,.UpdateFromUser = 0  })
					While myReader.Read
						Dim classe as new Utente(CType(myReader, IDataRecord))
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