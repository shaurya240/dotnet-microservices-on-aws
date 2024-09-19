using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Healthstatus
{
    [Table("status", Schema = "public")]
    public class HealthStatusEntity
    {
        public long Id { get; set; }
        [Column("timestamp")] public DateTime Timestamp { get; set; }
    }
}