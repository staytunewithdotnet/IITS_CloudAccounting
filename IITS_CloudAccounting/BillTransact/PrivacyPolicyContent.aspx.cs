// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PrivacyPolicyContent
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class PrivacyPolicyContent : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly PrivacyPolicyContentBLL objPrivacyPolicyContentBll = new PrivacyPolicyContentBLL();
    private CloudAccountDA.PrivacyPolicyContentDataTable objPrivacyPolicyContentDT = new CloudAccountDA.PrivacyPolicyContentDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    public static bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtPrivacyPolicyContent;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected HiddenField hfPrivacyPolicy;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("privacyPolicy")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          PrivacyPolicyContent.AddStatus = "True";
          PrivacyPolicyContent.EditStatus = "True";
          PrivacyPolicyContent.ViewStatus = "True";
          PrivacyPolicyContent.DeleteStatus = "True";
        }
        else if (Admin.RoleName == "MasterAdmin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "MasterAdmin"))
            {
              this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(str);
              if (this.objMasterAdminLoginMasterDT.Rows.Count > 0)
                this.hfMasterAdminID.Value = this.objMasterAdminLoginMasterDT.Rows[0]["MasterAdminUserID"].ToString();
            }
          }
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "PrivacyPolicyContent");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            PrivacyPolicyContent.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PrivacyPolicyContent.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PrivacyPolicyContent.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PrivacyPolicyContent.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PrivacyPolicyContent.AddStatus = "";
            PrivacyPolicyContent.EditStatus = "";
            PrivacyPolicyContent.ViewStatus = "";
            PrivacyPolicyContent.DeleteStatus = "";
          }
        }
        else if (Admin.RoleName == "Admin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "Admin"))
            {
              this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
              if (this.objCompanyLoginMasterDT.Rows.Count > 0)
              {
                this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                this.hfCompanyLoginID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString();
              }
            }
          }
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "PrivacyPolicyContent");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            PrivacyPolicyContent.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PrivacyPolicyContent.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PrivacyPolicyContent.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PrivacyPolicyContent.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PrivacyPolicyContent.AddStatus = "";
            PrivacyPolicyContent.EditStatus = "";
            PrivacyPolicyContent.ViewStatus = "";
            PrivacyPolicyContent.DeleteStatus = "";
          }
        }
        else
        {
          PrivacyPolicyContent.AddStatus = "";
          PrivacyPolicyContent.EditStatus = "";
          PrivacyPolicyContent.ViewStatus = "";
          PrivacyPolicyContent.DeleteStatus = "";
        }
      }
      if (PrivacyPolicyContent.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(PrivacyPolicyContent.ViewStatus == "True"))
                break;
              this.pnlAdd.Visible = false;
              this.btnUpdate.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(PrivacyPolicyContent.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.btnUpdate.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(PrivacyPolicyContent.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.pnlAdd.Visible = true;
              break;
            default:
              this.GotoPage();
              this.pnlAdd.Visible = false;
              break;
          }
        }
        else
        {
          this.GotoPage();
          this.pnlAdd.Visible = false;
        }
      }
      else if (PrivacyPolicyContent.AddStatus == "True" && PrivacyPolicyContent.EditStatus == "False" && (PrivacyPolicyContent.ViewStatus == "False" && PrivacyPolicyContent.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
      }
      else
        this.pnlAdd.Visible = false;
    }

    private void GotoPage()
    {
      this.objPrivacyPolicyContentDT = this.objPrivacyPolicyContentBll.GetAllDetail();
      if (this.objPrivacyPolicyContentDT.Rows.Count > 0)
      {
        this.hfPrivacyPolicy.Value = this.objPrivacyPolicyContentDT.Rows[0]["PrivacyPolicyContentID"].ToString();
        this.Response.Redirect("~/BillTransact/PrivacyPolicyContent.aspx?cmd=add&ID=" + this.hfPrivacyPolicy.Value);
      }
      else
        this.Response.Redirect("~/BillTransact/PrivacyPolicyContent.aspx?cmd=add");
    }

    private void SetRecord(string iD)
    {
      this.objPrivacyPolicyContentDT = this.objPrivacyPolicyContentBll.GetDataByPrivacyPolicyID(int.Parse(iD));
      if (this.objPrivacyPolicyContentDT.Rows.Count <= 0)
        return;
      this.hfPrivacyPolicy.Value = this.objPrivacyPolicyContentDT.Rows[0]["PrivacyPolicyContentID"].ToString();
      this.txtPrivacyPolicyContent.Text = this.objPrivacyPolicyContentDT.Rows[0]["PrivacyPolicyContent"].ToString();
    }

    private void Clear()
    {
      this.txtPrivacyPolicyContent.Text = "";
      this.txtPrivacyPolicyContent.Focus();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtPrivacyPolicyContent.Text.Trim().Length > 0)
      {
        int num = this.objPrivacyPolicyContentBll.AddPrivacyPolicy(this.txtPrivacyPolicyContent.Text.Trim());
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/PrivacyPolicyContent.aspx?cmd=add&ID=" + (object) num);
        }
        else
        {
          this.DisplayAlert("Fail to Add New Details.");
          this.Clear();
        }
      }
      else
        this.DisplayAlert("Please Fill All Details...!");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.txtPrivacyPolicyContent.Text.Trim().Length > 0)
          {
            if (this.objPrivacyPolicyContentBll.UpdatePrivacyPolicy(int.Parse(this.hfPrivacyPolicy.Value.Trim()), this.txtPrivacyPolicyContent.Text.Trim()))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/PrivacyPolicyContent.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
            }
            else
              this.DisplayAlert("Fail to Update Details.");
          }
          else
            this.DisplayAlert("Please Fill All Details...!");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }
  }
}
