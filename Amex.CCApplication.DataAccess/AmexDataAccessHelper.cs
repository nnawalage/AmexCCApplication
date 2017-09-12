using Amex.CCA.DataAccess.Entities;
using System.Data.Entity;

namespace Amex.CCA.DataAccess
{
    public class AmexDataAccessHelper
    {


        /// <summary>
        /// Adds the credit card to the database.
        /// </summary>
        /// <param name="creditCard">credit card instance.</param>
        /// <returns></returns>
        public bool AddCreditCard(CreditCard creditCard)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                dbContext.CreditCards.Add(creditCard);
                return dbContext.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Updates the credit card.
        /// </summary>
        /// <param name="creditCard">credit card instance.</param>
        /// <returns></returns>
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                //if detached attach again
                if (dbContext.Entry(creditCard).State == EntityState.Detached)
                {
                    dbContext.CreditCards.Attach(creditCard);
                }
                //change entity state to modified
                dbContext.Entry(creditCard).State = EntityState.Modified;
                return dbContext.SaveChanges() == 1;
            }
        }

    }
}
