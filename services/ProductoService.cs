using Inventario.interfaces;
using Inventario.interfaces.IProducto;
using Inventario.models.Categoria;
using Inventario.models.Producto;
using Inventario.Utils;

namespace Inventario.services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IAsignaciones _AsinacionesService;

        public ProductoService(IProductoRepository productoRepository, IAsignaciones asignacionesService)
        {
            _productoRepository = productoRepository;
            _AsinacionesService = asignacionesService;
        }

        public async Task<IEnumerable<ProductoDto>> GetProductos()
        {

            var productos = await _productoRepository.GetProductos();
            if (productos == null)
            {
                throw new KeyNotFoundException("Lista de productos Vacia.");
            }
            var productoDto = productos.Select(e => new ProductoDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? "",
                Sku = e.Sku,
                Marca = e.Marca?.Nombre ?? "",
                Categoria = e.Categoria?.Nombre ?? "",
                UnidadMedida = e.UnidadMedida?.Nombre ?? "",
            });

            return productoDto;
        }
        public async Task<IEnumerable<ProductoDto>> GetProductosByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var productos = await _productoRepository.GetProductosByEmpresaId(empresaId);
            if (productos == null)
            {
                throw new KeyNotFoundException("Lista de productos Vacia.");

            }
            var productoDto = productos.Select(e => new ProductoDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? "",
                Marca = e.Marca?.Nombre ?? "",
                Sku = e.Sku,
                Categoria = e.Categoria?.Nombre ?? "",
                UnidadMedida = e.UnidadMedida?.Nombre ?? "",
            });

            return productoDto;
        }
        public async Task<IEnumerable<ProductoDto>> GetProductosActivasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var productos = await _productoRepository.GetProductosActivasByEmpresaId(empresaId);
            if (productos == null)
            {
                throw new KeyNotFoundException("Lista de productos Vacia.");

            }
            var productoDto = productos.Select(e => new ProductoDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Sku = e.Sku,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? "",
                Marca = e.Marca?.Nombre ?? "",
                Categoria = e.Categoria?.Nombre ?? "",
                UnidadMedida = e.UnidadMedida?.Nombre ?? "",
            });

            return productoDto;
        }
        public async Task<IEnumerable<ProductoDto>> GetProductosActivas()
        {
            var productos = await _productoRepository.GetProductosActivas();
            if (productos == null)
            {
                throw new KeyNotFoundException("Lista de productos Vacia.");

            }
            var productoDto = productos.Select(e => new ProductoDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Sku = e.Sku,
                Empresa = e.Empresa?.nombre ?? "",
                Marca = e.Marca?.Nombre ?? "",
                Categoria = e.Categoria?.Nombre ?? "",
                UnidadMedida = e.UnidadMedida?.Nombre ?? "",
            });

            return productoDto;
        }
        public async Task<ProductoDto> GetProductosById(string id)
        {
            var producto = await _productoRepository.GetProductosById(id);
            if (producto == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var productoDto = new ProductoDto
            {
                Id = producto.Id!,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Activo = producto.activo,
                Empresa = producto.Empresa?.nombre ?? "",
                Sku = producto.Sku,
                Marca = producto.Marca?.Nombre ?? "",
                Categoria = producto.Categoria?.Nombre ?? "",
                UnidadMedida = producto.UnidadMedida?.Nombre ?? "",
            };

            return productoDto;
        }
        public async Task<ProductoDto> GetProductosByIdAndEmpresa(string id)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var producto = await _productoRepository.GetProductosByIdAndEmpresa(id, empresaId);
            if (producto == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var productoDto = new ProductoDto
            {
                Id = producto.Id!,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Activo = producto.activo,
                Sku = producto.Sku,
                Empresa = producto.Empresa?.nombre ?? "",
                Marca = producto.Marca?.Nombre ?? "",
                Categoria = producto.Categoria?.Nombre ?? "",
                UnidadMedida = producto.UnidadMedida?.Nombre ?? "",
            };

            return productoDto;
        }

        public async Task<ProductoDto> PostProductos(Producto producto)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            producto.Id = _AsinacionesService.GenerateNewId();
            producto.updated_at = _AsinacionesService.GetCurrentDateTime();
            producto.created_at = _AsinacionesService.GetCurrentDateTime();
            producto.activo = true;
            producto.Empresa_id = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            producto.adicionado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            producto.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            await _productoRepository.PostProductos(producto);

            var productoDto = new ProductoDto
            {
                Id = producto.Id!,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Activo = producto.activo,
                Sku = producto.Sku,
                Empresa = producto.Empresa?.nombre ?? "",
                Marca = producto.Marca?.Nombre ?? "",
                Categoria = producto.Categoria?.Nombre ?? "",
                UnidadMedida = producto.UnidadMedida?.Nombre ?? "",
            };

            return productoDto;
        }

        public async Task<ProductoDto> PutProductos(string id, Producto producto)
        {
            var productoFound = await _productoRepository.GetProductosById(id);

            if (productoFound == null)
            {
                throw new KeyNotFoundException("producto no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            productoFound.ActualizarPropiedades(producto);
            productoFound.activo = producto.activo;
            productoFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            productoFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _productoRepository.PutProductos(productoFound);
            return new ProductoDto
            {
                Id = productoFound.Id!,
                Nombre = productoFound.Nombre,
                Descripcion = productoFound.Descripcion,
                Activo = productoFound.activo,
                Sku= productoFound.Sku,
                Empresa = productoFound.Empresa?.nombre ?? "",
                Marca = productoFound.Marca?.Nombre ?? "",
                Categoria = productoFound.Categoria?.Nombre ?? "",
                UnidadMedida = productoFound.UnidadMedida?.Nombre ?? "",
            };
        }
    }
}
