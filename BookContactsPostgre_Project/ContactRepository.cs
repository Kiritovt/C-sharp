using Npgsql;

namespace BookContacts;

public class ContactRepository
{
    private readonly NpgsqlConnection _conn;

    public ContactRepository(NpgsqlConnection conn)
    {
        _conn = conn;
    }

    public List<Contact> LoadContacts()
    {
        List<Contact> contacts = new();
        var sql = "SELECT * From contacts Order By id ASC";
        using (var select = new NpgsqlCommand(sql, _conn))
        {
            using (var reader = select.ExecuteReader())
            {
                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.id = Convert.ToInt32(reader["id"]);
                    contact.name = reader["name"].ToString() ?? "";
                    contact.surname = reader["surname"].ToString() ?? "";
                    contact.phone_number = reader["phone_number"].ToString()?.Trim() ?? "";
                    contacts.Add(contact);
                }
            }
        }
        return(contacts);
    }

     public bool AddContact(string name, string surname, string phone_number)
    {
        var sql = "INSERT INTO Contacts (name, surname, phone_number) Values(@name, @surname, @phone_number)";

        using (var insert = new NpgsqlCommand(sql, _conn))
        {
            insert.Parameters.AddWithValue("name", name);
            insert.Parameters.AddWithValue("surname", surname);
            insert.Parameters.AddWithValue("phone_number", phone_number);

            var QueryCheck = insert.ExecuteNonQuery();
            return QueryCheck != 0;

        }
    }


    public bool UpdateContact(int id, string newPhoneNumber)
    {
        var sql = "UPDATE contacts set phone_number = @phone_number Where id = @id";

        using (var update = new NpgsqlCommand(sql, _conn))
        {
            update.Parameters.AddWithValue("phone_number", newPhoneNumber);
            update.Parameters.AddWithValue("id", id);

            var QueryCheck = update.ExecuteNonQuery();

            return QueryCheck != 0;
        }
    }

     public bool DeleteContact(int id)
    {
        var sql = "DELETE FROM contacts WHERE id = @id";

        using (var delete = new NpgsqlCommand(sql, _conn))

        {
            delete.Parameters.AddWithValue("id", id);
            var QueryCheck = delete.ExecuteNonQuery();
            return QueryCheck != 0;
        }

    }

}
