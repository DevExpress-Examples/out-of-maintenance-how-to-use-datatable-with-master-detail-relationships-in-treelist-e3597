Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace E3597
	Partial Public Class Form1
		Inherits Form
		Private ds As New DataSet1()
		Public Sub New()
			InitializeComponent()
			FillDataSet()
			Dim virtualHelper As New VirtualMasterDetailTree(treeList1, ds.MasterTable)
			Dim unboundHelper As New UnboundMasterDetailTree(treeList2, ds.MasterTable)

		End Sub
		Private Sub FillDataSet()
			For i As Integer = 0 To 4

				ds.MasterTable.Rows.Add(i, "Master " & i)
				For j As Integer = 0 To 4
					ds.Child1.Rows.Add(i * 100 + j, i, "Child1:" & j)
					For k As Integer = 0 To 4
						ds.Child3.Rows.Add((i * 100 + j) * 100 + k, i * 100 + j, "Child3:" & k)
					Next k
				Next j
			Next i
		End Sub

	End Class
End Namespace