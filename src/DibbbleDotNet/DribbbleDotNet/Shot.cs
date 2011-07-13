namespace DribbbleDotNet
{
    using System;
    using Hammock;
    using Hammock.Web;
    using Newtonsoft.Json;

    public class Shot : Base
    {
        public static Shot Find(int id)
        {
            var request = new RestRequest
            {
                Path = string.Format("shots/{0}", id),
                Method = WebMethod.Get
            };

            var response = client.Request(request);
            return Deserialize<Shot>(response.Content);
        }

        public static PaginatedList<Shot> Debuts(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("/shots/debuts"),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public static PaginatedList<Shot> Everyone(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("/shots/everyone"),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public static PaginatedList<Shot> Popular(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("/shots/popular"),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public string Title { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "short_url")]
        public string ShortUrl { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "image_teaser_url")]
        public string ImageTeaserUrl { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        [JsonProperty(PropertyName = "views_count")]
        public long ViewsCount { get; set; }

        [JsonProperty(PropertyName = "likes_count")]
        public long LikesCount { get; set; }

        [JsonProperty(PropertyName = "comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_count")]
        public long ReboundsCount { get; set; }

        public Player Player { get; set; }

        public PaginatedList<Shot> Rebounds(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("/shots/{0}/rebounds", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public PaginatedList<Comment> Comments(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("/shots/{0}/comments", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Comment>>(response.Content);
        }
    }
}