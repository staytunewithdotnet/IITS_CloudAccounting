// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PackageUpgradeRequestMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class PackageUpgradeRequestMaster : Page
  {
    protected Panel pnlViewAll;
    protected GridView gvPackageUpgrade;
    protected ObjectDataSource objdsPackageUpgrade;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageUpgradeRequest")).Attributes.Add("class", "active");
    }

    private void BindGrid()
    {
      this.gvPackageUpgrade.DataBind();
    }

    protected void gvPackageUpgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageUpgradeRequestMaster.aspx?cmd=view?ID=" + this.gvPackageUpgrade.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPackageUpgrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPackageUpgrade.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }
  }
}
