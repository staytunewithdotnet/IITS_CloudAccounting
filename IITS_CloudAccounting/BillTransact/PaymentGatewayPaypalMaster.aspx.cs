// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PaymentGatewayPaypalMaster
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
  public class PaymentGatewayPaypalMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly PaymentGatewayPaypalMasterBLL objPaymentGatewayPaypalMasterBll = new PaymentGatewayPaypalMasterBLL();
    private CloudAccountDA.PaymentGatewayPaypalMasterDataTable objPaymentGatewayPaypalMasterDT = new CloudAccountDA.PaymentGatewayPaypalMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected Panel pnlAdd;
    protected TextBox txtPaypalID;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblPaypalID;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvPaymentGateway;
    protected Button btnAddPaymentGateway;
    protected HiddenField hfPaymentGateway;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsPaymentGateway;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("paymentGatewayPaypal")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          PaymentGatewayPaypalMaster.AddStatus = "True";
          PaymentGatewayPaypalMaster.EditStatus = "True";
          PaymentGatewayPaypalMaster.ViewStatus = "True";
          PaymentGatewayPaypalMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "PaymentGatewayPaypalMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            PaymentGatewayPaypalMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PaymentGatewayPaypalMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PaymentGatewayPaypalMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PaymentGatewayPaypalMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PaymentGatewayPaypalMaster.AddStatus = "";
            PaymentGatewayPaypalMaster.EditStatus = "";
            PaymentGatewayPaypalMaster.ViewStatus = "";
            PaymentGatewayPaypalMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "PaymentGatewayPaypalMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            PaymentGatewayPaypalMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PaymentGatewayPaypalMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PaymentGatewayPaypalMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PaymentGatewayPaypalMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PaymentGatewayPaypalMaster.AddStatus = "";
            PaymentGatewayPaypalMaster.EditStatus = "";
            PaymentGatewayPaypalMaster.ViewStatus = "";
            PaymentGatewayPaypalMaster.DeleteStatus = "";
          }
        }
        else
        {
          PaymentGatewayPaypalMaster.AddStatus = "";
          PaymentGatewayPaypalMaster.EditStatus = "";
          PaymentGatewayPaypalMaster.ViewStatus = "";
          PaymentGatewayPaypalMaster.DeleteStatus = "";
        }
      }
      if (PaymentGatewayPaypalMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(PaymentGatewayPaypalMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = PaymentGatewayPaypalMaster.EditStatus == "True";
              this.btnAddPaymentGateway.Visible = this.btnAdd.Visible = PaymentGatewayPaypalMaster.AddStatus == "True";
              this.btnDelete.Visible = PaymentGatewayPaypalMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(PaymentGatewayPaypalMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(PaymentGatewayPaypalMaster.AddStatus == "True"))
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
          if (PaymentGatewayPaypalMaster.AddStatus == "False")
            this.btnAddPaymentGateway.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddPaymentGateway.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (PaymentGatewayPaypalMaster.AddStatus == "True" && PaymentGatewayPaypalMaster.EditStatus == "False" && (PaymentGatewayPaypalMaster.ViewStatus == "False" && PaymentGatewayPaypalMaster.DeleteStatus == "False"))
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
      this.objPaymentGatewayPaypalMasterDT = this.objPaymentGatewayPaypalMasterBll.GetDataByPaymentGatewayID(int.Parse(i));
      if (this.objPaymentGatewayPaypalMasterDT.Rows.Count <= 0)
        return;
      this.hfPaymentGateway.Value = this.objPaymentGatewayPaypalMasterDT.Rows[0]["PaymentGatewayPaypalID"].ToString();
      this.lblPaypalID.Text = this.objPaymentGatewayPaypalMasterDT.Rows[0]["PaypalID"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objPaymentGatewayPaypalMasterDT = this.objPaymentGatewayPaypalMasterBll.GetDataByPaymentGatewayID(int.Parse(iD));
      if (this.objPaymentGatewayPaypalMasterDT.Rows.Count <= 0)
        return;
      this.hfPaymentGateway.Value = this.objPaymentGatewayPaypalMasterDT.Rows[0]["PaymentGatewayPaypalID"].ToString();
      this.txtPaypalID.Text = this.objPaymentGatewayPaypalMasterDT.Rows[0]["PaypalID"].ToString();
    }

    private void Clear()
    {
      this.txtPaypalID.Text = "";
      this.txtPaypalID.Focus();
    }

    private void BindGrid()
    {
      this.gvPaymentGateway.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvPaymentGateway.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvPaymentGateway, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvPaymentGateway_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=view&ID=" + this.gvPaymentGateway.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPaymentGateway_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPaymentGateway.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddPaymentGateway_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtPaypalID.Text.Trim().Length > 0)
      {
        int num = this.objPaymentGatewayPaypalMasterBll.AddPaymentGateway(this.txtPaypalID.Text.Trim());
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Fail to Add New Details.");
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
          if (this.txtPaypalID.Text.Trim().Length > 0)
          {
            if (this.objPaymentGatewayPaypalMasterBll.UpdatePaymentGateway(int.Parse(this.hfPaymentGateway.Value.Trim()), this.txtPaypalID.Text.Trim()))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfPaymentGateway.Value != null)
      {
        if (this.objPaymentGatewayPaypalMasterBll.DeletePaymentGateway(int.Parse(this.hfPaymentGateway.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PaymentGatewayPaypalMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
