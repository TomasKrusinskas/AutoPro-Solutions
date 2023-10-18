using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestTomas.Data.Dtos.Jobs
{
    public record CreateJobDto([Required] string Title, [Required] string Description);
}
