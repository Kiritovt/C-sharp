using System.Runtime.InteropServices;
using BookContacts;
using Microsoft.VisualBasic;
using Npgsql;

class Program
{
    static void Main()
    {

        List<Contact> contacts = new();
        bool turnOff = false;
        string connString = "Host=localhost;Port=5432;Database=contacts_book;Username=postgres;Password=MegaLucario99!;";
        using (var conn = new NpgsqlConnection(connString))        {
            try
            {
                conn.Open();
                ContactRepository repository = new ContactRepository(conn);
                contacts = repository.LoadContacts();
                Console.WriteLine("Connected successfully.");
                int Id;
                string Name;
                string Surname;
                string phone_Number;
                while (!turnOff)
                {

                    int choice = ReadNumber("===== Contacts Book =====\n1. Add Contact \n2. Show Contacts \n3. Update Contact info \n4. Delete Contact \n5. Search contact by surname\n6. Order By Surname\n7. Search By ID\n8. Show Contacts Name\n9. Search surname and show ordered names\n10. Search for name or surname\n0. Exit");
                    bool Check;
                    switch (choice)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("Enter the contact name:");
                                Name = Console.ReadLine() ?? "";
                                Console.WriteLine("Enter the contact surname:");
                                Surname = Console.ReadLine() ?? "";
                                Console.WriteLine("Enter the contact phone number:");
                                phone_Number = Console.ReadLine() ?? "";

                                if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Surname) && string.IsNullOrWhiteSpace(phone_Number))
                                {
                                    Console.WriteLine("Invalid contact. Please retry");
                                }
                                else {break;}


                            }
                            Check= repository.AddContact(Name, Surname, phone_Number);
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
                                        Console.WriteLine($"{c.Id}. {c.Name} {c.Surname} {c.Phone_Number}");
                                    }

                            break;

                        case 3:
                            foreach (Contact c in contacts)
                            {
                                Console.Write($"\n{c.Id}. {c.Name} {c.Surname} - {c.Phone_Number}");
                            }

                            Id = ReadNumber("Enter the contact id:");
                            Console.WriteLine("Enter the new contact number:");
                            string newPhoneNumber = Console.ReadLine()??"";
                            Check = repository.UpdateContact(Id, newPhoneNumber);
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
                                Console.WriteLine($"{c.Id}. {c.Name} {c.Surname} - {c.Phone_Number}");
                            }
                            Id = ReadNumber("Enter the contact number:");

                            Check = repository.DeleteContact(Id);
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

                        case 5:
                            Console.WriteLine("Enter the contact surname:");
                            string surname = Console.ReadLine()?.ToLower()??"";

                            var result = contacts.Where(c => c.Surname.ToLower() == surname);

                            if (result.Any())
                            {
                                foreach (Contact contact in result)
                            {
                                Console.WriteLine($"{contact.Id} {contact.Name} {contact.Surname} - {contact.Phone_Number}");
                                }
                            }
                            else
                            {
                                    Console.WriteLine("No Contact found");
                                }
                            break;

                        case 6:
                            var SurnameOrder = contacts.OrderBy(c => c.Surname).ThenBy(c => c.Name);
                            foreach (Contact c in SurnameOrder)
                            {
                                Console.WriteLine($"{c.Id}. {c.Name} {c.Surname} - {c.Phone_Number}");
                            }
                            break;

                        case 7:
                            var SearchID = ReadNumber("Enter The contact ID");
                            Contact? foundCont = contacts.FirstOrDefault(c => c.Id == SearchID);
                            if (foundCont != null)
                            {
                                Console.WriteLine($"{foundCont.Name} {foundCont.Surname} - {foundCont.Phone_Number}");
                            }
                            else
                            {
                                Console.WriteLine("ID not found");
                            }
                            break;

                        case 8:
                            var ContactNames = contacts.Select(c => c.Name);
                            foreach (String c in ContactNames)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                        case 9:
                            Console.WriteLine("Enter the surname");
                            string filter = Console.ReadLine()?.ToLower().Trim() ??"";
                            var filteredNames = contacts.Where(c => c.Surname.ToLower().Trim() == filter).OrderBy(c => c.Name).Select(c => c.Name);
                            foreach (String name in filteredNames)
                            {
                                Console.WriteLine(name);
                            }

                            break;
                        case 10:
                            Console.WriteLine("Enter the contact name or surname:");
                            string info = Console.ReadLine()?.ToLower() ?? "";
                            var filtered = contacts.Where(c => c.Name != null && c.Name.ToLower().Contains(info) || c.Surname != null && c.Surname.ToLower().Contains(info))
                                .OrderBy(c => c.Surname).ThenBy(c => c.Name);

                            if (filtered.Any())
                            {
                                 foreach (Contact c in filtered )
                            {
                                Console.WriteLine($"{c.Id} {c.Name} {c.Surname} {c.Phone_Number}");
                            }
                            }
                            else
                            {
                                Console.WriteLine($"No contacts found with the name or surname: {info}");
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
                Console.WriteLine($"An error occured: {ex.Message}");
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





