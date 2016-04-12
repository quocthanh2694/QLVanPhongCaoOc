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
    public partial class CaoOc : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        CS.KetNoi ketNoi = new CS.KetNoi();
        public CaoOc()
        {
            InitializeComponent();
        }

        private void CaoOc_Load(object sender, EventArgs e)
        {
            //      if( select count (maco) from CaoOc )>0 select max( SUBSTRING(maco,3,5))+1 from CaoOc else select cast (1 as int)
            View();
        }

        private void View()
        {
            string sql = "Select MaCO,TenCO,DC from caooc";
            string[] arr = new string[0];

            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string muc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCO").ToString();
                string sql = "DELETE FROM [dbo].[CaoOc]  WHERE MaCO =@muc";
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
            string maCO = "";
            string TenCO = "";
            string diaChi = "";

            try
            {
                if (!(gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                {
                    return;
                }
                int row = (int)gridView1.FocusedRowHandle;

                // string value = gridView1.FocusedValue.ToString();
                maCO = gridView1.GetRowCellValue(row, "MaCO").ToString();
                //string maCO1 ="CO"+ Convert.ToInt16(ketNoi.laydata_dong("if( select count (maco) from CaoOc )>0 select max( SUBSTRING(maco,3,5))+1 from CaoOc else select cast (1 as int)")).ToString("0000");
                //TenCO = gridView1.GetRowCellValue(row, "TenCO").ToString();
                diaChi = gridView1.GetRowCellValue(row, "DC").ToString();

                string sql = "Select Count(MaCO) from CaoOc where MaCO=@muc";
                string[] arr = new string[2];
                arr[0] = "@muc";
                arr[1] = maCO;
                int kq = Convert.ToInt16(ketNoi.Excute_Reader_Sql(sql, CommandType.Text, arr));
                if (kq != 0)
                {
                    //update
                    sql = "UPDATE [CaoOc] SET  [TenCO]= @tenco, [DC]=@diachi WHERE MaCO=@maco";
                    arr = new string[6];
                   
                    arr[0] = "@tenco";
                    arr[1] = TenCO;
                    arr[2] = "@diachi";
                    arr[3] = diaChi;
                    arr[4] = "@maco";
                    arr[5] = maCO;
                    

                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }
                else
                {
                    //insert
                    sql = "INSERT INTO [caooc] ([MaCo],[TenCO],[DC]) VALUES(@maco ,@tenco,@diachi)";
                    arr = new string[6];
                    arr[0] = "@maco";
                    arr[1] = maCO;
                    arr[2] = "@tenco";
                    arr[3] = TenCO;
                    arr[4] = "@diachi";
                    arr[5] = diaChi;

                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}