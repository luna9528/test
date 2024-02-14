using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using test.Models.DTO;
using test.Models.Repository;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly InterfaceCompra _interfacecompra;

        public ComprasController( IMapper mapper, InterfaceCompra interfacecompra)
        {
            _mapper = mapper;
            _interfacecompra = interfacecompra;
    }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listCompras = await _interfacecompra.GetListCompras();
                var listComprasDTO = _mapper.Map<IEnumerable<CompraDTO>>(listCompras);
                return Ok(listCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var compras = await _interfacecompra.GetCompras(id);
                if (compras == null)
                {
                    return NotFound();
                    
                }
                var compraDTO = _mapper.Map<CompraDTO>(compras);

                return Ok(compraDTO);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var compra = await _interfacecompra.GetCompras(id);
                if (compra == null)
                {
                    return NotFound();
                }

                await _interfacecompra.DeleteCompra(compra);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompraDTO compraDTO)
        {
            try
            {
                var compras = _mapper.Map<Compras>(compraDTO);
        
                compras.FechaCreacion = DateTime.Now;

                var comprasItem = _interfacecompra.AddCompra(compras);

                var compraItemDto = _mapper.Map<CompraDTO>(compras);

                return CreatedAtAction("Get", new { id = compraItemDto.Id }, compraItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CompraDTO compraDTO)
        {
            try {
                var compras = _mapper.Map<Compras>(compraDTO);
                if (id != compras.Id)
                {
                    return BadRequest();
                }

                var comprasItem = await _interfacecompra.GetCompras(compras.Id);

                if(comprasItem == null)
                {
                    return NotFound();
                }

                await _interfacecompra.UpdateCompra(compras);


                return NoContent();


            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
