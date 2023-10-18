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
'''This class manage persistency on db of TipoCommessa object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _TipoCommesseDAO
	Inherits LUNA.LunaBaseClassDAO(Of TipoCommessa)

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
	'''Read from DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a TipoCommessa object
	''' </returns>
	Public Overrides Function Read(Id as integer) as TipoCommessa
		Dim cls as new TipoCommessa

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_tipocommessa WHERE IdTipoCom = " & Id
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
	'''Save on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as TipoCommessa) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdTipoCom = 0 Then
							sql = "INSERT INTO Td_tipocommessa ("
							sql &= " Descrizione,"
							sql &= " FronteRetro,"
							sql &= " IdCatModelli,"
							sql &= " IdFormato,"
							sql &= " IdImpianto,"
							sql &= " IdRis,"
							sql &= " MacchinaStampa,"
							sql &= " NumSpazi,"
							sql &= " PremioStampa,"
							sql &= " Quantita,"
							sql &= " TempoRif,"
							sql &= " TipoCom"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @FronteRetro,"
							sql &= " @IdCatModelli,"
							sql &= " @IdFormato,"
							sql &= " @IdImpianto,"
							sql &= " @IdRis,"
							sql &= " @MacchinaStampa,"
							sql &= " @NumSpazi,"
							sql &= " @PremioStampa,"
							sql &= " @Quantita,"
							sql &= " @TempoRif,"
							sql &= " @TipoCom"
							sql &= ")"
						Else
							sql = "UPDATE Td_tipocommessa SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.FronteRetro Then sql &= "FronteRetro = @FronteRetro,"
							If cls.WhatIsChanged.IdCatModelli Then sql &= "IdCatModelli = @IdCatModelli,"
							If cls.WhatIsChanged.IdFormato Then sql &= "IdFormato = @IdFormato,"
							If cls.WhatIsChanged.IdImpianto Then sql &= "IdImpianto = @IdImpianto,"
							If cls.WhatIsChanged.IdRis Then sql &= "IdRis = @IdRis,"
							If cls.WhatIsChanged.MacchinaStampa Then sql &= "MacchinaStampa = @MacchinaStampa,"
							If cls.WhatIsChanged.NumSpazi Then sql &= "NumSpazi = @NumSpazi,"
							If cls.WhatIsChanged.PremioStampa Then sql &= "PremioStampa = @PremioStampa,"
							If cls.WhatIsChanged.Quantita Then sql &= "Quantita = @Quantita,"
							If cls.WhatIsChanged.TempoRif Then sql &= "TempoRif = @TempoRif,"
							If cls.WhatIsChanged.TipoCom Then sql &= "TipoCom = @TipoCom"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdTipoCom= " & cls.IdTipoCom
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Descrizione"
						p.Value = cls.Descrizione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FronteRetro"
						p.Value = cls.FronteRetro
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCatModelli"
						p.Value = cls.IdCatModelli
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdFormato"
						p.Value = cls.IdFormato
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdImpianto"
						p.Value = cls.IdImpianto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdRis"
						p.Value = cls.IdRis
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@MacchinaStampa"
						p.Value = cls.MacchinaStampa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumSpazi"
						p.Value = cls.NumSpazi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PremioStampa"
						p.Value = cls.PremioStampa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Quantita"
						p.Value = cls.Quantita
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TempoRif"
						p.Value = cls.TempoRif
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoCom"
						p.Value = cls.TipoCom
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdTipoCom=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdTipoCom = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdTipoCom
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdTipoCom
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
				'Dim Sql As String = "UPDATE Td_tipocommessa SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_tipocommessa"
				Sql &= " WHERE IdTipoCom = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipocommessa. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipocommessa. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as TipoCommessa, Optional ByRef ListaObj as List (of TipoCommessa) = Nothing)
		DestroyPermanently (obj.IdTipoCom)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCommessa
		Dim ris As TipoCommessa = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of TipoCommessa) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return first of TipoCommessa
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCommessa
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return first of TipoCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCommessa
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table TipoCommessa
	''' </summary>
	''' <returns>
	'''Return first of TipoCommessa
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCommessa
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCommessa)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCommessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCommessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of TipoCommessa)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocommessa by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of TipoCommessa by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCommessa)
		Dim Ls As New List(Of TipoCommessa)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of TipoCommessa)
		Dim Ls As New List(Of TipoCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_tipocommessa" 
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
	'''Return all record on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCommessa
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of TipoCommessa)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCommessa
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCommessa)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipocommessa
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCommessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCommessa)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoCommessa)
		Dim Ls As List(Of TipoCommessa)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_tipocommessa" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoCommessa)
		Dim Ls As New List(Of TipoCommessa)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  TipoCommessa() With {.IdTipoCom = 0 ,.Descrizione = EmptyItemDescription,.FronteRetro = False ,.IdCatModelli = 0 ,.IdFormato = 0 ,.IdImpianto = 0 ,.IdRis = 0 ,.MacchinaStampa = "" ,.NumSpazi = 0 ,.PremioStampa = 0 ,.Quantita = 0 ,.TempoRif = 0 ,.TipoCom = 0  })
					While myReader.Read
						Dim classe as new TipoCommessa(CType(myReader, IDataRecord))
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