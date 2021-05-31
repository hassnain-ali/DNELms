using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System;
using System.Text.Json.Serialization;

[assembly: HostingStartup(typeof(DNELms.Areas.Api.ApiHostingStartup))]
namespace DNELms.Areas.Api
{
    public class ApiHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                //{
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidateLifetime = true,
                //        ValidateIssuerSigningKey = true,
                //        ValidIssuer = context.Configuration["Jwt:Issuer"],
                //        ValidAudience = context.Configuration["Jwt:Issuer"],
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["Jwt:Key"]))
                //    };
                //});
                // configure strongly typed settings object
                //services.AddTransient<IStartupFilter, ApiHostingConfigureFilter>();
                services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.WriteIndented = false;
                    options.JsonSerializerOptions.Converters.Add(new ObjectBoolConverter());
                });
                services.Configure<FormOptions>(o =>
                {
                    o.ValueLengthLimit = int.MaxValue;
                    o.MultipartBodyLengthLimit = int.MaxValue;
                    o.MemoryBufferThreshold = int.MaxValue;
                });
                //services.AddControllers().AddNewtonsoftJson(x =>
                //{
                //    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                //    x.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //    x.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                //});
            });
        }

    }
    //public class ApiHostingConfigureFilter : IStartupFilter
    //{
    //    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    //    {
    //        return app =>
    //        {
    //            app.UseMiddleware<JwtMiddleware>();
    //            next(app);
    //        };
    //    }
    //}
    public class ObjectBoolConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.True)
            {
                return true;
            }

            if (reader.TokenType == JsonTokenType.False)
            {
                return false;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt64(out long l))
                {
                    return l;
                }

                return reader.GetDouble();
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                if (reader.TryGetDateTime(out DateTime datetime))
                {
                    return datetime;
                }

                return reader.GetString();
            }

            // Use JsonElement as fallback.
            // Newtonsoft uses JArray or JObject.
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                return document.RootElement.Clone();
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
