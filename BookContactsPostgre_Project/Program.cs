using System;
using System.ComponentModel.Design;
using BookContacts;
using Npgsql;

class Program
{
    static void Main()
    {

        List<Contact> contacts = new();
        bool turnOff = false;
        string connString = "Host=localhost;Port=5432;Database=contacts_book;Username=postgres;Password=DemetraFormazione_18;";
        using (var conn = new NpgsqlConnection(connString))
        {
            try
            {
                conn.Open();
                ContactRepository repository = new ContactRepository(conn);
                contacts = repository.LoadContacts();
                Console.WriteLine("Connected successfully.");
                int id;
                string name;
                string surname;
                string phone_number;
                while (!turnOff)
                {

                    int choice = ReadNumber("===== Contacts Book =====\n1. Add Contact \n2. Show Contacts \n3. Update Contact info \n4. Delete Contact \n0. Exit");
                    bool Check;
                    switch (choice)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("Enter the contact name:");
                                name = Console.ReadLine() ?? "";
                                Console.WriteLine("Enter the contact surname:");
                                surname = Console.ReadLine() ?? "";
                                Console.WriteLine("Enter the contact phone number:");
                                phone_number = Console.ReadLine() ?? "";

                                if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(surname) && string.IsNullOrWhiteSpace(phone_number))
                                {
                                    Console.WriteLine("Invalid contact. Please retry");
                                }
                                else {break;}


                            }
                            Check= repository.AddContact(name, surname, phone_number);
                            if (Check)
                            {
                                Console.WriteLine("Contact successfully added.");
                                contacts = repository.LoadContacts();
                            }
                            else
                            {
                                Console.WriteLine("Operation Failed.");
                            }
                            break;

                        case 2:
                            contacts = repository.LoadContacts();
                                    foreach (Contact c in contacts)
                                    {
                                        Console.WriteLine($"{c.id}. {c.name} {c.surname} {c.phone_number}");
                                    }

                            break;

                        case 3:
                            foreach (Contact c in contacts)
                            {
                                Console.Write($"\n{c.id}. {c.name} {c.surname} - {c.phone_number}");
                            }

                            id = ReadNumber("Enter the contact id:");
                            Console.WriteLine("Enter the new contact number:");
                            string newPhoneNumber = Console.ReadLine()??"";
                            Check = repository.UpdateContact(id, newPhoneNumber);
                            if (Check)
                                {
                                    Console.WriteLine("Number successfully updated.");
                                    contacts = repository.LoadContacts();
                                } else
                                {
                                    Console.WriteLine("Operation failed.");
                                }

                            break;

                        case 4:
                            foreach (Contact c in contacts)
                            {
                                Console.WriteLine($"{c.id}. {c.name} {c.surname} - {c.phone_number}");
                            }
                            id = ReadNumber("Enter the contact number:");

                            Check = repository.DeleteContact(id);
                                    if (Check)
                            {
                                Console.WriteLine("Contact successfully deleted.");
                                contacts = repository.LoadContacts();
                                    }
                                    else
                                    {
                                Console.WriteLine("Operation failed");
                            }

                            break;

                        case 0:
                            turnOff = true;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Retry");
                            break;
                    }


                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }
    }
        public static int ReadNumber(string message)
    {
        while (true){
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

    }
}