using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance{get;private set;}
    private AudioSource audioSource;
    void Awake()
    {
        
            Instance = this;
            audioSource = this.GetComponent<AudioSource>();
           
        
        
    }
    
    public void PlayBgm(string bgmpath)
    {
        AudioClip ac = Resources.Load<AudioClip>(bgmpath);
        audioSource.clip = ac;
        
        audioSource.Play();
    }
    public void PlayClip(string path,float volumn = 1)
    {
         AudioClip ac = Resources.Load<AudioClip>(path);
         AudioSource.PlayClipAtPoint(ac,transform.position,volumn);
    }
   
    
}
