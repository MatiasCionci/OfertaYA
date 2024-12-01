
using SuperOferta.Data;

namespace SuperOferta.Models
{
    public class ProcesoAutomatizado : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
  

        public ProcesoAutomatizado(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                {



                    using var scope = _serviceProvider.CreateScope();


                    var productoService = scope.ServiceProvider.GetRequiredService<ProductoService>();


               await productoService.EliminarProductosVencidos();







                 await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Corre cada 24 horas
                }
            }
        }
    }
  }

