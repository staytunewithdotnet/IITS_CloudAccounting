// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ClientMaster
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
  public class ClientMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly ClientMasterBLL objClientMasterBll = new ClientMasterBLL();
    private CloudAccountDA.ClientMasterDataTable objClientMasterDT = new CloudAccountDA.ClientMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtURL;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected FileUpload fuLogo;
    protected RequiredFieldValidator rfvLogo;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblURL;
    protected Image imgLogo;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvClient;
    protected Button btnAddClient;
    protected HiddenField hfClient;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsClient;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("clientMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          ClientMaster.AddStatus = "True";
          ClientMaster.EditStatus = "True";
          ClientMaster.ViewStatus = "True";
          ClientMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "ClientMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            ClientMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ClientMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ClientMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ClientMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ClientMaster.AddStatus = "";
            ClientMaster.EditStatus = "";
            ClientMaster.ViewStatus = "";
            ClientMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "ClientMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            ClientMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ClientMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ClientMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ClientMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ClientMaster.AddStatus = "";
            ClientMaster.EditStatus = "";
            ClientMaster.ViewStatus = "";
            ClientMaster.DeleteStatus = "";
          }
        }
        else
        {
          ClientMaster.AddStatus = "";
          ClientMaster.EditStatus = "";
          ClientMaster.ViewStatus = "";
          ClientMaster.DeleteStatus = "";
        }
      }
      if (ClientMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(ClientMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = ClientMaster.EditStatus == "True";
              this.btnAddClient.Visible = this.btnAdd.Visible = ClientMaster.AddStatus == "True";
              this.btnDelete.Visible = ClientMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(ClientMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlView.Visible = false;
                this.pnlViewAll.Visible = false;
                this.btnSubmit.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnReset.Visible = false;
                this.btnListAll.Visible = false;
                this.btnCancel.Visible = true;
                this.txtName.Focus();
                this.rfvLogo.Enabled = false;
                break;
              }
              if (!(ClientMaster.AddStatus == "True"))
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
          if (ClientMaster.AddStatus == "False")
            this.btnAddClient.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddClient.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (ClientMaster.AddStatus == "True" && ClientMaster.EditStatus == "False" && (ClientMaster.ViewStatus == "False" && ClientMaster.DeleteStatus == "False"))
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
      this.objClientMasterDT = this.objClientMasterBll.GetDataByClientID(int.Parse(i));
      if (this.objClientMasterDT.Rows.Count <= 0)
        return;
      this.hfClient.Value = this.objClientMasterDT.Rows[0]["ClientID"].ToString();
      this.lblURL.Text = this.objClientMasterDT.Rows[0]["ClientURL"].ToString();
      this.lblName.Text = this.objClientMasterDT.Rows[0]["ClientName"].ToString();
      this.lblStatus.Text = this.objClientMasterDT.Rows[0]["ClientStatus"].ToString() == "True" ? "True" : "False";
      this.imgLogo.ImageUrl = "~/Handler/ClientHandler.ashx?id=" + this.hfClient.Value;
    }

    private void SetRecord(string iD)
    {
      this.objClientMasterDT = this.objClientMasterBll.GetDataByClientID(int.Parse(iD));
      if (this.objClientMasterDT.Rows.Count <= 0)
        return;
      this.hfClient.Value = this.objClientMasterDT.Rows[0]["ClientID"].ToString();
      this.txtURL.Text = this.objClientMasterDT.Rows[0]["ClientURL"].ToString();
      this.txtName.Text = this.objClientMasterDT.Rows[0]["ClientName"].ToString();
      this.chkStatus.Checked = this.objClientMasterDT.Rows[0]["ClientStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtURL.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvClient.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvClient.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvClient, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvClient_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=view&ID=" + this.gvClient.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvClient.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddClient_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtURL.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0 && this.fuLogo.HasFile)
      {
        this.objClientMasterDT = this.objClientMasterBll.GetDataByClientName(this.txtName.Text);
        if (this.objClientMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Client Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int contentLength = this.fuLogo.PostedFile.ContentLength;
          byte[] numArray = new byte[contentLength];
          this.fuLogo.PostedFile.InputStream.Read(numArray, 0, contentLength);
          int num = this.objClientMasterBll.AddClient(this.txtName.Text.Trim(), this.txtURL.Text.Trim(), this.chkStatus.Checked, numArray);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtURL.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
          {
            bool flag;
            if (this.fuLogo.HasFile)
            {
              int contentLength = this.fuLogo.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuLogo.PostedFile.InputStream.Read(numArray, 0, contentLength);
              flag = this.objClientMasterBll.UpdateClient(int.Parse(this.hfClient.Value.Trim()), this.txtName.Text.Trim(), this.txtURL.Text.Trim(), this.chkStatus.Checked, numArray);
            }
            else
            {
              this.objClientMasterDT = this.objClientMasterBll.GetDataByClientID(int.Parse(this.hfClient.Value.Trim()));
              flag = this.objClientMasterBll.UpdateClient(int.Parse(this.hfClient.Value.Trim()), this.txtName.Text.Trim(), this.txtURL.Text.Trim(), this.chkStatus.Checked, (byte[]) this.objClientMasterDT.Rows[0]["ClientLogo"]);
            }
            if (flag)
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfClient.Value != null)
      {
        if (this.objClientMasterBll.DeleteClient(int.Parse(this.hfClient.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/ClientMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ClientMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ClientMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
