using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    internal class PriceBLL
    {
        private readonly PriceDAL priceDAL;
        
        public PriceBLL()
        {
            priceDAL = new PriceDAL();
        }

        public ObservableCollection<Price> GetPrices()
        {
            return priceDAL.GetPrices();
        }

        public void AddPrice(Price price)
        {
            priceDAL.AddPrice(price);
        }

        public void EditPrice(Price price)
        {
            priceDAL.EditPrice(price);
        }
    }
}
