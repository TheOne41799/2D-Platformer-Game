using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDeathParticleSystem;


    public void PlayParticleSystemEffect(ParticleSystemType psType, Vector3 spawnPos)
    {
        ParticleSystem particleSystemToPlay = null;

        switch (psType)
        {
            case ParticleSystemType.PLAYER_DEATH:
                particleSystemToPlay = playerDeathParticleSystem;
                break;
        }


        if (particleSystemToPlay != null)
        {
            particleSystemToPlay.transform.position = spawnPos;
            particleSystemToPlay.Play();
        }
        else
        {
            Debug.LogError("Particle system not assigned for type: " + psType);
        }
    }
}


public enum ParticleSystemType
{
    PLAYER_DEATH,
    LEVEL_FINISHED
}






