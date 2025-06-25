using System.Text.RegularExpressions;

namespace WebApplication11.Models
{
    public static class PasswordHelper
    {
        public static int CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            int score = 0;

            // Uzunluk kontrolü
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;

            // Karakter türü kontrolleri
            if (Regex.IsMatch(password, @"[a-z]")) score++; // Küçük harf
            if (Regex.IsMatch(password, @"[A-Z]")) score++; // Büyük harf
            if (Regex.IsMatch(password, @"\d")) score++;    // Sayı
            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?\"":{}|<>]")) score++; // Sembol

            // Skor değerlendirmesi
            if (score <= 2) return 0; // Weak
            if (score <= 4) return 1; // Medium
            return 2; // Strong
        }

        public static string GetPasswordStrengthText(int strength)
        {
            switch (strength)
            {
                case 0: return "Zayıf";
                case 1: return "Orta";
                case 2: return "Güçlü";
                default: return "Bilinmiyor";
            }
        }

        public static string GetPasswordStrengthColor(int strength)
        {
            switch (strength)
            {
                case 0: return "danger";
                case 1: return "warning";
                case 2: return "success";
                default: return "secondary";
            }
        }

        public static string GetPasswordStrengthIcon(int strength)
        {
            switch (strength)
            {
                case 0: return "glyphicon-remove-circle";
                case 1: return "glyphicon-exclamation-sign";
                case 2: return "glyphicon-ok-circle";
                default: return "glyphicon-question-sign";
            }
        }

        public static int GetPasswordStrengthPercentage(int strength)
        {
            switch (strength)
            {
                case 0: return 25;
                case 1: return 65;
                case 2: return 100;
                default: return 0;
            }
        }
    }
}