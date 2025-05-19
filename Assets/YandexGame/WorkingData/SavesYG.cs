namespace YG
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

        public bool[] isLevelPassed = new bool[7];
        public bool isFirstLaunch = true;
        public float musicVolume = 1.0f;
        public float soundsVolume = 1.0f;
        public bool isMusicOn = true;
        public bool isSoundsOn = true;
        public int healthPowerUps = 0;
        public int damagePowerUps = 0;
        public int gridPowerUps = 0;
        public int coinsCount = 0;
        public string chosenLanguage = default;
        
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива           
            openLevels[1] = true;
        }
    }
}
