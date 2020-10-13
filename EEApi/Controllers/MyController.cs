using DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEApi.Model;
using System.Data;

namespace EEApi.Controllers
{
    public class MyController
    {
        public DataTable Show()
        {
            string sql = "select * from Emp";
            return DBHelper.GetTable(sql);
        }
    }
}
