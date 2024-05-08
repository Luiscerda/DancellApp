using DancellApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.Services
{
    public class ComitionService
    {
        readonly string urlBase = Application.Current.Resources["UrlBase"].ToString();

        public async Task<IAjaxResult> GetComitionByIdPos(string controller, string userName, string password, string idPos)
        {
            IAjaxResult resultAjax = new();
            try
            {
                var model = new Dictionary<string, string>
                {
                    {"UserName", userName},
                    {"PassWord",password },
                    {"IdPos",idPos }
                };
                var content = new FormUrlEncodedContent(model);
                var client = new HttpClient();
                var response = await client.PostAsync(urlBase + controller, content);
                if (!response.IsSuccessStatusCode)
                {
                    return new IAjaxResult
                    {
                        Msj = response.RequestMessage.ToString(),
                        Is_Error = true,
                    };
                }
                var result = await response.Content.ReadAsStringAsync();
                resultAjax = JsonConvert.DeserializeObject<IAjaxResult>(result);
            }
            catch (Exception ex)
            {
                resultAjax.Msj = ex.Message;
                resultAjax.Is_Error = true;
            }
            return resultAjax;
        }
    }
}
