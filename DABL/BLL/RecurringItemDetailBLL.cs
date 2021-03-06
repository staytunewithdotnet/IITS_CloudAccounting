// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class RecurringItemDetailBLL
    {
        private RecurringItemDetailTableAdapter _RecurringItemDetailAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddRecurringItem(int iRecurringID, int iItemID, string sItemDesc, decimal? dUnitCost, decimal? dQuantity, int? iTaxID1, int? iTaxID2, decimal? dTotal)
        {
            int? recurringItemDetailID = 0;
            this.Adapter.Insert(ref recurringItemDetailID, new int?(iRecurringID), new int?(iItemID), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, dTotal);
            return recurringItemDetailID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool DeleteByRecurring(int iRecurringID)
        {
            try
            {
                this.Adapter.DeleteByRecurringID(new int?(iRecurringID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteRecurringItem(int iRecurringItemID)
        {
            try
            {
                this.Adapter.Delete(new int?(iRecurringItemID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.RecurringItemDetailDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.RecurringItemDetailDataTable GetDataByItemID(int iItemID)
        {
            return this.Adapter.GetDataByItemID(new int?(iItemID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.RecurringItemDetailDataTable GetDataByRecurringID(int iRecurringID)
        {
            return this.Adapter.GetDataByRecurringID(new int?(iRecurringID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.RecurringItemDetailDataTable GetDataByRecurringItemID(int iRecurringItemID)
        {
            return this.Adapter.GetDataByRecurringItemDetailID(new int?(iRecurringItemID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateRecurringItem(int iRecurringItemID, int iRecurringID, int iItemID, string sItemDesc, decimal? dUnitCost, decimal? dQuantity, int? iTaxID1, int? iTaxID2, decimal? dTotal)
        {
            try
            {
                this.Adapter.Update(new int?(iRecurringItemID), new int?(iRecurringID), new int?(iItemID), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, dTotal);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected RecurringItemDetailTableAdapter Adapter
        {
            get
            {
                if (this._RecurringItemDetailAdapter == null)
                {
                    return new RecurringItemDetailTableAdapter();
                }
                return this._RecurringItemDetailAdapter;
            }
        }
    }
}
