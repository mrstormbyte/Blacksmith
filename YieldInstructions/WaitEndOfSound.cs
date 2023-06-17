using UnityEngine;

public class WaitForEndOfSound : CustomYieldInstruction
{
    //Звук
    private AudioSource _audioSource;

    public override bool keepWaiting
    {
        get => _audioSource.isPlaying;
    }

    public WaitForEndOfSound(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }
}
