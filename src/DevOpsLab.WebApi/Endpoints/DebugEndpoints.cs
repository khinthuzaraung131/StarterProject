using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;

namespace DevOpsLab.WebApi.Endpoints;

public static class DebugEndpoints
{
    public static IEndpointRouteBuilder MapDebugEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/debug/search", async (string query, string connectionString) =>
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            // Vulnerable: SQL query built directly from user-controlled input
            command.CommandText = "SELECT * FROM Products WHERE Name LIKE '%" + query + "%'";
            using var reader = await command.ExecuteReaderAsync();
            return Results.Ok("Search executed");
        });
        return app;
    }
}