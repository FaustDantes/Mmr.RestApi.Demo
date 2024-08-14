namespace Mmr.Universal
{
    public static class UniversalService
    {

        public static int CalculateAge()
        {
            return 10000 + DateTime.UtcNow.Second;
        }

    }
}
