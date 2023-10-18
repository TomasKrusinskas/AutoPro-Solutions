using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTomas.Data.Dtos.Jobs
{
    public record JobDto(int Id, string Title, string Description);
}
