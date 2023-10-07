<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Pages/Listing.aspx.cs"
    MasterPageFile="~/Pages/Store.Master"
    Inherits="SportsStore.Pages.Listing" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
    <%--<%foreach(SportsStore.Models.Product prod in GetProducts()) {
            Response.Write("<div class='item'>");
            Response.Write(string.Format("<h3>{0}<h3>", prod.Name));
            Response.Write(prod.Description);
            Response.Write(string.Format("<h4>{0}<h4>", prod.Price));
            Response.Write(string.Format("<button name='add' type='submit'"
                + "value='{0}'>Add to Cart</button>", prod.ProductID));
            Response.Write("</div>");
        }%>--%>
        <asp:Repeater ItemType="SportsStore.Models.Product"
             SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Name %></h3>
                    <%# Item.Description %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit" value="<%#Item.ProductID %>">Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <%for(int i = 1; i <= MaxPage; i++)
            {
                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(
                    string.Format(
                        "<a href = '{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class = 'selected'" : "", i));
            }%> 
    </div>
</asp:Content>
