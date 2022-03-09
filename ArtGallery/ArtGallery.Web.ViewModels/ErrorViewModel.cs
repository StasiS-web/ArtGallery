namespace ArtGallery.Web.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

        public string ErrorMessage { get; set; }

        public int StatusCode { get; set; }

       /* public ErrorViewModel(string message)
        {
            this.ErrorMessage = message;
        } */
    }
}