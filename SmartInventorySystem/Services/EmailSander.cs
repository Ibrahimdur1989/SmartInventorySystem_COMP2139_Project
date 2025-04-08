﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SmartInventorySystem.Services;

public class EmailSender : IEmailSender
{
    
    private readonly string _sendGridApiKey;

    public EmailSender(IConfiguration configuration)
    {
        _sendGridApiKey = configuration["sendGrid:ApiKey"] 
                          ??  throw new ArgumentNullException("SendGrid Key is missing");
    }


    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("ibrahimdur1989@gmail.com", "PM Tool Default Sender");
            var to = new EmailAddress(email);
            var msg = MailHelper
                .CreateSingleEmail(from, to, subject, "Welcome to PM Tool Inc", message);
            
            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Body.ReadAsStringAsync();
                Console.WriteLine($"An erorr occurred while sending email: {errorMessage}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An erorr occurred while sending email: {ex.Message}");
            throw;
        }
        
        
        
    }
    
}