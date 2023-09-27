using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        
        /* 返回从EFDbContext类中读取同名属性的结果 */
        public IEnumerable<Product> Products {
            get { return context.Products; }
        }
    }
}