using System;

namespace list6._10
{
    public class PdaItem
    {
        public virtual string Name { get; set; }
    }

    public class Contact : PdaItem
    {
        public override string Name
        {
            get
            {
                return $"{FirstName}{LastName}";
            }
            set
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName  = names[1];
            }
        }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact;
            PdaItem item;

            contact = new Contact();
            item = contact;

            item.Name = "Inigo Montoya";

            Console.WriteLine( $"{contact.FirstName} {contact.LastName}");
        }
    }
}
