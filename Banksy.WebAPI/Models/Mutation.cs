﻿using System;

namespace Banksy.WebAPI.Models
{
    public class Mutation
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string ContraAccount { get; set; }
        public string Code { get; set; }
        public string DebitCredit { get; set; }
        public double Amount { get; set; }
        public string MutaionType { get; set; }
        public string Description { get; set; }
    }
}