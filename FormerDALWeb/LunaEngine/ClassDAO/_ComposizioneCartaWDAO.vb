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
'''This class manage persistency on db of ComposizioneCartaW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ComposizioneCartaWDAO
	Inherits LUNA.LunaBaseClassDAO(Of ComposizioneCartaW)

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
	'''Read from DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a ComposizioneCartaW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ComposizioneCartaW
		Dim cls as new ComposizioneCartaW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Tr_cartacomposta WHERE IdCartaComposta = " & Id
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
	'''Save on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ComposizioneCartaW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCartaComposta = 0 Then
							sql = "INSERT INTO Tr_cartacomposta ("
							sql &= " IdCartaPadre,"
							sql &= " IdCartaSingola,"
							sql &= " NumFogli"
							sql &= ") VALUES ("
							sql &= " @IdCartaPadre,"
							sql &= " @IdCartaSingola,"
							sql &= " @NumFogli"
							sql &= ")"
						Else
							sql = "UPDATE Tr_cartacomposta SET "
							If cls.WhatIsChanged.IdCartaPadre Then sql &= "IdCartaPadre = @IdCartaPadre,"
							If cls.WhatIsChanged.IdCartaSingola Then sql &= "IdCartaSingola = @IdCartaSingola,"
							If cls.WhatIsChanged.NumFogli Then sql &= "NumFogli = @NumFogli"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCartaComposta= " & cls.IdCartaComposta
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdCartaPadre Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCartaPadre"
							p.Value = cls.IdCartaPadre
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCartaSingola Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCartaSingola"
							p.Value = cls.IdCartaSingola
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NumFogli Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NumFogli"
							p.Value = cls.NumFogli
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCartaComposta=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCartaComposta = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCartaComposta
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCartaComposta
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
				'Dim Sql As String = "UPDATE Tr_cartacomposta SET DELETED=True "
				Dim Sql As String = "DELETE FROM Tr_cartacomposta"
				Sql &= " WHERE IdCartaComposta = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Tr_cartacomposta. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Tr_cartacomposta. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ComposizioneCartaW, Optional ByRef ListaObj as List (of ComposizioneCartaW) = Nothing)
		DestroyPermanently (obj.IdCartaComposta)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComposizioneCartaW
		Dim ris As ComposizioneCartaW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ComposizioneCartaW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return first of ComposizioneCartaW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComposizioneCartaW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return first of ComposizioneCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComposizioneCartaW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ComposizioneCartaW
	''' </summary>
	''' <returns>
	'''Return first of ComposizioneCartaW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComposizioneCartaW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComposizioneCartaW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComposizioneCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComposizioneCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComposizioneCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComposizioneCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ComposizioneCartaW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_cartacomposta by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ComposizioneCartaW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ComposizioneCartaW)
		Dim Ls As New List(Of ComposizioneCartaW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ComposizioneCartaW)
		Dim Ls As New List(Of ComposizioneCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Tr_cartacomposta" 
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
	'''Return all record on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return all record in list of ComposizioneCartaW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ComposizioneCartaW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return all record in list of ComposizioneCartaW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ComposizioneCartaW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Tr_cartacomposta
	''' </summary>
	''' <returns>
	'''Return all record in list of ComposizioneCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ComposizioneCartaW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ComposizioneCartaW)
		Dim Ls As List(Of ComposizioneCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Tr_cartacomposta" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ComposizioneCartaW)
		Dim Ls As New List(Of ComposizioneCartaW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ComposizioneCartaW() With {.IdCartaComposta = 0 ,.IdCartaPadre = 0 ,.IdCartaSingola = 0 ,.NumFogli = 0  })
					While myReader.Read
						Dim classe as new ComposizioneCartaW(CType(myReader, IDataRecord))
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