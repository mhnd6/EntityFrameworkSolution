using EntityFrameworkUI.DataAccess;
using EntityFrameworkUI.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUI
{
    class Program
    {
        static void Main(string[] args)
        {


            //CreateMhnd();
            //ReadAll();
            //ReadById(1);
            // CreateAmjed();
            //UpdateFirstName(1, "Rabea");
            //ReadAll();
            //RemovePhoneNumber(1, "555-1212");
            RemoveUser(1);
            ReadAll();

            Console.WriteLine("Done Processing!");
            Console.ReadLine();
        }

        private static void CreateMhnd()
        {
            var c = new Contact
            {
                FirstName = "Mohanned",
                LastName = "Akbar"
            };
            c.EmailAddresses.Add(new Email { EmailAddress = "Mrmohandtv@gmail.com" });
            c.EmailAddresses.Add(new Email { EmailAddress = "mohndakbar@gmail.com" });// will insert into email table
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-3451" });

            using (var db = new ContactContext())
            {
                db.Contacts.Add(c);
                db.SaveChanges();// this will right to sql
            }
        }

        private static void CreateAmjed()
        {
            var c = new Contact
            {
                FirstName = "Amjed",
                LastName = "Bukhari"
            };
            c.EmailAddresses.Add(new Email { EmailAddress = "Amj@gmail.com" });
            c.EmailAddresses.Add(new Email { EmailAddress = "Bukhari@gmail.com" });// will insert into email table
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-3451" });

            using (var db = new ContactContext())
            {
                db.Contacts.Add(c);
                db.SaveChanges();// this will right to sql
            }
        }
        private static void ReadAll()
        {
            using (var db = new ContactContext())
            {
                //only include what you need
                var records = db.Contacts
                  //  .Include(e => e.EmailAddresses)// like join
                   // .Include(p => p.PhoneNumbers)
                    .ToList();

                foreach (var c in records)
                {
                    Console.WriteLine($"{c.FirstName } { c.LastName}");
                }
            }
        }

        public static void RemoveUser(int id)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts
                    .Include(e => e.EmailAddresses)
                    .Include(p => p.PhoneNumbers)
                    .Where(c => c.Id == id).First();
                db.Contacts.Remove(user);
                db.SaveChanges();
            }
        }

        public static void RemovePhoneNumber(int id, string phoneNumber)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts
                    .Include(p => p.PhoneNumbers)
                    .Where(c => c.Id == id).First();

                user.PhoneNumbers.RemoveAll(p => p.PhoneNumber == phoneNumber);

                db.SaveChanges();


            }
        }

        private static void ReadById(int id)
        {
            using (var db = new ContactContext())
            {
                //This SQL is in the server side to determine (optimized)
                var user = db.Contacts.Where(c => c.Id == id).First();

                Console.WriteLine($"{user.FirstName } { user.LastName}");

            }
        }

        private static void UpdateFirstName(int id, string firstName)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts.Where(c => c.Id == id).First();

                user.FirstName = firstName;

                db.SaveChanges();
            
            
            }
        }
    }
}
