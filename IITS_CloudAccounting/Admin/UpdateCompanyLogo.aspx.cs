// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpdateCompanyLogo
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class UpdateCompanyLogo : Page
  {
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected HtmlGenericControl divSave;
    protected FileUpload fuLogo;
    protected Button btnSave;
    protected Button btnCancel;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("colorLogo")).Attributes.Add("class", "active open");
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
        else
          this.Response.Redirect("../MemberArea.aspx");
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveCmpLogo"] != null;
      this.Session.Abandon();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      FileStream fileStream = new FileStream(this.Server.MapPath("~/App_Themes/Blue/images/logo.jpg"), FileMode.Open, FileAccess.Read);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, (int) fileStream.Length);
      fileStream.Close();
      this.objCompanyMasterBll.UpdateOnlyLogo(int.Parse(this.hfCompanyID.Value), "application/jpg", numArray);
      this.Response.Redirect("~/Admin/UpdateCompanyLogo.aspx");
      this.Session["saveCmpLogo"] = (object) 1;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      if (this.fuLogo.HasFile)
      {
        string sCompanyLogoType = string.Empty;
        switch (Path.GetExtension(Path.GetFileName(this.fuLogo.PostedFile.FileName)))
        {
          case ".jpg":
          case ".jpge":
            sCompanyLogoType = "image/jpg";
            break;
          case ".png":
            sCompanyLogoType = "image/png";
            break;
          case ".gif":
            sCompanyLogoType = "image/gif";
            break;
          case ".dwg":
            sCompanyLogoType = "image/dwg";
            break;
        }
        Stream inputStream = this.fuLogo.PostedFile.InputStream;
        byte[] byCompanyLogo = new BinaryReader(inputStream).ReadBytes((int) inputStream.Length);
        if (!string.IsNullOrEmpty(sCompanyLogoType))
          this.objCompanyMasterBll.UpdateOnlyLogo(int.Parse(this.hfCompanyID.Value), sCompanyLogoType, byCompanyLogo);
        else
          this.DisplayAlert("Please Upload Image With Extension .png OR .gif OR .jpg OR .jpge ");
      }
      this.Session["saveCmpLogo"] = (object) 1;
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
