using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        namespace Post
        {
            public class MachineTag
            {
                public string Value { get; set; }
                public string Action { get; set; }
            }

            public class MachineScan
            {
                public string Comment { get; set; }

                public string ScanType { get; set; }
            }

            public class IsolateMachine
            {
                public string Comment { get; set; }
                public string IsolationType { get; set; }
            }

            public class UnIsolateMachine
            {
                public string Comment { get; set; }
            }

            public class CollectInvestigationPackage
            {
                public string Comment { get; set; }
            }
        }
    }
}