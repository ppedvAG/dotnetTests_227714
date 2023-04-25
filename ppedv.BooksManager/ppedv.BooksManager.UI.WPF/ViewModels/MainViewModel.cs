using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.BooksManager.Logic;
using ppedv.BooksManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.BooksManager.UI.WPF.ViewModels;

public class MainViewModel : ObservableObject
{

    public MainViewModel(IReadRepository repo)
    {
        bs = new BooksService(repo);
        LoadBooksCommand = new RelayCommand(() =>
        {
            BookList.Clear();
            repo.GetAll().ToList().ForEach(x => BookList.Add(x));
        });
    }

    BooksService bs;
    public ICommand LoadBooksCommand { get; }
    public ObservableCollection<Book> BookList { get; set; } = new ObservableCollection<Book>();
}
