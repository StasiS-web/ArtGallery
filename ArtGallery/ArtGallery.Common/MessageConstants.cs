namespace ArtGallery.Common
{
    public static class MessageConstants
    {
        public const string WarningMessage = "WarningMessage";
        public const string ErrorMessage = "ErrorMessage";
        public const string OperationalMessage = "OperationalMessage";

        // All Error Messages
        public const string InvalidUserId = "User with ID: {0} does not exist.";
        public const string PasswordValidation = "The Password and Confirmation Password do not match.";
        public const string PasswordLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string EmptyField = "The field should not be empthy. It is required to have a content.";
        public const string PageContentLength = "Page content should be between 1000 and 15000 characters long.";
        public const string UnknowUser = "Unknown user.";
        public const string UnableToDelete = "Unable to Delete the item.";
        public const string NonExistsArt = "Art does not exist.";

        // Events
        public const string EventName = "Event Name should be between 8 and 30 characters long.";
        public const string EventDescription = "Description should be between 250 and 1500 characters long.";
        public const string EventCapacity = "Event Capacity depends from the Exhibition Hall Type. It should be between 5 and 100 people.";

        // Blog
        public const string Title = "Title must be between 5 and 70 characters long.";
        public const string Content = "Content must be between 600 and 3500 characters long.";
        public const string Comment = "Comment should be between 15 and 150 characters long.";
        public const string LatestPost = "Your Blog Post should be the latest date published.";
        public const string NonExistingPost = "A Blog Post does not exists with id: {0} !";
        public const string BlogPostCreate = "Blog Post was created successfully!";
        public const string BlogPostAlredyExists = "A Blog Post already exist with Title: {O}.";

        // Arts
        public const string PaintingName = "Painting Name should be between 10 and 35 characters long.";
        public const string ArtsDescription = "Description must be between 150 and 1000 chracters long.";
        public const string InvalidArt = "This art does not exist";

        // Names 
        public const string AuthorsName = "Author name must be between 50 and 100 characters long.";
        public const string InvalidUsername = "User with Username: {0} does not exist.";
        public const string UserFullname = "Fullname is invalid. It should be between 90 and 500 characters long.";
        public const string UsernameLength = "Username should not be null. It should be between 5 and 20 characters long.";

        // OperationalMessages
        public const string SuccessfullyBookedEvent = "Your choosen event has been succefully booked!";
        public const string SuccessfullyCheckoutOrder = "Your order has been successfully checkout!";
        public const string SuccessfullyRunningToaster = "Well done, you manage to drive the tostr!";
        public const string UpdateSuccessMessage = "Profile was updated succefully!";

        // ErrorMessage 
        public const string UpdateError = "You will need to fill the required input fields!";
    }
}
