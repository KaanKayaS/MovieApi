﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Interfaces.Events
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message) where T : class;
    }
}
