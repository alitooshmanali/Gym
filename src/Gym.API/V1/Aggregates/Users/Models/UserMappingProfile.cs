using AutoMapper;
using Gym.API.V1.Models;
using Gym.Application.Aggregates.Users;
using Gym.Application.Aggregates.Users.Commands.CreateUser;
using Gym.Application.Aggregates.Users.Queries.GetUserCollection;

namespace Gym.API.V1.Aggregates.Users.Models
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SearchModel, GetUserCollectionQuery>();
            CreateMap<UserRequest, CreateUserCommand>();
            CreateMap<UserQueryResult, UserResponse>();
        }
    }
}
