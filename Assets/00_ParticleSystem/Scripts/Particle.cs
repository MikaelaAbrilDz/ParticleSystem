using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleController controller;
    public float initialAngle;
    public float initialSpeedX, initialSpeedY;
    public float lifeTime;
    public float gravity;
    public float time;
    public void SetValues(ParticleController controller, float initialAngle, float initialSpeed, float lifeTime, float gravity)
    {
        this.controller = controller;
        this.initialAngle = initialAngle;
        this.initialSpeedX = initialSpeed * Mathf.Cos(initialAngle * Mathf.Deg2Rad);
        this.initialSpeedY = initialSpeed * Mathf.Sin(initialAngle * Mathf.Deg2Rad);
        this.lifeTime = lifeTime;
        this.gravity = gravity;

        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        controller.UpdateParticleExplosion(this, time);
    }
}
