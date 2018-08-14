using c_final_capstone_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_final_capstone_v2.Dbo
{
    public interface ICatSqlDao
    {
        List<Cat> GetAllCats();
        bool AddCat(Cat cat);
    }
}
