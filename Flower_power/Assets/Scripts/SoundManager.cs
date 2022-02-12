
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{ get; private set; }
    private AudioSource source;
    private void Awake(){
        source = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip _sound){
        source.PlayOneShot(_sound);
    }
}