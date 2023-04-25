﻿namespace ppedv.BooksManager.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<string> Authors { get; set; } = new HashSet<string>();
    }
}