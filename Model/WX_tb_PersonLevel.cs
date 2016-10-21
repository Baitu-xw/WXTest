using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_PersonLevel
    {
        /// <summary>
        /// 级别ID
        /// </summary>
        public int Level_ID { get; set; }
        /// <summary>
        /// 级别名称：2.5级、3.0级、3.5级、4.0级、4.5级、5.0级
        /// </summary>
        public string Level_Name { get; set; }
    }
}
