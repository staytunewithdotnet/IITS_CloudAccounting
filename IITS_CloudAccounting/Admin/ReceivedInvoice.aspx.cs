// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ReceivedInvoice
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ReceivedInvoice : Page
  {
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly ItemMasterBLL objItemMasterBll = new ItemMasterBLL();
    private CloudAccountDA.ItemMasterDataTable objItemMasterDT = new CloudAccountDA.ItemMasterDataTable();
    private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
    private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlView;
    protected Label lblInvoiceNumHead;
    protected HtmlGenericControl divStatus;
    protected Label lblCompanyName;
    protected Label lblCompanyAddress;
    protected Image imgLogo;
    protected Label lblClientOrganizationName;
    protected Label lblClientFullName;
    protected Label lblClientAddress;
    protected Label lblInvoiceNum;
    protected Label lblInvoiceDate;
    protected Label lblPONumber;
    protected Label lblCurSymbolView1;
    protected Label lblInvoiceAmount;
    protected Label lblCurCodeView1;
    protected GridView gvTaskView;
    protected GridView gvItemView;
    protected ObjectDataSource objdsItemView;
    protected ObjectDataSource objdsTaskView;
    protected Label lblSubTotalView;
    protected Label lblDiscout;
    protected Label lblDiscountAmt;
    protected Label lblAddedTaxesView;
    protected HtmlGenericControl divTaxView;
    protected HtmlGenericControl divTaxValueView;
    protected Label lblInvoiceTotalView;
    protected Label lblPaidToDateView;
    protected Label lblCurSymbolView2;
    protected Label lblAmountDue;
    protected Label lblCurCodeView2;
    protected Label lblTerms;
    protected Label lblNotes;
    protected HtmlGenericControl brandingDiv;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected TextBox txtClientNameSearch;
    protected DropDownList ddlStatusSearch;
    protected TextBox txtInvoiceDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtInvoiceDateTo;
    protected CalendarExtender ceDateTo;
    protected TextBox txtInvoiceTotalFrom;
    protected TextBox txtInvoiceTotalTo;
    protected Button btnSearch;
    protected Button btnReset;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected Button btnConvert;
    protected GridView gvInvoice;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected GridView gvInvoiceTotal;
    protected SqlDataSource sqldsInvoiceTotalCompany;
    protected ObjectDataSource objdsInvoice;
    protected HiddenField hfCompanyEmail;
    protected HiddenField hfInvoiceID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      this.Page.MaintainScrollPositionOnPostBack = true;
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("receivedInvoice")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
          this.hfCompanyEmail.Value = username;
      }
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string id = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.ViewRecord(id);
            break;
          default:
            this.btnArchived.Visible = !this.CheckARQuery();
            this.btnUnArchived.Visible = this.CheckARQuery();
            this.btnDelete.Visible = !this.CheckDEQuery();
            this.btnUnDelete.Visible = this.CheckDEQuery();
            this.ATagStyle();
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.btnArchived.Visible = !this.CheckARQuery();
        this.btnUnArchived.Visible = this.CheckARQuery();
        this.btnDelete.Visible = !this.CheckDEQuery();
        this.btnUnDelete.Visible = this.CheckDEQuery();
        this.ATagStyle();
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Received Invoices";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Received Invoices";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Received Invoices";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Received Invoices";
    }

    private void BindGrid()
    {
      this.gvInvoice.DataBind();
      this.gvInvoiceTotal.DataBind();
    }

    private void ViewRecord(string id)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(id));
      if (this.objInvoiceMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objInvoiceMasterDT.Rows[0]["CompanyID"].ToString();
      this.hfInvoiceID.Value = this.objInvoiceMasterDT.Rows[0]["InvoiceID"].ToString();
      this.lblInvoiceNum.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"].ToString();
      this.lblTerms.Text = this.objInvoiceMasterDT.Rows[0]["Terms"].ToString();
      this.lblNotes.Text = this.objInvoiceMasterDT.Rows[0]["Notes"].ToString();
      this.lblInvoiceNumHead.Text = "Invoice: " + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"];
      this.lblInvoiceDate.Text = DateTime.Parse(this.objInvoiceMasterDT.Rows[0]["InvoiceDate"].ToString()).ToString("MMMM dd, yyyy");
      this.lblPONumber.Text = this.objInvoiceMasterDT.Rows[0]["PONumber"].ToString();
      string s1 = this.objInvoiceMasterDT.Rows[0]["Discount"].ToString();
      this.lblDiscout.Text = s1.Length > 0 ? s1 : "0.00";
      this.lblInvoiceTotalView.Text = Decimal.Round(Decimal.Parse(this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString()), 2).ToString();
            this.lblPaidToDateView.Text = "0";// Decimal.Round(Decimal.Parse(this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString()), 2).ToString();
      Label label1 = this.lblInvoiceAmount;
      Label label2 = this.lblAmountDue;
            Decimal num1 = Decimal.Parse(this.lblInvoiceTotalView.Text) - Decimal.Parse(this.lblPaidToDateView.Text);
      string str1;
      string str2 = str1 = num1.ToString();
      label2.Text = str1;
      string str3 = str2;
      label1.Text = str3;
      Label label3 = this.lblInvoiceAmount;
      Label label4 = this.lblAmountDue;
      Decimal num2 = Decimal.Round(Decimal.Parse(this.lblAmountDue.Text), 2);
      string str4;
      string str5 = str4 = num2.ToString();
      label4.Text = str4;
      string str6 = str5;
      label3.Text = str6;
      this.divTaxValueView.Controls.Clear();
      this.divTaxView.Controls.Clear();
      Hashtable hashtable = new Hashtable();
      if (this.gvTaskView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTaskView.Rows.Count; ++index)
        {
          string text1 = this.gvTaskView.Rows[index].Cells[2].Text;
          string text2 = this.gvTaskView.Rows[index].Cells[3].Text;
          string text3 = this.gvTaskView.Rows[index].Cells[4].Text;
          string text4 = this.gvTaskView.Rows[index].Cells[5].Text;
          try
          {
            if (!string.IsNullOrEmpty(text3) && !text3.Contains("&"))
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text3);
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                Label label5 = new Label()
                {
                  Text = this.gvTaskView.Rows[index].Cells[4].Text + "(" + s2 + ")"
                };
                Label label6 = new Label()
                {
                  Text = string.Concat((object) Decimal.Round(d, 2))
                };
                if (hashtable.ContainsKey((object) label5.Text))
                {
                  object obj = hashtable[(object) label5.Text];
                  Decimal num3 = d + Decimal.Parse(obj.ToString());
                  hashtable.Remove((object) label5.Text);
                  hashtable.Add((object) label5.Text, (object) num3.ToString());
                }
                else
                  hashtable.Add((object) label5.Text, (object) label6.Text);
              }
            }
            if (!string.IsNullOrEmpty(text4))
            {
              if (!text4.Contains("&"))
              {
                this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                if (this.objTaxMasterDT.Rows.Count > 0)
                {
                  string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                  Label label5 = new Label()
                  {
                    Text = this.gvTaskView.Rows[index].Cells[5].Text + "(" + s2 + ")"
                  };
                  Label label6 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label5.Text))
                  {
                    object obj = hashtable[(object) label5.Text];
                    Decimal num3 = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label5.Text);
                    hashtable.Add((object) label5.Text, (object) num3.ToString());
                  }
                  else
                    hashtable.Add((object) label5.Text, (object) label6.Text);
                }
              }
            }
          }
          catch (Exception ex)
          {
            this.gvTaskView.Rows[index].Cells[4].Text = "";
            this.gvTaskView.Rows[index].Cells[5].Text = "";
          }
        }
      }
      if (this.gvItemView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvItemView.Rows.Count; ++index)
        {
          string text1 = this.gvItemView.Rows[index].Cells[2].Text;
          string text2 = this.gvItemView.Rows[index].Cells[3].Text;
          string text3 = this.gvItemView.Rows[index].Cells[4].Text;
          string text4 = this.gvItemView.Rows[index].Cells[5].Text;
          try
          {
            if (!string.IsNullOrEmpty(text3) && !text3.Contains("&"))
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text3);
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                Label label5 = new Label()
                {
                  Text = this.gvItemView.Rows[index].Cells[4].Text + "(" + s2 + ")"
                };
                Label label6 = new Label()
                {
                  Text = string.Concat((object) Decimal.Round(d, 2))
                };
                if (hashtable.ContainsKey((object) label5.Text))
                {
                  object obj = hashtable[(object) label5.Text];
                  Decimal num3 = d + Decimal.Parse(obj.ToString());
                  hashtable.Remove((object) label5.Text);
                  hashtable.Add((object) label5.Text, (object) num3.ToString());
                }
                else
                  hashtable.Add((object) label5.Text, (object) label6.Text);
              }
            }
            if (!string.IsNullOrEmpty(text4))
            {
              if (!text4.Contains("&"))
              {
                this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                if (this.objTaxMasterDT.Rows.Count > 0)
                {
                  string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                  Label label5 = new Label()
                  {
                    Text = this.gvItemView.Rows[index].Cells[5].Text + "(" + s2 + ")"
                  };
                  Label label6 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label5.Text))
                  {
                    object obj = hashtable[(object) label5.Text];
                    Decimal num3 = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label5.Text);
                    hashtable.Add((object) label5.Text, (object) num3.ToString());
                  }
                  else
                    hashtable.Add((object) label5.Text, (object) label6.Text);
                }
              }
            }
          }
          catch (Exception ex)
          {
            this.gvItemView.Rows[index].Cells[4].Text = "";
            this.gvItemView.Rows[index].Cells[5].Text = "";
          }
        }
      }
      if (hashtable.Count > 0)
      {
        foreach (string str7 in (IEnumerable) hashtable.Keys)
        {
          this.divTaxView.Controls.Add((Control) new Label()
          {
            Text = str7
          });
          this.divTaxView.Controls.Add((Control) new LiteralControl("<br />"));
        }
        foreach (object obj in (IEnumerable) hashtable.Values)
        {
          this.divTaxValueView.Controls.Add((Control) new Label()
          {
            Text = ("+" + (object) Decimal.Round(Decimal.Parse(obj.ToString()), 2))
          });
          this.divTaxValueView.Controls.Add((Control) new LiteralControl("<br />"));
        }
      }
      Decimal d1 = new Decimal(0);
      if (this.gvItemView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvItemView.Rows.Count; ++index)
        {
          string text = this.gvItemView.Rows[index].Cells[6].Text;
          d1 += Decimal.Parse(text);
        }
      }
      if (this.gvTaskView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTaskView.Rows.Count; ++index)
        {
          string text = this.gvTaskView.Rows[index].Cells[6].Text;
          d1 += Decimal.Parse(text);
        }
      }
      Label label7 = this.lblSubTotalView;
      num2 = Decimal.Round(d1, 2);
      string str8 = num2.ToString();
      label7.Text = str8;
      Label label8 = this.lblDiscountAmt;
      num2 = Decimal.Parse(this.lblSubTotalView.Text) * Decimal.Parse(s1) / new Decimal(100);
      string str9 = num2.ToString();
      label8.Text = str9;
      Label label9 = this.lblDiscountAmt;
      num2 = Decimal.Round(Decimal.Parse(this.lblDiscountAmt.Text), 2);
      string str10 = num2.ToString();
      label9.Text = str10;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + this.objCompanyMasterDT.Rows[0]["CompanyID"];
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      string str11 = string.Empty;
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString()))
        str11 = str11 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString()))
        str11 = str11 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
          str11 = str11 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString()))
        str11 = str11 + this.objCompanyMasterDT.Rows[0]["CompanyZipCode"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
          str11 = str11 + this.objStateMasterDT.Rows[0]["StateName"] + ",<br />";
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
        if (this.objCountryMasterDT.Rows.Count > 0)
          str11 = str11 + this.objCountryMasterDT.Rows[0]["CountryName"] + ".<br />";
      }
      this.lblCompanyAddress.Text = str11;
      Label label10 = this.lblCompanyAddress;
      string str12 = label10.Text + (object) "Email: <a href=\"mailto:" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "\">" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "</a><br />";
      label10.Text = str12;
      Label label11 = this.lblCompanyAddress;
      string str13 = label11.Text + (object) "Phone: " + (string) this.objCompanyMasterDT.Rows[0]["CompanyPhone"];
      label11.Text = str13;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientId"].ToString()));
      this.lblClientOrganizationName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      this.lblClientFullName.Text = (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
      string str14 = string.Empty + this.objCompanyClientMasterDT.Rows[0]["Address1"] + " ";
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString()))
        str14 += ",<br />";
      string str15 = str14 + this.objCompanyClientMasterDT.Rows[0]["Address2"] + " ";
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString()))
        str15 += ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
          str15 = str15 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
      }
      string str16 = str15 + this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString();
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString()))
        str16 += ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
          str16 = str16 + this.objStateMasterDT.Rows[0]["StateName"] + " ";
      }
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()));
        str16 = str16 + this.objCountryMasterDT.Rows[0]["CountryName"] + ".";
      }
      this.lblClientAddress.Text = str16;
      this.divStatus.Attributes.Add("class", "status-" + this.SetStatus(this.objInvoiceMasterDT.Rows[0]["InvoiceStatus"].ToString()));
      string s3 = this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString();
      if (string.IsNullOrEmpty(s3))
        return;
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s3));
      if (this.objCurrencyMasterDT.Rows.Count <= 0)
        return;
      this.lblCurCodeView1.Text = this.lblCurCodeView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      this.lblCurSymbolView1.Text = this.lblCurSymbolView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
    }

    public string SetStatus(string status)
    {
      switch (status)
      {
        case "draft":
          return "draft";
        case "draft-partial":
          return "draft-partial";
        case "created":
        case "sent":
        case "viewed":
        case "outstanding":
          return "outstanding";
        case "disputed":
          return "disputed";
        case "paid":
          return "paid";
        case "partial":
          return "partial";
        case "pending":
          return "pending";
        case "declined":
          return "declined";
        case "auto-paid":
          return "auto-paid";
        case "retry":
          return "retry";
        case "failed":
          return "failed";
        case "replied":
          return "replied";
        case "commented":
          return "commented";
        case "resolved":
          return "resolved";
        case "accepted":
          return "accepted";
        case "invoiced":
          return "invoiced";
        case "open":
          return "open";
        default:
          return "created";
      }
    }

    protected void btnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objInvoiceMasterBll.UpdateWhenAnyReceivedBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Received Invoices were selected.");
      else
        this.Response.Redirect("ReceivedInvoice.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objInvoiceMasterBll.UpdateWhenAnyReceivedBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Received Invoices were selected.");
      else
        this.Response.Redirect("ReceivedInvoice.aspx?de=true&ac=false");
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objInvoiceMasterBll.UpdateWhenAnyReceivedBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Received Invoices were selected.");
      else
        this.Response.Redirect("ReceivedInvoice.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objInvoiceMasterBll.UpdateWhenAnyReceivedBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Received Invoices were selected.");
      else
        this.Response.Redirect("ReceivedInvoice.aspx?de=true&ac=false");
    }

    protected void btnConvert_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
      {
        if (((CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID")).Checked)
          ++num;
      }
      if (num == 0)
        this.DisplayAlert("No Received Invoices were selected.");
      else if (num > 1)
      {
        this.DisplayAlert("You can only convert one received invoice at a time.");
      }
      else
      {
        for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
        {
          CheckBox checkBox = (CheckBox) this.gvInvoice.Rows[index].Cells[0].FindControl("chkID");
          if (checkBox.Checked)
          {
            if (!bool.Parse(checkBox.CssClass))
            {
              this.Response.Redirect("ExpenseMaster.aspx?cmd=invoice&ID=" + checkBox.ToolTip);
            }
            else
            {
              this.DisplayAlert("Expence has already been created from this invoice.");
              break;
            }
          }
        }
      }
    }

    public bool CheckARQuery()
    {
      return this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]);
    }

    public bool CheckDEQuery()
    {
      return this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]);
    }

    protected void gvInvoice_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvInvoice.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[2].Text));
      e.Row.Cells[2].Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
    }

    protected string GetCurrency(string curId)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(curId));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return "(" + this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + ")";
      return "";
    }

    protected void gvItemView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      string text1 = e.Row.Cells[0].Text;
      string text2 = e.Row.Cells[4].Text;
      string text3 = e.Row.Cells[5].Text;
      this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(text1));
      if (this.objItemMasterDT.Rows.Count > 0)
        e.Row.Cells[0].Text = this.objItemMasterDT.Rows[0]["ItemName"].ToString();
      try
      {
        if (!string.IsNullOrEmpty(text2) && !text2.Contains("&"))
        {
          this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text2));
          if (this.objTaxMasterDT.Rows.Count > 0)
            e.Row.Cells[4].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
        }
        if (string.IsNullOrEmpty(text3) || text3.Contains("&"))
          return;
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text3));
        if (this.objTaxMasterDT.Rows.Count <= 0)
          return;
        e.Row.Cells[5].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      }
      catch (Exception ex)
      {
        e.Row.Cells[4].Text = "";
        e.Row.Cells[5].Text = "";
      }
    }

    protected void gvTaskView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      string text1 = e.Row.Cells[0].Text;
      string text2 = e.Row.Cells[4].Text;
      string text3 = e.Row.Cells[5].Text;
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(text1));
      if (this.objTaskMasterDT.Rows.Count > 0)
        e.Row.Cells[0].Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
      try
      {
        if (!string.IsNullOrEmpty(text2) && !text2.Contains("&"))
        {
          this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text2));
          if (this.objTaxMasterDT.Rows.Count > 0)
            e.Row.Cells[4].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
        }
        if (string.IsNullOrEmpty(text3) || text3.Contains("&"))
          return;
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text3));
        if (this.objTaxMasterDT.Rows.Count <= 0)
          return;
        e.Row.Cells[5].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      }
      catch (Exception ex)
      {
        e.Row.Cells[4].Text = "";
        e.Row.Cells[5].Text = "";
      }
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}
