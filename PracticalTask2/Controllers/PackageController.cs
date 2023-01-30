using Microsoft.AspNetCore.Mvc;
using PracticalTask2.Entities;
using PracticalTask2.Services;

namespace PracticalTask2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet(Name = nameof(GetAllPackages))]
        public List<Package> GetAllPackages()
        {
            return _packageService.GetPackages();
        }

        [HttpGet(Name = nameof(GetPackagesWithStatusDelivered))]
        public List<Package> GetPackagesWithStatusDelivered(string status = "DELIVERED")
        {
            return _packageService.GetPackagesWithStatus(status);
        }

        [HttpGet(Name = nameof(GetPackagesForRecipient))]
        public List<Package> GetPackagesForRecipient(int recipientId)
        {
            return _packageService.GetPackagesForRecipient(recipientId);
        }

        [HttpGet(Name = nameof(GetPackage))]
        public Package? GetPackage(int packageId)
        {
            return _packageService.GetPackage(packageId);
        }

        [HttpPost(Name = nameof(AddPackage))]
        public void AddPackage(Package package)
        {
            _packageService.AddPackage(package);
        }

        [HttpPost(Name = nameof(UpdatePackage))]
        public void UpdatePackage(Package package)
        {
            _packageService.UpdatePackage(package);
        }

        [HttpGet(Name = nameof(GetPackageBarcode))]
        public IActionResult GetPackageBarcode(int packageId)
        {
            var barcode = _packageService.GetPackageBarcode(packageId);
            
            return barcode == null ? NoContent() : File(barcode, "image/jpeg");
        }
    }
}