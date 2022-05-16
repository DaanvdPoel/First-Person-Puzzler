using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    using BehaviourList = List<IBehaviour>;


    public class Steering : MonoBehaviour
    {
        [Header("Steering Settings")]
        public string m_label;                                       // label to show when running 
        public SteeringSettings m_settings;                          // the steering settings for all behaviours

        [Header("Steering Runtime")]
        public Vector3 m_position = Vector3.zero;                    // current position
        public Vector3 m_velocity = Vector3.zero;                    // current velocity
        public Vector3 m_steering = Vector3.zero;                    // steering force
        public BehaviourList m_behaviours = new BehaviourList();     // list with all behaviours

        private void Start()
        {
            m_position = transform.position;
        }

        private void FixedUpdate()
        {
            // calculate steering force
            m_steering = Vector3.zero;
            foreach(IBehaviour behaviour in m_behaviours)
            {
                m_steering += behaviour.CalculateSteeringForce(Time.fixedDeltaTime, new BehaviourContext(m_position, m_velocity, m_settings));
            }
            m_steering.y = 0.0f;

            // clamp steering force to maximum steering force and apply mass
            m_steering = Vector3.ClampMagnitude(m_steering, m_settings.m_maxSteeringForce);
            m_steering /= m_settings.m_mass;

            // update velocity with steering force and update position
            m_velocity = Vector3.ClampMagnitude(m_velocity + m_steering, m_settings.m_maxSpeed);
            m_position += m_velocity * Time.fixedDeltaTime;


            // update object with new position
            transform.position = m_position;
            transform.LookAt(m_position + Time.fixedDeltaTime * m_velocity);
        }

        // draw all supportive items in scene
        private void OnDrawGizmos()
        {
            Support.DrawRay(transform.position, m_velocity, Color.red);
            Support.DrawLabel(transform.position, m_label, Color.white);

            foreach(IBehaviour behaviour in m_behaviours)
            {
                behaviour.OnDrawGizmos(new BehaviourContext(m_position, m_velocity, m_settings));
            }
        }

        // sets current behaviour of object
        public void SetBehaviours(BehaviourList behaviours, string label = "")
        {
            m_label = label;
            m_behaviours = behaviours;

            foreach(IBehaviour behaviour in m_behaviours)
            {
                behaviour.Start(new BehaviourContext(m_position, m_velocity, m_settings));
            }
        }
    }
}
