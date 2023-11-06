<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" 
    Inherits="SportsStore.Pages.Checkout" MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Checkout Now</h2>
            Please enter your details,and we'll ship your goods right away!
            <div id="errors" data-valmsg-summary="true">
                <ul><li style="display:none"></li></ul>
                <asp:ValidationSummary runat="server" />
            </div>
            <h3>Ship to</h3>
            <div>
                <label for="name">Name:</label>
                <%--<input id="name" name="name" data-val="true" data-val-required="Enter a name" />--%>
                <SX:VInput Property="Name" runat="server" />
            </div>
            <h3>Address</h3>
            <div>
                <label for="line1">Line 1:</label>
                <%--<input id="line1" name="line1" />--%>
               <SX:VInput Property="Line1" runat="server" />

            </div>
            <div>
                <label for="line2">Line 2:</label>
                <%--<input id="line2" name="line2" />--%>
                <SX:VInput Property="Line2" runat="server" />

            </div>
            <div>
                <label for="line3">Line 3:</label>
                <%--<input id="line3" name="line3" />--%>
                <SX:VInput Property="Line3" runat="server" />

            </div>
            <div>
                <label for="city">City:</label>
                <%--<input id="city" name="city" />--%>
                <SX:VInput Property="City" runat="server" />

            </div>
            <div>
                <label for="state">State:</label>
                <%--<input id="state" name="state" />--%>
                <SX:VInput Property="State" runat="server" />

            </div>

            <h3>Options</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Gift wrap these items?
            <p class="actionButtons">
                <button class="actionButtons" type="submit">Complete Order</button>
            </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Thanks!</h2>
            Thanks for placing your order. we'll ship your goods as soon as possible.
        </div>
    </div>
</asp:Content>