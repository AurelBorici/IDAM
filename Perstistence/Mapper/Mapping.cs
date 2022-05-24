using Application.RequestModels.CommandRequestModel.Role;
using Application.RequestModels.CommandRequestModel.User;
using Application.ResponseModel.CommandResponseModel.Role;
using Application.ResponseModel.CommandResponseModel.User;
using AutoMapper;
using Domain.Models;

namespace Perstistence.Mapper;

public class Mapping : Profile
{
    public Mapping()
    {
        #region User
        CreateMap<User, AddUserRequestModel>().ReverseMap();
        CreateMap<AddUserResponseModel, AddUserRequestModel>().ReverseMap();
        #endregion

        #region Role
        CreateMap<Role, AddRoleRequestModel>().ReverseMap();
        CreateMap<AddRoleResponseModel, AddRoleRequestModel>().ReverseMap();
        #endregion
    }
}
