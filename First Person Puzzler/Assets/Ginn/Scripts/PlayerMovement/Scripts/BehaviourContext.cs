using UnityEngine;

public class BehaviourContext
{
    public Vector3 m_position;             // the current position
    public Vector3 m_velocity;             // the current velocity
    public SteeringSettings m_settings;    // all steering settings

    public BehaviourContext(Vector3 position, Vector3 velocity, SteeringSettings settings)
    {
        m_position = position;
        m_velocity = velocity;
        m_settings = settings;
    }
}
