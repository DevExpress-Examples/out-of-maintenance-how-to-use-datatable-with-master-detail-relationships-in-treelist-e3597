using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace treelist
{
    class UnboundMasterDetailTree
    {
        DataTable _dataSource;
        public DataTable DataSource
        {
            get { return _dataSource; }
            set
            {
                if (_dataSource == value)
                    return;
                _dataSource = value;
                //_masterTreeList.RefreshDataSource();
            }
        }
        TreeList _masterTreeList;
        TreeList MasterTreeList
        {
            get { return _masterTreeList; }
            set
            {
                if (_masterTreeList == value)
                    return;
                Detach();
                Attach(value);
            }
        }

        public UnboundMasterDetailTree(TreeList masterTreeList, DataTable dt)
        {
            MasterTreeList = masterTreeList;
            _masterTreeList.BeforeExpand += new BeforeExpandEventHandler(BeforeExpand);
            _masterTreeList.CellValueChanged += new CellValueChangedEventHandler(_masterTreeList_CellValueChanged);
            _dataSource = dt;
            foreach (DataRow row in _dataSource.Select())
            {
                TreeListNode node = _masterTreeList.AppendNode(new object[] { row["ID"], null, row["Value"] }, null, row);
                node.HasChildren = row.Table.ChildRelations.Count != 0;
            }
        }

        void _masterTreeList_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            (e.Node.Tag as DataRow)[e.Column.FieldName] = e.Value;
        }

        void Detach()
        {
        }
        void Attach(TreeList treeList)
        {
            _masterTreeList = treeList;
        }
        private void BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (e.Node.Nodes.Count != 0) return;
            DataRow row = e.Node.Tag as DataRow;
            foreach (DataRow childRow in row.GetChildRows(row.Table.ChildRelations[0]))
            {
                TreeListNode node = MasterTreeList.AppendNode(new object[] { childRow["ID"], childRow["ParentID"], childRow["Value"] }, e.Node, childRow);
                node.HasChildren = childRow.Table.ChildRelations.Count != 0;
            }
        }


    }
}
