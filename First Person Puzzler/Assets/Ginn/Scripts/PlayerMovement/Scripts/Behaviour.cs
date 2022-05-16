using UnityEngine;

public abstract class Behaviour: IBehaviour
{
    [Header("Behaviour Runtime")]
    public Vector3 m_positionTarget = Vector3.zero;      // targeted position
    public Vector3 m_velocityDesired = Vector3.zero;     // current velocity

    // position where target needs to go to
    public virtual void Start(BehaviourContext context)
    {
        m_positionTarget = context.m_position;
    }

    // calculate and return steering force
    public abstract Vector3 CalculateSteeringForce(float dt, BehaviourContext context);


    // draws all support in scene
    public virtual void OnDrawGizmos(BehaviourContext context)
    {
        Support.DrawRay(m_positionTarget, m_velocityDesired, Color.red);
        Support.DrawSolidDisc(m_positionTarget, Color.cyan);
    }
}
