using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEApi.Context;
using EEApi.Model;
using EEApi.Model.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace EEApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JiaoShiController : ControllerBase
    {
        DBHelper db1 = new DBHelper();
        public MyContext db;
        public JiaoShiController(MyContext db) { this.db = db; }

        [HttpGet]
        public  List<VirtualTb> GetTeacher(string name)
        {
            //var list =  db.teachers.ToList();
            string sql = $"select * from Teacher where 1=1 ";
            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += $" and TeaName like '%{name}%'";
            }
            var list = db1.GetToList<VirtualTb>(sql);
            //if (!string.IsNullOrEmpty(name))
            //{
            //    list = list.Where(x => x.TeaName.Contains(name)).ToList();
            //} 
            //if (!string.IsNullOrWhiteSpace(TeaName))
            //{
            //    list = list.Where(s => s.TeaName.Equals(TeaName)).ToList();
            //}
            return list;
        }

        [HttpDelete]
        //删除
        public async Task<ActionResult<int>> DelTeacher(int Id)
        {
            db.teachers.Remove(db.teachers.FirstOrDefault(MyContext => MyContext.Id == Id));
            return await db.SaveChangesAsync();
        }
        //添加
        [HttpPost]
        public async Task<ActionResult<int>> AddTeacher(Teacher m)
        {
            db.teachers.Add(m);
            return await db.SaveChangesAsync();
        }

        [HttpGet]
        //详情
        public Teacher GetTeacherById(int id)
        {
            return db.teachers.Where(x => x.Id == id).ToList()[0];
        }

        [HttpGet]
        //修改
        public async Task<ActionResult<int>> UptTeacher(int id,string TeaName,DateTime UpdTime)
        {
            var ls = new Teacher() { TeaName = TeaName, UpdTime = UpdTime, Id = id };
            db.Entry(ls).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }

        public async Task<ActionResult<Login>> Login(string Name,string Pwd)
        {
            return await db.Login.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(Name) && x.Pwd.Equals(Pwd));
        }

    }
}
