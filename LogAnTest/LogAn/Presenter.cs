using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn
{
    public class Presenter
    {
        private readonly IView _view;
        private readonly ILogger _logger;

        public Presenter(IView view)
        {
            _view = view;
            this._view.Loaded += OnLoaded;
        }
        public Presenter(IView view, ILogger logger)
        {
            _view = view;
            _logger = logger;
            this._view.Loaded += OnLoaded;
            this._view.ErrorOccured += delegate
            {
                _logger.LogError("fake error");
            };
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }

    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
    }
}
