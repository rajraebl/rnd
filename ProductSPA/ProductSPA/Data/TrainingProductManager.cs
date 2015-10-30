using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductSPA.Data
{
    public class TrainingProductManager
    {
        private List<TrainingProduct> ret = new List<TrainingProduct>();

        public List<TrainingProduct> Get(TrainingProduct entityProduct)
        {
            var data = CreateMockData();
            if (!string.IsNullOrEmpty(entityProduct.ProductName))
            {
                return 
                    data.FindAll(
                        x =>
                            x.ProductName.ToLower()
                                .StartsWith(entityProduct.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }
            return data;

        }
        private List<TrainingProduct> CreateMockData()
        {
            for(int i=1;i<12;i++)
            {
                
            ret.Add(new TrainingProduct()
            {
                Id = i,
                ProductName = getName(i),
                IntroductionDate = Convert.ToDateTime("1/" + i + "/2015"),
                Url = "http://bit.ly/"+i,
                Price = Convert.ToDecimal( 12.13+i)

            });
            }
            return ret;
        }

        private string getName(int i)
        {
            string ProductName;
            if (i%2 == 0)
                ProductName = "Extending Bootstrap-" + i;
            else
                ProductName = "Bootstrap Extending-" + i;
            return ProductName;
        }
    }
}