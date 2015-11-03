using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Collections
{
    public class Cache<T, U> : IDisposable
    {
        private readonly Dictionary<T, CacheItem<U>> _internalCache;
        private readonly TimeSpan _timeToExpire;

        public Cache(TimeSpan timeToExpire, int capacity)
        {
            _timeToExpire = timeToExpire;
            _internalCache = new Dictionary<T, CacheItem<U>>(capacity);
        }

        public void Clean()
        {
            var keys = _internalCache.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                T key = keys[i];
                var cacheItem = _internalCache[key];

                if (cacheItem.IsExpired)
                    _internalCache.Remove(key);
            }
        }

        public void Dispose()
        {
            foreach (var cacheItem in _internalCache.Values)
                cacheItem.Dispose();
        }

        public U this[T index]
        {
            get
            {
                U item = default(U);
                CacheItem<U> cacheItem;

                if (_internalCache.TryGetValue(index, out cacheItem))
                    item = cacheItem.Value;

                return item;
            }
            set
            {
                CacheItem<U> cacheItem;

                if (!_internalCache.TryGetValue(index, out cacheItem))
                {
                    cacheItem = new CacheItem<U>(value, _timeToExpire);
                    _internalCache.Add(index, cacheItem);
                }

                cacheItem.Value = value;
            }
        }

        private class CacheItem<TValueType> : IDisposable
        {
            private TValueType _value;
            private DateTime _lastAccess;
            private readonly TimeSpan _timeToExpire;

            public TValueType Value
            {
                get
                {
                    _lastAccess = DateTime.Now;
                    return _value;
                }
                set
                {
                    _lastAccess = DateTime.Now;
                    _value = value;
                }
            }

            public CacheItem(TValueType value, TimeSpan timeToExpire)
            {
                _value = value;
                _lastAccess = DateTime.Now;
                _timeToExpire = timeToExpire;
            }

            public bool IsExpired
            {
                get { return DateTime.Now >= _lastAccess + _timeToExpire; }
            }

            public void Dispose()
            {
                if (_value is IDisposable)
                    ((IDisposable)_value).Dispose();
            }
        }
    }
}
