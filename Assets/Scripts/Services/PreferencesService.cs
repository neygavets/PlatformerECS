using Characters;
using UnityEngine;

namespace Service {
	public class PreferencesService {
		//TODO: Зашифровывать сохранения
		private const string PLAYER_MAX_HEALTH = "player_max_health";

		private PlayerData playerData;

		public PreferencesService ( PlayerData playerData ) {
			this.playerData = playerData;
		}

		public void SavePlayerData () {
			PlayerPrefs.SetInt (PLAYER_MAX_HEALTH, playerData.Stamina);
		}

		public void LoadPlayerData () {
			if (PlayerPrefs.HasKey (PLAYER_MAX_HEALTH))
				playerData.Stamina = PlayerPrefs.GetInt (PLAYER_MAX_HEALTH);
		}
	}
}