#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of ModelloCommessa object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ModelliCommessaDAO
	Inherits LUNA.LunaBaseClassDAO(Of ModelloCommessa)

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
	'''Read from DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a ModelloCommessa object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ModelloCommessa
		Dim cls as new ModelloCommessa

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_modellicommessa WHERE IdModello = " & Id
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
	'''Save on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ModelloCommessa) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdModello = 0 Then
							sql = "INSERT INTO T_modellicommessa ("
							sql &= " AbilitatoAutomazione,"
							sql &= " Anteprima,"
							sql &= " AnteprimaR,"
							sql &= " Descrizione,"
							sql &= " Disattivo,"
							sql &= " FileJDP,"
							sql &= " FromGanging,"
							sql &= " FronteRetro,"
							sql &= " FRSuSeStessa,"
							sql &= " IdCatModello,"
							sql &= " IdFormatoMacchina,"
							sql &= " IdMacchinarioDef,"
							sql &= " IdMacchinarioTaglioDef,"
							sql &= " IdReparto,"
							sql &= " Job,"
							sql &= " MinGiroTaglio,"
							sql &= " Nome,"
							sql &= " NumSpazi,"
							sql &= " PathTemplateAutomazione,"
							sql &= " PDF,"
							sql &= " RitieniOkDuplicati,"
							sql &= " TiraturaIdeale"
							sql &= ") VALUES ("
							sql &= " @AbilitatoAutomazione,"
							sql &= " @Anteprima,"
							sql &= " @AnteprimaR,"
							sql &= " @Descrizione,"
							sql &= " @Disattivo,"
							sql &= " @FileJDP,"
							sql &= " @FromGanging,"
							sql &= " @FronteRetro,"
							sql &= " @FRSuSeStessa,"
							sql &= " @IdCatModello,"
							sql &= " @IdFormatoMacchina,"
							sql &= " @IdMacchinarioDef,"
							sql &= " @IdMacchinarioTaglioDef,"
							sql &= " @IdReparto,"
							sql &= " @Job,"
							sql &= " @MinGiroTaglio,"
							sql &= " @Nome,"
							sql &= " @NumSpazi,"
							sql &= " @PathTemplateAutomazione,"
							sql &= " @PDF,"
							sql &= " @RitieniOkDuplicati,"
							sql &= " @TiraturaIdeale"
							sql &= ")"
						Else
							sql = "UPDATE T_modellicommessa SET "
							If cls.WhatIsChanged.AbilitatoAutomazione Then sql &= "AbilitatoAutomazione = @AbilitatoAutomazione,"
							If cls.WhatIsChanged.Anteprima Then sql &= "Anteprima = @Anteprima,"
							If cls.WhatIsChanged.AnteprimaR Then sql &= "AnteprimaR = @AnteprimaR,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.Disattivo Then sql &= "Disattivo = @Disattivo,"
							If cls.WhatIsChanged.FileJDP Then sql &= "FileJDP = @FileJDP,"
							If cls.WhatIsChanged.FromGanging Then sql &= "FromGanging = @FromGanging,"
							If cls.WhatIsChanged.FronteRetro Then sql &= "FronteRetro = @FronteRetro,"
							If cls.WhatIsChanged.FRSuSeStessa Then sql &= "FRSuSeStessa = @FRSuSeStessa,"
							If cls.WhatIsChanged.IdCatModello Then sql &= "IdCatModello = @IdCatModello,"
							If cls.WhatIsChanged.IdFormatoMacchina Then sql &= "IdFormatoMacchina = @IdFormatoMacchina,"
							If cls.WhatIsChanged.IdMacchinarioDef Then sql &= "IdMacchinarioDef = @IdMacchinarioDef,"
							If cls.WhatIsChanged.IdMacchinarioTaglioDef Then sql &= "IdMacchinarioTaglioDef = @IdMacchinarioTaglioDef,"
							If cls.WhatIsChanged.IdReparto Then sql &= "IdReparto = @IdReparto,"
							If cls.WhatIsChanged.Job Then sql &= "Job = @Job,"
							If cls.WhatIsChanged.MinGiroTaglio Then sql &= "MinGiroTaglio = @MinGiroTaglio,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.NumSpazi Then sql &= "NumSpazi = @NumSpazi,"
							If cls.WhatIsChanged.PathTemplateAutomazione Then sql &= "PathTemplateAutomazione = @PathTemplateAutomazione,"
							If cls.WhatIsChanged.PDF Then sql &= "PDF = @PDF,"
							If cls.WhatIsChanged.RitieniOkDuplicati Then sql &= "RitieniOkDuplicati = @RitieniOkDuplicati,"
							If cls.WhatIsChanged.TiraturaIdeale Then sql &= "TiraturaIdeale = @TiraturaIdeale"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdModello= " & cls.IdModello
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@AbilitatoAutomazione"
						p.Value = cls.AbilitatoAutomazione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Anteprima"
						p.Value = cls.Anteprima
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@AnteprimaR"
						p.Value = cls.AnteprimaR
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Descrizione"
						p.Value = cls.Descrizione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Disattivo"
						p.Value = cls.Disattivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FileJDP"
						p.Value = cls.FileJDP
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FromGanging"
						p.Value = cls.FromGanging
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FronteRetro"
						p.Value = cls.FronteRetro
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FRSuSeStessa"
						p.Value = cls.FRSuSeStessa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCatModello"
						p.Value = cls.IdCatModello
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdFormatoMacchina"
						p.Value = cls.IdFormatoMacchina
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdMacchinarioDef"
						p.Value = cls.IdMacchinarioDef
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdMacchinarioTaglioDef"
						p.Value = cls.IdMacchinarioTaglioDef
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdReparto"
						p.Value = cls.IdReparto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Job"
						p.Value = cls.Job
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@MinGiroTaglio"
						p.Value = cls.MinGiroTaglio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Nome"
						p.Value = cls.Nome
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumSpazi"
						p.Value = cls.NumSpazi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PathTemplateAutomazione"
						p.Value = cls.PathTemplateAutomazione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PDF"
						p.Value = cls.PDF
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@RitieniOkDuplicati"
						p.Value = cls.RitieniOkDuplicati
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TiraturaIdeale"
						p.Value = cls.TiraturaIdeale
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdModello=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdModello = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdModello
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdModello
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
				'Dim Sql As String = "UPDATE T_modellicommessa SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_modellicommessa"
				Sql &= " WHERE IdModello = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_modellicommessa. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_modellicommessa. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ModelloCommessa, Optional ByRef ListaObj as List (of ModelloCommessa) = Nothing)
		DestroyPermanently (obj.IdModello)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ModelloCommessa
		Dim ris As ModelloCommessa = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ModelloCommessa) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return first of ModelloCommessa
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ModelloCommessa
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return first of ModelloCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ModelloCommessa
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ModelloCommessa
	''' </summary>
	''' <returns>
	'''Return first of ModelloCommessa
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ModelloCommessa
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ModelloCommessa)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ModelloCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ModelloCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ModelloCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ModelloCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ModelloCommessa)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_modellicommessa by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ModelloCommessa by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ModelloCommessa)
		Dim Ls As New List(Of ModelloCommessa)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ModelloCommessa)
		Dim Ls As New List(Of ModelloCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_modellicommessa" 
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
	'''Return all record on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of ModelloCommessa
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ModelloCommessa)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of ModelloCommessa
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ModelloCommessa)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_modellicommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of ModelloCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ModelloCommessa)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ModelloCommessa)
		Dim Ls As List(Of ModelloCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_modellicommessa" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ModelloCommessa)
		Dim Ls As New List(Of ModelloCommessa)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ModelloCommessa() With {.IdModello = 0 ,.AbilitatoAutomazione = 0 ,.Anteprima = "" ,.AnteprimaR = "" ,.Descrizione = EmptyItemDescription,.Disattivo = 0 ,.FileJDP = "" ,.FromGanging = 0 ,.FronteRetro = 0 ,.FRSuSeStessa = 0 ,.IdCatModello = 0 ,.IdFormatoMacchina = 0 ,.IdMacchinarioDef = 0 ,.IdMacchinarioTaglioDef = 0 ,.IdReparto = 0 ,.Job = "" ,.MinGiroTaglio = 0 ,.Nome = "" ,.NumSpazi = 0 ,.PathTemplateAutomazione = "" ,.PDF = "" ,.RitieniOkDuplicati = 0 ,.TiraturaIdeale = 0  })
					While myReader.Read
						Dim classe as new ModelloCommessa(CType(myReader, IDataRecord))
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