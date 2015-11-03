using System;

namespace Client
{
    public abstract class WeakActionBase
    {
        private WeakReference _reference;

        public WeakActionBase(object target)
        {
            _reference = new WeakReference(target);
        }

        public virtual bool IsAlive
        {
            get
            {
                if (_reference == null)
                {
                    return false;
                }

                return _reference.IsAlive;
            }
        }

        public virtual object Target
        {
            get
            {
                if (_reference == null)
                {
                    return null;
                }

                return _reference.Target;
            }
        }

        public virtual void MarkForDeletion()
        {
            _reference = null;
        }
    }

    public sealed class WeakAction : WeakActionBase
    {
        private readonly Action _action;

        public WeakAction(object target, Action action)
            : base(target)
        {
            _action = action;
        }

        public void Execute()
        {
            if (_action != null
                && IsAlive)
            {
                _action();
            }
        }
    }

    public sealed class WeakAction<T> : WeakActionBase
    {
        private readonly Action<T> _action;

        public WeakAction(object target, Action<T> action)
            : base(target)
        {
            _action = action;
        }

        public void Execute(T item)
        {
            if (_action != null
                && IsAlive)
            {
                _action(item);
            }
        }
    }
}
