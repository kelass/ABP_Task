using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;

namespace TZ.Data.Configuration
{
    public class ExperimentConfiguration:IEntityTypeConfiguration<Experiment>
    {
        public void Configure(EntityTypeBuilder<Experiment> builder)
        {
            builder.HasData(new Experiment[]
            {
                 new Experiment{Id=new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"),Name="price"},
                 new Experiment{Id=new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"),Name="button_color"}
            });
        }
    }
}
