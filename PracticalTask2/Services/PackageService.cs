using BarcodeLib;
using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public class PackageService : IPackageService
    {
        public PackageService()
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

        public List<Package> GetPackages()
        {
            using (var context = new ApiContext())
            {
                return context.Packages.ToList();
            }
        }

        public List<Package> GetPackagesWithStatus(string status)
        {
            using (var context = new ApiContext())
            {
                return context.Packages.Where(i => i.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }

        public List<Package> GetPackagesForRecipient(int recipientId)
        {
            using (var context = new ApiContext())
            {
                return context.Packages.Where(i => i.RecipientId == recipientId).ToList();
            }
        }

        public Package? GetPackage(int packageId)
        {
            using (var context = new ApiContext())
            {
                return context.Packages.FirstOrDefault(i => i.Id == packageId);
            }
        }

        public void AddPackage(Package package)
        {
            package.Status = "RECEIVED";

            using (var context = new ApiContext())
            {
                context.Packages.Add(package);
                context.SaveChanges();
            }
        }

        public void UpdatePackage(Package package)
        {
            using (var context = new ApiContext())
            {
                context.Packages.Update(package);
                context.SaveChanges();
            }
        }

        public byte[]? GetPackageBarcode(int packageId)
        {
            var packageIdentifier = GetPackage(packageId)?.PackageIdentifier;

            if (packageIdentifier == null)
                return null;
            
            var barcodeGenerator = new Barcode();
            barcodeGenerator.Encode(TYPE.CODE39, packageIdentifier);
            return barcodeGenerator.GetImageData(SaveTypes.JPG);
        }

    }
}
