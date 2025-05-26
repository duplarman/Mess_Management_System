using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Mess_Management_System.Models;
using Mess_Management_System.Services;

namespace Mess_Management_System.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: Member
        public ActionResult Index()
        {
            var members = _memberService.GetActiveMembers();
            return View(members);
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                member.JoinDate = DateTime.Now;
                member.IsActive = true;
                _memberService.Add(member);
                _memberService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.Update(member);
                _memberService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = _memberService.GetById(id);
            if (member != null)
            {
                member.IsActive = false;
                _memberService.Update(member);
                _memberService.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Member/MealHistory/5
        public ActionResult MealHistory(int id, DateTime? startDate = null, DateTime? endDate = null)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            startDate = startDate ?? DateTime.Now.AddMonths(-1);
            endDate = endDate ?? DateTime.Now;

            var mealHistory = _memberService.GetMemberMealHistory(id, startDate.Value, endDate.Value);
            ViewBag.Member = member;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(mealHistory);
        }

        // GET: Member/PaymentHistory/5
        public ActionResult PaymentHistory(int id, DateTime? startDate = null, DateTime? endDate = null)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            startDate = startDate ?? DateTime.Now.AddMonths(-1);
            endDate = endDate ?? DateTime.Now;

            var paymentHistory = _memberService.GetMemberPaymentHistory(id, startDate.Value, endDate.Value);
            ViewBag.Member = member;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(paymentHistory);
        }

        // GET: Member/MonthlySummary/5
        public ActionResult MonthlySummary(int id, int? year = null, int? month = null)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            year = year ?? DateTime.Now.Year;
            month = month ?? DateTime.Now.Month;

            var summary = _memberService.GetMonthlySummary(id, year.Value, month.Value);
            ViewBag.Member = member;
            ViewBag.Year = year;
            ViewBag.Month = month;

            return View(summary);
        }
    }
} 