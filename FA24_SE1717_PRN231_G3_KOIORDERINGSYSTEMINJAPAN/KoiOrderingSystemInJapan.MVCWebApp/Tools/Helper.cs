using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Request.Auths;
using KoiOrderingSystemInJapan.Service.Base;
using Newtonsoft.Json;
using System.Text;

namespace KoiOrderingSystemInJapan.MVCWebApp.Tools
{
    public static class Helper
    {
        public static async Task<bool> IsUserGuestAsync(string token)
        {
            using (var httpClient = new HttpClient())
            {
                // Tạo đối tượng TokenRequest
                var tokenRequest = new TokenRequest { Token = token };

                // Chuyển đổi đối tượng thành JSON
                var jsonContent = JsonConvert.SerializeObject(tokenRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST với nội dung JSON
                using (var response = await httpClient.PostAsync(Const.APIEndPoint + "Users/decode-token", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(responseContent);

                        if (result != null && result.Data != null)
                        {
                            // Kiểm tra dữ liệu trả về
                            var data = JsonConvert.DeserializeObject<DecodedToken>(result.Data.ToString());
                            if (data != null)
                            {
                                // Kiểm tra điều kiện để xác định xem người dùng có phải là guest hay không
                                return data.Name != null && data.Name.Equals("customer", StringComparison.OrdinalIgnoreCase);
                            }
                        }
                    }
                }
            }
            // Nếu không có phản hồi thành công hoặc không tìm thấy thông tin, coi như không phải guest
            return false;
        }

    }
}
