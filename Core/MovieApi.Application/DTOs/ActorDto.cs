﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.DTOs
{
    public class ActorDto
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
    }
}
