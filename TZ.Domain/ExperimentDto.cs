using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Domain
{
    public class ExperimentDto
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public string Value { get; set; }
        public string Key = "button_color";
    }
}
