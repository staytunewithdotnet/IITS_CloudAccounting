// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class NewStaffEmailTemplateBLL
    {
        private NewStaffEmailTemplateTableAdapter _NewStaffEmailTemplateAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddStaffTemplate(int iCompanyID, string sStaffTemplateSubject, string sStaffTemplateBody)
        {
            int? newStaffEmailTemplateID = 0;
            this.Adapter.Insert(ref newStaffEmailTemplateID, new int?(iCompanyID), sStaffTemplateSubject, sStaffTemplateBody);
            return newStaffEmailTemplateID.Value;
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
        public bool DeleteStaffTemplate(int iStaffTemplateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iStaffTemplateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.NewStaffEmailTemplateDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.NewStaffEmailTemplateDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateStaffTemplate(int iStaffTemplateID, int iCompanyID, string sStaffTemplateSubject, string sStaffTemplateBody)
        {
            try
            {
                this.Adapter.Update(new int?(iStaffTemplateID), new int?(iCompanyID), sStaffTemplateSubject, sStaffTemplateBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected NewStaffEmailTemplateTableAdapter Adapter
        {
            get
            {
                if (this._NewStaffEmailTemplateAdapter == null)
                {
                    return new NewStaffEmailTemplateTableAdapter();
                }
                return this._NewStaffEmailTemplateAdapter;
            }
        }
    }
}
