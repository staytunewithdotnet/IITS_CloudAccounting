// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class NewEstimateEmailTemplateBLL
    {
        private NewEstimateEmailTemplateTableAdapter _NewEstimateEmailTemplateAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddEstimateTemplate(int iCompanyID, string sEstimateTemplateSubject, string sEstimateTemplateBody)
        {
            int? newEstimateEmailTemplateID = 0;
            this.Adapter.Insert(ref newEstimateEmailTemplateID, new int?(iCompanyID), sEstimateTemplateSubject, sEstimateTemplateBody);
            return newEstimateEmailTemplateID.Value;
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
        public bool DeleteEstimateTemplate(int iEstimateTemplateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iEstimateTemplateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.NewEstimateEmailTemplateDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.NewEstimateEmailTemplateDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateEstimateTemplate(int iEstimateTemplateID, int iCompanyID, string sEstimateTemplateSubject, string sEstimateTemplateBody)
        {
            try
            {
                this.Adapter.Update(new int?(iEstimateTemplateID), new int?(iCompanyID), sEstimateTemplateSubject, sEstimateTemplateBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected NewEstimateEmailTemplateTableAdapter Adapter
        {
            get
            {
                if (this._NewEstimateEmailTemplateAdapter == null)
                {
                    return new NewEstimateEmailTemplateTableAdapter();
                }
                return this._NewEstimateEmailTemplateAdapter;
            }
        }
    }
}
