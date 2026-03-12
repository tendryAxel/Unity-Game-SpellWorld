using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSc : MonoBehaviour
{
    [SerializeField]
    private string sceneAfterPassingTheDoor;
    [SerializeField]
    private Vector3 offset;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with " + other);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Load scene " + sceneAfterPassingTheDoor);
            SceneManager.LoadScene(sceneAfterPassingTheDoor);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Player found: " + player);
            player.transform.position = offset;
        }
    }
}
