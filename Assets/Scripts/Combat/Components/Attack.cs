using UnityEngine;

namespace Combat {
    struct Attack {
        public int Damage { get => Random.Range (Min, Max); }
        public int Max;
        public int Min;
		public int Default;
    }
}