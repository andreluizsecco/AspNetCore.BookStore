using System;
using System.Linq;
using FluentValidation.Results;
using MediatR;

namespace AspNetCore.Bookstore.Domain.Notifications
{
    public class Notification : INotification
    {
        public string Message { get; private set; }

        public Notification(string message) =>
            Message = message;
        
        public Notification(ValidationResult result) =>
            Message = string.Join(Environment.NewLine, result.Errors?.Select(x => x.ErrorMessage));        
    }
}