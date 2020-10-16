using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEApi.Model.Teachers
{
    public class VirtualTb
    {
        [Key]
        public int Id { get; set; }
        public string TeaName { get; set; }
        public string TeaImg { get; set; }
        public string organizationName { get; set; }
        public int OrderBy { get; set; }
        public DateTime UpdTime { get; set; }
        public int CId { get; set; }
        public int States { get; set; }
        public string CreateName { get; set; }
    }
    public class Pages
    {
        public int AllCount { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<VirtualTb> virtualTbs { get; set; }
    }
}
