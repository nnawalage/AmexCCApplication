using Amex.CCA.Common.Enums;
using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class CardStatusDataAccessHelper
    {
        /// <summary>
        /// Gets all active card types.
        /// </summary>
        /// <returns>list of card types</returns>
        public int GetPendingCardStatusId(Enums.CardStatusEnum cardStatus)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                var cardStatuses = dbContext.CardStatuses.Where(n => n.IsActive).ToList();
                if (cardStatuses == null)
                {
                    return 0;
                }
                var test = cardStatus.GetType().ToString();
                var selectedCardStatus = cardStatuses.Where(x => x.Name == cardStatus.GetType().ToString()).FirstOrDefault();
                return selectedCardStatus != null ? selectedCardStatus.CardStatusId : 0;
            }
        }
    }
}