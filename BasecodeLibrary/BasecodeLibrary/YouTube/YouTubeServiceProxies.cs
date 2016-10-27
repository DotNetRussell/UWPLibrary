using BasecodeLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube
{
    internal static class YouTubeServiceProxies
    {
        private static HttpClient _httpClient = new HttpClient();

        private static readonly string _baseURL = @"https://www.googleapis.com/youtube/v3/";
        private static readonly string _channels = @"channels?part=contentDetails";
        private static readonly string _playlists = @"playlists?part=contentDetails";
        private static readonly string _playlistDetails = @"playlistItems?part=contentDetails";
        private static readonly string _videoDetails = @"videos?part=snippet";
        private static string _id = "&id=";
        private static string _playlistId = "&playlistId=";
        private static string _channelId = "&channelId=";
        private static string _maxResults = "&maxResults=";
        private static string _apiKey = "&key=";

        public static string API_KEY { get; set; }

        public static async Task<string> GetChannels(string channelId)
        {
            HttpResponseMessage response = await BasecodeRequestManager.BeginRequest(_baseURL + _channels + _id + channelId + _apiKey + API_KEY);
            response.EnsureSuccessStatusCode();
            HttpContent content = response.Content;
            return await content.ReadAsStringAsync();
        }

        public static async Task<string> GetPlaylists(string channelId, int maxResults)
        {
            HttpResponseMessage response = await BasecodeRequestManager.BeginRequest(_baseURL + _playlists + _channelId + channelId + _maxResults + maxResults + _apiKey + API_KEY);
            if (response == null)
            {
                return String.Empty;
            }

            response.EnsureSuccessStatusCode();
            HttpContent content = response.Content;
            return await content.ReadAsStringAsync();
        }

        public static async Task<string> GetPlaylistDetails(string playlistId, int maxResults)
        {
            HttpResponseMessage response = await BasecodeRequestManager.BeginRequest(_baseURL + _playlistDetails + _playlistId + playlistId + _maxResults + maxResults + _apiKey + API_KEY);
            if (response == null)
            {
                return String.Empty;
            }

            response.EnsureSuccessStatusCode();
            HttpContent content = response.Content;
            return await content.ReadAsStringAsync();
        }

        public static async Task<string> GetVideoDetails(string videoId)
        {
            HttpResponseMessage response = await BasecodeRequestManager.BeginRequest(_baseURL + _videoDetails + _id + videoId + _apiKey + API_KEY);
            if (response == null)
            {
                return String.Empty;
            }

            response.EnsureSuccessStatusCode();
            HttpContent content = response.Content;
            return await content.ReadAsStringAsync();
        }
    }
}
