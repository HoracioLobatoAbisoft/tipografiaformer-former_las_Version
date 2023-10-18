#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of CatLav object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CatLavDAO
	Inherits LUNA.LunaBaseClassDAO(Of CatLav)

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
	'''Read from DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a CatLav object
	''' </returns>
	Public Overrides Function Read(Id as integer) as CatLav
		Dim cls as new CatLav

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_catlav WHERE IdCatLav = " & Id
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
	'''Save on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as CatLav) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCatLav = 0 Then
							sql = "INSERT INTO Td_catlav ("
							sql &= " Descrizione,"
							sql &= " FileLavNonSelezionata,"
							sql &= " OrdineEsecuzione,"
							sql &= " RepartoAppartenenza,"
							sql &= " SovrascriviImgScheda,"
							sql &= " TipoCaratteristica,"
							sql &= " TipoControllo,"
							sql &= " VisibilePreventivo"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @FileLavNonSelezionata,"
							sql &= " @OrdineEsecuzione,"
							sql &= " @RepartoAppartenenza,"
							sql &= " @SovrascriviImgScheda,"
							sql &= " @TipoCaratteristica,"
							sql &= " @TipoControllo,"
							sql &= " @VisibilePreventivo"
							sql &= ")"
						Else
							sql = "UPDATE Td_catlav SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.FileLavNonSelezionata Then sql &= "FileLavNonSelezionata = @FileLavNonSelezionata,"
							If cls.WhatIsChanged.OrdineEsecuzione Then sql &= "OrdineEsecuzione = @OrdineEsecuzione,"
							If cls.WhatIsChanged.RepartoAppartenenza Then sql &= "RepartoAppartenenza = @RepartoAppartenenza,"
							If cls.WhatIsChanged.SovrascriviImgScheda Then sql &= "SovrascriviImgScheda = @SovrascriviImgScheda,"
							If cls.WhatIsChanged.TipoCaratteristica Then sql &= "TipoCaratteristica = @TipoCaratteristica,"
							If cls.WhatIsChanged.TipoControllo Then sql &= "TipoControllo = @TipoControllo,"
							If cls.WhatIsChanged.VisibilePreventivo Then sql &= "VisibilePreventivo = @VisibilePreventivo"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCatLav= " & cls.IdCatLav
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FileLavNonSelezionata Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FileLavNonSelezionata"
							p.Value = cls.FileLavNonSelezionata
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdineEsecuzione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdineEsecuzione"
							p.Value = cls.OrdineEsecuzione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RepartoAppartenenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RepartoAppartenenza"
							p.Value = cls.RepartoAppartenenza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SovrascriviImgScheda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SovrascriviImgScheda"
							p.Value = cls.SovrascriviImgScheda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCaratteristica Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCaratteristica"
							p.Value = cls.TipoCaratteristica
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoControllo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoControllo"
							p.Value = cls.TipoControllo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.VisibilePreventivo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@VisibilePreventivo"
							p.Value = cls.VisibilePreventivo
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCatLav=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCatLav = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCatLav
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCatLav
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
				'Dim Sql As String = "UPDATE Td_catlav SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_catlav"
				Sql &= " WHERE IdCatLav = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_catlav. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_catlav. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as CatLav, Optional ByRef ListaObj as List (of CatLav) = Nothing)
		DestroyPermanently (obj.IdCatLav)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatLav
		Dim ris As CatLav = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of CatLav) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return first of CatLav
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatLav
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return first of CatLav
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatLav
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table CatLav
	''' </summary>
	''' <returns>
	'''Return first of CatLav
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatLav
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatLav)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatLav)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatLav)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatLav)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatLav)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return a list of CatLav
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of CatLav)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catlav by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of CatLav by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of CatLav)
		Dim Ls As New List(Of CatLav)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of CatLav)
		Dim Ls As New List(Of CatLav)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_catlav" 
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
	'''Return all record on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return all record in list of CatLav
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of CatLav)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return all record in list of CatLav
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CatLav)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_catlav
	''' </summary>
	''' <returns>
	'''Return all record in list of CatLav
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CatLav)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CatLav)
		Dim Ls As List(Of CatLav)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_catlav" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CatLav)
		Dim Ls As New List(Of CatLav)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  CatLav() With {.IdCatLav = 0 ,.Descrizione = EmptyItemDescription,.FileLavNonSelezionata = "" ,.OrdineEsecuzione = 0 ,.RepartoAppartenenza = 0 ,.SovrascriviImgScheda = 0 ,.TipoCaratteristica = 0 ,.TipoControllo = 0 ,.VisibilePreventivo = 0  })
					While myReader.Read
						Dim classe as new CatLav(CType(myReader, IDataRecord))
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