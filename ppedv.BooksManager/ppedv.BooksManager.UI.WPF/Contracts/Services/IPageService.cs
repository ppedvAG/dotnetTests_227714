﻿using System.Windows.Controls;

namespace ppedv.BooksManager.UI.WPF.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
