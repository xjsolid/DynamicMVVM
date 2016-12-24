// need reference System.Componentmodel.DataAnnotations

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Dynamic;
using System.Diagnostics.Contracts;

namespace xPlusProject.DynaVMBase
{
    public class ViewModelBase : DynamicObject, INotifyPropertyChanged
    {
        #region ctor
        public ViewModelBase()
        {
        }
        #endregion

        #region props
        #endregion


        #region implentation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            var propertyExpression = property.Body as MemberExpression;
            PropertyInfo prop = propertyExpression.Member as PropertyInfo;
            NotifyPropertyChanged(prop.Name);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            if (!this.GetType().GetProperties().Any(x => x.Name == propertyName))
            {
                throw new ArgumentException(
                    "The property name does not exist in this type.",
                    "propertyName");
            }

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
