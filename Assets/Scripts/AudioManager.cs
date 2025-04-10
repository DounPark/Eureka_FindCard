using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    AudioSource audioSource;
    public AudioClip clip;
    private float originalVolume;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            originalVolume = audioSource.volume;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }

    public void SetVolume(float volume) // ✅ 볼륨 조절 메서드
    {
        audioSource.volume = volume;
    }

    public void ResetVolume() // ✅ 볼륨 복구 메서드
    {
        audioSource.volume = originalVolume;
    }

    void OnEnable()
{
    if(audioSource != null && !audioSource.isPlaying)
    {
        audioSource.Play();  // ✅ 씬 재시작 시 자동 재생
    }
}

}
