public class HomePointStrategy : ITargetStrategy
{
  public void OnTargetReached(BotCollector bot)
  {
    bot.ResourcesGrabber.DisableGraberCollider();
    bot.SetAvailable(true);
  }
}