using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using treelist;

namespace E3597
{
    public partial class Form1 : Form
    {
        DataSet1 ds = new DataSet1();
        public Form1()
        {
            InitializeComponent();
            FillDataSet();
            VirtualMasterDetailTree virtualHelper = new VirtualMasterDetailTree(treeList1, ds.MasterTable);
            UnboundMasterDetailTree unboundHelper = new UnboundMasterDetailTree(treeList2, ds.MasterTable);

        }
        void FillDataSet()
        {
            for (int i = 0; i < 5; i++)
            {

                ds.MasterTable.Rows.Add(i, "Master " + i);
                for (int j = 0; j < 5; j++)
                {
                    ds.Child1.Rows.Add(i * 100 + j, i, "Child1:" + j);
                    for (int k = 0; k < 5; k++)
                    {
                        ds.Child3.Rows.Add((i * 100 + j) * 100 + k, i * 100 + j, "Child3:" + k);
                    }
                }
            }
        }

    }
}