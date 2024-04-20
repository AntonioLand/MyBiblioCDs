// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "discid.h"
#include "windef.h"
#include "test.h"
#include "musicbrainz.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

#include "pch.h"

/*
BOOL APIENTRY DllMain( HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
*/

int MusicBrainzLibDisc(mb_disc_private* disc, char* device)
{
    DiscId* d;
    char* error_msg;
    int feature_read;

    if (device == 0) {
        return 0;
    }
    d = discid_new();
    feature_read = discid_has_feature(DISCID_FEATURE_READ);
    evaluate(feature_read == 0 || feature_read == 1);
    if (!discid_read_sparse1(d, device, 0, disc))
    {
        error_msg = discid_get_error_msg(d);
        evaluate(strlen(error_msg) > 0);
        discid_free(d);
        return 77;
    }
    evaluate(discid_has_feature(DISCID_FEATURE_READ));
    /* In contrast to test_core, there should be a device now.  */
    evaluate(strlen(discid_get_default_device()) > 0);
    {
        char* x;
        evaluate(equal_int((int)strlen(x = discid_get_id1(d, disc)), 28));
        strncpy_s(disc->id, 29, x, 32);
    }
    create_toc_string1(disc, (char*)"+");
    discid_get_webservice_url1(d, disc);
    discid_free(d);
    return 1;
}
