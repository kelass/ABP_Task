using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;

namespace TZ.Domain.ViewModels
{
    public class ExperimentsViewModel
    {
       public List<ExperimentResult> Experiments { get; set; }
        public ExperimentsViewModel()
        {
            
        }
    }
}
