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
Imports System.Data.Common
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_preventivazione
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PreventivazioniDAO
    Inherits _PreventivazioniDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = " - Tutti"

    Public Sub OrdinaListinoPerFormatoProd(ByRef Lst As List(Of ListinoBase))

        Lst.Sort(AddressOf Comparer)

    End Sub

    Private Function Comparer(x As ListinoBase, y As ListinoBase) As Integer

        Dim ris As Integer = x.Ordinamento.CompareTo(y.Ordinamento)
        If ris = 0 Then
            ris = x.FormatoProdotto.AreaCmQuadrati.CompareTo(y.FormatoProdotto.AreaCmQuadrati)
            If ris = 0 Then
                ris = x.FormatoProdotto.Orientamento.CompareTo(y.FormatoProdotto.Orientamento)
                If ris = 0 Then
                    ris = x.TipoCarta.Tipologia.CompareTo(y.TipoCarta.Tipologia)
                    If ris = 0 Then
                        ris = x.ColoreStampa.FR.CompareTo(y.ColoreStampa.FR)
                    End If
                End If
            End If
        End If
        Return ris
    End Function

    Public Function UseThisTipoCarta(IdPrev As Integer, IdTipoCarta As Integer) As Boolean
        Dim Ris As Boolean = False

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "SELECT * FROM t_listinobase where idtipocarta = " & IdTipoCarta & " and idprev = " & IdPrev
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader

                    myReader.Read()

                    If myReader.HasRows Then
                        Ris = True
                    End If

                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function
    Public Sub UpdateFile(IdRif As Integer, PathFile As String)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                Dim Sql As String = "UPDATE T_preventivazione SET ImgRif = " & LUNA.LunaTools.StringTools.Ap(PathFile) & " WHERE idprev = " & IdRif

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub
    Public Function ListaInCoda() As List(Of Preventivazione)
        Dim ris As List(Of Preventivazione)
        Dim sql As String = String.Empty

        sql = "select distinct p.* from T_preventivazione  p, T_Listinobase lb, t_ordini o, t_prodotti pr, T_Lavlog ll where p.idprev = lb.idprev and lb.idlistinobase = pr.IdListinoBase and pr.idprod = o.idprod and (ll.idord = o.idord or ll.idcom = o.idcom) and not ll.DataOraFine is null  order by idreparto , descrizione"

        ris = GetData(sql, True)

        Return ris

    End Function


    Public Function UseThisCatLav(IdPrev As Integer, IdCatLav As Integer) As Boolean
        Dim Ris As Boolean = False

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "select distinct l.* from t_listinobase l, Tr_lavprev lp, T_lavori lv where l.idprev = " & IdPrev & " and l.idlistinobase = lp.idlistinobase and lp.idlavoro = lv.idlavoro and lv.idcatlav = " & IdCatLav
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader

                    myReader.Read()

                    If myReader.HasRows Then
                        Ris = True
                    End If

                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    Public Function ResetGruppoVariante(IdGruppoVariante) As Integer
        Dim ris As Integer = 0

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "UPDATE T_Preventivazione SET GruppoVariante = 0 WHERE GruppoVariante = " & IdGruppoVariante
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris
    End Function

    Public Function NumeroOrdiniByIdRub(IdRub As Integer, IdPrev As Integer) As Integer
        Dim ris As Integer = 0

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "select count(*) as tot from T_ordini o, T_Prodotti p, T_listinoBase L where o.idprod=p.idprod and p.IdListinoBase = l.idlistinobase and l.idprev =" & IdPrev & " and o.idrub= " & IdRub
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader

                    myReader.Read()

                    ris = myReader("tot")

                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris
    End Function

    Public Function GetByIdRub(IdRub As Integer, Optional AddEmpty As Boolean = True) As IEnumerable(Of Preventivazione)

        Dim ris As List(Of Preventivazione)

        Dim Sql As String = String.Empty

        Sql = "select distinct pre.* from t_preventivazione pre, t_ordini o, t_prodotti p, t_listinobase l where o.idrub = " & IdRub & " and o.idprod = p.idprod and p.idlistinobase = l.idlistinobase and l.idprev = pre.idprev order by pre.descrizione"

        ris = GetData(Sql, AddEmpty)

        Return ris

    End Function


End Class


Public Class PreventivazioniValidatorDAO
    Inherits _PreventivazioniDAO

    Public Function GetAllPrevValidator() As List(Of PreventivazioneValidator)

        Dim Ls As New List(Of PreventivazioneValidator)
        Try

            Dim Sql As String = String.Empty

            Sql = "SELECT * from T_Preventivazione order by IDReparto, Descrizione"
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New PreventivazioneValidator(CType(myReader, IDataRecord))

                        Using mgrV As New ValidatorErrorLevelDAO

                            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", classe.IdPrev),
                                           New LUNA.LunaSearchParameter("ValidatorErrorCode", enValidatorErrorCode.DimensioniNonCorrette))
                                If Not vel Is Nothing Then
                                    classe.ErrorLevelDimensioniNonCorrette = vel.ValidatorErrorLevel
                                Else
                                    classe.ErrorLevelDimensioniNonCorrette = enValidatorErrorLevel.None
                                End If
                            End Using

                            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", classe.IdPrev),
                                            New LUNA.LunaSearchParameter("ValidatorErrorCode", enValidatorErrorCode.OrientamentoNonCorretto))
                                If Not vel Is Nothing Then
                                    classe.ErrorLevelOrientamentoNonCorretto = vel.ValidatorErrorLevel
                                Else
                                    classe.ErrorLevelOrientamentoNonCorretto = enValidatorErrorLevel.None
                                End If
                            End Using

                            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", classe.IdPrev),
                                           New LUNA.LunaSearchParameter("ValidatorErrorCode", enValidatorErrorCode.FontIncorporati))
                                If Not vel Is Nothing Then
                                    classe.ErrorLevelFontIncorporati = vel.ValidatorErrorLevel
                                Else
                                    classe.ErrorLevelFontIncorporati = enValidatorErrorLevel.None
                                End If
                            End Using

                            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", classe.IdPrev),
                                            New LUNA.LunaSearchParameter("ValidatorErrorCode", enValidatorErrorCode.FontNonIncorporati))
                                If Not vel Is Nothing Then
                                    classe.ErrorLevelFontNonIncorporati = vel.ValidatorErrorLevel
                                Else
                                    classe.ErrorLevelFontNonIncorporati = enValidatorErrorLevel.None
                                End If
                            End Using

                            Using vel As ValidatorErrorLevel = mgrV.Find(New LUNA.LunaSearchParameter("IdPreventivazione", classe.IdPrev),
                                            New LUNA.LunaSearchParameter("ValidatorErrorCode", enValidatorErrorCode.AbbondanzaErrata))
                                If Not vel Is Nothing Then
                                    classe.ErrorLevelAbbondanzaErrata = vel.ValidatorErrorLevel
                                Else
                                    classe.ErrorLevelAbbondanzaErrata = enValidatorErrorLevel.None
                                End If
                            End Using

                        End Using

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