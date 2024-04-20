using System;
using System.Collections.Generic;

namespace MyBiblioCDsAudio2
{
    public class Result2
    {
        public string country { get; set; }
        public int year { get; set; }
        public StringList format2 { get; set; }
        public StringList genre { get; set; }
        public StringList style { get; set; }
        public int id { get; set; }
        public StringList label { get; set; }
        public string type { get; set; }
        public StringList barcode { get; set; }
        public User_Data user_data { get; set; }
        public int master_id { get; set; }
        public string master_url { get; set; }
        public string uri { get; set; }
        public string catno { get; set; }
        public string title { get; set; }
        public string thumb { get; set; }
        public string cover_image { get; set; }
        public string resource_url { get; set; }
        public struct community
        {
            public int want { get; set; }
            public int have { get; set; }
        }
        public int format_quantity { get; set; }
        public struct formats2
        {
            public string name { get; set; }
            public string qty { get; set; }
            public string[] descriptions { get; set; }
        }

    }
    public class StringList
    {
        public List<string> stringlist { get; set; }
    }
    public class User_Data
    {
        public bool in_wantlist { get; set; }
        public bool in_collection { get; set; }
    }
}
