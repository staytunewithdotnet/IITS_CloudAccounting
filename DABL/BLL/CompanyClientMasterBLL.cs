// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class CompanyClientMasterBLL
    {
        private CompanyClientMasterTableAdapter _CompanyClientMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddCompanyClient(int iCompanyID, string sOrganizationName, int? iCurrencyID, bool binvoiceEmail, bool bInvoiceSnailMail, string sEmail, string sFirstName, string sLastName, string sHomePhone, string sMobile, bool bLoginCredentials, string sUserName, string sAddress1, string sAddress2, int? iCountryID, int? iStateID, int? iCityID, string sZipCode, string sSecondaryAddress1, string sSecondaryAddress2, int? iSecondaryCountryID, int? iSecondaryStateID, int? iSecondaryCityID, string sSecondaryZipCode, int? iIndustryID, string sCompanySize, string sBussinessPhone, string sFax, string sCompanyClientDesc, bool bActive, bool bArchived, bool bDeleted)
        {
            int? companyClientID = 0;
            this.Adapter.Insert(ref companyClientID, new int?(iCompanyID), sOrganizationName, iCurrencyID, new bool?(binvoiceEmail), new bool?(bInvoiceSnailMail), sEmail, sFirstName, sLastName, sHomePhone, sMobile, new bool?(bLoginCredentials), sUserName, sAddress1, sAddress2, iCountryID, iStateID, iCityID, sZipCode, sSecondaryAddress1, sSecondaryAddress2, iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, sSecondaryZipCode, iIndustryID, sCompanySize, sBussinessPhone, sFax, sCompanyClientDesc, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
            return companyClientID.Value;
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
        public bool DeleteCompanyClient(int iCompanyClientID)
        {
            try
            {
                this.Adapter.Delete(new int?(iCompanyClientID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.CompanyClientMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByCompanyClientID(int iCompanyClientID)
        {
            return this.Adapter.GetDataByCompanyClientID(new int?(iCompanyClientID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByCompanyEmail(int iCompanyID, string sEmail)
        {
            return this.Adapter.GetDataByCompanyIDAndEmail(new int?(iCompanyID), sEmail);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByCompanyStaffIDAndStatus(int iCompanyID, int iStaffID, bool bActive, bool bArchived, bool bDeleted, string sOrganization, string sFirstName, string sLastName, string sAddress, string sEmail, string sPhone, string sNotes)
        {
            return this.Adapter.GetDataByCompanyStaffIDAndStatus(new int?(iCompanyID), new int?(iStaffID), new bool?(bActive), new bool?(bArchived), new bool?(bDeleted), sOrganization, sFirstName, sLastName, sAddress, sEmail, sPhone, sNotes);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByCompanyStatus(int iCompanyID, bool bActive, bool bArchived, bool bDeleted, string sOrganization, string sFirstName, string sLastName, string sAddress, string sEmail, string sPhone, string sNotes)
        {
            return this.Adapter.GetDataByCompanyIDAndStatus(new int?(iCompanyID), new bool?(bActive), new bool?(bArchived), new bool?(bDeleted), sOrganization, sFirstName, sLastName, sAddress, sEmail, sPhone, sNotes);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.CompanyClientMasterDataTable GetDataByUsername(string sUsername)
        {
            return this.Adapter.GetDataByUsername(sUsername);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateBoxData(int iCompanyClientID, int iCompanyID, string sOrganizationName, string sEmail, string sFirstName, string sLastName, string sAddress1, string sAddress2, int? iCountryID, int? iStateID, int? iCityID, string sZipCode, int? iIndustryID, string sCompanySize)
        {
            try
            {
                this.Adapter.UpdateBoxData(new int?(iCompanyClientID), new int?(iCompanyID), sOrganizationName, sEmail, sFirstName, sLastName, sAddress1, sAddress2, iCountryID, iStateID, iCityID, sZipCode, iIndustryID, sCompanySize);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateClientProfile(int iCompanyClientID, int iCompanyID, string sEmail, string sFirstName, string sLastName, string sHomePhone, string sMobile, string sUserName, string sAddress1, string sAddress2, int? iCountryID, int? iStateID, int? iCityID, string sZipCode, string sSecondaryAddress1, string sSecondaryAddress2, int? iSecondaryCountryID, int? iSecondaryStateID, int? iSecondaryCityID, string sSecondaryZipCode, string sBussinessPhone, string sFax)
        {
            try
            {
                this.Adapter.UpdateClientProfile(new int?(iCompanyClientID), new int?(iCompanyID), sEmail, sFirstName, sLastName, sHomePhone, sMobile, sUserName, sAddress1, sAddress2, iCountryID, iStateID, iCityID, sZipCode, sSecondaryAddress1, sSecondaryAddress2, iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, sSecondaryZipCode, sBussinessPhone, sFax);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateCompanyClient(int iCompanyClientID, int iCompanyID, string sOrganizationName, int? iCurrencyID, bool binvoiceEmail, bool bInvoiceSnailMail, string sEmail, string sFirstName, string sLastName, string sHomePhone, string sMobile, bool bLoginCredentials, string sUserName, string sAddress1, string sAddress2, int? iCountryID, int? iStateID, int? iCityID, string sZipCode, string sSecondaryAddress1, string sSecondaryAddress2, int? iSecondaryCountryID, int? iSecondaryStateID, int? iSecondaryCityID, string sSecondaryZipCode, int? iIndustryID, string sCompanySize, string sBussinessPhone, string sFax, string sCompanyClientDesc, bool bActive, bool bArchived, bool bDeleted)
        {
            try
            {
                this.Adapter.Update(new int?(iCompanyClientID), new int?(iCompanyID), sOrganizationName, iCurrencyID, new bool?(binvoiceEmail), new bool?(bInvoiceSnailMail), sEmail, sFirstName, sLastName, sHomePhone, sMobile, new bool?(bLoginCredentials), sUserName, sAddress1, sAddress2, iCountryID, iStateID, iCityID, sZipCode, sSecondaryAddress1, sSecondaryAddress2, iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, sSecondaryZipCode, iIndustryID, sCompanySize, sBussinessPhone, sFax, sCompanyClientDesc, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateWhenAnyBit(int iCompanyClientID, bool bActive, bool bDeleted, bool bArchived)
        {
            try
            {
                this.Adapter.UpdateWhenAnyBit(new int?(iCompanyClientID), new bool?(bActive), new bool?(bDeleted), new bool?(bArchived));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected CompanyClientMasterTableAdapter Adapter
        {
            get
            {
                if (this._CompanyClientMasterAdapter == null)
                {
                    return new CompanyClientMasterTableAdapter();
                }
                return this._CompanyClientMasterAdapter;
            }
        }
    }
}
