using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Common
{
    public class TemplateMessageJson:BaseJsonResult
    {
        public ValueColor first { set; get; }

        //public ValueColor personName { set; get; }

        //public ValueColor competitionName { set; get; }

        //public ValueColor competitionTime { set; get; }

        //public ValueColor competitionAddress { set; get; }


        public ValueColor keyword1 { set; get; }

        public ValueColor keyword2 { set; get; }

        public ValueColor keyword3 { set; get; }

        public ValueColor keyword4 { set; get; }

        public ValueColor remark { set; get; }
    }
}
