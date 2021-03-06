// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class StateMasterBLL
    {
        private StateMasterTableAdapter _StateMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddState(int iCountryID, string sStateCode, string sStateName, string sStateDesc, bool bStateStatus)
        {
            int? stateID = 0;
            this.Adapter.Insert(ref stateID, new int?(iCountryID), sStateCode, sStateName, sStateDesc, new bool?(bStateStatus));
            return stateID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteState(int iStateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iStateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.StateMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StateMasterDataTable GetDataByCountryID(int iCountryID)
        {
            return this.Adapter.GetDataByCountryID(new int?(iCountryID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StateMasterDataTable GetDataByCountryStateName(int iCountryID, string sStateName)
        {
            return this.Adapter.GetDataByCountryStateName(new int?(iCountryID), sStateName);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StateMasterDataTable GetDataByCountryStateName(int iStateID, int iCountryID, string sStateName)
        {
            return this.Adapter.GetDataByCountryStateNameUpdate(new int?(iStateID), new int?(iCountryID), sStateName);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StateMasterDataTable GetDataByStateID(int iStateID)
        {
            return this.Adapter.GetDataByStateID(new int?(iStateID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StateMasterDataTable GetDataByStateName(string sStateName)
        {
            return this.Adapter.GetDataByStateName(sStateName);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateState(int iStateID, int iCountryID, string sStateCode, string sStateName, string sStateDesc, bool bStateStatus)
        {
            try
            {
                this.Adapter.Update(new int?(iStateID), new int?(iCountryID), sStateCode, sStateName, sStateDesc, new bool?(bStateStatus));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected StateMasterTableAdapter Adapter
        {
            get
            {
                if (this._StateMasterAdapter == null)
                {
                    return new StateMasterTableAdapter();
                }
                return this._StateMasterAdapter;
            }
        }
    }
}
