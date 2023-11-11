﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace RestTomas.Data.Dtos.Auth
{
    public record RegisterUserDto([Required] string UserName, [EmailAddress] [Required] string Email,
        [Required] string Password);
}
