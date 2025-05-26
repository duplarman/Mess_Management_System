using Mess_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess_Management_System.Services.Interfaces
{
    public interface IMemberService
    {
        Member GetById(int id);
        IEnumerable<Member> GetAll();
        void Create(Member member);
        void Update(Member member);
        void Delete(int id);
    }
}
