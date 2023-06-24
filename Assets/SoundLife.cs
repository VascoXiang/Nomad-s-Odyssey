using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLife : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject,gameObject.GetComponent<AudioSource>().clip.length);
    }
}
