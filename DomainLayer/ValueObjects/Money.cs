using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; set; }
        public string Currency {  get; set; }

        public Money(decimal amount, string currency = "EGP")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative", nameof(amount));

            Amount = amount;                    // بنحط القيمة بعد التحقق
            Currency = currency?.ToUpper() ?? "EGP";
        }

        public static Money Zero => new(0m);

        // Override للـ ToString عشان لما تطبعي Money يطلع شكل جميل
        public override string ToString() => $"{Amount} {Currency}";

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add different currencies");
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Multiply(decimal multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public bool IsZero => Amount == 0;


    }
}
