using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen
{
    public sealed class HeenDeen<TType>
    {
        TType _target;
        PropertyInfo _targetProperty;

        public HeenDeen()
        {
            _target = (TType)Activator.CreateInstance(typeof(TType));
        }

        public HeenDeen<TType> Init<TValue>(Expression<Func<TType, TValue>> selector)
        {
            MemberInfo member = ((MemberExpression)selector.Body).Member;
            _targetProperty = (PropertyInfo)member;
            return this;
        }

        public HeenDeen<TType> AsA()
        {
            return this;
        }

        public HeenDeen<TType> Constant(object value)
        {
            _targetProperty.SetValue(_target, value);
            return this;
        }

        public TType DoIt()
        {
            return _target;
        }
    }
}
