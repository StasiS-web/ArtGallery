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
            public const int UserFullNaneMinLenth = 90;
            public const int UserFullNameMaxLenth = 500;
        }

        public static class Event
        {
            public const int EventNameMinLenth = 8;
            public const int EventNameMaxLenth = 60;
            public const int PriceMinLenth = 15;
            public const int PriceMaxLenth = 60;
            public const int DescriptionMaxLenth = 1500;
        }

        public static class ArtStore
        {
            public const int PaintingNameMinLenth = 10;
            public const int PaintingNameMaxLenth = 35;
            public const int AuthorNameMinLenth = 50;
            public const int AuthorNameMaxLenth = 100;
            public const int DimentionsMinLenght = 5;
            public const int DimentionsMaxLenght = 7;
            public const int PriceMinLength = 150;
            public const int PriceMaxLength = 8000;
            public const int DescriptionMinLenth = 200;
            public const int DescriptionMaxLenth = 1000;
        }

        public static class BlogPost
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int ContentMinLength = 600;
            public const int ContentMaxLength = 4500;
            public const int AdminAuthorMinLength = 50;
            public const int AdminAuthorMaxLength = 100;
            public const int CommnetContentMinLength = 5;
            public const int CommentContentMaxLength = 250;
        }

        public static class ExhibitionHall
        {
            public const int CapacityMinLength = 5;
            public const int CapacityMaxLength = 100;
        }

        public static class Images
        {
            // public const string Index = " ";
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
            public const int PageContentMaxLength = 15000;
        }

        public static class ErrorMessages
        {
            public const string Title = "Tiitle must be between 5 and 70 characters";
            public const string Content = "Content must be between 600 and 4500 characters";
            public const string Author = "Author name must be between 50 and 100 characters";
            public const string Description = "Description must be between 200 and 1000 chracters";
        }

        public static class FaqEntity
        {
            public const int QuestionMaxLength = 100;
            public const int AnswerMaxLength = 1000;
        }
    }
}
