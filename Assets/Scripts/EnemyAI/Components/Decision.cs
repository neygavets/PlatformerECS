namespace EnemyAI {
    public enum ActionType {
        Normal,
        Agressive,
        Cowardly,
    }

    struct Decision {
        /// <summary>
        /// Current action to perform
        /// </summary>
        public ActionType Value;
    }
}