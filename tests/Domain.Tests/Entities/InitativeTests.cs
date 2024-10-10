

using Domain.Entities;

namespace Domain.Tests.Entities
{
    public class IniativeTest
    {
        [Fact]
        public void Initative_TryCheckCreateWithNewInstance_ReturnFalse()
        {
            var initative = new Initiative();
            bool result = initative.TryCheckCreate();

            int a = 10;
            int b = 100;
            (a, b) = (b, a);

            string c = initative switch
            {
                { Name: "TOTO" } => "wedwewd",
                null => "weuyiydwewd",
                _ => "efwefew"
            };

            Assert.False(result, "Can't create empty Initative");
        }
    }
}