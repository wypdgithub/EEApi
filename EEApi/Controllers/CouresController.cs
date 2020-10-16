using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEApi.Context;
using EEApi.Model;
using EEApi.Model.Teachers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EEApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class CouresController : ControllerBase
    {
        public MyContext hr;
        public CouresController(MyContext hr) { this.hr = hr; }



        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>    
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Course>>> GetEmp(string name = "")
        //{
        //    var i = await hr.courses.Where(s=>s.Recycle==0).ToListAsync();
        //    if (name != "")
        //    {
        //        i = i.Where(s => s.Name.Contains(name)).ToList();
        //    }
        //    i = i.OrderBy(s => s.Bian).ToList();

        //    return i;
        //}
        public List<CouseTea> GetEmp(string name = "")
        {
            var i = (from u in hr.courses
                     join t in hr.teachers on u.Teacher equals t.Id
                     where u.Recycle == 0
                     select new CouseTea
                     {
                         Id = u.Id,
                         Bian = u.Bian,
                         Name = u.Name,
                         Image = u.Image,
                         State = u.State,
                         Original = u.Original,
                         Discounts = u.Discounts,
                         Teacher = u.Teacher,
                         NewTime = u.NewTime,
                         Recycle = u.Recycle,
                         TeaName = t.TeaName
                     }).ToList();
            if (name != "")
            {
                i = i.Where(s => s.Name.Contains(name)).ToList();
            }
            i = i.OrderBy(s => s.Bian).ToList();

            return i;
        }
        /// <summary>
        /// 获取所有回收数据
        /// </summary>
        /// <returns></returns>    
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Course>>> Getcouse(string name = "")
        //{
        //    var i = await hr.courses.Where(s => s.Recycle == 1).ToListAsync();
        //    if (name != "")
        //    {
        //        i = i.Where(s => s.Name.Contains(name)).ToList();
        //    }
        //    i = i.OrderBy(s => s.Bian).ToList();

        //    return i;
        //}

        public List<CouseTea> Getcouse(string name = "")
        {
            var i = (from u in hr.courses
                     join t in hr.teachers on u.Teacher equals t.Id
                     where u.Recycle == 1
                     select new CouseTea
                     {
                         Id = u.Id,
                         Bian = u.Bian,
                         Name = u.Name,
                         Image = u.Image,
                         State = u.State,
                         Original = u.Original,
                         Discounts = u.Discounts,
                         Teacher = u.Teacher,
                         NewTime = u.NewTime,
                         Recycle = u.Recycle,
                         TeaName = t.TeaName
                     }).ToList();
            if (name != "")
            {
                i = i.Where(s => s.Name.Contains(name)).ToList();
            }
            i = i.OrderBy(s => s.Bian).ToList();

            return i;
        }
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        public int Addcoutse(Course p)
        {
            string sql;
            sql = $"insert into [Course] values('{p.Bian}','{p.Name}','/Image/6.jpg','{p.State}','{p.Original}','{p.Discounts}','{DateTime.Now}','{p.Teacher}','0')";
            hr.Database.ExecuteSqlCommand(sql);
            return 1;
        }
        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<int>> Delcouse(int id)
        {
            hr.courses.Remove(hr.courses.FirstOrDefault(m => m.Id == id));
            return await hr.SaveChangesAsync();
        }
        /// <summary>
        /// 更改下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        public int Uptsatae1(int id)
        {
            string sql;
            sql = $"update Course set State=2 where Id={id}";
            hr.Database.ExecuteSqlCommand(sql);
            return 1;
        }
        /// <summary>
        /// 更改上架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        public int Uptsatae2(int id)
        {
            string sql;
            sql = $"update Course set State=1 where Id={id}";
            hr.Database.ExecuteSqlCommand(sql);
            return 1;
        }
        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        public int UptRecycle1(int id)
        {
            string sql;
            sql = $"update Course set Recycle=1 where Id={id}";
            hr.Database.ExecuteSqlCommand(sql);
            return 1;
        }
        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        public int UptRecycle2(int id)
        {
            string sql;
            sql = $"update Course set Recycle=0 where Id={id}";
            hr.Database.ExecuteSqlCommand(sql);
            return 1;
        }
        /// <summary>
        /// 下拉讲师
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> Getteacher()
        {
            return await hr.teachers.ToListAsync(); ;
        }
    }
}
