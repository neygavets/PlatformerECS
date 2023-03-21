using UnityEngine;

namespace Service {
	public class PreferencesService {
		//TODO: Зашифровывать сохранения
		private const string PLAYER_CURRENT_HEALTH = "player_current_health";
		private const string PLAYER_MAX_HEALTH = "player_max_health";
		private const int PLAYER_MAX_HEALTH_DEFAULT = 100;

		public void SavePlayerCurrentHealth ( int value ) {
			PlayerPrefs.SetInt (PLAYER_CURRENT_HEALTH, value);
		}

		public int LoadPlayerCurrentHealth () {
			if (PlayerPrefs.HasKey (PLAYER_CURRENT_HEALTH))
				return PlayerPrefs.GetInt (PLAYER_CURRENT_HEALTH);
			else if (PlayerPrefs.HasKey (PLAYER_MAX_HEALTH))
				return PlayerPrefs.GetInt (PLAYER_MAX_HEALTH);
			else
				return PLAYER_MAX_HEALTH_DEFAULT;
		}

		public void SavePlayerMaxHealth ( int value ) {
			PlayerPrefs.SetInt (PLAYER_MAX_HEALTH, value);
		}

		public int LoadPlayerMaxHealth () {
			if (PlayerPrefs.HasKey (PLAYER_MAX_HEALTH))
				return PlayerPrefs.GetInt (PLAYER_MAX_HEALTH);
			else
				return PLAYER_MAX_HEALTH_DEFAULT;
		}
	}
}
