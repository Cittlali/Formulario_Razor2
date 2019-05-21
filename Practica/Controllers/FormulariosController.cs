using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Practica.Models;

namespace Practica.Controllers
{
    public class FormulariosController : Controller
    {
        public readonly PracticaContext _context;
        public IConfiguration Configuration { get; }

        public FormulariosController(PracticaContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: Formularios/Index=Lista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Formulario.ToListAsync());
        }
        // GET: Formularios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }
        // GET: Formularios/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Formularios/Create
        [HttpPost]
        public IActionResult Create(Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:PracticaContext"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into Formulario(nombre, apellidoP, apellidoM, usuario, contrasena, telefono, direccion) Values ('{formulario.nombre}', '{formulario.apellidoP}','{formulario.apellidoM}','{formulario.usuario}', '{formulario.contrasena}', '{formulario.telefono}', '{formulario.direccion}' )";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();

                    }
                    return RedirectToAction("Index");
                }

            }
            else
                return View();
        }

    

  

    // GET: Formularios/Edit
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario.FindAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            return View(formulario);
        }

        // POST: Formularios/Edit

        [HttpPost]
        public IActionResult Edit(Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:PracticaContext"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"UPDATE Formulario SET nombre='{formulario.nombre}', apellidoP ='{formulario.apellidoP}', apellidoM ='{formulario.apellidoM}', usuario ='{formulario.usuario}', contrasena ='{formulario.contrasena}', telefono ='{formulario.telefono}', direccion ='{formulario.direccion}' WHERE Id='{formulario.Id}'";

                  
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();

                    }
                    return RedirectToAction("Index");
                }

            }
            else
                return View();
        }
                // GET: Formularios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formulario.FindAsync(id);
            _context.Formulario.Remove(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.Formulario.Any(e => e.Id == id);
        }


    





    }
}


