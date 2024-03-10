using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public Sounds[] Sounds;
    public static AudioManager Instance;
    [FormerlySerializedAs("volumeSlider")]
    public Slider VolumeSlider;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        foreach (Sounds s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    //au lancement de la scène, la musique de fond se lance
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
            PlaySound("MainMenu");
        else
            PlaySound("InGame");
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    //permet de jouer un son
    public void PlaySound(string name)
    {
        Sounds s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + " not found");
            return;
        }
        s.Source.Play();
    }

    //permet d'arrêter un son
    public void StopSound(string name)
    {
        Sounds s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + " not found in StopSound");
            return;
        }
        s.Source.Stop();
    }

    //permet au slider de changer le volume
    public void VolumeChange()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }

    //sauvegarde le volume choisi par le joueur
    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", VolumeSlider.value);
    }

    //charge le volume choisi précédement pour le joueur
    public void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }


}