// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class EstimateMasterBLL
    {
        private EstimateMasterTableAdapter _EstimateMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddEstimate(int iCompanyID, int? iClientID, int? iCurrencyID, string sEstimateNumber, DateTime? dtEstimateDate, string sPONumber, decimal? dDiscount, decimal? dDiscountAmt, string sNotes, string sTerms, string sEstimateStatus, decimal? dEstimateTotal, decimal? dPaidToDate, bool bActive, bool bArchived, bool bDeleted, bool bReceivedActive, bool bReceivedArchived, bool bReceivedDeleted)
        {
            int? estimateID = 0;
            this.Adapter.Insert(ref estimateID, new int?(iCompanyID), iClientID, iCurrencyID, sEstimateNumber, dtEstimateDate, sPONumber, dDiscount, dDiscountAmt, sNotes, sTerms, sEstimateStatus, dEstimateTotal, dPaidToDate, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted), new bool?(bReceivedActive), new bool?(bReceivedArchived), new bool?(bReceivedDeleted));
            return estimateID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByClient(int iClientID)
        {
            try
            {
                this.Adapter.DeleteByClientID(new int?(iClientID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByCompany(int iCompanyID)
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
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteEstimate(int iEstimateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iEstimateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.EstimateMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByClientID(int iClientID)
        {
            return this.Adapter.GetDataByClientID(new int?(iClientID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByCompanyEstimate(int iCompanyID, string sEstimateNum)
        {
            return this.Adapter.GetDataByCompanyEstimateNumber(new int?(iCompanyID), sEstimateNum);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByCompanyEstimateUpdate(int iCompanyID, string sEstimateNum, int iEstimateID)
        {
            return this.Adapter.GetDataByCompanyEstimateNumberUpdate(new int?(iCompanyID), sEstimateNum, new int?(iEstimateID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByCompanyStaffStatus(int iCompanyID, int iStaffID, bool bActive, bool bArchived, bool bDeleted)
        {
            return this.Adapter.GetDataByCompanyStaffIDAndStatus(new int?(iCompanyID), new int?(iStaffID), new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByCompanyStatus(int iCompanyID, bool bActive, bool bArchived, bool bDeleted)
        {
            return this.Adapter.GetDataByCompanyIDAndStatus(new int?(iCompanyID), new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.EstimateMasterDataTable GetDataByEstimateID(int iEstimateID)
        {
            return this.Adapter.GetDataByEstimateID(new int?(iEstimateID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateEstimate(int iEstimateID, int iCompanyID, int? iClientID, int? iCurrencyID, string sEstimateNumber, DateTime? dtEstimateDate, string sPONumber, decimal? dDiscount, decimal? dDiscountAmt, string sNotes, string sTerms, string sEstimateStatus, decimal? dEstimateTotal, decimal? dPaidToDate, bool bActive, bool bArchived, bool bDeleted, bool bReceivedActive, bool bReceivedArchived, bool bReceivedDeleted)
        {
            try
            {
                this.Adapter.Update(new int?(iEstimateID), new int?(iCompanyID), iClientID, iCurrencyID, sEstimateNumber, dtEstimateDate, sPONumber, dDiscount, dDiscountAmt, sNotes, sTerms, sEstimateStatus, dEstimateTotal, dPaidToDate, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted), new bool?(bReceivedActive), new bool?(bReceivedArchived), new bool?(bReceivedDeleted));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateEstimateStatus(string sEstimateStatus, int iEstimateID)
        {
            try
            {
                this.Adapter.UpdateStatus(sEstimateStatus, iEstimateID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateWhenAnyBit(int iEstimateID, bool bActive, bool bDeleted, bool bArchived)
        {
            try
            {
                this.Adapter.UpdateWhenAnyBit(new int?(iEstimateID), new bool?(bActive), new bool?(bDeleted), new bool?(bArchived));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateWhenAnyReceivedBit(int iEstimateID, bool bReceivedActive, bool bReceivedDeleted, bool bReceivedArchived)
        {
            try
            {
                this.Adapter.UpdateWhenAnyReceivedBit(new int?(iEstimateID), new bool?(bReceivedActive), new bool?(bReceivedDeleted), new bool?(bReceivedArchived));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected EstimateMasterTableAdapter Adapter
        {
            get
            {
                if (this._EstimateMasterAdapter == null)
                {
                    return new EstimateMasterTableAdapter();
                }
                return this._EstimateMasterAdapter;
            }
        }
    }
}
