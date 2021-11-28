using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Data;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Recipes.Tests
{
    public class TestHelper
    {
        private static readonly Checkpoint _checkpoint;
        private static readonly IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        static TestHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            _scopeFactory = provider.GetService<IServiceScopeFactory>();
            _checkpoint = new Checkpoint();
        }

        public static Task ResetDatabase() => _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));

        public static Task Insert<T>(params T[] entities) where T : class
        {
            return ExecuteDbContext(db =>
            {
                foreach (var entity in entities)
                {
                    db.Set<T>().Add(entity);
                }
                return db.SaveChangesAsync();
            });
        }

        public static Task Insert<T>(IEnumerable<T> entities) where T : class
        {
            return ExecuteDbContext(db =>
            {
                foreach (var entity in entities)
                {
                    db.Set<T>().Add(entity);
                }
                return db.SaveChangesAsync();
            });
        }
     
        public static Task ExecuteDbContext(Func<RecipeContext, Task> action)
        {
            return ExecuteScope(sp => action(sp.GetService<RecipeContext>()));
        }

        public static Task ExecuteDbContext(Func<RecipeContext, IMediator, Task> action)
        {
            return ExecuteScope(sp => action(sp.GetService<RecipeContext>(), sp.GetService<IMediator>()));
        }

        public static Task<T> ExecuteDbContext<T>(Func<RecipeContext, Task<T>> action)
        {
            return ExecuteScope(sp => action(sp.GetService<RecipeContext>()));
        }

        public static Task<T> ExecuteDbContext<T>(Func<RecipeContext, IMediator, Task<T>> action)
        {
            return ExecuteScope(sp => action(sp.GetService<RecipeContext>(), sp.GetService<IMediator>()));
        }

        public static async Task ExecuteScope(Func<IServiceProvider, Task> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<RecipeContext>();

                try
                {
                    await action(scope.ServiceProvider).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async Task<T> ExecuteScope<T>(Func<IServiceProvider, Task<T>> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<RecipeContext>();

                try
                {
                    var result = await action(scope.ServiceProvider).ConfigureAwait(false);

                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static Task<T> Find<T>(int id) where T : Entity
        {
            return ExecuteDbContext(async db => await db.Set<T>().FindAsync(id));
        }

        public static Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScope(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public static Task Send(IRequest request)
        {
            return ExecuteScope(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

    }
}
