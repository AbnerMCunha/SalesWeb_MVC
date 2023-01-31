using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SalesWebMVC.Services {
    public class DepartmentService {

        private readonly SalesWebMVCContext _context;

        public DepartmentService( SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()   //Assincrono
        {
            //Operações Linq por si só prepara a consulta mas não são executadas, elas precisam de alguém que provoque essa execução, no caso é o .ToList() e .ToListAsync()/
            //O ToList(), SINCRONAMENTE: a Aplicação fica bloqueada executando o Extension Method
            //ToListAsync(), ASSINCONA, executa sem travar a linha de execução atual, Para que a assincronicidade ocorra de fato precisaria de um await.
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();   
        }
        /*
        public List<Department> FindAll()   //Sincrono
        {
            return _context.Department.OrderBy(x => x.Name).ToList();   //Retornando a Lista, ordenada por Nome
            //return _context.Department.ToList();          //Retornando a Lista
        }
        */


    }
}
