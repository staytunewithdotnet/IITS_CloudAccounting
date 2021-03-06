// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class ReportInvoiceDetailsBLL
    {
        private ReportInvoiceDetailsTableAdapter _ReportInvoiceDetailsAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.ReportInvoiceDetailsDataTable GetData(int iCompanyID, int iClientID, string sStatus, DateTime? dtFromDate, DateTime? dtToDate)
        {
            return this.Adapter.GetData(new int?(iCompanyID), new int?(iClientID), sStatus, dtFromDate, dtToDate);
        }
        
        protected ReportInvoiceDetailsTableAdapter Adapter
        {
            get
            {
                if (this._ReportInvoiceDetailsAdapter == null)
                {
                    return new ReportInvoiceDetailsTableAdapter();
                }
                return this._ReportInvoiceDetailsAdapter;
            }
        }
    }
}
