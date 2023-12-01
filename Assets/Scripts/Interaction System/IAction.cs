using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    /*
    * WHAT IS THIS SCRIPT FOR?
    * 
    * The scripts we make to solve some action and that will be activated by the switches
    * must implement this interface called IAction, so they must have defined an Activate method that
    * will run when we activate the switch.
    * Within the Activate method we solve the behavior of the action.
    * 
    */
    void Activate();

    
}
