public class HomePointStrategy : ITargetStrategy
{
    public void ArrivedOnTarget(BotCollector bot)
    {
        bot.DisableGraber();
    }
}