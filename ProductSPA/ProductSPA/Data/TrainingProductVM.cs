using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSPA.Data
{
    public class TrainingProductVM
    {
        public TrainingProductVM()
        {
            Products = new List<TrainingProduct>();
            Command = "List";
            SearchEntity = new TrainingProduct();
        }


        public void HandleRequest()
        {
            switch (Command.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    resetSearch();
                    Get();
                    break;
                default:
                    break;
            }
        }

        public List<TrainingProduct> Products { get; set; }
        public string Command { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }

        private void resetSearch()
        {
            SearchEntity = new TrainingProduct();
        }
    }
}