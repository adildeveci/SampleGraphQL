using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using SampleGraphQL;
using SampleGraphQL.GraphQL.Types;
using SampleGraphQL.GraphQL;
using GraphQL.SystemTextJson;
using SampleGraphQL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddSingleton<MovieContext>();

builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddSingleton<IGraphQLSerializer, GraphQLSerializer>();
builder.Services.AddSingleton<IGraphQLTextSerializer, GraphQLSerializer>();

//type
builder.Services.AddSingleton<MovieType>();
builder.Services.AddSingleton<GenreType>();
builder.Services.AddSingleton<PersonType>();
builder.Services.AddSingleton<CountryType>(); 
builder.Services.AddSingleton<MovieFilterType>();
builder.Services.AddSingleton<RangeFilterInputType<int>>();
builder.Services.AddSingleton<RangeFilterInputType<decimal>>();


builder.Services.AddSingleton<MovieQuery>();



builder.Services.AddSingleton<ISchema, MovieSchema>();

builder.Services.AddControllersWithViews();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<MovieSchema>()  // schema   
    .AddSystemTextJson());   // serializer 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseGraphQL("/graphql");  
app.UseGraphQLAltair();
app.UseGraphQLGraphiQL();
app.UseGraphQLPlayground();
app.UseGraphQLVoyager();

//app.MapGraphQL();
app.MapControllers();
 
app.Run();
