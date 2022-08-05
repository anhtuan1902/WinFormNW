using System.Data;
using System.Windows.Forms;

namespace TranAnhTuan
{
    class ProductBUS
    {
        private ProductDAL productDAL;
        public ProductBUS()
        {
            productDAL = new ProductDAL();
        }

        public DataTable Getproducts()
        {
            return productDAL.Getproducts();
        }
        public void GetCategorys(ComboBox c)
        {
            c.DataSource = productDAL.GetCategorys();
            c.DisplayMember = "CategoryName";
            c.ValueMember = "CategoryID";
        }
        public void GetSuppliers(ComboBox c)
        {
            c.DataSource = productDAL.GetSuppliers();
            c.DisplayMember = "CompanyName";
            c.ValueMember = "SupplierID";
        }

        public int AddProduct(Product p)
        {
            int result = 0;
            if (!productDAL.CheckProductName(p))
            {
                result = productDAL.AddProduct(p);
            }
            else
            {
                result = -1;
            }
            return result;
        }

        public int UpdateProduct(Product p)
        {
            int result = 0;
            if (!productDAL.CheckProductID(p))
            {
                result = productDAL.UpdateProduct(p);
            }
            else
            {
                result = -1;
            }
            return result;
        }
        public int DeleteProduct(Product p)
        {
            int result = 0;
            if (!productDAL.CheckProductID(p))
            {
                result = productDAL.DeleteProduct(p);
            }
            else
            {
                result = -1;
            }
            return result;
        }
    }
}
