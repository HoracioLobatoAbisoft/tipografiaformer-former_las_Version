#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.2.11 
'Author: Diego Lunadei
'Date: 04/05/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Ordine object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _OrdiniDAO
	Inherits LUNA.LunaBaseClassDAO(Of Ordine)

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
	'''Read from DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a Ordine object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Ordine
		Dim cls as new Ordine

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_ordini WHERE IdOrd = " & Id
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
	'''Save on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Ordine) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdOrd = 0 Then
							sql = "INSERT INTO T_ordini ("
							sql &= " Annotazioni,"
							sql &= " ConsegnaGarantita,"
							sql &= " ConsegnaGarantitaDa,"
							sql &= " CostoSped,"
							sql &= " DataCambioStato,"
							sql &= " DataEffConsegna,"
							sql &= " DataIns,"
							sql &= " DataPrevConsegna,"
							sql &= " DataPrevProduzione,"
							sql &= " ExtraData,"
							sql &= " FilePath,"
							sql &= " FileSorgente,"
							sql &= " ForzaIdFormatoProdotto,"
							sql &= " ForzaIdMacchinarioProduzione,"
							sql &= " ForzaIdTipoCarta,"
							sql &= " ForzaQta,"
							sql &= " IdCom,"
							sql &= " IdConsProgrammata,"
							sql &= " IdConsRiferimento,"
							sql &= " IdCorriere,"
							sql &= " IdCoupon,"
							sql &= " IdDoc,"
							sql &= " IdIndirizzo,"
							sql &= " IdMacchinarioProduzioneUtilizzato,"
							sql &= " IdMailPreventivo,"
							sql &= " IdOrdineProvvisorio,"
							sql &= " IdOrdOnline,"
							sql &= " IdProd,"
							sql &= " IdPromo,"
							sql &= " IdRub,"
							sql &= " IdTipoFustella,"
							sql &= " IdTipoProd,"
							sql &= " Iva,"
							sql &= " Largo,"
							sql &= " LastUpdate,"
							sql &= " Lungo,"
							sql &= " MantieniCampione,"
							sql &= " Mq,"
							sql &= " NFogli,"
							sql &= " NomeFileOriginale,"
							sql &= " NomeLavoro,"
							sql &= " NumeroRealeColli,"
							sql &= " OraConsegna,"
							sql &= " OrdineInOmaggio,"
							sql &= " OrdMail,"
							sql &= " Orientamento,"
							sql &= " PeriodoPrevConsegna,"
							sql &= " PreRefineErrorCode,"
							sql &= " Preventivo,"
							sql &= " Prezzo,"
							sql &= " PrezzoProd,"
							sql &= " Priorita,"
							sql &= " Profondita,"
							sql &= " Qta,"
							sql &= " Ricarico,"
							sql &= " RilascioCli,"
							sql &= " Sconto,"
							sql &= " Stato,"
							sql &= " TipoConsegna,"
							sql &= " TipoRetro,"
							sql &= " TotaleForn,"
							sql &= " UsaNomeLavoroInFattura"
							sql &= ") VALUES ("
							sql &= " @Annotazioni,"
							sql &= " @ConsegnaGarantita,"
							sql &= " @ConsegnaGarantitaDa,"
							sql &= " @CostoSped,"
							sql &= " @DataCambioStato,"
							sql &= " @DataEffConsegna,"
							sql &= " @DataIns,"
							sql &= " @DataPrevConsegna,"
							sql &= " @DataPrevProduzione,"
							sql &= " @ExtraData,"
							sql &= " @FilePath,"
							sql &= " @FileSorgente,"
							sql &= " @ForzaIdFormatoProdotto,"
							sql &= " @ForzaIdMacchinarioProduzione,"
							sql &= " @ForzaIdTipoCarta,"
							sql &= " @ForzaQta,"
							sql &= " @IdCom,"
							sql &= " @IdConsProgrammata,"
							sql &= " @IdConsRiferimento,"
							sql &= " @IdCorriere,"
							sql &= " @IdCoupon,"
							sql &= " @IdDoc,"
							sql &= " @IdIndirizzo,"
							sql &= " @IdMacchinarioProduzioneUtilizzato,"
							sql &= " @IdMailPreventivo,"
							sql &= " @IdOrdineProvvisorio,"
							sql &= " @IdOrdOnline,"
							sql &= " @IdProd,"
							sql &= " @IdPromo,"
							sql &= " @IdRub,"
							sql &= " @IdTipoFustella,"
							sql &= " @IdTipoProd,"
							sql &= " @Iva,"
							sql &= " @Largo,"
							sql &= " @LastUpdate,"
							sql &= " @Lungo,"
							sql &= " @MantieniCampione,"
							sql &= " @Mq,"
							sql &= " @NFogli,"
							sql &= " @NomeFileOriginale,"
							sql &= " @NomeLavoro,"
							sql &= " @NumeroRealeColli,"
							sql &= " @OraConsegna,"
							sql &= " @OrdineInOmaggio,"
							sql &= " @OrdMail,"
							sql &= " @Orientamento,"
							sql &= " @PeriodoPrevConsegna,"
							sql &= " @PreRefineErrorCode,"
							sql &= " @Preventivo,"
							sql &= " @Prezzo,"
							sql &= " @PrezzoProd,"
							sql &= " @Priorita,"
							sql &= " @Profondita,"
							sql &= " @Qta,"
							sql &= " @Ricarico,"
							sql &= " @RilascioCli,"
							sql &= " @Sconto,"
							sql &= " @Stato,"
							sql &= " @TipoConsegna,"
							sql &= " @TipoRetro,"
							sql &= " @TotaleForn,"
							sql &= " @UsaNomeLavoroInFattura"
							sql &= ")"
						Else
							sql = "UPDATE T_ordini SET "
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.ConsegnaGarantita Then sql &= "ConsegnaGarantita = @ConsegnaGarantita,"
							If cls.WhatIsChanged.ConsegnaGarantitaDa Then sql &= "ConsegnaGarantitaDa = @ConsegnaGarantitaDa,"
							If cls.WhatIsChanged.CostoSped Then sql &= "CostoSped = @CostoSped,"
							If cls.WhatIsChanged.DataCambioStato Then sql &= "DataCambioStato = @DataCambioStato,"
							If cls.WhatIsChanged.DataEffConsegna Then sql &= "DataEffConsegna = @DataEffConsegna,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.DataPrevConsegna Then sql &= "DataPrevConsegna = @DataPrevConsegna,"
							If cls.WhatIsChanged.DataPrevProduzione Then sql &= "DataPrevProduzione = @DataPrevProduzione,"
							If cls.WhatIsChanged.ExtraData Then sql &= "ExtraData = @ExtraData,"
							If cls.WhatIsChanged.FilePath Then sql &= "FilePath = @FilePath,"
							If cls.WhatIsChanged.FileSorgente Then sql &= "FileSorgente = @FileSorgente,"
							If cls.WhatIsChanged.ForzaIdFormatoProdotto Then sql &= "ForzaIdFormatoProdotto = @ForzaIdFormatoProdotto,"
							If cls.WhatIsChanged.ForzaIdMacchinarioProduzione Then sql &= "ForzaIdMacchinarioProduzione = @ForzaIdMacchinarioProduzione,"
							If cls.WhatIsChanged.ForzaIdTipoCarta Then sql &= "ForzaIdTipoCarta = @ForzaIdTipoCarta,"
							If cls.WhatIsChanged.ForzaQta Then sql &= "ForzaQta = @ForzaQta,"
							If cls.WhatIsChanged.IdCom Then sql &= "IdCom = @IdCom,"
							If cls.WhatIsChanged.IdConsProgrammata Then sql &= "IdConsProgrammata = @IdConsProgrammata,"
							If cls.WhatIsChanged.IdConsRiferimento Then sql &= "IdConsRiferimento = @IdConsRiferimento,"
							If cls.WhatIsChanged.IdCorriere Then sql &= "IdCorriere = @IdCorriere,"
							If cls.WhatIsChanged.IdCoupon Then sql &= "IdCoupon = @IdCoupon,"
							If cls.WhatIsChanged.IdDoc Then sql &= "IdDoc = @IdDoc,"
							If cls.WhatIsChanged.IdIndirizzo Then sql &= "IdIndirizzo = @IdIndirizzo,"
							If cls.WhatIsChanged.IdMacchinarioProduzioneUtilizzato Then sql &= "IdMacchinarioProduzioneUtilizzato = @IdMacchinarioProduzioneUtilizzato,"
							If cls.WhatIsChanged.IdMailPreventivo Then sql &= "IdMailPreventivo = @IdMailPreventivo,"
							If cls.WhatIsChanged.IdOrdineProvvisorio Then sql &= "IdOrdineProvvisorio = @IdOrdineProvvisorio,"
							If cls.WhatIsChanged.IdOrdOnline Then sql &= "IdOrdOnline = @IdOrdOnline,"
							If cls.WhatIsChanged.IdProd Then sql &= "IdProd = @IdProd,"
							If cls.WhatIsChanged.IdPromo Then sql &= "IdPromo = @IdPromo,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdTipoFustella Then sql &= "IdTipoFustella = @IdTipoFustella,"
							If cls.WhatIsChanged.IdTipoProd Then sql &= "IdTipoProd = @IdTipoProd,"
							If cls.WhatIsChanged.Iva Then sql &= "Iva = @Iva,"
							If cls.WhatIsChanged.Largo Then sql &= "Largo = @Largo,"
							If cls.WhatIsChanged.LastUpdate Then sql &= "LastUpdate = @LastUpdate,"
							If cls.WhatIsChanged.Lungo Then sql &= "Lungo = @Lungo,"
							If cls.WhatIsChanged.MantieniCampione Then sql &= "MantieniCampione = @MantieniCampione,"
							If cls.WhatIsChanged.Mq Then sql &= "Mq = @Mq,"
							If cls.WhatIsChanged.NFogli Then sql &= "NFogli = @NFogli,"
							If cls.WhatIsChanged.NomeFileOriginale Then sql &= "NomeFileOriginale = @NomeFileOriginale,"
							If cls.WhatIsChanged.NomeLavoro Then sql &= "NomeLavoro = @NomeLavoro,"
							If cls.WhatIsChanged.NumeroRealeColli Then sql &= "NumeroRealeColli = @NumeroRealeColli,"
							If cls.WhatIsChanged.OraConsegna Then sql &= "OraConsegna = @OraConsegna,"
							If cls.WhatIsChanged.OrdineInOmaggio Then sql &= "OrdineInOmaggio = @OrdineInOmaggio,"
							If cls.WhatIsChanged.OrdMail Then sql &= "OrdMail = @OrdMail,"
							If cls.WhatIsChanged.Orientamento Then sql &= "Orientamento = @Orientamento,"
							If cls.WhatIsChanged.PeriodoPrevConsegna Then sql &= "PeriodoPrevConsegna = @PeriodoPrevConsegna,"
							If cls.WhatIsChanged.PreRefineErrorCode Then sql &= "PreRefineErrorCode = @PreRefineErrorCode,"
							If cls.WhatIsChanged.Preventivo Then sql &= "Preventivo = @Preventivo,"
							If cls.WhatIsChanged.Prezzo Then sql &= "Prezzo = @Prezzo,"
							If cls.WhatIsChanged.PrezzoProd Then sql &= "PrezzoProd = @PrezzoProd,"
							If cls.WhatIsChanged.Priorita Then sql &= "Priorita = @Priorita,"
							If cls.WhatIsChanged.Profondita Then sql &= "Profondita = @Profondita,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta,"
							If cls.WhatIsChanged.Ricarico Then sql &= "Ricarico = @Ricarico,"
							If cls.WhatIsChanged.RilascioCli Then sql &= "RilascioCli = @RilascioCli,"
							If cls.WhatIsChanged.Sconto Then sql &= "Sconto = @Sconto,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.TipoConsegna Then sql &= "TipoConsegna = @TipoConsegna,"
							If cls.WhatIsChanged.TipoRetro Then sql &= "TipoRetro = @TipoRetro,"
							If cls.WhatIsChanged.TotaleForn Then sql &= "TotaleForn = @TotaleForn,"
							If cls.WhatIsChanged.UsaNomeLavoroInFattura Then sql &= "UsaNomeLavoroInFattura = @UsaNomeLavoroInFattura"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdOrd= " & cls.IdOrd
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Annotazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Annotazioni"
							p.Value = cls.Annotazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ConsegnaGarantita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ConsegnaGarantita"
							p.DbType = DbType.DateTime
							If cls.ConsegnaGarantita <> Date.MinValue Then
								p.Value = cls.ConsegnaGarantita
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ConsegnaGarantitaDa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ConsegnaGarantitaDa"
							p.Value = cls.ConsegnaGarantitaDa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoSped Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoSped"
							p.Value = cls.CostoSped
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

						If cls.WhatIsChanged.DataEffConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataEffConsegna"
							p.DbType = DbType.DateTime
							If cls.DataEffConsegna <> Date.MinValue Then
								p.Value = cls.DataEffConsegna
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

						If cls.WhatIsChanged.DataPrevConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataPrevConsegna"
							p.DbType = DbType.DateTime
							If cls.DataPrevConsegna <> Date.MinValue Then
								p.Value = cls.DataPrevConsegna
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataPrevProduzione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataPrevProduzione"
							p.DbType = DbType.DateTime
							If cls.DataPrevProduzione <> Date.MinValue Then
								p.Value = cls.DataPrevProduzione
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ExtraData Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ExtraData"
							p.Value = cls.ExtraData
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FilePath Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FilePath"
							p.Value = cls.FilePath
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FileSorgente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FileSorgente"
							p.Value = cls.FileSorgente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ForzaIdFormatoProdotto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ForzaIdFormatoProdotto"
							p.Value = cls.ForzaIdFormatoProdotto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ForzaIdMacchinarioProduzione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ForzaIdMacchinarioProduzione"
							p.Value = cls.ForzaIdMacchinarioProduzione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ForzaIdTipoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ForzaIdTipoCarta"
							p.Value = cls.ForzaIdTipoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ForzaQta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ForzaQta"
							p.Value = cls.ForzaQta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCom"
							p.Value = cls.IdCom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdConsProgrammata Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdConsProgrammata"
							p.Value = cls.IdConsProgrammata
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdConsRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdConsRiferimento"
							p.Value = cls.IdConsRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorriere"
							p.Value = cls.IdCorriere
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCoupon Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCoupon"
							p.Value = cls.IdCoupon
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdDoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdDoc"
							p.Value = cls.IdDoc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdIndirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdIndirizzo"
							p.Value = cls.IdIndirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinarioProduzioneUtilizzato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinarioProduzioneUtilizzato"
							p.Value = cls.IdMacchinarioProduzioneUtilizzato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMailPreventivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMailPreventivo"
							p.Value = cls.IdMailPreventivo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrdineProvvisorio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrdineProvvisorio"
							p.Value = cls.IdOrdineProvvisorio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrdOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrdOnline"
							p.Value = cls.IdOrdOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdProd"
							p.Value = cls.IdProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPromo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPromo"
							p.Value = cls.IdPromo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoFustella Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoFustella"
							p.Value = cls.IdTipoFustella
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoProd"
							p.Value = cls.IdTipoProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Iva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Iva"
							p.Value = cls.Iva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Largo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Largo"
							p.Value = cls.Largo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastUpdate Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastUpdate"
							p.Value = cls.LastUpdate
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Lungo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Lungo"
							p.Value = cls.Lungo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MantieniCampione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MantieniCampione"
							p.Value = cls.MantieniCampione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Mq Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Mq"
							p.Value = cls.Mq
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NFogli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NFogli"
							p.Value = cls.NFogli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeFileOriginale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeFileOriginale"
							p.Value = cls.NomeFileOriginale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeLavoro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeLavoro"
							p.Value = cls.NomeLavoro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroRealeColli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroRealeColli"
							p.Value = cls.NumeroRealeColli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OraConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OraConsegna"
							p.Value = cls.OraConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdineInOmaggio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdineInOmaggio"
							p.Value = cls.OrdineInOmaggio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdMail Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdMail"
							p.Value = cls.OrdMail
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Orientamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Orientamento"
							p.Value = cls.Orientamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PeriodoPrevConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PeriodoPrevConsegna"
							p.Value = cls.PeriodoPrevConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PreRefineErrorCode Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PreRefineErrorCode"
							p.Value = cls.PreRefineErrorCode
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Preventivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Preventivo"
							p.Value = cls.Preventivo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo"
							p.Value = cls.Prezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoProd"
							p.Value = cls.PrezzoProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Priorita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Priorita"
							p.Value = cls.Priorita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Profondita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Profondita"
							p.Value = cls.Profondita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta"
							p.Value = cls.Qta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Ricarico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Ricarico"
							p.Value = cls.Ricarico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RilascioCli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RilascioCli"
							p.Value = cls.RilascioCli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sconto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sconto"
							p.Value = cls.Sconto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoConsegna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoConsegna"
							p.Value = cls.TipoConsegna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoRetro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoRetro"
							p.Value = cls.TipoRetro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TotaleForn Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TotaleForn"
							p.Value = cls.TotaleForn
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UsaNomeLavoroInFattura Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UsaNomeLavoroInFattura"
							p.Value = cls.UsaNomeLavoroInFattura
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdOrd=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdOrd = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdOrd
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdOrd
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
				'Dim Sql As String = "UPDATE T_ordini SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_ordini"
				Sql &= " WHERE IdOrd = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_ordini. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_ordini. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Ordine, Optional ByRef ListaObj as List (of Ordine) = Nothing)
		DestroyPermanently (obj.IdOrd)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ordine
		Dim ris As Ordine = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Ordine) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return first of Ordine
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ordine
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return first of Ordine
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ordine
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Ordine
	''' </summary>
	''' <returns>
	'''Return first of Ordine
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Ordine
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ordine)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ordine)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ordine)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ordine)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Ordine)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return a list of Ordine
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Ordine)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_ordini by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Ordine by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Ordine)
		Dim Ls As New List(Of Ordine)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Ordine)
		Dim Ls As New List(Of Ordine)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_ordini" 
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
	'''Return all record on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of Ordine
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Ordine)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of Ordine
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Ordine)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of Ordine
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Ordine)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Ordine)
		Dim Ls As List(Of Ordine)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_ordini" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Ordine)
		Dim Ls As New List(Of Ordine)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Ordine() With {.IdOrd = 0 ,.Annotazioni = "" ,.ConsegnaGarantita = Nothing ,.ConsegnaGarantitaDa = 0 ,.CostoSped = 0 ,.DataCambioStato = Nothing ,.DataEffConsegna = Nothing ,.DataIns = Nothing ,.DataPrevConsegna = Nothing ,.DataPrevProduzione = Nothing ,.ExtraData = "" ,.FilePath = "" ,.FileSorgente = "" ,.ForzaIdFormatoProdotto = 0 ,.ForzaIdMacchinarioProduzione = 0 ,.ForzaIdTipoCarta = 0 ,.ForzaQta = 0 ,.IdCom = 0 ,.IdConsProgrammata = 0 ,.IdConsRiferimento = 0 ,.IdCorriere = 0 ,.IdCoupon = 0 ,.IdDoc = 0 ,.IdIndirizzo = 0 ,.IdMacchinarioProduzioneUtilizzato = 0 ,.IdMailPreventivo = 0 ,.IdOrdineProvvisorio = 0 ,.IdOrdOnline = 0 ,.IdProd = 0 ,.IdPromo = 0 ,.IdRub = 0 ,.IdTipoFustella = 0 ,.IdTipoProd = 0 ,.Iva = 0 ,.Largo = 0 ,.LastUpdate = 0 ,.Lungo = 0 ,.MantieniCampione = 0 ,.Mq = 0 ,.NFogli = 0 ,.NomeFileOriginale = "" ,.NomeLavoro = "" ,.NumeroRealeColli = 0 ,.OraConsegna = "" ,.OrdineInOmaggio = 0 ,.OrdMail = False ,.Orientamento = 0 ,.PeriodoPrevConsegna = 0 ,.PreRefineErrorCode = 0 ,.Preventivo = 0 ,.Prezzo = 0 ,.PrezzoProd = 0 ,.Priorita = 0 ,.Profondita = 0 ,.Qta = 0 ,.Ricarico = 0 ,.RilascioCli = 0 ,.Sconto = 0 ,.Stato = 0 ,.TipoConsegna = 0 ,.TipoRetro = 0 ,.TotaleForn = 0 ,.UsaNomeLavoroInFattura = 0  })
					While myReader.Read
						Dim classe as new Ordine(CType(myReader, IDataRecord))
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