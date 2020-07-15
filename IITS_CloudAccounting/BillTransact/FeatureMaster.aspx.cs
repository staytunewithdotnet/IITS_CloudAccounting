// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FeatureMaster
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
  public class FeatureMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FeatureMasterBLL objFeatureMasterBll = new FeatureMasterBLL();
    private CloudAccountDA.FeatureMasterDataTable objFeatureMasterDT = new CloudAccountDA.FeatureMasterDataTable();
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
    protected TextBox txtFeatureName;
    protected RequiredFieldValidator rfvFeatureName;
    protected FileUpload fuFeatureImage;
    protected RequiredFieldValidator rfvfuFeatureImage;
    protected CheckBox chkStatus;
    protected CheckBox chkHome;
    protected TextBox txtDesc;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFeatureName;
    protected Image imgFeatureImage;
    protected Label lblStatus;
    protected Label lblHome;
    protected Label lblDesc;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFeature;
    protected Button btnAddNew;
    protected ObjectDataSource objdsFeature;
    protected HiddenField hfFeature;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("featureCat")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FeatureMaster.AddStatus = "True";
          FeatureMaster.EditStatus = "True";
          FeatureMaster.ViewStatus = "True";
          FeatureMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FeatureMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FeatureMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FeatureMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FeatureMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FeatureMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FeatureMaster.AddStatus = "";
            FeatureMaster.EditStatus = "";
            FeatureMaster.ViewStatus = "";
            FeatureMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "FeatureMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            FeatureMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FeatureMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FeatureMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FeatureMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FeatureMaster.AddStatus = "";
            FeatureMaster.EditStatus = "";
            FeatureMaster.ViewStatus = "";
            FeatureMaster.DeleteStatus = "";
          }
        }
        else
        {
          FeatureMaster.AddStatus = "";
          FeatureMaster.EditStatus = "";
          FeatureMaster.ViewStatus = "";
          FeatureMaster.DeleteStatus = "";
        }
      }
      if (FeatureMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FeatureMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = FeatureMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = FeatureMaster.AddStatus == "True";
              this.btnDelete.Visible = FeatureMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FeatureMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                this.txtFeatureName.Focus();
                this.rfvfuFeatureImage.Enabled = false;
                break;
              }
              if (!(FeatureMaster.AddStatus == "True"))
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
          if (FeatureMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (FeatureMaster.AddStatus == "True" && FeatureMaster.EditStatus == "False" && (FeatureMaster.ViewStatus == "False" && FeatureMaster.DeleteStatus == "False"))
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

    private void ViewRecord(string i)
    {
      this.objFeatureMasterDT = this.objFeatureMasterBll.GetDataByFeatureID(int.Parse(i));
      if (this.objFeatureMasterDT.Rows.Count <= 0)
        return;
      this.hfFeature.Value = this.objFeatureMasterDT.Rows[0]["FeatureID"].ToString();
      this.lblFeatureName.Text = this.objFeatureMasterDT.Rows[0]["FeatureName"].ToString();
      this.lblDesc.Text = this.objFeatureMasterDT.Rows[0]["FeatureDesc"].ToString();
      this.lblStatus.Text = this.objFeatureMasterDT.Rows[0]["FeatureStatus"].ToString() == "True" ? "True" : "False";
      this.lblHome.Text = this.objFeatureMasterDT.Rows[0]["ShowOnHomePage"].ToString() == "True" ? "True" : "False";
      this.imgFeatureImage.ImageUrl = "~/Handler/FeatureHandler.ashx?id=" + this.hfFeature.Value;
    }

    private void SetRecord(string iD)
    {
      this.objFeatureMasterDT = this.objFeatureMasterBll.GetDataByFeatureID(int.Parse(iD));
      if (this.objFeatureMasterDT.Rows.Count <= 0)
        return;
      this.hfFeature.Value = this.objFeatureMasterDT.Rows[0]["FeatureID"].ToString();
      this.txtFeatureName.Text = this.objFeatureMasterDT.Rows[0]["FeatureName"].ToString();
      this.txtDesc.Text = this.objFeatureMasterDT.Rows[0]["FeatureDesc"].ToString();
      this.chkStatus.Checked = this.objFeatureMasterDT.Rows[0]["FeatureStatus"].ToString() == "True";
      this.chkHome.Checked = this.objFeatureMasterDT.Rows[0]["ShowOnHomePage"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtFeatureName.Text = this.txtDesc.Text = "";
      this.chkStatus.Checked = this.chkHome.Checked = false;
      this.txtFeatureName.Focus();
    }

    private void BindGrid()
    {
      this.gvFeature.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFeature.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFeature, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFeature_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=view&ID=" + this.gvFeature.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFeature_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFeature.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvFeature_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objFeatureMasterDT = this.objFeatureMasterBll.GetDataByFeatureID(int.Parse(e.Row.Cells[1].Text));
      if (this.objFeatureMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objFeatureMasterDT.Rows[0]["FeatureName"].ToString();
    }

    protected void btnAddFeature_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtFeatureName.Text.Trim().Length > 0 && this.fuFeatureImage.HasFile)
      {
        this.objFeatureMasterDT = this.objFeatureMasterBll.GetDataByFeatureName(this.txtFeatureName.Text);
        if (this.objFeatureMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Feature  Already Exist..");
          FeatureMaster.checkInDB = true;
        }
        else
          FeatureMaster.checkInDB = false;
        if (!FeatureMaster.checkInDB)
        {
          int contentLength = this.fuFeatureImage.PostedFile.ContentLength;
          byte[] numArray = new byte[contentLength];
          this.fuFeatureImage.PostedFile.InputStream.Read(numArray, 0, contentLength);
          int num = this.objFeatureMasterBll.AddFeature(this.txtFeatureName.Text.Trim(), numArray, this.txtDesc.Text.Trim(), this.chkStatus.Checked, this.chkHome.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtFeatureName.Text.Trim().Length > 0)
          {
            if (this.fuFeatureImage.HasFile)
            {
              int contentLength = this.fuFeatureImage.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuFeatureImage.PostedFile.InputStream.Read(numArray, 0, contentLength);
              if (this.objFeatureMasterBll.UpdateFeature(int.Parse(this.hfFeature.Value.Trim()), this.txtFeatureName.Text.Trim(), numArray, this.txtDesc.Text.Trim(), this.chkStatus.Checked, this.chkHome.Checked))
              {
                this.DisplayAlert("Update Successfully..");
                this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
              }
              else
                this.DisplayAlert("Fail to Update Details.");
            }
            else
            {
              this.objFeatureMasterDT = this.objFeatureMasterBll.GetDataByFeatureID(int.Parse(this.hfFeature.Value.Trim()));
              if (this.objFeatureMasterBll.UpdateFeature(int.Parse(this.hfFeature.Value.Trim()), this.txtFeatureName.Text.Trim(), (byte[]) this.objFeatureMasterDT.Rows[0]["FeatureImage"], this.txtDesc.Text.Trim(), this.chkStatus.Checked, this.chkHome.Checked))
              {
                this.DisplayAlert("Update Successfully..");
                this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
              }
              else
                this.DisplayAlert("Fail to Update Details.");
            }
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFeature.Value != null)
      {
        if (this.objFeatureMasterBll.DeleteFeature(int.Parse(this.hfFeature.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/FeatureMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FeatureMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FeatureMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
