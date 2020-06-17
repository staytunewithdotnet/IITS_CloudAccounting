// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SupportTicketsMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class SupportTicketsMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly DoyinGoSupportTicketBLL objDoyinGoSupportTicketBll = new DoyinGoSupportTicketBLL();
    private CloudAccountDA.DoyinGoSupportTicketDataTable objDoyinGoSupportTicketDT = new CloudAccountDA.DoyinGoSupportTicketDataTable();
    private readonly DoyinGoSupportDiscussionBLL objDoyinGoSupportDiscussionBll = new DoyinGoSupportDiscussionBLL();
    private readonly DoyinGoTicketAttachmentBLL objDoyinGoTicketAttachmentBll = new DoyinGoTicketAttachmentBLL();
    private CloudAccountDA.DoyinGoTicketAttachmentDataTable objDoyinGoTicketAttachmentDT = new CloudAccountDA.DoyinGoTicketAttachmentDataTable();
    private readonly SupportDepartmentMasterBLL objSupportDepartmentMasterBll = new SupportDepartmentMasterBLL();
    private CloudAccountDA.SupportDepartmentMasterDataTable objSupportDepartmentMasterDT = new CloudAccountDA.SupportDepartmentMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
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
    protected Panel pnlView;
    protected Label lblSubject;
    protected Label lblSupportDate;
    protected Label lblSupportDepartment;
    protected UpdatePanel upEditStatus;
    protected Label lblStatus;
    protected DropDownList ddlStatus;
    protected LinkButton lnkEditStatus;
    protected UpdatePanel upEditPriority;
    protected Label lblSupportPriority;
    protected DropDownList ddlSupportPriority;
    protected LinkButton lnkEditPriority;
    protected DataList dlAttachment;
    protected SqlDataSource sqldsAttachment;
    protected Label lblCompanyPersonName;
    protected Label lblCompanyName;
    protected Label lblSupportDate1;
    protected Label lblMessage;
    protected DataList dlDiscussion;
    protected SqlDataSource sqldsDiscussion;
    protected TextBox txtDiscussion;
    protected Button btnSaveDiscussion;
    protected Button btnListAll;
    protected Button btnClose;
    protected Button btnOpen;
    protected Panel pnlViewAll;
    protected GridView gvSupportTicket;
    protected ObjectDataSource objdsSupportTicket;
    protected HiddenField hfSupportTicketID;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("supportMasters")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("supportTickets")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          SupportTicketsMaster.AddStatus = "True";
          SupportTicketsMaster.EditStatus = "True";
          SupportTicketsMaster.ViewStatus = "True";
          SupportTicketsMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "SupportDepartmentMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            SupportTicketsMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SupportTicketsMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SupportTicketsMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SupportTicketsMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SupportTicketsMaster.AddStatus = "";
            SupportTicketsMaster.EditStatus = "";
            SupportTicketsMaster.ViewStatus = "";
            SupportTicketsMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "SupportDepartmentMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            SupportTicketsMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SupportTicketsMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SupportTicketsMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SupportTicketsMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SupportTicketsMaster.AddStatus = "";
            SupportTicketsMaster.EditStatus = "";
            SupportTicketsMaster.ViewStatus = "";
            SupportTicketsMaster.DeleteStatus = "";
          }
        }
        else
        {
          SupportTicketsMaster.AddStatus = "";
          SupportTicketsMaster.EditStatus = "";
          SupportTicketsMaster.ViewStatus = "";
          SupportTicketsMaster.DeleteStatus = "";
        }
      }
      if (SupportTicketsMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(SupportTicketsMaster.ViewStatus == "True"))
                break;
              string sId = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(sId);
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(SupportTicketsMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                break;
              }
              if (!(SupportTicketsMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.pnlAdd.Visible = true;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
              break;
            default:
              this.BindGrid();
              this.pnlViewAll.Visible = true;
              this.pnlView.Visible = false;
              this.pnlAdd.Visible = false;
              break;
          }
        }
        else
        {
          this.BindGrid();
          this.pnlViewAll.Visible = true;
          this.pnlView.Visible = false;
          this.pnlAdd.Visible = false;
        }
      }
      else if (SupportTicketsMaster.AddStatus == "True" && SupportTicketsMaster.EditStatus == "False" && (SupportTicketsMaster.ViewStatus == "False" && SupportTicketsMaster.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
      }
      else
      {
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    private void SetRecord(string sId)
    {
      this.objDoyinGoSupportTicketDT = this.objDoyinGoSupportTicketBll.GetDataByDoyinGoSupportTicketID(int.Parse(sId));
      if (this.objDoyinGoSupportTicketDT.Rows.Count <= 0)
        return;
      this.hfSupportTicketID.Value = this.objDoyinGoSupportTicketDT.Rows[0]["DoyinGoSupportTicketID"].ToString();
    }

    private void ViewRecord(string sId)
    {
      this.objDoyinGoSupportTicketDT = this.objDoyinGoSupportTicketBll.GetDataByDoyinGoSupportTicketID(int.Parse(sId));
      if (this.objDoyinGoSupportTicketDT.Rows.Count <= 0)
        return;
      this.hfSupportTicketID.Value = this.objDoyinGoSupportTicketDT.Rows[0]["DoyinGoSupportTicketID"].ToString();
      this.lblSupportDepartment.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportDepartmentID"].ToString();
      this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentID(int.Parse(this.lblSupportDepartment.Text));
      this.lblSupportDepartment.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentName"].ToString();
      this.lblSupportDate.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportDate"].ToString();
      this.lblSupportDate1.Text = "Posted On: " + this.objDoyinGoSupportTicketDT.Rows[0]["SupportDate"];
      this.lblSubject.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Subject"].ToString();
      this.lblMessage.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Message"].ToString();
      this.ddlSupportPriority.SelectedValue = this.lblSupportPriority.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportPriority"].ToString();
      this.ddlStatus.SelectedValue = this.lblStatus.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportStatus"].ToString();
      this.btnClose.Visible = this.lblStatus.Text != "Closed";
      this.btnOpen.Visible = this.lblStatus.Text == "Closed";
      this.lblStatus.Text = this.SetStatus(this.lblStatus.Text);
      this.dlDiscussion.DataBind();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.objDoyinGoSupportTicketDT.Rows[0]["CompanyID"].ToString()));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.lblCompanyPersonName.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
    }

    private void Clear()
    {
    }

    private void BindGrid()
    {
      this.gvSupportTicket.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvSupportTicket.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvSupportTicket, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvSupportTicket_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("SupportTicketsMaster.aspx?cmd=view&ID=" + this.gvSupportTicket.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvSupportTicket_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvSupportTicket.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvSupportTicket_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
      e.Row.Cells[1].Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentID(int.Parse(e.Row.Cells[2].Text));
      e.Row.Cells[2].Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentName"].ToString();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value))
        return;
      this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "Closed");
      this.Response.Redirect("SupportTicketsMaster.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
    }

    protected void btnOpen_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value))
        return;
      this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "Open");
      this.Response.Redirect("SupportTicketsMaster.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
    }

    protected void btnSaveDiscussion_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value) || this.txtDiscussion.Text.Trim().Length <= 0)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        this.objDoyinGoSupportDiscussionBll.AddDoyinGoSupportDiscussion(int.Parse(this.hfSupportTicketID.Value), this.txtDiscussion.Text.Trim().Replace("\n", "<br />"), DateTime.Now, "MAdmin_" + user.UserName);
        this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "Awaiting Client Reply");
      }
      this.Response.Redirect("SupportTicketsMaster.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("SupportTicketsMaster.aspx");
    }

    protected string SetName(string username)
    {
      if (username.Contains("MAdmin_"))
      {
        this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(username.Replace("MAdmin_", ""));
        if (this.objMasterAdminLoginMasterDT.Rows.Count > 0)
          return (string) this.objMasterAdminLoginMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objMasterAdminLoginMasterDT.Rows[0]["LastName"];
      }
      else if (username.Contains("CAdmin_"))
      {
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(username.Replace("CAdmin_", ""));
        if (this.objCompanyMasterDT.Rows.Count > 0)
          return this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
      }
      return "";
    }

    protected void lnkEditStatus_Click(object sender, EventArgs e)
    {
      this.lblStatus.Visible = false;
      this.ddlStatus.Visible = true;
      this.lnkEditStatus.Visible = false;
    }

    protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), this.ddlStatus.SelectedItem.Value);
      this.ViewRecord(this.hfSupportTicketID.Value);
      this.lblStatus.Visible = true;
      this.ddlStatus.Visible = false;
      this.lnkEditStatus.Visible = true;
    }

    protected void lnkEditPriority_Click(object sender, EventArgs e)
    {
      this.lblSupportPriority.Visible = false;
      this.ddlSupportPriority.Visible = true;
      this.lnkEditPriority.Visible = false;
    }

    protected void ddlPriority_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.objDoyinGoSupportTicketBll.UpdateSupportPriority(int.Parse(this.hfSupportTicketID.Value), this.ddlSupportPriority.SelectedItem.Value);
      this.ViewRecord(this.hfSupportTicketID.Value);
      this.lblSupportPriority.Visible = true;
      this.ddlSupportPriority.Visible = false;
      this.lnkEditPriority.Visible = true;
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
      this.objDoyinGoTicketAttachmentDT = this.objDoyinGoTicketAttachmentBll.GetDataByDoyinGoTicketAttachmentID(int.Parse(((WebControl) sender).ToolTip));
      try
      {
        if (this.objDoyinGoTicketAttachmentDT.Rows.Count <= 0)
          return;
        this.Response.Clear();
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.Buffer = true;
        this.Response.ContentType = this.objDoyinGoTicketAttachmentDT.Rows[0]["AttachFileType"].ToString();
        this.Response.AddHeader("content-disposition", "attachment;filename=" + this.objDoyinGoTicketAttachmentDT.Rows[0]["AttachFileName"]);
        this.Response.Charset = "";
        this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        this.Response.BinaryWrite((byte[]) this.objDoyinGoTicketAttachmentDT.Rows[0]["AttachFile"]);
        this.Response.End();
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.ToString());
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

    protected string GetCompanyName(string username)
    {
      if (username.Contains("MAdmin_"))
          return "Bill Transact Support";
      if (username.Contains("CAdmin_"))
      {
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(username.Replace("CAdmin_", ""));
        if (this.objCompanyMasterDT.Rows.Count > 0)
          return this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      }
      return "";
    }

    protected string SetStatus(string status)
    {
      if (status == "On Hold")
        return "Customer-Reply";
      return status;
    }
  }
}
