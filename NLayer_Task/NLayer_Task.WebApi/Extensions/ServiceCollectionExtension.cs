using System.Text.Json.Serialization;

namespace NLayer_Task.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddService(this IServiceCollection service) 
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            service.AddSwaggerGen();
        }
    }
}
