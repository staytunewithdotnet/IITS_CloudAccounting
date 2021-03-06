// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class AutoBillEmailTemplateBLL
    {
        private AutoBillEmailTemplateTableAdapter _AutoBillEmailTemplateAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddAutoBillEmail(int iCompanyID, string sTemplateFor, bool bEnable, string sAutoBillEmailSubject, string sAutoBillEmailBody)
        {
            int? autoBillEmailTemplateID = 0;
            this.Adapter.Insert(ref autoBillEmailTemplateID, new int?(iCompanyID), sTemplateFor, new bool?(bEnable), sAutoBillEmailSubject, sAutoBillEmailBody);
            return autoBillEmailTemplateID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteAutoBillEmail(int iAutoBillEmailID)
        {
            try
            {
                this.Adapter.Delete(new int?(iAutoBillEmailID));
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
        public CloudAccountDA.AutoBillEmailTemplateDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.AutoBillEmailTemplateDataTable GetDataByCompanyID(int iCompanyID, string sTemplateFor)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID), sTemplateFor);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateAutoBillEmail(int iAutoBillEmailID, int iCompanyID, string sTemplateFor, bool bEnable, string sAutoBillEmailSubject, string sAutoBillEmailBody)
        {
            try
            {
                this.Adapter.Update(new int?(iAutoBillEmailID), new int?(iCompanyID), sTemplateFor, new bool?(bEnable), sAutoBillEmailSubject, sAutoBillEmailBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected AutoBillEmailTemplateTableAdapter Adapter
        {
            get
            {
                if (this._AutoBillEmailTemplateAdapter == null)
                {
                    return new AutoBillEmailTemplateTableAdapter();
                }
                return this._AutoBillEmailTemplateAdapter;
            }
        }
    }
}
