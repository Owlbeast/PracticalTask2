using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public interface IRecipientService
    {
        public void AddRecipient(Recipient recipient);

        public void UpdateRecipient(Recipient recipient);
    }
}
