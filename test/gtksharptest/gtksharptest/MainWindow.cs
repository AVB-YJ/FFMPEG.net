using System;
using Gtk;
using Gtk.DotNet;
using SharpFFmpeg;
using System.Threading;
using System.IO;
using System.Drawing;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		g = Gtk.DotNet.Graphics.FromDrawable (mainDraw.GdkWindow);
		string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
		Environment.CurrentDirectory = myExeDir;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	private System.Drawing.Graphics g = null;

	Thread workingThread = null;
	bool closing = false;
	protected void Click_Handler (object sender, EventArgs e)
	{
		string file = "/home/apa/test.wmv";
		//writer.Seek(44, SeekOrigin.Begin);
		workingThread = new Thread(new ThreadStart(() =>
		                                           {
			var stream = FFMpegBase.Instance.GetAVStream(file);
			IAVFrame frame = null;
			while ( ((frame = stream.GetNext()) != null) && (!closing))
			{
				if (frame.FrameType == AVFrameType.Video)
				{
					SharpFFmpeg.VideoFrame video = (SharpFFmpeg.VideoFrame)frame;
					if (frame.Decode())
					{
						var data = video.ImgData;
						DrawImage(data);
					}
				}
				else if(frame.FrameType == AVFrameType.Audio)
				{
					SharpFFmpeg.AudioFrame audio = (SharpFFmpeg.AudioFrame)frame;
					if (audio.Decode())
					{
						var data = audio.WaveDate;
					}
				}
				frame.Close();
			}
			stream.Close();
		}));
		workingThread.Start();

	}

	private void DrawImage(VideoFrameType type)
	{
		Stream str = new MemoryStream();
		BinaryWriter writer = new BinaryWriter(str);
		// LITTLE ENDIAN!!
		writer.Write(new byte[] { 0x42, 0x4D });
		writer.Write((int)(type.managedData.Length + 0x36));
		writer.Write((int)0);
		writer.Write((int)0x36);
		writer.Write((int)40);
		writer.Write((int)type.width);
		writer.Write((int)type.height);
		writer.Write((short)1);
		writer.Write((short)24);
		writer.Write((int)0);
		writer.Write((int)type.managedData.Length);
		writer.Write((int)3780);
		writer.Write((int)3780);
		writer.Write((int)0);
		writer.Write((int)0);
		for (int y = type.height - 1; y >= 0; y--)
			writer.Write(type.managedData, y * type.linesize, type.width * 3);
		writer.Flush();
		writer.Seek(0, SeekOrigin.Begin);
		Bitmap bitmap = new Bitmap(str);
		g.DrawImage(bitmap, 0, 0, mainDraw.WidthRequest, mainDraw.HeightRequest);
		writer.Close();

	}

}
