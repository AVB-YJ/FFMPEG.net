# FFMPEG.net


A simple .net wrapper of ffmpeg (http://ffmpeg.org)

Unlike other wrapper, this library do not use c++/cli or unsafe code.

Currently it support windows and linux, mac support will not available until mono64 launched

It is licensed under the GPLv2.


## Translator

This is a sub-project for ffmpeg, but it can be used in any other project that needs P/Invoke

It read .h files with c/c++ grammer, and output c# file with P/Invoke insturction included.

This tool is based on CppSharp project which itself is based on llvm/clang.

## Status

Both FFMPEG.net and Translator are under develop, they may change a lot in the futhure
