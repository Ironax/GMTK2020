using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
	[SerializeField] private float baseGlobalVolume = 0.2f;
	[SerializeField] private float baseMusicVolume = 0.2f;
	private AudioSource audioSource;
	private AudioListener audioListener;
    // Start is called before the first frame update
    void Start()
	{
		audioSource = GetComponent<AudioSource>();
		UpdateVolumeValues();
	}

	public void UpdateVolumeValues()
	{
		if(audioSource && PlayerPrefs.HasKey("MusicVolume"))
			audioSource.volume   = PlayerPrefs.GetFloat("MusicVolume");
		if(PlayerPrefs.HasKey("GlobalVolume"))
			AudioListener.volume = PlayerPrefs.GetFloat("GlobalVolume");
	}

	public void SetMusicActive(bool active)
	{
		if(active)
			PlayerPrefs.SetFloat("MusicVolume", baseMusicVolume);
		else
			PlayerPrefs.SetFloat("MusicVolume", 0.0f);
		UpdateVolumeValues();
	}

	public void SetSoundActive(bool active)
	{
		if (active)
			PlayerPrefs.SetFloat("GlobalVolume", baseGlobalVolume);
		else
			PlayerPrefs.SetFloat("GlobalVolume", 0.0f);
		UpdateVolumeValues();
	}
}
