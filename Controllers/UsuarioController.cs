﻿using Inventario.interfaces.IUsuario;
using Inventario.models.Usuario;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
                var usuarios = await _usuarioService.GetUsuarios();

                if (usuarios == null || !usuarios.Any())
                    return NotFound("No se encontraron usuarios.");

                return Ok(usuarios);


        }
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosActivos()
        {
                var usuarios = await _usuarioService.GetUsuariosActivos();

                if (usuarios == null || !usuarios.Any())
                    return NotFound("No se encontraron usuarios.");

                return Ok(usuarios);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioById(string id)
        {

                var usuarios = await _usuarioService.GetUsuarioById(id);

                return Ok(usuarios);

        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuarios(Usuario usuario)
        {
            var usuarios = await _usuarioService.PostUsuario(usuario);
            return CreatedAtAction(nameof(CreateUsuarios), new { id = usuarios.id }, usuarios);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDto>> UpdateUsuarios(string id, Usuario usuario)
        {
            try
            {
                // Llamada al Service
                var usuarioActualizado = await _usuarioService.PutUsuario(id, usuario);

                // Si todo sale bien, responde con un 200 OK
                return Ok(usuarioActualizado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
