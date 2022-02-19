using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


    public class throwtest : Throwable
    {

    private Hand hand2;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("x"))
            {
                if (hand2.IsGrabEnding(this.gameObject))
                {
                    hand2.DetachObject(gameObject, restoreOriginalParent);
                }
            }
        }

    //-------------------------------------------------
    protected override  void HandAttachedUpdate(Hand hand)
    {
        if(hand2 == null)
        {
            hand2 = hand;
        }

        /*if (hand.IsGrabEnding(this.gameObject))
        {
            hand.DetachObject(gameObject, restoreOriginalParent);

            // Uncomment to detach ourselves late in the frame.
            // This is so that any vehicles the player is attached to
            // have a chance to finish updating themselves.
            // If we detach now, our position could be behind what it
            // will be at the end of the frame, and the object may appear
            // to teleport behind the hand when the player releases it.
            //StartCoroutine( LateDetach( hand ) );
        }*/

        if (onHeldUpdate != null)
            onHeldUpdate.Invoke(hand);
    }


}

