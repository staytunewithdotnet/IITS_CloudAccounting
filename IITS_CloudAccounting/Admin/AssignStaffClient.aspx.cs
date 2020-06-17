// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AssignStaffClient
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
  public class AssignStaffClient : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly StaffClientAssignDetailBLL objStaffClientAssignDetailBll = new StaffClientAssignDetailBLL();
    private CloudAccountDA.StaffClientAssignDetailDataTable objStaffClientAssignDetailDT = new CloudAccountDA.StaffClientAssignDetailDataTable();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected Panel pnlStaffToClient;
    protected UpdatePanel upSTC;
    protected DropDownList ddlClients;
    protected GridView gvStaff;
    protected Button btnSaveStaff;
    protected Panel pnlClientToStaff;
    protected UpdatePanel upCTS;
    protected DropDownList ddlStaff;
    protected GridView gvClients;
    protected Button btnSaveClient;
    protected HiddenField hfCompanyID;
    protected SqlDataSource sqldsClientDropdown;
    protected SqlDataSource sqldsStaffGrid;
    protected SqlDataSource sqldsClientGrid;
    protected SqlDataSource sqldsStaffDropDown;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("userManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("assignClient")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveStaffC"] != null;
      this.Session.Abandon();
      if (this.Request.QueryString["staff_to_client"] != null)
      {
        if (this.Request.QueryString["staff_to_client"] == "1")
        {
          this.pnlStaffToClient.Visible = false;
          this.pnlClientToStaff.Visible = true;
        }
        else
        {
          this.pnlStaffToClient.Visible = true;
          this.pnlClientToStaff.Visible = false;
        }
      }
      else
      {
        this.pnlStaffToClient.Visible = true;
        this.pnlClientToStaff.Visible = false;
      }
    }

    protected void chkAllStaff_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
        ((CheckBox) this.gvStaff.Rows[index].Cells[2].FindControl("chkStaffID")).Checked = checkBox.Checked;
    }

    protected void chkAllClients_OnCheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      for (int index = 0; index < this.gvClients.Rows.Count; ++index)
        ((CheckBox) this.gvClients.Rows[index].Cells[2].FindControl("chkCompanyClientID")).Checked = checkBox.Checked;
    }

    protected void ddlClients_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlClients.SelectedIndex > 0)
      {
        this.gvStaff.DataBind();
        for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
        {
          CheckBox checkBox1 = (CheckBox) this.gvStaff.HeaderRow.FindControl("chkAllStaff");
          CheckBox checkBox2 = (CheckBox) this.gvStaff.Rows[index].Cells[2].FindControl("chkStaffID");
          checkBox1.Checked = checkBox2.Checked = false;
          checkBox1.Enabled = checkBox2.Enabled = true;
        }
        this.objStaffClientAssignDetailDT = this.objStaffClientAssignDetailBll.GetDataByClientID(int.Parse(this.ddlClients.SelectedItem.Value));
        if (this.objStaffClientAssignDetailDT.Rows.Count <= 0)
          return;
        for (int index1 = 0; index1 < this.objStaffClientAssignDetailDT.Rows.Count; ++index1)
        {
          string str1 = this.objStaffClientAssignDetailDT.Rows[index1]["StaffID"].ToString();
          string str2 = this.objStaffClientAssignDetailDT.Rows[index1]["IsAssign"].ToString();
          for (int index2 = 0; index2 < this.gvStaff.Rows.Count; ++index2)
          {
            CheckBox checkBox = (CheckBox) this.gvStaff.Rows[index2].Cells[2].FindControl("chkStaffID");
            if (checkBox.ToolTip == str1)
            {
              checkBox.Checked = bool.Parse(str2);
              break;
            }
          }
        }
      }
      else
      {
        for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
        {
          CheckBox checkBox1 = (CheckBox) this.gvStaff.HeaderRow.FindControl("chkAllStaff");
          CheckBox checkBox2 = (CheckBox) this.gvStaff.Rows[index].Cells[2].FindControl("chkStaffID");
          checkBox1.Checked = checkBox2.Checked = false;
          checkBox1.Enabled = checkBox2.Enabled = false;
        }
      }
    }

    protected void ddlStaff_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlStaff.SelectedIndex > 0)
      {
        this.gvClients.DataBind();
        for (int index = 0; index < this.gvClients.Rows.Count; ++index)
        {
          CheckBox checkBox1 = (CheckBox) this.gvClients.HeaderRow.FindControl("chkAllClients");
          CheckBox checkBox2 = (CheckBox) this.gvClients.Rows[index].Cells[2].FindControl("chkCompanyClientID");
          checkBox1.Checked = checkBox2.Checked = false;
          checkBox1.Enabled = checkBox2.Enabled = false;
        }
        this.objStaffClientAssignDetailDT = this.objStaffClientAssignDetailBll.GetDataByStaffID(int.Parse(this.ddlStaff.SelectedItem.Value));
        if (this.objStaffClientAssignDetailDT.Rows.Count <= 0)
          return;
        for (int index1 = 0; index1 < this.objStaffClientAssignDetailDT.Rows.Count; ++index1)
        {
          string str1 = this.objStaffClientAssignDetailDT.Rows[index1]["ClientID"].ToString();
          string str2 = this.objStaffClientAssignDetailDT.Rows[index1]["IsAssign"].ToString();
          for (int index2 = 0; index2 < this.gvClients.Rows.Count; ++index2)
          {
            CheckBox checkBox = (CheckBox) this.gvClients.Rows[index2].Cells[2].FindControl("chkCompanyClientID");
            if (checkBox.ToolTip == str1)
            {
              checkBox.Checked = bool.Parse(str2);
              break;
            }
          }
        }
      }
      else
      {
        this.gvClients.DataBind();
        for (int index = 0; index < this.gvClients.Rows.Count; ++index)
        {
          CheckBox checkBox1 = (CheckBox) this.gvClients.HeaderRow.FindControl("chkAllClients");
          CheckBox checkBox2 = (CheckBox) this.gvClients.Rows[index].Cells[2].FindControl("chkCompanyClientID");
          checkBox1.Checked = checkBox2.Checked = false;
          checkBox1.Enabled = checkBox2.Enabled = false;
        }
      }
    }

    protected void btnSaveStaff_OnClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlClients.SelectedIndex > 0)
      {
        int num = 0;
        if (this.gvStaff.Rows.Count > 0)
        {
          int iClientID = int.Parse(this.ddlClients.SelectedItem.Value);
          this.objStaffClientAssignDetailBll.DeleteByClient(iClientID);
          for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
          {
            CheckBox checkBox = (CheckBox) this.gvStaff.Rows[index].Cells[2].FindControl("chkStaffID");
            num = this.objStaffClientAssignDetailBll.AddStaffClientAssignDetail(int.Parse(this.hfCompanyID.Value), int.Parse(checkBox.ToolTip), iClientID, checkBox.Checked);
          }
        }
        if (num == 0)
          return;
        this.Session["saveStaffC"] = (object) 1;
        this.Response.Redirect("~/Admin/AssignStaffClient.aspx");
      }
      else
        this.DisplayAlert("Please select a client");
    }

    protected void btnSaveClient_OnClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlStaff.SelectedIndex > 0)
      {
        int num = 0;
        if (this.gvClients.Rows.Count > 0)
        {
          int iStaffID = int.Parse(this.ddlStaff.SelectedItem.Value);
          this.objStaffClientAssignDetailBll.DeleteByStaff(iStaffID);
          for (int index = 0; index < this.gvClients.Rows.Count; ++index)
          {
            CheckBox checkBox = (CheckBox) this.gvClients.Rows[index].Cells[2].FindControl("chkCompanyClientID");
            string toolTip = checkBox.ToolTip;
            num = this.objStaffClientAssignDetailBll.AddStaffClientAssignDetail(int.Parse(this.hfCompanyID.Value), iStaffID, int.Parse(toolTip), checkBox.Checked);
          }
        }
        if (num == 0)
          return;
        this.Session["saveStaffC"] = (object) 1;
        this.Response.Redirect("~/Admin/AssignStaffClient.aspx?staff_to_client=1");
      }
      else
        this.DisplayAlert("Please select a client");
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
