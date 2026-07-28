using System.Text.Json;
namespace Phonelist;

public class Contact
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public void SaveContact(List<Contact> a)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(a, options);
        File.WriteAllText("Contacts.json", json);
    }
    
    public List<Contact> LoadContacts()
    {
        if (File.Exists("Contacts.json")) 
                    {
                        string contacts = File.ReadAllText("Contacts.json");
                        return JsonSerializer.Deserialize<List<Contact>>(contacts) ?? new List<Contact>();
                    }
                    else
                    {
                        return new List<Contact>();
                    }
    }
}