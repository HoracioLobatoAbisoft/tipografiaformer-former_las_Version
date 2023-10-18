#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of LavLog object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _LavLogDAO
	Inherits LUNA.LunaBaseClassDAO(Of LavLog)

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
	'''Read from DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a LavLog object
	''' </returns>
	Public Overrides Function Read(Id as integer) as LavLog
		Dim cls as new LavLog

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_lavlog WHERE IdLavLog = " & Id
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
	'''Save on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as LavLog) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLavLog = 0 Then
							sql = "INSERT INTO T_lavlog ("
							sql &= " Custom,"
							sql &= " DataOraFine,"
							sql &= " DataOraInizio,"
							sql &= " Descrizione,"
							sql &= " ExtraData,"
							sql &= " IdCom,"
							sql &= " Idlav,"
							sql &= " IdMacchinario,"
							sql &= " IdOrd,"
							sql &= " IdUt,"
							sql &= " IdUtenteForzato,"
							sql &= " Macchinario,"
							sql &= " Opz,"
							sql &= " Ordine,"
							sql &= " Premio,"
							sql &= " Tempo,"
							sql &= " TempoStimatoOperatore"
							sql &= ") VALUES ("
							sql &= " @Custom,"
							sql &= " @DataOraFine,"
							sql &= " @DataOraInizio,"
							sql &= " @Descrizione,"
							sql &= " @ExtraData,"
							sql &= " @IdCom,"
							sql &= " @Idlav,"
							sql &= " @IdMacchinario,"
							sql &= " @IdOrd,"
							sql &= " @IdUt,"
							sql &= " @IdUtenteForzato,"
							sql &= " @Macchinario,"
							sql &= " @Opz,"
							sql &= " @Ordine,"
							sql &= " @Premio,"
							sql &= " @Tempo,"
							sql &= " @TempoStimatoOperatore"
							sql &= ")"
						Else
							sql = "UPDATE T_lavlog SET "
							If cls.WhatIsChanged.Custom Then sql &= "Custom = @Custom,"
							If cls.WhatIsChanged.DataOraFine Then sql &= "DataOraFine = @DataOraFine,"
							If cls.WhatIsChanged.DataOraInizio Then sql &= "DataOraInizio = @DataOraInizio,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.ExtraData Then sql &= "ExtraData = @ExtraData,"
							If cls.WhatIsChanged.IdCom Then sql &= "IdCom = @IdCom,"
							If cls.WhatIsChanged.Idlav Then sql &= "Idlav = @Idlav,"
							If cls.WhatIsChanged.IdMacchinario Then sql &= "IdMacchinario = @IdMacchinario,"
							If cls.WhatIsChanged.IdOrd Then sql &= "IdOrd = @IdOrd,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.IdUtenteForzato Then sql &= "IdUtenteForzato = @IdUtenteForzato,"
							If cls.WhatIsChanged.Macchinario Then sql &= "Macchinario = @Macchinario,"
							If cls.WhatIsChanged.Opz Then sql &= "Opz = @Opz,"
							If cls.WhatIsChanged.Ordine Then sql &= "Ordine = @Ordine,"
							If cls.WhatIsChanged.Premio Then sql &= "Premio = @Premio,"
							If cls.WhatIsChanged.Tempo Then sql &= "Tempo = @Tempo,"
							If cls.WhatIsChanged.TempoStimatoOperatore Then sql &= "TempoStimatoOperatore = @TempoStimatoOperatore"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLavLog= " & cls.IdLavLog
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Custom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Custom"
							p.Value = cls.Custom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataOraFine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataOraFine"
							p.DbType = DbType.DateTime
							If cls.DataOraFine <> Date.MinValue Then
								p.Value = cls.DataOraFine
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataOraInizio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataOraInizio"
							p.DbType = DbType.DateTime
							If cls.DataOraInizio <> Date.MinValue Then
								p.Value = cls.DataOraInizio
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ExtraData Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ExtraData"
							p.Value = cls.ExtraData
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCom"
							p.Value = cls.IdCom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Idlav Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Idlav"
							p.Value = cls.Idlav
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinario"
							p.Value = cls.IdMacchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrd"
							p.Value = cls.IdOrd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtenteForzato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtenteForzato"
							p.Value = cls.IdUtenteForzato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Macchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Macchinario"
							p.Value = cls.Macchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Opz Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Opz"
							p.Value = cls.Opz
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Ordine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Ordine"
							p.Value = cls.Ordine
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Premio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Premio"
							p.Value = cls.Premio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tempo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tempo"
							p.Value = cls.Tempo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TempoStimatoOperatore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TempoStimatoOperatore"
							p.Value = cls.TempoStimatoOperatore
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdLavLog=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdLavLog = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdLavLog
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLavLog
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
				'Dim Sql As String = "UPDATE T_lavlog SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_lavlog"
				Sql &= " WHERE IdLavLog = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_lavlog. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_lavlog. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as LavLog, Optional ByRef ListaObj as List (of LavLog) = Nothing)
		DestroyPermanently (obj.IdLavLog)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavLog
		Dim ris As LavLog = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of LavLog) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return first of LavLog
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavLog
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return first of LavLog
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavLog
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table LavLog
	''' </summary>
	''' <returns>
	'''Return first of LavLog
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavLog
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavLog)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavLog)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavLog)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavLog)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavLog)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return a list of LavLog
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of LavLog)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavlog by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of LavLog by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of LavLog)
		Dim Ls As New List(Of LavLog)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of LavLog)
		Dim Ls As New List(Of LavLog)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_lavlog" 
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
	'''Return all record on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return all record in list of LavLog
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of LavLog)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return all record in list of LavLog
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavLog)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_lavlog
	''' </summary>
	''' <returns>
	'''Return all record in list of LavLog
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavLog)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavLog)
		Dim Ls As List(Of LavLog)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_lavlog" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavLog)
		Dim Ls As New List(Of LavLog)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  LavLog() With {.IdLavLog = 0 ,.Custom = False ,.DataOraFine = Nothing ,.DataOraInizio = Nothing ,.Descrizione = EmptyItemDescription,.ExtraData = "" ,.IdCom = 0 ,.Idlav = 0 ,.IdMacchinario = 0 ,.IdOrd = 0 ,.IdUt = 0 ,.IdUtenteForzato = 0 ,.Macchinario = "" ,.Opz = False ,.Ordine = 0 ,.Premio = 0 ,.Tempo = 0 ,.TempoStimatoOperatore = 0  })
					While myReader.Read
						Dim classe as new LavLog(CType(myReader, IDataRecord))
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