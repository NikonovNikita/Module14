using Module14.Models;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var phoneBook = new List<Contact>
        {
            new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
            new Contact("Сергей", "Довлатов",79990000010, "serge@example.com"),
            new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
            new Contact("Валерий", "Леонтьев",79990000012, "valera@example.com"),
            new Contact("Сергей", "Брин",  799900000013, "serg@example.com"),
            new Contact("Иннокентий", "Смоктуновский",799900000013, "innokentiy@example.com"),
            new Contact("Иннокентий", "Пупкин", 89008003535, "innokit.pochta@example.com")
        }.OrderBy(b => b.LastName).ThenBy(b => b.Name);

        Console.WriteLine($"Телефонная книга:\n");
        foreach(var contact in  phoneBook)
            Console.WriteLine($"{contact.LastName} --> {contact.Name} --> {contact.PhoneNumber} --> {contact.Email}");

        Console.WriteLine("\nТелефонная книга поддерживает постраничный вывод на консоль по 2 контакта!\n\nВведите" +
            " номер страницы:"); Console.WriteLine();

        var pageCount = Math.Round((float)phoneBook.Count() / 2);

        do
        {
            var inputKey = Console.ReadKey().KeyChar;
            Console.WriteLine();

            var IsParsed = int.TryParse(inputKey.ToString(), out int number);

            if(!IsParsed || number < 1 || number > pageCount)
            {
                Console.WriteLine($"Страницы не существует!");
                continue;
            }

            IEnumerable<Contact> page = phoneBook.Skip((number * 2) - 2).Take(2);

            foreach(var contact in page)
                Console.WriteLine($"{contact.LastName} --> {contact.Name} --> {contact.PhoneNumber} --> {contact.Email}");

        } while (true);
    }
}