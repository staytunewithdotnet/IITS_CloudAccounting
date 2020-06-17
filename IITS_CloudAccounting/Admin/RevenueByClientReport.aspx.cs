// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.RevenueByClientReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class RevenueByClientReport : Page
  {
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected DropDownList ddlYear;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected DropDownList ddlSales;
    protected Button btnUpdate;
    protected Image imgLogo;
    protected Label lblInfo;
    protected Label lblCompanyName;
    protected GridView gvClient;
    protected ObjectDataSource objdsClientGrid;
    protected HiddenField hfCompanyID;
    protected HiddenField hfDate;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("reports")).Attributes.Add("class", "active open");
      if (!this.IsPostBack)
      {
        this.ddlYear.Items.AddRange(Enumerable.ToArray<ListItem>(Enumerable.Select<int, ListItem>(Enumerable.Range(DateTime.Now.Year - 12, 13), (Func<int, ListItem>) (enumerable => new ListItem(enumerable.ToString((IFormatProvider) CultureInfo.InvariantCulture))))));
        this.ddlYear.SelectedIndex = this.ddlYear.Items.IndexOf(this.ddlYear.Items.FindByText(DateTime.Now.Year.ToString((IFormatProvider) CultureInfo.InvariantCulture)));
        this.BindGrid();
      }
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      string str = user.ToString();
      if (Roles.IsUserInRole(str, "Admin"))
      {
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
        if (this.objCompanyLoginMasterDT.Rows.Count > 0)
        {
          this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
          this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
        }
      }
      else if (Roles.IsUserInRole(str, "Employee"))
      {
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
        if (this.objStaffMasterDT.Rows.Count > 0)
        {
          this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
          this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
        }
      }
      this.SetMiscValues(this.hfCompanyID.Value);
    }

    private void BindGrid()
    {
      this.gvClient.DataBind();
    }

    private void SetMiscValues(string companyId)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.lblInfo.Text = " - " + this.ddlYear.SelectedItem.Text + " - " + this.ddlSales.SelectedItem.Text;
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}
