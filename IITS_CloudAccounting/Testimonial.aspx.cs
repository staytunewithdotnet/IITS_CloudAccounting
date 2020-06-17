// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Testimonial
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class Testimonial : Page
  {
    private readonly TestimonialsMasterBLL _objTestimonialsMasterBll = new TestimonialsMasterBLL();
    private CloudAccountDA.TestimonialsMasterDataTable _objTestimonialsMasterDt = new CloudAccountDA.TestimonialsMasterDataTable();
    private readonly PagedDataSource _pds = new PagedDataSource();
    protected ToolkitScriptManager tsm;
    protected Repeater rpTestimonial;
    protected LinkButton lnkbtnPrevious;
    protected DataList dlPaging;
    protected LinkButton lnkbtnNext;
    protected SqlDataSource sqldsTestimonial;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected TextBox txtLocation;
    protected RequiredFieldValidator RequiredFieldValidator3;
    protected TextBox txtComment;
    protected UpdatePanel upCaptcha;
    protected Image imgCaptcha;
    protected Button btnRefresh;
    protected TextBox txtCaptcha;
    protected RequiredFieldValidator rfvCaptcha;
    protected Button btnSubmit;

    public int CurrentPage
    {
      get
      {
        if (this.ViewState["CurrentPage"] != null)
          return (int) Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
        return 0;
      }
      set
      {
        this.ViewState["CurrentPage"] = (object) value;
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("Testimonial")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      if (this.IsPostBack)
        return;
      this.BindTestimonials();
      this.FillCapctha();
    }

    private void FillCapctha()
    {
      try
      {
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 6; ++index)
          stringBuilder.Append("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[random.Next("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)]);
        this.Session["captcha"] = (object) stringBuilder.ToString();
        this.imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
        throw;
      }
    }

    protected void BtnRefreshClick(object sender, EventArgs e)
    {
      this.FillCapctha();
    }

    private void BindTestimonials()
    {
      this._objTestimonialsMasterDt = this._objTestimonialsMasterBll.GetAllDataForPage();
      this.rpTestimonial.DataSource = (object) this._objTestimonialsMasterDt;
      this.rpTestimonial.DataBind();
      this._pds.DataSource = (IEnumerable) this._objTestimonialsMasterDt.DefaultView;
      this._pds.AllowPaging = true;
      this._pds.PageSize = 6;
      this._pds.CurrentPageIndex = this.CurrentPage;
      this.lnkbtnNext.Enabled = !this._pds.IsLastPage;
      this.lnkbtnPrevious.Enabled = !this._pds.IsFirstPage;
      this.rpTestimonial.DataSource = (object) this._pds;
      this.rpTestimonial.DataBind();
      this.DoPaging();
    }

    protected void LnkbtnPreviousClick(object sender, EventArgs e)
    {
      --this.CurrentPage;
      this.BindTestimonials();
    }

    protected void LnkbtnNextClick(object sender, EventArgs e)
    {
      ++this.CurrentPage;
      this.BindTestimonials();
    }

    protected void DlPagingItemCommand(object source, DataListCommandEventArgs e)
    {
      if (!e.CommandName.Equals("lnkbtnPaging"))
        return;
      this.CurrentPage = (int) Convert.ToInt16(e.CommandArgument.ToString());
      this.BindTestimonials();
    }

    protected void DlPagingItemDataBound(object sender, DataListItemEventArgs e)
    {
      LinkButton linkButton = (LinkButton) e.Item.FindControl("lnkbtnPaging");
      if (!(linkButton.CommandArgument.ToString((IFormatProvider) CultureInfo.InvariantCulture) == this.CurrentPage.ToString((IFormatProvider) CultureInfo.InvariantCulture)))
        return;
      linkButton.Enabled = false;
      linkButton.Font.Bold = true;
    }

    private void DoPaging()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("PageIndex");
      dataTable.Columns.Add("PageText");
      for (int index = 0; index < this._pds.PageCount; ++index)
      {
        DataRow row = dataTable.NewRow();
        row[0] = (object) index;
        row[1] = (object) (index + 1);
        dataTable.Rows.Add(row);
      }
      this.dlPaging.DataSource = (object) dataTable;
      this.dlPaging.DataBind();
    }

    protected void BtnSubmitClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0 && (this.txtLocation.Text.Trim().Length > 0 && this.txtCaptcha.Text.Trim().Length > 0))
      {
        bool flag = this.Session["captcha"].ToString() == this.txtCaptcha.Text;
        this.FillCapctha();
        if (flag)
        {
          if (this._objTestimonialsMasterBll.AddTestimonials(this.txtName.Text.Trim(), this.txtCompanyName.Text.Trim(), this.txtLocation.Text.Trim(), this.txtComment.Text.Trim(), new DateTime?(DateTime.Now), false) != 0)
          {
            this.DisplayAlert("Testimonial Added Successfully.");
            this.Response.Redirect("Testimonial.aspx");
          }
          else
          {
            this.DisplayAlert("Fail to Add New Testimonial.");
            this.Clear();
          }
        }
        else
          this.DisplayAlert("Please Enter Valid Captcha Code..!");
      }
      else
        this.DisplayAlert("Please Fill All Details...!");
    }

    private void Clear()
    {
      this.txtName.Text = this.txtCompanyName.Text = this.txtLocation.Text = this.txtComment.Text = "";
      this.txtName.Focus();
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
