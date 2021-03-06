// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class NewClientEmailTemplateBLL
    {
        private NewClientEmailTemplateTableAdapter _NewClientEmailTemplateAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddClientTemplate(int iCompanyID, string sClientTemplateSubject, string sClientTemplateBody)
        {
            int? newClientEmailTemplateID = 0;
            this.Adapter.Insert(ref newClientEmailTemplateID, new int?(iCompanyID), sClientTemplateSubject, sClientTemplateBody);
            return newClientEmailTemplateID.Value;
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
        public bool DeleteClientTemplate(int iClientTemplateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iClientTemplateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.NewClientEmailTemplateDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.NewClientEmailTemplateDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateClientTemplate(int iClientTemplateID, int iCompanyID, string sClientTemplateSubject, string sClientTemplateBody)
        {
            try
            {
                this.Adapter.Update(new int?(iClientTemplateID), new int?(iCompanyID), sClientTemplateSubject, sClientTemplateBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected NewClientEmailTemplateTableAdapter Adapter
        {
            get
            {
                if (this._NewClientEmailTemplateAdapter == null)
                {
                    return new NewClientEmailTemplateTableAdapter();
                }
                return this._NewClientEmailTemplateAdapter;
            }
        }
    }
}
