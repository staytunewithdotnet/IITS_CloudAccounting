// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FreePackageSettings
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class FreePackageSettings : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FreePackageSettingsBLL objFreePackageSettingsBll = new FreePackageSettingsBLL();
    private CloudAccountDA.FreePackageSettingsDataTable objFreePackageSettingsDT = new CloudAccountDA.FreePackageSettingsDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected TextBox txtFreeDays;
    protected RequiredFieldValidator rfvFreeDays;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected HiddenField hfFreePackageSettingID;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("freePackage")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FreePackageSettings.AddStatus = "True";
          FreePackageSettings.EditStatus = "True";
          FreePackageSettings.ViewStatus = "True";
          FreePackageSettings.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FreePackageSettings");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FreePackageSettings.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FreePackageSettings.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FreePackageSettings.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FreePackageSettings.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FreePackageSettings.AddStatus = "";
            FreePackageSettings.EditStatus = "";
            FreePackageSettings.ViewStatus = "";
            FreePackageSettings.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "FreePackageSettings");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            FreePackageSettings.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FreePackageSettings.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FreePackageSettings.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FreePackageSettings.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FreePackageSettings.AddStatus = "";
            FreePackageSettings.EditStatus = "";
            FreePackageSettings.ViewStatus = "";
            FreePackageSettings.DeleteStatus = "";
          }
        }
        else
        {
          FreePackageSettings.AddStatus = "";
          FreePackageSettings.EditStatus = "";
          FreePackageSettings.ViewStatus = "";
          FreePackageSettings.DeleteStatus = "";
        }
      }
      if (FreePackageSettings.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FreePackageSettings.ViewStatus == "True"))
                break;
              this.pnlAdd.Visible = false;
              this.btnUpdate.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FreePackageSettings.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.btnUpdate.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(FreePackageSettings.AddStatus == "True"))
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
      else if (FreePackageSettings.AddStatus == "True" && FreePackageSettings.EditStatus == "False" && (FreePackageSettings.ViewStatus == "False" && FreePackageSettings.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
      }
      else
        this.pnlAdd.Visible = false;
    }

    private void SetRecord(string iD)
    {
      this.objFreePackageSettingsDT = this.objFreePackageSettingsBll.GetDataByFreePackageSettingsID(int.Parse(iD));
      if (this.objFreePackageSettingsDT.Rows.Count <= 0)
        return;
      this.hfFreePackageSettingID.Value = this.objFreePackageSettingsDT.Rows[0]["FreePackageSettingID"].ToString();
      this.txtFreeDays.Text = this.objFreePackageSettingsDT.Rows[0]["FreePackageDays"].ToString();
    }

    private void Clear()
    {
      this.txtFreeDays.Text = "";
      this.txtFreeDays.Focus();
    }

    private void GotoPage()
    {
      this.objFreePackageSettingsDT = this.objFreePackageSettingsBll.GetAllDetail();
      if (this.objFreePackageSettingsDT.Rows.Count > 0)
      {
        this.hfFreePackageSettingID.Value = this.objFreePackageSettingsDT.Rows[0]["FreePackageSettingID"].ToString();
        this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add&ID=" + this.hfFreePackageSettingID.Value);
      }
      else
        this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add");
    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      int num = this.objFreePackageSettingsBll.AddFreePackageSettings(int.Parse(this.txtFreeDays.Text.Trim()));
      if (num != 0)
      {
        this.DisplayAlert("Details Added Successfully.");
        this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add&ID=" + (object) num);
      }
      else
      {
        this.DisplayAlert("Fail to Add New Details.");
        this.Clear();
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.objFreePackageSettingsBll.UpdateFreePackageSettings(int.Parse(this.hfFreePackageSettingID.Value.Trim()), int.Parse(this.txtFreeDays.Text.Trim())))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFreePackageSettingID.Value != null)
      {
        if (this.objFreePackageSettingsBll.DeleteFreePackageSettings(int.Parse(this.hfFreePackageSettingID.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/FreePackageSettings.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FreePackageSettings.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FreePackageSettings.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
