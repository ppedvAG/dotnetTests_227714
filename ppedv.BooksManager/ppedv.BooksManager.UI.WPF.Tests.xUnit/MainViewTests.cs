using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using ppedv.BooksManager.UI.WPF.Views;
using Xunit;

namespace ppedv.BooksManager.UI.WPF.Tests.xUnit
{
    public class MainViewTests
    {
        [Fact]
        [Trait("", "UITest")]
        public void Click_load_button_should_display_some_Books()
        {
            var appPath = typeof(MainPage).Assembly.Location.Replace(".dll", ".exe");
            using var app = FlaUI.Core.Application.Launch(appPath);
            using var automation = new UIA3Automation();

            var win = app.GetMainWindow(automation);

            var loadBtn = win.FindFirstDescendant(x => x.ByAutomationId("b1")).AsButton();
            loadBtn.Click();

            var grid = win.FindFirstDescendant(x => x.ByAutomationId("g1")).AsDataGridView();
            grid.Rows.Length.Should().BeGreaterThan(1);

            app.Close();
        }
    }
}

