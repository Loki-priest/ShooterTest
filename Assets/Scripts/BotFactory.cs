

public class BotFactory : Factory
{
    GameSettings.EnemiesSettings botSettings; //all bot settings

    public BotFactory(GameSettings.EnemiesSettings _botSettings)
    {
        botSettings = _botSettings;
    }

    public override Bot CreateBot()
    {
        Bot bot = Bot.Instantiate(botSettings.botPrefab);
        bot.InitMe(botSettings);
        return bot;
    }


}
