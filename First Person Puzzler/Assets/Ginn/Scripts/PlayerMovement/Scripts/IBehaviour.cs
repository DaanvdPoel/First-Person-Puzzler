using UnityEngine;

public interface IBehaviour
{
    // allow the behaviour to initialize
    void Start(BehaviourContext context);

    // calculate the steering force contributed by this behaviour
    Vector3 CalculateSteeringForce(float dt, BehaviourContext context);


    // draw the Gizmos for this behaviour
    void OnDrawGizmos(BehaviourContext context);
}
