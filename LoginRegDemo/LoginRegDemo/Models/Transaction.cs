
using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class Transaction
    {
        
        public int TransactionId {get; set;}

        public double Amount {get; set;}
        public DateTime Date {get; set;}

        public int AccountId {get; set;}

        public Transaction() {
            Date = DateTime.Now;


        }
    }

}