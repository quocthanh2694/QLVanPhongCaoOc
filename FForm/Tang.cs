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
    public partial class Tang : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        CS.KetNoi ketNoi = new CS.KetNoi();
        public Tang()
        {
            InitializeComponent();
        }

        private void Tang_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            //gridView
            string sql = "Select MaT,SoPhong,MaCO from Tang";
            string[] arr = new string[0];
            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;

            //lookupEdit
            string sqlCO = "Select MaCO,TenCO from CaoOc";
            DataTable dtb = ketNoi.Excute_Datatable_Sql(sqlCO, CommandType.Text, arr);
            repositoryItemLookUpEdit1.DataSource = dtb;
            repositoryItemLookUpEdit1.DisplayMember = "TenCO";
            repositoryItemLookUpEdit1.ValueMember = "MaCO";
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
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    string maCO=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"MaCO").ToString();
                    string muc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaT").ToString();
                    string sql = "DELETE FROM [dbo].[Tang]  WHERE MaT =@muc and maCO=@maCO";
                    string[] arr = new string[4];
                    arr[0] = "@muc";
                    arr[1] = muc;
                    arr[2] = "@maCO";
                    arr[3] = maCO;
                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }
            }
            catch (Exception es)
            {
                XtraMessageBox.Show(es.ToString());
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string MaT = "";
            string SoPhong = "";
            string maCO = "";
           
            try
            {
                if (!(gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
                {
                    return;
                }
                int row = (int)gridView1.FocusedRowHandle;

                // string value = gridView1.FocusedValue.ToString();
                maCO = gridView1.GetRowCellValue(row, "MaCO").ToString();
                //string maCO1 = "CO" + Convert.ToInt16(ketNoi.laydata_dong("if( select count (maco) from CaoOc )>0 select max( SUBSTRING(maco,3,5))+1 from CaoOc else select cast (1 as int)")).ToString("0000");
                MaT = gridView1.GetRowCellValue(row, "MaT").ToString();
                SoPhong = gridView1.GetRowCellValue(row, "SoPhong").ToString();
                if (MaT == string.Empty || SoPhong == string.Empty || maCO == string.Empty)
                {
                   // MessageBox.Show("Vui lòng nhập đủ thông tin các cột");
                    return ;
                }
                    
                
                string sql = "Select Count(*) from Tang where MaCO=@muc and MaT=@maT";
                string[] arr = new string[4];
                arr[0] = "@muc";
                arr[1] = maCO;
                arr[2] = "@maT";
                arr[3] = MaT;
                int kq = Convert.ToInt16(ketNoi.Excute_Reader_Sql(sql, CommandType.Text, arr));
                if (kq != 0)
                {
                    //update
                    sql = "UPDATE [Tang] SET  [soPhong]= @soPhong WHERE MaCO=@maco and maT=@maT";
                    arr = new string[6];

                    arr[0] = "@soPhong";
                    arr[1] = SoPhong;
                    arr[2] = "@maco";
                    arr[3] = maCO;
                    arr[4] = "@maT";
                    arr[5] = MaT;


                    bool kqua = ketNoi.Excute_Nonquery_Sql(sql, CommandType.Text, arr);
                    if (kqua)
                    {
                        View();
                    }
                }
                else
                {
                    //insert
                    sql = "INSERT INTO [tang] ([maT],[soPhong],[MaCO]) VALUES(@maco ,@tenco,@diachi)";
                    arr = new string[6];
                    arr[0] = "@maco";
                    arr[1] = MaT;
                    arr[2] = "@tenco";
                    arr[3] = SoPhong;
                    arr[4] = "@diachi";
                    arr[5] = maCO;

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