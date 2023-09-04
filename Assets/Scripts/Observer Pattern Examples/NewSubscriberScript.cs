using UnityEngine;

public class NewSubscriberScript : MonoBehaviour
{
    NewPublisherScript publisher;

    private void Awake()
    {
        if (GameObject.Find("Sphere").TryGetComponent(out publisher))
            publisher.SigSent += SignalRecieved;
    }

    private void SignalRecieved(Vector3 location, Vector3 angle, Vector3 scale)
    {
        Debug.Log($"{location}/{angle}/{scale}");
    }
}
