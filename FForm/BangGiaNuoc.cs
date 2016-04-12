using System;
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
    public partial class BangGiaNuoc : DevExpress.XtraEditors.XtraForm
    {
        CS.KetNoi ketNoi = new CS.KetNoi();
        DataTable dt = new DataTable();
        public BangGiaNuoc()
        {
            InitializeComponent();
        }

        private void BangGiaNuoc_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            string sql = "Select Muc,SoTien from banggianuoc";
            string[] arr = new string[0];

            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string muc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Muc").ToString();
                string sql = "DELETE FROM [dbo].[BangGiaNuoc]  WHERE Muc =@muc";
                string[] arr = new string[2];
                arr[0] = "@muc";
                arr[1] = muc;
                bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                if (kqua)
                {
                    View();
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string muc = "";
            string SoTien = "";
            try
            {
                if (!(gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                {
                    return;
                }
                int row = (int)gridView1.FocusedRowHandle;

                // string value = gridView1.FocusedValue.ToString();
                muc = gridView1.GetRowCellValue(row, "Muc").ToString();
                SoTien = gridView1.GetRowCellValue(row, "SoTien").ToString();

                string sql = "Select Count(Muc) from banggianuoc where Muc=@muc";
                string[] arr = new string[2];
                arr[0] = "@muc";
                arr[1] = muc;
                int kq = Convert.ToInt16(ketNoi.Excute_Reader_Sql(sql, CommandType.Text, arr));
                if (kq != 0)
                {
                    //update
                    sql = "UPDATE [BangGiaNuoc] SET [SoTien] =@sotien WHERE Muc=@muc";
                    arr = new string[4];
                    arr[0] = "@sotien";
                    arr[1] = SoTien;
                    arr[2] = "@muc";
                    arr[3] = muc;
                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }
                else
                {
                    //insert
                    sql = "INSERT INTO [BangGiaNuoc] ([Muc],[SoTien]) VALUES(@muc ,@sotien)";
                    arr = new string[4];
                    arr[0] = "@sotien";
                    arr[1] = SoTien;
                    arr[2] = "@muc";
                    arr[3] = muc;
                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(muc + SoTien + "\n" + ex.ToString());
            }
        }
    }
}