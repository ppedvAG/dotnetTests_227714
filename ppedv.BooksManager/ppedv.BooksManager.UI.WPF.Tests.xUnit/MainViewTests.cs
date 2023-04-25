using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using ppedv.BooksManager.UI.WPF.Views;
using Xunit;

namespace ppedv.BooksManager.UI.WPF.Tests.xUnit
{
    public class MainViewTests : IDisposable
    {
        readonly string appPath = typeof(MainPage).Assembly.Location.Replace(".dll", ".exe");
        public MainViewTests()
        {
            app = FlaUI.Core.Application.Launch(appPath);
            app.WaitWhileMainHandleIsMissing();
            automation = new UIA3Automation();
            win = app.GetMainWindow(automation);
            win.WaitUntilClickable();
            win.WaitUntilEnabled();
        }

        FlaUI.Core.Application app;

        UIA3Automation automation;
        Window win;

        public void Dispose()
        {
            win.Close();
            automation.Dispose();
            app.Dispose();
        }

        [Fact]
        [Trait("", "UITest")]
        public void Click_load_button_should_display_some_Books()
        {
            win.FindFirstDescendant("mp").WaitUntilClickable();
            var loadBtn = win.FindFirstDescendant("b1").AsButton();
            loadBtn.Click();

            Thread.Sleep(100);
            var grid = win.FindFirstDescendant(x => x.ByAutomationId("g1")).AsDataGridView();

            grid.Rows.Length.Should().BeGreaterThan(1);
        }


        //[Fact]
        //[Trait("", "UITest")]
        //public void Click_load_button_should_display_some_Books()
        //{
        //    string appPath = typeof(MainPage).Assembly.Location.Replace(".dll", ".exe");

        //    var app = FlaUI.Core.Application.Launch(appPath);
        //    app.WaitWhileBusy();
        //    app.WaitWhileMainHandleIsMissing();
        //    try
        //    {
        //        using (var automation = new UIA3Automation())
        //        {
        //            var window = app.GetMainWindow(automation);
        //            window.FindFirstDescendant("mp").WaitUntilClickable();
        //            var loadBtn = window.FindFirstDescendant("b1").AsButton();

        //            loadBtn.WaitUntilClickable();
        //            loadBtn.Click();

        //            var grid = window.FindFirstDescendant(x => x.ByAutomationId("g1")).AsDataGridView();
        //            grid.Rows.Length.Should().BeGreaterThan(1);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        app.Close();
        //    }
        //}
    }
}

