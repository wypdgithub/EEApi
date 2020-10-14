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
        //显示
        [HttpGet]
        public List<Emp> Show(string Ename)
        {
            string sql = "select * from Emp where EState=0";
            var list= db.GetToList<Emp>(sql);

            if (!string.IsNullOrEmpty(Ename))
            {
                list = list.Where(s => s.Name.Contains(Ename)).ToList();
            }
            return list;

        }
        //修改状态/假删除
        [HttpGet]
        public int UpdState(int id)
        {
            string sql = $"update Emp set EState=1 where Id={id}";
            return db.ExecuteNonQuery(sql);
        }
        //添加
        [HttpPost]
        public int Add(Emp m)
        {
            string sql = $"insert into Emp values('{m.Name}',{m.Age},0)";
            return db.ExecuteNonQuery(sql);
        }
        [HttpGet]
        public List<Emp> Find(int id)
        {
            string sql = $"select * from Emp where Id={id}";
            return db.GetToList<Emp>(sql);
        }
        //修改
        [HttpPost]
        public int UpdEmp(Emp m)
        {
            string sql = $"update Emp set Name='{m.Name}' ,Age='{m.Age}' where Id={m.Id}";
            return db.ExecuteNonQuery(sql);
        }
    }
}
