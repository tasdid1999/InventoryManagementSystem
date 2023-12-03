using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity
{
    public class TestOuter
    {
        public string Name { get; set; }

        public List<TestInner> Inner { get; set;}
    }
}
