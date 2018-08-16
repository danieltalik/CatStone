using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.DAL
{
    public interface ISkillDao
    {
        List<string> GetCatSkills(int id);
        void AddCatSkillsToTable(int id, List<string> skills);
    }
}
