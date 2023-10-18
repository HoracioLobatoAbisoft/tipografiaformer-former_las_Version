#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 18/03/2020 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Listinobasesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _ListinoBaseSource
	Inherits LUNA.LunaBaseClassEntity
	Implements _IListinoBaseSource
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IListinoBaseSource.FillFromDataRecord
		IdListinoBaseSource = myRecord("IdListinoBaseSource")
		if not myRecord("AbilitaQtaIntermedie") is DBNull.Value then AbilitaQtaIntermedie = myRecord("AbilitaQtaIntermedie")
		if not myRecord("AbilitaQtaSottoColonna1") is DBNull.Value then AbilitaQtaSottoColonna1 = myRecord("AbilitaQtaSottoColonna1")
		if not myRecord("AvviamStampa") is DBNull.Value then AvviamStampa = myRecord("AvviamStampa")
		if not myRecord("AvviamStampa2") is DBNull.Value then AvviamStampa2 = myRecord("AvviamStampa2")
		if not myRecord("CalcolaAncheDaSolo") is DBNull.Value then CalcolaAncheDaSolo = myRecord("CalcolaAncheDaSolo")
		if not myRecord("DefaultNFogli") is DBNull.Value then DefaultNFogli = myRecord("DefaultNFogli")
		if not myRecord("DescrSito") is DBNull.Value then DescrSito = myRecord("DescrSito")
		if not myRecord("Disattivo") is DBNull.Value then Disattivo = myRecord("Disattivo")
		if not myRecord("faccmax") is DBNull.Value then faccmax = myRecord("faccmax")
		if not myRecord("faccmin") is DBNull.Value then faccmin = myRecord("faccmin")
		if not myRecord("GoogleDescr") is DBNull.Value then GoogleDescr = myRecord("GoogleDescr")
		if not myRecord("GoogleSEO") is DBNull.Value then GoogleSEO = myRecord("GoogleSEO")
		if not myRecord("IdColoreStampa") is DBNull.Value then IdColoreStampa = myRecord("IdColoreStampa")
		if not myRecord("IdCurvaAtt") is DBNull.Value then IdCurvaAtt = myRecord("IdCurvaAtt")
		if not myRecord("IdCurvaPubbl") is DBNull.Value then IdCurvaPubbl = myRecord("IdCurvaPubbl")
		if not myRecord("IdFormato") is DBNull.Value then IdFormato = myRecord("IdFormato")
		if not myRecord("IdFormatoMacchina2") is DBNull.Value then IdFormatoMacchina2 = myRecord("IdFormatoMacchina2")
		if not myRecord("IdFormProd") is DBNull.Value then IdFormProd = myRecord("IdFormProd")
		if not myRecord("IdHotFolderPostRefine") is DBNull.Value then IdHotFolderPostRefine = myRecord("IdHotFolderPostRefine")
		if not myRecord("IdMacchinarioProduzione") is DBNull.Value then IdMacchinarioProduzione = myRecord("IdMacchinarioProduzione")
		if not myRecord("IdMacchinarioProduzione2") is DBNull.Value then IdMacchinarioProduzione2 = myRecord("IdMacchinarioProduzione2")
		if not myRecord("IdMacchinarioTaglio") is DBNull.Value then IdMacchinarioTaglio = myRecord("IdMacchinarioTaglio")
		if not myRecord("IdModelloCubetto") is DBNull.Value then IdModelloCubetto = myRecord("IdModelloCubetto")
		if not myRecord("IdPrev") is DBNull.Value then IdPrev = myRecord("IdPrev")
		if not myRecord("IdTipoCarta") is DBNull.Value then IdTipoCarta = myRecord("IdTipoCarta")
		if not myRecord("IdTipoCartaCop") is DBNull.Value then IdTipoCartaCop = myRecord("IdTipoCartaCop")
		if not myRecord("IdTipoCartaDorso") is DBNull.Value then IdTipoCartaDorso = myRecord("IdTipoCartaDorso")
		if not myRecord("IdTipoImballo") is DBNull.Value then IdTipoImballo = myRecord("IdTipoImballo")
		if not myRecord("imgrif") is DBNull.Value then imgrif = myRecord("imgrif")
		if not myRecord("ImgSito") is DBNull.Value then ImgSito = myRecord("ImgSito")
		if not myRecord("InEvidenza") is DBNull.Value then InEvidenza = myRecord("InEvidenza")
		if not myRecord("IsFormerChoice") is DBNull.Value then IsFormerChoice = myRecord("IsFormerChoice")
		if not myRecord("LabelWeb") is DBNull.Value then LabelWeb = myRecord("LabelWeb")
		if not myRecord("LargRotolo") is DBNull.Value then LargRotolo = myRecord("LargRotolo")
		if not myRecord("LastUpdate") is DBNull.Value then LastUpdate = myRecord("LastUpdate")
		if not myRecord("MinimaleStampa") is DBNull.Value then MinimaleStampa = myRecord("MinimaleStampa")
		if not myRecord("MinimaleStampa2") is DBNull.Value then MinimaleStampa2 = myRecord("MinimaleStampa2")
		if not myRecord("MoltiplicatoreQta") is DBNull.Value then MoltiplicatoreQta = myRecord("MoltiplicatoreQta")
		if not myRecord("MoltiplicatoreQta0") is DBNull.Value then MoltiplicatoreQta0 = myRecord("MoltiplicatoreQta0")
		if not myRecord("MoltiplicatoreQta2") is DBNull.Value then MoltiplicatoreQta2 = myRecord("MoltiplicatoreQta2")
		if not myRecord("MoltiplicatoreQta3") is DBNull.Value then MoltiplicatoreQta3 = myRecord("MoltiplicatoreQta3")
		if not myRecord("MoltiplicatoreQta4") is DBNull.Value then MoltiplicatoreQta4 = myRecord("MoltiplicatoreQta4")
		if not myRecord("MoltiplicatoreQta5") is DBNull.Value then MoltiplicatoreQta5 = myRecord("MoltiplicatoreQta5")
		if not myRecord("MoltiplicatoreQtaIntermedia") is DBNull.Value then MoltiplicatoreQtaIntermedia = myRecord("MoltiplicatoreQtaIntermedia")
		if not myRecord("MostraPrezziTabella") is DBNull.Value then MostraPrezziTabella = myRecord("MostraPrezziTabella")
		if not myRecord("MultiploQta") is DBNull.Value then MultiploQta = myRecord("MultiploQta")
		if not myRecord("NascondiOnline") is DBNull.Value then NascondiOnline = myRecord("NascondiOnline")
		if not myRecord("nofaccsuimpianti") is DBNull.Value then nofaccsuimpianti = myRecord("nofaccsuimpianti")
		if not myRecord("Nome") is DBNull.Value then Nome = myRecord("Nome")
		if not myRecord("NomeInterno") is DBNull.Value then NomeInterno = myRecord("NomeInterno")
		if not myRecord("noResa") is DBNull.Value then noResa = myRecord("noResa")
		if not myRecord("Ordinamento") is DBNull.Value then Ordinamento = myRecord("Ordinamento")
		if not myRecord("p1") is DBNull.Value then p1 = myRecord("p1")
		if not myRecord("p2") is DBNull.Value then p2 = myRecord("p2")
		if not myRecord("p3") is DBNull.Value then p3 = myRecord("p3")
		if not myRecord("p4") is DBNull.Value then p4 = myRecord("p4")
		if not myRecord("p5") is DBNull.Value then p5 = myRecord("p5")
		if not myRecord("p6") is DBNull.Value then p6 = myRecord("p6")
		if not myRecord("PercAdatCostoCopia") is DBNull.Value then PercAdatCostoCopia = myRecord("PercAdatCostoCopia")
		if not myRecord("PercMaxPromoFatturato") is DBNull.Value then PercMaxPromoFatturato = myRecord("PercMaxPromoFatturato")
		if not myRecord("PercPromoAutomatico") is DBNull.Value then PercPromoAutomatico = myRecord("PercPromoAutomatico")
		if not myRecord("PrendiIcoDa") is DBNull.Value then PrendiIcoDa = myRecord("PrendiIcoDa")
		if not myRecord("qta1") is DBNull.Value then qta1 = myRecord("qta1")
		if not myRecord("qta2") is DBNull.Value then qta2 = myRecord("qta2")
		if not myRecord("qta3") is DBNull.Value then qta3 = myRecord("qta3")
		if not myRecord("qta4") is DBNull.Value then qta4 = myRecord("qta4")
		if not myRecord("qta5") is DBNull.Value then qta5 = myRecord("qta5")
		if not myRecord("qta6") is DBNull.Value then qta6 = myRecord("qta6")
		if not myRecord("qtacollo") is DBNull.Value then qtacollo = myRecord("qtacollo")
		if not myRecord("QtaDefault") is DBNull.Value then QtaDefault = myRecord("QtaDefault")
		if not myRecord("TipoControlloPrezzo") is DBNull.Value then TipoControlloPrezzo = myRecord("TipoControlloPrezzo")
		if not myRecord("TipoPrezzo") is DBNull.Value then TipoPrezzo = myRecord("TipoPrezzo")
		if not myRecord("v1") is DBNull.Value then v1 = myRecord("v1")
		if not myRecord("v2") is DBNull.Value then v2 = myRecord("v2")
		if not myRecord("v3") is DBNull.Value then v3 = myRecord("v3")
		if not myRecord("v4") is DBNull.Value then v4 = myRecord("v4")
		if not myRecord("v5") is DBNull.Value then v5 = myRecord("v5")
		if not myRecord("v6") is DBNull.Value then v6 = myRecord("v6")
		if not myRecord("VMotoreCalcolo") is DBNull.Value then VMotoreCalcolo = myRecord("VMotoreCalcolo")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of ListinoBaseSource)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(ListinoBaseSourceDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of ListinoBaseSource))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdListinoBaseSource As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AbilitaQtaIntermedie As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AbilitaQtaSottoColonna1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AvviamStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AvviamStampa2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CalcolaAncheDaSolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DefaultNFogli As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DescrSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disattivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property faccmax As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property faccmin As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GoogleDescr As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GoogleSEO As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdColoreStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCurvaAtt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCurvaPubbl As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormatoMacchina2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFormProd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdHotFolderPostRefine As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioProduzione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioProduzione2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdMacchinarioTaglio As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdModelloCubetto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCarta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCartaCop As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoCartaDorso As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdTipoImballo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property imgrif As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImgSito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InEvidenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IsFormerChoice As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LabelWeb As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LargRotolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property LastUpdate As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MinimaleStampa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MinimaleStampa2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta0 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQta5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MoltiplicatoreQtaIntermedia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MostraPrezziTabella As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property MultiploQta As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NascondiOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property nofaccsuimpianti As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Nome As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeInterno As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property noResa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Ordinamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property p6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercAdatCostoCopia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercMaxPromoFatturato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercPromoAutomatico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrendiIcoDa As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qta6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property qtacollo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaDefault As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoControlloPrezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoPrezzo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property v6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property VMotoreCalcolo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdListinoBaseSource = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AbilitaQtaIntermedie = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AbilitaQtaSottoColonna1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AvviamStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AvviamStampa2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CalcolaAncheDaSolo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DefaultNFogli = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DescrSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disattivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.faccmax = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.faccmin = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GoogleDescr = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GoogleSEO = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdColoreStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCurvaAtt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCurvaPubbl = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormatoMacchina2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFormProd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdHotFolderPostRefine = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioProduzione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioProduzione2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdMacchinarioTaglio = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdModelloCubetto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCarta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCartaCop = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoCartaDorso = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdTipoImballo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.imgrif = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImgSito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InEvidenza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IsFormerChoice = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LabelWeb = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LargRotolo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.LastUpdate = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MinimaleStampa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MinimaleStampa2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta0 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQta5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MoltiplicatoreQtaIntermedia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MostraPrezziTabella = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.MultiploQta = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NascondiOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.nofaccsuimpianti = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Nome = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeInterno = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.noResa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Ordinamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.p6 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercAdatCostoCopia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercMaxPromoFatturato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercPromoAutomatico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrendiIcoDa = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qta6 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.qtacollo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaDefault = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoControlloPrezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoPrezzo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.v6 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.VMotoreCalcolo = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdListinoBaseSource as integer  = 0 
	Public Overridable Property IdListinoBaseSource() as integer  Implements _IListinoBaseSource.IdListinoBaseSource
		Get
			Return _IdListinoBaseSource
		End Get
		Set (byval value as integer)
			If _IdListinoBaseSource <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBaseSource = True
				_IdListinoBaseSource = value
			End If
		End Set
	End property 

	Protected _AbilitaQtaIntermedie as integer  = 0 
	Public Overridable Property AbilitaQtaIntermedie() as integer  Implements _IListinoBaseSource.AbilitaQtaIntermedie
		Get
			Return _AbilitaQtaIntermedie
		End Get
		Set (byval value as integer)
			If _AbilitaQtaIntermedie <> value Then
				IsChanged = True
				WhatIsChanged.AbilitaQtaIntermedie = True
				_AbilitaQtaIntermedie = value
			End If
		End Set
	End property 

	Protected _AbilitaQtaSottoColonna1 as integer  = 0 
	Public Overridable Property AbilitaQtaSottoColonna1() as integer  Implements _IListinoBaseSource.AbilitaQtaSottoColonna1
		Get
			Return _AbilitaQtaSottoColonna1
		End Get
		Set (byval value as integer)
			If _AbilitaQtaSottoColonna1 <> value Then
				IsChanged = True
				WhatIsChanged.AbilitaQtaSottoColonna1 = True
				_AbilitaQtaSottoColonna1 = value
			End If
		End Set
	End property 

	Protected _AvviamStampa as integer  = 0 
	Public Overridable Property AvviamStampa() as integer  Implements _IListinoBaseSource.AvviamStampa
		Get
			Return _AvviamStampa
		End Get
		Set (byval value as integer)
			If _AvviamStampa <> value Then
				IsChanged = True
				WhatIsChanged.AvviamStampa = True
				_AvviamStampa = value
			End If
		End Set
	End property 

	Protected _AvviamStampa2 as integer  = 0 
	Public Overridable Property AvviamStampa2() as integer  Implements _IListinoBaseSource.AvviamStampa2
		Get
			Return _AvviamStampa2
		End Get
		Set (byval value as integer)
			If _AvviamStampa2 <> value Then
				IsChanged = True
				WhatIsChanged.AvviamStampa2 = True
				_AvviamStampa2 = value
			End If
		End Set
	End property 

	Protected _CalcolaAncheDaSolo as integer  = 0 
	Public Overridable Property CalcolaAncheDaSolo() as integer  Implements _IListinoBaseSource.CalcolaAncheDaSolo
		Get
			Return _CalcolaAncheDaSolo
		End Get
		Set (byval value as integer)
			If _CalcolaAncheDaSolo <> value Then
				IsChanged = True
				WhatIsChanged.CalcolaAncheDaSolo = True
				_CalcolaAncheDaSolo = value
			End If
		End Set
	End property 

	Protected _DefaultNFogli as integer  = 0 
	Public Overridable Property DefaultNFogli() as integer  Implements _IListinoBaseSource.DefaultNFogli
		Get
			Return _DefaultNFogli
		End Get
		Set (byval value as integer)
			If _DefaultNFogli <> value Then
				IsChanged = True
				WhatIsChanged.DefaultNFogli = True
				_DefaultNFogli = value
			End If
		End Set
	End property 

	Protected _DescrSito as string  = "" 
	Public Overridable Property DescrSito() as string  Implements _IListinoBaseSource.DescrSito
		Get
			Return _DescrSito
		End Get
		Set (byval value as string)
			If _DescrSito <> value Then
				IsChanged = True
				WhatIsChanged.DescrSito = True
				_DescrSito = value
			End If
		End Set
	End property 

	Protected _Disattivo as integer  = 0 
	Public Overridable Property Disattivo() as integer  Implements _IListinoBaseSource.Disattivo
		Get
			Return _Disattivo
		End Get
		Set (byval value as integer)
			If _Disattivo <> value Then
				IsChanged = True
				WhatIsChanged.Disattivo = True
				_Disattivo = value
			End If
		End Set
	End property 

	Protected _faccmax as integer  = 0 
	Public Overridable Property faccmax() as integer  Implements _IListinoBaseSource.faccmax
		Get
			Return _faccmax
		End Get
		Set (byval value as integer)
			If _faccmax <> value Then
				IsChanged = True
				WhatIsChanged.faccmax = True
				_faccmax = value
			End If
		End Set
	End property 

	Protected _faccmin as integer  = 0 
	Public Overridable Property faccmin() as integer  Implements _IListinoBaseSource.faccmin
		Get
			Return _faccmin
		End Get
		Set (byval value as integer)
			If _faccmin <> value Then
				IsChanged = True
				WhatIsChanged.faccmin = True
				_faccmin = value
			End If
		End Set
	End property 

	Protected _GoogleDescr as string  = "" 
	Public Overridable Property GoogleDescr() as string  Implements _IListinoBaseSource.GoogleDescr
		Get
			Return _GoogleDescr
		End Get
		Set (byval value as string)
			If _GoogleDescr <> value Then
				IsChanged = True
				WhatIsChanged.GoogleDescr = True
				_GoogleDescr = value
			End If
		End Set
	End property 

	Protected _GoogleSEO as string  = "" 
	Public Overridable Property GoogleSEO() as string  Implements _IListinoBaseSource.GoogleSEO
		Get
			Return _GoogleSEO
		End Get
		Set (byval value as string)
			If _GoogleSEO <> value Then
				IsChanged = True
				WhatIsChanged.GoogleSEO = True
				_GoogleSEO = value
			End If
		End Set
	End property 

	Protected _IdColoreStampa as integer  = 0 
	Public Overridable Property IdColoreStampa() as integer  Implements _IListinoBaseSource.IdColoreStampa
		Get
			Return _IdColoreStampa
		End Get
		Set (byval value as integer)
			If _IdColoreStampa <> value Then
				IsChanged = True
				WhatIsChanged.IdColoreStampa = True
				_IdColoreStampa = value
			End If
		End Set
	End property 

	Protected _IdCurvaAtt as integer  = 0 
	Public Overridable Property IdCurvaAtt() as integer  Implements _IListinoBaseSource.IdCurvaAtt
		Get
			Return _IdCurvaAtt
		End Get
		Set (byval value as integer)
			If _IdCurvaAtt <> value Then
				IsChanged = True
				WhatIsChanged.IdCurvaAtt = True
				_IdCurvaAtt = value
			End If
		End Set
	End property 

	Protected _IdCurvaPubbl as integer  = 0 
	Public Overridable Property IdCurvaPubbl() as integer  Implements _IListinoBaseSource.IdCurvaPubbl
		Get
			Return _IdCurvaPubbl
		End Get
		Set (byval value as integer)
			If _IdCurvaPubbl <> value Then
				IsChanged = True
				WhatIsChanged.IdCurvaPubbl = True
				_IdCurvaPubbl = value
			End If
		End Set
	End property 

	Protected _IdFormato as integer  = 0 
	Public Overridable Property IdFormato() as integer  Implements _IListinoBaseSource.IdFormato
		Get
			Return _IdFormato
		End Get
		Set (byval value as integer)
			If _IdFormato <> value Then
				IsChanged = True
				WhatIsChanged.IdFormato = True
				_IdFormato = value
			End If
		End Set
	End property 

	Protected _IdFormatoMacchina2 as integer  = 0 
	Public Overridable Property IdFormatoMacchina2() as integer  Implements _IListinoBaseSource.IdFormatoMacchina2
		Get
			Return _IdFormatoMacchina2
		End Get
		Set (byval value as integer)
			If _IdFormatoMacchina2 <> value Then
				IsChanged = True
				WhatIsChanged.IdFormatoMacchina2 = True
				_IdFormatoMacchina2 = value
			End If
		End Set
	End property 

	Protected _IdFormProd as integer  = 0 
	Public Overridable Property IdFormProd() as integer  Implements _IListinoBaseSource.IdFormProd
		Get
			Return _IdFormProd
		End Get
		Set (byval value as integer)
			If _IdFormProd <> value Then
				IsChanged = True
				WhatIsChanged.IdFormProd = True
				_IdFormProd = value
			End If
		End Set
	End property 

	Protected _IdHotFolderPostRefine as integer  = 0 
	Public Overridable Property IdHotFolderPostRefine() as integer  Implements _IListinoBaseSource.IdHotFolderPostRefine
		Get
			Return _IdHotFolderPostRefine
		End Get
		Set (byval value as integer)
			If _IdHotFolderPostRefine <> value Then
				IsChanged = True
				WhatIsChanged.IdHotFolderPostRefine = True
				_IdHotFolderPostRefine = value
			End If
		End Set
	End property 

	Protected _IdMacchinarioProduzione as integer  = 0 
	Public Overridable Property IdMacchinarioProduzione() as integer  Implements _IListinoBaseSource.IdMacchinarioProduzione
		Get
			Return _IdMacchinarioProduzione
		End Get
		Set (byval value as integer)
			If _IdMacchinarioProduzione <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioProduzione = True
				_IdMacchinarioProduzione = value
			End If
		End Set
	End property 

	Protected _IdMacchinarioProduzione2 as integer  = 0 
	Public Overridable Property IdMacchinarioProduzione2() as integer  Implements _IListinoBaseSource.IdMacchinarioProduzione2
		Get
			Return _IdMacchinarioProduzione2
		End Get
		Set (byval value as integer)
			If _IdMacchinarioProduzione2 <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioProduzione2 = True
				_IdMacchinarioProduzione2 = value
			End If
		End Set
	End property 

	Protected _IdMacchinarioTaglio as integer  = 0 
	Public Overridable Property IdMacchinarioTaglio() as integer  Implements _IListinoBaseSource.IdMacchinarioTaglio
		Get
			Return _IdMacchinarioTaglio
		End Get
		Set (byval value as integer)
			If _IdMacchinarioTaglio <> value Then
				IsChanged = True
				WhatIsChanged.IdMacchinarioTaglio = True
				_IdMacchinarioTaglio = value
			End If
		End Set
	End property 

	Protected _IdModelloCubetto as integer  = 0 
	Public Overridable Property IdModelloCubetto() as integer  Implements _IListinoBaseSource.IdModelloCubetto
		Get
			Return _IdModelloCubetto
		End Get
		Set (byval value as integer)
			If _IdModelloCubetto <> value Then
				IsChanged = True
				WhatIsChanged.IdModelloCubetto = True
				_IdModelloCubetto = value
			End If
		End Set
	End property 

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _IListinoBaseSource.IdPrev
		Get
			Return _IdPrev
		End Get
		Set (byval value as integer)
			If _IdPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdPrev = True
				_IdPrev = value
			End If
		End Set
	End property 

	Protected _IdTipoCarta as integer  = 0 
	Public Overridable Property IdTipoCarta() as integer  Implements _IListinoBaseSource.IdTipoCarta
		Get
			Return _IdTipoCarta
		End Get
		Set (byval value as integer)
			If _IdTipoCarta <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCarta = True
				_IdTipoCarta = value
			End If
		End Set
	End property 

	Protected _IdTipoCartaCop as integer  = 0 
	Public Overridable Property IdTipoCartaCop() as integer  Implements _IListinoBaseSource.IdTipoCartaCop
		Get
			Return _IdTipoCartaCop
		End Get
		Set (byval value as integer)
			If _IdTipoCartaCop <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCartaCop = True
				_IdTipoCartaCop = value
			End If
		End Set
	End property 

	Protected _IdTipoCartaDorso as integer  = 0 
	Public Overridable Property IdTipoCartaDorso() as integer  Implements _IListinoBaseSource.IdTipoCartaDorso
		Get
			Return _IdTipoCartaDorso
		End Get
		Set (byval value as integer)
			If _IdTipoCartaDorso <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoCartaDorso = True
				_IdTipoCartaDorso = value
			End If
		End Set
	End property 

	Protected _IdTipoImballo as integer  = 0 
	Public Overridable Property IdTipoImballo() as integer  Implements _IListinoBaseSource.IdTipoImballo
		Get
			Return _IdTipoImballo
		End Get
		Set (byval value as integer)
			If _IdTipoImballo <> value Then
				IsChanged = True
				WhatIsChanged.IdTipoImballo = True
				_IdTipoImballo = value
			End If
		End Set
	End property 

	Protected _imgrif as string  = "" 
	Public Overridable Property imgrif() as string  Implements _IListinoBaseSource.imgrif
		Get
			Return _imgrif
		End Get
		Set (byval value as string)
			If _imgrif <> value Then
				IsChanged = True
				WhatIsChanged.imgrif = True
				_imgrif = value
			End If
		End Set
	End property 

	Protected _ImgSito as string  = "" 
	Public Overridable Property ImgSito() as string  Implements _IListinoBaseSource.ImgSito
		Get
			Return _ImgSito
		End Get
		Set (byval value as string)
			If _ImgSito <> value Then
				IsChanged = True
				WhatIsChanged.ImgSito = True
				_ImgSito = value
			End If
		End Set
	End property 

	Protected _InEvidenza as integer  = 0 
	Public Overridable Property InEvidenza() as integer  Implements _IListinoBaseSource.InEvidenza
		Get
			Return _InEvidenza
		End Get
		Set (byval value as integer)
			If _InEvidenza <> value Then
				IsChanged = True
				WhatIsChanged.InEvidenza = True
				_InEvidenza = value
			End If
		End Set
	End property 

	Protected _IsFormerChoice as integer  = 0 
	Public Overridable Property IsFormerChoice() as integer  Implements _IListinoBaseSource.IsFormerChoice
		Get
			Return _IsFormerChoice
		End Get
		Set (byval value as integer)
			If _IsFormerChoice <> value Then
				IsChanged = True
				WhatIsChanged.IsFormerChoice = True
				_IsFormerChoice = value
			End If
		End Set
	End property 

	Protected _LabelWeb as string  = "" 
	Public Overridable Property LabelWeb() as string  Implements _IListinoBaseSource.LabelWeb
		Get
			Return _LabelWeb
		End Get
		Set (byval value as string)
			If _LabelWeb <> value Then
				IsChanged = True
				WhatIsChanged.LabelWeb = True
				_LabelWeb = value
			End If
		End Set
	End property 

	Protected _LargRotolo as string  = "" 
	Public Overridable Property LargRotolo() as string  Implements _IListinoBaseSource.LargRotolo
		Get
			Return _LargRotolo
		End Get
		Set (byval value as string)
			If _LargRotolo <> value Then
				IsChanged = True
				WhatIsChanged.LargRotolo = True
				_LargRotolo = value
			End If
		End Set
	End property 

	Protected _LastUpdate as integer  = 0 
	Public Overridable Property LastUpdate() as integer  Implements _IListinoBaseSource.LastUpdate
		Get
			Return _LastUpdate
		End Get
		Set (byval value as integer)
			If _LastUpdate <> value Then
				IsChanged = True
				WhatIsChanged.LastUpdate = True
				_LastUpdate = value
			End If
		End Set
	End property 

	Protected _MinimaleStampa as integer  = 0 
	Public Overridable Property MinimaleStampa() as integer  Implements _IListinoBaseSource.MinimaleStampa
		Get
			Return _MinimaleStampa
		End Get
		Set (byval value as integer)
			If _MinimaleStampa <> value Then
				IsChanged = True
				WhatIsChanged.MinimaleStampa = True
				_MinimaleStampa = value
			End If
		End Set
	End property 

	Protected _MinimaleStampa2 as integer  = 0 
	Public Overridable Property MinimaleStampa2() as integer  Implements _IListinoBaseSource.MinimaleStampa2
		Get
			Return _MinimaleStampa2
		End Get
		Set (byval value as integer)
			If _MinimaleStampa2 <> value Then
				IsChanged = True
				WhatIsChanged.MinimaleStampa2 = True
				_MinimaleStampa2 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta as integer  = 0 
	Public Overridable Property MoltiplicatoreQta() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta
		Get
			Return _MoltiplicatoreQta
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta = True
				_MoltiplicatoreQta = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta0 as integer  = 0 
	Public Overridable Property MoltiplicatoreQta0() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta0
		Get
			Return _MoltiplicatoreQta0
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta0 <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta0 = True
				_MoltiplicatoreQta0 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta2 as integer  = 0 
	Public Overridable Property MoltiplicatoreQta2() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta2
		Get
			Return _MoltiplicatoreQta2
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta2 <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta2 = True
				_MoltiplicatoreQta2 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta3 as integer  = 0 
	Public Overridable Property MoltiplicatoreQta3() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta3
		Get
			Return _MoltiplicatoreQta3
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta3 <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta3 = True
				_MoltiplicatoreQta3 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta4 as integer  = 0 
	Public Overridable Property MoltiplicatoreQta4() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta4
		Get
			Return _MoltiplicatoreQta4
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta4 <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta4 = True
				_MoltiplicatoreQta4 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQta5 as integer  = 0 
	Public Overridable Property MoltiplicatoreQta5() as integer  Implements _IListinoBaseSource.MoltiplicatoreQta5
		Get
			Return _MoltiplicatoreQta5
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQta5 <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQta5 = True
				_MoltiplicatoreQta5 = value
			End If
		End Set
	End property 

	Protected _MoltiplicatoreQtaIntermedia as integer  = 0 
	Public Overridable Property MoltiplicatoreQtaIntermedia() as integer  Implements _IListinoBaseSource.MoltiplicatoreQtaIntermedia
		Get
			Return _MoltiplicatoreQtaIntermedia
		End Get
		Set (byval value as integer)
			If _MoltiplicatoreQtaIntermedia <> value Then
				IsChanged = True
				WhatIsChanged.MoltiplicatoreQtaIntermedia = True
				_MoltiplicatoreQtaIntermedia = value
			End If
		End Set
	End property 

	Protected _MostraPrezziTabella as integer  = 0 
	Public Overridable Property MostraPrezziTabella() as integer  Implements _IListinoBaseSource.MostraPrezziTabella
		Get
			Return _MostraPrezziTabella
		End Get
		Set (byval value as integer)
			If _MostraPrezziTabella <> value Then
				IsChanged = True
				WhatIsChanged.MostraPrezziTabella = True
				_MostraPrezziTabella = value
			End If
		End Set
	End property 

	Protected _MultiploQta as integer  = 0 
	Public Overridable Property MultiploQta() as integer  Implements _IListinoBaseSource.MultiploQta
		Get
			Return _MultiploQta
		End Get
		Set (byval value as integer)
			If _MultiploQta <> value Then
				IsChanged = True
				WhatIsChanged.MultiploQta = True
				_MultiploQta = value
			End If
		End Set
	End property 

	Protected _NascondiOnline as integer  = 0 
	Public Overridable Property NascondiOnline() as integer  Implements _IListinoBaseSource.NascondiOnline
		Get
			Return _NascondiOnline
		End Get
		Set (byval value as integer)
			If _NascondiOnline <> value Then
				IsChanged = True
				WhatIsChanged.NascondiOnline = True
				_NascondiOnline = value
			End If
		End Set
	End property 

	Protected _nofaccsuimpianti as Boolean  = False 
	Public Overridable Property nofaccsuimpianti() as Boolean  Implements _IListinoBaseSource.nofaccsuimpianti
		Get
			Return _nofaccsuimpianti
		End Get
		Set (byval value as Boolean)
			If _nofaccsuimpianti <> value Then
				IsChanged = True
				WhatIsChanged.nofaccsuimpianti = True
				_nofaccsuimpianti = value
			End If
		End Set
	End property 

	Protected _Nome as string  = "" 
	Public Overridable Property Nome() as string  Implements _IListinoBaseSource.Nome
		Get
			Return _Nome
		End Get
		Set (byval value as string)
			If _Nome <> value Then
				IsChanged = True
				WhatIsChanged.Nome = True
				_Nome = value
			End If
		End Set
	End property 

	Protected _NomeInterno as string  = "" 
	Public Overridable Property NomeInterno() as string  Implements _IListinoBaseSource.NomeInterno
		Get
			Return _NomeInterno
		End Get
		Set (byval value as string)
			If _NomeInterno <> value Then
				IsChanged = True
				WhatIsChanged.NomeInterno = True
				_NomeInterno = value
			End If
		End Set
	End property 

	Protected _noResa as integer  = 0 
	Public Overridable Property noResa() as integer  Implements _IListinoBaseSource.noResa
		Get
			Return _noResa
		End Get
		Set (byval value as integer)
			If _noResa <> value Then
				IsChanged = True
				WhatIsChanged.noResa = True
				_noResa = value
			End If
		End Set
	End property 

	Protected _Ordinamento as integer  = 0 
	Public Overridable Property Ordinamento() as integer  Implements _IListinoBaseSource.Ordinamento
		Get
			Return _Ordinamento
		End Get
		Set (byval value as integer)
			If _Ordinamento <> value Then
				IsChanged = True
				WhatIsChanged.Ordinamento = True
				_Ordinamento = value
			End If
		End Set
	End property 

	Protected _p1 as Single  = 0 
	Public Overridable Property p1() as Single  Implements _IListinoBaseSource.p1
		Get
			Return _p1
		End Get
		Set (byval value as Single)
			If _p1 <> value Then
				IsChanged = True
				WhatIsChanged.p1 = True
				_p1 = value
			End If
		End Set
	End property 

	Protected _p2 as Single  = 0 
	Public Overridable Property p2() as Single  Implements _IListinoBaseSource.p2
		Get
			Return _p2
		End Get
		Set (byval value as Single)
			If _p2 <> value Then
				IsChanged = True
				WhatIsChanged.p2 = True
				_p2 = value
			End If
		End Set
	End property 

	Protected _p3 as Single  = 0 
	Public Overridable Property p3() as Single  Implements _IListinoBaseSource.p3
		Get
			Return _p3
		End Get
		Set (byval value as Single)
			If _p3 <> value Then
				IsChanged = True
				WhatIsChanged.p3 = True
				_p3 = value
			End If
		End Set
	End property 

	Protected _p4 as Single  = 0 
	Public Overridable Property p4() as Single  Implements _IListinoBaseSource.p4
		Get
			Return _p4
		End Get
		Set (byval value as Single)
			If _p4 <> value Then
				IsChanged = True
				WhatIsChanged.p4 = True
				_p4 = value
			End If
		End Set
	End property 

	Protected _p5 as Single  = 0 
	Public Overridable Property p5() as Single  Implements _IListinoBaseSource.p5
		Get
			Return _p5
		End Get
		Set (byval value as Single)
			If _p5 <> value Then
				IsChanged = True
				WhatIsChanged.p5 = True
				_p5 = value
			End If
		End Set
	End property 

	Protected _p6 as Single  = 0 
	Public Overridable Property p6() as Single  Implements _IListinoBaseSource.p6
		Get
			Return _p6
		End Get
		Set (byval value as Single)
			If _p6 <> value Then
				IsChanged = True
				WhatIsChanged.p6 = True
				_p6 = value
			End If
		End Set
	End property 

	Protected _PercAdatCostoCopia as integer  = 0 
	Public Overridable Property PercAdatCostoCopia() as integer  Implements _IListinoBaseSource.PercAdatCostoCopia
		Get
			Return _PercAdatCostoCopia
		End Get
		Set (byval value as integer)
			If _PercAdatCostoCopia <> value Then
				IsChanged = True
				WhatIsChanged.PercAdatCostoCopia = True
				_PercAdatCostoCopia = value
			End If
		End Set
	End property 

	Protected _PercMaxPromoFatturato as integer  = 0 
	Public Overridable Property PercMaxPromoFatturato() as integer  Implements _IListinoBaseSource.PercMaxPromoFatturato
		Get
			Return _PercMaxPromoFatturato
		End Get
		Set (byval value as integer)
			If _PercMaxPromoFatturato <> value Then
				IsChanged = True
				WhatIsChanged.PercMaxPromoFatturato = True
				_PercMaxPromoFatturato = value
			End If
		End Set
	End property 

	Protected _PercPromoAutomatico as integer  = 0 
	Public Overridable Property PercPromoAutomatico() as integer  Implements _IListinoBaseSource.PercPromoAutomatico
		Get
			Return _PercPromoAutomatico
		End Get
		Set (byval value as integer)
			If _PercPromoAutomatico <> value Then
				IsChanged = True
				WhatIsChanged.PercPromoAutomatico = True
				_PercPromoAutomatico = value
			End If
		End Set
	End property 

	Protected _PrendiIcoDa as integer  = 0 
	Public Overridable Property PrendiIcoDa() as integer  Implements _IListinoBaseSource.PrendiIcoDa
		Get
			Return _PrendiIcoDa
		End Get
		Set (byval value as integer)
			If _PrendiIcoDa <> value Then
				IsChanged = True
				WhatIsChanged.PrendiIcoDa = True
				_PrendiIcoDa = value
			End If
		End Set
	End property 

	Protected _qta1 as Single  = 0 
	Public Overridable Property qta1() as Single  Implements _IListinoBaseSource.qta1
		Get
			Return _qta1
		End Get
		Set (byval value as Single)
			If _qta1 <> value Then
				IsChanged = True
				WhatIsChanged.qta1 = True
				_qta1 = value
			End If
		End Set
	End property 

	Protected _qta2 as Single  = 0 
	Public Overridable Property qta2() as Single  Implements _IListinoBaseSource.qta2
		Get
			Return _qta2
		End Get
		Set (byval value as Single)
			If _qta2 <> value Then
				IsChanged = True
				WhatIsChanged.qta2 = True
				_qta2 = value
			End If
		End Set
	End property 

	Protected _qta3 as Single  = 0 
	Public Overridable Property qta3() as Single  Implements _IListinoBaseSource.qta3
		Get
			Return _qta3
		End Get
		Set (byval value as Single)
			If _qta3 <> value Then
				IsChanged = True
				WhatIsChanged.qta3 = True
				_qta3 = value
			End If
		End Set
	End property 

	Protected _qta4 as Single  = 0 
	Public Overridable Property qta4() as Single  Implements _IListinoBaseSource.qta4
		Get
			Return _qta4
		End Get
		Set (byval value as Single)
			If _qta4 <> value Then
				IsChanged = True
				WhatIsChanged.qta4 = True
				_qta4 = value
			End If
		End Set
	End property 

	Protected _qta5 as Single  = 0 
	Public Overridable Property qta5() as Single  Implements _IListinoBaseSource.qta5
		Get
			Return _qta5
		End Get
		Set (byval value as Single)
			If _qta5 <> value Then
				IsChanged = True
				WhatIsChanged.qta5 = True
				_qta5 = value
			End If
		End Set
	End property 

	Protected _qta6 as Single  = 0 
	Public Overridable Property qta6() as Single  Implements _IListinoBaseSource.qta6
		Get
			Return _qta6
		End Get
		Set (byval value as Single)
			If _qta6 <> value Then
				IsChanged = True
				WhatIsChanged.qta6 = True
				_qta6 = value
			End If
		End Set
	End property 

	Protected _qtacollo as integer  = 0 
	Public Overridable Property qtacollo() as integer  Implements _IListinoBaseSource.qtacollo
		Get
			Return _qtacollo
		End Get
		Set (byval value as integer)
			If _qtacollo <> value Then
				IsChanged = True
				WhatIsChanged.qtacollo = True
				_qtacollo = value
			End If
		End Set
	End property 

	Protected _QtaDefault as integer  = 0 
	Public Overridable Property QtaDefault() as integer  Implements _IListinoBaseSource.QtaDefault
		Get
			Return _QtaDefault
		End Get
		Set (byval value as integer)
			If _QtaDefault <> value Then
				IsChanged = True
				WhatIsChanged.QtaDefault = True
				_QtaDefault = value
			End If
		End Set
	End property 

	Protected _TipoControlloPrezzo as integer  = 0 
	Public Overridable Property TipoControlloPrezzo() as integer  Implements _IListinoBaseSource.TipoControlloPrezzo
		Get
			Return _TipoControlloPrezzo
		End Get
		Set (byval value as integer)
			If _TipoControlloPrezzo <> value Then
				IsChanged = True
				WhatIsChanged.TipoControlloPrezzo = True
				_TipoControlloPrezzo = value
			End If
		End Set
	End property 

	Protected _TipoPrezzo as integer  = 0 
	Public Overridable Property TipoPrezzo() as integer  Implements _IListinoBaseSource.TipoPrezzo
		Get
			Return _TipoPrezzo
		End Get
		Set (byval value as integer)
			If _TipoPrezzo <> value Then
				IsChanged = True
				WhatIsChanged.TipoPrezzo = True
				_TipoPrezzo = value
			End If
		End Set
	End property 

	Protected _v1 as decimal  = 0 
	Public Overridable Property v1() as decimal  Implements _IListinoBaseSource.v1
		Get
			Return _v1
		End Get
		Set (byval value as decimal)
			If _v1 <> value Then
				IsChanged = True
				WhatIsChanged.v1 = True
				_v1 = value
			End If
		End Set
	End property 

	Protected _v2 as decimal  = 0 
	Public Overridable Property v2() as decimal  Implements _IListinoBaseSource.v2
		Get
			Return _v2
		End Get
		Set (byval value as decimal)
			If _v2 <> value Then
				IsChanged = True
				WhatIsChanged.v2 = True
				_v2 = value
			End If
		End Set
	End property 

	Protected _v3 as decimal  = 0 
	Public Overridable Property v3() as decimal  Implements _IListinoBaseSource.v3
		Get
			Return _v3
		End Get
		Set (byval value as decimal)
			If _v3 <> value Then
				IsChanged = True
				WhatIsChanged.v3 = True
				_v3 = value
			End If
		End Set
	End property 

	Protected _v4 as decimal  = 0 
	Public Overridable Property v4() as decimal  Implements _IListinoBaseSource.v4
		Get
			Return _v4
		End Get
		Set (byval value as decimal)
			If _v4 <> value Then
				IsChanged = True
				WhatIsChanged.v4 = True
				_v4 = value
			End If
		End Set
	End property 

	Protected _v5 as decimal  = 0 
	Public Overridable Property v5() as decimal  Implements _IListinoBaseSource.v5
		Get
			Return _v5
		End Get
		Set (byval value as decimal)
			If _v5 <> value Then
				IsChanged = True
				WhatIsChanged.v5 = True
				_v5 = value
			End If
		End Set
	End property 

	Protected _v6 as decimal  = 0 
	Public Overridable Property v6() as decimal  Implements _IListinoBaseSource.v6
		Get
			Return _v6
		End Get
		Set (byval value as decimal)
			If _v6 <> value Then
				IsChanged = True
				WhatIsChanged.v6 = True
				_v6 = value
			End If
		End Set
	End property 

	Protected _VMotoreCalcolo as integer  = 0 
	Public Overridable Property VMotoreCalcolo() as integer  Implements _IListinoBaseSource.VMotoreCalcolo
		Get
			Return _VMotoreCalcolo
		End Get
		Set (byval value as integer)
			If _VMotoreCalcolo <> value Then
				IsChanged = True
				WhatIsChanged.VMotoreCalcolo = True
				_VMotoreCalcolo = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an ListinoBaseSource from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As ListinoBaseSource = Manager.Read(Id)
				_IdListinoBaseSource = int.IdListinoBaseSource
				_AbilitaQtaIntermedie = int.AbilitaQtaIntermedie
				_AbilitaQtaSottoColonna1 = int.AbilitaQtaSottoColonna1
				_AvviamStampa = int.AvviamStampa
				_AvviamStampa2 = int.AvviamStampa2
				_CalcolaAncheDaSolo = int.CalcolaAncheDaSolo
				_DefaultNFogli = int.DefaultNFogli
				_DescrSito = int.DescrSito
				_Disattivo = int.Disattivo
				_faccmax = int.faccmax
				_faccmin = int.faccmin
				_GoogleDescr = int.GoogleDescr
				_GoogleSEO = int.GoogleSEO
				_IdColoreStampa = int.IdColoreStampa
				_IdCurvaAtt = int.IdCurvaAtt
				_IdCurvaPubbl = int.IdCurvaPubbl
				_IdFormato = int.IdFormato
				_IdFormatoMacchina2 = int.IdFormatoMacchina2
				_IdFormProd = int.IdFormProd
				_IdHotFolderPostRefine = int.IdHotFolderPostRefine
				_IdMacchinarioProduzione = int.IdMacchinarioProduzione
				_IdMacchinarioProduzione2 = int.IdMacchinarioProduzione2
				_IdMacchinarioTaglio = int.IdMacchinarioTaglio
				_IdModelloCubetto = int.IdModelloCubetto
				_IdPrev = int.IdPrev
				_IdTipoCarta = int.IdTipoCarta
				_IdTipoCartaCop = int.IdTipoCartaCop
				_IdTipoCartaDorso = int.IdTipoCartaDorso
				_IdTipoImballo = int.IdTipoImballo
				_imgrif = int.imgrif
				_ImgSito = int.ImgSito
				_InEvidenza = int.InEvidenza
				_IsFormerChoice = int.IsFormerChoice
				_LabelWeb = int.LabelWeb
				_LargRotolo = int.LargRotolo
				_LastUpdate = int.LastUpdate
				_MinimaleStampa = int.MinimaleStampa
				_MinimaleStampa2 = int.MinimaleStampa2
				_MoltiplicatoreQta = int.MoltiplicatoreQta
				_MoltiplicatoreQta0 = int.MoltiplicatoreQta0
				_MoltiplicatoreQta2 = int.MoltiplicatoreQta2
				_MoltiplicatoreQta3 = int.MoltiplicatoreQta3
				_MoltiplicatoreQta4 = int.MoltiplicatoreQta4
				_MoltiplicatoreQta5 = int.MoltiplicatoreQta5
				_MoltiplicatoreQtaIntermedia = int.MoltiplicatoreQtaIntermedia
				_MostraPrezziTabella = int.MostraPrezziTabella
				_MultiploQta = int.MultiploQta
				_NascondiOnline = int.NascondiOnline
				_nofaccsuimpianti = int.nofaccsuimpianti
				_Nome = int.Nome
				_NomeInterno = int.NomeInterno
				_noResa = int.noResa
				_Ordinamento = int.Ordinamento
				_p1 = int.p1
				_p2 = int.p2
				_p3 = int.p3
				_p4 = int.p4
				_p5 = int.p5
				_p6 = int.p6
				_PercAdatCostoCopia = int.PercAdatCostoCopia
				_PercMaxPromoFatturato = int.PercMaxPromoFatturato
				_PercPromoAutomatico = int.PercPromoAutomatico
				_PrendiIcoDa = int.PrendiIcoDa
				_qta1 = int.qta1
				_qta2 = int.qta2
				_qta3 = int.qta3
				_qta4 = int.qta4
				_qta5 = int.qta5
				_qta6 = int.qta6
				_qtacollo = int.qtacollo
				_QtaDefault = int.QtaDefault
				_TipoControlloPrezzo = int.TipoControlloPrezzo
				_TipoPrezzo = int.TipoPrezzo
				_v1 = int.v1
				_v2 = int.v2
				_v3 = int.v3
				_v4 = int.v4
				_v5 = int.v5
				_v6 = int.v6
				_VMotoreCalcolo = int.VMotoreCalcolo
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdListinoBaseSource Then
            ris = Read(IdListinoBaseSource)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an ListinoBaseSource on DB.
	''' </summary>
	''' <returns>
	'''Return Id insert in DB if all ok, 0 if error
	''' </returns>
	Public Overridable Function Save() As Integer
		'Return the id Inserted
		Dim Ris As Integer = 0
		Try
			Using Manager
				Ris = Manager.Save(Me)
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True
		if _DescrSito.Length > 255 then Ris = False
		if _GoogleDescr.Length > 255 then Ris = False
		if _GoogleSEO.Length > 2000 then Ris = False
		if _imgrif.Length > 255 then Ris = False
		if _ImgSito.Length > 255 then Ris = False
		if _LabelWeb.Length > 255 then Ris = False
		if _LargRotolo.Length > 255 then Ris = False
		if _Nome.Length > 255 then Ris = False
		if _NomeInterno.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Listinobasesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IListinoBaseSource

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdListinoBaseSource() as integer
	Property AbilitaQtaIntermedie() as integer
	Property AbilitaQtaSottoColonna1() as integer
	Property AvviamStampa() as integer
	Property AvviamStampa2() as integer
	Property CalcolaAncheDaSolo() as integer
	Property DefaultNFogli() as integer
	Property DescrSito() as string
	Property Disattivo() as integer
	Property faccmax() as integer
	Property faccmin() as integer
	Property GoogleDescr() as string
	Property GoogleSEO() as string
	Property IdColoreStampa() as integer
	Property IdCurvaAtt() as integer
	Property IdCurvaPubbl() as integer
	Property IdFormato() as integer
	Property IdFormatoMacchina2() as integer
	Property IdFormProd() as integer
	Property IdHotFolderPostRefine() as integer
	Property IdMacchinarioProduzione() as integer
	Property IdMacchinarioProduzione2() as integer
	Property IdMacchinarioTaglio() as integer
	Property IdModelloCubetto() as integer
	Property IdPrev() as integer
	Property IdTipoCarta() as integer
	Property IdTipoCartaCop() as integer
	Property IdTipoCartaDorso() as integer
	Property IdTipoImballo() as integer
	Property imgrif() as string
	Property ImgSito() as string
	Property InEvidenza() as integer
	Property IsFormerChoice() as integer
	Property LabelWeb() as string
	Property LargRotolo() as string
	Property LastUpdate() as integer
	Property MinimaleStampa() as integer
	Property MinimaleStampa2() as integer
	Property MoltiplicatoreQta() as integer
	Property MoltiplicatoreQta0() as integer
	Property MoltiplicatoreQta2() as integer
	Property MoltiplicatoreQta3() as integer
	Property MoltiplicatoreQta4() as integer
	Property MoltiplicatoreQta5() as integer
	Property MoltiplicatoreQtaIntermedia() as integer
	Property MostraPrezziTabella() as integer
	Property MultiploQta() as integer
	Property NascondiOnline() as integer
	Property nofaccsuimpianti() as Boolean
	Property Nome() as string
	Property NomeInterno() as string
	Property noResa() as integer
	Property Ordinamento() as integer
	Property p1() as Single
	Property p2() as Single
	Property p3() as Single
	Property p4() as Single
	Property p5() as Single
	Property p6() as Single
	Property PercAdatCostoCopia() as integer
	Property PercMaxPromoFatturato() as integer
	Property PercPromoAutomatico() as integer
	Property PrendiIcoDa() as integer
	Property qta1() as Single
	Property qta2() as Single
	Property qta3() as Single
	Property qta4() as Single
	Property qta5() as Single
	Property qta6() as Single
	Property qtacollo() as integer
	Property QtaDefault() as integer
	Property TipoControlloPrezzo() as integer
	Property TipoPrezzo() as integer
	Property v1() as decimal
	Property v2() as decimal
	Property v3() as decimal
	Property v4() as decimal
	Property v5() as decimal
	Property v6() as decimal
	Property VMotoreCalcolo() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class ListinoBaseSource
		Public Shared ReadOnly Property IdListinoBaseSource As New LUNA.LunaFieldName("IdListinoBaseSource")
		Public Shared ReadOnly Property AbilitaQtaIntermedie As New LUNA.LunaFieldName("AbilitaQtaIntermedie")
		Public Shared ReadOnly Property AbilitaQtaSottoColonna1 As New LUNA.LunaFieldName("AbilitaQtaSottoColonna1")
		Public Shared ReadOnly Property AvviamStampa As New LUNA.LunaFieldName("AvviamStampa")
		Public Shared ReadOnly Property AvviamStampa2 As New LUNA.LunaFieldName("AvviamStampa2")
		Public Shared ReadOnly Property CalcolaAncheDaSolo As New LUNA.LunaFieldName("CalcolaAncheDaSolo")
		Public Shared ReadOnly Property DefaultNFogli As New LUNA.LunaFieldName("DefaultNFogli")
		Public Shared ReadOnly Property DescrSito As New LUNA.LunaFieldName("DescrSito")
		Public Shared ReadOnly Property Disattivo As New LUNA.LunaFieldName("Disattivo")
		Public Shared ReadOnly Property faccmax As New LUNA.LunaFieldName("faccmax")
		Public Shared ReadOnly Property faccmin As New LUNA.LunaFieldName("faccmin")
		Public Shared ReadOnly Property GoogleDescr As New LUNA.LunaFieldName("GoogleDescr")
		Public Shared ReadOnly Property GoogleSEO As New LUNA.LunaFieldName("GoogleSEO")
		Public Shared ReadOnly Property IdColoreStampa As New LUNA.LunaFieldName("IdColoreStampa")
		Public Shared ReadOnly Property IdCurvaAtt As New LUNA.LunaFieldName("IdCurvaAtt")
		Public Shared ReadOnly Property IdCurvaPubbl As New LUNA.LunaFieldName("IdCurvaPubbl")
		Public Shared ReadOnly Property IdFormato As New LUNA.LunaFieldName("IdFormato")
		Public Shared ReadOnly Property IdFormatoMacchina2 As New LUNA.LunaFieldName("IdFormatoMacchina2")
		Public Shared ReadOnly Property IdFormProd As New LUNA.LunaFieldName("IdFormProd")
		Public Shared ReadOnly Property IdHotFolderPostRefine As New LUNA.LunaFieldName("IdHotFolderPostRefine")
		Public Shared ReadOnly Property IdMacchinarioProduzione As New LUNA.LunaFieldName("IdMacchinarioProduzione")
		Public Shared ReadOnly Property IdMacchinarioProduzione2 As New LUNA.LunaFieldName("IdMacchinarioProduzione2")
		Public Shared ReadOnly Property IdMacchinarioTaglio As New LUNA.LunaFieldName("IdMacchinarioTaglio")
		Public Shared ReadOnly Property IdModelloCubetto As New LUNA.LunaFieldName("IdModelloCubetto")
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property IdTipoCarta As New LUNA.LunaFieldName("IdTipoCarta")
		Public Shared ReadOnly Property IdTipoCartaCop As New LUNA.LunaFieldName("IdTipoCartaCop")
		Public Shared ReadOnly Property IdTipoCartaDorso As New LUNA.LunaFieldName("IdTipoCartaDorso")
		Public Shared ReadOnly Property IdTipoImballo As New LUNA.LunaFieldName("IdTipoImballo")
		Public Shared ReadOnly Property imgrif As New LUNA.LunaFieldName("imgrif")
		Public Shared ReadOnly Property ImgSito As New LUNA.LunaFieldName("ImgSito")
		Public Shared ReadOnly Property InEvidenza As New LUNA.LunaFieldName("InEvidenza")
		Public Shared ReadOnly Property IsFormerChoice As New LUNA.LunaFieldName("IsFormerChoice")
		Public Shared ReadOnly Property LabelWeb As New LUNA.LunaFieldName("LabelWeb")
		Public Shared ReadOnly Property LargRotolo As New LUNA.LunaFieldName("LargRotolo")
		Public Shared ReadOnly Property LastUpdate As New LUNA.LunaFieldName("LastUpdate")
		Public Shared ReadOnly Property MinimaleStampa As New LUNA.LunaFieldName("MinimaleStampa")
		Public Shared ReadOnly Property MinimaleStampa2 As New LUNA.LunaFieldName("MinimaleStampa2")
		Public Shared ReadOnly Property MoltiplicatoreQta As New LUNA.LunaFieldName("MoltiplicatoreQta")
		Public Shared ReadOnly Property MoltiplicatoreQta0 As New LUNA.LunaFieldName("MoltiplicatoreQta0")
		Public Shared ReadOnly Property MoltiplicatoreQta2 As New LUNA.LunaFieldName("MoltiplicatoreQta2")
		Public Shared ReadOnly Property MoltiplicatoreQta3 As New LUNA.LunaFieldName("MoltiplicatoreQta3")
		Public Shared ReadOnly Property MoltiplicatoreQta4 As New LUNA.LunaFieldName("MoltiplicatoreQta4")
		Public Shared ReadOnly Property MoltiplicatoreQta5 As New LUNA.LunaFieldName("MoltiplicatoreQta5")
		Public Shared ReadOnly Property MoltiplicatoreQtaIntermedia As New LUNA.LunaFieldName("MoltiplicatoreQtaIntermedia")
		Public Shared ReadOnly Property MostraPrezziTabella As New LUNA.LunaFieldName("MostraPrezziTabella")
		Public Shared ReadOnly Property MultiploQta As New LUNA.LunaFieldName("MultiploQta")
		Public Shared ReadOnly Property NascondiOnline As New LUNA.LunaFieldName("NascondiOnline")
		Public Shared ReadOnly Property nofaccsuimpianti As New LUNA.LunaFieldName("nofaccsuimpianti")
		Public Shared ReadOnly Property Nome As New LUNA.LunaFieldName("Nome")
		Public Shared ReadOnly Property NomeInterno As New LUNA.LunaFieldName("NomeInterno")
		Public Shared ReadOnly Property noResa As New LUNA.LunaFieldName("noResa")
		Public Shared ReadOnly Property Ordinamento As New LUNA.LunaFieldName("Ordinamento")
		Public Shared ReadOnly Property p1 As New LUNA.LunaFieldName("p1")
		Public Shared ReadOnly Property p2 As New LUNA.LunaFieldName("p2")
		Public Shared ReadOnly Property p3 As New LUNA.LunaFieldName("p3")
		Public Shared ReadOnly Property p4 As New LUNA.LunaFieldName("p4")
		Public Shared ReadOnly Property p5 As New LUNA.LunaFieldName("p5")
		Public Shared ReadOnly Property p6 As New LUNA.LunaFieldName("p6")
		Public Shared ReadOnly Property PercAdatCostoCopia As New LUNA.LunaFieldName("PercAdatCostoCopia")
		Public Shared ReadOnly Property PercMaxPromoFatturato As New LUNA.LunaFieldName("PercMaxPromoFatturato")
		Public Shared ReadOnly Property PercPromoAutomatico As New LUNA.LunaFieldName("PercPromoAutomatico")
		Public Shared ReadOnly Property PrendiIcoDa As New LUNA.LunaFieldName("PrendiIcoDa")
		Public Shared ReadOnly Property qta1 As New LUNA.LunaFieldName("qta1")
		Public Shared ReadOnly Property qta2 As New LUNA.LunaFieldName("qta2")
		Public Shared ReadOnly Property qta3 As New LUNA.LunaFieldName("qta3")
		Public Shared ReadOnly Property qta4 As New LUNA.LunaFieldName("qta4")
		Public Shared ReadOnly Property qta5 As New LUNA.LunaFieldName("qta5")
		Public Shared ReadOnly Property qta6 As New LUNA.LunaFieldName("qta6")
		Public Shared ReadOnly Property qtacollo As New LUNA.LunaFieldName("qtacollo")
		Public Shared ReadOnly Property QtaDefault As New LUNA.LunaFieldName("QtaDefault")
		Public Shared ReadOnly Property TipoControlloPrezzo As New LUNA.LunaFieldName("TipoControlloPrezzo")
		Public Shared ReadOnly Property TipoPrezzo As New LUNA.LunaFieldName("TipoPrezzo")
		Public Shared ReadOnly Property v1 As New LUNA.LunaFieldName("v1")
		Public Shared ReadOnly Property v2 As New LUNA.LunaFieldName("v2")
		Public Shared ReadOnly Property v3 As New LUNA.LunaFieldName("v3")
		Public Shared ReadOnly Property v4 As New LUNA.LunaFieldName("v4")
		Public Shared ReadOnly Property v5 As New LUNA.LunaFieldName("v5")
		Public Shared ReadOnly Property v6 As New LUNA.LunaFieldName("v6")
		Public Shared ReadOnly Property VMotoreCalcolo As New LUNA.LunaFieldName("VMotoreCalcolo")
	End Class

End Class