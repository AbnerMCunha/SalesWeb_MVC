﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services {
    public class DepartmentService {

        private readonly SalesWebMVCContext _context;

        public DepartmentService( SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();   //Retornando a Lista, ordenada por Nome
            //return _context.Department.ToList();          //Retornando a Lista
        }


    }
}
