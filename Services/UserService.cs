using DancellApp.Interfaces;
using DancellApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace DancellApp.Services
{
    public class UserService
    {
        string urlBase = Application.Current.Resources["UrlBase"].ToString();

        public async Task<IAjaxResult> GetByUserAndPassword(string controller ,string userName, string password)
        {
            IAjaxResult resultAjax = new IAjaxResult();
            try
            {
                var model = new Dictionary<string, string>
                {
                    {"UserName", userName},
                    {"PassWord",password },
                };
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                var response = await client.PostAsync(controller, new StringContent(string.Format("UserName={0}&PassWord={1}",
                    userName, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
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

        public async Task<IAjaxResult> EditProfileUser(string controller, Usuario usuario)
        {
            IAjaxResult resultAjax = new IAjaxResult();
            try
            {
                var request = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
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
