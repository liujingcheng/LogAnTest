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
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(mockView);
            mockView.Loaded += Raise.Event<Action>();//此处应是触发，而不是订阅的含义

            mockView.Received().Render(Arg.Is<string>(s=>s.Contains("Hello World")));
        }

    }
}
