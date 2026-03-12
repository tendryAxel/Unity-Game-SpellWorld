using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSc : MonoBehaviour
{
    [SerializeField]
    private string sceneAfterPassingTheDoor;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with " + other);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Load scene " + sceneAfterPassingTheDoor);
            SceneManager.LoadScene(sceneAfterPassingTheDoor);
        }
    }
}
