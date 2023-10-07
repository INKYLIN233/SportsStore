using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        private int pageSize = 4;   //分页
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"],out selectedProductId) )
                {
                    Product selectedProduct = repo.Products
                        .Where(p => p.ProductID == selectedProductId)
                        .FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);
                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            //OrderBy方法确保始终按照ProductID顺序处理Product对象
            //Skip方法忽略在所需页面之前出现过的Product对象
            //Take方法选择用户显示的Product对象数量
            return FilterProducts()
                .OrderBy(p => p.ProductID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }
        protected int CurrentPage
        {
            get
            {
                int page;
                //page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                page = GetPageFromRequest();
                //flase返回1,true返回page
                return page > MaxPage ? MaxPage : page;
                //如果page > MaxPage为真（例如200>3）则返回MaxPage,否则返回Page，即当超出最大页数时显示最后一个有效页面
            }
        }
        protected int MaxPage
        {
            get
            {
                //动态返回Procut对象的最大页数
                int prodCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = repo.Products;
            string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return currentCategory == null ? products : products.Where(p => p.Category == currentCategory);
        }

        private int GetPageFromRequest()
        {
            int page;
            //从URL中获取不为空的可用变量值，如果没有可用变量则将检查Request.QueryString属性
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return (reqValue != null && int.TryParse(reqValue, out page)) ? page : 1;
        }
    }
}