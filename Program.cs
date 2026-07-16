using Microsoft.EntityFrameworkCore;
using DevTracker.Data;
using DevTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Swagger/OpenAPI support (Great for demonstrating to employers!)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Register AppDbContext and configure it to use SQLite
// This reads the connection string we configured (or defaults to devtracker.db)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=devtracker.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// 3. Enable Swagger UI in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect root URL "/" to "/swagger" so the employer instantly sees the interactive UI
app.MapGet("/", () => Results.Redirect("/swagger"));

// ==========================================
// 🚀 API Endpoints (Minimal APIs)
// ==========================================

// GET: Retrieve all projects including their tasks
app.MapGet("/projects", async (AppDbContext db) =>
{
    var projects = await db.Projects.Include(p => p.Tasks).ToListAsync();
    return Results.Ok(projects);
});

// POST: Create a new project
app.MapPost("/projects", async (Project project, AppDbContext db) =>
{
    db.Projects.Add(project);
    await db.SaveChangesAsync();
    return Results.Created($"/projects/{project.Id}", project);
});

// POST: Add a task to a specific project
app.MapPost("/projects/{projectId:int}/tasks", async (int projectId, DevTask task, AppDbContext db) =>
{
    var project = await db.Projects.FindAsync(projectId);
    if (project == null) return Results.NotFound($"Project with ID {projectId} not found.");

    task.ProjectId = projectId;
    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    return Results.Created($"/projects/{projectId}/tasks/{task.Id}", task);
});

// DELETE: Delete a project (will cascade delete tasks due to our DbContext config!)
app.MapDelete("/projects/{id:int}", async (int id, AppDbContext db) =>
{
    var project = await db.Projects.FindAsync(id);
    if (project == null) return Results.NotFound();

    db.Projects.Remove(project);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();