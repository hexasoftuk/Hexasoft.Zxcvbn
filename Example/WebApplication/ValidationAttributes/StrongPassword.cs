using Hexasoft.Zxcvbn;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class StrongPassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value as string;

            if (string.IsNullOrEmpty(password))
                return new ValidationResult("Password can't be empty.");

            var estimator = new ZxcvbnEstimator();
            var result = estimator.EstimateStrength(password);

            if (result.Score < 3)
            {
                string warning = !string.IsNullOrWhiteSpace(result.Feedback.Warning)
                    ? " " + result.Feedback.Warning.TrimEnd('.') + "."
                    : "";

                string suggestions = string.Join(" ", result.Feedback.Suggestions.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.TrimEnd('.') + "."));

                if (!string.IsNullOrWhiteSpace(suggestions))
                    suggestions = " " + suggestions;

                return new ValidationResult(string.Join("", "Password is not strong enough.", warning, suggestions));
            }

            return ValidationResult.Success;
        }
    }
}