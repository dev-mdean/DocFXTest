using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicles
{
    /// <summary>Serves as the base for all other classes in the <c>Vehicles</c> namespace</summary>
    public abstract class VehicleBase : MonoBehaviour
    {
        /// <summary>Gets and sets the maximum speed.</summary>
        public virtual float maxSpeed { get; protected set; }
        /// <summary>Gets and sets the minimum speed.</summary>
        public virtual float minSpeed { get; protected set; }
        /// <summary>Gets and sets the current speed.</summary>
        public virtual float speed { get; protected set; }
        /// <summary>Gets and sets the number of passengers.</summary>
        public virtual float passengers { get; protected set; }

        /// <summary>Makes this Vehicle go faster. The opposite of <see cref="Decelerate"/></summary>
        /// <param name="throttle">A percentage representing how fast the user wants to accelerate.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="throttle"/> is less than 0 or greater than 1.</exception>
        /// <exception cref="System.OverflowException">Thrown when the Vehicle can't go faster.</exception>
        public virtual void Accelerate(float throttle)
        {
            if (throttle < 0 || throttle > 1)
            {
                throw new System.ArgumentOutOfRangeException("throttle", "is not between 0 and 1");
            }

            if (speed + throttle > maxSpeed)
            {
                speed = maxSpeed;
                throw new System.OverflowException($"Vehicle cannot go faster than {maxSpeed}");
            }

            speed += throttle;
        }

        /// <summary>Makes this Vehicle go slower. The opposite of <see cref="Accelerate"/></summary>
        /// <param name="brake">A percentage representing how fast the user wants to decelerate.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="brake"/> is less than 0 or greater than 1.</exception>
        /// <exception cref="System.OverflowException">Thrown when the Vehicle can't go faster.</exception>
        public virtual void Decelerate(float brake)
        {
            if (brake < 0 || brake > 1)
            {
                throw new System.ArgumentOutOfRangeException("throttle", "is not between 0 and 1");
            }

            if (speed - brake < minSpeed)
            {
                speed = minSpeed;
                throw new System.OverflowException($"Vehicle cannot go slower than {minSpeed}");
            }

            speed -= brake;
        }
    }
}