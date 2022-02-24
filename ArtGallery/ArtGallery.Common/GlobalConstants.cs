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
