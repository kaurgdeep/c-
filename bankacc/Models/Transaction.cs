using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankacc.Models

{
    public class Transaction
    {

        public int TransactionId { get; set; }
        public int CurrentBalance { get; set; }
        public int Deposit { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Account")]
        public int AccountId {get; set;}
        public Account Accounts {get; set;}

    public Transaction()
        {
            Date = DateTime.Now;

        }

       
    }
}