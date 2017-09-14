using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class CardStatusDataAccessHelper
    {
        /// <summary>
        /// Gets all active card types.
        /// </summary>
        /// <returns>list of card types</returns>
        public int GetPendingCardStatusId()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                var cardStatuses = dbContext.CardStatuses.Where(n => n.IsActive).ToList();
                if (cardStatuses == null)
                {
                    return 0;
                }
                var cardStatus = cardStatuses.Where(x => x.Name == "Pending").FirstOrDefault();
                return cardStatus != null ? cardStatus.CardStatusId : 0;
            }
        }
    }
}
