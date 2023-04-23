using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Domain.DbModels
{
    public class Experiment
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
