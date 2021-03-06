// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class PackageMasterBLL
    {
        private PackageMasterTableAdapter _PackageMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddPackage(string sPackageCode, string sPackageName, bool bFreeTrialPackage, int iNoOfAdminUserMin, int iNoOfAdminUserMax, int iNoOfStaffUserMin, int iNoOfStaffUserMax, decimal? dPricePerMonth, int iMonthCurrencyID, decimal? dPricePerYear, int iYearCurrencyID, string sPackageDesc, int? iNoOfTrialDays, bool bPackageStatus)
        {
            int? packageID = 0;
            this.Adapter.Insert(ref packageID, sPackageCode, sPackageName, new bool?(bFreeTrialPackage), new int?(iNoOfAdminUserMin), new int?(iNoOfAdminUserMax), new int?(iNoOfStaffUserMin), new int?(iNoOfStaffUserMax), dPricePerMonth, new int?(iMonthCurrencyID), dPricePerYear, new int?(iYearCurrencyID), sPackageDesc, iNoOfTrialDays, new bool?(bPackageStatus));
            return packageID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeletePackage(int iPackageID)
        {
            try
            {
                this.Adapter.Delete(new int?(iPackageID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.PackageMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PackageMasterDataTable GetDataByPackageID(int iPackageID)
        {
            return this.Adapter.GetDataByPackageID(new int?(iPackageID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.PackageMasterDataTable GetDataByPackageName(string sPackageName)
        {
            return this.Adapter.GetDataByPackageName(sPackageName);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdatePackage(int iPackageID, string sPackageCode, string sPackageName, bool bFreeTrialPackage, int iNoOfAdminUserMin, int iNoOfAdminUserMax, int iNoOfStaffUserMin, int iNoOfStaffUserMax, decimal? dPricePerMonth, int iMonthCurrencyID, decimal? dPricePerYear, int iYearCurrencyID, string sPackageDesc, int? iNoOfTrialDays, bool bPackageStatus)
        {
            try
            {
                this.Adapter.Update(new int?(iPackageID), sPackageCode, sPackageName, new bool?(bFreeTrialPackage), new int?(iNoOfAdminUserMin), new int?(iNoOfAdminUserMax), new int?(iNoOfStaffUserMin), new int?(iNoOfStaffUserMax), dPricePerMonth, new int?(iMonthCurrencyID), dPricePerYear, new int?(iYearCurrencyID), sPackageDesc, iNoOfTrialDays, new bool?(bPackageStatus));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected PackageMasterTableAdapter Adapter
        {
            get
            {
                if (this._PackageMasterAdapter == null)
                {
                    return new PackageMasterTableAdapter();
                }
                return this._PackageMasterAdapter;
            }
        }
    }
}
