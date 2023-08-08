namespace MusicPlayer.Models.ResponseModels
{
    public class ReturnResponse<T> where T : class
    {
        public string message { get; set; }
        public bool error { get; set; }
        public T? data { get; set; }

        public ReturnResponse(T data, string messageSuccess = "Sucess", string messageFail = "Fail")
        {
            if (data == null)
            {
                message = messageFail;
                error = true;
            }
            else
            {
                message = messageSuccess;
                error = false;
                this.data = data;
            }
        }
    }
}
