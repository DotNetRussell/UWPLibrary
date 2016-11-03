using Newtonsoft.Json;
using BaseCodeLibrary.YouTube.YouTubeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube
{
    internal static class YouTubeJsonParser
    {
        public static async Task<YTChannelsRequestResults> ParseChannels(string jsonData)
        {
            return await Task.Factory.StartNew(() =>
            {
                YTChannelsRequestResults channelResults;
                dynamic dynamicData = JsonConvert.DeserializeObject(jsonData);

                channelResults = new YTChannelsRequestResults()
                {
                    Kind = dynamicData.kind,
                    Etag = dynamicData.etag,
                    PageInfo = new YTPageInfoModel()
                    {
                        TotalResults = dynamicData.pageInfo.totalResults,
                        ResultsPerPage = dynamicData.pageInfo.resultsPerPage
                    },
                    Items = new List<YTChannelModel>()
                };

                foreach (var item in dynamicData.items)
                {
                    YTChannelModel channel = new YTChannelModel()
                    {
                        Kind = item.kind,
                        Etag = item.etag,
                        Id = item.id,
                        ChannelDetails = new YTChannelContentDetails()
                        {
                            RelatedPlaylists = new YTRelatedPlaylistsModel()
                            {
                                Uploads = item.contentDetails.relatedPlaylists.uploads
                            },
                            GooglePlusUserId = item.contentDetails.googlePlusUserId
                        }
                    };
                    (channelResults.Items as List<YTChannelModel>).Add(channel);
                }

                return channelResults;
            });
        }

        public static async Task<YTPlaylistsRequestResults> ParsePlaylists(string jsonData)
        {
            return await Task.Factory.StartNew(() =>
            {
                YTPlaylistsRequestResults results;
                dynamic dynamicData = JsonConvert.DeserializeObject(jsonData);

                results = new YTPlaylistsRequestResults()
                {
                    Kind = dynamicData.kind,
                    Etag = dynamicData.etag,
                    PageInfo = new YTPageInfoModel()
                    {
                        TotalResults = dynamicData.pageInfo.totalResults,
                        ResultsPerPage = dynamicData.pageInfo.resultsPerPage
                    },
                    Items = new List<YTItemModel>()
                };

                foreach (var item in dynamicData.items)
                {
                    YTItemModel itemModel = new YTItemModel()
                    {
                        Kind = item.kind,
                        ETag = item.etag,
                        Id = item.id,
                        ContentDetails = new YTPlaylistsContentDetails() { ItemCount = item.contentDetails.itemCount }
                    };
                    results.Items.Add(itemModel);
                }
                return results;
            });
        }

        public static async Task<YTPlaylistDetailsRequestResults> ParsePlaylistDetails(string jsonData)
        {
            return await Task.Factory.StartNew(() =>
            {
                YTPlaylistDetailsRequestResults playlistDetails;

                dynamic dynamicData = JsonConvert.DeserializeObject(jsonData);

                playlistDetails = new YTPlaylistDetailsRequestResults()
                {
                    Kind = dynamicData.kind,
                    Etag = dynamicData.etag,
                    PageInfo = new YTPageInfoModel()
                    {
                        TotalResults = dynamicData.pageInfo.totalResults,
                        ResultsPerPage = dynamicData.pageInfo.resultsPerPage
                    },
                    Videos = new List<YTVideoModel>()
                };

                foreach (var item in dynamicData.items)
                {
                    YTVideoModel video = new YTVideoModel()
                    {
                        Kind = item.kind,
                        ETag = item.etag,
                        VideoId = item.id,
                        ContentDetails = new YTVideoContentDetails() { VideoId = item.contentDetails.videoId }
                    };
                    (playlistDetails.Videos as List<YTVideoModel>).Add(video);
                }
                return playlistDetails;
            });
        }

        public static async Task<YTVideoDetailsRequestResults> ParseVideoDetails(string jsonData)
        {
            return await Task.Factory.StartNew(() =>
            {
                YTVideoDetailsRequestResults videoDetails;

                dynamic dynamicData = JsonConvert.DeserializeObject(jsonData);

                videoDetails = new YTVideoDetailsRequestResults()
                {
                    Kind = dynamicData.kind,
                    Etag = dynamicData.etag,
                    PageInfo = new YTPageInfoModel()
                    {
                        TotalResults = dynamicData.totalResults,
                        ResultsPerPage = dynamicData.resultsPerPage
                    },
                    Items = new List<YTVideoDetailsContentDetails>()
                };

                foreach (var item in dynamicData.items)
                {
                    YTVideoDetailsContentDetails details = new YTVideoDetailsContentDetails()
                    {
                        Kind = item.kind,
                        Etag = item.etag,
                        Id = item.id,
                        Snippet = new YTSnipperModel()
                        {
                            PublishedAt = item.snippet.publishedAt,
                            ChannelId = item.snippet.channelId,
                            Title = item.snippet.title,
                            Description = item.snippet.description,
                            Thumbnails = new List<YTThumbnailModel>(),
                            ChannelTitle = item.snippet.channelTitle,
                            CategoryId = item.snippet.categoryId,
                            LiveBroadcastContent = item.snippet.liveBroadcastContent
                        }
                    };


                    YTThumbnailModel mediumThumbnail = new YTThumbnailModel()
                    {
                        ThumbnailSize = YTEnums.ThumbnailSizes.medium,
                        Url = item.snippet.thumbnails.medium.url,
                        Width = item.snippet.thumbnails.medium.width,
                        Height = item.snippet.thumbnails.medium.height
                    };
                    YTThumbnailModel highThumbnail = new YTThumbnailModel()
                    {
                        ThumbnailSize = YTEnums.ThumbnailSizes.high,
                        Url = item.snippet.thumbnails.medium.url,
                        Width = item.snippet.thumbnails.medium.width,
                        Height = item.snippet.thumbnails.medium.height
                    };
                    YTThumbnailModel standardThumbnail = new YTThumbnailModel()
                    {
                        ThumbnailSize = YTEnums.ThumbnailSizes.standard,
                        Url = item.snippet.thumbnails.medium.url,
                        Width = item.snippet.thumbnails.medium.width,
                        Height = item.snippet.thumbnails.medium.height
                    };
                    YTThumbnailModel maxresThumbnail = new YTThumbnailModel()
                    {
                        ThumbnailSize = YTEnums.ThumbnailSizes.maxres,
                        Url = item.snippet.thumbnails.medium.url,
                        Width = item.snippet.thumbnails.medium.width,
                        Height = item.snippet.thumbnails.medium.height
                    };

                    details.Snippet.Thumbnails.Add(mediumThumbnail);
                    details.Snippet.Thumbnails.Add(highThumbnail);
                    details.Snippet.Thumbnails.Add(standardThumbnail);
                    details.Snippet.Thumbnails.Add(maxresThumbnail);

                    videoDetails.Items.Add(details);
                }

                return videoDetails;
            });
        }
    }
}
