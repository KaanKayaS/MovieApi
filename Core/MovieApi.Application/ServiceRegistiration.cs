﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.AutoMapper;
using MovieApi.Application.Beheviors;
using MovieApi.Application.Features.Validator;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Application.Exceptions;
using MovieApi.Application.Features.Rules;

namespace MovieApi.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateMovieCommandValidator>();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient<MovieRules>();
            services.AddTransient<AuthRules>();
            services.AddTransient<RefreshTokenRules>();
            services.AddTransient<SeriesRules>();
            services.AddTransient<CommentRules>();

        }
    }
}
