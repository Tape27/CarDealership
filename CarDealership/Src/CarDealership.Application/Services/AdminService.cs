using System.Security.Authentication;
using Application.Common.Exceptions;
using AutoMapper;
using CarDealership.Application.Abstractions;
using CarDealership.Application.Abstractions.Auth;
using CarDealership.Application.Models.Dto.AdminDto;
using CarDealership.Application.Models.ViewModels.AdminVm;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly ICookiesProvider _cookiesProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IValidator<AdminModel> _adminValidator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IImageValidator _imageValidator;
        public AdminService(ICookiesProvider cookiesProvider,
            IHttpContextAccessor httpContextAccessor,
            IValidator<AdminModel> adminValidator,
            IAdminRepository adminRepository,
            IMapper mapper,
            IPasswordHasher passwordHasher,
            IImageValidator imageValidator)
        {
            _cookiesProvider = cookiesProvider;
            _httpContextAccessor = httpContextAccessor;
            _adminValidator = adminValidator;
            _adminRepository = adminRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _imageValidator = imageValidator;
        }

        public async Task IncrementClosedOrderByCookies()
        {
            int? id = _cookiesProvider.GetIdByCookies();

            if (id != null)
            {
                await _adminRepository.IncrementCompletedOrdersById(id.Value);
            }
        }
        public async Task<AdminClaimDto> GetAdminForClaim(int id)
        {
            var admin = await _adminRepository.GetById(id);

            return _mapper.Map<AdminClaimDto>(admin);
        }
        private async Task IsValidModel(AdminModel adminModel)
        {
            var validationResult = await _adminValidator.ValidateAsync(adminModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
        
        private async Task<bool> IsAdminLoginUnique(string login)
        {
            return await _adminRepository.IsFreeLogin(login);
        }

        public async Task Update(UpdateAdminDto updAdmin)
        {

            var oldAdmin = await _adminRepository.GetById(updAdmin.Id);

            if (oldAdmin == null || oldAdmin.Id != updAdmin.Id)
            {
                throw new NotFoundException(nameof(oldAdmin), updAdmin.Id);
            }

            if (oldAdmin.Login != updAdmin.Login)
            {
                if (!await IsAdminLoginUnique(updAdmin.Login))
                {
                    throw new ValidationException("This login already in use");
                }
            }

            var adminModel = new AdminModel
            {
                Id = updAdmin.Id,
                FullName = updAdmin.FullName,
                Login = updAdmin.Login,
                Role = updAdmin.Role,
                Password = updAdmin.Password
            };

            if (updAdmin.Image != null)
            {
                if (!await _imageValidator.IsValidJpegFile(updAdmin.Image))
                {
                    throw new ValidationException("Incorrect image file");
                }

                if (!string.IsNullOrEmpty(oldAdmin.ImageUrl))
                {
                    await _adminRepository.DeleteImage(oldAdmin.ImageUrl);
                }

                adminModel.ImageUrl = await _adminRepository.SaveImage(updAdmin.Image);
            }
            else
            {
                adminModel.ImageUrl = oldAdmin.ImageUrl;
            }

            if (string.IsNullOrEmpty(updAdmin.Password))
            {
                adminModel.Id = oldAdmin.Id;
                adminModel.Password = oldAdmin.Password;
                await IsValidModel(adminModel);
            }
            else
            {
                await IsValidModel(adminModel);
                adminModel.Password = _passwordHasher.Generate(adminModel.Password!);
            }

            await _adminRepository.Update(adminModel);

            
        }

        public async Task<AdminVm> GetAdminById(int id)
        {
            var admin = await _adminRepository.GetById(id);

            if (admin == null || admin.Id != id)
            {
                throw new NotFoundException(nameof(admin), id);
            }

            return _mapper.Map<AdminVm>(admin);
        }

        public async Task<AdminListVm> GetAllAdmins()
        {
           var admins = await _adminRepository.GetAll();

           var adminsDto = admins.Select(admin => _mapper.Map<AdminVm>(admin));

           return new AdminListVm { Admins = adminsDto };
        }

        public async Task Register(CreateAdminDto newAdmin)
        {
            if (!await IsAdminLoginUnique(newAdmin.Login))
            {
                throw new ValidationException("This login already in use");
            }

            string imageUrl = string.Empty;

            if (newAdmin.Image != null)
            {
                if (!await _imageValidator.IsValidJpegFile(newAdmin.Image))
                {
                    throw new ValidationException("Incorrect image file");
                }
                imageUrl = await _adminRepository.SaveImage(newAdmin.Image);
            }

            var adminModel = new AdminModel
            {
                FullName = newAdmin.FullName,
                Login = newAdmin.Login,
                Password = newAdmin.Password,
                Role = newAdmin.Role,
                CountClosedOrders = 0,
                DateLastAuth = null,
                ImageUrl = imageUrl,
            };

            await IsValidModel(adminModel);

            adminModel.Password = _passwordHasher.Generate(newAdmin.Password);

            await _adminRepository.Create(adminModel);
        }

        public bool IsAuthorized()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        public async Task<bool> Login(string login, string password)
        {
            var admin = await _adminRepository.GetByLogin(login);

            if (admin == null)
            {
                throw new AuthenticationException("Wrong login or password");
            }

            var result = _passwordHasher.Verify(password, admin.Password);

            if (!result)
            {
                throw new AuthenticationException("Wrong login or password");
            }

            var adminClaimDto = _mapper.Map<AdminClaimDto>(admin);

            await _cookiesProvider.Set(adminClaimDto);

            await _adminRepository.SetDateLastAuthById(adminClaimDto.Id);

            return true;
        }

        public async Task Logout()
        {
            await _httpContextAccessor!.HttpContext!.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task DeleteAdmin(int id)
        {
            string? url = await _adminRepository.GetImageUrlById(id);

            if (!string.IsNullOrEmpty(url))
            {
                await _adminRepository.DeleteImage(url);
            }

            await _adminRepository.Delete(id);
        }
    }
}
