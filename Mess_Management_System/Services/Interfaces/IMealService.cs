using Mess_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess_Management_System.Services.Interfaces
{
    public interface IMealService
    {
        Meal GetById(int id);
        IEnumerable<Meal> GetAll();
        void Add(Meal meal);
        void Update(Meal meal);
        void Delete(int id);
        IEnumerable<Meal> GetMealsByDate(DateTime date);
    }
}
