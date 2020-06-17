// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.DoyinGoSupportTicket
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class DoyinGoSupportTicket : Page
  {
    private readonly DoyinGoSupportTicketBLL objDoyinGoSupportTicketBll = new DoyinGoSupportTicketBLL();
    private CloudAccountDA.DoyinGoSupportTicketDataTable objDoyinGoSupportTicketDT = new CloudAccountDA.DoyinGoSupportTicketDataTable();
    private readonly DoyinGoTicketAttachmentBLL objDoyinGoTicketAttachmentBll = new DoyinGoTicketAttachmentBLL();
    private CloudAccountDA.DoyinGoTicketAttachmentDataTable objDoyinGoTicketAttachmentDT = new CloudAccountDA.DoyinGoTicketAttachmentDataTable();
    private readonly DoyinGoSupportDiscussionBLL objDoyinGoSupportDiscussionBll = new DoyinGoSupportDiscussionBLL();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly SupportDepartmentMasterBLL objSupportDepartmentMasterBll = new SupportDepartmentMasterBLL();
    private CloudAccountDA.SupportDepartmentMasterDataTable objSupportDepartmentMasterDT = new CloudAccountDA.SupportDepartmentMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected DropDownList ddlSupportDepartment;
    protected RequiredFieldValidator rfvDepartment;
    protected SqlDataSource sqldsSupportDepartment;
    protected TextBox txtSubject;
    protected RequiredFieldValidator rfvSubject;
    protected TextBox txtMessage;
    protected RequiredFieldValidator rfvMessage;
    protected DropDownList ddlSupportPriority;
    protected UpdatePanel upFile;
    protected HtmlGenericControl divAttach;
    protected FileUpload fuAttach1;
    protected FileUpload fuAttach2;
    protected FileUpload fuAttach3;
    protected FileUpload fuAttach4;
    protected FileUpload fuAttach5;
    protected Button btnAddFile;
    protected Button btnSave;
    protected Button btnUpdate;
    protected Panel pnlView;
    protected Button btnClose;
    protected Button btnOpen;
    protected Label lblSubject;
    protected Label lblSupportDate;
    protected Label lblSupportDepartment;
    protected Label lblStatus;
    protected UpdatePanel upEditPriority;
    protected Label lblSupportPriority;
    protected DropDownList ddlPriority;
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
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected GridView gvSupportTicket;
    protected ObjectDataSource objdsSupportTicket;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected HiddenField hfSupportTicketID;

    private List<int> ControlIds
    {
      get
      {
        return (List<int>) this.ViewState["ControlIds"] ?? new List<int>();
      }
      set
      {
        this.ViewState["ControlIds"] = (object) value;
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("home")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("doyinGoSupport")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
      {
        foreach (int num in this.ControlIds)
        {
          FileUpload fileUpload = new FileUpload();
          fileUpload.ID = "fileUpload" + (object) num;
          this.divAttach.Controls.Add((Control) fileUpload);
          this.divAttach.Controls.Add((Control) new LiteralControl("<br />"));
        }
      }
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
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
          }
        }
      }
      if (this.IsPostBack)
        return;
      this.Session.Abandon();
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string sId = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(sId);
            break;
          case "copied":
            if (this.Request.QueryString["ID"] == null)
              break;
            this.SetRecord(this.Request.QueryString["ID"]);
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = false;
            this.btnSave.Visible = true;
            this.btnUpdate.Visible = false;
            this.ddlSupportDepartment.Focus();
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null)
            {
              this.SetRecord(this.Request.QueryString["ID"]);
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.btnSave.Visible = false;
              this.btnUpdate.Visible = true;
              this.ddlSupportDepartment.Focus();
              break;
            }
            this.Clear();
            this.ddlSupportDepartment.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlView.Visible = false;
            this.pnlAdd.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnSave.Visible = true;
            break;
          default:
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.pnlAdd.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
        this.BindGrid();
      }
    }

    private void SetRecord(string sId)
    {
      this.objDoyinGoSupportTicketDT = this.objDoyinGoSupportTicketBll.GetDataByDoyinGoSupportTicketID(int.Parse(sId));
      if (this.objDoyinGoSupportTicketDT.Rows.Count <= 0)
        return;
      this.hfSupportTicketID.Value = this.objDoyinGoSupportTicketDT.Rows[0]["DoyinGoSupportTicketID"].ToString();
      this.ddlSupportDepartment.SelectedValue = this.objDoyinGoSupportTicketDT.Rows[0]["SupportDepartmentID"].ToString();
      this.txtSubject.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Subject"].ToString();
      this.txtMessage.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Message"].ToString();
      this.ddlSupportPriority.SelectedValue = this.objDoyinGoSupportTicketDT.Rows[0]["SupportPriority"].ToString();
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
      this.lblSupportDate1.Text = this.lblSupportDate.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportDate"].ToString();
      this.lblSupportDate1.Text = "Posted On: " + this.objDoyinGoSupportTicketDT.Rows[0]["SupportDate"];
      this.lblSubject.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Subject"].ToString();
      this.lblMessage.Text = this.objDoyinGoSupportTicketDT.Rows[0]["Message"].ToString();
      this.ddlPriority.SelectedValue = this.lblSupportPriority.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportPriority"].ToString();
      this.lblStatus.Text = this.objDoyinGoSupportTicketDT.Rows[0]["SupportStatus"].ToString();
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
      this.ddlSupportDepartment.SelectedIndex = this.ddlSupportPriority.SelectedIndex = 0;
      this.txtMessage.Text = this.txtSubject.Text = "";
      this.ddlSupportDepartment.Focus();
    }

    private void BindGrid()
    {
      this.gvSupportTicket.DataBind();
    }

    protected void btnAddFile_Click(object sender, EventArgs e)
    {
      int num = new Random().Next(0, 100);
      List<int> controlIds = this.ControlIds;
      if (controlIds.Contains(num))
        return;
      controlIds.Add(num);
      this.ControlIds = controlIds;
      FileUpload fileUpload = new FileUpload();
      fileUpload.ID = "fileUpload" + (object) num;
      this.divAttach.Controls.Add((Control) fileUpload);
      this.divAttach.Controls.Add((Control) new LiteralControl("<br />"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlSupportDepartment.SelectedIndex > 0 && this.txtMessage.Text.Trim().Length > 0 && this.txtSubject.Text.Trim().Length > 0)
      {
        int iSupportTicketID = this.objDoyinGoSupportTicketBll.AddDoyinGoSupportTicket(int.Parse(this.hfCompanyID.Value), new int?(int.Parse(this.ddlSupportDepartment.SelectedItem.Value)), this.txtSubject.Text.Trim(), this.txtMessage.Text.Trim().Replace("\n", "<br />"), this.ddlSupportPriority.SelectedItem.Text, "Open");
        if (iSupportTicketID != 0)
        {
          if (this.divAttach.Controls.Count > 0)
          {
            if (this.fuAttach1.HasFile)
            {
              int contentLength = this.fuAttach1.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAttach1.PostedFile.InputStream.Read(numArray, 0, contentLength);
              this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, this.fuAttach1.FileName, this.fuAttach1.FileName.Split('.')[1], numArray);
            }
            if (this.fuAttach2.HasFile)
            {
              int contentLength = this.fuAttach2.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAttach2.PostedFile.InputStream.Read(numArray, 0, contentLength);
              this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, this.fuAttach2.FileName, this.fuAttach2.FileName.Split('.')[1], numArray);
            }
            if (this.fuAttach3.HasFile)
            {
              int contentLength = this.fuAttach3.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAttach3.PostedFile.InputStream.Read(numArray, 0, contentLength);
              this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, this.fuAttach3.FileName, this.fuAttach3.FileName.Split('.')[1], numArray);
            }
            if (this.fuAttach4.HasFile)
            {
              int contentLength = this.fuAttach4.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAttach4.PostedFile.InputStream.Read(numArray, 0, contentLength);
              this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, this.fuAttach4.FileName, this.fuAttach4.FileName.Split('.')[1], numArray);
            }
            if (this.fuAttach5.HasFile)
            {
              int contentLength = this.fuAttach5.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAttach5.PostedFile.InputStream.Read(numArray, 0, contentLength);
              this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, this.fuAttach5.FileName, this.fuAttach5.FileName.Split('.')[1], numArray);
            }
            foreach (int num in this.ControlIds)
            {
              FileUpload fileUpload1 = new FileUpload();
              fileUpload1.ID = "fileUpload" + (object) num;
              FileUpload fileUpload2 = fileUpload1;
              if (fileUpload2.HasFile)
              {
                int contentLength = fileUpload2.PostedFile.ContentLength;
                byte[] numArray = new byte[contentLength];
                fileUpload2.PostedFile.InputStream.Read(numArray, 0, contentLength);
                this.objDoyinGoTicketAttachmentBll.AddDoyinGoTicketAttachment(iSupportTicketID, fileUpload2.FileName, fileUpload2.FileName.Split('.')[1], numArray);
              }
            }
          }
          this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=view&ID=" + (object) iSupportTicketID);
        }
        else
          this.DisplayAlert("Insertion Failed..Please Try After Some Time..!");
      }
      else
        this.DisplayAlert("Please Fill All Requied Data..!");
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
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
      this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=view&ID=" + this.gvSupportTicket.SelectedRow.Cells[0].Text);
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
      this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentID(int.Parse(e.Row.Cells[1].Text));
      e.Row.Cells[1].Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentName"].ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=add");
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value))
        return;
      this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "Closed");
      this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
    }

    protected void btnOpen_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value))
        return;
      this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "Open");
      this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
    }

    protected void btnSaveDiscussion_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.hfSupportTicketID.Value) || this.txtDiscussion.Text.Trim().Length <= 0)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        this.objDoyinGoSupportDiscussionBll.AddDoyinGoSupportDiscussion(int.Parse(this.hfSupportTicketID.Value), this.txtDiscussion.Text.Trim().Replace("\n", "<br />"), DateTime.Now, "CAdmin_" + user.UserName);
        this.objDoyinGoSupportTicketBll.UpdateSupportStatus(int.Parse(this.hfSupportTicketID.Value), "On Hold");
      }
      this.Response.Redirect("DoyinGoSupportTicket.aspx?cmd=view&ID=" + this.hfSupportTicketID.Value);
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

    protected void lnkEditPriority_Click(object sender, EventArgs e)
    {
      this.lblSupportPriority.Visible = false;
      this.ddlPriority.Visible = true;
      this.lnkEditPriority.Visible = false;
    }

    protected void ddlPriority_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.objDoyinGoSupportTicketBll.UpdateSupportPriority(int.Parse(this.hfSupportTicketID.Value), this.ddlPriority.SelectedItem.Value);
      this.ViewRecord(this.hfSupportTicketID.Value);
      this.lblSupportPriority.Visible = true;
      this.ddlPriority.Visible = false;
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
      if (status == "Awaiting Client Reply")
        return "Replied";
      return status;
    }
  }
}
