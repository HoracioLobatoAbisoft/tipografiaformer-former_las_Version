#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 18/03/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of ListinoBaseSource object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ListinoBaseSourceDAO
	Inherits LUNA.LunaBaseClassDAO(Of ListinoBaseSource)

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
	'''Read from DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a ListinoBaseSource object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ListinoBaseSource
		Dim cls as new ListinoBaseSource

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Listinobasesource WHERE IdListinoBaseSource = " & Id
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
	'''Save on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ListinoBaseSource) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdListinoBaseSource = 0 Then
							sql = "INSERT INTO Listinobasesource ("
							sql &= " AbilitaQtaIntermedie,"
							sql &= " AbilitaQtaSottoColonna1,"
							sql &= " AvviamStampa,"
							sql &= " AvviamStampa2,"
							sql &= " CalcolaAncheDaSolo,"
							sql &= " DefaultNFogli,"
							sql &= " DescrSito,"
							sql &= " Disattivo,"
							sql &= " faccmax,"
							sql &= " faccmin,"
							sql &= " GoogleDescr,"
							sql &= " GoogleSEO,"
							sql &= " IdColoreStampa,"
							sql &= " IdCurvaAtt,"
							sql &= " IdCurvaPubbl,"
							sql &= " IdFormato,"
							sql &= " IdFormatoMacchina2,"
							sql &= " IdFormProd,"
							sql &= " IdHotFolderPostRefine,"
							sql &= " IdMacchinarioProduzione,"
							sql &= " IdMacchinarioProduzione2,"
							sql &= " IdMacchinarioTaglio,"
							sql &= " IdModelloCubetto,"
							sql &= " IdPrev,"
							sql &= " IdTipoCarta,"
							sql &= " IdTipoCartaCop,"
							sql &= " IdTipoCartaDorso,"
							sql &= " IdTipoImballo,"
							sql &= " imgrif,"
							sql &= " ImgSito,"
							sql &= " InEvidenza,"
							sql &= " IsFormerChoice,"
							sql &= " LabelWeb,"
							sql &= " LargRotolo,"
							sql &= " LastUpdate,"
							sql &= " MinimaleStampa,"
							sql &= " MinimaleStampa2,"
							sql &= " MoltiplicatoreQta,"
							sql &= " MoltiplicatoreQta0,"
							sql &= " MoltiplicatoreQta2,"
							sql &= " MoltiplicatoreQta3,"
							sql &= " MoltiplicatoreQta4,"
							sql &= " MoltiplicatoreQta5,"
							sql &= " MoltiplicatoreQtaIntermedia,"
							sql &= " MostraPrezziTabella,"
							sql &= " MultiploQta,"
							sql &= " NascondiOnline,"
							sql &= " nofaccsuimpianti,"
							sql &= " Nome,"
							sql &= " NomeInterno,"
							sql &= " noResa,"
							sql &= " Ordinamento,"
							sql &= " p1,"
							sql &= " p2,"
							sql &= " p3,"
							sql &= " p4,"
							sql &= " p5,"
							sql &= " p6,"
							sql &= " PercAdatCostoCopia,"
							sql &= " PercMaxPromoFatturato,"
							sql &= " PercPromoAutomatico,"
							sql &= " PrendiIcoDa,"
							sql &= " qta1,"
							sql &= " qta2,"
							sql &= " qta3,"
							sql &= " qta4,"
							sql &= " qta5,"
							sql &= " qta6,"
							sql &= " qtacollo,"
							sql &= " QtaDefault,"
							sql &= " TipoControlloPrezzo,"
							sql &= " TipoPrezzo,"
							sql &= " v1,"
							sql &= " v2,"
							sql &= " v3,"
							sql &= " v4,"
							sql &= " v5,"
							sql &= " v6,"
							sql &= " VMotoreCalcolo"
							sql &= ") VALUES ("
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?,"
							sql &= " ?"
							sql &= ")"
						Else
							sql = "UPDATE Listinobasesource SET "
							If cls.WhatIsChanged.AbilitaQtaIntermedie Then sql &= "AbilitaQtaIntermedie = ? ,"
							If cls.WhatIsChanged.AbilitaQtaSottoColonna1 Then sql &= "AbilitaQtaSottoColonna1 = ? ,"
							If cls.WhatIsChanged.AvviamStampa Then sql &= "AvviamStampa = ? ,"
							If cls.WhatIsChanged.AvviamStampa2 Then sql &= "AvviamStampa2 = ? ,"
							If cls.WhatIsChanged.CalcolaAncheDaSolo Then sql &= "CalcolaAncheDaSolo = ? ,"
							If cls.WhatIsChanged.DefaultNFogli Then sql &= "DefaultNFogli = ? ,"
							If cls.WhatIsChanged.DescrSito Then sql &= "DescrSito = ? ,"
							If cls.WhatIsChanged.Disattivo Then sql &= "Disattivo = ? ,"
							If cls.WhatIsChanged.faccmax Then sql &= "faccmax = ? ,"
							If cls.WhatIsChanged.faccmin Then sql &= "faccmin = ? ,"
							If cls.WhatIsChanged.GoogleDescr Then sql &= "GoogleDescr = ? ,"
							If cls.WhatIsChanged.GoogleSEO Then sql &= "GoogleSEO = ? ,"
							If cls.WhatIsChanged.IdColoreStampa Then sql &= "IdColoreStampa = ? ,"
							If cls.WhatIsChanged.IdCurvaAtt Then sql &= "IdCurvaAtt = ? ,"
							If cls.WhatIsChanged.IdCurvaPubbl Then sql &= "IdCurvaPubbl = ? ,"
							If cls.WhatIsChanged.IdFormato Then sql &= "IdFormato = ? ,"
							If cls.WhatIsChanged.IdFormatoMacchina2 Then sql &= "IdFormatoMacchina2 = ? ,"
							If cls.WhatIsChanged.IdFormProd Then sql &= "IdFormProd = ? ,"
							If cls.WhatIsChanged.IdHotFolderPostRefine Then sql &= "IdHotFolderPostRefine = ? ,"
							If cls.WhatIsChanged.IdMacchinarioProduzione Then sql &= "IdMacchinarioProduzione = ? ,"
							If cls.WhatIsChanged.IdMacchinarioProduzione2 Then sql &= "IdMacchinarioProduzione2 = ? ,"
							If cls.WhatIsChanged.IdMacchinarioTaglio Then sql &= "IdMacchinarioTaglio = ? ,"
							If cls.WhatIsChanged.IdModelloCubetto Then sql &= "IdModelloCubetto = ? ,"
							If cls.WhatIsChanged.IdPrev Then sql &= "IdPrev = ? ,"
							If cls.WhatIsChanged.IdTipoCarta Then sql &= "IdTipoCarta = ? ,"
							If cls.WhatIsChanged.IdTipoCartaCop Then sql &= "IdTipoCartaCop = ? ,"
							If cls.WhatIsChanged.IdTipoCartaDorso Then sql &= "IdTipoCartaDorso = ? ,"
							If cls.WhatIsChanged.IdTipoImballo Then sql &= "IdTipoImballo = ? ,"
							If cls.WhatIsChanged.imgrif Then sql &= "imgrif = ? ,"
							If cls.WhatIsChanged.ImgSito Then sql &= "ImgSito = ? ,"
							If cls.WhatIsChanged.InEvidenza Then sql &= "InEvidenza = ? ,"
							If cls.WhatIsChanged.IsFormerChoice Then sql &= "IsFormerChoice = ? ,"
							If cls.WhatIsChanged.LabelWeb Then sql &= "LabelWeb = ? ,"
							If cls.WhatIsChanged.LargRotolo Then sql &= "LargRotolo = ? ,"
							If cls.WhatIsChanged.LastUpdate Then sql &= "LastUpdate = ? ,"
							If cls.WhatIsChanged.MinimaleStampa Then sql &= "MinimaleStampa = ? ,"
							If cls.WhatIsChanged.MinimaleStampa2 Then sql &= "MinimaleStampa2 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta Then sql &= "MoltiplicatoreQta = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta0 Then sql &= "MoltiplicatoreQta0 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta2 Then sql &= "MoltiplicatoreQta2 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta3 Then sql &= "MoltiplicatoreQta3 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta4 Then sql &= "MoltiplicatoreQta4 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQta5 Then sql &= "MoltiplicatoreQta5 = ? ,"
							If cls.WhatIsChanged.MoltiplicatoreQtaIntermedia Then sql &= "MoltiplicatoreQtaIntermedia = ? ,"
							If cls.WhatIsChanged.MostraPrezziTabella Then sql &= "MostraPrezziTabella = ? ,"
							If cls.WhatIsChanged.MultiploQta Then sql &= "MultiploQta = ? ,"
							If cls.WhatIsChanged.NascondiOnline Then sql &= "NascondiOnline = ? ,"
							If cls.WhatIsChanged.nofaccsuimpianti Then sql &= "nofaccsuimpianti = ? ,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = ? ,"
							If cls.WhatIsChanged.NomeInterno Then sql &= "NomeInterno = ? ,"
							If cls.WhatIsChanged.noResa Then sql &= "noResa = ? ,"
							If cls.WhatIsChanged.Ordinamento Then sql &= "Ordinamento = ? ,"
							If cls.WhatIsChanged.p1 Then sql &= "p1 = ? ,"
							If cls.WhatIsChanged.p2 Then sql &= "p2 = ? ,"
							If cls.WhatIsChanged.p3 Then sql &= "p3 = ? ,"
							If cls.WhatIsChanged.p4 Then sql &= "p4 = ? ,"
							If cls.WhatIsChanged.p5 Then sql &= "p5 = ? ,"
							If cls.WhatIsChanged.p6 Then sql &= "p6 = ? ,"
							If cls.WhatIsChanged.PercAdatCostoCopia Then sql &= "PercAdatCostoCopia = ? ,"
							If cls.WhatIsChanged.PercMaxPromoFatturato Then sql &= "PercMaxPromoFatturato = ? ,"
							If cls.WhatIsChanged.PercPromoAutomatico Then sql &= "PercPromoAutomatico = ? ,"
							If cls.WhatIsChanged.PrendiIcoDa Then sql &= "PrendiIcoDa = ? ,"
							If cls.WhatIsChanged.qta1 Then sql &= "qta1 = ? ,"
							If cls.WhatIsChanged.qta2 Then sql &= "qta2 = ? ,"
							If cls.WhatIsChanged.qta3 Then sql &= "qta3 = ? ,"
							If cls.WhatIsChanged.qta4 Then sql &= "qta4 = ? ,"
							If cls.WhatIsChanged.qta5 Then sql &= "qta5 = ? ,"
							If cls.WhatIsChanged.qta6 Then sql &= "qta6 = ? ,"
							If cls.WhatIsChanged.qtacollo Then sql &= "qtacollo = ? ,"
							If cls.WhatIsChanged.QtaDefault Then sql &= "QtaDefault = ? ,"
							If cls.WhatIsChanged.TipoControlloPrezzo Then sql &= "TipoControlloPrezzo = ? ,"
							If cls.WhatIsChanged.TipoPrezzo Then sql &= "TipoPrezzo = ? ,"
							If cls.WhatIsChanged.v1 Then sql &= "v1 = ? ,"
							If cls.WhatIsChanged.v2 Then sql &= "v2 = ? ,"
							If cls.WhatIsChanged.v3 Then sql &= "v3 = ? ,"
							If cls.WhatIsChanged.v4 Then sql &= "v4 = ? ,"
							If cls.WhatIsChanged.v5 Then sql &= "v5 = ? ,"
							If cls.WhatIsChanged.v6 Then sql &= "v6 = ? ,"
							If cls.WhatIsChanged.VMotoreCalcolo Then sql &= "VMotoreCalcolo = ? "
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdListinoBaseSource= " & cls.IdListinoBaseSource
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AbilitaQtaIntermedie Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AbilitaQtaIntermedie"
							p.Value = cls.AbilitaQtaIntermedie
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AbilitaQtaSottoColonna1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AbilitaQtaSottoColonna1"
							p.Value = cls.AbilitaQtaSottoColonna1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AvviamStampa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AvviamStampa"
							p.Value = cls.AvviamStampa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AvviamStampa2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AvviamStampa2"
							p.Value = cls.AvviamStampa2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CalcolaAncheDaSolo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CalcolaAncheDaSolo"
							p.Value = cls.CalcolaAncheDaSolo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DefaultNFogli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DefaultNFogli"
							p.Value = cls.DefaultNFogli
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrSito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrSito"
							p.Value = cls.DescrSito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Disattivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Disattivo"
							p.Value = cls.Disattivo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.faccmax Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@faccmax"
							p.Value = cls.faccmax
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.faccmin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@faccmin"
							p.Value = cls.faccmin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GoogleDescr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GoogleDescr"
							p.Value = cls.GoogleDescr
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GoogleSEO Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GoogleSEO"
							p.Value = cls.GoogleSEO
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdColoreStampa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdColoreStampa"
							p.Value = cls.IdColoreStampa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCurvaAtt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCurvaAtt"
							p.Value = cls.IdCurvaAtt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCurvaPubbl Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCurvaPubbl"
							p.Value = cls.IdCurvaPubbl
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFormato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormato"
							p.Value = cls.IdFormato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFormatoMacchina2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormatoMacchina2"
							p.Value = cls.IdFormatoMacchina2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFormProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormProd"
							p.Value = cls.IdFormProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdHotFolderPostRefine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdHotFolderPostRefine"
							p.Value = cls.IdHotFolderPostRefine
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinarioProduzione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinarioProduzione"
							p.Value = cls.IdMacchinarioProduzione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinarioProduzione2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinarioProduzione2"
							p.Value = cls.IdMacchinarioProduzione2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinarioTaglio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinarioTaglio"
							p.Value = cls.IdMacchinarioTaglio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdModelloCubetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdModelloCubetto"
							p.Value = cls.IdModelloCubetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPrev Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPrev"
							p.Value = cls.IdPrev
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoCarta"
							p.Value = cls.IdTipoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoCartaCop Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoCartaCop"
							p.Value = cls.IdTipoCartaCop
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoCartaDorso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoCartaDorso"
							p.Value = cls.IdTipoCartaDorso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoImballo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoImballo"
							p.Value = cls.IdTipoImballo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.imgrif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@imgrif"
							p.Value = cls.imgrif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgSito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgSito"
							p.Value = cls.ImgSito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InEvidenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InEvidenza"
							p.Value = cls.InEvidenza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IsFormerChoice Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IsFormerChoice"
							p.Value = cls.IsFormerChoice
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LabelWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LabelWeb"
							p.Value = cls.LabelWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LargRotolo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LargRotolo"
							p.Value = cls.LargRotolo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LastUpdate Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LastUpdate"
							p.Value = cls.LastUpdate
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MinimaleStampa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MinimaleStampa"
							p.Value = cls.MinimaleStampa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MinimaleStampa2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MinimaleStampa2"
							p.Value = cls.MinimaleStampa2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta"
							p.Value = cls.MoltiplicatoreQta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta0 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta0"
							p.Value = cls.MoltiplicatoreQta0
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta2"
							p.Value = cls.MoltiplicatoreQta2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta3"
							p.Value = cls.MoltiplicatoreQta3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta4"
							p.Value = cls.MoltiplicatoreQta4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQta5 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQta5"
							p.Value = cls.MoltiplicatoreQta5
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MoltiplicatoreQtaIntermedia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MoltiplicatoreQtaIntermedia"
							p.Value = cls.MoltiplicatoreQtaIntermedia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MostraPrezziTabella Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MostraPrezziTabella"
							p.Value = cls.MostraPrezziTabella
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MultiploQta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MultiploQta"
							p.Value = cls.MultiploQta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NascondiOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NascondiOnline"
							p.Value = cls.NascondiOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.nofaccsuimpianti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@nofaccsuimpianti"
							p.Value = cls.nofaccsuimpianti
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeInterno Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeInterno"
							p.Value = cls.NomeInterno
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.noResa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@noResa"
							p.Value = cls.noResa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Ordinamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Ordinamento"
							p.Value = cls.Ordinamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p1"
							p.Value = cls.p1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p2"
							p.Value = cls.p2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p3"
							p.Value = cls.p3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p4"
							p.Value = cls.p4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p5 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p5"
							p.Value = cls.p5
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.p6 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@p6"
							p.Value = cls.p6
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercAdatCostoCopia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercAdatCostoCopia"
							p.Value = cls.PercAdatCostoCopia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercMaxPromoFatturato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercMaxPromoFatturato"
							p.Value = cls.PercMaxPromoFatturato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercPromoAutomatico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercPromoAutomatico"
							p.Value = cls.PercPromoAutomatico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrendiIcoDa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrendiIcoDa"
							p.Value = cls.PrendiIcoDa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta1"
							p.Value = cls.qta1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta2"
							p.Value = cls.qta2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta3"
							p.Value = cls.qta3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta4"
							p.Value = cls.qta4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta5 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta5"
							p.Value = cls.qta5
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qta6 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qta6"
							p.Value = cls.qta6
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.qtacollo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@qtacollo"
							p.Value = cls.qtacollo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QtaDefault Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QtaDefault"
							p.Value = cls.QtaDefault
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoControlloPrezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoControlloPrezzo"
							p.Value = cls.TipoControlloPrezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoPrezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoPrezzo"
							p.Value = cls.TipoPrezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v1"
							p.Value = cls.v1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v2"
							p.Value = cls.v2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v3"
							p.Value = cls.v3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v4 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v4"
							p.Value = cls.v4
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v5 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v5"
							p.Value = cls.v5
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.v6 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@v6"
							p.Value = cls.v6
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.VMotoreCalcolo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@VMotoreCalcolo"
							p.Value = cls.VMotoreCalcolo
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdListinoBaseSource=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdListinoBaseSource = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdListinoBaseSource
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdListinoBaseSource
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
				'Dim Sql As String = "UPDATE Listinobasesource SET DELETED=True "
				Dim Sql As String = "DELETE FROM Listinobasesource"
				Sql &= " WHERE IdListinoBaseSource = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Listinobasesource. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Listinobasesource. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ListinoBaseSource, Optional ByRef ListaObj as List (of ListinoBaseSource) = Nothing)
		DestroyPermanently (obj.IdListinoBaseSource)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoBaseSource
		Dim ris As ListinoBaseSource = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ListinoBaseSource) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return first of ListinoBaseSource
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoBaseSource
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return first of ListinoBaseSource
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoBaseSource
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ListinoBaseSource
	''' </summary>
	''' <returns>
	'''Return first of ListinoBaseSource
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ListinoBaseSource
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoBaseSource)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoBaseSource)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoBaseSource)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoBaseSource)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ListinoBaseSource)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ListinoBaseSource)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Listinobasesource by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ListinoBaseSource by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoBaseSource)
		Dim Ls As New List(Of ListinoBaseSource)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ListinoBaseSource)
		Dim Ls As New List(Of ListinoBaseSource)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Listinobasesource" 
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
	'''Return all record on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoBaseSource
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ListinoBaseSource)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoBaseSource
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoBaseSource)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Listinobasesource
	''' </summary>
	''' <returns>
	'''Return all record in list of ListinoBaseSource
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ListinoBaseSource)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ListinoBaseSource)
		Dim Ls As List(Of ListinoBaseSource)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Listinobasesource" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ListinoBaseSource)
		Dim Ls As New List(Of ListinoBaseSource)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ListinoBaseSource() With {.IdListinoBaseSource = 0 ,.AbilitaQtaIntermedie = 0 ,.AbilitaQtaSottoColonna1 = 0 ,.AvviamStampa = 0 ,.AvviamStampa2 = 0 ,.CalcolaAncheDaSolo = 0 ,.DefaultNFogli = 0 ,.DescrSito = "" ,.Disattivo = 0 ,.faccmax = 0 ,.faccmin = 0 ,.GoogleDescr = "" ,.GoogleSEO = "" ,.IdColoreStampa = 0 ,.IdCurvaAtt = 0 ,.IdCurvaPubbl = 0 ,.IdFormato = 0 ,.IdFormatoMacchina2 = 0 ,.IdFormProd = 0 ,.IdHotFolderPostRefine = 0 ,.IdMacchinarioProduzione = 0 ,.IdMacchinarioProduzione2 = 0 ,.IdMacchinarioTaglio = 0 ,.IdModelloCubetto = 0 ,.IdPrev = 0 ,.IdTipoCarta = 0 ,.IdTipoCartaCop = 0 ,.IdTipoCartaDorso = 0 ,.IdTipoImballo = 0 ,.imgrif = "" ,.ImgSito = "" ,.InEvidenza = 0 ,.IsFormerChoice = 0 ,.LabelWeb = "" ,.LargRotolo = "" ,.LastUpdate = 0 ,.MinimaleStampa = 0 ,.MinimaleStampa2 = 0 ,.MoltiplicatoreQta = 0 ,.MoltiplicatoreQta0 = 0 ,.MoltiplicatoreQta2 = 0 ,.MoltiplicatoreQta3 = 0 ,.MoltiplicatoreQta4 = 0 ,.MoltiplicatoreQta5 = 0 ,.MoltiplicatoreQtaIntermedia = 0 ,.MostraPrezziTabella = 0 ,.MultiploQta = 0 ,.NascondiOnline = 0 ,.nofaccsuimpianti = False ,.Nome = "" ,.NomeInterno = "" ,.noResa = 0 ,.Ordinamento = 0 ,.p1 = 0 ,.p2 = 0 ,.p3 = 0 ,.p4 = 0 ,.p5 = 0 ,.p6 = 0 ,.PercAdatCostoCopia = 0 ,.PercMaxPromoFatturato = 0 ,.PercPromoAutomatico = 0 ,.PrendiIcoDa = 0 ,.qta1 = 0 ,.qta2 = 0 ,.qta3 = 0 ,.qta4 = 0 ,.qta5 = 0 ,.qta6 = 0 ,.qtacollo = 0 ,.QtaDefault = 0 ,.TipoControlloPrezzo = 0 ,.TipoPrezzo = 0 ,.v1 = 0 ,.v2 = 0 ,.v3 = 0 ,.v4 = 0 ,.v5 = 0 ,.v6 = 0 ,.VMotoreCalcolo = 0  })
					While myReader.Read
						Dim classe as new ListinoBaseSource(CType(myReader, IDataRecord))
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