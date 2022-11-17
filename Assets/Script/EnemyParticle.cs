using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    public ParticleSystem enemyParticle;
    public CharacterPlayer player;

    private void OnParticleTrigger()
    {
        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // get
        int numEnter = enemyParticle.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);

        ParticleSystem.ColliderData collider;
        enemyParticle.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter, out collider);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = Color.blue;

            Debug.Log("Collide With Player");
            player.TakeDamage(1);

            p.remainingLifetime = 0f;
            enter[i] = p;
        }

        // set
        enemyParticle.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);
    }
}
