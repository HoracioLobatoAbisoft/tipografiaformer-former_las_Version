#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.1 
'Author: Diego Lunadei
'Date: 08/11/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of OrdineWeb object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _OrdiniWebDAO
	Inherits LUNA.LunaBaseClassDAO(Of OrdineWeb)

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
	'''Read from DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a OrdineWeb object
	''' </returns>
	Public Overrides Function Read(Id as integer) as OrdineWeb
		Dim cls as new OrdineWeb

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Ordini WHERE IdOrdine = " & Id
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
	'''Save on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as OrdineWeb) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdOrdine = 0 Then
							sql = "INSERT INTO Ordini ("
							sql &= " Altezza,"
							sql &= " Annotazioni,"
							sql &= " Anteprima,"
							sql &= " ConsegnaGarantita,"
							sql &= " ConsegnaGarantitaDa,"
							sql &= " DataCambioStato,"
							sql &= " DataIns,"
							sql &= " DataPrevConsegna,"
							sql &= " DataPrevProduzione,"
							sql &= " ExtraData,"
							sql &= " IdCons,"
							sql &= " IdCorriere,"
							sql &= " IdCoupon,"
							sql &= " IdIndirizzo,"
							sql &= " IdListinoBase,"
							sql &= " IdMacchinarioProduzioneUtilizzato,"
							sql &= " IdMailPreventivo,"
							sql &= " IdOrdineInt,"
							sql &= " IdPromo,"
							sql &= " IdTipoFustella,"
							sql &= " IdUt,"
							sql &= " InseritoDa,"
							sql &= " Larghezza,"
							sql &= " Lavorazioni,"
							sql &= " Mq,"
							sql &= " Nfogli,"
							sql &= " NoEmailDemone,"
							sql &= " NomeLavoro,"
							sql &= " NumeroColli,"
							sql &= " OrdineInOmaggio,"
							sql &= " OrdineWeb,"
							sql &= " Orientamento,"
							sql &= " Peso,"
							sql &= " Preventivo,"
							sql &= " PrezzoCalcolatoNetto,"
							sql &= " PrezzoCorriere,"
							sql &= " Profondita,"
							sql &= " Qta,"
							sql &= " Ricarico,"
							sql &= " Sconto,"
							sql &= " SorgenteCopertina,"
							sql &= " SorgenteFronte,"
							sql &= " SorgenteRetro,"
							sql &= " Stato,"
							sql &= " StatoWeb,"
							sql &= " TipoConsegna,"
							sql &= " TipoRetro,"
							sql &= " TotaleIva,"
							sql &= " TotaleNetto,"
							sql &= " TotaleOrdine,"
							sql &= " UsaNomeLavoroInFattura"
							sql &= ") VALUES ("
							sql &= " @Altezza,"
							sql &= " @Annotazioni,"
							sql &= " @Anteprima,"
							sql &= " @ConsegnaGarantita,"
							sql &= " @ConsegnaGarantitaDa,"
							sql &= " @DataCambioStato,"
							sql &= " @DataIns,"
							sql &= " @DataPrevConsegna,"
							sql &= " @DataPrevProduzione,"
							sql &= " @ExtraData,"
							sql &= " @IdCons,"
							sql &= " @IdCorriere,"
							sql &= " @IdCoupon,"
							sql &= " @IdIndirizzo,"
							sql &= " @IdListinoBase,"
							sql &= " @IdMacchinarioProduzioneUtilizzato,"
							sql &= " @IdMailPreventivo,"
							sql &= " @IdOrdineInt,"
							sql &= " @IdPromo,"
							sql &= " @IdTipoFustella,"
							sql &= " @IdUt,"
							sql &= " @InseritoDa,"
							sql &= " @Larghezza,"
							sql &= " @Lavorazioni,"
							sql &= " @Mq,"
							sql &= " @Nfogli,"
							sql &= " @NoEmailDemone,"
							sql &= " @NomeLavoro,"
							sql &= " @NumeroColli,"
							sql &= " @OrdineInOmaggio,"
							sql &= " @OrdineWeb,"
							sql &= " @Orientamento,"
							sql &= " @Peso,"
							sql &= " @Preventivo,"
							sql &= " @PrezzoCalcolatoNetto,"
							sql &= " @PrezzoCorriere,"
							sql &= " @Profondita,"
							sql &= " @Qta,"
							sql &= " @Ricarico,"
							sql &= " @Sconto,"
							sql &= " @SorgenteCopertina,"
							sql &= " @SorgenteFronte,"
							sql &= " @SorgenteRetro,"
							sql &= " @Stato,"
							sql &= " @StatoWeb,"
							sql &= " @TipoConsegna,"
							sql &= " @TipoRetro,"
							sql &= " @TotaleIva,"
							sql &= " @TotaleNetto,"
							sql &= " @TotaleOrdine,"
							sql &= " @UsaNomeLavoroInFattura"
							sql &= ")"
						Else
							sql = "UPDATE Ordini SET "
							If cls.WhatIsChanged.Altezza Then sql &= "Altezza = @Altezza,"
							If cls.WhatIsChanged.Annotazioni Then sql &= "Annotazioni = @Annotazioni,"
							If cls.WhatIsChanged.Anteprima Then sql &= "Anteprima = @Anteprima,"
							If cls.WhatIsChanged.ConsegnaGarantita Then sql &= "ConsegnaGarantita = @ConsegnaGarantita,"
							If cls.WhatIsChanged.ConsegnaGarantitaDa Then sql &= "ConsegnaGarantitaDa = @ConsegnaGarantitaDa,"
							If cls.WhatIsChanged.DataCambioStato Then sql &= "DataCambioStato = @DataCambioStato,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.DataPrevConsegna Then sql &= "DataPrevConsegna = @DataPrevConsegna,"
							If cls.WhatIsChanged.DataPrevProduzione Then sql &= "DataPrevProduzione = @DataPrevProduzione,"
							If cls.WhatIsChanged.ExtraData Then sql &= "ExtraData = @ExtraData,"
							If cls.WhatIsChanged.IdCons Then sql &= "IdCons = @IdCons,"
							If cls.WhatIsChanged.IdCorriere Then sql &= "IdCorriere = @IdCorriere,"
							If cls.WhatIsChanged.IdCoupon Then sql &= "IdCoupon = @IdCoupon,"
							If cls.WhatIsChanged.IdIndirizzo Then sql &= "IdIndirizzo = @IdIndirizzo,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdMacchinarioProduzioneUtilizzato Then sql &= "IdMacchinarioProduzioneUtilizzato = @IdMacchinarioProduzioneUtilizzato,"
							If cls.WhatIsChanged.IdMailPreventivo Then sql &= "IdMailPreventivo = @IdMailPreventivo,"
							If cls.WhatIsChanged.IdOrdineInt Then sql &= "IdOrdineInt = @IdOrdineInt,"
							If cls.WhatIsChanged.IdPromo Then sql &= "IdPromo = @IdPromo,"
							If cls.WhatIsChanged.IdTipoFustella Then sql &= "IdTipoFustella = @IdTipoFustella,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.InseritoDa Then sql &= "InseritoDa = @InseritoDa,"
							If cls.WhatIsChanged.Larghezza Then sql &= "Larghezza = @Larghezza,"
							If cls.WhatIsChanged.Lavorazioni Then sql &= "Lavorazioni = @Lavorazioni,"
							If cls.WhatIsChanged.Mq Then sql &= "Mq = @Mq,"
							If cls.WhatIsChanged.Nfogli Then sql &= "Nfogli = @Nfogli,"
							If cls.WhatIsChanged.NoEmailDemone Then sql &= "NoEmailDemone = @NoEmailDemone,"
							If cls.WhatIsChanged.NomeLavoro Then sql &= "NomeLavoro = @NomeLavoro,"
							If cls.WhatIsChanged.NumeroColli Then sql &= "NumeroColli = @NumeroColli,"
							If cls.WhatIsChanged.OrdineInOmaggio Then sql &= "OrdineInOmaggio = @OrdineInOmaggio,"
							If cls.WhatIsChanged.OrdineWeb Then sql &= "OrdineWeb = @OrdineWeb,"
							If cls.WhatIsChanged.Orientamento Then sql &= "Orientamento = @Orientamento,"
							If cls.WhatIsChanged.Peso Then sql &= "Peso = @Peso,"
							If cls.WhatIsChanged.Preventivo Then sql &= "Preventivo = @Preventivo,"
							If cls.WhatIsChanged.PrezzoCalcolatoNetto Then sql &= "PrezzoCalcolatoNetto = @PrezzoCalcolatoNetto,"
							If cls.WhatIsChanged.PrezzoCorriere Then sql &= "PrezzoCorriere = @PrezzoCorriere,"
							If cls.WhatIsChanged.Profondita Then sql &= "Profondita = @Profondita,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta,"
							If cls.WhatIsChanged.Ricarico Then sql &= "Ricarico = @Ricarico,"
							If cls.WhatIsChanged.Sconto Then sql &= "Sconto = @Sconto,"
							If cls.WhatIsChanged.SorgenteCopertina Then sql &= "SorgenteCopertina = @SorgenteCopertina,"
							If cls.WhatIsChanged.SorgenteFronte Then sql &= "SorgenteFronte = @SorgenteFronte,"
							If cls.WhatIsChanged.SorgenteRetro Then sql &= "SorgenteRetro = @SorgenteRetro,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.StatoWeb Then sql &= "StatoWeb = @StatoWeb,"
							If cls.WhatIsChanged.TipoConsegna Then sql &= "TipoConsegna = @TipoConsegna,"
							If cls.WhatIsChanged.TipoRetro Then sql &= "TipoRetro = @TipoRetro,"
							If cls.WhatIsChanged.TotaleIva Then sql &= "TotaleIva = @TotaleIva,"
							If cls.WhatIsChanged.TotaleNetto Then sql &= "TotaleNetto = @TotaleNetto,"
							If cls.WhatIsChanged.TotaleOrdine Then sql &= "TotaleOrdine = @TotaleOrdine,"
							If cls.WhatIsChanged.UsaNomeLavoroInFattura Then sql &= "UsaNomeLavoroInFattura = @UsaNomeLavoroInFattura"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdOrdine= " & cls.IdOrdine
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Altezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Altezza"
							p.Value = cls.Altezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Annotazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Annotazioni"
							p.Value = cls.Annotazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Anteprima Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Anteprima"
							p.Value = cls.Anteprima
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

						If cls.WhatIsChanged.IdCons Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCons"
							p.Value = cls.IdCons
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

						If cls.WhatIsChanged.IdIndirizzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdIndirizzo"
							p.Value = cls.IdIndirizzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdListinoBase Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdListinoBase"
							p.Value = cls.IdListinoBase
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

						If cls.WhatIsChanged.IdOrdineInt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrdineInt"
							p.Value = cls.IdOrdineInt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPromo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPromo"
							p.Value = cls.IdPromo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoFustella Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoFustella"
							p.Value = cls.IdTipoFustella
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InseritoDa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InseritoDa"
							p.Value = cls.InseritoDa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Larghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Larghezza"
							p.Value = cls.Larghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Lavorazioni Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Lavorazioni"
							p.Value = cls.Lavorazioni
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Mq Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Mq"
							p.Value = cls.Mq
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nfogli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nfogli"
							p.Value = cls.Nfogli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NoEmailDemone Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NoEmailDemone"
							p.Value = cls.NoEmailDemone
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeLavoro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeLavoro"
							p.Value = cls.NomeLavoro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumeroColli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumeroColli"
							p.Value = cls.NumeroColli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdineInOmaggio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdineInOmaggio"
							p.Value = cls.OrdineInOmaggio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdineWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdineWeb"
							p.Value = cls.OrdineWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Orientamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Orientamento"
							p.Value = cls.Orientamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Peso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Peso"
							p.Value = cls.Peso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Preventivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Preventivo"
							p.Value = cls.Preventivo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoCalcolatoNetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoCalcolatoNetto"
							p.Value = cls.PrezzoCalcolatoNetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoCorriere Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoCorriere"
							p.Value = cls.PrezzoCorriere
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

						If cls.WhatIsChanged.Sconto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sconto"
							p.Value = cls.Sconto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SorgenteCopertina Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SorgenteCopertina"
							p.Value = cls.SorgenteCopertina
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SorgenteFronte Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SorgenteFronte"
							p.Value = cls.SorgenteFronte
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SorgenteRetro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SorgenteRetro"
							p.Value = cls.SorgenteRetro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.StatoWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@StatoWeb"
							p.Value = cls.StatoWeb
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

						If cls.WhatIsChanged.TotaleIva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TotaleIva"
							p.Value = cls.TotaleIva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TotaleNetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TotaleNetto"
							p.Value = cls.TotaleNetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TotaleOrdine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TotaleOrdine"
							p.Value = cls.TotaleOrdine
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

		            
						If cls.IdOrdine=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdOrdine = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdOrdine
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdOrdine
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
				'Dim Sql As String = "UPDATE Ordini SET DELETED=True "
				Dim Sql As String = "DELETE FROM Ordini"
				Sql &= " WHERE IdOrdine = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Ordini. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Ordini. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as OrdineWeb, Optional ByRef ListaObj as List (of OrdineWeb) = Nothing)
		DestroyPermanently (obj.IdOrdine)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OrdineWeb
		Dim ris As OrdineWeb = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of OrdineWeb) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return first of OrdineWeb
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OrdineWeb
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return first of OrdineWeb
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OrdineWeb
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table OrdineWeb
	''' </summary>
	''' <returns>
	'''Return first of OrdineWeb
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As OrdineWeb
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OrdineWeb)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OrdineWeb)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OrdineWeb)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OrdineWeb)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of OrdineWeb)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of OrdineWeb)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Ordini by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of OrdineWeb by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of OrdineWeb)
		Dim Ls As New List(Of OrdineWeb)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of OrdineWeb)
		Dim Ls As New List(Of OrdineWeb)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Ordini" 
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
	'''Return all record on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of OrdineWeb
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of OrdineWeb)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of OrdineWeb
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of OrdineWeb)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Ordini
	''' </summary>
	''' <returns>
	'''Return all record in list of OrdineWeb
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of OrdineWeb)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of OrdineWeb)
		Dim Ls As List(Of OrdineWeb)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Ordini" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of OrdineWeb)
		Dim Ls As New List(Of OrdineWeb)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  OrdineWeb() With {.IdOrdine = 0 ,.Altezza = 0 ,.Annotazioni = "" ,.Anteprima = "" ,.ConsegnaGarantita = Nothing ,.ConsegnaGarantitaDa = 0 ,.DataCambioStato = Nothing ,.DataIns = Nothing ,.DataPrevConsegna = Nothing ,.DataPrevProduzione = Nothing ,.ExtraData = "" ,.IdCons = 0 ,.IdCorriere = 0 ,.IdCoupon = 0 ,.IdIndirizzo = 0 ,.IdListinoBase = 0 ,.IdMacchinarioProduzioneUtilizzato = 0 ,.IdMailPreventivo = 0 ,.IdOrdineInt = 0 ,.IdPromo = 0 ,.IdTipoFustella = 0 ,.IdUt = 0 ,.InseritoDa = 0 ,.Larghezza = 0 ,.Lavorazioni = "" ,.Mq = 0 ,.Nfogli = 0 ,.NoEmailDemone = 0 ,.NomeLavoro = "" ,.NumeroColli = 0 ,.OrdineInOmaggio = 0 ,.OrdineWeb = False ,.Orientamento = 0 ,.Peso = 0 ,.Preventivo = 0 ,.PrezzoCalcolatoNetto = 0 ,.PrezzoCorriere = 0 ,.Profondita = 0 ,.Qta = 0 ,.Ricarico = 0 ,.Sconto = 0 ,.SorgenteCopertina = "" ,.SorgenteFronte = "" ,.SorgenteRetro = "" ,.Stato = 0 ,.StatoWeb = 0 ,.TipoConsegna = 0 ,.TipoRetro = 0 ,.TotaleIva = 0 ,.TotaleNetto = 0 ,.TotaleOrdine = 0 ,.UsaNomeLavoroInFattura = 0  })
					While myReader.Read
						Dim classe as new OrdineWeb(CType(myReader, IDataRecord))
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