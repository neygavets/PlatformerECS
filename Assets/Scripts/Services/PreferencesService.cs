using Characters;
using UnityEngine;

namespace Service
{
	public class PreferencesService
	{
		private const string PLAYER_MAX_HEALTH = "player_max_health";

		private PlayerData _playerData;

		public PreferencesService ( PlayerData playerData )
		{
			this._playerData = playerData;
		}

		public void SavePlayerData ()
		{
			PlayerPrefs.SetInt (PLAYER_MAX_HEALTH, _playerData.Stamina);
		}

		public void LoadPlayerData ()
		{
			if (PlayerPrefs.HasKey (PLAYER_MAX_HEALTH))
				_playerData.Stamina = PlayerPrefs.GetInt (PLAYER_MAX_HEALTH);
		}
	}
}