using System.Windows.Controls;

using ppedv.BooksManager.UI.WPF.ViewModels;

namespace ppedv.BooksManager.UI.WPF.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
