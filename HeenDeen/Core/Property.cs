using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen.Core
{
    public sealed class Property<TType> where TType : class
    {
        private Compiler<TType> _compiler;
        private PropertyInfo _targetProperty;
        private object _intendedValue = null;

        public Property(Compiler<TType> compiler, PropertyInfo property)
        {
            _compiler = compiler;
            _targetProperty = property;
        }

        public Property<TType> AsA()
        {
            return this;
        }

        public Compiler<TType> Value(object value)
        {
            _intendedValue = value;
            return _compiler;
        }

        public TType Compute(TType instance)
        {
            _targetProperty.SetValue(instance, _intendedValue);
            return instance;
        }
    }
}
