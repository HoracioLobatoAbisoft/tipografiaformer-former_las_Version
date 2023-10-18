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
'''This class manage persistency on db of RichiestaRegistrazioneW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _RichiesteRegistrazioneWDAO
	Inherits LUNA.LunaBaseClassDAO(Of RichiestaRegistrazioneW)

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
	'''Read from DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a RichiestaRegistrazioneW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as RichiestaRegistrazioneW
		Dim cls as new RichiestaRegistrazioneW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Richiesteregistrazione WHERE IdRichReg = " & Id
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
	'''Save on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as RichiestaRegistrazioneW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdRichReg = 0 Then
							sql = "INSERT INTO Richiesteregistrazione ("
							sql &= " Cap,"
							sql &= " Citta,"
							sql &= " Citta,"
							sql &= " CodFisc,"
							sql &= " Cognome,"
							sql &= " Email,"
							sql &= " IdComune,"
							sql &= " IdProvincia,"
							sql &= " Indirizzo,"
							sql &= " Nazione,"
							sql &= " Nome,"
							sql &= " NomeAz,"
							sql &= " Piva,"
							sql &= " Sito,"
							sql &= " Stato,"
							sql &= " Telefono,"
							sql &= " Tipo,"
							sql &= " TipoStr"
							sql &= ") VALUES ("
							sql &= " @Cap,"
							sql &= " @Citta,"
							sql &= " @Citta,"
							sql &= " @CodFisc,"
							sql &= " @Cognome,"
							sql &= " @Email,"
							sql &= " @IdComune,"
							sql &= " @IdProvincia,"
							sql &= " @Indirizzo,"
							sql &= " @Nazione,"
							sql &= " @Nome,"
							sql &= " @NomeAz,"
							sql &= " @Piva,"
							sql &= " @Sito,"
							sql &= " @Stato,"
							sql &= " @Telefono,"
							sql &= " @Tipo,"
							sql &= " @TipoStr"
							sql &= ")"
						Else
							sql = "UPDATE Richiesteregistrazione SET "
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.CodFisc Then sql &= "CodFisc = @CodFisc,"
							If cls.WhatIsChanged.Cognome Then sql &= "Cognome = @Cognome,"
							If cls.WhatIsChanged.Email Then sql &= "Email = @Email,"
							If cls.WhatIsChanged.IdComune Then sql &= "IdComune = @IdComune,"
							If cls.WhatIsChanged.IdProvincia Then sql &= "IdProvincia = @IdProvincia,"
							If cls.WhatIsChanged.Indirizzo Then sql &= "Indirizzo = @Indirizzo,"
							If cls.WhatIsChanged.Nazione Then sql &= "Nazione = @Nazione,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.NomeAz Then sql &= "NomeAz = @NomeAz,"
							If cls.WhatIsChanged.Piva Then sql &= "Piva = @Piva,"
							If cls.WhatIsChanged.Sito Then sql &= "Sito = @Sito,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.Telefono Then sql &= "Telefono = @Telefono,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.TipoStr Then sql &= "TipoStr = @TipoStr"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdRichReg= " & cls.IdRichReg
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Cap Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cap"
							p.Value = cls.Cap
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Citta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Citta"
							p.Value = cls.Citta
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

						If cls.WhatIsChanged.Cognome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cognome"
							p.Value = cls.Cognome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Email Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Email"
							p.Value = cls.Email
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdComune Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdComune"
							p.Value = cls.IdComune
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdProvincia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdProvincia"
							p.Value = cls.IdProvincia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Indirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Indirizzo"
							p.Value = cls.Indirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nazione"
							p.Value = cls.Nazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeAz Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeAz"
							p.Value = cls.NomeAz
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Piva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Piva"
							p.Value = cls.Piva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sito"
							p.Value = cls.Sito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Telefono Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Telefono"
							p.Value = cls.Telefono
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipo"
							p.Value = cls.Tipo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoStr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoStr"
							p.Value = cls.TipoStr
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdRichReg=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdRichReg = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdRichReg
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdRichReg
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
				'Dim Sql As String = "UPDATE Richiesteregistrazione SET DELETED=True "
				Dim Sql As String = "DELETE FROM Richiesteregistrazione"
				Sql &= " WHERE IdRichReg = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Richiesteregistrazione. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Richiesteregistrazione. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as RichiestaRegistrazioneW, Optional ByRef ListaObj as List (of RichiestaRegistrazioneW) = Nothing)
		DestroyPermanently (obj.IdRichReg)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As RichiestaRegistrazioneW
		Dim ris As RichiestaRegistrazioneW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of RichiestaRegistrazioneW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return first of RichiestaRegistrazioneW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As RichiestaRegistrazioneW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return first of RichiestaRegistrazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As RichiestaRegistrazioneW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table RichiestaRegistrazioneW
	''' </summary>
	''' <returns>
	'''Return first of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As RichiestaRegistrazioneW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of RichiestaRegistrazioneW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of RichiestaRegistrazioneW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of RichiestaRegistrazioneW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of RichiestaRegistrazioneW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of RichiestaRegistrazioneW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of RichiestaRegistrazioneW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Richiesteregistrazione by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of RichiestaRegistrazioneW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of RichiestaRegistrazioneW)
		Dim Ls As New List(Of RichiestaRegistrazioneW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of RichiestaRegistrazioneW)
		Dim Ls As New List(Of RichiestaRegistrazioneW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Richiesteregistrazione" 
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
	'''Return all record on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return all record in list of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of RichiestaRegistrazioneW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return all record in list of RichiestaRegistrazioneW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of RichiestaRegistrazioneW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Richiesteregistrazione
	''' </summary>
	''' <returns>
	'''Return all record in list of RichiestaRegistrazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of RichiestaRegistrazioneW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of RichiestaRegistrazioneW)
		Dim Ls As List(Of RichiestaRegistrazioneW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Richiesteregistrazione" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of RichiestaRegistrazioneW)
		Dim Ls As New List(Of RichiestaRegistrazioneW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
                    If AddEmptyItem Then Ls.Add(New RichiestaRegistrazioneW() With {.IdRichReg = 0, .Cap = "", .Citta = "", .CodFisc = "", .Cognome = "", .Email = "", .IdComune = 0, .IdProvincia = 0, .Indirizzo = "", .Nazione = "", .Nome = "", .NomeAz = "", .Piva = "", .Sito = "", .Stato = 0, .Telefono = "", .Tipo = 0, .TipoStr = ""})
                    While myReader.Read
						Dim classe as new RichiestaRegistrazioneW(CType(myReader, IDataRecord))
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