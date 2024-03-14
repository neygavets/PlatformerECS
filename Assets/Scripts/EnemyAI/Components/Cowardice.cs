using UnityEngine;

namespace EnemyAI {
    struct Cowardice {
        float value;

        /// <summary>
        /// 0: brave, 100: scared
        /// </summary>
        public float Value {
            get => value;
            set => this.value = this.value = Mathf.Clamp (value, 0, 100);
        }
	}
}