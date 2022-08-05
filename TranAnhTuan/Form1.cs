using System;
using System.Windows.Forms;

namespace TranAnhTuan
{
    public partial class Form1 : Form
    {
        private ProductBUS productBUS;
        int productID;

        public Form1()
        {
            InitializeComponent();
            productBUS = new ProductBUS();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gvSanPham.DataSource = productBUS.Getproducts();
            productBUS.GetCategorys(cbLoaiSP);
            productBUS.GetSuppliers(cbNCC);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            Product p = new Product();
            p.ProductName = txtTenSP.Text;
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.UnitPrice = double.Parse(txtDonGia.Text);
            p.Quantity = int.Parse(txtSoLuong.Text);

            result = productBUS.AddProduct(p);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Them that bai");
                    break;
                case 1:
                    MessageBox.Show("Them thanh cong");
                    gvSanPham.DataSource = productBUS.Getproducts();
                    break;
                case -1:
                    MessageBox.Show("Khong tim thay san pham");
                    break;

            }
        }

        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)
            {
                productID = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                cbLoaiSP.SelectedValue = gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                cbNCC.SelectedValue = gvSanPham.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int result = 0;
            Product p = new Product();
            p.ProductName = txtTenSP.Text;
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.UnitPrice = double.Parse(txtDonGia.Text);
            p.Quantity = int.Parse(txtSoLuong.Text);
            p.ProductID = productID;

            result = productBUS.UpdateProduct(p);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Sua that bai");
                    break;
                case 1:
                    MessageBox.Show("Sua thanh cong");
                    gvSanPham.DataSource = productBUS.Getproducts();
                    break;
                case -1:
                    MessageBox.Show("Khong tim thay san pham");
                    break;

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int result = 0;
            Product p = new Product();
            p.ProductID = productID;

            result = productBUS.DeleteProduct(p);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Sua that bai");
                    break;
                case 1:
                    MessageBox.Show("Sua thanh cong");
                    gvSanPham.DataSource = productBUS.Getproducts();
                    break;
                case -1:
                    MessageBox.Show("Khong tim thay san pham");
                    break;

            }
        }
    }
}
