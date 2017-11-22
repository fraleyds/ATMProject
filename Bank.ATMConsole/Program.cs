using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // While loop 
            bool running = true;

            while (running)
            {
                AccountService acctService = new AccountService();
                CustomerService customerService = new CustomerService();
                Console.WriteLine("Welcome to Cool Bank . . .\n\n");
                bool accountLoop = true;
                int accountNum = 0;
                while (accountLoop)
                {
                    Console.WriteLine("Enter Account Number:");
                    bool accountInt = int.TryParse(Console.ReadLine(), out accountNum);
                    if (accountInt)
                    {
                        accountLoop = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid account number.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                bool pinLoop = true;
                int pinInput = 0;
                while (pinLoop)
                {
                    Console.WriteLine("\nEnter PIN:");
                    bool pinInt = int.TryParse(Console.ReadLine(), out pinInput);
                    if (pinInt)
                    {
                        pinLoop = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid PIN.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                var currentAcct = acctService.Login(accountNum, pinInput);

                // LOGIN FAILED
                if (currentAcct == null)
                {
                    Console.WriteLine("The account number or PIN you entered was incorrect.");
                    Console.ReadLine();
                    Console.Clear();
                }

                // LOGIN SUCCESS
                else
                {
                    Console.Clear();
                    var customer = customerService.CustomerById(currentAcct.CustomerID);

                    TransactionService transaction = new TransactionService();
                    bool menuLoop = true;
                    while (menuLoop)
                    {
                        Console.Clear();
                        Console.WriteLine("What would you like to do?\n\n" +
                            "1. View Account Details\n" +
                            "2. Withdraw Money\n" +
                            "3. Deposit Money\n" +
                            "4. View Transaction History\n" +
                            "5. Exit");

                        string actionInput = Console.ReadLine();

                        // Viewing Account Details
                        if (actionInput == "1")
                        {
                            Console.WriteLine($"Account Owner Surname: {customer.LastName}\n" +
                                $"Account Owner First Name: {customer.FirstName}\n");
                            if (currentAcct.LastName2 != null)
                            {
                                Console.WriteLine($"Secondary User Surname: {currentAcct.LastName2}");
                            }
                            if (currentAcct.FirstName2 != null)
                            {
                                Console.WriteLine($"Secondary User First Name: {currentAcct.FirstName2}\n");
                            }
                            Console.WriteLine($"Account Number: {currentAcct.AccountNum}\n" +
                                $"Account Type: {currentAcct.AccountType}\n\n" +
                                $"Balance: {currentAcct.Balance}");
                            Console.ReadLine();
                        }

                        // Withdrawing
                        else if (actionInput == "2")
                        {
                            WithdrawalService withdrawal = new WithdrawalService();
                        }

                        // Depositing
                        else if (actionInput == "3")
                        {
                            DepositService deposit = new DepositService();
                        }
                        
                        // Transaction history
                        else if (actionInput == "4")
                        {
                            Console.Clear();
                            transaction.GetInteractions(currentAcct.AccountID);
                            Console.ReadLine();
                        }

                        // Closing the program
                        else if (actionInput == "5")
                        {
                            menuLoop = false;
                            Console.WriteLine("Goodbye!");
                        }

                        // None of the above
                        else
                        {
                            Console.WriteLine("Invalid input.");
                            Console.ReadLine();
                        }
                    }
                    running = false;
                }
            }
        }
    }
}
