namespace DribbbleDotNet
{
    using Hammock;
    using Hammock.Web;
    using Newtonsoft.Json;

    public class Player : Base
    {
        public static Player Find(int id)
        {
            return Find(id.ToString());
        }

        public static Player Find(string username)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}", username),
                Method = WebMethod.Get
            };

            var response = client.Request(request);
            return Deserialize<Player>(response.Content);
        }

        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string Location { get; set; }
        
        [JsonProperty(PropertyName = "twitter_screen_name")]
        public string TwitterScreenName { get; set; }

        [JsonProperty(PropertyName = "drafted_by_player_id")]
        public long? DraftedByPlayerId { get; set; }

        public string Url { get; set; }
        
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "website_url")] 
        public string WebSiteUrl { get; set; }

        [JsonProperty(PropertyName = "shots_count")]
        public long ShotsCount { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty(PropertyName = "following_count")]
        public long FollowingCount { get; set; }

        [JsonProperty(PropertyName = "likes_count")]
        public long LikesCount { get; set; }

        [JsonProperty(PropertyName = "likes_received_count")]
        public long LikesReceivedCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_count")]
        public long ReboundsCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_received_count")]
        public long ReboundsReceivedCount { get; set; }

        [JsonProperty(PropertyName = "draftees_count")]
        public long DrafteesCount { get; set; }

        [JsonProperty(PropertyName = "comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty(PropertyName = "comments_received_count")]
        public long CommentsReceivedCount { get; set; }

        public PaginatedList<Shot> Shots(int page = 1, int perPage = 15)
        {
            var request = new RestRequest 
            {
                Path = string.Format("players/{0}/shots", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public PaginatedList<Shot> ShotsFollowing(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}/shots/following", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public PaginatedList<Shot> ShotsLikes(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}/shots/likes", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Shot>>(response.Content);
        }

        public PaginatedList<Player> Followers(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}/followers", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Player>>(response.Content);
        }

        public PaginatedList<Player> Following(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}/following", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Player>>(response.Content);
        }

        public PaginatedList<Player> Draftees(int page = 1, int perPage = 15)
        {
            var request = new RestRequest
            {
                Path = string.Format("players/{0}/draftees", Id),
                Method = WebMethod.Get
            };
            SetPaginationParameters(request, page, perPage);
            var response = client.Request(request);
            return Deserialize<PaginatedList<Player>>(response.Content);
        }
    }
}
