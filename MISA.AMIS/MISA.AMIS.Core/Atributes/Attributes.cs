using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Atributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISANotMap : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAEmail : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MISACode : Attribute
    {

    }
}
