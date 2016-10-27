using BasecodeLibrary.Utilities;
using BaseCodeLibrary.YouTube.YouTubeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube
{
    public static class YouTubeServices
    {
        private enum RequestNames { GetChannels, GetPlaylists, GetPlaylistDetails, GetVideoDetails };
        private static List<RequestNames> _Requests = new List<RequestNames>();
        public static bool IsAwaitingResponse
        {
            get
            {
                return _Requests.Count != 0;
            }
        }

        public static string YouTubeAPIKey { get; set; }

        private static void RegisterRequest(RequestNames request)
        {
            _Requests.Add(request);
        }

        private static void RemoveRequest(RequestNames request)
        {
            _Requests.Remove(request);
        }

        public static async Task<YTChannelsRequestResults> GetChannels(string channelId)
        {
            if (YouTubeAPIKey != String.Empty)
            {
                CheckYouTubAPIKey();
                RegisterRequest(RequestNames.GetChannels);

                string response = await YouTubeServiceProxies.GetChannels(channelId);
                if (String.IsNullOrEmpty(response))
                {
                    return null;
                }

                YTChannelsRequestResults results = await YouTubeJsonParser.ParseChannels(response); 

                RemoveRequest(RequestNames.GetChannels);
                return results;
            }
            else
            {
                throw new YouTubeException() { Source = "YouTubeServices.GetChannels - API Key cannot be null" };
            }
        }

        public static async Task<YTPlaylistsRequestResults> GetPlaylists(string channelId)
        {
            if (YouTubeAPIKey != String.Empty)
            {
                CheckYouTubAPIKey();
                RegisterRequest(RequestNames.GetPlaylists);

                string response = await YouTubeServiceProxies.GetPlaylists(channelId, 50);
                if (String.IsNullOrEmpty(response))
                {
                    return null;
                }

                YTPlaylistsRequestResults results = await YouTubeJsonParser.ParsePlaylists(response);

                RemoveRequest(RequestNames.GetPlaylists);
                return results;
            }
            else
            {
                throw new YouTubeException() { Source = "YouTubeServices.GetPlaylists - API Key cannot be null" };
            }
        }

        public static async Task<YTPlaylistDetailsRequestResults> GetPlaylistDetails(string playlistId)
        {
            if (YouTubeAPIKey != String.Empty)
            {
                CheckYouTubAPIKey();
                RegisterRequest(RequestNames.GetPlaylistDetails);

                string response = await YouTubeServiceProxies.GetPlaylistDetails(playlistId, 50);
                if (String.IsNullOrEmpty(response))
                {
                    return null;
                }

                YTPlaylistDetailsRequestResults results = await YouTubeJsonParser.ParsePlaylistDetails(response);

                RemoveRequest(RequestNames.GetPlaylistDetails);
                return results;
            }
            else
            {
                throw new YouTubeException() { Source = "YouTubeServices.GetPlaylistDetails - API Key cannot be null" };
            }
        }

        public static async Task<YTVideoDetailsRequestResults> GetVideoDetails(string videoId)
        {
            if (YouTubeAPIKey != String.Empty)
            {
                CheckYouTubAPIKey();
                RegisterRequest(RequestNames.GetVideoDetails);

                string response = await YouTubeServiceProxies.GetVideoDetails(videoId);
                if (String.IsNullOrEmpty(response))
                {
                    return null;
                }

                YTVideoDetailsRequestResults results = await YouTubeJsonParser.ParseVideoDetails(response);

                RemoveRequest(RequestNames.GetVideoDetails);
                return results;
            }
            else
            {
                throw new YouTubeException() { Source = "YouTubeServices.GetPlaylistDetails - API Key cannot be null" };
            }
        }

        private static void CheckYouTubAPIKey()
        {
            if (YouTubeServiceProxies.API_KEY == String.Empty || YouTubeServiceProxies.API_KEY == null)
            {
                YouTubeServiceProxies.API_KEY = YouTubeAPIKey;
            }
        }
    }
}
