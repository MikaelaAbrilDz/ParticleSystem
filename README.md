# Particle System Project

## How does it work
When pressing the spacebar, it spawns a burst of particles.
## Classes used
#### Particle Controller
Spawner and manager of the particles. It instantates a particle prefab and gives it values to its paremeters.
It does it using a base value for the parameter and a variation value. Then it gives a normal distribution using those values to get the final value for the parameter.
#### Particle
Used in every particle prefab. It stores its initial parameters and calls the Particle Controller to update its values based on a time parameter. Then, it applies those values to the particle transform.
## Parameters used
#### Particle number
The number of particles spawned on every burst.
#### Initial angle
The base angle on which the particles are launched.
#### Angle variation
The launch angle variation used per particle using a normal distribution.
#### Initial speed
The base speed at which the particles are launched.
#### Speed variation
The launch speed variation used per particle using a normal distribution.
#### Initial lifetime
The base lifetime at which the particles are launched.
#### Lifetime variation
The lifetime variation used per particle using a normal distribution.
#### Gravity
The gravity all particles will use.
