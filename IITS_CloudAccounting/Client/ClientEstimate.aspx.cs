// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.ClientEstimate
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
  public class ClientEstimate : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly EstimateDisputeHistoryBLL objEstimateDisputeHistoryBll = new EstimateDisputeHistoryBLL();
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
    private readonly EstimateMasterBLL objEstimateMasterBll = new EstimateMasterBLL();
    private CloudAccountDA.EstimateMasterDataTable objEstimateMasterDT = new CloudAccountDA.EstimateMasterDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    public string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    protected Panel pnlView;
    protected Label lblEstimateNumHead;
    protected Button btnDispute;
    protected Button btnAccept;
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
    protected Label lblEstimateTitle;
    protected Label lblEstimateNum;
    protected Label lblEstimateTitleDate;
    protected Label lblEstimateDate;
    protected Label lblPONumber;
    protected Label lblCurSymbolView1;
    protected Label lblEstimateAmount;
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
    protected Label lblEstimateTotalView;
    protected Label lblPaidToDateView;
    protected Label lblCurSymbolView2;
    protected Label lblAmountDue;
    protected Label lblCurCodeView2;
    protected Label lblTerms;
    protected Label lblNotes;
    protected HtmlGenericControl brandingDiv;
    protected Panel pnlViewAll;
    protected GridView gvEstimate;
    protected Label lblTotal;
    protected Label lblCurCode;
    protected ObjectDataSource objdsEstimate;
    protected HiddenField hfCompanyID;
    protected HiddenField hfEstimateID;
    protected HiddenField hfClientID;
    protected HiddenField hfClientContactID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("Estimate")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("newEstimate")).Attributes.Add("class", "active open");
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
      this.gvEstimate.PageSize = this.linePerPage;
      this.lblCompanyLogoText.Text = this.objMiscellaneousMasterDT.Rows[0]["TextBelowYourLogo"].ToString();
      this.brandingDiv.Visible = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"];
    }

    private void BindGrid()
    {
      this.gvEstimate.DataBind();
      this.GetEstimateTotal();
    }

    private void ViewRecord(string id)
    {
      bool flag = false;
      this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(int.Parse(id));
      if (this.objEstimateMasterDT.Rows.Count > 0)
        flag = this.objEstimateMasterDT.Rows[0]["ClientID"].ToString() == this.hfClientID.Value;
      if (this.objEstimateMasterDT.Rows.Count > 0 && flag)
      {
        this.hfCompanyID.Value = this.objEstimateMasterDT.Rows[0]["CompanyID"].ToString();
        this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objTemplateSettingsDT.Rows.Count > 0)
        {
          this.lblEstimateTitle.Text = (string) this.objTemplateSettingsDT.Rows[0]["EstimateTitle"] + (object) " #";
          this.lblEstimateTitleDate.Text = (string) this.objTemplateSettingsDT.Rows[0]["EstimateTitle"] + (object) " Date";
        }
        this.hfEstimateID.Value = this.objEstimateMasterDT.Rows[0]["EstimateID"].ToString();
        this.lblEstimateNum.Text = this.objEstimateMasterDT.Rows[0]["EstimateNumber"].ToString();
        this.lblEstimateNumHead.Text = "Estimate: " + this.objEstimateMasterDT.Rows[0]["EstimateNumber"];
        this.lblEstimateDate.Text = DateTime.Parse(this.objEstimateMasterDT.Rows[0]["EstimateDate"].ToString()).ToString("MMMM dd, yyyy");
        this.lblPONumber.Text = this.objEstimateMasterDT.Rows[0]["PONumber"].ToString();
        this.lblTerms.Text = this.objEstimateMasterDT.Rows[0]["Terms"].ToString();
        this.lblNotes.Text = this.objEstimateMasterDT.Rows[0]["Notes"].ToString();
        string s1 = this.objEstimateMasterDT.Rows[0]["Discount"].ToString();
        this.lblDiscout.Text = s1.Length > 0 ? s1 : "0.00";
        this.lblEstimateTotalView.Text = Decimal.Round(Decimal.Parse(this.objEstimateMasterDT.Rows[0]["EstimateTotal"].ToString()), 2).ToString();
        this.lblPaidToDateView.Text = Decimal.Round(Decimal.Parse(this.objEstimateMasterDT.Rows[0]["PaidToDate"].ToString()), 2).ToString();
        Label label1 = this.lblEstimateAmount;
        Label label2 = this.lblAmountDue;
        Decimal num1 = Decimal.Parse(this.lblEstimateTotalView.Text) - Decimal.Parse(this.lblPaidToDateView.Text);
        string str1;
        string str2 = str1 = num1.ToString();
        label2.Text = str1;
        string str3 = str2;
        label1.Text = str3;
        Label label3 = this.lblEstimateAmount;
        Label label4 = this.lblAmountDue;
        Decimal num2 = Decimal.Round(Decimal.Parse(this.lblAmountDue.Text), 2);
        string str4;
        string str5 = str4 = num2.ToString();
        label4.Text = str4;
        string str6 = str5;
        label3.Text = str6;
        string str7 = this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString();
        if (str7.ToLower() == "sent")
          this.objEstimateMasterBll.UpdateEstimateStatus("viewed", int.Parse(this.hfEstimateID.Value));
        this.dlHistory.DataBind();
        this.disputeDivLabel.Visible = this.dlHistory.Items.Count > 0;
        this.disputeDiv.Visible = this.disputeDivLabel.Visible;
        this.btnAccept.Visible = str7.ToLower() != "accepted";
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
        this.lblAddedTaxesView.Text = Decimal.Round(Decimal.Parse(this.lblEstimateAmount.Text) - Decimal.Parse(this.lblSubTotalView.Text) + Decimal.Parse(this.lblDiscountAmt.Text), 2).ToString();
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
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objEstimateMasterDT.Rows[0]["ClientId"].ToString()));
        this.lblClientOrganizationName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        this.lblClientFullName.Text = (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
        string str12 = string.Empty + this.objCompanyClientMasterDT.Rows[0]["Address1"] + ",<br />" + this.objCompanyClientMasterDT.Rows[0]["Address2"] + ",<br />";
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()));
          if (this.objCityMasterDT.Rows.Count > 0)
            str12 = str12 + this.objCityMasterDT.Rows[0]["CityName"] + " ";
        }
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()))
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()));
          if (this.objStateMasterDT.Rows.Count > 0)
            str12 = str12 + this.objStateMasterDT.Rows[0]["StateName"] + " ";
        }
        string str13 = string.Concat(new object[4]
        {
          (object) str12,
          (object) " - ",
          this.objCompanyClientMasterDT.Rows[0]["ZipCode"],
          (object) ",<br />"
        });
        if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()))
        {
          this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()));
          str13 += this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
        }
        this.lblClientAddress.Text = str13;
        switch (this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString())
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
            this.divStatus.Attributes.Add("class", "status-received");
            break;
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
          case "invoiced":
            this.divStatus.Attributes.Add("class", "status-invoiced");
            break;
          case "accepted":
            this.divStatus.Attributes.Add("class", "status-accepted");
            break;
          case "Estimated":
            this.divStatus.Attributes.Add("class", "status-Estimated");
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
        string s3 = this.objEstimateMasterDT.Rows[0]["CurrencyID"].ToString();
        if (string.IsNullOrEmpty(s3))
          return;
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s3));
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

    protected void gvEstimate_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvEstimate_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvEstimate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvEstimate.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    private void GetEstimateTotal()
    {
      if (this.gvEstimate.Rows.Count > 0)
      {
        Decimal d = new Decimal(0);
        for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
        {
          string text = this.gvEstimate.Rows[index].Cells[3].Text;
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

    protected void gvEstimate_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      BoundField boundField = ((GridView) sender).Columns[2] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected string SetStatus(string status)
    {
      if (status.ToLower() == "sent" || status.ToLower() == "viewed")
        return "received";
      return status;
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.hfEstimateID.Value))
      {
        this.objEstimateMasterBll.UpdateEstimateStatus("accepted", int.Parse(this.hfEstimateID.Value));
        this.Response.Redirect("ClientEstimate.aspx?cmd=view&ID=" + this.hfEstimateID.Value);
      }
      else
        this.Response.Redirect("ClientEstimate.aspx");
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
          this.objEstimateDisputeHistoryBll.AddEstimateDisputeHistory(int.Parse(this.hfEstimateID.Value), "CompanyClientContact", int.Parse(this.hfClientContactID.Value), this.txtDisputeText.Text.Trim());
        else
          this.objEstimateDisputeHistoryBll.AddEstimateDisputeHistory(int.Parse(this.hfEstimateID.Value), "CompanyClient", int.Parse(this.hfClientID.Value), this.txtDisputeText.Text.Trim());
        this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(int.Parse(this.hfEstimateID.Value));
        string str = this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString();
        if (str.ToLower().Contains("sent") || str.ToLower().Contains("draft") || str.ToLower().Contains("viewed"))
          this.objEstimateMasterBll.UpdateEstimateStatus("replied", int.Parse(this.hfEstimateID.Value));
        this.Response.Redirect("ClientEstimate.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
  }
}
