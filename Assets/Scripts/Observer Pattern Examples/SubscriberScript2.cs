using System.Collections;
using UnityEngine;

public class SubscriberScript2 : MonoBehaviour
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
        publisher.QPressed += OnQPressedSubscriber;
    }

    // Whenever the signal is sent, the subscriber can use any information carried within.
    private void OnQPressedSubscriber(Vector3 position)
    {
        // The visual queue is a delayed jump based on position.
        StartCoroutine(Jump(DelayTime(position)));
    }

    private IEnumerator Jump(float delayTime)
    {
        publisher.QPressed -= OnQPressedSubscriber;
        yield return new WaitForSeconds(delayTime);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        yield return new WaitForSeconds(1.0f - delayTime);
        publisher.QPressed += OnQPressedSubscriber;
    }

    private float DelayTime(Vector3 position)
    {
        position -= transform.position;
        return position.magnitude / interval;
    }
}
