using Internal_set_a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Internal_set_a.Controllers
{
    public class DonorController : Controller
    {
        DBDonorEntities con=new DBDonorEntities();
        // GET: Donor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult insert(TBLDonor d)
        {
            if(d.Donation_Amount<9999)
            {
                return View("Message");
            }
            else
            {
                con.TBLDonors.Add(d);
                con.SaveChanges();
                return RedirectToAction("GetAll");
            }
            
        }
        public ActionResult GetAll()
        {
            List<TBLDonor> tBLDonors=con.TBLDonors.ToList();
            return View(tBLDonors);
        }
        public ActionResult Delete(int id)
        {
            TBLDonor t1=con.TBLDonors.Find(id);
            con.TBLDonors.Remove(t1);
            con.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public ActionResult update(int id)
        {
            TBLDonor t1 = con.TBLDonors.Find(id);
            return View(t1);
        }
        public ActionResult updatedata(TBLDonor ndata)
        {
            TBLDonor t1 = con.TBLDonors.Find(ndata.ID_PK);
            t1.Name=ndata.Name;
            t1.Donation_Date=ndata.Donation_Date;
            t1.City=ndata.City;
            t1.Aadhar_Number=ndata.Aadhar_Number;
            t1.Donation_Amount=ndata.Donation_Amount;
            con.SaveChanges();
            return RedirectToAction("GetAll");
        }

    }
}