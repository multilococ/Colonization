public class ResourceStrategy : ITargetStrategy
{
    public void ArrivedOnTarget(BotCollector bot)
    {
       bot.EnableGraber();
    }
}
