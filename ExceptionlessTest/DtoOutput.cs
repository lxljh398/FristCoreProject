using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionlessTest
{
    /// <summary>
    /// 输出
    /// </summary>
    public class DtoOutput
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 学生集合
        /// </summary>
        public List<Stu> Stus { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public class Stu
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 年龄
            /// </summary>
            public int Age { get; set; }
        }
    }
}
