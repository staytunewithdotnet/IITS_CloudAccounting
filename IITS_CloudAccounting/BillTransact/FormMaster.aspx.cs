// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FormMaster
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
  public class FormMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FormMasterBLL objFormMasterBll = new FormMasterBLL();
    private CloudAccountDA.FormMasterDataTable objFormMasterDT = new CloudAccountDA.FormMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtFormName;
    protected RequiredFieldValidator rfvFormName;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFormName;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvForm;
    protected Button btnAddForm;
    protected HiddenField hfForm;
    protected HiddenField hfMasterAdminID;
    protected ObjectDataSource objdsForm;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("formManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("formMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FormMaster.AddStatus = "True";
          FormMaster.EditStatus = "True";
          FormMaster.ViewStatus = "True";
          FormMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FormMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FormMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FormMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FormMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FormMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FormMaster.AddStatus = "";
            FormMaster.EditStatus = "";
            FormMaster.ViewStatus = "";
            FormMaster.DeleteStatus = "";
          }
        }
        else
        {
          FormMaster.AddStatus = "";
          FormMaster.EditStatus = "";
          FormMaster.ViewStatus = "";
          FormMaster.DeleteStatus = "";
        }
      }
      if (FormMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FormMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = FormMaster.EditStatus == "True";
              this.btnAddForm.Visible = this.btnAdd.Visible = FormMaster.AddStatus == "True";
              this.btnDelete.Visible = FormMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FormMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                this.txtFormName.Focus();
                break;
              }
              if (!(FormMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
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
          if (FormMaster.AddStatus == "False")
            this.btnAddForm.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddForm.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (FormMaster.AddStatus == "True" && FormMaster.EditStatus == "False" && (FormMaster.ViewStatus == "False" && FormMaster.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
        this.btnCancel.Visible = false;
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

    private void Clear()
    {
      this.txtFormName.Text = "";
      this.txtFormName.Focus();
    }

    private void BindGrid()
    {
      this.gvForm.DataBind();
    }

    private void ViewRecord(string i)
    {
      this.objFormMasterDT = this.objFormMasterBll.GetDataByFormID(int.Parse(i));
      if (this.objFormMasterDT.Rows.Count <= 0)
        return;
      this.hfForm.Value = this.objFormMasterDT.Rows[0]["FormID"].ToString();
      this.lblFormName.Text = this.objFormMasterDT.Rows[0]["FormName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objFormMasterDT = this.objFormMasterBll.GetDataByFormID(int.Parse(iD));
      if (this.objFormMasterDT.Rows.Count <= 0)
        return;
      this.hfForm.Value = this.objFormMasterDT.Rows[0]["FormID"].ToString();
      this.txtFormName.Text = this.objFormMasterDT.Rows[0]["FormName"].ToString();
    }

    protected void gvForm_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=view&ID=" + this.gvForm.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvForm.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvForm.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvForm, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAddForm_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtFormName.Text.Trim().Length > 0)
      {
        this.objFormMasterDT = this.objFormMasterBll.GetDataByFormName(this.txtFormName.Text.Trim());
        if (this.objFormMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Form Already Exist..");
          this.checkInDB = true;
        }
        if (!this.checkInDB)
        {
          int num = this.objFormMasterBll.AddForm(this.txtFormName.Text.Trim());
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=view&ID=" + (object) num);
          }
          else
          {
            this.DisplayAlert("Fail to Add New Details.");
            this.Clear();
          }
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.txtFormName.Text.Trim().Length > 0)
        {
          if (this.objFormMasterBll.UpdateForm(int.Parse(this.hfForm.Value), this.txtFormName.Text.Trim()))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Please Fill All Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfForm.Value != null)
      {
        if (this.objFormMasterBll.DeleteForm(int.Parse(this.hfForm.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/FormMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FormMaster.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FormMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
