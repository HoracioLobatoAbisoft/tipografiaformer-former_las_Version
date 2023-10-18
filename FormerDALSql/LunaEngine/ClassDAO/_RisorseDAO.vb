#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.7.9 
'Author: Diego Lunadei
'Date: 16/09/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Risorsa object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _RisorseDAO
	Inherits LUNA.LunaBaseClassDAO(Of Risorsa)

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
	'''Read from DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a Risorsa object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Risorsa
		Dim cls as new Risorsa

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_risorse WHERE IdRis = " & Id
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
	'''Save on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Risorsa) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdRis = 0 Then
							sql = "INSERT INTO T_risorse ("
							sql &= " BarCode,"
							sql &= " Categoria,"
							sql &= " Codice,"
							sql &= " CostoFoglioFormato,"
							sql &= " CostoFoglioSteso,"
							sql &= " CostoTotale,"
							sql &= " CostoVenduto,"
							sql &= " DataAggiornamento,"
							sql &= " Descrizione,"
							sql &= " Giacenza,"
							sql &= " GiacenzaMin,"
							sql &= " Grammatura,"
							sql &= " IdTipoCarta,"
							sql &= " IdUnitaMisura,"
							sql &= " IdUnitaMisuraConfezione,"
							sql &= " imgPath,"
							sql &= " IsLastra,"
							sql &= " Larghezza,"
							sql &= " Lunghezza,"
							sql &= " Nlastre,"
							sql &= " ProdottoFinito,"
							sql &= " Stato,"
							sql &= " TipoRis"
							sql &= ") VALUES ("
							sql &= " @BarCode,"
							sql &= " @Categoria,"
							sql &= " @Codice,"
							sql &= " @CostoFoglioFormato,"
							sql &= " @CostoFoglioSteso,"
							sql &= " @CostoTotale,"
							sql &= " @CostoVenduto,"
							sql &= " @DataAggiornamento,"
							sql &= " @Descrizione,"
							sql &= " @Giacenza,"
							sql &= " @GiacenzaMin,"
							sql &= " @Grammatura,"
							sql &= " @IdTipoCarta,"
							sql &= " @IdUnitaMisura,"
							sql &= " @IdUnitaMisuraConfezione,"
							sql &= " @imgPath,"
							sql &= " @IsLastra,"
							sql &= " @Larghezza,"
							sql &= " @Lunghezza,"
							sql &= " @Nlastre,"
							sql &= " @ProdottoFinito,"
							sql &= " @Stato,"
							sql &= " @TipoRis"
							sql &= ")"
						Else
							sql = "UPDATE T_risorse SET "
							If cls.WhatIsChanged.BarCode Then sql &= "BarCode = @BarCode,"
							If cls.WhatIsChanged.Categoria Then sql &= "Categoria = @Categoria,"
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.CostoFoglioFormato Then sql &= "CostoFoglioFormato = @CostoFoglioFormato,"
							If cls.WhatIsChanged.CostoFoglioSteso Then sql &= "CostoFoglioSteso = @CostoFoglioSteso,"
							If cls.WhatIsChanged.CostoTotale Then sql &= "CostoTotale = @CostoTotale,"
							If cls.WhatIsChanged.CostoVenduto Then sql &= "CostoVenduto = @CostoVenduto,"
							If cls.WhatIsChanged.DataAggiornamento Then sql &= "DataAggiornamento = @DataAggiornamento,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.Giacenza Then sql &= "Giacenza = @Giacenza,"
							If cls.WhatIsChanged.GiacenzaMin Then sql &= "GiacenzaMin = @GiacenzaMin,"
							If cls.WhatIsChanged.Grammatura Then sql &= "Grammatura = @Grammatura,"
							If cls.WhatIsChanged.IdTipoCarta Then sql &= "IdTipoCarta = @IdTipoCarta,"
							If cls.WhatIsChanged.IdUnitaMisura Then sql &= "IdUnitaMisura = @IdUnitaMisura,"
							If cls.WhatIsChanged.IdUnitaMisuraConfezione Then sql &= "IdUnitaMisuraConfezione = @IdUnitaMisuraConfezione,"
							If cls.WhatIsChanged.imgPath Then sql &= "imgPath = @imgPath,"
							If cls.WhatIsChanged.IsLastra Then sql &= "IsLastra = @IsLastra,"
							If cls.WhatIsChanged.Larghezza Then sql &= "Larghezza = @Larghezza,"
							If cls.WhatIsChanged.Lunghezza Then sql &= "Lunghezza = @Lunghezza,"
							If cls.WhatIsChanged.Nlastre Then sql &= "Nlastre = @Nlastre,"
							If cls.WhatIsChanged.ProdottoFinito Then sql &= "ProdottoFinito = @ProdottoFinito,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.TipoRis Then sql &= "TipoRis = @TipoRis"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdRis= " & cls.IdRis
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.BarCode Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@BarCode"
							p.Value = cls.BarCode
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Categoria Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Categoria"
							p.Value = cls.Categoria
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Codice Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Codice"
							p.Value = cls.Codice
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoFoglioFormato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoFoglioFormato"
							p.Value = cls.CostoFoglioFormato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoFoglioSteso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoFoglioSteso"
							p.Value = cls.CostoFoglioSteso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoTotale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoTotale"
							p.Value = cls.CostoTotale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoVenduto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoVenduto"
							p.Value = cls.CostoVenduto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataAggiornamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataAggiornamento"
							p.DbType = DbType.DateTime
							If cls.DataAggiornamento <> Date.MinValue Then
								p.Value = cls.DataAggiornamento
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Giacenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Giacenza"
							p.Value = cls.Giacenza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GiacenzaMin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GiacenzaMin"
							p.Value = cls.GiacenzaMin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Grammatura Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Grammatura"
							p.Value = cls.Grammatura
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoCarta"
							p.Value = cls.IdTipoCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUnitaMisura Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUnitaMisura"
							p.Value = cls.IdUnitaMisura
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUnitaMisuraConfezione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUnitaMisuraConfezione"
							p.Value = cls.IdUnitaMisuraConfezione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.imgPath Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@imgPath"
							p.Value = cls.imgPath
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IsLastra Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IsLastra"
							p.Value = cls.IsLastra
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Larghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Larghezza"
							p.Value = cls.Larghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Lunghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Lunghezza"
							p.Value = cls.Lunghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nlastre Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nlastre"
							p.Value = cls.Nlastre
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ProdottoFinito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ProdottoFinito"
							p.Value = cls.ProdottoFinito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoRis Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoRis"
							p.Value = cls.TipoRis
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdRis=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdRis = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdRis
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdRis
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
				'Dim Sql As String = "UPDATE T_risorse SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_risorse"
				Sql &= " WHERE IdRis = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_risorse. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_risorse. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Risorsa, Optional ByRef ListaObj as List (of Risorsa) = Nothing)
		DestroyPermanently (obj.IdRis)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Risorsa
		Dim ris As Risorsa = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Risorsa) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return first of Risorsa
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Risorsa
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return first of Risorsa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Risorsa
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Risorsa
	''' </summary>
	''' <returns>
	'''Return first of Risorsa
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Risorsa
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Risorsa)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Risorsa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Risorsa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Risorsa)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Risorsa)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Risorsa)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_risorse by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Risorsa by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Risorsa)
		Dim Ls As New List(Of Risorsa)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Risorsa)
		Dim Ls As New List(Of Risorsa)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_risorse" 
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
	'''Return all record on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return all record in list of Risorsa
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Risorsa)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return all record in list of Risorsa
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Risorsa)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_risorse
	''' </summary>
	''' <returns>
	'''Return all record in list of Risorsa
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Risorsa)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Risorsa)
		Dim Ls As List(Of Risorsa)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_risorse" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Risorsa)
		Dim Ls As New List(Of Risorsa)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Risorsa() With {.IdRis = 0 ,.BarCode = "" ,.Categoria = "" ,.Codice = "" ,.CostoFoglioFormato = 0 ,.CostoFoglioSteso = 0 ,.CostoTotale = 0 ,.CostoVenduto = 0 ,.DataAggiornamento = Nothing ,.Descrizione = EmptyItemDescription,.Giacenza = 0 ,.GiacenzaMin = 0 ,.Grammatura = 0 ,.IdTipoCarta = 0 ,.IdUnitaMisura = 0 ,.IdUnitaMisuraConfezione = 0 ,.imgPath = "" ,.IsLastra = False ,.Larghezza = 0 ,.Lunghezza = 0 ,.Nlastre = 0 ,.ProdottoFinito = 0 ,.Stato = 0 ,.TipoRis = 0  })
					While myReader.Read
						Dim classe as new Risorsa(CType(myReader, IDataRecord))
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