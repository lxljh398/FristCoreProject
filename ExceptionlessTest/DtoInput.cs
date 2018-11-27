using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionlessTest
{
    /// <summary>
    /// Dto
    /// </summary>
    public class DtoInput
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }
    }
}
