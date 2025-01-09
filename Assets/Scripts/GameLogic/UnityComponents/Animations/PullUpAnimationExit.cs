using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
    public class PullUpAnimationExit : StateMachineBehaviour {
        override public void OnStateExit ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            MonoEntity monoEntity = animator.gameObject.GetComponentInParent<MonoEntity> ();
            if (monoEntity != null) {
                EcsEntity entity = monoEntity.Entity;
                if (entity.Has<LedgePointsLink> ()) {
                    monoEntity.gameObject.transform.position = Physics2D.Raycast (entity.Get<LedgePointsLink> ().PointBehind.position, Vector2.down, 0.5f, LayerMasks.Ground).point;
                    entity.Get<FreeMovingFlag> ();
                    entity.Get<VerticalSpeedAnimation> ().Value = 0.0f;
                    entity.Get<HorizontalMovingFlag> ();
                } else
                    Debug.Log ("Unable to pull up, the entity has no service points found (LedgePointsLink component)");
            }
        }
    }
}