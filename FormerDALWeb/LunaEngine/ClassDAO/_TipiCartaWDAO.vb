#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 11/03/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of TipoCartaW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _TipiCartaWDAO
	Inherits LUNA.LunaBaseClassDAO(Of TipoCartaW)

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
	'''Read from DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a TipoCartaW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as TipoCartaW
		Dim cls as new TipoCartaW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_tipocarta WHERE IdTipoCarta = " & Id
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
	'''Save on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as TipoCartaW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdTipoCarta = 0 Then
							sql = "INSERT INTO Td_tipocarta ("
							sql &= " Altezza,"
							sql &= " CostoCartaKg,"
							sql &= " CostoRiferimento,"
							sql &= " DescrizioneEstesa,"
							sql &= " Finitura,"
							sql &= " Grammi,"
							sql &= " HotFolder,"
							sql &= " ImgRif,"
							sql &= " Larghezza,"
							sql &= " Sigla,"
							sql &= " Spessore,"
							sql &= " TipoCarta,"
							sql &= " TipoCosto,"
							sql &= " Tipologia"
							sql &= ") VALUES ("
							sql &= " @Altezza,"
							sql &= " @CostoCartaKg,"
							sql &= " @CostoRiferimento,"
							sql &= " @DescrizioneEstesa,"
							sql &= " @Finitura,"
							sql &= " @Grammi,"
							sql &= " @HotFolder,"
							sql &= " @ImgRif,"
							sql &= " @Larghezza,"
							sql &= " @Sigla,"
							sql &= " @Spessore,"
							sql &= " @TipoCarta,"
							sql &= " @TipoCosto,"
							sql &= " @Tipologia"
							sql &= ")"
						Else
							sql = "UPDATE Td_tipocarta SET "
							If cls.WhatIsChanged.Altezza Then sql &= "Altezza = @Altezza,"
							If cls.WhatIsChanged.CostoCartaKg Then sql &= "CostoCartaKg = @CostoCartaKg,"
							If cls.WhatIsChanged.CostoRiferimento Then sql &= "CostoRiferimento = @CostoRiferimento,"
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.Finitura Then sql &= "Finitura = @Finitura,"
							If cls.WhatIsChanged.Grammi Then sql &= "Grammi = @Grammi,"
							If cls.WhatIsChanged.HotFolder Then sql &= "HotFolder = @HotFolder,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.Larghezza Then sql &= "Larghezza = @Larghezza,"
							If cls.WhatIsChanged.Sigla Then sql &= "Sigla = @Sigla,"
							If cls.WhatIsChanged.Spessore Then sql &= "Spessore = @Spessore,"
							If cls.WhatIsChanged.TipoCarta Then sql &= "TipoCarta = @TipoCarta,"
							If cls.WhatIsChanged.TipoCosto Then sql &= "TipoCosto = @TipoCosto,"
							If cls.WhatIsChanged.Tipologia Then sql &= "Tipologia = @Tipologia"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdTipoCarta= " & cls.IdTipoCarta
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Altezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Altezza"
							p.Value = cls.Altezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoCartaKg Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoCartaKg"
							p.Value = cls.CostoCartaKg
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoRiferimento"
							p.Value = cls.CostoRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Finitura Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Finitura"
							p.Value = cls.Finitura
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Grammi Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Grammi"
							p.Value = cls.Grammi
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.HotFolder Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@HotFolder"
							p.Value = cls.HotFolder
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Larghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Larghezza"
							p.Value = cls.Larghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sigla Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sigla"
							p.Value = cls.Sigla
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Spessore Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Spessore"
							p.Value = cls.Spessore
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCarta"
							p.Value = cls.TipoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCosto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCosto"
							p.Value = cls.TipoCosto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipologia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipologia"
							p.Value = cls.Tipologia
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdTipoCarta=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdTipoCarta = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdTipoCarta
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdTipoCarta
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
				'Dim Sql As String = "UPDATE Td_tipocarta SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_tipocarta"
				Sql &= " WHERE IdTipoCarta = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipocarta. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipocarta. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as TipoCartaW, Optional ByRef ListaObj as List (of TipoCartaW) = Nothing)
		DestroyPermanently (obj.IdTipoCarta)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCartaW
		Dim ris As TipoCartaW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of TipoCartaW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return first of TipoCartaW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCartaW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return first of TipoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCartaW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table TipoCartaW
	''' </summary>
	''' <returns>
	'''Return first of TipoCartaW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoCartaW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCartaW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCartaW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoCartaW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of TipoCartaW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipocarta by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of TipoCartaW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCartaW)
		Dim Ls As New List(Of TipoCartaW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of TipoCartaW)
		Dim Ls As New List(Of TipoCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_tipocarta" 
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
	'''Return all record on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCartaW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of TipoCartaW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCartaW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCartaW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipocarta
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoCartaW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoCartaW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoCartaW)
		Dim Ls As List(Of TipoCartaW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_tipocarta" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoCartaW)
		Dim Ls As New List(Of TipoCartaW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  TipoCartaW() With {.IdTipoCarta = 0 ,.Altezza = 0 ,.CostoCartaKg = 0 ,.CostoRiferimento = 0 ,.DescrizioneEstesa = "" ,.Finitura = "" ,.Grammi = 0 ,.HotFolder = "" ,.ImgRif = "" ,.Larghezza = 0 ,.Sigla = "" ,.Spessore = 0 ,.TipoCarta = 0 ,.TipoCosto = 0 ,.Tipologia = ""  })
					While myReader.Read
						Dim classe as new TipoCartaW(CType(myReader, IDataRecord))
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