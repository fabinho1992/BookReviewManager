using Google.Apis.Books.v1.Data;
using Google.Apis.Books.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BookReviewManager.Domain.IServices;

namespace BookReviewManager.Infrastructure.Service
{
    public class GoogleBookApi : IGoogleBookApi
    {
        private readonly BooksService _booksService;
        private readonly IConfiguration _config;

        public GoogleBookApi(string apiKey, IConfiguration config)
        {
            _config = config;

            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = _config["KeyGoogleBooksApi:KeyApi"],
                ApplicationName = "BookReviewManager"
            });
            
        }

        public async Task<List<ApiBooksResponse>> SearchBooksAsync(string query, int maxResults)
        {
            maxResults = maxResults == 0 ? 10 : maxResults;

            var request = _booksService.Volumes.List(q: query);
            request.MaxResults = maxResults;

            var response = await request.ExecuteAsync();

            // Cria uma lista de ApiBooksResponse
            var bookResponses = response.Items?.Select(item => new ApiBooksResponse
            {
                Title = item.VolumeInfo.Title,
                Autor = string.Join(", ", item.VolumeInfo.Authors),
                YearOfRelease = item.VolumeInfo.PublishedDate?.Substring(0, 4) // Extrai o ano
            }).ToList() ?? new List<ApiBooksResponse>();

            return bookResponses;
        }

        //public async Task<List<ApiBooksResponse>> SearchBooksAsync(string query, int maxResults = 10)
        //{
        //    var request = _booksService.Volumes.List(q: query);
        //    request.MaxResults = maxResults;

        //    var response = await request.ExecuteAsync();

        //    // Cria uma lista de ApiBooksResponse
        //    var bookResponses = response.Items?.Select(item => new ApiBooksResponse
        //    {
        //        Title = item.VolumeInfo.Title,
        //        Autor = string.Join(", ", item.VolumeInfo.Authors)
        //    }).ToList() ?? new List<ApiBooksResponse>();

        //    return bookResponses;
        //}
    }
}
