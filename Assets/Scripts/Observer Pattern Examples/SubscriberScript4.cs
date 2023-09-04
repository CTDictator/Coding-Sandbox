using System.Collections;
using UnityEngine;

public class SubscriberScript4 : MonoBehaviour
{
    private PublisherScript publisher;
    private Rigidbody rb;
    private const float force = 3.0f;
    private const float interval = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Need a reference to the publisher and then subscribe to it.
        publisher = GameObject.Find("Publisher").GetComponent<PublisherScript>();
    }

    // Whenever the signal is sent, the subscriber can use any information carried within.
    public void OnEPressedSubscriber()
    {
        // The visual queue is a delayed jump based on position.
        StartCoroutine(Jump(DelayTime(transform.position)));
    }

    private IEnumerator Jump(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        yield return new WaitForSeconds(1.0f - delayTime);
    }

    private float DelayTime(Vector3 position)
    {
        position -= transform.position;
        return position.magnitude / interval;
    }
}
