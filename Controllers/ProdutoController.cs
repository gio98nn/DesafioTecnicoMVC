using Microsoft.AspNetCore.Mvc;
using produtoMVC.Models;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace produtoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5207/api/")
            };
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("produtos");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<ProdutoViewModel>>();
                return View(data);
            }

            return View(new List<ProdutoViewModel>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            // Verifica se o modelo passou na validação
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            _logger.LogInformation($"[MVC] Criando produto: {JsonSerializer.Serialize(produto)}");

            // Envia a requisição POST para a API (lembre-se: o BaseAddress já inclui "api/")
            var response = await _httpClient.PostAsJsonAsync("produtos", produto);

            _logger.LogInformation($"[MVC] Status da resposta da API: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Se ocorrer erro, registra o conteúdo retornado e adiciona erro ao ModelState
                var erro = await response.Content.ReadAsStringAsync();
                _logger.LogError($"[MVC] Erro ao criar produto: {erro}");
                ModelState.AddModelError(string.Empty, "Erro ao criar o produto.");
                return View(produto);
            }
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"produtos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var produto = await response.Content.ReadFromJsonAsync<ProdutoViewModel>();
                return View(produto);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            _logger.LogInformation($"[MVC] Editando produto: {JsonSerializer.Serialize(produto)}");

            var response = await _httpClient.PutAsJsonAsync($"produtos/{id}", produto);

            _logger.LogInformation($"[MVC] Status da resposta da API: {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();
                _logger.LogError($"[MVC] Erro ao editar produto: {erro}");
                ModelState.AddModelError(string.Empty, "Erro ao editar produto: " + erro);
                return View(produto);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"produtos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var produto = await response.Content.ReadFromJsonAsync<ProdutoViewModel>();
                return View(produto);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"produtos/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return BadRequest();
        }
    }
}
