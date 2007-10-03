// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently,
// but are changed infrequently

#pragma once

extern "C" {
	#define __STDC_CONSTANT_MACROS
	#define __STDC_LIMIT_MACROS
	#include <avformat.h>
	#include <avcodec.h>
	#include <avutil.h>
	#include <swscale.h>
}
