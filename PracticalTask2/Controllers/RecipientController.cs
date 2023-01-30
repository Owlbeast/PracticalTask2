using Microsoft.AspNetCore.Mvc;
using PracticalTask2.Entities;
using PracticalTask2.Services;

namespace PracticalTask2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientService _recipientService;
//- add new recipient
//- edit recipient

        public RecipientController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }

        [HttpPost(Name = nameof(AddRecipient))]
        public void AddRecipient(Recipient recipient)
        {
            _recipientService.AddRecipient(recipient);
        }

        [HttpPost(Name = nameof(UpdateRecipient))]
        public void UpdateRecipient(Recipient recipient)
        {
            _recipientService.UpdateRecipient(recipient);
        }

    }
}
