using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository
{
    public class EFDbContext:DbContext
    {
        /* 将Product模型类型用于表示Products表中的行 */
        public DbSet<Product> Products { get; set; }
    }
}