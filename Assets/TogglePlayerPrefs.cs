using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class TogglePlayerPrefs : MonoBehaviour
{
	private Toggle toggle;
	[SerializeField] private string name;
    // Start is called before the first frame update
    void Start()
	{
		toggle = GetComponent<Toggle>();
		if (PlayerPrefs.HasKey(name)) toggle.isOn = !PlayerPrefs.GetFloat(name).Equals(0.0f);
	}
}
