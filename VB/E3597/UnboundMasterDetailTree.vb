Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes

Namespace E3597
    Friend Class UnboundMasterDetailTree
        Private _dataSource As DataTable
        Public Property DataSource() As DataTable
            Get
                Return _dataSource
            End Get
            Set(ByVal value As DataTable)
                If _dataSource Is value Then
                    Return
                End If
                _dataSource = value
            End Set
        End Property
        Private _masterTreeList As treelist
        Private Property MasterTreeList() As treelist
            Get
                Return _masterTreeList
            End Get
            Set(ByVal value As treelist)
                If _masterTreeList Is value Then
                    Return
                End If
                Detach()
                Attach(value)
            End Set
        End Property

        Public Sub New(ByVal masterTreeList As treelist, ByVal dt As DataTable)
            Me.MasterTreeList = masterTreeList
            AddHandler _masterTreeList.BeforeExpand, AddressOf BeforeExpand
            AddHandler _masterTreeList.CellValueChanged, AddressOf _masterTreeList_CellValueChanged
            Dim rootNode As TreeListNode = Nothing

            _dataSource = dt
            For Each row As DataRow In _dataSource.Select()
                Dim node As TreeListNode = _masterTreeList.AppendNode(New Object() {row("ID"), Nothing, row("Value")}, rootNode, row)
                node.HasChildren = row.Table.ChildRelations.Count <> 0
            Next row
        End Sub

        Private Sub _masterTreeList_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs)
            TryCast(e.Node.Tag, DataRow)(e.Column.FieldName) = e.Value
        End Sub

        Private Sub Detach()
        End Sub
        Private Sub Attach(ByVal treeList As treelist)
            _masterTreeList = treeList
        End Sub
        Private Sub BeforeExpand(ByVal sender As Object, ByVal e As BeforeExpandEventArgs)
            If e.Node.Nodes.Count <> 0 Then
                Return
            End If
            Dim row As DataRow = TryCast(e.Node.Tag, DataRow)
            For Each childRow As DataRow In row.GetChildRows(row.Table.ChildRelations(0))
                Dim node As TreeListNode = MasterTreeList.AppendNode(New Object() {childRow("ID"), childRow("ParentID"), childRow("Value")}, e.Node, childRow)
                node.HasChildren = childRow.Table.ChildRelations.Count <> 0
            Next childRow
        End Sub


    End Class
End Namespace
