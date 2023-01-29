using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;   //para pegar id generico
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using SalesWebMVC.Models.ViewModels;
using Microsoft.AspNetCore;

namespace SalesWebMVC.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //Delete---------------------------------
        //Create Get
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel() { Departments = departments }; //Adciona os valores de Departamentos para passar na tela de Criação como componente
            return View(viewModel);
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); // Fazer assim para caso de renomeações do view, posteriormente, outro jeito seria: ao inves de RedirectToAction(Index)
        }


        //Delete---------------------------------
        //Delete Get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not Found!" });
            }

            //_sellerService.RemoveSeller(id.Value);        //Errei aqui, cuidado ao passar Ação, no Metodo Get, ação só no metodos Post, (verificar)
            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }


        //Details---------------------------------
        //Details Get
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not Found" });
            }

            return View(obj);
        }



        //Edit---------------------------------
        //Edit Get
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { Message = "Id not Found" });
            }

            List<Department> departments = new List<Department>(_departmentService.FindAll());
            var viewModel = new SellerFormViewModel() { Seller = obj, Departments = departments }; //Adciona os valores de Departamentos para passar na tela de Criação como componente
            return View(viewModel);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                //BadRequest();
                return RedirectToAction(nameof(Error), new { Message = "Id Mismatch" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)   //ApplicationException  é Superclase de NotFoundException e DbConcurrencyException, por upcasting acaba representando as 2
            {
                return RedirectToAction(nameof(Error), e.Message);  //Posso usar a mensagem da exceção retornda
            }
            /* ApplicationException  é Superclase de NotFoundException e DbConcurrencyException, por upcasting acaba representando as 2
              
              catch(NotFoundException e) //Caso retorne na Camada de Servico essa excção, retonar excção personalizada no Controler
            {
                return NotFound();
            }
            catch(DbConcurrencyException e) //Caso retorne na Camada de Servico essa excção, retonar excção personalizada no Controler
            {
                return BadRequest();
            }
            */
        }
        /*
        public IActionResult Error( string message)
        {
            var errorViewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                //? significa que é opcional
                //?? Operador de coalescencia nulla
            };
            return View(errorViewModel);
        }*/

        public IActionResult Error(string Message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = Message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //Macete Pra pegar o Id Interno da Requisição.
            };
            return View(viewModel);
        }
    }
}