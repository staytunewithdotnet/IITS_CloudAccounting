// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class PackageModuleMasterBLL
    {
        private PackageModuleMasterTableAdapter _PackageModuleMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddPackageModule(string sPackageModuleName, string sPackageModuleDesc, bool bPackageModuleStatus)
        {
            int? packageModuleID = 0;
            this.Adapter.Insert(ref packageModuleID, sPackageModuleName, sPackageModuleDesc, new bool?(bPackageModuleStatus));
            return packageModuleID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeletePackageModule(int iPackageModuleID)
        {
            try
            {
                this.Adapter.Delete(new int?(iPackageModuleID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.PackageModuleMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PackageModuleMasterDataTable GetDataByPackageModuleID(int iPackageModuleID)
        {
            return this.Adapter.GetDataByPackageModuleID(new int?(iPackageModuleID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PackageModuleMasterDataTable GetDataByPackageModuleName(string sPackageModuleName)
        {
            return this.Adapter.GetDataByPackageModuleName(sPackageModuleName);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdatePackageModule(int iPackageModuleID, string sPackageModuleName, string sPackageModuleDesc, bool bPackageModuleStatus)
        {
            try
            {
                this.Adapter.Update(new int?(iPackageModuleID), sPackageModuleName, sPackageModuleDesc, new bool?(bPackageModuleStatus));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected PackageModuleMasterTableAdapter Adapter
        {
            get
            {
                if (this._PackageModuleMasterAdapter == null)
                {
                    return new PackageModuleMasterTableAdapter();
                }
                return this._PackageModuleMasterAdapter;
            }
        }
    }
}
