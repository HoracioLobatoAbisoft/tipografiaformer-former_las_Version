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
'''This class manage persistency on db of VoceRubrica object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _VociRubricaDAO
	Inherits LUNA.LunaBaseClassDAO(Of VoceRubrica)

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
	'''Read from DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a VoceRubrica object
	''' </returns>
	Public Overrides Function Read(Id as integer) as VoceRubrica
		Dim cls as new VoceRubrica

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_rubrica WHERE IdRub = " & Id
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
	'''Save on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as VoceRubrica) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdRub = 0 Then
							sql = "INSERT INTO T_rubrica ("
							sql &= " AbilitaInserimentoManualeDoc,"
							sql &= " AltroTel,"
							sql &= " AltroTelRif,"
							sql &= " AssRilIntMitt,"
							sql &= " BigliettoVisita,"
							sql &= " CAP,"
							sql &= " Cellulare,"
							sql &= " CellulareRif,"
							sql &= " Citta,"
							sql &= " CodFisc,"
							sql &= " CodiceSDI,"
							sql &= " Cognome,"
							sql &= " DataIns,"
							sql &= " DisattivaAccessoSito,"
							sql &= " Email,"
							sql &= " EmailAdmin,"
							sql &= " EsigibilitaIva,"
							sql &= " Fax,"
							sql &= " FaxRif,"
							sql &= " IdAge,"
							sql &= " IdAziendaDefaultFatture,"
							sql &= " IdCatContab,"
							sql &= " IdCategoria,"
							sql &= " IdComune,"
							sql &= " IdCorriere,"
							sql &= " IdNazione,"
							sql &= " IdOld,"
							sql &= " IdPagamento,"
							sql &= " IdProvincia,"
							sql &= " IdRubricaLinked,"
							sql &= " IdTipoAttivita,"
							sql &= " IdUtOnline,"
							sql &= " IdZona,"
							sql &= " IndCons,"
							sql &= " Indirizzo,"
							sql &= " InserimentoManualeFatture,"
							sql &= " IsFornitore,"
							sql &= " LastUpdate,"
							sql &= " NoCheckDatiFisc,"
							sql &= " NoEmail,"
							sql &= " Nome,"
							sql &= " NonCreareAutomaticamenteDocumentiDiCarico,"
							sql &= " Pagamento,"
							sql &= " Pec,"
							sql &= " Piva,"
							sql &= " PrefissoPIva,"
							sql &= " Provincia,"
							sql &= " RagSoc,"
							sql &= " RegistraAutomaticamentePagamenti,"
							sql &= " ScopertoMax,"
							sql &= " SitoWeb,"
							sql &= " Sorgente,"
							sql &= " SorgenteStorico,"
							sql &= " StampaAutomaticaDocumenti,"
							sql &= " Status,"
							sql &= " tag,"
							sql &= " Tel,"
							sql &= " TelRif,"
							sql &= " Tipo,"
							sql &= " TipoDoc"
							sql &= ") VALUES ("
							sql &= " @AbilitaInserimentoManualeDoc,"
							sql &= " @AltroTel,"
							sql &= " @AltroTelRif,"
							sql &= " @AssRilIntMitt,"
							sql &= " @BigliettoVisita,"
							sql &= " @CAP,"
							sql &= " @Cellulare,"
							sql &= " @CellulareRif,"
							sql &= " @Citta,"
							sql &= " @CodFisc,"
							sql &= " @CodiceSDI,"
							sql &= " @Cognome,"
							sql &= " @DataIns,"
							sql &= " @DisattivaAccessoSito,"
							sql &= " @Email,"
							sql &= " @EmailAdmin,"
							sql &= " @EsigibilitaIva,"
							sql &= " @Fax,"
							sql &= " @FaxRif,"
							sql &= " @IdAge,"
							sql &= " @IdAziendaDefaultFatture,"
							sql &= " @IdCatContab,"
							sql &= " @IdCategoria,"
							sql &= " @IdComune,"
							sql &= " @IdCorriere,"
							sql &= " @IdNazione,"
							sql &= " @IdOld,"
							sql &= " @IdPagamento,"
							sql &= " @IdProvincia,"
							sql &= " @IdRubricaLinked,"
							sql &= " @IdTipoAttivita,"
							sql &= " @IdUtOnline,"
							sql &= " @IdZona,"
							sql &= " @IndCons,"
							sql &= " @Indirizzo,"
							sql &= " @InserimentoManualeFatture,"
							sql &= " @IsFornitore,"
							sql &= " @LastUpdate,"
							sql &= " @NoCheckDatiFisc,"
							sql &= " @NoEmail,"
							sql &= " @Nome,"
							sql &= " @NonCreareAutomaticamenteDocumentiDiCarico,"
							sql &= " @Pagamento,"
							sql &= " @Pec,"
							sql &= " @Piva,"
							sql &= " @PrefissoPIva,"
							sql &= " @Provincia,"
							sql &= " @RagSoc,"
							sql &= " @RegistraAutomaticamentePagamenti,"
							sql &= " @ScopertoMax,"
							sql &= " @SitoWeb,"
							sql &= " @Sorgente,"
							sql &= " @SorgenteStorico,"
							sql &= " @StampaAutomaticaDocumenti,"
							sql &= " @Status,"
							sql &= " @tag,"
							sql &= " @Tel,"
							sql &= " @TelRif,"
							sql &= " @Tipo,"
							sql &= " @TipoDoc"
							sql &= ")"
						Else
							sql = "UPDATE T_rubrica SET "
							If cls.WhatIsChanged.AbilitaInserimentoManualeDoc Then sql &= "AbilitaInserimentoManualeDoc = @AbilitaInserimentoManualeDoc,"
							If cls.WhatIsChanged.AltroTel Then sql &= "AltroTel = @AltroTel,"
							If cls.WhatIsChanged.AltroTelRif Then sql &= "AltroTelRif = @AltroTelRif,"
							If cls.WhatIsChanged.AssRilIntMitt Then sql &= "AssRilIntMitt = @AssRilIntMitt,"
							If cls.WhatIsChanged.BigliettoVisita Then sql &= "BigliettoVisita = @BigliettoVisita,"
							If cls.WhatIsChanged.CAP Then sql &= "CAP = @CAP,"
							If cls.WhatIsChanged.Cellulare Then sql &= "Cellulare = @Cellulare,"
							If cls.WhatIsChanged.CellulareRif Then sql &= "CellulareRif = @CellulareRif,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.CodFisc Then sql &= "CodFisc = @CodFisc,"
							If cls.WhatIsChanged.CodiceSDI Then sql &= "CodiceSDI = @CodiceSDI,"
							If cls.WhatIsChanged.Cognome Then sql &= "Cognome = @Cognome,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.DisattivaAccessoSito Then sql &= "DisattivaAccessoSito = @DisattivaAccessoSito,"
							If cls.WhatIsChanged.Email Then sql &= "Email = @Email,"
							If cls.WhatIsChanged.EmailAdmin Then sql &= "EmailAdmin = @EmailAdmin,"
							If cls.WhatIsChanged.EsigibilitaIva Then sql &= "EsigibilitaIva = @EsigibilitaIva,"
							If cls.WhatIsChanged.Fax Then sql &= "Fax = @Fax,"
							If cls.WhatIsChanged.FaxRif Then sql &= "FaxRif = @FaxRif,"
							If cls.WhatIsChanged.IdAge Then sql &= "IdAge = @IdAge,"
							If cls.WhatIsChanged.IdAziendaDefaultFatture Then sql &= "IdAziendaDefaultFatture = @IdAziendaDefaultFatture,"
							If cls.WhatIsChanged.IdCatContab Then sql &= "IdCatContab = @IdCatContab,"
							If cls.WhatIsChanged.IdCategoria Then sql &= "IdCategoria = @IdCategoria,"
							If cls.WhatIsChanged.IdComune Then sql &= "IdComune = @IdComune,"
							If cls.WhatIsChanged.IdCorriere Then sql &= "IdCorriere = @IdCorriere,"
							If cls.WhatIsChanged.IdNazione Then sql &= "IdNazione = @IdNazione,"
							If cls.WhatIsChanged.IdOld Then sql &= "IdOld = @IdOld,"
							If cls.WhatIsChanged.IdPagamento Then sql &= "IdPagamento = @IdPagamento,"
							If cls.WhatIsChanged.IdProvincia Then sql &= "IdProvincia = @IdProvincia,"
							If cls.WhatIsChanged.IdRubricaLinked Then sql &= "IdRubricaLinked = @IdRubricaLinked,"
							If cls.WhatIsChanged.IdTipoAttivita Then sql &= "IdTipoAttivita = @IdTipoAttivita,"
							If cls.WhatIsChanged.IdUtOnline Then sql &= "IdUtOnline = @IdUtOnline,"
							If cls.WhatIsChanged.IdZona Then sql &= "IdZona = @IdZona,"
							If cls.WhatIsChanged.IndCons Then sql &= "IndCons = @IndCons,"
							If cls.WhatIsChanged.Indirizzo Then sql &= "Indirizzo = @Indirizzo,"
							If cls.WhatIsChanged.InserimentoManualeFatture Then sql &= "InserimentoManualeFatture = @InserimentoManualeFatture,"
							If cls.WhatIsChanged.IsFornitore Then sql &= "IsFornitore = @IsFornitore,"
							If cls.WhatIsChanged.LastUpdate Then sql &= "LastUpdate = @LastUpdate,"
							If cls.WhatIsChanged.NoCheckDatiFisc Then sql &= "NoCheckDatiFisc = @NoCheckDatiFisc,"
							If cls.WhatIsChanged.NoEmail Then sql &= "NoEmail = @NoEmail,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.NonCreareAutomaticamenteDocumentiDiCarico Then sql &= "NonCreareAutomaticamenteDocumentiDiCarico = @NonCreareAutomaticamenteDocumentiDiCarico,"
							If cls.WhatIsChanged.Pagamento Then sql &= "Pagamento = @Pagamento,"
							If cls.WhatIsChanged.Pec Then sql &= "Pec = @Pec,"
							If cls.WhatIsChanged.Piva Then sql &= "Piva = @Piva,"
							If cls.WhatIsChanged.PrefissoPIva Then sql &= "PrefissoPIva = @PrefissoPIva,"
							If cls.WhatIsChanged.Provincia Then sql &= "Provincia = @Provincia,"
							If cls.WhatIsChanged.RagSoc Then sql &= "RagSoc = @RagSoc,"
							If cls.WhatIsChanged.RegistraAutomaticamentePagamenti Then sql &= "RegistraAutomaticamentePagamenti = @RegistraAutomaticamentePagamenti,"
							If cls.WhatIsChanged.ScopertoMax Then sql &= "ScopertoMax = @ScopertoMax,"
							If cls.WhatIsChanged.SitoWeb Then sql &= "SitoWeb = @SitoWeb,"
							If cls.WhatIsChanged.Sorgente Then sql &= "Sorgente = @Sorgente,"
							If cls.WhatIsChanged.SorgenteStorico Then sql &= "SorgenteStorico = @SorgenteStorico,"
							If cls.WhatIsChanged.StampaAutomaticaDocumenti Then sql &= "StampaAutomaticaDocumenti = @StampaAutomaticaDocumenti,"
							If cls.WhatIsChanged.Status Then sql &= "Status = @Status,"
							If cls.WhatIsChanged.tag Then sql &= "tag = @tag,"
							If cls.WhatIsChanged.Tel Then sql &= "Tel = @Tel,"
							If cls.WhatIsChanged.TelRif Then sql &= "TelRif = @TelRif,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.TipoDoc Then sql &= "TipoDoc = @TipoDoc"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdRub= " & cls.IdRub
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AbilitaInserimentoManualeDoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AbilitaInserimentoManualeDoc"
							p.Value = cls.AbilitaInserimentoManualeDoc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AltroTel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AltroTel"
							p.Value = cls.AltroTel
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AltroTelRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AltroTelRif"
							p.Value = cls.AltroTelRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AssRilIntMitt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AssRilIntMitt"
							p.Value = cls.AssRilIntMitt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.BigliettoVisita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@BigliettoVisita"
							p.Value = cls.BigliettoVisita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CAP Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CAP"
							p.Value = cls.CAP
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Cellulare Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Cellulare"
							p.Value = cls.Cellulare
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CellulareRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CellulareRif"
							p.Value = cls.CellulareRif
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

						If cls.WhatIsChanged.Email Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Email"
							p.Value = cls.Email
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.EmailAdmin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@EmailAdmin"
							p.Value = cls.EmailAdmin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.EsigibilitaIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@EsigibilitaIva"
							p.Value = cls.EsigibilitaIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Fax Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Fax"
							p.Value = cls.Fax
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FaxRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FaxRif"
							p.Value = cls.FaxRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAge Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAge"
							p.Value = cls.IdAge
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAziendaDefaultFatture Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAziendaDefaultFatture"
							p.Value = cls.IdAziendaDefaultFatture
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCatContab Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCatContab"
							p.Value = cls.IdCatContab
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCategoria Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCategoria"
							p.Value = cls.IdCategoria
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdComune Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdComune"
							p.Value = cls.IdComune
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCorriere"
							p.Value = cls.IdCorriere
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdNazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdNazione"
							p.Value = cls.IdNazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOld Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOld"
							p.Value = cls.IdOld
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

						If cls.WhatIsChanged.IdRubricaLinked Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRubricaLinked"
							p.Value = cls.IdRubricaLinked
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoAttivita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoAttivita"
							p.Value = cls.IdTipoAttivita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtOnline"
							p.Value = cls.IdUtOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdZona Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdZona"
							p.Value = cls.IdZona
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IndCons Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IndCons"
							p.Value = cls.IndCons
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Indirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Indirizzo"
							p.Value = cls.Indirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InserimentoManualeFatture Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InserimentoManualeFatture"
							p.Value = cls.InserimentoManualeFatture
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IsFornitore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IsFornitore"
							p.Value = cls.IsFornitore
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

						If cls.WhatIsChanged.NoEmail Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoEmail"
							p.Value = cls.NoEmail
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NonCreareAutomaticamenteDocumentiDiCarico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NonCreareAutomaticamenteDocumentiDiCarico"
							p.Value = cls.NonCreareAutomaticamenteDocumentiDiCarico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Pagamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Pagamento"
							p.Value = cls.Pagamento
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

						If cls.WhatIsChanged.RegistraAutomaticamentePagamenti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RegistraAutomaticamentePagamenti"
							p.Value = cls.RegistraAutomaticamentePagamenti
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ScopertoMax Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ScopertoMax"
							p.Value = cls.ScopertoMax
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SitoWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SitoWeb"
							p.Value = cls.SitoWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sorgente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sorgente"
							p.Value = cls.Sorgente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SorgenteStorico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SorgenteStorico"
							p.Value = cls.SorgenteStorico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StampaAutomaticaDocumenti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StampaAutomaticaDocumenti"
							p.Value = cls.StampaAutomaticaDocumenti
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Status Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Status"
							p.Value = cls.Status
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.tag Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@tag"
							p.Value = cls.tag
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tel"
							p.Value = cls.Tel
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TelRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TelRif"
							p.Value = cls.TelRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipo"
							p.Value = cls.Tipo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoDoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoDoc"
							p.Value = cls.TipoDoc
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdRub=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdRub = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdRub
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdRub
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
				'Dim Sql As String = "UPDATE T_rubrica SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_rubrica"
				Sql &= " WHERE IdRub = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_rubrica. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_rubrica. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as VoceRubrica, Optional ByRef ListaObj as List (of VoceRubrica) = Nothing)
		DestroyPermanently (obj.IdRub)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubrica
		Dim ris As VoceRubrica = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of VoceRubrica) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return first of VoceRubrica
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubrica
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return first of VoceRubrica
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubrica
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table VoceRubrica
	''' </summary>
	''' <returns>
	'''Return first of VoceRubrica
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceRubrica
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubrica)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubrica)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubrica)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubrica)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceRubrica)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of VoceRubrica)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_rubrica by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of VoceRubrica by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubrica)
		Dim Ls As New List(Of VoceRubrica)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of VoceRubrica)
		Dim Ls As New List(Of VoceRubrica)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_rubrica" 
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
	'''Return all record on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubrica
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of VoceRubrica)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubrica
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubrica)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_rubrica
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceRubrica
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceRubrica)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceRubrica)
		Dim Ls As List(Of VoceRubrica)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_rubrica" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceRubrica)
		Dim Ls As New List(Of VoceRubrica)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  VoceRubrica() With {.IdRub = 0 ,.AbilitaInserimentoManualeDoc = 0 ,.AltroTel = "" ,.AltroTelRif = "" ,.AssRilIntMitt = 0 ,.BigliettoVisita = "" ,.CAP = "" ,.Cellulare = "" ,.CellulareRif = "" ,.Citta = "" ,.CodFisc = "" ,.CodiceSDI = "" ,.Cognome = "" ,.DataIns = Nothing ,.DisattivaAccessoSito = 0 ,.Email = "" ,.EmailAdmin = "" ,.EsigibilitaIva = 0 ,.Fax = "" ,.FaxRif = "" ,.IdAge = 0 ,.IdAziendaDefaultFatture = 0 ,.IdCatContab = 0 ,.IdCategoria = 0 ,.IdComune = 0 ,.IdCorriere = 0 ,.IdNazione = 0 ,.IdOld = 0 ,.IdPagamento = 0 ,.IdProvincia = 0 ,.IdRubricaLinked = 0 ,.IdTipoAttivita = 0 ,.IdUtOnline = 0 ,.IdZona = 0 ,.IndCons = "" ,.Indirizzo = "" ,.InserimentoManualeFatture = 0 ,.IsFornitore = 0 ,.LastUpdate = Nothing ,.NoCheckDatiFisc = 0 ,.NoEmail = 0 ,.Nome = "" ,.NonCreareAutomaticamenteDocumentiDiCarico = 0 ,.Pagamento = "" ,.Pec = "" ,.Piva = "" ,.PrefissoPIva = "" ,.Provincia = "" ,.RagSoc = "" ,.RegistraAutomaticamentePagamenti = 0 ,.ScopertoMax = 0 ,.SitoWeb = "" ,.Sorgente = "" ,.SorgenteStorico = "" ,.StampaAutomaticaDocumenti = 0 ,.Status = 0 ,.tag = "" ,.Tel = "" ,.TelRif = "" ,.Tipo = 0 ,.TipoDoc = 0  })
					While myReader.Read
						Dim classe as new VoceRubrica(CType(myReader, IDataRecord))
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