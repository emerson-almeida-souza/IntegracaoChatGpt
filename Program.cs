using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


class Program
{
    static async Task Main(string[] args)
    {
        // definir o URL da API do ChatGPT
        string url = "https://api.openai.com/v1/completions";

        // definir o token de autenticação da API do ChatGPT
        string token = "Seu TOKEN";

        // criar um objeto HttpClient
        HttpClient client = new HttpClient();

        // criar um objeto HttpRequestMessage para representar a requisição POST
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

        // adicionar o token de autenticação no cabeçalho da requisição
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        // adicionar os parâmetros da requisição no corpo da mensagem
        var parameters = new
        {
            model = "text-davinci-003",
            prompt = "Texto de exemplo",
            max_tokens = 200,
            temperature = 0
        };

        request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(parameters), System.Text.Encoding.UTF8, "application/json");

        // enviar a requisição para a API do ChatGPT e obter a resposta
        HttpResponseMessage response = await client.SendAsync(request);

        // ler o conteúdo da resposta como uma string
        string responseContent = await response.Content.ReadAsStringAsync();

        // exibir o conteúdo da resposta no console
        Console.WriteLine(responseContent);
    }
}
