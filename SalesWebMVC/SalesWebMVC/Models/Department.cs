using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;    //Para o Tratamento de Erros
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Models {
    public class Department {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller)
        {
            try { 
            Sellers.Remove(seller);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't Delete Departament because it has Sellers with sales linked.");
            }
        }

        public double TotalSales(DateTime Initial, DateTime Final)
        {
            return Sellers.Sum(seler => seler.TotalSales(Initial, Final));
        }

    }
}
