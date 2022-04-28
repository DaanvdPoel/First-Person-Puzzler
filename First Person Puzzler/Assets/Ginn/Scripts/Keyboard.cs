using UnityEngine;


    public class Keyboard : Behaviour
    {
        public override Vector3 CalculateSteeringForce(float dt, BehaviourContext context)
        {
            // get requested direction from input
            Vector3 requestedDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            // update target position
            if(requestedDirection != Vector3.zero)
            {
                m_positionTarget = context.m_position + requestedDirection.normalized * context.m_settings.m_maxDesiredVelocity;
            }

            else
            {
                m_positionTarget = context.m_position;
            }

            // calculate desired velocity and return the steering force
            m_velocityDesired = (m_positionTarget - context.m_position).normalized * context.m_settings.m_maxDesiredVelocity;
            return m_velocityDesired - context.m_velocity;
        }
    }

