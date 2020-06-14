using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c11.Models;
using Microsoft.AspNetCore.Mvc;

namespace c11.Controllers{
    public class DoctorsController : Controller{

        private readonly s18911Context DbContext;

        public DoctorsController(s18911Context DbContext){
            this.DbContext = DbContext;
        }

        public IActionResult IndexDoctors(){
            var ListDoctors = DbContext.Doctor.ToList();
            return View(ListDoctors);
        }

        public IActionResult GetDoctorData(int id) {
            var doctor = new Doctor();
            if (DbContext.Doctor.Where(d => d.IdDoctor == id).Any()){
                doctor = DbContext.Doctor.SingleOrDefault(d => d.IdDoctor == id);
            }
            else {
                doctor = null;
            }
            return View(doctor);
        }

        public IActionResult AddDoctor() {
            
            return View(); 
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor) {
            if (!ModelState.IsValid){
                return View(doctor);
            }else {
                if (DbContext.Doctor.Where(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName).Any()){
                    return View(doctor);
                }
                else {
                    int id = DbContext.Doctor.Max(d => d.IdDoctor);

                    var NewDoctor = new Doctor {
                        IdDoctor = id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName
                    };
                    DbContext.Doctor.Add(NewDoctor);
                    DbContext.SaveChanges();
                }
            }
            return RedirectToAction("IndexDoctors");
        }

        public IActionResult DeleteDector() {

            return View();
        }

        [HttpPost]
        public IActionResult DeleteDoctor(Doctor doctor) {
            if (!ModelState.IsValid){
                return View(doctor);
            }
            else{
                if (DbContext.Doctor.Where(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName).Any()){
                    return View(doctor);
                }
                else{
                    var DeleteDoctor = DbContext.Doctor.SingleOrDefault(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName);
                    DbContext.Doctor.Remove(DeleteDoctor);
                    DbContext.SaveChanges();
                }
            }
            return RedirectToAction("IndexDoctors");

            return View();
        }
    }
}