using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace simple_demo.Module.BusinessObjects
{
    [DefaultClassOptions, Persistent("DEPARTMENT")]
    public class Department : BaseObject
    {
        public Department(Session session) : base(session)
        {
            DepartmentRecorder.Add(this);
        }

        ~Department()
        {
            DepartmentRecorder.Kill(this);
        }

        string code;
        [DevExpress.Xpo.DisplayName("Code"), Persistent("CODE"), Size(50)]
        public string Code
        {
            get => code;
            set => SetPropertyValue("Code", ref code, value);
        }

        string name;
        [DevExpress.Xpo.DisplayName("Name"), Persistent("NAME"), RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get => name;
            set => SetPropertyValue("Name", ref name, value);
        }


        //create a space in memory to watch the debug memory grow up
        //this is not real business code, is just to show these is some Department instance not be disposed
        byte[] buffer = new byte[1024 * 1024 * 100];

    }
}
