using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass5_CreditCardValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String cardNumber;

            // ensure we return false unless we confirm the card is valid
            bool isValidCard = false;
            bool isNumeric = false; 

            //get user input
            Console.WriteLine("Please Enter Your 16 Digit Credit Card Number!");
            cardNumber = Console.ReadLine();

            // checks if the inputed card number is numeric
            isNumeric = NumeracyChecker(cardNumber, "lorem");

            // checks if the number is valid
            isValidCard = ValidityChecker(cardNumber, isNumeric);

            if (isNumeric == true && isValidCard == true)
            {
                Console.WriteLine(" ");
                Console.WriteLine(cardNumber + " Is a Valid Card Number!");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(cardNumber + " Is not a Valid Card Number!");
            }
            
            Console.WriteLine(" ");
            Console.WriteLine("Press Any Key To Escape!");
            Console.ReadKey();
        }

        public static bool NumeracyChecker(String cardNumber, string overload)
        {
            bool isNumeric = true;

            //checks if each individual character is an int
            for (int i = 0; i <= cardNumber.Length-1; i++)
            {
                if (!(char.IsDigit(cardNumber[i])))
                {
                    isNumeric = false;
                }
            }

            return isNumeric;
        }

        public static bool ValidityChecker(String cardNumber, bool isNumeric)
        {
            bool isValid = false;

            int sum = 0;
            int undoubledSum = 0;
            int doubledSum = 0;

            List<String> newCardNumber = new List<String>();

            //add every number to a list
            for (int i = 0; i <= cardNumber.Length-1; i++)
            {
                newCardNumber.Add(cardNumber[i].ToString());
            }

            // double every other number
            for (int i = 0; i <= cardNumber.Length-1; i++) {
                if ((i % 2 == 0))
                {
                    newCardNumber[i] = ((int.Parse(newCardNumber[i]) * 2).ToString());

                    // checks if each number is > 9
                    if (int.Parse(newCardNumber[i]) > 9)
                    {
                        newCardNumber[i] = ((int.Parse(newCardNumber[i]) % 10) + 1).ToString();
                    }
                }
            }

            // sum all undoubled numbers and all doubled numbers
            for (int i = 0; i <= cardNumber.Count() - 1; i++)
            {
                if (i % 2 == 0)
                {
                    undoubledSum += (int.Parse(newCardNumber[i]));
                }
                else if (!(i % 2 == 0))
                {
                    doubledSum += (int.Parse(newCardNumber[i]));
                }
            }

            // check if the result is divisible by 10
            if (((doubledSum + undoubledSum) % 10) == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
