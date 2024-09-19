using System;

namespace Model
{
    public class Policy
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Holder { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}