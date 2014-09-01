using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen
{
    public class Property<TType>
    {
        private Compiler<TType> _compiler;
        private PropertyInfo _target;
        private object _value;

        public Property(Compiler<TType> compiler, PropertyInfo property)
        {
            _compiler = compiler;
            _target = property;
        }

        public Property<TType> AsA()
        {
            return this;
        }

        public Compiler<TType> Value(object value)
        {
            _value = value;
            return _compiler;
        }

        public TType Compute()
        {
            var instance = (TType)Activator.CreateInstance(typeof(TType));
            _target.SetValue(instance, _value);
            return instance;
        }
    }
}
