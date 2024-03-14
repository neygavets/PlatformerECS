using UnityEngine;

namespace EnemyAI {
    struct Aggression {
        float value;

        /// <summary>
        /// 0: peaceful, 100: fury
        /// </summary>
        public float Value {
            get => value;
            set => this.value = Mathf.Clamp (value, 0, 100);
        }
    }
}