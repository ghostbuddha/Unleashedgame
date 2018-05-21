using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : StateMachineBehaviour {
    
    int caseSwitch;
    //Player player = Animator.FindObjectOfType<Player>();
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        
        //caseSwitch = animator.gameObject.GetComponent<Baddie>().addNo;

        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	switch (caseSwitch)
        {
            case 1:
                //  Universal Buff
                break;
            case 2:
                //  Slow/Freeze
                break;
            case 3:
                //  Miasma DoT
                break;
            case 4:
                //  Defense Steal
                break;
            default:
                
                break;
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
