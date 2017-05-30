using System;
using System.Transactions;

namespace Thoth.Framework.Core.CrossCuttingConcern.Transaction.ManageHelper
{
    public class ManagerBase
    {
        public void ExecuteTransactionalOperation(Action codetoExecute)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    codetoExecute.Invoke();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
