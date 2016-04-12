﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MainForm.FForm
{
    public partial class BangGiaTang : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        CS.KetNoi ketNoi = new CS.KetNoi();
        public BangGiaTang()
        {
            InitializeComponent();
        }

        private void BangGiaTang_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            string sql = "Select Tang,SoTien from banggiatang";
            string[] arr = new string[0];

            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string tang = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tang").ToString();
                string sql = "DELETE FROM [dbo].[BangGiaTang]  WHERE Tang =@tang";
                string[] arr = new string[2];
                arr[0] = "@tang";
                arr[1] = tang;
                bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                if (kqua)
                {
                    View();
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string tang = "";
            string SoTien = "";
            try
            {
                if (!(gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                {
                    return;
                }
                int row = (int)gridView1.FocusedRowHandle;

                // string value = gridView1.FocusedValue.ToString();
                tang = gridView1.GetRowCellValue(row, "Tang").ToString();
                SoTien = gridView1.GetRowCellValue(row, "SoTien").ToString();

                string sql = "Select Count(Tang) from BangGiaTang where Tang=@tang";
                string[] arr = new string[2];
                arr[0] = "@tang";
                arr[1] = tang;
                int kq = Convert.ToInt16(ketNoi.Excute_Reader_Sql(sql, CommandType.Text, arr));
                if (kq != 0)
                {
                    //update
                    sql = "UPDATE [BangGiaTang] SET [SoTien] =@sotien WHERE Tang=@tang";
                    arr = new string[4];
                    arr[0] = "@sotien";
                    arr[1] = SoTien;
                    arr[2] = "@tang";
                    arr[3] = tang;
                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }
                else
                {
                    //insert
                    sql = "INSERT INTO [BangGiaTang] ([Tang],[SoTien]) VALUES(@tang ,@sotien)";
                    arr = new string[4];
                    arr[0] = "@sotien";
                    arr[1] = SoTien;
                    arr[2] = "@tang";
                    arr[3] = tang;
                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(tang + SoTien + "\n" + ex.ToString());
            }
        }
    }
}