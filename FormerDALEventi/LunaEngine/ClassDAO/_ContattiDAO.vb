#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.9.11 
'Author: Diego Lunadei
'Date: 26/09/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Contatto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ContattiDAO
Inherits LUNA.LunaBaseClassDAO(Of Contatto)

''' <summary>
'''New() create an istance of this class. Use default DB Connection
''' </summary>
Public Sub New()
	MyBase.New()
End Sub

''' <summary>
'''New() create an istance of this class and specify an OPENED DB connection
''' </summary>
Public Sub New(ByVal Connection As DbConnection)
	MyBase.New(Connection)
End Sub

''' <summary>
'''Read from DB table Contatti
''' </summary>
''' <returns>
'''Return a Contatto object
''' </returns>
Public Overrides Function Read(Id as integer) as Contatto
    Dim cls as new Contatto

    Try
        Using myCommand As DbCommand = _cn.CreateCommand
        
            myCommand.CommandText = "SELECT * FROM Contatti WHERE IdContatto = " & Id
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Using myReader As DbDataReader = myCommand.ExecuteReader

                myReader.Read()
                if myReader.HasRows then
                    cls.FillFromDataRecord(CType(myReader, IDataRecord))	
                End If
                myReader.Close()
            End Using
        End Using
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Contatti
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Contatto) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Using myCommand As DbCommand = _Cn.CreateCommand()
	            Try
		            Dim sql As String = String.Empty
		            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
		            If cls.IdContatto = 0 Then
                        sql = "INSERT INTO Contatti ("
                            sql &= " RagSoc,"
                            sql &= " Nominativo,"
                            sql &= " Email,"
                            sql &= " Cellulare,"
                            sql &= " DataIns,"
                            sql &= " Tag"
                      sql &= ") VALUES ("
                      sql &= " @RagSoc,"
                      sql &= " @Nominativo,"
                      sql &= " @Email,"
                      sql &= " @Cellulare,"
                      sql &= " @DataIns,"
                      sql &= " @Tag"
                      sql &= ")"
		            Else
			            sql = "UPDATE Contatti SET "
                  If cls.WhatIsChanged.RagSoc Then sql &= "RagSoc = @RagSoc,"
                  If cls.WhatIsChanged.Nominativo Then sql &= "Nominativo = @Nominativo,"
                  If cls.WhatIsChanged.Email Then sql &= "Email = @Email,"
                  If cls.WhatIsChanged.Cellulare Then sql &= "Cellulare = @Cellulare,"
                  If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
                  If cls.WhatIsChanged.Tag Then sql &= "Tag = @Tag"
						sql = sql.TrimEnd(",")
			            sql &= " WHERE IdContatto= " & cls.IdContatto
		            End if
					
					Dim p As DbParameter = Nothing 
					p = myCommand.CreateParameter
					p.ParameterName = "@RagSoc"
					p.Value = cls.RagSoc
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Nominativo"
					p.Value = cls.Nominativo
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Email"
					p.Value = cls.Email
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Cellulare"
					p.Value = cls.Cellulare
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@DataIns"
					p.Value = cls.DataIns
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Tag"
					p.Value = cls.Tag
  					myCommand.Parameters.Add(p)

                    myCommand.CommandType = CommandType.Text
		            myCommand.CommandText = sql
		            myCommand.ExecuteNonQuery()

		            
					If cls.IdContatto=0 Then
			            Dim IdInserito as integer = 0
			            Sql = "select @@identity"
			            myCommand.CommandText = Sql
			            Idinserito = myCommand.ExecuteScalar()
			            cls.IdContatto = Idinserito
			            Ris = Idinserito
		            else
			            Ris  =  cls.IdContatto
		            End If
		            

	            Catch ex As Exception
		            ManageError(ex)
	            End Try
            End Using
        else
	        Ris  =  cls.IdContatto
        End If

    Else
	    throw new ApplicationException("Object data is not valid")
    End If
    Return Ris
End Function

Private Sub DestroyPermanently(Id as integer) 
    Try

    Using myCommand As DbCommand = _Cn.CreateCommand
        myCommand.Connection = _cn

        '******IMPORTANT: You can use this commented instruction to make a logical delete .
        '******Replace DELETED Field with your logic deleted field name.
        'Dim Sql As String = "UPDATE Contatti SET DELETED=True "
        Dim Sql As String = "DELETE FROM Contatti"
        Sql &= " WHERE IdContatto = " & Id 

        myCommand.CommandText = Sql
        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
        myCommand.ExecuteNonQuery()
    
    End Using
    Catch ex As Exception
	    ManageError(ex)
    End Try
End Sub

''' <summary>
'''Delete from DB table Contatti. Accept id of object to delete.
''' </summary>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Contatti. Accept object to delete and optional a List to remove the object from.
''' </summary>
Public Overrides Sub Delete(byref obj as Contatto, Optional ByRef ListaObj as List (of Contatto) = Nothing)
        DestroyPermanently (obj.IdContatto)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return first of Contatto
''' </returns>
Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Contatto
    Dim ris As Contatto = Nothing
    Dim So As New LUNA.LunaSearchOption With {.Top = 1}
    Dim l As IEnumerable(Of Contatto) = FindReal(So, Parameter)
    If l.Count Then
        ris = l(0)
    End If
    Return ris
End Function

''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return first of Contatto
''' </returns>
Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Contatto
    Dim ris As Contatto = Nothing
    Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
    Dim l As IEnumerable(Of Contatto) = FindReal(So, Parameter)
    If l.Count Then
        ris = l(0)
    End If
    Return ris
End Function
''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return a list of Contatto
''' </returns>
Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Contatto)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return a list of Contatto
''' </returns>
Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Contatto)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return a list of Contatto
''' </returns>
Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Contatto)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

																																							  ''' <summary>
'''Find on DB table Contatti by custom query 
''' </summary>
''' <returns>
'''Return a list of Contatto
''' </returns>
Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Contatto)
     Dim Ls As New List(Of Contatto)
    Try
	 Ls = GetData(SQlQuery, AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

''' <summary>
'''Find on DB table Contatti
''' </summary>
''' <returns>
'''Return a list of Contatto
''' </returns>
Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Contatto)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Contatto)
    Dim Ls As New List(Of Contatto)
    Try

    Dim sql As String = ""
    sql ="SELECT "   
		if SearchOption.Top then sql &= " TOP " & SearchOption.Top
		sql &=" * FROM Contatti" 
    For Each Par As LUNA.LunaSearchParameter In Parameter
	    If Not Par Is Nothing Then
		    If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
		        sql &= Par.FieldName & " " & Par.SqlOperator
                If Par.SqlOperator.ToUpper.IndexOf("IN") <> -1 Then
                    sql &= " " & ApIn(Par.Value)
                Else
                    sql &= " " & Ap(Par.Value)
                End If
	    End if
    Next

    If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

	
    Ls = GetData(sql, SearchOption.AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Contatto)
    Dim Ls As New List(Of Contatto)
    Try

    Dim sql As String = ""
    sql ="SELECT * FROM Contatti" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Protected Overridable Property EmptyItemDescription As String = "Selezionare una voce"

Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Contatto)
    Dim Ls As New List(Of Contatto)
    Try
        Using myCommand As DbCommand = _Cn.CreateCommand
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Using myReader As DbDataReader = myCommand.ExecuteReader()
                If AddEmptyItem Then Ls.Add(New  Contatto() With {.IdContatto = 0 ,.RagSoc = "" ,.Nominativo = "" ,.Email = "" ,.Cellulare = "" ,.DataIns = "" ,.Tag = ""  })
                while myReader.Read
	                Dim classe as new Contatto(CType(myReader, IDataRecord))
	                Ls.Add(classe)
                end while
                myReader.Close()
            End Using
        End Using

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function
End Class
