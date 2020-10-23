using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEApi.Model.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace EEApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        DBHelper db = new DBHelper();
        //显示教师
        [HttpGet]
        public Pages GetList(string name,int pageSize=8,int pageIndex=1)
        {
            try
            {
                string sql = $"select * from Teacher t join createPeople c on t.CId=c.Id where t.States=0";
                var list= db.GetToList<VirtualTb>(sql);
                if (!string.IsNullOrEmpty(name))
                {
                    list = list.Where(s => s.TeaName.Contains(name)).ToList();
                }
                list = list.OrderByDescending(s => s.Id).ToList();
                int count = list.Count;
                int pageCount=0;
                if (pageCount % pageSize == 0)
                {
                    pageCount = count / pageSize;
                }
                if (pageCount % pageSize != 0)
                {
                    pageCount = count / pageSize + 1;
                }
                Pages p = new Pages();
                p.virtualTbs = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                p.PageIndex = pageIndex;
                p.PageCount = pageCount;
                p.PageSize = pageSize;
                p.AllCount = count;
                return p;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //删除教师
        [HttpDelete]
        public int Del(int id)
        {
            try
            {
                string sql = $"update Teacher set States=1 where Id={id}";
                return db.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //添加教师
        [HttpPost]
        public int Add(Teacher m)
        {
            try
            {
                string sql = $"insert into Teacher values('{m.TeaName}','/Img{m.TeaImg.Substring(11,7)}','{m.organizationName}',0,'{DateTime.Now}',2,0)";
                return db.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //编辑教师
        [HttpPost]
        public int UpdTeacher(Teacher m)
        {
            try
            {
                string sql = $"update Teacher set TeaName='{m.TeaName}',TeaImg='/Img/7.jpg',organizationName='{m.organizationName}',UpdTime='{DateTime.Now}',CId=2,States=0 where Id={m.Id}";
                return db.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public List<Teacher> Find(int id)
        {
            try
            {
                string sql = $"select * from Teacher where Id={id}";
                return db.GetToList<Teacher>(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
