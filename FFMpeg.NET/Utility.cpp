#include "StdAfx.h"

#define __STDC_CONSTANT_MACROS

#include <avcodec.h>
#include <avformat.h>

#include "Utility.h"

void Utility::Initialize(void)
{
	if(Initialized) return;
	av_register_all();
	Initialized = true;
}

void main()
{
}