// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class DoyinGoSupportDiscussionBLL
    {
        private DoyinGoSupportDiscussionTableAdapter _DoyinGoSupportDiscussionAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddDoyinGoSupportDiscussion(int iSupportTicketID, string sMessage, DateTime dtMessageDate, string sMessageBy)
        {
            int? doyinGoSupportDiscussionID = 0;
            this.Adapter.Insert(ref doyinGoSupportDiscussionID, new int?(iSupportTicketID), sMessage, new DateTime?(dtMessageDate), sMessageBy);
            return doyinGoSupportDiscussionID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteDoyinGoSupportDiscussion(int iDoyinGoSupportDiscussionID)
        {
            try
            {
                this.Adapter.Delete(new int?(iDoyinGoSupportDiscussionID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.DoyinGoSupportDiscussionDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.DoyinGoSupportDiscussionDataTable GetDataByDoyinGoSupportDiscussionID(int iDoyinGoSupportDiscussionID)
        {
            return this.Adapter.GetDataByDoyinGoSupportDiscussionID(new int?(iDoyinGoSupportDiscussionID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.DoyinGoSupportDiscussionDataTable GetDataBySupportTicketID(int iSupportTicketID)
        {
            return this.Adapter.GetDataByDoyinGoSupportTicketID(new int?(iSupportTicketID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateDoyinGoSupportDiscussion(int iDoyinGoSupportDiscussionID, int iSupportTicketID, string sMessage, DateTime dtMessageDate, string sMessageBy)
        {
            try
            {
                this.Adapter.Update(new int?(iDoyinGoSupportDiscussionID), new int?(iSupportTicketID), sMessage, new DateTime?(dtMessageDate), sMessageBy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected DoyinGoSupportDiscussionTableAdapter Adapter
        {
            get
            {
                if (this._DoyinGoSupportDiscussionAdapter == null)
                {
                    return new DoyinGoSupportDiscussionTableAdapter();
                }
                return this._DoyinGoSupportDiscussionAdapter;
            }
        }
    }
}
