using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class CreditCardDataAccessHelper
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

        public IQueryable GetAllCreditCards(string email)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.CreditCards
                    .Include(c => c.CardStatus)
                    .Include(c => c.CardType)
                    .Include(c => c.Nationality);                          
            }
        }

        public CreditCard GetCreditCardById(int id)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.CreditCards
                    .Include(c => c.CardStatus)
                    .Include(c => c.CardType)
                    .Include(c => c.Nationality).FirstOrDefault(x => x.CreditCardId == id);
            }
        }
    }
}