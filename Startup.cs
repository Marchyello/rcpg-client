using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Core;
using Rcpg;
using RcpgMicroserviceClient.Entities;
using RcpgMicroserviceClient.Services;

namespace RcpgMicroserviceClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<RcpgClientDbContext>(
                builder => builder.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            // Create Channel instance with configuration.
            var grpcChannel = new Channel("localhost", 50051, ChannelCredentials.Insecure);

            // Make Channel and RcpgClient instances persist between requests.
            services.AddSingleton<Channel>(grpcChannel);
            services.AddSingleton<IRcpgClient, RcpgClient>();
            services.AddSingleton<IKafkaClient, KafkaClient>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Rcpg/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Rcpg}/{action=Index}/{id?}");
            });
        }
    }
}
