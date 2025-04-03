using Inventario.interfaces;
using Inventario.interfaces.IPrecioProducto;
using Inventario.models.PrecioProducto;
using Inventario.Utils;

namespace Inventario.services
{
    public class PrecioProductoService : IPrecioProductoService
    {
        private readonly IPrecioProductoRepository _repository;
        private readonly IAsignaciones _AsinacionesService;
        public PrecioProductoService(IPrecioProductoRepository repository, IAsignaciones asignacionesService)
        {
            _repository = repository;
            _AsinacionesService = asignacionesService;
        }

        public async Task<IEnumerable<PrecioProductoDto>> GetAllPrecioProductoByIdProducto(string id)
        {

            var precioProductos = await _repository.GetAllPrecioProductoByIdProducto(id);
            if (precioProductos == null)
            {
                throw new KeyNotFoundException("Lista de precios Vacia.");
            }
            var preciosDto = precioProductos.Select(e => new PrecioProductoDto
            {
                Id = e.Id!,
                PrecioCompra = e.PrecioCompra,
                PrecioVenta = e.PrecioVenta,
                FechaFin = e.FechaFin,
                FechaInicio = e.FechaInicio,
                Producto_id = e.Producto_id,
                Producto = e.Producto?.Nombre ?? ""
            });

            return preciosDto;
        }

        public async Task<PrecioProductoDto> GetActualPrecioProductoByIdProducto(string id)
        {
            var precioProducto = await _repository.GetActualPrecioProductoByIdProducto(id);
            if (precioProducto == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var precioProductoDto = new PrecioProductoDto
            {
                Id = precioProducto.Id!,
                PrecioCompra = precioProducto.PrecioCompra,
                PrecioVenta = precioProducto.PrecioVenta,
                FechaFin = precioProducto.FechaFin,
                FechaInicio = precioProducto.FechaInicio,
                Producto_id = precioProducto.Producto_id,
                Producto = precioProducto.Producto?.Nombre ?? ""
            };

            return precioProductoDto;
        }
        public async Task<PrecioProductoDto> GetPrecioProductoByIdProductoById(string id)
        {
            var precioProducto = await _repository.GetPrecioProductoByIdProductoById(id);
            if (precioProducto == null)
            {
                throw new KeyNotFoundException("precio No encontrado.");

            }
            var precioProductoDto = new PrecioProductoDto
            {
                Id = precioProducto.Id!,
                PrecioCompra = precioProducto.PrecioCompra,
                PrecioVenta = precioProducto.PrecioVenta,
                FechaFin = precioProducto.FechaFin,
                FechaInicio = precioProducto.FechaInicio,
                Producto_id = precioProducto.Producto_id,
                Producto = precioProducto.Producto?.Nombre ?? ""
            };

            return precioProductoDto;
        }

        public async Task<PrecioProductoDto> PostPrecioProducto(PrecioProductos precioProducto)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var precioProductoExist = await _repository.GetActualPrecioProductoByIdProducto(precioProducto.Producto_id!);
            if (precioProductoExist != null)
            {
                precioProductoExist.FechaFin = _AsinacionesService.GetCurrentDateTime();
                precioProductoExist.updated_at = _AsinacionesService.GetCurrentDateTime();
                precioProducto.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
                await _repository.PutPrecioProducto(precioProductoExist);
            }
            precioProducto.Id = _AsinacionesService.GenerateNewId();
            precioProducto.updated_at = _AsinacionesService.GetCurrentDateTime();
            precioProducto.created_at = _AsinacionesService.GetCurrentDateTime();
            precioProducto.FechaInicio = _AsinacionesService.GetCurrentDateTime();
            precioProducto.adicionado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            precioProducto.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            await _repository.PostPrecioProducto(precioProducto);

            var categoriaDto = new PrecioProductoDto
            {
                Id = precioProducto.Id!,
                PrecioCompra = precioProducto.PrecioCompra,
                PrecioVenta = precioProducto.PrecioVenta,
                FechaFin = precioProducto.FechaFin,
                FechaInicio = precioProducto.FechaInicio,
                Producto_id = precioProducto.Producto_id,
                Producto = precioProducto.Producto?.Nombre ?? ""
            };
            return categoriaDto;
        }

        public async Task<PrecioProductoDto> PutPrecioProducto(string id, PrecioProductos precioProducto)
        {
            var precioProductoFound = await _repository.GetPrecioProductoByIdProductoById(id);

            if (precioProductoFound == null)
            {
                throw new KeyNotFoundException("Precio no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            precioProductoFound.ActualizarPropiedades(precioProducto);
            precioProductoFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            precioProductoFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _repository.PutPrecioProducto(precioProductoFound);
            return new PrecioProductoDto
            {
                Id = precioProducto.Id!,
                PrecioCompra = precioProducto.PrecioCompra,
                PrecioVenta = precioProducto.PrecioVenta,
                FechaFin = precioProducto.FechaFin,
                FechaInicio = precioProducto.FechaInicio,
                Producto_id = precioProducto.Producto_id,
                Producto = precioProducto.Producto?.Nombre ?? ""
            };
        }
        public async Task<PrecioProductoDto> UpdatePrecioProducto(string id, PrecioProductos precioProducto)
        {
            var precioProductoFound = await _repository.GetPrecioProductoByIdProductoById(id);

            if (precioProductoFound == null)
            {
                throw new KeyNotFoundException("Precio no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            precioProductoFound.ActualizarPropiedades(precioProducto);
            precioProducto.FechaFin = _AsinacionesService.GetCurrentDateTime();
            precioProductoFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            precioProductoFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _repository.UpdatePrecioProducto(precioProductoFound);
            return new PrecioProductoDto
            {
                Id = precioProducto.Id!,
                PrecioCompra = precioProducto.PrecioCompra,
                PrecioVenta = precioProducto.PrecioVenta,
                FechaFin = precioProducto.FechaFin,
                FechaInicio = precioProducto.FechaInicio,
                Producto_id = precioProducto.Producto_id,
                Producto = precioProducto.Producto?.Nombre ?? ""
            };
        }
    }
}
