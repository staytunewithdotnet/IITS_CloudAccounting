// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.HomePageSlider
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using AjaxControlToolkit.HTMLEditor;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class HomePageSlider : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly HomePageSliderBLL objHomePageSliderBll = new HomePageSliderBLL();
    private CloudAccountDA.HomePageSliderDataTable objHomePageSliderDT = new CloudAccountDA.HomePageSliderDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    public static bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected FileUpload flUploadSlider1;
    protected RequiredFieldValidator rfvflUploadSlider1;
    protected Editor edContent1;
    protected FileUpload flUploadSlider2;
    protected RequiredFieldValidator rfvflUploadSlider2;
    protected Editor edContent2;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Panel pnlView;
    protected Image imgSlider1;
    protected Label lblContent1;
    protected Image imgSlider2;
    protected Label lblContent2;
    protected Button btnEdit;
    protected HiddenField hfHome;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("homePageSlider")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          HomePageSlider.AddStatus = "True";
          HomePageSlider.EditStatus = "True";
          HomePageSlider.ViewStatus = "True";
          HomePageSlider.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "HomePageSlider");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            HomePageSlider.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            HomePageSlider.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            HomePageSlider.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            HomePageSlider.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            HomePageSlider.AddStatus = "";
            HomePageSlider.EditStatus = "";
            HomePageSlider.ViewStatus = "";
            HomePageSlider.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "HomePageSlider");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            HomePageSlider.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            HomePageSlider.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            HomePageSlider.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            HomePageSlider.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            HomePageSlider.AddStatus = "";
            HomePageSlider.EditStatus = "";
            HomePageSlider.ViewStatus = "";
            HomePageSlider.DeleteStatus = "";
          }
        }
        else
        {
          HomePageSlider.AddStatus = "";
          HomePageSlider.EditStatus = "";
          HomePageSlider.ViewStatus = "";
          HomePageSlider.DeleteStatus = "";
        }
      }
      if (HomePageSlider.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(HomePageSlider.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = HomePageSlider.EditStatus == "True";
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(HomePageSlider.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                this.rfvflUploadSlider1.Enabled = false;
                this.rfvflUploadSlider2.Enabled = false;
                break;
              }
              if (!(HomePageSlider.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              break;
            default:
              this.GotoPage();
              this.pnlView.Visible = false;
              this.pnlAdd.Visible = false;
              break;
          }
        }
        else
          this.GotoPage();
      }
      else if (HomePageSlider.AddStatus == "True" && HomePageSlider.EditStatus == "False" && (HomePageSlider.ViewStatus == "False" && HomePageSlider.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
        this.btnCancel.Visible = false;
        this.pnlView.Visible = false;
      }
      else
      {
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    private void GotoPage()
    {
      this.objHomePageSliderDT = this.objHomePageSliderBll.GetAllDetail();
      if (this.objHomePageSliderDT.Rows.Count > 0)
      {
        this.hfHome.Value = this.objHomePageSliderDT.Rows[0]["HomePageSliderID"].ToString();
        this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=view&ID=" + this.hfHome.Value);
      }
      else
        this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=add");
    }

    private void ViewRecord(string i)
    {
      this.objHomePageSliderDT = this.objHomePageSliderBll.GetDataByHomePageSliderID(int.Parse(i));
      if (this.objHomePageSliderDT.Rows.Count <= 0)
        return;
      this.hfHome.Value = this.objHomePageSliderDT.Rows[0]["HomePageSliderID"].ToString();
      this.lblContent1.Text = this.objHomePageSliderDT.Rows[0]["SliderContent1"].ToString();
      this.lblContent2.Text = this.objHomePageSliderDT.Rows[0]["SliderContent2"].ToString();
      this.imgSlider1.ImageUrl = "~/Handler/HomeSliderHandler1.ashx?id=" + this.hfHome.Value;
      this.imgSlider2.ImageUrl = "~/Handler/HomeSliderHandler2.ashx?id=" + this.hfHome.Value;
    }

    private void SetRecord(string iD)
    {
      this.objHomePageSliderDT = this.objHomePageSliderBll.GetDataByHomePageSliderID(int.Parse(iD));
      if (this.objHomePageSliderDT.Rows.Count <= 0)
        return;
      this.hfHome.Value = this.objHomePageSliderDT.Rows[0]["HomePageSliderID"].ToString();
      this.edContent1.Content = this.objHomePageSliderDT.Rows[0]["SliderContent1"].ToString();
      this.edContent2.Content = this.objHomePageSliderDT.Rows[0]["SliderContent2"].ToString();
    }

    private void Clear()
    {
      this.edContent1.Content = this.edContent2.Content = "";
      this.flUploadSlider1.Focus();
    }

    protected void btnAddHomePageSlider_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.flUploadSlider1.HasFile && this.flUploadSlider2.HasFile)
      {
        int contentLength1 = this.flUploadSlider1.PostedFile.ContentLength;
        byte[] numArray1 = new byte[contentLength1];
        this.flUploadSlider1.PostedFile.InputStream.Read(numArray1, 0, contentLength1);
        int contentLength2 = this.flUploadSlider2.PostedFile.ContentLength;
        byte[] numArray2 = new byte[contentLength2];
        this.flUploadSlider2.PostedFile.InputStream.Read(numArray2, 0, contentLength2);
        int num = this.objHomePageSliderBll.AddHomePageSlider(numArray1, this.edContent1.Content.Trim(), numArray2, this.edContent1.Content.Trim());
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=view&ID=" + (object) num);
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
          byte[] numArray1;
          byte[] numArray2;
          if (this.flUploadSlider1.HasFile && this.flUploadSlider2.HasFile)
          {
            int contentLength1 = this.flUploadSlider1.PostedFile.ContentLength;
            numArray1 = new byte[contentLength1];
            this.flUploadSlider1.PostedFile.InputStream.Read(numArray1, 0, contentLength1);
            int contentLength2 = this.flUploadSlider2.PostedFile.ContentLength;
            numArray2 = new byte[contentLength2];
            this.flUploadSlider2.PostedFile.InputStream.Read(numArray2, 0, contentLength2);
          }
          else if (this.flUploadSlider1.HasFile)
          {
            this.objHomePageSliderDT = this.objHomePageSliderBll.GetDataByHomePageSliderID(int.Parse(this.hfHome.Value.Trim()));
            numArray2 = (byte[]) this.objHomePageSliderDT.Rows[0]["Slider2"];
            int contentLength = this.flUploadSlider1.PostedFile.ContentLength;
            numArray1 = new byte[contentLength];
            this.flUploadSlider1.PostedFile.InputStream.Read(numArray1, 0, contentLength);
          }
          else if (this.flUploadSlider2.HasFile)
          {
            this.objHomePageSliderDT = this.objHomePageSliderBll.GetDataByHomePageSliderID(int.Parse(this.hfHome.Value.Trim()));
            numArray1 = (byte[]) this.objHomePageSliderDT.Rows[0]["Slider1"];
            int contentLength = this.flUploadSlider2.PostedFile.ContentLength;
            numArray2 = new byte[contentLength];
            this.flUploadSlider2.PostedFile.InputStream.Read(numArray2, 0, contentLength);
          }
          else
          {
            this.objHomePageSliderDT = this.objHomePageSliderBll.GetDataByHomePageSliderID(int.Parse(this.hfHome.Value.Trim()));
            numArray1 = (byte[]) this.objHomePageSliderDT.Rows[0]["Slider1"];
            numArray2 = (byte[]) this.objHomePageSliderDT.Rows[0]["Slider2"];
          }
          if (this.objHomePageSliderBll.UpdateHomePageSlider(int.Parse(this.hfHome.Value.Trim()), numArray1, this.edContent1.Content.Trim(), numArray2, this.edContent2.Content.Trim()))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfHome.Value != null)
      {
        if (this.objHomePageSliderBll.DeleteHomePageSlider(int.Parse(this.hfHome.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/HomePageSlider.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/HomePageSlider.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/HomePageSlider.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
