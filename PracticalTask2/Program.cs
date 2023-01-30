using Microsoft.Extensions.Options;
using PracticalTask2;
using PracticalTask2.Entities;
using PracticalTask2.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IRecipientService, RecipientService>();

var app = builder.Build();

AddInitialData();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddInitialData()
{
    using (var context = new ApiContext())
    {
        var recipients = new List<Recipient>
                {
                    new Recipient
                    {
                        Id = 0,
                        Name = "John Doe",
                        Address = "Something st. 1",
                        Packages= new List<Package>
                        {
                            new Package { Name = "Test 1", Description = "Qwe qwe", LastUpdated = DateTime.Now,
                                Status = "DELIVERED", PackageIdentifier = "What is it", RecipientId = 1},
                            new Package { Name = "Test 2", Description = "Asd asd", LastUpdated = DateTime.Parse("2022-11-12"),
                                Status = "RECEIVED", PackageIdentifier = "something", RecipientId = 1},
                            new Package { Name = "Test 3", Description = "Zxc Zxc", LastUpdated = DateTime.Now.AddDays(10),
                                Status = "DELIVERED", PackageIdentifier = "identifier", RecipientId = 1}
                        }
                    },
                    new Recipient
                    {
                        Id = 0,
                        Name = "Qwe Rty",
                        Address = "Test Test 123"
                    }
                };

        context.Recipients.AddRange(recipients);
        context.SaveChanges();
    }
}
