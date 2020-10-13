using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EEApi.Model;
using EEApi.Context;

namespace EEApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        DBHelper db = new DBHelper();
        //上下文
        public MyContext mc;
        public SomeController(MyContext mc) { this.mc = mc; }

        //public List<Emp> Show()
        //{
        //    return mc.emps.ToList();
        //}
        [HttpGet]
        public List<Emp> Show()
        {
            string sql = "select * from Emp where EState=0";
            return db.GetToList<Emp>(sql);
        }
    }
}
