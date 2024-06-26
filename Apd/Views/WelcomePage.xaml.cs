using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Apd
{
    public partial class WelcomePage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private bool isRegistering = true;
        private const string ApiBaseUrl = "https://apdwebapi.somee.com/api";

        public WelcomePage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            if (isRegistering)
            {
                // Código de registro
                int language = languagePicker.SelectedIndex == 0 ? 1 : 2;
                string email = emailEntry.Text;
                string password = passwordEntry.Text;
                string confirmPassword = confirmPasswordEntry.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Error", "All fields are required", "OK");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    await DisplayAlert("Error", "Invalid email format", "OK");
                    return;
                }

                if (password != confirmPassword)
                {
                    await DisplayAlert("Error", "Passwords do not match", "OK");
                    return;
                }

                string hashedPassword = GetSHA256(password);

                var user = new
                {
                    Language = language,
                    Email = email,
                    PasswordHash = hashedPassword
                };

                string json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await _httpClient.PostAsync($"{ApiBaseUrl}/Users/register", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // La API devuelve solo el email del usuario registrado
                        await DisplayAlert("Success", $"Account created for {responseBody}", "OK");

                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Failed to create account: {responseBody}", "OK");
                    }
                }
                catch (JsonException ex)
                {
                    await DisplayAlert("Error", $"JSON error: {ex.Message}", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Unexpected error: {ex.Message}", "OK");
                }
            }
            else
            {
                string email = emailEntry.Text;
                string password = passwordEntry.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Error", "All fields are required", "OK");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    await DisplayAlert("Error", "Invalid email format", "OK");
                    return;
                }

                var loginData = new
                {
                    Email = email,
                    Password = password // Enviamos la contraseña en texto plano
                };

                string json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await _httpClient.PostAsync($"{ApiBaseUrl}/Users/login", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var tokens = JsonSerializer.Deserialize<TokenResponse>(responseBody);

                        if (tokens != null && !string.IsNullOrEmpty(tokens.AccessToken) && !string.IsNullOrEmpty(tokens.RefreshToken))
                        {
                            await SecureStorage.SetAsync("access_token", tokens.AccessToken);
                            await SecureStorage.SetAsync("refresh_token", tokens.RefreshToken);
                            await SecureStorage.SetAsync("user_id", tokens.UserId.ToString()); // Guarda el ID del usuario

                            Preferences.Set(StorageKeys.IsFirstTimeKey, false);
                            Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, false);

                            await Navigation.PushAsync(new MainPage());
                        }
                        else
                        {
                            await DisplayAlert("Error", "Invalid response from the server", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Failed to log in: {responseBody}", "OK");
                    }
                }
                catch (JsonException ex)
                {
                    await DisplayAlert("Error", $"JSON error: {ex.Message}", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Unexpected error: {ex.Message}", "OK");
                }
            }
        }

        private void OnToggleButtonClicked(object sender, EventArgs e)
        {
            isRegistering = !isRegistering;
            if (isRegistering)
            {
                titleLabel.Text = "Choose your language";
                languagePicker.IsVisible = true;
                confirmPasswordEntry.IsVisible = true;
                submitButton.Text = "Create Account";
                toggleButton.Text = "Already have an account?";
            }
            else
            {
                titleLabel.Text = "Log In";
                languagePicker.IsVisible = false;
                confirmPasswordEntry.IsVisible = false;
                submitButton.Text = "Log In";
                toggleButton.Text = "Don't have an account?";
            }
        }

        public static string GetSHA256(string str)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.AppendFormat("{0:x2}", b);
            }
            return builder.ToString();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private class TokenResponse
        {
            [JsonPropertyName("userId")]
            public int UserId { get; set; } // Cambiado a int

            [JsonPropertyName("accessToken")]
            public string AccessToken { get; set; }

            [JsonPropertyName("refreshToken")]
            public string RefreshToken { get; set; }
        }
    }
}
