using System;

namespace DriverLog.Services.Drivers.Contracts.Dtos
{
    public class GetDriverDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int LogsCount { get; set; }
    }
}
