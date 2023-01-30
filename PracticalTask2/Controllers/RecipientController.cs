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

        public RecipientController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }

        [HttpPost(Name = nameof(AddRecipient))]
        public IActionResult AddRecipient(Recipient recipient)
        {
            try
            {
                _recipientService.AddRecipient(recipient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = nameof(UpdateRecipient))]
        public IActionResult UpdateRecipient(Recipient recipient)
        {
            try 
            { 
                _recipientService.UpdateRecipient(recipient);
                return Ok();
            } 
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = nameof(GetRecipients))]
        public List<Recipient> GetRecipients()
        {
            return _recipientService.GetRecipients();
        }

    }
}
