// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class SecurityQuestionMasterBLL
    {
        private SecurityQuestionMasterTableAdapter _SecurityQuestionMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddSecurityQuestion(string Question, string sDefaultAnswer, string Description, bool Status)
        {
            int? securityQuestionID = 0;
            this.Adapter.Insert(ref securityQuestionID, Question, sDefaultAnswer, Description, new bool?(Status));
            return securityQuestionID.Value;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteSecurityQuestion(int iSecurityQuestionID)
        {
            try
            {
                this.Adapter.Delete(new int?(iSecurityQuestionID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.SecurityQuestionMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.SecurityQuestionMasterDataTable GetDataByQuestion(string sQuestion)
        {
            return this.Adapter.GetDataByQuestion(sQuestion);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.SecurityQuestionMasterDataTable GetDataBySecurityQuestionID(int iSecurityQuestionID)
        {
            return this.Adapter.GetDataBySecurityQuestionID(new int?(iSecurityQuestionID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateSecurityQuestion(int iSecurityQuestionID, string Question, string sDefaultAnswer, string Description, bool Status)
        {
            try
            {
                this.Adapter.Update(new int?(iSecurityQuestionID), Question, sDefaultAnswer, Description, new bool?(Status));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected SecurityQuestionMasterTableAdapter Adapter
        {
            get
            {
                if (this._SecurityQuestionMasterAdapter == null)
                {
                    return new SecurityQuestionMasterTableAdapter();
                }
                return this._SecurityQuestionMasterAdapter;
            }
        }
    }
}
