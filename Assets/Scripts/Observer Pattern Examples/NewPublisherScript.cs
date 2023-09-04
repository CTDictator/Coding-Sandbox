using UnityEngine;

public class NewPublisherScript : MonoBehaviour
{
    public delegate void SignalSent(Vector3 transform, Vector3 rotation, Vector3 scale);
    public event SignalSent SigSent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SigSent?.Invoke(transform.position, transform.rotation.eulerAngles, transform.localScale);
        }
    }
}
