using Microsoft.EntityFrameworkCore;
using ParcelTrackingManager.Data;
using ParcelTrackingManager.Models;
using ParcelTrackingManager.DTO;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core In-Memory database
builder.Services.AddDbContext<ParcelContext>(options =>
    options.UseInMemoryDatabase("ParcelDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Seed test parcel mockup data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ParcelContext>();
    SeedData(context);
}

void SeedData(ParcelContext context)
{
    var parcels = new List<Parcel>
{
    new Parcel {
        Id = 1,
        TrackingNumber = "LT1234567890",
        Sender = new Person { Name = "Jonas Petrauskas", Address = "Vilniaus g. 10, Vilnius, LT-01119", Phone = "+37061234567" },
        Recipient = new Person { Name = "Agnė Žukauskaitė", Address = "Kauno g. 5, Kaunas, LT-44296", Phone = "+37069876543" },
        Status = "Created",
        CreatedAt = DateTime.Parse("2025-08-28T10:15:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Created", Timestamp = DateTime.Parse("2025-08-28T10:15:00Z") }
        }
    },
    new Parcel {
        Id = 2,
        TrackingNumber = "LT9876543210",
        Sender = new Person { Name = "Mantas Jankauskas", Address = "Gedimino pr. 22, Vilnius, LT-01103", Phone = "+37061122334" },
        Recipient = new Person { Name = "Eglė Stankevičiūtė", Address = "Taikos pr. 45, Klaipėda, LT-91149", Phone = "+37069911223" },
        Status = "Sent",
        CreatedAt = DateTime.Parse("2025-08-29T09:00:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Sent", Timestamp = DateTime.Parse("2025-08-29T09:00:00Z") }
        }
    },
    new Parcel {
        Id = 3,
        TrackingNumber = "LT4567891230",
        Sender = new Person { Name = "Rasa Vaitkutė", Address = "Savanorių pr. 100, Kaunas, LT-44147", Phone = "+37061233445" },
        Recipient = new Person { Name = "Tomas Žilinskas", Address = "Aušros al. 15, Šiauliai, LT-76288", Phone = "+37069877665" },
        Status = "Accepted",
        CreatedAt = DateTime.Parse("2025-08-30T14:30:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Accepted", Timestamp = DateTime.Parse("2025-08-30T14:30:00Z") }
        }
    },
    new Parcel {
        Id = 4,
        TrackingNumber = "LT3216549870",
        Sender = new Person { Name = "Ieva Grigaitė", Address = "Laisvės al. 5, Kaunas, LT-44304", Phone = "+37060012345" },
        Recipient = new Person { Name = "Dainius Kavaliauskas", Address = "Tilto g. 8, Vilnius, LT-01101", Phone = "+37069899887" },
        Status = "Returned",
        CreatedAt = DateTime.Parse("2025-08-25T08:45:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Returned", Timestamp = DateTime.Parse("2025-08-25T08:45:00Z") }
        }
    },
    new Parcel {
        Id = 5,
        TrackingNumber = "LT7418529630",
        Sender = new Person { Name = "Laura Šimkutė", Address = "Žalgirio g. 90, Vilnius, LT-09303", Phone = "+37061299887" },
        Recipient = new Person { Name = "Karolis Dambrauskas", Address = "Vytauto g. 12, Panevėžys, LT-35186", Phone = "+37069933445" },
        Status = "Canceled",
        CreatedAt = DateTime.Parse("2025-08-31T11:00:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Canceled", Timestamp = DateTime.Parse("2025-08-31T11:00:00Z") }
        }
    },
    new Parcel {
        Id = 6,
        TrackingNumber = "LT8529637410",
        Sender = new Person { Name = "Simonas Petrauskas", Address = "Naugarduko g. 24, Vilnius, LT-03225", Phone = "+37061144556" },
        Recipient = new Person { Name = "Monika Jurevičiūtė", Address = "J. Basanavičiaus g. 3, Marijampolė, LT-68309", Phone = "+37069811223" },
        Status = "Sent",
        CreatedAt = DateTime.Parse("2025-08-27T16:20:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Sent", Timestamp = DateTime.Parse("2025-08-27T16:20:00Z") }
        }
    },
    new Parcel {
        Id = 7,
        TrackingNumber = "LT1597534862",
        Sender = new Person { Name = "Greta Kazlauskaitė", Address = "Šv. Stepono g. 7, Vilnius, LT-01138", Phone = "+37061277665" },
        Recipient = new Person { Name = "Mindaugas Žukauskas", Address = "Kęstučio g. 18, Telšiai, LT-87120", Phone = "+37069988776" },
        Status = "Accepted",
        CreatedAt = DateTime.Parse("2025-08-30T13:15:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Accepted", Timestamp = DateTime.Parse("2025-08-30T13:15:00Z") }
        }
    },
    new Parcel {
        Id = 8,
        TrackingNumber = "LT3692581470",
        Sender = new Person { Name = "Dovilė Petrauskienė", Address = "Pylimo g. 17, Vilnius, LT-01141", Phone = "+37060099887" },
        Recipient = new Person { Name = "Rokas Jankauskas", Address = "Respublikos g. 2, Utena, LT-28199", Phone = "+37069822334" },
        Status = "Created",
        CreatedAt = DateTime.Parse("2025-08-31T10:30:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Created", Timestamp = DateTime.Parse("2025-08-31T10:30:00Z") }
        }
    },
    new Parcel {
        Id = 9,
        TrackingNumber = "LT9638527410",
        Sender = new Person { Name = "Aistė Žilinskaitė", Address = "Kalvarijų g. 125, Vilnius, LT-08221", Phone = "+37061233456" },
        Recipient = new Person { Name = "Vilius Stankevičius", Address = "J. Janonio g. 4, Biržai, LT-41148", Phone = "+37069944556" },
        Status = "Returned",
        CreatedAt = DateTime.Parse("2025-08-29T17:00:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Returned", Timestamp = DateTime.Parse("2025-08-29T17:00:00Z") }
        }
    },
    new Parcel {
        Id = 10,
        TrackingNumber = "LT7419638520",
        Sender = new Person { Name = "Neringa Vaitkutė", Address = "Antakalnio g. 60, Vilnius, LT-10300", Phone = "+37061199887" },
        Recipient = new Person { Name = "Paulius Grigaitis", Address = "Vytauto g. 20, Alytus, LT-62112", Phone = "+37069877654" },
        Status = "Canceled",
        CreatedAt = DateTime.Parse("2025-08-26T12:00:00Z"),
        StatusHistory = new List<StatusEntry> {
            new StatusEntry { Status = "Canceled", Timestamp = DateTime.Parse("2025-08-26T12:00:00Z") }
        }
    }
};


    context.Parcels.AddRange(parcels);
    context.SaveChanges();
}

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get all parcels.
app.MapGet("/api/parcels", async (ParcelContext db) =>
    await db.Parcels
        .Select(p => new
        {
            p.Id,
            p.TrackingNumber,
            SenderName = p.Sender.Name,
            RecipientName = p.Recipient.Name,
            p.Status,
            p.CreatedAt,
        })
        .ToListAsync()
).WithName("GetParcels");

// Get parcel by id
app.MapGet("/api/parcels/{id}", async (int id, ParcelContext db) =>
{
    var parcel = await db.Parcels
        .Include(p => p.StatusHistory) // Optional: only if you track status changes
        .FirstOrDefaultAsync(p => p.Id == id);

    if (parcel == null)
        return Results.NotFound(new { error = "Parcel not found" });

    return Results.Ok(new
    {
        parcel.Id,
        parcel.TrackingNumber,
        parcel.Status,
        parcel.CreatedAt,
        parcel.UpdatedAt,
        SenderName = parcel.Sender.Name,
        SenderPhone = parcel.Sender.Phone,
        SenderAddress = parcel.Sender.Address,
        RecipientName = parcel.Recipient.Name,
        RecipientPhone = parcel.Recipient.Phone,
        RecipientAddress = parcel.Recipient.Address,
        StatusHistory = parcel.StatusHistory.Select(h => new
        {
            h.Status,
            h.Timestamp
        })
    });
});


// Create new parcel.
app.MapPost("/api/parcels/createParcel", async (ParcelDto parcelDto, ParcelContext db) =>
{
    var sender = new Person
    {
        Name = parcelDto.SenderName,
        Phone = parcelDto.SenderPhone,
        Address = parcelDto.SenderAddress
    };

    var recipient = new Person
    {
        Name = parcelDto.RecipientName,
        Phone = parcelDto.RecipientPhone,
        Address = parcelDto.RecipientAddress
    };

    var parcel = new Parcel
    {
        TrackingNumber = parcelDto.TrackingNumber,
        Status = "Created",
        Sender = sender,
        Recipient = recipient,
        CreatedAt = DateTime.UtcNow,
        StatusHistory = new List<StatusEntry>
        {
            new StatusEntry
            {
                Status = "Created",
                Timestamp = DateTime.UtcNow
            }
        }
    };

    db.Parcels.Add(parcel);
    await db.SaveChangesAsync();

    return Results.Ok($"Parcel {parcel.TrackingNumber} created successfully");
});

// Update package status and record status entry.
app.MapPut("/api/parcels/{id}/status", async (int id, StatusUpdateDto dto, ParcelContext db) =>
{
    var parcel = await db.Parcels.FindAsync(id);
    if (parcel == null)
        return Results.NotFound("Parcel not found");

    // Create and save status history entry
    var statusEntry = new StatusEntry
    {
        ParcelId = parcel.Id,
        Status = dto.NewStatus,
        Timestamp = DateTime.UtcNow
    };
    db.StatusEntries.Add(statusEntry);

    // Update current status
    parcel.Status = dto.NewStatus;
    await db.SaveChangesAsync();

    return Results.Ok(new { message = $"Parcel {parcel.TrackingNumber} status updated to {dto.NewStatus}" });
});


app.UseCors("AllowReactApp");

app.Run();

