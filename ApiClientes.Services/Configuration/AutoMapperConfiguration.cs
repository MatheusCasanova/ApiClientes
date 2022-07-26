namespace ApiClientes.Services.Configuration
{
    /// <summary>
    /// Classe de configuração do automapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// método para configuração do uso do automapper
        /// </summary>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
