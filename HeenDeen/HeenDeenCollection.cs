using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeenDeen
{
    public sealed class HeenDeenCollection<TType>
    {
        private List<TType> _collection;
        private int _collectionSize;
        private HeenDeen<TType> _config;

        public HeenDeenCollection()
        {
            _collection = new List<TType>();
            _collectionSize = 0;
            _config = new HeenDeen<TType>();
        }

        public HeenDeenCollection<TType> GiveMe(int collectionSize)
        {
            _collectionSize = collectionSize;
            return this;
        }

        public HeenDeenCollection<TType> ConfigureWith(Action<HeenDeen<TType>> config)
        {
            config(_config);
            return this;
        }

        public ICollection<TType> DoIt()
        {
            for (int i = 0; i < _collectionSize; i++)
            {
                TType obj = _config.DoIt();
                _collection.Add(obj);
            }
            return _collection;
        }
    }
}
