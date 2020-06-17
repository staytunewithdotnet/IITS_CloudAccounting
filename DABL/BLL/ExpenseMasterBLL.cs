// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.BLL
{
    using DABL.DAL;
    using DABL.DAL.CloudAccountDATableAdapters;
    using System;
    using System.ComponentModel;
    
    public class ExpenseMasterBLL
    {
        private ExpenseMasterTableAdapter _ExpenseMasterAdapter;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int AddExpense(int iCompanyID, decimal dExpenseAmount, DateTime? dtExpenseDate, string sVendor, int? iCategoryID, int? iSubCategoryID, string sNotes, bool bTaxes, int? iTax1, decimal? dTaxAmount1, int? iTax2, decimal? dTaxAmount2, bool bRecurringExpense, int? iFrequencyID, string sUntilTimePeriod, DateTime? dtEndDate, bool bAssignedToClient, int? iClientID, bool bAttachImage, byte[] byImage, string sExpenseStatus, bool bActive, bool bArchived, bool bDeleted)
        {
            int? expenseID = 0;
            this.Adapter.Insert(ref expenseID, new int?(iCompanyID), new decimal?(dExpenseAmount), dtExpenseDate, sVendor, iCategoryID, iSubCategoryID, sNotes, new bool?(bTaxes), iTax1, dTaxAmount1, iTax2, dTaxAmount2, new bool?(bRecurringExpense), iFrequencyID, sUntilTimePeriod, dtEndDate, new bool?(bAssignedToClient), iClientID, new bool?(bAttachImage), byImage, sExpenseStatus, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
            return expenseID.Value;
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
        public bool DeleteExpense(int iExpenseID)
        {
            try
            {
                this.Adapter.Delete(new int?(iExpenseID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CloudAccountDA.ExpenseMasterDataTable GetAllDetail()
        {
            return this.Adapter.GetData();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.ExpenseMasterDataTable GetDataByCompanyID(int iCompanyID)
        {
            return this.Adapter.GetDataByCompanyID(new int?(iCompanyID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.ExpenseMasterDataTable GetDataByCompanyIDAndStatus(int iCompanyID, bool bActive, bool bArchived, bool bDeleted)
        {
            return this.Adapter.GetDataByCompanyIDAndStatus(new int?(iCompanyID), new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CloudAccountDA.ExpenseMasterDataTable GetDataByExpenseID(int iExpenseID)
        {
            return this.Adapter.GetDataByExpenseID(new int?(iExpenseID));
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateExpense(int iExpenseID, int iCompanyID, decimal dExpenseAmount, DateTime? dtExpenseDate, string sVendor, int? iCategoryID, int? iSubCategoryID, string sNotes, bool bTaxes, int? iTax1, decimal? dTaxAmount1, int? iTax2, decimal? dTaxAmount2, bool bRecurringExpense, int? iFrequencyID, string sUntilTimePeriod, DateTime? dtEndDate, bool bAssignedToClient, int? iClientID, bool bAttachImage, byte[] byImage, string sExpenseStatus, bool bActive, bool bArchived, bool bDeleted)
        {
            try
            {
                this.Adapter.Update(new int?(iExpenseID), new int?(iCompanyID), new decimal?(dExpenseAmount), dtExpenseDate, sVendor, iCategoryID, iSubCategoryID, sNotes, new bool?(bTaxes), iTax1, dTaxAmount1, iTax2, dTaxAmount2, new bool?(bRecurringExpense), iFrequencyID, sUntilTimePeriod, dtEndDate, new bool?(bAssignedToClient), iClientID, new bool?(bAttachImage), byImage, sExpenseStatus, new bool?(bActive), new bool?(bArchived), new bool?(bDeleted));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateExpenseStatus(int iExpenseID, string sExpenseStatus)
        {
            try
            {
                this.Adapter.UpdateExpenseStatus(new int?(iExpenseID), sExpenseStatus);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public bool UpdateWhenAnyBit(int iExpenseID, bool bActive, bool bDeleted, bool bArchived)
        {
            try
            {
                this.Adapter.UpdateWhenAnyBit(new int?(iExpenseID), new bool?(bActive), new bool?(bDeleted), new bool?(bArchived));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected ExpenseMasterTableAdapter Adapter
        {
            get
            {
                if (this._ExpenseMasterAdapter == null)
                {
                    return new ExpenseMasterTableAdapter();
                }
                return this._ExpenseMasterAdapter;
            }
        }
    }
}
