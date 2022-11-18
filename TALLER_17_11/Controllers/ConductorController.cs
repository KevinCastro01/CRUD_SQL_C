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
    public class ConductorController : ControllerBase
    {
        private readonly FichaDbContext _context;

        public ConductorController(FichaDbContext context)
        {
            _context = context;
        }

        #region // GET: api/<MatriculaControllers>
        //ActionResault para invocar codigos de estado
        /// <summary>
        /// <Method = "Get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            try
            {
                var conductor = await _context.Conductor.Select(x =>
                new ConductorDTO
                {
                    ID = x.ID,
                    IDENTIFICACION = x.IDENTIFICACION,
                    NOMBRE = x.NOMBRE,
                    APELLIDOS = x.APELLIDOS,
                    DIRECCION = x.DIRECCION,
                    TELEFONO = x.TELEFONO,
                    EMAIL = x.EMAIL,
                    FECHANACIMIENTO = x.FECHANACIMIENTO,
                    ESTADO = x.ESTADO
                }).ToListAsync();
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// GET api/<ConductorController>/5
        /// <summary>
        /// <Method = "Get Por ID">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{IDENTIFICACION}")]
        public async Task<ActionResult<ConductorDTO>> Get(string IDENTIFICACION)
        {
            try
            {
                var conductor = await _context.Conductor.Select(x =>
                new ConductorDTO
                {
                    ID = x.ID,
                    IDENTIFICACION = x.IDENTIFICACION,
                    NOMBRE = x.NOMBRE,
                    APELLIDOS = x.APELLIDOS,
                    DIRECCION = x.DIRECCION,
                    TELEFONO = x.TELEFONO,
                    EMAIL = x.EMAIL,
                    FECHANACIMIENTO = x.FECHANACIMIENTO,
                    ESTADO = x.ESTADO
                }).FirstOrDefaultAsync(x => x.IDENTIFICACION == IDENTIFICACION);
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// POST api/<ConductorController>
        /// <summary>
        /// <Method = Post>
        /// </Method>
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            try
            {
                var entity = new Conductor()
                {
                    //ID = vendedor.ID,
                    IDENTIFICACION = conductor.IDENTIFICACION,
                    NOMBRE = conductor.NOMBRE,
                    APELLIDOS = conductor.APELLIDOS,
                    DIRECCION = conductor.DIRECCION,
                    TELEFONO = conductor.TELEFONO,
                    EMAIL = conductor.EMAIL,
                    FECHANACIMIENTO = conductor.FECHANACIMIENTO,
                    ESTADO = conductor.ESTADO
                };
                _context.Conductor.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region// PUT api/<ConductorController>/5
        // PUT api/<VendedoresController>/5
        /// <summary>
        /// <Method = Put>
        /// </Method>
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPut("{IDENTIFICACION}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductor)
        {
            try
            {
                var entity = await _context.Conductor.FirstOrDefaultAsync(v => v.IDENTIFICACION == conductor.IDENTIFICACION);
                //entity.ID = conductor.ID;
                entity.IDENTIFICACION = conductor.IDENTIFICACION;
                entity.NOMBRE = conductor.NOMBRE;
                entity.APELLIDOS = conductor.APELLIDOS;
                entity.DIRECCION = conductor.DIRECCION;
                entity.TELEFONO = conductor.TELEFONO;
                entity.EMAIL = conductor.EMAIL;
                entity.FECHANACIMIENTO = conductor.FECHANACIMIENTO;
                entity.ESTADO = conductor.ESTADO;
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

        #region// DELETE api/<ConductorController>/5
        /// <summary>
        /// <Method = Delete>
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{IDENTIFICACION}")]
        public async Task<HttpStatusCode> Delete(string IDENTIFICACION)
        {
            var entity = new Conductor()
            {
                IDENTIFICACION = IDENTIFICACION
            };
            _context.Conductor.Attach(entity);
            _context.Conductor.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
