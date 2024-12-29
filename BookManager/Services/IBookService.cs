﻿using BookManager.Dtos;

namespace BookManager.Services
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        BookDto AddBook(BookCreateDto newBook);
        BookDto UpdateBook(int id, BookCreateDto newBook);
        BookDto GetBookById(int id);

        bool DeleteBook(int id);
    }
}