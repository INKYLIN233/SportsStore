﻿using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        private Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public decimal Total(IEnumerable<OrderLine> orderLines)
        {
            decimal total = 0;
            foreach (OrderLine ol in orderLines)
            {
                total += ol.Product.Price * ol.Quantity;
            }
            return total;
        }

        public System.Collections.IEnumerable GetOrders([Control] bool showDispatched)
        {
            if (showDispatched)
            {
                return repo.Orders;
            }
            else 
            { 
                return repo.Orders.Where(o => !o.Dispatched);
            }
        }
    }
}