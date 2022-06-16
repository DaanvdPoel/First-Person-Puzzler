using UnityEngine;

[CreateAssetMenu(fileName = "Audiodata", menuName = "ScriptableObjects/Audiodata", order = 0)]
public class AudioScriptableObject : ScriptableObject
{
    public AudioClip[] soundEffects;
    public AudioClip[] backgroundMusic;
}

