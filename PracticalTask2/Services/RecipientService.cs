using Microsoft.EntityFrameworkCore;
using PracticalTask2.Entities;

namespace PracticalTask2.Services
{
    public class RecipientService : IRecipientService
    {
        public void AddRecipient(Recipient recipient)
        {
            recipient.Id = 0;
            AddUpdateRecipient(recipient);
        }

        public void UpdateRecipient(Recipient recipient)
        {
            if (recipient.Id == 0)
            {
                throw new DbUpdateConcurrencyException();
            }

            AddUpdateRecipient(recipient);
        }

        private void AddUpdateRecipient(Recipient recipient)
        {
            using (var context = new ApiContext())
            {
                context.Recipients.Update(recipient);
                context.SaveChanges();
            }
        }

        public List<Recipient> GetRecipients()
        {
            using (var context = new ApiContext())
            {
                return context.Recipients.ToList();
            }
        }
    }
}
