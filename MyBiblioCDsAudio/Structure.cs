using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDsAudio
{
    public class Structure
    {
        public const int MB_DISC_ID_LENGTH = 32;
        public const int FREEDB_DISC_ID_LENGTH = 8;
        public const int MB_ERROR_MSG_LENGTH = 255;
        public const int MB_URL_PREFIX_LENGTH = 300;
        public const int MB_TOC_STRING_LENGTH = (3 + 3 + 100 * 7);
        public const int MB_MAX_URL_LENGTH = (MB_URL_PREFIX_LENGTH + MB_DISC_ID_LENGTH + MB_TOC_STRING_LENGTH);
        public const int ISRC_STR_LENGTH = 12;
        public const int MCN_STR_LENGTH = 13;
        public static StringBuilder device;

        public struct mb_disc_private
        {
            public int first_track_num;
            public int last_track_num;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I4)]
            public int[] track_offsets; // = new int[100];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MB_DISC_ID_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] id;                 // = new char[MB_DISC_ID_LENGTH + 1];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = FREEDB_DISC_ID_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] freedb_id;          //[FREEDB_DISC_ID_LENGTH + 1];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MB_MAX_URL_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] submission_url;     // [MB_MAX_URL_LENGTH + 1];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MB_MAX_URL_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] webservice_url;     //[MB_MAX_URL_LENGTH + 1];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MB_TOC_STRING_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] toc_string;         // [MB_TOC_STRING_LENGTH + 1];
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MB_ERROR_MSG_LENGTH + 1, ArraySubType = UnmanagedType.ByValTStr)]
            public char[] error_msg;          // [MB_ERROR_MSG_LENGTH + 1];
            public int success;
            public mb_disc_private(int first, int last)
            {
                first_track_num = first;
                last_track_num = last;
                track_offsets = new int[100]; //track_offsets[0] = '\0';
                id = new char[MB_DISC_ID_LENGTH + 1]; //id[0] = '\0';
                freedb_id = new char[FREEDB_DISC_ID_LENGTH + 1]; //freedb_id[0] = '\0';
                submission_url = new char[MB_MAX_URL_LENGTH + 1]; //submission_url[0] = '\0';
                webservice_url = new char[MB_MAX_URL_LENGTH + 1]; //webservice_url[0] = '\0';
                toc_string = new char[MB_TOC_STRING_LENGTH + 1]; //toc_string[0] = '\0';
                error_msg = new char[MB_ERROR_MSG_LENGTH + 1]; //error_msg[0] = '\0';
                success = 0;
            }
        }
    }

    static public class Device
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.AnsiBStr)]
        static public char[] device = new char[3];
    }
}