using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public float maxDistance;
    public Material puzzleMat;
    public GameObject puzzlePiece;

    bool pieceGrabbed;
    bool isEnabled;
    MeshRenderer meshRenderer;
    PuzzleController controller;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        controller = GetComponentInParent<PuzzleController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (pieceGrabbed && !isEnabled && Vector3.Distance(transform.position, puzzlePiece.transform.position) <= maxDistance)
        {
            meshRenderer.enabled = true;
            isEnabled = true;
        } else if (isEnabled && (!pieceGrabbed || Vector3.Distance(transform.position, puzzlePiece.transform.position) > maxDistance))
        {
            meshRenderer.enabled = false;
            isEnabled = false;
        }
    }

    public void TriggerPieceGrabbed()
    {
        pieceGrabbed = true;
    }

    public void TriggerPieceUngrabbed()
    {
        if (Vector3.Distance(transform.position, puzzlePiece.transform.position) < maxDistance)
        {
            puzzlePiece.SetActive(false);
            meshRenderer.material = puzzleMat;
            controller.AddSnappedPiece();
            return;
        }

        pieceGrabbed = false;
    }

}
