using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.DesignPatterns.Builder.ProductBuilder
{
    public class ProductDirector
    {
        public ProductViewModel GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
            return productBuilder.GetModel();
        }
    }
}
