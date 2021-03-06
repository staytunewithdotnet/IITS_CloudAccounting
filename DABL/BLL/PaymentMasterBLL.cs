// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class PaymentMasterBLL
    {
        private PaymentMasterTableAdapter _PaymentMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddPayment(int iCompanyID, int iInvoiceID, decimal? dPaymentAmount, string sPaymentMethod, DateTime? dtPaymentDate, string sPaymentNotes)
        {
            int? paymentID = 0;
            this.Adapter.Insert(ref paymentID, new int?(iCompanyID), new int?(iInvoiceID), dPaymentAmount, sPaymentMethod, dtPaymentDate, sPaymentNotes);
            return paymentID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByCompanyID(int iCompanyID)
        {
            try
            {
                this.Adapter.DeleteByCompanyID(new int?(iCompanyID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByInvoiceID(int iInvoiceID)
        {
            try
            {
                this.Adapter.DeleteByInvoiceID(new int?(iInvoiceID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeletePayment(int iPaymentID)
        {
            try
            {
                this.Adapter.Delete(new int?(iPaymentID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.PaymentMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PaymentMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PaymentMasterDataTable GetDataByCompanyStaffID(int iCompanyID, int iStaffID)
        {
            return this.Adapter.GetDataByCompanyStaffID(new int?(iCompanyID), new int?(iStaffID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PaymentMasterDataTable GetDataByInvoiceID(int iInvoiceID)
        {
            return this.Adapter.GetDataByInvoiceID(new int?(iInvoiceID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PaymentMasterDataTable GetDataByPaymentID(int iPaymentID)
        {
            return this.Adapter.GetDataByPaymentID(new int?(iPaymentID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdatePayment(int iPaymentID, int iCompanyID, int iInvoiceID, decimal? dPaymentAmount, string sPaymentMethod, DateTime? dtPaymentDate, string sPaymentNotes)
        {
            try
            {
                this.Adapter.Update(new int?(iPaymentID), new int?(iCompanyID), new int?(iInvoiceID), dPaymentAmount, sPaymentMethod, dtPaymentDate, sPaymentNotes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected PaymentMasterTableAdapter Adapter
        {
            get
            {
                if (this._PaymentMasterAdapter == null)
                {
                    return new PaymentMasterTableAdapter();
                }
                return this._PaymentMasterAdapter;
            }
        }
    }
}
