using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankacc.Models

{
    public class Account
    {

        public int AccountId { get; set; }
        public int Amount { get; set; }

         public List<Transaction> alltransaction { get; set;}
         [ForeignKey("Person")]
        public int PersonId { get; set;}
        public Person Person { get; set;}


    public Account()
        {
            alltransaction = new List<Transaction>();

        }

   
       
    }
}


