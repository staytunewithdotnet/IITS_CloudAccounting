// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class CompanyPaypalMasterBLL
    {
        private CompanyPaypalMasterTableAdapter _CompanyPaypalMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddCompanyPaypal(int iCompanyID, string sPaypalID)
        {
            int? companyPaypalID = 0;
            this.Adapter.Insert(ref companyPaypalID, new int?(iCompanyID), sPaypalID);
            return companyPaypalID.Value;
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
        public bool DeleteCompanyPaypal(int iCompanyPaypalID)
        {
            try
            {
                this.Adapter.Delete(new int?(iCompanyPaypalID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.CompanyPaypalMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyPaypalMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyPaypalMasterDataTable GetDataByCompanyPaypalID(int iCompanyPaypalID)
        {
            return this.Adapter.GetDataByCompanyPaypalID(new int?(iCompanyPaypalID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateCompanyPaypal(int iCompanyPaypalID, int iCompanyID, string sPaypalID)
        {
            try
            {
                this.Adapter.Update(new int?(iCompanyPaypalID), new int?(iCompanyID), sPaypalID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected CompanyPaypalMasterTableAdapter Adapter
        {
            get
            {
                if (this._CompanyPaypalMasterAdapter == null)
                {
                    return new CompanyPaypalMasterTableAdapter();
                }
                return this._CompanyPaypalMasterAdapter;
            }
        }
    }
}
