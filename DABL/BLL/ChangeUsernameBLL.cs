// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class ChangeUsernameBLL
    {
        private readonly ChangeUsernameTableAdapter _ChangeUsernameAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.ChangeUsernameDataTable GetAllDetail(string sOldUserName, string sNewUserName)
        {
            return this.Adapter.GetData("cloudaccount", sOldUserName, sNewUserName);
        }
        
        protected ChangeUsernameTableAdapter Adapter
        {
            get
            {
                if (this._ChangeUsernameAdapter == null)
                {
                    return new ChangeUsernameTableAdapter();
                }
                return this._ChangeUsernameAdapter;
            }
        }
    }
}
