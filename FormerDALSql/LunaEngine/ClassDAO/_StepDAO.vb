#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.37 
'Author: Diego Lunadei
'Date: 20/12/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Step object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _StepDAO
Inherits LUNA.LunaBaseClassDAO(Of Step)

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
    '''Read from DB table T_step
    ''' </summary>
    ''' <returns>
    '''Return a Step object
    ''' </returns>
    Public Overrides Function Read(Id As Integer) As [Step]
        Dim cls As New [Step]

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand

                myCommand.CommandText = "SELECT * FROM T_step WHERE IdStep = " & Id
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader

                    myReader.Read()
                    If myReader.HasRows Then
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
    '''Save on DB table T_step
    ''' </summary>
    ''' <returns>
    '''Return ID insert in DB
    ''' </returns>
    Public Overrides Function Save(byRef cls as Step) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Using myCommand As DbCommand = _Cn.CreateCommand()
	            Try
		            Dim sql As String = String.Empty
		            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
		            If cls.IdStep = 0 Then
                        sql = "INSERT INTO T_step ("
                            sql &= " IdProcedura,"
                            sql &= " Titolo,"
                            sql &= " Testo,"
                            sql &= " FilePath,"
                            sql &= " Ordine"
                      sql &= ") VALUES ("
                      sql &= " @IdProcedura,"
                      sql &= " @Titolo,"
                      sql &= " @Testo,"
                      sql &= " @FilePath,"
                      sql &= " @Ordine"
                      sql &= ")"
		            Else
			            sql = "UPDATE T_step SET "
                  If cls.WhatIsChanged.IdProcedura Then sql &= "IdProcedura = @IdProcedura,"
                  If cls.WhatIsChanged.Titolo Then sql &= "Titolo = @Titolo,"
                  If cls.WhatIsChanged.Testo Then sql &= "Testo = @Testo,"
                  If cls.WhatIsChanged.FilePath Then sql &= "FilePath = @FilePath,"
                  If cls.WhatIsChanged.Ordine Then sql &= "Ordine = @Ordine"
						sql = sql.TrimEnd(",")
			            sql &= " WHERE IdStep= " & cls.IdStep
		            End if
					
					Dim p As DbParameter = Nothing 
					p = myCommand.CreateParameter
					p.ParameterName = "@IdProcedura"
					p.Value = cls.IdProcedura
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Titolo"
					p.Value = cls.Titolo
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Testo"
					p.Value = cls.Testo
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@FilePath"
					p.Value = cls.FilePath
  					myCommand.Parameters.Add(p)

					p = myCommand.CreateParameter
					p.ParameterName = "@Ordine"
					p.Value = cls.Ordine
  					myCommand.Parameters.Add(p)

                    myCommand.CommandType = CommandType.Text
		            myCommand.CommandText = sql
		            myCommand.ExecuteNonQuery()

		            
					If cls.IdStep=0 Then
			            Dim IdInserito as integer = 0
			            Sql = "select @@identity"
			            myCommand.CommandText = Sql
			            Idinserito = myCommand.ExecuteScalar()
			            cls.IdStep = Idinserito
			            Ris = Idinserito
		            else
			            Ris  =  cls.IdStep
		            End If
		            

	            Catch ex As Exception
		            ManageError(ex)
	            End Try
            End Using
        else
	        Ris  =  cls.IdStep
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
        'Dim Sql As String = "UPDATE T_step SET DELETED=True "
        Dim Sql As String = "DELETE FROM T_step"
        Sql &= " WHERE IdStep = " & Id 

        myCommand.CommandText = Sql
        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
        myCommand.ExecuteNonQuery()
    
    End Using
    Catch ex As Exception
	    ManageError(ex)
    End Try
End Sub

''' <summary>
'''Delete from DB table T_step. Accept id of object to delete.
''' </summary>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table T_step. Accept object to delete and optional a List to remove the object from.
''' </summary>
Public Overrides Sub Delete(byref obj as Step, Optional ByRef ListaObj as List (of Step) = Nothing)
        DestroyPermanently (obj.IdStep)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return first of Step
''' </returns>
Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Step
    Dim ris As Step = Nothing
    Dim So As New LUNA.LunaSearchOption With {.Top = 1}
    Dim l As IEnumerable(Of Step) = FindReal(So, Parameter)
    If l.Count Then
        ris = l(0)
    End If
    Return ris
End Function

''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return first of Step
''' </returns>
Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Step
    Dim ris As Step = Nothing
    Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
    Dim l As IEnumerable(Of Step) = FindReal(So, Parameter)
    If l.Count Then
        ris = l(0)
    End If
    Return ris
End Function
''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return a list of Step
''' </returns>
Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Step)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return a list of Step
''' </returns>
Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Step)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return a list of Step
''' </returns>
Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Step)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

																																							  ''' <summary>
'''Find on DB table T_step by custom query 
''' </summary>
''' <returns>
'''Return a list of Step
''' </returns>
Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Step)
     Dim Ls As New List(Of Step)
    Try
	 Ls = GetData(SQlQuery, AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

''' <summary>
'''Find on DB table T_step
''' </summary>
''' <returns>
'''Return a list of Step
''' </returns>
Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Step)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Step)
    Dim Ls As New List(Of Step)
    Try

    Dim sql As String = ""
    sql ="SELECT "   
		if SearchOption.Top then sql &= " TOP " & SearchOption.Top
		sql &=" * FROM T_step" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Step)
    Dim Ls As New List(Of Step)
    Try

    Dim sql As String = ""
    sql ="SELECT * FROM T_step" 
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

Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Step)
    Dim Ls As New List(Of Step)
    Try
        Using myCommand As DbCommand = _Cn.CreateCommand
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Using myReader As DbDataReader = myCommand.ExecuteReader()
                If AddEmptyItem Then Ls.Add(New  Step() With {.IdStep = 0 ,.IdProcedura = 0 ,.Titolo = "" ,.Testo = "" ,.FilePath = "" ,.Ordine = 0  })
                while myReader.Read
	                Dim classe as new Step(CType(myReader, IDataRecord))
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
