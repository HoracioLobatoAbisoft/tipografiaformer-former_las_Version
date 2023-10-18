#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Faq object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _FaqDAO
	Inherits LUNA.LunaBaseClassDAO(Of Faq)

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
	'''Read from DB table Faq
	''' </summary>
	''' <returns>
	'''Return a Faq object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Faq
		Dim cls as new Faq

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Faq WHERE IDFaq = " & Id
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
	'''Save on DB table Faq
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Faq) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IDFaq = 0 Then
							sql = "INSERT INTO Faq ("
							sql &= " IDFaq,"
							sql &= " Domanda,"
							sql &= " IDArgomento,"
							sql &= " IDReparto,"
							sql &= " Ordine,"
							sql &= " Risposta"
							sql &= ") VALUES ("
							sql &= " @IDFaq,"
							sql &= " @Domanda,"
							sql &= " @IDArgomento,"
							sql &= " @IDReparto,"
							sql &= " @Ordine,"
							sql &= " @Risposta"
							sql &= ")"
						Else
							sql = "UPDATE Faq SET "
							If cls.WhatIsChanged.IDFaq Then sql &= "IDFaq = @IDFaq,"
							If cls.WhatIsChanged.Domanda Then sql &= "Domanda = @Domanda,"
							If cls.WhatIsChanged.IDArgomento Then sql &= "IDArgomento = @IDArgomento,"
							If cls.WhatIsChanged.IDReparto Then sql &= "IDReparto = @IDReparto,"
							If cls.WhatIsChanged.Ordine Then sql &= "Ordine = @Ordine,"
							If cls.WhatIsChanged.Risposta Then sql &= "Risposta = @Risposta"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IDFaq= " & cls.IDFaq
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IDFaq Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IDFaq"
							p.Value = cls.IDFaq
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Domanda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Domanda"
							p.Value = cls.Domanda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IDArgomento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IDArgomento"
							p.Value = cls.IDArgomento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IDReparto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IDReparto"
							p.Value = cls.IDReparto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Ordine Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Ordine"
							p.Value = cls.Ordine
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Risposta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Risposta"
							p.Value = cls.Risposta
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

						Ris = cls.IDFaq
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IDFaq
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
				'Dim Sql As String = "UPDATE Faq SET DELETED=True "
				Dim Sql As String = "DELETE FROM Faq"
				Sql &= " WHERE IDFaq = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Faq. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Faq. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Faq, Optional ByRef ListaObj as List (of Faq) = Nothing)
		DestroyPermanently (obj.IDFaq)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Faq
		Dim ris As Faq = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Faq) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Faq
	''' </summary>
	''' <returns>
	'''Return first of Faq
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Faq
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Faq
	''' </summary>
	''' <returns>
	'''Return first of Faq
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Faq
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Faq
	''' </summary>
	''' <returns>
	'''Return first of Faq
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Faq
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Faq)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Faq)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Faq)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Faq)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Faq)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq
	''' </summary>
	''' <returns>
	'''Return a list of Faq
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Faq)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Faq by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Faq by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Faq)
		Dim Ls As New List(Of Faq)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Faq)
		Dim Ls As New List(Of Faq)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Faq" 
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

	''' <summary>
	'''Return all record on DB table Faq
	''' </summary>
	''' <returns>
	'''Return all record in list of Faq
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Faq)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Faq
	''' </summary>
	''' <returns>
	'''Return all record in list of Faq
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Faq)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Faq
	''' </summary>
	''' <returns>
	'''Return all record in list of Faq
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Faq)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Faq)
		Dim Ls As List(Of Faq)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Faq" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Faq)
		Dim Ls As New List(Of Faq)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Faq() With {.IDFaq = 0 ,.Domanda = "" ,.IDArgomento = 0 ,.IDReparto = 0 ,.Ordine = 0 ,.Risposta = ""  })
					While myReader.Read
						Dim classe as new Faq(CType(myReader, IDataRecord))
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