using UnityEngine;

// the robot's walk animation sends these signals for footstep sounds
// the guard does not need sounds, so they do nothing (they only stop console errors)
public class GuardAnimationEvents : MonoBehaviour
{
    void OnFootstep(AnimationEvent animationEvent) { }
    void OnLand(AnimationEvent animationEvent) { }
}