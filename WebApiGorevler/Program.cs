using Microsoft.EntityFrameworkCore;
using WebApiGorevler.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cors Pilicy ile ilgili ayarlari yapmamiz gerekir.
builder.Services.AddCors(o => o.AddDefaultPolicy(p=>p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("BaglantiCumlem");
builder.Services.AddDbContext<UygulamaDbContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(cs));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.Run();

// Görev1: Web Api projesi acma ve inceleme
// Görev2: Swagger, RESTful API'lerin tasarımı, belgelendirilmesi ve kullanımını kolaylaştıran bir araç ve standarttır. Swagger, RESTful API'lerin daha iyi anlaşılmasını, hızlı entegrasyonu ve daha az belgeleme çabası gerektiren geliştirme süreçlerini destekler.

// Swagger Spec/OpenAPI Spec: Swagger, API'nin açık bir şekilde tanımlanması için bir standart olan OpenAPI Specification (eski adıyla Swagger Specification) tarafından desteklenir. Bu, API'nin endpoint'lerini, parametrelerini, yanıtlarını ve diğer önemli bilgileri tanımlayan bir JSON veya YAML belgesidir.

// Swagger UI: Swagger UI, belgelenen API'leri görsel olarak keşfetmeyi ve test etmeyi sağlayan kullanıcı arayüzüdür. Swagger Spec/OpenAPI Spec belgesini alır ve bu belgeye dayanarak interaktif bir API belgesi oluşturur.

// Swagger Editor: Swagger Editor, Swagger Spec/OpenAPI Spec belgelerini oluşturmak, düzenlemek ve görselleştirmek için bir araçtır. Geliştiricilere API belgelerini yazarken veya düzenlerken otomatik tamamlama, hata denetimi ve daha fazlasını sağlar.






