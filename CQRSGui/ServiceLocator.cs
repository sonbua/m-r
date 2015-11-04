using SimpleCQRS.Bus;

namespace CQRSGui
{
    public static class ServiceLocator
    {
        public static FakeBus Bus { get; set; }
    }
}
