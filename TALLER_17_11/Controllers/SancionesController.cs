namespace TALLER_17_11.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TALLER_17_11.DAL.DbContext;
    using TALLER_17_11.DAL.Entities;
    using TALLER_17_11.DTOs;

    [ApiController]
    [Route("api/[controller]")]
    public class SancionesController : ControllerBase
    {
        private readonly FichaDbContext _context;

        public SancionesController(FichaDbContext context)
        {
            _context = context;
        }

        #region // GET: api/<SancionesControllers>
        //ActionResault para invocar codigos de estado
        /// <summary>
        /// <Method = "Get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            try
            {
                var sanciones = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    ID = x.ID,
                    FECHA_ACTUAL = x.FECHA_ACTUAL,
                    SANCION = x.SANCION,
                    OBSERVACION = x.OBSERVACION,
                    VALOR = x.VALOR
                }).ToListAsync();
                if (sanciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return sanciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// GET api/<SancionesController>/5
        /// <summary>
        /// <Method = "Get Por ID">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            try
            {
                var sanciones = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    ID = x.ID,
                    FECHA_ACTUAL = x.FECHA_ACTUAL,
                    SANCION = x.SANCION,
                    OBSERVACION = x.OBSERVACION,
                    VALOR = x.VALOR
                }).FirstOrDefaultAsync(x => x.ID == id);
                if (sanciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return sanciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// POST api/<SancionesController>
        /// <summary>
        /// <Method = Post>
        /// </Method>
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            try
            {
                var entity = new Sanciones()
                {
                    //ID = sanciones.ID,
                    FECHA_ACTUAL = sanciones.FECHA_ACTUAL,
                    SANCION = sanciones.SANCION,
                    OBSERVACION = sanciones.OBSERVACION,
                    VALOR = sanciones.VALOR
                };
                _context.Sanciones.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// PUT api/<SancionesController>/5
        // PUT api/<VendedoresController>/5
        /// <summary>
        /// <Method = Put>
        /// </Method>
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        [HttpPut("{ID}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sanciones)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.ID == sanciones.ID);
                entity.ID = sanciones.ID;
                entity.FECHA_ACTUAL = sanciones.FECHA_ACTUAL;
                entity.SANCION = sanciones.SANCION;
                entity.OBSERVACION = sanciones.OBSERVACION;
                entity.VALOR = sanciones.VALOR;
                //_context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }
        #endregion

        #region// DELETE api/<SedesController>/5
        /// <summary>
        /// <Method = Delete>
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<HttpStatusCode> Delete(int ID)
        {
            var entity = new Sanciones()
            {
                ID = ID
            };
            _context.Sanciones.Attach(entity);
            _context.Sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
