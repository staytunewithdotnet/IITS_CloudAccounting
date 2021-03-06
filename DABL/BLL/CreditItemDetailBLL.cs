// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class CreditItemDetailBLL
    {
        private CreditItemDetailTableAdapter _CreditItemDetailAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddCreditItem(int iCreditID, int iItemID, string sItemDesc, decimal? dUnitCost, decimal? dQuantity, int? iTaxID1, int? iTaxID2, decimal? dTotal)
        {
            int? creditItemDetailID = 0;
            this.Adapter.Insert(ref creditItemDetailID, new int?(iCreditID), new int?(iItemID), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, dTotal);
            return creditItemDetailID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByCredit(int iCreditID)
        {
            try
            {
                this.Adapter.DeleteByCreditID(new int?(iCreditID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteCreditItem(int iCreditItemID)
        {
            try
            {
                this.Adapter.Delete(new int?(iCreditItemID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.CreditItemDetailDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CreditItemDetailDataTable GetDataByCreditID(int iCreditID)
        {
            return this.Adapter.GetDataByCreditID(new int?(iCreditID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CreditItemDetailDataTable GetDataByCreditItemID(int iCreditItemID)
        {
            return this.Adapter.GetDataByCreditItemDetailID(new int?(iCreditItemID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CreditItemDetailDataTable GetDataByItemID(int iItemID)
        {
            return this.Adapter.GetDataByItemID(new int?(iItemID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateCreditItem(int iCreditItemID, int iCreditID, int iItemID, string sItemDesc, decimal? dUnitCost, decimal? dQuantity, int? iTaxID1, int? iTaxID2, decimal? dTotal)
        {
            try
            {
                this.Adapter.Update(new int?(iCreditItemID), new int?(iCreditID), new int?(iItemID), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, dTotal);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected CreditItemDetailTableAdapter Adapter
        {
            get
            {
                if (this._CreditItemDetailAdapter == null)
                {
                    return new CreditItemDetailTableAdapter();
                }
                return this._CreditItemDetailAdapter;
            }
        }
    }
}
