using System.Windows.Controls;

using MahApps.Metro.Controls;

using ppedv.BooksManager.UI.WPF.Contracts.Views;
using ppedv.BooksManager.UI.WPF.ViewModels;

namespace ppedv.BooksManager.UI.WPF.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();
}
