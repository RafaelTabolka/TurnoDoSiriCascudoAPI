using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using System.Text.Json.Serialization;
using TurnoDoSiriCascudo.Dominio.Comportamentos;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.ClienteRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.IngredienteRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.PedidoRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.ProdutoRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IServicoToken;
using TurnoDoSiriCascudo.Infra.CrossCutting.Extensoes.ServicoToken;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.ClienteRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.IngredienteRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.PedidoRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.ProdutoRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.UsuarioRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Obtém as configurações utilizadas na autenticação JWT.
var chaveJwt =
    builder.Configuration["Jwt:Chave"]
    ?? throw new InvalidOperationException(
        "A chave JWT não foi configurada.");

var emissorJwt =
    builder.Configuration["Jwt:Emissor"]
    ?? throw new InvalidOperationException(
        "O emissor JWT não foi configurado.");

var audienciaJwt =
    builder.Configuration["Jwt:Audiencia"]
    ?? throw new InvalidOperationException(
        "A audiência JWT não foi configurada.");

// Obtém a string utilizada para conectar ao SQL Server.
var connectionString =
    builder.Configuration.GetConnectionString(
        "TurnoDoSiriCascudoConnection")
    ?? throw new InvalidOperationException(
        "A connection string não foi configurada.");

// Adiciona suporte aos Controllers e configura a conversão para JSON.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        // Evita erros causados por referências circulares.
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;

        // Organiza o JSON retornado para facilitar sua leitura.
        options.JsonSerializerOptions.WriteIndented = true;

        // Retorna os valores dos enums como texto.
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Configura a autenticação da API utilizando JWT Bearer.
builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                // Verifica quem emitiu o token.
                ValidateIssuer = true,

                // Verifica para qual aplicação o token foi criado.
                ValidateAudience = true,

                // Verifica se o token ainda está válido.
                ValidateLifetime = true,

                // Verifica a assinatura do token.
                ValidateIssuerSigningKey = true,

                // Define o emissor esperado.
                ValidIssuer = emissorJwt,

                // Define a audiência esperada.
                ValidAudience = audienciaJwt,

                // Converte a chave configurada para uma chave de segurança.
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(chaveJwt)),

                // Define a claim "papel" como papel do usuário.
                RoleClaimType = "papel"
            };
    });

// Adiciona suporte às regras de autorização.
builder.Services.AddAuthorization();

// Registra o contexto responsável pelo acesso ao SQL Server.
builder.Services.AddDbContext<TurnoDoSiriCascudoContexto>(
    options =>
    {
        options.UseSqlServer(connectionString);

        // Exibe valores utilizados nas consultas durante o desenvolvimento.
        if (builder.Environment.IsDevelopment())
            options.EnableSensitiveDataLogging();
    });

// Registra os repositórios utilizados pelos Handlers.
builder.Services.AddScoped<
    IRepositorioCliente,
    RepositorioCliente>();

builder.Services.AddScoped<
    IRepositorioIngrediente,
    RepositorioIngrediente>();

builder.Services.AddScoped<
    IRepositorioPedido,
    RepositorioPedido>();

builder.Services.AddScoped<
    IRepositorioProduto,
    RepositorioProduto>();

builder.Services.AddScoped<
    IRepositorioUsuario,
    RepositorioUsuario>();

// Registra o serviço utilizado para gerar e validar hash de senha.
builder.Services.AddScoped<
    IPasswordHasher<Usuario>,
    PasswordHasher<Usuario>>();

// Registra o serviço responsável pela geração do token JWT.
builder.Services.AddScoped<
    IServicoToken,
    ServicoToken>();

// Obtém o caminho físico da pasta pública wwwroot.
//var caminhoRaizImagens =
//    builder.Environment.WebRootPath
//    ?? Path.Combine(
//        builder.Environment.ContentRootPath,
//        "wwwroot");

// Registra o serviço responsável por armazenar as imagens.
//builder.Services.AddScoped<IArmazenamentoImagem>(_ =>
//    new ArmazenamentoImagem(caminhoRaizImagens));

// Obtém a camada onde estão os handlers e validators.
var assemblyDominio =
    typeof(ValidacaoBehavior<,>).Assembly;

// Localiza e registra os validators da camada Dominio.
builder.Services.AddValidatorsFromAssembly(
    assemblyDominio,
    includeInternalTypes: true);

// Registra os handlers e o comportamento de validação.
builder.Services.AddMediatR(configuration =>
{
    // Localiza e registra os handlers.
    configuration.RegisterServicesFromAssembly(
        assemblyDominio);

    // Faz todas as requests passarem pela validação.
    configuration.AddOpenBehavior(
        typeof(ValidacaoBehavior<,>));
});

// Permite que o Swagger encontre os endpoints da API.
builder.Services.AddEndpointsApiExplorer();

// Configura a documentação e os testes pelo Swagger.
builder.Services.AddSwaggerGen(options =>
{
    // Informa ao Swagger que a API utiliza JWT Bearer.
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Informe somente o token JWT.",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

    // Faz o Swagger enviar o token nas requisições protegidas.
    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference(
                    "Bearer",
                    document)
            ] = []
        });
});

// Constrói a aplicação com as configurações anteriores.
var app = builder.Build();

// Gera o documento utilizado pelo Swagger.
app.UseSwagger();

// Disponibiliza a interface visual do Swagger.
app.UseSwaggerUI();

// Redireciona requisições HTTP para HTTPS.
app.UseHttpsRedirection();

// Disponibiliza publicamente os arquivos da pasta wwwroot.
//app.UseStaticFiles();

// Lê e valida o token JWT enviado na requisição.
app.UseAuthentication();

// Verifica se o usuário possui autorização para acessar a rota.
app.UseAuthorization();

// Mapeia as rotas definidas nos Controllers.
app.MapControllers();

// Inicia a aplicação e começa a receber requisições.
app.Run();