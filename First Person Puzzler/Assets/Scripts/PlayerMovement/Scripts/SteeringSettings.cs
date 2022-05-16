using UnityEngine;


[CreateAssetMenu(fileName = "Steering Settings", menuName = "Steering/SteeringSettings", order = 1)]
public class SteeringSettings : ScriptableObject
{
    [Header("Steering Settings")]
    public float m_mass = 70.0f;                  // mass in kg
    public float m_maxDesiredVelocity = 3.0f;     // max desired velocity in m/s
    public float m_maxSteeringForce = 3.0f;       // max steering force in m/s
    public float m_maxSpeed = 3.0f;               // max speed in m/s

    [Header("Follow Path")]
    public float m_followPathRadius = 0.2f;     // radius to change waypoint

    [Header("Arrive")]
    public float arriveDistance = 1.0f;         // distance to object when we reach zero velocity in m
    public float slowingDistance = 2.0f;

    [Header("Pursue and evade")]
    public float lookAheadTime = 1.0f;

    [Header("Wander")]
    public float wanderCircleDistance = 5.0f;
    public float wanderCircleRadius = 5.0f;
    public float wanderNoiseAngle = 10.0f;

    [Header("Avoid")]
    public string m_obstacleLayer = "Obstacles";  // the layer name containing all obstacle colliders
    public string m_wallLayer = "Walls";      // the layer name containing all walls colliders

    public float m_avoidDistance = 3.0f;        // length of feeler ray detecting obstacles and walls in m
    public float m_avoidMaxForce = 5.0f;        // max steering 'force' to avoid obstacles and walls in m/s
    public float m_avoidAngleThreshold = 1.0f;        // angle threshold in degrees

    [Header("Hide")]
    public string m_hideLayer = "Obstacles";
    public float m_hideOffset = 1.0f;
}
