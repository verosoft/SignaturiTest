
using Signaturi.ApplicationService;
using Signaturi.Domain.Services;

namespace Signaturi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ITrialService, TrialService>();
            builder.Services.AddSingleton<ITrialApp, TrialApp>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var contracts = app.MapGroup("contracts");

            contracts.MapGet("/trial/{plaintiff}/{defendan}", Trial);
            contracts.MapGet("/minimun/{plaintiff}/{defendan}", Minum);


            app.Run();
        }

        private static IResult Minum(string plaintiff, string defendan, ITrialApp trialApp)
        {
            var result = trialApp.MinimumSignatureNecessaryWinTrial(plaintiff, defendan);
            return TypedResults.Ok(result);
        }

        private static IResult Trial(string plaintiff, string defendan, ITrialApp trialApp)
        {
            var result = trialApp.Trial(plaintiff, defendan);
            var name = result.Name;
            return TypedResults.Ok(name);
        }
    }
}