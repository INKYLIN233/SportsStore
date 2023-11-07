using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        //查找值为0的ProductID，确定在数据库中没有对应行的Product对象。
        //如果没有某个Product对象的ProductID非0，则更新数据库中存储的现有数据
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Find(product.ProductID);
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Product))
                .Where(o => o.OrderLines.Count(ol => ol.Product.ProductID == product.ProductID) > 0);

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Products.Remove(product);
            context.SaveChanges();
        }

        /* 返回从EFDbContext类中读取同名属性的结果 */
        public IEnumerable<Product> Products {
            get { return context.Products; }
        }
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Product));
            }
        }
        /* 存储新的Order对象or修改现有对象 */
        public void SaveOrder(Order order)
        {
            if(order.OrderId == 0)
            {
                order = context.Orders.Add(order);
                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Product).State
                        = EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Adress = order.Adress;
                    dbOrder.City = order.City;
                    dbOrder.Province = order.Province;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }
    }
}