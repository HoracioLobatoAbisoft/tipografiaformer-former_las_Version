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
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_utenti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class UtentiDAO
    Inherits _UtentiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare un utente"

    Public Function LoginUt(Login As String, Pwd As String) As Utente

        Dim Ris As Utente = Nothing

        Dim lst As List(Of Utente) = FindAll(New LUNA.LunaSearchParameter("Login", Login), _
                                          New LUNA.LunaSearchParameter("Pwd", Pwd))
        If lst.Count Then
            Ris = lst(0)
        End If

        Return Ris

    End Function

    Public Function LoginUt(U As Utente) As Utente

        Dim Ris As Utente = Nothing

        Dim lst As List(Of Utente) = FindAll(New LUNA.LunaSearchParameter("Login", U.Login), _
                                          New LUNA.LunaSearchParameter("Pwd", U.Pwd))
        If lst.Count Then
            Ris = lst(0)
        End If

        Return Ris

    End Function

    Public Function ElencoLavori(IdUt As Integer, ByVal Mese As Integer, ByVal Anno As Integer) As DataTable

        Dim dt As New DataTable
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim Sql As String = ""

            Sql = "SELECT DataOraInizio as Data,IdCom as Commessa,IdOrd as Ordine,Tempo as [Tempo Disp], "
            Sql &= " datediff(n,DataOraInizio,DataOraFine) as [Tempo Imp],"
            Sql &= "Descrizione, "
            'TODO: 15/05/2014 DISATTIVATI BONUS NEL PASSAGGIO A SQL SERVER 
            Sql &= "0 as Bonus "
            'Sql &= " iif(DataOraFine, iif(datediff(n,DataOraInizio,DataOraFine)>Tempo,- Premio , Premio),'0') as Bonus "
            Sql &= " FROM T_LavLog where IdUt = " & IdUt
            Sql &= " AND month(dataorainizio) = " & Mese
            Sql &= " AND Year(dataorainizio) = " & Anno

            myCommand.CommandText = Sql

            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            dt.Load(myReader)

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return dt

    End Function

    'Public Function CalcolaBonus(IdUt As Integer, Optional Mese As Integer = 0, Optional ByVal Anno As Integer = 0) As Double

    '    Dim Ris As Double = 0
    '    If Mese = 0 Then
    '        Mese = Month(Now)
    '    End If
    '    If Anno = 0 Then
    '        Anno = Year(Now)
    '    End If

    '    Try

    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
    '        Dim Sql As String = ""

    '        Sql = "SELECT * FROM T_LavLog where IdUt = " & IdUt
    '        Sql &= " AND month(dataorainizio)=" & Mese
    '        Sql &= " AND year(dataorainizio)=" & Anno
    '        Sql &= " AND not dataorafine is null "

    '        myCommand.CommandText = Sql

    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

    '        While myReader.Read()

    '            If DateDiff(DateInterval.Minute, myReader("dataorainizio"), myReader("dataorafine")) <= myReader("Tempo") Then
    '                Ris += myReader("Premio")
    '            Else
    '                Ris -= myReader("Premio")
    '            End If

    '        End While

    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)

    '    End Try

    '    Return Ris

    'End Function

    Public Function NotUnique(U As Utente) As Boolean
        Dim ris As Boolean = False

        Try
            Dim lst As List(Of Utente) = FindAll(New LUNA.LunaSearchParameter("Login", U.Login), New LUNA.LunaSearchParameter("Idut", U.IdUt, "<>"))
            If lst.Count Then
                ris = True
            End If
        Catch ex As Exception
            ManageError(ex)

        End Try

        Return ris

    End Function

    Public Function NonInElenco(ListaIdUt As String) As IEnumerable(Of Utente)
        Dim Ls As New List(Of Utente)
        Try

            Dim sql As String = ""
            sql = "SELECT IdUt," & _
                "Login," & _
                "Pwd," & _
                "NomeReale," & _
                "RepDefault," & _
                "Attivo," & _
                "Tipo"
            sql &= " from T_utenti"
            sql &= " WHERE ATTIVO = TRUE AND (IDUT NOT IN (" & ListaIdUt & ")) and TIPO = " & enTipoUtente.Operatore

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function
End Class