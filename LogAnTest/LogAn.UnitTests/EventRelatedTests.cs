using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class EventRelatedTests
    {
        [Test]
        public void Ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(mockView);
            mockView.Loaded += Raise.Event<Action>();//此处应是触发，而不是订阅的含义

            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void Ctor_WhenViewHasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            Presenter presenter = new Presenter(stubView, mockLogger);
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        [Test]
        public void EventFiringManual()
        {
            bool loaded = false;
            IView view = Substitute.For<IView>();
            view.Loaded += delegate { loaded = true; };

            view.Loaded += Raise.Event<Action>();

            Assert.IsTrue(loaded);
        }

    }
}
