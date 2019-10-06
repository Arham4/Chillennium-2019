using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Radio : MonoBehaviour
{
    public static float RevertTime;
    private AudioSource _audioSource;
    private bool _usingPerk;
    private int _chillUsages = 1;
    private int _pumpUsages = 1;
    private Text _usage1;
    private Text _usage2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio source is not found!");
            return;
        }
        _audioSource.loop = false;
        _usage1 = GameObject.Find("Usage1").GetComponent<Text>();
        if (_usage1 == null)
        {
            Debug.LogError("Usage1 Text is not found!");
            return;
        }
        _usage2 = GameObject.Find("Usage2").GetComponent<Text>();
        if (_usage2 == null)
        {
            Debug.LogError("Usage1 Text is not found!");
            return;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        RevertTime -= Time.deltaTime;
        if (Input.GetKeyDown("z") && _chillUsages > 0)
        {
            _usingPerk = true;
            RevertTime = 10f;
            PlaySong(SongType.Chill);
            _chillUsages--;
        }
        else if (Input.GetKeyDown("x") && _pumpUsages > 0)
        {
            _usingPerk = true;
            RevertTime = 10f;
            PlaySong(SongType.Pump);
            _pumpUsages--;
        }
        if (!_audioSource.isPlaying || (_usingPerk && RevertTime < 0))
        {
            _usingPerk = false;
            PlaySong(SongType.Regular);
        }

        _usage1.text = _chillUsages + "";
        _usage2.text = _pumpUsages + "";
    }

    private void Reset()
    {
        _chillUsages = 1;
        _pumpUsages = 1;
    }

    public void PlaySong(SongType songType)
    {
        _audioSource.clip = getAudioClip(songType);
        _audioSource.Play();
        GameSingleton.Instance.currentSongType = songType;
    }

    private AudioClip getAudioClip(SongType songType)
    {
        switch (songType)
        {
            case SongType.Regular:
                return Resources.Load<AudioClip>("Songs/general_" + Random.Range(1, 3));
            case SongType.Chill:
                return Resources.Load<AudioClip>("Songs/chill_" + Random.Range(1, 3));
            case SongType.Pump:
                return Resources.Load<AudioClip>("Songs/pump_" + Random.Range(1, 3));
            default:
                throw new ArgumentOutOfRangeException(nameof(songType), songType, null);
        }
    }
    
    public enum SongType
    {
        Regular,
        Chill,
        Pump
    }
}
