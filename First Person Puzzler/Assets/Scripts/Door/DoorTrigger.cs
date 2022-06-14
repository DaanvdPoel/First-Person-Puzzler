using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isDoorLocked = false;
    [SerializeField] private Door[] doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller) && isDoorLocked == false)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (!doors[i].IsOpen)
                {
                    doors[i].Open(other.transform.position);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller) && isDoorLocked == false)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].IsOpen)
                {
                    doors[i].Close();
                }
            }
        }
    }
}