﻿using BookReviewManager.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IServices
{
    public interface IGoogleBookApi
    {
        Task<List<ApiBooksResponse>> SearchBooksAsync(string query, int maxResults);
    }
}
