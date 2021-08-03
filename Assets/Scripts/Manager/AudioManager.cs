using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    #endregion

    public enum ChannelType
    {
        Sfx,
        BackgroundMusic,
        UIfx,
        Sfx3D
    }

    [SerializeField] private int _sfxChannels = 5;
    [SerializeField] private int _backgroundMusicChannels = 3;
    [SerializeField] private int _UIfxChannels = 2;
    [SerializeField] private int _3DsfxChannels = 5;

    //variables de uso
    private AudioSource[] _sfx;
    private AudioSource[] _backgroundMusic;
    private AudioSource[] _UIfx;
    private AudioSource[] _3Dsfx;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _sfx = new AudioSource[_sfxChannels];
        Initialize2DChannels(_sfx);

        _backgroundMusic = new AudioSource[_backgroundMusicChannels];
        Initialize2DChannels(_backgroundMusic);

        _UIfx = new AudioSource[_UIfxChannels];
        Initialize2DChannels(_UIfx);

        _3Dsfx = new AudioSource[_3DsfxChannels];
        Initialize2DChannels(_3Dsfx);
    }

    private void Initialize2DChannels(AudioSource[] sources)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();

            sources[i].spatialBlend = 0; // a 1 value makes it 3D
            sources[i].playOnAwake = false;
        }
    }

    private void Initialize3DChannels(AudioSource[] sources)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i] =new GameObject().AddComponent<AudioSource>();

            sources[i].spatialBlend = 1; // a 1 value makes it 3D
            sources[i].playOnAwake = false;
            sources[i].transform.SetParent(this.transform);
        }
    }

    private void PlayClip(AudioClip clip, float volume, bool loop, AudioSource[] sources)
    {
        AudioSource source = FindEmptySource(sources);

        if (source)//If not null;
        {
            source.clip = clip;
            source.volume = volume;
            source.loop = loop;

            source.Play();
        }
    }

    /// <summary>
    /// Return null if there are no empty sources available
    /// </summary>
    /// <param name="sources"></param>
    /// <returns></returns>
    private AudioSource FindEmptySource(AudioSource[] sources)
    {
        foreach (AudioSource source in sources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }

        Debug.LogError("No empty sources");
        return null;
    }

    /// <summary>
    /// Return null if there are no clip as the one passed as a parameter
    /// </summary>
    /// <param name="sources"></param>
    /// <returns></returns>
    private AudioSource FindClip(AudioClip clip, AudioSource[] sources)
    {
        foreach (AudioSource source in sources)
        {
            if (source.clip == clip)
            {
                return source;
            }            
        }

        Debug.LogError("No such clip in "+ sources);
        return null;
    }

    private void ChangeVolume(AudioClip clip, float volume, ChannelType type)
    {
        AudioSource source;
        switch (type)
        {
            case ChannelType.Sfx:
                source = FindClip(clip, _sfx);

                if(source.isPlaying)
                {
                    source.volume = volume;
                }                
                break;
            case ChannelType.BackgroundMusic:
                source = FindClip(clip, _backgroundMusic);

                if (source.isPlaying)
                {
                    source.volume = volume;
                }
                break;
            case ChannelType.UIfx:
                source = FindClip(clip, _UIfx);

                if (source.isPlaying)
                {
                    source.volume = volume;
                }
                break;
            case ChannelType.Sfx3D:
                source = FindClip(clip, _3Dsfx);

                if (source.isPlaying)
                {
                    source.volume = volume;
                }
                break;
            default:
                break;
        }
    }

    private void StopClip(AudioClip clip,  ChannelType type)
    {
        AudioSource source;
        switch (type)
        {
            case ChannelType.Sfx:
                source = FindClip(clip, _sfx);

                if (source.isPlaying)
                {
                    source.Stop();
                }
                break;
            case ChannelType.BackgroundMusic:
                source = FindClip(clip, _backgroundMusic);

                if (source.isPlaying)
                {
                    source.Stop();
                }
                break;
            case ChannelType.UIfx:
                source = FindClip(clip, _UIfx);

                if (source.isPlaying)
                {
                    source.Stop();
                }                
                break;
            case ChannelType.Sfx3D:
                source = FindClip(clip, _3Dsfx);

                if (source.isPlaying)
                {
                    source.Stop();
                }
                break;
            default:
                break;
        }
    }

    private void PauseClip(AudioClip clip, ChannelType type)
    {
        AudioSource source;
        switch (type)
        {
            case ChannelType.Sfx:
                source = FindClip(clip, _sfx);

                if (source.isPlaying)
                {
                    source.Pause();
                }
                break;
            case ChannelType.BackgroundMusic:
                source = FindClip(clip, _backgroundMusic);

                if (source.isPlaying)
                {
                    source.Pause();
                }
                break;
            case ChannelType.UIfx:
                source = FindClip(clip, _UIfx);

                if (source.isPlaying)
                {
                    source.Pause();
                }
                break;
            case ChannelType.Sfx3D:
                source = FindClip(clip, _3Dsfx);

                if (source.isPlaying)
                {
                    source.Pause();
                }
                break;
            default:
                break;
        }
    }

    public void PlayClip(AudioClip clip, float volume, bool loop, ChannelType type)
    {
        switch (type)
        {
            case ChannelType.Sfx:
                PlayClip(clip, volume, loop, _sfx);
                break;
            case ChannelType.BackgroundMusic:
                PlayClip(clip, volume, loop, _backgroundMusic);
                break;
            case ChannelType.UIfx:
                PlayClip(clip, volume, loop, _UIfx);
                break;
            default:
                break;
        }
    }

    public void Play3DClip(AudioClip clip, float volume, bool loop, Vector3 position)
    {
        AudioSource source = FindEmptySource(_3Dsfx);

        if (source)//If not null;
        {
            source.transform.position = position;

            source.clip = clip;
            source.volume = volume;
            source.loop = loop;

            //Se le puede agregar todos los chiches que se quiera.


            source.Play();
        }
    }
}
