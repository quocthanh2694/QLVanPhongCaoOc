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
    public partial class BangGiaDT : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        CS.KetNoi ketNoi = new CS.KetNoi();
        public BangGiaDT()
        {
            InitializeComponent();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            //gridView1.DeleteRow(gridView1.FocusedRowHandle);
            //Delete
            if (gridView1.FocusedRowHandle >= 0)
            {
                string muc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MucDienTich").ToString();
                string sql = "DELETE FROM [dbo].[BangGiaDT]  WHERE MucDienTich =@mucdientich";
                string[] arr = new string[2];
                arr[0] = "@mucdientich";
                arr[1] = muc;
                bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                if (kqua)
                {
                    View();
                }
            }
        }

        private void BangGiaDT_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            string sql = "Select MucDienTich,SoTien from banggiadT";
            string[] arr = new string[0];

            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;
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
                muc = gridView1.GetRowCellValue(row, "MucDienTich").ToString();
                SoTien = gridView1.GetRowCellValue(row, "SoTien").ToString();

                string sql = "Select Count(MucDienTich) from banggiadt where MucDienTich=@muc";
                string[] arr = new string[2];
                arr[0] = "@muc";
                arr[1] = muc;
                int kq = Convert.ToInt16(ketNoi.Excute_Reader_Sql(sql, CommandType.Text, arr));
                if (kq != 0)
                {
                    //update
                    sql = "UPDATE [BangGiaDT] SET [SoTien] =@sotien WHERE MucDienTich=@muc";
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
                    sql = "INSERT INTO [BangGiaDT] ([MucDienTich],[SoTien]) VALUES(@muc ,@sotien)";
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}