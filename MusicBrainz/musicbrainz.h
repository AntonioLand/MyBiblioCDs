#pragma once
#ifndef MUSICBRAINZ_H_INCLUDED
#define MUSICBRAINZ_H_INCLUDED

#include <windows.h>
#include <commctrl.h>
#include "discid_private.h"

/*  To use this exported function of dll, include this header
 *  in your project.
 */

#ifdef MUSICBRAINZ_H_EXPORTS
#define DLL_EXPORT __declspec(dllexport)
#else
#define DLL_EXPORT __declspec(dllimport)
#endif


#ifdef __cplusplus
extern "C"
{
#endif

	extern "C" DLL_EXPORT int MusicBrainzLibDisc(mb_disc_private * disc, char* device);

#ifdef __cplusplus
}
#endif

#endif // MUSICBRAINZ_H_INCLUDED