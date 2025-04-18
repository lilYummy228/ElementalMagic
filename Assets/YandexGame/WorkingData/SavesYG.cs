﻿namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public bool[] IsLevelPassed = new bool[7];
        public bool IsFirstLaunch = true;
        public float MusicVolume = 1.0f;
        public float SoundsVolume = 1.0f;
        public bool IsMusicOn = true;
        public bool IsSoundsOn = true;
        public int HealthPowerUps = 0;
        public int DamagePowerUps = 0;
        public int GridPowerUps = 0;
        public int CoinsCount = 0;
        public string Language = default;
        
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива           
            openLevels[1] = true;
        }
    }
}
