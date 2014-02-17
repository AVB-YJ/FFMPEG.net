#include <alsa/asoundlib.h> 
#include <stdio.h>

int main()
{
	snd_pcm_t *pcm = NULL;
	int err;
	if ((err = snd_pcm_open(&pcm, "default",
						     SND_PCM_STREAM_PLAYBACK, 0)) < 0)
	{
		printf("Playback open error: %s\n", snd_strerror(err));
		exit(EXIT_FAILURE);
	}
	else
	{
		printf("Playback open ok\n");
	}
	return 0;
}
