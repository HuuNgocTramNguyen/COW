using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Linq
{
    class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return string.Format("CategoryID = {0}, CategoryName= {1}, ",
                 CategoryId, CategoryName);
        }


    }
}
