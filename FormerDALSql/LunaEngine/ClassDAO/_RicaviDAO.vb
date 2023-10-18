#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 17/12/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Ricavo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _RicaviDAO
	Inherits LUNA.LunaBaseClassDAO(Of Ricavo)

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
	'''Read from DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a Ricavo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Ricavo
		Dim cls as new Ricavo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_contabricavi WHERE IdRicavo = " & Id
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
	'''Save on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Ricavo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdRicavo = 0 Then
							sql = "INSERT INTO T_contabricavi ("
							sql &= " CostoCorr,"
							sql &= " CounterStampe,"
							sql &= " DataOraInvio,"
							sql &= " Dataprevpagam,"
							sql &= " DataRicavo,"
							sql &= " DataUltimoCambioStatoFE,"
							sql &= " Descrizione,"
							sql &= " DocXML,"
							sql &= " EsigibilitaIva,"
							sql &= " IdAzienda,"
							sql &= " IdCat,"
							sql &= " IdCorr,"
							sql &= " IdDocRif,"
							sql &= " IdentificativoSdI,"
							sql &= " IdFatturaNotaDiCredito,"
							sql &= " IdMessaggioFE,"
							sql &= " Idpagamento,"
							sql &= " IdRub,"
							sql &= " IdRubIntestatario,"
							sql &= " idstato,"
							sql &= " Importo,"
							sql &= " InfoFE,"
							sql &= " Iva,"
							sql &= " NaturaEsclIva,"
							sql &= " NumColli,"
							sql &= " Numero,"
							sql &= " pCap,"
							sql &= " pCitta,"
							sql &= " PercIva,"
							sql &= " Peso,"
							sql &= " pIndCons,"
							sql &= " pIndirizzo,"
							sql &= " pIva,"
							sql &= " pPagamento,"
							sql &= " pRagSoc,"
							sql &= " RicevutaXML,"
							sql &= " Scansione,"
							sql &= " Scansione1,"
							sql &= " Scansione2,"
							sql &= " Scansione3,"
							sql &= " Scansione4,"
							sql &= " StatoFE,"
							sql &= " StatoIncasso,"
							sql &= " Tipo,"
							sql &= " Totale"
							sql &= ") VALUES ("
							sql &= " @CostoCorr,"
							sql &= " @CounterStampe,"
							sql &= " @DataOraInvio,"
							sql &= " @Dataprevpagam,"
							sql &= " @DataRicavo,"
							sql &= " @DataUltimoCambioStatoFE,"
							sql &= " @Descrizione,"
							sql &= " @DocXML,"
							sql &= " @EsigibilitaIva,"
							sql &= " @IdAzienda,"
							sql &= " @IdCat,"
							sql &= " @IdCorr,"
							sql &= " @IdDocRif,"
							sql &= " @IdentificativoSdI,"
							sql &= " @IdFatturaNotaDiCredito,"
							sql &= " @IdMessaggioFE,"
							sql &= " @Idpagamento,"
							sql &= " @IdRub,"
							sql &= " @IdRubIntestatario,"
							sql &= " @idstato,"
							sql &= " @Importo,"
							sql &= " @InfoFE,"
							sql &= " @Iva,"
							sql &= " @NaturaEsclIva,"
							sql &= " @NumColli,"
							sql &= " @Numero,"
							sql &= " @pCap,"
							sql &= " @pCitta,"
							sql &= " @PercIva,"
							sql &= " @Peso,"
							sql &= " @pIndCons,"
							sql &= " @pIndirizzo,"
							sql &= " @pIva,"
							sql &= " @pPagamento,"
							sql &= " @pRagSoc,"
							sql &= " @RicevutaXML,"
							sql &= " @Scansione,"
							sql &= " @Scansione1,"
							sql &= " @Scansione2,"
							sql &= " @Scansione3,"
							sql &= " @Scansione4,"
							sql &= " @StatoFE,"
							sql &= " @StatoIncasso,"
							sql &= " @Tipo,"
							sql &= " @Totale"
							sql &= ")"
						Else
							sql = "UPDATE T_contabricavi SET "
							If cls.WhatIsChanged.CostoCorr Then sql &= "CostoCorr = @CostoCorr,"
							If cls.WhatIsChanged.CounterStampe Then sql &= "CounterStampe = @CounterStampe,"
							If cls.WhatIsChanged.DataOraInvio Then sql &= "DataOraInvio = @DataOraInvio,"
							If cls.WhatIsChanged.Dataprevpagam Then sql &= "Dataprevpagam = @Dataprevpagam,"
							If cls.WhatIsChanged.DataRicavo Then sql &= "DataRicavo = @DataRicavo,"
							If cls.WhatIsChanged.DataUltimoCambioStatoFE Then sql &= "DataUltimoCambioStatoFE = @DataUltimoCambioStatoFE,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DocXML Then sql &= "DocXML = @DocXML,"
							If cls.WhatIsChanged.EsigibilitaIva Then sql &= "EsigibilitaIva = @EsigibilitaIva,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.IdCat Then sql &= "IdCat = @IdCat,"
							If cls.WhatIsChanged.IdCorr Then sql &= "IdCorr = @IdCorr,"
							If cls.WhatIsChanged.IdDocRif Then sql &= "IdDocRif = @IdDocRif,"
							If cls.WhatIsChanged.IdentificativoSdI Then sql &= "IdentificativoSdI = @IdentificativoSdI,"
							If cls.WhatIsChanged.IdFatturaNotaDiCredito Then sql &= "IdFatturaNotaDiCredito = @IdFatturaNotaDiCredito,"
							If cls.WhatIsChanged.IdMessaggioFE Then sql &= "IdMessaggioFE = @IdMessaggioFE,"
							If cls.WhatIsChanged.Idpagamento Then sql &= "Idpagamento = @Idpagamento,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdRubIntestatario Then sql &= "IdRubIntestatario = @IdRubIntestatario,"
							If cls.WhatIsChanged.idstato Then sql &= "idstato = @idstato,"
							If cls.WhatIsChanged.Importo Then sql &= "Importo = @Importo,"
							If cls.WhatIsChanged.InfoFE Then sql &= "InfoFE = @InfoFE,"
							If cls.WhatIsChanged.Iva Then sql &= "Iva = @Iva,"
							If cls.WhatIsChanged.NaturaEsclIva Then sql &= "NaturaEsclIva = @NaturaEsclIva,"
							If cls.WhatIsChanged.NumColli Then sql &= "NumColli = @NumColli,"
							If cls.WhatIsChanged.Numero Then sql &= "Numero = @Numero,"
							If cls.WhatIsChanged.pCap Then sql &= "pCap = @pCap,"
							If cls.WhatIsChanged.pCitta Then sql &= "pCitta = @pCitta,"
							If cls.WhatIsChanged.PercIva Then sql &= "PercIva = @PercIva,"
							If cls.WhatIsChanged.Peso Then sql &= "Peso = @Peso,"
							If cls.WhatIsChanged.pIndCons Then sql &= "pIndCons = @pIndCons,"
							If cls.WhatIsChanged.pIndirizzo Then sql &= "pIndirizzo = @pIndirizzo,"
							If cls.WhatIsChanged.pIva Then sql &= "pIva = @pIva,"
							If cls.WhatIsChanged.pPagamento Then sql &= "pPagamento = @pPagamento,"
							If cls.WhatIsChanged.pRagSoc Then sql &= "pRagSoc = @pRagSoc,"
							If cls.WhatIsChanged.RicevutaXML Then sql &= "RicevutaXML = @RicevutaXML,"
							If cls.WhatIsChanged.Scansione Then sql &= "Scansione = @Scansione,"
							If cls.WhatIsChanged.Scansione1 Then sql &= "Scansione1 = @Scansione1,"
							If cls.WhatIsChanged.Scansione2 Then sql &= "Scansione2 = @Scansione2,"
							If cls.WhatIsChanged.Scansione3 Then sql &= "Scansione3 = @Scansione3,"
							If cls.WhatIsChanged.Scansione4 Then sql &= "Scansione4 = @Scansione4,"
							If cls.WhatIsChanged.StatoFE Then sql &= "StatoFE = @StatoFE,"
							If cls.WhatIsChanged.StatoIncasso Then sql &= "StatoIncasso = @StatoIncasso,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.Totale Then sql &= "Totale = @Totale"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdRicavo= " & cls.IdRicavo
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.CostoCorr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoCorr"
							p.Value = cls.CostoCorr
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CounterStampe Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CounterStampe"
							p.Value = cls.CounterStampe
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataOraInvio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataOraInvio"
							p.DbType = DbType.DateTime
							If cls.DataOraInvio <> Date.MinValue Then
								p.Value = cls.DataOraInvio
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Dataprevpagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Dataprevpagam"
							p.DbType = DbType.DateTime
							If cls.Dataprevpagam <> Date.MinValue Then
								p.Value = cls.Dataprevpagam
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataRicavo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataRicavo"
							p.DbType = DbType.DateTime
							If cls.DataRicavo <> Date.MinValue Then
								p.Value = cls.DataRicavo
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataUltimoCambioStatoFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataUltimoCambioStatoFE"
							p.DbType = DbType.DateTime
							If cls.DataUltimoCambioStatoFE <> Date.MinValue Then
								p.Value = cls.DataUltimoCambioStatoFE
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

						If cls.WhatIsChanged.EsigibilitaIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@EsigibilitaIva"
							p.Value = cls.EsigibilitaIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAzienda"
							p.Value = cls.IdAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCat Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCat"
							p.Value = cls.IdCat
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorr"
							p.Value = cls.IdCorr
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

						If cls.WhatIsChanged.IdFatturaNotaDiCredito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFatturaNotaDiCredito"
							p.Value = cls.IdFatturaNotaDiCredito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMessaggioFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMessaggioFE"
							p.Value = cls.IdMessaggioFE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Idpagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Idpagamento"
							p.Value = cls.Idpagamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRubIntestatario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRubIntestatario"
							p.Value = cls.IdRubIntestatario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.idstato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@idstato"
							p.Value = cls.idstato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Importo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Importo"
							p.Value = cls.Importo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InfoFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InfoFE"
							p.Value = cls.InfoFE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Iva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Iva"
							p.Value = cls.Iva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NaturaEsclIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NaturaEsclIva"
							p.Value = cls.NaturaEsclIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumColli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumColli"
							p.Value = cls.NumColli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Numero Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Numero"
							p.Value = cls.Numero
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pCap Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pCap"
							p.Value = cls.pCap
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pCitta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pCitta"
							p.Value = cls.pCitta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercIva"
							p.Value = cls.PercIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Peso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Peso"
							p.Value = cls.Peso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pIndCons Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pIndCons"
							p.Value = cls.pIndCons
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pIndirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pIndirizzo"
							p.Value = cls.pIndirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pIva"
							p.Value = cls.pIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pPagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pPagamento"
							p.Value = cls.pPagamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.pRagSoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@pRagSoc"
							p.Value = cls.pRagSoc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RicevutaXML Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RicevutaXML"
							p.Value = cls.RicevutaXML
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

						If cls.WhatIsChanged.StatoFE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoFE"
							p.Value = cls.StatoFE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StatoIncasso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoIncasso"
							p.Value = cls.StatoIncasso
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

		            
						If cls.IdRicavo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdRicavo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdRicavo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdRicavo
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
				'Dim Sql As String = "UPDATE T_contabricavi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_contabricavi"
				Sql &= " WHERE IdRicavo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_contabricavi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_contabricavi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Ricavo, Optional ByRef ListaObj as List (of Ricavo) = Nothing)
		DestroyPermanently (obj.IdRicavo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ricavo
		Dim ris As Ricavo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Ricavo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return first of Ricavo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ricavo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return first of Ricavo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ricavo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Ricavo
	''' </summary>
	''' <returns>
	'''Return first of Ricavo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ricavo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ricavo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ricavo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ricavo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ricavo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ricavo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Ricavo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_contabricavi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Ricavo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Ricavo)
		Dim Ls As New List(Of Ricavo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Ricavo)
		Dim Ls As New List(Of Ricavo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_contabricavi" 
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
	'''Return all record on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return all record in list of Ricavo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Ricavo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return all record in list of Ricavo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Ricavo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_contabricavi
	''' </summary>
	''' <returns>
	'''Return all record in list of Ricavo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Ricavo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Ricavo)
		Dim Ls As List(Of Ricavo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_contabricavi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Ricavo)
		Dim Ls As New List(Of Ricavo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Ricavo() With {.IdRicavo = 0 ,.CostoCorr = 0 ,.CounterStampe = 0 ,.DataOraInvio = Nothing ,.Dataprevpagam = Nothing ,.DataRicavo = Nothing ,.DataUltimoCambioStatoFE = Nothing ,.Descrizione = EmptyItemDescription,.DocXML = "" ,.EsigibilitaIva = 0 ,.IdAzienda = 0 ,.IdCat = 0 ,.IdCorr = 0 ,.IdDocRif = 0 ,.IdentificativoSdI = "" ,.IdFatturaNotaDiCredito = 0 ,.IdMessaggioFE = "" ,.Idpagamento = 0 ,.IdRub = 0 ,.IdRubIntestatario = 0 ,.idstato = 0 ,.Importo = 0 ,.InfoFE = "" ,.Iva = 0 ,.NaturaEsclIva = "" ,.NumColli = 0 ,.Numero = 0 ,.pCap = "" ,.pCitta = "" ,.PercIva = 0 ,.Peso = 0 ,.pIndCons = "" ,.pIndirizzo = "" ,.pIva = "" ,.pPagamento = "" ,.pRagSoc = "" ,.RicevutaXML = "" ,.Scansione = "" ,.Scansione1 = "" ,.Scansione2 = "" ,.Scansione3 = "" ,.Scansione4 = "" ,.StatoFE = 0 ,.StatoIncasso = 0 ,.Tipo = 0 ,.Totale = 0  })
					While myReader.Read
						Dim classe as new Ricavo(CType(myReader, IDataRecord))
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