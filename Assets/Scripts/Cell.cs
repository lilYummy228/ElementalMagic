using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsFilled /*{ get; private set; }*/ = false;

    public void UpdateState()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back);

        if (hit && hit.collider.gameObject.TryGetComponent(out Element element))
        {
            Debug.Log(element);

            IsFilled = true;
        }
        else
        {
            IsFilled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.back);
    }
}
