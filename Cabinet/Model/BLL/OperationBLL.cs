using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    internal class OperationBLL
    {
        private readonly OperationDAL operationDAL;

        public OperationBLL()
        {
            operationDAL = new OperationDAL();
        }

        public ObservableCollection<Operation> GetOperations()
        {
            return operationDAL.GetOperations();
        }

        public void AddOperation(Operation operation)
        {
            operationDAL.AddOperation(operation);
        }

        public void EditOperation(Operation operation)
        {
            operationDAL.EditOperation(operation);
        }
    }
}
