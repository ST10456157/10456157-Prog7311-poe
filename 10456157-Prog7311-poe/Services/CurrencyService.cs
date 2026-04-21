using Newtonsoft.Json;

namespace _10456157_Prog7311_poe.Services
{
    public class CurrencyService
    {
        public async Task<double> ConvertUsdToZar(double amount)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync("https://api.exchangerate-api.com/v4/latest/USD");

                dynamic data = JsonConvert.DeserializeObject(response);
                return amount * data.rates.ZAR;
            }
            catch
            {
                return 0;
            }
        }
    }
}
