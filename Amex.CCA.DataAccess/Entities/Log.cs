namespace Amex.CCA.DataAccess.Entities
{
    public class Log : AmexModelBase
    {
        public int LogId { get; set; }

        public string Action { get; set; }

        public string Comment { get; set; }

        public int CreditCardId { get; set; }

        public virtual CreditCard CreditCard { get; set; }
    }
}