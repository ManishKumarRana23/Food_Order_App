

using System;
namespace Food_Ordering_App
{
    public class CateringOrder : Order
    {
        //setting some properties for the Catering class
        public string strCustomerCode { get; set; }
        public double decDeliveryFee { get; set; }
        public Boolean bolPreferredCustomer { get; set; }

        //constructor with a parameter for customer type
        /* public CateringOrder(CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        }*/

        //calc total method to set delivery fee and to set a calculated total.
        public override void CalcTotals()
        {
            //sets customer delivery fee to zero if preferred
            if (bolPreferredCustomer) 
            { 
                decDeliveryFee = 0; 
            }

            //calculates the total for the order
            decTotal = decSubtotal + decDeliveryFee;

        }

        //overriding the ToString Method
        public override string ToString()
        {
            /*-------------------------ORIGINAL CODE-----------------
            return "Customer Type: " + CustomerType + "\n" + "Customer Code: " + strCustomerCode + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nFries Subtotal: " + decFriesubtotal.ToString("c2") + "\nBurger Subtotal: " + decBurgerSubtotal.ToString("c2")
                + "\nSubtotal: " + decSubtotal.ToString("c2") + "\nDelivery Fee: " + decDeliveryFee.ToString("c2") + "\nGrand Total: " + decTotal.ToString("c2");
            */
            return "Customer Type: " + CustomerType + "\n" + "Customer Code: " + strCustomerCode + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nFries Subtotal: " + decFriesubtotal.ToString() + "\nBurger Subtotal: " + decBurgerSubtotal.ToString()
                + "\nSubtotal: " + decSubtotal.ToString() + "\nDelivery Fee: " + decDeliveryFee.ToString() + "\nGrand Total: " + decTotal.ToString();

        }
    }
}
