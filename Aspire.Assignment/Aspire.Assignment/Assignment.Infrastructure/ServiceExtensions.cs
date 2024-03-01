using Assignment.Contracts.Data;
using Assignment.Core.Data;
using Assignment.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Assignment.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Net.Mail;
using System.Net;

namespace Assignment.Infrastructure
{
    public static class ServiceExtensions
    {
        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
             return services.AddSqlServer<DatabaseContext>(configuration.GetConnectionString("DefaultConnection"), (options) =>
            {
                options.MigrationsAssembly("Assignment.Migrations");
            });
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            return services.AddDatabaseContext(configuration).AddUnitOfWork();
        }

        private static string randomCode="000000";
     static public string sendEmail(string to)
    {
      string from, pass, messageBody;
      Random rand = new Random();
      randomCode = (rand.Next(999999)).ToString();
      MailMessage message = new MailMessage();
      from = "srisaichocolates@gmail.com";
      pass = "saydadjncyknxudg";
      messageBody = "Your Verification Code is " + randomCode;
      message.To.Add(new MailAddress(to));
      message.From = new MailAddress(from);
      message.Body = messageBody;
      message.Subject = "password code";
      SmtpClient smtp = new SmtpClient("smtp.gmail.com");
      smtp.EnableSsl = true;
      smtp.Port = 587;
      smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtp.Credentials = new NetworkCredential(from, pass);
      smtp.Send(message);
      return "sent";
    }
    }
}
