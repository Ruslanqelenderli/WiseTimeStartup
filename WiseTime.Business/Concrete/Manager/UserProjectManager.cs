using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.Concrete.ReturnResult;
using WiseTime.Business.DTOs;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.Business.Concrete.Manager
{
    public class UserProjectManager : IUserProjectService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        public UserProjectManager(IMapper mapper,UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<UserDto>> Create(UserDto model)
        {
            var returnresult = new BusinessReturnResult<UserDto>();
            var data = mapper.Map<User>(model);
            data.UserName = data.Email;
            var result = await userManager.CreateAsync(data, data.PasswordHash);
            if (result.Succeeded)
            {

                returnresult.MainMethod(null, true, "Succeed");
                return returnresult;
            }
            else
            {
                returnresult.MainMethod(null, false, "Create error");
                return returnresult;
            }
            
        }

        public async Task<BusinessReturnResult<UserDto>> Edit(UserDto model)
        {
            var returnresult = new BusinessReturnResult<UserDto>();
            var data = mapper.Map<User>(model);

            var values = await userManager.FindByNameAsync(model.UserName);

            string password = data.PasswordHash;
            values.PasswordHash= userManager.PasswordHasher.HashPassword(data,password);
            var result = await userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                 returnresult.MainMethod(null, true, "Succeed");
                return returnresult;
            }
            else
            {
                returnresult.MainMethod(null, false, "Update error");
                return returnresult;
            }
        }

        public async Task<string> GenerateToken(UserDto dto)
        {
            var result = new BusinessReturnResult<UserDto>();
            var user = await  userManager.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user != null)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                return token;
            }
            return "Error";
        }

        public async Task<BusinessReturnResult<UserDto>> GetAll()
        {
            var result = new BusinessReturnResult<UserDto>();
            var users=await userManager.Users.ToListAsync();
            var data =  mapper.Map<ICollection<UserDto>>(users);
            result.MainMethod(data, true, "Succeed");
            return result;
        }

        public async Task<BusinessReturnResult<UserDto>> GetByEmail(string email)
        {
            var result = new BusinessReturnResult<UserDto>();
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            var dto = mapper.Map<UserDto>(user);

            var data = new List<UserDto>();
            data.Add(dto);
            result.MainMethod(data, true, "Succeed");
            return result;
        }

        public async Task<BusinessReturnResult<UserDto>> GetById(int id)
        {
            var result = new BusinessReturnResult<UserDto>();
            var user =await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var data = mapper.Map<ICollection<UserDto>>(user);
            result.MainMethod(data, true, "Succeed");
            return result;
        }

        public async Task<BusinessReturnResult<UserDto>> Remove(UserDto model)
        {
            var returnresult = new BusinessReturnResult<UserDto>();
            var data = mapper.Map<User>(model);
            var result = await userManager.DeleteAsync(data);
            if (result.Succeeded)
            {
                returnresult.MainMethod(null, true, "Succeed");
                return returnresult;
            }
            else
            {
                returnresult.MainMethod(null, false, "Remove error");
                return returnresult;
            }
        }
    }
}
