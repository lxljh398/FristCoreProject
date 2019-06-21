using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elasticsearch
{
    [ElasticsearchType(Name = "Company")]
    public class Company
    {

        public string OriginID { get; set; }


        public string Title { get; set; }


        public string Mobile { get; set; }


        public string Name { get; set; }


        public string StoreID { get; set; }


        public string TenantID { get; set; }


        public string TypeName { get; set; }


        public string AssistID { get; set; }
    }
}
