using System;

namespace DriverLog.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
