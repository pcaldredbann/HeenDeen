using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen.Core
{
    public class Compiler<TType> where TType : class
    {
        private List<Property<TType>> _properties;
        private int _collectionSize = 0;

        public Compiler<TType> MakeMe(int collectionSize)
        {
            _properties = new List<Property<TType>>();
            _collectionSize = collectionSize;
            return this;
        }

        public Property<TType> Init<TDataType>(Expression<Func<TType, TDataType>> selector)
        {
            MemberExpression exp = (MemberExpression)selector.Body;
            PropertyInfo prop = (PropertyInfo)exp.Member;
            Property<TType> subject = new Property<TType>(this, prop);
            _properties.Add(subject);
            return subject;
        }

        public ICollection<TType> Compile()
        {
            List<TType> result = new List<TType>();

            for (int i = 0; i < _collectionSize; i++)
            {
                TType instance = (TType)Activator.CreateInstance(typeof(TType));
                foreach (Property<TType> property in _properties)
                {
                    property.Compute(instance);
                }
                result.Add(instance);
            }
            return result;
        }
    }
}
