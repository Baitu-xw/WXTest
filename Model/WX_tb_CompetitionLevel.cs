using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionLevel
    {
        /// <summary>
        /// 比赛级别ID
        /// </summary>
        public int CompetitionLevel_ID { get; set; }
        /// <summary>
        /// 比赛级别:2.5、3.0、3.5、4.0、4.5、5.0、6.0、7.0、8.0、9.0、10.0
        /// </summary>
        public string CompetitionLevel_Name { get; set; }
    }
}
