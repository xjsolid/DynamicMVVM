using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xPlusProject.DynaVMBase
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class AffectsOtherPropertyAttribute : Attribute
    {
        public AffectsOtherPropertyAttribute(string otherPropertyName)
        {
            this.AffectsProperty = otherPropertyName;
        }
        public string AffectsProperty { get; private set; } }
}
