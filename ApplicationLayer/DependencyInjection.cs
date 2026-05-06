using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ApplicationLayer.Common.Behaviors; // تأكد من الـ namespace الصحيح للـ Behavior بتاعك

namespace ApplicationLayer // نفس اسم البروجكت بتاعك
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // 1. تسجيل MediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // 2. تسجيل الـ Validation Behavior ليعمل مع كل الطلبات
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}