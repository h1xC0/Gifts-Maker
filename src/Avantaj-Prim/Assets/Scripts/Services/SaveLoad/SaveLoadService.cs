using System.Linq;
using Constants;
using Services.LevelConfigurationService;
using UnityEngine;

namespace Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly ILevelConfigurationService _levelConfigurationService;

        public SaveLoadService(ILevelConfigurationService levelConfigurationService)
        {
            _levelConfigurationService = levelConfigurationService;
        }
        
        public void Save(PlayerProgressionModel playerProgressionModel)
        {
            var playerProgression = JsonUtility.ToJson(playerProgressionModel);
            System.IO.File.WriteAllText(SaveNames.FilePath, playerProgression);
        }

        public PlayerProgressionModel Load()
        {
            PlayerProgressionModel playerProgression = new PlayerProgressionModel
            {
                ResourcesCount = 0,
                LastLevelIndex = 1,
                GiftSlots = GetGiftSlots()
            };
            
            if (System.IO.File.Exists(SaveNames.FilePath) == false || string.IsNullOrEmpty(System.IO.File.ReadAllText(SaveNames.FilePath)))
            {
                // System.IO.File.CreateText(SaveNames.FilePath);
                Save(playerProgression);
            }

            var file = System.IO.File.ReadAllText(SaveNames.FilePath);
            playerProgression = JsonUtility.FromJson<PlayerProgressionModel>(file);
            
            return playerProgression;
        }
        
        private string[] GetGiftSlots() =>
            _levelConfigurationService.GiftSlots
                .Where(x => x.OpenFromStart)
                .Select(x => x.Title)
                .ToArray();

        public void Dispose()
        {
            
        }
    }
}