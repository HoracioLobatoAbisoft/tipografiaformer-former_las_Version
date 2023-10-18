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
'''DAO Class for table Localita
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Localita
	Inherits LUNA.LunaBaseClassEntity
	Implements _ILocalita
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ILocalita.FillFromDataRecord
		IdLocalita = myRecord("IdLocalita")
		if not myRecord("ALTITUDINE") is DBNull.Value then ALTITUDINE = myRecord("ALTITUDINE")
		if not myRecord("CENTRO") is DBNull.Value then CENTRO = myRecord("CENTRO")
		if not myRecord("IdComune") is DBNull.Value then IdComune = myRecord("IdComune")
		if not myRecord("IdProvincia") is DBNull.Value then IdProvincia = myRecord("IdProvincia")
		if not myRecord("IdRegione") is DBNull.Value then IdRegione = myRecord("IdRegione")
		loc = myRecord("loc")
		if not myRecord("localita") is DBNull.Value then localita = myRecord("localita")
		if not myRecord("POP2001") is DBNull.Value then POP2001 = myRecord("POP2001")
		if not myRecord("TIPO_LOC") is DBNull.Value then TIPO_LOC = myRecord("TIPO_LOC")
		if not myRecord("xcoord") is DBNull.Value then xcoord = myRecord("xcoord")
		if not myRecord("ycoord") is DBNull.Value then ycoord = myRecord("ycoord")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of Localita)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(LocalitaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of Localita))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdLocalita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ALTITUDINE As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property CENTRO As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdComune As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdProvincia As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdRegione As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property loc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property localita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property POP2001 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TIPO_LOC As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property xcoord As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ycoord As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdLocalita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ALTITUDINE = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.CENTRO = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdComune = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdProvincia = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdRegione = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.loc = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.localita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.POP2001 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TIPO_LOC = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.xcoord = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ycoord = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdLocalita as Double  = 0 
	Public Overridable Property IdLocalita() as Double  Implements _ILocalita.IdLocalita
		Get
			Return _IdLocalita
		End Get
		Set (byval value as Double)
			If _IdLocalita <> value Then
				IsChanged = True
				WhatIsChanged.IdLocalita = True
				_IdLocalita = value
			End If
		End Set
	End property 

	Protected _ALTITUDINE as string  = "" 
	Public Overridable Property ALTITUDINE() as string  Implements _ILocalita.ALTITUDINE
		Get
			Return _ALTITUDINE
		End Get
		Set (byval value as string)
			If _ALTITUDINE <> value Then
				IsChanged = True
				WhatIsChanged.ALTITUDINE = True
				_ALTITUDINE = value
			End If
		End Set
	End property 

	Protected _CENTRO as integer  = 0 
	Public Overridable Property CENTRO() as integer  Implements _ILocalita.CENTRO
		Get
			Return _CENTRO
		End Get
		Set (byval value as integer)
			If _CENTRO <> value Then
				IsChanged = True
				WhatIsChanged.CENTRO = True
				_CENTRO = value
			End If
		End Set
	End property 

	Protected _IdComune as integer  = 0 
	Public Overridable Property IdComune() as integer  Implements _ILocalita.IdComune
		Get
			Return _IdComune
		End Get
		Set (byval value as integer)
			If _IdComune <> value Then
				IsChanged = True
				WhatIsChanged.IdComune = True
				_IdComune = value
			End If
		End Set
	End property 

	Protected _IdProvincia as integer  = 0 
	Public Overridable Property IdProvincia() as integer  Implements _ILocalita.IdProvincia
		Get
			Return _IdProvincia
		End Get
		Set (byval value as integer)
			If _IdProvincia <> value Then
				IsChanged = True
				WhatIsChanged.IdProvincia = True
				_IdProvincia = value
			End If
		End Set
	End property 

	Protected _IdRegione as integer  = 0 
	Public Overridable Property IdRegione() as integer  Implements _ILocalita.IdRegione
		Get
			Return _IdRegione
		End Get
		Set (byval value as integer)
			If _IdRegione <> value Then
				IsChanged = True
				WhatIsChanged.IdRegione = True
				_IdRegione = value
			End If
		End Set
	End property 

	Protected _loc as integer  = 0 
	Public Overridable Property loc() as integer  Implements _ILocalita.loc
		Get
			Return _loc
		End Get
		Set (byval value as integer)
			If _loc <> value Then
				IsChanged = True
				WhatIsChanged.loc = True
				_loc = value
			End If
		End Set
	End property 

	Protected _localita as string  = "" 
	Public Overridable Property localita() as string  Implements _ILocalita.localita
		Get
			Return _localita
		End Get
		Set (byval value as string)
			If _localita <> value Then
				IsChanged = True
				WhatIsChanged.localita = True
				_localita = value
			End If
		End Set
	End property 

	Protected _POP2001 as integer  = 0 
	Public Overridable Property POP2001() as integer  Implements _ILocalita.POP2001
		Get
			Return _POP2001
		End Get
		Set (byval value as integer)
			If _POP2001 <> value Then
				IsChanged = True
				WhatIsChanged.POP2001 = True
				_POP2001 = value
			End If
		End Set
	End property 

	Protected _TIPO_LOC as integer  = 0 
	Public Overridable Property TIPO_LOC() as integer  Implements _ILocalita.TIPO_LOC
		Get
			Return _TIPO_LOC
		End Get
		Set (byval value as integer)
			If _TIPO_LOC <> value Then
				IsChanged = True
				WhatIsChanged.TIPO_LOC = True
				_TIPO_LOC = value
			End If
		End Set
	End property 

	Protected _xcoord as Double  = 0 
	Public Overridable Property xcoord() as Double  Implements _ILocalita.xcoord
		Get
			Return _xcoord
		End Get
		Set (byval value as Double)
			If _xcoord <> value Then
				IsChanged = True
				WhatIsChanged.xcoord = True
				_xcoord = value
			End If
		End Set
	End property 

	Protected _ycoord as Double  = 0 
	Public Overridable Property ycoord() as Double  Implements _ILocalita.ycoord
		Get
			Return _ycoord
		End Get
		Set (byval value as Double)
			If _ycoord <> value Then
				IsChanged = True
				WhatIsChanged.ycoord = True
				_ycoord = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an Localita from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As Localita = Manager.Read(Id)
				_IdLocalita = int.IdLocalita
				_ALTITUDINE = int.ALTITUDINE
				_CENTRO = int.CENTRO
				_IdComune = int.IdComune
				_IdProvincia = int.IdProvincia
				_IdRegione = int.IdRegione
				_loc = int.loc
				_localita = int.localita
				_POP2001 = int.POP2001
				_TIPO_LOC = int.TIPO_LOC
				_xcoord = int.xcoord
				_ycoord = int.ycoord
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an Localita on DB.
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
		if _ALTITUDINE.Length > 255 then Ris = False
		if _localita.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Localita
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ILocalita

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdLocalita() as Double
	Property ALTITUDINE() as string
	Property CENTRO() as integer
	Property IdComune() as integer
	Property IdProvincia() as integer
	Property IdRegione() as integer
	Property loc() as integer
	Property localita() as string
	Property POP2001() as integer
	Property TIPO_LOC() as integer
	Property xcoord() as Double
	Property ycoord() as Double

#End Region

End Interface

Partial Public Class LFM

	Public Class Localita
		Public Shared ReadOnly Property IdLocalita As New LUNA.LunaFieldName("IdLocalita")
		Public Shared ReadOnly Property ALTITUDINE As New LUNA.LunaFieldName("ALTITUDINE")
		Public Shared ReadOnly Property CENTRO As New LUNA.LunaFieldName("CENTRO")
		Public Shared ReadOnly Property IdComune As New LUNA.LunaFieldName("IdComune")
		Public Shared ReadOnly Property IdProvincia As New LUNA.LunaFieldName("IdProvincia")
		Public Shared ReadOnly Property IdRegione As New LUNA.LunaFieldName("IdRegione")
		Public Shared ReadOnly Property loc As New LUNA.LunaFieldName("loc")
		Public Shared ReadOnly Property localita As New LUNA.LunaFieldName("localita")
		Public Shared ReadOnly Property POP2001 As New LUNA.LunaFieldName("POP2001")
		Public Shared ReadOnly Property TIPO_LOC As New LUNA.LunaFieldName("TIPO_LOC")
		Public Shared ReadOnly Property xcoord As New LUNA.LunaFieldName("xcoord")
		Public Shared ReadOnly Property ycoord As New LUNA.LunaFieldName("ycoord")
	End Class

End Class