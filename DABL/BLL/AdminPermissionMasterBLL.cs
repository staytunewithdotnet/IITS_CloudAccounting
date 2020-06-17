// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class AdminPermissionMasterBLL
    {
        private AdminPermissionMasterTableAdapter _AdminPermissionMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddAdminPermission(int iCompanyID, bool bEstimate, bool bExpense, bool bTimeTracking, bool bSupport, bool bDocuments)
        {
            int? adminPermissionID = 0;
            this.Adapter.Insert(ref adminPermissionID, new int?(iCompanyID), new bool?(bEstimate), new bool?(bExpense), new bool?(bTimeTracking), new bool?(bSupport), new bool?(bDocuments));
            return adminPermissionID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteAdminPermission(int iAdminPermissionID)
        {
            try
            {
                this.Adapter.Delete(new int?(iAdminPermissionID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.AdminPermissionMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.AdminPermissionMasterDataTable GetDataByAdminPermissionID(int iAdminPermissionID)
        {
            return this.Adapter.GetDataByAdminPermissionID(new int?(iAdminPermissionID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.AdminPermissionMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateAdminPermission(int iAdminPermissionID, int iCompanyID, bool bEstimate, bool bExpense, bool bTimeTracking, bool bSupport, bool bDocuments)
        {
            try
            {
                this.Adapter.Update(new int?(iAdminPermissionID), new int?(iCompanyID), new bool?(bEstimate), new bool?(bExpense), new bool?(bTimeTracking), new bool?(bSupport), new bool?(bDocuments));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected AdminPermissionMasterTableAdapter Adapter
        {
            get
            {
                if (this._AdminPermissionMasterAdapter == null)
                {
                    return new AdminPermissionMasterTableAdapter();
                }
                return this._AdminPermissionMasterAdapter;
            }
        }
    }
}
