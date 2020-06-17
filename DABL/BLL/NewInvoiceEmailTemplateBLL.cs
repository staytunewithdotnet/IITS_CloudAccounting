// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class NewInvoiceEmailTemplateBLL
    {
        private NewInvoiceEmailTemplateTableAdapter _NewInvoiceEmailTemplateAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddInvoiceTemplate(int iCompanyID, string sInvoiceTemplateSubject, string sInvoiceTemplateBody)
        {
            int? newInvoiceEmailTemplateID = 0;
            this.Adapter.Insert(ref newInvoiceEmailTemplateID, new int?(iCompanyID), sInvoiceTemplateSubject, sInvoiceTemplateBody);
            return newInvoiceEmailTemplateID.Value;
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
        public bool DeleteInvoiceTemplate(int iInvoiceTemplateID)
        {
            try
            {
                this.Adapter.Delete(new int?(iInvoiceTemplateID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.NewInvoiceEmailTemplateDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.NewInvoiceEmailTemplateDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateInvoiceTemplate(int iInvoiceTemplateID, int iCompanyID, string sInvoiceTemplateSubject, string sInvoiceTemplateBody)
        {
            try
            {
                this.Adapter.Update(new int?(iInvoiceTemplateID), new int?(iCompanyID), sInvoiceTemplateSubject, sInvoiceTemplateBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected NewInvoiceEmailTemplateTableAdapter Adapter
        {
            get
            {
                if (this._NewInvoiceEmailTemplateAdapter == null)
                {
                    return new NewInvoiceEmailTemplateTableAdapter();
                }
                return this._NewInvoiceEmailTemplateAdapter;
            }
        }
    }
}
