using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestTomas.Data.Dtos.Techninians
{
    public record CreateTechninianDto([Required] string Name, [Required] string Specialization);
}
