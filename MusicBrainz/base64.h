#pragma once
#ifndef BASE64_H_INCLUDED
#define BASE64_H_INCLUDED

#include "discid.h" /* for LIBDISCID_INTERNAL */

//LIBDISCID_INTERNAL unsigned char* rfc822_binary(void* src, unsigned long srcl, unsigned long* len);
unsigned char* rfc822_binary(void* src, unsigned long srcl, unsigned long* len);


#endif // BASE64_H_INCLUDED