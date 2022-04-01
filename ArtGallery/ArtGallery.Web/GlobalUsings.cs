global using System.Diagnostics.CodeAnalysis;
global using System.Reflection;
global using ArtGallery.Common;

// Data
global using ArtGallery.Data;
global using ArtGallery.Data.Common;
global using ArtGallery.Data.Models;
global using ArtGallery.Data.Seeding;

// Services
global using ArtGallery.Services.Data;
global using ArtGallery.Services.Data.Contracts;
global using ArtGallery.Services.Mapping;

// Web ModelBinders & ViewModels
global using ArtGallery.Web.ModelBinders;
global using ArtGallery.Web.ViewModels.Administrator;
global using ArtGallery.Web.ViewModels.ArtStore;
global using ArtGallery.Web.ViewModels.BlogPosts;
global using ArtGallery.Web.ViewModels.Events;
global using ArtGallery.Web.ViewModels.Home;
global using ArtGallery.Web.ViewModels.Privacy;
global using ArtGallery.Web.ViewModels.Settings;
global using ArtGallery.Web.ViewModels.ShoppingCart;
global using ArtGallery.Web.ViewModels.Users;

global using CloudinaryDotNet;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using static ArtGallery.Common.GlobalConstants;

#pragma warning disable SA1404 // Code analysis suppression should have justification
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1200:Using directives should be placed correctly", Justification = "<Pending>")]
#pragma warning restore SA1404 // Code analysis suppression should have justification
