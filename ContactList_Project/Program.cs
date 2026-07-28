using Phonelist;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        bool TurnOff = false;
        Contact contact = new Contact();
        List<Contact> Contactsbook = contact.LoadContacts();
        while (!TurnOff)
        {
            int Choice = ReadChoice("===== Contact Book =====\n1. Add Contact\n2. Show Conctacts\n3. Search Contact\n4. Remove Contact\n5. Save Contact\n6. Import Contacts\n0. Exit");

            switch (Choice)
            {
                case 1:
                    Contact contactx = new Contact();
                    Console.WriteLine("Enter the Name:");
                    contactx.Name = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter the Surname:");
                    contactx.Surname = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter the Phone Number:");
                    contactx.PhoneNumber = Console.ReadLine()?? "";
                    if (string.IsNullOrWhiteSpace(contactx.Name) && string.IsNullOrWhiteSpace(contactx.Surname) && string.IsNullOrWhiteSpace(contactx.PhoneNumber))
                    {
                        Console.WriteLine("Uncorrect compilation. The contact has 0 information so it cannot be added");
                    } else
                    {
                        Contactsbook.Add(contactx);
                        contact.SaveContact(Contactsbook);
                    }
                    break;

                case 2:
                    if (Contactsbook.Count == 0)
                    {
                        Console.WriteLine("The Contacts Book is empty");
                    } else
                    {
                        int i = 0;
                        foreach (Contact contactEntry in Contactsbook)
                        {
                            Console.WriteLine($"{i + 1}. {contactEntry.Name} {contactEntry.Surname} - {contactEntry.PhoneNumber}");
                            i++;
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter Name Or Surname:");
                    string information = Console.ReadLine()?.ToLower().Trim() ?? "";
                    while (true)
                    {
                        if (string.IsNullOrWhiteSpace(information))
                        {
                            Console.WriteLine("The entered Namer Or Surname is not valid. Please re-try");
                            information = Console.ReadLine()?.ToLower().Trim() ?? "";
                        }
                        else
                        {
                            break;
                        }
                    }
                    bool contactFound = false;
                    foreach (Contact contactSearch in Contactsbook)
                    {
                        if (information == contactSearch.Name.ToLower() || information == contactSearch.Surname.ToLower())
                        {
                            Console.WriteLine($"Here the contact with the Name/Surname {information}: \n{contactSearch.Name} {contactSearch.Surname} - {contactSearch.PhoneNumber}");
                            contactFound = true;
                        }
                    } if (contactFound == false)
                    {
                        Console.WriteLine("No contact Found.");
                    }
                    break;

                case 4:
                    int c = 0;
                    if (Contactsbook.Count == 0)
                    {
                        Console.WriteLine("The Contacts Book is empty.");
                    }
                    else
                    {
                        foreach (Contact contacts in Contactsbook)
                        {
                            Console.WriteLine($"{c + 1}. {contacts.Name} {contacts.Surname} - {contacts.PhoneNumber}");
                            c++;
                        }
                        int removed = ReadChoice("Enter the contact that you want to remove:");
                        while (true)
                        {
                            if (removed > Contactsbook.Count || removed < 1)
                            {
                                Console.WriteLine("Invalid input. Please retry");
                                removed = ReadChoice("Enter the contact that you want to remove:");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Contactsbook.RemoveAt(removed - 1);
                        contact.SaveContact(Contactsbook);
                    }
                    break;

                case 5:
                    contact.SaveContact(Contactsbook);
                    Console.WriteLine("Contact successfully saved");
                    break;

                case 6:
                    Contactsbook = contact.LoadContacts();
                    break;

                case 0:
                    TurnOff = true;
                    break;

                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }
    }
     private static int ReadChoice(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}