using System;
using System.Collections.Generic;

namespace RequestInjectionTest.Models
{
    public class TestModel
    {
        public string TestString { get; set; }
        public int TestInt { get; set; }
        public DateTime TestDateTime { get; set; }
        public ChildClass1 ChildClass1 { get; set; }
        public List<ChildClass2> ChildClass2 { get; set; }
    }
}
