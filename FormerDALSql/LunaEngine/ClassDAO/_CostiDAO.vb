#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 24/03/2021 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Costo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CostiDAO
	Inherits LUNA.LunaBaseClassDAO(Of Costo)

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
	'''Read from DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a Costo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Costo
		Dim cls as new Costo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_contabcosti WHERE IdCosto = " & Id
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
	'''Save on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Costo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCosto = 0 Then
							sql = "INSERT INTO T_contabcosti ("
							sql &= " AddebitiVari,"
							sql &= " CostoCorr,"
							sql &= " DataCosto,"
							sql &= " DataEffettivoPagamento,"
							sql &= " DataOraRicezione,"
							sql &= " DataPrevPagam,"
							sql &= " Descrizione,"
							sql &= " DocXML,"
							sql &= " IdAzienda,"
							sql &= " IdCaricoMagazzino,"
							sql &= " IdCat,"
							sql &= " IdDocRif,"
							sql &= " IdentificativoSdI,"
							sql &= " IdMessaggioFE,"
							sql &= " IdRub,"
							sql &= " IdStato,"
							sql &= " Importo,"
							sql &= " Iva,"
							sql &= " Numero,"
							sql &= " PercIva,"
							sql &= " Scansione,"
							sql &= " Scansione1,"
							sql &= " Scansione2,"
							sql &= " Scansione3,"
							sql &= " Scansione4,"
							sql &= " SpeseIncasso,"
							sql &= " StatoFE,"
							sql &= " StatoFEInterno,"
							sql &= " Tipo,"
							sql &= " Totale"
							sql &= ") VALUES ("
							sql &= " @AddebitiVari,"
							sql &= " @CostoCorr,"
							sql &= " @DataCosto,"
							sql &= " @DataEffettivoPagamento,"
							sql &= " @DataOraRicezione,"
							sql &= " @DataPrevPagam,"
							sql &= " @Descrizione,"
							sql &= " @DocXML,"
							sql &= " @IdAzienda,"
							sql &= " @IdCaricoMagazzino,"
							sql &= " @IdCat,"
							sql &= " @IdDocRif,"
							sql &= " @IdentificativoSdI,"
							sql &= " @IdMessaggioFE,"
							sql &= " @IdRub,"
							sql &= " @IdStato,"
							sql &= " @Importo,"
							sql &= " @Iva,"
							sql &= " @Numero,"
							sql &= " @PercIva,"
							sql &= " @Scansione,"
							sql &= " @Scansione1,"
							sql &= " @Scansione2,"
							sql &= " @Scansione3,"
							sql &= " @Scansione4,"
							sql &= " @SpeseIncasso,"
							sql &= " @StatoFE,"
							sql &= " @StatoFEInterno,"
							sql &= " @Tipo,"
							sql &= " @Totale"
							sql &= ")"
						Else
							sql = "UPDATE T_contabcosti SET "
							If cls.WhatIsChanged.AddebitiVari Then sql &= "AddebitiVari = @AddebitiVari,"
							If cls.WhatIsChanged.CostoCorr Then sql &= "CostoCorr = @CostoCorr,"
							If cls.WhatIsChanged.DataCosto Then sql &= "DataCosto = @DataCosto,"
							If cls.WhatIsChanged.DataEffettivoPagamento Then sql &= "DataEffettivoPagamento = @DataEffettivoPagamento,"
							If cls.WhatIsChanged.DataOraRicezione Then sql &= "DataOraRicezione = @DataOraRicezione,"
							If cls.WhatIsChanged.DataPrevPagam Then sql &= "DataPrevPagam = @DataPrevPagam,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DocXML Then sql &= "DocXML = @DocXML,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.IdCaricoMagazzino Then sql &= "IdCaricoMagazzino = @IdCaricoMagazzino,"
							If cls.WhatIsChanged.IdCat Then sql &= "IdCat = @IdCat,"
							If cls.WhatIsChanged.IdDocRif Then sql &= "IdDocRif = @IdDocRif,"
							If cls.WhatIsChanged.IdentificativoSdI Then sql &= "IdentificativoSdI = @IdentificativoSdI,"
							If cls.WhatIsChanged.IdMessaggioFE Then sql &= "IdMessaggioFE = @IdMessaggioFE,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdStato Then sql &= "IdStato = @IdStato,"
							If cls.WhatIsChanged.Importo Then sql &= "Importo = @Importo,"
							If cls.WhatIsChanged.Iva Then sql &= "Iva = @Iva,"
							If cls.WhatIsChanged.Numero Then sql &= "Numero = @Numero,"
							If cls.WhatIsChanged.PercIva Then sql &= "PercIva = @PercIva,"
							If cls.WhatIsChanged.Scansione Then sql &= "Scansione = @Scansione,"
							If cls.WhatIsChanged.Scansione1 Then sql &= "Scansione1 = @Scansione1,"
							If cls.WhatIsChanged.Scansione2 Then sql &= "Scansione2 = @Scansione2,"
							If cls.WhatIsChanged.Scansione3 Then sql &= "Scansione3 = @Scansione3,"
							If cls.WhatIsChanged.Scansione4 Then sql &= "Scansione4 = @Scansione4,"
							If cls.WhatIsChanged.SpeseIncasso Then sql &= "SpeseIncasso = @SpeseIncasso,"
							If cls.WhatIsChanged.StatoFE Then sql &= "StatoFE = @StatoFE,"
							If cls.WhatIsChanged.StatoFEInterno Then sql &= "StatoFEInterno = @StatoFEInterno,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.Totale Then sql &= "Totale = @Totale"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCosto= " & cls.IdCosto
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AddebitiVari Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AddebitiVari"
							p.Value = cls.AddebitiVari
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoCorr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoCorr"
							p.Value = cls.CostoCorr
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataCosto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataCosto"
							p.DbType = DbType.DateTime
							If cls.DataCosto <> Date.MinValue Then
								p.Value = cls.DataCosto
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataEffettivoPagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataEffettivoPagamento"
							p.DbType = DbType.DateTime
							If cls.DataEffettivoPagamento <> Date.MinValue Then
								p.Value = cls.DataEffettivoPagamento
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataOraRicezione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataOraRicezione"
							p.DbType = DbType.DateTime
							If cls.DataOraRicezione <> Date.MinValue Then
								p.Value = cls.DataOraRicezione
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataPrevPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataPrevPagam"
							p.DbType = DbType.DateTime
							If cls.DataPrevPagam <> Date.MinValue Then
								p.Value = cls.DataPrevPagam
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

						If cls.WhatIsChanged.DocXML Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DocXML"
							p.Value = cls.DocXML
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAzienda"
							p.Value = cls.IdAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCaricoMagazzino Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCaricoMagazzino"
							p.Value = cls.IdCaricoMagazzino
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCat Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCat"
							p.Value = cls.IdCat
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdDocRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdDocRif"
							p.Value = cls.IdDocRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdentificativoSdI Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdentificativoSdI"
							p.Value = cls.IdentificativoSdI
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMessaggioFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMessaggioFE"
							p.Value = cls.IdMessaggioFE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdStato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdStato"
							p.Value = cls.IdStato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Importo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Importo"
							p.Value = cls.Importo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Iva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Iva"
							p.Value = cls.Iva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Numero Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Numero"
							p.Value = cls.Numero
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercIva"
							p.Value = cls.PercIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Scansione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Scansione"
							p.Value = cls.Scansione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Scansione1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Scansione1"
							p.Value = cls.Scansione1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Scansione2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Scansione2"
							p.Value = cls.Scansione2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Scansione3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Scansione3"
							p.Value = cls.Scansione3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Scansione4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Scansione4"
							p.Value = cls.Scansione4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SpeseIncasso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SpeseIncasso"
							p.Value = cls.SpeseIncasso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StatoFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoFE"
							p.Value = cls.StatoFE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StatoFEInterno Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoFEInterno"
							p.Value = cls.StatoFEInterno
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipo"
							p.Value = cls.Tipo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Totale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Totale"
							p.Value = cls.Totale
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCosto=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCosto = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCosto
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCosto
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
				'Dim Sql As String = "UPDATE T_contabcosti SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_contabcosti"
				Sql &= " WHERE IdCosto = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_contabcosti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_contabcosti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Costo, Optional ByRef ListaObj as List (of Costo) = Nothing)
		DestroyPermanently (obj.IdCosto)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Costo
		Dim ris As Costo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Costo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return first of Costo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Costo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return first of Costo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Costo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Costo
	''' </summary>
	''' <returns>
	'''Return first of Costo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Costo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Costo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Costo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Costo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Costo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Costo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return a list of Costo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Costo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabcosti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Costo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Costo)
		Dim Ls As New List(Of Costo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Costo)
		Dim Ls As New List(Of Costo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_contabcosti" 
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
	'''Return all record on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return all record in list of Costo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Costo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return all record in list of Costo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Costo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_contabcosti
	''' </summary>
	''' <returns>
	'''Return all record in list of Costo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Costo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Costo)
		Dim Ls As List(Of Costo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_contabcosti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Costo)
		Dim Ls As New List(Of Costo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Costo() With {.IdCosto = 0 ,.AddebitiVari = 0 ,.CostoCorr = 0 ,.DataCosto = Nothing ,.DataEffettivoPagamento = Nothing ,.DataOraRicezione = Nothing ,.DataPrevPagam = Nothing ,.Descrizione = EmptyItemDescription,.DocXML = "" ,.IdAzienda = 0 ,.IdCaricoMagazzino = 0 ,.IdCat = 0 ,.IdDocRif = 0 ,.IdentificativoSdI = "" ,.IdMessaggioFE = "" ,.IdRub = 0 ,.IdStato = 0 ,.Importo = 0 ,.Iva = 0 ,.Numero = "" ,.PercIva = 0 ,.Scansione = "" ,.Scansione1 = "" ,.Scansione2 = "" ,.Scansione3 = "" ,.Scansione4 = "" ,.SpeseIncasso = 0 ,.StatoFE = 0 ,.StatoFEInterno = 0 ,.Tipo = 0 ,.Totale = 0  })
					While myReader.Read
						Dim classe as new Costo(CType(myReader, IDataRecord))
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