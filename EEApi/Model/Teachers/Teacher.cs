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
        public string TeaName { get; set; }
        public string TeaImg { get; set; }
        public string organizationName { get; set; }
        public int OrderBy { get; set; }
        public DateTime UpdTime { get; set; }
        public int CId { get; set; }
        public int States { get; set; }
    }
}
