Imports Microsoft.VisualBasic
Imports System
Namespace E3597
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.treeList2 = New DevExpress.XtraTreeList.TreeList()
			Me.treeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.treeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.treeListColumn3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.treeListColumn4 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.treeListColumn5 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.treeListColumn6 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.treeList2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.treeListColumn1, Me.treeListColumn2, Me.treeListColumn3})
			Me.treeList1.Location = New System.Drawing.Point(12, 46)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(396, 354)
			Me.treeList1.TabIndex = 0
			' 
			' treeList2
			' 
			Me.treeList2.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.treeListColumn4, Me.treeListColumn5, Me.treeListColumn6})
			Me.treeList2.Location = New System.Drawing.Point(427, 46)
			Me.treeList2.Name = "treeList2"
			Me.treeList2.Size = New System.Drawing.Size(407, 354)
			Me.treeList2.TabIndex = 1
			' 
			' treeListColumn1
			' 
			Me.treeListColumn1.Caption = "ID"
			Me.treeListColumn1.FieldName = "ID"
			Me.treeListColumn1.Name = "treeListColumn1"
			Me.treeListColumn1.Visible = True
			Me.treeListColumn1.VisibleIndex = 0
			' 
			' treeListColumn2
			' 
			Me.treeListColumn2.Caption = "ParentID"
			Me.treeListColumn2.FieldName = "ParentID"
			Me.treeListColumn2.Name = "treeListColumn2"
			Me.treeListColumn2.Visible = True
			Me.treeListColumn2.VisibleIndex = 1
			' 
			' treeListColumn3
			' 
			Me.treeListColumn3.Caption = "Value"
			Me.treeListColumn3.FieldName = "Value"
			Me.treeListColumn3.Name = "treeListColumn3"
			Me.treeListColumn3.Visible = True
			Me.treeListColumn3.VisibleIndex = 2
			' 
			' treeListColumn4
			' 
			Me.treeListColumn4.Caption = "ID"
			Me.treeListColumn4.FieldName = "ID"
			Me.treeListColumn4.Name = "treeListColumn4"
			Me.treeListColumn4.Visible = True
			Me.treeListColumn4.VisibleIndex = 0
			' 
			' treeListColumn5
			' 
			Me.treeListColumn5.Caption = "ParentID"
			Me.treeListColumn5.FieldName = "ParentID"
			Me.treeListColumn5.Name = "treeListColumn5"
			Me.treeListColumn5.Visible = True
			Me.treeListColumn5.VisibleIndex = 1
			' 
			' treeListColumn6
			' 
			Me.treeListColumn6.Caption = "Value"
			Me.treeListColumn6.FieldName = "Value"
			Me.treeListColumn6.Name = "treeListColumn6"
			Me.treeListColumn6.Visible = True
			Me.treeListColumn6.VisibleIndex = 2
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(12, 13)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(112, 13)
			Me.labelControl1.TabIndex = 2
			Me.labelControl1.Text = "VirtualMasterDetailTree"
			' 
			' labelControl2
			' 
			Me.labelControl2.Location = New System.Drawing.Point(427, 12)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(125, 13)
			Me.labelControl2.TabIndex = 3
			Me.labelControl2.Text = "UnboundMasterDetailTree"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(846, 412)
			Me.Controls.Add(Me.labelControl2)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.treeList2)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.treeList2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private treeList1 As DevExpress.XtraTreeList.TreeList
		Private treeList2 As DevExpress.XtraTreeList.TreeList
		Private treeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private treeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private treeListColumn3 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private treeListColumn4 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private treeListColumn5 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private treeListColumn6 As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private labelControl2 As DevExpress.XtraEditors.LabelControl


	End Class
End Namespace

