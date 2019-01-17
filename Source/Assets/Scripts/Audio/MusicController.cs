using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicController : SingletonBehavior<MusicController> {

  
    [System.Serializable]
    public class Music
    {
        public MUSIC_ID id;
        public AudioClip src;
        public bool bLoop = false;
    };

    public Music[] pool = new Music[1];

    public enum MUSIC_ID
    {
        MUSIC_GAME,
        NUM_TRACKS
    };

    const int kNumTracks = (int)MUSIC_ID.NUM_TRACKS;

    Queue<MUSIC_ID> _qTracks = new Queue<MUSIC_ID>();

    Dictionary<MUSIC_ID, Music> _clipPool = new Dictionary<MUSIC_ID, Music>();

    MUSIC_ID _currentTrack = MUSIC_ID.NUM_TRACKS;

    public AudioSource[] musicAudioSources = new AudioSource[2];
    public int curMainAudioSource = 0;


    bool _bPlaying = false;

    float _fGameTime = 0.0F;
    float _fQuietTime = float.NaN;


    bool _bMute = false;
    public bool Mute {
        get { return _bMute; }
        set { _bMute = value; _Mute(_bMute); }
    }

    void _Mute(bool bSetMute)
    {
        for (int i = 0; i < musicAudioSources.Length; ++i)
        {
            if (musicAudioSources[i].mute != bSetMute)
            {
                musicAudioSources[i].mute = bSetMute;
            }
        }
    }

    public void QuietTime(float fQuietTime)
    {
        float fEndTime = _fGameTime + fQuietTime;
        if (!float.IsNaN(_fQuietTime))
        {
            //we're alreadt quiet.
            if (fEndTime < _fQuietTime)
            {
                return;
            }
        }

        _fQuietTime = fEndTime;
    }

    private bool isCrossfading = false;
    // Use this for initialization
    void Awake()
    {
        //ideally we could make this into an array of lists so we can have variants
        //convert the inspector into a usable format
        for (int i = 0; i < pool.Length; ++i)
        {
            _clipPool[pool[i].id] = pool[i];
        }

        _fGameTime = 0.0F;
       
    }

    void Update()
    {
        _fGameTime += Time.deltaTime;

        bool bQuiet = false;

        if (!float.IsNaN(_fQuietTime))
        {
            if (_fGameTime >= _fQuietTime)
            {
                _fQuietTime = float.NaN;
            }
            else
            {
                bQuiet = true;
            }
        }
        const float kfQuietVolume = 0.5F;
        const float kfFullVolume = 1.0F;

        musicAudioSources[0].volume = (bQuiet) ? kfQuietVolume : kfFullVolume;
        musicAudioSources[1].volume = (bQuiet) ? kfQuietVolume : kfFullVolume;


        if (_bPlaying && !musicAudioSources[curMainAudioSource].isPlaying)
        {
            //it's done!
            if (_qTracks.Count>0)
            {
                MUSIC_ID nextTrack = _qTracks.Dequeue();
                _currentTrack = nextTrack;
                CrossFade(_clipPool[nextTrack].src);
            }
            else if(_clipPool.ContainsKey(_currentTrack) && _clipPool[_currentTrack].bLoop)
            {
                //play it again, sam.
                //looping is a product of the audio file
                {
                    musicAudioSources[curMainAudioSource].Play();
                }
            }
            else
            {
                _bPlaying = false;
            }
        }
    }


    public void Stop()
    {
        _bPlaying = false;
        if (musicAudioSources[curMainAudioSource].isPlaying)
        {
            musicAudioSources[curMainAudioSource].Stop();
        }
    }


    public void PlayTrack(MUSIC_ID track_id)
    {
        //wipe out the queue if we're taking direct control
        _qTracks.Clear();

        if (_clipPool.ContainsKey(track_id))
        {
            _bPlaying = true;
            CrossFade(_clipPool[track_id].src);
            _currentTrack = track_id;
        }
    }

    public void QueueTrack(MUSIC_ID track_id)
    {
        if (!_bPlaying)
        {
            PlayTrack(track_id);
        }
        else
        {
            _qTracks.Enqueue(track_id);
        }
    }

    public void Reset()
    {
        foreach (AudioSource source in musicAudioSources)
        {
            source.Stop();
        }

      
        curMainAudioSource = 0;
    }


    public void CrossFade(AudioClip ac)
    {
//        Debug.Log("CHANGE MUSIC : " + ac.name);
        if (!isCrossfading)
        {
            StartCoroutine(FadeOut(musicAudioSources[curMainAudioSource]));
            curMainAudioSource = (curMainAudioSource+1)%2;
            musicAudioSources[curMainAudioSource].clip = ac;
            musicAudioSources[curMainAudioSource].volume = 0;
            musicAudioSources[curMainAudioSource].Play();
            StartCoroutine(FadeIn(musicAudioSources[curMainAudioSource]));
            isCrossfading = true;
        }
        //If we try to switch tracks while still cross-fading (should only happen on load?)
        //Just switch the current main track to the new clip!
        else
        {
            musicAudioSources[curMainAudioSource].Stop();
            musicAudioSources[curMainAudioSource].clip = ac;
            musicAudioSources[curMainAudioSource].Play();
        }
    }


    private static float FADE_RATE = 0.75f;

    IEnumerator FadeOut(AudioSource a)
    {
        while( a.volume > 0.1 )
        {
            a.volume = Mathf.Lerp( a.volume, 0.0f, FADE_RATE * Time.deltaTime );
            yield return null;
        }

        // Close enough, turn it off!
        a.volume = 0.0f;
        a.Stop();
        isCrossfading = false;
    }

    IEnumerator FadeIn(AudioSource a)
    {
        while( a.volume< 0.9 )
        {
            a.volume = Mathf.Lerp( a.volume, 1.0f, FADE_RATE * Time.deltaTime);
            yield return null;
        }
 
        // Close enough, turn it on!
        a.volume = 1.0f;
    }
}
