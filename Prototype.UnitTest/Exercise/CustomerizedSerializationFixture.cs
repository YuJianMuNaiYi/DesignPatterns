using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.UnitTest.Exercise
{
    [TestClass]
    public class CustomerizedSerializationFixture
    {
        [Serializable]
        public class Project
        {
            /// <summary>
            /// 结项年份
            /// </summary>
            public int EndYear { get; set; }

            /// <summary>
            /// 项目资金规模(万元)
            /// </summary>
            public double Scale { get; set; }
        }

        [Flags]
        enum QualificationOptions
        {
            Assisstant,      //  助理级
            Professional,    //  专家级
            Senior,          //  高级、资深级
            Principal        //  主任、主管级
        }
    }
}
