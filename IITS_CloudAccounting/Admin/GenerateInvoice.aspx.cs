// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.GenerateInvoice
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class GenerateInvoice : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upInvoice;
    protected TextBox txtStartDate;
    protected CalendarExtender ceStartDate;
    protected TextBox txtEndDate;
    protected CalendarExtender ceEndDate;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected CheckBoxList cblProjects;
    protected SqlDataSource sqldsProjects;
    protected HtmlGenericControl radioDetailed;
    protected RadioButton rbDetailed;
    protected HtmlGenericControl radioGrouped;
    protected RadioButton rbGroupped;
    protected HtmlGenericControl radioSingleLine;
    protected RadioButton rbSingleLine;
    protected HtmlGenericControl divDetailed;
    protected Label lblTaskDetail;
    protected Label lblProjectDetailed;
    protected Label lblEntryDateDetailed;
    protected Label lblTeamMemberDetailed;
    protected Label lblNotesDetailed;
    protected CheckBox chkProjectDetailed;
    protected CheckBox chkTaskNameDetailed;
    protected CheckBox chkTeamMemberDetailed;
    protected CheckBox chkEntryDateDetailed;
    protected CheckBox chkNotesDetailed;
    protected HtmlGenericControl divGrouped;
    protected Label lblTaskGrouped;
    protected Label lblProjectGrouped;
    protected Label lblDateRange;
    protected Label lblTeamMemberGrouped;
    protected CheckBox chkProjectGrouped;
    protected CheckBox chkTaskNameGrouped;
    protected CheckBox chkTeamMemberGrouped;
    protected CheckBox chkDateRangeGrouped;
    protected HtmlGenericControl divSingleLine;
    protected Label lblSingleLine;
    protected RadioButtonList rblAddExpense;
    protected Button btnSave;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("genrateInv")).Attributes.Add("class", "active open");
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
      this.txtStartDate.Attributes.Add("readonly", "readonly");
      this.txtEndDate.Attributes.Add("readonly", "readonly");
    }

    protected void txtStartDate_OnTextChanged(object sender, EventArgs e)
    {
      if (this.txtStartDate.Text.Trim().Length <= 0)
        return;
      this.ceEndDate.StartDate = new DateTime?(DateTime.Parse(this.txtStartDate.Text).AddDays(1.0));
      this.txtEndDate.Focus();
    }

    protected void txtEndDate_OnTextChanged(object sender, EventArgs e)
    {
      if (this.txtEndDate.Text.Trim().Length <= 0)
        return;
      this.ceStartDate.EndDate = new DateTime?(DateTime.Parse(this.txtEndDate.Text).AddDays(-1.0));
      this.ddlClient.Focus();
    }

    protected void rbDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      if (this.rbDetailed.Checked)
      {
        this.radioDetailed.Attributes.Remove("class");
        this.radioDetailed.Attributes.Add("class", "col-lg-4 activeRadio");
        this.radioGrouped.Attributes.Remove("class");
        this.radioGrouped.Attributes.Add("class", "col-lg-4");
        this.radioSingleLine.Attributes.Remove("class");
        this.radioSingleLine.Attributes.Add("class", "col-lg-4");
        this.divDetailed.Visible = true;
        this.divGrouped.Visible = false;
        this.divSingleLine.Visible = false;
      }
      else if (this.rbGroupped.Checked)
      {
        this.radioGrouped.Attributes.Remove("class");
        this.radioGrouped.Attributes.Add("class", "col-lg-4 activeRadio");
        this.radioDetailed.Attributes.Remove("class");
        this.radioDetailed.Attributes.Add("class", "col-lg-4");
        this.radioSingleLine.Attributes.Remove("class");
        this.radioSingleLine.Attributes.Add("class", "col-lg-4");
        this.divGrouped.Visible = true;
        this.divDetailed.Visible = false;
        this.divSingleLine.Visible = false;
      }
      else
      {
        if (!this.rbSingleLine.Checked)
          return;
        this.radioSingleLine.Attributes.Remove("class");
        this.radioSingleLine.Attributes.Add("class", "col-lg-4 activeRadio");
        this.radioGrouped.Attributes.Remove("class");
        this.radioGrouped.Attributes.Add("class", "col-lg-4");
        this.radioDetailed.Attributes.Remove("class");
        this.radioDetailed.Attributes.Add("class", "col-lg-4");
        this.divSingleLine.Visible = true;
        this.divGrouped.Visible = false;
        this.divDetailed.Visible = false;
      }
    }

    protected void chkTaskNameDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblTaskDetail.Text = this.chkTaskNameDetailed.Checked ? "Design" : "Time";
      this.chkTaskNameDetailed.Checked = this.chkTaskNameDetailed.Checked;
    }

    protected void chkProjectDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblProjectDetailed.Visible = this.chkProjectDetailed.Checked;
    }

    protected void chkTeamMemberDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblTeamMemberDetailed.Visible = this.chkTeamMemberDetailed.Checked;
    }

    protected void chkEntryDateDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblEntryDateDetailed.Visible = this.chkEntryDateDetailed.Checked;
    }

    protected void chkNotesDetailed_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblNotesDetailed.Visible = this.chkNotesDetailed.Checked;
    }

    protected void chkTaskNameGrouped_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblTaskGrouped.Text = this.chkTaskNameGrouped.Checked ? "Design" : "Time";
    }

    protected void chkProjectGrouped_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblProjectGrouped.Visible = this.chkProjectGrouped.Checked;
    }

    protected void chkTeamMemberGrouped_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblTeamMemberGrouped.Visible = this.chkTeamMemberGrouped.Checked;
    }

    protected void chkDateRangeGrouped_OnCheckedChanged(object sender, EventArgs e)
    {
      this.lblDateRange.Visible = this.chkDateRangeGrouped.Checked;
    }

    protected void cblProjects_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      int num = 0;
      if (Enumerable.Any<ListItem>(Enumerable.Cast<ListItem>((IEnumerable) this.cblProjects.Items), (Func<ListItem, bool>) (li => li.Selected)))
      {
        ++num;
        this.rblAddExpense.Items.FindByValue("projects").Enabled = true;
      }
      if (num != 0)
        return;
      this.rblAddExpense.Items.FindByValue("projects").Selected = false;
      this.rblAddExpense.Items.FindByValue("all").Selected = true;
      this.rblAddExpense.Items.FindByValue("projects").Enabled = false;
    }
  }
}
