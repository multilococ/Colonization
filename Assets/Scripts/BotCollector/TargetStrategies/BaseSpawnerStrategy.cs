public class BaseSpawnerStrategy : ITargetStrategy
{
    public void ArrivedOnTarget(BotCollector bot)
    {
        bot.SpawnBase(bot.transform.position);
    }
}
