/*
 * copyright (c) 20012 Crazyender
 *
 * This file is part of FFmpeg.mono
 *
 * FFmpeg.mono is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * FFmpeg.mono is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with FFmpeg; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using SharpFFmpeg;


namespace Multimedia
{
    public class AvCodec : NativeWrapper<FFmpeg.AVCodec>
    {
        internal AvCodec (IntPtr codec ) : base(codec)
        {
        }
        internal AvCodec (IntPtr codec, IntPtr context) : base(codec)
        {
            this.context = new NativeWrapper<FFmpeg.AVCodecContext>(context);
        }
        public string Name
        {
            get{return Handle.name;}
        }
        public NativeWrapper<FFmpeg.AVCodecContext> Context
        {
            get{return this.context;}
        }
        
        public void Open()
        {
            if( this.context == null )
                throw new InvalidOperationException("Invalid context.");
            if( FFmpeg.avcodec_open(context.Ptr, this.Ptr ) < 0 )
                throw new Exception("Could not open codec.");
            opened = true;
        }
        
        private bool freeNeeded;
        private bool opened;
        private NativeWrapper<FFmpeg.AVCodecContext> context;
    }
    
}

