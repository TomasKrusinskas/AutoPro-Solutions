using System.ComponentModel.DataAnnotations;

namespace RestTomas.Data.Dtos.Centers
{
    public record CreateCenterDto([Required] string Name, [Required] string Description, string UserId);
}
