using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.UserViewsModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.UserQueries.UserQueriesById
{
    public class UserByIdQuery : IRequest<ResultViewModel<UserResponseAll>> 
    {
        public UserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
