namespace ArtGallery.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "ArtGallery";
        public const string AdministratorRoleName = "Admiinistrator";
        public const string GalleryManagerRoleName = "Manager";
        public const string CloudName = "art-gallery";

        public static class AccountSeeding
        {
            public const string Password = "123455";
            public const string AdminEmail = "admin@admin.com";
            public const string GalleryManagerEmail = "manager@manager.com";
            public const string UserEmail = "user@user.com";
        }

        public static class ArtGalleryUser
        {
            public const int FullNaneMinLenth = 90;
            public const int FullNameMaxLenth = 500;
        }

        public static class Event
        {
            public const int EventNameMinLenth = 8;
            public const int EventNameMaxLenth = 60;
            public const int EventDescriptionMinLength = 250;
            public const int EventDescriptionMaxLenth = 1500;
        }

        public static class ArtStore
        {
            public const int PaintingNameMinLenth = 10;
            public const int PaintingNameMaxLenth = 35;
            public const int AuthorNameMinLenth = 50;
            public const int AuthorNameMaxLenth = 100;
            public const int ArtsDescriptionMinLenth = 150;
            public const int ArtsDescriptionMaxLenth = 1000;
        }

        public static class BlogPost
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int ContentMinLength = 600;
            public const int ContentMaxLength = 3500;
            public const int AdminAuthorMinLength = 50;
            public const int AdminAuthorMaxLength = 100;
            public const int CommnetContentMinLength = 5;
            public const int CommentContentMaxLength = 150;
        }

        public static class ExhibitionHall
        {
            public const int CapacityMinLength = 5;
            public const int CapacityMaxLength = 100;
        }

        public static class Images
        {
            public const string Error404 = "https://res.cloudinary.com/art-gallery/image/upload/c_fit,h_325,w_1200/v1645821424/app_gallery/error404-jpg_xnvavw.jpg";

            // Art Store
            public const string MrPeacock = "https://res.cloudinary.com/art-gallery/image/upload/c_fit,h_300,w_300/v1645821443/app_gallery/peacock-jpeg_d9gei3.jpg";
            public const string TheStaryNight = "https://res.cloudinary.com/art-gallery/image/upload/c_fit,h_300,w_300/v1645821452/app_gallery/The_Starry_Night-jpeg_ph9mxf.jpg";
            public const string TerraceProspect = "https://res.cloudinary.com/art-gallery/image/upload/c_fit,h_300,w_300/v1645821445/app_gallery/Terrace_Prospect_Park_1887_-jpeg_uesqef.jpg";
            public const string GreeanWheatFields = "https://res.cloudinary.com/art-gallery/image/upload/c_fit,h_300,w_300/v1645821441/app_gallery/Green_Wheat_Fields-jpeg_dzmndr.jpg";
            public const string MonaLisa = "https://res.cloudinary.com/art-galleryl/image/upload/c_fit,h_300,w_300/v1645821444/app_gallery/Portrait_of_Mona_Lisa-jpeg_jhvgpi.jpg";
        }

        public static class Privacy
        {
            public const int PageContentMinLength = 1000;
            public const int PageContentMaxLength = 15000;
            public const string PageContentDisplayName = "Page Content";
        }

        public static class FaqEntity
        {
            public const int QuestionMinLength = 10;
            public const int QuestionMaxLength = 100;
            public const int AnswerMinLength = 20;
            public const int AnswerMaxLength = 1000;
        }

        public static class ErrorMessages
        {
            public const string UserFullname = "Fullname is invalid. It should be between 90 and 500 characters long.";

            // Events
            public const string EventName = "Event Name should be between 8 and 60 characters long.";
            public const string EventDescription = "Description should be between 250 and 1500 characters long.";
            public const string EventCapacity = "Event Capacity depends from the Exhibition Hall Type. It should be between 5 and 100 people.";

            // Blog
            public const string Title = "Title must be between 5 and 70 characters long.";
            public const string Content = "Content must be between 600 and 3500 characters long.";
            public const string Comment = "Comment should be between 5 and 150 characters long.";

            // Arts
            public const string PaintingName = "Painting Name should be between 10 and 35 characters long.";
            public const string ArtsDescription = "Description must be between 150 and 1000 chracters long.";

            // Arts and Blog
            public const string AuthorsName = "Author name must be between 50 and 100 characters long.";
        }

        public static class OperationalMessages
        {
            public const string SuccessfullyBookedEvent = "Your choosen event has been succefully booked!";
            public const string SuccessfullyCheckoutOrder = "Your order has been successfully checkout!";
        }
    }
}
