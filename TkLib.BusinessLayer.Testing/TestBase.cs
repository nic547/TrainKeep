using Xunit;

using TkLib.Dal;

namespace TkLib.BusinessLayer.Testing
{
    public class TestBase
    {
        private static bool IsFirstExecution = true;

        public TestBase()
        {
            if (IsFirstExecution)
            {
                using(var context = new TrainKeepContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    IsFirstExecution = false;
                }
            }
        }
    }
}
