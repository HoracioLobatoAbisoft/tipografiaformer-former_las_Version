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
'''This class manage persistency on db of FormatoCartaW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _FormatiCartaWDAO
	Inherits LUNA.LunaBaseClassDAO(Of FormatoCartaW)

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
	'''Read from DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a FormatoCartaW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as FormatoCartaW
		Dim cls as new FormatoCartaW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_formatocarta WHERE IdFormCarta = " & Id
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
	'''Save on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as FormatoCartaW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdFormCarta = 0 Then
							sql = "INSERT INTO Td_formatocarta ("
							sql &= " Altezza,"
							sql &= " FormatoCarta,"
							sql &= " Larghezza,"
							sql &= " TolleranzaDifetto,"
							sql &= " TolleranzaEccesso"
							sql &= ") VALUES ("
							sql &= " @Altezza,"
							sql &= " @FormatoCarta,"
							sql &= " @Larghezza,"
							sql &= " @TolleranzaDifetto,"
							sql &= " @TolleranzaEccesso"
							sql &= ")"
						Else
							sql = "UPDATE Td_formatocarta SET "
							If cls.WhatIsChanged.Altezza Then sql &= "Altezza = @Altezza,"
							If cls.WhatIsChanged.FormatoCarta Then sql &= "FormatoCarta = @FormatoCarta,"
							If cls.WhatIsChanged.Larghezza Then sql &= "Larghezza = @Larghezza,"
							If cls.WhatIsChanged.TolleranzaDifetto Then sql &= "TolleranzaDifetto = @TolleranzaDifetto,"
							If cls.WhatIsChanged.TolleranzaEccesso Then sql &= "TolleranzaEccesso = @TolleranzaEccesso"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdFormCarta= " & cls.IdFormCarta
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Altezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Altezza"
							p.Value = cls.Altezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FormatoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FormatoCarta"
							p.Value = cls.FormatoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Larghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Larghezza"
							p.Value = cls.Larghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TolleranzaDifetto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TolleranzaDifetto"
							p.Value = cls.TolleranzaDifetto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TolleranzaEccesso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TolleranzaEccesso"
							p.Value = cls.TolleranzaEccesso
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdFormCarta=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdFormCarta = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdFormCarta
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdFormCarta
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
				'Dim Sql As String = "UPDATE Td_formatocarta SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_formatocarta"
				Sql &= " WHERE IdFormCarta = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_formatocarta. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_formatocarta. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as FormatoCartaW, Optional ByRef ListaObj as List (of FormatoCartaW) = Nothing)
		DestroyPermanently (obj.IdFormCarta)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoCartaW
		Dim ris As FormatoCartaW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of FormatoCartaW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return first of FormatoCartaW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoCartaW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return first of FormatoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoCartaW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table FormatoCartaW
	''' </summary>
	''' <returns>
	'''Return first of FormatoCartaW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoCartaW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoCartaW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of FormatoCartaW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatocarta by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of FormatoCartaW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoCartaW)
		Dim Ls As New List(Of FormatoCartaW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of FormatoCartaW)
		Dim Ls As New List(Of FormatoCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_formatocarta" 
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
	'''Return all record on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoCartaW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of FormatoCartaW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoCartaW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoCartaW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_formatocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoCartaW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FormatoCartaW)
		Dim Ls As List(Of FormatoCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_formatocarta" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FormatoCartaW)
		Dim Ls As New List(Of FormatoCartaW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  FormatoCartaW() With {.IdFormCarta = 0 ,.Altezza = 0 ,.FormatoCarta = "" ,.Larghezza = 0 ,.TolleranzaDifetto = 0 ,.TolleranzaEccesso = 0  })
					While myReader.Read
						Dim classe as new FormatoCartaW(CType(myReader, IDataRecord))
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