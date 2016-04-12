using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


using DevExpress.XtraEditors.Controls;

namespace MainForm.FForm
{
    public partial class PhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        CS.KetNoi kketnoi = new CS.KetNoi();
        private void chucnangcha()
        {
            string sql = "select * from ChucNangCha";
            gridControl1.DataSource = kketnoi.Excute_Datatable_Sql(sql,CommandType.Text);



        }
        private void chucnangcon(string idchucnangcha)
        {
            try
            {
                string sql = "select IDChucNangCha,IDChucNangCon,TenChucNang,MoTa,CAST(QuyenHan as bit) QuyenHan from(select ChucNangCha.IDChucNangCha,IDChucNangCon,ChucNangCon.TenChucNang,ChucNangCon.MoTa,case when QuyenDangNhap.QuyenHan = 1 then 1 else 0 end QuyenHan  from ChucNangCha right join ChucNangCon on ChucNangCha.IDChucNangCha = ChucNangCon.IDChucNangCha left join QuyenDangNhap on ChucNangCon.IDChucNangCon = QuyenDangNhap.IDChucNang and IDDangNhap = " + tendncbx.EditValue.ToString() + " ) kq where IDChucNangCha = " + idchucnangcha + "";
                gridControl2.DataSource = kketnoi.Excute_Datatable_Sql(sql, CommandType.Text);
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn tài khoản trước"); 
            }
        }
        public PhanQuyen()
        {
            InitializeComponent();
        }

        private void PhanQuyen_Load(object sender, EventArgs e)
        {
            string sql = "select id,TenDangNhap [Tên đăng nhập],Hoten [Họ tên],case when  TrangThai = '1' then N'Đang hoạt động' else N'Bị Khóa' end [Trạng thái] from DangNhap order by TenDangNhap";
            tendncbx.Properties.DataSource = kketnoi.Excute_Datatable_Sql(sql, CommandType.Text);
            tendncbx.Properties.DisplayMember = "Tên đăng nhập";
            tendncbx.Properties.ValueMember = "id";
            tendncbx.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            tendncbx.Properties.PopulateColumns();
            tendncbx.Properties.Columns["id"].Visible = false;
            chucnangcha();
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
       
        }

      
        CS.Function funn = new CS.Function();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn cài lại mật khẩu cho tài khoản này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (matkhautxt.Text.Trim() != "")
                {
                    string sql = "update DangNhap set MatKhau ='" + funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, matkhautxt.Text.Trim()) + "' where id = " + tendncbx.EditValue.ToString() + "";
                    kketnoi.connectdulieu();
                    
                   SqlCommand comd = new SqlCommand(sql, kketnoi.conn);
                    comd.ExecuteNonQuery();
                    kketnoi.closeketnoi_sql();
                    XtraMessageBox.Show("Cập nhật thành công");

                }
                else { XtraMessageBox.Show("Vui lòng nhập mật khẩu mới"); matkhautxt.Focus(); }
            }
        }

        private void tendncbx_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "select  TrangThai  from DangNhap where id =" +tendncbx.EditValue.ToString();
            trangthaicbx.SelectedIndex =Convert.ToInt32(kketnoi.Excute_Reader_Sql(sql,CommandType.Text));
        }

        private void gridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string idchucnangcha = gridView1.GetRowCellValue(e.RowHandle, "IDChucNangCha").ToString().Trim();
           
            chucnangcon(idchucnangcha);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           if( XtraMessageBox.Show("Bạn muốn cập nhật?","Thông báo",MessageBoxButtons.YesNo) ==DialogResult.Yes)
           {
               kketnoi.connectdulieu();
               SqlCommand cmd0 = new SqlCommand("update DangNhap set TrangThai = @TrangThai where ID = @IDDangNhap", kketnoi.conn);
               cmd0.Parameters.AddWithValue("@TrangThai", trangthaicbx.SelectedIndex);
               cmd0.Parameters.AddWithValue("@IDDangNhap", tendncbx.EditValue.ToString());
               cmd0.ExecuteNonQuery();

               for (int i = 0; i < gridView2.RowCount; i++)
               {
                   string quyen = gridView2.GetRowCellValue(i, "QuyenHan").ToString().Trim();
                   string idchucnang = gridView2.GetRowCellValue(i, "IDChucNangCon").ToString().Trim();
                   string sql = "delete QuyenDangNhap where IDDangNhap =@IDDangNhap and IDChucNang = @IDChucNang ";
                   SqlCommand cmd = new SqlCommand(sql, kketnoi.conn);
                   cmd.Parameters.AddWithValue("@IDDangNhap", tendncbx.EditValue.ToString());
                   cmd.Parameters.AddWithValue("@IDChucNang", idchucnang);
                   cmd.ExecuteNonQuery();


                   if (quyen == "True")
                   {
                       string sqlinsert = "insert QuyenDangNhap select @IDDangNhap,@IDChucNang,1 ";
                       SqlCommand cmd2 = new SqlCommand(sqlinsert, kketnoi.conn);
                       cmd2.Parameters.AddWithValue("@IDDangNhap", tendncbx.EditValue.ToString());
                       cmd2.Parameters.AddWithValue("@IDChucNang", idchucnang);
                       cmd2.ExecuteNonQuery();

                   }
               }
               kketnoi.closeketnoi_sql();
               XtraMessageBox.Show("Cập nhật thành công");
           }
        }

    }
}