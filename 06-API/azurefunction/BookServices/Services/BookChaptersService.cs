﻿using BooksServiceSample.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BooksServiceSample.Services
{
    public class BookChaptersService : IBookChaptersService
    {
        private readonly ConcurrentDictionary<Guid, BookChapter> _memorychapters = new ConcurrentDictionary<Guid, BookChapter>();

        public void Add(BookChapter chapter)
        {
            chapter.Id = Guid.NewGuid();
            _memorychapters[chapter.Id] = chapter;
        }
        public void AddRange(IEnumerable<BookChapter> chapters)
        {
            foreach (var chapter in chapters)
            {
                chapter.Id = Guid.NewGuid();
                _memorychapters[chapter.Id] = chapter;
            }
        }
        public BookChapter Find(Guid id)
        {
            _memorychapters.TryGetValue(id, out BookChapter chapter);
            return chapter;
        }
        public IEnumerable<BookChapter> GetAll() => _memorychapters.Values;
        public BookChapter Remove(Guid id)
        {
            BookChapter removed;
            _memorychapters.TryRemove(id, out removed);
            return removed;
        }
        public void Update(BookChapter chapter) =>
            _memorychapters[chapter.Id] = chapter;
    }
}
