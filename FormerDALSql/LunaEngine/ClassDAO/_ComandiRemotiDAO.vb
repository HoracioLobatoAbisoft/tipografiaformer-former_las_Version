#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 04/07/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of ComandoRemoto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ComandiRemotiDAO
	Inherits LUNA.LunaBaseClassDAO(Of ComandoRemoto)

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
	'''Read from DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a ComandoRemoto object
	''' </returns>
	Public Overrides Function Read(Id as integer) as ComandoRemoto
		Dim cls as new ComandoRemoto

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Comandiremoti WHERE IdCM = " & Id
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
	'''Save on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as ComandoRemoto) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCM = 0 Then
							sql = "INSERT INTO Comandiremoti ("
							sql &= " IdCom,"
							sql &= " IdOrd,"
							sql &= " IdUt,"
							sql &= " Stato,"
							sql &= " TipoOperazione"
							sql &= ") VALUES ("
							sql &= " @IdCom,"
							sql &= " @IdOrd,"
							sql &= " @IdUt,"
							sql &= " @Stato,"
							sql &= " @TipoOperazione"
							sql &= ")"
						Else
							sql = "UPDATE Comandiremoti SET "
							If cls.WhatIsChanged.IdCom Then sql &= "IdCom = @IdCom,"
							If cls.WhatIsChanged.IdOrd Then sql &= "IdOrd = @IdOrd,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.TipoOperazione Then sql &= "TipoOperazione = @TipoOperazione"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCM= " & cls.IdCM
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCom"
							p.Value = cls.IdCom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrd"
							p.Value = cls.IdOrd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoOperazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoOperazione"
							p.Value = cls.TipoOperazione
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCM=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCM = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCM
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCM
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
				'Dim Sql As String = "UPDATE Comandiremoti SET DELETED=True "
				Dim Sql As String = "DELETE FROM Comandiremoti"
				Sql &= " WHERE IdCM = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Comandiremoti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Comandiremoti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as ComandoRemoto, Optional ByRef ListaObj as List (of ComandoRemoto) = Nothing)
		DestroyPermanently (obj.IdCM)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComandoRemoto
		Dim ris As ComandoRemoto = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of ComandoRemoto) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return first of ComandoRemoto
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComandoRemoto
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return first of ComandoRemoto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComandoRemoto
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table ComandoRemoto
	''' </summary>
	''' <returns>
	'''Return first of ComandoRemoto
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As ComandoRemoto
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComandoRemoto)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComandoRemoto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComandoRemoto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComandoRemoto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of ComandoRemoto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of ComandoRemoto)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Comandiremoti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of ComandoRemoto by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of ComandoRemoto)
		Dim Ls As New List(Of ComandoRemoto)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of ComandoRemoto)
		Dim Ls As New List(Of ComandoRemoto)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Comandiremoti" 
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
	'''Return all record on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return all record in list of ComandoRemoto
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of ComandoRemoto)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return all record in list of ComandoRemoto
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ComandoRemoto)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Comandiremoti
	''' </summary>
	''' <returns>
	'''Return all record in list of ComandoRemoto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of ComandoRemoto)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ComandoRemoto)
		Dim Ls As List(Of ComandoRemoto)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Comandiremoti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of ComandoRemoto)
		Dim Ls As New List(Of ComandoRemoto)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  ComandoRemoto() With {.IdCM = 0 ,.IdCom = 0 ,.IdOrd = 0 ,.IdUt = 0 ,.Stato = 0 ,.TipoOperazione = 0  })
					While myReader.Read
						Dim classe as new ComandoRemoto(CType(myReader, IDataRecord))
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