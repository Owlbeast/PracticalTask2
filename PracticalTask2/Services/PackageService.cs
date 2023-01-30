using BarcodeLib;
using Microsoft.EntityFrameworkCore;
using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public class PackageService : IPackageService
    {
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
            package.Id = 0;

            AddUpdatePackage(package);
        }

        public void UpdatePackage(Package package)
        {
            if (package.Id == 0)
            {
                throw new DbUpdateConcurrencyException();
            }

            AddUpdatePackage(package);
        }

        private void AddUpdatePackage(Package package)
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
            barcodeGenerator.Encode(TYPE.CODE39Extended, packageIdentifier);
            return barcodeGenerator.GetImageData(SaveTypes.JPG);
        }

    }
}
