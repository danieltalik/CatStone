using c_final_capstone_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_final_capstone_v2.DAL
{
    public interface ICatSqlDao
    {
        List<Cat> GetAllCats();
        bool AddCat(Cat cat);
        Cat ViewCat(int id);
        int GetCatId(string picId);
    }
}
