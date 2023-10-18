#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing

''' <summary>
'''Entity Class for table T_preventivi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Preventivo
    Inherits _Preventivo
    Implements IPreventivo

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub



#Region "Logic Field"
    Public ReadOnly Property CreaRiepilogoBreve()
        Get
            Dim bufferHtml As String = ""

            Dim _prevsel As Preventivo = Me

            bufferHtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

            'qui carico se ha immagini e in caso faccio il box incorniciato

            '            bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Ordine</CENTER></FONT><BR><BR>"

            Dim cli As New VoceRubrica
            cli.Read(_prevsel.IdRub)

            bufferHtml &= "Cliente:<BR> <FONT SIZE=2><B>" & IIf(cli.RagSocNome.Length, cli.RagSocNome & "<BR>", "") & IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<BR>", "") & cli.Indirizzo & "<BR>" & cli.Tel & IIf(cli.Cellulare.Length, "<BR>" & cli.Cellulare, "") & "</B></FONT><BR><BR>"

            cli = Nothing
            Dim strWidth As String = ""
            Try
                If File.Exists(_prevsel.Anteprima) Then
                    Dim x As Image = Image.FromFile(_prevsel.Anteprima)

                    If x.Width > x.Height Then
                        strWidth = " width=200 "
                    Else
                        strWidth = " height=200 "
                    End If
                End If


            Catch ex As Exception

            End Try

            bufferHtml &= "<A HREF=""" & _prevsel.Anteprima & """ target=""_new""><IMG SRC=""" & _prevsel.Anteprima & """ " & strWidth & " border=0></A><BR>"

            bufferHtml &= "<FONT SIZE=3><B>" & _prevsel.TipoLavoro & "</B><BR><BR>"

            bufferHtml &= "<FONT Face=Arial>"
            bufferHtml &= "<FONT FACE=Arial size=1>Codice <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Codice & "</B></FONT><BR>"
            bufferHtml &= "<FONT SIZE=1>Preventivo N: <FONT SIZE=2><b>" & _prevsel.Numero & "</B> del <FONT SIZE=2><b>" & _prevsel.DataIns.Date & "</b><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Qta <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Qta & "</B></FONT><BR>"

            bufferHtml &= "<FONT FACE=Arial size=1>Pagine <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Pagine & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Stampa <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Stampa & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Formato Aperto <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.FormatoAperto & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Formato Chiuso<FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.FormatoChiuso & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Carta <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Carta & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Lavorazioni <FONT FACE=Arial><FONT SIZE=2><B>" & _prevsel.Lavorazioni & "</B></FONT><BR>"

            Dim Corr As New Corriere
            Corr.Read(_prevsel.IdCorr)

            '            bufferHtml &= "<br><B>Trasporto:</B>: "
            bufferHtml &= "<FONT FACE=Arial size=1>Trasporto <FONT FACE=Arial><FONT SIZE=2><B>" & Corr.Descrizione & " </B></FONT><BR>"
            Corr = Nothing

            bufferHtml &= "<FONT FACE=Arial size=1>Prezzo <FONT FACE=Arial><FONT SIZE=2><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_prevsel.PrezzoNetto) & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Sconto <FONT FACE=Arial><FONT SIZE=2><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_prevsel.Sconto) & "</B></FONT><BR>"
            bufferHtml &= "<FONT FACE=Arial size=1>Iva <FONT FACE=Arial><FONT SIZE=2><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_prevsel.Iva) & "</B></FONT><BR>"
            If _prevsel.Anteprima.Length Then

                bufferHtml &= "<BR><FONT SIZE=2><B>File</B>:<BR>"
                bufferHtml &= "<FONT SIZE=1>Anteprima: <FONT SIZE=1 face=Arial><b><A HREF=""" & _prevsel.Anteprima.ToString & """ target=""_new"">" & _prevsel.Anteprima & "</A></b><BR>"

            End If

            If _prevsel.Risposto Then

                bufferHtml &= "<BR><FONT SIZE=2><B>Risposto</B>:<BR>"
                bufferHtml &= "<FONT SIZE=1>" & _prevsel.TestoRisp & "<BR>"

            End If


            'bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

            Return bufferHtml
        End Get
    End Property

    Public ReadOnly Property CreaRiepilogoMail()
        Get
            Dim bufferHtml As String = ""

            Dim _prevsel As Preventivo = Me

            bufferHtml = "In riferimento alla vostra richiesta di preventivo qui sotto riepilogata " & ControlChars.NewLine & ControlChars.NewLine

            bufferHtml &= "Tipolavoro: " & _prevsel.TipoLavoro & ControlChars.NewLine


            bufferHtml &= "Preventivo N: " & _prevsel.Numero & " del " & _prevsel.DataIns.Date & ControlChars.NewLine

            bufferHtml &= "Qta: " & _prevsel.Qta & ControlChars.NewLine
            bufferHtml &= "Pagine: " & _prevsel.Pagine & ControlChars.NewLine
            bufferHtml &= "Stampa: " & _prevsel.Stampa & ControlChars.NewLine
            bufferHtml &= "Formato Aperto: " & _prevsel.FormatoAperto & ControlChars.NewLine
            bufferHtml &= "Formato Chiuso: " & _prevsel.FormatoChiuso & ControlChars.NewLine
            bufferHtml &= "Carta: " & _prevsel.Carta & ControlChars.NewLine
            bufferHtml &= "Lavorazioni: " & _prevsel.Lavorazioni & ControlChars.NewLine

            Dim Corr As New Corriere
            Corr.Read(_prevsel.IdCorr)

            '            bufferHtml &= "<br><B>Trasporto:</B>: "
            bufferHtml &= "Corriere: " & Corr.Descrizione & ControlChars.NewLine
            Corr = Nothing


            'bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

            Return bufferHtml
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPreventivo.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPreventivo.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPreventivo.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_preventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPreventivo
    Inherits _IPreventivo

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface