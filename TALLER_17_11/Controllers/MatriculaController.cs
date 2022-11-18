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
    public class MatriculaController : ControllerBase
    {
        private readonly FichaDbContext _context;

        public MatriculaController(FichaDbContext context)
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
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            try
            {
                var matricula = await _context.Matricula.Select(x =>
                new MatriculaDTO
                {
                    ID = x.ID,
                    NUMERO = x.NUMERO,
                    FECHAEXPEDICION = x.FECHAEXPEDICION,
                    VALIDAHASTA = x.VALIDAHASTA,
                    ESTADO = x.ESTADO
                }).ToListAsync();
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// GET api/<MatriculaController>/5
        /// <summary>
        /// <Method = "Get Por ID">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDTO>> Get(int id)
        {
            try
            {
                var matricula = await _context.Matricula.Select(x =>
                new MatriculaDTO
                {
                    ID = x.ID,
                    NUMERO = x.NUMERO,
                    FECHAEXPEDICION = x.FECHAEXPEDICION,
                    VALIDAHASTA = x.VALIDAHASTA,
                    ESTADO = x.ESTADO
                }).FirstOrDefaultAsync(x => x.ID == id);
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region// POST api/<MatriculaController>
        /// <summary>
        /// <Method = Post>
        /// </Method>
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTO matricula)
        {
            try
            {
                var entity = new Matricula()
                {
                    //ID = vendedor.ID,
                    NUMERO = matricula.NUMERO,
                    FECHAEXPEDICION = matricula.FECHAEXPEDICION,
                    VALIDAHASTA = matricula.VALIDAHASTA,
                    ESTADO = matricula.ESTADO
                };
                _context.Matricula.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        #endregion

        #region// PUT api/<MatriculaController>/5
        // PUT api/<VendedoresController>/5
        /// <summary>
        /// <Method = Put>
        /// </Method>
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPut("{NUMERO}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matricula)
        {
            try
            {
                var entity = await _context.Matricula.FirstOrDefaultAsync(v => v.NUMERO == matricula.NUMERO);
                //entity.ID = matricula.ID;
                entity.NUMERO = matricula.NUMERO;
                entity.FECHAEXPEDICION = matricula.FECHAEXPEDICION;
                entity.VALIDAHASTA = matricula.VALIDAHASTA;
                entity.ESTADO = matricula.ESTADO;
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
        [HttpDelete("{NUMERO}")]
        public async Task<HttpStatusCode> Delete(string NUMERO)
        {
            var entity = new Matricula()
            {
                NUMERO = NUMERO
            };
            _context.Matricula.Attach(entity);
            _context.Matricula.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
