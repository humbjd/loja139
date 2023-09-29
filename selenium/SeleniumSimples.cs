// 1 - Namespace - Pacote - Grupo de Classe - Workspace
namespace SeleniumSimples;

// 2 - Bibliotecas - Dependencias
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


// 3 - Classe
[TestFixture] // Configura como uma classe de teste
public class AdicionarProdutoNoCarrinhoTest{
// 3.1 - Atributos - Caracteristicas - Campos
private IWebDriver driver; // objeto do Selenium WebDriver

// 3.2 - Função ou Método de Apoio


// 3.3 - Configurações de Antes do Teste
[SetUp] // Configura um método para ser executado antes dos testes
public void Before(){
    // Faz o download e instalação da versão mais recente do ChromeDriver - Instanciando o ChromeDriver
    new DriverManager().SetUpDriver(new ChromeConfig());
    driver = new ChromeDriver(); // Instancia o objeto do Selenium como Chrome
    driver.Manage().Window.Maximize(); // Maximiza a janela do navegador
    // Configura uma espera de 5 segundos para qualquer elemento aparecer
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);



} // Fim do Before


// 3.4 - Configurações de Depois do Teste
[TearDown] // Configura um método para ser usado depois dos testes
public void After(){
    driver.Quit(); // Destruir o objeto do Selenium na memória
} // Fim do After

// 3.5 - O(s) Teste(s)
[Test] // Indica que é um método de teste
public void Login(){
    // Abrir o navegador e acessar o site
    driver.Navigate().GoToUrl("https://www.saucedemo.com");
    //Thread.Sleep(2000); // Pausa forçada - remover antes de publicar

    // preencher o usuario
    driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
    // preencher a senha 
    driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
    // clicar no botão Login
    driver.FindElement(By.CssSelector("input.submit-button.btn_action")).Click();

    // Verificar se fizemos o login no sistema, confirmando um texto ancora
    Assert.AreEqual(driver.FindElement(By.CssSelector("span.title")).Text, "Products");


    Thread.Sleep(2000);



}// Fim do Login




} // Fim da classe

