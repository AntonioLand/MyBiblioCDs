using System;

namespace MyBiblioCDsDiscogs
{
    public class Rootobject
    {
        public int id { get; set; }
        public string status { get; set; }
        public int year { get; set; }
        public string resource_url { get; set; }
        public string uri { get; set; }
        public Artist[] artists { get; set; }
        public string artists_sort { get; set; }
        public Label[] labels { get; set; }
        public object[] series { get; set; }
        public Company[] companies { get; set; }
        public Format[] formats { get; set; }
        public string data_quality { get; set; }
        public Community community { get; set; }
        public int format_quantity { get; set; }
        public DateTime date_added { get; set; }
        public DateTime date_changed { get; set; }
        public int num_for_sale { get; set; }
        public float lowest_price { get; set; }
        public int master_id { get; set; }
        public string master_url { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string released { get; set; }
        public string notes { get; set; }
        public string released_formatted { get; set; }
        public Identifier[] identifiers { get; set; }
        public Video[] videos { get; set; }
        public string[] genres { get; set; }
        public string[] styles { get; set; }
        public Tracklist[] tracklist { get; set; }
        public Extraartist1[] extraartists { get; set; }
        public Image[] images { get; set; }
        public string thumb { get; set; }
        public int estimated_weight { get; set; }
        public bool blocked_from_sale { get; set; }
    }

    public class Community
    {
        public int have { get; set; }
        public int want { get; set; }
        public Rating rating { get; set; }
        public Submitter submitter { get; set; }
        public Contributor[] contributors { get; set; }
        public string data_quality { get; set; }
        public string status { get; set; }
    }

    public class Rating
    {
        public int count { get; set; }
        public float average { get; set; }
    }

    public class Submitter
    {
        public string username { get; set; }
        public string resource_url { get; set; }
    }

    public class Contributor
    {
        public string username { get; set; }
        public string resource_url { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string anv { get; set; }
        public string join { get; set; }
        public string role { get; set; }
        public string tracks { get; set; }
        public int id { get; set; }
        public string resource_url { get; set; }
    }

    public class Label
    {
        public string name { get; set; }
        public string catno { get; set; }
        public string entity_type { get; set; }
        public string entity_type_name { get; set; }
        public int id { get; set; }
        public string resource_url { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catno { get; set; }
        public string entity_type { get; set; }
        public string entity_type_name { get; set; }
        public int id { get; set; }
        public string resource_url { get; set; }
    }

    public class Format
    {
        public string name { get; set; }
        public string qty { get; set; }
        public string[] descriptions { get; set; }
    }

    public class Identifier
    {
        public string type { get; set; }
        public string value { get; set; }
        public string description { get; set; }
    }

    public class Video
    {
        public string uri { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public bool embed { get; set; }
    }

    public class Tracklist
    {
        public string position { get; set; }
        public string type_ { get; set; }
        public string title { get; set; }
        public Extraartist[] extraartists { get; set; }
        public string duration { get; set; }
    }

    public class Extraartist
    {
        public string name { get; set; }
        public string anv { get; set; }
        public string join { get; set; }
        public string role { get; set; }
        public string tracks { get; set; }
        public int id { get; set; }
        public string resource_url { get; set; }
    }

    public class Extraartist1
    {
        public string name { get; set; }
        public string anv { get; set; }
        public string join { get; set; }
        public string role { get; set; }
        public string tracks { get; set; }
        public int id { get; set; }
        public string resource_url { get; set; }
    }

    public class Image
    {
        public string type { get; set; }
        public string uri { get; set; }
        public string resource_url { get; set; }
        public string uri150 { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}