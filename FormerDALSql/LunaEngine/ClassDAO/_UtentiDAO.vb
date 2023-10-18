#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
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
	'''Read from DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return a Utente object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Utente
		Dim cls as new Utente

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_utenti WHERE IdUt = " & Id
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
	'''Save on DB table T_utenti
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
							sql = "INSERT INTO T_utenti ("
							sql &= " AbilitaRepartoImballaggio,"
							sql &= " Attivo,"
							sql &= " idAzienda,"
							sql &= " Login,"
							sql &= " NomeReale,"
							sql &= " NumeroMensilita,"
							sql &= " PathFoto,"
							sql &= " Pwd,"
							sql &= " RedditoLordoMese,"
							sql &= " RepDefault,"
							sql &= " Tipo"
							sql &= ") VALUES ("
							sql &= " @AbilitaRepartoImballaggio,"
							sql &= " @Attivo,"
							sql &= " @idAzienda,"
							sql &= " @Login,"
							sql &= " @NomeReale,"
							sql &= " @NumeroMensilita,"
							sql &= " @PathFoto,"
							sql &= " @Pwd,"
							sql &= " @RedditoLordoMese,"
							sql &= " @RepDefault,"
							sql &= " @Tipo"
							sql &= ")"
						Else
							sql = "UPDATE T_utenti SET "
							If cls.WhatIsChanged.AbilitaRepartoImballaggio Then sql &= "AbilitaRepartoImballaggio = @AbilitaRepartoImballaggio,"
							If cls.WhatIsChanged.Attivo Then sql &= "Attivo = @Attivo,"
							If cls.WhatIsChanged.idAzienda Then sql &= "idAzienda = @idAzienda,"
							If cls.WhatIsChanged.Login Then sql &= "Login = @Login,"
							If cls.WhatIsChanged.NomeReale Then sql &= "NomeReale = @NomeReale,"
							If cls.WhatIsChanged.NumeroMensilita Then sql &= "NumeroMensilita = @NumeroMensilita,"
							If cls.WhatIsChanged.PathFoto Then sql &= "PathFoto = @PathFoto,"
							If cls.WhatIsChanged.Pwd Then sql &= "Pwd = @Pwd,"
							If cls.WhatIsChanged.RedditoLordoMese Then sql &= "RedditoLordoMese = @RedditoLordoMese,"
							If cls.WhatIsChanged.RepDefault Then sql &= "RepDefault = @RepDefault,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdUt= " & cls.IdUt
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AbilitaRepartoImballaggio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AbilitaRepartoImballaggio"
							p.Value = cls.AbilitaRepartoImballaggio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Attivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Attivo"
							p.Value = cls.Attivo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.idAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@idAzienda"
							p.Value = cls.idAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Login Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Login"
							p.Value = cls.Login
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeReale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeReale"
							p.Value = cls.NomeReale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroMensilita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroMensilita"
							p.Value = cls.NumeroMensilita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PathFoto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PathFoto"
							p.Value = cls.PathFoto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Pwd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Pwd"
							p.Value = cls.Pwd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RedditoLordoMese Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RedditoLordoMese"
							p.Value = cls.RedditoLordoMese
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RepDefault Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RepDefault"
							p.Value = cls.RepDefault
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipo"
							p.Value = cls.Tipo
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
				'Dim Sql As String = "UPDATE T_utenti SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_utenti"
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
	'''Delete from DB table T_utenti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_utenti. Accept object to delete and optional a List to remove the object from.
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
	'''Find one on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return first of Utente
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Utente
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_utenti
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
	'''Find on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_utenti
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
	'''Find on DB table T_utenti
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
	'''Find on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Utente)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return a list of Utente
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Utente)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_utenti by custom query 
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
			sql &=" * FROM T_utenti" 
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
	'''Return all record on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Utente
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Utente)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_utenti
	''' </summary>
	''' <returns>
	'''Return all record in list of Utente
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Utente)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_utenti
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
			sql ="SELECT * FROM T_utenti" 
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
					If AddEmptyItem Then Ls.Add(New  Utente() With {.IdUt = 0 ,.AbilitaRepartoImballaggio = 0 ,.Attivo = False ,.idAzienda = 0 ,.Login = "" ,.NomeReale = "" ,.NumeroMensilita = 0 ,.PathFoto = "" ,.Pwd = "" ,.RedditoLordoMese = 0 ,.RepDefault = 0 ,.Tipo = 0  })
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