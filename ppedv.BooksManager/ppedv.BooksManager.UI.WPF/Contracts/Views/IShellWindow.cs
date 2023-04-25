using System.Windows.Controls;

namespace ppedv.BooksManager.UI.WPF.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();
}
