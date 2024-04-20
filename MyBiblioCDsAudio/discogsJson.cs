using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDsAudio
{
    public class discogsJson
    {
            public string @context { get; set; }
            public string @type { get; set; }
            public string @id { get; set; }
            public string name { get; set; }
            public string musicReleaseFormat { get; set; }
            public string catalogNumber { get; set; }
            public ReLeaseOf releaseOf { get; set; }
            public ReleasedEvent releasedEvent { get; set; }
            public RecordLabel[] recordLabel { get; set; }
            public Track_AU[] LTracks { get; set; }
            public string description { get; set; }
            public double numTracks { get; set; }
            public string image { get; set; }
            public string[] genre { get; set; }
            public OFFERS Offers { get; set; }
            public AggregateRating aggregateRating { get; set; }
            public string datePublished { get; set; }

            public class ReLeaseOf
            {
                public string @type { get; set; }
                public string name { get; set; }
                public double numTracks { get; set; }
                public string @id { get; set; }
                public ByArtist[] byArtist { get; set; }

                public class ByArtist
                {
                    public string @type { get; set; }
                    public string name { get; set; }
                    public string @id { get; set; }

                }
                public string datePublished { get; set; }
            }
            public class ReleasedEvent
            {
                public string @type { get; set; }
                public class location
                {
                    public string @type { get; set; }
                    public string name { get; set; }
                }
                public string startDate { get; set; }
            }
            public class RecordLabel
            {
                public string @type { get; set; }
                public string name { get; set; }
                public string @id { get; set; }
            }
            public class Track_AU
            {
                public string @type { get; set; }
                public string name { get; set; }
                public string duration { get; set; }
            }
            public class OFFERS
            {
                public string @type { get; set; }
                public string availability { get; set; }
                public string lowPrice { get; set; }
                public string offerCount { get; set; }
                public string priceCurrency { get; set; }
                public ItemOffered itemOffered { get; set; }
                public class ItemOffered
                {
                    public string @type { get; set; }
                    public string name { get; set; }
                }
            }

            public class AggregateRating
            {
                public string @type { get; set; }
                public string ratingValue { get; set; }
                public string ratingCount { get; set; }
            }
    }
    public class jsonCover
    {
        public imgcov[] dataimages { get; set; }
        public class imgcov
        {
            public string id { get; set; }
            public string thumb { get; set; }
            public string full { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }
    }
}
