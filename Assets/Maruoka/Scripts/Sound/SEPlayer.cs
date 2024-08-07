using System;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    private static Dictionary<string, AudioClip> _soundTable;

    public static void PlaySE(string name)
    {
        if (_soundTable == null)
        {
            InitializeSoundTable();
        }

        if (!_soundTable.TryGetValue(name, out var clip))
        {
            Debug.LogError("SE not found: " + name);
            return;
        }


        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 3f);
        var audioSource = new GameObject("SEPlayer").AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }

    private static void InitializeSoundTable()
    {
        _soundTable = new Dictionary<string, AudioClip>();
        var soundList = Resources.LoadAll<AudioClip>("SE");
        foreach (var sound in soundList)
        {
            _soundTable[sound.name] = sound;
        }
    }
}
