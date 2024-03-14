namespace Utils {
    public static class MechanicÑalculator {
        public static int StaminaToHealth (int stamina) {
            return stamina * 5;
        }

        public static float AttackPower ( int primaryCharacteristic, int secondaryCharacteristic ) {
            return primaryCharacteristic + secondaryCharacteristic * 0.2f;
        }

        public static int Damage ( float attackPower, int weaponDamage, int targetArmor ) {
            float multiplier = attackPower - targetArmor;
            if (multiplier > 0)
                return (int)(weaponDamage * (1 + multiplier * 0.05f));
            else 
                return (int)(weaponDamage / (1 + multiplier * 0.05f));
        }
    }
}