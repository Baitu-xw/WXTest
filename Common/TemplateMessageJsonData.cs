using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Common
{
    public class TemplateMessageJsonData
    {
        public string touser { set; get; }

        public string template_id { set; get; }

        public string topcolor { set; get; }

        public TemplateMessageJson data { set; get; }
    }
}
