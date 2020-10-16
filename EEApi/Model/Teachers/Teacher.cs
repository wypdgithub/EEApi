using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EEApi.Model.Teachers
{
    [Table("Teacher")]
    public class Teacher
    {
        //初始化
        public Teacher()
        {
            this.States = 0;
        }
        [Key]
        public int Id { get; set; }
        public string TeaName { get; set; }//教师名称
        public string TeaImg { get; set; }//教师头像
        public string organizationName { get; set; }//机构名称
        public int OrderBy { get; set; }//排序号
        public DateTime UpdTime { get; set; }//创建时间
        public int CId { get; set; }//外键
        public int States { get; set; }//删除状态
    }
}
