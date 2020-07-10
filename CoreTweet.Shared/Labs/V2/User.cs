// The MIT License (MIT)
//
// CoreTweet - A .NET Twitter Library supporting Twitter API 1.1
// Copyright (c) 2013-2018 CoreTweet Development Team
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Linq;
using System.Text;
using CoreTweet.Core;
using Newtonsoft.Json;

namespace CoreTweet.Labs.V2
{
    public class User : CoreBase
    {
        /// <summary>
        /// Unique identifier of this user.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Creation time of this account.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.CreatedAt"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The friendly name of this user, as shown on their profile.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The Twitter handle (screen name) of this user.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Indicates if this user has chosen to protect their Tweets (in other words, if this user's Tweets are private).
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Protected"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("protected")]
        public bool? Protected { get; set; }

        /// <summary>
        /// Contains withholding details for withheld content.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Withheld"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("withheld")]
        public Withheld Withheld { get; set; }

        /// <summary>
        /// The location specified in the user's profile, if the user provided one. As this is a freeform value, it may not indicate a valid location, but it may be fuzzily evaluated when performing searches with location queries.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Location"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// The URL specified in the user's profile, if present.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Url"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The text of this user's profile description (also known as bio), if the user provided one.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Description"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicate if this user is a verified Twitter User.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Verified"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        /// <summary>
        /// This object and its children fields contain details about text that has a special meaning in the user's description.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.Entities"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("entities")]
        public UserEntities Entities { get; set; }

        /// <summary>
        /// The URL to the profile image for this user, as shown on the user's profile.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.ProfileImageUrl"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// Contains details about activity for this user.
        /// </summary>
        /// <remarks>
        /// To return this field, add <see cref="UserFields.PublicMetrics"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("public_metrics")]
        public UserPublicMetrics PublicMetrics { get; set; }

        /// <summary>
        /// Unique identifier of this user's pinned Tweet.
        /// </summary>
        /// <remarks>
        /// You can obtain the expanded object in <see cref="UserResponseIncludes.Tweets"/> by adding <see cref="UserExpansions.PinnedTweetId"/> in the request's query parameter.
        /// </remarks>
        [JsonProperty("pinned_tweet_id")]
        public long? PinnedTweetId { get; set; }

        public static explicit operator User(V1.User value)
        {
            return new User
            {
                Id = value.Id,
                CreatedAt = value.CreatedAt,
                Name = value.Name,
                Username = value.Username,
                Protected = value.Protected,
                Withheld = (Withheld)value.Withheld,
                Location = value.Location,
                Url = value.Url,
                Description = value.Description,
                Verified = value.Verified,
                Entities = (UserEntities)value.Entities,
                ProfileImageUrl = value.ProfileImageUrl,
                PublicMetrics = (UserPublicMetrics)value.PublicMetrics,
                PinnedTweetId = value.PinnedTweetId,
            };
        }

        public static explicit operator V1.User(User value)
        {
            return new V1.User
            {
                Id = value.Id,
                CreatedAt = value.CreatedAt,
                Name = value.Name,
                Username = value.Username,
                Protected = value.Protected,
                Withheld = (V1.Withheld)value.Withheld,
                Location = value.Location,
                Url = value.Url,
                Description = value.Description,
                Verified = value.Verified,
                Entities = (V1.UserEntities)value.Entities,
                ProfileImageUrl = value.ProfileImageUrl,
                PublicMetrics = (V1.UserPublicMetrics)value.PublicMetrics,
                PinnedTweetId = value.PinnedTweetId,
            };
        }
    }

    public class UserEntities : CoreBase
    {
        [JsonProperty("url")]
        public Entities Url { get; set; }

        [JsonProperty("description")]
        public Entities Description { get; set; }

        public static explicit operator UserEntities(V1.UserEntities value)
        {
            return new UserEntities
            {
                Url = (Entities)value.Url,
                Description = (Entities)value.Description,
            };
        }

        public static explicit operator V1.UserEntities(UserEntities value)
        {
            return new V1.UserEntities
            {
                Url = (V1.Entities)value.Url,
                Description = (V1.Entities)value.Description,
            };
        }
    }

    public class UserPublicMetrics : CoreBase
    {
        /// <summary>
        /// Number of users who follow this user.
        /// </summary>
        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        /// <summary>
        /// Number of users this user is following.
        /// </summary>
        [JsonProperty("following_count")]
        public long FollowingCount { get; set; }

        /// <summary>
        /// Number of Tweets (including Retweets) posted by this user.
        /// </summary>
        [JsonProperty("tweet_count")]
        public long TweetCount { get; set; }

        /// <summary>
        /// Number of lists that include this user.
        /// </summary>
        [JsonProperty("listed_count")]
        public long ListedCount { get; set; }

        public static explicit operator UserPublicMetrics(V1.UserPublicMetrics value)
        {
            return new UserPublicMetrics
            {
                FollowersCount = value.FollowersCount,
                FollowingCount = value.FollowingCount,
                TweetCount = value.TweetCount,
                ListedCount = value.ListedCount,
            };
        }

        public static explicit operator V1.UserPublicMetrics(UserPublicMetrics value)
        {
            return new V1.UserPublicMetrics
            {
                FollowersCount = value.FollowersCount,
                FollowingCount = value.FollowingCount,
                TweetCount = value.TweetCount,
                ListedCount = value.ListedCount,
            };
        }
    }

    public class UserResponseIncludes : CoreBase
    {
        /// <summary>
        /// For referenced Tweets, this is a list of objects with the same structure as the one described by <see cref="TweetsAndUsersApi.GetTweets(object)"/>.
        /// </summary>
        [JsonProperty("tweets")]
        public Tweet[] Tweets { get; set; }

        public static explicit operator UserResponseIncludes(V1.UserResponseIncludes value)
        {
            return new UserResponseIncludes
            {
                Tweets = value.Tweets?.Select(x => (Tweet)x).ToArray(),
            };
        }

        public static explicit operator V1.UserResponseIncludes(UserResponseIncludes value)
        {
            return new V1.UserResponseIncludes
            {
                Tweets = value.Tweets?.Select(x => (V1.Tweet)x).ToArray(),
            };
        }
    }

    public class UserResponse : ResponseBase
    {
        [JsonProperty("data")]
        public User Data { get; set; }

        /// <summary>
        /// Returns the requested <see cref="UserExpansions"/>, if available.
        /// </summary>
        [JsonProperty("includes")]
        public UserResponseIncludes Includes { get; set; }

        public static explicit operator UserResponse(V1.UserResponse value)
        {
            return new UserResponse
            {
                Errors = value.Errors?.Select(x => (Error)x).ToArray(),
                RateLimit = value.RateLimit,
                Json = value.Json,
                Data = (User)value.Data,
                Includes = (UserResponseIncludes)value.Includes,
            };
        }

        public static explicit operator V1.UserResponse(UserResponse value)
        {
            return new V1.UserResponse
            {
                Errors = value.Errors?.Select(x => (V1.Error)x).ToArray(),
                RateLimit = value.RateLimit,
                Json = value.Json,
                Data = (V1.User)value.Data,
                Includes = (V1.UserResponseIncludes)value.Includes,
            };
        }
    }

    public class UsersResponse : ResponseBase
    {
        [JsonProperty("data")]
        public User[] Data { get; set; }

        /// <summary>
        /// Returns the requested <see cref="UserExpansions"/>, if available.
        /// </summary>
        [JsonProperty("includes")]
        public UserResponseIncludes Includes { get; set; }

        public static explicit operator UsersResponse(V1.UsersResponse value)
        {
            return new UsersResponse
            {
                Errors = value.Errors?.Select(x => (Error)x).ToArray(),
                RateLimit = value.RateLimit,
                Json = value.Json,
                Data = value.Data?.Select(x => (User)x).ToArray(),
                Includes = (UserResponseIncludes)value.Includes,
            };
        }

        public static explicit operator V1.UsersResponse(UsersResponse value)
        {
            return new V1.UsersResponse
            {
                Errors = value.Errors?.Select(x => (V1.Error)x).ToArray(),
                RateLimit = value.RateLimit,
                Json = value.Json,
                Data = value.Data?.Select(x => (V1.User)x).ToArray(),
                Includes = (V1.UserResponseIncludes)value.Includes,
            };
        }
    }

    /// <summary>
    /// List of additional fields to return in the User object. By default, the endpoint does not return any user field.
    /// </summary>
    [Flags]
    public enum UserFields
    {
        None            = 0x00000000,
        CreatedAt       = 0x00000001,
        Description     = 0x00000002,
        Entities        = 0x00000004,
        Id              = 0x00000008,
        Location        = 0x00000010,
        Name            = 0x00000020,
        PinnedTweetId   = 0x00000040,
        ProfileImageUrl = 0x00000080,
        Protected       = 0x00000100,
        PublicMetrics   = 0x00000200,
        Url             = 0x00000400,
        Username        = 0x00000800,
        Verified        = 0x00001000,
        Withheld        = 0x00002000,
        All             = 0x00003fff,
        AllPublic       = All,
    }

    internal static class UserFieldsExtensions
    {
        internal static string ToQueryString(this UserFields value)
        {
            if (value == UserFields.None)
                return "";

            var builder = new StringBuilder();

            if ((value & UserFields.CreatedAt) != 0)
                builder.Append("created_at,");
            if ((value & UserFields.Description) != 0)
                builder.Append("description,");
            if ((value & UserFields.Entities) != 0)
                builder.Append("entities,");
            if ((value & UserFields.Id) != 0)
                builder.Append("id,");
            if ((value & UserFields.Location) != 0)
                builder.Append("location,");
            if ((value & UserFields.Name) != 0)
                builder.Append("name,");
            if ((value & UserFields.PinnedTweetId) != 0)
                builder.Append("pinned_tweet_id,");
            if ((value & UserFields.ProfileImageUrl) != 0)
                builder.Append("profile_image_url,");
            if ((value & UserFields.Protected) != 0)
                builder.Append("protected,");
            if ((value & UserFields.PublicMetrics) != 0)
                builder.Append("public_metrics,");
            if ((value & UserFields.Url) != 0)
                builder.Append("url,");
            if ((value & UserFields.Username) != 0)
                builder.Append("username,");
            if ((value & UserFields.Verified) != 0)
                builder.Append("verified,");
            if ((value & UserFields.Withheld) != 0)
                builder.Append("withheld,");

            return builder.ToString(0, builder.Length - 1);
        }
    }

    /// <summary>
    /// List of fields to return in the Tweet poll object. The response will contain the selected fields only if a Tweet contains a poll.
    /// </summary>
    [Flags]
    public enum UserExpansions
    {
        None          = 0x00000000,
        PinnedTweetId = 0x00000001,
        All           = 0x00000001,
        AllPublic     = All,
    }

    public static class UserExpansionsExtensions
    {
        public static string ToQueryString(this UserExpansions value)
        {
            if (value == UserExpansions.None)
                return "";

            var builder = new StringBuilder();

            if ((value & UserExpansions.PinnedTweetId) != 0)
                builder.Append("pinned_tweet_id,");

            return builder.ToString(0, builder.Length - 1);
        }
    }
}
