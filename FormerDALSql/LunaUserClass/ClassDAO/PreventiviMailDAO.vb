#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 06/07/2016 
#End Region


Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Mailpreventivi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PreventiviMailDAO
    Inherits _PreventiviMailDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function CounterDaLavorare() As Integer
        Dim ris As Integer = 0

        Try

            Dim sql As String = ""
            sql = "select COUNT(IdMailPreventivo) as tot from MailPreventivi where IdMailRif=0 and Stato=" & enStatoPreventivoMail.DaLavorare

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader()
                    If myReader.Read Then
                        ris = myReader("tot")
                    End If
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris
    End Function

    Public Function ElencoMail(Optional Cerca As String = "",
                               Optional DataDal As Date = Nothing,
                               Optional DataAl As Date = Nothing,
                               Optional IdRub As Integer = 0,
                               Optional TipoMail As enTipoMail = enTipoMail.Preventivo,
                               Optional StatoMail As enStatoPreventivoMail = enStatoPreventivoMail.Qualsiasi,
                               Optional IndirizzoMail As String = "") As List(Of PreventivoMail)

        Dim ris As List(Of PreventivoMail) = Nothing

        'mgr.FindAll("DataRif", New LUNA.LunaSearchParameter("Stato", enStatoPreventivoMail.Eliminata, "<>"),
        'New LUNA.LunaSearchParameter("IdMailRif", 0))

        Dim sql As String = "SELECT * FROM MailPreventivi WHERE IdMailRif = 0 "

        If DataDal <> Date.MinValue Then
            sql &= " AND datediff(d,CONVERT(datetime,'" & DataDal.Day & "/" & DataDal.Month & "/" & DataDal.Year & "',103),datarif)>=0 "
        End If

        If DataAl <> Date.MinValue Then
            sql &= " AND datediff(d,datarif,'" & DataAl.Day & "/" & DataAl.Month & "/" & DataAl.Year & "')>=0 "
        End If

        If IdRub = 0 And IndirizzoMail.Length = 0 And Cerca.Length = 0 Then
            sql &= " AND Stato <> " & enStatoPreventivoMail.Eliminata
            If StatoMail <> enStatoPreventivoMail.Qualsiasi Then
                sql &= " AND Stato = " & StatoMail
            End If
        End If

        'If StatoMail <> enStatoPreventivoMail.Qualsiasi Then
        '    If IdRub = 0 And IndirizzoMail = "" Then
        '        sql &= " AND Stato = " & StatoMail
        '    End If
        'End If

        If Cerca.Length Then
            'serve la doppia select perche devo ricostruire la conversazione intera 
            'devo cercare nel testo della mail 
            'nel nome degli allegati
            'nel nome della mail del mittente
            'nel titolo della mail
            sql &= " AND GuidMail IN (SELECT DISTINCT guidmail FROM mailpreventivi p LEFT JOIN t_rubrica r ON p.idrub = r.idrub WHERE "

            If FormerLib.FormerHelper.Mail.IsValidEmailAddress(Cerca) Then

                sql &= " mittente = " & Ap(Cerca) & " OR "

            End If

            sql &= " titolo " & ApLike(Cerca) & " OR testo " & ApLike(Cerca) & ""

            sql &= " OR IdMailPreventivo IN (SELECT idmailpreventivo FROM MailPrevAttach WHERE nomefile " & ApLike(Cerca) & ")"

            sql &= " OR ragsoc " & ApLike(Cerca)

            sql &= " OR cognome " & ApLike(Cerca)

            sql &= ")"

        End If

        If IdRub Then

            sql &= " AND IdRub = " & IdRub

        End If

        If IndirizzoMail <> "" Then
            sql &= " AND mittente = " & Ap(IndirizzoMail)
        End If

        sql &= " AND TipoMail = " & TipoMail

        sql &= " ORDER BY DATARIF"

        ris = GetData(sql)

        Return ris

    End Function

    Public Sub AssegnaEmailaIdRub(Email As String,
                                  IdRub As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Mailpreventivi Set DELETED=True "
                Dim Sql As String = "UPDATE Mailpreventivi Set IdRub = " & IdRub & " WHERE Mittente = " & Ap(Email.Trim) & " And IdRub = 0 "

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function GetIdRubFromStorico(Mittente As String) As Integer
        Dim ris As Integer = 0

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = "SELECT DISTINCT IdRub FROM MailPreventivi WHERE mittente=" & Ap(Mittente) & " AND idrub <> 0"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        If ris = 0 Then
                            ris = myReader("IdRub")
                        Else
                            'qui non va bene ce ne sono piu di uno 
                            'non posso assegnarne nessuno
                            ris = 0
                            Exit While
                        End If
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris
    End Function

    Public Sub DeleteByGuid(Guid As String)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                Dim Sql As String = "UPDATE Mailpreventivi SET Stato = " & enStatoPreventivoMail.Eliminata
                'Dim Sql As String = "DELETE FROM Mailpreventivi"
                Sql &= " WHERE GuidMail = '" & Guid & "'"

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class