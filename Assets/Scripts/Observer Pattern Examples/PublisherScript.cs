using System;
using UnityEngine;
using UnityEngine.Events;

public class PublisherScript : MonoBehaviour
{
    // Observer pattern #1:
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs
    {
        public Vector3 position;
    }

    // Observer pattern #2:
    public event OnQPressed QPressed;
    public delegate void OnQPressed(Vector3 position);

    // Observer pattern #3:
    public event Action<Vector3> WPressed;

    // Observer pattern #4:
    public UnityEvent OnUnityEvent;

    private void Update()
    {
        // Observer #1 being called when player hits space.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Does a null check before sending the signal.
            OnSpacePressed?.Invoke(this, 
                new OnSpacePressedEventArgs { position = transform.position});
        }
        // Observer #2 being called when player hits Q.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QPressed?.Invoke(transform.position);
        }
        // Observer #3 being fired when player hits W.
        if (Input.GetKeyDown(KeyCode.W))
        {
            WPressed?.Invoke(transform.position);
        }
        // Observer #4 being fired when player hits E.
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnUnityEvent?.Invoke();
        }
    }
}
