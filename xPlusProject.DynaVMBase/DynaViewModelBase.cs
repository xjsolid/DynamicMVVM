using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace xPlusProject.DynaVMBase
{
    public class DynaViewModelBase<T> : ViewModelBase
    {
        #region ctor
        public DynaViewModelBase(T modelObject)
        {
            this.ModelObject = modelObject;
        }
        #endregion

        #region props
        public T ModelObject { get; private set; }
        #endregion

        #region DynamicObject overrides
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string propertyName = binder.Name;
            PropertyInfo property = this.ModelObject.GetType().GetProperty(propertyName);

            if (property == null || property.CanRead == false)
            {
                result = null;
                return false;
            }

            result = property.GetValue(this.ModelObject, null);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string propertyName = binder.Name;
            PropertyInfo property = this.ModelObject.GetType().GetProperty(propertyName);

            if (property == null || property.CanWrite == false)
                return false;

            property.SetValue(this.ModelObject, value, null);

            this.NotifyPropertyChanged(propertyName);
            var affectsProps = property.GetCustomAttributes(typeof(AffectsOtherPropertyAttribute), true);
            foreach (AffectsOtherPropertyAttribute otherPropertyAttr in affectsProps)
            {
                this.NotifyPropertyChanged(otherPropertyAttr.AffectsProperty);
            }

            return true;
        }
        #endregion

    }
}
