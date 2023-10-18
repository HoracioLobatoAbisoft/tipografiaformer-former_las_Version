#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 27/06/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Commessa object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CommesseDAO
	Inherits LUNA.LunaBaseClassDAO(Of Commessa)

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
	'''Read from DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a Commessa object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Commessa
		Dim cls as new Commessa

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_commesse WHERE IdCom = " & Id
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
	'''Save on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Commessa) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCom = 0 Then
							sql = "INSERT INTO T_commesse ("
							sql &= " Annotazioni,"
							sql &= " Copie,"
							sql &= " CostoCarta,"
							sql &= " CostoFoglioSteso,"
							sql &= " CostoImpianti,"
							sql &= " CostoTotale,"
							sql &= " CreataAutomaticamente,"
							sql &= " DataCambioStato,"
							sql &= " DataIns,"
							sql &= " FilePath,"
							sql &= " FromJob,"
							sql &= " FronteRetro,"
							sql &= " IdFormato,"
							sql &= " IdLavorazione,"
							sql &= " IdMacchinario,"
							sql &= " IdModelloCommessa,"
							sql &= " IdReparto,"
							sql &= " IdRis,"
							sql &= " IdTipoCom,"
							sql &= " IdUtCreatore,"
							sql &= " Largo,"
							sql &= " Lungo,"
							sql &= " MacchinaStampa,"
							sql &= " NLastreNecessarie,"
							sql &= " Numero,"
							sql &= " Priorita,"
							sql &= " Riassunto,"
							sql &= " SchemaTaglio,"
							sql &= " Segnature,"
							sql &= " SoggettiFoglio,"
							sql &= " Stato,"
							sql &= " TipoCom"
							sql &= ") VALUES ("
							sql &= " @Annotazioni,"
							sql &= " @Copie,"
							sql &= " @CostoCarta,"
							sql &= " @CostoFoglioSteso,"
							sql &= " @CostoImpianti,"
							sql &= " @CostoTotale,"
							sql &= " @CreataAutomaticamente,"
							sql &= " @DataCambioStato,"
							sql &= " @DataIns,"
							sql &= " @FilePath,"
							sql &= " @FromJob,"
							sql &= " @FronteRetro,"
							sql &= " @IdFormato,"
							sql &= " @IdLavorazione,"
							sql &= " @IdMacchinario,"
							sql &= " @IdModelloCommessa,"
							sql &= " @IdReparto,"
							sql &= " @IdRis,"
							sql &= " @IdTipoCom,"
							sql &= " @IdUtCreatore,"
							sql &= " @Largo,"
							sql &= " @Lungo,"
							sql &= " @MacchinaStampa,"
							sql &= " @NLastreNecessarie,"
							sql &= " @Numero,"
							sql &= " @Priorita,"
							sql &= " @Riassunto,"
							sql &= " @SchemaTaglio,"
							sql &= " @Segnature,"
							sql &= " @SoggettiFoglio,"
							sql &= " @Stato,"
							sql &= " @TipoCom"
							sql &= ")"
						Else
							sql = "UPDATE T_commesse SET "
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.Copie Then sql &= "Copie = @Copie,"
							If cls.WhatIsChanged.CostoCarta Then sql &= "CostoCarta = @CostoCarta,"
							If cls.WhatIsChanged.CostoFoglioSteso Then sql &= "CostoFoglioSteso = @CostoFoglioSteso,"
							If cls.WhatIsChanged.CostoImpianti Then sql &= "CostoImpianti = @CostoImpianti,"
							If cls.WhatIsChanged.CostoTotale Then sql &= "CostoTotale = @CostoTotale,"
							If cls.WhatIsChanged.CreataAutomaticamente Then sql &= "CreataAutomaticamente = @CreataAutomaticamente,"
							If cls.WhatIsChanged.DataCambioStato Then sql &= "DataCambioStato = @DataCambioStato,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.FilePath Then sql &= "FilePath = @FilePath,"
							If cls.WhatIsChanged.FromJob Then sql &= "FromJob = @FromJob,"
							If cls.WhatIsChanged.FronteRetro Then sql &= "FronteRetro = @FronteRetro,"
							If cls.WhatIsChanged.IdFormato Then sql &= "IdFormato = @IdFormato,"
							If cls.WhatIsChanged.IdLavorazione Then sql &= "IdLavorazione = @IdLavorazione,"
							If cls.WhatIsChanged.IdMacchinario Then sql &= "IdMacchinario = @IdMacchinario,"
							If cls.WhatIsChanged.IdModelloCommessa Then sql &= "IdModelloCommessa = @IdModelloCommessa,"
							If cls.WhatIsChanged.IdReparto Then sql &= "IdReparto = @IdReparto,"
							If cls.WhatIsChanged.IdRis Then sql &= "IdRis = @IdRis,"
							If cls.WhatIsChanged.IdTipoCom Then sql &= "IdTipoCom = @IdTipoCom,"
							If cls.WhatIsChanged.IdUtCreatore Then sql &= "IdUtCreatore = @IdUtCreatore,"
							If cls.WhatIsChanged.Largo Then sql &= "Largo = @Largo,"
							If cls.WhatIsChanged.Lungo Then sql &= "Lungo = @Lungo,"
							If cls.WhatIsChanged.MacchinaStampa Then sql &= "MacchinaStampa = @MacchinaStampa,"
							If cls.WhatIsChanged.NLastreNecessarie Then sql &= "NLastreNecessarie = @NLastreNecessarie,"
							If cls.WhatIsChanged.Numero Then sql &= "Numero = @Numero,"
							If cls.WhatIsChanged.Priorita Then sql &= "Priorita = @Priorita,"
							If cls.WhatIsChanged.Riassunto Then sql &= "Riassunto = @Riassunto,"
							If cls.WhatIsChanged.SchemaTaglio Then sql &= "SchemaTaglio = @SchemaTaglio,"
							If cls.WhatIsChanged.Segnature Then sql &= "Segnature = @Segnature,"
							If cls.WhatIsChanged.SoggettiFoglio Then sql &= "SoggettiFoglio = @SoggettiFoglio,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.TipoCom Then sql &= "TipoCom = @TipoCom"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCom= " & cls.IdCom
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Annotazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Annotazioni"
							p.Value = cls.Annotazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Copie Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Copie"
							p.Value = cls.Copie
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoCarta"
							p.Value = cls.CostoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoFoglioSteso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoFoglioSteso"
							p.Value = cls.CostoFoglioSteso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoImpianti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoImpianti"
							p.Value = cls.CostoImpianti
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoTotale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoTotale"
							p.Value = cls.CostoTotale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CreataAutomaticamente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CreataAutomaticamente"
							p.Value = cls.CreataAutomaticamente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataCambioStato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataCambioStato"
							p.DbType = DbType.DateTime
							If cls.DataCambioStato <> Date.MinValue Then
								p.Value = cls.DataCambioStato
							Else
								p.Value = DBNull.Value
							End If  
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

						If cls.WhatIsChanged.FilePath Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FilePath"
							p.Value = cls.FilePath
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FromJob Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FromJob"
							p.Value = cls.FromJob
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FronteRetro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FronteRetro"
							p.Value = cls.FronteRetro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFormato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormato"
							p.Value = cls.IdFormato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdLavorazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdLavorazione"
							p.Value = cls.IdLavorazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinario"
							p.Value = cls.IdMacchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdModelloCommessa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdModelloCommessa"
							p.Value = cls.IdModelloCommessa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdReparto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdReparto"
							p.Value = cls.IdReparto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRis Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRis"
							p.Value = cls.IdRis
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoCom"
							p.Value = cls.IdTipoCom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtCreatore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtCreatore"
							p.Value = cls.IdUtCreatore
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Largo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Largo"
							p.Value = cls.Largo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Lungo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Lungo"
							p.Value = cls.Lungo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MacchinaStampa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MacchinaStampa"
							p.Value = cls.MacchinaStampa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NLastreNecessarie Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NLastreNecessarie"
							p.Value = cls.NLastreNecessarie
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Numero Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Numero"
							p.Value = cls.Numero
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Priorita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Priorita"
							p.Value = cls.Priorita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Riassunto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Riassunto"
							p.Value = cls.Riassunto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SchemaTaglio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SchemaTaglio"
							p.Value = cls.SchemaTaglio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Segnature Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Segnature"
							p.Value = cls.Segnature
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SoggettiFoglio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SoggettiFoglio"
							p.Value = cls.SoggettiFoglio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCom"
							p.Value = cls.TipoCom
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCom=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCom = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCom
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCom
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
				'Dim Sql As String = "UPDATE T_commesse SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_commesse"
				Sql &= " WHERE IdCom = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_commesse. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_commesse. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Commessa, Optional ByRef ListaObj as List (of Commessa) = Nothing)
		DestroyPermanently (obj.IdCom)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Commessa
		Dim ris As Commessa = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Commessa) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return first of Commessa
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Commessa
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return first of Commessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Commessa
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Commessa
	''' </summary>
	''' <returns>
	'''Return first of Commessa
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Commessa
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Commessa)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Commessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Commessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Commessa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Commessa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return a list of Commessa
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Commessa)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_commesse by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Commessa by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Commessa)
		Dim Ls As New List(Of Commessa)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Commessa)
		Dim Ls As New List(Of Commessa)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_commesse" 
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
	'''Return all record on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return all record in list of Commessa
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Commessa)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return all record in list of Commessa
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Commessa)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_commesse
	''' </summary>
	''' <returns>
	'''Return all record in list of Commessa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Commessa)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Commessa)
		Dim Ls As List(Of Commessa)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_commesse" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Commessa)
		Dim Ls As New List(Of Commessa)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Commessa() With {.IdCom = 0 ,.Annotazioni = "" ,.Copie = 0 ,.CostoCarta = 0 ,.CostoFoglioSteso = 0 ,.CostoImpianti = 0 ,.CostoTotale = 0 ,.CreataAutomaticamente = 0 ,.DataCambioStato = Nothing ,.DataIns = Nothing ,.FilePath = "" ,.FromJob = 0 ,.FronteRetro = 0 ,.IdFormato = 0 ,.IdLavorazione = 0 ,.IdMacchinario = 0 ,.IdModelloCommessa = 0 ,.IdReparto = 0 ,.IdRis = 0 ,.IdTipoCom = 0 ,.IdUtCreatore = 0 ,.Largo = 0 ,.Lungo = 0 ,.MacchinaStampa = "" ,.NLastreNecessarie = 0 ,.Numero = "" ,.Priorita = 0 ,.Riassunto = "" ,.SchemaTaglio = "" ,.Segnature = 0 ,.SoggettiFoglio = 0 ,.Stato = 0 ,.TipoCom = 0  })
					While myReader.Read
						Dim classe as new Commessa(CType(myReader, IDataRecord))
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