// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.AllInvoice
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using IITS_CloudAccounting.Admin;
using System;
using System.Collections;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Client
{
  public class AllInvoice : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly InvoiceDisputeHistoryBLL objInvoiceDisputeHistoryBll = new InvoiceDisputeHistoryBLL();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly TemplateSettingsBLL objTemplateSettingsBll = new TemplateSettingsBLL();
    private CloudAccountDA.TemplateSettingsDataTable objTemplateSettingsDT = new CloudAccountDA.TemplateSettingsDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
    private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly ItemMasterBLL objItemMasterBll = new ItemMasterBLL();
    private CloudAccountDA.ItemMasterDataTable objItemMasterDT = new CloudAccountDA.ItemMasterDataTable();
    private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
    private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    public string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    protected Panel pnlView;
    protected Label lblInvoiceNumHead;
    protected Button btnDispute;
    protected Button btnForward;
    protected Button btnPayOnline;
    protected HtmlGenericControl forwardDiv;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtFirstName;
    protected TextBox txtLastName;
    protected TextBox txtEmailBody;
    protected Button btnForwardSend;
    protected LinkButton lnkCloseForward;
    protected HtmlGenericControl disputeDiv;
    protected HtmlGenericControl disputeDivLabel;
    protected DataList dlHistory;
    protected SqlDataSource sqldsHistory;
    protected HtmlGenericControl disputeDivText;
    protected TextBox txtDisputeText;
    protected Button btnDisputeSend;
    protected LinkButton lnkCloseDispute;
    protected HtmlGenericControl divStatus;
    protected Label lblCompanyName;
    protected Label lblCompanyAddress;
    protected Image imgLogo;
    protected Label lblCompanyLogoText;
    protected Label lblClientOrganizationName;
    protected Label lblClientFullName;
    protected Label lblClientAddress;
    protected Label lblInvoiceTitle;
    protected Label lblInvoiceNum;
    protected Label lblInvoiceTitleDate;
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
    protected GridView gvInvoiceHistory;
    protected ObjectDataSource objdsPaymentHistory;
    protected Panel pnlViewAll;
    protected GridView gvInvoice;
    protected ObjectDataSource objdsInvoice;
    protected Label lblTotal;
    protected Label lblCurCode;
    protected HiddenField hfClientID;
    protected HiddenField hfInvoiceID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("allInvoice")).Attributes.Add("class", "active open");
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
      this.gvInvoice.PageSize = this.linePerPage;
      this.lblCompanyLogoText.Text = this.objMiscellaneousMasterDT.Rows[0]["TextBelowYourLogo"].ToString();
      this.brandingDiv.Visible = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"];
    }

    protected void gvInvoice_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvInvoice.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    private void BindGrid()
    {
      this.gvInvoice.DataBind();
      this.GetInvoiceTotal();
    }

    private void ViewRecord(string id)
    {
      bool flag = false;
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(id));
      if (this.objInvoiceMasterDT.Rows.Count > 0)
        flag = this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString() == this.hfClientID.Value;
      if (this.objInvoiceMasterDT.Rows.Count > 0 && flag)
      {
        this.hfCompanyID.Value = this.objInvoiceMasterDT.Rows[0]["CompanyID"].ToString();
        this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objTemplateSettingsDT.Rows.Count > 0)
        {
          this.lblInvoiceTitle.Text = (string) this.objTemplateSettingsDT.Rows[0]["InvoiceTitle"] + (object) " #";
          this.lblInvoiceTitleDate.Text = (string) this.objTemplateSettingsDT.Rows[0]["InvoiceTitle"] + (object) " Date";
        }
        this.hfInvoiceID.Value = this.objInvoiceMasterDT.Rows[0]["InvoiceID"].ToString();
        this.dlHistory.DataBind();
        this.disputeDivLabel.Visible = this.dlHistory.Items.Count > 0;
        this.disputeDiv.Visible = this.disputeDivLabel.Visible;
        this.lblInvoiceNum.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"].ToString();
        this.lblTerms.Text = this.objInvoiceMasterDT.Rows[0]["Terms"].ToString();
        this.lblNotes.Text = this.objInvoiceMasterDT.Rows[0]["Notes"].ToString();
        this.lblInvoiceNumHead.Text = "Invoice: " + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"];
        this.lblInvoiceDate.Text = DateTime.Parse(this.objInvoiceMasterDT.Rows[0]["InvoiceDate"].ToString()).ToString("MMMM dd, yyyy");
        this.lblPONumber.Text = this.objInvoiceMasterDT.Rows[0]["PONumber"].ToString();
        string s1 = this.objInvoiceMasterDT.Rows[0]["Discount"].ToString();
        this.lblDiscout.Text = s1.Length > 0 ? s1 : "0.00";
        string str1 = this.objInvoiceMasterDT.Rows[0]["InvoiceStatus"].ToString();
        if (str1.ToLower() == "sent")
          this.objInvoiceMasterBll.UpdateInvoiceStatus("viewed", int.Parse(this.hfInvoiceID.Value));
        this.btnDispute.Visible = str1.ToLower() != "paid";
        this.lblInvoiceTotalView.Text = Decimal.Round(Decimal.Parse(this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString()), 2).ToString();
        //this.lblPaidToDateView.Text = Decimal.Round(Decimal.Parse(this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString()), 2).ToString();
        Label label1 = this.lblInvoiceAmount;
        Label label2 = this.lblAmountDue;
                //Decimal num1 = Decimal.Parse(this.lblInvoiceTotalView.Text) - Decimal.Parse(this.lblPaidToDateView.Text);
                Decimal num1 = Decimal.Parse(this.lblInvoiceTotalView.Text);
        string str2;
        string str3 = str2 = num1.ToString();
        label2.Text = str2;
        string str4 = str3;
        label1.Text = str4;
        Label label3 = this.lblInvoiceAmount;
        Label label4 = this.lblAmountDue;
        Decimal num2 = Decimal.Round(Decimal.Parse(this.lblAmountDue.Text), 2);
        string str5;
        string str6 = str5 = num2.ToString();
        label4.Text = str5;
        string str7 = str6;
        label3.Text = str7;
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
          foreach (string str8 in (IEnumerable) hashtable.Keys)
          {
            this.divTaxView.Controls.Add((Control) new Label()
            {
              Text = str8
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
        this.lblSubTotalView.Text = Decimal.Round(d1, 2).ToString();
        this.lblDiscountAmt.Text = (Decimal.Parse(this.lblSubTotalView.Text) * Decimal.Parse(s1) / new Decimal(100)).ToString();
        this.lblDiscountAmt.Text = Decimal.Round(Decimal.Parse(this.lblDiscountAmt.Text), 2).ToString();
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + this.objCompanyMasterDT.Rows[0]["CompanyID"];
        this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
        string str9 = string.Empty;
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString()))
          str9 = str9 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString()))
          str9 = str9 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
          if (this.objCityMasterDT.Rows.Count > 0)
            str9 = str9 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
        }
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString()))
          str9 = str9 + this.objCompanyMasterDT.Rows[0]["CompanyZipCode"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
          if (this.objStateMasterDT.Rows.Count > 0)
            str9 = str9 + this.objStateMasterDT.Rows[0]["StateName"] + ",<br />";
        }
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
        {
          this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
          if (this.objCountryMasterDT.Rows.Count > 0)
            str9 = str9 + this.objCountryMasterDT.Rows[0]["CountryName"] + ".<br />";
        }
        this.lblCompanyAddress.Text = str9;
        Label label7 = this.lblCompanyAddress;
        string str10 = label7.Text + (object) "Email: <a href=\"mailto:" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "\">" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "</a><br />";
        label7.Text = str10;
        Label label8 = this.lblCompanyAddress;
        string str11 = label8.Text + (object) "Phone: " + (string) this.objCompanyMasterDT.Rows[0]["CompanyPhone"];
        label8.Text = str11;
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientId"].ToString()));
        this.lblClientOrganizationName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        this.lblClientFullName.Text = (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
        string str12 = string.Empty + this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString();
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString()))
          str12 += ",<br />";
        string str13 = str12 + this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString();
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString()))
          str13 += ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()));
          if (this.objCityMasterDT.Rows.Count > 0)
            str13 = str13 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
        }
        string str14 = str13 + this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString();
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString()))
          str14 += ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()))
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()));
          if (this.objStateMasterDT.Rows.Count > 0)
            str14 = str14 + this.objStateMasterDT.Rows[0]["StateName"] + " ";
        }
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()))
        {
          this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()));
          str14 += this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
        }
        this.lblClientAddress.Text = str14;
        switch (this.objInvoiceMasterDT.Rows[0]["InvoiceStatus"].ToString())
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
          case "invoiced":
            this.divStatus.Attributes.Add("class", "status-invoiced");
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
        string s3 = this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString();
        if (!string.IsNullOrEmpty(s3))
        {
          this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s3));
          if (this.objCurrencyMasterDT.Rows.Count > 0)
          {
            this.lblCurCodeView1.Text = this.lblCurCodeView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
            this.lblCurSymbolView1.Text = this.lblCurSymbolView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
          }
        }
        this.btnPayOnline.Visible = Decimal.Parse(this.lblAmountDue.Text) != new Decimal(0);
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void GetInvoiceTotal()
    {
      if (this.gvInvoice.Rows.Count > 0)
      {
        Decimal d = new Decimal(0);
        for (int index = 0; index < this.gvInvoice.Rows.Count; ++index)
        {
          string text = this.gvInvoice.Rows[index].Cells[3].Text;
          if (!string.IsNullOrEmpty(text))
            d += Decimal.Parse(text);
        }
        this.lblTotal.Text = Decimal.Round(d, 2).ToString();
      }
      else
        this.lblTotal.Text = "0.00";
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.hfClientID.Value));
      string s = this.objCompanyClientMasterDT.Rows[0]["CurrencyID"].ToString();
      if (!string.IsNullOrEmpty(s))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s));
        if (this.objCurrencyMasterDT.Rows.Count <= 0)
          return;
        this.lblCurCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      }
      else
        this.lblCurCode.Text = "NGN";
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

    protected void gvInvoice_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      BoundField boundField = ((GridView) sender).Columns[2] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void gvInvoiceHistory_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      BoundField boundField = ((GridView) sender).Columns[3] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void lnkCloseForward_OnClick(object sender, EventArgs e)
    {
      this.txtEmailBody.Text = this.txtEmail.Text = this.txtFirstName.Text = this.txtLastName.Text = "";
      this.forwardDiv.Visible = false;
      this.txtEmailBody.Text = this.lblClientFullName.Text + " has forwarded you an invoice.  To view it online, click here:\n\n##invoiceLink##";
    }

    protected void btnForward_OnClick(object sender, EventArgs e)
    {
      this.txtEmailBody.Text = this.txtEmail.Text = this.txtFirstName.Text = this.txtLastName.Text = "";
      this.forwardDiv.Visible = true;
      this.txtEmailBody.Text = this.lblClientFullName.Text + " has forwarded you an invoice.  To view it online, click here:\n\n##invoiceLink##\n";
    }

    protected void btnForwardSend_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      string sUserName;
      MembershipCreateStatus status;
      do
      {
        sUserName = Doyingo.GenerateCode(6);
        string password = Doyingo.GenerateCode(8);
        Membership.CreateUser(sUserName.Trim(), password, this.txtEmail.Text.Trim(), "What is your email?", this.txtEmail.Text.Trim(), true, out status);
      }
      while (status != MembershipCreateStatus.Success);
      if (Roles.IsUserInRole(sUserName.Trim(), "CompanyClient"))
        return;
      Roles.AddUserToRole(sUserName.Trim(), "CompanyClient");
      this.SendMail(int.Parse(this.hfInvoiceID.Value), this.objCompanyClientContactDetailBll.AddCompanyClientContact(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfClientID.Value), this.txtEmail.Text.Trim(), this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), "", "", true, sUserName, false));
      this.txtEmailBody.Text = this.txtEmail.Text = this.txtFirstName.Text = this.txtLastName.Text = "";
      this.forwardDiv.Visible = false;
      this.txtEmailBody.Text = this.lblClientFullName.Text + " has forwarded you an invoice.  To view it online, click here:\n\n##invoiceLink##";
    }

    private void SendMail(int invoiceId, int contactId)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(invoiceId);
      string s = this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString();
      string str1 = string.Empty;
      string addresses = string.Empty;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(s));
      if (this.objCompanyClientMasterDT.Rows.Count > 0)
        addresses = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientContactID(contactId);
      if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        MembershipUser user = Membership.GetUser(this.objCompanyClientContactDetailDT.Rows[0]["UserName"].ToString());
        if (user != null)
        {
          string key1 = Doyingo.GenerateCode();
          string str2 = HttpUtility.UrlEncode(this.Encrypt(user.UserName, key1));
          string password = user.GetPassword();
          string key2 = Doyingo.GenerateCode();
          string str3 = HttpUtility.UrlEncode(this.Encrypt(password, key2));
          str1 = string.Format("http://www.billtransact.com/CheckClient.aspx?page=invoice&anyId={0}&name={1}&tech={2}&keyname={3}&keytech={4}", (object) invoiceId, (object) str2, (object) str3, (object) key1, (object) key2);
        }
      }
      string str4 = this.txtEmailBody.Text.Replace("\n", "<br />");
      string address = "noreply@DoyniGo.com";
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
        address = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
      Hashtable Variables = new Hashtable()
      {
        {
          (object) "template",
          (object) str4
        },
        {
          (object) "invoiceLink",
          (object) str1
        }
      };
      Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/ForwardedInvoice.html"), Variables);
      string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
      File.WriteAllText(Path.Combine(path1, "Invoice.html"), parser1.Parse());
      Parser parser2 = new Parser(path1 + "Invoice.html", Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress(address, "DoyinGo")
        };
        message.To.Add(new MailAddress(this.txtEmail.Text.Trim()));
        message.ReplyToList.Add(addresses);
        message.Subject = "I'm forwarding you an invoice from " + this.lblCompanyName.Text.ToUpper();
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser2.Parse();
        message.IsBodyHtml = true;
        SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
        File.Delete(Path.Combine(path1, "Invoice.html"));
      }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
      }
    }

    private string Encrypt(string clearText, string key)
    {
      string password = key;
      byte[] bytes = Encoding.Unicode.GetBytes(clearText);
      using (Aes aes = Aes.Create())
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
        {
          (byte) 73,
          (byte) 118,
          (byte) 97,
          (byte) 110,
          (byte) 32,
          (byte) 77,
          (byte) 101,
          (byte) 100,
          (byte) 118,
          (byte) 101,
          (byte) 100,
          (byte) 101,
          (byte) 118
        });
        if (aes != null)
        {
          aes.Key = rfc2898DeriveBytes.GetBytes(32);
          aes.IV = rfc2898DeriveBytes.GetBytes(16);
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
              cryptoStream.Write(bytes, 0, bytes.Length);
              cryptoStream.Close();
            }
            clearText = Convert.ToBase64String(memoryStream.ToArray());
          }
        }
      }
      return clearText;
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void txtEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmail.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        if (!(this.hfCompanyID.Value == this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString()))
          return;
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System As Your Company.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else if (this.objStaffMasterDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else if (this.objContractorMasterDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else
        this.txtFirstName.Focus();
    }

    protected void lnkCloseDispute_OnClick(object sender, EventArgs e)
    {
      this.disputeDiv.Visible = true;
      this.txtDisputeText.Text = "";
      this.disputeDivText.Visible = false;
      this.disputeDivLabel.Visible = true;
      this.dlHistory.DataBind();
      this.disputeDivLabel.Visible = this.dlHistory.Items.Count > 0;
      this.disputeDiv.Visible = this.disputeDivLabel.Visible;
    }

    protected void btnDispute_OnClick(object sender, EventArgs e)
    {
      this.txtDisputeText.Text = "";
      this.disputeDiv.Visible = true;
      this.disputeDivText.Visible = true;
      this.disputeDivLabel.Visible = true;
      this.disputeDiv.Visible = this.disputeDivText.Visible || this.disputeDivLabel.Visible;
      this.txtDisputeText.Focus();
    }

    protected void btnDisputeSend_OnClick(object sender, EventArgs e)
    {
      if (this.txtDisputeText.Text.Trim().Length > 0)
      {
        if (!string.IsNullOrEmpty(this.hfClientContactID.Value))
          this.objInvoiceDisputeHistoryBll.AddInvoiceDisputeHistory(int.Parse(this.hfInvoiceID.Value), "CompanyClientContact", int.Parse(this.hfClientContactID.Value), this.txtDisputeText.Text.Trim());
        else
          this.objInvoiceDisputeHistoryBll.AddInvoiceDisputeHistory(int.Parse(this.hfInvoiceID.Value), "CompanyClient", int.Parse(this.hfClientID.Value), this.txtDisputeText.Text.Trim());
        this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(this.hfInvoiceID.Value));
        string str = this.objInvoiceMasterDT.Rows[0]["InvoiceStatus"].ToString();
        if (str.ToLower().Contains("sent") || str.ToLower().Contains("draft") || str.ToLower().Contains("viewed"))
          this.objInvoiceMasterBll.UpdateInvoiceStatus("disputed", int.Parse(this.hfInvoiceID.Value));
        this.Response.Redirect("AllInvoice.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
      }
      else
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('You must provide a reason.')", true);
        this.txtDisputeText.Focus();
      }
    }

    protected string SetName(string id, string role)
    {
      switch (role)
      {
        case "Company":
          this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(id));
          return this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
        case "CompanyClientContact":
          this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientContactID(int.Parse(id));
          return (string) this.objCompanyClientContactDetailDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientContactDetailDT.Rows[0]["LastName"];
        case "CompanyClient":
          this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(id));
          return (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
        default:
          return string.Empty;
      }
    }

    protected void btnPayOnline_Click(object sender, EventArgs e)
    {
      string key = Doyingo.GenerateCode(5);
      this.Response.Redirect("InvoicePayment.aspx?invoice=" + HttpUtility.UrlEncode(this.Encrypt(this.hfInvoiceID.Value, key)) + "&val=" + key);
    }
  }
}
