using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen
{
    public class Compiler<TType>
    {
        private List<TType> _values;
        private int _collectionSize = 0;

        public Compiler<TType> MakeMe(int collectionSize)
        {   
            _collectionSize = collectionSize;
            _values = new List<TType>(collectionSize);
            return this;
        }

        public Property<TType> Init(Expression<Func<TType, object>> selector)
        {
            MemberInfo member = ((MemberExpression)selector.Body).Member;
            var property = (PropertyInfo)member;
            var subject = new Property<TType>(this, property);
            _values.Add(subject);
            return subject;
        }

        public ICollection<TType> Compile()
        {
            List<TType> computedList = new List<TType>();
            foreach (var subject in _values)
            {
                computedList.Add(subject.Compute());
            }
            return computedList;
        }
    }
}
