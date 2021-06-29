﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.CategoryService;
using WebAPI.Services.ColorService;

namespace WebAPI.Extensions
{
    public static class ScopedExtensions
    {
        public static IServiceCollection AddScopedExtensions(this IServiceCollection services)
        {
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}