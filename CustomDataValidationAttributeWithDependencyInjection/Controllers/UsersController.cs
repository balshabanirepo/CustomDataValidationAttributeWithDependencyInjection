using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataRepository.GateWay;
using ServiceClassLibrary;

namespace CustomDataValidationAttributeWithDependencyInjection.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserServiceInterface _userServiceInterface ;

        public UsersController(UserServiceInterface userServiceInterface)
        {
            _userServiceInterface = userServiceInterface;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View( _userServiceInterface.list());
        }

       

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(UserDataModel user)
        {
            if (ModelState.IsValid)
            {
                _userServiceInterface.SaveUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userServiceInterface.GetUser((int)id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(UserDataModel user)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _userServiceInterface.SaveUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _userServiceInterface.GetUser((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user =  _userServiceInterface.GetUser(id);
            _userServiceInterface.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _userServiceInterface.GetUser(id)!=null;
        }
    }
}
