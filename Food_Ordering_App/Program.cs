
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace Food_Ordering_App
{
    public enum CustomerType { CONSUMER, CATERING };
    class Program
    {
        public static void Main(string[] args)
        {
            //declaring constants

            const double decPriceFries = 10.00;
            const double decPriceSand = 30.00;
           

        //declaring variables for input
        string strCustomerCodeInput;
            string strFries;
            Int32 intFries;
            string strSand;
            Int32 intBurger;
            Int32 intCountItems;


            //declaring Boolean variable for customer type and positive number validation
            Boolean bolCustomerType;

            //Get customer type from the user with a while post validation loop
            do
            {
                //Ask for the Customer Type
                Console.WriteLine("Which type of order would you like to process <CONSUMER or CATERING>?");
                strCustomerCodeInput = Console.ReadLine().ToUpper();

                //calling validation method to validate the users input on type of customer
                bolCustomerType = Validation.CheckCustomerType(strCustomerCodeInput);

                //prints error message if the customer enters incorrect value for type of customer
                if (bolCustomerType == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid customer type. Please enter either 'Consumer' or 'Catering'. ");
                    Console.WriteLine("");
                }
            } while (bolCustomerType == false);

            //get customer input for number of Fries/Burger while validating that they ordered at least one item
            do
            {
                // start the order process
                intCountItems = 0;

                //Fries order loop
                do
                {
                    //asks user for input
                    Console.WriteLine("How Many Fries would you like?:");
                    strFries = Console.ReadLine();

                    //call check positive to make sure order amount is a correct format
                    intFries = Validation.CheckItem(strFries);

                    //Fries error message
                    if (intFries == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Fries Order Amount. Please Order in whole number intervals with no special symbols.");
                        Console.WriteLine("");
                    }

                    //keep order count to make sure they order at least one item
                    else if (intFries != -1) { intCountItems = intCountItems + intFries; }

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (intFries == -1);

                //Burger order loop
                do
                {
                    //asks user for input
                    Console.WriteLine("How Many Burger would you like?:");
                    strSand = Console.ReadLine();

                    //call check positive to make sure order amount is a correct format
                    intBurger = Validation.CheckItem(strSand);

                    //Burger error message
                    if (intBurger == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Burger Order Amount. Please Order in whole number intervals with no special symbols.");
                        Console.WriteLine("");
                    }

                    //keep order count to make sure they order at least one item
                    else if (intBurger != -1) { intCountItems = intCountItems + intBurger; }

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (intBurger == -1);

                if (intCountItems < 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid order amount. Customers must order at least one item.");
                    Console.WriteLine("");
                }

            } while (intCountItems < 1);

            if (strCustomerCodeInput == "CATERING")
            { CheckoutCatering(intFries, intBurger); }
            else if (strCustomerCodeInput == "CONSUMER")
            { CheckoutConsumer(intFries, intBurger); }

            //code to keep code running until we press a key
            Console.WriteLine("");
            Console.WriteLine("Please hit any key to end the order.");
            Console.ReadLine();

            //method for creating a catering order
            void CheckoutCatering(Int32 intFriesNum, Int32 intBurgerNum)
            {
                //creates a new instance of the object CateringOrder
                CateringOrder CaterObj = new CateringOrder();

                //declares variables for input
                string strCustomerCode;
                string strDeliveryFee;
                string strPreferred;
                double decDeliveryFee1;
                Boolean bolCustomerCode;

                do
                {
                    Console.WriteLine("Please enter the Customer Code (Letters Only - 4 to 6 characters):");
                    strCustomerCode = Console.ReadLine().ToUpper();

                    //calls the validation method to check the customer code
                    bolCustomerCode = Validation.CheckCustomerCode(strCustomerCode);

                    //print error message if needed
                    if (bolCustomerCode == false) { Console.WriteLine("Invalid Customer Code. Please enter a Code 4 to 6 Letters Only."); }

                    //assigns the Customer Code to the object property.
                    CaterObj.strCustomerCode = strCustomerCode;

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (bolCustomerCode == false);

                //loop to get delivery fee and validate it
                do
                {
                    Console.WriteLine("Please enter the delivery fee:");
                    strDeliveryFee = Console.ReadLine();

                    decDeliveryFee1 = Validation.CheckDeliveryFee(strDeliveryFee);

                    //print error message if needed
                    if (decDeliveryFee1 == -1) { Console.WriteLine("Invalid Delivery Fee. Please enter a positive value."); }

                    CaterObj.decDeliveryFee = decDeliveryFee1;

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (decDeliveryFee1 == -1);

                //asks the user if this customer is preferred
                Console.WriteLine("Is this a preferred customer? <'Y or y' for yes, any other key for No> :");
                strPreferred = Console.ReadLine();

                //sets delivery fee to zero if the customer is a preferred customer
                if (strPreferred == "Y" || strPreferred == "y") { CaterObj.bolPreferredCustomer = true; }
                else { CaterObj.bolPreferredCustomer = false; }

                //populates the inputs of the object instance
                CaterObj.CustomerType = CustomerType.CATERING;
                CaterObj.intNumberOfFries = intFriesNum;
                CaterObj.intNumberOfBurger = intBurgerNum;
                CaterObj.intTotalItems = intFriesNum + intBurgerNum;
                CaterObj.decFriesubtotal = intFriesNum * decPriceFries;
                CaterObj.decBurgerSubtotal = intBurgerNum * decPriceSand;
                CaterObj.decSubtotal = CaterObj.decFriesubtotal + CaterObj.decBurgerSubtotal;

                //call method to calculate the totals
                CaterObj.CalcTotals();

                //display the totals and receipt
                Console.WriteLine(CaterObj.ToString());

            }

            //method for consumer checkouts
            void CheckoutConsumer(Int32 intFriesNum, Int32 intBurgerNum)
            {
                //declaring some variables
                string strNameInput;

                //creates a new instance of the object ConsumerOrder
                ConsumerOrder obj = new ConsumerOrder();

                //asks the user to enter the name of the customer
                Console.WriteLine("What is the customer's name:");
                strNameInput = Console.ReadLine();

                //populating the input properties on the ConsumerOrder Class
                obj.CustomerType = CustomerType.CONSUMER;
                obj.strCustomerName = strNameInput;
                obj.intNumberOfFries = intFriesNum;
                obj.intNumberOfBurger = intBurgerNum;
                obj.intTotalItems = intFriesNum + intBurgerNum;
                obj.decFriesubtotal = intFriesNum * decPriceFries;
                obj.decBurgerSubtotal = intBurgerNum * decPriceSand;
                obj.decSubtotal = obj.decFriesubtotal + obj.decBurgerSubtotal;

                //call method to calculate the totals
                obj.CalcTotals();

                //display the totals and receipt
                Console.WriteLine(obj.ToString());
            }
        }


    }
}