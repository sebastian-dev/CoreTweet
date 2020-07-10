using System.Linq;
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

using CoreTweet.Core;
using Newtonsoft.Json;

namespace CoreTweet.Labs.V2
{
    /// <summary>
    /// This object and its children fields contain details about text that has a special meaning in the parent model.
    /// </summary>
    public class Entities : CoreBase
    {
        /// <summary>
        /// Contains details about annotations relative to the text within a Tweet.
        /// </summary>
        [JsonProperty("annotations")]
        public AnnotationEntity[] Annotations { get; set; }

        /// <summary>
        /// Contains details about text recognized as a URL.
        /// </summary>
        [JsonProperty("urls")]
        public UrlEntity[] Urls { get; set; }

        /// <summary>
        /// Contains details about text recognized as a Hashtag.
        /// </summary>
        [JsonProperty("hashtags")]
        public HashtagEntity[] Hashtags { get; set; }

        /// <summary>
        /// Contains details about text recognized as a user mention.
        /// </summary>
        [JsonProperty("mentions")]
        public MentionEntity[] Mentions { get; set; }

        /// <summary>
        /// Contains details about text recognized as a Cashtag.
        /// </summary>
        [JsonProperty("cashtags")]
        public CashtagEntity[] Cashtags { get; set; }

        public static explicit operator Entities(V1.Entities value)
        {
            return new Entities
            {
                Annotations = value.Annotations?.Select(x => (AnnotationEntity)x).ToArray(),
                Urls = value.Urls?.Select(x => (UrlEntity)x).ToArray(),
                Hashtags = value.Hashtags?.Select(x => (HashtagEntity)x).ToArray(),
                Mentions = value.Mentions?.Select(x => (MentionEntity)x).ToArray(),
                Cashtags = value.Cashtags?.Select(x => (CashtagEntity)x).ToArray(),
            };
        }

        public static explicit operator V1.Entities(Entities value)
        {
            return new V1.Entities
            {
                Annotations = value.Annotations?.Select(x => (V1.AnnotationEntity)x).ToArray(),
                Urls = value.Urls?.Select(x => (V1.UrlEntity)x).ToArray(),
                Hashtags = value.Hashtags?.Select(x => (V1.HashtagEntity)x).ToArray(),
                Mentions = value.Mentions?.Select(x => (V1.MentionEntity)x).ToArray(),
                Cashtags = value.Cashtags?.Select(x => (V1.CashtagEntity)x).ToArray(),
            };
        }
    }

    /// <summary>
    /// Contains details about text recognized as an entity.
    /// </summary>
    public abstract class Entity : CoreBase
    {
        /// <summary>
        /// The start position (zero-based) of the recognized entity within the Tweet.
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }

        /// <summary>
        /// The end position (zero-based) of the recognized entity within the Tweet.
        /// </summary>
        [JsonProperty("end")]
        public int End { get; set; }
    }

    /// <summary>
    /// Contains details about annotations relative to the text within a Tweet.
    /// </summary>
    public class AnnotationEntity : Entity
    {
        /// <summary>
        /// The confidence score for the annotation as it correlates to the Tweet text.
        /// </summary>
        [JsonProperty("probability")]
        public double Probability { get; set; }

        /// <summary>
        /// The description of the type of entity identified when the Tweet text was interpreted.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The text used to determine the annotation type.
        /// </summary>
        [JsonProperty("normalized_text")]
        public string NormalizedText { get; set; }

        public static explicit operator AnnotationEntity(V1.AnnotationEntity value)
        {
            return new AnnotationEntity
            {
                Start = value.Start,
                End = value.End,
                Probability = value.Probability,
                Type = value.Type,
                NormalizedText = value.NormalizedText,
            };
        }

        public static explicit operator V1.AnnotationEntity(AnnotationEntity value)
        {
            return new V1.AnnotationEntity
            {
                Start = value.Start,
                End = value.End,
                Probability = value.Probability,
                Type = value.Type,
                NormalizedText = value.NormalizedText,
            };
        }
    }

    /// <summary>
    /// Contains details about text recognized as a URL.
    /// </summary>
    public class UrlEntity : Entity
    {
        /// <summary>
        /// The URL in the format tweeted by the user.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The fully resolved URL.
        /// </summary>
        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        /// <summary>
        /// The URL as displayed in the Twitter client.
        /// </summary>
        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("images")]
        public UrlEntityImage[] Images { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("status")]
        public int? Status { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The full destination URL.
        /// </summary>
        [JsonProperty("unwound_url")]
        public string UnwoundUrl { get; set; }

        public static explicit operator UrlEntity(V1.UrlEntity value)
        {
            return new UrlEntity
            {
                Start = value.Start,
                End = value.End,
                Url = value.Url,
                ExpandedUrl = value.ExpandedUrl,
                DisplayUrl = value.DisplayUrl,
                Images = value.Images?.Select(x => (UrlEntityImage)x).ToArray(),
                Status = value.Status,
                Title = value.Title,
                Description = value.Description,
                UnwoundUrl = value.UnwoundUrl,
            };
        }

        public static explicit operator V1.UrlEntity(UrlEntity value)
        {
            return new V1.UrlEntity
            {
                Start = value.Start,
                End = value.End,
                Url = value.Url,
                ExpandedUrl = value.ExpandedUrl,
                DisplayUrl = value.DisplayUrl,
                Images = value.Images?.Select(x => (V1.UrlEntityImage)x).ToArray(),
                Status = value.Status,
                Title = value.Title,
                Description = value.Description,
                UnwoundUrl = value.UnwoundUrl,
            };
        }
    }

    /// <remarks>
    /// Undocumented property. (availables on OGP only)
    /// </remarks>
    public class UrlEntityImage : CoreBase
    {
        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <remarks>
        /// Undocumented property. (availables on OGP only)
        /// </remarks>
        [JsonProperty("height")]
        public int Height { get; set; }

        public static explicit operator UrlEntityImage(V1.UrlEntityImage value)
        {
            return new UrlEntityImage
            {
                Url = value.Url,
                Width = value.Width,
                Height = value.Height,
            };
        }

        public static explicit operator V1.UrlEntityImage(UrlEntityImage value)
        {
            return new V1.UrlEntityImage
            {
                Url = value.Url,
                Width = value.Width,
                Height = value.Height,
            };
        }
    }

    /// <summary>
    /// Contains details about text recognized as a Hashtag.
    /// </summary>
    public class HashtagEntity : Entity
    {
        /// <summary>
        /// The text of the Hashtag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
        // MEMO: the document is wrong (actual property key is `tag`, not `hashtag`)

        public static explicit operator HashtagEntity(V1.HashtagEntity value)
        {
            return new HashtagEntity
            {
                Start = value.Start,
                End = value.End,
                Tag = value.Tag,
            };
        }

        public static explicit operator V1.HashtagEntity(HashtagEntity value)
        {
            return new V1.HashtagEntity
            {
                Start = value.Start,
                End = value.End,
                Tag = value.Tag,
            };
        }
    }

    /// <summary>
    /// Contains details about text recognized as a user mention.
    /// </summary>
    public class MentionEntity : Entity
    {
        /// <summary>
        /// The part of text recognized as a user mention.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        public static explicit operator MentionEntity(V1.MentionEntity value)
        {
            return new MentionEntity
            {
                Start = value.Start,
                End = value.End,
                Username = value.Username,
            };
        }

        public static explicit operator V1.MentionEntity(MentionEntity value)
        {
            return new V1.MentionEntity
            {
                Start = value.Start,
                End = value.End,
                Username = value.Username,
            };
        }
    }

    /// <summary>
    /// Contains details about text recognized as a Cashtag.
    /// </summary>
    public class CashtagEntity : Entity
    {
        /// <summary>
        /// The text of the Cashtag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
        // MEMO: the document is wrong (actual property key is `tag`, not `cashtag`)

        public static explicit operator CashtagEntity(V1.CashtagEntity value)
        {
            return new CashtagEntity
            {
                Start = value.Start,
                End = value.End,
                Tag = value.Tag,
            };
        }

        public static explicit operator V1.CashtagEntity(CashtagEntity value)
        {
            return new V1.CashtagEntity
            {
                Start = value.Start,
                End = value.End,
                Tag = value.Tag,
            };
        }
    }
}
