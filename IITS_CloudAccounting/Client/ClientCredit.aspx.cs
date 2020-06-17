// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.ClientCredit
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Client
{
  public class ClientCredit : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly TemplateSettingsBLL objTemplateSettingsBll = new TemplateSettingsBLL();
    private CloudAccountDA.TemplateSettingsDataTable objTemplateSettingsDT = new CloudAccountDA.TemplateSettingsDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly ItemMasterBLL objItemMasterBll = new ItemMasterBLL();
    private CloudAccountDA.ItemMasterDataTable objItemMasterDT = new CloudAccountDA.ItemMasterDataTable();
    private readonly CreditMasterBLL objCreditMasterBll = new CreditMasterBLL();
    private CloudAccountDA.CreditMasterDataTable objCreditMasterDT = new CloudAccountDA.CreditMasterDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    protected Panel pnlView;
    protected Label lblCreditNumHead;
    protected HtmlGenericControl divStatus;
    protected Label lblCompanyName;
    protected Label lblCompanyAddress;
    protected Image imgLogo;
    protected Label lblCompanyLogoText;
    protected Label lblClientOrganizationName;
    protected Label lblClientFullName;
    protected Label lblClientAddress;
    protected Label lblCreditTitle;
    protected Label lblCreditNum;
    protected Label lblCreditTitleDate;
    protected Label lblCreditDate;
    protected Label lblCurSymbolView1;
    protected Label lblCreditAmount;
    protected Label lblCurCodeView1;
    protected GridView gvTaskView;
    protected GridView gvItemView;
    protected ObjectDataSource objdsItemView;
    protected ObjectDataSource objdsTaskView;
    protected Label lblSubTotalView;
    protected Label lblAddedTaxesView;
    protected HtmlGenericControl divTaxView;
    protected HtmlGenericControl divTaxValueView;
    protected Label lblCurSymbolView2;
    protected Label lblCreditTotalView;
    protected Label lblCurCodeView2;
    protected Label lblTerms;
    protected Label lblNotes;
    protected HtmlGenericControl brandingDiv;
    protected GridView gvCreditHistory;
    protected ObjectDataSource objdsCreditHistory;
    protected Panel pnlViewAll;
    protected GridView gvCredit;
    protected ObjectDataSource objdsCredit;
    protected HiddenField hfClientID;
    protected HiddenField hfCreditID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("credits")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByUsername(user.ToString());
        if (this.objCompanyClientMasterDT.Rows.Count > 0)
        {
          this.hfClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
        }
        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
        if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
        {
          this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
          this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
        }
        this.SetMiscValues(this.hfCompanyID.Value);
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
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvCredit.PageSize = this.linePerPage;
      this.lblCompanyLogoText.Text = this.objMiscellaneousMasterDT.Rows[0]["TextBelowYourLogo"].ToString();
      this.brandingDiv.Visible = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"];
    }

    private void BindGrid()
    {
      this.gvCredit.DataBind();
    }

    private void ViewRecord(string id)
    {
      bool flag = false;
      this.objCreditMasterDT = this.objCreditMasterBll.GetDataByCreditID(int.Parse(id));
      if (this.objCreditMasterDT.Rows.Count > 0)
        flag = this.objCreditMasterDT.Rows[0]["ClientID"].ToString() == this.hfClientID.Value;
      if (this.objCreditMasterDT.Rows.Count > 0 && flag)
      {
        this.hfCompanyID.Value = this.objCreditMasterDT.Rows[0]["CompanyID"].ToString();
        this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objTemplateSettingsDT.Rows.Count > 0)
        {
          this.lblCreditTitle.Text = (string) this.objTemplateSettingsDT.Rows[0]["CreditTitle"] + (object) " #";
          this.lblCreditTitleDate.Text = (string) this.objTemplateSettingsDT.Rows[0]["CreditTitle"] + (object) " Date";
        }
        this.hfCreditID.Value = this.objCreditMasterDT.Rows[0]["CreditID"].ToString();
        this.lblCreditNum.Text = this.objCreditMasterDT.Rows[0]["CreditNumber"].ToString();
        this.lblTerms.Text = this.objCreditMasterDT.Rows[0]["Terms"].ToString();
        this.lblNotes.Text = this.objCreditMasterDT.Rows[0]["Notes"].ToString();
        this.lblCreditNumHead.Text = "Credit: " + this.objCreditMasterDT.Rows[0]["CreditNumber"];
        this.lblCreditDate.Text = DateTime.Parse(this.objCreditMasterDT.Rows[0]["CreditDate"].ToString()).ToString("MMMM dd, yyyy");
        this.lblCreditTotalView.Text = Decimal.Round(Decimal.Parse(this.objCreditMasterDT.Rows[0]["CreditTotal"].ToString()), 2).ToString();
        if (this.objCreditMasterDT.Rows[0]["CreditStatus"].ToString().ToLower() == "sent")
          this.objCreditMasterBll.UpdateCreditStatus(int.Parse(this.hfCreditID.Value), "viewed");
        this.lblCreditAmount.Text = Decimal.Parse(this.lblCreditTotalView.Text).ToString();
        this.lblCreditAmount.Text = Decimal.Round(Decimal.Parse(this.lblCreditAmount.Text), 2).ToString();
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
                  string s = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s) / new Decimal(100);
                  Label label1 = new Label()
                  {
                    Text = this.gvTaskView.Rows[index].Cells[4].Text + "(" + s + ")"
                  };
                  Label label2 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label1.Text))
                  {
                    object obj = hashtable[(object) label1.Text];
                    Decimal num = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label1.Text);
                    hashtable.Add((object) label1.Text, (object) num.ToString());
                  }
                  else
                    hashtable.Add((object) label1.Text, (object) label2.Text);
                }
              }
              if (!string.IsNullOrEmpty(text4))
              {
                if (!text4.Contains("&"))
                {
                  this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                  if (this.objTaxMasterDT.Rows.Count > 0)
                  {
                    string s = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                    Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s) / new Decimal(100);
                    Label label1 = new Label()
                    {
                      Text = this.gvTaskView.Rows[index].Cells[5].Text + "(" + s + ")"
                    };
                    Label label2 = new Label()
                    {
                      Text = string.Concat((object) Decimal.Round(d, 2))
                    };
                    if (hashtable.ContainsKey((object) label1.Text))
                    {
                      object obj = hashtable[(object) label1.Text];
                      Decimal num = d + Decimal.Parse(obj.ToString());
                      hashtable.Remove((object) label1.Text);
                      hashtable.Add((object) label1.Text, (object) num.ToString());
                    }
                    else
                      hashtable.Add((object) label1.Text, (object) label2.Text);
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
                  string s = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s) / new Decimal(100);
                  Label label1 = new Label()
                  {
                    Text = this.gvItemView.Rows[index].Cells[4].Text + "(" + s + ")"
                  };
                  Label label2 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label1.Text))
                  {
                    object obj = hashtable[(object) label1.Text];
                    Decimal num = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label1.Text);
                    hashtable.Add((object) label1.Text, (object) num.ToString());
                  }
                  else
                    hashtable.Add((object) label1.Text, (object) label2.Text);
                }
              }
              if (!string.IsNullOrEmpty(text4))
              {
                if (!text4.Contains("&"))
                {
                  this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                  if (this.objTaxMasterDT.Rows.Count > 0)
                  {
                    string s = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                    Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s) / new Decimal(100);
                    Label label1 = new Label()
                    {
                      Text = this.gvItemView.Rows[index].Cells[5].Text + "(" + s + ")"
                    };
                    Label label2 = new Label()
                    {
                      Text = string.Concat((object) Decimal.Round(d, 2))
                    };
                    if (hashtable.ContainsKey((object) label1.Text))
                    {
                      object obj = hashtable[(object) label1.Text];
                      Decimal num = d + Decimal.Parse(obj.ToString());
                      hashtable.Remove((object) label1.Text);
                      hashtable.Add((object) label1.Text, (object) num.ToString());
                    }
                    else
                      hashtable.Add((object) label1.Text, (object) label2.Text);
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
          foreach (string str in (IEnumerable) hashtable.Keys)
          {
            this.divTaxView.Controls.Add((Control) new Label()
            {
              Text = str
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
            if (!string.IsNullOrEmpty(text))
              d1 += Decimal.Parse(text);
          }
        }
        if (this.gvTaskView.Rows.Count > 0)
        {
          for (int index = 0; index < this.gvTaskView.Rows.Count; ++index)
          {
            string text = this.gvTaskView.Rows[index].Cells[6].Text;
            if (!string.IsNullOrEmpty(text))
              d1 += Decimal.Parse(text);
          }
        }
        if (this.gvTaskView.Rows.Count <= 0 && this.gvItemView.Rows.Count <= 0)
          d1 += Decimal.Parse(this.lblCreditAmount.Text);
        this.lblSubTotalView.Text = Decimal.Round(d1, 2).ToString();
        this.lblAddedTaxesView.Text = Decimal.Round(Decimal.Parse(this.lblCreditAmount.Text) - Decimal.Parse(this.lblSubTotalView.Text), 2).ToString();
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + this.objCompanyMasterDT.Rows[0]["CompanyID"];
        this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
        string str1 = string.Empty;
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString()))
          str1 = str1 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString()))
          str1 = str1 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
          if (this.objCityMasterDT.Rows.Count > 0)
            str1 = str1 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
        }
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString()))
          str1 = str1 + this.objCompanyMasterDT.Rows[0]["CompanyZipCode"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
          if (this.objStateMasterDT.Rows.Count > 0)
            str1 = str1 + this.objStateMasterDT.Rows[0]["StateName"] + ",<br />";
        }
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
        {
          this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
          if (this.objCountryMasterDT.Rows.Count > 0)
            str1 = str1 + this.objCountryMasterDT.Rows[0]["CountryName"] + ".<br />";
        }
        this.lblCompanyAddress.Text = str1;
        Label label3 = this.lblCompanyAddress;
        string str2 = label3.Text + (object) "Email: <a href=\"mailto:" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "\">" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "</a><br />";
        label3.Text = str2;
        Label label4 = this.lblCompanyAddress;
        string str3 = label4.Text + (object) "Phone: " + (string) this.objCompanyMasterDT.Rows[0]["CompanyPhone"];
        label4.Text = str3;
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objCreditMasterDT.Rows[0]["ClientId"].ToString()));
        this.lblClientOrganizationName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        this.lblClientFullName.Text = (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
        string str4 = string.Empty + this.objCompanyClientMasterDT.Rows[0]["Address1"] + ",<br />" + this.objCompanyClientMasterDT.Rows[0]["Address2"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()));
          if (this.objCityMasterDT.Rows.Count > 0)
            str4 = str4 + this.objCityMasterDT.Rows[0]["CityName"] + " ";
        }
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()))
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()));
          if (this.objStateMasterDT.Rows.Count > 0)
            str4 = str4 + this.objStateMasterDT.Rows[0]["StateName"] + " ";
        }
        string str5 = string.Concat(new object[4]
        {
          (object) str4,
          (object) " - ",
          this.objCompanyClientMasterDT.Rows[0]["ZipCode"],
          (object) ",<br />"
        });
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()))
        {
          this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()));
          str5 += this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
        }
        this.lblClientAddress.Text = str5;
        switch (this.objCreditMasterDT.Rows[0]["CreditStatus"].ToString())
        {
          case "draft":
            this.divStatus.Attributes.Add("class", "status-draft");
            break;
          case "draft-partial":
            this.divStatus.Attributes.Add("class", "status-draft-partial");
            break;
          case "created":
            this.divStatus.Attributes.Add("class", "status-created");
            break;
          case "sent":
          case "viewed":
            this.divStatus.Attributes.Add("class", "status-received");
            break;
          case "disputed":
            this.divStatus.Attributes.Add("class", "status-disputed");
            break;
          case "paid":
            this.divStatus.Attributes.Add("class", "status-paid");
            break;
          case "partial":
            this.divStatus.Attributes.Add("class", "status-partial");
            break;
          case "pending":
            this.divStatus.Attributes.Add("class", "status-pending");
            break;
          case "declined":
            this.divStatus.Attributes.Add("class", "status-declined");
            break;
          case "auto-paid":
            this.divStatus.Attributes.Add("class", "status-auto-paid");
            break;
          case "retry":
            this.divStatus.Attributes.Add("class", "status-retry");
            break;
          case "failed":
            this.divStatus.Attributes.Add("class", "status-failed");
            break;
          case "replied":
            this.divStatus.Attributes.Add("class", "status-replied");
            break;
          case "commented":
            this.divStatus.Attributes.Add("class", "status-commented");
            break;
          case "resolved":
            this.divStatus.Attributes.Add("class", "status-resolved");
            break;
          case "accepted":
            this.divStatus.Attributes.Add("class", "status-accepted");
            break;
          case "Creditd":
            this.divStatus.Attributes.Add("class", "status-Creditd");
            break;
          case "outstanding":
            this.divStatus.Attributes.Add("class", "status-outstanding");
            break;
          case "open":
            this.divStatus.Attributes.Add("class", "status-open");
            break;
          default:
            this.divStatus.Attributes.Add("class", "status-created");
            break;
        }
        string s1 = this.objCreditMasterDT.Rows[0]["CurrencyID"].ToString();
        if (string.IsNullOrEmpty(s1))
          return;
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s1));
        if (this.objCurrencyMasterDT.Rows.Count <= 0)
          return;
        this.lblCurCodeView1.Text = this.lblCurCodeView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
        this.lblCurSymbolView1.Text = this.lblCurSymbolView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    protected void gvCredit_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvCredit_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvCredit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCredit.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCredit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(e.Row.Cells[2].Text));
        e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      }
      BoundField boundField = ((GridView) sender).Columns[3] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void gvCreditHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      GridView gridView = (GridView) sender;
      BoundField boundField1 = gridView.Columns[2] as BoundField;
      if (boundField1 != null)
        boundField1.DataFormatString = "{0:" + this.dateFormat + "}";
      BoundField boundField2 = gridView.Columns[5] as BoundField;
      if (boundField2 == null)
        return;
      boundField2.DataFormatString = "{0:" + this.dateFormat + "}";
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

    protected string SetStatus(string status)
    {
      if (status.ToLower() == "sent")
        return "received";
      if (status.ToLower() == "viewed")
        return "outstanding";
      return status;
    }
  }
}
