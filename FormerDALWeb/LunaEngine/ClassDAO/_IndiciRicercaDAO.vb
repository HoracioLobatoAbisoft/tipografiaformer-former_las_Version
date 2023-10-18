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
'''This class manage persistency on db of IndiceRicerca object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _IndiciRicercaDAO
	Inherits LUNA.LunaBaseClassDAO(Of IndiceRicerca)

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
	'''Read from DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a IndiceRicerca object
	''' </returns>
	Public Overrides Function Read(Id as integer) as IndiceRicerca
		Dim cls as new IndiceRicerca

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Indiciricerca WHERE IdIndiceRicerca = " & Id
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
	'''Save on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as IndiceRicerca) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdIndiceRicerca = 0 Then
							sql = "INSERT INTO Indiciricerca ("
							sql &= " IdListinoBase,"
							sql &= " IdPrev,"
							sql &= " InEvidenza,"
							sql &= " NomeListino,"
							sql &= " PercCoupon,"
							sql &= " Prezzo1,"
							sql &= " Prezzo1Riv,"
							sql &= " Prezzo2,"
							sql &= " Prezzo2Riv,"
							sql &= " Prezzo3,"
							sql &= " Prezzo3Riv,"
							sql &= " ProdottoFinito,"
							sql &= " Qta1,"
							sql &= " Qta2,"
							sql &= " Qta3,"
							sql &= " TotOrdini"
							sql &= ") VALUES ("
							sql &= " @IdListinoBase,"
							sql &= " @IdPrev,"
							sql &= " @InEvidenza,"
							sql &= " @NomeListino,"
							sql &= " @PercCoupon,"
							sql &= " @Prezzo1,"
							sql &= " @Prezzo1Riv,"
							sql &= " @Prezzo2,"
							sql &= " @Prezzo2Riv,"
							sql &= " @Prezzo3,"
							sql &= " @Prezzo3Riv,"
							sql &= " @ProdottoFinito,"
							sql &= " @Qta1,"
							sql &= " @Qta2,"
							sql &= " @Qta3,"
							sql &= " @TotOrdini"
							sql &= ")"
						Else
							sql = "UPDATE Indiciricerca SET "
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdPrev Then sql &= "IdPrev = @IdPrev,"
							If cls.WhatIsChanged.InEvidenza Then sql &= "InEvidenza = @InEvidenza,"
							If cls.WhatIsChanged.NomeListino Then sql &= "NomeListino = @NomeListino,"
							If cls.WhatIsChanged.PercCoupon Then sql &= "PercCoupon = @PercCoupon,"
							If cls.WhatIsChanged.Prezzo1 Then sql &= "Prezzo1 = @Prezzo1,"
							If cls.WhatIsChanged.Prezzo1Riv Then sql &= "Prezzo1Riv = @Prezzo1Riv,"
							If cls.WhatIsChanged.Prezzo2 Then sql &= "Prezzo2 = @Prezzo2,"
							If cls.WhatIsChanged.Prezzo2Riv Then sql &= "Prezzo2Riv = @Prezzo2Riv,"
							If cls.WhatIsChanged.Prezzo3 Then sql &= "Prezzo3 = @Prezzo3,"
							If cls.WhatIsChanged.Prezzo3Riv Then sql &= "Prezzo3Riv = @Prezzo3Riv,"
							If cls.WhatIsChanged.ProdottoFinito Then sql &= "ProdottoFinito = @ProdottoFinito,"
							If cls.WhatIsChanged.Qta1 Then sql &= "Qta1 = @Qta1,"
							If cls.WhatIsChanged.Qta2 Then sql &= "Qta2 = @Qta2,"
							If cls.WhatIsChanged.Qta3 Then sql &= "Qta3 = @Qta3,"
							If cls.WhatIsChanged.TotOrdini Then sql &= "TotOrdini = @TotOrdini"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdIndiceRicerca= " & cls.IdIndiceRicerca
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdListinoBase Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdListinoBase"
							p.Value = cls.IdListinoBase
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPrev Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPrev"
							p.Value = cls.IdPrev
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.InEvidenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@InEvidenza"
							p.Value = cls.InEvidenza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeListino Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeListino"
							p.Value = cls.NomeListino
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercCoupon Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercCoupon"
							p.Value = cls.PercCoupon
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo1"
							p.Value = cls.Prezzo1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo1Riv Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo1Riv"
							p.Value = cls.Prezzo1Riv
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo2"
							p.Value = cls.Prezzo2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo2Riv Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo2Riv"
							p.Value = cls.Prezzo2Riv
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo3"
							p.Value = cls.Prezzo3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo3Riv Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo3Riv"
							p.Value = cls.Prezzo3Riv
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ProdottoFinito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ProdottoFinito"
							p.Value = cls.ProdottoFinito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta1"
							p.Value = cls.Qta1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta2"
							p.Value = cls.Qta2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta3 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta3"
							p.Value = cls.Qta3
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TotOrdini Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TotOrdini"
							p.Value = cls.TotOrdini
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdIndiceRicerca=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdIndiceRicerca = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdIndiceRicerca
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdIndiceRicerca
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
				'Dim Sql As String = "UPDATE Indiciricerca SET DELETED=True "
				Dim Sql As String = "DELETE FROM Indiciricerca"
				Sql &= " WHERE IdIndiceRicerca = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Indiciricerca. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Indiciricerca. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as IndiceRicerca, Optional ByRef ListaObj as List (of IndiceRicerca) = Nothing)
		DestroyPermanently (obj.IdIndiceRicerca)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IndiceRicerca
		Dim ris As IndiceRicerca = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of IndiceRicerca) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return first of IndiceRicerca
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IndiceRicerca
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return first of IndiceRicerca
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IndiceRicerca
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table IndiceRicerca
	''' </summary>
	''' <returns>
	'''Return first of IndiceRicerca
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IndiceRicerca
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of IndiceRicerca)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of IndiceRicerca)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of IndiceRicerca)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of IndiceRicerca)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of IndiceRicerca)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of IndiceRicerca)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Indiciricerca by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of IndiceRicerca by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of IndiceRicerca)
		Dim Ls As New List(Of IndiceRicerca)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of IndiceRicerca)
		Dim Ls As New List(Of IndiceRicerca)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Indiciricerca" 
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
	'''Return all record on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return all record in list of IndiceRicerca
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of IndiceRicerca)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return all record in list of IndiceRicerca
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of IndiceRicerca)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Indiciricerca
	''' </summary>
	''' <returns>
	'''Return all record in list of IndiceRicerca
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of IndiceRicerca)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of IndiceRicerca)
		Dim Ls As List(Of IndiceRicerca)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Indiciricerca" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of IndiceRicerca)
		Dim Ls As New List(Of IndiceRicerca)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  IndiceRicerca() With {.IdIndiceRicerca = 0 ,.IdListinoBase = 0 ,.IdPrev = 0 ,.InEvidenza = 0 ,.NomeListino = "" ,.PercCoupon = 0 ,.Prezzo1 = 0 ,.Prezzo1Riv = 0 ,.Prezzo2 = 0 ,.Prezzo2Riv = 0 ,.Prezzo3 = 0 ,.Prezzo3Riv = 0 ,.ProdottoFinito = 0 ,.Qta1 = 0 ,.Qta2 = 0 ,.Qta3 = 0 ,.TotOrdini = 0  })
					While myReader.Read
						Dim classe as new IndiceRicerca(CType(myReader, IDataRecord))
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