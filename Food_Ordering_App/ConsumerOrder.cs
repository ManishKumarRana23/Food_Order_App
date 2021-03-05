

using System;
namespace Food_Ordering_App
{
    public class ConsumerOrder : Order
    {
        //creating properties for the class
        public string strCustomerName { get; set; }
        public double decSalesTax { get; set; }

        //constructor with a parameter for customertype
        /* public ConsumerOrder (CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        } */

        //method to calculate the totals for sales tax and the total
        public override void CalcTotals()
        {
            decSalesTax = decTaxRate * decSubtotal;
            decTotal = decSubtotal + decSalesTax;
        }

        //overriding the ToString Method for this class
        public override string ToString()
        {
            /*----ORIGINAL CODE-----\
             
            return "Customer Type: " + CustomerType + "\n" + "Customer name: " + strCustomerName + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nFries Subtotal: " + decFriesubtotal.ToString("c2") + "\nBurger Subtotal: " + decBurgerSubtotal.ToString("c2")
                + "\nSubtotal: " + decSubtotal.ToString("c2") + "\nSales Tax: " + decSalesTax.ToString("c2") + "\nGrand Total: " + decTotal.ToString("c2");
            */
            return "Customer Type: " + CustomerType + "\n" + "Customer name: " + strCustomerName + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nFries Subtotal: " + decFriesubtotal.ToString() + "\nBurger Subtotal: " + decBurgerSubtotal.ToString()
                + "\nSubtotal: " + decSubtotal.ToString() + "\nSales Tax: " + decSalesTax.ToString() + "\nGrand Total: " + decTotal.ToString();
        }
    }
}
