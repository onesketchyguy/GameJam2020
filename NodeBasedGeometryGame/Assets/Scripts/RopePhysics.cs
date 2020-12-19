using UnityEngine;

public class RopePhysics : MonoBehaviour
{
    [SerializeField]
    private LineRenderer linerenderer = null;

    [SerializeField]
    private int vertices = 20;

    private Vector3[] vertexPositions;

    public Transform startPoint;
    public Transform tracking;

    private void Start()
    {
        linerenderer.positionCount = vertices;
        vertexPositions = new Vector3[vertices];

        vertexPositions[0] = startPoint != null ? startPoint.position : transform.position;
    }

    private void Update()
    {
        // Set positions for each vertex
        linerenderer.SetPositions(vertexPositions);

        // Update the positions for each vertex
        for (int i = 1; i < vertices - 1; i++)
        {
            vertexPositions[i] = Vector3.Lerp(vertexPositions[i - 1], vertexPositions[i + 1], 0.5f) + Vector3.up * Physics.gravity.y * Time.deltaTime;
        }

        vertexPositions[vertices - 1] = tracking.position;
    }
}