using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TranAnhTuan
{
    class ProductDAL
    {
        SqlConnection conn;
        public ProductDAL()
        {
            connDatabase();
        }

        private void connDatabase()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        public DataTable Getproducts()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "Select * From Products";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetCategorys()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "select CategoryID, CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string query = "select SupplierID, CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        public int AddProduct(Product p)
        {
            int r = 0;
            int n = 0;
            try
            {
                SqlCommand sqlComm;
                string query = String.Format("Insert into Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice) Values(N'{0}', {1}, {2}, {3}, {4})",
                                p.ProductName, p.SupplierID, p.CategoryID, p.Quantity, p.UnitPrice);
                sqlComm = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlComm.ExecuteNonQuery().ToString());
                r = (n > 0 ? 1 : 0);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                r = 0;
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public bool CheckProductName(Product p)
        {
            bool r = false;
            int n = 0;
            try
            {
                SqlCommand sqlComm;
                string query = String.Format("Select count(*) From Products Where ProductName =N'{0}'", p.ProductName);
                sqlComm = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlComm.ExecuteNonQuery().ToString());
                r = (n > 0 ? true : false);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                r = false;
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public bool CheckProductID(Product p)
        {
            bool r = false;
            int n = 0;
            try
            {
                SqlCommand sqlComm;
                string query = String.Format("Select count(*) From Products Where ProductID ={0}", p.ProductID);
                sqlComm = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlComm.ExecuteNonQuery().ToString());
                r = (n > 0 ? true : false);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                r = false;
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public int UpdateProduct(Product p)
        {
            int r = 0;
            int n = 0;
            try
            {
                SqlCommand sqlComm;
                string query = String.Format("Update Products SET ProductName = N'{0}', " +
                    "SupplierID = {1}, " +
                    "CategoryID = {2}, " +
                    "UnitsInStock = {3}, " +
                    "UnitPrice = {4} " +
                    "Where ProductID = {5}",
                                p.ProductName, p.SupplierID, p.CategoryID, p.Quantity, p.UnitPrice, p.ProductID);
                sqlComm = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlComm.ExecuteNonQuery().ToString());
                r = (n > 0 ? 1 : 0);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                r = 0;
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public int DeleteProduct(Product p)
        {
            int r = 0;
            int n = 0;
            try
            {
                SqlCommand sqlComm;
                string query = String.Format("Delete From Products Where ProductID = {0}", p.ProductID);
                sqlComm = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlComm.ExecuteNonQuery().ToString());
                r = (n > 0 ? 1 : 0);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                r = 0;
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

    }
}
