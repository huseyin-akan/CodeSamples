using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.DesignPatterns.Builder.ProductBuilder
{
    public class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new();

        public override void ApplyDiscount()
        {
            viewModel.Id = 1;
            viewModel.CategoryName = "Apple";
            viewModel.ProductName = "Iphone";
            viewModel.UnitPrice = 20;
        }
        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice * (decimal)0.90;
            viewModel.IsDiscountApplied = true;
        }
    }
}
