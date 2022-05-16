using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    [RequireComponent(typeof(Steering))]

    public class SimpleBrain : MonoBehaviour
    {
        // supported behaviours
        public enum BehaviourEnum {Keyboard, SeekClickPoint, NotSet}

        [Header("Manual")]
        public BehaviourEnum m_behaviour; // the requested behaviour
        public GameObject m_target;       // the target we are working with
        public List<GameObject> m_wayPoints;
        

        [Header("Private")]
        private Steering m_steering;

        public SimpleBrain()
        {
            m_behaviour = BehaviourEnum.NotSet;
            m_target = null;
        }

        private void Start()
        {
            //try to get the target and steering target
            if (m_behaviour == BehaviourEnum.Keyboard || m_behaviour == BehaviourEnum.SeekClickPoint)
            {
                m_target = null;
            }

            else
            {
                if(m_target == null)
                {
                    m_target = GameObject.Find("Player");
                }
                if(m_target == null)
                {
                    m_target = GameObject.Find("Target");
                }
            }

            // get steering
            m_steering = GetComponent<Steering>();

            // configure steering
            List<IBehaviour> behaviours = new List<IBehaviour>();
            switch (m_behaviour)
            {
                case BehaviourEnum.Keyboard:
                    behaviours.Add(new Keyboard());
                    m_steering.SetBehaviours(behaviours, "Keyboard");
                    break;

               
                default:
                    Debug.LogError($"Behaviour of type {m_behaviour} not implemented yet!");
                    break;
            
            }
        }
    }
}

