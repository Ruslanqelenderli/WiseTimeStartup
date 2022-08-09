using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;
using WiseTime.Business.DTOs.ExamDtos;
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

            CreateMap<Exam,ExamDto>();
            CreateMap<ExamDto, Exam>();

            CreateMap<ExamType, ExamTypeDto>();
            CreateMap<ExamTypeDto, ExamType>();

            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();

            CreateMap<DataReturnResult<Question>, BusinessReturnResult<QuestionDto>>();
            CreateMap<BusinessReturnResult<QuestionDto>, DataReturnResult<Question>>();

            CreateMap<DataReturnResult<Post>, BusinessReturnResult<PostDto>>();
            CreateMap<BusinessReturnResult<PostDto>, DataReturnResult<Post>>();

            CreateMap<DataReturnResult<Category>, BusinessReturnResult<CategoryDto>>();
            CreateMap<BusinessReturnResult<CategoryDto>, DataReturnResult<Category>>();

            CreateMap<DataReturnResult<Comment>, BusinessReturnResult<CommentDto>>();
            CreateMap<BusinessReturnResult<CommentDto>, DataReturnResult<Comment>>();

            CreateMap<DataReturnResult<AnswerComment>, BusinessReturnResult<CommentReplyDto>>();
            CreateMap<BusinessReturnResult<CommentReplyDto>, DataReturnResult<AnswerComment>>();

            CreateMap<DataReturnResult<Exam>, BusinessReturnResult<ExamDto>>();
            CreateMap<BusinessReturnResult<ExamDto>, DataReturnResult<Exam>>();

            CreateMap<DataReturnResult<ExamType>, BusinessReturnResult<ExamTypeDto>>();
            CreateMap<BusinessReturnResult<ExamTypeDto>, DataReturnResult<ExamType>>();
        }
    }
}
