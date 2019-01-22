using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//a collection of audio clips. pooled and triggered by ID.

public class SFXController : SingletonBehavior<SFXController>
{
    public AudioSource audioSrc;

    [System.Serializable]
    public class Sound
    {
        public SOUND_ID id;
        public AudioClip[] variants;
    };

    public Sound[] pool = new Sound[1];

    public enum SOUND_ID
    {
        FOOTBALL_COLLISION,
        BALL_GOAL,
        KICK_BALL,
        BOO,
        CHEER,
        COUNTDOWN_A,
        COUNTDOWN_B,
        FIREWORKS,
        BACK_BUTTON,
        GENERAL_BUTTON,

        SCORE_RING,

        BASKETBALL_BACKBOARD,
        BASKETBALL_GROUND_01,
        BASKETBALL_GROUND_02,
        BASKETBALL_NET,
        BASKETBALL_RIM,
        BASKETBALL_THROW,

        HATRICK_IGNITE,
        GUI_ENDSCORE_ROLLBACK,
        GUI_ENDSCORE_ROLLOUT,

        BASEBALL_PITCH,
        BASEBALL_PITCH_FIREBALL,
        BASEBALL_FIREBALL_MISS,
        BASEBALL_HIT,
        BASEBALL_SWING,
        BASEBALL_WINDUP,

        HOCKEY_BLOCKED,
        HOCKEY_GOAL_CROSSBAR,
        HOCKEY_GOAL_NET,
        HOCKEY_POST_BOUNCE,
        HOKCEY_HIT,
        HOCKEY_WALL_BOUNCE,
        HOCKEY_STICK_PULLBACK,

        BEERPONG_CUP_BOUNCE,
        BEERPONG_TABLE_BOUNCE,
        BEERPONG_SCORE,

        BASKETBALL_GROUND_03,
        BASKETBALL_GROUND_04,

        NUM_SOUNDS
    };

    const int kNumSounds = (int)SOUND_ID.NUM_SOUNDS;

    Dictionary<SOUND_ID, AudioClip[]> _clipPool = new Dictionary<SOUND_ID, AudioClip[]>();


    bool _bMute = false;
    public bool Mute
    {
        get { return _bMute; }
        set { _bMute = value; _Mute(_bMute); }
    }

    void _Mute(bool bSetMute)
    {
        if (audioSrc.mute != bSetMute)
        {
            audioSrc.mute = bSetMute;
        }
    }


    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {

        //ideally we could make this into an array of lists so we can have variants
        //convert the inspector into a usable format
        for (int i = 0; i < pool.Length; ++i)
        {
            if (pool[i].variants != null)
            {
                int len = pool[i].variants.Length;
                if (len > 0)
                {
                    _clipPool[pool[i].id] = new AudioClip[len];
                    pool[i].variants.CopyTo(_clipPool[pool[i].id], 0);
                }
            }
        }
    }

    float[] fLastPlayTime = new float[kNumSounds];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < kNumSounds; ++i)
        {
            fLastPlayTime[i] = 0;
        }
    }

    public void PlaySound(SOUND_ID eID)
    {
        //only play if..
        if (Time.time - fLastPlayTime[(int)eID] > 0.01F)
        {
            //go ahead and play.
            //pick a random one
            if (!_clipPool.ContainsKey(eID))
                return;

            int nLen = _clipPool[eID].Length;
            int nRand = Random.Range(0, nLen - 1);
            audioSrc.PlayOneShot(_clipPool[eID][nRand]);
            fLastPlayTime[(int)eID] = Time.time;
        }
    }

}
