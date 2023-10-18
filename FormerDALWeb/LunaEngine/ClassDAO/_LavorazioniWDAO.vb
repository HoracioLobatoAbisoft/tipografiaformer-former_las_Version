#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/04/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of LavorazioneW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _LavorazioniWDAO
	Inherits LUNA.LunaBaseClassDAO(Of LavorazioneW)

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
	'''Read from DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a LavorazioneW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as LavorazioneW
		Dim cls as new LavorazioneW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_lavori WHERE IdLavoro = " & Id
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
	'''Save on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as LavorazioneW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLavoro = 0 Then
							sql = "INSERT INTO T_lavori ("
							sql &= " Accorpabile,"
							sql &= " CostoSingCopia,"
							sql &= " Descrizione,"
							sql &= " DescrizioneEstesa,"
							sql &= " DimensMaxH,"
							sql &= " DimensMaxW,"
							sql &= " DimensMedieMaxH,"
							sql &= " DimensMedieMaxW,"
							sql &= " DimensMedieMinH,"
							sql &= " DimensMedieMinW,"
							sql &= " DimensMinH,"
							sql &= " DimensMinW,"
							sql &= " ExtraData,"
							sql &= " FormatoRiferimento,"
							sql &= " ggRealiz,"
							sql &= " GrammiMax,"
							sql &= " GrammiMin,"
							sql &= " IdCatLav,"
							sql &= " IdMacchinario,"
							sql &= " IdMacchinario2,"
							sql &= " IdTipoLav,"
							sql &= " ImgRif,"
							sql &= " ImgZoom,"
							sql &= " LavorazioneInterna,"
							sql &= " Macchinario,"
							sql &= " Premio,"
							sql &= " PreTaglio,"
							sql &= " Prezzo,"
							sql &= " Pubblica,"
							sql &= " SePresenteCalcolaSuSoggetti,"
							sql &= " Sigla,"
							sql &= " Stato,"
							sql &= " SuCommessa,"
							sql &= " SuProdotto,"
							sql &= " TempoRif,"
							sql &= " TipoControlloWeb"
							sql &= ") VALUES ("
							sql &= " @Accorpabile,"
							sql &= " @CostoSingCopia,"
							sql &= " @Descrizione,"
							sql &= " @DescrizioneEstesa,"
							sql &= " @DimensMaxH,"
							sql &= " @DimensMaxW,"
							sql &= " @DimensMedieMaxH,"
							sql &= " @DimensMedieMaxW,"
							sql &= " @DimensMedieMinH,"
							sql &= " @DimensMedieMinW,"
							sql &= " @DimensMinH,"
							sql &= " @DimensMinW,"
							sql &= " @ExtraData,"
							sql &= " @FormatoRiferimento,"
							sql &= " @ggRealiz,"
							sql &= " @GrammiMax,"
							sql &= " @GrammiMin,"
							sql &= " @IdCatLav,"
							sql &= " @IdMacchinario,"
							sql &= " @IdMacchinario2,"
							sql &= " @IdTipoLav,"
							sql &= " @ImgRif,"
							sql &= " @ImgZoom,"
							sql &= " @LavorazioneInterna,"
							sql &= " @Macchinario,"
							sql &= " @Premio,"
							sql &= " @PreTaglio,"
							sql &= " @Prezzo,"
							sql &= " @Pubblica,"
							sql &= " @SePresenteCalcolaSuSoggetti,"
							sql &= " @Sigla,"
							sql &= " @Stato,"
							sql &= " @SuCommessa,"
							sql &= " @SuProdotto,"
							sql &= " @TempoRif,"
							sql &= " @TipoControlloWeb"
							sql &= ")"
						Else
							sql = "UPDATE T_lavori SET "
							If cls.WhatIsChanged.Accorpabile Then sql &= "Accorpabile = @Accorpabile,"
							If cls.WhatIsChanged.CostoSingCopia Then sql &= "CostoSingCopia = @CostoSingCopia,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.DimensMaxH Then sql &= "DimensMaxH = @DimensMaxH,"
							If cls.WhatIsChanged.DimensMaxW Then sql &= "DimensMaxW = @DimensMaxW,"
							If cls.WhatIsChanged.DimensMedieMaxH Then sql &= "DimensMedieMaxH = @DimensMedieMaxH,"
							If cls.WhatIsChanged.DimensMedieMaxW Then sql &= "DimensMedieMaxW = @DimensMedieMaxW,"
							If cls.WhatIsChanged.DimensMedieMinH Then sql &= "DimensMedieMinH = @DimensMedieMinH,"
							If cls.WhatIsChanged.DimensMedieMinW Then sql &= "DimensMedieMinW = @DimensMedieMinW,"
							If cls.WhatIsChanged.DimensMinH Then sql &= "DimensMinH = @DimensMinH,"
							If cls.WhatIsChanged.DimensMinW Then sql &= "DimensMinW = @DimensMinW,"
							If cls.WhatIsChanged.ExtraData Then sql &= "ExtraData = @ExtraData,"
							If cls.WhatIsChanged.FormatoRiferimento Then sql &= "FormatoRiferimento = @FormatoRiferimento,"
							If cls.WhatIsChanged.ggRealiz Then sql &= "ggRealiz = @ggRealiz,"
							If cls.WhatIsChanged.GrammiMax Then sql &= "GrammiMax = @GrammiMax,"
							If cls.WhatIsChanged.GrammiMin Then sql &= "GrammiMin = @GrammiMin,"
							If cls.WhatIsChanged.IdCatLav Then sql &= "IdCatLav = @IdCatLav,"
							If cls.WhatIsChanged.IdMacchinario Then sql &= "IdMacchinario = @IdMacchinario,"
							If cls.WhatIsChanged.IdMacchinario2 Then sql &= "IdMacchinario2 = @IdMacchinario2,"
							If cls.WhatIsChanged.IdTipoLav Then sql &= "IdTipoLav = @IdTipoLav,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.ImgZoom Then sql &= "ImgZoom = @ImgZoom,"
							If cls.WhatIsChanged.LavorazioneInterna Then sql &= "LavorazioneInterna = @LavorazioneInterna,"
							If cls.WhatIsChanged.Macchinario Then sql &= "Macchinario = @Macchinario,"
							If cls.WhatIsChanged.Premio Then sql &= "Premio = @Premio,"
							If cls.WhatIsChanged.PreTaglio Then sql &= "PreTaglio = @PreTaglio,"
							If cls.WhatIsChanged.Prezzo Then sql &= "Prezzo = @Prezzo,"
							If cls.WhatIsChanged.Pubblica Then sql &= "Pubblica = @Pubblica,"
							If cls.WhatIsChanged.SePresenteCalcolaSuSoggetti Then sql &= "SePresenteCalcolaSuSoggetti = @SePresenteCalcolaSuSoggetti,"
							If cls.WhatIsChanged.Sigla Then sql &= "Sigla = @Sigla,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.SuCommessa Then sql &= "SuCommessa = @SuCommessa,"
							If cls.WhatIsChanged.SuProdotto Then sql &= "SuProdotto = @SuProdotto,"
							If cls.WhatIsChanged.TempoRif Then sql &= "TempoRif = @TempoRif,"
							If cls.WhatIsChanged.TipoControlloWeb Then sql &= "TipoControlloWeb = @TipoControlloWeb"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLavoro= " & cls.IdLavoro
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Accorpabile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Accorpabile"
							p.Value = cls.Accorpabile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoSingCopia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoSingCopia"
							p.Value = cls.CostoSingCopia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMaxH Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMaxH"
							p.Value = cls.DimensMaxH
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMaxW Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMaxW"
							p.Value = cls.DimensMaxW
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMedieMaxH Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMedieMaxH"
							p.Value = cls.DimensMedieMaxH
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMedieMaxW Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMedieMaxW"
							p.Value = cls.DimensMedieMaxW
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMedieMinH Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMedieMinH"
							p.Value = cls.DimensMedieMinH
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMedieMinW Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMedieMinW"
							p.Value = cls.DimensMedieMinW
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMinH Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMinH"
							p.Value = cls.DimensMinH
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DimensMinW Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DimensMinW"
							p.Value = cls.DimensMinW
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ExtraData Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ExtraData"
							p.Value = cls.ExtraData
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FormatoRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FormatoRiferimento"
							p.Value = cls.FormatoRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ggRealiz Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ggRealiz"
							p.Value = cls.ggRealiz
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GrammiMax Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GrammiMax"
							p.Value = cls.GrammiMax
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GrammiMin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GrammiMin"
							p.Value = cls.GrammiMin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCatLav Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCatLav"
							p.Value = cls.IdCatLav
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinario"
							p.Value = cls.IdMacchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinario2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinario2"
							p.Value = cls.IdMacchinario2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdTipoLav Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdTipoLav"
							p.Value = cls.IdTipoLav
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgZoom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgZoom"
							p.Value = cls.ImgZoom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.LavorazioneInterna Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@LavorazioneInterna"
							p.Value = cls.LavorazioneInterna
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Macchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Macchinario"
							p.Value = cls.Macchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Premio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Premio"
							p.Value = cls.Premio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PreTaglio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PreTaglio"
							p.Value = cls.PreTaglio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo"
							p.Value = cls.Prezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Pubblica Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Pubblica"
							p.Value = cls.Pubblica
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SePresenteCalcolaSuSoggetti Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SePresenteCalcolaSuSoggetti"
							p.Value = cls.SePresenteCalcolaSuSoggetti
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sigla Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sigla"
							p.Value = cls.Sigla
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SuCommessa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SuCommessa"
							p.Value = cls.SuCommessa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SuProdotto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SuProdotto"
							p.Value = cls.SuProdotto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TempoRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TempoRif"
							p.Value = cls.TempoRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoControlloWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoControlloWeb"
							p.Value = cls.TipoControlloWeb
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdLavoro=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdLavoro = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdLavoro
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLavoro
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
				'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_lavori"
				Sql &= " WHERE IdLavoro = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_lavori. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_lavori. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as LavorazioneW, Optional ByRef ListaObj as List (of LavorazioneW) = Nothing)
		DestroyPermanently (obj.IdLavoro)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioneW
		Dim ris As LavorazioneW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of LavorazioneW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return first of LavorazioneW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioneW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return first of LavorazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioneW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table LavorazioneW
	''' </summary>
	''' <returns>
	'''Return first of LavorazioneW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As LavorazioneW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioneW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioneW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioneW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioneW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of LavorazioneW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of LavorazioneW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_lavori by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of LavorazioneW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioneW)
		Dim Ls As New List(Of LavorazioneW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of LavorazioneW)
		Dim Ls As New List(Of LavorazioneW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_lavori" 
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
	'''Return all record on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioneW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of LavorazioneW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioneW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioneW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_lavori
	''' </summary>
	''' <returns>
	'''Return all record in list of LavorazioneW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of LavorazioneW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavorazioneW)
		Dim Ls As List(Of LavorazioneW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_lavori" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of LavorazioneW)
		Dim Ls As New List(Of LavorazioneW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  LavorazioneW() With {.IdLavoro = 0 ,.Accorpabile = 0 ,.CostoSingCopia = 0 ,.Descrizione = EmptyItemDescription,.DescrizioneEstesa = "" ,.DimensMaxH = 0 ,.DimensMaxW = 0 ,.DimensMedieMaxH = 0 ,.DimensMedieMaxW = 0 ,.DimensMedieMinH = 0 ,.DimensMedieMinW = 0 ,.DimensMinH = 0 ,.DimensMinW = 0 ,.ExtraData = "" ,.FormatoRiferimento = "" ,.ggRealiz = 0 ,.GrammiMax = 0 ,.GrammiMin = 0 ,.IdCatLav = 0 ,.IdMacchinario = 0 ,.IdMacchinario2 = 0 ,.IdTipoLav = 0 ,.ImgRif = "" ,.ImgZoom = "" ,.LavorazioneInterna = 0 ,.Macchinario = "" ,.Premio = 0 ,.PreTaglio = 0 ,.Prezzo = 0 ,.Pubblica = False ,.SePresenteCalcolaSuSoggetti = 0 ,.Sigla = "" ,.Stato = 0 ,.SuCommessa = False ,.SuProdotto = False ,.TempoRif = 0 ,.TipoControlloWeb = 0  })
					While myReader.Read
						Dim classe as new LavorazioneW(CType(myReader, IDataRecord))
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