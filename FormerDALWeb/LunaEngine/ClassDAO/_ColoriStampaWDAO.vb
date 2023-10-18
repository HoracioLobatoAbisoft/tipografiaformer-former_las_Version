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
'''This class manage persistency on db of ColoreStampaW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ColoriStampaWDAO
	Inherits LUNA.LunaBaseClassDAO(Of ColoreStampaW)

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
	'''Read from DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a ColoreStampaW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ColoreStampaW
		Dim cls as new ColoreStampaW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_coloristampa WHERE IdColoreStampa = " & Id
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
	'''Save on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ColoreStampaW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdColoreStampa = 0 Then
							sql = "INSERT INTO Td_coloristampa ("
							sql &= " Descrizione,"
							sql &= " FR,"
							sql &= " imgrif,"
							sql &= " NLastre,"
							sql &= " Sigla"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @FR,"
							sql &= " @imgrif,"
							sql &= " @NLastre,"
							sql &= " @Sigla"
							sql &= ")"
						Else
							sql = "UPDATE Td_coloristampa SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.FR Then sql &= "FR = @FR,"
							If cls.WhatIsChanged.imgrif Then sql &= "imgrif = @imgrif,"
							If cls.WhatIsChanged.NLastre Then sql &= "NLastre = @NLastre,"
							If cls.WhatIsChanged.Sigla Then sql &= "Sigla = @Sigla"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdColoreStampa= " & cls.IdColoreStampa
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FR Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FR"
							p.Value = cls.FR
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.imgrif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@imgrif"
							p.Value = cls.imgrif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NLastre Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NLastre"
							p.Value = cls.NLastre
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sigla Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sigla"
							p.Value = cls.Sigla
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdColoreStampa=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdColoreStampa = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdColoreStampa
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdColoreStampa
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
				'Dim Sql As String = "UPDATE Td_coloristampa SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_coloristampa"
				Sql &= " WHERE IdColoreStampa = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_coloristampa. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_coloristampa. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ColoreStampaW, Optional ByRef ListaObj as List (of ColoreStampaW) = Nothing)
		DestroyPermanently (obj.IdColoreStampa)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreStampaW
		Dim ris As ColoreStampaW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ColoreStampaW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return first of ColoreStampaW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreStampaW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return first of ColoreStampaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreStampaW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ColoreStampaW
	''' </summary>
	''' <returns>
	'''Return first of ColoreStampaW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ColoreStampaW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreStampaW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreStampaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreStampaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreStampaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ColoreStampaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ColoreStampaW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_coloristampa by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ColoreStampaW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreStampaW)
		Dim Ls As New List(Of ColoreStampaW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ColoreStampaW)
		Dim Ls As New List(Of ColoreStampaW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_coloristampa" 
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
	'''Return all record on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreStampaW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ColoreStampaW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreStampaW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreStampaW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_coloristampa
	''' </summary>
	''' <returns>
	'''Return all record in list of ColoreStampaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ColoreStampaW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreStampaW)
		Dim Ls As List(Of ColoreStampaW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_coloristampa" 
			If OrderByField.Length Then
				Sql &= " ORDER BY " & OrderByField
			End If
			Ls = GetData(Sql,AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

    Protected Overridable Property EmptyItemDescription As String = "-"

    Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ColoreStampaW)
		Dim Ls As New List(Of ColoreStampaW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ColoreStampaW() With {.IdColoreStampa = 0 ,.Descrizione = EmptyItemDescription,.FR = False ,.imgrif = "" ,.NLastre = 0 ,.Sigla = ""  })
					While myReader.Read
						Dim classe as new ColoreStampaW(CType(myReader, IDataRecord))
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