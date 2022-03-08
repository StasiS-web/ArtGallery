namespace ArtGallery.Web.ViewModels
{
    public class ErrorViewModel
    {
        // public string RequestId { get; set; }

        // public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
        public string ErrorMessage { get; init; }

        public ErrorViewModel(string message)
        {
            this.ErrorMessage = message;
        }
    }
}