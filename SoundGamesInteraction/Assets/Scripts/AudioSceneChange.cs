using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private AudioSource audioSource;
    private bool isPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        isPlaying = false;
        audioSource.Play();
        isPlaying = true;
    }

    private void Update()
    {
        if (isPlaying && !audioSource.isPlaying)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
