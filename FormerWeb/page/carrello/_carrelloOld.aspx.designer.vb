'------------------------------------------------------------------------------
' <generato automaticamente>
'     Codice generato da uno strumento.
'
'     Le modifiche a questo file possono causare un comportamento non corretto e verranno perse se
'     il codice viene rigenerato. 
' </generato automaticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class pCarrelloOld

    '''<summary>
    '''Controllo lnkSvuota.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents lnkSvuota As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Controllo rptOrdini.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents rptOrdini As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Controllo PannelloDinamico.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents PannelloDinamico As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Controllo rdoCorr.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents rdoCorr As Global.System.Web.UI.WebControls.RadioButtonList

    '''<summary>
    '''Controllo pnlSelectIndirizzo.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents pnlSelectIndirizzo As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Controllo ddlIndirizzo.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents ddlIndirizzo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Controllo lnkAddInd.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents lnkAddInd As Global.System.Web.UI.HtmlControls.HtmlAnchor

    '''<summary>
    '''Controllo pnlIndRitiro.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents pnlIndRitiro As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Controllo lblInfoCorr.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents lblInfoCorr As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Controllo pnlCouponCarrello.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents pnlCouponCarrello As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Controllo txtCoupon.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents txtCoupon As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Controllo btnCoupon.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents btnCoupon As Global.System.Web.UI.WebControls.ImageButton

    '''<summary>
    '''Controllo pnlRisCoupon.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents pnlRisCoupon As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Controllo lblRisCoupon.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents lblRisCoupon As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Controllo rdoPagam.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents rdoPagam As Global.System.Web.UI.WebControls.RadioButtonList

    '''<summary>
    '''Controllo lblDataCons.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents lblDataCons As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Controllo btnOrdina.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents btnOrdina As Global.System.Web.UI.WebControls.ImageButton

    '''<summary>
    '''Controllo btnSvuota.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents btnSvuota As Global.System.Web.UI.WebControls.ImageButton

    '''<summary>
    '''Controllo btnIndietroCarr.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents btnIndietroCarr As Global.System.Web.UI.WebControls.ImageButton

    '''<summary>
    '''Controllo UpdateProgress1.
    '''</summary>
    '''<remarks>
    '''Campo generato automaticamente.
    '''Per la modifica, spostare la dichiarazione di campo dal file di progettazione al file code-behind.
    '''</remarks>
    Protected WithEvents UpdateProgress1 As Global.System.Web.UI.UpdateProgress
End Class
