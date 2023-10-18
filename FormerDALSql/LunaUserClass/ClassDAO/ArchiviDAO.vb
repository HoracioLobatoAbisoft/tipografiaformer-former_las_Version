#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.6.16 
'Author: Diego Lunadei
'Date: 26/06/2017 
#End Region


Imports System.Data.Common
Imports FormerLib

''' <summary>
'''DAO Class for table Archivi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ArchiviDAO
    Inherits _ArchiviDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function Lista(DataDal As Date,
                          DataAl As Date) As List(Of Archiviato)
        Dim ris As List(Of Archiviato) = Nothing

        Dim sql As String = "SELECT * FROM Archivi WHERE "

        sql &= " datediff(d," & FormerHelper.Stringhe.FormattaDataPerSQL(DataDal) & ",datains)>=0 "

        sql &= " AND datediff(d,datains," & FormerHelper.Stringhe.FormattaDataPerSQL(DataAl) & ")>=0 "

        ris = GetData(sql)

        Return ris

    End Function

End Class