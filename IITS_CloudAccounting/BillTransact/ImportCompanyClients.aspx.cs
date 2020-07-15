// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ImportCompanyClients
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;
using Thought.vCards;

namespace IITS_CloudAccounting.Admin
{
  public class ImportCompanyClients : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
    private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    protected HtmlGenericControl divError;
    protected Label lblError;
    protected Panel pnlCsv;
    protected MultiView mvCsv;
    protected View csvFile;
    protected LinkButton lnkDownload;
    protected FileUpload fuCsv;
    protected Button btnUploadCsv;
    protected View csvGrid;
    protected GridView gvCsvClient;
    protected Button btnUploadCsvClient;
    protected Button btnCancelCsv;
    protected Panel pnlvCard;
    protected MultiView mvvCard;
    protected View vCardFile;
    protected FileUpload fuvCard;
    protected Button btnUploadvCard;
    protected View vCardGrid;
    protected Label lblOrganization;
    protected Label lblName;
    protected Label lblEmail;
    protected CheckBox chkImport;
    protected HiddenField hfMobile;
    protected HiddenField hfHome;
    protected HiddenField hfWork;
    protected Button btnUploadvCardClient;
    protected Button btnCancelvCard;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyName;
    protected HiddenField hfStaffID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("account")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("importExport")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
              this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
              this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            }
          }
        }
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
              this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
              this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            }
          }
        }
      }
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["format"] != null)
      {
        switch (this.Request.QueryString["format"])
        {
          case "csv":
            this.pnlCsv.Visible = true;
            this.pnlvCard.Visible = false;
            this.mvCsv.SetActiveView(this.csvFile);
            break;
          case "vcard":
            this.pnlCsv.Visible = false;
            this.pnlvCard.Visible = true;
            this.mvvCard.SetActiveView(this.vCardFile);
            break;
          default:
            this.pnlCsv.Visible = false;
            this.pnlvCard.Visible = false;
            this.Response.Redirect("ImportCompanyClients.aspx?format=csv");
            break;
        }
      }
      else
      {
        this.pnlCsv.Visible = false;
        this.pnlvCard.Visible = false;
        this.Response.Redirect("ImportCompanyClients.aspx?format=csv");
      }
    }

    protected void btnUploadCsv_OnClick(object sender, EventArgs e)
    {
      this.lblError.Text = "";
      this.divError.Visible = false;
      if (this.fuCsv.HasFile)
      {
        string fileName = Path.GetFileName(this.fuCsv.FileName);
        if (fileName != null && fileName.Contains(".csv"))
        {
          DataTable csvdt = new DataTable();
          this.fuCsv.SaveAs(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          string str1 = File.ReadAllText(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          int num = 0;
          string str2 = str1;
          char[] chArray1 = new char[1]
          {
            '\n'
          };
          foreach (string str3 in str2.Split(chArray1))
          {
            if (!string.IsNullOrEmpty(str3) && num == 0)
            {
              string str4 = str3;
              char[] chArray2 = new char[1]
              {
                ','
              };
              foreach (string str5 in str4.Split(chArray2))
                csvdt.Columns.Add(str5.Replace("\r", ""));
            }
            bool flag = csvdt.Columns.Contains("organization");
            if (csvdt.Columns.Contains("email") && flag)
            {
              if (!string.IsNullOrEmpty(str3) && num != 0)
              {
                csvdt.Rows.Add();
                int index = 0;
                string str4 = str3;
                char[] chArray2 = new char[1]
                {
                  ','
                };
                foreach (string str5 in str4.Split(chArray2))
                {
                  csvdt.Rows[csvdt.Rows.Count - 1][index] = (object) str5;
                  ++index;
                }
              }
              ++num;
            }
            else
            {
              this.divError.Visible = true;
              this.lblError.Text = "The CSV file is invalid. OR file is not CSV";
              break;
            }
          }
          this.Bindgrid(csvdt);
          File.Delete(this.Server.MapPath("~/UploadCSVFile/") + fileName);
        }
        else
        {
          this.divError.Visible = true;
          this.lblError.Text = "The CSV file is invalid. OR file is not CSV";
        }
      }
      else
      {
        this.divError.Visible = true;
        this.lblError.Text = "No File Selected. Please Select CSV file.";
      }
    }

    private void Bindgrid(DataTable csvdt)
    {
      this.gvCsvClient.DataSource = (object) csvdt;
      this.gvCsvClient.DataBind();
      if (this.gvCsvClient.Rows.Count > 0)
      {
        this.mvCsv.SetActiveView(this.csvGrid);
      }
      else
      {
        this.btnUploadCsvClient.Visible = false;
        this.divError.Visible = true;
        this.lblError.Text = "No records found in file. Please select other file.";
      }
    }

    protected void btnUploadCsvClient_OnClick(object sender, EventArgs e)
    {
      if (this.gvCsvClient.Rows.Count <= 0)
        return;
      int num = 0;
      for (int index = 0; index < this.gvCsvClient.Rows.Count; ++index)
      {
        string text1 = this.gvCsvClient.Rows[index].Cells[1].Text;
        string text2 = this.gvCsvClient.Rows[index].Cells[3].Text;
        CheckBox checkBox = (CheckBox) this.gvCsvClient.Rows[index].FindControl("chk");
        Label label1 = (Label) this.gvCsvClient.Rows[index].FindControl("lblFirstName");
        Label label2 = (Label) this.gvCsvClient.Rows[index].FindControl("lblLastName");
        HiddenField hiddenField1 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfStreet");
        HiddenField hiddenField2 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfStreet2");
        HiddenField hiddenField3 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfSecStreet");
        HiddenField hiddenField4 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfSecStreet2");
        HiddenField hiddenField5 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfBusPhone");
        HiddenField hiddenField6 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfHomePhone");
        HiddenField hiddenField7 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfMobPhone");
        HiddenField hiddenField8 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfFax");
        HiddenField hiddenField9 = (HiddenField) this.gvCsvClient.Rows[index].FindControl("hfNotes");
        if (!string.IsNullOrEmpty(text1) && !string.IsNullOrEmpty(text2) && (checkBox.Checked && !this.CheckEmail(text2)))
        {
          string str1;
          string str2;
          MembershipCreateStatus status;
          do
          {
            str1 = Doyingo.GenerateCode(6);
            str2 = Doyingo.GenerateCode(8);
            Membership.CreateUser(str1.Trim(), str2, text2, "What's Your Email?", text2, true, out status);
          }
          while (status != MembershipCreateStatus.Success);
          Roles.AddUserToRole(str1.Trim(), "CompanyClient");
          this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
          int? iCurrencyID = new int?();
          if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()))
            iCurrencyID = new int?(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()));
          if (this.objCompanyClientMasterBll.AddCompanyClient(int.Parse(this.hfCompanyID.Value), text1, iCurrencyID, true, false, text2, label1.Text, label2.Text, hiddenField6.Value.Trim(), hiddenField7.Value.Trim(), true, str1.Trim(), hiddenField1.Value, hiddenField2.Value, new int?(), new int?(), new int?(), "", hiddenField3.Value, hiddenField4.Value, new int?(), new int?(), new int?(), "", new int?(), "[choose one]", hiddenField5.Value.Trim(), hiddenField8.Value, hiddenField9.Value, true, false, false) != 0)
          {
            ++num;
            this.SendMail(str1.Trim(), str2, this.lblEmail.Text);
          }
        }
      }
      this.Session["importClient"] = (object) num;
      this.Response.Redirect("~/Admin/CompanyClientMaster.aspx");
    }

    protected void btnCancelCsv_OnClick(object sender, EventArgs e)
    {
      this.mvCsv.SetActiveView(this.csvFile);
    }

    protected void btnUploadvCard_OnClick(object sender, EventArgs e)
    {
      this.lblError.Text = "";
      this.divError.Visible = false;
      if (this.fuvCard.HasFile)
      {
        string fileName = Path.GetFileName(this.fuvCard.FileName);
        if (fileName != null && fileName.Contains(".vcf"))
        {
          this.fuvCard.SaveAs(this.Server.MapPath("~/UploadvCardFile/") + fileName);
          vCard vCard = new vCard(this.Server.MapPath("~/UploadvCardFile/") + fileName);
          this.lblName.Text = vCard.FormattedName;
          this.lblOrganization.Text = vCard.Organization;
          if (vCard.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet) != null)
            this.lblEmail.Text = vCard.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet).Address;
          if (vCard.Phones.GetFirstChoice(vCardPhoneTypes.Cellular) != null)
            this.hfMobile.Value = vCard.Phones.GetFirstChoice(vCardPhoneTypes.Cellular).FullNumber;
          if (vCard.Phones.GetFirstChoice(vCardPhoneTypes.Home) != null)
            this.hfHome.Value = vCard.Phones.GetFirstChoice(vCardPhoneTypes.Home).FullNumber;
          if (vCard.Phones.GetFirstChoice(vCardPhoneTypes.Work) != null)
            this.hfWork.Value = vCard.Phones.GetFirstChoice(vCardPhoneTypes.Work).FullNumber;
          File.Delete(this.Server.MapPath("~/UploadvCardFile/") + fileName);
          if (!this.CheckEmail(this.lblEmail.Text))
          {
            if (!string.IsNullOrEmpty(this.lblOrganization.Text) && !string.IsNullOrEmpty(this.lblEmail.Text))
            {
              this.mvvCard.SetActiveView(this.vCardGrid);
            }
            else
            {
              this.divError.Visible = true;
              this.lblError.Text = "No records found in file. Please select other file.";
            }
          }
          else
          {
            this.divError.Visible = true;
            this.lblError.Text = "This Client Cant Be Imported. Because his/her Email is Register In System.";
          }
        }
        else
        {
          this.divError.Visible = true;
          this.lblError.Text = "The vCard file is invalid. OR file is not vCard";
        }
      }
      else
      {
        this.divError.Visible = true;
        this.lblError.Text = "No File Selected. Please Select vCard file.";
      }
    }

    protected void btnUploadvCardClient_OnClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.lblOrganization.Text) && !string.IsNullOrEmpty(this.lblEmail.Text) && (this.chkImport.Checked && !this.CheckEmail(this.lblEmail.Text)))
      {
        string str1;
        string str2;
        MembershipCreateStatus status;
        do
        {
          str1 = Doyingo.GenerateCode(6);
          str2 = Doyingo.GenerateCode(8);
          Membership.CreateUser(str1.Trim(), str2, this.lblEmail.Text, "What's Your Email?", this.lblEmail.Text, true, out status);
        }
        while (status != MembershipCreateStatus.Success);
        Roles.AddUserToRole(str1.Trim(), "CompanyClient");
        string sOrganizationName = this.lblOrganization.Text.Trim();
        if (string.IsNullOrEmpty(sOrganizationName))
          sOrganizationName = this.lblEmail.Text.Trim();
        string[] strArray = this.lblName.Text.Split(' ');
        string sLastName = "";
        string sFirstName = "";
        if (strArray.Length >= 0)
          sFirstName = strArray[0];
        if (strArray.Length >= 1)
          sLastName = strArray[1];
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        int? iCurrencyID = new int?();
        if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()))
          iCurrencyID = new int?(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()));
        if (this.objCompanyClientMasterBll.AddCompanyClient(int.Parse(this.hfCompanyID.Value), sOrganizationName, iCurrencyID, true, false, this.lblEmail.Text, sFirstName, sLastName, this.hfHome.Value.Trim(), this.hfMobile.Value.Trim(), true, str1.Trim(), "", "", new int?(), new int?(), new int?(), "", "", "", new int?(), new int?(), new int?(), "", new int?(), "[choose one]", this.hfWork.Value.Trim(), "", "Imported from vCard", true, false, false) == 0)
          return;
        this.SendMail(str1.Trim(), str2, this.lblEmail.Text);
        this.Session["importClient"] = (object) 1;
        this.Response.Redirect("~/Admin/CompanyClientMaster.aspx");
      }
      else
      {
        this.mvvCard.SetActiveView(this.vCardFile);
        this.divError.Visible = true;
        this.lblError.Text = "Some Error Occured. So Cant Import Your Client.";
      }
    }

    private void SendMail(string user, string pass, string email)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      string str = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      Hashtable Variables = new Hashtable()
      {
        {
          (object) "company",
          (object) str
        },
        {
          (object) "companyEmail",
          (object) addresses
        },
        {
          (object) "username",
          (object) user
        },
        {
          (object) "password",
          (object) pass
        }
      };
      string address = "noreply@DoyniGo.com";
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
        address = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/CompanyClient.htm"), Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress(address, str.ToUpper())
        };
        message.To.Add(new MailAddress(email));
        message.ReplyToList.Add(addresses);
        message.Subject = str.ToUpper() + " is now invoicing you with Bill Transact";
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser.Parse();
        message.IsBodyHtml = true;
        SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
      }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
      }
    }

    private bool CheckEmail(string email)
    {
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), email.Trim());
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), email.Trim());
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), email.Trim());
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), email.Trim());
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(email.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
        return this.hfCompanyID.Value == this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString() ? true : true;
      return this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0 || (this.objStaffMasterDT.Rows.Count > 0 || this.objContractorMasterDT.Rows.Count > 0);
    }

    protected void btnCancelvCard_OnClick(object sender, EventArgs e)
    {
      this.mvvCard.SetActiveView(this.vCardFile);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void gvCsvClient_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      Label label1 = (Label) e.Row.FindControl("lblFirstName");
      Label label2 = (Label) e.Row.FindControl("lblLastName");
      HiddenField hiddenField1 = (HiddenField) e.Row.FindControl("hfStreet");
      HiddenField hiddenField2 = (HiddenField) e.Row.FindControl("hfStreet2");
      HiddenField hiddenField3 = (HiddenField) e.Row.FindControl("hfSecStreet");
      HiddenField hiddenField4 = (HiddenField) e.Row.FindControl("hfSecStreet2");
      HiddenField hiddenField5 = (HiddenField) e.Row.FindControl("hfBusPhone");
      HiddenField hiddenField6 = (HiddenField) e.Row.FindControl("hfHomePhone");
      HiddenField hiddenField7 = (HiddenField) e.Row.FindControl("hfMobPhone");
      HiddenField hiddenField8 = (HiddenField) e.Row.FindControl("hfFax");
      HiddenField hiddenField9 = (HiddenField) e.Row.FindControl("hfNotes");
      DataRowView dataRowView = (DataRowView) e.Row.DataItem;
      string columnNameToCheck = "FirstName";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        label1.Text = DataBinder.Eval(e.Row.DataItem, "FirstName").ToString();
      columnNameToCheck = "LastName";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        label2.Text = " " + DataBinder.Eval(e.Row.DataItem, "LastName");
      columnNameToCheck = "Street";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField1.Value = DataBinder.Eval(e.Row.DataItem, "Street").ToString();
      columnNameToCheck = "Street2";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField2.Value = DataBinder.Eval(e.Row.DataItem, "Street2").ToString();
      columnNameToCheck = "SecStreet";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField3.Value = DataBinder.Eval(e.Row.DataItem, "SecStreet").ToString();
      columnNameToCheck = "SecStreet2";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField4.Value = DataBinder.Eval(e.Row.DataItem, "SecStreet2").ToString();
      columnNameToCheck = "BusPhone";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField5.Value = DataBinder.Eval(e.Row.DataItem, "BusPhone").ToString();
      columnNameToCheck = "HomePhone";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField6.Value = DataBinder.Eval(e.Row.DataItem, "HomePhone").ToString();
      columnNameToCheck = "MobPhone";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField7.Value = DataBinder.Eval(e.Row.DataItem, "MobPhone").ToString();
      columnNameToCheck = "Fax";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        hiddenField8.Value = DataBinder.Eval(e.Row.DataItem, "Fax").ToString();
      columnNameToCheck = "Notes";
      if (!Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        return;
      hiddenField9.Value = DataBinder.Eval(e.Row.DataItem, "Notes").ToString();
    }

    protected void lnkDownload_OnClick(object sender, EventArgs e)
    {
      this.Response.ContentType = "application/text";
      this.Response.AppendHeader("Content-Disposition", "attachment; filename=" + this.hfCompanyName.Value + "_SampleClients.csv");
      this.Response.TransmitFile(this.Server.MapPath("~/SampleFile/SampleClients.csv"));
      this.Response.End();
    }
  }
}
