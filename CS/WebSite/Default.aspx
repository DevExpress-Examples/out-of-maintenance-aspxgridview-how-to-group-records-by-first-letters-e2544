<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to group records by first letters</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="sds"
                KeyFieldName="ProductID" OnCustomColumnGroup="grid_CustomColumnGroup" 
                OnCustomGroupDisplayText="grid_CustomGroupDisplayText" OnBeforeColumnSortingGrouping="grid_BeforeColumnSortingGrouping">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="VisibleProductName" FieldName="ProductName" VisibleIndex="1">
                        <Settings AllowGroup="True" SortMode="Custom" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="InvisibleProductName" FieldName="ProductName" VisibleIndex="2"
                        Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings ShowGroupPanel="True" />
            </dx:ASPxGridView>
        </div>
        <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]"></asp:SqlDataSource>
    </form>
</body>
</html>
