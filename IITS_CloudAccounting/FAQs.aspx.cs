// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.FAQs
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
  public class FAQs : Page
  {
    private readonly FAQCategoryMasterBLL objFAQCategoryMasterBll = new FAQCategoryMasterBLL();
    private CloudAccountDA.FAQCategoryMasterDataTable objFAQCategoryMasterDT = new CloudAccountDA.FAQCategoryMasterDataTable();
    protected Panel pnlView;
    protected DataList dlFAQMaster;
    protected Panel pnlViewAll;
    protected DataList ddlFAQCategory;
    protected SqlDataSource sqldsFAQMaster;
    protected SqlDataSource sqldsFAQCategory;
    protected HiddenField hfFAQ;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("FAQs")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      this.hfFAQ.Value = "1";
      if (this.IsPostBack)
        return;
      try
      {
        if (this.Request.QueryString.Count > 0 && !string.IsNullOrEmpty(this.Request.QueryString["fId"]))
          this.Session["FAQCategoryID"] = (object) this.Request.QueryString["fId"];
        if (this.Session["FAQCategoryID"] != null)
        {
          this.sqldsFAQMaster.SelectParameters["FAQCategoryID"].DefaultValue = this.hfFAQ.Value = this.Session["FAQCategoryID"].ToString();
          this.sqldsFAQMaster.DataBind();
          this.Session.Abandon();
        }
        else
        {
          this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.MaxFAQCategoryID();
          if (this.objFAQCategoryMasterDT.Rows.Count > 0)
            this.hfFAQ.Value = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryID"].ToString();
          this.sqldsFAQMaster.SelectParameters["FAQCategoryID"].DefaultValue = this.hfFAQ.Value;
          this.sqldsFAQMaster.DataBind();
        }
        this.pnlView.Visible = true;
        this.pnlViewAll.Visible = false;
      }
      catch (Exception ex)
      {
        this.pnlView.Visible = false;
        this.pnlViewAll.Visible = true;
      }
    }

    protected void ddlFAQCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (this.hfFAQ.Value == ((Label) e.Item.FindControl("FAQCategoryIDLabel")).Text)
        ((WebControl) e.Item.FindControl("FAQCategoryNameLabel")).ForeColor = ColorTranslator.FromHtml("#2E9A9C");
      else
        ((WebControl) e.Item.FindControl("FAQCategoryNameLabel")).ForeColor = ColorTranslator.FromHtml("#7a7c82");
    }
  }
}
