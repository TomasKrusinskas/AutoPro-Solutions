using System.ComponentModel.DataAnnotations;

namespace RestTomas.Data.Dtos.Centers
{
    public record UpdateCenterDto([Required] string Name,string Description);
}
