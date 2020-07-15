// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ExpensesReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class ExpensesReport : Page
    {
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        public string dateFormat = "dd/MMM/yyyy";
        protected ToolkitScriptManager tsm;
        protected TextBox txtDateFrom;
        protected CalendarExtender ceDateFrom;
        protected TextBox txtDateTo;
        protected CalendarExtender ceDateTo;
        protected DropDownList ddlCategory;
        protected SqlDataSource sqldsCategory;
        protected Button btnUpdate;
        protected Image imgLogo;
        protected Label lblCompanyName;
        protected Label lblInfo;
        protected GridView gvExpense;
        protected ObjectDataSource objdsExpense;
        protected HiddenField hfCompanyID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("reports")).Attributes.Add("class", "active open");
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
                        this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
                    }
                }
                else if (Roles.IsUserInRole(str, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                    {
                        this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                        this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
                    }
                }
                this.SetMiscValues(this.hfCompanyID.Value);
            }
            if (this.IsPostBack)
                return;
            DateTime dateTime = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime now = DateTime.Now;
            this.txtDateFrom.Text = dateTime.ToString(this.dateFormat);
            this.txtDateTo.Text = now.ToString(this.dateFormat);
            this.BindGrid();
        }

        private void SetMiscValues(string companyId)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
            this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyId));
            if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
                return;
            if (string.IsNullOrEmpty(this.txtDateFrom.Text.Trim()) || string.IsNullOrEmpty(this.txtDateTo.Text.Trim()))
            {
                DateTime dateTime = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime now = DateTime.Now;
                this.txtDateFrom.Text = dateTime.ToString(this.dateFormat);
                this.txtDateTo.Text = now.ToString(this.dateFormat);
            }
            string[] formats = new string[7]
            {
        this.dateFormat,
        "MM/dd/yy",
        "MM/dd/yyyy",
        "dd/MM/yy",
        "dd/MM/yyyy",
        "yy-MM-dd",
        "yyyy-MM-dd"
            };
            //this.lblInfo.Text = "Between " + DateTime.ParseExact(this.txtDateFrom.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy") + " and " + DateTime.ParseExact(this.txtDateTo.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy");

            this.lblInfo.Text = "Between " + txtDateFrom.Text + " and " + txtDateTo.Text;
        }

        private void BindGrid()
        {
            this.gvExpense.DataBind();
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}
