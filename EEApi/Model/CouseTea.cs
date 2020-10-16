using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEApi.Model
{
    public class CouseTea
    {
        public int Id { get; set; }//编号
        public int Bian { get; set; }//课程编号
        public string Name { get; set; }//课程名称
        public string Image { get; set; }//图片
        public int State { get; set; }//上下架状态
        public decimal Original { get; set; }//课程原价
        public decimal Discounts { get; set; }//课程优惠价
        public DateTime NewTime { get; set; }//更新时间
        public int Teacher { get; set; }//课程讲师
        public int Recycle { get; set; }//回收状态
        public string TeaName { get; set; }//讲师名称
    }
}
