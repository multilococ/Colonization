public class SpawnBaseStrategy : ITargetStrategy
{
  public void OnTargetReached(BotCollector bot)
  {
    bot.SpawnBase(bot.transform.position);
  }
}