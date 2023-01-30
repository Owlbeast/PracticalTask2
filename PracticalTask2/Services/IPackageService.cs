using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public interface IPackageService
    {
        public List<Package> GetPackages();

        public List<Package> GetPackagesWithStatus(string status);

        public List<Package> GetPackagesForRecipient(int recipientId);

        public Package? GetPackage(int packageId);

        public void AddPackage(Package package);

        public void UpdatePackage(Package package);

        public byte[]? GetPackageBarcode(int packageId);
    }
}
