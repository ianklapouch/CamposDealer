using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealer.Data;
using CamposDealer.Models;

namespace CamposDealer.Controllers
{
    public class VendasController(CamposDealerContext context) : Controller
    {
        private readonly CamposDealerContext _context = context;

        // GET: Vendas
        public async Task<IActionResult> Index(int qtdVenda, decimal vlrUnitarioVenda, DateTime dthVenda, decimal vlrTotalVenda, int idCliente, int idProduto)
        {

            if (_context.Venda is null)
            {
                return Problem("Não existem Vendas cadastradas no sistema!");
            }

            var vendas = from venda in _context.Venda.Include(v => v.Cliente).Include(v => v.Produto) select venda;

            if (qtdVenda > 0)
            {
                vendas = vendas.Where(v => v.QtdVenda.Equals(dthVenda));
            }

            if (vlrUnitarioVenda > 0)
            {
                vendas = vendas.Where(v => v.VlrUnitarioVenda.Equals(vlrUnitarioVenda));
            }

            if (dthVenda != DateTime.MinValue)
            {
                vendas = vendas.Where(v => v.DthVenda.Equals(dthVenda));
            }

            if (vlrTotalVenda > 0)
            {
                vendas = vendas.Where(v => v.VlrTotalVenda.Equals(vlrTotalVenda));
            }

            if (idCliente > 0)
            {
                vendas = vendas.Where(v => v.IdCliente.Equals(idCliente));
            }

            if (idProduto > 0)
            {
                vendas = vendas.Where(v => v.IdProduto.Equals(idProduto));
            }

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NmCliente");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "DscProduto");
            return View(await vendas.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NmCliente");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "DscProduto");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", venda.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NmCliente");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "DscProduto");
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", venda.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.IdVenda == id);
        }
    }
}
