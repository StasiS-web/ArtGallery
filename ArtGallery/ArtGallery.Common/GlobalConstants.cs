namespace ArtGallery.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "ArtGallery";
        public const string CloudName = "dnvg6uuxl";
        public const string CloudMainFolderForImage = "app_gallery";
        public const string CloudSubFolderForErrorImages = "errors";

        public const string AdministratorRoleName = "Administrator";
        public const string GalleryManagerRoleName = "Manager";
        public const string UserRoleName = "Identity User";

        public static class AccountSeeding
        {
            public const string Password = "123455";
            public const string AdminEmail = "admin@admin.com";
            public const string GalleryManagerEmail = "manager@manager.com";
            public const string UserEmail = "user@user.com";
        }

        public static class ArtGalleryUser
        {
            public const int FullNaneMinLenth = 50;
            public const int FullNameMaxLenth = 100;
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

        public static class Event
        {
            public const int EventNameMinLenth = 8;
            public const int EventNameMaxLenth = 30;
            public const int EventDescriptionMinLength = 250;
            public const int EventDescriptionMaxLenth = 1500;
            public const double PriceMin = 0.0;
            public const double PriceMax = 80;
        }

        public static class ArtStore
        {
            public const int PaintingNameMinLenth = 10;
            public const int PaintingNameMaxLenth = 35;
            public const int AuthorNameMinLenth = 50;
            public const int AuthorNameMaxLenth = 100;
            public const int ArtsDescriptionMinLenth = 150;
            public const int ArtsDescriptionMaxLenth = 1000;
            public const double PriceMin = 0.0;
            public const double PriceMax = 10000;
        }

        public static class BlogPost
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int ContentMinLength = 600;
            public const int ContentMaxLength = 3500;
            public const int AdminAuthorMinLength = 50;
            public const int AdminAuthorMaxLength = 100;
            public const int CommnetContentMinLength = 15;
            public const int CommentContentMaxLength = 150;
        }

        public static class ExhibitionHall
        {
            public const int CapacityMinLength = 5;
            public const int CapacityMaxLength = 100;
        }

        public static class Images
        {
            // (Images is for Personal and non-Commercial. Use only for this project. Need repalcement for real app.)
            public const string Error404 = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--yJ6E6V_n--/c_fit,h_600,w_750/v1646650092/app_gallery/errors/error_404_wnxcl7.jpg";
            public const string Error500 = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--jesAiZsZ--/c_fit,h_600,w_750/v1646871576/app_gallery/errors/500_g4gern.jpg";

            // Art Store (Images Resourse from rawpixel)
            public const string MrPeacock = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821443/app_gallery/peacock-jpeg_d9gei3.jpg";
            public const string TheStaryNight = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821452/app_gallery/The_Starry_Night-jpeg_ph9mxf.jpg";
            public const string TerraceProspect = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821445/app_gallery/Terrace_Prospect_Park_1887_-jpeg_uesqef.jpg";
            public const string GreeanWheatFields = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821441/app_gallery/Green_Wheat_Fields-jpeg_dzmndr.jpg";
            public const string MonaLisa = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821444/app_gallery/Portrait_of_Mona_Lisa-jpeg_jhvgpi.jpg";
            public const string Landscape = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1646154562/app_gallery/landscape-jpeg_odeze0.jpg";
            public const string SingingBirds = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--18fSIQ9v--/c_fit,h_400,w_400/v1648592592/app_gallery/y4PqRPqSako-unsplash_gzmv2d.jpg"
                ;
            // Blog (Images Resourse from rawpixel)
            public const string ArtisticPainter = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646156702/app_gallery/Artist_painting-jpeg_nn02fh.jpg";
            public const string Art = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--eMTBpUc4--/c_fit,h_400,w_400/v1646156777/app_gallery/image-from-id-405327-jpeg_njsywp.jpg";
            public const string AnimalSpirits = "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646157537/app_gallery/image-from-id-556828-jpeg_pvzrkd.jpg";
            public const string Buttons = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--GIhqN_we--/c_fit,h_400,w_400/v1648590618/app_gallery/arun-prakash-unsplash_tuluof.jpg";
            public const string BestArt = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--7d9hBVji--/c_fit,h_400,w_400/v1648591070/app_gallery/annie-spratt-unsplash_e2hv3u.jpg";
            public const string AcrylicPainting = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--43NHpf2_--/c_fit,h_400,w_400/v1648592182/app_gallery/russn_fckr-unsplash_alixhl.jpg";

            // User Reactiosn (Image Resourse from flaticon)
            public const string Like = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--yUbJIoLH--/c_fit,h_300,w_300/v1646622718/app_gallery/userReaction/like_n9eqy5.png";
            public const string Love = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--xljmDf6J--/c_fit,h_300,w_300/v1646622804/app_gallery/userReaction/love_vph4np.png";
            public const string Care = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--XtBUfpfO--/c_fill,h_300,w_300/v1646623102/app_gallery/userReaction/care_ahys3v.png";
            public const string Haha = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--wlIa_i1J--/c_fit,h_300,w_300/v1646623121/app_gallery/userReaction/laughing_gvhjav.png";
            public const string Sad = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--Tg_IWpwl--/c_fit,h_300,w_300/v1646623104/app_gallery/userReaction/sad_qmoef2.png";
            public const string Wow = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--nnKxfZg5--/c_fit,h_300,w_300/v1646623111/app_gallery/userReaction/wow_yzaigj.png";
            public const string Angry = "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--hSTvysVb--/c_fit,h_300,w_300/v1646623146/app_gallery/userReaction/angry_lj6awp.png";
        }

        public static class Privacy
        {
            public const int PageContentMinLength = 1000;
            public const int PageContentMaxLength = 15000;
        }

        public static class FaqEntity
        {
            public const int QuestionMinLength = 20;
            public const int QuestionMaxLength = 100;
            public const int AnswerMinLength = 20;
            public const int AnswerMaxLength = 500;
        }

        public static class Formating
        {
            public const string NormalDateFormat = "dd-mm-yyyy";
            public const string DateTimeFormat = "dd-mm-yyyy hh:mm";
        }

        public static class DisplayNames
        {

            public const string FirstNameDisplayName = "First Name";
            public const string LastNameDisplayName = "Last Name";
            public const string EmailDisplay = "Email";
            public const string UsernameDisplay = "Username";
            public const string PasswordDisplay = "Password";
            public const string ConfirmPasswordDisplay = "Confirm Password";
            public const string PageContentDisplayName = "Page Content";
            public const string EventNameDisplay = "Event Name";
            public const string CoverImageDisplayName = "Cover Image";
            public const string ProductImageDisplayName = "Art's Image";
            public const string ImageDisplayName = "Photo";
        }

        public static class SeededDataCounts
        {
            public const int Events = 9;
            public const int BlogPost = 6;
            public const int ArtStore = 7;

            public const int UpcomingEventCount = 3;
            public const int LatestBlogCount = 2;
        }
    }
}
