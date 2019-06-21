using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;

namespace Elasticsearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //多uris
            var uris = new Uri[] { new Uri("http://localhost:9200") };
            var pool = new StaticConnectionPool(uris);
            var settings = new ConnectionSettings(pool).DefaultIndex("coredata");
            var client = new ElasticClient(settings);


            //var searchResponse = client.Search<CoreData>(s => s
            //                                             .From(0)
            //                                             .Size(5)
            //                                             .Query(q => q
            //                                                  .Match(m => m
            //                                                     .Field(f => f.Name)
            //                                                     .Query("浙江和联电力科技有限公司")
            //                                                  )
            //                                             )
            //                                             .Index("coredata")
            //                                             .Type("coredata")
            //                                         );



            //List<QueryContainerDescriptor<CoreData>> queryList = new List<QueryContainerDescriptor<CoreData>>();
            //QueryContainerDescriptor<CoreData> queryTitle = new QueryContainerDescriptor<CoreData>();
            ////queryTitle.Term(m => m.Field("Name.keyword").Value("浙江金陵药材开发有限公司"));
            ////queryTitle.MatchPhrase(m => m.Field("Name.keyword").Query("金陵药材"));
            //queryTitle.MatchPhrase(ma => ma.Field(x => x.title).Query("浙江省"));
            //queryList.Add(queryTitle);

            //QueryContainerDescriptor<CoreData> queryTenantID = new QueryContainerDescriptor<CoreData>();
            //queryTenantID.Terms(t => t.Field("tenantID.keyword").Terms(new Guid[] { Guid.Parse("ffc739ba-2f95-409d-bc07-e3d3ee610f35") }));
            //queryList.Add(queryTenantID);

            //QueryContainerDescriptor<CoreData> queryTable = new QueryContainerDescriptor<CoreData>();
            //queryTable.Term(t => t.Field("typeName.keyword").Value("land"));
            //queryList.Add(queryTable);


            //QueryContainerDescriptor<CoreData> queryStoreID = new QueryContainerDescriptor<CoreData>();
            //queryStoreID.Term(t => t.Field("storeID").Value(10));
            //queryList.Add(queryStoreID);



            List<QueryContainerDescriptor<ESCompany>> queryList = new List<QueryContainerDescriptor<ESCompany>>();
            QueryContainerDescriptor<ESCompany> queryTitle = new QueryContainerDescriptor<ESCompany>();
            //queryTitle.Term(m => m.Field("Name.keyword").Value("浙江金陵药材开发有限公司"));
            //queryTitle.MatchPhrase(m => m.Field("Name.keyword").Query("金陵药材"));
            queryTitle.MatchPhrase(m => m.Field(x => x.name).Query("长兴和平石船坞"));
            queryList.Add(queryTitle);

            QueryContainerDescriptor<ESCompany> queryDistrict = new QueryContainerDescriptor<ESCompany>();
            //queryDistrict.Terms(t => t.Field("districtA.keyword").Terms(new string[] { so.DistrictA }));
            queryDistrict.Term(t => t.Field("districtA").Value(174));
            queryList.Add(queryDistrict);

            var searchRes = client.Search<ESCompany>(s =>
                            s.Query(q =>
                                q.Bool(b =>
                                    b.Must(queryList.ToArray()))
                                ).Index("company").Type("escompany")
                                .From(0)
                                .Size(100)
                            );

            long total = searchRes.Total;


            //var secondSearchResponse = client.Search<CoreData>(new SearchRequest<CoreData>
            //{
            //    Query = new TermQuery { Field = "name.keyword", Value = "浙江金陵药材开发有限公司" } 
            //});

            //var searchResponse = client.Search<CoreData>(s => s
            //                                            .Query(q => q
            //                                                .Wildcard(m => m.Field(f=> f.name).Value("金陵药材")
            //                                                )
            //                                            )
            //                                        );

            Console.WriteLine();
        }



        /// <summary>
        /// 获取索引核心数据源
        /// </summary>
        public class CoreData
        {
            /// <summary>
            /// 源ID
            /// </summary>
            public int originID { get; set; }

            /// <summary>
            /// 检索列
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 联系人号码
            /// </summary>
            public string mobile { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int storeID { get; set; }

            /// <summary>
            /// 数据类型
            /// </summary>
            public string typeName { get; set; }

            /// <summary>
            /// 租户ID
            /// </summary>
            public Guid tenantID { get; set; }
        }

        /// <summary>
        /// ES企业数据
        /// </summary>
        public class ESCompany
        {
            /// <summary>
            /// 企业名称
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int? districtA { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int? districtB { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int? districtC { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int? districtD { get; set; }

            /// <summary>
            /// 地址
            /// </summary>
            public string address { get; set; }

            /// <summary>
            /// 坐标
            /// </summary>
            public decimal? pointX { get; set; }

            /// <summary>
            /// 坐标
            /// </summary>
            public decimal? pointY { get; set; }

            /// <summary>
            /// 传真
            /// </summary>
            public string fax { get; set; }

            /// <summary>
            /// 企业类型：外资、中外合资、无形资产出资、境外、内资
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 销售额
            /// </summary>
            public string annualOutputValue { get; set; }

            /// <summary>
            /// 注册资金
            /// </summary>
            public string ownFunds { get; set; }

            /// <summary>
            /// 经营范围
            /// </summary>
            public string businessScope { get; set; }

            /// <summary>
            /// 产品
            /// </summary>
            public string operatingProduct { get; set; }

            /// <summary>
            /// 工业区
            /// </summary>
            public string industrialPark { get; set; }

            /// <summary>
            /// 联系人名称
            /// </summary>
            public string contactName { get; set; }

            /// <summary>
            /// 座机
            /// </summary>
            public string tel { get; set; }

            /// <summary>
            /// 手机
            /// </summary>
            public string mobile { get; set; }

            /// <summary>
            /// 邮编
            /// </summary>
            public string postcode { get; set; }

            /// <summary>
            /// 企业规模
            /// </summary>
            public string companyNumber { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public string createDate { get; set; }

            /// <summary>
            /// 产业ID
            /// </summary>
            public int? industryID { get; set; }

            /// <summary>
            /// ID
            /// </summary>
            public int id { get; set; }
        }
    }
}
