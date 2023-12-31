﻿using System.ComponentModel.DataAnnotations;

namespace RestTomas.Data.Dtos.Jobs
{
    public record CreateJobDto([Required] string Title, [Required] string Description, [Required] int CenterId, [Required] int TechnicianId);
}
