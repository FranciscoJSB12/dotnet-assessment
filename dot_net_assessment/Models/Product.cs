﻿namespace dot_net_assessment.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Faulty { get; set; }

        public bool Dispatched { get; set; }

        public Guid ManufacturingProcessId { get; set; }

        public ManufacturingProcess ManufacturingProcess { get; set; }
    }
}
