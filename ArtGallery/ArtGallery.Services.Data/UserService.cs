namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.MessageConstants;

    public class UserService : IUserService
    {
        private readonly IAppRepository userRepo;
        private readonly IValidationService validationService;
        private readonly UserManager<ArtGalleryAccount> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ArtGalleryAccount> signInManager;

        public UserService(IAppRepository userRepo, SignInManager<ArtGalleryAccount> signInManager, IValidationService validationService, UserManager<ArtGalleryAccount> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userRepo = userRepo;
            this.validationService = validationService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public string Login(LoginInputViewModel model)
        {
            var user = this.userRepo
               .All<ArtGalleryUser>()
               .Where(u => u.UserName == model.Username)
               .Where(u => u.PasswordHash == this.CalculateHash(model.Password))
               .SingleOrDefault();

            return user?.Id;
        }

        public void Logout()
        {
            this.signInManager.SignOutAsync();
        }


        public (bool isRegister, string error) Register(RegisterInputViewModel model)
        {
            bool isRegister = false;
            string error = null;

            var (isValid, validationError) = this.validationService.ValidationModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            ShoppingCart cart = new ShoppingCart();

            ArtGalleryUser user = new ArtGalleryUser()
            {
                Email = model.Email,
                PasswordHash = this.CalculateHash(model.Password),
                FullName = model.FullName,
                UserName = model.Username,
                ShoppingCart = cart,
                ShoppingCartId = cart.Id,
            };

            try
            {
                this.userRepo.AddAsync(user);
                this.userRepo.SaveChanges();
            }
            catch (Exception)
            {
                error = "Could not save user in Database";
            }

            return (isRegister, error);
        }

        public string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }


        public IEnumerable<UserViewModel> GetAllUser(string userId)
        {
            return this.userRepo
                .All<UserViewModel>()
                .Where(u => u.UserId == userId)
                .ToList();
        }

        public string GetUserById(UserViewModel model)
        {
            var user = this.userRepo
                .All<ArtGalleryUser>()
                .SingleOrDefault(x => x.Id == model.UserId);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(InvalidUserId, model.UserId));
            }

            return user.Id;
        }

        public string GetIdByUsername(UserViewModel model)
        {
            var user = this.userRepo
                .All<ArtGalleryUser>()
                .SingleOrDefault(x => x.UserName == model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(InvalidUsername, model.UserName));
            }

            return user.Id;
        }

        public async Task<string> DeleteAsync(string userId)
        {
            var currentUser = await this.userRepo
                .AllWithDeleted<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.UrlImage)
                .SingleOrDefaultAsync();

            var id = currentUser?.Id ?? string.Empty;

            if (id == " ")
            {
                id = string.Empty;
            }

            return id;
        }
    }
}
