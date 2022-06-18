using System;

namespace DriverLog.Entities
{
    public class DriveLog
    {
        public int Id { get; set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
