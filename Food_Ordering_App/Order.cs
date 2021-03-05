
using System;
namespace Food_Ordering_App
{
    public abstract class Order
    {
        //declaring constants

        
        /*
        public const double decPriceFries = 10.00m;
        public const double decPriceSand = 30.00m;
        */
        public const double decTaxRate = 0.0825;
        


        //creating the properties for the class
        public CustomerType CustomerType { get; set; }
        public Int32 intNumberOfBurger { get; set; }
        public Int32 intNumberOfFries { get; set; }
        public double decFriesubtotal { get; set; }
        public double decBurgerSubtotal { get; set; }
        public double decSubtotal { get; set; }
        public double decTotal { get; set; }
        public Int32 intTotalItems { get; set; }

        //blank constructor
        public Order() { }


        //constructor for the class with customer type parameter
        public Order(CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        }

        //method for calculating the total is abstract
        //blank because subclass contains the implementations
        public abstract void CalcTotals();
    }
}
