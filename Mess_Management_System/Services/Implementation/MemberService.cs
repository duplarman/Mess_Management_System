using Mess_Management_System.Models;
using Mess_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly MessDbContext _context;
        public MemberService(MessDbContext context)
        {
            _context = context;
        }

        public void Create(Member member) => _context.Members.Add(member);
        public void Delete(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null) _context.Members.Remove(member);
        }
        public IEnumerable<Member> GetAll() => _context.Members.ToList();
        public Member GetById(int id) => _context.Members.Find(id);
        public void Update(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
        }
    }
}