#include "pch.h"
#include <ctype.h>
#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include "base64.h"

unsigned char* rfc822_binary(void* src, unsigned long srcl, unsigned long* len)
{
    unsigned char* ret, * d;
    unsigned char* s = (unsigned char*)src;
    const char* v = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789._";
    unsigned long i = ((srcl + 2) / 3) * 4;
    *len = i += 2 * ((i / 60) + 1);
    d = ret = (unsigned char*)malloc((size_t) ++i);
    for (i = 0; srcl; s += 3) {	/* process tuplets */
        *d++ = v[s[0] >> 2];	/* byte 1: high 6 bits (1) */
        /* byte 2: low 2 bits (1), high 4 bits (2) */
        *d++ = v[((s[0] << 4) + (--srcl ? (s[1] >> 4) : 0)) & 0x3f];
        /* byte 3: low 4 bits (2), high 2 bits (3) */
        *d++ = srcl ? v[((s[1] << 2) + (--srcl ? (s[2] >> 6) : 0)) & 0x3f] : '-';
        /* byte 4: low 6 bits (3) */
        *d++ = srcl ? v[s[2] & 0x3f] : '-';
        if (srcl) srcl--;		/* count third character if processed */
        if ((++i) == 15) 	/* output 60 characters? */
        {
            i = 0;			/* restart line break count, insert CRLF */
            *d++ = '\015'; *d++ = '\012';
        }
    }

    *d = '\0';			/* tie off string */
    return ret;			/* return the resulting string */
}

