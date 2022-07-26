using ApiClientes.Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Configurando os controllers da aplica��o
builder.Services.AddControllers();

//Adicionando a configura��o do swagger
SwaggerConfiguration.AddSwagger(builder);

//Adicionando a configura��o do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionando a configura��o do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

builder.Services.AddCors(
    s => s.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    })
);
    
//Add services to the container
var app = builder.Build();

//Habilitar as rotas e endpoints da api
app.UseRouting();

//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
