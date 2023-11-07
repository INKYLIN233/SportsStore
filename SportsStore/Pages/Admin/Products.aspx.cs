using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace SportsStore.Pages.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Product> GetProducts()
        {
            return repo.Products;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void UpdateProduct(int productId)
        {
            Product myProduct = repo.Products
                .Where(p => p.ProductID == productId).FirstOrDefault();
            // 在此加载该项，例如 item = MyDataLayer.Find(id);
            if (myProduct != null && TryUpdateModel(myProduct,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repo.SaveProduct(myProduct);
            }
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void DeleteProduct(int productId)
        {
            Product myProduct = repo.Products
                .Where(p => p.ProductID == productId).FirstOrDefault();
            if (myProduct != null)
            {
                repo.DeleteProduct(myProduct);
            }
        }

        public void InsertProduct()
        {
            Product myProduct = new Product();
            if (TryUpdateModel(myProduct,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repo.SaveProduct(myProduct);
            }
        }
    }
}