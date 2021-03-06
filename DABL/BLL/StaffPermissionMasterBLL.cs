// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class StaffPermissionMasterBLL
    {
        private StaffPermissionMasterTableAdapter _StaffPermissionMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddStaffPermission(int iCompanyID, bool bPeople, bool bInvoice, bool bEstimate, bool bExpense, bool bTimeTracking, bool bSupport, bool bDocuments, bool bReports, bool bProjectAccess, bool bSendInvEstCre, bool bClientMngt, bool bTicketAdministration)
        {
            int? staffPermissionID = 0;
            this.Adapter.Insert(ref staffPermissionID, new int?(iCompanyID), new bool?(bPeople), new bool?(bInvoice), new bool?(bEstimate), new bool?(bExpense), new bool?(bTimeTracking), new bool?(bSupport), new bool?(bDocuments), new bool?(bReports), new bool?(bProjectAccess), new bool?(bSendInvEstCre), new bool?(bClientMngt), new bool?(bTicketAdministration));
            return staffPermissionID.Value;
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
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteStaffPermission(int iStaffPermissionID)
        {
            try
            {
                this.Adapter.Delete(new int?(iStaffPermissionID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.StaffPermissionMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StaffPermissionMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.StaffPermissionMasterDataTable GetDataByStaffPermissionID(int iStaffPermissionID)
        {
            return this.Adapter.GetDataByStaffPermissionID(new int?(iStaffPermissionID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateStaffPermission(int iStaffPermissionID, int iCompanyID, bool bPeople, bool bInvoice, bool bEstimate, bool bExpense, bool bTimeTracking, bool bSupport, bool bDocuments, bool bReports, bool bProjectAccess, bool bSendInvEstCre, bool bClientMngt, bool bTicketAdministration)
        {
            try
            {
                this.Adapter.Update(new int?(iStaffPermissionID), new int?(iCompanyID), new bool?(bPeople), new bool?(bInvoice), new bool?(bEstimate), new bool?(bExpense), new bool?(bTimeTracking), new bool?(bSupport), new bool?(bDocuments), new bool?(bReports), new bool?(bProjectAccess), new bool?(bSendInvEstCre), new bool?(bClientMngt), new bool?(bTicketAdministration));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected StaffPermissionMasterTableAdapter Adapter
        {
            get
            {
                if (this._StaffPermissionMasterAdapter == null)
                {
                    return new StaffPermissionMasterTableAdapter();
                }
                return this._StaffPermissionMasterAdapter;
            }
        }
    }
}
