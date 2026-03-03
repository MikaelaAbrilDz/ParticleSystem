using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    [SerializeField] int particleNumber;
    [SerializeField] float initialAngle;
    [SerializeField] float angleVariation;
    [SerializeField] float initialSpeed;
    [SerializeField] float speedVariation;
    [SerializeField] float initialLifeTime;
    [SerializeField] float lifeTimeVariation;
    [SerializeField] float gravity;
    Particle lastParticle;
    public void onBurst(InputAction.CallbackContext context)
    {
        if (context.performed)CreateParticleExplosion();
    }
    void CreateParticleExplosion()
    {
        for (int i = 0; i < particleNumber; i++)
        {
            lastParticle = Instantiate(particlePrefab, transform).GetComponent<Particle>();
            float angle = initialAngle + angleVariation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value);
            float speed = Mathf.Max(initialSpeed + speedVariation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value), 0);
            float lifeTime = initialLifeTime + lifeTimeVariation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value);
            lastParticle.SetValues(this, angle, speed, lifeTime, gravity);
        }
    }
    public void UpdateParticleExplosion(Particle p, float t)
    {
        if (p.lifeTime < t)
        {
            p.gameObject.SetActive(false);
            return;
        }
        Vector3 newPosition = p.transform.position;
        newPosition.x = p.initialSpeedX * t;
        newPosition.y = (p.initialSpeedY * t) - (p.gravity * t * t / 2);
        p.transform.position = newPosition;
    }
}
