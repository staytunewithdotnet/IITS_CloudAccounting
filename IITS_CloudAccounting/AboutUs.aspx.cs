// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.AboutUs
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class AboutUs : Page
  {
    private readonly AboutCategoryMasterBLL objAboutCategoryMasterBll = new AboutCategoryMasterBLL();
    private CloudAccountDA.AboutCategoryMasterDataTable objAboutCategoryMasterDT = new CloudAccountDA.AboutCategoryMasterDataTable();
    protected DataList ddlAboutCategory;
    protected Panel pnlView;
    protected DataList dlAboutContent;
    protected Panel pnlViewAll;
    protected SqlDataSource sqldsAboutMaster;
    protected SqlDataSource sqldsAboutCategory;
    protected HiddenField hfAbout;

    protected void Page_Load(object sender, EventArgs e)
    {
      //if (this.Master == null)
      //  return;
      //((HtmlControl) this.Master.FindControl("aboutus")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      this.hfAbout.Value = "1";
      if (this.IsPostBack)
        return;
      try
      {
        if (this.Request.QueryString.Count > 0 && !string.IsNullOrEmpty(this.Request.QueryString["aId"]))
          this.Session["AboutCategoryID"] = (object) this.Request.QueryString["aId"];
        if (this.Session["AboutCategoryID"] != null)
        {
          this.sqldsAboutMaster.SelectParameters["AboutCategoryID"].DefaultValue = this.hfAbout.Value = this.Session["AboutCategoryID"].ToString();
          this.sqldsAboutMaster.DataBind();
          this.Session.Abandon();
        }
        else
        {
          this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.MaxAboutCategoryID();
          if (this.objAboutCategoryMasterDT.Rows.Count > 0)
            this.hfAbout.Value = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryID"].ToString();
          this.sqldsAboutMaster.SelectParameters["AboutCategoryID"].DefaultValue = this.hfAbout.Value;
          this.sqldsAboutMaster.DataBind();
        }
        //this.pnlView.Visible = true;
        //this.pnlViewAll.Visible = false;
      }
      catch (Exception ex)
      {
        //this.pnlView.Visible = false;
        //this.pnlViewAll.Visible = true;
      }
    }

    protected void ddlAboutCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (this.hfAbout.Value == ((Label) e.Item.FindControl("AboutCategoryIDLabel")).Text)
        ((WebControl) e.Item.FindControl("AboutCategoryNameLabel")).ForeColor = ColorTranslator.FromHtml("#2E9A9C");
      else
        ((WebControl) e.Item.FindControl("AboutCategoryNameLabel")).ForeColor = ColorTranslator.FromHtml("#7a7c82");
    }

    protected bool SetDivHideShow(byte[] img)
    {
      return img != null;
    }
  }
}
