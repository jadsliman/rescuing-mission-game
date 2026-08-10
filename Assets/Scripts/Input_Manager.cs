using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    public Camera cam;
    public Wizard wizard;
    private Grid_Manager gm;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && wizard.CanMove)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Block clickedBlock = hit.collider.GetComponent<Block>();
                Star clickedStar = hit.collider.GetComponent<Star>();
                Gadget clickedGadget = hit.collider.GetComponent<Gadget>();
                if(clickedStar != null)
                {
                    clickedBlock = clickedStar.placedBlock;
                }

                if (clickedGadget != null)
                {
                    clickedBlock = clickedGadget.placedBlock;
                }

                if (clickedBlock != null && !wizard.OpenedBlocks.Contains(clickedBlock) && !wizard.ClosedBlocks.Contains(clickedBlock) && !wizard.FBs.Contains(clickedBlock) && clickedBlock != wizard.CurrentBlock && !wizard.Won && !wizard.Lost && !wizard.Paused)
                {
                    wizard.MoveTo(clickedBlock);
                }
            }
        }    
    }
}
