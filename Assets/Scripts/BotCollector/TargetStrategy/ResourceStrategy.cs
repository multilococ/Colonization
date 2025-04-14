public class ResourceStrategy : ITargetStrategy
{
  public void OnTargetReached(BotCollector bot)
  {
    bot.ResourcesGrabber.EnableGraberCollider();
    bot.SetAvailable(true);
  }
}