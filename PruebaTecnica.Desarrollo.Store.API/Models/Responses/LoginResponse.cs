﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Models.Responses
{
    public class LoginResponse
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}


