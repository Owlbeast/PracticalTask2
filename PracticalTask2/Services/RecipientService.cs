using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public class RecipientService : IRecipientService
    {
        public RecipientService()
        {
            //using (var context = new ApiContext())
            //{
            //    var recipients = new List<Recipient>
            //    {
            //        new Recipient
            //        {
            //            Id = 1,
            //            Name = "John Doe",
            //            Address = "Something st. 1",
            //            Packages= new List<Package>
            //            {
            //                new Package { Name = "Test 1", Description = "Qwe qwe", LastUpdated = DateTime.Now,
            //                    Status = "DELIVERED", PackageIdentifier = "What is it", RecipientId = 1},
            //                new Package { Name = "Test 2", Description = "Asd asd", LastUpdated = DateTime.Parse("2022-11-12"),
            //                    Status = "RECEIVED", PackageIdentifier = "something", RecipientId = 1},
            //                new Package { Name = "Test 3", Description = "Zxc Zxc", LastUpdated = DateTime.Now.AddDays(10),
            //                    Status = "DELIVERED", PackageIdentifier = "identifier", RecipientId = 1}
            //            }
            //        }
            //    };
            //    context.Recipients.AddRange(recipients);
            //    context.SaveChanges();
            //}
        }

        public void AddRecipient(Recipient recipient)
        {
            using (var context = new ApiContext())
            {
                context.Recipients.Add(recipient);
                context.SaveChanges();
            }
        }

        public void UpdateRecipient(Recipient recipient)
        {
            using (var context = new ApiContext())
            {
                context.Recipients.Update(recipient);
                context.SaveChanges();
            }
        }
    }
}
