using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.UserViewsModel;
using BookReviewManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.UserQueries.UserQuerieList
{
    public class UserListQuery : ParametrosPaginacao ,IRequest<ResultViewModel<List<UserResponse>>>
    {
        public UserListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
