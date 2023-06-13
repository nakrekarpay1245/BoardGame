using UnityEngine;

[System.Serializable]
public class Particle
{
    public string name;
    public ParticleSystem particleSystem;

    public void Play()
    {
        particleSystem.Play();
    }

    public bool IsPlaying()
    {
        return particleSystem.isPlaying;
    }
}
