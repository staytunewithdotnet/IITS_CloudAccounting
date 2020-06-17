// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.PricingTable
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class PricingTable : Page
  {
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    protected Repeater rpPackage;
    protected SqlDataSource sqldsPackage;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("pricing")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      this.Response.Redirect("NewPricingTable.aspx");
    }

    protected string GetCurrency(string cID)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      return "";
    }

    protected string SetIconTrueFalse(bool icon)
    {
      return icon ? "<i class=\"fa fa-check-circle\" title=\"Yes\" style=\"font-size: 30px;\"></i>" : "<i class=\"fa fa-exclamation-circle\" title=\"No\" style=\"font-size: 30px;\"></i>";
    }
  }
}
