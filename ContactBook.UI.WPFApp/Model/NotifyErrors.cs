using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

namespace ContactBook.UI.WPFApp.Model
{
    public abstract class NotifyErrors : ObservableObject, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public virtual bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public virtual IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else
                return null;
        }

        protected virtual void ChangeError(Func<bool> func, string property, string msg)
        {
            if (func())
                RemoveError(property, msg);
            else
                AddError(property, msg);
            RaisePropertyChanged(property);
        }

        protected virtual void AddError(string property, string msg)
        {
            if (msg == null)
                return;

            if (!_errors.ContainsKey(property))
            {
                _errors.Add(property, new List<string>() { msg });
            }
            else
            {
                if (!_errors[property].Exists(x => string.Equals(x, msg)))
                    _errors[property].Add(msg);
            }

            ErrorsChanged(null, new DataErrorsChangedEventArgs(property));
        }

        protected virtual void RemoveError(string property, string msg)
        {
            if (msg == null)
                return;

            if (_errors.ContainsKey(property))
            {
                _errors[property].RemoveAll(x => string.Equals(x, msg));
                if (_errors[property].Count == 0)
                    _errors.Remove(property);
            }

            ErrorsChanged(null, new DataErrorsChangedEventArgs(property));
        }
    }
}
