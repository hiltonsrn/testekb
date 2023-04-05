
using Kanban.API;
using Kanban.Application.Interfaces;
using Kanban.Application.Services;
using Kanban.Domain.Interfaces.Repository;
using Kanban.Domain.Interfaces.Services;
using Kanban.Domain.Interfaces;
using Kanban.Domain.Services;
using Kanban.Infra.Data.Repository;
using Microsoft.AspNetCore;
using Kanban.Infra.Data.Mapping;
using Kanban.Domain.Entities;
using Kanban.Application.DTO;
using AutoMapper;
using Kanban.Application;
using Kanban.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var corsBuilder = new CorsPolicyBuilder();
corsBuilder.AllowAnyHeader();
corsBuilder.AllowAnyMethod();
corsBuilder.AllowAnyOrigin(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
});
builder.Services.AddDbContext<KanbanContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("kanban")));

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntities()));
builder.Services.AddScoped(typeof(IApp<,>), typeof(App<,>));
builder.Services.AddScoped<IBoardApp, BoardApp>();

//Domínio
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IBoardService, BoardService>();

//Repositorio
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("SiteCorsPolicy");
app.Run();
