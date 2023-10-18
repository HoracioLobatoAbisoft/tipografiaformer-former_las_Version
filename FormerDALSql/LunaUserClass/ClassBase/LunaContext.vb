#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.10.5.13 
'Author: Diego Lunadei
'Date: 13/05/2014 
#End Region

Imports FormerLib.FormerEnum

Namespace LUNA
    Public Class LunaContext

        Public Sub New()
            MyBase.New()

        End Sub

        Public Shared Property IsolationLevel As Data.IsolationLevel = IsolationLevel.ReadUncommitted 'IsolationLevel.Snapshot

        Public Shared ReadOnly Property OldDbConnection As IDbConnection
            Get
                Dim ris As IDbConnection = Nothing
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then
                    ris = LUNA.LunaContext.TransactionBox.DbConnection
                Else
                    ris = LUNA.LunaContext.Connection
                End If
                Return ris
            End Get
        End Property

        Private Shared _IdUtenteConnesso As Integer = 0
        'Friend Shared ReadOnly Property IdUtenteConnesso As Integer
        '    Get
        '        Return _IdUtenteConnesso
        '    End Get
        'End Property

        Private Shared _TipoUtenteConnesso As enTipoUtente = enTipoUtente.Operatore
        'Friend Shared ReadOnly Property TipoUtenteConnesso As enTipoUtente
        '    Get
        '        Return _TipoUtenteConnesso
        '    End Get
        'End Property

        Private Shared _UtenteConnesso As Utente
        Friend Shared ReadOnly Property UtenteConnesso As Utente
            Get
                If _UtenteConnesso Is Nothing Then

                    'mi auto invio una email 
                    'FormerLib.FormerHelper.Mail.InviaMail("Errore UtenteConnesso non disponibile ", "Utente connesso non disponibile", "soft@tipografiaformer.it")
                    'questo solo per non mandarlo inerrore
                    _UtenteConnesso = New Utente

                End If

                Return _UtenteConnesso
            End Get
        End Property

        Public Shared Sub SetUtenteConnesso(ByVal Utente As Utente)
            _UtenteConnesso = Utente
            _IdUtenteConnesso = Utente.IdUt
            _TipoUtenteConnesso = Utente.Tipo
        End Sub

    End Class

End Namespace