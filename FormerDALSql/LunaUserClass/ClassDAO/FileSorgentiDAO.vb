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
'''DAO Class for table T_sorgenti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FileSorgentiDAO
    Inherits _FileSorgentiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub AzzeraSorgentiRefine()

        Try
            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE T_sorgenti SET DELETED=True "
            Dim Sql As String = "UPDATE T_sorgenti SET StatoRefine = " & enStatoRefineSorgente.NonDefinito & " WHERE StatoRefine = " & enStatoRefineSorgente.InAttesaDiRefine
            Sql &= " AND IdOrd IN (SELECT IdOrd FROM T_Ordini WHERE STATO = " & enStatoOrdine.RefineAutomatico & ")"

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Sub DeleteByIdOrd(IdOrd As Integer)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE T_sorgenti SET DELETED=True "
            Dim Sql As String = "DELETE FROM T_sorgenti"
            Sql &= " Where IdOrd = " & IdOrd

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function CheckDimensioni(L As ListinoBase,
                                     FilePath As String,
                                     LarghezzaDallOrdine As Integer,
                                     AltezzaDallOrdine As Integer) As RisControlloDimensioniSorgente
        Dim Ris As New RisControlloDimensioniSorgente

        Ris.LarghezzaPrevista = LarghezzaDallOrdine
        Ris.AltezzaPrevista = AltezzaDallOrdine

        If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse
           L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
            Ris.LarghezzaPrevista = LarghezzaDallOrdine
            Ris.AltezzaPrevista = AltezzaDallOrdine
            If L.TipoUnitaMisuraInInput = enUnitaDiMisura.cm Then
                Ris.LarghezzaPrevista = LarghezzaDallOrdine * 10
                Ris.AltezzaPrevista = AltezzaDallOrdine * 10
            End If
            'Ris.LarghezzaPrevista = Ris.LarghezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 
            'Ris.AltezzaPrevista = Ris.AltezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 

        Else
            If L.AllowCustomSize = enSiNo.Si OrElse L.idGruppoLogico Then
                If LarghezzaDallOrdine <> 0 And AltezzaDallOrdine <> 0 Then
                    'qui arrivano gia in mm
                    Ris.LarghezzaPrevista = LarghezzaDallOrdine
                    Ris.AltezzaPrevista = AltezzaDallOrdine
                Else
                    Ris.LarghezzaPrevista = L.FormatoCarta.Larghezza
                    Ris.AltezzaPrevista = L.FormatoCarta.Altezza
                    Ris.LarghezzaPrevista = Ris.LarghezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 
                    Ris.AltezzaPrevista = Ris.AltezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri
                End If
            Else
                Ris.LarghezzaPrevista = L.FormatoCarta.Larghezza
                Ris.AltezzaPrevista = L.FormatoCarta.Altezza
                Ris.LarghezzaPrevista = Ris.LarghezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri 
                Ris.AltezzaPrevista = Ris.AltezzaPrevista * 10 'qui moltiplico per 10 perche sono espresse in centimetri e devo diventare millimetri
            End If

        End If


        If Ris.LarghezzaPrevista < Ris.AltezzaPrevista Then
            Dim tmp As Single = Ris.LarghezzaPrevista
            Ris.LarghezzaPrevista = Ris.AltezzaPrevista
            Ris.AltezzaPrevista = tmp
        End If
        'Ris.LarghezzaPrevista = IIf(Ris.LarghezzaPrevista > Ris.AltezzaPrevista, Ris.LarghezzaPrevista, Ris.AltezzaPrevista)
        'Ris.AltezzaPrevista = IIf(Ris.AltezzaPrevista < Ris.LarghezzaPrevista, Ris.AltezzaPrevista, Ris.LarghezzaPrevista)

        'For Each Sorg As FileSorgente In SingO.ListaSorgenti

        Dim dimensioniEffettive As System.Drawing.Size = FormerLib.FormerHelper.PDF.GetDimensioniTrimPagina(FilePath)

        If dimensioniEffettive.Width < dimensioniEffettive.Height Then
            Ris.LarghezzaRiscontrata = dimensioniEffettive.Height
            Ris.AltezzaRiscontrata = dimensioniEffettive.Width
        Else
            Ris.LarghezzaRiscontrata = dimensioniEffettive.Width
            Ris.AltezzaRiscontrata = dimensioniEffettive.Height
        End If

        'Ris.LarghezzaRiscontrata = IIf(dimensioniEffettive.Width > dimensioniEffettive.Height, dimensioniEffettive.Width, dimensioniEffettive.Height)
        'Ris.AltezzaRiscontrata = IIf(dimensioniEffettive.Height < dimensioniEffettive.Width, dimensioniEffettive.Height, dimensioniEffettive.Width)
        Dim diffW As Integer = Ris.LarghezzaRiscontrata - Ris.LarghezzaPrevista
        Dim diffH As Integer = Ris.AltezzaRiscontrata - Ris.AltezzaPrevista

        If diffW Then
            If diffW > 0 Then 'qui il file e' piu grande del formato carta
                If diffW > (L.FormatoCarta.TolleranzaEccesso * 2) Then Ris.ErroreDimensioni = True
            Else 'qui il file e' piu piccolo del formato carta
                If Math.Abs(diffW) > (L.FormatoCarta.TolleranzaDifetto * 2) Then Ris.ErroreDimensioni = True
            End If
        End If

        If Ris.ErroreDimensioni = False AndAlso diffH <> 0 Then
            If diffH > 0 Then 'qui il file e' piu grande del formato carta
                If diffH > (L.FormatoCarta.TolleranzaEccesso * 2) Then Ris.ErroreDimensioni = True
            Else 'qui il file e' piu piccolo del formato carta
                If Math.Abs(diffH) > (L.FormatoCarta.TolleranzaDifetto * 2) Then Ris.ErroreDimensioni = True
            End If
        End If

        Return Ris
    End Function


    Public Function CheckDimensioni(F As FileSorgente) As RisControlloDimensioniSorgente

        Return CheckDimensioni(F.Ordine.ListinoBase, F.FilePath, F.Ordine.Largo, F.Ordine.Lungo)

    End Function

End Class