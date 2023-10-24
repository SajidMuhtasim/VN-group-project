using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]AudioSource _musicSource, SFXsource;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the manager persists between scenes if needed
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);        
    }
}
