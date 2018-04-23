using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    protected int GetGroupNumber(string str) {
        str = str.ToLower();
        char ch = str[0];
        int i = Convert.ToInt32(ch);

        if (ch >= 'a' && ch <= 'e') return 1;
        if (ch >= 'f' && ch <= 'j') return 2;
        if (ch >= 'k' && ch <= 'q') return 3;
        if (ch >= 'r' && ch <= 'v') return 4;
        if (ch >= 'x' && ch <= 'z') return 5;

        return -1;
    }

    protected void grid_CustomColumnGroup(object sender, DevExpress.Web.ASPxGridView.CustomColumnSortEventArgs e) {
        if (e.Column.Name != "VisibleProductName") return;

        int res1 = GetGroupNumber(e.GetRow1Value(e.Column.FieldName).ToString());
        int res2 = GetGroupNumber(e.GetRow2Value(e.Column.FieldName).ToString());

        int res = res1 - res2;

        if (res < 0)
            res = 1;
        else if (res > 0)
            res = -1;

        e.Result = res;
        e.Handled = true;
    }

    protected void grid_CustomGroupDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e) {
        int ind = GetGroupNumber(e.Value.ToString());
        switch (ind) {
            case 1: e.DisplayText = "A-E"; break;
            case 2: e.DisplayText = "F-J"; break;
            case 3: e.DisplayText = "K-Q"; break;
            case 4: e.DisplayText = "R-V"; break;
            case 5: e.DisplayText = "X-Z"; break;
        }
    }

    protected void grid_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewBeforeColumnGroupingSortingEventArgs e) {
        if (e.Column.Name == "VisibleProductName")
            grid.Columns["InvisibleProductName"].Visible = ((grid.Columns["VisibleProductName"] as GridViewDataColumn).GroupIndex != -1);
    }
}
