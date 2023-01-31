using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;


namespace SalesWebMVC.Services {
    public class SellerService {

        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()   //Retona lista com todos os Vendedores. Operação SINCRONA
        {
            return await _context.Seller.Include(obj => obj.Department).ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            //return _context.Seller.Find(id);
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id) ;
        }


        public async Task RemoveSellerAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Seller seller)
        {
            var hasAny = await _context.Seller.AnyAsync(obj => obj.Id == seller.Id);

            if (!hasAny)
            {
                throw new Exceptions.DbConcurrencyException("Id Seller not found. ");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)   //IMPORTANTE SEGREGRAR CAMADAS: Interceptando excel do nivel de acesso a dados e relançando a minha exceçao de Nivel de Servico.
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


        /* Sincronos
        public List<Seller> FindAll()   //Retona lista com todos os Vendedores. Operação SINCRONA
        {
            return _context.Seller.Include(obj => obj.Department).ToList();
        }
        
        public void Insert(Seller obj)
        {
            //obj.Department = _context.Department.First();    //Gamibarra pra poder inserir Vendedor com primeiro departamento registrado, caso contrario, da erro.
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            //return _context.Seller.Find(id);
            return _context.Seller.Include(obj => obj.Department ).FirstOrDefault( obj => obj.Id == id );
        }

        public void RemoveSeller(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }


        public void Update(Seller seller)
        {
            if( !_context.Seller.Any(obj => obj.Id == seller.Id))
            {
                throw new Exceptions.DbConcurrencyException("Id Seller not found. ");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)   //IMPORTANTE SEGREGRAR CAMADAS: Interceptando excel do nivel de acesso a dados e relançando a minha exceçao de Nivel de Servico.
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        */

    }
}
