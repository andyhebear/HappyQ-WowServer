using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

using Client.Input;
using Client.Threading;

namespace Client.ComponentModel.Design
{
    public abstract class ViewModelBase : NotifierBase
    {
        private readonly List<CommandBase> _commands;

        public List<CommandBase> Commands
        {
            get { return _commands; }
        }

        public bool IsDesignMode
        {
            get { return (bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue); }
        }

        public DispatcherProxy DispatcherProxy
        {
            get { return DispatcherProxy.CreateDispatcher(); }
        }

        protected ViewModelBase()
        {
            _commands = new List<CommandBase>();
        }

        protected CommandBase CreateCommand(Action execute)
        {
            return CreateCommand(execute, null);
        }

        protected CommandBase CreateCommand(Action execute, Func<bool> canExecute)
        {
            if (canExecute == null)
            {
                canExecute = () => true;
            }

            CommandBase command = new RelayCommand(execute, canExecute);

            RegisterCommand(command);

            return command;
        }

        protected CommandBase CreateCommand<T>(Action<T> execute)
            where T : class
        {
            return CreateCommand<T>(execute, null);
        }

        protected CommandBase CreateCommand<T>(Action<T> execute, Func<T, bool> canExecute)
            where T : class
        {
            if (canExecute == null)
                canExecute = o => true;

            CommandBase command = new RelayCommand<T>(execute, canExecute);

            RegisterCommand(command);

            return command;
        }

        protected bool RegisterCommand(CommandBase command)
        {
            if (!_commands.Contains(command))
            {
                _commands.Add(command);
                return false;
            }

            return true;
        }

        protected DispatcherTimer CreateTimer(TimeSpan interval, EventHandler onTick)
        {
            return CreateTimer(interval, onTick, false);
        }

        protected DispatcherTimer CreateTimer(TimeSpan interval, EventHandler onTick, bool start)
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = interval;
            timer.Tick += onTick;

            if (start)
            {
                timer.Start();
            }

            return timer;
        }
    }
}
