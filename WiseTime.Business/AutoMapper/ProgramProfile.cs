using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;
using WiseTime.Data.Concrete.EntityFramework.ReturnResult;
using WiseTime.Entity.Entities;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.Business.AutoMapper
{
    public class ProgramProfile:Profile
    {
        public ProgramProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<AnswerComment, CommentReplyDto>();
            CreateMap<CommentReplyDto, AnswerComment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<GetAllReturnResult<Post>, BusinessReturnResult<PostDto>>();
            CreateMap<BusinessReturnResult<PostDto>, GetAllReturnResult<Post>>();

            CreateMap<GetAllReturnResult<Category>, BusinessReturnResult<CategoryDto>>();
            CreateMap<BusinessReturnResult<CategoryDto>, GetAllReturnResult<Category>>();

            CreateMap<GetAllReturnResult<Comment>, BusinessReturnResult<CommentDto>>();
            CreateMap<BusinessReturnResult<CommentDto>, GetAllReturnResult<Comment>>();

            CreateMap<GetAllReturnResult<AnswerComment>, BusinessReturnResult<CommentReplyDto>>();
            CreateMap<BusinessReturnResult<CommentReplyDto>, GetAllReturnResult<AnswerComment>>();
        }
    }
}
