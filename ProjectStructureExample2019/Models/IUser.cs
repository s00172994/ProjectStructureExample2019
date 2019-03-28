using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructureExample2019.Models
{
    public interface IUser
    {
        ApplicationUser GetUserById(string id);
        ApplicationUser GetUserByName(string name);
    }
}
