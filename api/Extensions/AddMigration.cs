using api.Context;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class AddMigration
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if(db.Database.GetPendingMigrations().Count() > 0)
                {
                    db.Database.Migrate();
                }
            }
        return app;
        }
    }
}
