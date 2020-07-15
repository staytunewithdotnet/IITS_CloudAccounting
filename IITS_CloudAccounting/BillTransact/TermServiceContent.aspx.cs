// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TermServiceContent
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
  public class TermServiceContent : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly TermServiceContentBLL objTermServiceContentBll = new TermServiceContentBLL();
    private CloudAccountDA.TermServiceContentDataTable objTermServiceContentDT = new CloudAccountDA.TermServiceContentDataTable();
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
    protected TextBox txtTermServiceContent;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected HiddenField hfTermService;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("termService")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          TermServiceContent.AddStatus = "True";
          TermServiceContent.EditStatus = "True";
          TermServiceContent.ViewStatus = "True";
          TermServiceContent.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "TermServiceContent");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            TermServiceContent.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            TermServiceContent.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            TermServiceContent.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            TermServiceContent.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            TermServiceContent.AddStatus = "";
            TermServiceContent.EditStatus = "";
            TermServiceContent.ViewStatus = "";
            TermServiceContent.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "TermServiceContent");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            TermServiceContent.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            TermServiceContent.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            TermServiceContent.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            TermServiceContent.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            TermServiceContent.AddStatus = "";
            TermServiceContent.EditStatus = "";
            TermServiceContent.ViewStatus = "";
            TermServiceContent.DeleteStatus = "";
          }
        }
        else
        {
          TermServiceContent.AddStatus = "";
          TermServiceContent.EditStatus = "";
          TermServiceContent.ViewStatus = "";
          TermServiceContent.DeleteStatus = "";
        }
      }
      if (TermServiceContent.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(TermServiceContent.ViewStatus == "True"))
                break;
              this.pnlAdd.Visible = false;
              this.btnUpdate.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(TermServiceContent.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.btnUpdate.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(TermServiceContent.AddStatus == "True"))
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
      else if (TermServiceContent.AddStatus == "True" && TermServiceContent.EditStatus == "False" && (TermServiceContent.ViewStatus == "False" && TermServiceContent.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
      }
      else
        this.pnlAdd.Visible = false;
    }

    private void GotoPage()
    {
      this.objTermServiceContentDT = this.objTermServiceContentBll.GetAllDetail();
      if (this.objTermServiceContentDT.Rows.Count > 0)
      {
        this.hfTermService.Value = this.objTermServiceContentDT.Rows[0]["TermServiceContentID"].ToString();
        this.Response.Redirect("~/BillTransact/TermServiceContent.aspx?cmd=add&ID=" + this.hfTermService.Value);
      }
      else
        this.Response.Redirect("~/BillTransact/TermServiceContent.aspx?cmd=add");
    }

    private void SetRecord(string iD)
    {
      this.objTermServiceContentDT = this.objTermServiceContentBll.GetDataByTermServiceID(int.Parse(iD));
      if (this.objTermServiceContentDT.Rows.Count <= 0)
        return;
      this.hfTermService.Value = this.objTermServiceContentDT.Rows[0]["TermServiceContentID"].ToString();
      this.txtTermServiceContent.Text = this.objTermServiceContentDT.Rows[0]["TermServiceContent"].ToString();
    }

    private void Clear()
    {
      this.txtTermServiceContent.Text = "";
      this.txtTermServiceContent.Focus();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtTermServiceContent.Text.Trim().Length > 0)
      {
        int num = this.objTermServiceContentBll.AddTermService(this.txtTermServiceContent.Text.Trim());
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/TermServiceContent.aspx?cmd=add&ID=" + (object) num);
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
          if (this.txtTermServiceContent.Text.Trim().Length > 0)
          {
            if (this.objTermServiceContentBll.UpdateTermService(int.Parse(this.hfTermService.Value.Trim()), this.txtTermServiceContent.Text.Trim()))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/TermServiceContent.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
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
