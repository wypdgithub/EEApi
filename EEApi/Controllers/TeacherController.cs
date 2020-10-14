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
        public List<VirtualTb> GetList()
        {
            try
            {
                string sql = $"select * from Teacher t join createPeople c on t.CId=c.Id where t.States=0";
                return db.GetToList<VirtualTb>(sql);
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
        public int Add(int id)
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
    }
}
