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
'''This class manage persistency on db of Localita object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _LocalitaDAO
	Inherits LUNA.LunaBaseClassDAO(Of Localita)

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
	'''Read from DB table Localita
	''' </summary>
	''' <returns>
	'''Return a Localita object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Localita
		Dim cls as new Localita

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Localita WHERE IdLocalita = " & Id
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
	'''Save on DB table Localita
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Localita) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLocalita = 0 Then
							sql = "INSERT INTO Localita ("
							sql &= " IdLocalita,"
							sql &= " ALTITUDINE,"
							sql &= " CENTRO,"
							sql &= " IdComune,"
							sql &= " IdProvincia,"
							sql &= " IdRegione,"
							sql &= " loc,"
							sql &= " localita,"
							sql &= " POP2001,"
							sql &= " TIPO_LOC,"
							sql &= " xcoord,"
							sql &= " ycoord"
							sql &= ") VALUES ("
							sql &= " @IdLocalita,"
							sql &= " @ALTITUDINE,"
							sql &= " @CENTRO,"
							sql &= " @IdComune,"
							sql &= " @IdProvincia,"
							sql &= " @IdRegione,"
							sql &= " @loc,"
							sql &= " @localita,"
							sql &= " @POP2001,"
							sql &= " @TIPO_LOC,"
							sql &= " @xcoord,"
							sql &= " @ycoord"
							sql &= ")"
						Else
							sql = "UPDATE Localita SET "
							If cls.WhatIsChanged.IdLocalita Then sql &= "IdLocalita = @IdLocalita,"
							If cls.WhatIsChanged.ALTITUDINE Then sql &= "ALTITUDINE = @ALTITUDINE,"
							If cls.WhatIsChanged.CENTRO Then sql &= "CENTRO = @CENTRO,"
							If cls.WhatIsChanged.IdComune Then sql &= "IdComune = @IdComune,"
							If cls.WhatIsChanged.IdProvincia Then sql &= "IdProvincia = @IdProvincia,"
							If cls.WhatIsChanged.IdRegione Then sql &= "IdRegione = @IdRegione,"
							If cls.WhatIsChanged.loc Then sql &= "loc = @loc,"
							If cls.WhatIsChanged.localita Then sql &= "localita = @localita,"
							If cls.WhatIsChanged.POP2001 Then sql &= "POP2001 = @POP2001,"
							If cls.WhatIsChanged.TIPO_LOC Then sql &= "TIPO_LOC = @TIPO_LOC,"
							If cls.WhatIsChanged.xcoord Then sql &= "xcoord = @xcoord,"
							If cls.WhatIsChanged.ycoord Then sql &= "ycoord = @ycoord"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLocalita= " & cls.IdLocalita
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdLocalita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdLocalita"
							p.Value = cls.IdLocalita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ALTITUDINE Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ALTITUDINE"
							p.Value = cls.ALTITUDINE
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CENTRO Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CENTRO"
							p.Value = cls.CENTRO
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdComune Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdComune"
							p.Value = cls.IdComune
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdProvincia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdProvincia"
							p.Value = cls.IdProvincia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRegione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRegione"
							p.Value = cls.IdRegione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.loc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@loc"
							p.Value = cls.loc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.localita Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@localita"
							p.Value = cls.localita
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.POP2001 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@POP2001"
							p.Value = cls.POP2001
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TIPO_LOC Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TIPO_LOC"
							p.Value = cls.TIPO_LOC
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.xcoord Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@xcoord"
							p.Value = cls.xcoord
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ycoord Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ycoord"
							p.Value = cls.ycoord
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

						Ris = cls.IdLocalita
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLocalita
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
				'Dim Sql As String = "UPDATE Localita SET DELETED=True "
				Dim Sql As String = "DELETE FROM Localita"
				Sql &= " WHERE IdLocalita = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Localita. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Localita. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Localita, Optional ByRef ListaObj as List (of Localita) = Nothing)
		DestroyPermanently (obj.IdLocalita)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Localita
		Dim ris As Localita = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Localita) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Localita
	''' </summary>
	''' <returns>
	'''Return first of Localita
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Localita
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Localita
	''' </summary>
	''' <returns>
	'''Return first of Localita
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Localita
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Localita
	''' </summary>
	''' <returns>
	'''Return first of Localita
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Localita
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Localita)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Localita)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Localita)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Localita)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Localita)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita
	''' </summary>
	''' <returns>
	'''Return a list of Localita
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Localita)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Localita by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Localita by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Localita)
		Dim Ls As New List(Of Localita)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Localita)
		Dim Ls As New List(Of Localita)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Localita" 
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
	'''Return all record on DB table Localita
	''' </summary>
	''' <returns>
	'''Return all record in list of Localita
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Localita)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Localita
	''' </summary>
	''' <returns>
	'''Return all record in list of Localita
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Localita)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Localita
	''' </summary>
	''' <returns>
	'''Return all record in list of Localita
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Localita)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Localita)
		Dim Ls As List(Of Localita)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Localita" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Localita)
		Dim Ls As New List(Of Localita)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Localita() With {.IdLocalita = 0 ,.ALTITUDINE = "" ,.CENTRO = 0 ,.IdComune = 0 ,.IdProvincia = 0 ,.IdRegione = 0 ,.loc = 0 ,.localita = "" ,.POP2001 = 0 ,.TIPO_LOC = 0 ,.xcoord = 0 ,.ycoord = 0  })
					While myReader.Read
						Dim classe as new Localita(CType(myReader, IDataRecord))
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