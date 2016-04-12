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
    public partial class Phong : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        CS.KetNoi ketNoi = new CS.KetNoi();
        public Phong()
        {
            InitializeComponent();
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            //gridView 
            string sql = "Select MaP,DienTich,DonGia,t.MaT,c.MaCO from Phong p, tang t, CaoOc c where p.mat=t.mat and t.MaCO=c.MaCO group by  MaP,DienTich,DonGia,t.maT,c.MaCO";
            string[] arr = new string[0];
            dt = ketNoi.Excute_Datatable_Sql(sql, CommandType.Text, arr);
            gridControl1.DataSource = dt;

            //lookupEdit 1 cao oc
            string sqlCO = "Select MaCO,TenCO from CaoOc";
            DataTable dtb = ketNoi.Excute_Datatable_Sql(sqlCO, CommandType.Text, arr);
            repositoryItemLookUpEdit1.DataSource = dtb;
            repositoryItemLookUpEdit1.DisplayMember = "TenCO";
            repositoryItemLookUpEdit1.ValueMember = "MaCO";

            string maCO = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCO").ToString();
            string sqlTg = "Select MaT,SoPhong from tang";// where maCO=@maCO";
            string[] arr1 = new string[2];
            arr1[0] = "@maCO";
            arr1[1] = maCO;
            DataTable dtb2 = ketNoi.Excute_Datatable_Sql(sqlTg, CommandType.Text, arr);
            repositoryItemLookUpEdit2.DataSource = dtb2;
            repositoryItemLookUpEdit2.DisplayMember = "MaT";
            repositoryItemLookUpEdit2.ValueMember = "MaT";
        }

        private void repositoryItemLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            

           
        }

        private void repositoryItemLookUpEdit1_Validating(object sender, CancelEventArgs e)
        {
           // MessageBox.Show(" vali dating");
        }

        private void repositoryItemLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //string maCO = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCO").ToString();
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns[""],)
        }

        //private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    string maCO = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCO").ToString();
        //    //lookupEdit 2 tang
        //    string sqlTg = "Select MaT,SoPhong from tang where maCO=@maCO";
        //    string[] arr = new string[2];
        //    arr[0] = "@maCO";
        //    arr[1] = maCO;
        //    DataTable dtb2 = ketNoi.Excute_Datatable_Sql(sqlTg, CommandType.Text, arr);
        //    repositoryItemLookUpEdit2.DataSource = dtb2;
        //    repositoryItemLookUpEdit2.DisplayMember = "MaT";
        //    repositoryItemLookUpEdit2.ValueMember = "MaT";
        //}

        //private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    //string maCO = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCO").ToString();
        //    ////lookupEdit 2 tang
        //    //string sqlTg = "Select MaT,SoPhong from tang where maCO=@maCO";
        //    //string[] arr = new string[2];
        //    //arr[0] = "@maCO";
        //    //arr[1] = maCO;
        //    //DataTable dtb2 = ketNoi.Excute_Datatable_Sql(sqlTg, CommandType.Text, arr);
        //    //repositoryItemLookUpEdit2.DataSource = dtb2;
        //    //repositoryItemLookUpEdit2.DisplayMember = "MaT";
        //    //repositoryItemLookUpEdit2.ValueMember = "MaT";
        //}
    }
}