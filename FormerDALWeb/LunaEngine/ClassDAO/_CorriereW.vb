#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_corriere
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _CorriereW
	Inherits LUNA.LunaBaseClassEntity
	Implements _ICorriereW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ICorriereW.FillFromDataRecord
		IdCorriere = myRecord("IdCorriere")
		if not myRecord("Costo") is DBNull.Value then Costo = myRecord("Costo")
		Descrizione = myRecord("Descrizione")
		if not myRecord("Disattivo") is DBNull.Value then Disattivo = myRecord("Disattivo")
		if not myRecord("DisponibileOnline") is DBNull.Value then DisponibileOnline = myRecord("DisponibileOnline")
		if not myRecord("GGConsegna") is DBNull.Value then GGConsegna = myRecord("GGConsegna")
		if not myRecord("KgLimite1") is DBNull.Value then KgLimite1 = myRecord("KgLimite1")
		if not myRecord("KgLimite2") is DBNull.Value then KgLimite2 = myRecord("KgLimite2")
		if not myRecord("KgLimite3") is DBNull.Value then KgLimite3 = myRecord("KgLimite3")
		if not myRecord("KgLimite4") is DBNull.Value then KgLimite4 = myRecord("KgLimite4")
		if not myRecord("KgLimite5") is DBNull.Value then KgLimite5 = myRecord("KgLimite5")
		if not myRecord("KgLimite6") is DBNull.Value then KgLimite6 = myRecord("KgLimite6")
		if not myRecord("KgLimite7") is DBNull.Value then KgLimite7 = myRecord("KgLimite7")
		if not myRecord("Label") is DBNull.Value then Label = myRecord("Label")
		if not myRecord("NomeBreve") is DBNull.Value then NomeBreve = myRecord("NomeBreve")
		if not myRecord("PathTrack") is DBNull.Value then PathTrack = myRecord("PathTrack")
		if not myRecord("PercPortoAssegnato") is DBNull.Value then PercPortoAssegnato = myRecord("PercPortoAssegnato")
		PrevedeAccorpamento = myRecord("PrevedeAccorpamento")
		if not myRecord("TariffaLimite1") is DBNull.Value then TariffaLimite1 = myRecord("TariffaLimite1")
		if not myRecord("TariffaLimite2") is DBNull.Value then TariffaLimite2 = myRecord("TariffaLimite2")
		if not myRecord("TariffaLimite3") is DBNull.Value then TariffaLimite3 = myRecord("TariffaLimite3")
		if not myRecord("TariffaLimite4") is DBNull.Value then TariffaLimite4 = myRecord("TariffaLimite4")
		if not myRecord("TariffaLimite5") is DBNull.Value then TariffaLimite5 = myRecord("TariffaLimite5")
		if not myRecord("TariffaLimite6") is DBNull.Value then TariffaLimite6 = myRecord("TariffaLimite6")
		if not myRecord("TariffaLimite7") is DBNull.Value then TariffaLimite7 = myRecord("TariffaLimite7")
		if not myRecord("TestoMail") is DBNull.Value then TestoMail = myRecord("TestoMail")
		if not myRecord("TipoCorriere") is DBNull.Value then TipoCorriere = myRecord("TipoCorriere")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of CorriereW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(CorrieriWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of CorriereW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Costo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Descrizione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Disattivo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DisponibileOnline As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property GGConsegna As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property KgLimite7 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Label As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeBreve As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PathTrack As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercPortoAssegnato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PrevedeAccorpamento As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite4 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite5 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite6 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TariffaLimite7 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TestoMail As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TipoCorriere As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Costo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Descrizione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Disattivo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DisponibileOnline = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.GGConsegna = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite6 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.KgLimite7 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Label = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeBreve = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PathTrack = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercPortoAssegnato = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PrevedeAccorpamento = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite4 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite5 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite6 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TariffaLimite7 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TestoMail = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TipoCorriere = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdCorriere as integer  = 0 
	Public Overridable Property IdCorriere() as integer  Implements _ICorriereW.IdCorriere
		Get
			Return _IdCorriere
		End Get
		Set (byval value as integer)
			If _IdCorriere <> value Then
				IsChanged = True
				WhatIsChanged.IdCorriere = True
				_IdCorriere = value
			End If
		End Set
	End property 

	Protected _Costo as decimal  = 0 
	Public Overridable Property Costo() as decimal  Implements _ICorriereW.Costo
		Get
			Return _Costo
		End Get
		Set (byval value as decimal)
			If _Costo <> value Then
				IsChanged = True
				WhatIsChanged.Costo = True
				_Costo = value
			End If
		End Set
	End property 

	Protected _Descrizione as string  = "" 
	Public Overridable Property Descrizione() as string  Implements _ICorriereW.Descrizione
		Get
			Return _Descrizione
		End Get
		Set (byval value as string)
			If _Descrizione <> value Then
				IsChanged = True
				WhatIsChanged.Descrizione = True
				_Descrizione = value
			End If
		End Set
	End property 

	Protected _Disattivo as integer  = 0 
	Public Overridable Property Disattivo() as integer  Implements _ICorriereW.Disattivo
		Get
			Return _Disattivo
		End Get
		Set (byval value as integer)
			If _Disattivo <> value Then
				IsChanged = True
				WhatIsChanged.Disattivo = True
				_Disattivo = value
			End If
		End Set
	End property 

	Protected _DisponibileOnline as Boolean  = False 
	Public Overridable Property DisponibileOnline() as Boolean  Implements _ICorriereW.DisponibileOnline
		Get
			Return _DisponibileOnline
		End Get
		Set (byval value as Boolean)
			If _DisponibileOnline <> value Then
				IsChanged = True
				WhatIsChanged.DisponibileOnline = True
				_DisponibileOnline = value
			End If
		End Set
	End property 

	Protected _GGConsegna as integer  = 0 
	Public Overridable Property GGConsegna() as integer  Implements _ICorriereW.GGConsegna
		Get
			Return _GGConsegna
		End Get
		Set (byval value as integer)
			If _GGConsegna <> value Then
				IsChanged = True
				WhatIsChanged.GGConsegna = True
				_GGConsegna = value
			End If
		End Set
	End property 

	Protected _KgLimite1 as integer  = 0 
	Public Overridable Property KgLimite1() as integer  Implements _ICorriereW.KgLimite1
		Get
			Return _KgLimite1
		End Get
		Set (byval value as integer)
			If _KgLimite1 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite1 = True
				_KgLimite1 = value
			End If
		End Set
	End property 

	Protected _KgLimite2 as integer  = 0 
	Public Overridable Property KgLimite2() as integer  Implements _ICorriereW.KgLimite2
		Get
			Return _KgLimite2
		End Get
		Set (byval value as integer)
			If _KgLimite2 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite2 = True
				_KgLimite2 = value
			End If
		End Set
	End property 

	Protected _KgLimite3 as integer  = 0 
	Public Overridable Property KgLimite3() as integer  Implements _ICorriereW.KgLimite3
		Get
			Return _KgLimite3
		End Get
		Set (byval value as integer)
			If _KgLimite3 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite3 = True
				_KgLimite3 = value
			End If
		End Set
	End property 

	Protected _KgLimite4 as integer  = 0 
	Public Overridable Property KgLimite4() as integer  Implements _ICorriereW.KgLimite4
		Get
			Return _KgLimite4
		End Get
		Set (byval value as integer)
			If _KgLimite4 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite4 = True
				_KgLimite4 = value
			End If
		End Set
	End property 

	Protected _KgLimite5 as integer  = 0 
	Public Overridable Property KgLimite5() as integer  Implements _ICorriereW.KgLimite5
		Get
			Return _KgLimite5
		End Get
		Set (byval value as integer)
			If _KgLimite5 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite5 = True
				_KgLimite5 = value
			End If
		End Set
	End property 

	Protected _KgLimite6 as integer  = 0 
	Public Overridable Property KgLimite6() as integer  Implements _ICorriereW.KgLimite6
		Get
			Return _KgLimite6
		End Get
		Set (byval value as integer)
			If _KgLimite6 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite6 = True
				_KgLimite6 = value
			End If
		End Set
	End property 

	Protected _KgLimite7 as integer  = 0 
	Public Overridable Property KgLimite7() as integer  Implements _ICorriereW.KgLimite7
		Get
			Return _KgLimite7
		End Get
		Set (byval value as integer)
			If _KgLimite7 <> value Then
				IsChanged = True
				WhatIsChanged.KgLimite7 = True
				_KgLimite7 = value
			End If
		End Set
	End property 

	Protected _Label as string  = "" 
	Public Overridable Property Label() as string  Implements _ICorriereW.Label
		Get
			Return _Label
		End Get
		Set (byval value as string)
			If _Label <> value Then
				IsChanged = True
				WhatIsChanged.Label = True
				_Label = value
			End If
		End Set
	End property 

	Protected _NomeBreve as string  = "" 
	Public Overridable Property NomeBreve() as string  Implements _ICorriereW.NomeBreve
		Get
			Return _NomeBreve
		End Get
		Set (byval value as string)
			If _NomeBreve <> value Then
				IsChanged = True
				WhatIsChanged.NomeBreve = True
				_NomeBreve = value
			End If
		End Set
	End property 

	Protected _PathTrack as string  = "" 
	Public Overridable Property PathTrack() as string  Implements _ICorriereW.PathTrack
		Get
			Return _PathTrack
		End Get
		Set (byval value as string)
			If _PathTrack <> value Then
				IsChanged = True
				WhatIsChanged.PathTrack = True
				_PathTrack = value
			End If
		End Set
	End property 

	Protected _PercPortoAssegnato as integer  = 0 
	Public Overridable Property PercPortoAssegnato() as integer  Implements _ICorriereW.PercPortoAssegnato
		Get
			Return _PercPortoAssegnato
		End Get
		Set (byval value as integer)
			If _PercPortoAssegnato <> value Then
				IsChanged = True
				WhatIsChanged.PercPortoAssegnato = True
				_PercPortoAssegnato = value
			End If
		End Set
	End property 

	Protected _PrevedeAccorpamento as Boolean  = False 
	Public Overridable Property PrevedeAccorpamento() as Boolean  Implements _ICorriereW.PrevedeAccorpamento
		Get
			Return _PrevedeAccorpamento
		End Get
		Set (byval value as Boolean)
			If _PrevedeAccorpamento <> value Then
				IsChanged = True
				WhatIsChanged.PrevedeAccorpamento = True
				_PrevedeAccorpamento = value
			End If
		End Set
	End property 

	Protected _TariffaLimite1 as decimal  = 0 
	Public Overridable Property TariffaLimite1() as decimal  Implements _ICorriereW.TariffaLimite1
		Get
			Return _TariffaLimite1
		End Get
		Set (byval value as decimal)
			If _TariffaLimite1 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite1 = True
				_TariffaLimite1 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite2 as decimal  = 0 
	Public Overridable Property TariffaLimite2() as decimal  Implements _ICorriereW.TariffaLimite2
		Get
			Return _TariffaLimite2
		End Get
		Set (byval value as decimal)
			If _TariffaLimite2 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite2 = True
				_TariffaLimite2 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite3 as decimal  = 0 
	Public Overridable Property TariffaLimite3() as decimal  Implements _ICorriereW.TariffaLimite3
		Get
			Return _TariffaLimite3
		End Get
		Set (byval value as decimal)
			If _TariffaLimite3 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite3 = True
				_TariffaLimite3 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite4 as decimal  = 0 
	Public Overridable Property TariffaLimite4() as decimal  Implements _ICorriereW.TariffaLimite4
		Get
			Return _TariffaLimite4
		End Get
		Set (byval value as decimal)
			If _TariffaLimite4 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite4 = True
				_TariffaLimite4 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite5 as decimal  = 0 
	Public Overridable Property TariffaLimite5() as decimal  Implements _ICorriereW.TariffaLimite5
		Get
			Return _TariffaLimite5
		End Get
		Set (byval value as decimal)
			If _TariffaLimite5 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite5 = True
				_TariffaLimite5 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite6 as decimal  = 0 
	Public Overridable Property TariffaLimite6() as decimal  Implements _ICorriereW.TariffaLimite6
		Get
			Return _TariffaLimite6
		End Get
		Set (byval value as decimal)
			If _TariffaLimite6 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite6 = True
				_TariffaLimite6 = value
			End If
		End Set
	End property 

	Protected _TariffaLimite7 as decimal  = 0 
	Public Overridable Property TariffaLimite7() as decimal  Implements _ICorriereW.TariffaLimite7
		Get
			Return _TariffaLimite7
		End Get
		Set (byval value as decimal)
			If _TariffaLimite7 <> value Then
				IsChanged = True
				WhatIsChanged.TariffaLimite7 = True
				_TariffaLimite7 = value
			End If
		End Set
	End property 

	Protected _TestoMail as string  = "" 
	Public Overridable Property TestoMail() as string  Implements _ICorriereW.TestoMail
		Get
			Return _TestoMail
		End Get
		Set (byval value as string)
			If _TestoMail <> value Then
				IsChanged = True
				WhatIsChanged.TestoMail = True
				_TestoMail = value
			End If
		End Set
	End property 

	Protected _TipoCorriere as integer  = 0 
	Public Overridable Property TipoCorriere() as integer  Implements _ICorriereW.TipoCorriere
		Get
			Return _TipoCorriere
		End Get
		Set (byval value as integer)
			If _TipoCorriere <> value Then
				IsChanged = True
				WhatIsChanged.TipoCorriere = True
				_TipoCorriere = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an CorriereW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As CorriereW = Manager.Read(Id)
				_IdCorriere = int.IdCorriere
				_Costo = int.Costo
				_Descrizione = int.Descrizione
				_Disattivo = int.Disattivo
				_DisponibileOnline = int.DisponibileOnline
				_GGConsegna = int.GGConsegna
				_KgLimite1 = int.KgLimite1
				_KgLimite2 = int.KgLimite2
				_KgLimite3 = int.KgLimite3
				_KgLimite4 = int.KgLimite4
				_KgLimite5 = int.KgLimite5
				_KgLimite6 = int.KgLimite6
				_KgLimite7 = int.KgLimite7
				_Label = int.Label
				_NomeBreve = int.NomeBreve
				_PathTrack = int.PathTrack
				_PercPortoAssegnato = int.PercPortoAssegnato
				_PrevedeAccorpamento = int.PrevedeAccorpamento
				_TariffaLimite1 = int.TariffaLimite1
				_TariffaLimite2 = int.TariffaLimite2
				_TariffaLimite3 = int.TariffaLimite3
				_TariffaLimite4 = int.TariffaLimite4
				_TariffaLimite5 = int.TariffaLimite5
				_TariffaLimite6 = int.TariffaLimite6
				_TariffaLimite7 = int.TariffaLimite7
				_TestoMail = int.TestoMail
				_TipoCorriere = int.TipoCorriere
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an CorriereW on DB.
	''' </summary>
	''' <returns>
	'''Return Id insert in DB if all ok, 0 if error
	''' </returns>
	Public Overridable Function Save() As Integer
		'Return the id Inserted
		Dim Ris As Integer = 0
		Try
			Using Manager
				Ris = Manager.Save(Me)
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True
  
		if _Descrizione.Length = 0 then Ris = False
		if _Descrizione.Length > 50 then Ris = False
		if _Label.Length > 255 then Ris = False
		if _NomeBreve.Length > 255 then Ris = False
		if _PathTrack.Length > 255 then Ris = False
		if _TestoMail.Length > 80 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_corriere
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ICorriereW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdCorriere() as integer
	Property Costo() as decimal
	Property Descrizione() as string
	Property Disattivo() as integer
	Property DisponibileOnline() as Boolean
	Property GGConsegna() as integer
	Property KgLimite1() as integer
	Property KgLimite2() as integer
	Property KgLimite3() as integer
	Property KgLimite4() as integer
	Property KgLimite5() as integer
	Property KgLimite6() as integer
	Property KgLimite7() as integer
	Property Label() as string
	Property NomeBreve() as string
	Property PathTrack() as string
	Property PercPortoAssegnato() as integer
	Property PrevedeAccorpamento() as Boolean
	Property TariffaLimite1() as decimal
	Property TariffaLimite2() as decimal
	Property TariffaLimite3() as decimal
	Property TariffaLimite4() as decimal
	Property TariffaLimite5() as decimal
	Property TariffaLimite6() as decimal
	Property TariffaLimite7() as decimal
	Property TestoMail() as string
	Property TipoCorriere() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class CorriereW
		Public Shared ReadOnly Property IdCorriere As New LUNA.LunaFieldName("IdCorriere")
		Public Shared ReadOnly Property Costo As New LUNA.LunaFieldName("Costo")
		Public Shared ReadOnly Property Descrizione As New LUNA.LunaFieldName("Descrizione")
		Public Shared ReadOnly Property Disattivo As New LUNA.LunaFieldName("Disattivo")
		Public Shared ReadOnly Property DisponibileOnline As New LUNA.LunaFieldName("DisponibileOnline")
		Public Shared ReadOnly Property GGConsegna As New LUNA.LunaFieldName("GGConsegna")
		Public Shared ReadOnly Property KgLimite1 As New LUNA.LunaFieldName("KgLimite1")
		Public Shared ReadOnly Property KgLimite2 As New LUNA.LunaFieldName("KgLimite2")
		Public Shared ReadOnly Property KgLimite3 As New LUNA.LunaFieldName("KgLimite3")
		Public Shared ReadOnly Property KgLimite4 As New LUNA.LunaFieldName("KgLimite4")
		Public Shared ReadOnly Property KgLimite5 As New LUNA.LunaFieldName("KgLimite5")
		Public Shared ReadOnly Property KgLimite6 As New LUNA.LunaFieldName("KgLimite6")
		Public Shared ReadOnly Property KgLimite7 As New LUNA.LunaFieldName("KgLimite7")
		Public Shared ReadOnly Property Label As New LUNA.LunaFieldName("Label")
		Public Shared ReadOnly Property NomeBreve As New LUNA.LunaFieldName("NomeBreve")
		Public Shared ReadOnly Property PathTrack As New LUNA.LunaFieldName("PathTrack")
		Public Shared ReadOnly Property PercPortoAssegnato As New LUNA.LunaFieldName("PercPortoAssegnato")
		Public Shared ReadOnly Property PrevedeAccorpamento As New LUNA.LunaFieldName("PrevedeAccorpamento")
		Public Shared ReadOnly Property TariffaLimite1 As New LUNA.LunaFieldName("TariffaLimite1")
		Public Shared ReadOnly Property TariffaLimite2 As New LUNA.LunaFieldName("TariffaLimite2")
		Public Shared ReadOnly Property TariffaLimite3 As New LUNA.LunaFieldName("TariffaLimite3")
		Public Shared ReadOnly Property TariffaLimite4 As New LUNA.LunaFieldName("TariffaLimite4")
		Public Shared ReadOnly Property TariffaLimite5 As New LUNA.LunaFieldName("TariffaLimite5")
		Public Shared ReadOnly Property TariffaLimite6 As New LUNA.LunaFieldName("TariffaLimite6")
		Public Shared ReadOnly Property TariffaLimite7 As New LUNA.LunaFieldName("TariffaLimite7")
		Public Shared ReadOnly Property TestoMail As New LUNA.LunaFieldName("TestoMail")
		Public Shared ReadOnly Property TipoCorriere As New LUNA.LunaFieldName("TipoCorriere")
	End Class

End Class