using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Domain.DtoModels
{
    public class ExperimentResultDto
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public string? Value { get; set; }
        public string? Key { get; set; }
        public Guid ExperimentId { get; set; }
    }
}
