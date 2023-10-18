Imports FormerLib.FormerEnum

Public Class ParametriCreazioneSoluzione

    Public Property MotoreScelto As enMotoreCalcoloSoluzioni

    Public Property IdMacchinario As Integer = 0
    'Public Property TieniContoRating As Boolean = False
    'Public Property TieniContoLavorazioniEsclusive As Boolean = False

    Public Property RielaboraSolitariInCommesseSimili As Boolean = False 'DEPRECATO
    Public Property MaxDuplicazioneSingoloOrdine As Integer = 10
    Public Property NonMostrareTutteleCombinazioni As Boolean = True
    Public Property PermettiQtaMinoreOrdini As Boolean = False
    Public Property ProvaEscludereOrdiniPerRaddoppiareSpazi As Boolean = False
    Public Property CreazioneAutomaticaCommesse As Boolean = False
    Public Property UtilizzaSoloMacchinarioDefault As Boolean = False
    Public Property TagliaCombinazioniSottoXPercento As Boolean = False
    Public Property SoloSoluzioniOttimali As Boolean = False
    Public Property UtilizzaSoloFormatiCarta As Boolean = False
    Public Property AccorpaCommesse As Boolean = True
    Public Property UtilizzaCalcoloVeloce As Boolean = False

    Public Property UtilizzaAncheFormatiCarta As Boolean = False

    Public Property IdModelloCommessa As Integer = 0

    Public Property SelezionaMacchinarioInBaseACostoDiProduzione As Boolean = True

End Class