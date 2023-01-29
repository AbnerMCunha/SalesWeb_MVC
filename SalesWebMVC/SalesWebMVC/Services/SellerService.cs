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
            catch(ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
